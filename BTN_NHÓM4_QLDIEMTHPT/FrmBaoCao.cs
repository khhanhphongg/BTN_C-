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
    public partial class FrmBaoCao : Form
    {
        ThongKeClass thongKe = new ThongKeClass();

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
                DataTable duLieu = thongKe.layDuLieuBaoCao(maLop, tenMon, hocLuc, tuDiem, denDiem);
                if (duLieu.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nào khớp với điều kiện đã chọn", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

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

        private string timFileReport(string tenFile)
        {
            string duongDan = Path.Combine(Application.StartupPath, tenFile);
            if (File.Exists(duongDan))
                return duongDan;
            duongDan = Path.Combine(Application.StartupPath, @"..\..\" + tenFile);
            if (File.Exists(duongDan))
                return duongDan;
            return "";
        }

        private void datThamSo(ReportDocument report, string ten, string giaTri)
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
    }
}
