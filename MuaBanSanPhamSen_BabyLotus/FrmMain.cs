using BeHatSenLotus.Model;
using Guna.UI2.WinForms;
using MuaBanSanPhamSen_BabyLotus.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            updateBoder(btnKhachHang);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            updateBoder(btnSanPham);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            updateBoder(btnTaiKhoan);

           
        }
    }
}
