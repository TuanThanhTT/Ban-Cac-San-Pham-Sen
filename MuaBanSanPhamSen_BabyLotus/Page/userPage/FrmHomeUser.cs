using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
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
                if(ds.Count <= end)
                {
                    end = ds.Count-1;
                }

                LayoutSanPham.Controls.Clear();
                for (int i = star; i <= end; i++)
                {
                    if (ds[i] != null)
                    {
                        // Tạo đối tượng điều khiển
                        var userFrom = new FrmSanPhamItem(ds[i]);

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



        public  void loadProductItemTheoDanhSach(List<Product> listItem)
        {
            try
            {
                var ds = listItem;
                int pageIndex = pageNow;

                if (pageNow == 1)
                {
                    pageIndex = 0;
                }
                else
                {
                    pageIndex--;
                }
                int star = pageIndex * 10;
                int end = star + 10;
                if (ds.Count <= end)
                {
                    end = ds.Count - 1;
                }

                LayoutSanPham.Controls.Clear();

                for (int i = star; i <= end; i++)
                {
                    if (ds[i] != null)
                    {
                        // Tạo đối tượng điều khiển
                        var userFrom = new FrmSanPhamItem(ds[i]);

                        // Đặt khoảng cách giữa các điều khiển
                        userFrom.Margin = new Padding(10);

                        // Thêm điều khiển vào FlowLayoutPanel
                        LayoutSanPham.Controls.Add(userFrom);

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        public async Task<List<Product>> getSanPhamTheoChuoiTim(string chuoiTim)
        {
            var listSanPham = new List<Product>();
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    int id = -1;
                    if (int.TryParse(chuoiTim, out id))
                    {
                        id = int.Parse(chuoiTim);
                    }
                    else
                    {
                        id = -1;
                    }
                    if (id != -1)
                    {
                        var sanPham = await context.Product.FindAsync(id);
                        if (sanPham != null)
                        {
                            listSanPham.Add(sanPham);
                            return listSanPham;
                        }
                    }
                    else
                    {
                        var ds = await context.Product.Where(op => !op.isDelete).ToListAsync();
                        listSanPham.AddRange(ds.Where(op => SoSanhChuoi(op.productName, chuoiTim)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listSanPham;
        }

        static bool SoSanhChuoi(string a, string b)
        {
            try
            {
                // Loại bỏ dấu và chuyển về chữ thường
                string aKhongDau = LoaiBoDau(a).ToLower();
                string bKhongDau = LoaiBoDau(b).ToLower();




                if (!aKhongDau.Contains(bKhongDau))
                {
                    return false; // Nếu bất kỳ từ nào không khớp, trả về false
                }

                return true; // Tất cả từ đều khớp
            }
            catch
            {
                return false;
            }
        }



        static string LoaiBoDau(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            // Chuẩn hóa chuỗi và loại bỏ các dấu
            string normalized = input.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            // Trả về chuỗi không dấu
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private async void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                var chuoiTim = txtTimKiem.Text.Trim();
                if (!string.IsNullOrEmpty(chuoiTim))
                {
                    var ds = await getSanPhamTheoChuoiTim(chuoiTim);

                    if (ds.Count > 0)
                    {
                        pageCount = (ds.Count + 9) / 10;
                        pageNow = 1;
                        lbPage.Text = $"{pageNow} / {pageCount}";
                        loadProductItemTheoDanhSach(ds);
                    }
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
