CREATE DATABASE studentdb;
GO

USE studentdb;
GO

CREATE TABLE department (
    DeptId INT IDENTITY(1,1) PRIMARY KEY,
    DeptName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(200)
);
GO

CREATE TABLE teacher (
    TeacherId INT IDENTITY(1,1) PRIMARY KEY,
    TeacherName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    DeptId INT NOT NULL,
    FOREIGN KEY (DeptId) REFERENCES department(DeptId)
);
GO

CREATE TABLE class (
    ClassId INT IDENTITY(1,1) PRIMARY KEY,
    ClassName NVARCHAR(50) NOT NULL UNIQUE,
    SchoolYear NVARCHAR(20) NOT NULL,
    DeptId INT NOT NULL,
    TeacherId INT,
    FOREIGN KEY (DeptId) REFERENCES department(DeptId),
    FOREIGN KEY (TeacherId) REFERENCES teacher(TeacherId)
);
GO

CREATE TABLE student (
    StdId INT IDENTITY(1,1) PRIMARY KEY,
    StdFirstName NVARCHAR(50) NOT NULL,
    StdLastName NVARCHAR(50) NOT NULL,
    Birthdate DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Phone NVARCHAR(20),
    Address NVARCHAR(200),
    Photo VARBINARY(MAX) NOT NULL
);
GO

CREATE TABLE student_class (
    StudentId INT PRIMARY KEY,
    ClassId INT NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (ClassId) REFERENCES class(ClassId)
);
GO

CREATE TABLE course (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(100) NOT NULL UNIQUE,
    CourseHour INT NOT NULL,
    Description NVARCHAR(200)
);
GO

CREATE TABLE semester (
    SemesterId INT IDENTITY(1,1) PRIMARY KEY,
    SemesterName NVARCHAR(50) NOT NULL UNIQUE,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);
GO

CREATE TABLE score (
    StudentId INT NOT NULL,
    CourseName NVARCHAR(100) NOT NULL,
    Score FLOAT NOT NULL,
    Description NVARCHAR(200),
    PRIMARY KEY (StudentId, CourseName),
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (CourseName) REFERENCES course(CourseName) ON UPDATE CASCADE ON DELETE CASCADE
);
GO

CREATE TABLE diem_chitiet (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseName NVARCHAR(100) NOT NULL,
    SemesterId INT NOT NULL,
    LoaiDiem NVARCHAR(20) NOT NULL,
    Diem FLOAT NOT NULL,
    HeSo INT NOT NULL DEFAULT 1,
    GhiChu NVARCHAR(200),
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (CourseName) REFERENCES course(CourseName) ON UPDATE CASCADE,
    FOREIGN KEY (SemesterId) REFERENCES semester(SemesterId)
);
GO

CREATE TABLE room (
    RoomId INT IDENTITY(1,1) PRIMARY KEY,
    RoomName NVARCHAR(50) NOT NULL UNIQUE,
    Capacity INT NOT NULL
);
GO

CREATE TABLE schedule (
    ScheduleId INT IDENTITY(1,1) PRIMARY KEY,
    CourseId INT NOT NULL,
    ClassId INT NOT NULL,
    TeacherId INT NOT NULL,
    RoomId INT NOT NULL,
    SemesterId INT NOT NULL,
    DayOfWeek NVARCHAR(10) NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    FOREIGN KEY (CourseId) REFERENCES course(CourseId) ON DELETE CASCADE,
    FOREIGN KEY (ClassId) REFERENCES class(ClassId),
    FOREIGN KEY (TeacherId) REFERENCES teacher(TeacherId),
    FOREIGN KEY (RoomId) REFERENCES room(RoomId),
    FOREIGN KEY (SemesterId) REFERENCES semester(SemesterId)
);
GO

CREATE TABLE attendance (
    AttendId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    AttendDate DATE NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    UNIQUE (StudentId, CourseId, AttendDate),
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (CourseId) REFERENCES course(CourseId) ON DELETE CASCADE
);
GO

CREATE TABLE tuition (
    TuitionId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT NOT NULL,
    SemesterId INT NOT NULL,
    Amount INT NOT NULL,
    PaidDate DATE,
    Status NVARCHAR(20) NOT NULL,
    UNIQUE (StudentId, SemesterId),
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (SemesterId) REFERENCES semester(SemesterId)
);
GO

