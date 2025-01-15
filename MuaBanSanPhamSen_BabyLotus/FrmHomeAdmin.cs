using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Page;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
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
            LoadInitialData();
           
        }

        private async void LoadInitialData()
        {
            try
            {
                await setCountPageAsync();
                loadSanPhamAsync(); // Chỉ gọi khi cần
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu ban đầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task setCountPageAsync()
        {
            try
            {
                int totalItems = await GetTotalItemCount();
                if (totalItems > 0)
                {
                    countPage = (totalItems + 9) / 10; // Mỗi trang 10 sản phẩm
                    pageNow = 1;
                    lbCountPage.Text = $"{pageNow} / {countPage}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tính số trang: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task<int> GetTotalItemCount()
        {
            using (var context = new BanSanPhamSen())
            {
                return await context.Product.CountAsync(p => !p.isDelete);
            }
        }



        public async void setCountpage()
        {
            var ds = await getDanhSach(); 
            if (ds.Count > 0) { 
                countPage = (ds.Count + 9) / 10; 
                pageNow = 1; 
                lbCountPage.Text = $"{pageNow} / {countPage}";
                loadSanPham();
            }

        }


        public async void loadSanPhamAsync()
        {
            try
            {
                LayoutHienThiSanPham.Controls.Clear(); // Xóa nội dung cũ
                var dsSanPham = await GetProductsByPage(pageNow, 10); // Lấy 10 sản phẩm cho trang hiện tại

                foreach (var product in dsSanPham)
                {
                    if (product != null)
                    {
                        var userForm = new FrmSanPhamItem(product);
                        userForm.Margin = new Padding(20);
                        LayoutHienThiSanPham.Controls.Add(userForm);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task<List<Product>> GetProductsByPage(int pageNumber, int pageSize)
        {
            using (var context = new BanSanPhamSen())
            {
                return await context.Product
                    .Where(p => !p.isDelete)
                    .OrderBy(p => p.productId) // Đảm bảo thứ tự
                    .Skip((pageNumber - 1) * pageSize) // Bỏ qua các sản phẩm của trang trước
                    .Take(pageSize) // Lấy đúng số lượng sản phẩm cần
                    .ToListAsync();
            }
        }



        public async void loadSanPham()
        {
            try { 
                LayoutHienThiSanPham.Controls.Clear(); 
                var dsSanPham = await getDanhSach(); 
                int start = (pageNow - 1) * 10; 
                int end = Math.Min(start + 10, dsSanPham.Count); 
                for (int i = start; i < end; i++) 
                {
                  
                    if (i >= dsSanPham.Count) break; 
                    if (dsSanPham[i] != null) 
                    {
                      
                            var userForm = new FrmSanPhamItem(dsSanPham[i]);
                            userForm.Margin = new Padding(20);
                            LayoutHienThiSanPham.Controls.Add(userForm);
                        
                        
                    } 
                } 
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show($"Lỗi ở đây: {ex}");
            }

        }


        private void LayoutHienThiSanPham_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (pageNow >= countPage) 
                return;
            pageNow++;
            loadSanPhamAsync();
            lbCountPage.Text = $"{pageNow} / {countPage}";


          

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
            if (pageNow <= 1) 
                return; 
            pageNow--;
            loadSanPhamAsync(); 
            lbCountPage.Text = $"{pageNow} / {countPage}";

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                var chuoiTim = txtTimSanPham.Text.Trim();
                if (!string.IsNullOrEmpty(chuoiTim))
                {
                    var ds = await getSanPhamTheoChuoiTim(chuoiTim);
                    
                    if (ds.Count > 0)
                    {
                        countPage = (ds.Count + 9) / 10;
                        pageNow = 1;
                        lbCountPage.Text = $"{pageNow} / {countPage}";
                        loadSanPhamTim(ds);
                    }
                }
                else
                {
                    LoadInitialData();

                }




            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void loadSanPhamTim(List<Product> dsTim)
        {
            try
            {
                LayoutHienThiSanPham.Controls.Clear();
                var dsSanPham = dsTim;
                int start = (pageNow - 1) * 10;
                int end = Math.Min(start + 10, dsSanPham.Count);
                LayoutHienThiSanPham.Controls.Clear();
                for (int i = start; i < end; i++)
                {
                   
                    if (i >= dsSanPham.Count) break;
                    if (dsSanPham[i] != null)
                    {
                       
                            var userForm = new FrmSanPhamItem(dsSanPham[i]);
                            userForm.Margin = new Padding(20);
                            LayoutHienThiSanPham.Controls.Add(userForm);
                     

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi ở đây: {ex}");
            }

        }



        public async Task<List<Product>>getSanPhamTheoChuoiTim(string chuoiTim)
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






    }   
}
