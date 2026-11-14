-- =====================================================================
--  BTN_NHÓM4_QLDIEMTHPT - Cơ sở dữ liệu studentdb (SQL Server)
--
--  Cách chạy: mở SQL Server Management Studio (SSMS), File > Open > File
--  chọn file này, rồi bấm Execute (F5). Không cần tạo CSDL trước,
--  file tự tạo studentdb nếu chưa có.
--
--  Bản T-SQL này chuyển từ bản MySQL cũ. Những chỗ đã đổi:
--    `tên`              -> [tên]
--    AUTO_INCREMENT     -> IDENTITY(1,1)
--    VARCHAR            -> NVARCHAR  (để lưu tiếng Việt)
--    'chuỗi tiếng Việt' -> N'chuỗi tiếng Việt'
--    DOUBLE             -> FLOAT
--    LONGBLOB           -> VARBINARY(MAX)
--    X'89504E...'       -> 0x89504E...
--    CREATE TABLE IF NOT EXISTS -> IF OBJECT_ID(...) IS NULL CREATE TABLE
--    INSERT IGNORE      -> IF NOT EXISTS (...) + SET IDENTITY_INSERT
--
--  File chạy lại nhiều lần không sao: mỗi khối INSERT đều có kiểm tra
--  bảng đã có dữ liệu chưa.
--
--  Gồm 14 bảng: 12 bảng gốc kèm dữ liệu mẫu (phần A), thêm hai bảng
--  login và diem_chitiet (phần B), đổi dữ liệu tiếng Anh của bản cũ sang
--  tiếng Việt (phần C).
-- =====================================================================

IF DB_ID('studentdb') IS NULL
    CREATE DATABASE studentdb;
GO

USE studentdb;
GO

-- =====================================================================
--  PHẦN A - 12 BẢNG GỐC
-- =====================================================================

