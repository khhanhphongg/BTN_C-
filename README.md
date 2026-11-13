# BTN_NHÓM4_QLDIEMTHPT - Hệ thống quản lý điểm học sinh THPT

Bài tập nhóm môn Lập trình .NET. Viết bằng C# WinForms (.NET Framework 4.7.2),
cơ sở dữ liệu MySQL `studentdb`, báo cáo bằng Crystal Reports.

## 1. Cần cài gì trước

| Phần mềm | Dùng để làm gì |
|---|---|
| XAMPP (MySQL) | chạy cơ sở dữ liệu studentdb |
| MySQL Connector/NET | để C# nối được MySQL |
| SAP Crystal Reports for Visual Studio | để build và xem báo cáo |

Crystal Reports tải ở bản "SAP Crystal Reports developer version for Microsoft
Visual Studio". Chưa cài thì project báo lỗi thiếu 4 reference
`CrystalDecisions.*` và không build được.

## 2. Chuẩn bị cơ sở dữ liệu

1. Bật XAMPP, chạy Apache và MySQL
2. Mở http://localhost/phpmyadmin
3. Vào tab SQL, dán cả file `capnhat_studentdb.sql` rồi bấm Go
   (không cần chọn CSDL trước)

File đó tạo đủ 14 bảng: 12 bảng gốc của studentdb kèm dữ liệu mẫu, cộng
`login` và `diem_chitiet`. Nó cũng chuyển các dòng điểm có sẵn thành đầu điểm
"Thi" để điểm trung bình tính ra khớp với điểm cũ, và đổi các giá trị tiếng
Anh của bản studentdb cũ (`Male`, `Monday`, `Present`, `Paid`...) sang tiếng
Việt.

Chạy lại nhiều lần không sao: lệnh tạo bảng đều có `IF NOT EXISTS`, lệnh thêm
dữ liệu đều là `INSERT IGNORE` và có khoá chính tường minh, nên dữ liệu không
bị nhân bản.

Bảng `user` cũ không dùng nữa vì chỉ có username và password, `login` thay thế.
CSDL cũ nào còn bảng đó thì bỏ dấu `--` ở dòng `DROP TABLE IF EXISTS user;`
gần cuối file rồi chạy lại.

## 3. Mở và chạy project

1. Mở `BTN_NHÓM4_QLDIEMTHPT.sln` bằng Visual Studio
2. Nếu reference `MySql.Data` bị dấu chấm than vàng: chuột phải project,
   Manage NuGet Packages, cài `MySql.Data`
3. Bấm F5

Tài khoản đăng nhập:

| Tên đăng nhập | Mật khẩu | Vai trò |
|---|---|---|
| admin | admin123 | Admin |
| giaovien | 123456 | Giáo viên |
| vanphong | 123456 | Văn phòng |

## 4. Tạo file báo cáo Crystal Report

File `.rpt` là định dạng nhị phân, chỉ tạo được bằng designer trong Visual
Studio nên phần này phải làm tay một lần.

1. Chuột phải project, Add > New Item > Reporting > Crystal Reports,
   đặt tên đúng là `BaoCaoDiem.rpt`
2. Hộp thoại Crystal Reports Gallery: chọn As a Blank Report, OK
3. Trong Field Explorer, chuột phải Database Fields > Database Expert
4. Create New Connection > ADO.NET (XML), bấm nút "..." chọn file
   `BaoCaoDiem.xsd` trong thư mục project, Finish
5. Đưa bảng BaoCaoDiem từ cột trái sang cột phải, OK
6. Kéo các cột từ Field Explorer vào vùng Details: `HoTen`, `Lop`, `MonHoc`,
   `DiemTB`, `HocLuc`. Muốn đẹp hơn thì kéo thêm tiêu đề vào Page Header
7. Chọn file `BaoCaoDiem.rpt` trong Solution Explorer, cửa sổ Properties đặt
   Copy to Output Directory = Copy always

Xong thì vào form Tra cứu - Thống kê, bấm nút Báo cáo Crystal Report.

Muốn report có tiêu đề động thì trong Field Explorer chuột phải
Parameter Fields > New, tạo tham số kiểu String tên đúng một trong các tên
`TenLop`, `TenMon`, `HocLuc`, `KhoangDiem`, `NgayIn` rồi kéo vào Page Header.
Code đã truyền giá trị vào, report không khai báo tham số nào thì cũng không lỗi.

Chưa tạo file `.rpt` thì nút In nhanh lưới vẫn in được (dùng DGVPrinter), nút
Báo cáo Crystal Report sẽ hiện thông báo nhắc tạo file.

## 5. Đối chiếu với yêu cầu của đề

