namespace QLDiemTHPT
{
    partial class FrmBangDiem
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
            this.label_hocSinh = new System.Windows.Forms.Label();
            this.comboBox_hocSinh = new System.Windows.Forms.ComboBox();
            this.label_monHoc = new System.Windows.Forms.Label();
            this.comboBox_monHoc = new System.Windows.Forms.ComboBox();
            this.label_diemTB = new System.Windows.Forms.Label();
            this.textBox_diemTB = new System.Windows.Forms.TextBox();
            this.label_hocLuc = new System.Windows.Forms.Label();
            this.textBox_hocLuc = new System.Windows.Forms.TextBox();
            this.button_them = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_lamMoi = new System.Windows.Forms.Button();
            this.textBox_timKiem = new System.Windows.Forms.TextBox();
            this.button_timKiem = new System.Windows.Forms.Button();
            this.DataGridView_bangDiem = new System.Windows.Forms.DataGridView();
            this.panel_tieude.SuspendLayout();
            this.panel_nhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_bangDiem)).BeginInit();
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
            this.label_tieude.Text = "QUẢN LÝ BẢNG ĐIỂM";
            // 
            // panel_nhap
            // 
            this.panel_nhap.BackColor = System.Drawing.Color.White;
            this.panel_nhap.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_nhap.Location = new System.Drawing.Point(0, 55);
            this.panel_nhap.Name = "panel_nhap";
            this.panel_nhap.Size = new System.Drawing.Size(460, 558);
            this.panel_nhap.TabIndex = 1;
            this.panel_nhap.Controls.Add(this.label_hocSinh);
            this.panel_nhap.Controls.Add(this.comboBox_hocSinh);
            this.panel_nhap.Controls.Add(this.label_monHoc);
            this.panel_nhap.Controls.Add(this.comboBox_monHoc);
            this.panel_nhap.Controls.Add(this.label_diemTB);
            this.panel_nhap.Controls.Add(this.textBox_diemTB);
            this.panel_nhap.Controls.Add(this.label_hocLuc);
            this.panel_nhap.Controls.Add(this.textBox_hocLuc);
            this.panel_nhap.Controls.Add(this.button_them);
            this.panel_nhap.Controls.Add(this.button_xoa);
            this.panel_nhap.Controls.Add(this.button_lamMoi);
            // 
            // label_hocSinh
            // 
            this.label_hocSinh.AutoSize = true;
            this.label_hocSinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_hocSinh.Location = new System.Drawing.Point(15, 16);
            this.label_hocSinh.Name = "label_hocSinh";
            this.label_hocSinh.Size = new System.Drawing.Size(150, 21);
            this.label_hocSinh.TabIndex = 0;
            this.label_hocSinh.Text = "Học sinh :";
            // 
            // comboBox_hocSinh
            // 
            this.comboBox_hocSinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_hocSinh.FormattingEnabled = true;
            this.comboBox_hocSinh.Location = new System.Drawing.Point(185, 12);
            this.comboBox_hocSinh.Name = "comboBox_hocSinh";
            this.comboBox_hocSinh.Size = new System.Drawing.Size(255, 29);
            this.comboBox_hocSinh.TabIndex = 1;
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
            // label_diemTB
            // 
            this.label_diemTB.AutoSize = true;
            this.label_diemTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_diemTB.Location = new System.Drawing.Point(15, 96);
            this.label_diemTB.Name = "label_diemTB";
            this.label_diemTB.Size = new System.Drawing.Size(150, 21);
            this.label_diemTB.TabIndex = 0;
            this.label_diemTB.Text = "Điểm TB môn :";
            // 
            // textBox_diemTB
            // 
            this.textBox_diemTB.Location = new System.Drawing.Point(185, 92);
            this.textBox_diemTB.Name = "textBox_diemTB";
            this.textBox_diemTB.Size = new System.Drawing.Size(255, 27);
            this.textBox_diemTB.TabIndex = 3;
            this.textBox_diemTB.ReadOnly = true;
            this.textBox_diemTB.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // label_hocLuc
            // 
            this.label_hocLuc.AutoSize = true;
            this.label_hocLuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_hocLuc.Location = new System.Drawing.Point(15, 136);
            this.label_hocLuc.Name = "label_hocLuc";
            this.label_hocLuc.Size = new System.Drawing.Size(150, 21);
            this.label_hocLuc.TabIndex = 0;
            this.label_hocLuc.Text = "Học lực :";
            // 
            // textBox_hocLuc
            // 
            this.textBox_hocLuc.Location = new System.Drawing.Point(185, 132);
            this.textBox_hocLuc.Name = "textBox_hocLuc";
            this.textBox_hocLuc.Size = new System.Drawing.Size(255, 27);
            this.textBox_hocLuc.TabIndex = 4;
            this.textBox_hocLuc.ReadOnly = true;
            this.textBox_hocLuc.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // button_them
            // 
            this.button_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_them.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_them.ForeColor = System.Drawing.Color.White;
            this.button_them.Location = new System.Drawing.Point(15, 180);
            this.button_them.Name = "button_them";
            this.button_them.Size = new System.Drawing.Size(102, 40);
            this.button_them.TabIndex = 30;
            this.button_them.Text = "Mở môn";
            this.button_them.UseVisualStyleBackColor = false;
            this.button_them.Click += new System.EventHandler(this.button_them_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_xoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_xoa.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.ForeColor = System.Drawing.Color.White;
            this.button_xoa.Location = new System.Drawing.Point(123, 180);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(102, 40);
            this.button_xoa.TabIndex = 30;
            this.button_xoa.Text = "Xoá môn";
            this.button_xoa.UseVisualStyleBackColor = false;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_lamMoi
            // 
            this.button_lamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_lamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_lamMoi.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_lamMoi.ForeColor = System.Drawing.Color.White;
            this.button_lamMoi.Location = new System.Drawing.Point(231, 180);
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
            // DataGridView_bangDiem
            // 
            this.DataGridView_bangDiem.AllowUserToAddRows = false;
            this.DataGridView_bangDiem.AllowUserToDeleteRows = false;
            this.DataGridView_bangDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_bangDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_bangDiem.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGridView_bangDiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_bangDiem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_bangDiem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_bangDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_bangDiem.GridColor = System.Drawing.Color.White;
            this.DataGridView_bangDiem.Location = new System.Drawing.Point(475, 110);
            this.DataGridView_bangDiem.MultiSelect = false;
            this.DataGridView_bangDiem.Name = "DataGridView_bangDiem";
            this.DataGridView_bangDiem.ReadOnly = true;
            this.DataGridView_bangDiem.RowHeadersVisible = false;
            this.DataGridView_bangDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_bangDiem.Size = new System.Drawing.Size(442, 480);
            this.DataGridView_bangDiem.TabIndex = 42;
            this.DataGridView_bangDiem.Click += new System.EventHandler(this.DataGridView_bangDiem_Click);
            // 
            // FrmBangDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 613);
            this.Controls.Add(this.DataGridView_bangDiem);
            this.Controls.Add(this.button_timKiem);
            this.Controls.Add(this.textBox_timKiem);
            this.Controls.Add(this.panel_nhap);
            this.Controls.Add(this.panel_tieude);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmBangDiem";
            this.Text = "FrmBangDiem";
            this.Load += new System.EventHandler(this.FrmBangDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_bangDiem)).EndInit();
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
        private System.Windows.Forms.Label label_hocSinh;
        private System.Windows.Forms.ComboBox comboBox_hocSinh;
        private System.Windows.Forms.Label label_monHoc;
        private System.Windows.Forms.ComboBox comboBox_monHoc;
        private System.Windows.Forms.Label label_diemTB;
        private System.Windows.Forms.TextBox textBox_diemTB;
        private System.Windows.Forms.Label label_hocLuc;
        private System.Windows.Forms.TextBox textBox_hocLuc;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_lamMoi;
        private System.Windows.Forms.TextBox textBox_timKiem;
        private System.Windows.Forms.Button button_timKiem;
        private System.Windows.Forms.DataGridView DataGridView_bangDiem;
    }
}
