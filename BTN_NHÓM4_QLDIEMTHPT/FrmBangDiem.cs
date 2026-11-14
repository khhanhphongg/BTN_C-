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
    /*
     * Form mở môn học cho học sinh. Điểm trung bình môn và học lực chỉ để
     * xem, không nhập tay được, vì do form Chi tiết điểm tính ra.
     */
    public partial class FrmBangDiem : Form
    {
        BangDiemClass bangDiem = new BangDiemClass();
        HocSinhClass hocSinh = new HocSinhClass();
        MonHocClass monHoc = new MonHocClass();
        public FrmBangDiem()
        {
            InitializeComponent();
        }

        private void FrmBangDiem_Load(object sender, EventArgs e)
        {
            comboBox_hocSinh.DataSource = hocSinh.getComboBox();
            comboBox_hocSinh.DisplayMember = "HoTen";
            comboBox_hocSinh.ValueMember = "StdId";
            comboBox_monHoc.DataSource = monHoc.getAll();
            comboBox_monHoc.DisplayMember = "CourseName";
            comboBox_monHoc.ValueMember = "CourseName";
            hienBang();
        }

        private void hienBang()
        {
            DataGridView_bangDiem.DataSource = bangDiem.getAll();
            datTieuDeCot();
        }

        private void datTieuDeCot()
        {
            if (DataGridView_bangDiem.Columns.Count < 7)
                return;
            DataGridView_bangDiem.Columns["StudentId"].HeaderText = "Mã HS";
            DataGridView_bangDiem.Columns["HoTen"].HeaderText = "Họ tên";
            DataGridView_bangDiem.Columns["ClassName"].HeaderText = "Lớp";
            DataGridView_bangDiem.Columns["CourseName"].HeaderText = "Môn học";
            DataGridView_bangDiem.Columns["Score"].HeaderText = "Điểm TB";
            DataGridView_bangDiem.Columns["Description"].HeaderText = "Học lực";
            DataGridView_bangDiem.Columns["SoDauDiem"].HeaderText = "Số đầu điểm";
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (comboBox_hocSinh.SelectedValue == null || comboBox_monHoc.SelectedValue == null)
            {
                MessageBox.Show("Phải chọn học sinh và môn học", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maHS = Convert.ToInt32(comboBox_hocSinh.SelectedValue);
            string tenMon = comboBox_monHoc.Text;
            if (bangDiem.kiemTraDaCo(maHS, tenMon))
            {
                MessageBox.Show("Học sinh này đã được mở môn " + tenMon, "Mở môn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bangDiem.insertBangDiem(maHS, tenMon))
            {
                hienBang();
                MessageBox.Show("Đã mở môn " + tenMon + " cho học sinh." + Environment.NewLine +
                    "Sang form Chi tiết điểm để nhập các đầu điểm.", "Mở môn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không mở được môn cho học sinh này", "Mở môn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //xoá một môn của học sinh, các đầu điểm của môn cũng mất theo
        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (DataGridView_bangDiem.CurrentRow == null || DataGridView_bangDiem.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("Hãy chọn một dòng trong bảng trước", "Xoá môn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maHS = Convert.ToInt32(DataGridView_bangDiem.CurrentRow.Cells["StudentId"].Value);
            string tenMon = DataGridView_bangDiem.CurrentRow.Cells["CourseName"].Value.ToString();
            if (MessageBox.Show("Xoá môn " + tenMon + " sẽ xoá luôn các đầu điểm của môn này. Bạn có chắc không?",
                "Xoá môn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (bangDiem.deleteBangDiem(maHS, tenMon))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá môn khỏi bảng điểm", "Xoá môn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được", "Xoá môn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_diemTB.Clear();
            textBox_hocLuc.Clear();
            textBox_timKiem.Clear();
            if (comboBox_hocSinh.Items.Count > 0)
                comboBox_hocSinh.SelectedIndex = 0;
            if (comboBox_monHoc.Items.Count > 0)
                comboBox_monHoc.SelectedIndex = 0;
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_bangDiem.DataSource = bangDiem.searchBangDiem(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        //click vào một dòng thì đổ lên các ô để xem
        private void DataGridView_bangDiem_Click(object sender, EventArgs e)
        {
            if (DataGridView_bangDiem.CurrentRow == null || DataGridView_bangDiem.CurrentRow.Cells[0].Value == null)
                return;
            comboBox_hocSinh.SelectedValue = DataGridView_bangDiem.CurrentRow.Cells["StudentId"].Value;
            comboBox_monHoc.Text = DataGridView_bangDiem.CurrentRow.Cells["CourseName"].Value.ToString();
            textBox_diemTB.Text = DataGridView_bangDiem.CurrentRow.Cells["Score"].Value.ToString();
            textBox_hocLuc.Text = DataGridView_bangDiem.CurrentRow.Cells["Description"].Value.ToString();
        }
    }
}
