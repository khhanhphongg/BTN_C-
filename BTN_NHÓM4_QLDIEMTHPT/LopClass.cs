using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng class (lớp học, thuộc một khoa và có một giáo viên chủ nhiệm)
    class LopClass : DuLieuClass
    {
        public bool insertLop(string tenLop, string namHoc, int maKhoa, int maGVCN)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [class]([ClassName], [SchoolYear], [DeptId], [TeacherId]) VALUES (@tl,@nh,@mk,@mgv)");
            command.Parameters.Add("@tl", SqlDbType.NVarChar).Value = tenLop;
            command.Parameters.Add("@nh", SqlDbType.NVarChar).Value = namHoc;
            command.Parameters.Add("@mk", SqlDbType.Int).Value = maKhoa;
            command.Parameters.Add("@mgv", SqlDbType.Int).Value = maGVCN;
            return run(command);
        }

        public bool updateLop(int maLop, string tenLop, string namHoc, int maKhoa, int maGVCN)
        {
            SqlCommand command = new SqlCommand("UPDATE [class] SET [ClassName]=@tl,[SchoolYear]=@nh,[DeptId]=@mk,[TeacherId]=@mgv WHERE [ClassId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maLop;
            command.Parameters.Add("@tl", SqlDbType.NVarChar).Value = tenLop;
            command.Parameters.Add("@nh", SqlDbType.NVarChar).Value = namHoc;
            command.Parameters.Add("@mk", SqlDbType.Int).Value = maKhoa;
            command.Parameters.Add("@mgv", SqlDbType.Int).Value = maGVCN;
            return run(command);
        }

        //xoá lớp, lớp còn học sinh hoặc còn trong thời khoá biểu thì không xoá được
        public bool deleteLop(int maLop)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [class] WHERE [ClassId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maLop;
            return run(command);
        }

        //câu select dùng chung: lớp kèm tên khoa, tên giáo viên chủ nhiệm và số học sinh
        private const string SELECT_LOP =
            "SELECT class.ClassId, class.ClassName, class.SchoolYear, department.DeptName, " +
            "ISNULL(teacher.TeacherName,N'Chưa phân công') AS TeacherName, " +
            "(SELECT COUNT(*) FROM student_class WHERE student_class.ClassId = class.ClassId) AS SoHocSinh, " +
            "class.DeptId, class.TeacherId " +
            "FROM class " +
            "INNER JOIN department ON class.DeptId = department.DeptId " +
            "LEFT JOIN teacher ON class.TeacherId = teacher.TeacherId";

        public DataTable getAll()
        {
            return getList(new SqlCommand(SELECT_LOP + " ORDER BY class.ClassId"));
        }

        //lấy lớp cho combobox (chỉ mã và tên)
        public DataTable getComboBox()
        {
            return getList(new SqlCommand("SELECT [ClassId],[ClassName] FROM [class] ORDER BY [ClassName]"));
        }

        //tìm lớp theo tên lớp, năm học, khoa hoặc giáo viên chủ nhiệm
        public DataTable searchLop(string tuKhoa)
        {
            SqlCommand command = new SqlCommand(SELECT_LOP + " WHERE CONCAT(class.ClassName, class.SchoolYear, department.DeptName, ISNULL(teacher.TeacherName,'')) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        public string tongLop()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM class");
            return tinhMotGiaTri(command);
        }
    }
}
