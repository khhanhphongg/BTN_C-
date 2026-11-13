using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    class LoginClass
    {
        DBconnect connect = new DBconnect();

        //hàm chạy câu select, trả về DataTable
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //kiểm tra đăng nhập, đúng thì trả về dòng tài khoản, sai thì trả về null
        public DataRow kiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `login` WHERE `TenDangNhap`=@u AND `MatKhau`=@p");
            command.Parameters.AddWithValue("@u", tenDangNhap);
            command.Parameters.AddWithValue("@p", matKhau);
            DataTable table = getList(command);
            if (table.Rows.Count > 0)
                return table.Rows[0];
            else
                return null;
        }
    }
}
