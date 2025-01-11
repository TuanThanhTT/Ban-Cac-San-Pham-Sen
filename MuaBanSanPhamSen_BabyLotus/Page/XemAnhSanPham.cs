using BeHatSenLotus.Model;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
	public partial class XemAnhSanPham : Form
	{
		private Product sanPham;
		private string filePaths;

		public XemAnhSanPham(Product sanPHam, string filePaths)
		{
			this.sanPham= sanPHam;
			this.filePaths= filePaths;
			InitializeComponent();
			LoadThongTinSanPham();
			XuLyFilePath();
			
		}


		public void LoadThongTinSanPham()
		{
			try
			{
				if(this.sanPham!=null)
				{
					txtGia.Text = sanPham.price.ToString() + "VND";
					txtMaSP.Text = sanPham.productId.ToString();
					txtTenSP.Text = sanPham.productName.ToString();
					txtSoLuong.Text = sanPham.quantity.ToString();	
					txtMoTa.Text = sanPham.Decrepsition.ToString();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void XuLyFilePath()
		{
			try
			{
				if(!string.IsNullOrEmpty(filePaths))
				{
					string[] listFile = this.filePaths.Trim().Split(';').ToArray();
					if(listFile.Length > 0 ) {

						
						for(int i = 0;i< listFile.Length;i++)
						{
							if (!string.IsNullOrEmpty(listFile[i]))
							{
								string destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload",listFile[i].Trim());
								listFile[i] = destFile;
							}	
							
						}
						loadImg(listFile);
					}
				}
			}catch(Exception ex)
			{
				MessageBox.Show("Lỗi xử lý file: "+ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}




		public void loadImg(string[] listFile)
		{
			LayoutImgs.Controls.Clear();
		
			foreach (string file in listFile)
			{
				
				if (!string.IsNullOrEmpty(file.Trim()))
				{
					
					var userFrom = new FrmLoadAnh(file);

					LayoutImgs.Controls.Add(userFrom);
				}
				

			}

		}







		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void LayoutImgs_Paint(object sender, PaintEventArgs e)
		{

		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
