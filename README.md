# Hướng dẫn cài đặt và chạy — BTN Nhóm 4, Quản lý điểm THPT

Tài liệu này dành cho thành viên nhóm cần dựng môi trường để build và chạy project trên một máy mới.

Project là **C# WinForms, .NET Framework 4.7.2**, dữ liệu lưu trên **SQL Server**, báo cáo in bằng **SAP Crystal Reports**.

> **Project đã được chuyển từ MySQL sang SQL Server.** Bản MySQL gốc còn nguyên ở thư mục `BTN_C--main_BACKUP_MySQL` cạnh thư mục project, nếu cần đối chiếu. Chi tiết những gì đã đổi xem mục 8.

---

## 1. Những thứ phải cài trước khi build

| # | Phần mềm | Dùng cho | Bắt buộc |
|---|---|---|---|
| 1 | Visual Studio 2022 (workload *.NET desktop development*) | Build + designer của Crystal Report | Có |
| 2 | SQL Server 2022 (bản nào cũng được, kể cả Express) + SSMS | Cơ sở dữ liệu `studentdb` | Có |
| 3 | SAP Crystal Reports for Visual Studio — **SP 32 trở lên** | 4 reference `CrystalDecisions.*` | Có |

Không cần cài driver cơ sở dữ liệu riêng: project dùng `System.Data.SqlClient`, nằm sẵn trong .NET Framework.

> **Không dùng Crystal Reports 9.2.** Bản 9.2 ra năm 2003, assembly build cho .NET Framework 1.0/1.1, không load được vào project .NET 4.7.2 này; phần tích hợp designer của nó cũng chỉ viết cho Visual Studio .NET 2002/2003. Phiên bản đầu tiên tích hợp được vào VS 2022 (ứng dụng 64-bit) là **CR for VS Service Pack 32**.
>
> Nếu môn học bắt buộc file `.rpt` phải tạo bằng designer 9.2: định dạng `.rpt` tương thích xuôi, nên vẫn vẽ được ở 9.2 rồi để runtime SP 32+ `Load()` file đó. Riêng bước chọn nguồn dữ liệu ADO.NET (XML) cần kiểm tra lại, vì hỗ trợ .NET của CR 9 còn sơ khai.

> **Chú ý về bitness.** File `.csproj` không khai báo `PlatformTarget`, nên mặc định AnyCPU + Prefer32Bit, tức app chạy **32-bit**. Nhưng runtime 32-bit của Crystal đã ngừng phát hành từ tháng 12/2025 — SP 39 là bản cuối còn cả x86 và x64, SP 40 chỉ còn x64. Chọn một trong hai:
>
> - Cài **SP 39 bản x86**, giữ nguyên project.
> - Cài **SP 40 x64**, rồi vào Project Properties → Build, bỏ tick `Prefer 32-bit`.
>
> Lệch bitness thì build qua nhưng lúc chạy báo `Could not load file or assembly 'CrystalDecisions...'`. Kiểm tra lại bitness của từng SP trên trang tải của SAP trước khi cài.

---

## 2. Dựng cơ sở dữ liệu

1. Mở **SQL Server Management Studio (SSMS)**, kết nối tới server của bạn.
2. File → Open → File, chọn `student_db.sql` ở thư mục gốc repo.
3. Bấm **Execute (F5)**. Script tự `CREATE DATABASE studentdb` nếu chưa có, nên không cần tạo trước.
4. Kiểm tra: database `studentdb` phải có **14 bảng** — `student`, `teacher`, `class`, `student_class`, `course`, `department`, `room`, `semester`, `schedule`, `score`, `diem_chitiet`, `attendance`, `tuition`, `login`.

Script chạy lại nhiều lần không sao: mỗi khối `INSERT` đều có kiểm tra bảng đã có dữ liệu chưa.

**Tài khoản đăng nhập có sẵn:**

| Tên đăng nhập | Mật khẩu | Vai trò |
|---|---|---|
| `admin` | `admin123` | Admin |
| `giaovien` | `123456` | Giáo viên |
| `vanphong` | `123456` | Văn phòng |

### Chuỗi kết nối

Khai báo trong `BTN_NHÓM4_QLDIEMTHPT/DBconnect.cs` — **đây là nơi duy nhất**, sửa chỗ này là xong, không phải sửa chỗ nào khác:

```csharp
Data Source=localhost;Initial Catalog=studentdb;Integrated Security=True
```

Các biến thể thường gặp:

| Trường hợp | Chuỗi kết nối |
|---|---|
| Named instance (SQLEXPRESS) | `Data Source=.\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True` |
| Đăng nhập bằng tài khoản SQL | `Data Source=localhost;Initial Catalog=studentdb;User ID=sa;Password=matkhau` |
| LocalDB đi kèm Visual Studio | `Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=studentdb;Integrated Security=True` |

---

## 3. Build project

1. Mở `BTN_NHÓM4_QLDIEMTHPT.sln` bằng Visual Studio 2022.
2. Build → Rebuild Solution.
3. Nếu báo thiếu `CrystalDecisions.*` → chưa cài mục 3 ở trên.