CREATE TABLE login (
    MaND INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(50) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL
);
GO

INSERT INTO department (DeptName, Description) VALUES
(N'Khối 10', N'Học sinh lớp 10, năm đầu cấp THPT'),
(N'Khối 11', N'Học sinh lớp 11'),
(N'Khối 12', N'Học sinh lớp 12, ôn thi tốt nghiệp THPT');
GO

INSERT INTO teacher (TeacherName, Phone, Email, DeptId) VALUES
(N'Nguyễn Văn Minh', '0912345678', 'minh.nv@mdemy.edu.vn', 1),
(N'Trần Thị Lan', '0983214567', 'lan.tt@mdemy.edu.vn', 1),
(N'Lê Quốc Bảo', '0905678123', 'bao.lq@mdemy.edu.vn', 1),
(N'Phạm Thu Hằng', '0936781245', 'hang.pt@mdemy.edu.vn', 2),
(N'Hoàng Đức Thịnh', '0978123456', 'thinh.hd@mdemy.edu.vn', 2),
(N'Vũ Ngọc Anh', '0941236789', 'anh.vn@mdemy.edu.vn', 3);
GO

INSERT INTO class (ClassName, SchoolYear, DeptId, TeacherId) VALUES
(N'10A1', N'2026-2029', 1, 1),
(N'10A2', N'2026-2029', 1, 2),
(N'11A1', N'2025-2028', 2, 3),
(N'12A1', N'2024-2027', 3, 4);
GO

DECLARE @photo VARBINARY(MAX) = 0x89504E470D0A1A0A0000000D49484452000000100000001008060000001FF3FF61000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA8640000001D49444154384F63F09A70F33F2598015D80543C6AC0A801A3060C160300B218B21FF4C5F6E30000000049454E44AE426082;

