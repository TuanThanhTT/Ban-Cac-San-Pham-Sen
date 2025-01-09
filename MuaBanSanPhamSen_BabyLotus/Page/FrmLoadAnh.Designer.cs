namespace MuaBanSanPhamSen_BabyLotus.Page
{
	partial class FrmLoadAnh
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelImg = new Guna.UI2.WinForms.Guna2Panel();
			this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
			this.lbTitileImg = new System.Windows.Forms.Label();
			this.imgs = new Guna.UI2.WinForms.Guna2PictureBox();
			this.panelImg.SuspendLayout();
			this.guna2Panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgs)).BeginInit();
			this.SuspendLayout();
			// 
			// panelImg
			// 
			this.panelImg.BackColor = System.Drawing.Color.White;
			this.panelImg.Controls.Add(this.imgs);
			this.panelImg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelImg.Location = new System.Drawing.Point(0, 45);
			this.panelImg.Name = "panelImg";
			this.panelImg.Size = new System.Drawing.Size(386, 199);
			this.panelImg.TabIndex = 0;
			this.panelImg.Paint += new System.Windows.Forms.PaintEventHandler(this.panelImg_Paint);
			// 
			// guna2Panel2
			// 
			this.guna2Panel2.BackColor = System.Drawing.Color.Silver;
			this.guna2Panel2.Controls.Add(this.lbTitileImg);
			this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.guna2Panel2.ForeColor = System.Drawing.Color.Gray;
			this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
			this.guna2Panel2.Name = "guna2Panel2";
			this.guna2Panel2.Size = new System.Drawing.Size(386, 45);
			this.guna2Panel2.TabIndex = 1;
			// 
			// lbTitileImg
			// 
			this.lbTitileImg.AutoSize = true;
			this.lbTitileImg.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitileImg.ForeColor = System.Drawing.Color.Black;
			this.lbTitileImg.Location = new System.Drawing.Point(12, 9);
			this.lbTitileImg.Name = "lbTitileImg";
			this.lbTitileImg.Size = new System.Drawing.Size(44, 24);
			this.lbTitileImg.TabIndex = 0;
			this.lbTitileImg.Text = "Ảnh";
			// 
			// imgs
			// 
			this.imgs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imgs.ImageRotate = 0F;
			this.imgs.Location = new System.Drawing.Point(0, 0);
			this.imgs.Name = "imgs";
			this.imgs.Size = new System.Drawing.Size(386, 199);
			this.imgs.TabIndex = 0;
			this.imgs.TabStop = false;
			this.imgs.Click += new System.EventHandler(this.imgs_Click);
			// 
			// FrmLoadAnh
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelImg);
			this.Controls.Add(this.guna2Panel2);
			this.Name = "FrmLoadAnh";
			this.Size = new System.Drawing.Size(386, 244);
			this.panelImg.ResumeLayout(false);
			this.guna2Panel2.ResumeLayout(false);
			this.guna2Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgs)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2Panel panelImg;
		private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
		private System.Windows.Forms.Label lbTitileImg;
		private Guna.UI2.WinForms.Guna2PictureBox imgs;
	}
}
