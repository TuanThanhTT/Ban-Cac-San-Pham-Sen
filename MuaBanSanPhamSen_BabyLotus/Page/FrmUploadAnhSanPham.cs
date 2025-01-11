using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus.Page
{
	public partial class FrmUploadAnhSanPham : Form
	{
		private string stringImgs = "";
		private string filePaths = "";
		public FrmUploadAnhSanPham()
		{
			InitializeComponent();
			
		}


		public void GhiFileVanBan(string noiDung)
		{
			try
			{
				string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload", "ChuoiHinh.txt");
				using (StreamWriter writer = new StreamWriter(filePath, true)) // `true` để ghi nối tiếp
				{
					writer.WriteLine(noiDung); // Ghi dòng nội dung
				}
				
			}
			catch (Exception ex)
			{
				
			}
		}

		public void loadImg(OpenFileDialog openFile)
		{
			layoutImgs.Controls.Clear();
			stringImgs = "";
			filePaths = "";
			foreach (string file in openFile.FileNames)
			{
				string destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", Path.GetFileName(file));
			
				var userFrom = new FrmLoadAnh(file);


				if (string.IsNullOrEmpty(filePaths)) {
					filePaths += file+";";
				}
				else
				{
					filePaths += ";" + file;
				}

				

				if (!string.IsNullOrEmpty(stringImgs))
				{
					stringImgs += ";"+Path.GetFileName(file);
				}
				else
				{
					stringImgs += Path.GetFileName(file);
				}
				layoutImgs.Controls.Add(userFrom);	

				
			}
		
		}


		private void btnLoadAnh_Click(object sender, EventArgs e)
		{
			try
			{				
							OpenFileDialog openFile = new OpenFileDialog();
							openFile.InitialDirectory = "c:\\";
							openFile.Filter = "PNG Files|*.png|GIF Files|*.gif|JPG Files|*.jpg";
							openFile.Multiselect = true;
							openFile.FilterIndex = 3;
							string imgs = "";
					
								if (openFile.ShowDialog() == DialogResult.OK)
								{
									if (openFile.FileNames.Length > 0)
									{
										//hien thi hinh anh len form
										loadImg(openFile);						
										//foreach (string file in openFile.FileNames)
										//{
										//	string destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", Path.GetFileName(file));
										//	if (File.Exists(destFile))
										//	{
										//		destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", Path.GetFileNameWithoutExtension(file) + "_" + DateTime.Now.Ticks + Path.GetExtension(file));
										//	}
										//	File.Copy(file, destFile);
										//	imgs += Path.GetFileName(file) + "\n";
										//}			
									}

								}
								
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: "+ex,"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnLuuHinh_Click(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrEmpty(stringImgs))
				{

					stringImgs = "";

					if (!string.IsNullOrEmpty(filePaths))
					{
						var list = filePaths.Split(';').ToArray();
						if(list.Length> 0)
						{
							foreach (var file in list)
							{
								if (!string.IsNullOrEmpty(file))
								{
									string destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", Path.GetFileName(file));
									if (File.Exists(destFile))
									{
										destFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", Path.GetFileNameWithoutExtension(file) + "_" + DateTime.Now.Ticks + Path.GetExtension(file));
									}
									File.Copy(file, destFile);
									if (string.IsNullOrEmpty(stringImgs))
									{
										stringImgs += Path.GetFileName(destFile) + ";";
									}
									else
									{
										stringImgs += ";" + Path.GetFileName(destFile);
									}
								}
							}

						}

					}

					GhiFileVanBan(stringImgs);

					MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
				else
				{
					MessageBox.Show("Chưa chọn hình để lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}

        private void layoutImgs_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
