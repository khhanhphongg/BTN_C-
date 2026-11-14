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
    public partial class FrmHocKy : Form
    {
        HocKyClass hocKy = new HocKyClass();
        public FrmHocKy()
        {
            InitializeComponent();
        }

        private void FrmHocKy_Load(object sender, EventArgs e)
        {
            hienBang();
        }

        private void hienBang()
        {
            DataGridView_hocKy.DataSource = hocKy.getAll();
            datTieuDeCot();
        }

        private void datTieuDeCot()
        {
            if (DataGridView_hocKy.Columns.Count < 4)
                return;
            DataGridView_hocKy.Columns["SemesterId"].HeaderText = "Mã HK";
            DataGridView_hocKy.Columns["SemesterName"].HeaderText = "Tên học kỳ";
            DataGridView_hocKy.Columns["StartDate"].HeaderText = "Ngày bắt đầu";
            DataGridView_hocKy.Columns["EndDate"].HeaderText = "Ngày kết thúc";
        }

        //kiểm tra dữ liệu, ngày kết thúc phải sau ngày bắt đầu
        private bool kiemTra()
        {
            if (textBox_tenHK.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập tên học kỳ", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dateTimePicker_ketThuc.Value.Date <= dateTimePicker_batDau.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu", "Ngày không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (!kiemTra())
                return;
            if (hocKy.insertHocKy(textBox_tenHK.Text.Trim(), dateTimePicker_batDau.Value, dateTimePicker_ketThuc.Value))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã thêm học kỳ mới", "Thêm học kỳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thêm được, tên học kỳ này đã tồn tại", "Thêm học kỳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maHK;
            if (!int.TryParse(textBox_maHK.Text, out maHK))
            {
                MessageBox.Show("Hãy chọn một học kỳ trong bảng trước", "Sửa học kỳ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kiemTra())
                return;
            if (hocKy.updateHocKy(maHK, textBox_tenHK.Text.Trim(), dateTimePicker_batDau.Value, dateTimePicker_ketThuc.Value))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã sửa học kỳ", "Sửa học kỳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được, tên học kỳ này đã tồn tại", "Sửa học kỳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maHK;
            if (!int.TryParse(textBox_maHK.Text, out maHK))
            {
                MessageBox.Show("Hãy chọn một học kỳ trong bảng trước", "Xoá học kỳ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá học kỳ này?", "Xoá học kỳ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (hocKy.deleteHocKy(maHK))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá học kỳ", "Xoá học kỳ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được vì học kỳ này đang có điểm, thời khoá biểu hoặc học phí", "Xoá học kỳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maHK.Clear();
            textBox_tenHK.Clear();
            textBox_timKiem.Clear();
            dateTimePicker_batDau.Value = DateTime.Now;
            dateTimePicker_ketThuc.Value = DateTime.Now.AddMonths(4);
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_hocKy.DataSource = hocKy.searchHocKy(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        private void DataGridView_hocKy_Click(object sender, EventArgs e)
        {
            if (DataGridView_hocKy.CurrentRow == null || DataGridView_hocKy.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maHK.Text = DataGridView_hocKy.CurrentRow.Cells["SemesterId"].Value.ToString();
            textBox_tenHK.Text = DataGridView_hocKy.CurrentRow.Cells["SemesterName"].Value.ToString();
            dateTimePicker_batDau.Value = Convert.ToDateTime(DataGridView_hocKy.CurrentRow.Cells["StartDate"].Value);
            dateTimePicker_ketThuc.Value = Convert.ToDateTime(DataGridView_hocKy.CurrentRow.Cells["EndDate"].Value);
        }
    }
}
