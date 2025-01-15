using BeHatSenLotus.Model;
using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmThongTinTaiKhoan : UserControl
    {
        private User user;
       
        public FrmThongTinTaiKhoan(User user)
        {
            this.user = user;   
            InitializeComponent();
            loadInfo();
            loadCombobox();
        }

        public void loadLaiUser()
        {
            if (user != null)
            {
                using(var context = new BanSanPhamSen())
                {
                    var nguoiDUng = context.Users.Find(user.UserId);
                    if(nguoiDUng != null)
                    {
                        user = nguoiDUng;
                    }
                }
            }
        }


        public async void loadInfo()
        {
            try
            {
                if (user != null)
                {
                    using(var context = new BanSanPhamSen())
                    {
                        var acc = await context.Account.Where(s=>s.UserAccountId  == user.UserId).FirstOrDefaultAsync();   
                        if(acc!= null)
                        {
                            lbFullName.Text = user.FullName;
                            lbNgayTao.Text = acc.createDate.ToString("dd/MM/yyyy");
                            lbUsserName.Text = acc.username;
                            lbUserID.Text = user.UserId.ToString();
                            lbAcountId.Text  = acc.accountId.ToString();
                            txtEmail.Text = user?.Email;    
                            txtPhoneNumber.Text = user?.PhoneNumber;    
                            llbTaiKhaonUsserName.Text = acc.username.ToString();

                            txtEditHoten.Text = user.FullName;
                            txtEditDiaChi.Text = user.Address;
                            txteditPhone.Text = user.PhoneNumber;
                            txtEditEmail.Text = user.Email;
                            int gioiTinh = -1;
                            if (user.Gender == "Nam") gioiTinh = 1;
                            else if(user.Gender == "Nữ")
                            {
                                gioiTinh = 0;
                            }
                               
                            CBBEditGioiTinh.SelectedValue = gioiTinh;

                            if (!string.IsNullOrEmpty(acc.avartar))
                            {
                                var avartar = acc.avartar.Trim();
                                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload",avartar);
                                if (File.Exists(filePath))
                                {
                                    if (PTBAvarTar.Image != null)
                                    {
                                        PTBAvarTar.Image = null;
                                    }

                                    PTBAvarTar.Image = Image.FromFile(filePath);    

                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);    
            }
          
        }


        public void loadCombobox()
        {
            var data = new DataTable();
            data.Columns.Add("Id", typeof(int));
            data.Columns.Add("Name", typeof(string));

            data.Rows.Add(-1, "");
            data.Rows.Add(1, "Nam");
            data.Rows.Add(0, "Nữ");

            CBBEditGioiTinh.DataSource = data;
            CBBEditGioiTinh.DisplayMember= "Name";  
            CBBEditGioiTinh.ValueMember= "Id";    

        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                string hoTen = txtEditHoten.Text;   
                string diaChi = txtEditDiaChi.Text;
                string email = txtEditEmail.Text;   
                int gioiTinh = Convert.ToInt32(CBBEditGioiTinh.SelectedValue.ToString());
                string dienThoai = txtPhoneNumber.Text;

                bool valid = true;


                if(string.IsNullOrEmpty(hoTen)) {

                    ErrTaiKhoan.SetError(txtEditHoten, "Họ tên không được bỏ trống");
                    valid = false;  
                }
                if(string.IsNullOrEmpty(diaChi))
                {
                    ErrTaiKhoan.SetError(txtEditDiaChi, "Địa chỉ không được bỏ trống");
                    valid = false;
                }

                if (!IsValidEmail(email))
                {
                    ErrTaiKhoan.SetError(txtEditEmail, "Email không đúng định dạng");
                    valid = false;
                }
                if (!IsValidPhoneNumber(dienThoai))
                {
                    ErrTaiKhoan.SetError(txtEditDiaChi, "Số điện thoại không đúng định dạng");
                    valid = false;
                }

                if (gioiTinh == -1)
                {
                    ErrTaiKhoan.SetError(CBBEditGioiTinh, "Giới tính không được bỏ trống");
                    valid = false;
                }

                if(!valid)
                {
                    return;
                }
                foreach (var control in ErrTaiKhoan.ContainerControl.Controls)
                {
                    if (control is Control)
                    {
                        ErrTaiKhoan.SetError((Control)control, string.Empty);
                    }
                }

                using(var context = new BanSanPhamSen())
                {
                    var taiKhoan = context.Users.Find(user.UserId);
                    if (taiKhoan != null)
                    {
                        taiKhoan.Address = diaChi;
                        taiKhoan.Email = email;
                        taiKhoan.PhoneNumber = dienThoai;
                        taiKhoan.FullName = hoTen;
                        taiKhoan.Gender = gioiTinh == 1 ? "Nam" : "Nữ";

                        context.SaveChanges();
                        MessageBox.Show("cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadLaiUser();
                        loadInfo(); 


                    }
                }







            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clear()
        {
            
            txtNhapLaiPass.Text = string.Empty; 
            txtPassMoi.Text = string.Empty;
           
        }


        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {

            return phoneNumber[0] == '0' && phoneNumber.Length == 10;
        }

        private void CbHienPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CbHienPass.Checked)
            {
                txtPassMoi.PasswordChar = '\0';
                txtPassMoi.UseSystemPasswordChar= false;
                txtNhapLaiPass.PasswordChar = '\0';
                txtNhapLaiPass.UseSystemPasswordChar = false;
            }
            else
            {
               
                txtPassMoi.UseSystemPasswordChar = true;
                txtNhapLaiPass.UseSystemPasswordChar = true;
            }
        }

        private void btnDoiPass_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = txtPassMoi.Text.Trim();
                string rePass = txtNhapLaiPass.Text.Trim();
                if(string.IsNullOrEmpty(pass) && string.IsNullOrEmpty(rePass))
                {
                    return;
                }
                bool valid = true;
                if (string.IsNullOrEmpty(pass))
                {
                    ErrTaiKhoan.SetError(txtPassMoi, "Mật khẩu không được bỏ trống");
                    valid = false;
                }
                if (string.IsNullOrEmpty(rePass))
                {
                    ErrTaiKhoan.SetError(txtNhapLaiPass, "Xac nhận mật khẩu không được bỏ trống");
                    valid = false;
                }

                if (!valid)
                {
                    return;
                }
                foreach (var control in ErrTaiKhoan.ContainerControl.Controls)
                {
                    if (control is Control)
                    {
                        ErrTaiKhoan.SetError((Control)control, string.Empty);
                    }
                }



                using (var context = new BanSanPhamSen())
                {
                    var acc = context.Account.Where(s=> s.UserAccountId == user.UserId).FirstOrDefault();   
                    if (acc != null)
                    {
                        acc.passs = pass;
                        context.SaveChanges();
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                    } 
                }



            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            try
            {
                if (user != null)
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.InitialDirectory = "c:\\";
                    openFile.Filter = "PNG Files|*.png|GIF Files|*.gif|JPG Files|*.jpg";
                    openFile.Multiselect = false;
                    openFile.FilterIndex = 3;


                    if (openFile.ShowDialog() == DialogResult.OK)
                    {

                        string sourceFile = openFile.FileName;
                        string destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", Path.GetFileName(sourceFile));
                        if (File.Exists(destFile))
                        {
                            destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", Path.GetFileNameWithoutExtension(sourceFile) + "_" + DateTime.Now.Ticks + Path.GetExtension(sourceFile));
                        }
                        File.Copy(sourceFile, destFile, true);
                        using (var context = new BanSanPhamSen())
                        {
                            var nguoiDung = context.Users.Find(user.UserId);
                            if (nguoiDung != null)
                            {
                                var acc = context.Account.Where(s => s.UserAccountId == nguoiDung.UserId).FirstOrDefault();
                                if (acc != null)
                                {
                                    acc.avartar = Path.GetFileName(destFile);
                                    context.SaveChanges();
                                    loadInfo();
                                    loadUser();
                                    MessageBox.Show("Cập nhật ảnh thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);


                                }

                            }


                        }

                    }
                }
                else
                {
                    MessageBox.Show("User null");
                }
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }

        public void loadUser()
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {
                    var nguoiDung = context.Users.Find(user.UserId);
                    if (nguoiDung != null)
                    {
                        user = nguoiDung;
                    }

                }

            }catch(Exception ex) {
            
            MessageBox.Show(ex.Message);
            }
        }
    }
}
