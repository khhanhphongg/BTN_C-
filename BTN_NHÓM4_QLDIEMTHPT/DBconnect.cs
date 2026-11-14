using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    //Lớp tạo kết nối tới CSDL SQL Server studentdb
    class DBconnect
    {
        SqlConnection connect = new SqlConnection("Data Source=localhost,1433;Initial Catalog=studentdb;Integrated Security=True");

        public SqlConnection getconnection
        {
            get
            {
                return connect;
            }
        }

        public void openConnect()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
                connect.Open();
        }

        public void closeConnect()
        {
            if (connect.State == System.Data.ConnectionState.Open)
                connect.Close();
        }
    }
}