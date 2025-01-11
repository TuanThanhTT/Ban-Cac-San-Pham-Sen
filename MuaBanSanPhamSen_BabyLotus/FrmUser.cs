using Guna.UI2.WinForms;
using MuaBanSanPhamSen_BabyLotus.Page.userPage;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    public partial class FrmUser : Form
    {
        private Guna2Button currentBtn;
        private CustomTabControl tabMain;
        public FrmUser()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Bé Hạt Sen Baby Lotus";           
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
            var form = new FrmHomeUser();
            addTabPage(tabMain, form);
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            updateBoder(btnDonHang);
            addTabMain();
            var form = new FrmDonHang();
            addTabPage(tabMain, form);
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            updateBoder(btnLichSu);
            addTabMain();
            var form = new FrmXemSanPhamMua();
            addTabPage(tabMain, form);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            updateBoder(btnTaiKhoan);
            addTabMain();
            var form = new FrmThongTinTaiKhoan();
            addTabPage(tabMain, form);
        }
    }
}
