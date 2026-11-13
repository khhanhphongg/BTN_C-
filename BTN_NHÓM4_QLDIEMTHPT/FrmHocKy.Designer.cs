namespace QLDiemTHPT
{
    partial class FrmHocKy
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
            this.label_maHK = new System.Windows.Forms.Label();
            this.textBox_maHK = new System.Windows.Forms.TextBox();
            this.label_tenHK = new System.Windows.Forms.Label();
            this.textBox_tenHK = new System.Windows.Forms.TextBox();
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
            this.DataGridView_hocKy = new System.Windows.Forms.DataGridView();
            this.panel_tieude.SuspendLayout();
            this.panel_nhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_hocKy)).BeginInit();
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
            this.label_tieude.Text = "QUẢN LÝ HỌC KỲ";
            // 
            // panel_nhap
            // 
            this.panel_nhap.BackColor = System.Drawing.Color.White;
            this.panel_nhap.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_nhap.Location = new System.Drawing.Point(0, 55);
            this.panel_nhap.Name = "panel_nhap";
            this.panel_nhap.Size = new System.Drawing.Size(460, 558);
            this.panel_nhap.TabIndex = 1;
            this.panel_nhap.Controls.Add(this.label_maHK);
            this.panel_nhap.Controls.Add(this.textBox_maHK);
            this.panel_nhap.Controls.Add(this.label_tenHK);
            this.panel_nhap.Controls.Add(this.textBox_tenHK);
            this.panel_nhap.Controls.Add(this.label_batDau);
            this.panel_nhap.Controls.Add(this.dateTimePicker_batDau);
            this.panel_nhap.Controls.Add(this.label_ketThuc);
            this.panel_nhap.Controls.Add(this.dateTimePicker_ketThuc);
            this.panel_nhap.Controls.Add(this.button_them);
            this.panel_nhap.Controls.Add(this.button_sua);
            this.panel_nhap.Controls.Add(this.button_xoa);
            this.panel_nhap.Controls.Add(this.button_lamMoi);
            // 
            // label_maHK
            // 
            this.label_maHK.AutoSize = true;
            this.label_maHK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_maHK.Location = new System.Drawing.Point(15, 16);
            this.label_maHK.Name = "label_maHK";
            this.label_maHK.Size = new System.Drawing.Size(150, 21);
            this.label_maHK.TabIndex = 0;
            this.label_maHK.Text = "Mã học kỳ :";
            // 
            // textBox_maHK
            // 
            this.textBox_maHK.Location = new System.Drawing.Point(185, 12);
            this.textBox_maHK.Name = "textBox_maHK";
            this.textBox_maHK.Size = new System.Drawing.Size(255, 27);
            this.textBox_maHK.TabIndex = 1;
            this.textBox_maHK.ReadOnly = true;
            this.textBox_maHK.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // label_tenHK
            // 
            this.label_tenHK.AutoSize = true;
            this.label_tenHK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_tenHK.Location = new System.Drawing.Point(15, 56);
            this.label_tenHK.Name = "label_tenHK";
            this.label_tenHK.Size = new System.Drawing.Size(150, 21);
            this.label_tenHK.TabIndex = 0;
            this.label_tenHK.Text = "Tên học kỳ :";
            // 
            // textBox_tenHK
            // 
            this.textBox_tenHK.Location = new System.Drawing.Point(185, 52);
            this.textBox_tenHK.Name = "textBox_tenHK";
            this.textBox_tenHK.Size = new System.Drawing.Size(255, 27);
            this.textBox_tenHK.TabIndex = 2;
            // 
            // label_batDau
            // 
            this.label_batDau.AutoSize = true;
            this.label_batDau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_batDau.Location = new System.Drawing.Point(15, 96);
            this.label_batDau.Name = "label_batDau";
            this.label_batDau.Size = new System.Drawing.Size(150, 21);
            this.label_batDau.TabIndex = 0;
            this.label_batDau.Text = "Ngày bắt đầu :";
            // 
            // dateTimePicker_batDau
            // 
            this.dateTimePicker_batDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_batDau.Location = new System.Drawing.Point(185, 92);
            this.dateTimePicker_batDau.Name = "dateTimePicker_batDau";
            this.dateTimePicker_batDau.Size = new System.Drawing.Size(255, 27);
            this.dateTimePicker_batDau.TabIndex = 3;
            // 
            // label_ketThuc
            // 
            this.label_ketThuc.AutoSize = true;
            this.label_ketThuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_ketThuc.Location = new System.Drawing.Point(15, 136);
            this.label_ketThuc.Name = "label_ketThuc";
            this.label_ketThuc.Size = new System.Drawing.Size(150, 21);
            this.label_ketThuc.TabIndex = 0;
            this.label_ketThuc.Text = "Ngày kết thúc :";
            // 
            // dateTimePicker_ketThuc
            // 
            this.dateTimePicker_ketThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_ketThuc.Location = new System.Drawing.Point(185, 132);
            this.dateTimePicker_ketThuc.Name = "dateTimePicker_ketThuc";
            this.dateTimePicker_ketThuc.Size = new System.Drawing.Size(255, 27);
            this.dateTimePicker_ketThuc.TabIndex = 4;
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
            this.button_sua.Location = new System.Drawing.Point(123, 180);
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
            this.button_xoa.Location = new System.Drawing.Point(231, 180);
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
            this.button_lamMoi.Location = new System.Drawing.Point(339, 180);
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
            // DataGridView_hocKy
            // 
            this.DataGridView_hocKy.AllowUserToAddRows = false;
            this.DataGridView_hocKy.AllowUserToDeleteRows = false;
            this.DataGridView_hocKy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_hocKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_hocKy.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGridView_hocKy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_hocKy.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_hocKy.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_hocKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_hocKy.GridColor = System.Drawing.Color.White;
            this.DataGridView_hocKy.Location = new System.Drawing.Point(475, 110);
            this.DataGridView_hocKy.MultiSelect = false;
            this.DataGridView_hocKy.Name = "DataGridView_hocKy";
            this.DataGridView_hocKy.ReadOnly = true;
            this.DataGridView_hocKy.RowHeadersVisible = false;
            this.DataGridView_hocKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_hocKy.Size = new System.Drawing.Size(442, 480);
            this.DataGridView_hocKy.TabIndex = 42;
            this.DataGridView_hocKy.Click += new System.EventHandler(this.DataGridView_hocKy_Click);
            // 
            // FrmHocKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 613);
            this.Controls.Add(this.DataGridView_hocKy);
            this.Controls.Add(this.button_timKiem);
            this.Controls.Add(this.textBox_timKiem);
            this.Controls.Add(this.panel_nhap);
            this.Controls.Add(this.panel_tieude);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmHocKy";
            this.Text = "FrmHocKy";
            this.Load += new System.EventHandler(this.FrmHocKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_hocKy)).EndInit();
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
        private System.Windows.Forms.Label label_maHK;
        private System.Windows.Forms.TextBox textBox_maHK;
        private System.Windows.Forms.Label label_tenHK;
        private System.Windows.Forms.TextBox textBox_tenHK;
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
        private System.Windows.Forms.DataGridView DataGridView_hocKy;
    }
}
