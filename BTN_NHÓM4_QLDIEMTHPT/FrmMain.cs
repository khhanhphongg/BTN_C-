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
    public partial class FrmMain : Form
    {
        HocSinhClass hocSinh = new HocSinhClass();
        GiaoVienClass giaoVien = new GiaoVienClass();
        LopClass lop = new LopClass();
        MonHocClass monHoc = new MonHocClass();
        ThoiKhoaBieuClass tkb = new ThoiKhoaBieuClass();
        ThongKeClass thongKe = new ThongKeClass();

        //lưu người đang đăng nhập để hiện lên dải người dùng
        string hoTenNguoiDung = "";
        string vaiTroNguoiDung = "";

        public FrmMain(string hoTen, string vaiTro)
        {
            InitializeComponent();
            hoTenNguoiDung = hoTen;
            vaiTroNguoiDung = vaiTro;
            anHetSubmenu();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            label_user.Text = hoTenNguoiDung;
            label_role.Text = vaiTroNguoiDung;
            demSoLieu();
            comboBox_lop.DataSource = lop.getComboBox();
            comboBox_lop.DisplayMember = "ClassName";
            comboBox_lop.ValueMember = "ClassName";
        }

        //đếm và hiện các số liệu tổng quan trên trang chủ
        private void demSoLieu()
        {
            label_tongHS.Text = "Tổng học sinh : " + hocSinh.tongHocSinh();
            label_nam.Text = "Nam : " + hocSinh.hocSinhNam();
            label_nu.Text = "Nữ : " + hocSinh.hocSinhNu();
            label_tongGV.Text = "Tổng giáo viên : " + giaoVien.tongGiaoVien();
            label_tongLop.Text = "Số lớp : " + lop.tongLop();
            label_tongMon.Text = "Số môn học : " + monHoc.tongMonHoc();
            label_tongTiet.Text = "Số tiết TKB : " + tkb.tongTiet();
            label_diemTBTruong.Text = "Điểm TB toàn trường : " + thongKe.diemTBChung(0, "", "", 0, 10);
        }

        //khi chọn một lớp thì hiện số học sinh và điểm trung bình của lớp đó
        private void comboBox_lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_lop.SelectedValue == null)
                return;
            string tenLop = comboBox_lop.Text;
            label_lopHS.Text = "Học sinh : " + hocSinh.demTheoLop(tenLop);
            //lấy mã lớp đang chọn để tính điểm trung bình của lớp
            DataRowView dong = comboBox_lop.SelectedItem as DataRowView;
            if (dong != null)
                label_lopDiem.Text = "Điểm TB lớp : " + thongKe.diemTBChung(Convert.ToInt32(dong["ClassId"]), "", "", 0, 10);
        }

        //ẩn hết các submenu khi mới mở form
        private void anHetSubmenu()
        {
            panel_dmSubmenu.Visible = false;
            panel_nsSubmenu.Visible = false;
            panel_diemSubmenu.Visible = false;
            panel_khacSubmenu.Visible = false;
        }

        //bấm vào một nhóm thì mở submenu của nhóm đó và đóng các nhóm khác
        private void moSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                anHetSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void button_danhMuc_Click(object sender, EventArgs e)
        {
            moSubmenu(panel_dmSubmenu);
        }

        private void button_nhanSu_Click(object sender, EventArgs e)
        {
            moSubmenu(panel_nsSubmenu);
        }

        private void button_diem_Click(object sender, EventArgs e)
        {
            moSubmenu(panel_diemSubmenu);
        }

        private void button_khac_Click(object sender, EventArgs e)
        {
            moSubmenu(panel_khacSubmenu);
        }

        //mở form con trong panel giữa, mỗi lần chỉ mở một form
        private Form formDangMo = null;
        private void moFormCon(Form formCon)
        {
            if (formDangMo != null)
                formDangMo.Close();
            formDangMo = formCon;
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            panel_main.Controls.Add(formCon);
            panel_main.Tag = formCon;
            formCon.BringToFront();
            formCon.Show();
            anHetSubmenu();
        }

        //nhóm Danh mục
        private void button_khoa_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmKhoa());
        }

        private void button_monHoc_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmMonHoc());
        }

        private void button_phongHoc_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmPhongHoc());
        }

        private void button_hocKy_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmHocKy());
        }

        private void button_lop_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmLop());
        }

        //nhóm Học sinh - Giáo viên
        private void button_giaoVien_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmGiaoVien());
        }

        private void button_hocSinh_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmHocSinh());
        }

        //nhóm Quản lý điểm
        private void button_bangDiem_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmBangDiem());
        }

        private void button_chiTietDiem_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmChiTietDiem());
        }

        //nhóm Lớp - Trường
        private void button_tkb_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmThoiKhoaBieu());
        }

        private void button_diemDanh_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmDiemDanh());
        }

        private void button_hocPhi_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmHocPhi());
        }

        //tra cứu và thống kê
        private void button_thongKe_Click(object sender, EventArgs e)
        {
            moFormCon(new FrmTraCuuThongKe());
        }

        //về trang chủ: đóng form con và đếm lại số liệu
        private void button_trangChu_Click(object sender, EventArgs e)
        {
            if (formDangMo != null)
            {
                formDangMo.Close();
                formDangMo = null;
            }
            panel_main.Controls.Add(panel_cover);
            anHetSubmenu();
            demSoLieu();
        }

        //đăng xuất: quay về form đăng nhập
        private void button_dangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FrmLogin login = new FrmLogin();
                this.Hide();
                login.Show();
            }
        }
    }
}
