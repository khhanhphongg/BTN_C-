using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    class HocSinhClass : DuLieuClass
    {
        public int insertHocSinh(string ho, string ten, DateTime ngaySinh, string gioiTinh, string dienThoai, string diaChi, byte[] anh, int maLop)
        {
            SqlCommand command = ganKetNoi(new SqlCommand("INSERT INTO [student]([StdFirstName], [StdLastName], [Birthdate], [Gender], [Phone], [Address], [Photo]) VALUES (@ten,@ho,@ns,@gt,@dt,@dc,@anh); SELECT CAST(SCOPE_IDENTITY() AS INT);"));
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ten;
            command.Parameters.Add("@ho", SqlDbType.NVarChar).Value = ho;
            command.Parameters.Add("@ns", SqlDbType.Date).Value = ngaySinh;
            command.Parameters.Add("@gt", SqlDbType.NVarChar).Value = gioiTinh;
            command.Parameters.Add("@dt", SqlDbType.NVarChar).Value = dienThoai;
            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = diaChi;
            command.Parameters.Add("@anh", SqlDbType.VarBinary).Value = anh;
            try
            {
                connect.openConnect();
                object ketQua = command.ExecuteScalar();
                if (ketQua == null || ketQua == DBNull.Value)
                    return 0;
                int maHS = (int)ketQua;
                SqlCommand xepLop = ganKetNoi(new SqlCommand("INSERT INTO [student_class]([StudentId], [ClassId]) VALUES (@mhs,@ml)"));
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

        public bool updateHocSinh(int maHS, string ho, string ten, DateTime ngaySinh, string gioiTinh, string dienThoai, string diaChi, byte[] anh, int maLop)
        {
            SqlCommand command = ganKetNoi(new SqlCommand("UPDATE [student] SET [StdFirstName]=@ten,[StdLastName]=@ho,[Birthdate]=@ns,[Gender]=@gt,[Phone]=@dt,[Address]=@dc,[Photo]=@anh WHERE [StdId]=@ma"));
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maHS;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = ten;
            command.Parameters.Add("@ho", SqlDbType.NVarChar).Value = ho;
            command.Parameters.Add("@ns", SqlDbType.Date).Value = ngaySinh;
            command.Parameters.Add("@gt", SqlDbType.NVarChar).Value = gioiTinh;
            command.Parameters.Add("@dt", SqlDbType.NVarChar).Value = dienThoai;
            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = diaChi;
            command.Parameters.Add("@anh", SqlDbType.VarBinary).Value = anh;
            try
            {
                connect.openConnect();
                bool ok = command.ExecuteNonQuery() == 1;
                SqlCommand demLop = ganKetNoi(new SqlCommand("SELECT COUNT(*) FROM [student_class] WHERE [StudentId]=@mhs"));
                demLop.Parameters.AddWithValue("@mhs", maHS);
                string cauLenhLop;
                if (Convert.ToInt32(demLop.ExecuteScalar()) > 0)
                    cauLenhLop = "UPDATE [student_class] SET [ClassId]=@ml WHERE [StudentId]=@mhs";
                else
                    cauLenhLop = "INSERT INTO [student_class]([StudentId], [ClassId]) VALUES (@mhs,@ml)";
                SqlCommand doiLop = ganKetNoi(new SqlCommand(cauLenhLop));
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

        public bool deleteHocSinh(int maHS)
        {
            SqlCommand command = ganKetNoi(new SqlCommand("DELETE FROM [student] WHERE [StdId]=@ma"));
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maHS;
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

        private const string SELECT_HS =
            "SELECT student.StdId, student.StdLastName, student.StdFirstName, student.Birthdate, " +
            "student.Gender, student.Phone, student.Address, " +
            "ISNULL(class.ClassName,N'Chưa xếp lớp') AS ClassName, student.Photo, " +
            "ISNULL(student_class.ClassId,0) AS ClassId " +
            "FROM student " +
            "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
            "LEFT JOIN class ON student_class.ClassId = class.ClassId";

        public DataTable getAll()
        {
            return getList(new SqlCommand(SELECT_HS + " ORDER BY student.StdId"));
        }

        public DataTable getComboBox()
        {
            return getList(new SqlCommand("SELECT [StdId], CONCAT([StdLastName],' ',[StdFirstName]) AS HoTen FROM [student] ORDER BY [StdLastName]"));
        }

        public DataTable getHocSinhTheoLop(int maLop)
        {
            SqlCommand command = new SqlCommand("SELECT student.StdId, CONCAT(student.StdLastName,' ',student.StdFirstName) AS HoTen FROM student INNER JOIN student_class ON student.StdId = student_class.StudentId WHERE student_class.ClassId=@ml ORDER BY student.StdLastName");
            command.Parameters.AddWithValue("@ml", maLop);
            return getList(command);
        }

        public DataTable searchHocSinh(string tuKhoa)
        {
            SqlCommand command = new SqlCommand(SELECT_HS + " WHERE CONCAT(student.StdLastName, student.StdFirstName, student.Address, student.Phone, ISNULL(class.ClassName,'')) LIKE @s");
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
            return demHocSinh("SELECT COUNT(*) FROM student WHERE [Gender]='Nam'");
        }

        public string hocSinhNu()
        {
            return demHocSinh("SELECT COUNT(*) FROM student WHERE [Gender]=N'Nữ'");
        }

        public string demTheoLop(string tenLop)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM student_class INNER JOIN class ON student_class.ClassId = class.ClassId WHERE class.ClassName = @tl");
            command.Parameters.AddWithValue("@tl", tenLop);
            return tinhMotGiaTri(command);
        }
    }
}
