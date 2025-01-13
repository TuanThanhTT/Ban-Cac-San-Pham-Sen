namespace MuaBanSanPhamSen_BabyLotus.Page
{
    partial class FrmDuyetHoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDuyetHoaDon));
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.GVDuyet = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnDuyet = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTim = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.btnDuyetHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.txtTenKh = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNgayLap = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTongtien = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTim = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaKh = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaDon = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GVDuyet)).BeginInit();
            this.btnDuyet.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.guna2Panel2);
            this.guna2GroupBox1.Controls.Add(this.btnDuyet);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1531, 905);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "Duyệt đơn hàng";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.Controls.Add(this.GVDuyet);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 394);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1531, 511);
            this.guna2Panel2.TabIndex = 1;
            // 
            // GVDuyet
            // 
            this.GVDuyet.AllowUserToAddRows = false;
            this.GVDuyet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.GVDuyet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GVDuyet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GVDuyet.ColumnHeadersHeight = 30;
            this.GVDuyet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GVDuyet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GVDuyet.DefaultCellStyle = dataGridViewCellStyle3;
            this.GVDuyet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GVDuyet.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GVDuyet.Location = new System.Drawing.Point(0, 0);
            this.GVDuyet.Name = "GVDuyet";
            this.GVDuyet.ReadOnly = true;
            this.GVDuyet.RowHeadersVisible = false;
            this.GVDuyet.RowHeadersWidth = 51;
            this.GVDuyet.RowTemplate.Height = 24;
            this.GVDuyet.Size = new System.Drawing.Size(1531, 511);
            this.GVDuyet.TabIndex = 0;
            this.GVDuyet.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GVDuyet.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GVDuyet.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.GVDuyet.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.GVDuyet.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.GVDuyet.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.GVDuyet.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GVDuyet.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GVDuyet.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GVDuyet.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GVDuyet.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GVDuyet.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GVDuyet.ThemeStyle.HeaderStyle.Height = 30;
            this.GVDuyet.ThemeStyle.ReadOnly = true;
            this.GVDuyet.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GVDuyet.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GVDuyet.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GVDuyet.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GVDuyet.ThemeStyle.RowsStyle.Height = 24;
            this.GVDuyet.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GVDuyet.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GVDuyet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GVDuyet_CellContentClick);
            // 
            // btnDuyet
            // 
            this.btnDuyet.BackColor = System.Drawing.Color.White;
            this.btnDuyet.Controls.Add(this.btnTim);
            this.btnDuyet.Controls.Add(this.btnLamMoi);
            this.btnDuyet.Controls.Add(this.btnXem);
            this.btnDuyet.Controls.Add(this.btnDuyetHoaDon);
            this.btnDuyet.Controls.Add(this.btnXoa);
            this.btnDuyet.Controls.Add(this.txtTenKh);
            this.btnDuyet.Controls.Add(this.txtNgayLap);
            this.btnDuyet.Controls.Add(this.txtMaDon);
            this.btnDuyet.Controls.Add(this.txtTongtien);
            this.btnDuyet.Controls.Add(this.txtTim);
            this.btnDuyet.Controls.Add(this.txtMaKh);
            this.btnDuyet.Controls.Add(this.label5);
            this.btnDuyet.Controls.Add(this.label4);
            this.btnDuyet.Controls.Add(this.label3);
            this.btnDuyet.Controls.Add(this.label2);
            this.btnDuyet.Controls.Add(this.label1);
            this.btnDuyet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDuyet.Location = new System.Drawing.Point(0, 40);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(1531, 354);
            this.btnDuyet.TabIndex = 0;
            // 
            // btnTim
            // 
            this.btnTim.Animated = true;
            this.btnTim.BackColor = System.Drawing.Color.Transparent;
            this.btnTim.BorderRadius = 10;
            this.btnTim.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTim.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTim.FillColor = System.Drawing.Color.Navy;
            this.btnTim.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.Image")));
            this.btnTim.Location = new System.Drawing.Point(1170, 280);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(123, 50);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseTransparentBackground = true;
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
            this.btnLamMoi.FillColor = System.Drawing.Color.Gray;
            this.btnLamMoi.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(351, 285);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(127, 45);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseTransparentBackground = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXem
            // 
            this.btnXem.Animated = true;
            this.btnXem.BackColor = System.Drawing.Color.Transparent;
            this.btnXem.BorderRadius = 10;
            this.btnXem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnXem.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(239, 285);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(106, 45);
            this.btnXem.TabIndex = 2;
            this.btnXem.Text = "Xem";
            this.btnXem.UseTransparentBackground = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnDuyetHoaDon
            // 
            this.btnDuyetHoaDon.Animated = true;
            this.btnDuyetHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.btnDuyetHoaDon.BorderRadius = 10;
            this.btnDuyetHoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDuyetHoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDuyetHoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDuyetHoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDuyetHoaDon.FillColor = System.Drawing.Color.Green;
            this.btnDuyetHoaDon.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDuyetHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnDuyetHoaDon.Image = ((System.Drawing.Image)(resources.GetObject("btnDuyetHoaDon.Image")));
            this.btnDuyetHoaDon.Location = new System.Drawing.Point(15, 285);
            this.btnDuyetHoaDon.Name = "btnDuyetHoaDon";
            this.btnDuyetHoaDon.Size = new System.Drawing.Size(106, 45);
            this.btnDuyetHoaDon.TabIndex = 2;
            this.btnDuyetHoaDon.Text = "Duyệt";
            this.btnDuyetHoaDon.UseTransparentBackground = true;
            this.btnDuyetHoaDon.Click += new System.EventHandler(this.btnDuyetHoaDon_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Animated = true;
            this.btnXoa.BackColor = System.Drawing.Color.Transparent;
            this.btnXoa.BorderRadius = 10;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.FillColor = System.Drawing.Color.Red;
            this.btnXoa.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(127, 285);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(106, 45);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseTransparentBackground = true;
            this.btnXoa.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // txtTenKh
            // 
            this.txtTenKh.BorderColor = System.Drawing.Color.Black;
            this.txtTenKh.BorderRadius = 10;
            this.txtTenKh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKh.DefaultText = "";
            this.txtTenKh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenKh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenKh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKh.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKh.ForeColor = System.Drawing.Color.Black;
            this.txtTenKh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKh.Location = new System.Drawing.Point(196, 106);
            this.txtTenKh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenKh.Name = "txtTenKh";
            this.txtTenKh.PasswordChar = '\0';
            this.txtTenKh.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTenKh.PlaceholderText = "";
            this.txtTenKh.ReadOnly = true;
            this.txtTenKh.SelectedText = "";
            this.txtTenKh.Size = new System.Drawing.Size(329, 50);
            this.txtTenKh.TabIndex = 1;
            // 
            // txtNgayLap
            // 
            this.txtNgayLap.BorderColor = System.Drawing.Color.Black;
            this.txtNgayLap.BorderRadius = 10;
            this.txtNgayLap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNgayLap.DefaultText = "";
            this.txtNgayLap.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNgayLap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNgayLap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNgayLap.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNgayLap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNgayLap.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayLap.ForeColor = System.Drawing.Color.Black;
            this.txtNgayLap.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNgayLap.Location = new System.Drawing.Point(710, 106);
            this.txtNgayLap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNgayLap.Name = "txtNgayLap";
            this.txtNgayLap.PasswordChar = '\0';
            this.txtNgayLap.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtNgayLap.PlaceholderText = "";
            this.txtNgayLap.ReadOnly = true;
            this.txtNgayLap.SelectedText = "";
            this.txtNgayLap.Size = new System.Drawing.Size(329, 50);
            this.txtNgayLap.TabIndex = 1;
            // 
            // txtTongtien
            // 
            this.txtTongtien.BorderColor = System.Drawing.Color.Black;
            this.txtTongtien.BorderRadius = 10;
            this.txtTongtien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTongtien.DefaultText = "";
            this.txtTongtien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTongtien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTongtien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTongtien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTongtien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongtien.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongtien.ForeColor = System.Drawing.Color.Black;
            this.txtTongtien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTongtien.Location = new System.Drawing.Point(709, 17);
            this.txtTongtien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTongtien.Name = "txtTongtien";
            this.txtTongtien.PasswordChar = '\0';
            this.txtTongtien.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTongtien.PlaceholderText = "";
            this.txtTongtien.ReadOnly = true;
            this.txtTongtien.SelectedText = "";
            this.txtTongtien.Size = new System.Drawing.Size(329, 50);
            this.txtTongtien.TabIndex = 1;
            // 
            // txtTim
            // 
            this.txtTim.BorderColor = System.Drawing.Color.Black;
            this.txtTim.BorderRadius = 10;
            this.txtTim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTim.DefaultText = "";
            this.txtTim.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTim.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTim.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTim.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.ForeColor = System.Drawing.Color.Black;
            this.txtTim.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTim.Location = new System.Drawing.Point(562, 280);
            this.txtTim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTim.Name = "txtTim";
            this.txtTim.PasswordChar = '\0';
            this.txtTim.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTim.PlaceholderText = "";
            this.txtTim.SelectedText = "";
            this.txtTim.Size = new System.Drawing.Size(588, 50);
            this.txtTim.TabIndex = 1;
            // 
            // txtMaKh
            // 
            this.txtMaKh.BorderColor = System.Drawing.Color.Black;
            this.txtMaKh.BorderRadius = 10;
            this.txtMaKh.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaKh.DefaultText = "";
            this.txtMaKh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaKh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaKh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKh.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKh.ForeColor = System.Drawing.Color.Black;
            this.txtMaKh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKh.Location = new System.Drawing.Point(196, 17);
            this.txtMaKh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaKh.Name = "txtMaKh";
            this.txtMaKh.PasswordChar = '\0';
            this.txtMaKh.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtMaKh.PlaceholderText = "";
            this.txtMaKh.ReadOnly = true;
            this.txtMaKh.SelectedText = "";
            this.txtMaKh.Size = new System.Drawing.Size(329, 50);
            this.txtMaKh.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(583, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày lập";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(583, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tổng tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên khách hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khách hàng";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Mã khách hàng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "MaDon";
            this.Column5.HeaderText = "Mã đơn hàng";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "Tên khách hàng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TongTien";
            this.Column3.HeaderText = "Tồng tiền";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NgayLap";
            this.Column4.HeaderText = "Ngày lập";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1073, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã đơn";
            // 
            // txtMaDon
            // 
            this.txtMaDon.BorderColor = System.Drawing.Color.Black;
            this.txtMaDon.BorderRadius = 10;
            this.txtMaDon.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaDon.DefaultText = "";
            this.txtMaDon.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaDon.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaDon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaDon.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDon.ForeColor = System.Drawing.Color.Black;
            this.txtMaDon.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaDon.Location = new System.Drawing.Point(1199, 17);
            this.txtMaDon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.PasswordChar = '\0';
            this.txtMaDon.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtMaDon.PlaceholderText = "";
            this.txtMaDon.ReadOnly = true;
            this.txtMaDon.SelectedText = "";
            this.txtMaDon.Size = new System.Drawing.Size(177, 50);
            this.txtMaDon.TabIndex = 1;
            // 
            // FrmDuyetHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GroupBox1);
            this.Name = "FrmDuyetHoaDon";
            this.Size = new System.Drawing.Size(1531, 905);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GVDuyet)).EndInit();
            this.btnDuyet.ResumeLayout(false);
            this.btnDuyet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DataGridView GVDuyet;
        private Guna.UI2.WinForms.Guna2Panel btnDuyet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnTim;
        private Guna.UI2.WinForms.Guna2TextBox txtTenKh;
        private Guna.UI2.WinForms.Guna2TextBox txtNgayLap;
        private Guna.UI2.WinForms.Guna2TextBox txtTongtien;
        private Guna.UI2.WinForms.Guna2TextBox txtTim;
        private Guna.UI2.WinForms.Guna2TextBox txtMaKh;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2Button btnDuyetHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private Guna.UI2.WinForms.Guna2TextBox txtMaDon;
        private System.Windows.Forms.Label label5;
    }
}
