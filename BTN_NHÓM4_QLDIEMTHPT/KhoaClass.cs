using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng department (khoa / tổ bộ môn)
    class KhoaClass
    {
        DBconnect connect = new DBconnect();

        //hàm thêm khoa mới
        public bool insertKhoa(string tenKhoa, string moTa)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `department`(`DeptName`, `Description`) VALUES (@tk,@mt)", connect.getconnection);
            command.Parameters.Add("@tk", MySqlDbType.VarChar).Value = tenKhoa;
            command.Parameters.Add("@mt", MySqlDbType.VarChar).Value = moTa;
            return run(command);
        }

        //hàm sửa khoa
        public bool updateKhoa(int maKhoa, string tenKhoa, string moTa)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `department` SET `DeptName`=@tk,`Description`=@mt WHERE `DeptId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maKhoa;
            command.Parameters.Add("@tk", MySqlDbType.VarChar).Value = tenKhoa;
            command.Parameters.Add("@mt", MySqlDbType.VarChar).Value = moTa;
            return run(command);
        }

        //hàm xoá khoa, khoa còn giáo viên hoặc lớp thì không xoá được
        public bool deleteKhoa(int maKhoa)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `department` WHERE `DeptId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maKhoa;
            return run(command);
        }

        //chạy lệnh thêm/sửa/xoá, trùng tên (1062) hoặc còn dữ liệu liên quan (1451) thì trả về false
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

        //hàm lấy toàn bộ khoa
        public DataTable getAll()
        {
            return getList(new MySqlCommand("SELECT * FROM `department` ORDER BY `DeptId`"));
        }

        //hàm tìm khoa theo tên hoặc mô tả
        public DataTable searchKhoa(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `department` WHERE CONCAT(`DeptName`,`Description`) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        //hàm đếm tổng số khoa
        public string tongKhoa()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM department", connect.getconnection);
            connect.openConnect();
            string dem = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return dem;
        }
    }
}
