using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    /*
     * Quản lý bảng diem_chitiet - phần CHI TIẾT của bảng điểm.
     * Mỗi dòng là một đầu điểm (miệng, 15 phút, 1 tiết, thi) có hệ số riêng.
     * Sau mỗi lần thêm/sửa/xoá, hàm capNhatDiemTB tính lại điểm trung bình môn
     * theo công thức SUM(Diem * HeSo) / SUM(HeSo) rồi ghi vào bảng score.
     */
    class ChiTietDiemClass : DuLieuClass
    {
        //bốn loại đầu điểm của bậc THPT, dùng để đổ vào combobox
        public static string[] cacLoaiDiem = { "Miệng", "15 phút", "1 tiết", "Thi" };

        //hàm thêm một đầu điểm
        public bool insertChiTiet(int maHS, string tenMon, int maHK, string loaiDiem, double diem, int heSo, string ghiChu)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `diem_chitiet`(`StudentId`, `CourseName`, `SemesterId`, `LoaiDiem`, `Diem`, `HeSo`, `GhiChu`) VALUES (@mhs,@tm,@mhk,@ld,@d,@hs,@gc)");
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@tm", MySqlDbType.VarChar).Value = tenMon;
            command.Parameters.Add("@mhk", MySqlDbType.Int32).Value = maHK;
            command.Parameters.Add("@ld", MySqlDbType.VarChar).Value = loaiDiem;
            command.Parameters.Add("@d", MySqlDbType.Double).Value = diem;
            command.Parameters.Add("@hs", MySqlDbType.Int32).Value = heSo;
            command.Parameters.Add("@gc", MySqlDbType.VarChar).Value = ghiChu;
            if (run(command))
            {
                capNhatDiemTB(maHS, tenMon);
                return true;
            }
            return false;
        }

        //hàm sửa một đầu điểm
        public bool updateChiTiet(int maCT, int maHK, string loaiDiem, double diem, int heSo, string ghiChu, int maHS, string tenMon)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `diem_chitiet` SET `SemesterId`=@mhk,`LoaiDiem`=@ld,`Diem`=@d,`HeSo`=@hs,`GhiChu`=@gc WHERE `MaCT`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maCT;
            command.Parameters.Add("@mhk", MySqlDbType.Int32).Value = maHK;
            command.Parameters.Add("@ld", MySqlDbType.VarChar).Value = loaiDiem;
            command.Parameters.Add("@d", MySqlDbType.Double).Value = diem;
            command.Parameters.Add("@hs", MySqlDbType.Int32).Value = heSo;
            command.Parameters.Add("@gc", MySqlDbType.VarChar).Value = ghiChu;
            if (run(command))
            {
                capNhatDiemTB(maHS, tenMon);
                return true;
            }
            return false;
        }

        //hàm xoá một đầu điểm
        public bool deleteChiTiet(int maCT, int maHS, string tenMon)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `diem_chitiet` WHERE `MaCT`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maCT;
            if (run(command))
            {
                capNhatDiemTB(maHS, tenMon);
                return true;
            }
            return false;
        }

        //hàm lấy các đầu điểm của một môn của một học sinh
        public DataTable getChiTiet(int maHS, string tenMon)
        {
            MySqlCommand command = new MySqlCommand(
                "SELECT diem_chitiet.MaCT, diem_chitiet.LoaiDiem, diem_chitiet.Diem, diem_chitiet.HeSo, " +
                "semester.SemesterName, diem_chitiet.GhiChu, diem_chitiet.SemesterId " +
                "FROM diem_chitiet INNER JOIN semester ON diem_chitiet.SemesterId = semester.SemesterId " +
                "WHERE diem_chitiet.StudentId=@mhs AND diem_chitiet.CourseName=@tm ORDER BY diem_chitiet.MaCT");
            command.Parameters.AddWithValue("@mhs", maHS);
            command.Parameters.AddWithValue("@tm", tenMon);
            return getList(command);
        }

        /*
         * Hàm tính lại điểm trung bình môn và học lực rồi ghi vào bảng score.
         * Môn chưa có đầu điểm nào thì điểm trung bình để 0 và học lực là
         * "Chưa có điểm".
         */
        public void capNhatDiemTB(int maHS, string tenMon)
        {
            MySqlCommand lenhTinh = new MySqlCommand(
                "SELECT IFNULL(SUM(Diem*HeSo)/SUM(HeSo), -1) FROM diem_chitiet WHERE StudentId=@mhs AND CourseName=@tm",
                connect.getconnection);
            lenhTinh.Parameters.AddWithValue("@mhs", maHS);
            lenhTinh.Parameters.AddWithValue("@tm", tenMon);
            try
            {
                connect.openConnect();
                double tb = Convert.ToDouble(lenhTinh.ExecuteScalar());
                string hocLuc;
                if (tb < 0)
                {
                    tb = 0;
                    hocLuc = "Chưa có điểm";
                }
                else
                {
                    tb = Math.Round(tb, 1);
                    hocLuc = xepLoai(tb);
                }
                MySqlCommand lenhGhi = ganKetNoi(new MySqlCommand("UPDATE `score` SET `Score`=@d,`Description`=@hl WHERE `StudentId`=@mhs AND `CourseName`=@tm"));
                lenhGhi.Parameters.AddWithValue("@d", tb);
                lenhGhi.Parameters.AddWithValue("@hl", hocLuc);
                lenhGhi.Parameters.AddWithValue("@mhs", maHS);
                lenhGhi.Parameters.AddWithValue("@tm", tenMon);
                lenhGhi.ExecuteNonQuery();
            }
            finally
            {
                connect.closeConnect();
            }
        }

        //hàm xếp loại học lực theo điểm trung bình môn
        public static string xepLoai(double diem)
        {
            if (diem >= 9) return "Xuất sắc";
            if (diem >= 8) return "Giỏi";
            if (diem >= 6.5) return "Khá";
            if (diem >= 5) return "Trung bình";
            return "Yếu";
        }

        //hàm đọc điểm người dùng nhập, nhận cả 8.5 và 8,5, phải từ 0 đến 10
        public static bool tryParseDiem(string text, out double value)
        {
            text = text.Trim().Replace(',', '.');
            return double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value) && value >= 0 && value <= 10;
        }

        //hàm tính điểm trung bình môn đang hiện trên form (tính trước khi lưu)
        public double tinhTrungBinh(int maHS, string tenMon)
        {
            DataTable table = getChiTiet(maHS, tenMon);
            double tongDiem = 0;
            int tongHeSo = 0;
            foreach (DataRow dong in table.Rows)
            {
                tongDiem += Convert.ToDouble(dong["Diem"]) * Convert.ToInt32(dong["HeSo"]);
                tongHeSo += Convert.ToInt32(dong["HeSo"]);
            }
            if (tongHeSo == 0)
                return 0;
            return Math.Round(tongDiem / tongHeSo, 1);
        }
    }
}
