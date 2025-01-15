using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Service;
using System;
using System.Data.Entity;
using System.Threading;
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

       


        private async void btnDangNhap_Click(object sender, EventArgs e)
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
                     var ds = await context.Account.ToListAsync();
                    var acc = new Account();
                    foreach(var item in ds)
                    {
                        if(item.username == userName)
                        {
                            acc = item;
                            break;
                        }
                    }

                    
                    if (acc != null )
                    {
                        
                        if(acc.passs.Trim() == MaHoaMD5.GetMd5Hash(pass.Trim()))
                        {
                            if (acc.EmployAccountId== null)
                            {
                                var user = context.Users.Find(acc.UserAccountId);
                                if (user != null)
                                {

                                    if (user.IsDelete == true)
                                    {
                                        MessageBox.Show("Tài khoản này đã bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    Thread thread = new Thread(new ThreadStart(() =>
                                    {
                                        var f = new FrmUser(user);
                                        f.ShowDialog(); 
                                    }));
                                    thread.SetApartmentState(ApartmentState.STA);
                                    thread.Start();
                                   
                                    this.Close();   
                                }
                            }
                            else{
                                var employ = context.Employees.Find(acc.EmployAccountId);
                                if (employ != null)
                                {
                                    if(employ.IsDelete== true)
                                    {
                                        MessageBox.Show("Tài khoản này đã bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                  
                                    Thread thread = new Thread(new ThreadStart(() =>
                                    {
                                        var f = new FrmMain(employ);
                                        f.ShowDialog();
                                    }));
                                    thread.SetApartmentState(ApartmentState.STA);
                                    thread.Start(); 
                                    this.Close();   

                                }
                            }
                        }
                        else
                        {
                            txtPass.PlaceholderForeColor = System.Drawing.Color.Red;
                            txtPass.BorderColor = System.Drawing.Color.Red;
                            txtPass.PlaceholderText = "Mật khẩu không chính xác";
                            txtPass.Text = "";
                            
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

        private void showFormDangKy()
        {
            var f = new FrmDangKy();
            f.ShowDialog();
        }


        private void lbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(showFormDangKy));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
           
            this.Close();   
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

        private void loadFormQuenMatKhau()
        {
            var form = new FrmQuenMatKhau();  
            form.ShowDialog();

        }
        private void linkLBQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(loadFormQuenMatKhau));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            
            this.Close();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
