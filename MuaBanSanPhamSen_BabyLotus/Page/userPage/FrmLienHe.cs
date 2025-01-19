using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmLienHe : UserControl
    {
        public FrmLienHe()
        {
            InitializeComponent();
            loadInfo();
        }


        public void loadInfo()
        {
            //   LayoutGioiThieuSanPHam.Controls.Add(new FrmThongTinGioiThieu("", "", LayoutGioiThieuSanPHam.Width-2));
            var form = new FrmThongTinGioiThieu("", "", guna2GroupBox1.Width - 2);
            
            guna2GroupBox1.Controls.Add(form);
            form.Dock = DockStyle.Fill; 
        }
        private void LayoutGioiThieuSanPHam_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
