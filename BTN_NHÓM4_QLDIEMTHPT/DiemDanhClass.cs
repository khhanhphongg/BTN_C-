using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    class DiemDanhClass : DuLieuClass
    {
        public static string[] cacTrangThai = { "Có mặt", "Vắng", "Đi muộn" };

        public bool insertDiemDanh(int maHS, int maMon, DateTime ngay, string trangThai)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [attendance]([StudentId], [CourseId], [AttendDate], [Status]) VALUES (@mhs,@mm,@ngay,@tt)");
            command.Parameters.Add("@mhs", SqlDbType.Int).Value = maHS;
            command.Parameters.Add("@mm", SqlDbType.Int).Value = maMon;
            command.Parameters.Add("@ngay", SqlDbType.Date).Value = ngay;
            command.Parameters.Add("@tt", SqlDbType.NVarChar).Value = trangThai;
            return run(command);
        }

        public bool updateDiemDanh(int maDD, int maHS, int maMon, DateTime ngay, string trangThai)
        {
            SqlCommand command = new SqlCommand("UPDATE [attendance] SET [StudentId]=@mhs,[CourseId]=@mm,[AttendDate]=@ngay,[Status]=@tt WHERE [AttendId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maDD;
            command.Parameters.Add("@mhs", SqlDbType.Int).Value = maHS;
            command.Parameters.Add("@mm", SqlDbType.Int).Value = maMon;
            command.Parameters.Add("@ngay", SqlDbType.Date).Value = ngay;
            command.Parameters.Add("@tt", SqlDbType.NVarChar).Value = trangThai;
            return run(command);
        }

        public bool deleteDiemDanh(int maDD)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [attendance] WHERE [AttendId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maDD;
            return run(command);
        }

        private const string SELECT_DD =
            "SELECT attendance.AttendId, CONCAT(student.StdLastName,' ',student.StdFirstName) AS HoTen, " +
            "ISNULL(class.ClassName,N'Chưa xếp lớp') AS ClassName, course.CourseName, " +
            "attendance.AttendDate, attendance.Status, attendance.StudentId, attendance.CourseId " +
            "FROM attendance " +
            "INNER JOIN student ON attendance.StudentId = student.StdId " +
            "INNER JOIN course ON attendance.CourseId = course.CourseId " +
            "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
            "LEFT JOIN class ON student_class.ClassId = class.ClassId";

        public DataTable getAll()
        {
            return getList(new SqlCommand(SELECT_DD + " ORDER BY attendance.AttendDate DESC, attendance.AttendId DESC"));
        }

        public DataTable searchDiemDanh(string tuKhoa)
        {
            SqlCommand command = new SqlCommand(SELECT_DD + " WHERE CONCAT(student.StdLastName, student.StdFirstName, ISNULL(class.ClassName,''), course.CourseName) LIKE @s ORDER BY attendance.AttendDate DESC");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        public DataTable thongKeVang()
        {
            return getList(new SqlCommand(
                "SELECT CONCAT(student.StdLastName,' ',student.StdFirstName) AS [Họ tên], " +
                "ISNULL(class.ClassName,N'Chưa xếp lớp') AS [Lớp], " +
                "SUM(CASE WHEN attendance.Status=N'Có mặt' THEN 1 ELSE 0 END) AS [Có mặt], " +
                "SUM(CASE WHEN attendance.Status=N'Vắng' THEN 1 ELSE 0 END) AS [Vắng], " +
                "SUM(CASE WHEN attendance.Status=N'Đi muộn' THEN 1 ELSE 0 END) AS [Đi muộn], " +
                "COUNT(*) AS [Tổng buổi] " +
                "FROM attendance " +
                "INNER JOIN student ON attendance.StudentId = student.StdId " +
                "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
                "LEFT JOIN class ON student_class.ClassId = class.ClassId " +
                "GROUP BY student.StdId, student.StdLastName, student.StdFirstName, class.ClassName " +
                "ORDER BY [Vắng] DESC"));
        }
    }
}