---

## 4. Crystal Report — tạo file `BaoCaoDiem.rpt`

**File `BaoCaoDiem.rpt` chưa có trong repo và phải tự tạo bằng designer của Visual Studio.** Repo chỉ có `BaoCaoDiem.xsd` (schema của dataset, dùng làm nguồn dữ liệu khi thiết kế).

Trước khi tạo, chương trình vẫn chạy bình thường — chỉ khi bấm nút **Báo cáo** ở form Tra cứu thống kê thì hiện hộp thoại "Chưa có file BaoCaoDiem.rpt" rồi đóng form lại, không crash.

### Bản vẽ layout chi tiết

Bản vẽ đầy đủ — toạ độ từng cột, chiều cao từng band, 5 tham số, 4 formula field, thứ tự thao tác và các cạm bẫy:

**https://claude.ai/artifact/GNbv2TTx3RTkqV5DwppbYj**

### Tóm tắt những gì phải khớp

Report lấy dữ liệu qua `report.SetDataSource(duLieu)` trong `FrmBaoCao.cs`, với `duLieu` là `DataTable` trả về từ `ThongKeClass.layDuLieuBaoCao()`. Vì vậy:

- **Nguồn dữ liệu trong designer phải là `BaoCaoDiem.xsd`** (Database Expert → Create New Connection → ADO.NET (XML)). **Không** nối report trực tiếp vào SQL Server, nếu không Crystal sẽ giữ connection riêng và đòi đăng nhập database khi chạy.
- **Tên bảng trong report phải là `BaoCaoDiem`**, vì code đặt `table.TableName = "BaoCaoDiem"`. Lệch tên thì `SetDataSource` vẫn chạy nhưng report ra trắng, không báo lỗi.

Bảy field, tên đã đối chiếu khớp giữa SQL và xsd:

| Field | Kiểu | Nguồn trong `SELECT_CHITIET` |
|---|---|---|
| `StudentId` | int | `score.StudentId` |
| `HoTen` | string | `CONCAT(StdLastName,' ',StdFirstName)` |
| `Lop` | string | `ISNULL(class.ClassName,N'Chưa xếp lớp')` |
| `MonHoc` | string | `score.CourseName` |
| `DiemTB` | double | `score.Score` |
| `HocLuc` | string | `score.Description` |
| `SoDauDiem` | int | `COUNT(*)` từ `diem_chitiet` |

Năm tham số, **tất cả kiểu String** (kể cả `NgayIn`, vì code truyền vào chuỗi đã format sẵn):

`TenLop` · `TenMon` · `HocLuc` · `KhoangDiem` · `NgayIn`

> Hàm `datThamSo()` trong `FrmBaoCao.cs` bỏ qua im lặng tham số không tìm thấy trong report. Gõ sai tên thì không có lỗi nào hiện ra, chỉ là tiêu đề để trống — rất khó phát hiện.

### Đặt file đúng chỗ

Hàm `timFileReport()` tìm `BaoCaoDiem.rpt` theo thứ tự:

