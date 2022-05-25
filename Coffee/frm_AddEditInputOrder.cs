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

namespace Coffee
{
    public partial class frm_AddEditInputOrder : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        public listorder P_ListOrder { get; set; }
        public bool _Add { get; set; }
        public int _employeeID { get; set; }
        public DateTime _Date { get; set; }

        private mycoffeeEntities _dbContext;
        private DateTime dtBegin = DateTime.Now;
        #endregion

        #region Form Method
        public frm_AddEditInputOrder()
        {
            InitializeComponent();
        }

        private void frm_AddEditInputOrder_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime dtNow = DateTime.Now;
                dtBegin = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                dateEdit_OrderDate.DateTime = dtBegin;

                //Danh sách nhân viên
                LoadEmployees();

                dateEdit_OrderDate.DateTime = _Date;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditInputOrder_Load");
            }
        }
        #endregion

        #region Helpers

        /// <summary>
        /// Load danh sách nhân viên
        /// </summary>
        private void LoadEmployees()
        {
            DataRow row;
            List<employee> employees;
            DataTable _tbSource;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                _tbSource = new DataTable();
                _tbSource.Columns.Add("EmployeeID");
                _tbSource.Columns.Add("EmployeeName");

                employees = (from em in _dbContext.employees.ToList() where em.EmployeeRight != CoffeeHelpers.EmpRight.Administrator.ToString() select em).ToList();
                if (employees != null && employees.Count > 0)
                {
                    foreach (employee emp in employees)
                    {
                        row = _tbSource.NewRow();
                        row["EmployeeID"] = emp.EmployeeID;
                        row["EmployeeName"] = emp.EmployeeName;

                        _tbSource.Rows.Add(row);
                    }

                    row = _tbSource.NewRow();
                    row["EmployeeID"] = -1;
                    row["EmployeeName"] = "Chọn nhân viên...";
                    _tbSource.Rows.InsertAt(row, 0);

                    sLookUpEdit_Employee.Properties.DisplayMember = "EmployeeName";
                    sLookUpEdit_Employee.Properties.ValueMember = "EmployeeID";
                    sLookUpEdit_Employee.Properties.DataSource = _tbSource;
                    sLookUpEdit_Employee.EditValue = -1;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadEmployees");
            }
        }
        #endregion

        #region Actions
        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(sLookUpEdit_Employee.EditValue) == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(textEdit_TotalMoney.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng nhập tiền đã thanh toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _Date = dateEdit_OrderDate.DateTime;

                P_ListOrder.EmployeeID = Convert.ToInt32(sLookUpEdit_Employee.EditValue);
                P_ListOrder.StartDate = dateEdit_OrderDate.DateTime;
                P_ListOrder.Total_Money = Convert.ToDecimal(textEdit_TotalMoney.EditValue);

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
        #endregion
    }
}