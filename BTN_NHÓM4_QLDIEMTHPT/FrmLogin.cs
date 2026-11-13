using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    public partial class FrmLogin : Form
    {
        LoginClass login = new LoginClass();
        public FrmLogin()
        {
            InitializeComponent();
        }

        //nhãn X ở góc phải để thoát chương trình
        private void label_dong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_dong_MouseEnter(object sender, EventArgs e)
        {
            label_dong.ForeColor = Color.Red;
        }

        private void label_dong_MouseLeave(object sender, EventArgs e)
        {
            label_dong.ForeColor = Color.Transparent;
        }

        //bấm Enter ở ô mật khẩu thì đăng nhập luôn
        private void textBox_matKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_dangNhap.PerformClick();
        }

        private void button_dangNhap_Click(object sender, EventArgs e)
        {
            if (textBox_tenDangNhap.Text == "" || textBox_matKhau.Text == "")
            {
                MessageBox.Show("Phải nhập tên đăng nhập và mật khẩu", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRow nguoiDung;
            try
            {
                nguoiDung = login.kiemTraDangNhap(textBox_tenDangNhap.Text, textBox_matKhau.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được cơ sở dữ liệu studentdb." + Environment.NewLine + Environment.NewLine + ex.Message,
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nguoiDung != null)
            {
                //truyền họ tên và vai trò sang form chính để hiện lên dải người dùng
                FrmMain main = new FrmMain(nguoiDung["HoTen"].ToString(), nguoiDung["VaiTro"].ToString());
                this.Hide();
                main.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_matKhau.Clear();
                textBox_matKhau.Focus();
            }
        }
    }
}
