using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmHomeUser : UserControl
    {
        private int pageNow = 0;
        private int pageCount = 0;  
        public FrmHomeUser()
        {
            InitializeComponent();
            setCountPage();
           
        }


        public async void setCountPage()
        {
            try
            {
                var ds = await getDanhSachSanPham();
                if(ds.Count <= 0)
                {
                    pageCount = 0;
                    pageNow = 0;
                }
                else
                {
                    pageCount = ds.Count / 10;
                    if (pageCount >= 0) pageCount = 1;
                    pageNow = 1 ;

                }
                loadProductItem();

            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);    
            }
        }


        public async Task<List<Product>> getDanhSachSanPham()
        {
            using(var context = new BanSanPhamSen())
            {
                return await Task.Run(() =>
                {
                    return context.Product.Where(s=>s.isDelete == false).ToList(); 
                });
            }
        }

        public async void loadProductItem()
        {
            try
            {
                var ds = await getDanhSachSanPham();
                int pageIndex = pageNow;
                
                if(pageNow == 1)
                {
                    pageIndex = 0;
                }
                else
                {
                    pageIndex--;
                }
                int star = pageIndex * 10;
                int end = star + 10;
                MessageBox.Show("star va end: " + star + " " + end);
                if(ds.Count <= end)
                {
                    end = ds.Count-1;
                }

                MessageBox.Show("so luong: " + ds.Count);

                for(int i = star; i <= end; i++)
                {
                    if (ds[i] != null)
                    {
                        // Tạo đối tượng điều khiển
                        var userFrom = new FrmXemSanPhamItem(ds[i]);

                        // Đặt khoảng cách giữa các điều khiển
                        userFrom.Margin = new Padding(10);

                        // Thêm điều khiển vào FlowLayoutPanel
                        LayoutSanPham.Controls.Add(userFrom);

                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }





        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            try
            {
                if (pageNow <= 1) return;
                pageNow--;
                loadProductItem();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (pageCount == pageNow) return;
                pageNow++;
                loadProductItem();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LayoutSanPham_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
