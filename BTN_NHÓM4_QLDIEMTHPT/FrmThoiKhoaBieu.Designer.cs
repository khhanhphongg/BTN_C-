namespace QLDiemTHPT
{
    partial class FrmThoiKhoaBieu
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
            this.label_maTiet = new System.Windows.Forms.Label();
            this.textBox_maTiet = new System.Windows.Forms.TextBox();
            this.label_monHoc = new System.Windows.Forms.Label();
            this.comboBox_monHoc = new System.Windows.Forms.ComboBox();
            this.label_lop = new System.Windows.Forms.Label();
            this.comboBox_lop = new System.Windows.Forms.ComboBox();
            this.label_giaoVien = new System.Windows.Forms.Label();
            this.comboBox_giaoVien = new System.Windows.Forms.ComboBox();
            this.label_phongHoc = new System.Windows.Forms.Label();
            this.comboBox_phongHoc = new System.Windows.Forms.ComboBox();
            this.label_hocKy = new System.Windows.Forms.Label();
            this.comboBox_hocKy = new System.Windows.Forms.ComboBox();
            this.label_thu = new System.Windows.Forms.Label();
            this.comboBox_thu = new System.Windows.Forms.ComboBox();
            this.label_batDau = new System.Windows.Forms.Label();
            this.dateTimePicker_batDau = new System.Windows.Forms.DateTimePicker();
            this.label_ketThuc = new System.Windows.Forms.Label();
            this.dateTimePicker_ketThuc = new System.Windows.Forms.DateTimePicker();
            this.button_them = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_lamMoi = new System.Windows.Forms.Button();
            this.textBox_timKiem = new System.Windows.Forms.TextBox();
            this.button_timKiem = new System.Windows.Forms.Button();
            this.DataGridView_tkb = new System.Windows.Forms.DataGridView();
            this.panel_tieude.SuspendLayout();
            this.panel_nhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_tkb)).BeginInit();
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
            this.label_tieude.Text = "QUẢN LÝ THỜI KHOÁ BIỂU";
            // 
            // panel_nhap
            // 
            this.panel_nhap.BackColor = System.Drawing.Color.White;
            this.panel_nhap.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_nhap.Location = new System.Drawing.Point(0, 55);
            this.panel_nhap.Name = "panel_nhap";
            this.panel_nhap.Size = new System.Drawing.Size(460, 558);
            this.panel_nhap.TabIndex = 1;
            this.panel_nhap.Controls.Add(this.label_maTiet);
            this.panel_nhap.Controls.Add(this.textBox_maTiet);
            this.panel_nhap.Controls.Add(this.label_monHoc);
            this.panel_nhap.Controls.Add(this.comboBox_monHoc);
            this.panel_nhap.Controls.Add(this.label_lop);
            this.panel_nhap.Controls.Add(this.comboBox_lop);
            this.panel_nhap.Controls.Add(this.label_giaoVien);
            this.panel_nhap.Controls.Add(this.comboBox_giaoVien);
            this.panel_nhap.Controls.Add(this.label_phongHoc);
            this.panel_nhap.Controls.Add(this.comboBox_phongHoc);
            this.panel_nhap.Controls.Add(this.label_hocKy);
            this.panel_nhap.Controls.Add(this.comboBox_hocKy);
            this.panel_nhap.Controls.Add(this.label_thu);
            this.panel_nhap.Controls.Add(this.comboBox_thu);
            this.panel_nhap.Controls.Add(this.label_batDau);
            this.panel_nhap.Controls.Add(this.dateTimePicker_batDau);
            this.panel_nhap.Controls.Add(this.label_ketThuc);
            this.panel_nhap.Controls.Add(this.dateTimePicker_ketThuc);
            this.panel_nhap.Controls.Add(this.button_them);
            this.panel_nhap.Controls.Add(this.button_sua);
            this.panel_nhap.Controls.Add(this.button_xoa);
            this.panel_nhap.Controls.Add(this.button_lamMoi);
            // 
            // label_maTiet
            // 
            this.label_maTiet.AutoSize = true;
            this.label_maTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_maTiet.Location = new System.Drawing.Point(15, 16);
            this.label_maTiet.Name = "label_maTiet";
            this.label_maTiet.Size = new System.Drawing.Size(150, 21);
            this.label_maTiet.TabIndex = 0;
            this.label_maTiet.Text = "Mã tiết :";
            // 
            // textBox_maTiet
            // 
            this.textBox_maTiet.Location = new System.Drawing.Point(185, 12);
            this.textBox_maTiet.Name = "textBox_maTiet";
            this.textBox_maTiet.Size = new System.Drawing.Size(255, 27);
            this.textBox_maTiet.TabIndex = 1;
            this.textBox_maTiet.ReadOnly = true;
            this.textBox_maTiet.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // label_monHoc
            // 
            this.label_monHoc.AutoSize = true;
            this.label_monHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_monHoc.Location = new System.Drawing.Point(15, 56);
            this.label_monHoc.Name = "label_monHoc";
            this.label_monHoc.Size = new System.Drawing.Size(150, 21);
            this.label_monHoc.TabIndex = 0;
            this.label_monHoc.Text = "Môn học :";
            // 
            // comboBox_monHoc
            // 
            this.comboBox_monHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_monHoc.FormattingEnabled = true;
            this.comboBox_monHoc.Location = new System.Drawing.Point(185, 52);
            this.comboBox_monHoc.Name = "comboBox_monHoc";
            this.comboBox_monHoc.Size = new System.Drawing.Size(255, 29);
            this.comboBox_monHoc.TabIndex = 2;
            // 
            // label_lop
            // 
            this.label_lop.AutoSize = true;
            this.label_lop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_lop.Location = new System.Drawing.Point(15, 96);
            this.label_lop.Name = "label_lop";
            this.label_lop.Size = new System.Drawing.Size(150, 21);
            this.label_lop.TabIndex = 0;
            this.label_lop.Text = "Lớp :";
            // 
            // comboBox_lop
            // 
            this.comboBox_lop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lop.FormattingEnabled = true;
            this.comboBox_lop.Location = new System.Drawing.Point(185, 92);
            this.comboBox_lop.Name = "comboBox_lop";
            this.comboBox_lop.Size = new System.Drawing.Size(255, 29);
            this.comboBox_lop.TabIndex = 3;
            // 
            // label_giaoVien
            // 
            this.label_giaoVien.AutoSize = true;
            this.label_giaoVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_giaoVien.Location = new System.Drawing.Point(15, 136);
            this.label_giaoVien.Name = "label_giaoVien";
            this.label_giaoVien.Size = new System.Drawing.Size(150, 21);
            this.label_giaoVien.TabIndex = 0;
            this.label_giaoVien.Text = "Giáo viên :";
            // 
            // comboBox_giaoVien
            // 
            this.comboBox_giaoVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_giaoVien.FormattingEnabled = true;
            this.comboBox_giaoVien.Location = new System.Drawing.Point(185, 132);
            this.comboBox_giaoVien.Name = "comboBox_giaoVien";
            this.comboBox_giaoVien.Size = new System.Drawing.Size(255, 29);
            this.comboBox_giaoVien.TabIndex = 4;
            // 
            // label_phongHoc
            // 
            this.label_phongHoc.AutoSize = true;
            this.label_phongHoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_phongHoc.Location = new System.Drawing.Point(15, 176);
            this.label_phongHoc.Name = "label_phongHoc";
            this.label_phongHoc.Size = new System.Drawing.Size(150, 21);
            this.label_phongHoc.TabIndex = 0;
            this.label_phongHoc.Text = "Phòng học :";
            // 
            // comboBox_phongHoc
            // 
            this.comboBox_phongHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_phongHoc.FormattingEnabled = true;
            this.comboBox_phongHoc.Location = new System.Drawing.Point(185, 172);
            this.comboBox_phongHoc.Name = "comboBox_phongHoc";
            this.comboBox_phongHoc.Size = new System.Drawing.Size(255, 29);
            this.comboBox_phongHoc.TabIndex = 5;
            // 
            // label_hocKy
            // 
            this.label_hocKy.AutoSize = true;
            this.label_hocKy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_hocKy.Location = new System.Drawing.Point(15, 216);
            this.label_hocKy.Name = "label_hocKy";
            this.label_hocKy.Size = new System.Drawing.Size(150, 21);
            this.label_hocKy.TabIndex = 0;
            this.label_hocKy.Text = "Học kỳ :";
            // 
            // comboBox_hocKy
            // 
            this.comboBox_hocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_hocKy.FormattingEnabled = true;
            this.comboBox_hocKy.Location = new System.Drawing.Point(185, 212);
            this.comboBox_hocKy.Name = "comboBox_hocKy";
            this.comboBox_hocKy.Size = new System.Drawing.Size(255, 29);
            this.comboBox_hocKy.TabIndex = 6;
            // 
            // label_thu
            // 
            this.label_thu.AutoSize = true;
            this.label_thu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_thu.Location = new System.Drawing.Point(15, 256);
            this.label_thu.Name = "label_thu";
            this.label_thu.Size = new System.Drawing.Size(150, 21);
            this.label_thu.TabIndex = 0;
            this.label_thu.Text = "Thứ :";
            // 
            // comboBox_thu
            // 
            this.comboBox_thu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_thu.FormattingEnabled = true;
            this.comboBox_thu.Location = new System.Drawing.Point(185, 252);
            this.comboBox_thu.Name = "comboBox_thu";
            this.comboBox_thu.Size = new System.Drawing.Size(255, 29);
            this.comboBox_thu.TabIndex = 7;
            // 
            // label_batDau
            // 
            this.label_batDau.AutoSize = true;
            this.label_batDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_batDau.Location = new System.Drawing.Point(15, 296);
            this.label_batDau.Name = "label_batDau";
            this.label_batDau.Size = new System.Drawing.Size(150, 21);
            this.label_batDau.TabIndex = 0;
            this.label_batDau.Text = "Giờ bắt đầu :";
            // 
            // dateTimePicker_batDau
            // 
            this.dateTimePicker_batDau.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_batDau.Location = new System.Drawing.Point(185, 292);
            this.dateTimePicker_batDau.Name = "dateTimePicker_batDau";
            this.dateTimePicker_batDau.ShowUpDown = true;
            this.dateTimePicker_batDau.Size = new System.Drawing.Size(255, 27);
            this.dateTimePicker_batDau.TabIndex = 8;
            // 
            // label_ketThuc
            // 
            this.label_ketThuc.AutoSize = true;
            this.label_ketThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_ketThuc.Location = new System.Drawing.Point(15, 336);
            this.label_ketThuc.Name = "label_ketThuc";
            this.label_ketThuc.Size = new System.Drawing.Size(150, 21);
            this.label_ketThuc.TabIndex = 0;
            this.label_ketThuc.Text = "Giờ kết thúc :";
            // 
            // dateTimePicker_ketThuc
            // 
            this.dateTimePicker_ketThuc.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_ketThuc.Location = new System.Drawing.Point(185, 332);
            this.dateTimePicker_ketThuc.Name = "dateTimePicker_ketThuc";
            this.dateTimePicker_ketThuc.ShowUpDown = true;
            this.dateTimePicker_ketThuc.Size = new System.Drawing.Size(255, 27);
            this.dateTimePicker_ketThuc.TabIndex = 9;
            // 
            // button_them
            // 
            this.button_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_them.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_them.ForeColor = System.Drawing.Color.White;
            this.button_them.Location = new System.Drawing.Point(15, 380);
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
            this.button_sua.Location = new System.Drawing.Point(123, 380);
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
            this.button_xoa.Location = new System.Drawing.Point(231, 380);
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
            this.button_lamMoi.Location = new System.Drawing.Point(339, 380);
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
            // DataGridView_tkb
            // 
            this.DataGridView_tkb.AllowUserToAddRows = false;
            this.DataGridView_tkb.AllowUserToDeleteRows = false;
            this.DataGridView_tkb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_tkb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_tkb.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGridView_tkb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_tkb.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_tkb.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_tkb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_tkb.GridColor = System.Drawing.Color.White;
            this.DataGridView_tkb.Location = new System.Drawing.Point(475, 110);
            this.DataGridView_tkb.MultiSelect = false;
            this.DataGridView_tkb.Name = "DataGridView_tkb";
            this.DataGridView_tkb.ReadOnly = true;
            this.DataGridView_tkb.RowHeadersVisible = false;
            this.DataGridView_tkb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_tkb.Size = new System.Drawing.Size(442, 480);
            this.DataGridView_tkb.TabIndex = 42;
            this.DataGridView_tkb.Click += new System.EventHandler(this.DataGridView_tkb_Click);
            // 
            // FrmThoiKhoaBieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 613);
            this.Controls.Add(this.DataGridView_tkb);
            this.Controls.Add(this.button_timKiem);
            this.Controls.Add(this.textBox_timKiem);
            this.Controls.Add(this.panel_nhap);
            this.Controls.Add(this.panel_tieude);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmThoiKhoaBieu";
            this.Text = "FrmThoiKhoaBieu";
            this.Load += new System.EventHandler(this.FrmThoiKhoaBieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_tkb)).EndInit();
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
        private System.Windows.Forms.Label label_maTiet;
        private System.Windows.Forms.TextBox textBox_maTiet;
        private System.Windows.Forms.Label label_monHoc;
        private System.Windows.Forms.ComboBox comboBox_monHoc;
        private System.Windows.Forms.Label label_lop;
        private System.Windows.Forms.ComboBox comboBox_lop;
        private System.Windows.Forms.Label label_giaoVien;
        private System.Windows.Forms.ComboBox comboBox_giaoVien;
        private System.Windows.Forms.Label label_phongHoc;
        private System.Windows.Forms.ComboBox comboBox_phongHoc;
        private System.Windows.Forms.Label label_hocKy;
        private System.Windows.Forms.ComboBox comboBox_hocKy;
        private System.Windows.Forms.Label label_thu;
        private System.Windows.Forms.ComboBox comboBox_thu;
        private System.Windows.Forms.Label label_batDau;
        private System.Windows.Forms.DateTimePicker dateTimePicker_batDau;
        private System.Windows.Forms.Label label_ketThuc;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ketThuc;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_lamMoi;
        private System.Windows.Forms.TextBox textBox_timKiem;
        private System.Windows.Forms.Button button_timKiem;
        private System.Windows.Forms.DataGridView DataGridView_tkb;
    }
}
