using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmXemSanPhamMua : UserControl
    {


        private int pageNow = 0;
        private int countPage = 0;
        private FrmUser formMain;
        private User user;
        public FrmXemSanPhamMua(FrmUser f, User user)
        {
            this.formMain = f;
            InitializeComponent();
            LoadInitialData();
            loadCombobox();
            this.user = user;
        }


        public async void loadCombobox()
        {
            try
            {
                var ds = await getLoaiSanPham();
               
                if(ds!= null) {
                    ds.Insert(0, new Category { categoryId = -1, categoryName =  "" });
                    CBBLoaiSanPham.DataSource = ds;
                 
                    CBBLoaiSanPham.DisplayMember= "categoryName";
                    CBBLoaiSanPham.ValueMember = "categoryId";
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task<List<Category>> getLoaiSanPham()
        {
            using(var context = new BanSanPhamSen())
            {
                return await Task.Run(() =>
                {
                    return context.Category.ToList();
                });
            }
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
                    LbPage.Text = $"{pageNow} / {countPage}";
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

        public async Task<int> GetTotalItemCountByCate(int id)
        {
            using (var context = new BanSanPhamSen())
            {
                return await context.Product.CountAsync(p => !p.isDelete && p.categoryId == id);
            }
        }

        public async Task<int> GetTotalItemCountAndChuoiTimByCate(int id, string chuoiTim)
        {
            using (var context = new BanSanPhamSen())
            {
                var ds =  await context.Product.Where(p => !p.isDelete && p.categoryId == id).ToListAsync();
                var count = 0;
                if (ds != null)
                {
                    foreach (var item in ds)
                    {
                        if (ContainsIgnoreCaseAndPunctuation(item.productName, chuoiTim)) count++;
                    }
                }
              
                return count;   
            }
        }


        public async Task<int> GetTotalItemCountByChuoiTim(string chuoiTim)
        {
            using (var context = new BanSanPhamSen())
            {
                var ds = await context.Product.Where(s=>s.isDelete == false).ToListAsync();
                int count = 0;
                if (ds != null)
                {
                    foreach (var item in ds)
                    {
                        if(ContainsIgnoreCaseAndPunctuation(item.productName, chuoiTim))
                        {
                            count++;    
                        }
                    }
                }
                return count;              
            }
        }

        public async void loadSanPhamAsync()
        {
            try
            {
                LayoutSanPham.Controls.Clear(); // Xóa nội dung cũ
                var dsSanPham = await GetProductsByPage(pageNow, 10); // Lấy 10 sản phẩm cho trang hiện tại

                foreach (var product in dsSanPham)
                {
                    if (product != null)
                    {
                        var userForm = new FrmXemSanPhamItem(product, this.formMain, user);
                        userForm.Margin = new Padding(20);
                        LayoutSanPham.Controls.Add(userForm);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async void loadSanPhamCateAsync(int id)
        {
            try
            {
                LayoutSanPham.Controls.Clear(); // Xóa nội dung cũ
                var dsSanPham = await GetProductsCateByPage(pageNow, 10, id); // Lấy 10 sản phẩm cho trang hiện tại

                foreach (var product in dsSanPham)
                {
                    if (product != null)
                    {
                        var userForm = new FrmXemSanPhamItem(product, this.formMain, user);
                        userForm.Margin = new Padding(20);
                        LayoutSanPham.Controls.Add(userForm);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void loadSanPhamCateAndChuoiTimAsync(int id, string chuoiTim)
        {
            try
            {
                LayoutSanPham.Controls.Clear(); // Xóa nội dung cũ
                var dsSanPham = await GetProductsCateAndChuoiTimByPage(pageNow, 10, id, chuoiTim); // Lấy 10 sản phẩm cho trang hiện tại

                foreach (var product in dsSanPham)
                {
                    if (product != null)
                    {
                        var userForm = new FrmXemSanPhamItem(product, this.formMain, user);
                        userForm.Margin = new Padding(20);
                        LayoutSanPham.Controls.Add(userForm);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void loadSanPhamChuoiTimAsync(string chuoiTim)
        {
            try
            {
                LayoutSanPham.Controls.Clear(); // Xóa nội dung cũ
                var dsSanPham = await GetProductsChuoiTimByPage(pageNow, 10, chuoiTim); // Lấy 10 sản phẩm cho trang hiện tại

                foreach (var product in dsSanPham)
                {
                    if (product != null)
                    {
                        var userForm = new FrmXemSanPhamItem(product, this.formMain, user);
                        userForm.Margin = new Padding(20);
                        LayoutSanPham.Controls.Add(userForm);
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

        public async Task<List<Product>> GetProductsCateByPage(int pageNumber, int pageSize, int id)
        {
            using (var context = new BanSanPhamSen())
            {
                return await context.Product
                    .Where(p => !p.isDelete && p.categoryId == id)
                    .OrderBy(p => p.productId) // Đảm bảo thứ tự
                    .Skip((pageNumber - 1) * pageSize) // Bỏ qua các sản phẩm của trang trước
                    .Take(pageSize) // Lấy đúng số lượng sản phẩm cần
                    .ToListAsync();
            }
        }
        public async Task<List<Product>> GetProductsCateAndChuoiTimByPage(int pageNumber, int pageSize, int id, string chuoiTim)
        {
            using (var context = new BanSanPhamSen())
            {
                var ds =  await context.Product
                    .Where(p => !p.isDelete && p.categoryId == id)
                    .OrderBy(p => p.productId) // Đảm bảo thứ tự
                    .Skip((pageNumber - 1) * pageSize) // Bỏ qua các sản phẩm của trang trước
                    .Take(pageSize) // Lấy đúng số lượng sản phẩm cần
                    .ToListAsync();
                var rs = new List<Product>();
                if (ds != null)
                {
                    rs = ds.Where(p=>ContainsIgnoreCaseAndPunctuation(p.productName, chuoiTim)).ToList();    
                }
                return rs;
            }
        }

        public async Task<List<Product>> GetProductsChuoiTimByPage(int pageNumber, int pageSize, string chuoiTim)
        {
            using (var context = new BanSanPhamSen())
            {
                var ds =  await context.Product
                    .Where(p => !p.isDelete)
                    .OrderBy(p => p.productId) // Đảm bảo thứ tự
                    .Skip((pageNumber - 1) * pageSize) // Bỏ qua các sản phẩm của trang trước
                    .Take(pageSize) // Lấy đúng số lượng sản phẩm cần
                    .ToListAsync();
                var rs = new List<Product>();
                if (ds != null)
                {
                    rs = ds.Where(p=>ContainsIgnoreCaseAndPunctuation(p.productName, chuoiTim)).ToList();
                    
                }
                return rs;
            }
        }






        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void PTBImgs_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LayoutSanPham_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (pageNow <= 1)
                return;
            pageNow--;
            loadSanPhamAsync();
            LbPage.Text = $"{pageNow} / {countPage}";
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (pageNow >= countPage)
                return;
            pageNow++;
            loadSanPhamAsync();
            LbPage.Text = $"{pageNow} / {countPage}";
        }

        private void btnTim_MouseHover(object sender, EventArgs e)
        {
            string fileIcon = "icons8-find-100.png";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Image", fileIcon);

            btnTim.Image = Image.FromFile(filePath);
            btnTim.Text = null;

          


        }

        private void btnTim_MouseLeave(object sender, EventArgs e)
        {
            if (btnTim.Image != null)
            {
                btnTim.Image = null;
                btnTim.Text = "Tìm";
            }
        }

        private void btnLoc_MouseHover(object sender, EventArgs e)
        {
            string fileIcon = "icons8-filter-100 (1).png";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Image", fileIcon);

            btnLoc.Image = Image.FromFile(filePath);
            btnLoc.Text = null;

        }

        private void btnLoc_MouseLeave(object sender, EventArgs e)
        {
            if (btnLoc.Image != null)
            {
                btnLoc.Image = null;
                btnLoc.Text = "Lọc";
            }
        }

        private async void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                var id  = Convert.ToInt32(CBBLoaiSanPham.SelectedValue.ToString());
                if (id != -1)
                {
                    await GetTotalItemCountByCate(id);
                    loadSanPhamCateAsync(id);
                }
                else
                {
                    LoadInitialData();
                }


               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu ban đầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool ContainsIgnoreCaseAndPunctuation(string source, string target)
        {
            string pattern = @"[^\w\s]";
            source = Regex.Replace(source, pattern, "");
            target = Regex.Replace(target, pattern, "");
            return source.IndexOf(target, StringComparison.OrdinalIgnoreCase) >= 0;
        }





        private async void btnTim_Click(object sender, EventArgs e)
        {
            try
            {

                var id = Convert.ToInt32(CBBLoaiSanPham.SelectedValue.ToString());
                string chuoiTim = txtTimKiem.Text.Trim();
                if (id != -1)
                {
                    //tim theo chuoi tim kiem + bo loc
                    if (!string.IsNullOrEmpty(chuoiTim))
                    {
                        await GetTotalItemCountAndChuoiTimByCate(id, chuoiTim);
                        loadSanPhamCateAndChuoiTimAsync(id,chuoiTim);
                    } 
                 
                }
                else
                {
                  
                    if (!string.IsNullOrEmpty(chuoiTim))
                    {
                        //tim theo chuoi tim kiem
                        await GetTotalItemCountByChuoiTim(chuoiTim);
                        loadSanPhamChuoiTimAsync(chuoiTim);
                    }

                  

                }




            }
            catch(Exception ex)
            {
                MessageBox.Show(ex+"");
            }
        }
    }
}
