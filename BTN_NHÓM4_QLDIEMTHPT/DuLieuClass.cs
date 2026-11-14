using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    /*
     * Lớp cơ sở cho các lớp nghiệp vụ. Gom mấy việc lớp nào cũng dùng:
     * chạy câu select, chạy câu thêm/sửa/xoá, chạy câu tính một giá trị.
     * Lớp con khai báo: class XxxClass : DuLieuClass
     */
    abstract class DuLieuClass
    {
        protected DBconnect connect = new DBconnect();

        //gán kết nối cho một câu lệnh, dùng khi phải tự mở kết nối để chạy nhiều câu liên tiếp
        protected SqlCommand ganKetNoi(SqlCommand command)
        {
            command.Connection = connect.getconnection;
            return command;
        }

        //chạy câu select, trả về DataTable để đổ lên DataGridView
        public DataTable getList(SqlCommand command)
        {
            command.Connection = connect.getconnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //chạy câu thêm/sửa/xoá, trả về true khi được 1 dòng
        //lỗi SQL Server (trùng khoá, còn dữ liệu con...) thì trả về false để form báo lại cho người dùng
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

        //chạy câu tác động nhiều dòng, trả về số dòng đã tác động
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

        //chạy câu COUNT, SUM, AVG... trả về một giá trị
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
