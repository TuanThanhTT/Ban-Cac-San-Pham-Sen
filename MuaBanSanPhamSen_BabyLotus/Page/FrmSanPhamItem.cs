using BeHatSenLotus.Model;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmSanPhamItem : UserControl
    {
        private Product product = null;
        public FrmSanPhamItem(Product p)
        {
            product = p;
            InitializeComponent();
            loadInfo();
        }


        public void loadInfo()
        {
         
            if (product == null) {

                return;
            };

            lbGiaBan.Text = product.price + "vnđ";
            string img = product.imgs;
            
            if(img != null) {
                
                string[]listImg = img.Trim().Split(';').ToArray(); 
                string anh = listImg[0];
                string destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", anh.Trim());
                if (File.Exists(destFile))
                {
                    // Dọn dẹp hình ảnh cũ nếu có
                    if (PTBImg.Image != null)
                    {
                        PTBImg.Image.Dispose();
                        PTBImg.Image = null;
                    }

                    // Tải và hiển thị hình ảnh mới
                    PTBImg.Image = Image.FromFile(destFile);
                    PTBImg.SizeMode = PictureBoxSizeMode.StretchImage; // Co giãn hình ảnh
                }
             
                
            }
            GBTenSanPham.Text= product.productName;


        }

        private void GBTenSanPham_Click(object sender, EventArgs e)
        {

        }

        private void PTBImg_Click(object sender, EventArgs e)
        {

        }
    }
}
