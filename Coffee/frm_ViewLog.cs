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
    public partial class frm_ViewLog : DevExpress.XtraEditors.XtraForm
    {
        private string connectionString;

        public string ConnectionString
        {
            set { connectionString = value; }
        }
        public employee EmployeeLogin { get; set; }

        public frm_ViewLog()
        {
            //DevExpress.Skins.SkinManager.EnableFormSkins();
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Lilian";
            InitializeComponent();
        }

        private void frm_ViewLog_Load(object sender, EventArgs e)
        {
            try
            {
                //dataGridView1.AutoGenerateColumns = false;
                DateTime now = DateTime.Now;
                dateTimePicker_BeginTime.Value = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0);
                dateTimePicker_EndTime.Value = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);
                LoadEmployee();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ViewLog_Load");
            }
        }

        private void LoadEmployee()
        {
            try
            {
                mycoffeeEntities db = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var logs = db.logs.Select(l => new { EmployeeName = l.employeename }).Distinct();

                comboBox_Employee.Items.Add("--- Tất cả ---");
                foreach (var item in logs)
                {
                    comboBox_Employee.Items.Add(item.EmployeeName);
                }
                comboBox_Employee.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadEmployee");
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker_BeginTime.Value > dateTimePicker_EndTime.Value)
                {
                    XtraMessageBox.Show("Vui lòng chọn từ ngày phải nhỏ hơn đến ngày.", "MapView", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                mycoffeeEntities db = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var logs = (from lg in db.logs.ToList()
                            where lg.actiondate >= dateTimePicker_BeginTime.Value && lg.actiondate <= dateTimePicker_EndTime.Value
                            select lg).ToList();

                if (comboBox_Employee.Text != "--- Tất cả ---")
                {
                    logs = (from lg in db.logs.ToList()
                            where lg.employeename == comboBox_Employee.Text
                            select lg).ToList();
                }

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    logs = (from lg in db.logs.ToList()
                            where lg.actions.Contains(textBox1.Text.Trim())
                            select lg).ToList();
                }

                DataTable tbSource = new DataTable();
                tbSource.Columns.Add("Time");
                tbSource.Columns.Add("Employee");
                tbSource.Columns.Add("Action");

                DataRow row;
                if (logs != null && logs.Count > 0)
                {
                    foreach(log lg in logs)
                    {
                        row = tbSource.NewRow();
                        row["Time"] = lg.actiondate;
                        row["Employee"] = lg.employeename;
                        row["Action"] = lg.actions;

                        tbSource.Rows.Add(row);
                    }
                }

                gridControl_ViewLog.DataSource = tbSource;

                if (logs.Count() == 0)
                {
                    gridControl_ViewLog.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "bnt_Refresh_Click");
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                //ReportData.DataSet_MyLog ds = new ReportData.DataSet_MyLog();
                //ReportData.DataSet_MyLog.MyLogRow row;
                //IQueryable<MyLog> logs = dataGridView1.DataSource as IQueryable<MyLog>;
                //if (logs == null) return;
                //foreach (MyLog item in logs)
                //{
                //    row = ds.MyLog.NewMyLogRow();
                //    row.EmployeeName = item.EmployeeName;
                //    row.ActionDate = item.ActionDate;
                //    row.Actions = item.Actions;
                //    ds.MyLog.AddMyLogRow(row);
                //}

                //ReportData.frmViewLog dlg = new ReportData.frmViewLog();
                //dlg.BTime = dateTimePicker_BeginTime.Value;
                //dlg.ETime = dateTimePicker_EndTime.Value;
                //dlg.EmployeeLogin = EmployeeLogin;
                //dlg.ds = ds;
                //dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Print_Click");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker_BeginTime.Value > dateTimePicker_EndTime.Value)
                {
                    XtraMessageBox.Show("Vui lòng chọn từ ngày phải nhỏ hơn đến ngày.", "MapView", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                mycoffeeEntities db = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var logs = (from lg in db.logs.ToList()
                            where lg.actiondate >= dateTimePicker_BeginTime.Value && lg.actiondate <= dateTimePicker_EndTime.Value
                            select lg).ToList();

                if (comboBox_Employee.Text != "--- Tất cả ---")
                {
                    logs = (from lg in db.logs.ToList()
                            where lg.employeename == comboBox_Employee.Text
                            select lg).ToList();
                }

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    logs = (from lg in db.logs.ToList()
                            where lg.actions.Contains(textBox1.Text.Trim())
                            select lg).ToList();
                }

                DataTable tbSource = new DataTable();
                tbSource.Columns.Add("Time");
                tbSource.Columns.Add("Employee");
                tbSource.Columns.Add("Action");

                DataRow row;
                if (logs != null && logs.Count > 0)
                {
                    foreach (log lg in logs)
                    {
                        row = tbSource.NewRow();
                        row["Time"] = lg.actiondate;
                        row["Employee"] = lg.employeename;
                        row["Action"] = lg.actions;

                        tbSource.Rows.Add(row);
                    }
                }

                gridControl_ViewLog.DataSource = tbSource;

                if (logs.Count() == 0)
                {
                    gridControl_ViewLog.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textBox1_TextChanged");
            }
        }
    }
}