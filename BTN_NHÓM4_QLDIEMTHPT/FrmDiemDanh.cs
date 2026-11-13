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
    public partial class FrmDiemDanh : Form
    {
        DiemDanhClass diemDanh = new DiemDanhClass();
        HocSinhClass hocSinh = new HocSinhClass();
        MonHocClass monHoc = new MonHocClass();
        LopClass lop = new LopClass();
        public FrmDiemDanh()
        {
            InitializeComponent();
        }

        private void FrmDiemDanh_Load(object sender, EventArgs e)
        {
            //chọn lớp trước rồi mới lọc ra học sinh của lớp đó
            comboBox_lop.DataSource = lop.getComboBox();
            comboBox_lop.DisplayMember = "ClassName";
            comboBox_lop.ValueMember = "ClassId";
            comboBox_monHoc.DataSource = monHoc.getAll();
            comboBox_monHoc.DisplayMember = "CourseName";
            comboBox_monHoc.ValueMember = "CourseId";
            //ba trạng thái điểm danh, hiện tiếng Việt nhưng lưu tiếng Anh vào CSDL
            foreach (string tt in DiemDanhClass.cacTrangThai)
                comboBox_trangThai.Items.Add(DiemDanhClass.trangThaiTiengViet(tt));
            comboBox_trangThai.SelectedIndex = 0;
            locHocSinh();
            hienBang();
        }

        //hàm lọc học sinh theo lớp đang chọn
        private void locHocSinh()
        {
            if (comboBox_lop.SelectedValue == null)
                return;
            comboBox_hocSinh.DataSource = hocSinh.getHocSinhTheoLop(Convert.ToInt32(comboBox_lop.SelectedValue));
            comboBox_hocSinh.DisplayMember = "HoTen";
            comboBox_hocSinh.ValueMember = "StdId";
        }

        private void comboBox_lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            locHocSinh();
        }

        //hàm đổ danh sách điểm danh lên lưới
        private void hienBang()
        {
            DataGridView_diemDanh.DataSource = diemDanh.getAll();
            datTieuDeCot();
        }

        private void datTieuDeCot()
        {
            if (DataGridView_diemDanh.Columns.Count < 8)
                return;
            DataGridView_diemDanh.Columns["AttendId"].HeaderText = "Mã";
            DataGridView_diemDanh.Columns["HoTen"].HeaderText = "Họ tên";
            DataGridView_diemDanh.Columns["ClassName"].HeaderText = "Lớp";
            DataGridView_diemDanh.Columns["CourseName"].HeaderText = "Môn học";
            DataGridView_diemDanh.Columns["AttendDate"].HeaderText = "Ngày";
            DataGridView_diemDanh.Columns["Status"].HeaderText = "Trạng thái";
            DataGridView_diemDanh.Columns["StudentId"].Visible = false;
            DataGridView_diemDanh.Columns["CourseId"].Visible = false;
        }

        //hàm đổi trạng thái tiếng Việt đang chọn về tiếng Anh để lưu
        private string layTrangThai()
        {
            int viTri = comboBox_trangThai.SelectedIndex;
            if (viTri < 0)
                viTri = 0;
            return DiemDanhClass.cacTrangThai[viTri];
        }

        //hàm kiểm tra dữ liệu bắt buộc
        private bool kiemTra()
        {
            if (comboBox_hocSinh.SelectedValue == null)
            {
                MessageBox.Show("Lớp này chưa có học sinh, hãy chọn lớp khác", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox_monHoc.SelectedValue == null)
            {
                MessageBox.Show("Phải chọn môn học", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dateTimePicker_ngay.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Không điểm danh cho ngày trong tương lai", "Ngày không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (!kiemTra())
                return;
            if (diemDanh.insertDiemDanh(Convert.ToInt32(comboBox_hocSinh.SelectedValue),
                Convert.ToInt32(comboBox_monHoc.SelectedValue), dateTimePicker_ngay.Value, layTrangThai()))
            {
                hienBang();
                MessageBox.Show("Đã điểm danh", "Điểm danh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Học sinh này đã được điểm danh môn đó trong ngày đã chọn", "Điểm danh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maDD;
            if (!int.TryParse(textBox_maDD.Text, out maDD))
            {
                MessageBox.Show("Hãy chọn một dòng trong bảng trước", "Sửa điểm danh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kiemTra())
                return;
            if (diemDanh.updateDiemDanh(maDD, Convert.ToInt32(comboBox_hocSinh.SelectedValue),
                Convert.ToInt32(comboBox_monHoc.SelectedValue), dateTimePicker_ngay.Value, layTrangThai()))
            {
                hienBang();
                MessageBox.Show("Đã sửa điểm danh", "Sửa điểm danh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được, có thể bị trùng với một dòng điểm danh khác", "Sửa điểm danh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maDD;
            if (!int.TryParse(textBox_maDD.Text, out maDD))
            {
                MessageBox.Show("Hãy chọn một dòng trong bảng trước", "Xoá điểm danh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá dòng điểm danh này?", "Xoá điểm danh", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (diemDanh.deleteDiemDanh(maDD))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá", "Xoá điểm danh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được", "Xoá điểm danh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maDD.Clear();
            textBox_timKiem.Clear();
            dateTimePicker_ngay.Value = DateTime.Now;
            comboBox_trangThai.SelectedIndex = 0;
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_diemDanh.DataSource = diemDanh.searchDiemDanh(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        //click vào một dòng thì đổ dữ liệu lên các ô nhập
        private void DataGridView_diemDanh_Click(object sender, EventArgs e)
        {
            if (DataGridView_diemDanh.CurrentRow == null || DataGridView_diemDanh.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maDD.Text = DataGridView_diemDanh.CurrentRow.Cells["AttendId"].Value.ToString();
            //chọn đúng lớp của học sinh rồi lọc lại danh sách học sinh
            comboBox_lop.Text = DataGridView_diemDanh.CurrentRow.Cells["ClassName"].Value.ToString();
            locHocSinh();
            comboBox_hocSinh.SelectedValue = DataGridView_diemDanh.CurrentRow.Cells["StudentId"].Value;
            comboBox_monHoc.SelectedValue = DataGridView_diemDanh.CurrentRow.Cells["CourseId"].Value;
            dateTimePicker_ngay.Value = Convert.ToDateTime(DataGridView_diemDanh.CurrentRow.Cells["AttendDate"].Value);
            //đổi trạng thái tiếng Anh về đúng dòng trên combobox
            string tt = DataGridView_diemDanh.CurrentRow.Cells["Status"].Value.ToString();
            for (int i = 0; i < DiemDanhClass.cacTrangThai.Length; i++)
            {
                if (DiemDanhClass.cacTrangThai[i] == tt)
                {
                    comboBox_trangThai.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
