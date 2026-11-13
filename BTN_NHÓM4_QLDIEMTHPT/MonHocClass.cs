using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng course (danh mục môn học)
    class MonHocClass : DuLieuClass
    {
        public bool insertMonHoc(string tenMon, int soTiet, string moTa)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `course`(`CourseName`, `CourseHour`, `Description`) VALUES (@tm,@st,@mt)");
            command.Parameters.Add("@tm", MySqlDbType.VarChar).Value = tenMon;
            command.Parameters.Add("@st", MySqlDbType.Int32).Value = soTiet;
            command.Parameters.Add("@mt", MySqlDbType.VarChar).Value = moTa;
            return run(command);
        }

        //sửa môn học, đổi tên môn thì điểm trong bảng score tự đổi theo (ON UPDATE CASCADE)
        public bool updateMonHoc(int maMon, string tenMon, int soTiet, string moTa)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `course` SET `CourseName`=@tm,`CourseHour`=@st,`Description`=@mt WHERE `CourseId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maMon;
            command.Parameters.Add("@tm", MySqlDbType.VarChar).Value = tenMon;
            command.Parameters.Add("@st", MySqlDbType.Int32).Value = soTiet;
            command.Parameters.Add("@mt", MySqlDbType.VarChar).Value = moTa;
            return run(command);
        }

        //xoá môn học, điểm của môn đó cũng bị xoá theo (ON DELETE CASCADE)
        public bool deleteMonHoc(int maMon)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `course` WHERE `CourseId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maMon;
            return run(command);
        }

        public DataTable getAll()
        {
            return getList(new MySqlCommand("SELECT * FROM `course` ORDER BY `CourseId`"));
        }

        public DataTable searchMonHoc(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `course` WHERE CONCAT(`CourseName`,`Description`) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        public string tongMonHoc()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM course");
            return tinhMotGiaTri(command);
        }
    }
}
