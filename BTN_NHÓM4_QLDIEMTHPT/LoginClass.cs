using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    class LoginClass : DuLieuClass
    {
        //kiểm tra đăng nhập, đúng thì trả về dòng tài khoản, sai thì trả về null
        public DataRow kiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [login] WHERE [TenDangNhap]=@u AND [MatKhau]=@p");
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
