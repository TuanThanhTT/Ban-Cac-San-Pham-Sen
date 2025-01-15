namespace MuaBanSanPhamSen_BabyLotus.PageCode
{
    partial class FrmTaoBarCode
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PTBBarCode = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnTaoBarCode = new Guna.UI2.WinForms.Guna2Button();
            this.txtNoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnBarcode = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PTBBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.txtNoiDung);
            this.guna2Panel1.Controls.Add(this.btnBarcode);
            this.guna2Panel1.Controls.Add(this.btnTaoBarCode);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(286, 450);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel2.Controls.Add(this.PTBBarCode);
            this.guna2Panel2.Controls.Add(this.btnLamMoi);
            this.guna2Panel2.Controls.Add(this.txtLuu);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(286, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(514, 450);
            this.guna2Panel2.TabIndex = 1;
            this.guna2Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tạo Code";
            // 
            // PTBBarCode
            // 
            this.PTBBarCode.ImageRotate = 0F;
            this.PTBBarCode.Location = new System.Drawing.Point(122, 95);
            this.PTBBarCode.Name = "PTBBarCode";
            this.PTBBarCode.Size = new System.Drawing.Size(300, 264);
            this.PTBBarCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PTBBarCode.TabIndex = 0;
            this.PTBBarCode.TabStop = false;
            // 
            // btnTaoBarCode
            // 
            this.btnTaoBarCode.Animated = true;
            this.btnTaoBarCode.BackColor = System.Drawing.Color.Transparent;
            this.btnTaoBarCode.BorderRadius = 10;
            this.btnTaoBarCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoBarCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoBarCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoBarCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoBarCode.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnTaoBarCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnTaoBarCode.ForeColor = System.Drawing.Color.White;
            this.btnTaoBarCode.Location = new System.Drawing.Point(12, 390);
            this.btnTaoBarCode.Name = "btnTaoBarCode";
            this.btnTaoBarCode.Size = new System.Drawing.Size(260, 45);
            this.btnTaoBarCode.TabIndex = 1;
            this.btnTaoBarCode.Text = "QRCode";
            this.btnTaoBarCode.UseTransparentBackground = true;
            this.btnTaoBarCode.Click += new System.EventHandler(this.btnTaoBarCode_Click);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Animated = true;
            this.txtNoiDung.BorderColor = System.Drawing.Color.Black;
            this.txtNoiDung.BorderRadius = 10;
            this.txtNoiDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoiDung.DefaultText = "";
            this.txtNoiDung.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNoiDung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNoiDung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDung.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDung.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDung.ForeColor = System.Drawing.Color.Black;
            this.txtNoiDung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDung.Location = new System.Drawing.Point(14, 80);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.PasswordChar = '\0';
            this.txtNoiDung.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtNoiDung.PlaceholderText = "Mã sản phẩm";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.SelectedText = "";
            this.txtNoiDung.Size = new System.Drawing.Size(258, 50);
            this.txtNoiDung.TabIndex = 2;
            // 
            // txtLuu
            // 
            this.txtLuu.Animated = true;
            this.txtLuu.BackColor = System.Drawing.Color.Transparent;
            this.txtLuu.BorderRadius = 10;
            this.txtLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtLuu.FillColor = System.Drawing.Color.Green;
            this.txtLuu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtLuu.ForeColor = System.Drawing.Color.White;
            this.txtLuu.Location = new System.Drawing.Point(143, 374);
            this.txtLuu.Name = "txtLuu";
            this.txtLuu.Size = new System.Drawing.Size(260, 45);
            this.txtLuu.TabIndex = 1;
            this.txtLuu.Text = "Lưu";
            this.txtLuu.UseTransparentBackground = true;
            this.txtLuu.Visible = false;
            this.txtLuu.Click += new System.EventHandler(this.txtLuu_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Animated = true;
            this.btnLamMoi.BackColor = System.Drawing.Color.Transparent;
            this.btnLamMoi.BorderRadius = 10;
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnLamMoi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(143, 33);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(260, 45);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseTransparentBackground = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Animated = true;
            this.btnBarcode.BackColor = System.Drawing.Color.Transparent;
            this.btnBarcode.BorderRadius = 10;
            this.btnBarcode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBarcode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBarcode.FillColor = System.Drawing.Color.DarkSlateGray;
            this.btnBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBarcode.ForeColor = System.Drawing.Color.White;
            this.btnBarcode.Location = new System.Drawing.Point(12, 339);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(260, 45);
            this.btnBarcode.TabIndex = 1;
            this.btnBarcode.Text = "Barcode";
            this.btnBarcode.UseTransparentBackground = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // FrmTaoBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FrmTaoBarCode";
            this.Text = "Tạo BarCode";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PTBBarCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2TextBox txtNoiDung;
        private Guna.UI2.WinForms.Guna2Button btnTaoBarCode;
        private Guna.UI2.WinForms.Guna2PictureBox PTBBarCode;
        private Guna.UI2.WinForms.Guna2Button btnBarcode;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button txtLuu;
    }
}