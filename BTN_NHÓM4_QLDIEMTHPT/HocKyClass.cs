using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng semester (học kỳ)
    class HocKyClass
    {
        DBconnect connect = new DBconnect();

        //hàm thêm học kỳ mới
        public bool insertHocKy(string tenHK, DateTime batDau, DateTime ketThuc)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `semester`(`SemesterName`, `StartDate`, `EndDate`) VALUES (@tn,@bd,@kt)", connect.getconnection);
            command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = tenHK;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = batDau;
            command.Parameters.Add("@kt", MySqlDbType.Date).Value = ketThuc;
            return run(command);
        }

        //hàm sửa học kỳ
        public bool updateHocKy(int maHK, string tenHK, DateTime batDau, DateTime ketThuc)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `semester` SET `SemesterName`=@tn,`StartDate`=@bd,`EndDate`=@kt WHERE `SemesterId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maHK;
            command.Parameters.Add("@tn", MySqlDbType.VarChar).Value = tenHK;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = batDau;
            command.Parameters.Add("@kt", MySqlDbType.Date).Value = ketThuc;
            return run(command);
        }

        //hàm xoá học kỳ, học kỳ đang có điểm, thời khoá biểu hoặc học phí thì không xoá được
        public bool deleteHocKy(int maHK)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `semester` WHERE `SemesterId`=@ma", connect.getconnection);
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maHK;
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

        //hàm lấy toàn bộ học kỳ
        public DataTable getAll()
        {
            return getList(new MySqlCommand("SELECT * FROM `semester` ORDER BY `SemesterId`"));
        }

        //hàm tìm học kỳ theo tên
        public DataTable searchHocKy(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `semester` WHERE `SemesterName` LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }
    }
}
