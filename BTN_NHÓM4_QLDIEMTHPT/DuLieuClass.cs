using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    /*
     * Lớp cơ sở cho tất cả các lớp nghiệp vụ.
     *
     * Ba việc dưới đây lớp nào cũng phải làm, nên gom về đây một lần thay vì
     * viết lại ở từng lớp:
     *    - getList()        : chạy một câu SELECT, trả về DataTable
     *    - run()            : chạy một câu INSERT/UPDATE/DELETE
     *    - tinhMotGiaTri()  : chạy câu COUNT, SUM, AVG... trả về một giá trị
     *
     * Cả ba hàm đều tự gán Connection và tự mở/đóng kết nối, nên các lớp con
     * chỉ cần tạo MySqlCommand với câu lệnh và tham số là đủ.
     *
     * Các lớp con khai báo: class XxxClass : DuLieuClass
     */
    abstract class DuLieuClass
    {
        //kết nối dùng chung cho lớp con
        protected DBconnect connect = new DBconnect();

        /*
         * Hàm gán kết nối cho một câu lệnh rồi trả lại chính nó.
         * Dùng cho mấy chỗ phải tự mở kết nối để chạy nhiều câu lệnh liên tiếp
         * trong cùng một lần mở, ví dụ thêm học sinh rồi xếp lớp luôn.
         */
        protected MySqlCommand ganKetNoi(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            return command;
        }

        //hàm chạy câu select bất kỳ, trả về DataTable để đổ lên DataGridView
        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        /*
         * Hàm chạy lệnh thêm/sửa/xoá, trả về true khi đúng 1 dòng bị tác động.
         *
         * boQuaLoi là danh sách mã lỗi MySQL được coi là "người dùng nhập sai"
         * chứ không phải lỗi chương trình, khi gặp thì trả về false để form
         * hiện thông báo thân thiện. Các mã hay dùng:
         *    1062 - trùng khoá chính hoặc trùng cột UNIQUE
         *    1451 - còn dữ liệu con nên không xoá được (khoá ngoại)
         *    1452 - mã cha không tồn tại (khoá ngoại)
         * Mã lỗi khác vẫn được ném ra ngoài để không che mất lỗi thật.
         */
        protected bool run(MySqlCommand command, params int[] boQuaLoi)
        {
            command.Connection = connect.getconnection;
            try
            {
                connect.openConnect();
                return command.ExecuteNonQuery() == 1;
            }
            catch (MySqlException ex)
            {
                foreach (int ma in boQuaLoi)
                {
                    if (ex.Number == ma)
                        return false;
                }
                throw;
            }
            finally
            {
                connect.closeConnect();
            }
        }

        /*
         * Hàm chạy lệnh tác động NHIỀU dòng (hoặc không dòng nào), trả về số
         * dòng đã tác động. Dùng cho mấy chỗ xoá hàng loạt, vì run() ở trên
         * chỉ đúng khi lệnh tác động chính xác một dòng.
         */
        protected int runNhieuDong(MySqlCommand command)
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

        //hàm chạy câu lệnh trả về một giá trị (COUNT, SUM, AVG...)
        protected string tinhMotGiaTri(MySqlCommand command)
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

        //dạng rút gọn khi câu lệnh không có tham số
        protected string tinhMotGiaTri(string cauLenh)
        {
            return tinhMotGiaTri(new MySqlCommand(cauLenh));
        }
    }
}
