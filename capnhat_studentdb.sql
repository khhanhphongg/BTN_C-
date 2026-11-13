-- =====================================================================
--  BTN_NHÓM4_QLDIEMTHPT - Cơ sở dữ liệu studentdb
--
--  Cách chạy: mở phpMyAdmin, vào tab SQL, dán cả file này rồi bấm Go.
--  Không cần chọn CSDL trước, file tự tạo studentdb nếu chưa có.
--
--  Gồm 14 bảng: 12 bảng gốc kèm dữ liệu mẫu (phần A), thêm hai bảng
--  login và diem_chitiet (phần B), đổi dữ liệu tiếng Anh của bản cũ sang
--  tiếng Việt (phần C).
-- =====================================================================

SET NAMES utf8mb4;

CREATE DATABASE IF NOT EXISTS studentdb CHARACTER SET utf8mb4;
USE studentdb;

-- =====================================================================
--  PHẦN A - 12 BẢNG GỐC
-- =====================================================================
CREATE TABLE IF NOT EXISTS `student` (
    StdId INT AUTO_INCREMENT PRIMARY KEY,
    StdFirstName VARCHAR(50) NOT NULL,
    StdLastName VARCHAR(50) NOT NULL,
    Birthdate DATE NOT NULL,
    Gender VARCHAR(10) NOT NULL,
    Phone VARCHAR(20),
    Address VARCHAR(200),
    Photo LONGBLOB NOT NULL
);

CREATE TABLE IF NOT EXISTS `course` (
    CourseId INT AUTO_INCREMENT PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL UNIQUE,
    CourseHour INT NOT NULL,
    Description VARCHAR(200)
);

