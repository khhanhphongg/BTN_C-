using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    abstract class DuLieuClass
    {
        protected DBconnect connect = new DBconnect();

        protected SqlCommand ganKetNoi(SqlCommand command)
        {
            command.Connection = connect.getconnection;
            return command;
        }

        public DataTable getList(SqlCommand command)
        {
            command.Connection = connect.getconnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        protected bool run(SqlCommand command)
        {
            command.Connection = connect.getconnection;
            try
            {
                connect.openConnect();
                return command.ExecuteNonQuery() == 1;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                connect.closeConnect();
            }
        }

        protected int runNhieuDong(SqlCommand command)
        {
            command.Connection = connect.getconnection;
            try
            {
                connect.openConnect();
                return command.ExecuteNonQuery();
            }
            finally
            {
                connect.closeConnect();
            }
        }

        protected string tinhMotGiaTri(SqlCommand command)
        {
            command.Connection = connect.getconnection;
            try
            {
                connect.openConnect();
                return command.ExecuteScalar().ToString();
            }
            finally
            {
                connect.closeConnect();
            }
        }

        protected string tinhMotGiaTri(string cauLenh)
        {
            return tinhMotGiaTri(new SqlCommand(cauLenh));
        }
    }
}
