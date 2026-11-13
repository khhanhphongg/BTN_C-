namespace QLDiemTHPT
{
    partial class FrmHocSinh
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
            this.label_maHS = new System.Windows.Forms.Label();
            this.textBox_maHS = new System.Windows.Forms.TextBox();
            this.label_ho = new System.Windows.Forms.Label();
            this.textBox_ho = new System.Windows.Forms.TextBox();
            this.label_ten = new System.Windows.Forms.Label();
            this.textBox_ten = new System.Windows.Forms.TextBox();
            this.label_ns = new System.Windows.Forms.Label();
            this.dateTimePicker_ns = new System.Windows.Forms.DateTimePicker();
            this.label_gt = new System.Windows.Forms.Label();
            this.radioButton_nam = new System.Windows.Forms.RadioButton();
            this.radioButton_nu = new System.Windows.Forms.RadioButton();
            this.label_dienThoai = new System.Windows.Forms.Label();
            this.textBox_dienThoai = new System.Windows.Forms.TextBox();
            this.label_diaChi = new System.Windows.Forms.Label();
            this.textBox_diaChi = new System.Windows.Forms.TextBox();
            this.label_lop = new System.Windows.Forms.Label();
            this.comboBox_lop = new System.Windows.Forms.ComboBox();
            this.label_anh = new System.Windows.Forms.Label();
            this.pictureBox_anh = new System.Windows.Forms.PictureBox();
            this.button_chonAnh = new System.Windows.Forms.Button();
            this.button_them = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_lamMoi = new System.Windows.Forms.Button();
            this.textBox_timKiem = new System.Windows.Forms.TextBox();
            this.button_timKiem = new System.Windows.Forms.Button();
            this.DataGridView_hocSinh = new System.Windows.Forms.DataGridView();
            this.panel_tieude.SuspendLayout();
            this.panel_nhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_anh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_hocSinh)).BeginInit();
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
            this.label_tieude.Text = "QUẢN LÝ THÔNG TIN HỌC SINH";
            // 
            // panel_nhap
            // 
            this.panel_nhap.BackColor = System.Drawing.Color.White;
            this.panel_nhap.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_nhap.Location = new System.Drawing.Point(0, 55);
            this.panel_nhap.Name = "panel_nhap";
            this.panel_nhap.Size = new System.Drawing.Size(460, 558);
            this.panel_nhap.TabIndex = 1;
            this.panel_nhap.Controls.Add(this.label_maHS);
            this.panel_nhap.Controls.Add(this.textBox_maHS);
            this.panel_nhap.Controls.Add(this.label_ho);
            this.panel_nhap.Controls.Add(this.textBox_ho);
            this.panel_nhap.Controls.Add(this.label_ten);
            this.panel_nhap.Controls.Add(this.textBox_ten);
            this.panel_nhap.Controls.Add(this.label_ns);
            this.panel_nhap.Controls.Add(this.dateTimePicker_ns);
            this.panel_nhap.Controls.Add(this.label_gt);
            this.panel_nhap.Controls.Add(this.radioButton_nam);
            this.panel_nhap.Controls.Add(this.radioButton_nu);
            this.panel_nhap.Controls.Add(this.label_dienThoai);
            this.panel_nhap.Controls.Add(this.textBox_dienThoai);
            this.panel_nhap.Controls.Add(this.label_diaChi);
            this.panel_nhap.Controls.Add(this.textBox_diaChi);
            this.panel_nhap.Controls.Add(this.label_lop);
            this.panel_nhap.Controls.Add(this.comboBox_lop);
            this.panel_nhap.Controls.Add(this.label_anh);
            this.panel_nhap.Controls.Add(this.pictureBox_anh);
            this.panel_nhap.Controls.Add(this.button_chonAnh);
            this.panel_nhap.Controls.Add(this.button_them);
            this.panel_nhap.Controls.Add(this.button_sua);
            this.panel_nhap.Controls.Add(this.button_xoa);
            this.panel_nhap.Controls.Add(this.button_lamMoi);
            // 
            // label_maHS
            // 
            this.label_maHS.AutoSize = true;
            this.label_maHS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_maHS.Location = new System.Drawing.Point(15, 16);
            this.label_maHS.Name = "label_maHS";
            this.label_maHS.Size = new System.Drawing.Size(150, 21);
            this.label_maHS.TabIndex = 0;
            this.label_maHS.Text = "Mã học sinh :";
            // 
            // textBox_maHS
            // 
            this.textBox_maHS.Location = new System.Drawing.Point(185, 12);
            this.textBox_maHS.Name = "textBox_maHS";
            this.textBox_maHS.Size = new System.Drawing.Size(255, 27);
            this.textBox_maHS.TabIndex = 1;
            this.textBox_maHS.ReadOnly = true;
            this.textBox_maHS.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // label_ho
            // 
            this.label_ho.AutoSize = true;
            this.label_ho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_ho.Location = new System.Drawing.Point(15, 56);
            this.label_ho.Name = "label_ho";
            this.label_ho.Size = new System.Drawing.Size(150, 21);
            this.label_ho.TabIndex = 0;
            this.label_ho.Text = "Họ :";
            // 
            // textBox_ho
            // 
            this.textBox_ho.Location = new System.Drawing.Point(185, 52);
            this.textBox_ho.Name = "textBox_ho";
            this.textBox_ho.Size = new System.Drawing.Size(255, 27);
            this.textBox_ho.TabIndex = 2;
            // 
            // label_ten
            // 
            this.label_ten.AutoSize = true;
            this.label_ten.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_ten.Location = new System.Drawing.Point(15, 96);
            this.label_ten.Name = "label_ten";
            this.label_ten.Size = new System.Drawing.Size(150, 21);
            this.label_ten.TabIndex = 0;
            this.label_ten.Text = "Tên :";
            // 
            // textBox_ten
            // 
            this.textBox_ten.Location = new System.Drawing.Point(185, 92);
            this.textBox_ten.Name = "textBox_ten";
            this.textBox_ten.Size = new System.Drawing.Size(255, 27);
            this.textBox_ten.TabIndex = 3;
            // 
            // label_ns
            // 
            this.label_ns.AutoSize = true;
            this.label_ns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_ns.Location = new System.Drawing.Point(15, 136);
            this.label_ns.Name = "label_ns";
            this.label_ns.Size = new System.Drawing.Size(150, 21);
            this.label_ns.TabIndex = 0;
            this.label_ns.Text = "Ngày sinh :";
            // 
            // dateTimePicker_ns
            // 
            this.dateTimePicker_ns.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ns.Location = new System.Drawing.Point(185, 132);
            this.dateTimePicker_ns.Name = "dateTimePicker_ns";
            this.dateTimePicker_ns.Size = new System.Drawing.Size(255, 27);
            this.dateTimePicker_ns.TabIndex = 4;
            // 
            // label_gt
            // 
            this.label_gt.AutoSize = true;
            this.label_gt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_gt.Location = new System.Drawing.Point(15, 176);
            this.label_gt.Name = "label_gt";
            this.label_gt.Size = new System.Drawing.Size(150, 21);
            this.label_gt.TabIndex = 0;
            this.label_gt.Text = "Giới tính :";
            // 
            // radioButton_nam
            // 
            this.radioButton_nam.AutoSize = true;
            this.radioButton_nam.Checked = true;
            this.radioButton_nam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.radioButton_nam.Location = new System.Drawing.Point(185, 172);
            this.radioButton_nam.Name = "radioButton_nam";
            this.radioButton_nam.Size = new System.Drawing.Size(70, 25);
            this.radioButton_nam.TabIndex = 5;
            this.radioButton_nam.TabStop = true;
            this.radioButton_nam.Text = "Nam";
            // 
            // radioButton_nu
            // 
            this.radioButton_nu.AutoSize = true;
            this.radioButton_nu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.radioButton_nu.Location = new System.Drawing.Point(300, 172);
            this.radioButton_nu.Name = "radioButton_nu";
            this.radioButton_nu.Size = new System.Drawing.Size(60, 25);
            this.radioButton_nu.TabIndex = 6;
            this.radioButton_nu.Text = "Nữ";
            // 
            // label_dienThoai
            // 
            this.label_dienThoai.AutoSize = true;
            this.label_dienThoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_dienThoai.Location = new System.Drawing.Point(15, 216);
            this.label_dienThoai.Name = "label_dienThoai";
            this.label_dienThoai.Size = new System.Drawing.Size(150, 21);
            this.label_dienThoai.TabIndex = 0;
            this.label_dienThoai.Text = "Điện thoại :";
            // 
            // textBox_dienThoai
            // 
            this.textBox_dienThoai.Location = new System.Drawing.Point(185, 212);
            this.textBox_dienThoai.Name = "textBox_dienThoai";
            this.textBox_dienThoai.Size = new System.Drawing.Size(255, 27);
            this.textBox_dienThoai.TabIndex = 6;
            // 
            // label_diaChi
            // 
            this.label_diaChi.AutoSize = true;
            this.label_diaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_diaChi.Location = new System.Drawing.Point(15, 256);
            this.label_diaChi.Name = "label_diaChi";
            this.label_diaChi.Size = new System.Drawing.Size(150, 21);
            this.label_diaChi.TabIndex = 0;
            this.label_diaChi.Text = "Địa chỉ :";
            // 
            // textBox_diaChi
            // 
            this.textBox_diaChi.Location = new System.Drawing.Point(185, 252);
            this.textBox_diaChi.Multiline = true;
            this.textBox_diaChi.Name = "textBox_diaChi";
            this.textBox_diaChi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_diaChi.Size = new System.Drawing.Size(255, 55);
            this.textBox_diaChi.TabIndex = 7;
            // 
            // label_lop
            // 
            this.label_lop.AutoSize = true;
            this.label_lop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_lop.Location = new System.Drawing.Point(15, 324);
            this.label_lop.Name = "label_lop";
            this.label_lop.Size = new System.Drawing.Size(150, 21);
            this.label_lop.TabIndex = 0;
            this.label_lop.Text = "Lớp :";
            // 
            // comboBox_lop
            // 
            this.comboBox_lop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lop.FormattingEnabled = true;
            this.comboBox_lop.Location = new System.Drawing.Point(185, 320);
            this.comboBox_lop.Name = "comboBox_lop";
            this.comboBox_lop.Size = new System.Drawing.Size(255, 29);
            this.comboBox_lop.TabIndex = 8;
            // 
            // label_anh
            // 
            this.label_anh.AutoSize = true;
            this.label_anh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_anh.Location = new System.Drawing.Point(15, 364);
            this.label_anh.Name = "label_anh";
            this.label_anh.Size = new System.Drawing.Size(150, 21);
            this.label_anh.TabIndex = 0;
            this.label_anh.Text = "Ảnh :";
            // 
            // pictureBox_anh
            // 
            this.pictureBox_anh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_anh.Location = new System.Drawing.Point(185, 360);
            this.pictureBox_anh.Name = "pictureBox_anh";
            this.pictureBox_anh.Size = new System.Drawing.Size(120, 120);
            this.pictureBox_anh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_anh.TabIndex = 20;
            this.pictureBox_anh.TabStop = false;
            // 
            // button_chonAnh
            // 
            this.button_chonAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_chonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_chonAnh.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_chonAnh.ForeColor = System.Drawing.Color.White;
            this.button_chonAnh.Location = new System.Drawing.Point(320, 405);
            this.button_chonAnh.Name = "button_chonAnh";
            this.button_chonAnh.Size = new System.Drawing.Size(120, 35);
            this.button_chonAnh.TabIndex = 30;
            this.button_chonAnh.Text = "Chọn ảnh";
            this.button_chonAnh.UseVisualStyleBackColor = false;
            this.button_chonAnh.Click += new System.EventHandler(this.button_chonAnh_Click);
            // 
            // button_them
            // 
            this.button_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_them.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_them.ForeColor = System.Drawing.Color.White;
            this.button_them.Location = new System.Drawing.Point(15, 500);
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
            this.button_sua.Location = new System.Drawing.Point(123, 500);
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
            this.button_xoa.Location = new System.Drawing.Point(231, 500);
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
            this.button_lamMoi.Location = new System.Drawing.Point(339, 500);
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
            // DataGridView_hocSinh
            // 
            this.DataGridView_hocSinh.AllowUserToAddRows = false;
            this.DataGridView_hocSinh.AllowUserToDeleteRows = false;
            this.DataGridView_hocSinh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_hocSinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_hocSinh.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGridView_hocSinh.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_hocSinh.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_hocSinh.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_hocSinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_hocSinh.GridColor = System.Drawing.Color.White;
            this.DataGridView_hocSinh.Location = new System.Drawing.Point(475, 110);
            this.DataGridView_hocSinh.MultiSelect = false;
            this.DataGridView_hocSinh.Name = "DataGridView_hocSinh";
            this.DataGridView_hocSinh.ReadOnly = true;
            this.DataGridView_hocSinh.RowHeadersVisible = false;
            this.DataGridView_hocSinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_hocSinh.Size = new System.Drawing.Size(442, 480);
            this.DataGridView_hocSinh.TabIndex = 42;
            this.DataGridView_hocSinh.Click += new System.EventHandler(this.DataGridView_hocSinh_Click);
            // 
            // FrmHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 613);
            this.Controls.Add(this.DataGridView_hocSinh);
            this.Controls.Add(this.button_timKiem);
            this.Controls.Add(this.textBox_timKiem);
            this.Controls.Add(this.panel_nhap);
            this.Controls.Add(this.panel_tieude);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmHocSinh";
            this.Text = "FrmHocSinh";
            this.Load += new System.EventHandler(this.FrmHocSinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_anh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_hocSinh)).EndInit();
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
        private System.Windows.Forms.Label label_maHS;
        private System.Windows.Forms.TextBox textBox_maHS;
        private System.Windows.Forms.Label label_ho;
        private System.Windows.Forms.TextBox textBox_ho;
        private System.Windows.Forms.Label label_ten;
        private System.Windows.Forms.TextBox textBox_ten;
        private System.Windows.Forms.Label label_ns;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ns;
        private System.Windows.Forms.Label label_gt;
        private System.Windows.Forms.RadioButton radioButton_nam;
        private System.Windows.Forms.RadioButton radioButton_nu;
        private System.Windows.Forms.Label label_dienThoai;
        private System.Windows.Forms.TextBox textBox_dienThoai;
        private System.Windows.Forms.Label label_diaChi;
        private System.Windows.Forms.TextBox textBox_diaChi;
        private System.Windows.Forms.Label label_lop;
        private System.Windows.Forms.ComboBox comboBox_lop;
        private System.Windows.Forms.Label label_anh;
        private System.Windows.Forms.PictureBox pictureBox_anh;
        private System.Windows.Forms.Button button_chonAnh;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_lamMoi;
        private System.Windows.Forms.TextBox textBox_timKiem;
        private System.Windows.Forms.Button button_timKiem;
        private System.Windows.Forms.DataGridView DataGridView_hocSinh;
    }
}
