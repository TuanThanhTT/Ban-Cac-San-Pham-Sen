using BeHatSenLotus.Model;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class IconDonHang : UserControl
    {
        private ChiTietGioHang ct;
        private FlowLayoutPanel main;
        public IconDonHang(ChiTietGioHang ct, FlowLayoutPanel donHang)
        {
            this.ct = ct;   
            this.main = donHang; 
            InitializeComponent();
            loadInfo();
        }

        public void loadInfo()
        {
            try
            {
                if (ct != null)
                {
                    txtSoLuong.Text = ct.quantity.ToString();
                    using(var context = new BanSanPhamSen())
                    {
                        var sanPham = context.Product.Find(ct.productId);
                        if(sanPham != null)
                        {
                            GroupBoxTenSanPham.Text = sanPham.productName;
                            string img = sanPham.imgs.Trim();
                            if(!string.IsNullOrEmpty(img) ) {
                             
                                var listimg = img.Split(';').ToArray();
                                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload", listimg[0].Trim());
                                if(File.Exists(filePath) )
                                {
                                    if(PTBHinhanh.Image != null)
                                    {
                                        PTBHinhanh.Image = null;

                                    }
                                    PTBHinhanh.Image = Image.FromFile(filePath);    

                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);    
            }
         
        }



        private void GroupBoxTenSanPham_Click(object sender, EventArgs e)
        {

        }

        private void PTBHinhanh_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                
                main.Controls.Remove(this); 
                using(var context = new BanSanPhamSen())
                {
                    //xoa chi tiet don hang
                    var chitietDonHang = context.ChiTietGioHang.Find(ct.id);
                    if(chitietDonHang != null)
                    {
                        context.ChiTietGioHang.Remove(chitietDonHang);
                        context.SaveChanges();
                        MessageBox.Show("Xóa đon hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                   
                }


            }catch(Exception ex)
            {
                MessageBox.Show(ex+"");
            }
        }
    }
}
