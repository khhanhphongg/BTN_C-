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
using DGVPrinterHelper;

namespace QLDiemTHPT
{
    public partial class FrmTraCuuThongKe : Form
    {
        ThongKeClass thongKe = new ThongKeClass();
        LopClass lop = new LopClass();
        MonHocClass monHoc = new MonHocClass();
        DGVPrinter printer = new DGVPrinter();

        public FrmTraCuuThongKe()
        {
            InitializeComponent();
        }

        private void FrmTraCuuThongKe_Load(object sender, EventArgs e)
        {
            DataTable bangLop = lop.getComboBox();
            DataRow dongTatCa = bangLop.NewRow();
            dongTatCa["ClassId"] = 0;
            dongTatCa["ClassName"] = "Tất cả các lớp";
            bangLop.Rows.InsertAt(dongTatCa, 0);
            comboBox_lop.DataSource = bangLop;
            comboBox_lop.DisplayMember = "ClassName";
            comboBox_lop.ValueMember = "ClassId";

            comboBox_mon.Items.Add("Tất cả");
            foreach (DataRow dong in monHoc.getAll().Rows)
                comboBox_mon.Items.Add(dong["CourseName"].ToString());
            comboBox_mon.SelectedIndex = 0;

            comboBox_hocLuc.Items.AddRange(new string[] { "Tất cả", "Xuất sắc", "Giỏi", "Khá", "Trung bình", "Yếu", "Chưa có điểm" });
            comboBox_hocLuc.SelectedIndex = 0;

            traCuu();
        }

        private int layMaLop()
        {
            if (comboBox_lop.SelectedValue == null)
                return 0;
            return Convert.ToInt32(comboBox_lop.SelectedValue);
        }

        private double layTuDiem()
        {
            double d;
            if (ChiTietDiemClass.tryParseDiem(textBox_tuDiem.Text, out d))
                return d;
            return 0;
        }

        private double layDenDiem()
        {
            double d;
            if (ChiTietDiemClass.tryParseDiem(textBox_denDiem.Text, out d))
                return d;
            return 10;
        }

        private void traCuu()
        {
            int maLop = layMaLop();
            string mon = comboBox_mon.Text;
            string hocLuc = comboBox_hocLuc.Text;
            double tuDiem = layTuDiem();
            double denDiem = layDenDiem();

            if (tuDiem > denDiem)
            {
                MessageBox.Show("Điểm từ phải nhỏ hơn hoặc bằng điểm đến", "Khoảng điểm không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable ketQua;
            if (radioButton_theoLop.Checked)
                ketQua = thongKe.thongKeTheoLop(maLop, mon, hocLuc, tuDiem, denDiem);
            else if (radioButton_theoMon.Checked)
                ketQua = thongKe.thongKeTheoMon(maLop, mon, hocLuc, tuDiem, denDiem);
            else if (radioButton_hocLuc.Checked)
                ketQua = thongKe.thongKeHocLuc(maLop, mon, hocLuc, tuDiem, denDiem);
            else if (radioButton_xepHang.Checked)
                ketQua = thongKe.xepHangHocSinh(maLop, mon, hocLuc, tuDiem, denDiem);
            else
            {
                ketQua = thongKe.traCuuChiTiet(maLop, mon, hocLuc, tuDiem, denDiem);
                DataGridView_ketQua.DataSource = ketQua;
                datTieuDeCotChiTiet();
                capNhatDaiTong(ketQua.Rows.Count, maLop, mon, hocLuc, tuDiem, denDiem);
                return;
            }
            DataGridView_ketQua.DataSource = ketQua;
            capNhatDaiTong(ketQua.Rows.Count, maLop, mon, hocLuc, tuDiem, denDiem);
        }

        private void datTieuDeCotChiTiet()
        {
            if (DataGridView_ketQua.Columns.Count < 7)
                return;
            DataGridView_ketQua.Columns["StudentId"].HeaderText = "Mã HS";
            DataGridView_ketQua.Columns["HoTen"].HeaderText = "Họ tên";
            DataGridView_ketQua.Columns["Lop"].HeaderText = "Lớp";
            DataGridView_ketQua.Columns["MonHoc"].HeaderText = "Môn học";
            DataGridView_ketQua.Columns["DiemTB"].HeaderText = "Điểm TB";
            DataGridView_ketQua.Columns["HocLuc"].HeaderText = "Học lực";
            DataGridView_ketQua.Columns["SoDauDiem"].HeaderText = "Số đầu điểm";
        }

        private void capNhatDaiTong(int soDong, int maLop, string mon, string hocLuc, double tuDiem, double denDiem)
        {
            label_soLuot.Text = "Số lượt điểm : " + thongKe.demLuotDiem(maLop, mon, hocLuc, tuDiem, denDiem);
            label_diemTBChung.Text = "Điểm trung bình chung : " + thongKe.diemTBChung(maLop, mon, hocLuc, tuDiem, denDiem);
            label_soDong.Text = "Số dòng kết quả : " + soDong;
        }

        private void button_traCuu_Click(object sender, EventArgs e)
        {
            traCuu();
        }

        private void radioButton_kieu_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
                traCuu();
        }

        private void button_inNhanh_Click(object sender, EventArgs e)
        {
            if (DataGridView_ketQua.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu để in", "In nhanh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            printer.Title = "TRƯỜNG THPT MDEMY - THỐNG KÊ HỌC TẬP";
            printer.SubTitle = "Ngày in: " + DateTime.Now.ToString("dd/MM/yyyy");
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Bài tập nhóm - Nhóm 4";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_ketQua);
        }

        private void button_baoCao_Click(object sender, EventArgs e)
        {
            double tuDiem = layTuDiem();
            double denDiem = layDenDiem();
            if (tuDiem > denDiem)
            {
                MessageBox.Show("Điểm từ phải nhỏ hơn hoặc bằng điểm đến", "Khoảng điểm không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmBaoCao baoCao = new FrmBaoCao(layMaLop(), comboBox_lop.Text, comboBox_mon.Text, comboBox_hocLuc.Text, tuDiem, denDiem);
            baoCao.ShowDialog();
        }
    }
}
