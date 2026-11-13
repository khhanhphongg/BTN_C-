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
    public partial class FrmMonHoc : Form
    {
        MonHocClass monHoc = new MonHocClass();
        public FrmMonHoc()
        {
            InitializeComponent();
        }

        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            hienBang();
        }

        private void hienBang()
        {
            DataGridView_monHoc.DataSource = monHoc.getAll();
            datTieuDeCot();
        }

        private void datTieuDeCot()
        {
            if (DataGridView_monHoc.Columns.Count < 4)
                return;
            DataGridView_monHoc.Columns["CourseId"].HeaderText = "Mã môn";
            DataGridView_monHoc.Columns["CourseName"].HeaderText = "Tên môn học";
            DataGridView_monHoc.Columns["CourseHour"].HeaderText = "Số tiết";
            DataGridView_monHoc.Columns["Description"].HeaderText = "Mô tả";
        }

        //kiểm tra dữ liệu, số tiết phải là số nguyên dương
        private bool kiemTra(out int soTiet)
        {
            soTiet = 0;
            if (textBox_tenMon.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập tên môn học", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(textBox_soTiet.Text.Trim(), out soTiet) || soTiet <= 0)
            {
                MessageBox.Show("Số tiết phải là số nguyên lớn hơn 0", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            int soTiet;
            if (!kiemTra(out soTiet))
                return;
            if (monHoc.insertMonHoc(textBox_tenMon.Text.Trim(), soTiet, textBox_moTa.Text.Trim()))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã thêm môn học mới", "Thêm môn học", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thêm được, tên môn học này đã tồn tại", "Thêm môn học", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maMon, soTiet;
            if (!int.TryParse(textBox_maMon.Text, out maMon))
            {
                MessageBox.Show("Hãy chọn một môn học trong bảng trước", "Sửa môn học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kiemTra(out soTiet))
                return;
            if (monHoc.updateMonHoc(maMon, textBox_tenMon.Text.Trim(), soTiet, textBox_moTa.Text.Trim()))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã sửa môn học", "Sửa môn học", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được, tên môn học này đã tồn tại", "Sửa môn học", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maMon;
            if (!int.TryParse(textBox_maMon.Text, out maMon))
            {
                MessageBox.Show("Hãy chọn một môn học trong bảng trước", "Xoá môn học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Xoá môn học sẽ xoá luôn toàn bộ điểm của môn này. Bạn có chắc không?", "Xoá môn học", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (monHoc.deleteMonHoc(maMon))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá môn học", "Xoá môn học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được môn học này", "Xoá môn học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maMon.Clear();
            textBox_tenMon.Clear();
            textBox_soTiet.Clear();
            textBox_moTa.Clear();
            textBox_timKiem.Clear();
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_monHoc.DataSource = monHoc.searchMonHoc(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        //click vào một dòng thì đổ dữ liệu lên các ô nhập
        private void DataGridView_monHoc_Click(object sender, EventArgs e)
        {
            if (DataGridView_monHoc.CurrentRow == null || DataGridView_monHoc.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maMon.Text = DataGridView_monHoc.CurrentRow.Cells["CourseId"].Value.ToString();
            textBox_tenMon.Text = DataGridView_monHoc.CurrentRow.Cells["CourseName"].Value.ToString();
            textBox_soTiet.Text = DataGridView_monHoc.CurrentRow.Cells["CourseHour"].Value.ToString();
            textBox_moTa.Text = DataGridView_monHoc.CurrentRow.Cells["Description"].Value.ToString();
        }
    }
}