1. Cạnh file `.exe` (tức `bin\Debug\`)
2. `..\..\BaoCaoDiem.rpt` — từ `bin\Debug` thì đây chính là thư mục project

Nên chỉ cần file `.rpt` nằm trong thư mục project là chạy được. Muốn chắc hơn thì chọn file trong Solution Explorer → Properties → `Copy to Output Directory` = **Copy always**.

> Đừng thêm `<None Include="BaoCaoDiem.rpt">` vào `.csproj` bằng tay khi file chưa tồn tại — build sẽ fail ở task Copy. Để Visual Studio tự ghi mục đó khi bạn đặt property.

---

## 5. Chạy thử

1. F5.
2. Đăng nhập `admin` / `admin123`.
3. Menu → Tra cứu thống kê → chọn lớp, môn, khoảng điểm → **Tra cứu** để xem dữ liệu trên lưới.
4. Bấm **Báo cáo** để mở Crystal Report với đúng điều kiện lọc vừa chọn.

---

## 6. Lỗi thường gặp

| Hiện tượng | Nguyên nhân |
|---|---|
| "Không kết nối được cơ sở dữ liệu studentdb" | SQL Server chưa chạy, tên instance sai, hoặc chưa chạy script tạo CSDL |
| `A network-related or instance-specific error` | Sai `Data Source`. Thử `.\SQLEXPRESS` hoặc `(localdb)\MSSQLLocalDB` |
| `Login failed for user` | Dùng Windows Authentication nhưng account Windows chưa được cấp quyền trên SQL Server, hoặc sai mật khẩu `sa` |
| Build lỗi thiếu `CrystalDecisions.*` | Chưa cài SAP Crystal Reports for Visual Studio |
| `Could not load file or assembly 'CrystalDecisions...'` lúc chạy | Bitness của runtime lệch với app, hoặc đang dùng Crystal 9.2 — xem mục 1 |
| Crystal không xuất hiện trong menu Add New Item của VS 2022 | Cài SP 31 trở xuống, cần SP 32+ |
| "Chưa có file BaoCaoDiem.rpt" | Chưa tạo report, xem mục 4 |
| Report mở ra nhưng trắng, chỉ có tiêu đề | Tên bảng trong report không phải `BaoCaoDiem` |
| Report mở ra nhưng tiêu đề trống | Tên tham số trong report gõ sai |
| Crystal đòi đăng nhập database khi chạy | Report nối trực tiếp vào SQL Server thay vì qua `BaoCaoDiem.xsd` |
| Chữ tiếng Việt hiện thành dấu hỏi | Cột đang là `VARCHAR` thay vì `NVARCHAR`, hoặc câu SQL thiếu tiền tố `N` trước chuỗi |

---

## 7. Ghi chú về cấu trúc code

Kiến trúc 2 lớp:

- `DuLieuClass.cs` — lớp cơ sở, gom `getList()` / `run()` / `tinhMotGiaTri()`. Mọi lớp nghiệp vụ kế thừa từ đây.
- `*Class.cs` — một lớp cho mỗi bảng (`HocSinhClass`, `GiaoVienClass`, `ThongKeClass`...).
- `Frm*.cs` — 15 form, treo dưới `FrmMain`.
- `DBconnect.cs` — nơi duy nhất khai báo chuỗi kết nối.
- `DGVPrinter.cs` — thư viện in `DataGridView` của bên thứ ba, dùng ở `FrmTraCuuThongKe`.

Luồng khởi động: `Program.cs` → `FrmLogin` → kiểm tra bảng `login` → truyền `HoTen` + `VaiTro` sang `FrmMain`.

> **Điểm có thể bị trừ điểm:** mật khẩu trong bảng `login` lưu dạng plaintext, `LoginClass.kiemTraDangNhap()` so sánh trực tiếp `MatKhau=@p` chứ không hash. Các câu truy vấn đều đã dùng parameter nên không bị SQL injection, chỉ riêng chỗ lưu mật khẩu là chưa an toàn.

---

## 8. Những gì đã đổi khi chuyển từ MySQL sang SQL Server

31 file `.cs` đã được sửa. `DGVPrinter.cs` không bị ảnh hưởng vì không chứa code truy cập CSDL.

### Trong code C#

| MySQL | SQL Server |
|---|---|
| `using MySql.Data.MySqlClient;` | `using System.Data.SqlClient;` |
| `MySqlCommand`, `MySqlConnection`, `MySqlDataAdapter`, `MySqlException` | `SqlCommand`, `SqlConnection`, `SqlDataAdapter`, `SqlException` |
| `MySqlDbType.Int32` | `SqlDbType.Int` |
| `MySqlDbType.VarChar` | `SqlDbType.NVarChar` |
| `MySqlDbType.Double` | `SqlDbType.Float` |
| `MySqlDbType.Blob` | `SqlDbType.VarBinary` |
| `MySqlDbType.Date` / `.Time` | `SqlDbType.Date` / `.Time` |
| `command.LastInsertedId` | `SELECT CAST(SCOPE_IDENTITY() AS INT)` + `ExecuteScalar()` |

### Trong câu SQL

| MySQL | SQL Server |
|---|---|
| `` `tên` `` | `[tên]` |
| `IFNULL(...)` | `ISNULL(...)` |
| `'chuỗi tiếng Việt'` | `N'chuỗi tiếng Việt'` |
| `CONCAT(...)` | giữ nguyên (SQL Server 2012+ có `CONCAT`) |

### Trong file SQL tạo CSDL

File tạo CSDL: `student_db.sql`. Bản MySQL gốc chỉ còn trong thư mục backup.

| MySQL | SQL Server |
|---|---|
| `AUTO_INCREMENT` | `IDENTITY(1,1)` |
| `VARCHAR(n)` | `NVARCHAR(n)` |
| `DOUBLE` | `FLOAT` |
| `LONGBLOB` | `VARBINARY(MAX)` |
| `X'89504E...'` | `0x89504E...` |
| `CREATE TABLE IF NOT EXISTS` | `IF OBJECT_ID('x','U') IS NULL CREATE TABLE` |
| `INSERT IGNORE` | `IF NOT EXISTS (...)` + `SET IDENTITY_INSERT ON/OFF` |
| `SET @photo = ...` | `DECLARE @photo VARBINARY(MAX) = ...` |

### Một khác biệt về ràng buộc cần biết

Ở bản MySQL, bảng `diem_chitiet` có khoá ngoại tới `course(CourseName)` với `ON UPDATE CASCADE ON DELETE CASCADE`. SQL Server không cho phép nhiều đường cascade cùng dẫn tới một bảng, nên khoá ngoại này **chỉ còn `ON UPDATE CASCADE`**.

Hệ quả: xoá một môn học trong bảng `course` sẽ không tự xoá các đầu điểm của môn đó trong `diem_chitiet` — SQL Server sẽ báo lỗi ràng buộc. Muốn xoá môn học thì xoá đầu điểm của nó trước. Đổi tên môn học vẫn cascade bình thường như cũ.
