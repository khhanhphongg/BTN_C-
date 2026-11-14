using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng room (phòng học)
    class PhongHocClass : DuLieuClass
    {
        public bool insertPhong(string tenPhong, int sucChua)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [room]([RoomName], [Capacity]) VALUES (@tp,@sc)");
            command.Parameters.Add("@tp", SqlDbType.NVarChar).Value = tenPhong;
            command.Parameters.Add("@sc", SqlDbType.Int).Value = sucChua;
            return run(command);
        }

        public bool updatePhong(int maPhong, string tenPhong, int sucChua)
        {
            SqlCommand command = new SqlCommand("UPDATE [room] SET [RoomName]=@tp,[Capacity]=@sc WHERE [RoomId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maPhong;
            command.Parameters.Add("@tp", SqlDbType.NVarChar).Value = tenPhong;
            command.Parameters.Add("@sc", SqlDbType.Int).Value = sucChua;
            return run(command);
        }

        //xoá phòng học, phòng đang có trong thời khoá biểu thì không xoá được
        public bool deletePhong(int maPhong)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [room] WHERE [RoomId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maPhong;
            return run(command);
        }

        public DataTable getAll()
        {
            return getList(new SqlCommand("SELECT * FROM [room] ORDER BY [RoomId]"));
        }

        public DataTable searchPhong(string tuKhoa)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [room] WHERE [RoomName] LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }
    }
}
