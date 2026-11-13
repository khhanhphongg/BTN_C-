using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng student (học sinh) và bảng student_class (xếp học sinh vào lớp)
    class HocSinhClass : DuLieuClass
    {
        //thêm học sinh mới rồi xếp vào lớp, trả về mã học sinh vừa thêm (0 nếu lỗi)
        public int insertHocSinh(string ho, string ten, DateTime ngaySinh, string gioiTinh, string dienThoai, string diaChi, byte[] anh, int maLop)
        {
            MySqlCommand command = ganKetNoi(new MySqlCommand("INSERT INTO `student`(`StdFirstName`, `StdLastName`, `Birthdate`, `Gender`, `Phone`, `Address`, `Photo`) VALUES (@ten,@ho,@ns,@gt,@dt,@dc,@anh)"));
            command.Parameters.Add("@ten", MySqlDbType.VarChar).Value = ten;
            command.Parameters.Add("@ho", MySqlDbType.VarChar).Value = ho;
            command.Parameters.Add("@ns", MySqlDbType.Date).Value = ngaySinh;
            command.Parameters.Add("@gt", MySqlDbType.VarChar).Value = gioiTinh;
            command.Parameters.Add("@dt", MySqlDbType.VarChar).Value = dienThoai;
            command.Parameters.Add("@dc", MySqlDbType.VarChar).Value = diaChi;
            command.Parameters.Add("@anh", MySqlDbType.Blob).Value = anh;
            try
            {
                connect.openConnect();
                if (command.ExecuteNonQuery() != 1)
                    return 0;
                int maHS = (int)command.LastInsertedId;
                MySqlCommand xepLop = ganKetNoi(new MySqlCommand("INSERT INTO `student_class`(`StudentId`, `ClassId`) VALUES (@mhs,@ml)"));
                xepLop.Parameters.AddWithValue("@mhs", maHS);
                xepLop.Parameters.AddWithValue("@ml", maLop);
                xepLop.ExecuteNonQuery();
                return maHS;
            }
            finally
            {
                connect.closeConnect();
            }
        }

        //sửa học sinh và đổi lớp
        public bool updateHocSinh(int maHS, string ho, string ten, DateTime ngaySinh, string gioiTinh, string dienThoai, string diaChi, byte[] anh, int maLop)
        {
            MySqlCommand command = ganKetNoi(new MySqlCommand("UPDATE `student` SET `StdFirstName`=@ten,`StdLastName`=@ho,`Birthdate`=@ns,`Gender`=@gt,`Phone`=@dt,`Address`=@dc,`Photo`=@anh WHERE `StdId`=@ma"));
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@ten", MySqlDbType.VarChar).Value = ten;
            command.Parameters.Add("@ho", MySqlDbType.VarChar).Value = ho;
            command.Parameters.Add("@ns", MySqlDbType.Date).Value = ngaySinh;
            command.Parameters.Add("@gt", MySqlDbType.VarChar).Value = gioiTinh;
            command.Parameters.Add("@dt", MySqlDbType.VarChar).Value = dienThoai;
            command.Parameters.Add("@dc", MySqlDbType.VarChar).Value = diaChi;
            command.Parameters.Add("@anh", MySqlDbType.Blob).Value = anh;
            try
            {
                connect.openConnect();
                bool ok = command.ExecuteNonQuery() == 1;
                //đổi lớp: có dòng xếp lớp rồi thì sửa, chưa có thì thêm mới
                MySqlCommand demLop = ganKetNoi(new MySqlCommand("SELECT COUNT(*) FROM `student_class` WHERE `StudentId`=@mhs"));
                demLop.Parameters.AddWithValue("@mhs", maHS);
                string cauLenhLop;
                if (Convert.ToInt32(demLop.ExecuteScalar()) > 0)
                    cauLenhLop = "UPDATE `student_class` SET `ClassId`=@ml WHERE `StudentId`=@mhs";
                else
                    cauLenhLop = "INSERT INTO `student_class`(`StudentId`, `ClassId`) VALUES (@mhs,@ml)";
                MySqlCommand doiLop = ganKetNoi(new MySqlCommand(cauLenhLop));
                doiLop.Parameters.AddWithValue("@mhs", maHS);
                doiLop.Parameters.AddWithValue("@ml", maLop);
                doiLop.ExecuteNonQuery();
                return ok;
            }
            finally
            {
                connect.closeConnect();
            }
        }

        //xoá học sinh, điểm và dòng xếp lớp tự xoá theo (ON DELETE CASCADE)
        public bool deleteHocSinh(int maHS)
        {
            MySqlCommand command = ganKetNoi(new MySqlCommand("DELETE FROM `student` WHERE `StdId`=@ma"));
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maHS;
            try
            {
                connect.openConnect();
                return command.ExecuteNonQuery() == 1;
            }
            finally
            {
                connect.closeConnect();
            }
        }

        //câu select dùng chung: học sinh kèm tên lớp
        private const string SELECT_HS =
            "SELECT student.StdId, student.StdLastName, student.StdFirstName, student.Birthdate, " +
            "student.Gender, student.Phone, student.Address, " +
            "IFNULL(class.ClassName,'Chưa xếp lớp') AS ClassName, student.Photo, " +
            "IFNULL(student_class.ClassId,0) AS ClassId " +
            "FROM student " +
            "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
            "LEFT JOIN class ON student_class.ClassId = class.ClassId";

        public DataTable getAll()
        {
            return getList(new MySqlCommand(SELECT_HS + " ORDER BY student.StdId"));
        }

        //lấy học sinh cho combobox, hiện họ tên đầy đủ
        public DataTable getComboBox()
        {
            return getList(new MySqlCommand("SELECT `StdId`, CONCAT(`StdLastName`,' ',`StdFirstName`) AS HoTen FROM `student` ORDER BY `StdLastName`"));
        }

        //lấy học sinh của một lớp, dùng cho điểm danh và nhập điểm theo lớp
        public DataTable getHocSinhTheoLop(int maLop)
        {
            MySqlCommand command = new MySqlCommand("SELECT student.StdId, CONCAT(student.StdLastName,' ',student.StdFirstName) AS HoTen FROM student INNER JOIN student_class ON student.StdId = student_class.StudentId WHERE student_class.ClassId=@ml ORDER BY student.StdLastName");
            command.Parameters.AddWithValue("@ml", maLop);
            return getList(command);
        }

        //tìm học sinh theo họ tên, địa chỉ, điện thoại hoặc tên lớp
        public DataTable searchHocSinh(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand(SELECT_HS + " WHERE CONCAT(student.StdLastName, student.StdFirstName, student.Address, student.Phone, IFNULL(class.ClassName,'')) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        public string demHocSinh(string cauLenh)
        {
            return tinhMotGiaTri(cauLenh);
        }

        public string tongHocSinh()
        {
            return demHocSinh("SELECT COUNT(*) FROM student");
        }

        public string hocSinhNam()
        {
            return demHocSinh("SELECT COUNT(*) FROM student WHERE `Gender`='Nam'");
        }

        public string hocSinhNu()
        {
            return demHocSinh("SELECT COUNT(*) FROM student WHERE `Gender`='Nữ'");
        }

        public string demTheoLop(string tenLop)
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM student_class INNER JOIN class ON student_class.ClassId = class.ClassId WHERE class.ClassName = @tl");
            command.Parameters.AddWithValue("@tl", tenLop);
            return tinhMotGiaTri(command);
        }
    }
}
