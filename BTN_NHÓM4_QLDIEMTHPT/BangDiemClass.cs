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
     * Quản lý bảng score. Mỗi dòng là một môn của một học sinh, cột Score là
     * điểm trung bình môn, cột Description là học lực. Hai cột này do
     * ChiTietDiemClass tính từ các đầu điểm nên không nhập tay.
     */
    class BangDiemClass : DuLieuClass
    {
        //mở một môn cho học sinh, điểm ban đầu là 0
        public bool insertBangDiem(int maHS, string tenMon)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [score]([StudentId], [CourseName], [Score], [Description]) VALUES (@mhs,@tm,0,N'Chưa có điểm')");
            command.Parameters.Add("@mhs", SqlDbType.Int).Value = maHS;
            command.Parameters.Add("@tm", SqlDbType.NVarChar).Value = tenMon;
            return run(command);
        }

        //xoá một môn của học sinh, phải xoá các đầu điểm của môn trước
        public bool deleteBangDiem(int maHS, string tenMon)
        {
            SqlCommand xoaDauDiem = new SqlCommand("DELETE FROM [diem_chitiet] WHERE [StudentId]=@mhs AND [CourseName]=@tm");
            xoaDauDiem.Parameters.Add("@mhs", SqlDbType.Int).Value = maHS;
            xoaDauDiem.Parameters.Add("@tm", SqlDbType.NVarChar).Value = tenMon;
            runNhieuDong(xoaDauDiem);

            SqlCommand command = new SqlCommand("DELETE FROM [score] WHERE [StudentId]=@mhs AND [CourseName]=@tm");
            command.Parameters.Add("@mhs", SqlDbType.Int).Value = maHS;
            command.Parameters.Add("@tm", SqlDbType.NVarChar).Value = tenMon;
            return run(command);
        }

        //câu select dùng chung: bảng điểm kèm họ tên học sinh, tên lớp và số đầu điểm
        private const string SELECT_BD =
            "SELECT score.StudentId, CONCAT(student.StdLastName,' ',student.StdFirstName) AS HoTen, " +
            "ISNULL(class.ClassName,N'Chưa xếp lớp') AS ClassName, score.CourseName, score.Score, score.Description, " +
            "(SELECT COUNT(*) FROM diem_chitiet d WHERE d.StudentId = score.StudentId AND d.CourseName = score.CourseName) AS SoDauDiem " +
            "FROM score " +
            "INNER JOIN student ON score.StudentId = student.StdId " +
            "LEFT JOIN student_class ON student.StdId = student_class.StudentId " +
            "LEFT JOIN class ON student_class.ClassId = class.ClassId";

        public DataTable getAll()
        {
            return getList(new SqlCommand(SELECT_BD + " ORDER BY score.StudentId, score.CourseName"));
        }

        //tìm theo họ tên học sinh, tên lớp, tên môn hoặc học lực
        public DataTable searchBangDiem(string tuKhoa)
        {
            SqlCommand command = new SqlCommand(SELECT_BD + " WHERE CONCAT(student.StdLastName, student.StdFirstName, ISNULL(class.ClassName,''), score.CourseName, score.Description) LIKE @s ORDER BY score.StudentId");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        public DataTable getBangDiemHocSinh(int maHS)
        {
            SqlCommand command = new SqlCommand(SELECT_BD + " WHERE score.StudentId=@mhs ORDER BY score.CourseName");
            command.Parameters.AddWithValue("@mhs", maHS);
            return getList(command);
        }

        public bool kiemTraDaCo(int maHS, string tenMon)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [score] WHERE [StudentId]=@mhs AND [CourseName]=@tm");
            command.Parameters.AddWithValue("@mhs", maHS);
            command.Parameters.AddWithValue("@tm", tenMon);
            return getList(command).Rows.Count > 0;
        }

        public string diemTBHocSinh(int maHS)
        {
            SqlCommand command = new SqlCommand("SELECT ISNULL(ROUND(AVG(Score),2),0) FROM score WHERE StudentId=@mhs");
            command.Parameters.AddWithValue("@mhs", maHS);
            return tinhMotGiaTri(command);
        }
    }
}
