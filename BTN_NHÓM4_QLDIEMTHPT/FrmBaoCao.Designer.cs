namespace QLDiemTHPT
{
    partial class FrmBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.crystalReportViewer_bc = new CrystalDecisions.Windows.Forms.CrystalReportViewer();

            this.SuspendLayout();
            // 
            // crystalReportViewer_bc
            // 
            this.crystalReportViewer_bc.ActiveViewIndex = -1;
            this.crystalReportViewer_bc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer_bc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer_bc.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer_bc.Name = "crystalReportViewer_bc";
            this.crystalReportViewer_bc.Size = new System.Drawing.Size(1000, 680);
            this.crystalReportViewer_bc.TabIndex = 0;
            this.crystalReportViewer_bc.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Controls.Add(this.crystalReportViewer_bc);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmBaoCao";
            this.Text = "FrmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBaoCao_Load);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer_bc;
    }
}
