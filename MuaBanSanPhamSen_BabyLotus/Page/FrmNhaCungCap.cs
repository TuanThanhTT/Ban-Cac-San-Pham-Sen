using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmNhaCungCap : UserControl
    {
        public FrmNhaCungCap()
        {
            InitializeComponent();
            loadtableNhaCUngCap();
        }

        public async void loadtableNhaCUngCap()
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(string));
                data.Columns.Add("Name", typeof(string));
                data.Columns.Add("Email", typeof(string));
                data.Columns.Add("DiaChi", typeof(string));
                data.Columns.Add("City", typeof(string));
                data.Columns.Add("Phone", typeof(string));
                data.Columns.Add("Country", typeof(string));


                var ds = await getDanhSachNhaCungCap();
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.manfactoryId, vi.manfactoryName, vi.email, vi.Address, vi.city, vi.phoneNumber, vi.country);
                        }

                    }
                    GVNhaCungCap.DataSource = data;
                }



            }
            catch(Exception ex) { 
                MessageBox.Show("Lỗi: "+ex.Message,"Lỗi0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public  void loadtableNhaCUngCapBangDanhSach(List<Manfactory> dsTim)
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(string));
                data.Columns.Add("Name", typeof(string));
                data.Columns.Add("Email", typeof(string));
                data.Columns.Add("DiaChi", typeof(string));
                data.Columns.Add("City", typeof(string));
                data.Columns.Add("Phone", typeof(string));
                data.Columns.Add("Country", typeof(string));


                var ds = dsTim;
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.manfactoryId, vi.manfactoryName, vi.email, vi.Address, vi.city, vi.phoneNumber, vi.country);
                        }

                    }
                    GVNhaCungCap.DataSource = data;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task<List<Manfactory>> getDanhSachNhaCungCap()
        {
            try
            {
                using (var context = new BanSanPhamSen())
                {

                    return await Task.Run(() =>
                    {
                        return context.Manfactory.Where(op => op.isDelete == false).ToListAsync();
                    });

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return new List<Manfactory>();
        }



        private void label4_Click(object sender, EventArgs e)
        {

        }
        public bool IsValidPhoneNumber(string phoneNumber)
        {

            return phoneNumber[0] == '0' && phoneNumber.Length == 10;
        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                var maNCC = txtMaNCC.Text;
                if (!string.IsNullOrEmpty(maNCC))
                {
                    return;
                }
                bool valid = true;

                string tenNCC = txtTenNCC.Text;
                if (string.IsNullOrEmpty(tenNCC))
                {
                    ErrMess.SetError(txtTenNCC,"Tên nhà cung cấp không được bỏ trống");
                    valid = false;
                }
                string email = txtEmail.Text;

                if(!IsValidEmail(email)) {
                    ErrMess.SetError(txtEmail, "Email nhà cung cấp không được bỏ trống");
                    valid = false;
                }

                string sdt = txtDienThoai.Text;
                //MessageBox.Show("sdt hop le: " + IsValidPhoneNumber(sdt));
                if(!IsValidPhoneNumber(sdt))
                {
                    ErrMess.SetError(txtDienThoai, "Số điện thoại nhà cung cấp không được bỏ trống và phải đủ 10 bắt đàu bằng 0");
                    valid = false;
                }

                string city = txtThanhPho.Text;

                if(string.IsNullOrEmpty(city)) {
                    ErrMess.SetError(txtThanhPho, "Tên Thành phố không được bỏ trống");
                    valid = false;
                }

                string quocGia = txtQuocGia.Text;
                if (string.IsNullOrEmpty(quocGia))
                {
                    ErrMess.SetError(txtQuocGia, "Tên quốc gia nhà cung cấp không được bỏ trống");
                    valid = false;
                }

                string diaChi = txtDiaChi.Text;

                if (string.IsNullOrEmpty(diaChi))
                {
                    ErrMess.SetError(txtDiaChi, "Đại chỉ nhà cung cấp không được bỏ trống");
                    valid = false;
                }



                if (!valid)
                {
                    return;
                }
                else
                {
                    foreach (Control c in this.Controls)
                    {
                        ErrMess.SetError(c, null);
                    }

                    using (var context = new BanSanPhamSen())
                    {
                        ErrMess.Clear();
                        var ds = context.Manfactory.Count();
                        int id = ds + 1;
                        var nhaCC = new Manfactory
                        {
                            manfactoryId = id,
                            manfactoryName = tenNCC,
                            Address = diaChi,
                            city = city,
                            email = email,
                            country = quocGia,
                            phoneNumber = sdt,
                            isDelete = false,
                        };

                        context.Manfactory.Add(nhaCC);
                        context.SaveChanges();
                        MessageBox.Show("Thêm nhà cung cấp thành công!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        loadtableNhaCUngCap();


                    }
                }
              



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clear()
        {
            txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtQuocGia.Text = txtMaNCC.Text = txtTenNCC.Text = txtThanhPho.Text = txtTimKiem.Text = "";

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clear();
            loadtableNhaCUngCap();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var maNCC = txtMaNCC.Text;
                if (string.IsNullOrEmpty(maNCC))
                {
                    return;
                }
               

                using (var context = new BanSanPhamSen())
                {
                   
                    var nhaCungCap = context.Manfactory.Find(Convert.ToInt32(maNCC));   
                    if(nhaCungCap!= null)
                    {
                        nhaCungCap.isDelete = true;
                        context.SaveChanges();
                        MessageBox.Show("Xóa nhà cung cấp thành công!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        loadtableNhaCUngCap();
                    }
                }



            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {

                var maNCC = txtMaNCC.Text;
                if (string.IsNullOrEmpty(maNCC))
                {
                    return;
                }
                bool valid = true;

                string tenNCC = txtTenNCC.Text;
                if (string.IsNullOrEmpty(tenNCC))
                {
                    ErrMess.SetError(txtTenNCC, "Tên nhà cung cấp không được bỏ trống");
                    valid = false;
                }
                string email = txtEmail.Text;

                if (!IsValidEmail(email))
                {
                    ErrMess.SetError(txtEmail, "Email nhà cung cấp không được bỏ trống");
                    valid = false;
                }

                string sdt = txtDienThoai.Text;
                if (!IsValidPhoneNumber(sdt))
                {
                    ErrMess.SetError(txtDienThoai, "Số điện thoại nhà cung cấp không được bỏ trống");
                    valid = false;
                }

                string city = txtThanhPho.Text;

                if (string.IsNullOrEmpty(city))
                {
                    ErrMess.SetError(txtThanhPho, "Tên Thành phố không được bỏ trống");
                    valid = false;
                }

                string quocGia = txtQuocGia.Text;
                if (string.IsNullOrEmpty(quocGia))
                {
                    ErrMess.SetError(txtQuocGia, "Tên quốc gia nhà cung cấp không được bỏ trống");
                    valid = false;
                }

                string diaChi = txtDiaChi.Text;

                if (string.IsNullOrEmpty(diaChi))
                {
                    ErrMess.SetError(txtDiaChi, "Đại chỉ nhà cung cấp không được bỏ trống");
                    valid = false;
                }



                if (!valid)
                {
                    return;
                }
                else
                {
                    foreach (Control c in this.Controls)
                    {
                        ErrMess.SetError(c, null);
                    }

                    using (var context = new BanSanPhamSen())
                    {

                        var nhaCungCap = context.Manfactory.Find(Convert.ToInt32(maNCC));
                        if (nhaCungCap != null)
                        {
                            nhaCungCap.manfactoryName = tenNCC;
                            nhaCungCap.Address = diaChi;
                            nhaCungCap.country = quocGia;
                            nhaCungCap.city = city;
                            nhaCungCap.email = email;
                            nhaCungCap.phoneNumber = sdt;
                            context.SaveChanges();
                            MessageBox.Show("Thêm nhà cung cấp thành công!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear();
                            loadtableNhaCUngCap();
                        }

                    }

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GVNhaCungCap.CurrentCell.RowIndex;
                var maNCC = GVNhaCungCap.Rows[selected].Cells[0].Value.ToString();
                var tenNCC = GVNhaCungCap.Rows[selected].Cells[1].Value.ToString();
                var email = (GVNhaCungCap.Rows[selected].Cells[2].Value.ToString());
                var diaChi = (GVNhaCungCap.Rows[selected].Cells[3].Value.ToString());
                var thanhPho = GVNhaCungCap.Rows[selected].Cells[4].Value.ToString();
                var sdt = GVNhaCungCap.Rows[selected].Cells[5].Value.ToString();
                var QuocGia = GVNhaCungCap.Rows[selected].Cells[6].Value.ToString();

                txtMaNCC.Text = maNCC;
                txtTenNCC.Text = tenNCC;
                txtThanhPho.Text = thanhPho;
                txtDienThoai.Text = sdt;
                txtEmail.Text = email;
                txtQuocGia.Text = QuocGia;
                txtDiaChi.Text = diaChi;
       
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string chuoiTim = txtTimKiem.Text;
                if (string.IsNullOrEmpty(chuoiTim))
                {
                    return;
                }
                var ds = await XuLyTimKiem(chuoiTim);

                loadtableNhaCUngCapBangDanhSach(ds);

            }
            catch (Exception ex)
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


        public async Task<List<Manfactory>> XuLyTimKiem(string chuoiTim)
        {
            var dsNhaCungCap = new List<Manfactory>();

            int maNCC = -1;
            if (int.TryParse(chuoiTim, out maNCC))
            {
                maNCC = int.Parse(chuoiTim);
            }


            try
            {
                using (var contxet = new BanSanPhamSen())
                {
                    //tim thep ma
                    if (maNCC != -1)
                    {
                        var nhaCC = await contxet.Manfactory.FindAsync(maNCC);
                        if (nhaCC != null)
                        {
                            dsNhaCungCap.Add(nhaCC);
                            return dsNhaCungCap;
                        }
                    }
                    //tim theo ten
                    var ds = await contxet.Manfactory.ToListAsync();
                    bool isContain = false;
                    foreach (var item in ds)
                    {
                        //tim theo ten
                        if (ContainsIgnoreCaseAndPunctuation(item.manfactoryName, chuoiTim) && !isContain)
                        {
                            dsNhaCungCap.Add(item);
                            isContain = true;
                        }
                        //tim theo so dien thoai
                        if (ContainsIgnoreCaseAndPunctuation(item.phoneNumber.ToString(), chuoiTim) && !isContain)
                        {
                            dsNhaCungCap.Add(item);
                            isContain = true;
                        }
                        //tim theo dia chi
                        if (ContainsIgnoreCaseAndPunctuation(item.Address, chuoiTim) && !isContain)
                        {
                            dsNhaCungCap.Add(item);
                            isContain = true;
                        }
                        //tim theo quocgia
                        if (ContainsIgnoreCaseAndPunctuation(item.country, chuoiTim) && !isContain)
                        {
                            dsNhaCungCap.Add(item);
                            isContain = true;
                        }
                        //tim theo thanh phố
                        if (ContainsIgnoreCaseAndPunctuation(item.city, chuoiTim) && !isContain)
                        {
                            dsNhaCungCap.Add(item);
                            isContain = true;
                        }
                        //tim theo email
                        if (ContainsIgnoreCaseAndPunctuation(item.email, chuoiTim) && !isContain)
                        {
                            dsNhaCungCap.Add(item);
                            isContain = true;
                        }

                        isContain = false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return dsNhaCungCap;
        }


       
    }
}