INSERT INTO student (StdFirstName, StdLastName, Birthdate, Gender, Phone, Address, Photo) VALUES
(N'Văn An', N'Nguyễn', '2011-03-12', N'Nam', '0941404371', N'12 Nguyễn Huệ, Quận 1, TP.HCM', @photo),
(N'Thị Bình', N'Trần', '2011-07-25', N'Nữ', '0949154299', N'45 Lê Lợi, Quận 1, TP.HCM', @photo),
(N'Minh Châu', N'Lê', '2010-11-02', N'Nam', '0912545845', N'78 Trần Hưng Đạo, Quận 5, TP.HCM', @photo),
(N'Ngọc Dung', N'Phạm', '2011-01-18', N'Nữ', '0869646355', N'23 Hai Bà Trưng, Hoàn Kiếm, Hà Nội', @photo),
(N'Quốc Huy', N'Hoàng', '2011-09-30', N'Nam', '0933969698', N'56 Lý Thường Kiệt, Hải Châu, Đà Nẵng', @photo),
(N'Thu Hà', N'Vũ', '2010-05-14', N'Nữ', '0941496562', N'89 Phan Chu Trinh, TP. Huế', @photo),
(N'Đức Khang', N'Đặng', '2011-04-08', N'Nam', '0912730878', N'34 Nguyễn Trãi, Ninh Kiều, Cần Thơ', @photo),
(N'Mai Linh', N'Bùi', '2011-12-21', N'Nữ', '0989100870', N'67 Võ Văn Tần, Quận 3, TP.HCM', @photo),
(N'Gia Bảo', N'Đỗ', '2010-08-09', N'Nam', '0948338056', N'10 Điện Biên Phủ, Bình Thạnh, TP.HCM', @photo),
(N'Phương Thảo', N'Ngô', '2011-02-27', N'Nữ', '0326164608', N'91 Nguyễn Văn Cừ, TP. Biên Hòa', @photo),
(N'Hoàng Nam', N'Phan', '2011-06-03', N'Nam', '0935920798', N'15 Lê Duẩn, Đống Đa, Hà Nội', @photo),
(N'Kim Ngân', N'Võ', '2011-10-17', N'Nữ', '0868878867', N'28 Pasteur, Quận 1, TP.HCM', @photo),
(N'Anh Tuấn', N'Đinh', '2010-02-22', N'Nam', '0866411674', N'7 Trần Phú, TP. Nha Trang', @photo),
(N'Bảo Trâm', N'Lý', '2011-07-11', N'Nữ', '0945529770', N'63 Nguyễn Thị Minh Khai, Quận 3, TP.HCM', @photo),
(N'Tấn Phát', N'Trương', '2011-01-29', N'Nam', '0979460588', N'102 Cách Mạng Tháng 8, Quận 10, TP.HCM', @photo),
(N'Yến Nhi', N'Dương', '2010-09-05', N'Nữ', '0914157219', N'19 Lê Hồng Phong, TP. Vũng Tàu', @photo),
(N'Công Danh', N'Huỳnh', '2010-03-14', N'Nam', '0983378885', N'44 Hùng Vương, TP. Buôn Ma Thuột', @photo),
(N'Cẩm Tú', N'Lâm', '2010-05-20', N'Nữ', '0943157135', N'8 Trần Quốc Toản, Quận 3, TP.HCM', @photo),
(N'Thanh Tùng', N'Mai', '2009-12-01', N'Nam', '0918897422', N'71 Nguyễn Văn Linh, Hải Châu, Đà Nẵng', @photo),
(N'Diệu Hiền', N'Tạ', '2010-08-23', N'Nữ', '0912829601', N'36 Trần Hưng Đạo, TP. Quy Nhơn', @photo),
(N'Khánh Duy', N'Cao', '2010-04-16', N'Nam', '0327948311', N'52 Quang Trung, Gò Vấp, TP.HCM', @photo),
(N'Hải Yến', N'Lương', '2009-06-27', N'Nữ', '0945664298', N'14 Hoàng Diệu, TP. Thủ Đức', @photo),
(N'Trọng Nghĩa', N'Châu', '2010-11-09', N'Nam', '0985336243', N'25 Phạm Ngũ Lão, TP. Hải Phòng', @photo),
(N'Lan Anh', N'Hồ', '2009-02-13', N'Nữ', '0906665802', N'93 Lê Văn Sỹ, Tân Bình, TP.HCM', @photo),
(N'Đình Khoa', N'Quách', '2008-10-30', N'Nam', '0917076599', N'6 Bạch Đằng, Hải Châu, Đà Nẵng', @photo),
(N'Tuyết Mai', N'Trịnh', '2009-05-06', N'Nữ', '0987087885', N'38 Nguyễn Đình Chiểu, Quận 3, TP.HCM', @photo),
(N'Minh Quân', N'Lưu', '2009-08-19', N'Nam', '0977560676', N'81 Hồ Tùng Mậu, Cầu Giấy, Hà Nội', @photo),
(N'Thùy Dương', N'Kiều', '2008-03-31', N'Nữ', '0949335495', N'17 Lê Thánh Tôn, Quận 1, TP.HCM', @photo),
(N'Văn Hậu', N'Đoàn', '2009-09-12', N'Nam', '0916233145', N'49 Nguyễn Tri Phương, TP. Huế', @photo),
(N'Bích Phượng', N'Thái', '2009-11-25', N'Nữ', '0916139710', N'22 Ba Tháng Hai, Ninh Kiều, Cần Thơ', @photo);
GO

INSERT INTO student_class (StudentId, ClassId) VALUES
(1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1), (7, 1), (8, 1),
(9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2),
(17, 3), (18, 3), (19, 3), (20, 3), (21, 3), (22, 3), (23, 3), (24, 4),
(25, 4), (26, 4), (27, 4), (28, 4), (29, 4), (30, 4);
GO

INSERT INTO course (CourseName, CourseHour, Description) VALUES
(N'Toán', 72, N'Đại số, giải tích và hình học'),
(N'Ngữ văn', 54, N'Đọc hiểu, làm văn và văn học Việt Nam'),
(N'Tiếng Anh', 54, N'Nghe, nói, đọc, viết và ngữ pháp'),
(N'Vật lý', 36, N'Cơ học, nhiệt học và điện học'),
(N'Hóa học', 36, N'Cấu tạo nguyên tử, bảng tuần hoàn và phản ứng hóa học'),
(N'Sinh học', 36, N'Tế bào, di truyền và tiến hóa');
GO

