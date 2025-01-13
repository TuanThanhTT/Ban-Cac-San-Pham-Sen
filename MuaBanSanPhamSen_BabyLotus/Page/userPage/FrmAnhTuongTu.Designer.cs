namespace MuaBanSanPhamSen_BabyLotus.Page.userPage
{
    partial class FrmAnhTuongTu
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
            this.PTBHinhANh = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PTBHinhANh)).BeginInit();
            this.SuspendLayout();
            // 
            // PTBHinhANh
            // 
            this.PTBHinhANh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTBHinhANh.ImageRotate = 0F;
            this.PTBHinhANh.Location = new System.Drawing.Point(0, 0);
            this.PTBHinhANh.Name = "PTBHinhANh";
            this.PTBHinhANh.Size = new System.Drawing.Size(70, 70);
            this.PTBHinhANh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PTBHinhANh.TabIndex = 0;
            this.PTBHinhANh.TabStop = false;
            this.PTBHinhANh.Click += new System.EventHandler(this.PTBHinhANh_Click);
            // 
            // FrmAnhTuongTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PTBHinhANh);
            this.Name = "FrmAnhTuongTu";
            this.Size = new System.Drawing.Size(70, 70);
            ((System.ComponentModel.ISupportInitialize)(this.PTBHinhANh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox PTBHinhANh;
    }
}
