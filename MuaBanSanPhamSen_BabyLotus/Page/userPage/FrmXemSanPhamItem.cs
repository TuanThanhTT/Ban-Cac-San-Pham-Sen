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
        private FrmUser formMain;
       
        public FrmXemSanPhamItem(Product p, FrmUser formMain)
        {
            this.formMain= formMain;    
            product = p;
            InitializeComponent();
            loadProduct();


        }


       

       
        public void loadProduct()
        {
            try
            {
                if (product != null)
                {

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



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupTitle_Click(object sender, EventArgs e)
        {

        }

        private void GroupTitle_MouseHover(object sender, EventArgs e)
        {
          

        }

        private void GroupTitle_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void FrmXemSanPhamItem_MouseHover(object sender, EventArgs e)
        {
        }

        private void FrmXemSanPhamItem_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            this.formMain.addTabMain();
            var form = new FrmChiTietSanPhamChon(product);
            this.formMain.addTabPage(this.formMain.tabMain, form);
        }

        private void PTBimg_Click(object sender, EventArgs e)
        {

        }
    }
}