INSERT INTO semester (SemesterName, StartDate, EndDate) VALUES
(N'Học kỳ 1 - 2025-2026', '2025-09-01', '2026-01-15'),
(N'Học kỳ 2 - 2025-2026', '2026-02-01', '2026-06-15'),
(N'Học kỳ 1 - 2026-2027', '2026-09-01', '2027-01-15');
GO

INSERT INTO score (StudentId, CourseName, Score, Description) VALUES
(1, N'Toán', 9, N'Xuất sắc'),
(1, N'Hóa học', 8, N'Giỏi'),
(1, N'Sinh học', 7, N'Khá'),
(2, N'Toán', 6, N'Trung bình'),
(2, N'Ngữ văn', 8, N'Giỏi'),
(2, N'Vật lý', 9, N'Xuất sắc'),
(2, N'Hóa học', 5, N'Trung bình'),
(3, N'Toán', 6, N'Trung bình'),
(3, N'Tiếng Anh', 8, N'Giỏi'),
(3, N'Vật lý', 6, N'Trung bình'),
(3, N'Sinh học', 6, N'Trung bình'),
(4, N'Ngữ văn', 7, N'Khá'),
(4, N'Vật lý', 9, N'Xuất sắc'),
(4, N'Hóa học', 8, N'Giỏi'),
(5, N'Ngữ văn', 10, N'Xuất sắc'),
(5, N'Hóa học', 9, N'Xuất sắc'),
(5, N'Sinh học', 9, N'Xuất sắc'),
(6, N'Toán', 7, N'Khá'),
(6, N'Tiếng Anh', 7, N'Khá'),
(6, N'Hóa học', 8, N'Giỏi'),
(7, N'Ngữ văn', 8, N'Giỏi'),
(7, N'Vật lý', 5, N'Trung bình'),
(7, N'Hóa học', 7, N'Khá'),
(7, N'Sinh học', 9, N'Xuất sắc'),
(8, N'Ngữ văn', 10, N'Xuất sắc'),
(8, N'Tiếng Anh', 8, N'Giỏi'),
(8, N'Sinh học', 10, N'Xuất sắc'),
(9, N'Ngữ văn', 8, N'Giỏi'),
(9, N'Tiếng Anh', 6, N'Trung bình'),
(9, N'Vật lý', 7, N'Khá'),
(10, N'Toán', 9, N'Xuất sắc'),
(10, N'Ngữ văn', 10, N'Xuất sắc'),
(10, N'Hóa học', 9, N'Xuất sắc'),
(10, N'Sinh học', 8, N'Giỏi'),
(11, N'Toán', 5, N'Trung bình'),
(11, N'Ngữ văn', 7, N'Khá'),
(11, N'Vật lý', 7, N'Khá'),
(11, N'Hóa học', 7, N'Khá'),
(12, N'Toán', 8, N'Giỏi'),
(12, N'Ngữ văn', 8, N'Giỏi'),
(12, N'Hóa học', 9, N'Xuất sắc'),
(12, N'Sinh học', 9, N'Xuất sắc'),
(13, N'Ngữ văn', 7, N'Khá'),
(13, N'Hóa học', 8, N'Giỏi'),
(13, N'Sinh học', 10, N'Xuất sắc'),
(14, N'Toán', 7, N'Khá'),
(14, N'Ngữ văn', 6, N'Trung bình'),
(14, N'Vật lý', 8, N'Giỏi'),
(14, N'Hóa học', 9, N'Xuất sắc'),
(15, N'Ngữ văn', 8, N'Giỏi'),
(15, N'Vật lý', 7, N'Khá'),
(15, N'Hóa học', 7, N'Khá'),
(15, N'Sinh học', 6, N'Trung bình'),
(16, N'Toán', 7, N'Khá'),
(16, N'Ngữ văn', 8, N'Giỏi'),
(16, N'Tiếng Anh', 10, N'Xuất sắc'),
(16, N'Hóa học', 10, N'Xuất sắc'),
(17, N'Ngữ văn', 10, N'Xuất sắc'),
(17, N'Tiếng Anh', 6, N'Trung bình'),
(17, N'Vật lý', 7, N'Khá'),
(18, N'Toán', 8, N'Giỏi'),
(18, N'Ngữ văn', 6, N'Trung bình'),
(18, N'Tiếng Anh', 9, N'Xuất sắc'),
(19, N'Vật lý', 8, N'Giỏi'),
(19, N'Hóa học', 9, N'Xuất sắc'),
(19, N'Sinh học', 8, N'Giỏi'),
(20, N'Toán', 5, N'Trung bình'),
(20, N'Vật lý', 6, N'Trung bình'),
(20, N'Hóa học', 9, N'Xuất sắc'),
(20, N'Sinh học', 6, N'Trung bình'),
(21, N'Toán', 5, N'Trung bình'),
(21, N'Hóa học', 7, N'Khá'),
(21, N'Sinh học', 8, N'Giỏi'),
(22, N'Toán', 6, N'Trung bình'),
(22, N'Ngữ văn', 6, N'Trung bình'),
(22, N'Hóa học', 8, N'Giỏi'),
(22, N'Sinh học', 9, N'Xuất sắc'),
(23, N'Tiếng Anh', 5, N'Trung bình'),
(23, N'Vật lý', 5, N'Trung bình'),
(23, N'Hóa học', 6, N'Trung bình'),
(24, N'Toán', 6, N'Trung bình'),
(24, N'Ngữ văn', 5, N'Trung bình'),
(24, N'Vật lý', 10, N'Xuất sắc'),
(24, N'Sinh học', 8, N'Giỏi'),
(25, N'Ngữ văn', 8, N'Giỏi'),
(25, N'Vật lý', 8, N'Giỏi'),
(25, N'Hóa học', 9, N'Xuất sắc'),
(25, N'Sinh học', 10, N'Xuất sắc'),
(26, N'Toán', 5, N'Trung bình'),
(26, N'Ngữ văn', 7, N'Khá'),
(26, N'Vật lý', 10, N'Xuất sắc'),
(27, N'Ngữ văn', 6, N'Trung bình'),
(27, N'Tiếng Anh', 6, N'Trung bình'),
(27, N'Sinh học', 5, N'Trung bình'),
(28, N'Ngữ văn', 8, N'Giỏi'),
(28, N'Tiếng Anh', 10, N'Xuất sắc'),
(28, N'Sinh học', 5, N'Trung bình'),
(29, N'Toán', 6, N'Trung bình'),
(29, N'Ngữ văn', 10, N'Xuất sắc'),
(29, N'Vật lý', 6, N'Trung bình'),
(30, N'Tiếng Anh', 9, N'Xuất sắc'),
(30, N'Vật lý', 7, N'Khá'),
(30, N'Hóa học', 6, N'Trung bình'),
(30, N'Sinh học', 8, N'Giỏi');
GO

