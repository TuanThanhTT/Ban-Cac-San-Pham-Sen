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
        private int pageNow = 1;
        private int countPage = 0;
        public FrmHomeAdmin()
        {
            InitializeComponent();
            loadSanPham();
        }


        public void loadSanPham()
        {
            try
            {
                LayoutHienThiSanPham.Controls.Clear();  
                for (int i = 0; i < 20; i++)
                {
                    var userFrom = new FrmSanPhamItem();

                    LayoutHienThiSanPham.Controls.Add(userFrom);
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LayoutHienThiSanPham_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (pageNow == 0) return;
            pageNow--;
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
        }
    }
}
