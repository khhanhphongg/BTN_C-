using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng department (khoa / tổ bộ môn)
    class KhoaClass : DuLieuClass
    {
        public bool insertKhoa(string tenKhoa, string moTa)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [department]([DeptName], [Description]) VALUES (@tk,@mt)");
            command.Parameters.Add("@tk", SqlDbType.NVarChar).Value = tenKhoa;
            command.Parameters.Add("@mt", SqlDbType.NVarChar).Value = moTa;
            return run(command);
        }

        public bool updateKhoa(int maKhoa, string tenKhoa, string moTa)
        {
            SqlCommand command = new SqlCommand("UPDATE [department] SET [DeptName]=@tk,[Description]=@mt WHERE [DeptId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maKhoa;
            command.Parameters.Add("@tk", SqlDbType.NVarChar).Value = tenKhoa;
            command.Parameters.Add("@mt", SqlDbType.NVarChar).Value = moTa;
            return run(command);
        }

        //xoá khoa, khoa còn giáo viên hoặc lớp thì không xoá được
        public bool deleteKhoa(int maKhoa)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [department] WHERE [DeptId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maKhoa;
            return run(command);
        }

        public DataTable getAll()
        {
            return getList(new SqlCommand("SELECT * FROM [department] ORDER BY [DeptId]"));
        }

        public DataTable searchKhoa(string tuKhoa)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [department] WHERE CONCAT([DeptName],[Description]) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        public string tongKhoa()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM department");
            return tinhMotGiaTri(command);
        }
    }
}
