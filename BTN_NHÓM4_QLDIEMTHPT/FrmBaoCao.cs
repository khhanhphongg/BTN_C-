using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace QLDiemTHPT
{
    /*
     * Form xem và in báo cáo bằng Crystal Report.
     *
     * Dữ liệu được nạp từ ThongKeClass.layDuLieuBaoCao() rồi đưa vào report
     * bằng SetDataSource, nên report không cần tự kết nối MySQL.
     *
     * File BaoCaoDiem.rpt phải được tạo trong Visual Studio (xem HUONG_DAN.md),
     * thiết kế dựa trên lược đồ BaoCaoDiem.xsd để tên cột khớp với DataTable.
     */
    public partial class FrmBaoCao : Form
    {
        ThongKeClass thongKe = new ThongKeClass();

        //các điều kiện lọc nhận từ form tra cứu
        int maLop;
        string tenLop;
        string tenMon;
        string hocLuc;
        double tuDiem;
        double denDiem;

        public FrmBaoCao(int maLop, string tenLop, string tenMon, string hocLuc, double tuDiem, double denDiem)
        {
            InitializeComponent();
            this.maLop = maLop;
            this.tenLop = tenLop;
            this.tenMon = tenMon;
            this.hocLuc = hocLuc;
            this.tuDiem = tuDiem;
            this.denDiem = denDiem;
            this.Text = "Báo cáo bảng điểm - " + tenLop;
        }

        private void FrmBaoCao_Load(object sender, EventArgs e)
        {
            try
            {
                //lấy dữ liệu theo đúng điều kiện lọc của form tra cứu
                DataTable duLieu = thongKe.layDuLieuBaoCao(maLop, tenMon, hocLuc, tuDiem, denDiem);
                if (duLieu.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nào khớp với điều kiện đã chọn", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                //tìm file report, ưu tiên bản nằm cạnh file chạy, không có thì lấy trong thư mục project
                string duongDan = timFileReport("BaoCaoDiem.rpt");
                if (duongDan == "")
                {
                    MessageBox.Show("Chưa có file BaoCaoDiem.rpt." + Environment.NewLine + Environment.NewLine +
                        "Hãy tạo report trong Visual Studio theo hướng dẫn ở file HUONG_DAN.md (mục Crystal Report), " +
                        "rồi để thuộc tính Copy to Output Directory của file .rpt là Copy always.",
                        "Thiếu file báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                ReportDocument report = new ReportDocument();
                report.Load(duongDan);
                report.SetDataSource(duLieu);

                //đưa các tham số tiêu đề vào report, bỏ qua nếu report chưa khai báo tham số
                datThamSo(report, "TenLop", tenLop);
                datThamSo(report, "TenMon", tenMon);
                datThamSo(report, "HocLuc", hocLuc);
                datThamSo(report, "KhoangDiem", tuDiem.ToString("0.0") + " - " + denDiem.ToString("0.0"));
                datThamSo(report, "NgayIn", DateTime.Now.ToString("dd/MM/yyyy"));

                crystalReportViewer_bc.ReportSource = report;
                crystalReportViewer_bc.Zoom(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được báo cáo." + Environment.NewLine + Environment.NewLine + ex.Message,
                    "Lỗi báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //hàm tìm file .rpt ở các vị trí thường gặp
        private string timFileReport(string tenFile)
        {
            string thuMucChay = Application.StartupPath;
            string[] cacNoi = {
                Path.Combine(thuMucChay, tenFile),
                Path.Combine(thuMucChay, @"..\..\" + tenFile),
                Path.Combine(thuMucChay, @"..\..\..\" + tenFile)
            };
            foreach (string noi in cacNoi)
            {
                if (File.Exists(noi))
                    return Path.GetFullPath(noi);
            }
            return "";
        }

        //hàm đặt một tham số cho report, report chưa có tham số đó thì bỏ qua
        private void datThamSo(ReportDocument report, string ten, string giaTri)
        {
            try
            {
                foreach (ParameterFieldDefinition thamSo in report.DataDefinition.ParameterFields)
                {
                    if (thamSo.ParameterFieldName == ten)
                    {
                        report.SetParameterValue(ten, giaTri);
                        return;
                    }
                }
            }
            catch
            {
                //report không khai báo tham số này thì không cần làm gì
            }
        }
    }
}
