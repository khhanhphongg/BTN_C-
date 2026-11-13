using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QLDiemTHPT
{
    //Quản lý bảng department (khoa / tổ bộ môn)
    class KhoaClass : DuLieuClass
    {
        //hàm thêm khoa mới
        public bool insertKhoa(string tenKhoa, string moTa)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `department`(`DeptName`, `Description`) VALUES (@tk,@mt)");
            command.Parameters.Add("@tk", MySqlDbType.VarChar).Value = tenKhoa;
            command.Parameters.Add("@mt", MySqlDbType.VarChar).Value = moTa;
            return run(command, 1062, 1451);
        }

        //hàm sửa khoa
        public bool updateKhoa(int maKhoa, string tenKhoa, string moTa)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `department` SET `DeptName`=@tk,`Description`=@mt WHERE `DeptId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maKhoa;
            command.Parameters.Add("@tk", MySqlDbType.VarChar).Value = tenKhoa;
            command.Parameters.Add("@mt", MySqlDbType.VarChar).Value = moTa;
            return run(command, 1062, 1451);
        }

        //hàm xoá khoa, khoa còn giáo viên hoặc lớp thì không xoá được
        public bool deleteKhoa(int maKhoa)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `department` WHERE `DeptId`=@ma");
            command.Parameters.Add("@ma", MySqlDbType.Int32).Value = maKhoa;
            return run(command, 1062, 1451);
        }

        //hàm lấy toàn bộ khoa
        public DataTable getAll()
        {
            return getList(new MySqlCommand("SELECT * FROM `department` ORDER BY `DeptId`"));
        }

        //hàm tìm khoa theo tên hoặc mô tả
        public DataTable searchKhoa(string tuKhoa)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `department` WHERE CONCAT(`DeptName`,`Description`) LIKE @s");
            command.Parameters.AddWithValue("@s", "%" + tuKhoa + "%");
            return getList(command);
        }

        //hàm đếm tổng số khoa
        public string tongKhoa()
        {
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM department");
            return tinhMotGiaTri(command);
        }
    }
}
