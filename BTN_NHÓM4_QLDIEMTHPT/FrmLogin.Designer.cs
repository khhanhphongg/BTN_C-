namespace QLDiemTHPT
{
    partial class FrmLogin
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
            this.label_dong = new System.Windows.Forms.Label();
            this.label_tenTruong = new System.Windows.Forms.Label();
            this.pictureBox_logoNho = new System.Windows.Forms.PictureBox();
            this.pictureBox_logoLon = new System.Windows.Forms.PictureBox();
            this.label_moiDangNhap = new System.Windows.Forms.Label();
            this.label_tenDangNhap = new System.Windows.Forms.Label();
            this.textBox_tenDangNhap = new System.Windows.Forms.TextBox();
            this.label_matKhau = new System.Windows.Forms.Label();
            this.textBox_matKhau = new System.Windows.Forms.TextBox();
            this.button_dangNhap = new System.Windows.Forms.Button();
            this.label_chanTrang = new System.Windows.Forms.Label();
            this.panel_tieude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logoNho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logoLon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_tieude
            // 
            this.panel_tieude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel_tieude.Controls.Add(this.label_dong);
            this.panel_tieude.Controls.Add(this.label_tenTruong);
            this.panel_tieude.Controls.Add(this.pictureBox_logoNho);
            this.panel_tieude.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_tieude.Location = new System.Drawing.Point(0, 0);
            this.panel_tieude.Name = "panel_tieude";
            this.panel_tieude.Size = new System.Drawing.Size(950, 56);
            this.panel_tieude.TabIndex = 0;
            // 
            // label_dong
            // 
            this.label_dong.AutoSize = true;
            this.label_dong.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dong.ForeColor = System.Drawing.Color.Transparent;
            this.label_dong.Location = new System.Drawing.Point(921, 2);
            this.label_dong.Name = "label_dong";
            this.label_dong.Size = new System.Drawing.Size(26, 25);
            this.label_dong.TabIndex = 1;
            this.label_dong.Text = "X";
            this.label_dong.Click += new System.EventHandler(this.label_dong_Click);
            this.label_dong.MouseEnter += new System.EventHandler(this.label_dong_MouseEnter);
            this.label_dong.MouseLeave += new System.EventHandler(this.label_dong_MouseLeave);
            // 
            // label_tenTruong
            // 
            this.label_tenTruong.AutoSize = true;
            this.label_tenTruong.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tenTruong.ForeColor = System.Drawing.Color.Transparent;
            this.label_tenTruong.Location = new System.Drawing.Point(70, 16);
            this.label_tenTruong.Name = "label_tenTruong";
            this.label_tenTruong.Size = new System.Drawing.Size(298, 25);
            this.label_tenTruong.TabIndex = 1;
            this.label_tenTruong.Text = "TRƯỜNG THPT MDEMY";
            // 
            // pictureBox_logoNho
            // 
            this.pictureBox_logoNho.Image = global::QLDiemTHPT.Properties.Resources.classroom_50whitepx;
            this.pictureBox_logoNho.Location = new System.Drawing.Point(5, 4);
            this.pictureBox_logoNho.Name = "pictureBox_logoNho";
            this.pictureBox_logoNho.Size = new System.Drawing.Size(46, 50);
            this.pictureBox_logoNho.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logoNho.TabIndex = 0;
            this.pictureBox_logoNho.TabStop = false;
            // 
            // pictureBox_logoLon
            // 
            this.pictureBox_logoLon.Image = global::QLDiemTHPT.Properties.Resources.classroomblue_50px;
            this.pictureBox_logoLon.Location = new System.Drawing.Point(418, 142);
            this.pictureBox_logoLon.Name = "pictureBox_logoLon";
            this.pictureBox_logoLon.Size = new System.Drawing.Size(115, 103);
            this.pictureBox_logoLon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_logoLon.TabIndex = 1;
            this.pictureBox_logoLon.TabStop = false;
            // 
            // label_moiDangNhap
            // 
            this.label_moiDangNhap.AutoSize = true;
            this.label_moiDangNhap.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_moiDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_moiDangNhap.Location = new System.Drawing.Point(300, 262);
            this.label_moiDangNhap.Name = "label_moiDangNhap";
            this.label_moiDangNhap.Size = new System.Drawing.Size(360, 23);
            this.label_moiDangNhap.TabIndex = 1;
            this.label_moiDangNhap.Text = "HỆ THỐNG QUẢN LÝ ĐIỂM HỌC SINH";
            // 
            // label_tenDangNhap
            // 
            this.label_tenDangNhap.AutoSize = true;
            this.label_tenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_tenDangNhap.Location = new System.Drawing.Point(309, 318);
            this.label_tenDangNhap.Name = "label_tenDangNhap";
            this.label_tenDangNhap.Size = new System.Drawing.Size(140, 21);
            this.label_tenDangNhap.TabIndex = 1;
            this.label_tenDangNhap.Text = "Tên đăng nhập :";
            // 
            // textBox_tenDangNhap
            // 
            this.textBox_tenDangNhap.Location = new System.Drawing.Point(313, 342);
            this.textBox_tenDangNhap.Name = "textBox_tenDangNhap";
            this.textBox_tenDangNhap.Size = new System.Drawing.Size(325, 27);
            this.textBox_tenDangNhap.TabIndex = 1;
            // 
            // label_matKhau
            // 
            this.label_matKhau.AutoSize = true;
            this.label_matKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_matKhau.Location = new System.Drawing.Point(309, 384);
            this.label_matKhau.Name = "label_matKhau";
            this.label_matKhau.Size = new System.Drawing.Size(90, 21);
            this.label_matKhau.TabIndex = 1;
            this.label_matKhau.Text = "Mật khẩu :";
            // 
            // textBox_matKhau
            // 
            this.textBox_matKhau.Location = new System.Drawing.Point(313, 408);
            this.textBox_matKhau.Name = "textBox_matKhau";
            this.textBox_matKhau.Size = new System.Drawing.Size(325, 27);
            this.textBox_matKhau.TabIndex = 2;
            this.textBox_matKhau.UseSystemPasswordChar = true;
            this.textBox_matKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_matKhau_KeyDown);
            // 
            // button_dangNhap
            // 
            this.button_dangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.button_dangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dangNhap.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_dangNhap.ForeColor = System.Drawing.Color.White;
            this.button_dangNhap.Location = new System.Drawing.Point(313, 465);
            this.button_dangNhap.Name = "button_dangNhap";
            this.button_dangNhap.Size = new System.Drawing.Size(325, 41);
            this.button_dangNhap.TabIndex = 3;
            this.button_dangNhap.Text = "Đăng nhập";
            this.button_dangNhap.UseVisualStyleBackColor = false;
            this.button_dangNhap.Click += new System.EventHandler(this.button_dangNhap_Click);
            // 
            // label_chanTrang
            // 
            this.label_chanTrang.AutoSize = true;
            this.label_chanTrang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label_chanTrang.Location = new System.Drawing.Point(520, 618);
            this.label_chanTrang.Name = "label_chanTrang";
            this.label_chanTrang.Size = new System.Drawing.Size(430, 21);
            this.label_chanTrang.TabIndex = 1;
            this.label_chanTrang.Text = "Bài tập nhóm - Nhóm 4 - Môn Lập trình .NET";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.button_dangNhap);
            this.Controls.Add(this.textBox_tenDangNhap);
            this.Controls.Add(this.textBox_matKhau);
            this.Controls.Add(this.label_matKhau);
            this.Controls.Add(this.label_tenDangNhap);
            this.Controls.Add(this.label_chanTrang);
            this.Controls.Add(this.label_moiDangNhap);
            this.Controls.Add(this.pictureBox_logoLon);
            this.Controls.Add(this.panel_tieude);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.panel_tieude.ResumeLayout(false);
            this.panel_tieude.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logoNho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logoLon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_tieude;
        private System.Windows.Forms.Label label_dong;
        private System.Windows.Forms.Label label_tenTruong;
        private System.Windows.Forms.PictureBox pictureBox_logoNho;
        private System.Windows.Forms.PictureBox pictureBox_logoLon;
        private System.Windows.Forms.Label label_moiDangNhap;
        private System.Windows.Forms.Label label_tenDangNhap;
        private System.Windows.Forms.TextBox textBox_tenDangNhap;
        private System.Windows.Forms.Label label_matKhau;
        private System.Windows.Forms.TextBox textBox_matKhau;
        private System.Windows.Forms.Button button_dangNhap;
        private System.Windows.Forms.Label label_chanTrang;
    }
}
