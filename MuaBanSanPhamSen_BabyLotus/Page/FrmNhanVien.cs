
using BeHatSenLotus.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            }
            catch{ }
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {
                    return await Task.Run(() =>
                    {
                        return context.Employees.ToList();
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
                        data.Rows.Add(vi.EmployeeId, vi.FullName, vi.PhoneNumber, vi.Email, vi.Address, vi.Position, vi.Gender);
                    }
                   
                }
                GVNhanVien.DataSource = data;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu! Lỗi "+ex,"Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string tenNV = txtHoTen.Text.Trim();
                string email = txtEmail.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                int gioiTinh = Convert.ToInt32(CBBGioiTinh.SelectedValue);
                string sdt = txtSDT.Text.Trim();   
                string chucVu = txtViTri.Text.Trim();
                DateTime ngaySinh = DTPK_ngaySinh.Value;
                if (string.IsNullOrEmpty(tenNV))
                {
                    ErrFrmNhanVien.SetError(txtHoTen, "Tên không được bỏ trống! Ví dụ: Định Hình Phương Hướng");
                }
                if (string.IsNullOrEmpty(diaChi))
                {
                    ErrFrmNhanVien.SetError(txtDiaChi, "Địa chỉ không được bỏ trống!");
                }
                if (string.IsNullOrEmpty(diaChi))
                {
                    ErrFrmNhanVien.SetError(txtViTri, "Chức vụ không được bỏ trống!");
                }
                if (!IsValidEmail(email) || string.IsNullOrEmpty(email))
                {
                    ErrFrmNhanVien.SetError(txtEmail, "Email không được bỏ trống hoặc sai định dạng! Ví dụ: J97@gmail.com");
                }
                if(string.IsNullOrEmpty(sdt) || !IsValidPhoneNumber(sdt))
                {
                    ErrFrmNhanVien.SetError(txtSDT, "Số điện thoại không được rỗng hoặc sai định dạng (quá 10 số)! Ví dụ: 0125xxxxxx");
                }

                if(gioiTinh == 0)
                {
                    MessageBox.Show("Bạn chưa chọn giới tính!", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                //tien hanh them nhan vie moi

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
                    MessageBox.Show("Thêm nhân viên thành công!");



                    // Tạo account
                    var acc = new Account
                    {
                        username = nhanVien.Email,
                        passs = nhanVien.PhoneNumber,
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
                    MessageBox.Show("thêm account va accountper thành công!");
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : "+ ex);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }      
    }
}
