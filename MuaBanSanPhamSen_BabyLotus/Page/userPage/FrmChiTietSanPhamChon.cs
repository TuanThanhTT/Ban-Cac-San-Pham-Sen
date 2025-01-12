using BeHatSenLotus.Model;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmChiTietSanPhamChon : UserControl
    {
        private Product pro;

        public FrmChiTietSanPhamChon(Product product)
        {
            pro = product;  
            InitializeComponent();
            loadInfo();
        }


        public void loadInfo()
        {
            try
            {
                if(pro != null)
                {
                    lbTenSanPham.Text = pro.productName;
                    lbGiaBan.Text = pro.price + " vnđ";
                    lbSoLuongTon.Text = pro.quantity.ToString();
                    lbTrangThai.Text = (pro.isDelete) ? "Ngừng bán" : "Còn hàng";
                    txtMoTa.Text = pro.Decrepsition.ToString();

                    if (!string.IsNullOrEmpty(pro.imgs))
                    {
                        var listImg = pro.imgs.Trim().Split(',').ToArray();
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload", listImg[0]);
                        MessageBox.Show("file path: " + filePath);
                        if(File.Exists(filePath)) {
                            MessageBox.Show("File co ton tai");
                            if (PTBHinhAnh.Image != null)
                            {
                                PTBHinhAnh.Image = null;
                            }
                            PTBHinhAnh.Image = Image.FromFile(filePath);
                        }
                      
                    }

                    //D:\DoAnMonHoc\MuaBanSanPhamSen_BabyLotus\MuaBanSanPhamSen_BabyLotus\Upload
                }




            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message,"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }




        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbTenSanPham_Click(object sender, EventArgs e)
        {

        }
    }
}
