using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng course (danh mục môn học)
    class MonHocClass
    {
        DBconnect connect = new DBconnect();

        //hàm thêm môn học mới
        public bool insertMonHoc(string tenMon, int soTiet, string moTa)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `course`(`CourseName`, `CourseHour`, `Description`) VALUES (@tm,@st,@mt)", connect.getconnection);
            command.Parameters.Add("@tm", MySqlDbType.VarChar).Value = tenMon;
            command.Parameters.Add("@st", MySqlDbType.Int32).Value = soTiet;
            command.Parameters.Add("@mt", MySqlDbType.VarChar).Value = moTa;
            return run(command);
        }

        //hàm sửa môn học, đổi tên môn thì điểm trong bảng score tự đổi theo (ON UPDATE CASCADE)
        public bool updateMonHoc(int maMon, string tenMon, int soTiet, string moTa)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `course` SET `CourseName`=@tm,`CourseHour`=@st,`Description`=@mt WHERE `CourseId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maMon;
            command.Parameters.Add("@tm", MySqlDbType.VarChar).Value = tenMon;
            command.Parameters.Add("@st", MySqlDbType.Int32).Value = soTiet;
            command.Parameters.Add("@mt", MySqlDbType.VarChar).Value = moTa;
            return run(command);
        }

        //hàm xoá môn học, điểm của môn đó cũng bị xoá theo (ON DELETE CASCADE)
        public bool deleteMonHoc(int maMon)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `course` WHERE `CourseId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maMon;
            return run(command);
        }

        //chạy lệnh thêm/sửa/xoá, trùng tên môn (1062) thì trả về false
        private bool run(MySqlCommand command)
        {
            try
            {
                connect.openConnect();
                return command.ExecuteNonQuery() == 1;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062 || ex.Number == 1451)
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

        //hàm lấy toàn bộ môn học
        public DataTable getAll()
        {
            return getList(new MySqlCommand("SELECT * FROM `course` ORDER BY `CourseId`"));
        }

        //hàm tìm môn học theo tên hoặc mô tả
        public DataTable searchMonHoc(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `course` WHERE CONCAT(`CourseName`,`Description`) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        //hàm đếm tổng số môn học
        public string tongMonHoc()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM course", connect.getconnection);
            connect.openConnect();
            string dem = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return dem;
        }
    }
}
