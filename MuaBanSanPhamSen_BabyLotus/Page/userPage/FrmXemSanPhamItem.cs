using BeHatSenLotus.Model;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmXemSanPhamItem : UserControl
    {
        private Product product;

        public FrmXemSanPhamItem(Product p)
        {
            product = p;
            InitializeComponent();
            loadProduct();
        }

        public void loadProduct()
        {
            try
            {
                if(product != null) {
                    MessageBox.Show("ko  nulll");
                    GroupTitle.Text = product.productName;
                    lbPrice.Text = product.price + "vnđ";

                    string img = product.imgs.Trim();
                    if (!string.IsNullOrEmpty(img))
                    {
                        var listImg = img.Split(';').ToArray();
                        string destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", listImg[0].Trim());

                        if (File.Exists(destFile))
                        {
                            // Dọn dẹp hình ảnh cũ nếu có
                            if (PTBimg.Image != null)
                            {
                                PTBimg.Image.Dispose();
                                PTBimg.Image = null;
                            }
                            // Tải và hiển thị hình ảnh mới
                            PTBimg.Image = Image.FromFile(destFile);
                            PTBimg.SizeMode = PictureBoxSizeMode.StretchImage; // Co giãn hình ảnh
                        }
                        else
                        {
                            MessageBox.Show("File không tồn tại!");
                        }

                    }




                }

                

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
