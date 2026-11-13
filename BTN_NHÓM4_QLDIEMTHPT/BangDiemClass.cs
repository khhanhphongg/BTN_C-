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
     * Quản lý bảng score. Mỗi dòng là một môn của một học sinh, cột Score là
     * điểm trung bình môn, cột Description là học lực. Hai cột này do
     * ChiTietDiemClass tính từ các đầu điểm nên không nhập tay.
     */
    class BangDiemClass : DuLieuClass
    {
        //mở một môn cho học sinh, điểm ban đầu là 0
        public bool insertBangDiem(int maHS, string tenMon)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `score`(`StudentId`, `CourseName`, `Score`, `Description`) VALUES (@mhs,@tm,0,'Chưa có điểm')");
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@tm", MySqlDbType.VarChar).Value = tenMon;
            return run(command);
        }

        //xoá một môn của học sinh, phải xoá các đầu điểm của môn trước
        public bool deleteBangDiem(int maHS, string tenMon)
        {
            MySqlCommand xoaDauDiem = new MySqlCommand("DELETE FROM `diem_chitiet` WHERE `StudentId`=@mhs AND `CourseName`=@tm");
            xoaDauDiem.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            xoaDauDiem.Parameters.Add("@tm", MySqlDbType.VarChar).Value = tenMon;
            runNhieuDong(xoaDauDiem);

            MySqlCommand command = new MySqlCommand("DELETE FROM `score` WHERE `StudentId`=@mhs AND `CourseName`=@tm");
            command.Parameters.Add("@mhs", MySqlDbType.Int32).Value = maHS;
            command.Parameters.Add("@tm", MySqlDbType.VarChar).Value = tenMon;
            return run(command);
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

        public DataTable getAll()
        {
            return getList(new MySqlCommand(SELECT_BD + " ORDER BY score.StudentId, score.CourseName"));
        }

        //tìm theo họ tên học sinh, tên lớp, tên môn hoặc học lực
        public DataTable searchBangDiem(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand(SELECT_BD + " WHERE CONCAT(student.StdLastName, student.StdFirstName, IFNULL(class.ClassName,''), score.CourseName, score.Description) LIKE @s ORDER BY score.StudentId");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        public DataTable getBangDiemHocSinh(int maHS)
        {
            MySqlCommand command = new MySqlCommand(SELECT_BD + " WHERE score.StudentId=@mhs ORDER BY score.CourseName");
            command.Parameters.AddWithValue("@mhs", maHS);
            return getList(command);
        }

        public bool kiemTraDaCo(int maHS, string tenMon)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `score` WHERE `StudentId`=@mhs AND `CourseName`=@tm");
            command.Parameters.AddWithValue("@mhs", maHS);
            command.Parameters.AddWithValue("@tm", tenMon);
            return getList(command).Rows.Count > 0;
        }

        public string diemTBHocSinh(int maHS)
        {
            MySqlCommand command = new MySqlCommand("SELECT IFNULL(ROUND(AVG(Score),2),0) FROM score WHERE StudentId=@mhs");
            command.Parameters.AddWithValue("@mhs", maHS);
            return tinhMotGiaTri(command);
        }
    }
}
