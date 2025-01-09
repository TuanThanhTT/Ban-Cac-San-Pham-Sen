using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
	public partial class FrmLoadAnh : UserControl
	{
		private string filePath = "";
		public FrmLoadAnh(string fileName)
		{
			this.filePath = fileName;
			InitializeComponent();
			setImg();
		}



		public void setImg()
		{
			try
			{
				if (!string.IsNullOrEmpty(filePath))
				{

					if (File.Exists(filePath))
					{
						// Dọn dẹp hình ảnh cũ nếu có
						if (imgs.Image != null)
						{
							imgs.Image.Dispose();
							imgs.Image = null;
						}

						// Tải và hiển thị hình ảnh mới
						imgs.Image = Image.FromFile(filePath);
						imgs.SizeMode = PictureBoxSizeMode.StretchImage; // Co giãn hình ảnh
					}
					else
					{
						MessageBox.Show("File không tồn tại!");
					}
				}
				else
				{
					MessageBox.Show("Đường dẫn hình ảnh rỗng!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}

		}

		private void panelImg_Paint(object sender, PaintEventArgs e)
		{

		}

		private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void imgs_Click(object sender, EventArgs e)
		{

		}
	}
}
