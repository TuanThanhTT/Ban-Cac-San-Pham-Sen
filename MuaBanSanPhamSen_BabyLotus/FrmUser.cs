using BeHatSenLotus.Model;
using Guna.UI2.WinForms;
using MuaBanSanPhamSen_BabyLotus.Page.userPage;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    public partial class FrmUser : Form
    {
        public Guna2Button currentBtn;
        public CustomTabControl tabMain;
        public Account account;
        public User user;
        public FrmUser(User user)
        {
          
           this.user = user;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Bé Hạt Sen Baby Lotus";
            setUpForm();
        }


        public async void setUpForm()
        {
            try
            {

                if (account != null)
                {

                    if (await getUsser() != null)
                    {
                        user = await getUsser();
                        lbHello.Text = user.FullName;
                    }
                }


            }catch(Exception ex) {
                MessageBox.Show("Lỗi: "+ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<User> getUsser()
        {
            try
            {
                using(var context = new BanSanPhamSen())
                {

                    int id = -1;
                    if (account.UserAccountId != null)
                    {
                        id = Convert.ToInt32(account.UserAccountId);
                    }

                    var user = await context.Users.FindAsync(id); 
                    return user;
                }
            }catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return null;
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

        public void addTabPageV2(CustomTabControl tab, UserControl userForm)
        {
            foreach (TabPage t in tab.TabPages)
            {
                if (t.Name == userForm.Name)
                {
                    tab.TabPages.Remove(t);
                    break; 
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
            var form = new FrmDonHang(user,this);
            addTabPage(tabMain, form);
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            updateBoder(btnLichSu);
            addTabMain();
            var form = new FrmXemSanPhamMua(this, user);
            addTabPage(tabMain, form);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            updateBoder(btnTaiKhoan);
            addTabMain();
            var form = new FrmThongTinTaiKhoan(user);
            addTabPage(tabMain, form);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (user != null)
            {
                lbHello.Text = user.FullName;
            }
        }

        private void Logout()
        {
            var f = new FrmLogin();
            f.ShowDialog();
            
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Logout));
         
            thread.Start();
            this.Close();
                
        }

        private void FrmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?",
    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No) e.Cancel = true;
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            updateBoder(btnSanPham);
            addTabMain();
            var form = new FrmLienHe();
            addTabPage(tabMain, form);
        }
    }
}