IF OBJECT_ID('student', 'U') IS NULL
CREATE TABLE [student] (
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

IF OBJECT_ID('course', 'U') IS NULL
CREATE TABLE [course] (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(100) NOT NULL UNIQUE,
    CourseHour INT NOT NULL,
    Description NVARCHAR(200)
);
GO

IF OBJECT_ID('score', 'U') IS NULL
CREATE TABLE [score] (
    StudentId INT NOT NULL,
    CourseName NVARCHAR(100) NOT NULL,
    Score FLOAT NOT NULL,
    Description NVARCHAR(200),
    PRIMARY KEY (StudentId, CourseName),
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (CourseName) REFERENCES course(CourseName) ON UPDATE CASCADE ON DELETE CASCADE
);
GO

IF OBJECT_ID('department', 'U') IS NULL
CREATE TABLE [department] (
    DeptId INT IDENTITY(1,1) PRIMARY KEY,
    DeptName NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(200)
);
GO

-- Giáo viên, mỗi người thuộc một khoa
IF OBJECT_ID('teacher', 'U') IS NULL
CREATE TABLE [teacher] (
    TeacherId INT IDENTITY(1,1) PRIMARY KEY,
    TeacherName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    DeptId INT NOT NULL,
    FOREIGN KEY (DeptId) REFERENCES department(DeptId)
);
GO

-- Lớp, thuộc một khoa và có một giáo viên chủ nhiệm
IF OBJECT_ID('class', 'U') IS NULL
CREATE TABLE [class] (
    ClassId INT IDENTITY(1,1) PRIMARY KEY,
    ClassName NVARCHAR(50) NOT NULL UNIQUE,
    SchoolYear NVARCHAR(20) NOT NULL,
    DeptId INT NOT NULL,
    TeacherId INT,
    FOREIGN KEY (DeptId) REFERENCES department(DeptId),
    FOREIGN KEY (TeacherId) REFERENCES teacher(TeacherId)
);
GO

-- Mỗi học sinh thuộc một lớp
IF OBJECT_ID('student_class', 'U') IS NULL
CREATE TABLE [student_class] (
    StudentId INT PRIMARY KEY,
    ClassId INT NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES student(StdId) ON DELETE CASCADE,
    FOREIGN KEY (ClassId) REFERENCES class(ClassId)
);
GO

IF OBJECT_ID('room', 'U') IS NULL
CREATE TABLE [room] (
    RoomId INT IDENTITY(1,1) PRIMARY KEY,
    RoomName NVARCHAR(50) NOT NULL UNIQUE,
    Capacity INT NOT NULL
);
GO

IF OBJECT_ID('semester', 'U') IS NULL
CREATE TABLE [semester] (
    SemesterId INT IDENTITY(1,1) PRIMARY KEY,
    SemesterName NVARCHAR(50) NOT NULL UNIQUE,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL
);
GO

-- Thời khoá biểu: môn nào, lớp nào, giáo viên nào, phòng nào, thứ mấy, mấy giờ
IF OBJECT_ID('schedule', 'U') IS NULL
CREATE TABLE [schedule] (
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

-- Điểm danh: Có mặt, Vắng, Đi muộn
IF OBJECT_ID('attendance', 'U') IS NULL
CREATE TABLE [attendance] (
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

-- Học phí mỗi học kỳ: Đã đóng, Chưa đóng
IF OBJECT_ID('tuition', 'U') IS NULL
CREATE TABLE [tuition] (
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

-- ---------------------------------------------------------------------
--  Dữ liệu mẫu
-- ---------------------------------------------------------------------

IF NOT EXISTS (SELECT 1 FROM [course])
BEGIN
    SET IDENTITY_INSERT [course] ON;
    INSERT INTO [course] ([CourseId], [CourseName], [CourseHour], [Description]) VALUES
    (1, N'Lập trình .NET', 60, N'Lập trình WinForms với C#'),
    (2, N'Cơ sở dữ liệu', 45, N'Thiết kế và truy vấn CSDL'),
    (3, N'Lập trình Web', 45, N'HTML, CSS, JavaScript'),
    (4, N'Mạng máy tính', 45, N'Mô hình OSI và TCP/IP'),
    (5, N'Toán rời rạc', 30, N'Logic, tập hợp và đồ thị'),
    (6, N'Cấu trúc dữ liệu', 45, N'Danh sách, cây và thuật toán sắp xếp');
    SET IDENTITY_INSERT [course] OFF;
END
GO

IF NOT EXISTS (SELECT 1 FROM [student])
BEGIN
    DECLARE @photo VARBINARY(MAX) = 0x89504E470D0A1A0A0000000D49484452000000100000001008060000001FF3FF61000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA8640000001D49444154384F63F09A70F33F2598015D80543C6AC0A801A3060C160300B218B21FF4C5F6E30000000049454E44AE426082;

    SET IDENTITY_INSERT [student] ON;
    INSERT INTO [student] ([StdId], [StdFirstName], [StdLastName], [Birthdate], [Gender], [Phone], [Address], [Photo]) VALUES
    (1, N'Văn An', N'Nguyễn', '2005-03-12', N'Nam', '0941404371', N'12 Nguyễn Huệ, Quận 1, TP.HCM', @photo),
    (2, N'Thị Bình', N'Trần', '2005-07-25', N'Nữ', '0949154299', N'45 Lê Lợi, Quận 1, TP.HCM', @photo),
    (3, N'Minh Châu', N'Lê', '2004-11-02', N'Nam', '0912545845', N'78 Trần Hưng Đạo, Quận 5, TP.HCM', @photo),
    (4, N'Ngọc Dung', N'Phạm', '2006-01-18', N'Nữ', '0869646355', N'23 Hai Bà Trưng, Hoàn Kiếm, Hà Nội', @photo),
    (5, N'Quốc Huy', N'Hoàng', '2005-09-30', N'Nam', '0933969698', N'56 Lý Thường Kiệt, Hải Châu, Đà Nẵng', @photo),
    (6, N'Thu Hà', N'Vũ', '2004-05-14', N'Nữ', '0941496562', N'89 Phan Chu Trinh, TP. Huế', @photo),
    (7, N'Đức Khang', N'Đặng', '2006-04-08', N'Nam', '0912730878', N'34 Nguyễn Trãi, Ninh Kiều, Cần Thơ', @photo),
    (8, N'Mai Linh', N'Bùi', '2005-12-21', N'Nữ', '0989100870', N'67 Võ Văn Tần, Quận 3, TP.HCM', @photo),
    (9, N'Gia Bảo', N'Đỗ', '2004-08-09', N'Nam', '0948338056', N'10 Điện Biên Phủ, Bình Thạnh, TP.HCM', @photo),
    (10, N'Phương Thảo', N'Ngô', '2006-02-27', N'Nữ', '0326164608', N'91 Nguyễn Văn Cừ, TP. Biên Hòa', @photo),
    (11, N'Hoàng Nam', N'Phan', '2005-06-03', N'Nam', '0935920798', N'15 Lê Duẩn, Đống Đa, Hà Nội', @photo),
    (12, N'Kim Ngân', N'Võ', '2005-10-17', N'Nữ', '0868878867', N'28 Pasteur, Quận 1, TP.HCM', @photo),
    (13, N'Anh Tuấn', N'Đinh', '2004-02-22', N'Nam', '0866411674', N'7 Trần Phú, TP. Nha Trang', @photo),
    (14, N'Bảo Trâm', N'Lý', '2006-07-11', N'Nữ', '0945529770', N'63 Nguyễn Thị Minh Khai, Quận 3, TP.HCM', @photo),
    (15, N'Tấn Phát', N'Trương', '2005-01-29', N'Nam', '0979460588', N'102 Cách Mạng Tháng 8, Quận 10, TP.HCM', @photo),
    (16, N'Yến Nhi', N'Dương', '2004-09-05', N'Nữ', '0914157219', N'19 Lê Hồng Phong, TP. Vũng Tàu', @photo),
    (17, N'Công Danh', N'Huỳnh', '2006-03-14', N'Nam', '0983378885', N'44 Hùng Vương, TP. Buôn Ma Thuột', @photo),
    (18, N'Cẩm Tú', N'Lâm', '2005-05-20', N'Nữ', '0943157135', N'8 Trần Quốc Toản, Quận 3, TP.HCM', @photo),
    (19, N'Thanh Tùng', N'Mai', '2004-12-01', N'Nam', '0918897422', N'71 Nguyễn Văn Linh, Hải Châu, Đà Nẵng', @photo),
    (20, N'Diệu Hiền', N'Tạ', '2006-08-23', N'Nữ', '0912829601', N'36 Trần Hưng Đạo, TP. Quy Nhơn', @photo),
    (21, N'Khánh Duy', N'Cao', '2005-04-16', N'Nam', '0327948311', N'52 Quang Trung, Gò Vấp, TP.HCM', @photo),
    (22, N'Hải Yến', N'Lương', '2004-06-27', N'Nữ', '0945664298', N'14 Hoàng Diệu, TP. Thủ Đức', @photo),
    (23, N'Trọng Nghĩa', N'Châu', '2006-11-09', N'Nam', '0985336243', N'25 Phạm Ngũ Lão, TP. Hải Phòng', @photo),
    (24, N'Lan Anh', N'Hồ', '2005-02-13', N'Nữ', '0906665802', N'93 Lê Văn Sỹ, Tân Bình, TP.HCM', @photo),
    (25, N'Đình Khoa', N'Quách', '2004-10-30', N'Nam', '0917076599', N'6 Bạch Đằng, Hải Châu, Đà Nẵng', @photo),
    (26, N'Tuyết Mai', N'Trịnh', '2006-05-06', N'Nữ', '0987087885', N'38 Nguyễn Đình Chiểu, Quận 3, TP.HCM', @photo),
    (27, N'Minh Quân', N'Lưu', '2005-08-19', N'Nam', '0977560676', N'81 Hồ Tùng Mậu, Cầu Giấy, Hà Nội', @photo),
    (28, N'Thùy Dương', N'Kiều', '2004-03-31', N'Nữ', '0949335495', N'17 Lê Thánh Tôn, Quận 1, TP.HCM', @photo),
    (29, N'Văn Hậu', N'Đoàn', '2006-09-12', N'Nam', '0916233145', N'49 Nguyễn Tri Phương, TP. Huế', @photo),
    (30, N'Bích Phượng', N'Thái', '2005-11-25', N'Nữ', '0916139710', N'22 Ba Tháng Hai, Ninh Kiều, Cần Thơ', @photo);
    SET IDENTITY_INSERT [student] OFF;
END
GO

IF NOT EXISTS (SELECT 1 FROM [score])
INSERT INTO [score] ([StudentId], [CourseName], [Score], [Description]) VALUES
(1, N'Lập trình .NET', 9, N'Xuất sắc'),
(1, N'Toán rời rạc', 8, N'Giỏi'),
(1, N'Cấu trúc dữ liệu', 7, N'Khá'),
(2, N'Lập trình .NET', 6, N'Trung bình'),
(2, N'Cơ sở dữ liệu', 8, N'Giỏi'),
(2, N'Mạng máy tính', 9, N'Xuất sắc'),
(2, N'Toán rời rạc', 5, N'Trung bình'),
(3, N'Lập trình .NET', 6, N'Trung bình'),
(3, N'Lập trình Web', 8, N'Giỏi'),
(3, N'Mạng máy tính', 6, N'Trung bình'),
(3, N'Cấu trúc dữ liệu', 6, N'Trung bình'),
(4, N'Cơ sở dữ liệu', 7, N'Khá'),
(4, N'Mạng máy tính', 9, N'Xuất sắc'),
(4, N'Toán rời rạc', 8, N'Giỏi'),
(5, N'Cơ sở dữ liệu', 10, N'Xuất sắc'),
(5, N'Toán rời rạc', 9, N'Xuất sắc'),
(5, N'Cấu trúc dữ liệu', 9, N'Xuất sắc'),
(6, N'Lập trình .NET', 7, N'Khá'),
(6, N'Lập trình Web', 7, N'Khá'),
(6, N'Toán rời rạc', 8, N'Giỏi'),
(7, N'Cơ sở dữ liệu', 8, N'Giỏi'),
(7, N'Mạng máy tính', 5, N'Trung bình'),
(7, N'Toán rời rạc', 7, N'Khá'),
(7, N'Cấu trúc dữ liệu', 9, N'Xuất sắc'),
(8, N'Cơ sở dữ liệu', 10, N'Xuất sắc'),
(8, N'Lập trình Web', 8, N'Giỏi'),
(8, N'Cấu trúc dữ liệu', 10, N'Xuất sắc'),
(9, N'Cơ sở dữ liệu', 8, N'Giỏi'),
(9, N'Lập trình Web', 6, N'Trung bình'),
(9, N'Mạng máy tính', 7, N'Khá'),
(10, N'Lập trình .NET', 9, N'Xuất sắc'),
(10, N'Cơ sở dữ liệu', 10, N'Xuất sắc'),
(10, N'Toán rời rạc', 9, N'Xuất sắc'),
(10, N'Cấu trúc dữ liệu', 8, N'Giỏi'),
(11, N'Lập trình .NET', 5, N'Trung bình'),
(11, N'Cơ sở dữ liệu', 7, N'Khá'),
(11, N'Mạng máy tính', 7, N'Khá'),
(11, N'Toán rời rạc', 7, N'Khá'),
(12, N'Lập trình .NET', 8, N'Giỏi'),
(12, N'Cơ sở dữ liệu', 8, N'Giỏi'),
(12, N'Toán rời rạc', 9, N'Xuất sắc'),
(12, N'Cấu trúc dữ liệu', 9, N'Xuất sắc'),
(13, N'Cơ sở dữ liệu', 7, N'Khá'),
(13, N'Toán rời rạc', 8, N'Giỏi'),
(13, N'Cấu trúc dữ liệu', 10, N'Xuất sắc'),
(14, N'Lập trình .NET', 7, N'Khá'),
(14, N'Cơ sở dữ liệu', 6, N'Trung bình'),
(14, N'Mạng máy tính', 8, N'Giỏi'),
(14, N'Toán rời rạc', 9, N'Xuất sắc'),
(15, N'Cơ sở dữ liệu', 8, N'Giỏi'),
(15, N'Mạng máy tính', 7, N'Khá'),
(15, N'Toán rời rạc', 7, N'Khá'),
(15, N'Cấu trúc dữ liệu', 6, N'Trung bình'),
(16, N'Lập trình .NET', 7, N'Khá'),
(16, N'Cơ sở dữ liệu', 8, N'Giỏi'),
(16, N'Lập trình Web', 10, N'Xuất sắc'),
(16, N'Toán rời rạc', 10, N'Xuất sắc'),
(17, N'Cơ sở dữ liệu', 10, N'Xuất sắc'),
(17, N'Lập trình Web', 6, N'Trung bình'),
(17, N'Mạng máy tính', 7, N'Khá'),
(18, N'Lập trình .NET', 8, N'Giỏi'),
(18, N'Cơ sở dữ liệu', 6, N'Trung bình'),
(18, N'Lập trình Web', 9, N'Xuất sắc'),
(19, N'Mạng máy tính', 8, N'Giỏi'),
(19, N'Toán rời rạc', 9, N'Xuất sắc'),
(19, N'Cấu trúc dữ liệu', 8, N'Giỏi'),
(20, N'Lập trình .NET', 5, N'Trung bình'),
(20, N'Mạng máy tính', 6, N'Trung bình'),
(20, N'Toán rời rạc', 9, N'Xuất sắc'),
(20, N'Cấu trúc dữ liệu', 6, N'Trung bình'),
(21, N'Lập trình .NET', 5, N'Trung bình'),
(21, N'Toán rời rạc', 7, N'Khá'),
(21, N'Cấu trúc dữ liệu', 8, N'Giỏi'),
(22, N'Lập trình .NET', 6, N'Trung bình'),
(22, N'Cơ sở dữ liệu', 6, N'Trung bình'),
(22, N'Toán rời rạc', 8, N'Giỏi'),
(22, N'Cấu trúc dữ liệu', 9, N'Xuất sắc'),
(23, N'Lập trình Web', 5, N'Trung bình'),
(23, N'Mạng máy tính', 5, N'Trung bình'),
(23, N'Toán rời rạc', 6, N'Trung bình'),
(24, N'Lập trình .NET', 6, N'Trung bình'),
(24, N'Cơ sở dữ liệu', 5, N'Trung bình'),
(24, N'Mạng máy tính', 10, N'Xuất sắc'),
(24, N'Cấu trúc dữ liệu', 8, N'Giỏi'),
(25, N'Cơ sở dữ liệu', 8, N'Giỏi'),
(25, N'Mạng máy tính', 8, N'Giỏi'),
(25, N'Toán rời rạc', 9, N'Xuất sắc'),
(25, N'Cấu trúc dữ liệu', 10, N'Xuất sắc'),
(26, N'Lập trình .NET', 5, N'Trung bình'),
(26, N'Cơ sở dữ liệu', 7, N'Khá'),
(26, N'Mạng máy tính', 10, N'Xuất sắc'),
(27, N'Cơ sở dữ liệu', 6, N'Trung bình'),
(27, N'Lập trình Web', 6, N'Trung bình'),
(27, N'Cấu trúc dữ liệu', 5, N'Trung bình'),
(28, N'Cơ sở dữ liệu', 8, N'Giỏi'),
(28, N'Lập trình Web', 10, N'Xuất sắc'),
(28, N'Cấu trúc dữ liệu', 5, N'Trung bình'),
(29, N'Lập trình .NET', 6, N'Trung bình'),
(29, N'Cơ sở dữ liệu', 10, N'Xuất sắc'),
(29, N'Mạng máy tính', 6, N'Trung bình'),
(30, N'Lập trình Web', 9, N'Xuất sắc'),
(30, N'Mạng máy tính', 7, N'Khá'),
(30, N'Toán rời rạc', 6, N'Trung bình'),
(30, N'Cấu trúc dữ liệu', 8, N'Giỏi');
GO

IF NOT EXISTS (SELECT 1 FROM [department])
BEGIN
    SET IDENTITY_INSERT [department] ON;
    INSERT INTO [department] ([DeptId], [DeptName], [Description]) VALUES
    (1, N'Công nghệ thông tin', N'Lập trình, cơ sở dữ liệu, mạng máy tính'),
    (2, N'Toán - Tin ứng dụng', N'Toán rời rạc, cấu trúc dữ liệu'),
    (3, N'Ngoại ngữ', N'Tiếng Anh chuyên ngành');
    SET IDENTITY_INSERT [department] OFF;
END
GO

IF NOT EXISTS (SELECT 1 FROM [teacher])
BEGIN
    SET IDENTITY_INSERT [teacher] ON;
    INSERT INTO [teacher] ([TeacherId], [TeacherName], [Phone], [Email], [DeptId]) VALUES
    (1, N'Nguyễn Văn Minh', '0900000001', 'minh.nv@mdemy.example', 1),
    (2, N'Trần Thị Lan', '0900000002', 'lan.tt@mdemy.example', 1),
    (3, N'Lê Quốc Bảo', '0900000003', 'bao.lq@mdemy.example', 1),
    (4, N'Phạm Thu Hằng', '0900000004', 'hang.pt@mdemy.example', 2),
    (5, N'Hoàng Đức Thịnh', '0900000005', 'thinh.hd@mdemy.example', 2),
    (6, N'Vũ Ngọc Anh', '0900000006', 'anh.vn@mdemy.example', 3);
    SET IDENTITY_INSERT [teacher] OFF;
END
GO

IF NOT EXISTS (SELECT 1 FROM [class])
BEGIN
    SET IDENTITY_INSERT [class] ON;
    INSERT INTO [class] ([ClassId], [ClassName], [SchoolYear], [DeptId], [TeacherId]) VALUES
    (1, N'CNTT23A', N'2023-2027', 1, 1),
    (2, N'CNTT23B', N'2023-2027', 1, 2),
    (3, N'CNTT23C', N'2023-2027', 1, 3),
    (4, N'TTUD23A', N'2023-2027', 2, 4);
    SET IDENTITY_INSERT [class] OFF;
END
GO

IF NOT EXISTS (SELECT 1 FROM [student_class])
INSERT INTO [student_class] ([StudentId], [ClassId]) VALUES
(1, 1), (2, 1), (3, 1), (4, 1), (5, 1), (6, 1), (7, 1), (8, 1),
(9, 2), (10, 2), (11, 2), (12, 2), (13, 2), (14, 2), (15, 2), (16, 2),
(17, 3), (18, 3), (19, 3), (20, 3), (21, 3), (22, 3), (23, 3), (24, 4),
(25, 4), (26, 4), (27, 4), (28, 4), (29, 4), (30, 4);
GO

IF NOT EXISTS (SELECT 1 FROM [room])
BEGIN
    SET IDENTITY_INSERT [room] ON;
    INSERT INTO [room] ([RoomId], [RoomName], [Capacity]) VALUES
    (1, N'A101', 40),
    (2, N'A102', 40),
    (3, N'B201', 50),
    (4, N'B202', 50),
    (5, N'LAB1', 30),
    (6, N'LAB2', 30);
    SET IDENTITY_INSERT [room] OFF;
END
GO

IF NOT EXISTS (SELECT 1 FROM [semester])
BEGIN
    SET IDENTITY_INSERT [semester] ON;
    INSERT INTO [semester] ([SemesterId], [SemesterName], [StartDate], [EndDate]) VALUES
    (1, N'Học kỳ 1 - 2025-2026', '2025-09-01', '2026-01-15'),
    (2, N'Học kỳ 2 - 2025-2026', '2026-02-01', '2026-06-15'),
    (3, N'Học kỳ 1 - 2026-2027', '2026-09-01', '2027-01-15');
    SET IDENTITY_INSERT [semester] OFF;
END
GO

IF NOT EXISTS (SELECT 1 FROM [schedule])
BEGIN
    SET IDENTITY_INSERT [schedule] ON;
    INSERT INTO [schedule] ([ScheduleId], [CourseId], [ClassId], [TeacherId], [RoomId], [SemesterId], [DayOfWeek], [StartTime], [EndTime]) VALUES
    (1, 1, 1, 1, 5, 3, N'Thứ 2', '07:30:00', '09:30:00'),
    (2, 1, 2, 1, 5, 3, N'Thứ 2', '09:45:00', '11:45:00'),
    (3, 2, 1, 2, 1, 3, N'Thứ 3', '07:30:00', '09:30:00'),
    (4, 2, 2, 2, 1, 3, N'Thứ 3', '09:45:00', '11:45:00'),
    (5, 2, 3, 2, 2, 3, N'Thứ 4', '07:30:00', '09:30:00'),
    (6, 3, 3, 3, 6, 3, N'Thứ 4', '13:00:00', '15:00:00'),
    (7, 3, 1, 3, 6, 3, N'Thứ 5', '07:30:00', '09:30:00'),
    (8, 4, 2, 3, 3, 3, N'Thứ 5', '13:00:00', '15:00:00'),
    (9, 4, 3, 3, 3, 3, N'Thứ 6', '07:30:00', '09:30:00'),
    (10, 5, 4, 4, 4, 3, N'Thứ 2', '13:00:00', '15:00:00'),
    (11, 5, 1, 4, 4, 3, N'Thứ 3', '13:00:00', '15:00:00'),
    (12, 6, 4, 5, 2, 3, N'Thứ 6', '13:00:00', '15:00:00'),
    (13, 6, 2, 5, 2, 3, N'Thứ 5', '09:45:00', '11:45:00');
    SET IDENTITY_INSERT [schedule] OFF;
END
GO

IF NOT EXISTS (SELECT 1 FROM [attendance])
INSERT INTO [attendance] ([StudentId], [CourseId], [AttendDate], [Status]) VALUES
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

IF NOT EXISTS (SELECT 1 FROM [tuition])
INSERT INTO [tuition] ([StudentId], [SemesterId], [Amount], [PaidDate], [Status]) VALUES
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

-- =====================================================================
--  PHẦN B - 2 BẢNG BỔ SUNG
-- =====================================================================

-- Bảng login: thêm họ tên và vai trò để form chính hiện được người đang
-- đăng nhập. Bảng [user] cũ chỉ có username và password nên không dùng nữa.
IF OBJECT_ID('login', 'U') IS NULL
CREATE TABLE [login] (
    MaND INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(50) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL
);
GO

IF NOT EXISTS (SELECT 1 FROM [login])
BEGIN
    SET IDENTITY_INSERT [login] ON;
    INSERT INTO [login] ([MaND], [TenDangNhap], [MatKhau], [HoTen], [VaiTro]) VALUES
    (1, N'admin', N'admin123', N'Quản trị hệ thống', N'Admin'),
    (2, N'giaovien', N'123456', N'Nguyễn Văn Minh', N'Giáo viên'),
    (3, N'vanphong', N'123456', N'Trần Thị Lan', N'Văn phòng');
    SET IDENTITY_INSERT [login] OFF;
END
GO

-- Bảng diem_chitiet: mỗi môn của mỗi học sinh có nhiều đầu điểm (miệng,
-- 15 phút, 1 tiết, thi), mỗi đầu điểm một hệ số. Điểm trung bình môn
-- = SUM(Diem * HeSo) / SUM(HeSo), chương trình tính rồi ghi vào score.
--
-- Lưu ý: khoá ngoại trỏ vào course(CourseName) với ON DELETE CASCADE sẽ
-- tạo nhiều đường cascade cùng tới student. SQL Server không cho phép,
-- nên FK tới course ở bảng này chỉ ON UPDATE CASCADE (khác bản MySQL).
IF OBJECT_ID('diem_chitiet', 'U') IS NULL
CREATE TABLE [diem_chitiet] (
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

-- Chuyển các dòng điểm có sẵn trong score thành đầu điểm "Thi" để điểm
-- trung bình tính ra khớp với điểm cũ.
INSERT INTO [diem_chitiet] (StudentId, CourseName, SemesterId, LoaiDiem, Diem, HeSo, GhiChu)
SELECT score.StudentId, score.CourseName, 3, N'Thi', score.Score, 1, N'Chuyển từ dữ liệu điểm cũ'
FROM score
WHERE NOT EXISTS (
    SELECT 1 FROM diem_chitiet d
    WHERE d.StudentId = score.StudentId AND d.CourseName = score.CourseName
);
GO

-- CSDL cũ nào vẫn còn bảng [user] thì bỏ dấu -- ở dòng dưới rồi chạy lại
-- DROP TABLE [user];

-- =====================================================================
--  PHẦN C - ĐỔI DỮ LIỆU CŨ SANG TIẾNG VIỆT
--  Chương trình lưu thẳng tiếng Việt vào CSDL. Mấy câu dưới đây đổi nốt
--  các giá trị tiếng Anh của bản studentdb cũ, chạy lại cũng không sao
--  vì không còn dòng nào khớp nữa.
-- =====================================================================
UPDATE [student] SET [Gender] = N'Nam' WHERE [Gender] = N'Male';
UPDATE [student] SET [Gender] = N'Nữ'  WHERE [Gender] = N'Female';

UPDATE [schedule] SET [DayOfWeek] = N'Thứ 2' WHERE [DayOfWeek] = N'Monday';
UPDATE [schedule] SET [DayOfWeek] = N'Thứ 3' WHERE [DayOfWeek] = N'Tuesday';
UPDATE [schedule] SET [DayOfWeek] = N'Thứ 4' WHERE [DayOfWeek] = N'Wednesday';
UPDATE [schedule] SET [DayOfWeek] = N'Thứ 5' WHERE [DayOfWeek] = N'Thursday';
UPDATE [schedule] SET [DayOfWeek] = N'Thứ 6' WHERE [DayOfWeek] = N'Friday';
UPDATE [schedule] SET [DayOfWeek] = N'Thứ 7' WHERE [DayOfWeek] = N'Saturday';

UPDATE [attendance] SET [Status] = N'Có mặt'  WHERE [Status] = N'Present';
UPDATE [attendance] SET [Status] = N'Vắng'    WHERE [Status] = N'Absent';
UPDATE [attendance] SET [Status] = N'Đi muộn' WHERE [Status] = N'Late';

UPDATE [tuition] SET [Status] = N'Đã đóng'  WHERE [Status] = N'Paid';
UPDATE [tuition] SET [Status] = N'Chưa đóng' WHERE [Status] = N'Unpaid';

UPDATE [score] SET [Description] = N'Trung bình' WHERE [Description] = N'Trung bình khá';
GO
