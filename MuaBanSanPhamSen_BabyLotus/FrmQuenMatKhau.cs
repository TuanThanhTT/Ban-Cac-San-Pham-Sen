using BeHatSenLotus.Model;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    public partial class FrmQuenMatKhau : Form
    {
        private int code;
        private string username = "";
        public FrmQuenMatKhau()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
        private void btnGuiMaOTP_Click(object sender, EventArgs e)
        {
            try
            {
                var userName = txtTenDangNhap.Text;
                var emailUser = txtEmail.Text;
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(emailUser) ) {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(!IsValidEmail(userName)) {
                    MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using(var context = new BanSanPhamSen())
                {
                    //tim tai khoan
                    var ds = context.Account.ToList();
                    if (ds != null)
                    {
                        bool valid = false;
                        foreach(var item in ds)
                        {
                            if(item.username == emailUser)
                            {
                                valid = true;
                                break;
                            }
                        }
                        if(!valid)
                        {
                            MessageBox.Show("Không tìm thấy tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);    
                        }
                        else
                        {

                            Random rd = new Random();
                            int otp = rd.Next(100000, 1000000);
                            code = otp;
                            var fromAddress = new MailAddress("tuanthanh00410@gmail.com");
                            var toAddress = new MailAddress(txtEmail.Text.Trim());
                            const string pass = "xdpu qwev xsrn ncdy";
                            const string subject = "Mã phục hồi tài khoản";
                            string body = @"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
            padding: 20px;
        }
        .container {
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #ffffff;
            max-width: 600px;
            margin: auto;
        }
        .header {
            text-align: center;
            margin-bottom: 20px;
        }
        .otp {
            font-size: 24px;
            font-weight: bold;
            color: #ff5722;
        }
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Ứng dụng mua bán các sản phẩm từ sen Baby Lotus</h1>
                    <h1>Mã phục hồi tài khoản</h1>
        </div>
        <p>Mã phục hồi tài khoản của bạn là: <span class='otp'>" + otp + @"</span></p>
    </div>
</body>
</html>";

                            var smtp = new SmtpClient
                            {
                                Host = "smtp.gmail.com",
                                Port = 587,
                                EnableSsl = true,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(fromAddress.Address, pass),
                                Timeout = 200000
                            };

                            using (var mess = new MailMessage(fromAddress, toAddress)
                            {
                                Subject = subject,
                                Body = body,
                                IsBodyHtml = true // Thiết lập gửi nội dung HTML
                            })
                            {
                                smtp.Send(mess);
                            }

                            MessageBox.Show("Đã gửi mã phục hồi tài khoản qua email. Vui lòng kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.username = txtTenDangNhap.Text.Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void loadFormDoiMatKhau()
        {
          
            var form = new FrmDoiMatKhau(username);
            form.ShowDialog();  
        }


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                string xacNhan = txtXacNhanOTP.Text.Trim();
                if (string.IsNullOrEmpty(xacNhan))
                {
                    return;
                }
                if(code.ToString() == xacNhan)
                {
                    //hien form xac nhan
                   
                    Thread thread = new Thread(new ThreadStart(loadFormDoiMatKhau));
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start(); 
                    this.Close();



                }
                else
                {
                    MessageBox.Show("Mã xác nhận không hợp lệ", "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
