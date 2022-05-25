using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using Coffee.Reports;
using Coffee.Utils;
using Coffee.DataSet;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraReports.UI;

namespace Coffee.Reports
{
    public partial class frm_ViewPlanDay : DevExpress.XtraEditors.XtraForm
    {
        public bool _checkEndPlanDay;
        private mycoffeeEntities _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
        private DataSet_ViewPlanDay ds = new DataSet_ViewPlanDay();
        XtraReport_ViewPlanDay report_PDF = new XtraReport_ViewPlanDay();

        // Đối tượng timer đóng ứng dụng
        private System.Threading.Timer _timerCloseApp = null;
        //Show Sologan
        DevExpress.Utils.WaitDialogForm dlg_sologan = null;

        public frm_ViewPlanDay()
        {
            InitializeComponent();
        }

        private void frm_ViewPlanDay_Load(object sender, EventArgs e)
        {
           
            try
            {
                SetReportSource();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_ViewPlanDay_Load");
            }
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            try
            {
                report_PDF.RequestParameters = false;
                report_PDF.PrinterName = "Báo cáo chi tiết doanh thu";
                report_PDF.PrintDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Print_Click");
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (_checkEndPlanDay == true)
                {
                    XtraMessageBox.Show("Không thể kết thúc. Còn bàn chưa thanh toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn kết thúc kế hoạch này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Stop_Click");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Close_Click");
            }
        }

        private void SetReportSource()
        {
            DataSet_ViewPlanDay.DataTable_PlanDayRow row;
            List<money_trading> moneys;
            company companys;

            try
            {
                string[] drives = System.IO.Directory.GetLogicalDrives();
                //--- Trừ ổ đĩa hệ thống
                if (drives != null)
                {
                    textEdit_PathFile.Text = drives[1].ToString();
                }

                moneys = (from mn in _dbContext.money_trading select mn).ToList();

                companys = (from cp in _dbContext.companies select cp).FirstOrDefault();

                DateTime date = DateTime.Now;
                decimal planMoney=0;
                decimal totalMoney=0;
                if (moneys != null && moneys.Count > 0)
                {
                    date = moneys.FirstOrDefault().StartDate;
                    planMoney = moneys.FirstOrDefault().TotalMoney;

                    int i = 1;
                    foreach (money_trading money in moneys)
                    {
                        row = ds.DataTable_PlanDay.NewDataTable_PlanDayRow();
                        row.ID = i;
                        row.EmployeeID = money.EmployeeID.ToString();
                        row.EmployeeName_Create = money.employee.EmployeeName + "(" + money.EmployeeID + ")"; ;
                        row.StartDate = money.StartDate.ToString("dd/MM HH:mm");
                        row.EmloyeeName_Receive = money.ReceiveByEmployeeName + "(" + money.ReceiveByEmployeeID + ")";
                        row.ReceiveDate = money.ReceiveDate.Value.ToString("dd/MM HH:mm");
                        row.DefaultMoney = money.TotalMoney;
                        row.TotalMoney = money.MoneyCredit;

                        ds.DataTable_PlanDay.AddDataTable_PlanDayRow(row);

                        totalMoney = money.MoneyCredit;

                        i++;
                    }
                }
                else
                {
                    ds = null;
                }

                decimal Money = totalMoney - planMoney;
                XtraReport_ViewPlanDay report = new XtraReport_ViewPlanDay();
                report.RequestParameters = false;
                report.Parameters["parameter_ExportDate"].Value = "........, Ngày " + DateTime.Now.Day + ", tháng " + DateTime.Now.Month + ", năm " + DateTime.Now.Year;
                report.Parameters["parameter_Today"].Value = "Ngày: " + date.ToString("dd/MM/yyyy");
                report.Parameters["parameter_PlanMoney"].Value = planMoney;
                report.Parameters["parameter_Money"].Value = Money;
                report.Parameters["parameter_TotalMoney"].Value = totalMoney;
                report.Parameters["parameter_EmployeeLogin"].Value = CoffeeHelpers.EmpLogin.EmployeeName;
                report.Parameters["parameter_CompanyName"].Value = companys.CompanyName;
                report.Parameters["parameter_AddressCompany"].Value = companys.Address;

                report.DataSource = ds;
                report.CreateDocument();

                printControl_ViewPlanDay.ShowPageMargins = false;
                printControl_ViewPlanDay.PrintingSystem = report.PrintingSystem;

                report_PDF = report;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SetReportSource");
            }
        }

        public void SetReportSource_SendToEmail(string Path_FileName)
        {
            DataSet_ViewPlanDay.DataTable_PlanDayRow row;
            List<money_trading> moneys;
            company companys;

            try
            {
                string[] drives = System.IO.Directory.GetLogicalDrives();
                //--- Trừ ổ đĩa hệ thống
                if (drives != null)
                {
                    textEdit_PathFile.Text = drives[1].ToString();
                }

                moneys = (from mn in _dbContext.money_trading select mn).ToList();
                companys = (from cp in _dbContext.companies select cp).FirstOrDefault();

                DateTime date = DateTime.Now;
                decimal planMoney = 0;
                decimal totalMoney = 0;
                if (moneys != null && moneys.Count > 0)
                {
                    date = moneys.FirstOrDefault().StartDate;
                    planMoney = moneys.FirstOrDefault().TotalMoney;

                    int i = 1;
                    foreach (money_trading money in moneys)
                    {
                        row = ds.DataTable_PlanDay.NewDataTable_PlanDayRow();
                        row.ID = i;
                        row.EmployeeID = money.EmployeeID.ToString();
                        row.EmployeeName_Create = money.employee.EmployeeName + "(" + money.EmployeeID + ")"; ;
                        row.StartDate = money.StartDate.ToString("dd/MM HH:mm");
                        row.EmloyeeName_Receive = money.ReceiveByEmployeeName + "(" + money.ReceiveByEmployeeID + ")";
                        row.ReceiveDate = money.ReceiveDate.Value.ToString("dd/MM HH:mm");
                        row.DefaultMoney = money.TotalMoney;
                        row.TotalMoney = money.MoneyCredit;

                        ds.DataTable_PlanDay.AddDataTable_PlanDayRow(row);

                        totalMoney = money.MoneyCredit;

                        i++;
                    }
                }
                else
                {
                    ds = null;
                }

                decimal Money = totalMoney - planMoney;
                XtraReport_ViewPlanDay report = new XtraReport_ViewPlanDay();
                report.RequestParameters = false;
                report.Parameters["parameter_ExportDate"].Value = "........, Ngày " + DateTime.Now.Day + ", tháng " + DateTime.Now.Month + ", năm " + DateTime.Now.Year;
                report.Parameters["parameter_Today"].Value = "Ngày: " + date.ToString("dd/MM/yyyy");
                report.Parameters["parameter_PlanMoney"].Value = planMoney;
                report.Parameters["parameter_Money"].Value = Money;
                report.Parameters["parameter_TotalMoney"].Value = totalMoney;
                report.Parameters["parameter_EmployeeLogin"].Value = CoffeeHelpers.EmpLogin.EmployeeName;
                report.Parameters["parameter_CompanyName"].Value = companys.CompanyName;
                report.Parameters["parameter_AddressCompany"].Value = companys.Address;

                report.DataSource = ds;
                report.ExportToPdf(Path_FileName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SetReportSource_SendToEmail");
            }
        }

        private void btn_BrowserFilePath_Click(object sender, EventArgs e)
        {
            string folderpath = "";
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult dr = fbd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    folderpath = fbd.SelectedPath;
                }
                if (folderpath != "")
                {
                    textEdit_PathFile.Text = folderpath;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "simpleButton_BrowserPathFile_Click");
            }
        }

        private void btnreport_ExportFile_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = "Doanh_thu_" + DateTime.Now.ToString("dd-MM-yyyy");
                report_PDF.ExportToPdf(textEdit_PathFile.Text.Trim() + "\\" + fileName + ".pdf");

                dlg_sologan = new DevExpress.Utils.WaitDialogForm("Đang xuất file", "Vui lòng chờ...", new Size(165, 50));
                _timerCloseApp = new System.Threading.Timer(TimerCloseAppCallback, null, 1000, System.Threading.Timeout.Infinite);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btnreport_ExportFile_Click");
            }
        }

        private void TimerCloseAppCallback(object state)
        {
            try
            {
                this.BeginInvoke(new Action(() => { dlg_sologan.Close(); _timerCloseApp = null; }));
            }
            catch (Exception ex)
            {
                // Xuất ra file log
                //log.Error("Hàm TimerCloseAppCallback đã phát ra Exception ", ex.Message);
            }
        }        
    }
}