| Yêu cầu của đề | Đã làm ở đâu |
|---|---|
| 1. Tạo project | `BTN_NHÓM4_QLDIEMTHPT.sln` |
| 2. Kết nối CSDL qua Class, viết các thủ tục xử lý | `DBconnect.cs` + 14 class nghiệp vụ |
| 3. Tạo FrmMain nối với các form | `FrmMain.cs`, menu trượt 4 nhóm |
| 4. Bổ sung bảng LOGIN, viết form Login | bảng `login` + `FrmLogin.cs` |
| 5a. Quản lý danh mục | `FrmKhoa`, `FrmMonHoc`, `FrmPhongHoc`, `FrmHocKy`, `FrmLop` |
| 5b. Quản lý thông tin học sinh | `FrmHocSinh.cs`, kèm ảnh và xếp lớp |
| 5c. Quản lý thông tin giáo viên | `FrmGiaoVien.cs` |
| 5d. Quản lý bảng điểm | `FrmBangDiem.cs` |
| 5e. Chi tiết điểm và xếp loại | `FrmChiTietDiem.cs` |
| 5f. Tra cứu và thống kê | `FrmTraCuuThongKe.cs`, 5 kiểu xem |
| 5g. Báo cáo | `FrmBaoCao.cs` + `BaoCaoDiem.xsd` |

Ngoài ra còn 3 form cho các bảng còn lại của CSDL: `FrmThoiKhoaBieu`,
`FrmDiemDanh`, `FrmHocPhi`.

## 6. Bảng điểm chia làm hai bảng

```
score                               điểm trung bình môn + học lực
  StudentId + CourseName
     |
     +-- diem_chitiet               từng đầu điểm
         Miệng    8.0  hệ số 1
         15 phút  7.5  hệ số 1
         1 tiết   9.0  hệ số 2
         Thi      8.5  hệ số 3
         Điểm TB = SUM(Diem * HeSo) / SUM(HeSo) = 8.4 -> Giỏi
```

Form Bảng điểm mở môn cho học sinh, form Chi tiết điểm nhập từng đầu điểm.
Mỗi lần thêm, sửa hoặc xoá đầu điểm thì hàm `ChiTietDiemClass.capNhatDiemTB()`
tính lại rồi ghi vào `score.Score` và `score.Description`. Vì vậy điểm trung
bình môn không nhập tay được.

Thang xếp loại: từ 9 Xuất sắc, từ 8 Giỏi, từ 6.5 Khá, từ 5 Trung bình, còn lại Yếu.

## 7. Mấy chỗ cần biết khi đọc code

- CSDL lưu thẳng tiếng Việt: giới tính `Nam`/`Nữ`, điểm danh `Có mặt`/`Vắng`/
  `Đi muộn`, học phí `Đã đóng`/`Chưa đóng`. Form đọc ghi đúng chuỗi đó, không
  phải đổi qua lại.
- Thứ trong `schedule` lưu dạng `Thứ 2` đến `Thứ 7`. Viết bằng số nên câu
  `ORDER BY DayOfWeek` cho ra đúng thứ tự thứ hai đến thứ bảy, không cần hàm
  `FIELD()` của MySQL.
- `student.StdLastName` là họ, `StdFirstName` là tên, ngược với tên cột nhưng
  dữ liệu cũ đang lưu như vậy nên giữ nguyên.
- Thời khoá biểu có kiểm tra trùng lịch: không cho hai lớp dùng một phòng cùng
  giờ, cũng không cho một giáo viên dạy hai nơi cùng giờ
  (`ThoiKhoaBieuClass.kiemTraTrungLich()`).
- Mọi câu lệnh SQL đều dùng tham số `@ten` nên không bị SQL injection.
- `diem_chitiet` trỏ khoá ngoại vào `student` và `course`, không trỏ vào
  `score`, để đổi tên môn học thì cả hai bảng cùng được cập nhật. Bù lại
  `BangDiemClass.deleteBangDiem()` phải tự xoá các đầu điểm trước khi xoá dòng
  `score`.
- Chuỗi kết nối nằm ở một chỗ duy nhất là `DBconnect.cs`. Máy nào đặt mật khẩu
  root cho MySQL thì sửa ở đó.

## 8. Danh sách file

```
BTN_NHÓM4_QLDIEMTHPT.sln
capnhat_studentdb.sql          script tạo CSDL và dữ liệu mẫu
HUONG_DAN.md                   file này
BTN_NHÓM4_QLDIEMTHPT/
    DBconnect.cs               kết nối MySQL
    DuLieuClass.cs             lớp cơ sở, 14 class dưới đây đều kế thừa
    LoginClass.cs              đăng nhập
    KhoaClass.cs               department
    MonHocClass.cs             course
    PhongHocClass.cs           room
    HocKyClass.cs              semester
    LopClass.cs                class
    GiaoVienClass.cs           teacher
    HocSinhClass.cs            student + student_class
    BangDiemClass.cs           score
    ChiTietDiemClass.cs        diem_chitiet, tính điểm trung bình môn
    ThoiKhoaBieuClass.cs       schedule, kiểm tra trùng lịch
    DiemDanhClass.cs           attendance
    HocPhiClass.cs             tuition
    ThongKeClass.cs            tra cứu, thống kê, dữ liệu cho báo cáo
    DGVPrinter.cs              thư viện in lưới
    BaoCaoDiem.xsd             lược đồ để thiết kế Crystal Report
    FrmLogin, FrmMain và 14 form nghiệp vụ
    Resources/                 ảnh dùng cho giao diện
```

## 9. Chưa làm

- File `BaoCaoDiem.rpt`, phải tạo tay trong Visual Studio, xem mục 4
- Mật khẩu trong bảng `login` còn để dạng chữ thường, chưa mã hoá
- Chưa phân quyền theo vai trò, cả 3 tài khoản đều thấy đủ menu
