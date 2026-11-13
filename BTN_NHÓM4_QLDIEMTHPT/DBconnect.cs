using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    /*
     * Lớp này tạo kết nối giữa chương trình và CSDL MySQL studentdb.
     * Cần cài XAMPP và MySQL Connector/NET cho project.
     * Trước khi chạy phải chạy file capnhat_studentdb.sql để bổ sung
     * hai bảng login và diem_chitiet vào studentdb.
     */

    class DBconnect
    {
        //tạo kết nối
        MySqlConnection connect = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=studentdb;charset=utf8mb4");

        //lấy kết nối ra dùng
        public MySqlConnection getconnection
        {
            get
            {
                return connect;
            }
        }

        //hàm mở kết nối
        public void openConnect()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
                connect.Open();
        }

        //hàm đóng kết nối
        public void closeConnect()
        {
            if (connect.State == System.Data.ConnectionState.Open)
                connect.Close();
        }
    }
}
