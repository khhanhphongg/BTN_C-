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
     * Quản lý bảng score - phần ĐẦU của bảng điểm.
     * Mỗi dòng là một môn của một học sinh, cột Score là điểm trung bình môn
     * và cột Description là học lực. Hai cột này do ChiTietDiemClass tính lại
     * tự động từ các đầu điểm, nên ở form bảng điểm người dùng chỉ mở môn cho
     * học sinh chứ không nhập tay điểm trung bình.
     */
    class BangDiemClass
    {
        DBconnect connect = new DBconnect();

        //hàm mở một môn cho học sinh (thêm dòng vào bảng score, điểm ban đầu là 0)
        public bool insertBangDiem(int maHS, string tenMon)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `score`(`StudentId`, `CourseName`, `Score`, `Description`) VALUES (@mhs,@tm,0,'Chưa có điểm')", connect.getconnection);
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@tm", MySqlDbType.VarChar).Value = tenMon;
            return run(command);
        }

        //hàm xoá một môn của học sinh, các đầu điểm của môn đó tự xoá theo
        public bool deleteBangDiem(int maHS, string tenMon)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `score` WHERE `StudentId`=@mhs AND `CourseName`=@tm", connect.getconnection);
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@tm", MySqlDbType.VarChar).Value = tenMon;
            return run(command);
        }

        //chạy lệnh thêm/xoá, trùng khoá chính (1062) hoặc không có học sinh/môn (1452) thì trả về false
        private bool run(MySqlCommand command)
        {
            try
            {
                connect.openConnect();
                return command.ExecuteNonQuery() == 1;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062 || ex.Number == 1452)
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

        //câu select dùng chung: bảng điểm kèm họ tên học sinh, tên lớp và số đầu điểm
        private const string SELECT_BD =
            "SELECT score.StudentId, CONCAT(student.StdLastName,' ',student.StdFirstName) AS HoTen, " +
            "IFNULL(class.ClassName,'Chưa xếp lớp') AS ClassName, score.CourseName, score.Score, score.Description, " +
            "(SELECT COUNT(*) FROM diem_chitiet d WHERE d.StudentId = score.StudentId AND d.CourseName = score.CourseName) AS SoDauDiem " +
            "FROM score " +
            "INNER JOIN student ON score.StudentId = student.StdId " +
            "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
            "LEFT JOIN class ON student_class.ClassId = class.ClassId";

        //hàm lấy toàn bộ bảng điểm
        public DataTable getAll()
        {
            return getList(new MySqlCommand(SELECT_BD + " ORDER BY score.StudentId, score.CourseName"));
        }

        //hàm tìm theo họ tên học sinh, tên lớp, tên môn hoặc học lực
        public DataTable searchBangDiem(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand(SELECT_BD + " WHERE CONCAT(student.StdLastName, student.StdFirstName, IFNULL(class.ClassName,''), score.CourseName, score.Description) LIKE @s ORDER BY score.StudentId");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        //hàm lấy bảng điểm của một học sinh
        public DataTable getBangDiemHocSinh(int maHS)
        {
            MySqlCommand command = new MySqlCommand(SELECT_BD + " WHERE score.StudentId=@mhs ORDER BY score.CourseName");
            command.Parameters.AddWithValue("@mhs", maHS);
            return getList(command);
        }

        //hàm kiểm tra học sinh đã được mở môn này chưa
        public bool kiemTraDaCo(int maHS, string tenMon)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `score` WHERE `StudentId`=@mhs AND `CourseName`=@tm");
            command.Parameters.AddWithValue("@mhs", maHS);
            command.Parameters.AddWithValue("@tm", tenMon);
            return getList(command).Rows.Count > 0;
        }

        //hàm tính điểm trung bình tất cả các môn của một học sinh
        public string diemTBHocSinh(int maHS)
        {
            MySqlCommand command = new MySqlCommand("SELECT IFNULL(ROUND(AVG(Score),2),0) FROM score WHERE StudentId=@mhs", connect.getconnection);
            command.Parameters.AddWithValue("@mhs", maHS);
            connect.openConnect();
            string tb = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return tb;
        }
    }
}
