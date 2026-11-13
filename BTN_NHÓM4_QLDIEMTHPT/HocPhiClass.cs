using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng tuition (học phí mỗi học kỳ)
    class HocPhiClass : DuLieuClass
    {
        //hai trạng thái học phí
        public static string[] cacTrangThai = { "Đã đóng", "Chưa đóng" };

        //thêm một dòng học phí, chưa đóng thì ngày đóng để trống
        public bool insertHocPhi(int maHS, int maHK, int soTien, DateTime? ngayDong, string trangThai)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `tuition`(`StudentId`, `SemesterId`, `Amount`, `PaidDate`, `Status`) VALUES (@mhs,@mhk,@st,@nd,@tt)");
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@mhk", MySqlDbType.Int32).Value = maHK;
            command.Parameters.Add("@st", MySqlDbType.Int32).Value = soTien;
            command.Parameters.Add("@tt", MySqlDbType.VarChar).Value = trangThai;
            if (ngayDong.HasValue)
                command.Parameters.Add("@nd", MySqlDbType.Date).Value = ngayDong.Value;
            else
                command.Parameters.Add("@nd", MySqlDbType.Date).Value = DBNull.Value;
            return run(command);
        }

        public bool updateHocPhi(int maHP, int maHS, int maHK, int soTien, DateTime? ngayDong, string trangThai)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `tuition` SET `StudentId`=@mhs,`SemesterId`=@mhk,`Amount`=@st,`PaidDate`=@nd,`Status`=@tt WHERE `TuitionId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maHP;
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@mhk", MySqlDbType.Int32).Value = maHK;
            command.Parameters.Add("@st", MySqlDbType.Int32).Value = soTien;
            command.Parameters.Add("@tt", MySqlDbType.VarChar).Value = trangThai;
            if (ngayDong.HasValue)
                command.Parameters.Add("@nd", MySqlDbType.Date).Value = ngayDong.Value;
            else
                command.Parameters.Add("@nd", MySqlDbType.Date).Value = DBNull.Value;
            return run(command);
        }

        public bool deleteHocPhi(int maHP)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `tuition` WHERE `TuitionId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maHP;
            return run(command);
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

        public DataTable getAll()
        {
            return getList(new MySqlCommand(SELECT_HP + " ORDER BY tuition.SemesterId DESC, tuition.TuitionId"));
        }

        //tìm theo họ tên, lớp, học kỳ hoặc trạng thái
        public DataTable searchHocPhi(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand(SELECT_HP + " WHERE CONCAT(student.StdLastName, student.StdFirstName, IFNULL(class.ClassName,''), semester.SemesterName, tuition.Status) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        //thống kê thu học phí theo học kỳ
        public DataTable thongKeHocPhi()
        {
            return getList(new MySqlCommand(
                "SELECT semester.SemesterName AS `Học kỳ`, COUNT(*) AS `Số học sinh`, " +
                "SUM(CASE WHEN tuition.Status='Đã đóng' THEN 1 ELSE 0 END) AS `Đã đóng`, " +
                "SUM(CASE WHEN tuition.Status='Chưa đóng' THEN 1 ELSE 0 END) AS `Chưa đóng`, " +
                "SUM(CASE WHEN tuition.Status='Đã đóng' THEN tuition.Amount ELSE 0 END) AS `Tiền đã thu`, " +
                "SUM(CASE WHEN tuition.Status='Chưa đóng' THEN tuition.Amount ELSE 0 END) AS `Tiền còn nợ` " +
                "FROM tuition INNER JOIN semester ON tuition.SemesterId = semester.SemesterId " +
                "GROUP BY semester.SemesterId, semester.SemesterName ORDER BY semester.SemesterId"));
        }

        public string tongTienDaThu()
        {
            MySqlCommand command = new MySqlCommand("SELECT IFNULL(SUM(Amount),0) FROM tuition WHERE Status='Đã đóng'");
            return tinhMotGiaTri(command);
        }

        //đọc số tiền người dùng nhập, bỏ dấu chấm và dấu phẩy phân cách nghìn
        public static bool tryParseTien(string text, out int value)
        {
            value = 0;
            text = text.Trim();
            text = text.Replace(".", "");
            text = text.Replace(",", "");
            text = text.Replace(" ", "");
            if (!int.TryParse(text, out value))
                return false;
            if (value < 0)
                return false;
            return true;
        }
    }
}
