using BeHatSenLotus.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    public partial class FrmDangKy : Form
    {
        public FrmDangKy()
        {
            InitializeComponent();

          
            this.MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Đăng ký tài khoản";
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            var text = txtHoTen.Text;
            if (!string.IsNullOrEmpty(text))
            {
                txtHoTen.BorderColor = System.Drawing.Color.Black;
                txtHoTen.PlaceholderForeColor = System.Drawing.Color.Gray;
            }
        }

        private void CBHienPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CBHienPass.Checked)
            {
                txtPass.PasswordChar = '\0';
                txtPass.UseSystemPasswordChar= false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
           
        }

        private void txtPass_Validated(object sender, EventArgs e)
        {
            
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
           
        }

        private void txtPass_VisibleChanged(object sender, EventArgs e)
        {
           
        }

        private void txtPass_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void lbLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở form mới
            FrmLogin form = new FrmLogin();
            form.Show();

            // Đóng form hiện tại
           this.Hide();


        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {

                var hoTen = txtHoTen.Text;  
                var email = txtEmail.Text;  
                var pass = txtPass.Text;
                var dienThoai = txtPhone.Text.Trim();
                bool valid = true;
                if (string.IsNullOrEmpty(hoTen))
                {
                    txtHoTen.BorderColor = System.Drawing.Color.Red;
                    txtHoTen.PlaceholderText = "Họ tên không được để trông";
                    txtHoTen.PlaceholderForeColor = System.Drawing.Color.Red;
                    txtHoTen.Text = "";
                    valid = false;
                }
                if(!IsValidEmail(email))
                {
                    txtEmail.BorderColor = System.Drawing.Color.Red;
                    txtEmail.PlaceholderText = "Email không hợp lệ";
                    txtEmail.PlaceholderForeColor = System.Drawing.Color.Red;
                    txtEmail.Text = ""; 
                    valid = false;
                }
                if (!IsValidPhoneNumber(dienThoai))
                {
                    txtPhone.BorderColor = System.Drawing.Color.Red;
                    txtPhone.PlaceholderText = "Số điện thoại không không hợp lệ";
                    txtPhone.PlaceholderForeColor = System.Drawing.Color.Red;
                    txtPhone.Text = "";
                    valid = false;
                }
                if(string.IsNullOrEmpty(pass)|| pass.Trim().Length < 8)
                {
                    txtPass.BorderColor = System.Drawing.Color.Red;
                    txtPass.PlaceholderText = "Mật khẩu phải đủ 8 ký tự";
                    txtPass.PlaceholderForeColor = System.Drawing.Color.Red;
                    txtPass.Text = "";
                    valid = false;
                }
                if(!valid)
                {
                    MessageBox.Show("Lỗi không đúng định dạng thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                using(var context = new BanSanPhamSen())
                {
                    var user = new User
                    {
                        FullName = hoTen,
                        Email = email,
                        PhoneNumber = dienThoai,
                        IsDelete= false
                    };
                    context.Users.Add(user);    
                    context.SaveChanges();

                    //tao account 
                    var acc = new Account
                    {
                        createDate= DateTime.Now,   
                        username = email,
                        passs = pass,
                        IsLocked = false,
                        UserAccountId = user.UserId
                    };

                    context.Account.Add(acc);
                    context.SaveChanges();
                    var accper = new AccountPermisstion
                    {
                        accountId = acc.accountId,
                        permissitionId = 3
                        
                    };
                    context.AccountPermisstion.Add(accper);
                    context.SaveChanges();

                    MessageBox.Show("Tạo tài khoản thành công. Vui lòng đến trang đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear();
                }




            }catch(Exception ex)
            {
                MessageBox.Show("lỗi: "+ex, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void txtHoTen_TabStopChanged(object sender, EventArgs e)
        {
           
        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return false;
            return phoneNumber[0] == '0' && phoneNumber.Length == 10;
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            var text = txtEmail.Text;
            if (IsValidEmail(text))
            {
                txtEmail.BorderColor = System.Drawing.Color.Black;
                txtEmail.PlaceholderForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            var text = txtPhone.Text;
            if (IsValidEmail(text))
            {
                txtPhone.BorderColor = System.Drawing.Color.Black;
                txtPhone.PlaceholderForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            var text = txtPass.Text;
            if (IsValidEmail(text))
            {
                txtPass.BorderColor = System.Drawing.Color.Black;
                txtPass.PlaceholderForeColor = System.Drawing.Color.Gray;
            }
        }
        
        public void clear()
        {
            txtEmail.Text = txtHoTen.Text = txtPass.Text = txtPass.Text = "";
            this.Hide();   
            var f = new FrmLogin();
            f.Show();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
