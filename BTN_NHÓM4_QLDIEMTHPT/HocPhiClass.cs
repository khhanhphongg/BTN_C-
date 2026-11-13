using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng tuition (học phí mỗi học kỳ: Paid đã đóng, Unpaid chưa đóng)
    class HocPhiClass : DuLieuClass
    {
        //hai trạng thái học phí
        public static string[] cacTrangThai = { "Paid", "Unpaid" };

        //hàm đổi trạng thái sang tiếng Việt để hiện lên form
        public static string trangThaiTiengViet(string trangThai)
        {
            if (trangThai == "Paid") return "Đã đóng";
            if (trangThai == "Unpaid") return "Chưa đóng";
            return trangThai;
        }

        //hàm thêm một dòng học phí, chưa đóng thì ngày đóng để trống
        public bool insertHocPhi(int maHS, int maHK, int soTien, DateTime? ngayDong, string trangThai)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `tuition`(`StudentId`, `SemesterId`, `Amount`, `PaidDate`, `Status`) VALUES (@mhs,@mhk,@st,@nd,@tt)");
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@mhk", MySqlDbType.Int32).Value = maHK;
            command.Parameters.Add("@st", MySqlDbType.Int32).Value = soTien;
            command.Parameters.Add("@nd", MySqlDbType.Date).Value = ngayDong.HasValue ? (object)ngayDong.Value : DBNull.Value;
            command.Parameters.Add("@tt", MySqlDbType.VarChar).Value = trangThai;
            return run(command, 1062, 1452);
        }

        //hàm sửa một dòng học phí
        public bool updateHocPhi(int maHP, int maHS, int maHK, int soTien, DateTime? ngayDong, string trangThai)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `tuition` SET `StudentId`=@mhs,`SemesterId`=@mhk,`Amount`=@st,`PaidDate`=@nd,`Status`=@tt WHERE `TuitionId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maHP;
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@mhk", MySqlDbType.Int32).Value = maHK;
            command.Parameters.Add("@st", MySqlDbType.Int32).Value = soTien;
            command.Parameters.Add("@nd", MySqlDbType.Date).Value = ngayDong.HasValue ? (object)ngayDong.Value : DBNull.Value;
            command.Parameters.Add("@tt", MySqlDbType.VarChar).Value = trangThai;
            return run(command, 1062, 1452);
        }

        //hàm xoá một dòng học phí
        public bool deleteHocPhi(int maHP)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `tuition` WHERE `TuitionId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maHP;
            return run(command, 1062, 1452);
        }

        //câu select dùng chung: học phí kèm họ tên học sinh, tên lớp, tên học kỳ
        private const string SELECT_HP =
            "SELECT tuition.TuitionId, CONCAT(student.StdLastName,' ',student.StdFirstName) AS HoTen, " +
            "IFNULL(class.ClassName,'Chưa xếp lớp') AS ClassName, semester.SemesterName, " +
            "tuition.Amount, tuition.PaidDate, tuition.Status, tuition.StudentId, tuition.SemesterId " +
            "FROM tuition " +
            "INNER JOIN student ON tuition.StudentId = student.StdId " +
            "INNER JOIN semester ON tuition.SemesterId = semester.SemesterId " +
            "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
            "LEFT JOIN class ON student_class.ClassId = class.ClassId";

        //hàm lấy toàn bộ học phí
        public DataTable getAll()
        {
            return getList(new MySqlCommand(SELECT_HP + " ORDER BY tuition.SemesterId DESC, tuition.TuitionId"));
        }

        //hàm tìm theo họ tên, lớp, học kỳ hoặc trạng thái
        public DataTable searchHocPhi(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand(SELECT_HP + " WHERE CONCAT(student.StdLastName, student.StdFirstName, IFNULL(class.ClassName,''), semester.SemesterName, tuition.Status) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        //hàm thống kê thu học phí theo học kỳ
        public DataTable thongKeHocPhi()
        {
            return getList(new MySqlCommand(
                "SELECT semester.SemesterName AS `Học kỳ`, COUNT(*) AS `Số học sinh`, " +
                "SUM(CASE WHEN tuition.Status='Paid' THEN 1 ELSE 0 END) AS `Đã đóng`, " +
                "SUM(CASE WHEN tuition.Status='Unpaid' THEN 1 ELSE 0 END) AS `Chưa đóng`, " +
                "SUM(CASE WHEN tuition.Status='Paid' THEN tuition.Amount ELSE 0 END) AS `Tiền đã thu`, " +
                "SUM(CASE WHEN tuition.Status='Unpaid' THEN tuition.Amount ELSE 0 END) AS `Tiền còn nợ` " +
                "FROM tuition INNER JOIN semester ON tuition.SemesterId = semester.SemesterId " +
                "GROUP BY semester.SemesterId, semester.SemesterName ORDER BY semester.SemesterId"));
        }

        //hàm tính tổng tiền đã thu
        public string tongTienDaThu()
        {
            MySqlCommand command = new MySqlCommand("SELECT IFNULL(SUM(Amount),0) FROM tuition WHERE Status='Paid'");
            return tinhMotGiaTri(command);
        }

        //hàm đọc số tiền người dùng nhập, bỏ dấu chấm phẩy phân cách
        public static bool tryParseTien(string text, out int value)
        {
            text = text.Trim().Replace(".", "").Replace(",", "").Replace(" ", "");
            return int.TryParse(text, out value) && value >= 0;
        }
    }
}
