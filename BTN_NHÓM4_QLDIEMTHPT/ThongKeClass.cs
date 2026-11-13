using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    /*
     * Lớp này chứa các câu truy vấn tra cứu và thống kê tình hình học tập.
     * Hàm layDuLieuBaoCao trả về đúng cấu trúc bảng BaoCaoDiem mô tả trong
     * file BaoCaoDiem.xsd, dùng làm nguồn dữ liệu cho Crystal Report.
     */
    class ThongKeClass
    {
        DBconnect connect = new DBconnect();

        //hàm chạy câu select bất kỳ
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //câu select chi tiết: bảng điểm kèm họ tên, lớp, khoa
        private const string SELECT_CHITIET =
            "SELECT score.StudentId, CONCAT(student.StdLastName,' ',student.StdFirstName) AS HoTen, " +
            "IFNULL(class.ClassName,'Chưa xếp lớp') AS Lop, score.CourseName AS MonHoc, " +
            "score.Score AS DiemTB, score.Description AS HocLuc, " +
            "(SELECT COUNT(*) FROM diem_chitiet d WHERE d.StudentId = score.StudentId AND d.CourseName = score.CourseName) AS SoDauDiem " +
            "FROM score " +
            "INNER JOIN student ON score.StudentId = student.StdId " +
            "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
            "LEFT JOIN class ON student_class.ClassId = class.ClassId";

        /*
         * Hàm ghép điều kiện lọc dùng chung cho mọi thống kê:
         *   maLop = 0      -> tất cả các lớp
         *   tenMon rỗng    -> tất cả các môn
         *   hocLuc rỗng    -> tất cả học lực
         *   luôn lọc theo khoảng điểm tuDiem..denDiem
         */
        private MySqlCommand taoLenhLoc(string select, int maLop, string tenMon, string hocLuc, double tuDiem, double denDiem, string phanCuoi)
        {
            string dieuKien = " WHERE score.Score BETWEEN @td AND @dd";
            if (maLop > 0)
                dieuKien += " AND student_class.ClassId = @ml";
            if (tenMon != "" && tenMon != "Tất cả")
                dieuKien += " AND score.CourseName = @tm";
            if (hocLuc != "" && hocLuc != "Tất cả")
                dieuKien += " AND score.Description = @hl";

            MySqlCommand command = new MySqlCommand(select + dieuKien + phanCuoi);
            command.Parameters.AddWithValue("@td", tuDiem);
            command.Parameters.AddWithValue("@dd", denDiem);
            if (maLop > 0)
                command.Parameters.AddWithValue("@ml", maLop);
            if (tenMon != "" && tenMon != "Tất cả")
                command.Parameters.AddWithValue("@tm", tenMon);
            if (hocLuc != "" && hocLuc != "Tất cả")
                command.Parameters.AddWithValue("@hl", hocLuc);
            return command;
        }

        //1. Tra cứu chi tiết: liệt kê từng môn của từng học sinh
        public DataTable traCuuChiTiet(int maLop, string tenMon, string hocLuc, double tuDiem, double denDiem)
        {
            return getList(taoLenhLoc(SELECT_CHITIET, maLop, tenMon, hocLuc, tuDiem, denDiem, " ORDER BY Lop, HoTen, MonHoc"));
        }

        //2. Thống kê theo lớp: mỗi lớp có bao nhiêu học sinh ở từng mức học lực
        public DataTable thongKeTheoLop(int maLop, string tenMon, string hocLuc, double tuDiem, double denDiem)
        {
            string select =
                "SELECT IFNULL(class.ClassName,'Chưa xếp lớp') AS `Lớp`, " +
                "COUNT(DISTINCT score.StudentId) AS `Số học sinh`, " +
                "ROUND(AVG(score.Score),2) AS `Điểm TB`, " +
                "SUM(CASE WHEN score.Score >= 8 THEN 1 ELSE 0 END) AS `Lượt giỏi`, " +
                "SUM(CASE WHEN score.Score >= 6.5 AND score.Score < 8 THEN 1 ELSE 0 END) AS `Lượt khá`, " +
                "SUM(CASE WHEN score.Score >= 5 AND score.Score < 6.5 THEN 1 ELSE 0 END) AS `Lượt trung bình`, " +
                "SUM(CASE WHEN score.Score < 5 THEN 1 ELSE 0 END) AS `Lượt yếu` " +
                "FROM score " +
                "INNER JOIN student ON score.StudentId = student.StdId " +
                "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
                "LEFT JOIN class ON student_class.ClassId = class.ClassId";
            return getList(taoLenhLoc(select, maLop, tenMon, hocLuc, tuDiem, denDiem, " GROUP BY class.ClassId, class.ClassName ORDER BY `Điểm TB` DESC"));
        }

        //3. Thống kê theo môn học: môn nào điểm cao, môn nào điểm thấp
        public DataTable thongKeTheoMon(int maLop, string tenMon, string hocLuc, double tuDiem, double denDiem)
        {
            string select =
                "SELECT score.CourseName AS `Môn học`, " +
                "COUNT(*) AS `Số lượt điểm`, " +
                "ROUND(AVG(score.Score),2) AS `Điểm TB`, " +
                "MAX(score.Score) AS `Cao nhất`, " +
                "MIN(score.Score) AS `Thấp nhất`, " +
                "SUM(CASE WHEN score.Score < 5 THEN 1 ELSE 0 END) AS `Số lượt yếu` " +
                "FROM score " +
                "INNER JOIN student ON score.StudentId = student.StdId " +
                "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
                "LEFT JOIN class ON student_class.ClassId = class.ClassId";
            return getList(taoLenhLoc(select, maLop, tenMon, hocLuc, tuDiem, denDiem, " GROUP BY score.CourseName ORDER BY `Điểm TB` DESC"));
        }

        //4. Thống kê phân bố học lực
        public DataTable thongKeHocLuc(int maLop, string tenMon, string hocLuc, double tuDiem, double denDiem)
        {
            string select =
                "SELECT score.Description AS `Học lực`, COUNT(*) AS `Số lượt`, " +
                "ROUND(AVG(score.Score),2) AS `Điểm TB` " +
                "FROM score " +
                "INNER JOIN student ON score.StudentId = student.StdId " +
                "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
                "LEFT JOIN class ON student_class.ClassId = class.ClassId";
            return getList(taoLenhLoc(select, maLop, tenMon, hocLuc, tuDiem, denDiem, " GROUP BY score.Description ORDER BY `Điểm TB` DESC"));
        }

        //5. Xếp hạng học sinh theo điểm trung bình tất cả các môn
        public DataTable xepHangHocSinh(int maLop, string tenMon, string hocLuc, double tuDiem, double denDiem)
        {
            string select =
                "SELECT CONCAT(student.StdLastName,' ',student.StdFirstName) AS `Họ tên`, " +
                "IFNULL(class.ClassName,'Chưa xếp lớp') AS `Lớp`, " +
                "COUNT(*) AS `Số môn`, " +
                "ROUND(AVG(score.Score),2) AS `Điểm TB`, " +
                "SUM(CASE WHEN score.Score < 5 THEN 1 ELSE 0 END) AS `Môn yếu` " +
                "FROM score " +
                "INNER JOIN student ON score.StudentId = student.StdId " +
                "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
                "LEFT JOIN class ON student_class.ClassId = class.ClassId";
            return getList(taoLenhLoc(select, maLop, tenMon, hocLuc, tuDiem, denDiem, " GROUP BY student.StdId, student.StdLastName, student.StdFirstName, class.ClassName ORDER BY `Điểm TB` DESC"));
        }

        //hàm đếm số lượt điểm theo điều kiện lọc
        public string demLuotDiem(int maLop, string tenMon, string hocLuc, double tuDiem, double denDiem)
        {
            string select = "SELECT COUNT(*) FROM score " +
                "INNER JOIN student ON score.StudentId = student.StdId " +
                "LEFT JOIN student_class ON student.StdId = student_class.StudentId";
            MySqlCommand command = taoLenhLoc(select, maLop, tenMon, hocLuc, tuDiem, denDiem, "");
            command.Connection = connect.getconnection;
            connect.openConnect();
            string dem = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return dem;
        }

        //hàm tính điểm trung bình chung theo điều kiện lọc
        public string diemTBChung(int maLop, string tenMon, string hocLuc, double tuDiem, double denDiem)
        {
            string select = "SELECT IFNULL(ROUND(AVG(score.Score),2),0) FROM score " +
                "INNER JOIN student ON score.StudentId = student.StdId " +
                "LEFT JOIN student_class ON student.StdId = student_class.StudentId";
            MySqlCommand command = taoLenhLoc(select, maLop, tenMon, hocLuc, tuDiem, denDiem, "");
            command.Connection = connect.getconnection;
            connect.openConnect();
            string tb = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return tb;
        }

        /*
         * Hàm lấy dữ liệu cho Crystal Report.
         * Tên bảng và tên cột phải trùng khít với file BaoCaoDiem.xsd,
         * nếu đổi ở đây thì phải đổi cả trong file xsd và thiết kế lại report.
         */
        public DataTable layDuLieuBaoCao(int maLop, string tenMon, string hocLuc, double tuDiem, double denDiem)
        {
            DataTable table = traCuuChiTiet(maLop, tenMon, hocLuc, tuDiem, denDiem);
            table.TableName = "BaoCaoDiem";
            return table;
        }
    }
}
