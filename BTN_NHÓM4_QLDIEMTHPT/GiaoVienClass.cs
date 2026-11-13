using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng teacher (giáo viên, thuộc một khoa)
    class GiaoVienClass : DuLieuClass
    {
        public bool insertGiaoVien(string hoTen, string dienThoai, string email, int maKhoa)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `teacher`(`TeacherName`, `Phone`, `Email`, `DeptId`) VALUES (@ht,@dt,@em,@mk)");
            command.Parameters.Add("@ht", MySqlDbType.VarChar).Value = hoTen;
            command.Parameters.Add("@dt", MySqlDbType.VarChar).Value = dienThoai;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@mk", MySqlDbType.Int32).Value = maKhoa;
            return run(command);
        }

        public bool updateGiaoVien(int maGV, string hoTen, string dienThoai, string email, int maKhoa)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `teacher` SET `TeacherName`=@ht,`Phone`=@dt,`Email`=@em,`DeptId`=@mk WHERE `TeacherId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maGV;
            command.Parameters.Add("@ht", MySqlDbType.VarChar).Value = hoTen;
            command.Parameters.Add("@dt", MySqlDbType.VarChar).Value = dienThoai;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@mk", MySqlDbType.Int32).Value = maKhoa;
            return run(command);
        }

        //xoá giáo viên, giáo viên đang chủ nhiệm lớp hoặc có trong thời khoá biểu thì không xoá được
        public bool deleteGiaoVien(int maGV)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `teacher` WHERE `TeacherId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maGV;
            return run(command);
        }

        //câu select dùng chung: giáo viên kèm tên khoa
        private const string SELECT_GV =
            "SELECT teacher.TeacherId, teacher.TeacherName, teacher.Phone, teacher.Email, " +
            "department.DeptName, teacher.DeptId " +
            "FROM teacher INNER JOIN department ON teacher.DeptId = department.DeptId";

        public DataTable getAll()
        {
            return getList(new MySqlCommand(SELECT_GV + " ORDER BY teacher.TeacherId"));
        }

        public DataTable getComboBox()
        {
            return getList(new MySqlCommand("SELECT `TeacherId`,`TeacherName` FROM `teacher` ORDER BY `TeacherName`"));
        }

        //tìm giáo viên theo tên, điện thoại, email hoặc khoa
        public DataTable searchGiaoVien(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand(SELECT_GV + " WHERE CONCAT(teacher.TeacherName, teacher.Phone, teacher.Email, department.DeptName) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        public string tongGiaoVien()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM teacher");
            return tinhMotGiaTri(command);
        }

        public string demTheoKhoa(string tenKhoa)
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM teacher INNER JOIN department ON teacher.DeptId = department.DeptId WHERE department.DeptName = @tk");
            command.Parameters.AddWithValue("@tk", tenKhoa);
            return tinhMotGiaTri(command);
        }
    }
}
