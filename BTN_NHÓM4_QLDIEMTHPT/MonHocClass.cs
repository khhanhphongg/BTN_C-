using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng course (danh mục môn học)
    class MonHocClass : DuLieuClass
    {
        public bool insertMonHoc(string tenMon, int soTiet, string moTa)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [course]([CourseName], [CourseHour], [Description]) VALUES (@tm,@st,@mt)");
            command.Parameters.Add("@tm", SqlDbType.NVarChar).Value = tenMon;
            command.Parameters.Add("@st", SqlDbType.Int).Value = soTiet;
            command.Parameters.Add("@mt", SqlDbType.NVarChar).Value = moTa;
            return run(command);
        }

        //sửa môn học, đổi tên môn thì điểm trong bảng score tự đổi theo (ON UPDATE CASCADE)
        public bool updateMonHoc(int maMon, string tenMon, int soTiet, string moTa)
        {
            SqlCommand command = new SqlCommand("UPDATE [course] SET [CourseName]=@tm,[CourseHour]=@st,[Description]=@mt WHERE [CourseId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maMon;
            command.Parameters.Add("@tm", SqlDbType.NVarChar).Value = tenMon;
            command.Parameters.Add("@st", SqlDbType.Int).Value = soTiet;
            command.Parameters.Add("@mt", SqlDbType.NVarChar).Value = moTa;
            return run(command);
        }

        //xoá môn học, điểm của môn đó cũng bị xoá theo (ON DELETE CASCADE)
        public bool deleteMonHoc(int maMon)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [course] WHERE [CourseId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maMon;
            return run(command);
        }

        public DataTable getAll()
        {
            return getList(new SqlCommand("SELECT * FROM [course] ORDER BY [CourseId]"));
        }

        public DataTable searchMonHoc(string tuKhoa)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [course] WHERE CONCAT([CourseName],[Description]) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        public string tongMonHoc()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM course");
            return tinhMotGiaTri(command);
        }
    }
}
