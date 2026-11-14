using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    /*
     * Quản lý bảng diem_chitiet. Mỗi dòng là một đầu điểm (miệng, 15 phút,
     * 1 tiết, thi) và có hệ số riêng. Sau mỗi lần thêm/sửa/xoá, hàm
     * capNhatDiemTB tính lại điểm trung bình môn rồi ghi vào bảng score.
     */
    class ChiTietDiemClass : DuLieuClass
    {
        public static string[] cacLoaiDiem = { "Miệng", "15 phút", "1 tiết", "Thi" };

        public bool insertChiTiet(int maHS, string tenMon, int maHK, string loaiDiem, double diem, int heSo, string ghiChu)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [diem_chitiet]([StudentId], [CourseName], [SemesterId], [LoaiDiem], [Diem], [HeSo], [GhiChu]) VALUES (@mhs,@tm,@mhk,@ld,@d,@hs,@gc)");
            command.Parameters.Add("@mhs", SqlDbType.Int).Value = maHS;
            command.Parameters.Add("@tm", SqlDbType.NVarChar).Value = tenMon;
            command.Parameters.Add("@mhk", SqlDbType.Int).Value = maHK;
            command.Parameters.Add("@ld", SqlDbType.NVarChar).Value = loaiDiem;
            command.Parameters.Add("@d", SqlDbType.Float).Value = diem;
            command.Parameters.Add("@hs", SqlDbType.Int).Value = heSo;
            command.Parameters.Add("@gc", SqlDbType.NVarChar).Value = ghiChu;
            if (run(command))
            {
                capNhatDiemTB(maHS, tenMon);
                return true;
            }
            return false;
        }

        public bool updateChiTiet(int maCT, int maHK, string loaiDiem, double diem, int heSo, string ghiChu, int maHS, string tenMon)
        {
            SqlCommand command = new SqlCommand("UPDATE [diem_chitiet] SET [SemesterId]=@mhk,[LoaiDiem]=@ld,[Diem]=@d,[HeSo]=@hs,[GhiChu]=@gc WHERE [MaCT]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maCT;
            command.Parameters.Add("@mhk", SqlDbType.Int).Value = maHK;
            command.Parameters.Add("@ld", SqlDbType.NVarChar).Value = loaiDiem;
            command.Parameters.Add("@d", SqlDbType.Float).Value = diem;
            command.Parameters.Add("@hs", SqlDbType.Int).Value = heSo;
            command.Parameters.Add("@gc", SqlDbType.NVarChar).Value = ghiChu;
            if (run(command))
            {
                capNhatDiemTB(maHS, tenMon);
                return true;
            }
            return false;
        }

        public bool deleteChiTiet(int maCT, int maHS, string tenMon)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [diem_chitiet] WHERE [MaCT]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maCT;
            if (run(command))
            {
                capNhatDiemTB(maHS, tenMon);
                return true;
            }
            return false;
        }

        public DataTable getChiTiet(int maHS, string tenMon)
        {
            SqlCommand command = new SqlCommand(
                "SELECT diem_chitiet.MaCT, diem_chitiet.LoaiDiem, diem_chitiet.Diem, diem_chitiet.HeSo, " +
                "semester.SemesterName, diem_chitiet.GhiChu, diem_chitiet.SemesterId " +
                "FROM diem_chitiet INNER JOIN semester ON diem_chitiet.SemesterId = semester.SemesterId " +
                "WHERE diem_chitiet.StudentId=@mhs AND diem_chitiet.CourseName=@tm ORDER BY diem_chitiet.MaCT");
            command.Parameters.AddWithValue("@mhs", maHS);
            command.Parameters.AddWithValue("@tm", tenMon);
            return getList(command);
        }

        //tính điểm trung bình môn = SUM(Diem * HeSo) / SUM(HeSo)
        public double tinhTrungBinh(int maHS, string tenMon)
        {
            return tinhTrungBinh(getChiTiet(maHS, tenMon));
        }

        //tính điểm trung bình từ bảng đầu điểm đã lấy sẵn
        private double tinhTrungBinh(DataTable table)
        {
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

        //tính lại điểm trung bình môn và học lực rồi ghi vào bảng score
        public void capNhatDiemTB(int maHS, string tenMon)
        {
            DataTable table = getChiTiet(maHS, tenMon);
            //môn chưa có đầu điểm nào thì để điểm 0
            double tb = 0;
            string hocLuc = "Chưa có điểm";
            if (table.Rows.Count > 0)
            {
                tb = tinhTrungBinh(table);
                hocLuc = xepLoai(tb);
            }
            SqlCommand command = new SqlCommand("UPDATE [score] SET [Score]=@d,[Description]=@hl WHERE [StudentId]=@mhs AND [CourseName]=@tm");
            command.Parameters.AddWithValue("@d", tb);
            command.Parameters.AddWithValue("@hl", hocLuc);
            command.Parameters.AddWithValue("@mhs", maHS);
            command.Parameters.AddWithValue("@tm", tenMon);
            runNhieuDong(command);
        }

        //xếp loại học lực theo điểm trung bình môn
        public static string xepLoai(double diem)
        {
            if (diem >= 9) return "Xuất sắc";
            if (diem >= 8) return "Giỏi";
            if (diem >= 6.5) return "Khá";
            if (diem >= 5) return "Trung bình";
            return "Yếu";
        }

        //đọc điểm người dùng nhập, nhận cả 8.5 và 8,5, phải từ 0 đến 10
        public static bool tryParseDiem(string text, out double value)
        {
            value = 0;
            text = text.Trim().Replace(',', '.');
            if (!double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                return false;
            if (value < 0 || value > 10)
                return false;
            return true;
        }
    }
}
