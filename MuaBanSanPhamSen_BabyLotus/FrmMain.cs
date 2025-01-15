using BeHatSenLotus.Model;
using Guna.UI2.WinForms;
using MuaBanSanPhamSen_BabyLotus.Page;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    public partial class FrmMain : Form
    {
        private Guna2Button currentBtn;
        public CustomTabControl tabMain;
        private Employee employ;
        public FrmMain(Employee employ)
        {
            this.employ = employ;   
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
           
          // Đảm bảo form luôn ở trên cùng
        }

        public void loadName()
        {
            if(employ!=null)
            {
                lbNameUsser.Text = employ.FullName;
            }
        }


        public void addTabMain()
        {
            if (tabMain == null)
            {
                tabMain = new CustomTabControl();
            }

            mainPanel.Controls.Add(tabMain);
            tabMain.Dock = DockStyle.Fill;
        }

        public void addTabPage(CustomTabControl tab, UserControl userForm)
        {
            foreach (TabPage t in tab.TabPages)
            {
                if (t.Name == userForm.Name)
                {
                    tab.SelectedTab = t;
                    return;
                }
            }

            var page = new TabPage(userForm.Name);
            page.Name = userForm.Name;
            userForm.Dock = DockStyle.Fill;
            page.Controls.Add(userForm);
            tab.Controls.Add(page);
            tab.SelectedTab = page;


        }



        public void updateBoder(Guna2Button newButton)
        {
            if (currentBtn != null)
            {

                currentBtn.BorderColor = Color.Transparent;
                currentBtn.CustomizableEdges.BottomLeft = false;
                currentBtn.Checked = false;
            }
            currentBtn = newButton;

            newButton.CustomizableEdges.BottomLeft = true;
            newButton.CustomizableEdges.BottomRight = false;
            newButton.CustomizableEdges.TopRight = false;
            newButton.CustomizableEdges.TopLeft = false;
            newButton.Checked = true;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            updateBoder(btnHome);
            addTabMain();
            var form = new FrmHomeAdmin();
            addTabPage(tabMain, form);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {

            if (employ != null)
            {
                using (var context = new BanSanPhamSen()) 
                {
                    var acc = context.Account.Where(s => s.EmployAccountId == employ.EmployeeId).FirstOrDefault();
                    if(acc!= null)
                    {
                        var accper = context.AccountPermisstion.Where(s=>s.accountId == acc.accountId).FirstOrDefault();
                        if (accper != null)
                        {
                            if(accper.permissitionId == 1)
                            {
                                updateBoder(btnNhanVien);
                                addTabMain();
                                var form = new FrmNhanVien();
                                addTabPage(tabMain, form);
                            }
                            else
                            {
                                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                }
            }


           

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            updateBoder(btnHoaDon);
            addTabMain();
            var form = new FrmHoaDon(employ, this);
            addTabPage(tabMain, form);

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            updateBoder(btnKhachHang);
            addTabMain();
            var form = new FrmQuanLyKhachHang();
            addTabPage(tabMain, form);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            updateBoder(btnSanPham);
            addTabMain();
            var form = new FrmSanPham();
            addTabPage(tabMain, form);

        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            updateBoder(btnNhaCungCap);
            addTabMain();
            var form = new FrmNhaCungCap();
            addTabPage(tabMain, form);


        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLoaiSanPham_Click(object sender, EventArgs e)
        {
            updateBoder(btnLoaiSanPham);
            addTabMain();
            var form = new FrmLoaiSanPham();
            addTabPage(tabMain, form);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void btnTaiKhoan_Click_1(object sender, EventArgs e)
        {
            updateBoder(btnTaiKhoan);
            addTabMain();
            var form = new FrmTaiKhoan();
            addTabPage(tabMain, form);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            updateBoder(btnThongKe);
            addTabMain();
            var form = new FrmThongKe();
            addTabPage(tabMain, form);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        public void Logout()
        {
            var f = new FrmLogin();
            f.ShowDialog();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
           Thread thread = new Thread(new ThreadStart(Logout));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(); 
            this.Close();

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?",
    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No) e.Cancel = true;
        }
    }
}
