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
    public partial class FrmPhongHoc : Form
    {
        PhongHocClass phongHoc = new PhongHocClass();
        public FrmPhongHoc()
        {
            InitializeComponent();
        }

        private void FrmPhongHoc_Load(object sender, EventArgs e)
        {
            hienBang();
        }

        //hàm đổ danh sách phòng học lên lưới
        private void hienBang()
        {
            DataGridView_phongHoc.DataSource = phongHoc.getAll();
            datTieuDeCot();
        }

        private void datTieuDeCot()
        {
            if (DataGridView_phongHoc.Columns.Count < 3)
                return;
            DataGridView_phongHoc.Columns["RoomId"].HeaderText = "Mã phòng";
            DataGridView_phongHoc.Columns["RoomName"].HeaderText = "Tên phòng";
            DataGridView_phongHoc.Columns["Capacity"].HeaderText = "Sức chứa";
        }

        //hàm kiểm tra dữ liệu, sức chứa phải là số nguyên dương
        private bool kiemTra(out int sucChua)
        {
            sucChua = 0;
            if (textBox_tenPhong.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập tên phòng", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(textBox_sucChua.Text.Trim(), out sucChua) || sucChua <= 0)
            {
                MessageBox.Show("Sức chứa phải là số nguyên lớn hơn 0", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            int sucChua;
            if (!kiemTra(out sucChua))
                return;
            if (phongHoc.insertPhong(textBox_tenPhong.Text.Trim(), sucChua))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã thêm phòng học mới", "Thêm phòng học", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thêm được, tên phòng này đã tồn tại", "Thêm phòng học", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int maPhong, sucChua;
            if (!int.TryParse(textBox_maPhong.Text, out maPhong))
            {
                MessageBox.Show("Hãy chọn một phòng trong bảng trước", "Sửa phòng học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!kiemTra(out sucChua))
                return;
            if (phongHoc.updatePhong(maPhong, textBox_tenPhong.Text.Trim(), sucChua))
            {
                hienBang();
                button_lamMoi.PerformClick();
                MessageBox.Show("Đã sửa phòng học", "Sửa phòng học", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không sửa được, tên phòng này đã tồn tại", "Sửa phòng học", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            int maPhong;
            if (!int.TryParse(textBox_maPhong.Text, out maPhong))
            {
                MessageBox.Show("Hãy chọn một phòng trong bảng trước", "Xoá phòng học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá phòng học này?", "Xoá phòng học", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (phongHoc.deletePhong(maPhong))
                {
                    hienBang();
                    button_lamMoi.PerformClick();
                    MessageBox.Show("Đã xoá phòng học", "Xoá phòng học", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không xoá được vì phòng này đang có trong thời khoá biểu", "Xoá phòng học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_lamMoi_Click(object sender, EventArgs e)
        {
            textBox_maPhong.Clear();
            textBox_tenPhong.Clear();
            textBox_sucChua.Clear();
            textBox_timKiem.Clear();
        }

        private void button_timKiem_Click(object sender, EventArgs e)
        {
            DataGridView_phongHoc.DataSource = phongHoc.searchPhong(textBox_timKiem.Text.Trim());
            datTieuDeCot();
        }

        private void DataGridView_phongHoc_Click(object sender, EventArgs e)
        {
            if (DataGridView_phongHoc.CurrentRow == null || DataGridView_phongHoc.CurrentRow.Cells[0].Value == null)
                return;
            textBox_maPhong.Text = DataGridView_phongHoc.CurrentRow.Cells["RoomId"].Value.ToString();
            textBox_tenPhong.Text = DataGridView_phongHoc.CurrentRow.Cells["RoomName"].Value.ToString();
            textBox_sucChua.Text = DataGridView_phongHoc.CurrentRow.Cells["Capacity"].Value.ToString();
        }
    }
}
