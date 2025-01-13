using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmChiTietSanPhamChon : UserControl
    {
        private Product pro;
        private List<Product> dsLaoiTuongTu = new List<Product>();
        public FrmChiTietSanPhamChon(Product product)
        {
            pro = product;  
            InitializeComponent();
            loadInfo();
            loadSanPhamTuongTu();
        }
        public void loadSanPhamTuongTu()
        {
            if (pro != null)
            {
                int loai = pro.categoryId;
                using (var context = new BanSanPhamSen())
                {
                    var dsLaoiTuongTu = context.Product.Where(s => s.categoryId == loai).ToList();
                    MessageBox.Show("so luong: " + dsLaoiTuongTu.Count);
                   
                }
            }
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
                        var listImg = pro.imgs.Trim().Split(';').ToArray();
                        string destFile = Path.Combine(Directory.GetCurrentDirectory(),"Upload", listImg[0].Trim());
                        MessageBox.Show("file path: " + destFile);
                        if(File.Exists(destFile)) {
                            MessageBox.Show("File co ton tai");
                            if (PTBHinhAnh.Image != null)
                            {
                                PTBHinhAnh.Image = null;
                            }
                            PTBHinhAnh.Image = Image.FromFile(destFile);
                        }

                        LayoutHinhAnh.FlowDirection = FlowDirection.LeftToRight;
                        LayoutHinhAnh.WrapContents= false;  
                        LayoutHinhAnh.Controls.Clear(); 
                        for(int i = 0; i < listImg.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(listImg[i]))
                            {
                                string path = Path.Combine(Directory.GetCurrentDirectory(), "Upload", listImg[i].Trim());
                                var f = new FrmAnhTuongTu(path, PTBHinhAnh);
                                LayoutHinhAnh.Controls.Add(f);
                            }
                          
                            

                        }


                    }
                    //load san pham tuong tu 
                    if (dsLaoiTuongTu.Count > 0)
                    {
                        LayOutLoaiSanPhamTuongTu.Controls.Clear();
                        LayOutLoaiSanPhamTuongTu.WrapContents = false;
                        foreach (var item in dsLaoiTuongTu)
                        {
                            var f = new FrmSanPhamTuongTu(item, this);
                            LayOutLoaiSanPhamTuongTu.Controls.Add(f);
                        }
                    }
                  

                }
            




            }
            catch(Exception ex) { 
                MessageBox.Show(ex+"","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }




        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbTenSanPham_Click(object sender, EventArgs e)
        {

        }

        private void LayoutHinhAnh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LayOutLoaiSanPhamTuongTu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
