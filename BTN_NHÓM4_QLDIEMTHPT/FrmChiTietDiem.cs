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
    /*
     * Form nhập các đầu điểm của một môn.
     * Bước 1 chọn môn của học sinh ở lưới trên, bước 2 thêm/sửa/xoá đầu điểm
     * ở lưới dưới. Mỗi lần lưu, điểm trung bình môn được tính lại.
     */
    public partial class FrmChiTietDiem : Form
    {
        ChiTietDiemClass chiTiet = new ChiTietDiemClass();
        BangDiemClass bangDiem = new BangDiemClass();
        HocKyClass hocKy = new HocKyClass();

        //môn đang chọn ở lưới trên
        int maHSDangChon = 0;
        string monDangChon = "";

        public FrmChiTietDiem()
        {
            InitializeComponent();
        }

        private void FrmChiTietDiem_Load(object sender, EventArgs e)
        {
            comboBox_hocKy.DataSource = hocKy.getAll();
            comboBox_hocKy.DisplayMember = "SemesterName";
            comboBox_hocKy.ValueMember = "SemesterId";
            comboBox_loaiDiem.Items.AddRange(ChiTietDiemClass.cacLoaiDiem);
            comboBox_loaiDiem.SelectedIndex = 0;
            comboBox_heSo.Items.Add("1");
            comboBox_heSo.Items.Add("2");
            comboBox_heSo.Items.Add("3");
            comboBox_heSo.SelectedIndex = 0;
            hienBangDiem();
        }

        //đổ bảng điểm lên lưới trên
        private void hienBangDiem()
        {
            DataGridView_bangDiem.DataSource = bangDiem.getAll();
            if (DataGridView_bangDiem.Columns.Count >= 7)
            {
                DataGridView_bangDiem.Columns["StudentId"].HeaderText = "Mã HS";
                DataGridView_bangDiem.Columns["HoTen"].HeaderText = "Họ tên";
                DataGridView_bangDiem.Columns["ClassName"].HeaderText = "Lớp";
                DataGridView_bangDiem.Columns["CourseName"].HeaderText = "Môn học";
                DataGridView_bangDiem.Columns["Score"].HeaderText = "Điểm TB";
                DataGridView_bangDiem.Columns["Description"].HeaderText = "Học lực";
                DataGridView_bangDiem.Columns["SoDauDiem"].HeaderText = "Số đầu điểm";
            }
        }

        //đổ các đầu điểm của môn đang chọn lên lưới dưới
        private void hienChiTiet()
        {
            if (maHSDangChon == 0)
                return;
            DataGridView_chiTiet.DataSource = chiTiet.getChiTiet(maHSDangChon, monDangChon);
            if (DataGridView_chiTiet.Columns.Count >= 7)
            {
                DataGridView_chiTiet.Columns["MaCT"].HeaderText = "Mã";
                DataGridView_chiTiet.Columns["LoaiDiem"].HeaderText = "Loại điểm";
                DataGridView_chiTiet.Columns["Diem"].HeaderText = "Điểm";
                DataGridView_chiTiet.Columns["HeSo"].HeaderText = "Hệ số";
                DataGridView_chiTiet.Columns["SemesterName"].HeaderText = "Học kỳ";
                DataGridView_chiTiet.Columns["GhiChu"].HeaderText = "Ghi chú";
                DataGridView_chiTiet.Columns["SemesterId"].Visible = false;
            }
        }

        //bước 1: chọn môn của học sinh ở lưới trên
        private void DataGridView_bangDiem_Click(object sender, EventArgs e)
        {
            if (DataGridView_bangDiem.CurrentRow == null || DataGridView_bangDiem.CurrentRow.Cells[0].Value == null)
                return;
            maHSDangChon = Convert.ToInt32(DataGridView_bangDiem.CurrentRow.Cells["StudentId"].Value);
            monDangChon = DataGridView_bangDiem.CurrentRow.Cells["CourseName"].Value.ToString();
            textBox_hocSinh.Text = DataGridView_bangDiem.CurrentRow.Cells["HoTen"].Value.ToString();
            textBox_monHoc.Text = monDangChon;
            textBox_maCT.Clear();
            hienChiTiet();
        }

        //chọn một đầu điểm ở lưới dưới để sửa
        private void DataGridView_chiTiet_Click(object sender, EventArgs e)
        {
            if (DataGridView_chiTiet.CurrentRow == null || DataGridView_chiTiet.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maCT.Text = DataGridView_chiTiet.CurrentRow.Cells["MaCT"].Value.ToString();
            comboBox_loaiDiem.Text = DataGridView_chiTiet.CurrentRow.Cells["LoaiDiem"].Value.ToString();
            textBox_diem.Text = DataGridView_chiTiet.CurrentRow.Cells["Diem"].Value.ToString();
            comboBox_heSo.Text = DataGridView_chiTiet.CurrentRow.Cells["HeSo"].Value.ToString();
            comboBox_hocKy.SelectedValue = DataGridView_chiTiet.CurrentRow.Cells["SemesterId"].Value;
            textBox_ghiChu.Text = DataGridView_chiTiet.CurrentRow.Cells["GhiChu"].Value.ToString();
        }

        //kiểm tra: phải chọn môn trước, điểm phải từ 0 đến 10
        private bool kiemTra(out double diem, out int heSo)
        {
            diem = 0;
            heSo = 1;
            if (maHSDangChon == 0)
            {
                MessageBox.Show("Bước 1: hãy chọn môn của học sinh ở lưới trên trước", "Chưa chọn môn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!ChiTietDiemClass.tryParseDiem(textBox_diem.Text, out diem))
            {
                MessageBox.Show("Điểm phải là số từ 0 đến 10", "Điểm không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(comboBox_heSo.Text, out heSo) || heSo <= 0)
            {
                MessageBox.Show("Phải chọn hệ số", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox_hocKy.SelectedValue == null)
            {
                MessageBox.Show("Phải chọn học kỳ", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //hiện điểm trung bình môn sau khi lưu
        private void baoDiemTB()
        {
            double tb = chiTiet.tinhTrungBinh(maHSDangChon, monDangChon);
            MessageBox.Show("Điểm trung bình môn " + monDangChon + " hiện là " + tb.ToString("0.0") +
                " - học lực " + ChiTietDiemClass.xepLoai(tb), "Đã cập nhật điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            double diem;
            int heSo;
            if (!kiemTra(out diem, out heSo))
                return;
            if (chiTiet.insertChiTiet(maHSDangChon, monDangChon, Convert.ToInt32(comboBox_hocKy.SelectedValue),
                comboBox_loaiDiem.Text, diem, heSo, textBox_ghiChu.Text.Trim()))
            {
                hienChiTiet();
                hienBangDiem();
                baoDiemTB();
            }
            else
            {
                MessageBox.Show("Không thêm được đầu điểm", "Thêm đầu điểm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maCT;
            if (!int.TryParse(textBox_maCT.Text, out maCT))
            {
                MessageBox.Show("Hãy chọn một đầu điểm ở lưới dưới trước", "Sửa đầu điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double diem;
            int heSo;
            if (!kiemTra(out diem, out heSo))
                return;
            if (chiTiet.updateChiTiet(maCT, Convert.ToInt32(comboBox_hocKy.SelectedValue), comboBox_loaiDiem.Text,
                diem, heSo, textBox_ghiChu.Text.Trim(), maHSDangChon, monDangChon))
            {
                hienChiTiet();
                hienBangDiem();
                baoDiemTB();
            }
            else
            {
                MessageBox.Show("Không sửa được đầu điểm", "Sửa đầu điểm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maCT;
            if (!int.TryParse(textBox_maCT.Text, out maCT))
            {
                MessageBox.Show("Hãy chọn một đầu điểm ở lưới dưới trước", "Xoá đầu điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá đầu điểm này?", "Xoá đầu điểm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (chiTiet.deleteChiTiet(maCT, maHSDangChon, monDangChon))
                {
                    hienChiTiet();
                    hienBangDiem();
                    textBox_maCT.Clear();
                    baoDiemTB();
                }
                else
                {
                    MessageBox.Show("Không xoá được đầu điểm", "Xoá đầu điểm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maCT.Clear();
            textBox_diem.Clear();
            textBox_ghiChu.Clear();
            textBox_timKiem.Clear();
            comboBox_loaiDiem.SelectedIndex = 0;
            comboBox_heSo.SelectedIndex = 0;
        }

        //tìm trong lưới trên theo họ tên học sinh, lớp hoặc môn
        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_bangDiem.DataSource = bangDiem.searchBangDiem(textBox_timKiem.Text.Trim());
        }
    }
}
