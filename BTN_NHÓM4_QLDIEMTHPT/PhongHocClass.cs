using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng room (phòng học)
    class PhongHocClass
    {
        DBconnect connect = new DBconnect();

        //hàm thêm phòng học mới
        public bool insertPhong(string tenPhong, int sucChua)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `room`(`RoomName`, `Capacity`) VALUES (@tp,@sc)", connect.getconnection);
            command.Parameters.Add("@tp", MySqlDbType.VarChar).Value = tenPhong;
            command.Parameters.Add("@sc", MySqlDbType.Int32).Value = sucChua;
            return run(command);
        }

        //hàm sửa phòng học
        public bool updatePhong(int maPhong, string tenPhong, int sucChua)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `room` SET `RoomName`=@tp,`Capacity`=@sc WHERE `RoomId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maPhong;
            command.Parameters.Add("@tp", MySqlDbType.VarChar).Value = tenPhong;
            command.Parameters.Add("@sc", MySqlDbType.Int32).Value = sucChua;
            return run(command);
        }

        //hàm xoá phòng học, phòng đang có trong thời khoá biểu thì không xoá được
        public bool deletePhong(int maPhong)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `room` WHERE `RoomId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maPhong;
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

        //hàm lấy toàn bộ phòng học
        public DataTable getAll()
        {
            return getList(new MySqlCommand("SELECT * FROM `room` ORDER BY `RoomId`"));
        }

        //hàm tìm phòng học theo tên
        public DataTable searchPhong(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `room` WHERE `RoomName` LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }
    }
}
