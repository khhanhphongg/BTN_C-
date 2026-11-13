using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    public partial class FrmHocSinh : Form
    {
        HocSinhClass hocSinh = new HocSinhClass();
        LopClass lop = new LopClass();
        public FrmHocSinh()
        {
            InitializeComponent();
        }

        private void FrmHocSinh_Load(object sender, EventArgs e)
        {
            comboBox_lop.DataSource = lop.getComboBox();
            comboBox_lop.DisplayMember = "ClassName";
            comboBox_lop.ValueMember = "ClassId";
            hienBang();
        }

        private void hienBang()
        {
            DataGridView_hocSinh.DataSource = hocSinh.getAll();
            datTieuDeCot();
        }

        //đặt tiêu đề cột và cho cột ảnh hiện vừa khung
        private void datTieuDeCot()
        {
            if (DataGridView_hocSinh.Columns.Count < 10)
                return;
            DataGridView_hocSinh.Columns["StdId"].HeaderText = "Mã HS";
            DataGridView_hocSinh.Columns["StdLastName"].HeaderText = "Họ";
            DataGridView_hocSinh.Columns["StdFirstName"].HeaderText = "Tên";
            DataGridView_hocSinh.Columns["Birthdate"].HeaderText = "Ngày sinh";
            DataGridView_hocSinh.Columns["Gender"].HeaderText = "Giới tính";
            DataGridView_hocSinh.Columns["Phone"].HeaderText = "Điện thoại";
            DataGridView_hocSinh.Columns["Address"].HeaderText = "Địa chỉ";
            DataGridView_hocSinh.Columns["ClassName"].HeaderText = "Lớp";
            DataGridView_hocSinh.Columns["Photo"].HeaderText = "Ảnh";
            DataGridView_hocSinh.Columns["ClassId"].Visible = false;
            DataGridViewImageColumn cotAnh = (DataGridViewImageColumn)DataGridView_hocSinh.Columns["Photo"];
            cotAnh.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void button_chonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Chọn ảnh (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox_anh.Image = Image.FromFile(opf.FileName);
        }

        //kiểm tra dữ liệu, tuổi học sinh THPT phải từ 10 đến 25
        private bool kiemTra()
        {
            if (textBox_ho.Text.Trim() == "" || textBox_ten.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập họ và tên học sinh", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (textBox_dienThoai.Text.Trim() == "" || textBox_diaChi.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập điện thoại và địa chỉ", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (pictureBox_anh.Image == null)
            {
                MessageBox.Show("Phải chọn ảnh cho học sinh", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            int tuoi = DateTime.Now.Year - dateTimePicker_ns.Value.Year;
            if (tuoi < 10 || tuoi > 25)
            {
                MessageBox.Show("Tuổi học sinh phải từ 10 đến 25", "Ngày sinh không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBox_lop.SelectedValue == null)
            {
                MessageBox.Show("Phải chọn lớp cho học sinh", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //đổi ảnh trong PictureBox thành mảng byte để lưu vào cột LONGBLOB
        private byte[] layAnh()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox_anh.Image.Save(ms, pictureBox_anh.Image.RawFormat);
            return ms.ToArray();
        }

        private string layGioiTinh()
        {
            if (radioButton_nam.Checked)
                return "Nam";
            return "Nữ";
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (!kiemTra())
                return;
            try
            {
                int maHS = hocSinh.insertHocSinh(textBox_ho.Text.Trim(), textBox_ten.Text.Trim(),
                    dateTimePicker_ns.Value, layGioiTinh(), textBox_dienThoai.Text.Trim(),
                    textBox_diaChi.Text.Trim(), layAnh(), Convert.ToInt32(comboBox_lop.SelectedValue));
                if (maHS > 0)
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã thêm học sinh mới, mã học sinh là " + maHS, "Thêm học sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thêm được học sinh", "Thêm học sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maHS;
            if (!int.TryParse(textBox_maHS.Text, out maHS))
            {
                MessageBox.Show("Hãy chọn một học sinh trong bảng trước", "Sửa học sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kiemTra())
                return;
            try
            {
                if (hocSinh.updateHocSinh(maHS, textBox_ho.Text.Trim(), textBox_ten.Text.Trim(),
                    dateTimePicker_ns.Value, layGioiTinh(), textBox_dienThoai.Text.Trim(),
                    textBox_diaChi.Text.Trim(), layAnh(), Convert.ToInt32(comboBox_lop.SelectedValue)))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã sửa thông tin học sinh", "Sửa học sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maHS;
            if (!int.TryParse(textBox_maHS.Text, out maHS))
            {
                MessageBox.Show("Hãy chọn một học sinh trong bảng trước", "Xoá học sinh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Xoá học sinh sẽ xoá luôn toàn bộ điểm, điểm danh và học phí của học sinh này. Bạn có chắc không?",
                "Xoá học sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (hocSinh.deleteHocSinh(maHS))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá học sinh", "Xoá học sinh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được học sinh", "Xoá học sinh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maHS.Clear();
            textBox_ho.Clear();
            textBox_ten.Clear();
            textBox_dienThoai.Clear();
            textBox_diaChi.Clear();
            textBox_timKiem.Clear();
            radioButton_nam.Checked = true;
            dateTimePicker_ns.Value = DateTime.Now;
            pictureBox_anh.Image = null;
            if (comboBox_lop.Items.Count > 0)
                comboBox_lop.SelectedIndex = 0;
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_hocSinh.DataSource = hocSinh.searchHocSinh(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        //click vào một dòng thì đổ dữ liệu lên các ô nhập
        private void DataGridView_hocSinh_Click(object sender, EventArgs e)
        {
            if (DataGridView_hocSinh.CurrentRow == null || DataGridView_hocSinh.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maHS.Text = DataGridView_hocSinh.CurrentRow.Cells["StdId"].Value.ToString();
            textBox_ho.Text = DataGridView_hocSinh.CurrentRow.Cells["StdLastName"].Value.ToString();
            textBox_ten.Text = DataGridView_hocSinh.CurrentRow.Cells["StdFirstName"].Value.ToString();
            dateTimePicker_ns.Value = Convert.ToDateTime(DataGridView_hocSinh.CurrentRow.Cells["Birthdate"].Value);
            if (DataGridView_hocSinh.CurrentRow.Cells["Gender"].Value.ToString() == "Nam")
                radioButton_nam.Checked = true;
            else
                radioButton_nu.Checked = true;
            textBox_dienThoai.Text = DataGridView_hocSinh.CurrentRow.Cells["Phone"].Value.ToString();
            textBox_diaChi.Text = DataGridView_hocSinh.CurrentRow.Cells["Address"].Value.ToString();
            //học sinh chưa xếp lớp thì cột ClassId là 0
            int maLop = Convert.ToInt32(DataGridView_hocSinh.CurrentRow.Cells["ClassId"].Value);
            if (maLop > 0)
                comboBox_lop.SelectedValue = maLop;
            //đọc ảnh từ cột LONGBLOB ra PictureBox
            if (DataGridView_hocSinh.CurrentRow.Cells["Photo"].Value != DBNull.Value)
            {
                byte[] anh = (byte[])DataGridView_hocSinh.CurrentRow.Cells["Photo"].Value;
                MemoryStream ms = new MemoryStream(anh);
                pictureBox_anh.Image = Image.FromStream(ms);
            }
            else
            {
                pictureBox_anh.Image = null;
            }
        }
    }
}
