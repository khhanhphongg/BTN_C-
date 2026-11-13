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
    class GiaoVienClass
    {
        DBconnect connect = new DBconnect();

        //hàm thêm giáo viên mới
        public bool insertGiaoVien(string hoTen, string dienThoai, string email, int maKhoa)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `teacher`(`TeacherName`, `Phone`, `Email`, `DeptId`) VALUES (@ht,@dt,@em,@mk)", connect.getconnection);
            command.Parameters.Add("@ht", MySqlDbType.VarChar).Value = hoTen;
            command.Parameters.Add("@dt", MySqlDbType.VarChar).Value = dienThoai;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@mk", MySqlDbType.Int32).Value = maKhoa;
            return run(command);
        }

        //hàm sửa giáo viên
        public bool updateGiaoVien(int maGV, string hoTen, string dienThoai, string email, int maKhoa)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `teacher` SET `TeacherName`=@ht,`Phone`=@dt,`Email`=@em,`DeptId`=@mk WHERE `TeacherId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maGV;
            command.Parameters.Add("@ht", MySqlDbType.VarChar).Value = hoTen;
            command.Parameters.Add("@dt", MySqlDbType.VarChar).Value = dienThoai;
            command.Parameters.Add("@em", MySqlDbType.VarChar).Value = email;
            command.Parameters.Add("@mk", MySqlDbType.Int32).Value = maKhoa;
            return run(command);
        }

        //hàm xoá giáo viên, giáo viên đang chủ nhiệm lớp hoặc có trong thời khoá biểu thì không xoá được
        public bool deleteGiaoVien(int maGV)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `teacher` WHERE `TeacherId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maGV;
            return run(command);
        }

        //chạy lệnh thêm/sửa/xoá
        private bool run(MySqlCommand command)
        {
            try
            {
                connect.openConnect();
                return command.ExecuteNonQuery() == 1;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451 || ex.Number == 1452)
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

        //câu select dùng chung: giáo viên kèm tên khoa
        private const string SELECT_GV =
            "SELECT teacher.TeacherId, teacher.TeacherName, teacher.Phone, teacher.Email, " +
            "department.DeptName, teacher.DeptId " +
            "FROM teacher INNER JOIN department ON teacher.DeptId = department.DeptId";

        //hàm lấy toàn bộ giáo viên
        public DataTable getAll()
        {
            return getList(new MySqlCommand(SELECT_GV + " ORDER BY teacher.TeacherId"));
        }

        //hàm lấy giáo viên cho combobox
        public DataTable getComboBox()
        {
            return getList(new MySqlCommand("SELECT `TeacherId`,`TeacherName` FROM `teacher` ORDER BY `TeacherName`"));
        }

        //hàm tìm giáo viên theo tên, điện thoại, email hoặc khoa
        public DataTable searchGiaoVien(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand(SELECT_GV + " WHERE CONCAT(teacher.TeacherName, teacher.Phone, teacher.Email, department.DeptName) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        //hàm đếm tổng số giáo viên
        public string tongGiaoVien()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM teacher", connect.getconnection);
            connect.openConnect();
            string dem = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return dem;
        }

        //hàm đếm số giáo viên của một khoa
        public string demTheoKhoa(string tenKhoa)
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM teacher INNER JOIN department ON teacher.DeptId = department.DeptId WHERE department.DeptName = @tk", connect.getconnection);
            command.Parameters.AddWithValue("@tk", tenKhoa);
            connect.openConnect();
            string dem = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return dem;
        }
    }
}
