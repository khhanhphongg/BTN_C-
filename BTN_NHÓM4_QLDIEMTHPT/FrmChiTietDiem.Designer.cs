namespace QLDiemTHPT
{
    partial class FrmChiTietDiem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel_tieude = new System.Windows.Forms.Panel();
            this.label_tieude = new System.Windows.Forms.Label();
            this.panel_nhap = new System.Windows.Forms.Panel();
            this.label_maCT = new System.Windows.Forms.Label();
            this.textBox_maCT = new System.Windows.Forms.TextBox();
            this.label_hocSinh = new System.Windows.Forms.Label();
            this.textBox_hocSinh = new System.Windows.Forms.TextBox();
            this.label_monHoc = new System.Windows.Forms.Label();
            this.textBox_monHoc = new System.Windows.Forms.TextBox();
            this.label_hocKy = new System.Windows.Forms.Label();
            this.comboBox_hocKy = new System.Windows.Forms.ComboBox();
            this.label_loaiDiem = new System.Windows.Forms.Label();
            this.comboBox_loaiDiem = new System.Windows.Forms.ComboBox();
            this.label_diem = new System.Windows.Forms.Label();
            this.textBox_diem = new System.Windows.Forms.TextBox();
            this.label_heSo = new System.Windows.Forms.Label();
            this.comboBox_heSo = new System.Windows.Forms.ComboBox();
            this.label_ghiChu = new System.Windows.Forms.Label();
            this.textBox_ghiChu = new System.Windows.Forms.TextBox();
            this.button_them = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_lamMoi = new System.Windows.Forms.Button();
            this.textBox_timKiem = new System.Windows.Forms.TextBox();
            this.button_timKiem = new System.Windows.Forms.Button();
            this.label_bangDiem = new System.Windows.Forms.Label();
            this.DataGridView_bangDiem = new System.Windows.Forms.DataGridView();
            this.label_chiTiet = new System.Windows.Forms.Label();
            this.DataGridView_chiTiet = new System.Windows.Forms.DataGridView();
            this.panel_tieude.SuspendLayout();
            this.panel_nhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_bangDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_chiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_tieude
            // 
            this.panel_tieude.BackColor = System.Drawing.Color.White;
            this.panel_tieude.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_tieude.Location = new System.Drawing.Point(0, 0);
            this.panel_tieude.Name = "panel_tieude";
            this.panel_tieude.Size = new System.Drawing.Size(934, 55);
            this.panel_tieude.TabIndex = 0;
            this.panel_tieude.Controls.Add(this.label_tieude);
            // 
            // label_tieude
            // 
            this.label_tieude.AutoSize = true;
            this.label_tieude.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tieude.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_tieude.Location = new System.Drawing.Point(20, 15);
            this.label_tieude.Name = "label_tieude";
            this.label_tieude.Size = new System.Drawing.Size(400, 23);
            this.label_tieude.TabIndex = 0;
            this.label_tieude.Text = "CHI TIẾT ĐIỂM - CÁC ĐẦU ĐIỂM";
            // 
            // panel_nhap
            // 
            this.panel_nhap.BackColor = System.Drawing.Color.White;
            this.panel_nhap.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_nhap.Location = new System.Drawing.Point(0, 55);
            this.panel_nhap.Name = "panel_nhap";
            this.panel_nhap.Size = new System.Drawing.Size(460, 558);
            this.panel_nhap.TabIndex = 1;
            this.panel_nhap.Controls.Add(this.label_maCT);
            this.panel_nhap.Controls.Add(this.textBox_maCT);
            this.panel_nhap.Controls.Add(this.label_hocSinh);
            this.panel_nhap.Controls.Add(this.textBox_hocSinh);
            this.panel_nhap.Controls.Add(this.label_monHoc);
            this.panel_nhap.Controls.Add(this.textBox_monHoc);
            this.panel_nhap.Controls.Add(this.label_hocKy);
            this.panel_nhap.Controls.Add(this.comboBox_hocKy);
            this.panel_nhap.Controls.Add(this.label_loaiDiem);
            this.panel_nhap.Controls.Add(this.comboBox_loaiDiem);
            this.panel_nhap.Controls.Add(this.label_diem);
            this.panel_nhap.Controls.Add(this.textBox_diem);
            this.panel_nhap.Controls.Add(this.label_heSo);
            this.panel_nhap.Controls.Add(this.comboBox_heSo);
            this.panel_nhap.Controls.Add(this.label_ghiChu);
            this.panel_nhap.Controls.Add(this.textBox_ghiChu);
            this.panel_nhap.Controls.Add(this.button_them);
            this.panel_nhap.Controls.Add(this.button_sua);
            this.panel_nhap.Controls.Add(this.button_xoa);
            this.panel_nhap.Controls.Add(this.button_lamMoi);
            // 
            // label_maCT
            // 
            this.label_maCT.AutoSize = true;
            this.label_maCT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_maCT.Location = new System.Drawing.Point(15, 16);
            this.label_maCT.Name = "label_maCT";
            this.label_maCT.Size = new System.Drawing.Size(150, 21);
            this.label_maCT.TabIndex = 0;
            this.label_maCT.Text = "Mã đầu điểm :";
            // 
            // textBox_maCT
            // 
            this.textBox_maCT.Location = new System.Drawing.Point(185, 12);
            this.textBox_maCT.Name = "textBox_maCT";
            this.textBox_maCT.Size = new System.Drawing.Size(255, 27);
            this.textBox_maCT.TabIndex = 1;
            this.textBox_maCT.ReadOnly = true;
            this.textBox_maCT.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // label_hocSinh
            // 
            this.label_hocSinh.AutoSize = true;
            this.label_hocSinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_hocSinh.Location = new System.Drawing.Point(15, 56);
            this.label_hocSinh.Name = "label_hocSinh";
            this.label_hocSinh.Size = new System.Drawing.Size(150, 21);
            this.label_hocSinh.TabIndex = 0;
            this.label_hocSinh.Text = "Học sinh :";
            // 
            // textBox_hocSinh
            // 
            this.textBox_hocSinh.Location = new System.Drawing.Point(185, 52);
            this.textBox_hocSinh.Name = "textBox_hocSinh";
            this.textBox_hocSinh.Size = new System.Drawing.Size(255, 27);
            this.textBox_hocSinh.TabIndex = 2;
            this.textBox_hocSinh.ReadOnly = true;
            this.textBox_hocSinh.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // label_monHoc
            // 
            this.label_monHoc.AutoSize = true;
            this.label_monHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_monHoc.Location = new System.Drawing.Point(15, 96);
            this.label_monHoc.Name = "label_monHoc";
            this.label_monHoc.Size = new System.Drawing.Size(150, 21);
            this.label_monHoc.TabIndex = 0;
            this.label_monHoc.Text = "Môn học :";
            // 
            // textBox_monHoc
            // 
            this.textBox_monHoc.Location = new System.Drawing.Point(185, 92);
            this.textBox_monHoc.Name = "textBox_monHoc";
            this.textBox_monHoc.Size = new System.Drawing.Size(255, 27);
            this.textBox_monHoc.TabIndex = 3;
            this.textBox_monHoc.ReadOnly = true;
            this.textBox_monHoc.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // label_hocKy
            // 
            this.label_hocKy.AutoSize = true;
            this.label_hocKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_hocKy.Location = new System.Drawing.Point(15, 136);
            this.label_hocKy.Name = "label_hocKy";
            this.label_hocKy.Size = new System.Drawing.Size(150, 21);
            this.label_hocKy.TabIndex = 0;
            this.label_hocKy.Text = "Học kỳ :";
            // 
            // comboBox_hocKy
            // 
            this.comboBox_hocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_hocKy.FormattingEnabled = true;
            this.comboBox_hocKy.Location = new System.Drawing.Point(185, 132);
            this.comboBox_hocKy.Name = "comboBox_hocKy";
            this.comboBox_hocKy.Size = new System.Drawing.Size(255, 29);
            this.comboBox_hocKy.TabIndex = 4;
            // 
            // label_loaiDiem
            // 
            this.label_loaiDiem.AutoSize = true;
            this.label_loaiDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_loaiDiem.Location = new System.Drawing.Point(15, 176);
            this.label_loaiDiem.Name = "label_loaiDiem";
            this.label_loaiDiem.Size = new System.Drawing.Size(150, 21);
            this.label_loaiDiem.TabIndex = 0;
            this.label_loaiDiem.Text = "Loại điểm :";
            // 
            // comboBox_loaiDiem
            // 
            this.comboBox_loaiDiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_loaiDiem.FormattingEnabled = true;
            this.comboBox_loaiDiem.Location = new System.Drawing.Point(185, 172);
            this.comboBox_loaiDiem.Name = "comboBox_loaiDiem";
            this.comboBox_loaiDiem.Size = new System.Drawing.Size(255, 29);
            this.comboBox_loaiDiem.TabIndex = 5;
            // 
            // label_diem
            // 
            this.label_diem.AutoSize = true;
            this.label_diem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_diem.Location = new System.Drawing.Point(15, 216);
            this.label_diem.Name = "label_diem";
            this.label_diem.Size = new System.Drawing.Size(150, 21);
            this.label_diem.TabIndex = 0;
            this.label_diem.Text = "Điểm :";
            // 
            // textBox_diem
            // 
            this.textBox_diem.Location = new System.Drawing.Point(185, 212);
            this.textBox_diem.Name = "textBox_diem";
            this.textBox_diem.Size = new System.Drawing.Size(255, 27);
            this.textBox_diem.TabIndex = 6;
            // 
            // label_heSo
            // 
            this.label_heSo.AutoSize = true;
            this.label_heSo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_heSo.Location = new System.Drawing.Point(15, 256);
            this.label_heSo.Name = "label_heSo";
            this.label_heSo.Size = new System.Drawing.Size(150, 21);
            this.label_heSo.TabIndex = 0;
            this.label_heSo.Text = "Hệ số :";
            // 
            // comboBox_heSo
            // 
            this.comboBox_heSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_heSo.FormattingEnabled = true;
            this.comboBox_heSo.Location = new System.Drawing.Point(185, 252);
            this.comboBox_heSo.Name = "comboBox_heSo";
            this.comboBox_heSo.Size = new System.Drawing.Size(255, 29);
            this.comboBox_heSo.TabIndex = 7;
            // 
            // label_ghiChu
            // 
            this.label_ghiChu.AutoSize = true;
            this.label_ghiChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_ghiChu.Location = new System.Drawing.Point(15, 296);
            this.label_ghiChu.Name = "label_ghiChu";
            this.label_ghiChu.Size = new System.Drawing.Size(150, 21);
            this.label_ghiChu.TabIndex = 0;
            this.label_ghiChu.Text = "Ghi chú :";
            // 
            // textBox_ghiChu
            // 
            this.textBox_ghiChu.Location = new System.Drawing.Point(185, 292);
            this.textBox_ghiChu.Multiline = true;
            this.textBox_ghiChu.Name = "textBox_ghiChu";
            this.textBox_ghiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_ghiChu.Size = new System.Drawing.Size(255, 55);
            this.textBox_ghiChu.TabIndex = 8;
            // 
            // button_them
            // 
            this.button_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_them.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_them.ForeColor = System.Drawing.Color.White;
            this.button_them.Location = new System.Drawing.Point(15, 368);
            this.button_them.Name = "button_them";
            this.button_them.Size = new System.Drawing.Size(102, 40);
            this.button_them.TabIndex = 30;
            this.button_them.Text = "Thêm";
            this.button_them.UseVisualStyleBackColor = false;
            this.button_them.Click += new System.EventHandler(this.button_them_Click);
            // 
            // button_sua
            // 
            this.button_sua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_sua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sua.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sua.ForeColor = System.Drawing.Color.White;
            this.button_sua.Location = new System.Drawing.Point(123, 368);
            this.button_sua.Name = "button_sua";
            this.button_sua.Size = new System.Drawing.Size(102, 40);
            this.button_sua.TabIndex = 30;
            this.button_sua.Text = "Sửa";
            this.button_sua.UseVisualStyleBackColor = false;
            this.button_sua.Click += new System.EventHandler(this.button_sua_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_xoa.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.ForeColor = System.Drawing.Color.White;
            this.button_xoa.Location = new System.Drawing.Point(231, 368);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(102, 40);
            this.button_xoa.TabIndex = 30;
            this.button_xoa.Text = "Xoá";
            this.button_xoa.UseVisualStyleBackColor = false;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_lamMoi
            // 
            this.button_lamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_lamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_lamMoi.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_lamMoi.ForeColor = System.Drawing.Color.White;
            this.button_lamMoi.Location = new System.Drawing.Point(339, 368);
            this.button_lamMoi.Name = "button_lamMoi";
            this.button_lamMoi.Size = new System.Drawing.Size(102, 40);
            this.button_lamMoi.TabIndex = 30;
            this.button_lamMoi.Text = "Làm mới";
            this.button_lamMoi.UseVisualStyleBackColor = false;
            this.button_lamMoi.Click += new System.EventHandler(this.button_lamMoi_Click);
            // 
            // textBox_timKiem
            // 
            this.textBox_timKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_timKiem.Location = new System.Drawing.Point(475, 70);
            this.textBox_timKiem.Name = "textBox_timKiem";
            this.textBox_timKiem.Size = new System.Drawing.Size(320, 27);
            this.textBox_timKiem.TabIndex = 40;
            // 
            // button_timKiem
            // 
            this.button_timKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_timKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_timKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_timKiem.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_timKiem.ForeColor = System.Drawing.Color.White;
            this.button_timKiem.Location = new System.Drawing.Point(805, 68);
            this.button_timKiem.Name = "button_timKiem";
            this.button_timKiem.Size = new System.Drawing.Size(112, 32);
            this.button_timKiem.TabIndex = 30;
            this.button_timKiem.Text = "Tìm kiếm";
            this.button_timKiem.UseVisualStyleBackColor = false;
            this.button_timKiem.Click += new System.EventHandler(this.button_timKiem_Click);
            // 
            // label_bangDiem
            // 
            this.label_bangDiem.AutoSize = true;
            this.label_bangDiem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_bangDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_bangDiem.Location = new System.Drawing.Point(475, 109);
            this.label_bangDiem.Name = "label_bangDiem";
            this.label_bangDiem.Size = new System.Drawing.Size(150, 21);
            this.label_bangDiem.TabIndex = 0;
            this.label_bangDiem.Text = "Bước 1 - Chọn môn của học sinh :";
            // 
            // DataGridView_bangDiem
            // 
            this.DataGridView_bangDiem.AllowUserToAddRows = false;
            this.DataGridView_bangDiem.AllowUserToDeleteRows = false;
            this.DataGridView_bangDiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_bangDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_bangDiem.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGridView_bangDiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_bangDiem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_bangDiem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_bangDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_bangDiem.GridColor = System.Drawing.Color.White;
            this.DataGridView_bangDiem.Location = new System.Drawing.Point(475, 135);
            this.DataGridView_bangDiem.MultiSelect = false;
            this.DataGridView_bangDiem.Name = "DataGridView_bangDiem";
            this.DataGridView_bangDiem.ReadOnly = true;
            this.DataGridView_bangDiem.RowHeadersVisible = false;
            this.DataGridView_bangDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_bangDiem.Size = new System.Drawing.Size(442, 215);
            this.DataGridView_bangDiem.TabIndex = 42;
            this.DataGridView_bangDiem.Click += new System.EventHandler(this.DataGridView_bangDiem_Click);
            // 
            // label_chiTiet
            // 
            this.label_chiTiet.AutoSize = true;
            this.label_chiTiet.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_chiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_chiTiet.Location = new System.Drawing.Point(475, 369);
            this.label_chiTiet.Name = "label_chiTiet";
            this.label_chiTiet.Size = new System.Drawing.Size(150, 21);
            this.label_chiTiet.TabIndex = 0;
            this.label_chiTiet.Text = "Bước 2 - Các đầu điểm của môn đã chọn :";
            // 
            // DataGridView_chiTiet
            // 
            this.DataGridView_chiTiet.AllowUserToAddRows = false;
            this.DataGridView_chiTiet.AllowUserToDeleteRows = false;
            this.DataGridView_chiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_chiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_chiTiet.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGridView_chiTiet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_chiTiet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_chiTiet.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_chiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_chiTiet.GridColor = System.Drawing.Color.White;
            this.DataGridView_chiTiet.Location = new System.Drawing.Point(475, 395);
            this.DataGridView_chiTiet.MultiSelect = false;
            this.DataGridView_chiTiet.Name = "DataGridView_chiTiet";
            this.DataGridView_chiTiet.ReadOnly = true;
            this.DataGridView_chiTiet.RowHeadersVisible = false;
            this.DataGridView_chiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_chiTiet.Size = new System.Drawing.Size(442, 195);
            this.DataGridView_chiTiet.TabIndex = 42;
            this.DataGridView_chiTiet.Click += new System.EventHandler(this.DataGridView_chiTiet_Click);
            // 
            // FrmChiTietDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 613);
            this.Controls.Add(this.DataGridView_chiTiet);
            this.Controls.Add(this.label_chiTiet);
            this.Controls.Add(this.DataGridView_bangDiem);
            this.Controls.Add(this.label_bangDiem);
            this.Controls.Add(this.button_timKiem);
            this.Controls.Add(this.textBox_timKiem);
            this.Controls.Add(this.panel_nhap);
            this.Controls.Add(this.panel_tieude);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmChiTietDiem";
            this.Text = "FrmChiTietDiem";
            this.Load += new System.EventHandler(this.FrmChiTietDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_bangDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_chiTiet)).EndInit();
            this.panel_tieude.ResumeLayout(false);
            this.panel_tieude.PerformLayout();
            this.panel_nhap.ResumeLayout(false);
            this.panel_nhap.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_tieude;
        private System.Windows.Forms.Label label_tieude;
        private System.Windows.Forms.Panel panel_nhap;
        private System.Windows.Forms.Label label_maCT;
        private System.Windows.Forms.TextBox textBox_maCT;
        private System.Windows.Forms.Label label_hocSinh;
        private System.Windows.Forms.TextBox textBox_hocSinh;
        private System.Windows.Forms.Label label_monHoc;
        private System.Windows.Forms.TextBox textBox_monHoc;
        private System.Windows.Forms.Label label_hocKy;
        private System.Windows.Forms.ComboBox comboBox_hocKy;
        private System.Windows.Forms.Label label_loaiDiem;
        private System.Windows.Forms.ComboBox comboBox_loaiDiem;
        private System.Windows.Forms.Label label_diem;
        private System.Windows.Forms.TextBox textBox_diem;
        private System.Windows.Forms.Label label_heSo;
        private System.Windows.Forms.ComboBox comboBox_heSo;
        private System.Windows.Forms.Label label_ghiChu;
        private System.Windows.Forms.TextBox textBox_ghiChu;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_lamMoi;
        private System.Windows.Forms.TextBox textBox_timKiem;
        private System.Windows.Forms.Button button_timKiem;
        private System.Windows.Forms.Label label_bangDiem;
        private System.Windows.Forms.DataGridView DataGridView_bangDiem;
        private System.Windows.Forms.Label label_chiTiet;
        private System.Windows.Forms.DataGridView DataGridView_chiTiet;
    }
}
