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
    class PhongHocClass : DuLieuClass
    {
        //hàm thêm phòng học mới
        public bool insertPhong(string tenPhong, int sucChua)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `room`(`RoomName`, `Capacity`) VALUES (@tp,@sc)");
            command.Parameters.Add("@tp", MySqlDbType.VarChar).Value = tenPhong;
            command.Parameters.Add("@sc", MySqlDbType.Int32).Value = sucChua;
            return run(command, 1062, 1451);
        }

        //hàm sửa phòng học
        public bool updatePhong(int maPhong, string tenPhong, int sucChua)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `room` SET `RoomName`=@tp,`Capacity`=@sc WHERE `RoomId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maPhong;
            command.Parameters.Add("@tp", MySqlDbType.VarChar).Value = tenPhong;
            command.Parameters.Add("@sc", MySqlDbType.Int32).Value = sucChua;
            return run(command, 1062, 1451);
        }

        //hàm xoá phòng học, phòng đang có trong thời khoá biểu thì không xoá được
        public bool deletePhong(int maPhong)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `room` WHERE `RoomId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maPhong;
            return run(command, 1062, 1451);
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
