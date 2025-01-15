using QRCoder;
using System;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.PageCode
{
    public partial class FrmTaoBarCode : Form
    {
        private string mess;
        public FrmTaoBarCode(string mess)
        {
            this.mess = mess;
            InitializeComponent();
            txtNoiDung.Text = mess; 
            this.MaximizeBox= false;
        }


        public void QRLink()
        {
            string url = this.mess; 
            if (string.IsNullOrEmpty(url)) 
            {
                MessageBox.Show("Vui lòng nhập URL hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            if (PTBBarCode.Image != null) 
            {
                PTBBarCode.Image = null;
            }
            QRCodeGenerator qrGenerator = new QRCodeGenerator(); 
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData); 
            PTBBarCode.Image = qrCode.GetGraphic(10); 
            txtLuu.Visible = true; 
            MessageBox.Show("Mã QR đã được tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        private void btnTaoBarCode_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNoiDung.Text)) return;

            if (PTBBarCode.Image != null)
            {
                PTBBarCode.Image = null;

            }


            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            var qr1 = qr.CreateQrCode(txtNoiDung.Text.Trim(), QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(qr1);

            PTBBarCode.Image = code.GetGraphic(10);
            txtLuu.Visible = true;
            //QRLink();
        }

        private void txtLuu_Click(object sender, EventArgs e)
        {
            if (PTBBarCode.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog 
                {
                    InitialDirectory = "c:\\",
                    Filter = "PNG Files|*.png|GIF Files|*.gif|JPG Files|*.jpg", 
                    FilterIndex = 3, RestoreDirectory = true
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    PTBBarCode.Image.Save(filePath);
                    MessageBox.Show("Lưu ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                } 
            } 
            else
            { 
                MessageBox.Show("Không có ảnh trong PictureBox để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                string barcode = txtNoiDung.Text.Trim();
                if(string.IsNullOrEmpty(barcode) )
                {
                    return;
                }
                try
                {
                    if(PTBBarCode.Image != null)
                    {
                        PTBBarCode.Image = null;
                    }
                    Zen.Barcode.Code128BarcodeDraw br = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                    PTBBarCode.Image = br.Draw(barcode, 5);
                    txtLuu.Visible= true;

                }
                catch
                {
                    MessageBox.Show("Lỗi tạo barcode","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                }
            }catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            if(PTBBarCode!= null)
            {
                PTBBarCode.Image = null;
                txtLuu.Visible = false;
            }

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
