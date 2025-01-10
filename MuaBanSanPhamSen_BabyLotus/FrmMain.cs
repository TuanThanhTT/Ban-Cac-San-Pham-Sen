using Guna.UI2.WinForms;
using MuaBanSanPhamSen_BabyLotus.Page;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    public partial class FrmMain : Form
    {
        private Guna2Button currentBtn;
        private CustomTabControl tabMain;
        public FrmMain()
        {
            InitializeComponent();
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
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            updateBoder(btnNhanVien);
            addTabMain();
            var form = new FrmNhanVien();
            addTabPage(tabMain, form);

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            updateBoder(btnHoaDon);
            addTabMain();
            var form = new FrmHoaDon();
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
    }
}
