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
    public partial class FrmLop : Form
    {
        LopClass lop = new LopClass();
        KhoaClass khoa = new KhoaClass();
        GiaoVienClass giaoVien = new GiaoVienClass();
        public FrmLop()
        {
            InitializeComponent();
        }

        private void FrmLop_Load(object sender, EventArgs e)
        {
            //đổ khoa và giáo viên vào combobox, ValueMember là mã để lấy khoá ngoại khi lưu
            comboBox_khoa.DataSource = khoa.getAll();
            comboBox_khoa.DisplayMember = "DeptName";
            comboBox_khoa.ValueMember = "DeptId";
            comboBox_gvcn.DataSource = giaoVien.getComboBox();
            comboBox_gvcn.DisplayMember = "TeacherName";
            comboBox_gvcn.ValueMember = "TeacherId";
            hienBang();
        }

        //hàm đổ danh sách lớp lên lưới
        private void hienBang()
        {
            DataGridView_lop.DataSource = lop.getAll();
            datTieuDeCot();
        }

        //hàm đặt tiêu đề cột, hai cột mã để ẩn vì chỉ dùng nội bộ
        private void datTieuDeCot()
        {
            if (DataGridView_lop.Columns.Count < 8)
                return;
            DataGridView_lop.Columns["ClassId"].HeaderText = "Mã lớp";
            DataGridView_lop.Columns["ClassName"].HeaderText = "Tên lớp";
            DataGridView_lop.Columns["SchoolYear"].HeaderText = "Năm học";
            DataGridView_lop.Columns["DeptName"].HeaderText = "Khoa";
            DataGridView_lop.Columns["TeacherName"].HeaderText = "GV chủ nhiệm";
            DataGridView_lop.Columns["SoHocSinh"].HeaderText = "Số HS";
            DataGridView_lop.Columns["DeptId"].Visible = false;
            DataGridView_lop.Columns["TeacherId"].Visible = false;
        }

        //hàm kiểm tra dữ liệu bắt buộc
        private bool kiemTra()
        {
            if (textBox_tenLop.Text.Trim() == "" || textBox_namHoc.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập tên lớp và năm học", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox_khoa.SelectedValue == null || comboBox_gvcn.SelectedValue == null)
            {
                MessageBox.Show("Phải chọn khoa và giáo viên chủ nhiệm", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (!kiemTra())
                return;
            if (lop.insertLop(textBox_tenLop.Text.Trim(), textBox_namHoc.Text.Trim(),
                Convert.ToInt32(comboBox_khoa.SelectedValue), Convert.ToInt32(comboBox_gvcn.SelectedValue)))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã thêm lớp mới", "Thêm lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thêm được, tên lớp này đã tồn tại", "Thêm lớp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maLop;
            if (!int.TryParse(textBox_maLop.Text, out maLop))
            {
                MessageBox.Show("Hãy chọn một lớp trong bảng trước", "Sửa lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kiemTra())
                return;
            if (lop.updateLop(maLop, textBox_tenLop.Text.Trim(), textBox_namHoc.Text.Trim(),
                Convert.ToInt32(comboBox_khoa.SelectedValue), Convert.ToInt32(comboBox_gvcn.SelectedValue)))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã sửa thông tin lớp", "Sửa lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được, tên lớp này đã tồn tại", "Sửa lớp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maLop;
            if (!int.TryParse(textBox_maLop.Text, out maLop))
            {
                MessageBox.Show("Hãy chọn một lớp trong bảng trước", "Xoá lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá lớp này?", "Xoá lớp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (lop.deleteLop(maLop))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá lớp", "Xoá lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được vì lớp này còn học sinh hoặc còn trong thời khoá biểu", "Xoá lớp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maLop.Clear();
            textBox_tenLop.Clear();
            textBox_namHoc.Clear();
            textBox_timKiem.Clear();
            if (comboBox_khoa.Items.Count > 0)
                comboBox_khoa.SelectedIndex = 0;
            if (comboBox_gvcn.Items.Count > 0)
                comboBox_gvcn.SelectedIndex = 0;
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_lop.DataSource = lop.searchLop(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        private void DataGridView_lop_Click(object sender, EventArgs e)
        {
            if (DataGridView_lop.CurrentRow == null || DataGridView_lop.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maLop.Text = DataGridView_lop.CurrentRow.Cells["ClassId"].Value.ToString();
            textBox_tenLop.Text = DataGridView_lop.CurrentRow.Cells["ClassName"].Value.ToString();
            textBox_namHoc.Text = DataGridView_lop.CurrentRow.Cells["SchoolYear"].Value.ToString();
            comboBox_khoa.SelectedValue = DataGridView_lop.CurrentRow.Cells["DeptId"].Value;
            //lớp có thể chưa phân công chủ nhiệm, khi đó cột TeacherId là null
            if (DataGridView_lop.CurrentRow.Cells["TeacherId"].Value != DBNull.Value)
                comboBox_gvcn.SelectedValue = DataGridView_lop.CurrentRow.Cells["TeacherId"].Value;
        }
    }
}
