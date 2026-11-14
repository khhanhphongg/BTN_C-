using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    class GiaoVienClass : DuLieuClass
    {
        public bool insertGiaoVien(string hoTen, string dienThoai, string email, int maKhoa)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [teacher]([TeacherName], [Phone], [Email], [DeptId]) VALUES (@ht,@dt,@em,@mk)");
            command.Parameters.Add("@ht", SqlDbType.NVarChar).Value = hoTen;
            command.Parameters.Add("@dt", SqlDbType.NVarChar).Value = dienThoai;
            command.Parameters.Add("@em", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@mk", SqlDbType.Int).Value = maKhoa;
            return run(command);
        }

        public bool updateGiaoVien(int maGV, string hoTen, string dienThoai, string email, int maKhoa)
        {
            SqlCommand command = new SqlCommand("UPDATE [teacher] SET [TeacherName]=@ht,[Phone]=@dt,[Email]=@em,[DeptId]=@mk WHERE [TeacherId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maGV;
            command.Parameters.Add("@ht", SqlDbType.NVarChar).Value = hoTen;
            command.Parameters.Add("@dt", SqlDbType.NVarChar).Value = dienThoai;
            command.Parameters.Add("@em", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@mk", SqlDbType.Int).Value = maKhoa;
            return run(command);
        }

        public bool deleteGiaoVien(int maGV)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [teacher] WHERE [TeacherId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maGV;
            return run(command);
        }

        private const string SELECT_GV =
            "SELECT teacher.TeacherId, teacher.TeacherName, teacher.Phone, teacher.Email, " +
            "department.DeptName, teacher.DeptId " +
            "FROM teacher INNER JOIN department ON teacher.DeptId = department.DeptId";

        public DataTable getAll()
        {
            return getList(new SqlCommand(SELECT_GV + " ORDER BY teacher.TeacherId"));
        }

        public DataTable getComboBox()
        {
            return getList(new SqlCommand("SELECT [TeacherId],[TeacherName] FROM [teacher] ORDER BY [TeacherName]"));
        }

        public DataTable searchGiaoVien(string tuKhoa)
        {
            SqlCommand command = new SqlCommand(SELECT_GV + " WHERE CONCAT(teacher.TeacherName, teacher.Phone, teacher.Email, department.DeptName) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        public string tongGiaoVien()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM teacher");
            return tinhMotGiaTri(command);
        }

        public string demTheoKhoa(string tenKhoa)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM teacher INNER JOIN department ON teacher.DeptId = department.DeptId WHERE department.DeptName = @tk");
            command.Parameters.AddWithValue("@tk", tenKhoa);
            return tinhMotGiaTri(command);
        }
    }
}
