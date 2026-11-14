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
    public partial class FrmThoiKhoaBieu : Form
    {
        ThoiKhoaBieuClass tkb = new ThoiKhoaBieuClass();
        MonHocClass monHoc = new MonHocClass();
        LopClass lop = new LopClass();
        GiaoVienClass giaoVien = new GiaoVienClass();
        PhongHocClass phongHoc = new PhongHocClass();
        HocKyClass hocKy = new HocKyClass();
        public FrmThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void FrmThoiKhoaBieu_Load(object sender, EventArgs e)
        {
            comboBox_monHoc.DataSource = monHoc.getAll();
            comboBox_monHoc.DisplayMember = "CourseName";
            comboBox_monHoc.ValueMember = "CourseId";
            comboBox_lop.DataSource = lop.getComboBox();
            comboBox_lop.DisplayMember = "ClassName";
            comboBox_lop.ValueMember = "ClassId";
            comboBox_giaoVien.DataSource = giaoVien.getComboBox();
            comboBox_giaoVien.DisplayMember = "TeacherName";
            comboBox_giaoVien.ValueMember = "TeacherId";
            comboBox_phongHoc.DataSource = phongHoc.getAll();
            comboBox_phongHoc.DisplayMember = "RoomName";
            comboBox_phongHoc.ValueMember = "RoomId";
            comboBox_hocKy.DataSource = hocKy.getAll();
            comboBox_hocKy.DisplayMember = "SemesterName";
            comboBox_hocKy.ValueMember = "SemesterId";
            comboBox_thu.Items.AddRange(ThoiKhoaBieuClass.cacThu);
            comboBox_thu.SelectedIndex = 0;
            //giờ mặc định của một tiết đôi
            dateTimePicker_batDau.Value = DateTime.Today.AddHours(7).AddMinutes(30);
            dateTimePicker_ketThuc.Value = DateTime.Today.AddHours(9).AddMinutes(30);
            hienBang();
        }

        private void hienBang()
        {
            DataGridView_tkb.DataSource = tkb.getAll();
            datTieuDeCot();
        }

        //đặt tiêu đề cột, các cột mã để ẩn vì chỉ dùng nội bộ
        private void datTieuDeCot()
        {
            if (DataGridView_tkb.Columns.Count < 14)
                return;
            DataGridView_tkb.Columns["ScheduleId"].HeaderText = "Mã tiết";
            DataGridView_tkb.Columns["CourseName"].HeaderText = "Môn học";
            DataGridView_tkb.Columns["ClassName"].HeaderText = "Lớp";
            DataGridView_tkb.Columns["TeacherName"].HeaderText = "Giáo viên";
            DataGridView_tkb.Columns["RoomName"].HeaderText = "Phòng";
            DataGridView_tkb.Columns["SemesterName"].HeaderText = "Học kỳ";
            DataGridView_tkb.Columns["DayOfWeek"].HeaderText = "Thứ";
            DataGridView_tkb.Columns["StartTime"].HeaderText = "Từ";
            DataGridView_tkb.Columns["EndTime"].HeaderText = "Đến";
            DataGridView_tkb.Columns["CourseId"].Visible = false;
            DataGridView_tkb.Columns["ClassId"].Visible = false;
            DataGridView_tkb.Columns["TeacherId"].Visible = false;
            DataGridView_tkb.Columns["RoomId"].Visible = false;
            DataGridView_tkb.Columns["SemesterId"].Visible = false;
        }

        private string layThu()
        {
            if (comboBox_thu.SelectedIndex < 0)
                return ThoiKhoaBieuClass.cacThu[0];
            return comboBox_thu.Text;
        }

        //kiểm tra dữ liệu và kiểm tra trùng lịch
        private bool kiemTra(int maTietBoQua)
        {
            if (comboBox_monHoc.SelectedValue == null || comboBox_lop.SelectedValue == null ||
                comboBox_giaoVien.SelectedValue == null || comboBox_phongHoc.SelectedValue == null ||
                comboBox_hocKy.SelectedValue == null)
            {
                MessageBox.Show("Phải chọn đủ môn học, lớp, giáo viên, phòng và học kỳ", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dateTimePicker_ketThuc.Value.TimeOfDay <= dateTimePicker_batDau.Value.TimeOfDay)
            {
                MessageBox.Show("Giờ kết thúc phải sau giờ bắt đầu", "Giờ không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //không cho hai lớp dùng chung một phòng hoặc một giáo viên dạy hai nơi cùng giờ
            string loi = tkb.kiemTraTrungLich(Convert.ToInt32(comboBox_phongHoc.SelectedValue),
                Convert.ToInt32(comboBox_giaoVien.SelectedValue), Convert.ToInt32(comboBox_hocKy.SelectedValue),
                layThu(), dateTimePicker_batDau.Value.TimeOfDay, dateTimePicker_ketThuc.Value.TimeOfDay, maTietBoQua);
            if (loi != "")
            {
                MessageBox.Show(loi, "Trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (!kiemTra(0))
                return;
            if (tkb.insertTiet(Convert.ToInt32(comboBox_monHoc.SelectedValue), Convert.ToInt32(comboBox_lop.SelectedValue),
                Convert.ToInt32(comboBox_giaoVien.SelectedValue), Convert.ToInt32(comboBox_phongHoc.SelectedValue),
                Convert.ToInt32(comboBox_hocKy.SelectedValue), layThu(),
                dateTimePicker_batDau.Value.TimeOfDay, dateTimePicker_ketThuc.Value.TimeOfDay))
            {
                hienBang();
                MessageBox.Show("Đã thêm tiết vào thời khoá biểu", "Thêm tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thêm được tiết", "Thêm tiết", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maTiet;
            if (!int.TryParse(textBox_maTiet.Text, out maTiet))
            {
                MessageBox.Show("Hãy chọn một tiết trong bảng trước", "Sửa tiết", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kiemTra(maTiet))
                return;
            if (tkb.updateTiet(maTiet, Convert.ToInt32(comboBox_monHoc.SelectedValue), Convert.ToInt32(comboBox_lop.SelectedValue),
                Convert.ToInt32(comboBox_giaoVien.SelectedValue), Convert.ToInt32(comboBox_phongHoc.SelectedValue),
                Convert.ToInt32(comboBox_hocKy.SelectedValue), layThu(),
                dateTimePicker_batDau.Value.TimeOfDay, dateTimePicker_ketThuc.Value.TimeOfDay))
            {
                hienBang();
                MessageBox.Show("Đã sửa tiết", "Sửa tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được tiết", "Sửa tiết", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maTiet;
            if (!int.TryParse(textBox_maTiet.Text, out maTiet))
            {
                MessageBox.Show("Hãy chọn một tiết trong bảng trước", "Xoá tiết", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá tiết này khỏi thời khoá biểu?", "Xoá tiết", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (tkb.deleteTiet(maTiet))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá tiết", "Xoá tiết", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được tiết", "Xoá tiết", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maTiet.Clear();
            textBox_timKiem.Clear();
            comboBox_thu.SelectedIndex = 0;
            dateTimePicker_batDau.Value = DateTime.Today.AddHours(7).AddMinutes(30);
            dateTimePicker_ketThuc.Value = DateTime.Today.AddHours(9).AddMinutes(30);
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_tkb.DataSource = tkb.searchTKB(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        //click vào một dòng thì đổ dữ liệu lên các ô nhập
        private void DataGridView_tkb_Click(object sender, EventArgs e)
        {
            if (DataGridView_tkb.CurrentRow == null || DataGridView_tkb.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maTiet.Text = DataGridView_tkb.CurrentRow.Cells["ScheduleId"].Value.ToString();
            comboBox_monHoc.SelectedValue = DataGridView_tkb.CurrentRow.Cells["CourseId"].Value;
            comboBox_lop.SelectedValue = DataGridView_tkb.CurrentRow.Cells["ClassId"].Value;
            comboBox_giaoVien.SelectedValue = DataGridView_tkb.CurrentRow.Cells["TeacherId"].Value;
            comboBox_phongHoc.SelectedValue = DataGridView_tkb.CurrentRow.Cells["RoomId"].Value;
            comboBox_hocKy.SelectedValue = DataGridView_tkb.CurrentRow.Cells["SemesterId"].Value;
            comboBox_thu.Text = DataGridView_tkb.CurrentRow.Cells["DayOfWeek"].Value.ToString();
            TimeSpan gioBatDau = (TimeSpan)DataGridView_tkb.CurrentRow.Cells["StartTime"].Value;
            TimeSpan gioKetThuc = (TimeSpan)DataGridView_tkb.CurrentRow.Cells["EndTime"].Value;
            dateTimePicker_batDau.Value = DateTime.Today.Add(gioBatDau);
            dateTimePicker_ketThuc.Value = DateTime.Today.Add(gioKetThuc);
        }
    }
}