CREATE TABLE IF NOT EXISTS `score` (
    StudentId INT NOT NULL,
    CourseName VARCHAR(100) NOT NULL,
    Score DOUBLE NOT NULL,
    Description VARCHAR(200),
    PRIMARY KEY (StudentId, CourseName),
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (CourseName) REFERENCES course(CourseName) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS `department` (
    DeptId INT AUTO_INCREMENT PRIMARY KEY,
    DeptName VARCHAR(100) NOT NULL UNIQUE,
    Description VARCHAR(200)
);

-- Giáo viên, mỗi người thuộc một khoa
CREATE TABLE IF NOT EXISTS `teacher` (
    TeacherId INT AUTO_INCREMENT PRIMARY KEY,
    TeacherName VARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    Email VARCHAR(100),
    DeptId INT NOT NULL,
    FOREIGN KEY (DeptId) REFERENCES department(DeptId)
);

-- Lớp, thuộc một khoa và có một giáo viên chủ nhiệm
CREATE TABLE IF NOT EXISTS `class` (
    ClassId INT AUTO_INCREMENT PRIMARY KEY,
    ClassName VARCHAR(50) NOT NULL UNIQUE,
    SchoolYear VARCHAR(20) NOT NULL,
    DeptId INT NOT NULL,
    TeacherId INT,
    FOREIGN KEY (DeptId) REFERENCES department(DeptId),
    FOREIGN KEY (TeacherId) REFERENCES teacher(TeacherId)
);

-- Mỗi học sinh thuộc một lớp
CREATE TABLE IF NOT EXISTS `student_class` (
    StudentId INT PRIMARY KEY,
    ClassId INT NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (ClassId) REFERENCES class(ClassId)
);

CREATE TABLE IF NOT EXISTS `room` (
    RoomId INT AUTO_INCREMENT PRIMARY KEY,
    RoomName VARCHAR(50) NOT NULL UNIQUE,
    Capacity INT NOT NULL
);

CREATE TABLE IF NOT EXISTS `semester` (
    SemesterId INT AUTO_INCREMENT PRIMARY KEY,
    SemesterName VARCHAR(50) NOT NULL UNIQUE,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);

-- Thời khoá biểu: môn nào, lớp nào, giáo viên nào, phòng nào, thứ mấy, mấy giờ
CREATE TABLE IF NOT EXISTS `schedule` (
    ScheduleId INT AUTO_INCREMENT PRIMARY KEY,
    CourseId INT NOT NULL,
    ClassId INT NOT NULL,
    TeacherId INT NOT NULL,
    RoomId INT NOT NULL,
    SemesterId INT NOT NULL,
    DayOfWeek VARCHAR(10) NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    FOREIGN KEY (CourseId) REFERENCES course(CourseId) ON DELETE CASCADE,
    FOREIGN KEY (ClassId) REFERENCES class(ClassId),
    FOREIGN KEY (TeacherId) REFERENCES teacher(TeacherId),
    FOREIGN KEY (RoomId) REFERENCES room(RoomId),
    FOREIGN KEY (SemesterId) REFERENCES semester(SemesterId)
);

-- Điểm danh: Có mặt, Vắng, Đi muộn
CREATE TABLE IF NOT EXISTS `attendance` (
    AttendId INT AUTO_INCREMENT PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    AttendDate DATE NOT NULL,
    Status VARCHAR(20) NOT NULL,
    UNIQUE (StudentId, CourseId, AttendDate),
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (CourseId) REFERENCES course(CourseId) ON DELETE CASCADE
);

-- Học phí mỗi học kỳ: Đã đóng, Chưa đóng
CREATE TABLE IF NOT EXISTS `tuition` (
    TuitionId INT AUTO_INCREMENT PRIMARY KEY,
    StudentId INT NOT NULL,
    SemesterId INT NOT NULL,
    Amount INT NOT NULL,
    PaidDate DATE,
    Status VARCHAR(20) NOT NULL,
    UNIQUE (StudentId, SemesterId),
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (SemesterId) REFERENCES semester(SemesterId)
);

INSERT IGNORE INTO `course` (`CourseId`, `CourseName`, `CourseHour`, `Description`) VALUES
(1, 'Lập trình .NET', 60, 'Lập trình WinForms với C#'),
(2, 'Cơ sở dữ liệu', 45, 'Thiết kế và truy vấn CSDL'),
(3, 'Lập trình Web', 45, 'HTML, CSS, JavaScript'),
(4, 'Mạng máy tính', 45, 'Mô hình OSI và TCP/IP'),
(5, 'Toán rời rạc', 30, 'Logic, tập hợp và đồ thị'),
(6, 'Cấu trúc dữ liệu', 45, 'Danh sách, cây và thuật toán sắp xếp');

SET @photo = X'89504E470D0A1A0A0000000D49484452000000100000001008060000001FF3FF61000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA8640000001D49444154384F63F09A70F33F2598015D80543C6AC0A801A3060C160300B218B21FF4C5F6E30000000049454E44AE426082';

INSERT IGNORE INTO `student` (`StdId`, `StdFirstName`, `StdLastName`, `Birthdate`, `Gender`, `Phone`, `Address`, `Photo`) VALUES
(1, 'Văn An', 'Nguyễn', '2005-03-12', 'Nam', '0941404371', '12 Nguyễn Huệ, Quận 1, TP.HCM', @photo),
(2, 'Thị Bình', 'Trần', '2005-07-25', 'Nữ', '0949154299', '45 Lê Lợi, Quận 1, TP.HCM', @photo),
(3, 'Minh Châu', 'Lê', '2004-11-02', 'Nam', '0912545845', '78 Trần Hưng Đạo, Quận 5, TP.HCM', @photo),
(4, 'Ngọc Dung', 'Phạm', '2006-01-18', 'Nữ', '0869646355', '23 Hai Bà Trưng, Hoàn Kiếm, Hà Nội', @photo),
(5, 'Quốc Huy', 'Hoàng', '2005-09-30', 'Nam', '0933969698', '56 Lý Thường Kiệt, Hải Châu, Đà Nẵng', @photo),
(6, 'Thu Hà', 'Vũ', '2004-05-14', 'Nữ', '0941496562', '89 Phan Chu Trinh, TP. Huế', @photo),
(7, 'Đức Khang', 'Đặng', '2006-04-08', 'Nam', '0912730878', '34 Nguyễn Trãi, Ninh Kiều, Cần Thơ', @photo),
(8, 'Mai Linh', 'Bùi', '2005-12-21', 'Nữ', '0989100870', '67 Võ Văn Tần, Quận 3, TP.HCM', @photo),
(9, 'Gia Bảo', 'Đỗ', '2004-08-09', 'Nam', '0948338056', '10 Điện Biên Phủ, Bình Thạnh, TP.HCM', @photo),
(10, 'Phương Thảo', 'Ngô', '2006-02-27', 'Nữ', '0326164608', '91 Nguyễn Văn Cừ, TP. Biên Hòa', @photo),
(11, 'Hoàng Nam', 'Phan', '2005-06-03', 'Nam', '0935920798', '15 Lê Duẩn, Đống Đa, Hà Nội', @photo),
(12, 'Kim Ngân', 'Võ', '2005-10-17', 'Nữ', '0868878867', '28 Pasteur, Quận 1, TP.HCM', @photo),
(13, 'Anh Tuấn', 'Đinh', '2004-02-22', 'Nam', '0866411674', '7 Trần Phú, TP. Nha Trang', @photo),
(14, 'Bảo Trâm', 'Lý', '2006-07-11', 'Nữ', '0945529770', '63 Nguyễn Thị Minh Khai, Quận 3, TP.HCM', @photo),
(15, 'Tấn Phát', 'Trương', '2005-01-29', 'Nam', '0979460588', '102 Cách Mạng Tháng 8, Quận 10, TP.HCM', @photo),
(16, 'Yến Nhi', 'Dương', '2004-09-05', 'Nữ', '0914157219', '19 Lê Hồng Phong, TP. Vũng Tàu', @photo),
(17, 'Công Danh', 'Huỳnh', '2006-03-14', 'Nam', '0983378885', '44 Hùng Vương, TP. Buôn Ma Thuột', @photo),
(18, 'Cẩm Tú', 'Lâm', '2005-05-20', 'Nữ', '0943157135', '8 Trần Quốc Toản, Quận 3, TP.HCM', @photo),
(19, 'Thanh Tùng', 'Mai', '2004-12-01', 'Nam', '0918897422', '71 Nguyễn Văn Linh, Hải Châu, Đà Nẵng', @photo),
(20, 'Diệu Hiền', 'Tạ', '2006-08-23', 'Nữ', '0912829601', '36 Trần Hưng Đạo, TP. Quy Nhơn', @photo),
(21, 'Khánh Duy', 'Cao', '2005-04-16', 'Nam', '0327948311', '52 Quang Trung, Gò Vấp, TP.HCM', @photo),
(22, 'Hải Yến', 'Lương', '2004-06-27', 'Nữ', '0945664298', '14 Hoàng Diệu, TP. Thủ Đức', @photo),
(23, 'Trọng Nghĩa', 'Châu', '2006-11-09', 'Nam', '0985336243', '25 Phạm Ngũ Lão, TP. Hải Phòng', @photo),
(24, 'Lan Anh', 'Hồ', '2005-02-13', 'Nữ', '0906665802', '93 Lê Văn Sỹ, Tân Bình, TP.HCM', @photo),
(25, 'Đình Khoa', 'Quách', '2004-10-30', 'Nam', '0917076599', '6 Bạch Đằng, Hải Châu, Đà Nẵng', @photo),
(26, 'Tuyết Mai', 'Trịnh', '2006-05-06', 'Nữ', '0987087885', '38 Nguyễn Đình Chiểu, Quận 3, TP.HCM', @photo),
(27, 'Minh Quân', 'Lưu', '2005-08-19', 'Nam', '0977560676', '81 Hồ Tùng Mậu, Cầu Giấy, Hà Nội', @photo),
(28, 'Thùy Dương', 'Kiều', '2004-03-31', 'Nữ', '0949335495', '17 Lê Thánh Tôn, Quận 1, TP.HCM', @photo),
(29, 'Văn Hậu', 'Đoàn', '2006-09-12', 'Nam', '0916233145', '49 Nguyễn Tri Phương, TP. Huế', @photo),
(30, 'Bích Phượng', 'Thái', '2005-11-25', 'Nữ', '0916139710', '22 Ba Tháng Hai, Ninh Kiều, Cần Thơ', @photo);

INSERT IGNORE INTO `score` (`StudentId`, `CourseName`, `Score`, `Description`) VALUES
(1, 'Lập trình .NET', 9, 'Xuất sắc'),
(1, 'Toán rời rạc', 8, 'Giỏi'),
(1, 'Cấu trúc dữ liệu', 7, 'Khá'),
(2, 'Lập trình .NET', 6, 'Trung bình'),
(2, 'Cơ sở dữ liệu', 8, 'Giỏi'),
(2, 'Mạng máy tính', 9, 'Xuất sắc'),
(2, 'Toán rời rạc', 5, 'Trung bình'),
(3, 'Lập trình .NET', 6, 'Trung bình'),
(3, 'Lập trình Web', 8, 'Giỏi'),
(3, 'Mạng máy tính', 6, 'Trung bình'),
(3, 'Cấu trúc dữ liệu', 6, 'Trung bình'),
(4, 'Cơ sở dữ liệu', 7, 'Khá'),
(4, 'Mạng máy tính', 9, 'Xuất sắc'),
(4, 'Toán rời rạc', 8, 'Giỏi'),
(5, 'Cơ sở dữ liệu', 10, 'Xuất sắc'),
(5, 'Toán rời rạc', 9, 'Xuất sắc'),
(5, 'Cấu trúc dữ liệu', 9, 'Xuất sắc'),
(6, 'Lập trình .NET', 7, 'Khá'),
(6, 'Lập trình Web', 7, 'Khá'),
(6, 'Toán rời rạc', 8, 'Giỏi'),
(7, 'Cơ sở dữ liệu', 8, 'Giỏi'),
(7, 'Mạng máy tính', 5, 'Trung bình'),
(7, 'Toán rời rạc', 7, 'Khá'),
(7, 'Cấu trúc dữ liệu', 9, 'Xuất sắc'),
(8, 'Cơ sở dữ liệu', 10, 'Xuất sắc'),
(8, 'Lập trình Web', 8, 'Giỏi'),
(8, 'Cấu trúc dữ liệu', 10, 'Xuất sắc'),
(9, 'Cơ sở dữ liệu', 8, 'Giỏi'),
(9, 'Lập trình Web', 6, 'Trung bình'),
(9, 'Mạng máy tính', 7, 'Khá'),
(10, 'Lập trình .NET', 9, 'Xuất sắc'),
(10, 'Cơ sở dữ liệu', 10, 'Xuất sắc'),
(10, 'Toán rời rạc', 9, 'Xuất sắc'),
(10, 'Cấu trúc dữ liệu', 8, 'Giỏi'),
(11, 'Lập trình .NET', 5, 'Trung bình'),
(11, 'Cơ sở dữ liệu', 7, 'Khá'),
(11, 'Mạng máy tính', 7, 'Khá'),
(11, 'Toán rời rạc', 7, 'Khá'),
(12, 'Lập trình .NET', 8, 'Giỏi'),
(12, 'Cơ sở dữ liệu', 8, 'Giỏi'),
(12, 'Toán rời rạc', 9, 'Xuất sắc'),
(12, 'Cấu trúc dữ liệu', 9, 'Xuất sắc'),
(13, 'Cơ sở dữ liệu', 7, 'Khá'),
(13, 'Toán rời rạc', 8, 'Giỏi'),
(13, 'Cấu trúc dữ liệu', 10, 'Xuất sắc'),
(14, 'Lập trình .NET', 7, 'Khá'),
(14, 'Cơ sở dữ liệu', 6, 'Trung bình'),
(14, 'Mạng máy tính', 8, 'Giỏi'),
(14, 'Toán rời rạc', 9, 'Xuất sắc'),
(15, 'Cơ sở dữ liệu', 8, 'Giỏi'),
(15, 'Mạng máy tính', 7, 'Khá'),
(15, 'Toán rời rạc', 7, 'Khá'),
(15, 'Cấu trúc dữ liệu', 6, 'Trung bình'),
(16, 'Lập trình .NET', 7, 'Khá'),
(16, 'Cơ sở dữ liệu', 8, 'Giỏi'),
(16, 'Lập trình Web', 10, 'Xuất sắc'),
(16, 'Toán rời rạc', 10, 'Xuất sắc'),
(17, 'Cơ sở dữ liệu', 10, 'Xuất sắc'),
(17, 'Lập trình Web', 6, 'Trung bình'),
(17, 'Mạng máy tính', 7, 'Khá'),
(18, 'Lập trình .NET', 8, 'Giỏi'),
(18, 'Cơ sở dữ liệu', 6, 'Trung bình'),
(18, 'Lập trình Web', 9, 'Xuất sắc'),
(19, 'Mạng máy tính', 8, 'Giỏi'),
(19, 'Toán rời rạc', 9, 'Xuất sắc'),
(19, 'Cấu trúc dữ liệu', 8, 'Giỏi'),
(20, 'Lập trình .NET', 5, 'Trung bình'),
(20, 'Mạng máy tính', 6, 'Trung bình'),
(20, 'Toán rời rạc', 9, 'Xuất sắc'),
(20, 'Cấu trúc dữ liệu', 6, 'Trung bình'),
(21, 'Lập trình .NET', 5, 'Trung bình'),
(21, 'Toán rời rạc', 7, 'Khá'),
(21, 'Cấu trúc dữ liệu', 8, 'Giỏi'),
(22, 'Lập trình .NET', 6, 'Trung bình'),
(22, 'Cơ sở dữ liệu', 6, 'Trung bình'),
(22, 'Toán rời rạc', 8, 'Giỏi'),
(22, 'Cấu trúc dữ liệu', 9, 'Xuất sắc'),
(23, 'Lập trình Web', 5, 'Trung bình'),
(23, 'Mạng máy tính', 5, 'Trung bình'),
(23, 'Toán rời rạc', 6, 'Trung bình'),
(24, 'Lập trình .NET', 6, 'Trung bình'),
(24, 'Cơ sở dữ liệu', 5, 'Trung bình'),
(24, 'Mạng máy tính', 10, 'Xuất sắc'),
(24, 'Cấu trúc dữ liệu', 8, 'Giỏi'),
(25, 'Cơ sở dữ liệu', 8, 'Giỏi'),
(25, 'Mạng máy tính', 8, 'Giỏi'),
(25, 'Toán rời rạc', 9, 'Xuất sắc'),
(25, 'Cấu trúc dữ liệu', 10, 'Xuất sắc'),
(26, 'Lập trình .NET', 5, 'Trung bình'),
(26, 'Cơ sở dữ liệu', 7, 'Khá'),
(26, 'Mạng máy tính', 10, 'Xuất sắc'),
(27, 'Cơ sở dữ liệu', 6, 'Trung bình'),
(27, 'Lập trình Web', 6, 'Trung bình'),
(27, 'Cấu trúc dữ liệu', 5, 'Trung bình'),
(28, 'Cơ sở dữ liệu', 8, 'Giỏi'),
(28, 'Lập trình Web', 10, 'Xuất sắc'),
(28, 'Cấu trúc dữ liệu', 5, 'Trung bình'),
(29, 'Lập trình .NET', 6, 'Trung bình'),
(29, 'Cơ sở dữ liệu', 10, 'Xuất sắc'),
(29, 'Mạng máy tính', 6, 'Trung bình'),
(30, 'Lập trình Web', 9, 'Xuất sắc'),
(30, 'Mạng máy tính', 7, 'Khá'),
(30, 'Toán rời rạc', 6, 'Trung bình'),
(30, 'Cấu trúc dữ liệu', 8, 'Giỏi');

INSERT IGNORE INTO `department` (`DeptId`, `DeptName`, `Description`) VALUES
(1, 'Công nghệ thông tin', 'Lập trình, cơ sở dữ liệu, mạng máy tính'),
(2, 'Toán - Tin ứng dụng', 'Toán rời rạc, cấu trúc dữ liệu'),
(3, 'Ngoại ngữ', 'Tiếng Anh chuyên ngành');

INSERT IGNORE INTO `teacher` (`TeacherId`, `TeacherName`, `Phone`, `Email`, `DeptId`) VALUES
(1, 'Nguyễn Văn Minh', '0900000001', 'minh.nv@mdemy.example', 1),
(2, 'Trần Thị Lan', '0900000002', 'lan.tt@mdemy.example', 1),
(3, 'Lê Quốc Bảo', '0900000003', 'bao.lq@mdemy.example', 1),
(4, 'Phạm Thu Hằng', '0900000004', 'hang.pt@mdemy.example', 2),
(5, 'Hoàng Đức Thịnh', '0900000005', 'thinh.hd@mdemy.example', 2),
(6, 'Vũ Ngọc Anh', '0900000006', 'anh.vn@mdemy.example', 3);

INSERT IGNORE INTO `class` (`ClassId`, `ClassName`, `SchoolYear`, `DeptId`, `TeacherId`) VALUES
(1, 'CNTT23A', '2023-2027', 1, 1),
(2, 'CNTT23B', '2023-2027', 1, 2),
(3, 'CNTT23C', '2023-2027', 1, 3),
(4, 'TTUD23A', '2023-2027', 2, 4);

INSERT IGNORE INTO `student_class` (`StudentId`, `ClassId`) VALUES
(1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1), (7, 1), (8, 1),
(9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2),
(17, 3), (18, 3), (19, 3), (20, 3), (21, 3), (22, 3), (23, 3), (24, 4),
(25, 4), (26, 4), (27, 4), (28, 4), (29, 4), (30, 4);

INSERT IGNORE INTO `room` (`RoomId`, `RoomName`, `Capacity`) VALUES
(1, 'A101', 40),
(2, 'A102', 40),
(3, 'B201', 50),
(4, 'B202', 50),
(5, 'LAB1', 30),
(6, 'LAB2', 30);

INSERT IGNORE INTO `semester` (`SemesterId`, `SemesterName`, `StartDate`, `EndDate`) VALUES
(1, 'Học kỳ 1 - 2025-2026', '2025-09-01', '2026-01-15'),
(2, 'Học kỳ 2 - 2025-2026', '2026-02-01', '2026-06-15'),
(3, 'Học kỳ 1 - 2026-2027', '2026-09-01', '2027-01-15');

INSERT IGNORE INTO `schedule` (`ScheduleId`, `CourseId`, `ClassId`, `TeacherId`, `RoomId`, `SemesterId`, `DayOfWeek`, `StartTime`, `EndTime`) VALUES
(1, 1, 1, 1, 5, 3, 'Thứ 2', '07:30:00', '09:30:00'),
(2, 1, 2, 1, 5, 3, 'Thứ 2', '09:45:00', '11:45:00'),
(3, 2, 1, 2, 1, 3, 'Thứ 3', '07:30:00', '09:30:00'),
(4, 2, 2, 2, 1, 3, 'Thứ 3', '09:45:00', '11:45:00'),
(5, 2, 3, 2, 2, 3, 'Thứ 4', '07:30:00', '09:30:00'),
(6, 3, 3, 3, 6, 3, 'Thứ 4', '13:00:00', '15:00:00'),
(7, 3, 1, 3, 6, 3, 'Thứ 5', '07:30:00', '09:30:00'),
(8, 4, 2, 3, 3, 3, 'Thứ 5', '13:00:00', '15:00:00'),
(9, 4, 3, 3, 3, 3, 'Thứ 6', '07:30:00', '09:30:00'),
(10, 5, 4, 4, 4, 3, 'Thứ 2', '13:00:00', '15:00:00'),
(11, 5, 1, 4, 4, 3, 'Thứ 3', '13:00:00', '15:00:00'),
(12, 6, 4, 5, 2, 3, 'Thứ 6', '13:00:00', '15:00:00'),
(13, 6, 2, 5, 2, 3, 'Thứ 5', '09:45:00', '11:45:00');

INSERT IGNORE INTO `attendance` (`StudentId`, `CourseId`, `AttendDate`, `Status`) VALUES
(1, 1, '2026-09-07', 'Có mặt'),
(2, 1, '2026-09-07', 'Có mặt'),
(3, 1, '2026-09-07', 'Đi muộn'),
(4, 1, '2026-09-07', 'Có mặt'),
(1, 1, '2026-09-14', 'Có mặt'),
(2, 1, '2026-09-14', 'Vắng'),
(3, 1, '2026-09-14', 'Có mặt'),
(4, 1, '2026-09-14', 'Có mặt'),
(1, 1, '2026-09-21', 'Có mặt'),
(2, 1, '2026-09-21', 'Có mặt'),
(3, 1, '2026-09-21', 'Có mặt'),
(4, 1, '2026-09-21', 'Vắng'),
(1, 2, '2026-09-08', 'Có mặt'),
(2, 2, '2026-09-08', 'Có mặt'),
(3, 2, '2026-09-08', 'Có mặt'),
(4, 2, '2026-09-08', 'Đi muộn'),
(1, 2, '2026-09-15', 'Có mặt'),
(2, 2, '2026-09-15', 'Vắng'),
(3, 2, '2026-09-15', 'Có mặt'),
(4, 2, '2026-09-15', 'Có mặt'),
(1, 3, '2026-09-10', 'Có mặt'),
(2, 3, '2026-09-10', 'Có mặt'),
(3, 3, '2026-09-10', 'Vắng'),
(1, 3, '2026-09-17', 'Có mặt'),
(2, 3, '2026-09-17', 'Đi muộn'),
(3, 3, '2026-09-17', 'Có mặt'),
(9, 1, '2026-09-07', 'Có mặt'),
(10, 1, '2026-09-07', 'Có mặt'),
(9, 1, '2026-09-14', 'Đi muộn'),
(10, 1, '2026-09-14', 'Có mặt');

INSERT IGNORE INTO `tuition` (`StudentId`, `SemesterId`, `Amount`, `PaidDate`, `Status`) VALUES
(1, 2, 7800000, '2026-02-05', 'Đã đóng'),
(2, 2, 7800000, '2026-02-06', 'Đã đóng'),
(3, 2, 7800000, '2026-02-08', 'Đã đóng'),
(4, 2, 7800000, '2026-02-10', 'Đã đóng'),
(5, 2, 7800000, '2026-02-10', 'Đã đóng'),
(6, 2, 7800000, '2026-02-12', 'Đã đóng'),
(7, 2, 7800000, '2026-02-12', 'Đã đóng'),
(8, 2, 7800000, '2026-02-14', 'Đã đóng'),
(9, 2, 7800000, '2026-02-15', 'Đã đóng'),
(10, 2, 7800000, '2026-02-15', 'Đã đóng'),
(1, 3, 8500000, '2026-09-02', 'Đã đóng'),
(2, 3, 8500000, '2026-09-03', 'Đã đóng'),
(3, 3, 8500000, '2026-09-03', 'Đã đóng'),
(4, 3, 8500000, '2026-09-05', 'Đã đóng'),
(5, 3, 8500000, '2026-09-05', 'Đã đóng'),
(6, 3, 8500000, NULL, 'Chưa đóng'),
(7, 3, 8500000, '2026-09-08', 'Đã đóng'),
(8, 3, 8500000, '2026-09-09', 'Đã đóng'),
(9, 3, 8500000, NULL, 'Chưa đóng'),
(10, 3, 8500000, '2026-09-10', 'Đã đóng');

-- =====================================================================
--  PHẦN B - 2 BẢNG BỔ SUNG
-- =====================================================================

-- Bảng login: thêm họ tên và vai trò để form chính hiện được người đang
-- đăng nhập. Bảng `user` cũ chỉ có username và password nên không dùng nữa.
CREATE TABLE IF NOT EXISTS `login` (
    MaND INT AUTO_INCREMENT PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(50) NOT NULL,
    HoTen VARCHAR(100) NOT NULL,
    VaiTro VARCHAR(20) NOT NULL
);

INSERT IGNORE INTO `login` (`MaND`, `TenDangNhap`, `MatKhau`, `HoTen`, `VaiTro`) VALUES
(1, 'admin', 'admin123', 'Quản trị hệ thống', 'Admin'),
(2, 'giaovien', '123456', 'Nguyễn Văn Minh', 'Giáo viên'),
(3, 'vanphong', '123456', 'Trần Thị Lan', 'Văn phòng');

-- Bảng diem_chitiet: mỗi môn của mỗi học sinh có nhiều đầu điểm (miệng,
-- 15 phút, 1 tiết, thi), mỗi đầu điểm một hệ số. Điểm trung bình môn
-- = SUM(Diem * HeSo) / SUM(HeSo), chương trình tính rồi ghi vào score.
CREATE TABLE IF NOT EXISTS `diem_chitiet` (
    MaCT INT AUTO_INCREMENT PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseName VARCHAR(100) NOT NULL,
    SemesterId INT NOT NULL,
    LoaiDiem VARCHAR(20) NOT NULL,
    Diem DOUBLE NOT NULL,
    HeSo INT NOT NULL DEFAULT 1,
    GhiChu VARCHAR(200),
    -- khoá ngoại trỏ vào student và course, không trỏ vào score, để đổi tên
    -- môn học thì cả hai bảng score và diem_chitiet cùng được cập nhật
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (CourseName) REFERENCES course(CourseName)
        ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (SemesterId) REFERENCES semester(SemesterId)
);

-- Chuyển các dòng điểm có sẵn trong score thành đầu điểm "Thi" để điểm
-- trung bình tính ra khớp với điểm cũ.
INSERT INTO `diem_chitiet` (StudentId, CourseName, SemesterId, LoaiDiem, Diem, HeSo, GhiChu)
SELECT score.StudentId, score.CourseName, 3, 'Thi', score.Score, 1, 'Chuyển từ dữ liệu điểm cũ'
FROM score
WHERE NOT EXISTS (
    SELECT 1 FROM diem_chitiet d
    WHERE d.StudentId = score.StudentId AND d.CourseName = score.CourseName
);

-- CSDL cũ nào vẫn còn bảng `user` thì bỏ dấu -- ở dòng dưới rồi chạy lại
-- DROP TABLE IF EXISTS `user`;

-- =====================================================================
--  PHẦN C - ĐỔI DỮ LIỆU CŨ SANG TIẾNG VIỆT
--  Chương trình lưu thẳng tiếng Việt vào CSDL. Mấy câu dưới đây đổi nốt
--  các giá trị tiếng Anh của bản studentdb cũ, chạy lại cũng không sao
--  vì không còn dòng nào khớp nữa.
-- =====================================================================
UPDATE `student` SET `Gender` = 'Nam' WHERE `Gender` = 'Male';
UPDATE `student` SET `Gender` = 'Nữ'  WHERE `Gender` = 'Female';

UPDATE `schedule` SET `DayOfWeek` = 'Thứ 2' WHERE `DayOfWeek` = 'Monday';
UPDATE `schedule` SET `DayOfWeek` = 'Thứ 3' WHERE `DayOfWeek` = 'Tuesday';
UPDATE `schedule` SET `DayOfWeek` = 'Thứ 4' WHERE `DayOfWeek` = 'Wednesday';
UPDATE `schedule` SET `DayOfWeek` = 'Thứ 5' WHERE `DayOfWeek` = 'Thursday';
UPDATE `schedule` SET `DayOfWeek` = 'Thứ 6' WHERE `DayOfWeek` = 'Friday';
UPDATE `schedule` SET `DayOfWeek` = 'Thứ 7' WHERE `DayOfWeek` = 'Saturday';

UPDATE `attendance` SET `Status` = 'Có mặt'  WHERE `Status` = 'Present';
UPDATE `attendance` SET `Status` = 'Vắng'    WHERE `Status` = 'Absent';
UPDATE `attendance` SET `Status` = 'Đi muộn' WHERE `Status` = 'Late';

UPDATE `tuition` SET `Status` = 'Đã đóng'  WHERE `Status` = 'Paid';
UPDATE `tuition` SET `Status` = 'Chưa đóng' WHERE `Status` = 'Unpaid';

UPDATE `score` SET `Description` = 'Trung bình' WHERE `Description` = 'Trung bình khá';
