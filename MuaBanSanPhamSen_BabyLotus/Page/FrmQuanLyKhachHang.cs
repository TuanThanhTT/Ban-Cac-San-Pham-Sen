using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmQuanLyKhachHang : UserControl
    {
        public FrmQuanLyKhachHang()
        {
            InitializeComponent();
            loadTableKhachHang();
        }


        public async void loadTableKhachHang()
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Name", typeof(string));
                data.Columns.Add("Email", typeof(string));
                data.Columns.Add("Phone", typeof(string));
                data.Columns.Add("Gender", typeof(string));
                data.Columns.Add("DiaChi", typeof(string));

                GVKhachHang.DataSource = null;

                var ds = await getDanhSachUser();
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.UserId, vi.FullName, vi.Email, vi.PhoneNumber, vi.Gender, vi.Address);
                        }

                    }
                    GVKhachHang.DataSource = data;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public  void loadTableKhachHangBangDanhSach(List<User>dsTim)
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Name", typeof(string));
                data.Columns.Add("Email", typeof(string));
                data.Columns.Add("Phone", typeof(string));
                data.Columns.Add("Gender", typeof(string));
                data.Columns.Add("DiaChi", typeof(string));


               
                var ds = dsTim;
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.UserId, vi.FullName, vi.Email, vi.PhoneNumber, vi.Gender, vi.Address);
                        }

                    }
                    GVKhachHang.DataSource = data;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<List<User>> getDanhSachUser()
        {
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    return await Task.Run(() =>
                    {
                        return context.Users.Where(op => op.IsDelete == false).ToList();
                    });
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return null;
        }


        private void FrmQuanLyKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnXemChonKH_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GVKhachHang.CurrentCell.RowIndex;
              
                var maKH = GVKhachHang.Rows[selected].Cells[0].Value.ToString();
                var tenKH = GVKhachHang.Rows[selected].Cells[1].Value.ToString();
                var email = (GVKhachHang.Rows[selected].Cells[2].Value.ToString());
                var phone = (GVKhachHang.Rows[selected].Cells[3].Value.ToString());
                var gioiTinh = GVKhachHang.Rows[selected].Cells[4].Value.ToString();
                var diaChi = GVKhachHang.Rows[selected].Cells[5].Value.ToString();


                txtDiaChi.Text = diaChi;
                txtDienThoai.Text = phone;
                txtMaKH.Text = maKH;
                txtTenKH.Text = tenKH;
                txtEmail.Text = email;
                txtGioiTinh.Text = gioiTinh;

                txtHoaDon.Text = "0";
                txtThanhTien.Text = "0";
                using(var context = new BanSanPhamSen())
                {
                    var acc = context.Account.Where(op=>op.UserAccountId.ToString() == maKH).FirstOrDefault();  
                    if (acc != null)
                    {
                        txtUserName.Text = acc.username;
                        if(!string.IsNullOrEmpty(acc.avartar))
                        {
                            string img = acc.avartar.Trim();
                            string destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", img);
                            

                            if (File.Exists(destFile))
                            {
                               
                                    // Dọn dẹp hình ảnh cũ nếu có
                                    if (txtAvartar.Image != null)
                                    {
                                   
                                         txtAvartar.Image = null;
                                    }

                                // Tải và hiển thị hình ảnh mới
                                txtAvartar.Image = Image.FromFile(destFile);
                                txtAvartar.SizeMode = PictureBoxSizeMode.StretchImage; // Co giãn hình ảnh
                                
                            }
                          
                            
                          



                        }
                    }
                    //so luong hoa don
                    var dsHoaDon = context.Orders.Where(s=>s.UserId.ToString() == maKH).ToList();
                    Decimal tongTien = 0;
                    if(dsHoaDon != null)
                    {
                        txtHoaDon.Text = dsHoaDon.Count() + "";
                        if(dsHoaDon.Count() > 0)
                        {
                            foreach(var item in dsHoaDon)
                            {
                                if (item != null)
                                {
                                    tongTien += item.totalAmount;
                                }
                            }
                            txtThanhTien.Text = tongTien + " vnđ";
                        }
                    }
                }

              


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtKhoaTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txtMaKH.Text.Trim();
                if(string.IsNullOrEmpty(maKH) )
                {
                    return;
                }

                using(var context = new BanSanPhamSen())
                {
                    var user = context.Users.Find(Convert.ToInt32(maKH));
                    if (user != null)
                    {
                        user.IsDelete= true;
                        var acc = context.Account.Where(op=>op.UserAccountId.ToString() == user.UserId.ToString() ).FirstOrDefault();
                        if(acc != null)
                        {
                            acc.IsLocked= true;
                        } 
                        context.SaveChanges();
                        loadTableKhachHang();
                        clear();
                        MessageBox.Show("Khóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void clear()
        {
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtGioiTinh.Text = "";
            txtHoaDon.Text = "";
            txtUserName.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtTim.Text = "";
            txtThanhTien.Text = "";

            if (txtAvartar.Image != null)
            {
              
                txtAvartar.Image = null;
                string fileName = "z6047182807262_7ebb469de6142223ea29ad16e467d8bf.jpg";
                string destFile = Path.Combine(Directory.GetCurrentDirectory(),"Image", Path.GetFileName(fileName));

                if (File.Exists(destFile))
                {
                
                    txtAvartar.Image = Image.FromFile(destFile);
                    txtAvartar.SizeMode = PictureBoxSizeMode.StretchImage;
                    txtAvartar.Visible = true;

                }

            }
           
            btnMoKhoa.Visible = false;
            txtKhoaTaiKhoan.Visible = true;
            loadTableKhachHang();
        }


        public void refresh()
        {
            try
            {
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
                txtEmail.Text = "";
                txtGioiTinh.Text = "";
                txtHoaDon.Text = "";
                txtUserName.Text = "";
                txtMaKH.Text = "";
                txtTenKH.Text = "";
                txtTim.Text = "";
                txtThanhTien.Text = "";

                if (txtAvartar.Image != null)
                {

                    txtAvartar.Image = null;
                    string fileName = "z6047182807262_7ebb469de6142223ea29ad16e467d8bf.jpg";
                    string destFile = Path.Combine(Directory.GetCurrentDirectory(), "Image", Path.GetFileName(fileName));

                    if (File.Exists(destFile))
                    {

                        txtAvartar.Image = Image.FromFile(destFile);
                        txtAvartar.SizeMode = PictureBoxSizeMode.StretchImage;
                        txtAvartar.Visible = true;

                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void GVKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string chuoiTim = txtTim.Text;  
                if(!string.IsNullOrEmpty(chuoiTim))
                {
                    var ds = await getDanhSachNguoiDung(chuoiTim);

                    
                    loadTableKhachHangBangDanhSach(ds); 
                    

                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex+"");
            }

        }


        static bool SoSanhChuoi(string a, string b)
        {
            try
            {
                // Loại bỏ dấu và chuyển về chữ thường
                string aKhongDau = LoaiBoDau(a).ToLower();
                string bKhongDau = LoaiBoDau(b).ToLower();




                if (!aKhongDau.Contains(bKhongDau))
                {
                    return false; // Nếu bất kỳ từ nào không khớp, trả về false
                }

                return true; // Tất cả từ đều khớp
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<User>>getDanhSachNguoiDung(string chuoiTim)
        {
            var dsTim = new List<User>();   

            try
            {
                using (var context = new BanSanPhamSen())
                {
                    int id = -1;
                    if (int.TryParse(chuoiTim, out id))
                    {
                        id = int.Parse(chuoiTim);
                    }
                    else
                    {
                        id = -1;
                    }
                    if (id != -1)
                    {
                        var user = await context.Users.FindAsync(id);
                        if (user != null)
                        {
                            dsTim.Add(user);
                            return dsTim;
                        }
                    }
                    else
                    {
                        var ds = context.Users.Where(op=>op.IsDelete == false).ToList();
                        
                        foreach(var i in ds)
                        {
                            if(SoSanhChuoi(i.FullName, chuoiTim))
                            {
                                dsTim.Add(i);   
                            }
                        }
                        return dsTim;
                    }

                }
            }catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return dsTim;
        }


        static string LoaiBoDau(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            // Chuẩn hóa chuỗi và loại bỏ các dấu
            string normalized = input.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // Trả về chuỗi không dấu
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

     


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            clear();

        }

        private  void btnDanhSachKhoa_Click(object sender, EventArgs e)
        {
            try
            {
               // clear();
               refresh();   
                var ds =  getDanhSachNguoiDungBiKhoa();
               
                loadTableKhachHangBangDanhSach(ds);
                txtKhoaTaiKhoan.Visible = false;
                btnMoKhoa.Visible = true;    


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public  List<User> getDanhSachNguoiDungBiKhoa()
        {
            using (var context = new BanSanPhamSen())
            {
                return  context.Users.Where(op => op.IsDelete == true).ToList();
            }
        }

        private async void btnMoKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txtMaKH.Text.Trim();  
                if (string.IsNullOrEmpty(maKH)) { return; }



                using(var context = new BanSanPhamSen())
                {
                  //  var ds = await context.Users.ToListAsync();
                    //foreach(var item in ds)
                    //{
                    //    if (item.IsDelete)
                    //    {
                    //        item.IsDelete = false;
                    //        var acc = context.Account.Where(op => op.UserAccountId.ToString() == item.UserId.ToString()).FirstOrDefault();
                    //        if (acc != null)
                    //            acc.IsLocked = false;
                    //    }
                            
                    //}
                    var khachHang = context.Users.Find(Convert.ToInt32(maKH));  
                    if (khachHang != null)
                    {
                        var acc = await  context.Account.Where(op => op.UserAccountId.ToString() == khachHang.UserId.ToString()).FirstOrDefaultAsync();
                        if (acc != null) {
                            khachHang.IsDelete = false;
                            acc.IsLocked = false; 
                            await context.SaveChangesAsync();
                            MessageBox.Show("Mở khóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var ds = getDanhSachNguoiDungBiKhoa();

                            loadTableKhachHangBangDanhSach(ds);
                        }
                    }
                   // await context.SaveChangesAsync();
                   // clear();
                    //loadTableKhachHang();
                    //btnMoKhoa.Visible = false;
                    //txtKhoaTaiKhoan.Visible = true;
                }
                                     
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXuatDanhSach_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|Excel 97-2003 files (*.xls)|*.xls";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    if(File.Exists(filePath))
                    {
                        MessageBox.Show("Đường dẫn đã tồn tại file", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FileServic file = new FileServic(); 
                    if(file.XuatDanhSachKHachHang(filePath))
                         MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
