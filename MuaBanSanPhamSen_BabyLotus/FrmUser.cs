using Guna.UI2.WinForms;
using MuaBanSanPhamSen_BabyLotus.Page;
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
            var form = new FrmNhanVien();
            addTabPage(tabMain, form);
        }
    }
}
