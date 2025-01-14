using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmDonHang : UserControl
    {
        private User user;
        private FrmUser main;

        public FrmDonHang(User user, FrmUser main)
        {
            this.user = user;
            this.main = main;
            InitializeComponent();
            init();
        }

        public void init()
        {
            if (user == null)
            {
                loadGioHang();
                loadTableDonHangChoDuyet();
            }
          
        }
        public async  void loadGioHang()
        {
            try
            {
              
                if (user != null)
                {
                    MessageBox.Show("uset khac null");
                   using(var context = new BanSanPhamSen())
                    {
                        var giohang = await context.GioHangs.Where(s => s.userId == user.UserId).FirstOrDefaultAsync();
                        if (giohang != null)
                        {
                            var danhsachSanPham = await getChiTietDonHang(giohang.Id);
                            if(danhsachSanPham.Count> 0 && danhsachSanPham!= null)
                            {
                                LayoutGioHang.Controls.Clear();
                                Decimal tongTien = 0;
                                foreach (var item in danhsachSanPham)
                                {
                                    var f = new IconDonHang(item, LayoutGioHang,this);
                                    LayoutGioHang.Controls.Add(f);

                                    var sanPham = context.Product.Where(s=>s.productId == item.productId).First();
                                    if (sanPham != null)
                                    {
                                        tongTien += (sanPham.price*item.quantity);
                                    }
                                    

                                }
                             
                                txtTongTienGioHang.Text = tongTien.ToString()+" vnđ";
                            }
                        }
                        else
                        {
                            MessageBox.Show("gio hàng null");
                        }
                    }
            
                }



            }catch(Exception ex)
            {
                MessageBox.Show(ex+"","Lỗi");
            }
        }

        public async Task<List<ChiTietGioHang>> getChiTietDonHang(int idGioHang)
        {
            using(var context = new BanSanPhamSen())
            {
                return await Task.Run(() =>
                {
                    return context.ChiTietGioHang.Where(s=>s.gioHangId == idGioHang).ToList();  
                });
            }
        }




        private void LayoutGioHang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtXoaTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                if (user != null)
                {
                    using (var context = new BanSanPhamSen())
                    {
                        var gioHang = context.GioHangs.Where(s => s.userId == user.UserId).FirstOrDefault();
                        if (gioHang != null)
                        {
                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác Nhận", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                var dsSanPham = context.ChiTietGioHang.Where(s => s.gioHangId == gioHang.Id).ToList();
                                context.ChiTietGioHang.RemoveRange(dsSanPham);
                                context.SaveChanges();
                                MessageBox.Show("Xóa giỏ hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LayoutGioHang.Controls.Clear();
                                txtTongTienGioHang.Text = "";

                            }
                           
                        }
                    }
                }
             




            }catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDatHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (user != null)
                {
                    if (string.IsNullOrEmpty(user.PhoneNumber) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Address))
                    {
                        DialogResult result = MessageBox.Show("Vui lòng cập nhật đầy đủ thông tin để tiến hành mua hàng?", "Xác nhận", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                          
                            main.addTabMain();
                            var form = new FrmThongTinTaiKhoan(user);
                            main.addTabPage(main.tabMain, form);
                        }
                    }
                    else
                    {




                        //tien hanh dat hang
                        using(var context = new BanSanPhamSen())
                        {

                            Decimal tongTien = 0;
                            var gioHang = context.GioHangs.Where(s=>s.userId == user.UserId).FirstOrDefault();  
                            if(gioHang != null)
                            {
                                var dsitem = context.ChiTietGioHang.Where(s=>s.gioHangId == gioHang.Id).ToList();
                                if(dsitem != null) { 
                                    foreach(var item in dsitem) {
                                        var product = context.Product.Find(item.productId);
                                        if(product != null)
                                        {
                                            tongTien += (product.price*item.quantity);
                                        }
                                    }
                                    var donHang = new Order
                                    {
                                        CreateDate = DateTime.Now,
                                        UserId = user.UserId,
                                        totalAmount = tongTien
                                    };
                                    context.Orders.Add(donHang);
                                    context.SaveChanges();
                                    //them oredr item
                                    var listOrder = new List<OrderItem>();  
                                    foreach (var item in dsitem)
                                    {
                                        var product = context.Product.Find(item.productId);
                                        var orderitem = new OrderItem
                                        {
                                            OrderId = donHang.OrderId,
                                            ProductId = product.productId,
                                            Quantity = item.quantity,
                                            totalAmount = (product.price*item.quantity)
                                        };
                                        listOrder.Add(orderitem);   
                                    }
                                    if(listOrder.Count > 0)
                                    {
                                        context.OrderItems.AddRange(listOrder);
                                        context.SaveChanges();
                                        MessageBox.Show("Đặt hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        LayoutGioHang.Controls.Clear();
                                        loadTableDonHangChoDuyet();
                                        txtTongTienGioHang.Text = "";
                                    }
                                }


                            }





                        }
                    }
                }



            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }


        public async void loadTableDonHangChoDuyet()
        {
            try
            {

                var ds = await getDanhSachDonHangChoDuyet();
                if(ds!= null)
                {
                    DataTable data = new DataTable();
                    data.Columns.Add("Id", typeof(int));
                    data.Columns.Add("Name", typeof(string));
                    data.Columns.Add("SoLuong", typeof(int));
                    data.Columns.Add("ThanhTien", typeof(string));
                    data.Columns.Add("NgayDat", typeof(string));
                    data.Columns.Add("TrangThai", typeof(string));

                    if (ds.Count > 0)
                    {
                        foreach(var item in ds)
                        {
                            data.Rows.Add(item.maDonHang, item.tenSanPham, item.soLuong, item.thanhTien, item.ngayTao.ToString("dd/MM/yyyy"), item.trangThai);

                        }

                        GVDonHangDaDuyet.DataSource = data;   

                    }



                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex+"");    
            }
        }


        public async Task<List<DonHangChoDuyet>> getDanhSachDonHangChoDuyet()
        {
            using(var context = new BanSanPhamSen())
            {
                var ds = await (from user in context.Users
                          join donHang in context.Orders on user.UserId equals donHang.UserId
                          join chitiet in context.OrderItems on donHang.OrderId equals chitiet.OrderId
                          join sanPham in context.Product on chitiet.ProductId equals sanPham.productId
                          where user.UserId == this.user.UserId && donHang.EmployeeId == null
                                select new DonHangChoDuyet
                          {
                              maDonHang = donHang.OrderId,
                              maSanPham = sanPham.productId,
                              id = sanPham.productId,
                              ngayTao = donHang.CreateDate,
                              maHoaDonChiTiet = chitiet.OrderItemId,
                              soLuong = chitiet.Quantity,
                              tenSanPham = sanPham.productName,
                              thanhTien = donHang.totalAmount,
                              trangThai = "Chờ Duyệt",

                          }).ToListAsync();
                return ds;  
            }
        }
        public async Task<List<DonHangChoDuyet>> getDanhSachDonHangDaDuyet()
        {
            using (var context = new BanSanPhamSen())
            {
                var ds = await (from user in context.Users
                                join donHang in context.Orders on user.UserId equals donHang.UserId
                                join chitiet in context.OrderItems on donHang.OrderId equals chitiet.OrderId
                                join sanPham in context.Product on chitiet.ProductId equals sanPham.productId
                                where user.UserId == this.user.UserId && donHang.EmployeeId != null
                                select new DonHangChoDuyet
                                {
                                    maDonHang = donHang.OrderId,
                                    maSanPham = sanPham.productId,
                                    id = sanPham.productId,
                                    ngayTao = donHang.CreateDate,
                                    maHoaDonChiTiet = chitiet.OrderItemId,
                                    soLuong = chitiet.Quantity,
                                    tenSanPham = sanPham.productName,
                                    thanhTien = donHang.totalAmount,
                                    trangThai = "Đã Duyệt",

                                }).ToListAsync();
                return ds;
            }
        }
        private void GVDonHangDaDuyet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCapNhatThongTin_Click(object sender, EventArgs e)
        {
            main.addTabMain();
            var form = new FrmThongTinTaiKhoan(user);
            main.addTabPage(main.tabMain, form);
        }

        private void GVDonHangDaDat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public async void loadDonHangDaDuyet()
        {
            try
            {
                var ds = await getDanhSachDonHangChoDuyet();
                if (ds != null)
                {
                    DataTable data = new DataTable();
                    data.Columns.Add("Id", typeof(int));
                    data.Columns.Add("Name", typeof(string));
                    data.Columns.Add("SoLuong", typeof(int));
                    data.Columns.Add("TongTien", typeof(string));
                    data.Columns.Add("NgayDat", typeof(string));
                    data.Columns.Add("TrangThai", typeof(string));

                    if (ds.Count > 0)
                    {
                        foreach (var item in ds)
                        {
                            data.Rows.Add(item.maDonHang, item.tenSanPham, item.soLuong, item.thanhTien, item.ngayTao.ToString("dd/MM/yyyy"), item.trangThai);

                        }

                        GVDonHangDaDat.DataSource = data;

                    }



                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex+"", "Lỗi");
            }
        }
        public void loadThongTinUsser()
        {
            if (user != null)
            {
                using(var c = new BanSanPhamSen())
                {
                    var nguoidung = c.Users.Find(user.UserId);
                    if (nguoidung != null)
                    {
                        user = nguoidung;
                    }
                }
            }
        }
        private  void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadThongTinUsser();
            txtNgayMua.Text = "";
            txtSoLuong.Text = string.Empty;
            txtTongTien.Text = string.Empty;
            txtTenSanPham.Text = string.Empty;
           loadGioHang();
           
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (GVDonHangDaDat.Rows.Count > 0)
                {
                    var selected = GVDonHangDaDat.CurrentCell.RowIndex;
                    var tenSanPham = GVDonHangDaDat.Rows[selected].Cells[1].Value.ToString();

                    var soLuong = GVDonHangDaDat.Rows[selected].Cells[2].Value.ToString();
                    var tongTien = GVDonHangDaDat.Rows[selected].Cells[3].Value.ToString();
                    var ngayMua = GVDonHangDaDat.Rows[selected].Cells[4].Value.ToString();


                    txtNgayMua.Text = ngayMua;
                    txtSoLuong.Text = soLuong;
                    txtTongTien.Text = tongTien + " vnđ";
                    txtTenSanPham.Text = tenSanPham;

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
