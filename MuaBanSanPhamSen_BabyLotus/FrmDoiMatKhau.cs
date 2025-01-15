using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Service;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    public partial class FrmDoiMatKhau : Form
    {
        private string userName;
        public FrmDoiMatKhau(string userName)
        {
            this.userName = userName;   
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CbHienPass_CheckedChanged(object sender, EventArgs e)
        {
            if(!CbHienPass.Checked)
            {
              
                txtPass.UseSystemPasswordChar = true;
                txtRePass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass.PasswordChar = '\0';
                txtPass.UseSystemPasswordChar= false;
                txtRePass.PasswordChar = '\0';
                txtRePass.UseSystemPasswordChar = false;

            }
        }

        private void showForm()
        {
            var f = new FrmLogin();
            f.ShowDialog(); 
        }


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = txtPass.Text.Trim();  
                string rePass = txtRePass.Text.Trim();  
                if(string.IsNullOrEmpty(pass) && string.IsNullOrEmpty(rePass)) {
                    MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(rePass))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if(rePass!= pass)
                {
                    MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại không trùng khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using(var context = new BanSanPhamSen())
                {
                    var ds = context.Account.ToList();
                    if (ds != null)
                    {
                        foreach(var item in ds)
                        {
                            if(item.username == userName)
                            {
                               
                                item.passs = MaHoaMD5.GetMd5Hash(pass);
                                context.SaveChanges();
                                MessageBox.Show("Đổi mật khẩu thành công", "thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Thread thread = new Thread(new ThreadStart(showForm));
                                thread.SetApartmentState(ApartmentState.STA);
                                thread.Start();
                                this.Close();
                                break;
                            }
                        }
                    }
                }




            }catch(Exception ex) { 
                MessageBox.Show(ex.Message);    
            }

        }
    }
}
