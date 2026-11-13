using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng attendance (điểm danh: Present có mặt, Absent vắng, Late đi muộn)
    class DiemDanhClass
    {
        DBconnect connect = new DBconnect();

        //ba trạng thái điểm danh, dùng để đổ vào combobox
        public static string[] cacTrangThai = { "Present", "Absent", "Late" };

        //hàm đổi trạng thái trong CSDL sang tiếng Việt để hiện lên form
        public static string trangThaiTiengViet(string trangThai)
        {
            switch (trangThai)
            {
                case "Present": return "Có mặt";
                case "Absent": return "Vắng";
                case "Late": return "Đi muộn";
                default: return trangThai;
            }
        }

        //hàm thêm một lượt điểm danh
        public bool insertDiemDanh(int maHS, int maMon, DateTime ngay, string trangThai)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `attendance`(`StudentId`, `CourseId`, `AttendDate`, `Status`) VALUES (@mhs,@mm,@ngay,@tt)", connect.getconnection);
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@mm", MySqlDbType.Int32).Value = maMon;
            command.Parameters.Add("@ngay", MySqlDbType.Date).Value = ngay;
            command.Parameters.Add("@tt", MySqlDbType.VarChar).Value = trangThai;
            return run(command);
        }

        //hàm sửa một lượt điểm danh
        public bool updateDiemDanh(int maDD, int maHS, int maMon, DateTime ngay, string trangThai)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `attendance` SET `StudentId`=@mhs,`CourseId`=@mm,`AttendDate`=@ngay,`Status`=@tt WHERE `AttendId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maDD;
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@mm", MySqlDbType.Int32).Value = maMon;
            command.Parameters.Add("@ngay", MySqlDbType.Date).Value = ngay;
            command.Parameters.Add("@tt", MySqlDbType.VarChar).Value = trangThai;
            return run(command);
        }

        //hàm xoá một lượt điểm danh
        public bool deleteDiemDanh(int maDD)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `attendance` WHERE `AttendId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maDD;
            return run(command);
        }

        //chạy lệnh thêm/sửa/xoá, trùng (học sinh, môn, ngày) là lỗi 1062
        private bool run(MySqlCommand command)
        {
            try
            {
                connect.openConnect();
                return command.ExecuteNonQuery() == 1;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062 || ex.Number == 1452)
                    return false;
                throw;
            }
            finally
            {
                connect.closeConnect();
            }
        }

        //hàm chạy câu select bất kỳ
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //câu select dùng chung: điểm danh kèm họ tên học sinh, tên lớp, tên môn
        private const string SELECT_DD =
            "SELECT attendance.AttendId, CONCAT(student.StdLastName,' ',student.StdFirstName) AS HoTen, " +
            "IFNULL(class.ClassName,'Chưa xếp lớp') AS ClassName, course.CourseName, " +
            "attendance.AttendDate, attendance.Status, attendance.StudentId, attendance.CourseId " +
            "FROM attendance " +
            "INNER JOIN student ON attendance.StudentId = student.StdId " +
            "INNER JOIN course ON attendance.CourseId = course.CourseId " +
            "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
            "LEFT JOIN class ON student_class.ClassId = class.ClassId";

        //hàm lấy toàn bộ điểm danh
        public DataTable getAll()
        {
            return getList(new MySqlCommand(SELECT_DD + " ORDER BY attendance.AttendDate DESC, attendance.AttendId DESC"));
        }

        //hàm tìm theo họ tên học sinh, tên lớp hoặc tên môn
        public DataTable searchDiemDanh(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand(SELECT_DD + " WHERE CONCAT(student.StdLastName, student.StdFirstName, IFNULL(class.ClassName,''), course.CourseName) LIKE @s ORDER BY attendance.AttendDate DESC");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        //hàm thống kê số buổi có mặt, vắng, đi muộn của từng học sinh
        public DataTable thongKeVang()
        {
            return getList(new MySqlCommand(
                "SELECT CONCAT(student.StdLastName,' ',student.StdFirstName) AS `Họ tên`, " +
                "IFNULL(class.ClassName,'Chưa xếp lớp') AS `Lớp`, " +
                "SUM(CASE WHEN attendance.Status='Present' THEN 1 ELSE 0 END) AS `Có mặt`, " +
                "SUM(CASE WHEN attendance.Status='Absent' THEN 1 ELSE 0 END) AS `Vắng`, " +
                "SUM(CASE WHEN attendance.Status='Late' THEN 1 ELSE 0 END) AS `Đi muộn`, " +
                "COUNT(*) AS `Tổng buổi` " +
                "FROM attendance " +
                "INNER JOIN student ON attendance.StudentId = student.StdId " +
                "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
                "LEFT JOIN class ON student_class.ClassId = class.ClassId " +
                "GROUP BY student.StdId, student.StdLastName, student.StdFirstName, class.ClassName " +
                "ORDER BY `Vắng` DESC"));
        }
    }
}
