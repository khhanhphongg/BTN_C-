namespace QLDiemTHPT
{
    partial class FrmMonHoc
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
            this.label_maMon = new System.Windows.Forms.Label();
            this.textBox_maMon = new System.Windows.Forms.TextBox();
            this.label_tenMon = new System.Windows.Forms.Label();
            this.textBox_tenMon = new System.Windows.Forms.TextBox();
            this.label_soTiet = new System.Windows.Forms.Label();
            this.textBox_soTiet = new System.Windows.Forms.TextBox();
            this.label_moTa = new System.Windows.Forms.Label();
            this.textBox_moTa = new System.Windows.Forms.TextBox();
            this.button_them = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_lamMoi = new System.Windows.Forms.Button();
            this.textBox_timKiem = new System.Windows.Forms.TextBox();
            this.button_timKiem = new System.Windows.Forms.Button();
            this.DataGridView_monHoc = new System.Windows.Forms.DataGridView();
            this.panel_tieude.SuspendLayout();
            this.panel_nhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_monHoc)).BeginInit();
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
            this.label_tieude.Text = "QUẢN LÝ DANH MỤC MÔN HỌC";
            // 
            // panel_nhap
            // 
            this.panel_nhap.BackColor = System.Drawing.Color.White;
            this.panel_nhap.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_nhap.Location = new System.Drawing.Point(0, 55);
            this.panel_nhap.Name = "panel_nhap";
            this.panel_nhap.Size = new System.Drawing.Size(460, 558);
            this.panel_nhap.TabIndex = 1;
            this.panel_nhap.Controls.Add(this.label_maMon);
            this.panel_nhap.Controls.Add(this.textBox_maMon);
            this.panel_nhap.Controls.Add(this.label_tenMon);
            this.panel_nhap.Controls.Add(this.textBox_tenMon);
            this.panel_nhap.Controls.Add(this.label_soTiet);
            this.panel_nhap.Controls.Add(this.textBox_soTiet);
            this.panel_nhap.Controls.Add(this.label_moTa);
            this.panel_nhap.Controls.Add(this.textBox_moTa);
            this.panel_nhap.Controls.Add(this.button_them);
            this.panel_nhap.Controls.Add(this.button_sua);
            this.panel_nhap.Controls.Add(this.button_xoa);
            this.panel_nhap.Controls.Add(this.button_lamMoi);
            // 
            // label_maMon
            // 
            this.label_maMon.AutoSize = true;
            this.label_maMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_maMon.Location = new System.Drawing.Point(15, 16);
            this.label_maMon.Name = "label_maMon";
            this.label_maMon.Size = new System.Drawing.Size(150, 21);
            this.label_maMon.TabIndex = 0;
            this.label_maMon.Text = "Mã môn :";
            // 
            // textBox_maMon
            // 
            this.textBox_maMon.Location = new System.Drawing.Point(185, 12);
            this.textBox_maMon.Name = "textBox_maMon";
            this.textBox_maMon.Size = new System.Drawing.Size(255, 27);
            this.textBox_maMon.TabIndex = 1;
            this.textBox_maMon.ReadOnly = true;
            this.textBox_maMon.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // label_tenMon
            // 
            this.label_tenMon.AutoSize = true;
            this.label_tenMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_tenMon.Location = new System.Drawing.Point(15, 56);
            this.label_tenMon.Name = "label_tenMon";
            this.label_tenMon.Size = new System.Drawing.Size(150, 21);
            this.label_tenMon.TabIndex = 0;
            this.label_tenMon.Text = "Tên môn học :";
            // 
            // textBox_tenMon
            // 
            this.textBox_tenMon.Location = new System.Drawing.Point(185, 52);
            this.textBox_tenMon.Name = "textBox_tenMon";
            this.textBox_tenMon.Size = new System.Drawing.Size(255, 27);
            this.textBox_tenMon.TabIndex = 2;
            // 
            // label_soTiet
            // 
            this.label_soTiet.AutoSize = true;
            this.label_soTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_soTiet.Location = new System.Drawing.Point(15, 96);
            this.label_soTiet.Name = "label_soTiet";
            this.label_soTiet.Size = new System.Drawing.Size(150, 21);
            this.label_soTiet.TabIndex = 0;
            this.label_soTiet.Text = "Số tiết :";
            // 
            // textBox_soTiet
            // 
            this.textBox_soTiet.Location = new System.Drawing.Point(185, 92);
            this.textBox_soTiet.Name = "textBox_soTiet";
            this.textBox_soTiet.Size = new System.Drawing.Size(255, 27);
            this.textBox_soTiet.TabIndex = 3;
            // 
            // label_moTa
            // 
            this.label_moTa.AutoSize = true;
            this.label_moTa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_moTa.Location = new System.Drawing.Point(15, 136);
            this.label_moTa.Name = "label_moTa";
            this.label_moTa.Size = new System.Drawing.Size(150, 21);
            this.label_moTa.TabIndex = 0;
            this.label_moTa.Text = "Mô tả :";
            // 
            // textBox_moTa
            // 
            this.textBox_moTa.Location = new System.Drawing.Point(185, 132);
            this.textBox_moTa.Multiline = true;
            this.textBox_moTa.Name = "textBox_moTa";
            this.textBox_moTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_moTa.Size = new System.Drawing.Size(255, 55);
            this.textBox_moTa.TabIndex = 4;
            // 
            // button_them
            // 
            this.button_them.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_them.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_them.ForeColor = System.Drawing.Color.White;
            this.button_them.Location = new System.Drawing.Point(15, 208);
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
            this.button_sua.Location = new System.Drawing.Point(123, 208);
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
            this.button_xoa.Location = new System.Drawing.Point(231, 208);
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
            this.button_lamMoi.Location = new System.Drawing.Point(339, 208);
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
            // DataGridView_monHoc
            // 
            this.DataGridView_monHoc.AllowUserToAddRows = false;
            this.DataGridView_monHoc.AllowUserToDeleteRows = false;
            this.DataGridView_monHoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_monHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_monHoc.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGridView_monHoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_monHoc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_monHoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_monHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_monHoc.GridColor = System.Drawing.Color.White;
            this.DataGridView_monHoc.Location = new System.Drawing.Point(475, 110);
            this.DataGridView_monHoc.MultiSelect = false;
            this.DataGridView_monHoc.Name = "DataGridView_monHoc";
            this.DataGridView_monHoc.ReadOnly = true;
            this.DataGridView_monHoc.RowHeadersVisible = false;
            this.DataGridView_monHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_monHoc.Size = new System.Drawing.Size(442, 480);
            this.DataGridView_monHoc.TabIndex = 42;
            this.DataGridView_monHoc.Click += new System.EventHandler(this.DataGridView_monHoc_Click);
            // 
            // FrmMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 613);
            this.Controls.Add(this.DataGridView_monHoc);
            this.Controls.Add(this.button_timKiem);
            this.Controls.Add(this.textBox_timKiem);
            this.Controls.Add(this.panel_nhap);
            this.Controls.Add(this.panel_tieude);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmMonHoc";
            this.Text = "FrmMonHoc";
            this.Load += new System.EventHandler(this.FrmMonHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_monHoc)).EndInit();
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
        private System.Windows.Forms.Label label_maMon;
        private System.Windows.Forms.TextBox textBox_maMon;
        private System.Windows.Forms.Label label_tenMon;
        private System.Windows.Forms.TextBox textBox_tenMon;
        private System.Windows.Forms.Label label_soTiet;
        private System.Windows.Forms.TextBox textBox_soTiet;
        private System.Windows.Forms.Label label_moTa;
        private System.Windows.Forms.TextBox textBox_moTa;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_lamMoi;
        private System.Windows.Forms.TextBox textBox_timKiem;
        private System.Windows.Forms.Button button_timKiem;
        private System.Windows.Forms.DataGridView DataGridView_monHoc;
    }
}
