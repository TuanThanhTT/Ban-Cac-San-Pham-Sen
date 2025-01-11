namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    partial class FrmXemSanPhamItem
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
            this.GroupTitle = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnXemChiTiet = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.PTBimg = new Guna.UI2.WinForms.Guna2PictureBox();
            this.GroupTitle.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PTBimg)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupTitle
            // 
            this.GroupTitle.Controls.Add(this.guna2Panel3);
            this.GroupTitle.Controls.Add(this.guna2Panel2);
            this.GroupTitle.Controls.Add(this.guna2Panel1);
            this.GroupTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupTitle.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupTitle.ForeColor = System.Drawing.Color.Black;
            this.GroupTitle.Location = new System.Drawing.Point(0, 0);
            this.GroupTitle.Name = "GroupTitle";
            this.GroupTitle.Size = new System.Drawing.Size(300, 370);
            this.GroupTitle.TabIndex = 0;
            this.GroupTitle.Text = "Tên sản phẩm";
            this.GroupTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GroupTitle.Click += new System.EventHandler(this.GroupTitle_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.PTBimg);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.ForeColor = System.Drawing.Color.Black;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 40);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(300, 215);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btnXemChiTiet);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 300);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(300, 70);
            this.guna2Panel2.TabIndex = 1;
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Animated = true;
            this.btnXemChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.btnXemChiTiet.BorderRadius = 10;
            this.btnXemChiTiet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemChiTiet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXemChiTiet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXemChiTiet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXemChiTiet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnXemChiTiet.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemChiTiet.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Location = new System.Drawing.Point(3, 12);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(294, 45);
            this.btnXemChiTiet.TabIndex = 0;
            this.btnXemChiTiet.Text = "Xem sản phẩm";
            this.btnXemChiTiet.UseTransparentBackground = true;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.White;
            this.guna2Panel3.Controls.Add(this.lbPrice);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 255);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(300, 45);
            this.guna2Panel3.TabIndex = 2;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(100, 12);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(99, 22);
            this.lbPrice.TabIndex = 0;
            this.lbPrice.Text = "120500vnđ";
            // 
            // PTBimg
            // 
            this.PTBimg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTBimg.ImageRotate = 0F;
            this.PTBimg.Location = new System.Drawing.Point(0, 0);
            this.PTBimg.Name = "PTBimg";
            this.PTBimg.Size = new System.Drawing.Size(300, 215);
            this.PTBimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PTBimg.TabIndex = 0;
            this.PTBimg.TabStop = false;
            // 
            // FrmXemSanPhamItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupTitle);
            this.Name = "FrmXemSanPhamItem";
            this.Size = new System.Drawing.Size(300, 370);
            this.GroupTitle.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PTBimg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox GroupTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label lbPrice;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnXemChiTiet;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox PTBimg;
    }
}
