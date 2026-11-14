using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng semester (học kỳ)
    class HocKyClass : DuLieuClass
    {
        public bool insertHocKy(string tenHK, DateTime batDau, DateTime ketThuc)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [semester]([SemesterName], [StartDate], [EndDate]) VALUES (@tn,@bd,@kt)");
            command.Parameters.Add("@tn", SqlDbType.NVarChar).Value = tenHK;
            command.Parameters.Add("@bd", SqlDbType.Date).Value = batDau;
            command.Parameters.Add("@kt", SqlDbType.Date).Value = ketThuc;
            return run(command);
        }

        public bool updateHocKy(int maHK, string tenHK, DateTime batDau, DateTime ketThuc)
        {
            SqlCommand command = new SqlCommand("UPDATE [semester] SET [SemesterName]=@tn,[StartDate]=@bd,[EndDate]=@kt WHERE [SemesterId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maHK;
            command.Parameters.Add("@tn", SqlDbType.NVarChar).Value = tenHK;
            command.Parameters.Add("@bd", SqlDbType.Date).Value = batDau;
            command.Parameters.Add("@kt", SqlDbType.Date).Value = ketThuc;
            return run(command);
        }

        //xoá học kỳ, học kỳ đang có điểm, thời khoá biểu hoặc học phí thì không xoá được
        public bool deleteHocKy(int maHK)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [semester] WHERE [SemesterId]=@ma");
            command.Parameters.Add("@ma", SqlDbType.Int).Value = maHK;
            return run(command);
        }

        public DataTable getAll()
        {
            return getList(new SqlCommand("SELECT * FROM [semester] ORDER BY [SemesterId]"));
        }

        public DataTable searchHocKy(string tuKhoa)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [semester] WHERE [SemesterName] LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }
    }
}
