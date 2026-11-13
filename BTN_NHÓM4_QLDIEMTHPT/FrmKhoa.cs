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
    public partial class FrmKhoa : Form
    {
        KhoaClass khoa = new KhoaClass();
        public FrmKhoa()
        {
            InitializeComponent();
        }

        private void FrmKhoa_Load(object sender, EventArgs e)
        {
            hienBang();
        }

        //hàm đổ danh sách khoa lên lưới
        private void hienBang()
        {
            DataGridView_khoa.DataSource = khoa.getAll();
            datTieuDeCot();
        }

        //hàm đặt tiêu đề cột tiếng Việt
        private void datTieuDeCot()
        {
            if (DataGridView_khoa.Columns.Count < 3)
                return;
            DataGridView_khoa.Columns["DeptId"].HeaderText = "Mã khoa";
            DataGridView_khoa.Columns["DeptName"].HeaderText = "Tên khoa";
            DataGridView_khoa.Columns["Description"].HeaderText = "Mô tả";
        }

        //hàm kiểm tra dữ liệu bắt buộc
        private bool kiemTra()
        {
            if (textBox_tenKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập tên khoa", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if (!kiemTra())
                return;
            if (khoa.insertKhoa(textBox_tenKhoa.Text.Trim(), textBox_moTa.Text.Trim()))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã thêm khoa mới", "Thêm khoa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thêm được, tên khoa này đã tồn tại", "Thêm khoa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maKhoa;
            if (!int.TryParse(textBox_maKhoa.Text, out maKhoa))
            {
                MessageBox.Show("Hãy chọn một khoa trong bảng trước", "Sửa khoa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kiemTra())
                return;
            if (khoa.updateKhoa(maKhoa, textBox_tenKhoa.Text.Trim(), textBox_moTa.Text.Trim()))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã sửa thông tin khoa", "Sửa khoa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được, tên khoa này đã tồn tại", "Sửa khoa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maKhoa;
            if (!int.TryParse(textBox_maKhoa.Text, out maKhoa))
            {
                MessageBox.Show("Hãy chọn một khoa trong bảng trước", "Xoá khoa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá khoa này?", "Xoá khoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (khoa.deleteKhoa(maKhoa))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá khoa", "Xoá khoa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được vì khoa này đang có giáo viên hoặc lớp", "Xoá khoa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maKhoa.Clear();
            textBox_tenKhoa.Clear();
            textBox_moTa.Clear();
            textBox_timKiem.Clear();
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_khoa.DataSource = khoa.searchKhoa(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        //click vào một dòng thì đổ dữ liệu lên các ô nhập
        private void DataGridView_khoa_Click(object sender, EventArgs e)
        {
            if (DataGridView_khoa.CurrentRow == null || DataGridView_khoa.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maKhoa.Text = DataGridView_khoa.CurrentRow.Cells["DeptId"].Value.ToString();
            textBox_tenKhoa.Text = DataGridView_khoa.CurrentRow.Cells["DeptName"].Value.ToString();
            textBox_moTa.Text = DataGridView_khoa.CurrentRow.Cells["Description"].Value.ToString();
        }
    }
}
