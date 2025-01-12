using BeHatSenLotus.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim();  
                string pass = txtPass.Text.Trim();
                bool valid = true;
                if(string.IsNullOrEmpty(userName) ) {
                    txtUserName.BackColor = System.Drawing.Color.Red;
                    txtUserName.PlaceholderText = "Tên tài khoản không được bỏ trống";
                    txtUserName.PlaceholderForeColor= System.Drawing.Color.Red; 
                    valid= false;   
                }
                if(string.IsNullOrEmpty(pass) )
                {
                    txtPass.BackColor = System.Drawing.Color.Red;
                    txtPass.PlaceholderText = "Mật khẩu không được bỏ trống";

                    txtPass.PlaceholderForeColor = System.Drawing.Color.Red;
                    valid = false;
                }
                if(!valid ) {
                    MessageBox.Show("Lỗi nhập thông tin", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using(var context = new BanSanPhamSen())
                {
                    var acc = context.Account.Where(s=>s.username == userName).FirstOrDefault();
                    if(acc != null )
                    {
                        if(acc.passs == pass)
                        {
                            var f = new FrmUser();
                            f.Show();
                            this.Close();   
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }




            }
            catch(Exception ex) { 
                MessageBox.Show("Lỗi: "+ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void CbHienPass_CheckedChanged(object sender, EventArgs e)
        {
            if(CbHienPass.Checked)
            {
                txtPass.PasswordChar ='\0';
                txtPass.UseSystemPasswordChar= false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void lbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var f = new FrmDangKy();
            this.Hide();
            f.Show();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            var text = txtUserName.Text.Trim();
            if(!string.IsNullOrEmpty(text) )
            {
                txtUserName.BorderColor = System.Drawing.Color.Black;
                txtUserName.PlaceholderForeColor= System.Drawing.Color.Gray;
                
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            var text = txtPass.Text.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                txtPass.BorderColor = System.Drawing.Color.Black;
                txtPass.PlaceholderForeColor = System.Drawing.Color.Gray;

            }
        }
    }
}
