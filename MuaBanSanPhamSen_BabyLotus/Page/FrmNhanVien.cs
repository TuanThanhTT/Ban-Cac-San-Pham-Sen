
using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Service;
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
    public partial class FrmNhanVien : UserControl
    {
        public FrmNhanVien()
        {
            InitializeComponent();
            loadComBoBox();
            loadGridView();
           
        }


        public void loadComBoBox()
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Name", typeof(string));

                data.Rows.Add(0, "Chọn");
                data.Rows.Add(1, "Nam");
                data.Rows.Add(2, "Nữ");

                CBBGioiTinh.DataSource = data;
                CBBGioiTinh.DisplayMember = "Name";
                CBBGioiTinh.ValueMember = "Id";

                DataTable chucVu = new DataTable();
                chucVu.Columns.Add("ID", typeof(int));
                chucVu.Columns.Add("Name", typeof(string));

                chucVu.Rows.Add(0, "");
                chucVu.Rows.Add(1, "Nhân Viên Bán Hàng");
                chucVu.Rows.Add(2, "Nhân Viên Kho");
                chucVu.Rows.Add(3, "Nhân Viên Quản Lý");

                CBB_ChucVu.DataSource = chucVu;
                CBB_ChucVu.DisplayMember = "Name";
                CBB_ChucVu.ValueMember= "Name";   

            }
            catch(Exception ex){
                MessageBox.Show("Có lỗi xảy ra! Lỗi " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {
                    return await Task.Run(() =>
                    {
                        return context.Employees.Where(op=>op.IsDelete==false).ToList();
                    });
                }
               
            }
            catch { }
            return new List<Employee>();
        }

        public async void loadGridView()
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("EmployeeId", typeof(int));
                data.Columns.Add("FullName", typeof(string));
                data.Columns.Add("PhoneNumber", typeof(string));
                data.Columns.Add("Email", typeof(string));
                data.Columns.Add("Address", typeof(string));
                data.Columns.Add("position", typeof(string));
                data.Columns.Add("gender", typeof(string));

                var nhanViens = await GetEmployeesAsync();
                
                if (nhanViens.Count() > 0)
                {
                    foreach (var vi in nhanViens)
                    {
                        data.Rows.Add(vi.EmployeeId, vi.FullName, vi.PhoneNumber, vi.Email, vi.Address, vi.Position, vi.Gender?"Nam":"Nữ");
                    }
                   
                }
                GVNhanVien.DataSource = data;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu! Lỗi "+ex,"Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public  void loadGridViewTheoDs(List<Employee> ds)
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("EmployeeId", typeof(int));
                data.Columns.Add("FullName", typeof(string));
                data.Columns.Add("PhoneNumber", typeof(string));
                data.Columns.Add("Email", typeof(string));
                data.Columns.Add("Address", typeof(string));
                data.Columns.Add("position", typeof(string));
                data.Columns.Add("gender", typeof(string));

                var nhanViens = ds;

                if (nhanViens.Count() > 0)
                {
                    foreach (var vi in nhanViens)
                    {
                        data.Rows.Add(vi.EmployeeId, vi.FullName, vi.PhoneNumber, vi.Email, vi.Address, vi.Position, vi.Gender ? "Nam" : "Nữ");
                    }

                }
                GVNhanVien.DataSource = data;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu! Lỗi " + ex, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      


            public bool IsValidEmail(string email)
        { 
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {

            return phoneNumber[0] == '0'&&phoneNumber.Length == 10;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text;
                if(!string.IsNullOrEmpty(maNV)) {
                    return;
                }

                string tenNV = txtHoTen.Text.Trim();
                string email = txtEmail.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                int gioiTinh = Convert.ToInt32(CBBGioiTinh.SelectedValue);
                string sdt = txtSDT.Text.Trim();   
                string chucVu = CBB_ChucVu.SelectedValue.ToString();
                DateTime ngaySinh = DTPK_ngaySinh.Value;
                if (string.IsNullOrEmpty(tenNV))
                {
                    ErrFrmNhanVien.SetError(txtHoTen, "Tên không được bỏ trống! Ví dụ: Định Hình Phương Hướng");
                    return;
                }
                if (string.IsNullOrEmpty(diaChi))
                {
                    ErrFrmNhanVien.SetError(txtDiaChi, "Địa chỉ không được bỏ trống!");
                    return;
                }
               
                if (!IsValidEmail(email) || string.IsNullOrEmpty(email))
                {
                    ErrFrmNhanVien.SetError(txtEmail, "Email không được bỏ trống hoặc sai định dạng! Ví dụ: J97@gmail.com");
                    return;
                }
                if(string.IsNullOrEmpty(sdt) || !IsValidPhoneNumber(sdt))
                {
                    ErrFrmNhanVien.SetError(txtSDT, "Số điện thoại không được rỗng hoặc sai định dạng (quá 10 số)! Ví dụ: 0125xxxxxx");
                    return;
                }

                if(gioiTinh == 0)
                {
                    MessageBox.Show("Bạn chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (chucVu == "")
                {
                    MessageBox.Show("Bạn chưa chọn chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if ((DateTime.Now.Year - ngaySinh.Year)<18)
                {
                    ErrFrmNhanVien.SetError(DTPK_ngaySinh, "Tuổi của nhân viên phải từ 18 tuổi!");
                    return;
                }

                //tien hanh them nhan vie moi
                foreach (Control c in this.Controls)
                {
                    ErrFrmNhanVien.SetError(c, null);
                }
                using (var context = new BanSanPhamSen())
                {
                    var nhanVien = new Employee
                    {
                        FullName = tenNV,
                        Email = email,
                        Gender = Convert.ToBoolean(gioiTinh),
                        Address = diaChi,
                        Position = chucVu,
                        PhoneNumber = sdt,
                        BirthDay = ngaySinh
                    };

                    //them nhan vien vo truoc
                    context.Employees.Add(nhanVien);
                    context.SaveChanges();
                    



                    // Tạo account
                    var acc = new Account
                    {
                        username = nhanVien.Email,
                        passs = MaHoaMD5.GetMd5Hash(nhanVien.PhoneNumber),
                        createDate = DateTime.Now,
                        IsLocked = false,
                        EmployAccountId = nhanVien.EmployeeId
                    };

                    // Tạo account permisstion
                    var accountPer = new AccountPermisstion
                    {
                        accountId = acc.accountId,
                        permissitionId = 2
                    };

                    // Thêm Account và AccountPermisstion
                    context.Account.Add(acc);
                    context.AccountPermisstion.Add(accountPer);

                  
                    context.SaveChanges();
                    MessageBox.Show("Thêm nhân viên mới thành công!","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //load lại gridView
                    loadGridView();
                    clear();
                }
                ClearAllErrors(ErrFrmNhanVien, this);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra! Lỗi : "+ ex.Message);
            }
        }
        private void ClearAllErrors(ErrorProvider errorProvider, Control control) 
        {
            errorProvider.SetError(control, string.Empty);
            foreach (Control child in control.Controls) 
            { 
                ClearAllErrors(errorProvider, child); 
            } 
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        public void clear()
        {
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtHoTen.Text = "";
            txtMaNV.Text = "";
            txtSDT.Text = "";
            
            txtTimKiem.Text = "";
            CBBGioiTinh.SelectedIndex = 0;
            CBB_ChucVu.SelectedIndex = 0;
            DTPK_ngaySinh.Value = DateTime.Now;
        }


        private void btnClear_Click(object sender, EventArgs e)
        {

            clear();
            loadGridView(); 
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GVNhanVien.CurrentCell.RowIndex;
                var quanId = GVNhanVien.Rows[selected].Cells[0].Value.ToString();

                var maNV = GVNhanVien.Rows[selected].Cells[0].Value.ToString();
                var tenNV = GVNhanVien.Rows[selected].Cells[1].Value.ToString();
                var sdt = GVNhanVien.Rows[selected].Cells[2].Value.ToString();
                var email = GVNhanVien.Rows[selected].Cells[3].Value.ToString();
                var diaChi = GVNhanVien.Rows[selected].Cells[4].Value.ToString();
                var chucVu = GVNhanVien.Rows[selected].Cells[5].Value.ToString();
                var gioiTinh = (GVNhanVien.Rows[selected].Cells[6].Value.ToString()=="Nam"?1:0);

              

                txtMaNV.Text = maNV;
                txtHoTen.Text = tenNV;
                txtSDT.Text = sdt;
                txtEmail.Text = email;  
                txtDiaChi.Text = diaChi;
                CBB_ChucVu.SelectedValue = chucVu;   
                CBBGioiTinh.SelectedValue= gioiTinh; 

                using(var context = new BanSanPhamSen())
                {
                    var nhanVien =  context.Employees.Find(Convert.ToInt32(maNV));
                    if(nhanVien!= null)
                    {
                        DTPK_ngaySinh.Value = nhanVien.BirthDay;
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: "+ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text;
                if (string.IsNullOrEmpty(maNV))
                {
                    return;
                
                }

                string tenNV = txtHoTen.Text.Trim();
                string email = txtEmail.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                int gioiTinh = Convert.ToInt32(CBBGioiTinh.SelectedValue);
                string sdt = txtSDT.Text.Trim();
                string chucVu = CBB_ChucVu.SelectedValue.ToString();
                DateTime ngaySinh = DTPK_ngaySinh.Value;

                bool valid = true;

                if (string.IsNullOrEmpty(tenNV))
                {
                    ErrFrmNhanVien.SetError(txtHoTen, "Tên không được bỏ trống! Ví dụ: Định Hình Phương Hướng");
                    valid = false;
                }
                if (string.IsNullOrEmpty(diaChi))
                {
                    ErrFrmNhanVien.SetError(txtDiaChi, "Địa chỉ không được bỏ trống!");
                    valid = false;
                }

                if (!IsValidEmail(email) || string.IsNullOrEmpty(email))
                {
                    ErrFrmNhanVien.SetError(txtEmail, "Email không được bỏ trống hoặc sai định dạng! Ví dụ: J97@gmail.com");
                    valid = false;
                }
                if (string.IsNullOrEmpty(sdt) || !IsValidPhoneNumber(sdt))
                {
                    ErrFrmNhanVien.SetError(txtSDT, "Số điện thoại không được rỗng hoặc sai định dạng (quá 10 số)! Ví dụ: 0125xxxxxx");
                    valid = false;
                }

                if (gioiTinh == 0)
                {
                    MessageBox.Show("Bạn chưa chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    valid = false;
                }
                if (chucVu == "")
                {
                    MessageBox.Show("Bạn chưa chọn chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    valid = false;
                }
                if ((DateTime.Now.Year - ngaySinh.Year) < 18)
                {
                    ErrFrmNhanVien.SetError(DTPK_ngaySinh, "Tuổi của nhân viên phải từ 18 tuổi!");
                    valid = false;
                }

                if (!valid) return;
                foreach (Control c in this.Controls)
                {
                    ErrFrmNhanVien.SetError(c, null);
                }
                using (var context = new BanSanPhamSen())
                {
                    var nhanVien = await context.Employees.FindAsync(Convert.ToInt32(maNV));
                    if(nhanVien!= null)
                    {
                        nhanVien.FullName = tenNV;
                        nhanVien.PhoneNumber = sdt;
                        nhanVien.Email = email;
                        nhanVien.Position = chucVu;
                        nhanVien.BirthDay = ngaySinh;
                        nhanVien.Address = diaChi;
                        nhanVien.Gender = (gioiTinh == 1 ? true : false);
                        await context.SaveChangesAsync();
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        loadGridView();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text; 
                if(!string.IsNullOrEmpty(maNV))
                {
                    using(var context = new BanSanPhamSen())
                    {
                        var nhanVien = await context.Employees.FindAsync(Convert.ToInt32(maNV));
                        if(nhanVien!= null)
                        {
                            DialogResult result = MessageBox.Show("Bạn có muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {

                                nhanVien.IsDelete = true;
                                //khoa luon tai khoan'
                                var acc = context.Account.Where(s => s.EmployAccountId == nhanVien.EmployeeId).FirstOrDefault();
                                if(acc != null) {
                                    acc.IsLocked = true;
                                    await context.SaveChangesAsync();
                                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    loadGridView();
                                    clear();
                                }
                                
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }



            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        public static bool ContainsIgnoreCaseAndPunctuation(string source, string target)
        { 
            string pattern = @"[^\w\s]"; 
            source = Regex.Replace(source, pattern, ""); 
            target = Regex.Replace(target, pattern, "");
            return source.IndexOf(target, StringComparison.OrdinalIgnoreCase) >= 0;
        }


            public async Task<List<Employee>> XuLyTimKiem(string chuoiTim)
        {
            var dsNhanVien = new List<Employee>();

            int maNV = -1;
            if(int.TryParse(chuoiTim, out maNV))
            {
                maNV = int.Parse(chuoiTim);
            }
          

            try
            {
                using (var contxet = new BanSanPhamSen())
                {
                    //tim thep ma
                    if (maNV != -1)
                    {
                        var nhanVien = await contxet.Employees.FindAsync(maNV);
                        if (nhanVien != null && nhanVien.IsDelete == false)
                        {
                            dsNhanVien.Add(nhanVien);
                            return dsNhanVien;
                        }
                    }
                    //tim theo ten
                    var ds = await contxet.Employees.ToListAsync();
                    bool isContain = false;
                    foreach (var item in ds)
                    {
                        if(item.IsDelete == false)
                        {
                            //tim theo ten
                            if (ContainsIgnoreCaseAndPunctuation(item.FullName, chuoiTim) && !isContain)
                            {
                                dsNhanVien.Add(item);
                                isContain = true;
                            }
                            //tim theo so dien thoai
                            if (ContainsIgnoreCaseAndPunctuation(item.PhoneNumber.ToString(), chuoiTim) && !isContain)
                            {
                                dsNhanVien.Add(item);
                                isContain = true;
                            }
                            //tim theo dia chi
                            if (ContainsIgnoreCaseAndPunctuation(item.Address, chuoiTim) && !isContain)
                            {
                                dsNhanVien.Add(item);
                                isContain = true;
                            }
                            //tim theo chuc vu
                            if (ContainsIgnoreCaseAndPunctuation(item.Position, chuoiTim) && !isContain)
                            {
                                dsNhanVien.Add(item);
                                isContain = true;
                            }
                            isContain = false;
                        }
                     
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return dsNhanVien;
        }


        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string chuoiTim = txtTimKiem.Text;
                if(string.IsNullOrEmpty(chuoiTim)) {
                    return;
                }
                var ds = await XuLyTimKiem(chuoiTim);

                loadGridViewTheoDs(ds);
 
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
