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
    public partial class FrmHocPhi : Form
    {
        HocPhiClass hocPhi = new HocPhiClass();
        HocSinhClass hocSinh = new HocSinhClass();
        HocKyClass hocKy = new HocKyClass();
        public FrmHocPhi()
        {
            InitializeComponent();
        }

        private void FrmHocPhi_Load(object sender, EventArgs e)
        {
            comboBox_hocSinh.DataSource = hocSinh.getComboBox();
            comboBox_hocSinh.DisplayMember = "HoTen";
            comboBox_hocSinh.ValueMember = "StdId";
            comboBox_hocKy.DataSource = hocKy.getAll();
            comboBox_hocKy.DisplayMember = "SemesterName";
            comboBox_hocKy.ValueMember = "SemesterId";
            comboBox_trangThai.Items.AddRange(HocPhiClass.cacTrangThai);
            comboBox_trangThai.SelectedIndex = 0;
            hienBang();
        }

        private void hienBang()
        {
            DataGridView_hocPhi.DataSource = hocPhi.getAll();
            datTieuDeCot();
        }

        private void datTieuDeCot()
        {
            if (DataGridView_hocPhi.Columns.Count < 9)
                return;
            DataGridView_hocPhi.Columns["TuitionId"].HeaderText = "Mã";
            DataGridView_hocPhi.Columns["HoTen"].HeaderText = "Họ tên";
            DataGridView_hocPhi.Columns["ClassName"].HeaderText = "Lớp";
            DataGridView_hocPhi.Columns["SemesterName"].HeaderText = "Học kỳ";
            DataGridView_hocPhi.Columns["Amount"].HeaderText = "Số tiền";
            DataGridView_hocPhi.Columns["PaidDate"].HeaderText = "Ngày đóng";
            DataGridView_hocPhi.Columns["Status"].HeaderText = "Trạng thái";
            DataGridView_hocPhi.Columns["StudentId"].Visible = false;
            DataGridView_hocPhi.Columns["SemesterId"].Visible = false;
            //hiện số tiền có dấu phân cách nghìn cho dễ đọc
            DataGridView_hocPhi.Columns["Amount"].DefaultCellStyle.Format = "N0";
        }

        private string layTrangThai()
        {
            if (comboBox_trangThai.SelectedIndex < 0)
                return HocPhiClass.cacTrangThai[0];
            return comboBox_trangThai.Text;
        }

        //chưa đóng thì không lưu ngày đóng
        private DateTime? layNgayDong()
        {
            if (layTrangThai() == "Đã đóng")
                return dateTimePicker_ngayDong.Value;
            return null;
        }

        //kiểm tra dữ liệu, số tiền phải là số không âm
        private bool kiemTra(out int soTien)
        {
            soTien = 0;
            if (comboBox_hocSinh.SelectedValue == null || comboBox_hocKy.SelectedValue == null)
            {
                MessageBox.Show("Phải chọn học sinh và học kỳ", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!HocPhiClass.tryParseTien(textBox_soTien.Text, out soTien))
            {
                MessageBox.Show("Số tiền phải là số nguyên không âm", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            int soTien;
            if (!kiemTra(out soTien))
                return;
            if (hocPhi.insertHocPhi(Convert.ToInt32(comboBox_hocSinh.SelectedValue),
                Convert.ToInt32(comboBox_hocKy.SelectedValue), soTien, layNgayDong(), layTrangThai()))
            {
                hienBang();
                MessageBox.Show("Đã thêm dòng học phí", "Thêm học phí", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Học sinh này đã có dòng học phí cho học kỳ đã chọn", "Thêm học phí", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maHP, soTien;
            if (!int.TryParse(textBox_maHP.Text, out maHP))
            {
                MessageBox.Show("Hãy chọn một dòng trong bảng trước", "Sửa học phí", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kiemTra(out soTien))
                return;
            if (hocPhi.updateHocPhi(maHP, Convert.ToInt32(comboBox_hocSinh.SelectedValue),
                Convert.ToInt32(comboBox_hocKy.SelectedValue), soTien, layNgayDong(), layTrangThai()))
            {
                hienBang();
                MessageBox.Show("Đã sửa học phí", "Sửa học phí", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được, có thể bị trùng học sinh và học kỳ với dòng khác", "Sửa học phí", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maHP;
            if (!int.TryParse(textBox_maHP.Text, out maHP))
            {
                MessageBox.Show("Hãy chọn một dòng trong bảng trước", "Xoá học phí", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá dòng học phí này?", "Xoá học phí", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (hocPhi.deleteHocPhi(maHP))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá", "Xoá học phí", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được", "Xoá học phí", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maHP.Clear();
            textBox_soTien.Clear();
            textBox_timKiem.Clear();
            dateTimePicker_ngayDong.Value = DateTime.Now;
            comboBox_trangThai.SelectedIndex = 0;
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_hocPhi.DataSource = hocPhi.searchHocPhi(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        //click vào một dòng thì đổ dữ liệu lên các ô nhập
        private void DataGridView_hocPhi_Click(object sender, EventArgs e)
        {
            if (DataGridView_hocPhi.CurrentRow == null || DataGridView_hocPhi.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maHP.Text = DataGridView_hocPhi.CurrentRow.Cells["TuitionId"].Value.ToString();
            comboBox_hocSinh.SelectedValue = DataGridView_hocPhi.CurrentRow.Cells["StudentId"].Value;
            comboBox_hocKy.SelectedValue = DataGridView_hocPhi.CurrentRow.Cells["SemesterId"].Value;
            textBox_soTien.Text = DataGridView_hocPhi.CurrentRow.Cells["Amount"].Value.ToString();
            //chưa đóng thì cột ngày đóng là null
            if (DataGridView_hocPhi.CurrentRow.Cells["PaidDate"].Value != DBNull.Value)
                dateTimePicker_ngayDong.Value = Convert.ToDateTime(DataGridView_hocPhi.CurrentRow.Cells["PaidDate"].Value);
            comboBox_trangThai.Text = DataGridView_hocPhi.CurrentRow.Cells["Status"].Value.ToString();
        }
    }
}
