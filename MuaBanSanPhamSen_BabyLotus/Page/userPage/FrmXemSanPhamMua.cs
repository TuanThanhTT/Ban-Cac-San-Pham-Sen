using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmXemSanPhamMua : UserControl
    {


        private int pageNow = 0;
        private int countPage = 0;
        private FrmUser formMain;
        public FrmXemSanPhamMua(FrmUser f)
        {
            this.formMain = f;
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
                        var userForm = new FrmXemSanPhamItem(product, this.formMain);
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
    }
}
