using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmSanPham : UserControl
    {

        private string imgString = "";
        public FrmSanPham()
        {
            InitializeComponent();
            loadComBoBox();
            loadTable();
        }

        public async void loadComBoBox()
        {
            try
            {
              
                    var dsLoaiSanPham = await getDanhSachCate();
                    dsLoaiSanPham.Insert(0, new Category
                    {
                        categoryId = 0,
                        categoryName = ""
                    });
                    CBBLoaiSanPham.DataSource = dsLoaiSanPham;
                    CBBLoaiSanPham.DisplayMember = "categoryName";
                    CBBLoaiSanPham.ValueMember = "categoryId";

                    var dsNhaCungCap = await getDanhSachMan();

                    dsNhaCungCap.Insert(0, new Manfactory
                    {
                        manfactoryId = 0,
                        manfactoryName = " ",
                    });
                    CBBNhaCungCap.DataSource = dsNhaCungCap;
                    CBBNhaCungCap.DisplayMember = "manfactoryName";
                    CBBNhaCungCap.ValueMember = "manfactoryId";


             

            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async Task<List<Category>> getDanhSachCate()
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


        public async Task<List<Manfactory>> getDanhSachMan()
        {
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    return await Task.Run(() =>
                    {
                        return context.Manfactory.ToList();
                    });
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return null;
        }

        public  void loadTableTheoDanhSach(List<Product> dsSanPHam)
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("MaSP", typeof(int));
                data.Columns.Add("TenSP", typeof(string));
                data.Columns.Add("nhaCungCap", typeof(int));
                data.Columns.Add("loaiSP", typeof(int));
                data.Columns.Add("soLuong", typeof(int));
                data.Columns.Add("giaBan", typeof(Decimal));
                data.Columns.Add("moTa", typeof(string));


                var ds = dsSanPHam;
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.productId, vi.productName, vi.manfactoryId, vi.categoryId, vi.quantity, vi.price, vi.Decrepsition);
                        }

                    }
                    GVSanPham.DataSource = data;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void loadTable()
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("MaSP", typeof(int));
                data.Columns.Add("TenSP", typeof(string));
                data.Columns.Add("nhaCungCap", typeof(int));
                data.Columns.Add("loaiSP", typeof(int));
                data.Columns.Add("soLuong", typeof(int));
                data.Columns.Add("giaBan", typeof(Decimal));
                data.Columns.Add("moTa", typeof(string));


                var ds = await getProdcut();
                if(ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.productId, vi.productName, vi.manfactoryId, vi.categoryId, vi.quantity, vi.price, vi.Decrepsition);
                        }

                    }
                    GVSanPham.DataSource = data;
                }
             


            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        public async Task<List<Product>> getProdcut()
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {

                    return await Task.Run(() =>
                    {
                        return context.Product.Where(op => op.isDelete == false).ToListAsync();
                    });
                    
                }


            }catch(Exception ex) {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return new List<Product>();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private  void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
               
                bool valid = true;

                string maSP = txtMaSP.Text; 
                if(!string.IsNullOrEmpty(maSP) )
                {
                    return;
                }
                if (string.IsNullOrEmpty(txtSoLuong.Text) || Convert.ToInt32(txtSoLuong.Text) <=0)
                {
                    ErrSanPham.SetError(txtSoLuong, "Số lượng không được để trống hoặc bé hơn 0");
                    valid = false;
                }

                if (string.IsNullOrEmpty(txtGiaBan.Text) || Convert.ToDecimal(txtGiaBan.Text) <= 0)
                {
                    ErrSanPham.SetError(txtGiaBan, "giaBan không được để trống hoặc bé hơn 0");
                    valid = false;
                }


                string tenSP = txtTenSP.Text;
                int soLuong = Convert.ToInt32(txtSoLuong.Text);
                Decimal giaBan = Convert.ToDecimal(txtGiaBan.Text);
                int nhaCungCap = Convert.ToInt32(CBBNhaCungCap.SelectedValue.ToString());
                int loaiSanPham = Convert.ToInt32(CBBLoaiSanPham.SelectedValue.ToString());
                string moTa = txtMota.Text;
                string img = imgString;
               
                if (string.IsNullOrEmpty(tenSP))
                {
                    ErrSanPham.SetError(txtTenSP,"Tên sản phẩm không được để trống");
                    valid = false;
                }

                if (nhaCungCap == 0)
                {
                    ErrSanPham.SetError(CBBNhaCungCap, "Nhà cung cấp không được để trống");
                    valid = false;
                }
                if (loaiSanPham == 0)
                {
                    ErrSanPham.SetError(CBBLoaiSanPham, "Loại sản phẩm không được để trống");
                    valid = false;
                }

                if (!valid)
                {
                  
                    return;
                }
                foreach (Control c in this.Controls)
                {
                    ErrSanPham.SetError(c, null);
                }
                using (var context = new BanSanPhamSen())
                {
                    var sanPham = new Product();

                    sanPham.productName = tenSP;
                    sanPham.price = giaBan;
                    sanPham.quantity = soLuong;
                    sanPham.isDelete = false;
                    sanPham.categoryId = loaiSanPham;
                    sanPham.manfactoryId = nhaCungCap;
                    sanPham.imgs = img;
                    sanPham.Decrepsition = moTa;

                    context.Product.Add(sanPham);
                    context.SaveChanges();

                    MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadTable();
                    clear();


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void clear()
        {
            txtGiaBan.Text = "";
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtMota.Text = "";
            CBBNhaCungCap.SelectedIndex = 0;
            CBBLoaiSanPham.SelectedIndex = 0;
            imgString = "";
            lbHinhAnh.Visible= false;
            btnChonAnh.Visible= false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clear();
            loadTable();
            txtTimKiem.Text = "";
            

        }

        private async void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GVSanPham.CurrentCell.RowIndex;
                var maSP = GVSanPham.Rows[selected].Cells[0].Value.ToString();
                var tenSP = GVSanPham.Rows[selected].Cells[1].Value.ToString();
                var nhaCungCap = Convert.ToInt32(GVSanPham.Rows[selected].Cells[2].Value.ToString());
                var loaiSanPham = Convert.ToInt32(GVSanPham.Rows[selected].Cells[3].Value.ToString());
                var soLuong = GVSanPham.Rows[selected].Cells[4].Value.ToString();
                var giaBan = GVSanPham.Rows[selected].Cells[5].Value.ToString();
                var moTa = GVSanPham.Rows[selected].Cells[6].Value.ToString();


                txtMaSP.Text = maSP;
                txtTenSP.Text = tenSP;
                txtMota.Text = moTa;
                txtSoLuong.Text = soLuong;
                txtGiaBan.Text = giaBan;
                txtMota.Text += moTa;
                CBBLoaiSanPham.SelectedValue = loaiSanPham;
                CBBNhaCungCap.SelectedValue = nhaCungCap;   

                using(var context = new BanSanPhamSen())
                {
                    var sp = await context.Product.FindAsync(Convert.ToInt32(maSP));
                    if (sp != null)
                    {
                        if (!string.IsNullOrEmpty(sp.imgs))
                        {
                            lbHinhAnh.Visible = true;
                            btnChonAnh.Visible = true;
                            btnChonAnh.Text = "Chọn Ảnh";
                        }
                        else
                        {
                            lbHinhAnh.Visible = true;
                            btnChonAnh.Visible = true;
                            btnChonAnh.Text = "Cập nhật ảnh";
                        }

                        if (!string.IsNullOrEmpty(sp.imgs.Trim()))
                        {
							btnXemAnh.Visible= true;    

						}
                    }

                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            { // Hủy sự kiện phím nếu không phải số
              e.Handled = true; 
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            { // Hủy sự kiện phím nếu không phải số
                e.Handled = true;
            }
        }

		public string DocToanBoFile(string filePath)
		{
			try
			{
				string noiDung = File.ReadAllText(filePath); // Đọc toàn bộ nội dung file
				return noiDung;
			}
			catch (Exception ex)
			{
				
				return "";
			}
		}


		private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string maSP = txtMaSP.Text;
                if(string.IsNullOrEmpty(maSP)) {
                    return;
                }

                bool valid = true;

                if (string.IsNullOrEmpty(txtSoLuong.Text) || Convert.ToInt32(txtSoLuong.Text) <= 0)
                {
                    ErrSanPham.SetError(txtSoLuong, "Số lượng không được để trống hoặc bé hơn 0");
                    valid = false;
                }

                if (string.IsNullOrEmpty(txtGiaBan.Text) || Convert.ToDecimal(txtGiaBan.Text) <= 0)
                {
                    ErrSanPham.SetError(txtGiaBan, "giaBan không được để trống hoặc bé hơn 0");
                    valid = false;
                }


                string tenSP = txtTenSP.Text;
                int soLuong = Convert.ToInt32(txtSoLuong.Text);
                Decimal giaBan = Convert.ToDecimal(txtGiaBan.Text);
                int nhaCungCap = Convert.ToInt32(CBBNhaCungCap.SelectedValue.ToString());
                int loaiSanPham = Convert.ToInt32(CBBLoaiSanPham.SelectedValue.ToString());
                string moTa = txtMota.Text;
                string img = imgString;

                if (string.IsNullOrEmpty(tenSP))
                {
                    ErrSanPham.SetError(txtTenSP, "Tên sản phẩm không được để trống");
                    valid = false;
                }

                if (nhaCungCap == 0)
                {
                    ErrSanPham.SetError(CBBNhaCungCap, "Nhà cung cấp không được để trống");
                    valid = false;
                }
                if (loaiSanPham == 0)
                {
                    ErrSanPham.SetError(CBBLoaiSanPham, "Loại sản phẩm không được để trống");
                    valid = false;
                }

                if (!valid)
                {

                    return;
                }
                foreach (Control c in this.Controls)
                {
                    ErrSanPham.SetError(c, null);
                }
                using (var context = new BanSanPhamSen())
                {
                    var sanPham = context.Product.Find(Convert.ToInt32(maSP));
                    if (sanPham != null)
                    {
                        sanPham.price = giaBan;
                        sanPham.quantity = soLuong;
                        sanPham.Decrepsition = moTa;
                        sanPham.productName = tenSP;
                        sanPham.manfactoryId = nhaCungCap;
                        sanPham.categoryId = loaiSanPham;


						string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload", "ChuoiHinh.txt");


						if (File.Exists(filePath))
						{
							imgString = DocToanBoFile(filePath);

                            File.Delete(filePath);

						}


						if (!string.IsNullOrEmpty(imgString))
                        {
                            sanPham.imgs = imgString;
                            imgString = "";
                        }
						


                        context.SaveChanges();
                        MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        loadTable();
                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maSP = txtMaSP.Text;
                if (string.IsNullOrEmpty(maSP))
                {
                    return;
                }

                using(var context = new BanSanPhamSen())
                {
                    var sanPham = context.Product.Find(Convert.ToInt32(maSP));
                    if(sanPham != null )
                    {
                        sanPham.isDelete = true;
                        context.SaveChanges();
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        loadTable();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool ContainsIgnoreCaseAndPunctuation(string source, string target)
        {
            string pattern = @"[^\w\s]";
            source = Regex.Replace(source, pattern, "");
            target = Regex.Replace(target, pattern, "");
            return source.IndexOf(target, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public List<Product> timKiemDanhSach(string chuoiTim)
        {
            var dsTim = new List<Product>();
            try
            {
                int id = -1;
                if(int.TryParse(chuoiTim, out id))
                {
                    id = int.Parse(chuoiTim);
                }
                using(var context = new BanSanPhamSen())
                {
                    var ds = context.Product.Where(op=>op.isDelete == false).ToList();
                    //tim theo id
                    if (id != -1)
                    {
                        foreach(var item in ds)
                        {
                            if(item.productId == id)
                            {
                                dsTim.Add(item);
                                return dsTim;
                            }
                        }
                    }
                    bool isContain = false;
                    foreach (var item in ds)
                    {
                        //tim kiem theo ten sap
                        if(ContainsIgnoreCaseAndPunctuation(item.productName, chuoiTim) && !isContain)
                        {
                            dsTim.Add(item);
                            isContain = true;   
                        }
                        
                        //tim theo gia
                        if(ContainsIgnoreCaseAndPunctuation(item.price.ToString(), chuoiTim) && !isContain) {
                            dsTim.Add(item);
                            isContain = true;
                        }
                        //tim theo số lượng
                        if (ContainsIgnoreCaseAndPunctuation(item.quantity.ToString(), chuoiTim) && !isContain)
                        {
                            dsTim.Add(item);
                            isContain = true;
                        }


                        isContain = false;

                      
                    }




                }




            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return dsTim;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string chuoiTim = txtTimKiem.Text;
                if(string.IsNullOrEmpty(chuoiTim) ) {
                    return;
                }
                var ds = timKiemDanhSach(chuoiTim);

                loadTableTheoDanhSach(ds);




            }catch(Exception ex) {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

		private void btnChonAnh_Click(object sender, EventArgs e)
		{
            try
            {
                //string maQuan = txt_maQuan.Text;
                //if (maQuan != "")
                //{
                //	using (var context = new TuVanQuanAnNhaHangTaiCanThoEntities())
                //	{
                //		var quanAn = context.QuanAns.Find(maQuan);
                //		if (quanAn != null)
                //		{
                //			OpenFileDialog openFile = new OpenFileDialog();
                //			openFile.InitialDirectory = "c:\\";
                //			openFile.Filter = "PNG Files|*.png|GIF Files|*.gif|JPG Files|*.jpg";
                //			openFile.Multiselect = true;
                //			openFile.FilterIndex = 3;
                //			string imgs = "";
                //			if (!string.IsNullOrEmpty(maQuan))
                //			{
                //				if (openFile.ShowDialog() == DialogResult.OK)
                //				{
                //					if (openFile.FileNames.Length > 0)
                //					{
                //						foreach (string file in openFile.FileNames)
                //						{
                //							string destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", Path.GetFileName(file));
                //							if (File.Exists(destFile))
                //							{
                //								destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", Path.GetFileNameWithoutExtension(file) + "_" + DateTime.Now.Ticks + Path.GetExtension(file));
                //							}
                //							File.Copy(file, destFile);
                //							imgs += Path.GetFileName(file) + "\n";
                //						}
                //						//  File.Copy(openFile.FileName, Directory.GetCurrentDirectory()+"\\img\\"+ openFile.SafeFileName);
                //						quanAn.imgs = imgs;
                //						context.SaveChanges();
                //						reLoadTable();
                //						MessageBox.Show("Thêm ảnh thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //					}

                //				}
                //			}


                //		}

                //	}
                //}

                var form = new FrmUploadAnhSanPham();

                form.ShowDialog();




			}
			catch(Exception ex )
            {
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnXemAnh_Click(object sender, EventArgs e)
		{
            try
            {
                string masp = txtMaSP.Text; 
                if(string.IsNullOrEmpty(masp)) { return; }
                using(var context = new BanSanPhamSen())
                {
                    var sanPham = context.Product.Find(Convert.ToInt32(masp));
                    if(sanPham != null)
                    {
						var form = new XemAnhSanPham(sanPham, sanPham.imgs);
						form.ShowDialog();
					}
                }


              


            }catch(Exception ex)
            {
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}
		}

        private void GVSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
