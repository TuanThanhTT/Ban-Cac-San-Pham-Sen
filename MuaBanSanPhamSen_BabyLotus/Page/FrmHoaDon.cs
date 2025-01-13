using BeHatSenLotus.Model;
using System;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
    public partial class FrmHoaDon : UserControl
    {
        private Employee employ;
        private FrmMain main;
        public FrmHoaDon(Employee employe , FrmMain  main)
        {
            this.employ = employe;
            this.main = main;
            InitializeComponent();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnDuyetHoaDon_Click(object sender, EventArgs e)
        {
            main.addTabMain();
            var form = new FrmDuyetHoaDon(employ);
            main.addTabPage(main.tabMain, form);
        }
    }
}