INSERT INTO diem_chitiet (StudentId, CourseName, SemesterId, LoaiDiem, Diem, HeSo, GhiChu)
SELECT StudentId, CourseName, 3, N'Thi', Score, 1, N'Thi cuối kỳ'
FROM score
ORDER BY StudentId, CourseName;
GO

INSERT INTO room (RoomName, Capacity) VALUES
(N'A101', 40),
(N'A102', 40),
(N'B201', 50),
(N'B202', 50),
(N'LAB1', 30),
(N'LAB2', 30);
GO

INSERT INTO schedule (CourseId, ClassId, TeacherId, RoomId, SemesterId, DayOfWeek, StartTime, EndTime) VALUES
(1, 1, 1, 5, 3, N'Thứ 2', '07:30:00', '09:30:00'),
(1, 2, 1, 5, 3, N'Thứ 2', '09:45:00', '11:45:00'),
(2, 1, 2, 1, 3, N'Thứ 3', '07:30:00', '09:30:00'),
(2, 2, 2, 1, 3, N'Thứ 3', '09:45:00', '11:45:00'),
(2, 3, 2, 2, 3, N'Thứ 4', '07:30:00', '09:30:00'),
(3, 3, 3, 6, 3, N'Thứ 4', '13:00:00', '15:00:00'),
(3, 1, 3, 6, 3, N'Thứ 5', '07:30:00', '09:30:00'),
(4, 2, 3, 3, 3, N'Thứ 5', '13:00:00', '15:00:00'),
(4, 3, 3, 3, 3, N'Thứ 6', '07:30:00', '09:30:00'),
(5, 4, 4, 4, 3, N'Thứ 2', '13:00:00', '15:00:00'),
(5, 1, 4, 4, 3, N'Thứ 3', '13:00:00', '15:00:00'),
(6, 4, 5, 2, 3, N'Thứ 6', '13:00:00', '15:00:00'),
(6, 2, 5, 2, 3, N'Thứ 5', '09:45:00', '11:45:00');
GO

