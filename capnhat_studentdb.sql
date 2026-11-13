
-- =====================================================================
-- BTN_NHÓM4_QLDIEMTHPT - Script cập nhật cơ sở dữ liệu studentdb
--
-- Script này KHÔNG xoá và KHÔNG tạo lại studentdb.
-- Nó chỉ bổ sung thêm 2 bảng vào CSDL đang có:
--    1. login        - bảng đăng nhập hệ thống (yêu cầu số 4 của đề)
--    2. diem_chitiet - các đầu điểm của một môn (miệng, 15 phút, 1 tiết, thi)
--
-- Cách chạy: mở phpMyAdmin > chọn CSDL studentdb > tab SQL > dán file này > Go
-- =====================================================================

SET NAMES utf8mb4;
USE studentdb;

-- ---------------------------------------------------------------------
-- 1. BẢNG LOGIN
-- Bảng `user` cũ chỉ có username và password, không biết ai đang đăng nhập.
-- Bảng login bổ sung thêm họ tên và vai trò để hiện lên form chính.
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS login (
    MaND INT AUTO_INCREMENT PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(50) NOT NULL,
    HoTen VARCHAR(100) NOT NULL,
    VaiTro VARCHAR(20) NOT NULL
);

INSERT IGNORE INTO login (TenDangNhap, MatKhau, HoTen, VaiTro) VALUES
('admin', 'admin123', 'Quản trị hệ thống', 'Admin'),
('giaovien', '123456', 'Nguyễn Văn Minh', 'Giáo viên'),
('vanphong', '123456', 'Trần Thị Lan', 'Văn phòng');

-- ---------------------------------------------------------------------
-- 2. BẢNG CHI TIẾT ĐIỂM (các đầu điểm của một môn)
--
-- Bảng `score` cũ giữ nguyên, nó trở thành phần ĐẦU (điểm trung bình môn
-- và học lực). Bảng diem_chitiet là phần CHI TIẾT: mỗi môn của mỗi học sinh
-- có nhiều đầu điểm, mỗi đầu điểm có hệ số riêng.
--
-- Điểm trung bình môn = SUM(Diem * HeSo) / SUM(HeSo), chương trình tự tính
-- lại và ghi vào score.Score mỗi khi thêm/sửa/xoá một đầu điểm.
-- ---------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS diem_chitiet (
    MaCT INT AUTO_INCREMENT PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseName VARCHAR(100) NOT NULL,
    SemesterId INT NOT NULL,
    LoaiDiem VARCHAR(20) NOT NULL,
    Diem DOUBLE NOT NULL,
    HeSo INT NOT NULL DEFAULT 1,
    GhiChu VARCHAR(200),
    FOREIGN KEY (StudentId, CourseName) REFERENCES score(StudentId, CourseName)
        ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (SemesterId) REFERENCES semester(SemesterId)
);

-- ---------------------------------------------------------------------
-- 3. Chuyển dữ liệu điểm đang có thành đầu điểm "Thi"
-- 106 dòng trong bảng score hiện chưa có đầu điểm nào. Dòng lệnh dưới đây
-- tạo cho mỗi dòng một đầu điểm "Thi" hệ số 1 bằng đúng điểm cũ, để điểm
-- trung bình môn tính ra vẫn khớp với điểm đang lưu.
-- ---------------------------------------------------------------------
INSERT INTO diem_chitiet (StudentId, CourseName, SemesterId, LoaiDiem, Diem, HeSo, GhiChu)
SELECT score.StudentId, score.CourseName, 3, 'Thi', score.Score, 1, 'Chuyển từ dữ liệu điểm cũ'
FROM score
WHERE NOT EXISTS (
    SELECT 1 FROM diem_chitiet d
    WHERE d.StudentId = score.StudentId AND d.CourseName = score.CourseName
);

-- ---------------------------------------------------------------------
-- 4. Kiểm tra kết quả
-- ---------------------------------------------------------------------
SELECT 'login' AS Bang, COUNT(*) AS SoDong FROM login
UNION ALL SELECT 'diem_chitiet', COUNT(*) FROM diem_chitiet
UNION ALL SELECT 'score', COUNT(*) FROM score
UNION ALL SELECT 'student', COUNT(*) FROM student
UNION ALL SELECT 'course', COUNT(*) FROM course
UNION ALL SELECT 'teacher', COUNT(*) FROM teacher
UNION ALL SELECT 'class', COUNT(*) FROM class
UNION ALL SELECT 'department', COUNT(*) FROM department
UNION ALL SELECT 'room', COUNT(*) FROM room
UNION ALL SELECT 'semester', COUNT(*) FROM semester
UNION ALL SELECT 'schedule', COUNT(*) FROM schedule
UNION ALL SELECT 'attendance', COUNT(*) FROM attendance
UNION ALL SELECT 'tuition', COUNT(*) FROM tuition
UNION ALL SELECT 'student_class', COUNT(*) FROM student_class;
