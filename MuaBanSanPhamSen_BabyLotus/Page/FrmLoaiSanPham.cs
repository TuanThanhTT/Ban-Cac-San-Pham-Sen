using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmLoaiSanPham : UserControl
    {
        public  FrmLoaiSanPham()
        {
            InitializeComponent();
            loadTableLoaiSanPham();
        }


        public async void loadTableLoaiSanPham()
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Name", typeof(string));


                var ds = await getDanhSachLoaiSP();
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.categoryId, vi.categoryName);
                        }

                    }
                    GVLoaiSanPham.DataSource = data;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        public async void loadTableBangdanhSach(List<Category> dsTim)
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Name", typeof(string));


                var ds = dsTim;
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.categoryId, vi.categoryName);
                        }

                    }
                    GVLoaiSanPham.DataSource = data;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task<List<Category>> getDanhSachLoaiSP()
        {
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    return await Task.Run(() =>
                    {
                        return context.Category.Where(op=>op.isDelete == false).ToList();
                    });
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return null;
        }


        public void clear()
        {
            txtTenLoai.Text = txtMaLoai.Text = txtTimKiem.Text = "";
        }




        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maLoai = txtMaLoai.Text;
                if(!string.IsNullOrEmpty(maLoai) )
                {
                    return;
                }

                string tenLoai = txtTenLoai.Text;

                if(string.IsNullOrEmpty(tenLoai) )
                {
                    MessageBox.Show("Tên sản phẩm không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using(var context = new BanSanPhamSen())
                {
                    var loaiSP = context.Category.Count();

                    int id = loaiSP + 1;
                    var loaiSanPham = new Category
                    {
                        categoryId = id,
                        categoryName = tenLoai,
                    };
                    
                    context.Category.Add(loaiSanPham);
                    context.SaveChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadTableLoaiSanPham();
                    clear();
                }




            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clear();
            loadTableLoaiSanPham(); 
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maLoai = txtMaLoai.Text;
                if (string.IsNullOrEmpty(maLoai))
                {
                    return;
                }

                using (var context = new BanSanPhamSen())
                {
                    var laoiSP = context.Category.Find(Convert.ToInt32(maLoai));
                    if (laoiSP != null)
                    {
                        laoiSP.isDelete = true;
                        context.SaveChanges();
                        MessageBox.Show("Xóa loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        loadTableLoaiSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy loại sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GVLoaiSanPham.CurrentCell.RowIndex;
                var maloaiSP = GVLoaiSanPham.Rows[selected].Cells[0].Value.ToString();
                var tenloaiSP = GVLoaiSanPham.Rows[selected].Cells[1].Value.ToString();
              


                txtMaLoai.Text = maloaiSP;
                txtTenLoai.Text = tenloaiSP;
         



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string maloaiSP = txtMaLoai.Text;
                if (string.IsNullOrEmpty(maloaiSP))
                {
                    return;
                }

                bool valid = true;

                string tenLoai  = txtTenLoai.Text;
                if (string.IsNullOrEmpty(tenLoai))
                {
                    MessageBox.Show("Tên loại sản phẩm không được bỏ trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                using (var context = new BanSanPhamSen())
                {
                    var loaiSP = context.Category.Find(Convert.ToInt32(maloaiSP));
                    if (loaiSP != null)
                    {
                        loaiSP.categoryName = tenLoai;
                      
                        context.SaveChanges();
                        MessageBox.Show("Cập nhật thông tin loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        loadTableLoaiSanPham();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        public static bool ContainsIgnoreCaseAndPunctuation(string source, string target)
        {
            string pattern = @"[^\w\s]";
            source = Regex.Replace(source, pattern, "");
            target = Regex.Replace(target, pattern, "");
            return source.IndexOf(target, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var dsTim = new List<Category>();
            try
            {
                string chuoiTim = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(chuoiTim))
                {
                    return;
                }
                // Tìm theo mã
                int id = -1;
                if (int.TryParse(chuoiTim, out id))
                {
                    id = int.Parse(chuoiTim);
                }
                else
                {
                    id = -1;
                }

                if (id == -1)
                {
                    // Tìm theo tên
                    using (var context = new BanSanPhamSen())
                    {
                        var ds = context.Category.Where(op => op.isDelete == false).ToList();

                        if (ds.Count > 0)
                        {
                            foreach (var item in ds)
                            {
                                if (item.isDelete == false)
                                {
                                    if (ContainsIgnoreCaseAndPunctuation(item.categoryName, chuoiTim))
                                    {
                                        dsTim.Add(item);
                                    }
                                }    
                               
                            }

                         
                        }

                    }
                }
                else
                {
                    // Tìm theo mã
                    using (var context = new BanSanPhamSen())
                    {
                        var loaiSanPham = context.Category.Find(id);
                        if (loaiSanPham != null && loaiSanPham.isDelete == false)
                        { 
                            dsTim.Add(loaiSanPham);
                        }
                    }
                }

                loadTableBangdanhSach(dsTim);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
    }
}