INSERT INTO attendance (StudentId, CourseId, AttendDate, Status) VALUES
(1, 1, '2026-09-07', N'Có mặt'),
(2, 1, '2026-09-07', N'Có mặt'),
(3, 1, '2026-09-07', N'Đi muộn'),
(4, 1, '2026-09-07', N'Có mặt'),
(1, 1, '2026-09-14', N'Có mặt'),
(2, 1, '2026-09-14', N'Vắng'),
(3, 1, '2026-09-14', N'Có mặt'),
(4, 1, '2026-09-14', N'Có mặt'),
(1, 1, '2026-09-21', N'Có mặt'),
(2, 1, '2026-09-21', N'Có mặt'),
(3, 1, '2026-09-21', N'Có mặt'),
(4, 1, '2026-09-21', N'Vắng'),
(1, 2, '2026-09-08', N'Có mặt'),
(2, 2, '2026-09-08', N'Có mặt'),
(3, 2, '2026-09-08', N'Có mặt'),
(4, 2, '2026-09-08', N'Đi muộn'),
(1, 2, '2026-09-15', N'Có mặt'),
(2, 2, '2026-09-15', N'Vắng'),
(3, 2, '2026-09-15', N'Có mặt'),
(4, 2, '2026-09-15', N'Có mặt'),
(1, 3, '2026-09-10', N'Có mặt'),
(2, 3, '2026-09-10', N'Có mặt'),
(3, 3, '2026-09-10', N'Vắng'),
(1, 3, '2026-09-17', N'Có mặt'),
(2, 3, '2026-09-17', N'Đi muộn'),
(3, 3, '2026-09-17', N'Có mặt'),
(9, 1, '2026-09-07', N'Có mặt'),
(10, 1, '2026-09-07', N'Có mặt'),
(9, 1, '2026-09-14', N'Đi muộn'),
(10, 1, '2026-09-14', N'Có mặt');
GO

INSERT INTO tuition (StudentId, SemesterId, Amount, PaidDate, Status) VALUES
(1, 2, 7800000, '2026-02-05', N'Đã đóng'),
(2, 2, 7800000, '2026-02-06', N'Đã đóng'),
(3, 2, 7800000, '2026-02-08', N'Đã đóng'),
(4, 2, 7800000, '2026-02-10', N'Đã đóng'),
(5, 2, 7800000, '2026-02-10', N'Đã đóng'),
(6, 2, 7800000, '2026-02-12', N'Đã đóng'),
(7, 2, 7800000, '2026-02-12', N'Đã đóng'),
(8, 2, 7800000, '2026-02-14', N'Đã đóng'),
(9, 2, 7800000, '2026-02-15', N'Đã đóng'),
(10, 2, 7800000, '2026-02-15', N'Đã đóng'),
(1, 3, 8500000, '2026-09-02', N'Đã đóng'),
(2, 3, 8500000, '2026-09-03', N'Đã đóng'),
(3, 3, 8500000, '2026-09-03', N'Đã đóng'),
(4, 3, 8500000, '2026-09-05', N'Đã đóng'),
(5, 3, 8500000, '2026-09-05', N'Đã đóng'),
(6, 3, 8500000, NULL, N'Chưa đóng'),
(7, 3, 8500000, '2026-09-08', N'Đã đóng'),
(8, 3, 8500000, '2026-09-09', N'Đã đóng'),
(9, 3, 8500000, NULL, N'Chưa đóng'),
(10, 3, 8500000, '2026-09-10', N'Đã đóng');
GO

INSERT INTO login (TenDangNhap, MatKhau, HoTen, VaiTro) VALUES
(N'admin', N'admin123', N'Quản trị hệ thống', N'Admin'),
(N'giaovien', N'123456', N'Nguyễn Văn Minh', N'Giáo viên'),
(N'vanphong', N'123456', N'Trần Thị Lan', N'Văn phòng');
GO
