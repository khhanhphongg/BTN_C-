using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    public partial class FrmGiaoVien : Form
    {
        GiaoVienClass giaoVien = new GiaoVienClass();
        KhoaClass khoa = new KhoaClass();
        public FrmGiaoVien()
        {
            InitializeComponent();
        }

        private void FrmGiaoVien_Load(object sender, EventArgs e)
        {
            comboBox_khoa.DataSource = khoa.getAll();
            comboBox_khoa.DisplayMember = "DeptName";
            comboBox_khoa.ValueMember = "DeptId";
            hienBang();
        }

        private void hienBang()
        {
            DataGridView_giaoVien.DataSource = giaoVien.getAll();
            datTieuDeCot();
        }

        private void datTieuDeCot()
        {
            if (DataGridView_giaoVien.Columns.Count < 6)
                return;
            DataGridView_giaoVien.Columns["TeacherId"].HeaderText = "Mã GV";
            DataGridView_giaoVien.Columns["TeacherName"].HeaderText = "Họ và tên";
            DataGridView_giaoVien.Columns["Phone"].HeaderText = "Điện thoại";
            DataGridView_giaoVien.Columns["Email"].HeaderText = "Email";
            DataGridView_giaoVien.Columns["DeptName"].HeaderText = "Khoa";
            DataGridView_giaoVien.Columns["DeptId"].Visible = false;
        }

        //kiểm tra dữ liệu, email phải có dấu @
        private bool kiemTra()
        {
            if (textBox_hoTen.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập họ tên giáo viên", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBox_email.Text.Trim() != "" && !textBox_email.Text.Contains("@"))
            {
                MessageBox.Show("Email không đúng định dạng", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBox_khoa.SelectedValue == null)
            {
                MessageBox.Show("Phải chọn khoa", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (!kiemTra())
                return;
            if (giaoVien.insertGiaoVien(textBox_hoTen.Text.Trim(), textBox_dienThoai.Text.Trim(),
                textBox_email.Text.Trim(), Convert.ToInt32(comboBox_khoa.SelectedValue)))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã thêm giáo viên mới", "Thêm giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thêm được giáo viên", "Thêm giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maGV;
            if (!int.TryParse(textBox_maGV.Text, out maGV))
            {
                MessageBox.Show("Hãy chọn một giáo viên trong bảng trước", "Sửa giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kiemTra())
                return;
            if (giaoVien.updateGiaoVien(maGV, textBox_hoTen.Text.Trim(), textBox_dienThoai.Text.Trim(),
                textBox_email.Text.Trim(), Convert.ToInt32(comboBox_khoa.SelectedValue)))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã sửa thông tin giáo viên", "Sửa giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được thông tin giáo viên", "Sửa giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maGV;
            if (!int.TryParse(textBox_maGV.Text, out maGV))
            {
                MessageBox.Show("Hãy chọn một giáo viên trong bảng trước", "Xoá giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá giáo viên này?", "Xoá giáo viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (giaoVien.deleteGiaoVien(maGV))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá giáo viên", "Xoá giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được vì giáo viên này đang chủ nhiệm lớp hoặc có tiết trong thời khoá biểu", "Xoá giáo viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maGV.Clear();
            textBox_hoTen.Clear();
            textBox_dienThoai.Clear();
            textBox_email.Clear();
            textBox_timKiem.Clear();
            if (comboBox_khoa.Items.Count > 0)
                comboBox_khoa.SelectedIndex = 0;
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_giaoVien.DataSource = giaoVien.searchGiaoVien(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        private void DataGridView_giaoVien_Click(object sender, EventArgs e)
        {
            if (DataGridView_giaoVien.CurrentRow == null || DataGridView_giaoVien.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maGV.Text = DataGridView_giaoVien.CurrentRow.Cells["TeacherId"].Value.ToString();
            textBox_hoTen.Text = DataGridView_giaoVien.CurrentRow.Cells["TeacherName"].Value.ToString();
            textBox_dienThoai.Text = DataGridView_giaoVien.CurrentRow.Cells["Phone"].Value.ToString();
            textBox_email.Text = DataGridView_giaoVien.CurrentRow.Cells["Email"].Value.ToString();
            comboBox_khoa.SelectedValue = DataGridView_giaoVien.CurrentRow.Cells["DeptId"].Value;
        }
    }
}
