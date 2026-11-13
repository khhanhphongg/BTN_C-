namespace QLDiemTHPT
{
    partial class FrmTraCuuThongKe
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
            this.panel_loc = new System.Windows.Forms.Panel();
            this.label_lop = new System.Windows.Forms.Label();
            this.comboBox_lop = new System.Windows.Forms.ComboBox();
            this.label_mon = new System.Windows.Forms.Label();
            this.comboBox_mon = new System.Windows.Forms.ComboBox();
            this.label_hocLuc = new System.Windows.Forms.Label();
            this.comboBox_hocLuc = new System.Windows.Forms.ComboBox();
            this.label_tuDiem = new System.Windows.Forms.Label();
            this.textBox_tuDiem = new System.Windows.Forms.TextBox();
            this.label_denDiem = new System.Windows.Forms.Label();
            this.textBox_denDiem = new System.Windows.Forms.TextBox();
            this.button_traCuu = new System.Windows.Forms.Button();
            this.button_inNhanh = new System.Windows.Forms.Button();
            this.button_baoCao = new System.Windows.Forms.Button();
            this.label_kieu = new System.Windows.Forms.Label();
            this.radioButton_chiTiet = new System.Windows.Forms.RadioButton();
            this.radioButton_theoLop = new System.Windows.Forms.RadioButton();
            this.radioButton_theoMon = new System.Windows.Forms.RadioButton();
            this.radioButton_hocLuc = new System.Windows.Forms.RadioButton();
            this.radioButton_xepHang = new System.Windows.Forms.RadioButton();
            this.panel_tong = new System.Windows.Forms.Panel();
            this.label_soLuot = new System.Windows.Forms.Label();
            this.label_diemTBChung = new System.Windows.Forms.Label();
            this.label_soDong = new System.Windows.Forms.Label();
            this.DataGridView_ketQua = new System.Windows.Forms.DataGridView();
            this.panel_tieude.SuspendLayout();
            this.panel_loc.SuspendLayout();
            this.panel_tong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_ketQua)).BeginInit();
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
            this.label_tieude.Text = "TRA CỨU VÀ THỐNG KÊ TÌNH HÌNH HỌC TẬP";
            // 
            // panel_loc
            // 
            this.panel_loc.BackColor = System.Drawing.Color.White;
            this.panel_loc.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_loc.Location = new System.Drawing.Point(0, 55);
            this.panel_loc.Name = "panel_loc";
            this.panel_loc.Size = new System.Drawing.Size(934, 155);
            this.panel_loc.TabIndex = 1;
            this.panel_loc.Controls.Add(this.label_lop);
            this.panel_loc.Controls.Add(this.comboBox_lop);
            this.panel_loc.Controls.Add(this.label_mon);
            this.panel_loc.Controls.Add(this.comboBox_mon);
            this.panel_loc.Controls.Add(this.label_hocLuc);
            this.panel_loc.Controls.Add(this.comboBox_hocLuc);
            this.panel_loc.Controls.Add(this.label_tuDiem);
            this.panel_loc.Controls.Add(this.textBox_tuDiem);
            this.panel_loc.Controls.Add(this.label_denDiem);
            this.panel_loc.Controls.Add(this.textBox_denDiem);
            this.panel_loc.Controls.Add(this.button_traCuu);
            this.panel_loc.Controls.Add(this.button_inNhanh);
            this.panel_loc.Controls.Add(this.button_baoCao);
            this.panel_loc.Controls.Add(this.label_kieu);
            this.panel_loc.Controls.Add(this.radioButton_chiTiet);
            this.panel_loc.Controls.Add(this.radioButton_theoLop);
            this.panel_loc.Controls.Add(this.radioButton_theoMon);
            this.panel_loc.Controls.Add(this.radioButton_hocLuc);
            this.panel_loc.Controls.Add(this.radioButton_xepHang);
            // 
            // label_lop
            // 
            this.label_lop.AutoSize = true;
            this.label_lop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_lop.Location = new System.Drawing.Point(15, 14);
            this.label_lop.Name = "label_lop";
            this.label_lop.Size = new System.Drawing.Size(150, 21);
            this.label_lop.TabIndex = 0;
            this.label_lop.Text = "Lớp :";
            // 
            // comboBox_lop
            // 
            this.comboBox_lop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_lop.FormattingEnabled = true;
            this.comboBox_lop.Location = new System.Drawing.Point(75, 10);
            this.comboBox_lop.Name = "comboBox_lop";
            this.comboBox_lop.Size = new System.Drawing.Size(200, 29);
            this.comboBox_lop.TabIndex = 1;
            // 
            // label_mon
            // 
            this.label_mon.AutoSize = true;
            this.label_mon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_mon.Location = new System.Drawing.Point(295, 14);
            this.label_mon.Name = "label_mon";
            this.label_mon.Size = new System.Drawing.Size(150, 21);
            this.label_mon.TabIndex = 0;
            this.label_mon.Text = "Môn :";
            // 
            // comboBox_mon
            // 
            this.comboBox_mon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_mon.FormattingEnabled = true;
            this.comboBox_mon.Location = new System.Drawing.Point(360, 10);
            this.comboBox_mon.Name = "comboBox_mon";
            this.comboBox_mon.Size = new System.Drawing.Size(210, 29);
            this.comboBox_mon.TabIndex = 2;
            // 
            // label_hocLuc
            // 
            this.label_hocLuc.AutoSize = true;
            this.label_hocLuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_hocLuc.Location = new System.Drawing.Point(590, 14);
            this.label_hocLuc.Name = "label_hocLuc";
            this.label_hocLuc.Size = new System.Drawing.Size(150, 21);
            this.label_hocLuc.TabIndex = 0;
            this.label_hocLuc.Text = "Học lực :";
            // 
            // comboBox_hocLuc
            // 
            this.comboBox_hocLuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_hocLuc.FormattingEnabled = true;
            this.comboBox_hocLuc.Location = new System.Drawing.Point(690, 10);
            this.comboBox_hocLuc.Name = "comboBox_hocLuc";
            this.comboBox_hocLuc.Size = new System.Drawing.Size(200, 29);
            this.comboBox_hocLuc.TabIndex = 3;
            // 
            // label_tuDiem
            // 
            this.label_tuDiem.AutoSize = true;
            this.label_tuDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_tuDiem.Location = new System.Drawing.Point(15, 57);
            this.label_tuDiem.Name = "label_tuDiem";
            this.label_tuDiem.Size = new System.Drawing.Size(150, 21);
            this.label_tuDiem.TabIndex = 0;
            this.label_tuDiem.Text = "Điểm từ :";
            // 
            // textBox_tuDiem
            // 
            this.textBox_tuDiem.Location = new System.Drawing.Point(110, 53);
            this.textBox_tuDiem.Name = "textBox_tuDiem";
            this.textBox_tuDiem.Size = new System.Drawing.Size(60, 27);
            this.textBox_tuDiem.TabIndex = 4;
            this.textBox_tuDiem.Text = "0";
            // 
            // label_denDiem
            // 
            this.label_denDiem.AutoSize = true;
            this.label_denDiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_denDiem.Location = new System.Drawing.Point(185, 57);
            this.label_denDiem.Name = "label_denDiem";
            this.label_denDiem.Size = new System.Drawing.Size(150, 21);
            this.label_denDiem.TabIndex = 0;
            this.label_denDiem.Text = "đến :";
            // 
            // textBox_denDiem
            // 
            this.textBox_denDiem.Location = new System.Drawing.Point(245, 53);
            this.textBox_denDiem.Name = "textBox_denDiem";
            this.textBox_denDiem.Size = new System.Drawing.Size(60, 27);
            this.textBox_denDiem.TabIndex = 5;
            this.textBox_denDiem.Text = "10";
            // 
            // button_traCuu
            // 
            this.button_traCuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_traCuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_traCuu.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_traCuu.ForeColor = System.Drawing.Color.White;
            this.button_traCuu.Location = new System.Drawing.Point(330, 50);
            this.button_traCuu.Name = "button_traCuu";
            this.button_traCuu.Size = new System.Drawing.Size(120, 34);
            this.button_traCuu.TabIndex = 30;
            this.button_traCuu.Text = "Tra cứu";
            this.button_traCuu.UseVisualStyleBackColor = false;
            this.button_traCuu.Click += new System.EventHandler(this.button_traCuu_Click);
            // 
            // button_inNhanh
            // 
            this.button_inNhanh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_inNhanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_inNhanh.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_inNhanh.ForeColor = System.Drawing.Color.White;
            this.button_inNhanh.Location = new System.Drawing.Point(460, 50);
            this.button_inNhanh.Name = "button_inNhanh";
            this.button_inNhanh.Size = new System.Drawing.Size(170, 34);
            this.button_inNhanh.TabIndex = 30;
            this.button_inNhanh.Text = "In nhanh lưới";
            this.button_inNhanh.UseVisualStyleBackColor = false;
            this.button_inNhanh.Click += new System.EventHandler(this.button_inNhanh_Click);
            // 
            // button_baoCao
            // 
            this.button_baoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_baoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_baoCao.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_baoCao.ForeColor = System.Drawing.Color.White;
            this.button_baoCao.Location = new System.Drawing.Point(640, 50);
            this.button_baoCao.Name = "button_baoCao";
            this.button_baoCao.Size = new System.Drawing.Size(250, 34);
            this.button_baoCao.TabIndex = 30;
            this.button_baoCao.Text = "Báo cáo Crystal Report";
            this.button_baoCao.UseVisualStyleBackColor = false;
            this.button_baoCao.Click += new System.EventHandler(this.button_baoCao_Click);
            // 
            // label_kieu
            // 
            this.label_kieu.AutoSize = true;
            this.label_kieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_kieu.Location = new System.Drawing.Point(15, 110);
            this.label_kieu.Name = "label_kieu";
            this.label_kieu.Size = new System.Drawing.Size(150, 21);
            this.label_kieu.TabIndex = 0;
            this.label_kieu.Text = "Kiểu xem :";
            // 
            // radioButton_chiTiet
            // 
            this.radioButton_chiTiet.AutoSize = true;
            this.radioButton_chiTiet.Checked = true;
            this.radioButton_chiTiet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.radioButton_chiTiet.Location = new System.Drawing.Point(115, 108);
            this.radioButton_chiTiet.Name = "radioButton_chiTiet";
            this.radioButton_chiTiet.Size = new System.Drawing.Size(150, 25);
            this.radioButton_chiTiet.TabIndex = 10;
            this.radioButton_chiTiet.Text = "Chi tiết bảng điểm";
            this.radioButton_chiTiet.CheckedChanged += new System.EventHandler(this.radioButton_kieu_CheckedChanged);
            this.radioButton_chiTiet.TabStop = true;
            // 
            // radioButton_theoLop
            // 
            this.radioButton_theoLop.AutoSize = true;
            this.radioButton_theoLop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.radioButton_theoLop.Location = new System.Drawing.Point(310, 108);
            this.radioButton_theoLop.Name = "radioButton_theoLop";
            this.radioButton_theoLop.Size = new System.Drawing.Size(150, 25);
            this.radioButton_theoLop.TabIndex = 11;
            this.radioButton_theoLop.Text = "Theo lớp";
            this.radioButton_theoLop.CheckedChanged += new System.EventHandler(this.radioButton_kieu_CheckedChanged);
            // 
            // radioButton_theoMon
            // 
            this.radioButton_theoMon.AutoSize = true;
            this.radioButton_theoMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.radioButton_theoMon.Location = new System.Drawing.Point(430, 108);
            this.radioButton_theoMon.Name = "radioButton_theoMon";
            this.radioButton_theoMon.Size = new System.Drawing.Size(150, 25);
            this.radioButton_theoMon.TabIndex = 12;
            this.radioButton_theoMon.Text = "Theo môn";
            this.radioButton_theoMon.CheckedChanged += new System.EventHandler(this.radioButton_kieu_CheckedChanged);
            // 
            // radioButton_hocLuc
            // 
            this.radioButton_hocLuc.AutoSize = true;
            this.radioButton_hocLuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.radioButton_hocLuc.Location = new System.Drawing.Point(560, 108);
            this.radioButton_hocLuc.Name = "radioButton_hocLuc";
            this.radioButton_hocLuc.Size = new System.Drawing.Size(150, 25);
            this.radioButton_hocLuc.TabIndex = 13;
            this.radioButton_hocLuc.Text = "Phân bố học lực";
            this.radioButton_hocLuc.CheckedChanged += new System.EventHandler(this.radioButton_kieu_CheckedChanged);
            // 
            // radioButton_xepHang
            // 
            this.radioButton_xepHang.AutoSize = true;
            this.radioButton_xepHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.radioButton_xepHang.Location = new System.Drawing.Point(740, 108);
            this.radioButton_xepHang.Name = "radioButton_xepHang";
            this.radioButton_xepHang.Size = new System.Drawing.Size(150, 25);
            this.radioButton_xepHang.TabIndex = 14;
            this.radioButton_xepHang.Text = "Xếp hạng học sinh";
            this.radioButton_xepHang.CheckedChanged += new System.EventHandler(this.radioButton_kieu_CheckedChanged);
            // 
            // panel_tong
            // 
            this.panel_tong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel_tong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_tong.Location = new System.Drawing.Point(0, 568);
            this.panel_tong.Name = "panel_tong";
            this.panel_tong.Size = new System.Drawing.Size(934, 45);
            this.panel_tong.TabIndex = 2;
            this.panel_tong.Controls.Add(this.label_soLuot);
            this.panel_tong.Controls.Add(this.label_diemTBChung);
            this.panel_tong.Controls.Add(this.label_soDong);
            // 
            // label_soLuot
            // 
            this.label_soLuot.AutoSize = true;
            this.label_soLuot.ForeColor = System.Drawing.Color.White;
            this.label_soLuot.Location = new System.Drawing.Point(20, 11);
            this.label_soLuot.Name = "label_soLuot";
            this.label_soLuot.Size = new System.Drawing.Size(250, 21);
            this.label_soLuot.TabIndex = 0;
            this.label_soLuot.Text = "Số lượt điểm : 0";
            // 
            // label_diemTBChung
            // 
            this.label_diemTBChung.AutoSize = true;
            this.label_diemTBChung.ForeColor = System.Drawing.Color.White;
            this.label_diemTBChung.Location = new System.Drawing.Point(320, 11);
            this.label_diemTBChung.Name = "label_diemTBChung";
            this.label_diemTBChung.Size = new System.Drawing.Size(250, 21);
            this.label_diemTBChung.TabIndex = 0;
            this.label_diemTBChung.Text = "Điểm trung bình chung : 0";
            // 
            // label_soDong
            // 
            this.label_soDong.AutoSize = true;
            this.label_soDong.ForeColor = System.Drawing.Color.White;
            this.label_soDong.Location = new System.Drawing.Point(680, 11);
            this.label_soDong.Name = "label_soDong";
            this.label_soDong.Size = new System.Drawing.Size(250, 21);
            this.label_soDong.TabIndex = 0;
            this.label_soDong.Text = "Số dòng kết quả : 0";
            // 
            // DataGridView_ketQua
            // 
            this.DataGridView_ketQua.AllowUserToAddRows = false;
            this.DataGridView_ketQua.AllowUserToDeleteRows = false;
            this.DataGridView_ketQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_ketQua.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.DataGridView_ketQua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_ketQua.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_ketQua.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_ketQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_ketQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView_ketQua.GridColor = System.Drawing.Color.White;
            this.DataGridView_ketQua.Location = new System.Drawing.Point(0, 210);
            this.DataGridView_ketQua.MultiSelect = false;
            this.DataGridView_ketQua.Name = "DataGridView_ketQua";
            this.DataGridView_ketQua.ReadOnly = true;
            this.DataGridView_ketQua.RowHeadersVisible = false;
            this.DataGridView_ketQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_ketQua.Size = new System.Drawing.Size(934, 358);
            this.DataGridView_ketQua.TabIndex = 3;
            // 
            // FrmTraCuuThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(934, 613);
            this.Controls.Add(this.DataGridView_ketQua);
            this.Controls.Add(this.panel_tong);
            this.Controls.Add(this.panel_loc);
            this.Controls.Add(this.panel_tieude);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmTraCuuThongKe";
            this.Text = "FrmTraCuuThongKe";
            this.Load += new System.EventHandler(this.FrmTraCuuThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_ketQua)).EndInit();
            this.panel_tieude.ResumeLayout(false);
            this.panel_tieude.PerformLayout();
            this.panel_loc.ResumeLayout(false);
            this.panel_loc.PerformLayout();
            this.panel_tong.ResumeLayout(false);
            this.panel_tong.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_tieude;
        private System.Windows.Forms.Label label_tieude;
        private System.Windows.Forms.Panel panel_loc;
        private System.Windows.Forms.Label label_lop;
        private System.Windows.Forms.ComboBox comboBox_lop;
        private System.Windows.Forms.Label label_mon;
        private System.Windows.Forms.ComboBox comboBox_mon;
        private System.Windows.Forms.Label label_hocLuc;
        private System.Windows.Forms.ComboBox comboBox_hocLuc;
        private System.Windows.Forms.Label label_tuDiem;
        private System.Windows.Forms.TextBox textBox_tuDiem;
        private System.Windows.Forms.Label label_denDiem;
        private System.Windows.Forms.TextBox textBox_denDiem;
        private System.Windows.Forms.Button button_traCuu;
        private System.Windows.Forms.Button button_inNhanh;
        private System.Windows.Forms.Button button_baoCao;
        private System.Windows.Forms.Label label_kieu;
        private System.Windows.Forms.RadioButton radioButton_chiTiet;
        private System.Windows.Forms.RadioButton radioButton_theoLop;
        private System.Windows.Forms.RadioButton radioButton_theoMon;
        private System.Windows.Forms.RadioButton radioButton_hocLuc;
        private System.Windows.Forms.RadioButton radioButton_xepHang;
        private System.Windows.Forms.Panel panel_tong;
        private System.Windows.Forms.Label label_soLuot;
        private System.Windows.Forms.Label label_diemTBChung;
        private System.Windows.Forms.Label label_soDong;
        private System.Windows.Forms.DataGridView DataGridView_ketQua;
    }
}
