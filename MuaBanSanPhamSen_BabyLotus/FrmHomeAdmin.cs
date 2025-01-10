using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    public partial class FrmHomeAdmin : UserControl
    {
        private int pageNow = 0;
        private int countPage = 0;
        public FrmHomeAdmin()
        {
            InitializeComponent();
            setCountpage();
            loadSanPham();
        }


        public async void setCountpage()
        {
            var ds = await getDanhSach();
            if(ds.Count > 0 )
            {
                countPage = (ds.Count / 1);
                if(countPage> 0)
                {
                    pageNow = 1;
                }

                lbCountPage.Text = pageNow+ "/" + countPage;
            }

        }

        public async void loadSanPham()
        {
            try
            {
                LayoutHienThiSanPham.Controls.Clear();

                var dsSanPham = await getDanhSach();

                int star = (pageNow-1) * 1;
                int end = star + 1;

                if (dsSanPham.Count < end)
                {
                    end = dsSanPham.Count;
                }
                if (star >= 0)
                {
                    for (int i = star; i < end; i++)
                    {
                        if (i >= dsSanPham.Count) break; // Đã thay đổi thành i >= dsSanPham.Count
                        if (dsSanPham[i] != null)
                        {
                            var userForm = new FrmSanPhamItem(dsSanPham[i]);
                            LayoutHienThiSanPham.Controls.Add(userForm);
                        }
                    }
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ở đây: " + ex);
            }

        }


        private void LayoutHienThiSanPham_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (pageNow <=1) return;
            pageNow--;
            loadSanPham();
            lbCountPage.Text = pageNow + "/" + countPage;

        }

        private void CBBTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        public async Task<List<Product>> getDanhSach()
        {
            using (var context = new BanSanPhamSen())
            {
                return await Task.Run(() =>
                {
                    return context.Product.Where(op => op.isDelete == false).ToList();
                });
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if(pageNow == countPage) return;
            pageNow++;
            loadSanPham();
            lbCountPage.Text = pageNow+ "/" + countPage;

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
