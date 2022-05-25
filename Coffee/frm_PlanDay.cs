using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Coffee.Utils;
using System.Linq;
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_PlanDay : DevExpress.XtraEditors.XtraForm
    {
        private mycoffeeEntities _dbContext;
        public money_trading P_PlanDay { get; set; }

        private const string _cEmployeeID = "EmployeeID";
        private const string _cEmployeeName = "EmployeeName";
        private const string _cMoneyCredit = "MoneyCredit";

        public frm_PlanDay()
        {
            InitializeComponent();
        }

        private void frm_PlanDay_Load(object sender, EventArgs e)
        {
            try
            {
                Load_CreditOfEmployee();

                if (P_PlanDay.TotalMoney == 0)
                {
                    lbl_AddMoney.Visible = false;
                    textEdit_AddMoneyPlan.Visible = false;
                    this.Height = this.Height - 40;
                }
                else
                {
                    textEdit_MoneyPlan.EditValue = string.Format("{0:#,#}", P_PlanDay.TotalMoney);
                    textEdit_AddMoneyPlan.EditValue = 0;

                    textEdit_MoneyPlan.Properties.ReadOnly = true;
                    lbl_AddMoney.Visible = true;
                    textEdit_AddMoneyPlan.Visible = true;  
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_PlanDay_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (P_PlanDay.TotalMoney == 0)
                {
                    P_PlanDay.TotalMoney = Convert.ToDecimal(textEdit_MoneyPlan.EditValue);
                    P_PlanDay.MoneyCredit = Convert.ToDecimal(textEdit_MoneyPlan.EditValue);
                    P_PlanDay.EmployeeID = CoffeeHelpers.EmpLogin.EmployeeID;//Nhâ viên tạo ca(Quản lý)
                    P_PlanDay.ReceiveByEmployeeName = CoffeeHelpers.EmpLogin.EmployeeName;//Nhận viên nhận(Quản lý)
                    P_PlanDay.StartDate = DateTime.Now;

                    lbl_AddMoney.Visible = false;
                    textEdit_AddMoneyPlan.Visible = false;
                }
                else
                {
                    P_PlanDay.MoneyCredit = Convert.ToDecimal(textEdit_AddMoneyPlan.EditValue);
                    P_PlanDay.Notes = "\nCộng thêm " + Convert.ToDecimal(textEdit_AddMoneyPlan.EditValue) + " vào ngân quỹ bởi " + CoffeeHelpers.EmpLogin.EmployeeName + " vào lúc " + DateTime.Now;

                    lbl_AddMoney.Visible = true;
                    textEdit_AddMoneyPlan.Visible = true;
                    textEdit_AddMoneyPlan.EditValue = 0;
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Save_Click");
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Close_Click");
            }
        }

        //Load thông tin doanh thu của từng nhân viên
        private void Load_CreditOfEmployee()
        {
            DataTable tbsource;
            List<money_trading> moneyTradings;
            DataRow newRow;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                moneyTradings = (from mn in _dbContext.money_trading.ToList() select mn).ToList();
                if (moneyTradings != null && moneyTradings.Count > 0)
                {
                    tbsource = new DataTable();
                    tbsource.Columns.Add(_cEmployeeID);
                    tbsource.Columns.Add(_cEmployeeName);
                    tbsource.Columns.Add(_cMoneyCredit);

                    foreach (money_trading item in moneyTradings)
                    {
                        newRow = tbsource.NewRow();
                        newRow[_cEmployeeID] = item.EmployeeID;
                        newRow[_cEmployeeName] = item.employee.EmployeeName;
                        newRow[_cMoneyCredit] = string.Format("{0:#,#}", item.MoneyCredit);

                        tbsource.Rows.Add(newRow);
                    }

                    slookUpEdit_MoneyPlanDetail.Properties.DataSource = tbsource;
                    slookUpEdit_MoneyPlanDetail.Text = "Xem lịch sử";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Load_CreditOfEmployee");
            }
        }

        // Di chuyển form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelControl3_MouseDown(object sender, MouseEventArgs e)
        {
             try
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "panelControl3_MouseDown");
            }
        }

    }
}