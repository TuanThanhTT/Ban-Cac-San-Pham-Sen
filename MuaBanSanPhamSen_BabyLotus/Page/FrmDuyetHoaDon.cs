using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmDuyetHoaDon : UserControl
    {
        private Employee employee;
        public FrmDuyetHoaDon(Employee employee)
        {
            this.employee = employee;
            InitializeComponent();
            loadTableDuyetHoaDon();
        }


        public async void loadTableDuyetHoaDon()
        {
            try
            {

                var ds = await getThongTinDonHangDuyet();

                if(ds != null)
                {
                    var data = new DataTable();
                    data.Columns.Add("Id", typeof(int));
                    data.Columns.Add("MaDon", typeof(string));
                    data.Columns.Add("Name", typeof(string));

                    data.Columns.Add("TongTien", typeof(Decimal));
                    data.Columns.Add("NgayLap",typeof(string));

                    if(ds.Count> 0)
                    {
                        foreach(var item in ds)
                        {
                            data.Rows.Add(item.maKhachHang,item.maDonHang, item.tenKhachHang, item.tongTien, item.ngayDatHang);
                        }
                        GVDuyet.DataSource = data;  
                    }



                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<List<ThongTinDonHangDuyet>> getThongTinDonHangDuyet()
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {
                    var ds = await (from nguoiDung in context.Users
                             join donHang in context.Orders on nguoiDung.UserId equals donHang.UserId
                             join chitiet in context.OrderItems on donHang.OrderId equals chitiet.OrderId
                             join sanPham in context.Product on chitiet.ProductId equals sanPham.productId
                             where donHang.EmployeeId == null
                             select new ThongTinDonHangDuyet
                             {
                                 ID = donHang.OrderId,
                                 maKhachHang = nguoiDung.UserId,
                                 maDonHang = donHang.OrderId,
                                 ngayDatHang = donHang.CreateDate,
                                 tenKhachHang = nguoiDung.FullName,
                                 tongTien = donHang.totalAmount,

                             }).Distinct().ToListAsync();
                    return ds;
                }



            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);    
            }
            return null;
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (GVDuyet.Rows.Count > 0)
                {
                    var selected = GVDuyet.CurrentCell.RowIndex;
                    var maKhacHang = GVDuyet.Rows[selected].Cells[0].Value.ToString();
                    var maDon = GVDuyet.Rows[selected].Cells[1].Value.ToString();
                    var hoTen = GVDuyet.Rows[selected].Cells[2].Value.ToString();
                    var TongTien = GVDuyet.Rows[selected].Cells[3].Value.ToString();
                    var ngayLap = GVDuyet.Rows[selected].Cells[4].Value.ToString();

                    txtTenKh.Text = hoTen;
                    txtMaDon.Text = maDon;
                    txtMaKh.Text = maKhacHang;
                    txtNgayLap.Text = ngayLap;
                    txtTongtien.Text = TongTien;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenKh.Text = "";
            txtMaKh.Text = "";
            txtNgayLap.Text = "";
            txtTongtien.Text = "";
            txtMaDon.Text = "";
        }

        private async void btnDuyetHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                string maDon = txtMaDon.Text.Trim();
                if (string.IsNullOrEmpty(maDon))
                {
                    return;
                }
                int idDonHang = Convert.ToInt32(maDon);

                using (var context = new BanSanPhamSen())
                {
                    // Lấy hóa đơn có tổng tiền lớn nhất chưa được duyệt
                    var hoaDon = await context.Orders
                        .Where(s => s.EmployeeId == null && s.OrderId == idDonHang)
                        .OrderByDescending(s => s.totalAmount)
                        .FirstOrDefaultAsync();

                    if (hoaDon != null)
                    {
                        // Lấy danh sách sản phẩm trong hóa đơn
                        var dsItem = await context.OrderItems
                            .Where(s => s.OrderId == hoaDon.OrderId)
                            .ToListAsync();

                        bool valid = true;

                        // Kiểm tra và xử lý sản phẩm trong hóa đơn
                        foreach (var order in dsItem)
                        {
                            var sanPham = await context.Product.FindAsync(order.ProductId);
                            if (sanPham != null && sanPham.quantity >= order.Quantity)
                            {
                                // Trừ số lượng sản phẩm
                                sanPham.quantity -= order.Quantity;
                            }
                            else
                            {
                                valid = false;
                                MessageBox.Show(
                                    $"Mặt hàng {sanPham?.productName ?? "không xác định"} không đủ số lượng để duyệt",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                break;
                            }
                        }

                        if (valid)
                        {
                            // Gán EmployeeId khi tất cả sản phẩm trong hóa đơn hợp lệ
                            hoaDon.EmployeeId = employee.EmployeeId;
                            MessageBox.Show("Duyệt hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Lưu thay đổi vào database
                            await context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void GVDuyet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
