using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng class (lớp học, thuộc một khoa và có một giáo viên chủ nhiệm)
    class LopClass
    {
        DBconnect connect = new DBconnect();

        //hàm thêm lớp mới
        public bool insertLop(string tenLop, string namHoc, int maKhoa, int maGVCN)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `class`(`ClassName`, `SchoolYear`, `DeptId`, `TeacherId`) VALUES (@tl,@nh,@mk,@mgv)", connect.getconnection);
            command.Parameters.Add("@tl", MySqlDbType.VarChar).Value = tenLop;
            command.Parameters.Add("@nh", MySqlDbType.VarChar).Value = namHoc;
            command.Parameters.Add("@mk", MySqlDbType.Int32).Value = maKhoa;
            command.Parameters.Add("@mgv", MySqlDbType.Int32).Value = maGVCN;
            return run(command);
        }

        //hàm sửa lớp
        public bool updateLop(int maLop, string tenLop, string namHoc, int maKhoa, int maGVCN)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `class` SET `ClassName`=@tl,`SchoolYear`=@nh,`DeptId`=@mk,`TeacherId`=@mgv WHERE `ClassId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maLop;
            command.Parameters.Add("@tl", MySqlDbType.VarChar).Value = tenLop;
            command.Parameters.Add("@nh", MySqlDbType.VarChar).Value = namHoc;
            command.Parameters.Add("@mk", MySqlDbType.Int32).Value = maKhoa;
            command.Parameters.Add("@mgv", MySqlDbType.Int32).Value = maGVCN;
            return run(command);
        }

        //hàm xoá lớp, lớp còn học sinh hoặc còn trong thời khoá biểu thì không xoá được
        public bool deleteLop(int maLop)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `class` WHERE `ClassId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maLop;
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
                if (ex.Number == 1062 || ex.Number == 1451 || ex.Number == 1452)
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

        //câu select dùng chung: lớp kèm tên khoa, tên giáo viên chủ nhiệm và số học sinh
        private const string SELECT_LOP =
            "SELECT class.ClassId, class.ClassName, class.SchoolYear, department.DeptName, " +
            "IFNULL(teacher.TeacherName,'Chưa phân công') AS TeacherName, " +
            "(SELECT COUNT(*) FROM student_class WHERE student_class.ClassId = class.ClassId) AS SoHocSinh, " +
            "class.DeptId, class.TeacherId " +
            "FROM class " +
            "INNER JOIN department ON class.DeptId = department.DeptId " +
            "LEFT JOIN teacher ON class.TeacherId = teacher.TeacherId";

        //hàm lấy toàn bộ lớp
        public DataTable getAll()
        {
            return getList(new MySqlCommand(SELECT_LOP + " ORDER BY class.ClassId"));
        }

        //hàm lấy lớp cho combobox (chỉ mã và tên)
        public DataTable getComboBox()
        {
            return getList(new MySqlCommand("SELECT `ClassId`,`ClassName` FROM `class` ORDER BY `ClassName`"));
        }

        //hàm tìm lớp theo tên lớp, năm học, khoa hoặc giáo viên chủ nhiệm
        public DataTable searchLop(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand(SELECT_LOP + " WHERE CONCAT(class.ClassName, class.SchoolYear, department.DeptName, IFNULL(teacher.TeacherName,'')) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        //hàm đếm tổng số lớp
        public string tongLop()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM class", connect.getconnection);
            connect.openConnect();
            string dem = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return dem;
        }
    }
}
