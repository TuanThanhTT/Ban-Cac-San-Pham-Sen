namespace MuaBanSanPhamSen_BabyLotus.Page
{
    partial class FrmSanPhamItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSanPhamItem));
            this.GBTenSanPham = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.PTBImg = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbGiaBan = new System.Windows.Forms.Label();
            this.GBTenSanPham.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PTBImg)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBTenSanPham
            // 
            this.GBTenSanPham.BackColor = System.Drawing.Color.Transparent;
            this.GBTenSanPham.BorderColor = System.Drawing.Color.Black;
            this.GBTenSanPham.BorderRadius = 10;
            this.GBTenSanPham.BorderThickness = 3;
            this.GBTenSanPham.Controls.Add(this.guna2GradientPanel1);
            this.GBTenSanPham.CustomBorderColor = System.Drawing.Color.Transparent;
            this.GBTenSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GBTenSanPham.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBTenSanPham.ForeColor = System.Drawing.Color.Black;
            this.GBTenSanPham.Location = new System.Drawing.Point(0, 0);
            this.GBTenSanPham.Name = "GBTenSanPham";
            this.GBTenSanPham.Size = new System.Drawing.Size(270, 370);
            this.GBTenSanPham.TabIndex = 0;
            this.GBTenSanPham.Text = "Tên sản phẩm";
            this.GBTenSanPham.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GBTenSanPham.Click += new System.EventHandler(this.GBTenSanPham_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel1.Controls.Add(this.guna2Panel2);
            this.guna2GradientPanel1.Controls.Add(this.guna2Panel1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.ForeColor = System.Drawing.Color.Black;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 40);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(270, 330);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Controls.Add(this.PTBImg);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(270, 280);
            this.guna2Panel2.TabIndex = 1;
            // 
            // PTBImg
            // 
            this.PTBImg.BorderRadius = 10;
            this.PTBImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTBImg.Image = ((System.Drawing.Image)(resources.GetObject("PTBImg.Image")));
            this.PTBImg.ImageRotate = 0F;
            this.PTBImg.Location = new System.Drawing.Point(0, 0);
            this.PTBImg.Name = "PTBImg";
            this.PTBImg.Size = new System.Drawing.Size(270, 280);
            this.PTBImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PTBImg.TabIndex = 0;
            this.PTBImg.TabStop = false;
            this.PTBImg.UseTransparentBackground = true;
            this.PTBImg.Click += new System.EventHandler(this.PTBImg_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel1.Controls.Add(this.lbGiaBan);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 280);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(270, 50);
            this.guna2Panel1.TabIndex = 0;
            // 
            // lbGiaBan
            // 
            this.lbGiaBan.AutoSize = true;
            this.lbGiaBan.Location = new System.Drawing.Point(77, 20);
            this.lbGiaBan.Name = "lbGiaBan";
            this.lbGiaBan.Size = new System.Drawing.Size(108, 21);
            this.lbGiaBan.TabIndex = 0;
            this.lbGiaBan.Text = "250000vnđ";
            // 
            // FrmSanPhamItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GBTenSanPham);
            this.Name = "FrmSanPhamItem";
            this.Size = new System.Drawing.Size(270, 370);
            this.GBTenSanPham.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PTBImg)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox GBTenSanPham;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2PictureBox PTBImg;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lbGiaBan;
    }
}
