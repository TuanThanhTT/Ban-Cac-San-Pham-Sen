using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmQuanLyKhachHang : UserControl
    {
        public FrmQuanLyKhachHang()
        {
            InitializeComponent();
            loadTableKhachHang();
        }


        public async void loadTableKhachHang()
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Ten", typeof(string));
                data.Columns.Add("Email", typeof(int));
                data.Columns.Add("Phone", typeof(int));
                data.Columns.Add("Gender", typeof(int));
                data.Columns.Add("DiaChi", typeof(Decimal));


                var ds = await getDanhSachUser();
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.UserId, vi.FullName, vi.Email, vi.PhoneNumber, vi.Gender, vi.Address);
                        }

                    }
                    GVKhachHang.DataSource = data;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public  void loadTableKhachHangBangDanhSach(List<User>dsTim)
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Name", typeof(string));
                data.Columns.Add("Email", typeof(int));
                data.Columns.Add("Phone", typeof(int));
                data.Columns.Add("Gender", typeof(int));
                data.Columns.Add("DiaChi", typeof(Decimal));



                var ds = dsTim;
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.UserId, vi.FullName, vi.Email, vi.PhoneNumber, vi.Gender, vi.Address);
                        }

                    }
                    GVKhachHang.DataSource = data;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<List<User>> getDanhSachUser()
        {
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    return await Task.Run(() =>
                    {
                        return context.Users.Where(op => op.IsDelete == false).ToList();
                    });
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return null;
        }


        private void FrmQuanLyKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnXemChonKH_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GVKhachHang.CurrentCell.RowIndex;
                var maKH = GVKhachHang.Rows[selected].Cells[0].Value.ToString();
                var tenKH = GVKhachHang.Rows[selected].Cells[1].Value.ToString();
                var email = (GVKhachHang.Rows[selected].Cells[2].Value.ToString());
                var phone = (GVKhachHang.Rows[selected].Cells[3].Value.ToString());
                var gioiTinh = GVKhachHang.Rows[selected].Cells[4].Value.ToString();
                var diaChi = GVKhachHang.Rows[selected].Cells[5].Value.ToString();


                txtDiaChi.Text = diaChi;
                txtDienThoai.Text = phone;
                txtMaKH.Text = maKH;
                txtTenKH.Text = tenKH;
                txtEmail.Text = email;
                txtGioiTinh.Text = gioiTinh;
                

              


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtKhoaTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = txtMaKH.Text.Trim();
                if(string.IsNullOrEmpty(maKH) )
                {
                    return;
                }

                using(var context = new BanSanPhamSen())
                {
                    var sanPham = context.Users.Find(Convert.ToInt32(maKH));
                    if (sanPham != null)
                    {
                        sanPham.IsDelete= true;
                        context.SaveChanges();
                        loadTableKhachHang();
                        clear();
                        MessageBox.Show("Khóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void clear()
        {
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtGioiTinh.Text = "";
            txtHoaDon.Text = "";
            txtUserName.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtTim.Text = "";
            txtThanhTien.Text = "";
          
        }
    }
}
