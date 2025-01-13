using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    public partial class FrmAnhTuongTu : UserControl
    {
        private string filePath;
        private Guna2PictureBox main;
        public FrmAnhTuongTu(string filePath, Guna2PictureBox main)
        {
            this.filePath = filePath;
            this.main = main;
            InitializeComponent();
            loadImg();
        }

        public void loadImg()
        {
            if(!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
            {
                PTBHinhANh.Image = Image.FromFile(filePath);

            }
        }

        private void PTBHinhANh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if(File.Exists(filePath))
                {
                    if (main.Image != null)
                    {
                        main.Image = null;
                    }
                    main.Image = Image.FromFile(filePath);
                }
               


            }
        }
    }
}
