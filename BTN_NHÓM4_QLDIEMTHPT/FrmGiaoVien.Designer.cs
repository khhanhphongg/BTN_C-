namespace QLDiemTHPT
{
    partial class FrmGiaoVien
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
            this.label_maGV = new System.Windows.Forms.Label();
            this.textBox_maGV = new System.Windows.Forms.TextBox();
            this.label_hoTen = new System.Windows.Forms.Label();
            this.textBox_hoTen = new System.Windows.Forms.TextBox();
            this.label_dienThoai = new System.Windows.Forms.Label();
            this.textBox_dienThoai = new System.Windows.Forms.TextBox();
            this.label_email = new System.Windows.Forms.Label();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.label_khoa = new System.Windows.Forms.Label();
            this.comboBox_khoa = new System.Windows.Forms.ComboBox();
            this.button_them = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_lamMoi = new System.Windows.Forms.Button();
            this.textBox_timKiem = new System.Windows.Forms.TextBox();
            this.button_timKiem = new System.Windows.Forms.Button();
            this.DataGridView_giaoVien = new System.Windows.Forms.DataGridView();
            this.panel_tieude.SuspendLayout();
            this.panel_nhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_giaoVien)).BeginInit();
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
            this.label_tieude.Text = "QUẢN LÝ THÔNG TIN GIÁO VIÊN";
            // 
            // panel_nhap
            // 
            this.panel_nhap.BackColor = System.Drawing.Color.White;
            this.panel_nhap.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_nhap.Location = new System.Drawing.Point(0, 55);
            this.panel_nhap.Name = "panel_nhap";
            this.panel_nhap.Size = new System.Drawing.Size(460, 558);
            this.panel_nhap.TabIndex = 1;
            this.panel_nhap.Controls.Add(this.label_maGV);
            this.panel_nhap.Controls.Add(this.textBox_maGV);
            this.panel_nhap.Controls.Add(this.label_hoTen);
            this.panel_nhap.Controls.Add(this.textBox_hoTen);
            this.panel_nhap.Controls.Add(this.label_dienThoai);
            this.panel_nhap.Controls.Add(this.textBox_dienThoai);
            this.panel_nhap.Controls.Add(this.label_email);
            this.panel_nhap.Controls.Add(this.textBox_email);
            this.panel_nhap.Controls.Add(this.label_khoa);
            this.panel_nhap.Controls.Add(this.comboBox_khoa);
            this.panel_nhap.Controls.Add(this.button_them);
            this.panel_nhap.Controls.Add(this.button_sua);
            this.panel_nhap.Controls.Add(this.button_xoa);
            this.panel_nhap.Controls.Add(this.button_lamMoi);
            // 
            // label_maGV
            // 
            this.label_maGV.AutoSize = true;
            this.label_maGV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_maGV.Location = new System.Drawing.Point(15, 16);
            this.label_maGV.Name = "label_maGV";
            this.label_maGV.Size = new System.Drawing.Size(150, 21);
            this.label_maGV.TabIndex = 0;
            this.label_maGV.Text = "Mã giáo viên :";
            // 
            // textBox_maGV
            // 
            this.textBox_maGV.Location = new System.Drawing.Point(185, 12);
            this.textBox_maGV.Name = "textBox_maGV";
            this.textBox_maGV.Size = new System.Drawing.Size(255, 27);
            this.textBox_maGV.TabIndex = 1;
            this.textBox_maGV.ReadOnly = true;
            this.textBox_maGV.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // label_hoTen
            // 
            this.label_hoTen.AutoSize = true;
            this.label_hoTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_hoTen.Location = new System.Drawing.Point(15, 56);
            this.label_hoTen.Name = "label_hoTen";
            this.label_hoTen.Size = new System.Drawing.Size(150, 21);
            this.label_hoTen.TabIndex = 0;
            this.label_hoTen.Text = "Họ và tên :";
            // 
            // textBox_hoTen
            // 
            this.textBox_hoTen.Location = new System.Drawing.Point(185, 52);
            this.textBox_hoTen.Name = "textBox_hoTen";
            this.textBox_hoTen.Size = new System.Drawing.Size(255, 27);
            this.textBox_hoTen.TabIndex = 2;
            // 
            // label_dienThoai
            // 
            this.label_dienThoai.AutoSize = true;
            this.label_dienThoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_dienThoai.Location = new System.Drawing.Point(15, 96);
            this.label_dienThoai.Name = "label_dienThoai";
            this.label_dienThoai.Size = new System.Drawing.Size(150, 21);
            this.label_dienThoai.TabIndex = 0;
            this.label_dienThoai.Text = "Điện thoại :";
            // 
            // textBox_dienThoai
            // 
            this.textBox_dienThoai.Location = new System.Drawing.Point(185, 92);
            this.textBox_dienThoai.Name = "textBox_dienThoai";
            this.textBox_dienThoai.Size = new System.Drawing.Size(255, 27);
            this.textBox_dienThoai.TabIndex = 3;
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_email.Location = new System.Drawing.Point(15, 136);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(150, 21);
            this.label_email.TabIndex = 0;
            this.label_email.Text = "Email :";
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(185, 132);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(255, 27);
            this.textBox_email.TabIndex = 4;
            // 
            // label_khoa
            // 
            this.label_khoa.AutoSize = true;
            this.label_khoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_khoa.Location = new System.Drawing.Point(15, 176);
            this.label_khoa.Name = "label_khoa";
            this.label_khoa.Size = new System.Drawing.Size(150, 21);
            this.label_khoa.TabIndex = 0;
            this.label_khoa.Text = "Khoa :";
            // 
            // comboBox_khoa
            // 
            this.comboBox_khoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_khoa.FormattingEnabled = true;
            this.comboBox_khoa.Location = new System.Drawing.Point(185, 172);
            this.comboBox_khoa.Name = "comboBox_khoa";
            this.comboBox_khoa.Size = new System.Drawing.Size(255, 29);
            this.comboBox_khoa.TabIndex = 5;
            // 
            // button_them
            // 
            this.button_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_them.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_them.ForeColor = System.Drawing.Color.White;
            this.button_them.Location = new System.Drawing.Point(15, 220);
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
            this.button_sua.Location = new System.Drawing.Point(123, 220);
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
            this.button_xoa.Location = new System.Drawing.Point(231, 220);
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
            this.button_lamMoi.Location = new System.Drawing.Point(339, 220);
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
            // DataGridView_giaoVien
            // 
            this.DataGridView_giaoVien.AllowUserToAddRows = false;
            this.DataGridView_giaoVien.AllowUserToDeleteRows = false;
            this.DataGridView_giaoVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_giaoVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_giaoVien.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGridView_giaoVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_giaoVien.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_giaoVien.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_giaoVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_giaoVien.GridColor = System.Drawing.Color.White;
            this.DataGridView_giaoVien.Location = new System.Drawing.Point(475, 110);
            this.DataGridView_giaoVien.MultiSelect = false;
            this.DataGridView_giaoVien.Name = "DataGridView_giaoVien";
            this.DataGridView_giaoVien.ReadOnly = true;
            this.DataGridView_giaoVien.RowHeadersVisible = false;
            this.DataGridView_giaoVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_giaoVien.Size = new System.Drawing.Size(442, 480);
            this.DataGridView_giaoVien.TabIndex = 42;
            this.DataGridView_giaoVien.Click += new System.EventHandler(this.DataGridView_giaoVien_Click);
            // 
            // FrmGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 613);
            this.Controls.Add(this.DataGridView_giaoVien);
            this.Controls.Add(this.button_timKiem);
            this.Controls.Add(this.textBox_timKiem);
            this.Controls.Add(this.panel_nhap);
            this.Controls.Add(this.panel_tieude);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmGiaoVien";
            this.Text = "FrmGiaoVien";
            this.Load += new System.EventHandler(this.FrmGiaoVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_giaoVien)).EndInit();
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
        private System.Windows.Forms.Label label_maGV;
        private System.Windows.Forms.TextBox textBox_maGV;
        private System.Windows.Forms.Label label_hoTen;
        private System.Windows.Forms.TextBox textBox_hoTen;
        private System.Windows.Forms.Label label_dienThoai;
        private System.Windows.Forms.TextBox textBox_dienThoai;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.Label label_khoa;
        private System.Windows.Forms.ComboBox comboBox_khoa;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_lamMoi;
        private System.Windows.Forms.TextBox textBox_timKiem;
        private System.Windows.Forms.Button button_timKiem;
        private System.Windows.Forms.DataGridView DataGridView_giaoVien;
    }
}
