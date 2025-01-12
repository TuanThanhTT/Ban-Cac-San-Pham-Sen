using BeHatSenLotus.Migrations;
using BeHatSenLotus.Model;
using MuaBanSanPhamSen_BabyLotus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmTaiKhoan : UserControl
    {
        public FrmTaiKhoan()
        {
            InitializeComponent();
            loadCombobox();
            LoadTaiKhoan();
        }


        public async void loadCombobox()
        {
            try
            {
                var ds = await getLoaiTaiKhoan();
                ds.Insert(0, new Permissition { permissitionId = -1, permissitionName = "" });
                
                if (ds != null)
                {
                    var dsLoc = new List<Permissition>();
                    dsLoc.AddRange(ds);


                    CBB_EditLoaiTaiKhoan.DataSource = ds;
                    CBB_EditLoaiTaiKhoan.DisplayMember = "permissitionName";
                    CBB_EditLoaiTaiKhoan.ValueMember = "permissitionId";

                    CBB_LocLoaiTaiKhoan.DataSource = dsLoc;
                    CBB_LocLoaiTaiKhoan.DisplayMember = "permissitionName";
                    CBB_LocLoaiTaiKhoan.ValueMember = "permissitionId";

                }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        public async Task<List<Permissition>> getLoaiTaiKhoan()
        {
            using(var context = new BanSanPhamSen())
            {
                return await Task.Run(async () =>
                {
                    return await context.Permissition.ToListAsync();
                });
                    
            }
        }




        public async void LoadTaiKhoan()
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Name", typeof(string));
                data.Columns.Add("Quyen", typeof(string));
                data.Columns.Add("NgayTao", typeof(string));
                data.Columns.Add("TrangThai", typeof(string));



                var ds = await Task.Run(()=>getDanhSachAccount());
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.accountId, vi.usserName, vi.quyenTaiKhoan, vi.ngayTao.ToString("dd/MM/yyyy"), vi.TrangThai);
                        }

                    }
                    GVTaiKhoan.DataSource = data;
                }
               




            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async Task<List<DanhSachTaiKhoan>> getDanhSachAccount()
        {
            using (var context = new BanSanPhamSen())
            {
                List<DanhSachTaiKhoan> dsTaiKhoan = await (from acc in context.Account
                                 join accper in context.AccountPermisstion on acc.accountId equals accper.accountId
                                 join per in context.Permissition on accper.permissitionId equals per.permissitionId
                                 select new DanhSachTaiKhoan
                                 {
                                     accountId = acc.accountId,
                                     loaiTaiKhoan = per.permissitionName,
                                     quyenTaiKhoan = per.permissitionName,
                                     ngayTao = acc.createDate,
                                     usserName = acc.username,
                                     avartar = acc.avartar,
                                     TrangThai = (acc.IsLocked)?"Đã khóa" : "Hoạt động"
                                 }).ToListAsync();

                return dsTaiKhoan;




            }
        }
        public async void LoadTaiKhoanTheoLoai(int loaiTaiKhaon)
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Name", typeof(string));
                data.Columns.Add("Quyen", typeof(string));
                data.Columns.Add("NgayTao", typeof(string));
                data.Columns.Add("TrangThai", typeof(string));



                var ds = await Task.Run(() => getDanhSachAccountTheoLoai(loaiTaiKhaon));
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.accountId, vi.usserName, vi.quyenTaiKhoan, vi.ngayTao.ToString("dd/MM/yyyy"), vi.TrangThai);
                        }

                    }
                    GVTaiKhoan.DataSource = data;
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async Task<List<DanhSachTaiKhoan>> getDanhSachAccountTheoLoai(int loaiTaiKhoan)
        {
            using (var context = new BanSanPhamSen())
            {
                List<DanhSachTaiKhoan> dsTaiKhoan = await (from acc in context.Account
                                                           join accper in context.AccountPermisstion on acc.accountId equals accper.accountId
                                                           join per in context.Permissition on accper.permissitionId equals per.permissitionId
                                                           where per.permissitionId == loaiTaiKhoan
                                                           select new DanhSachTaiKhoan
                                                           {
                                                               accountId = acc.accountId,
                                                               loaiTaiKhoan = per.permissitionName,
                                                               quyenTaiKhoan = per.permissitionName,
                                                               ngayTao = acc.createDate,
                                                               usserName = acc.username,
                                                               avartar = acc.avartar,
                                                               TrangThai = (acc.IsLocked) ? "Đã khóa" : "Hoạt động"
                                                           }).ToListAsync();

                return dsTaiKhoan;




            }
        }


        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = GVTaiKhoan.CurrentCell.RowIndex;
                var accountId = GVTaiKhoan.Rows[selected].Cells[0].Value.ToString();

                var tenTaiKhoan = GVTaiKhoan.Rows[selected].Cells[1].Value.ToString();
                var quyenTaiKhoan = GVTaiKhoan.Rows[selected].Cells[2].Value.ToString();
                var ngayTao = GVTaiKhoan.Rows[selected].Cells[3].Value.ToString();
            
                txtAccountId.Text = accountId;  
                txtTenDangNhap.Text = tenTaiKhoan;
                txtLoaiTaiKhoan.Text = quyenTaiKhoan;
                txtNgayTao.Text = ngayTao;

             

               
                var id = await  getRoleIdAccount(Convert.ToInt32(accountId));
                if (id != -1)
                {
                    CBB_EditLoaiTaiKhoan.SelectedValue= id;
                   
                }
                 loadAvatar(Convert.ToInt32(accountId));



            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public  void loadAvatar(int accountId)
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {
                    var acc = context.Account.Find(accountId);
                    if(acc != null && !string.IsNullOrEmpty(acc.avartar))
                    {
                        string imgs = acc.avartar.Trim();
                        var listImg = imgs.Split(';').ToArray();
                        if(listImg.Length > 0)
                        {
                            string fileName = listImg[0];
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"Image", fileName);
                            if (File.Exists(filePath))
                            {
                                if (PTB_hinhanh.Image != null)
                                {
                                    PTB_hinhanh.Image = null;
                                }
                                PTB_hinhanh.Image = Image.FromFile(filePath);   
                            }
                        }

                    }
                }



            }catch(Exception ex)
            {
                MessageBox.Show(ex+"", "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        public async Task<int> getRoleIdAccount(int accountId) {
            try
            {
                using (var context = new BanSanPhamSen())
                {
                    var roleId = await (from acc in context.Account
                                        join accper in context.AccountPermisstion on acc.accountId equals accper.accountId
                                        join per in context.Permissition on accper.permissitionId equals per.permissitionId
                                        where acc.accountId == accountId
                                        select per.permissitionId)
                                        .FirstOrDefaultAsync();

                    return roleId > 0 ? roleId : -1; 
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1;
        }

        private void CBB_LocLoaiTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void clear()
        {
            txtTimKiem.Text = "";
            txtNgayTao.Text = "";
            txtTenDangNhap.Text = "";
            txtLoaiTaiKhoan.Text = "";
            txtAccountId.Text = "";
            CBB_EditLoaiTaiKhoan.SelectedValue = -1;
            CBB_LocLoaiTaiKhoan.SelectedValue = -1;
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
                LoadTaiKhoan();
                   
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                string accountId = txtAccountId.Text;
                if(!string.IsNullOrEmpty(accountId))
                {
                    int accID = Convert.ToInt32(accountId);    
                    var id = Convert.ToInt32(CBB_EditLoaiTaiKhoan.SelectedValue.ToString());
                    if(id == 3)
                    {
                        MessageBox.Show("Không thể cập nhật quyền cho người dùng","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (id != -1)
                    {
                        using (var context = new BanSanPhamSen())
                        {
                            var acc = context.Account.Find(accID);
                            if (acc != null)
                            {
                              


                                var accper = context.AccountPermisstion.Where(op=>op.accountId == acc.accountId).FirstOrDefault();   
                                if(accper!= null)
                                {
                                    if(accper.permissitionId == id)
                                    {

                                        return;
                                    }

                                    // tao account pẻ mới;
                                    
                                    

                             

                                 
                                    //tao accountper mới
                                    var newAccountPer = new AccountPermisstion
                                    {
                                        accountId = acc.accountId,
                                        permissitionId = id
                                    };
                                    context.AccountPermisstion.Add(newAccountPer);
                                    context.SaveChanges();

                                    context.AccountPermisstion.Remove(accper);
                                    context.SaveChanges();  
                                    MessageBox.Show("Cập nhật thành công","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clear();
                                    LoadTaiKhoan(); 
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            try
            {
                var maTaiKhoan = txtAccountId.Text; 
                if(!string.IsNullOrEmpty(maTaiKhoan) ) { 
                    using(var context  = new BanSanPhamSen())
                    {
                        var account = context.Account.Find(Convert.ToInt32(maTaiKhoan));    
                        if(account != null ) { 
                            account.IsLocked= true; 
                            context.SaveChanges();
                            MessageBox.Show("Khóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear();
                            LoadTaiKhoan();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLocTheoLoai_Click(object sender, EventArgs e)
        {

            try
            {
                var idLoaiTaiKhoan = Convert.ToInt32(CBB_LocLoaiTaiKhoan.SelectedValue.ToString());
                if(idLoaiTaiKhoan != -1)
                {
                     LoadTaiKhoanTheoLoai(idLoaiTaiKhoan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                var idLoaiTaiKhoan = Convert.ToInt32(CBB_LocLoaiTaiKhoan.SelectedValue.ToString());
                string chuoiTim = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(chuoiTim)) return;
                if (idLoaiTaiKhoan == -1)
                {

                    //tim kiem theo ten tai khoan
                    LoadTaiKhoanTheoTenTaiKhoan(chuoiTim);

                }
                else
                {
                    locTaiKhoanTheoLoai(chuoiTim, idLoaiTaiKhoan);
                    //tim kiem theo loai tai khoan + theo ten
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void locTaiKhoanTheoLoai(string chuoiTim, int idRole)
        {
            try
            {
                var ds = await Task.Run(() => getDanhSachAccountTheoTenTaiKhoan(chuoiTim));
                var listItem = new List<DanhSachTaiKhoan>();
                foreach(var item in ds) { 
                    if(item.roleId== idRole)
                    {
                        listItem.Add(item); 
                    }
                }

                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Name", typeof(string));
                data.Columns.Add("Quyen", typeof(string));
                data.Columns.Add("NgayTao", typeof(string));
                data.Columns.Add("TrangThai", typeof(string));


             
                if (listItem != null)
                {
                    if (listItem.Count() > 0 && listItem.Any())
                    {
                        foreach (var vi in listItem)
                        {
                            data.Rows.Add(vi.accountId, vi.usserName, vi.quyenTaiKhoan, vi.ngayTao.ToString("dd/MM/yyyy"), vi.TrangThai);
                        }

                    }
                    GVTaiKhoan.DataSource = data;
                }




            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);        
            }
        }



        public async void LoadTaiKhoanTheoTenTaiKhoan(string userName)
        {
            try
            {
                DataTable data = new DataTable();
                data.Columns.Add("Id", typeof(int));
                data.Columns.Add("Name", typeof(string));
                data.Columns.Add("Quyen", typeof(string));
                data.Columns.Add("NgayTao", typeof(string));
                data.Columns.Add("TrangThai", typeof(string));


                var ds = await Task.Run(() => getDanhSachAccountTheoTenTaiKhoan(userName));
                if (ds != null)
                {
                    if (ds.Count() > 0 && ds.Any())
                    {
                        foreach (var vi in ds)
                        {
                            data.Rows.Add(vi.accountId, vi.usserName, vi.quyenTaiKhoan, vi.ngayTao.ToString("dd/MM/yyyy"), vi.TrangThai);
                        }

                    }
                    GVTaiKhoan.DataSource = data;
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Err", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task<List<DanhSachTaiKhoan>> getDanhSachAccountTheoTenTaiKhoan(string userName)
        {
            using (var context = new BanSanPhamSen())
            {
                List<DanhSachTaiKhoan> dsTaiKhoan = await (from acc in context.Account
                                                           join accper in context.AccountPermisstion on acc.accountId equals accper.accountId
                                                           join per in context.Permissition on accper.permissitionId equals per.permissitionId
                                                           select new DanhSachTaiKhoan
                                                           {
                                                               accountId = acc.accountId,
                                                               loaiTaiKhoan = per.permissitionName,
                                                               quyenTaiKhoan = per.permissitionName,
                                                               ngayTao = acc.createDate,
                                                               usserName = acc.username,
                                                               avartar = acc.avartar,
                                                               roleId = per.permissitionId,
                                                               TrangThai = (acc.IsLocked) ? "Đã khóa" : "Hoạt động"
                                                           }).ToListAsync();

                return  dsTaiKhoan.Where(op => ContainsIgnoreCaseAndPunctuation(op.usserName, userName) == true).ToList();
            }
        }

        public  bool ContainsIgnoreCaseAndPunctuation(string source, string target)
        {
            string pattern = @"[^\w\s]";
            source = Regex.Replace(source, pattern, "");
            target = Regex.Replace(target, pattern, "");
            return source.IndexOf(target, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void PTB_hinhanh_Click(object sender, EventArgs e)
        {

        }
    }
}
