namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    partial class FrmSanPhamTuongTu
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
            this.GroupTenSanPham = new Guna.UI2.WinForms.Guna2GroupBox();
            this.PTBAnhSanPham = new Guna.UI2.WinForms.Guna2PictureBox();
            this.GroupTenSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PTBAnhSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupTenSanPham
            // 
            this.GroupTenSanPham.Controls.Add(this.PTBAnhSanPham);
            this.GroupTenSanPham.CustomBorderColor = System.Drawing.Color.Teal;
            this.GroupTenSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupTenSanPham.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupTenSanPham.ForeColor = System.Drawing.Color.White;
            this.GroupTenSanPham.Location = new System.Drawing.Point(0, 0);
            this.GroupTenSanPham.Name = "GroupTenSanPham";
            this.GroupTenSanPham.Size = new System.Drawing.Size(170, 210);
            this.GroupTenSanPham.TabIndex = 0;
            this.GroupTenSanPham.Text = "Tên sản phẩm";
            this.GroupTenSanPham.Click += new System.EventHandler(this.GroupTenSanPham_Click);
            // 
            // PTBAnhSanPham
            // 
            this.PTBAnhSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTBAnhSanPham.ImageRotate = 0F;
            this.PTBAnhSanPham.Location = new System.Drawing.Point(0, 40);
            this.PTBAnhSanPham.Name = "PTBAnhSanPham";
            this.PTBAnhSanPham.Size = new System.Drawing.Size(170, 170);
            this.PTBAnhSanPham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PTBAnhSanPham.TabIndex = 0;
            this.PTBAnhSanPham.TabStop = false;
            this.PTBAnhSanPham.Click += new System.EventHandler(this.PTBAnhSanPham_Click);
            // 
            // FrmSanPhamTuongTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupTenSanPham);
            this.Name = "FrmSanPhamTuongTu";
            this.Size = new System.Drawing.Size(170, 210);
            this.GroupTenSanPham.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PTBAnhSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox GroupTenSanPham;
        private Guna.UI2.WinForms.Guna2PictureBox PTBAnhSanPham;
    }
}
