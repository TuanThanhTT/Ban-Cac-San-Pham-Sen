using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Models;
using MuaBanSanPhamSen_BabyLotus.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmHoaDon : UserControl
    {
        private Employee employ;
        private FrmMain main;
        public FrmHoaDon(Employee employe , FrmMain  main)
        {
            this.employ = employe;
            this.main = main;
            InitializeComponent();
            LoadTableHoaDon();
        }


        public async void LoadTableHoaDon()
        {
            try
            {
                var ds = await getDanhSachHoaDonDaDuyet();
                if(ds != null)
                {
                    var data = new DataTable();
                    data.Columns.Add("MaHoaDon", typeof(int));
                    data.Columns.Add("MaKhachHang",typeof(int));
                    data.Columns.Add("TongTien", typeof(Decimal));
                    data.Columns.Add("NgayLap",typeof(string));
                    data.Columns.Add("MaNhanVien",typeof(string));


                    if (ds.Count > 0)
                    {
                        foreach(var item in ds)
                        {
                            data.Rows.Add(item.maHoaDon, item.maUser, item.tongTien, item.ngayLap.ToString("dd/MM/yyyy"), item.maNhanVien);
                        }
                        GvHoaDon.DataSource = data; 
                    }


                }


            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);    
            }
        }
        public  void LoadTableHoaDonTheoDanhSach(List<XemThongTinHoaDon>list)
        {
            try
            {
                var ds = list;
                if (ds != null)
                {
                    var data = new DataTable();
                    data.Columns.Add("MaHoaDon", typeof(int));
                    data.Columns.Add("MaKhachHang", typeof(int));
                    data.Columns.Add("TongTien", typeof(Decimal));
                    data.Columns.Add("NgayLap", typeof(string));
                    data.Columns.Add("MaNhanVien", typeof(string));


                    if (ds.Count > 0)
                    {
                        foreach (var item in ds)
                        {
                            data.Rows.Add(item.maHoaDon, item.maUser, item.tongTien, item.ngayLap.ToString("dd/MM/yyyy"), item.maNhanVien);
                        }
                        GvHoaDon.DataSource = data;
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public  async void LoadTableHoaDonTheoMa(int ma)
        {
            try
            {
                var ds = await getDanhSachHoaDonDaDuyetTheoMa(ma);
                if (ds != null)
                {
                    var data = new DataTable();
                    data.Columns.Add("MaHoaDon", typeof(int));
                    data.Columns.Add("MaKhachHang", typeof(int));
                    data.Columns.Add("TongTien", typeof(Decimal));
                    data.Columns.Add("NgayLap", typeof(string));
                    data.Columns.Add("MaNhanVien", typeof(string));


                    if (ds.Count > 0)
                    {
                        foreach (var item in ds)
                        {
                            data.Rows.Add(item.maHoaDon, item.maUser, item.tongTien, item.ngayLap.ToString("dd/MM/yyyy"), item.maNhanVien);
                        }
                        GvHoaDon.DataSource = data;
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<List<XemThongTinHoaDon>> getDanhSachHoaDonDaDuyet()
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {
                    var ds = await (from user in context.Users
                             join donhang in context.Orders on user.UserId equals donhang.UserId
                             join ct in context.OrderItems on donhang.OrderId equals ct.OrderId
                             join emp in context.Employees on donhang.EmployeeId equals emp.EmployeeId
                             where donhang.EmployeeId != null
                             select new XemThongTinHoaDon
                             {
                                 ID = donhang.OrderId,
                                 maUser = user.UserId,
                                 maHoaDon = donhang.OrderId,
                                 maNhanVien = emp.EmployeeId,
                                 ngayLap = donhang.CreateDate,
                                 tenNguoiDung = user.FullName,
                                 tongTien = donhang.totalAmount,
                                 tenNhanVien = emp.FullName
                                
                             }).Distinct().ToListAsync();
                    if (ds != null) return ds;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }


        public async Task<List<XemThongTinHoaDon>> getDanhSachHoaDonDaDuyetTheoMa(int ma)
        {
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    var ds = await (from user in context.Users
                                    join donhang in context.Orders on user.UserId equals donhang.UserId
                                    join ct in context.OrderItems on donhang.OrderId equals ct.OrderId
                                    join emp in context.Employees on donhang.EmployeeId equals emp.EmployeeId
                                    where donhang.EmployeeId != null && user.UserId == ma
                                    select new XemThongTinHoaDon
                                    {
                                        ID = donhang.OrderId,
                                        maUser = user.UserId,
                                        maHoaDon = donhang.OrderId,
                                        maNhanVien = emp.EmployeeId,
                                        ngayLap = donhang.CreateDate,
                                        tenNguoiDung = user.FullName,
                                        tongTien = donhang.totalAmount,
                                        tenNhanVien = emp.FullName

                                    }).Distinct().ToListAsync();
                    if (ds != null) return ds;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }




        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GvHoaDon.CurrentCell.RowIndex;
                var maHoaDon = GvHoaDon.Rows[selected].Cells[0].Value.ToString();

                var maKH = GvHoaDon.Rows[selected].Cells[1].Value.ToString();
                var maNV = GvHoaDon.Rows[selected].Cells[4].Value.ToString();


                using (var context = new BanSanPhamSen())
                {
                    var nguoiDung = context.Users.Find(Convert.ToInt32(maKH));
                    if(nguoiDung!= null) { 
                        txtEmail.Text = nguoiDung.Email;
                        txtMaKH.Text = nguoiDung.UserId+"";
                        txtDiaChiNhan.Text = nguoiDung.Address;
                        txtTenKH.Text = nguoiDung.FullName;
                        txtSDT.Text = nguoiDung.PhoneNumber;
                      //  txtDiaChi.Text = nguoiDung.Address;

                    }
                    var nv = context.Employees.Find(Convert.ToInt32(maNV));
                    if(nv!= null)
                    {
                        txtMaNhanVien.Text = nv.EmployeeId+"";
                        txtTenNhanVien.Text = nv.FullName;
                    }

                    var donhang = context.Orders.Find(Convert.ToInt32(maHoaDon));
                    if (donhang!=null)
                    {
                        txtNgayLap.Text = donhang.CreateDate.ToString("dd/MM/yyyy");
                        txtDiaChi.Text = donhang.OrderId + "";
                    }

                    var dsDonHang = context.OrderItems.Where(s=>s.OrderId.ToString() == maHoaDon).ToList();
                    if(dsDonHang!= null && dsDonHang.Count>0) {

                        var listitem = new List<Product>();
                        foreach(var item in dsDonHang)
                        {
                            var pro = context.Product.Find(item.ProductId);
                            if(pro!= null)
                            {
                                listitem.Add(pro);  
                            }
                        }
                        if(listitem.Count>0)
                        {
                            var data = new DataTable();
                            data.Columns.Add("MaSanPham", typeof(int));
                            data.Columns.Add("TenSanPham",typeof(string));
                            data.Columns.Add("GiaBan",typeof(Decimal));
                            data.Columns.Add("SoLuong", typeof(int));

                            foreach(var item in listitem) {
                                var dh = dsDonHang.Where(s => s.ProductId == item.productId).FirstOrDefault();
                                if(dh!=null) {
                                    data.Rows.Add(item.productId, item.productName, item.price, dh.Quantity);
                                }
                            }
                            GVDanHSachSanPham.DataSource = data;    
                        }
                    }


                }


             



                



            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDuyetHoaDon_Click(object sender, EventArgs e)
        {
            main.addTabMain();
            var form = new FrmDuyetHoaDon(employ);
            main.addTabPage(main.tabMain, form);
        }

        private void GvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string chuoiTim = txtTim.Text.Trim();   
                if(string.IsNullOrEmpty(chuoiTim) )
                {
                    return;
                }
                int idKhachHang = -1;
                if(int.TryParse(chuoiTim, out idKhachHang) )
                {
                    idKhachHang  = int.Parse(chuoiTim);
                }
                else
                {
                    idKhachHang = -1;
                }

                using(var context = new BanSanPhamSen())
                {
                    if(idKhachHang == -1)
                    {
                        //tim theo ten

                        var ds = await getDanhSachHoaDonDaDuyet();
                        var list = new List<XemThongTinHoaDon>();   
                        if(ds!= null && ds.Count  >0)
                        {
                            foreach(var item in ds)
                            {
                                if(ContainsIgnoreCaseAndPunctuation(item.tenNguoiDung, chuoiTim))
                                {
                                    list.Add(item);
                                }
                            }
                            if(list.Count > 0)
                            {
                                LoadTableHoaDonTheoDanhSach(list);
                            }

                        }

                    }
                    else
                    {
                        //tim theo ma
                         LoadTableHoaDonTheoMa(idKhachHang);


                    }
                }



            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        public static bool ContainsIgnoreCaseAndPunctuation(string source, string target)
        {
            string pattern = @"[^\w\s]";
            source = Regex.Replace(source, pattern, "");
            target = Regex.Replace(target, pattern, "");
            return source.IndexOf(target, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                txtEmail.Text = "";
                txtMaKH.Text = "";
                txtDiaChiNhan.Text = "";
                txtTenKH.Text = "";
                txtSDT.Text = "";
                txtDiaChi.Text = "";

                txtMaNhanVien.Text = "";

                txtTenNhanVien.Text = "";
                txtNgayLap.Text = "";

                txtTim.Text = "";

                GVDanHSachSanPham.Controls.Clear();
                GVDanHSachSanPham.DataSource = null;


                LoadTableHoaDon();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txtDiaChi.Text.Trim();
                if(!string.IsNullOrEmpty(maHD) )
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|Excel 97-2003 files (*.xls)|*.xls";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        if(File.Exists(filePath) )
                        {
                            MessageBox.Show("Đường dẫn đã tồn tại file", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        FileServic file = new FileServic();
                        
                        if(file.XuatHoaDon(Convert.ToInt32(maHD), filePath))
                        {
                            MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }

              

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
