using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng schedule (thời khoá biểu: môn nào, lớp nào, giáo viên nào, phòng nào, học kỳ nào)
    class ThoiKhoaBieuClass : DuLieuClass
    {
        //các thứ trong tuần, dùng để đổ vào combobox
        public static string[] cacThu = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        //hàm đổi tên thứ tiếng Anh trong CSDL sang tiếng Việt để hiện lên form
        public static string thuTiengViet(string thu)
        {
            switch (thu)
            {
                case "Monday": return "Thứ hai";
                case "Tuesday": return "Thứ ba";
                case "Wednesday": return "Thứ tư";
                case "Thursday": return "Thứ năm";
                case "Friday": return "Thứ sáu";
                case "Saturday": return "Thứ bảy";
                default: return thu;
            }
        }

        //hàm thêm một tiết vào thời khoá biểu
        public bool insertTiet(int maMon, int maLop, int maGV, int maPhong, int maHK, string thu, TimeSpan batDau, TimeSpan ketThuc)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `schedule`(`CourseId`, `ClassId`, `TeacherId`, `RoomId`, `SemesterId`, `DayOfWeek`, `StartTime`, `EndTime`) VALUES (@mm,@ml,@mgv,@mp,@mhk,@thu,@bd,@kt)");
            command.Parameters.Add("@mm", MySqlDbType.Int32).Value = maMon;
            command.Parameters.Add("@ml", MySqlDbType.Int32).Value = maLop;
            command.Parameters.Add("@mgv", MySqlDbType.Int32).Value = maGV;
            command.Parameters.Add("@mp", MySqlDbType.Int32).Value = maPhong;
            command.Parameters.Add("@mhk", MySqlDbType.Int32).Value = maHK;
            command.Parameters.Add("@thu", MySqlDbType.VarChar).Value = thu;
            command.Parameters.Add("@bd", MySqlDbType.Time).Value = batDau;
            command.Parameters.Add("@kt", MySqlDbType.Time).Value = ketThuc;
            return run(command, 1452);
        }

        //hàm sửa một tiết
        public bool updateTiet(int maTiet, int maMon, int maLop, int maGV, int maPhong, int maHK, string thu, TimeSpan batDau, TimeSpan ketThuc)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `schedule` SET `CourseId`=@mm,`ClassId`=@ml,`TeacherId`=@mgv,`RoomId`=@mp,`SemesterId`=@mhk,`DayOfWeek`=@thu,`StartTime`=@bd,`EndTime`=@kt WHERE `ScheduleId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maTiet;
            command.Parameters.Add("@mm", MySqlDbType.Int32).Value = maMon;
            command.Parameters.Add("@ml", MySqlDbType.Int32).Value = maLop;
            command.Parameters.Add("@mgv", MySqlDbType.Int32).Value = maGV;
            command.Parameters.Add("@mp", MySqlDbType.Int32).Value = maPhong;
            command.Parameters.Add("@mhk", MySqlDbType.Int32).Value = maHK;
            command.Parameters.Add("@thu", MySqlDbType.VarChar).Value = thu;
            command.Parameters.Add("@bd", MySqlDbType.Time).Value = batDau;
            command.Parameters.Add("@kt", MySqlDbType.Time).Value = ketThuc;
            return run(command, 1452);
        }

        //hàm xoá một tiết
        public bool deleteTiet(int maTiet)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `schedule` WHERE `ScheduleId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maTiet;
            return run(command, 1452);
        }

        //câu select dùng chung: nối 5 bảng để hiện tên thay vì mã
        private const string SELECT_TKB =
            "SELECT schedule.ScheduleId, course.CourseName, class.ClassName, teacher.TeacherName, " +
            "room.RoomName, semester.SemesterName, schedule.`DayOfWeek`, schedule.StartTime, schedule.EndTime, " +
            "schedule.CourseId, schedule.ClassId, schedule.TeacherId, schedule.RoomId, schedule.SemesterId " +
            "FROM schedule " +
            "INNER JOIN course ON schedule.CourseId = course.CourseId " +
            "INNER JOIN class ON schedule.ClassId = class.ClassId " +
            "INNER JOIN teacher ON schedule.TeacherId = teacher.TeacherId " +
            "INNER JOIN room ON schedule.RoomId = room.RoomId " +
            "INNER JOIN semester ON schedule.SemesterId = semester.SemesterId";

        //hàm lấy toàn bộ thời khoá biểu
        public DataTable getAll()
        {
            return getList(new MySqlCommand(SELECT_TKB + " ORDER BY schedule.SemesterId, FIELD(schedule.`DayOfWeek`,'Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'), schedule.StartTime"));
        }

        //hàm tìm theo tên môn, tên lớp, giáo viên hoặc phòng
        public DataTable searchTKB(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand(SELECT_TKB + " WHERE CONCAT(course.CourseName, class.ClassName, teacher.TeacherName, room.RoomName, semester.SemesterName) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        /*
         * Hàm kiểm tra trùng lịch: cùng học kỳ, cùng thứ, giờ bị chồng nhau mà
         * lại trùng phòng hoặc trùng giáo viên thì không cho lưu.
         * maTietBoQua dùng khi sửa, để không so chính dòng đang sửa với nó.
         */
        public string kiemTraTrungLich(int maPhong, int maGV, int maHK, string thu, TimeSpan batDau, TimeSpan ketThuc, int maTietBoQua)
        {
            MySqlCommand command = new MySqlCommand(
                "SELECT room.RoomName, teacher.TeacherName, schedule.RoomId, schedule.TeacherId " +
                "FROM schedule " +
                "INNER JOIN room ON schedule.RoomId = room.RoomId " +
                "INNER JOIN teacher ON schedule.TeacherId = teacher.TeacherId " +
                "WHERE schedule.SemesterId=@mhk AND schedule.`DayOfWeek`=@thu AND schedule.ScheduleId<>@bq " +
                "AND schedule.StartTime < @kt AND schedule.EndTime > @bd " +
                "AND (schedule.RoomId=@mp OR schedule.TeacherId=@mgv)");
            command.Parameters.AddWithValue("@mhk", maHK);
            command.Parameters.AddWithValue("@thu", thu);
            command.Parameters.AddWithValue("@bq", maTietBoQua);
            command.Parameters.AddWithValue("@bd", batDau);
            command.Parameters.AddWithValue("@kt", ketThuc);
            command.Parameters.AddWithValue("@mp", maPhong);
            command.Parameters.AddWithValue("@mgv", maGV);
            DataTable table = getList(command);
            if (table.Rows.Count == 0)
                return "";
            DataRow dong = table.Rows[0];
            if (Convert.ToInt32(dong["RoomId"]) == maPhong)
                return "Phòng " + dong["RoomName"].ToString() + " đã có lớp khác học vào giờ này";
            return "Giáo viên " + dong["TeacherName"].ToString() + " đã có tiết dạy vào giờ này";
        }

        //hàm đếm tổng số tiết trong thời khoá biểu
        public string tongTiet()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM schedule");
            return tinhMotGiaTri(command);
        }
    }
}
