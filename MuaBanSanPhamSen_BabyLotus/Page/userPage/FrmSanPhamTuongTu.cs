using BeHatSenLotus.Model;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmSanPhamTuongTu : UserControl
    {
        private Product product;
        private FrmChiTietSanPhamChon main;

        public FrmSanPhamTuongTu(Product product, FrmChiTietSanPhamChon main)
        {
            this.product = product; 
            this.main = main;
            InitializeComponent();
        }


        public void LoadInfo()
        {
            if (product != null)
            {
                GroupTenSanPham.Text = product.productName;
                if(!string.IsNullOrEmpty(product.imgs))
                {
                    var listImg = product.imgs.Trim().Split(',').ToList();
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload", listImg[0].Trim());
                    if(File.Exists(filePath)) {
                        if (PTBAnhSanPham.Image != null)
                        {
                            PTBAnhSanPham.Image = null;
                        }
                        PTBAnhSanPham.Image = Image.FromFile(filePath); 

                    }
                }
            }
        }


        private void GroupTenSanPham_Click(object sender, EventArgs e)
        {

        }

        private void PTBAnhSanPham_Click(object sender, EventArgs e)
        {
            
        }
    }
}
