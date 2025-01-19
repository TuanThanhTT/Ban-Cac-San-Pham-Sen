using System;
using System.Drawing;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmThongTinGioiThieu : UserControl
    {
        private string mess;
        private string filePath;
        public FrmThongTinGioiThieu(string mess, string filePath, int dai)
        {
            InitializeComponent();
            this.mess = mess;
            this.filePath = filePath;
            var size = new Size(dai,this.Height);
            this.Size = size;   
            //0022410911@student.dthu.edu.vn
        }


        public void loadInfo()
        {
           
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PTBHInhAnh_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
