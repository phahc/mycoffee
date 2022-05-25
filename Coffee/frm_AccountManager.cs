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
using DevExpress.XtraGrid.Views.Grid;
using TracerX;

namespace Coffee
{
    public partial class frm_AccountManager : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private static readonly TracerX.Logger log = Logger.GetLogger(typeof(frm_MainCoffee));

        private mycoffeeEntities _dbContext;
        //--- Datatable Source cho gridControl
        private DataTable _tbSource;

        #region ColumnName

        private const string _cEmployeeID = "EmployeeID";
        private const string _cEmployeeName = "EmployeeName";
        private const string _cEmployeeCode = "EmployeeCode";
        private const string _cEmployeeRight = "EmployeeRight";
        private const string _cReceiveDate = "ReceiveDate";
        private const string _cBirthDay = "BirthDay";
        private const string _cEmail = "Email";
        private const string _cPhone = "Phone";
        private const string _cAddress= "Address";
        private const string _cNotes = "Notes";
        private const string _cPassWord= "PassWord";
        private const string _cPlanWork = "PlanWork";
        private const string _cSex = "Sex";
        private const string _cSalary = "Salary";
        private const string _cLocked = "Locked";

        #endregion //--- ColumnName

        #endregion //--- Fields    

        #region Form Method
        public frm_AccountManager()
        {
            InitializeComponent();
        }

        private void frm_AccountManager_Load(object sender, EventArgs e)
        {
            DataRow newRow;
            
            try
            {
                //Trạng thái lOCKED
                LoadLockedStatus();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var listemployees = (from emp in _dbContext.employees.ToList()
                                where emp.EmployeeRight != CoffeeHelpers.EmpRight.Administrator.ToString()
                                orderby emp.EmployeeName
                                select new
                                {
                                    emp.EmployeeID,
                                    emp.EmployeeCode,
                                    emp.EmployeeName,
                                    EmployeeRight = emp.EmployeeRight == CoffeeHelpers.EmpRight.Operator.ToString() ? CoffeeHelpers.GetEmployeeRightTitle(CoffeeHelpers.EmpRight.Operator) : CoffeeHelpers.GetEmployeeRightTitle(CoffeeHelpers.EmpRight.SupAdmin),
                                    emp.Birthday,
                                    emp.EmployeeDate,
                                    emp.Email,
                                    emp.Telephone,
                                    emp.Address,
                                    emp.Notes,
                                    emp.planwork.PlanWorkName,
                                    emp.Sex,
                                    emp.Salary,
                                    emp.Locked
                                });

                _tbSource = new DataTable();

                _tbSource.Columns.Add(_cEmployeeID);
                _tbSource.Columns.Add(_cEmployeeName);
                _tbSource.Columns.Add(_cEmployeeCode);
                _tbSource.Columns.Add(_cEmployeeRight);
                _tbSource.Columns.Add(_cBirthDay);
                _tbSource.Columns.Add(_cReceiveDate);
                _tbSource.Columns.Add(_cEmail);
                _tbSource.Columns.Add(_cPhone);
                _tbSource.Columns.Add(_cAddress);
                _tbSource.Columns.Add(_cNotes);
                _tbSource.Columns.Add(_cPlanWork);
                _tbSource.Columns.Add(_cSex);
                _tbSource.Columns.Add(_cSalary);
                _tbSource.Columns.Add(_cLocked);

                if (listemployees != null && listemployees.Count() > 0)
                {
                    foreach (var emp in listemployees)
                    {
                        newRow = _tbSource.NewRow();
                        newRow[_cEmployeeID] = emp.EmployeeID;
                        newRow[_cEmployeeName] = emp.EmployeeName;
                        newRow[_cEmployeeCode] = emp.EmployeeCode;
                        newRow[_cEmployeeRight] = emp.EmployeeRight;
                        newRow[_cBirthDay] = emp.Birthday;
                        newRow[_cReceiveDate] = emp.EmployeeDate;
                        newRow[_cEmail] = emp.Email;
                        newRow[_cPhone] = emp.Telephone;
                        newRow[_cAddress] = emp.Address;
                        newRow[_cNotes] = emp.Notes;
                        newRow[_cPlanWork] = emp.PlanWorkName;
                        newRow[_cSex] = emp.Sex;
                        newRow[_cSalary] = emp.Salary;
                        newRow[_cLocked] = emp.Locked;

                        _tbSource.Rows.Add(newRow);
                    }
                }

                gridControl_Employee.DataSource = _tbSource;

                gridView_Employee.Columns[_cEmployeeName].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                if (CoffeeHelpers.EmpLogin.EmpRight == CoffeeHelpers.EmpRight.Operator) //--- Nếu là quyền người dùng
                {
                    barButtonItem_Add.Enabled = false;
                    barButtonItem_Update.Enabled = false;
                    barButtonItem_Delete.Enabled = false;
                    barButtonItem_ResetPassWord.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AccountManager_Load");
            }
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Load danh sách Products status
        /// </summary>
        private void LoadLockedStatus()
        {
            DataTable tbLocked;
            string cLockedID = "LockedID";
            string cLockedName = "LockedName";

            try
            {
                // Trạng thái sản phẩm
                tbLocked = new DataTable();
                tbLocked.Columns.Add(cLockedID);
                tbLocked.Columns.Add(cLockedName);

                tbLocked.Rows.Add(1, "Đang kích hoạt");
                tbLocked.Rows.Add(2, "Đã khóa");
                tbLocked.Rows.Add("", "Tất cả");

                repositoryItemLookUpEdit_Locked.DisplayMember = cLockedName;
                repositoryItemLookUpEdit_Locked.ValueMember = cLockedID;
                repositoryItemLookUpEdit_Locked.DataSource = tbLocked;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadLockedStatus");
            }
        }
        #endregion

        #region Actions
        private void button_Add_Click(object sender, EventArgs e)
        {
            
        }

        private void button_ResetPassword_Click(object sender, EventArgs e)
        {
            
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
           
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
           
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
           
        }

        private void gridView_Employee_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view;
            DataRow row;
            try
            {
                if (e.RowHandle <= -1)
                    return;
                view = sender as GridView;
                row = view.GetDataRow(e.RowHandle);
                if (Convert.ToInt32(row[_cLocked]) == 2)//Đã khóa
                {
                    e.Appearance.BackColor = Color.FromArgb(0, 205, 0);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Employee_RowCellStyle");
            }
        }

        private void gridView_Employee_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    return;
                }
                if (e.Button == MouseButtons.Right)
                {
                    barButtonItem_EmployeeDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                popupMenu_Employee.ShowPopup(Control.MousePosition);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Employee_MouseUp");
            }
        }

        private void barButtonItem_EmployeeDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_EmployeeInformation dlg;
            DataRow row;

            try
            {
                row = gridView_Employee.GetFocusedDataRow();
                dlg = new frm_EmployeeInformation();
                if (row != null)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    dlg._dbContext = _dbContext;
                    dlg._employeeCode = row[_cEmployeeCode].ToString();
                    dlg.Text = "Thông Tin Nhân Viên " + row[_cEmployeeName].ToString();
                    dlg.Show();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_EmployeeDetail_ItemClick");
            }
        }
        #endregion

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddEditAccount dlg;
            DataRow newRow;

            try
            {
                dlg = new frm_AddEditAccount();
                dlg.P_Employee = new employee();
                dlg._dbContext = _dbContext;
                dlg.Text = "Thêm Nhân Viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    byte[] pass = CoffeeHelpers.ScramblePassword.Encode(dlg.P_Employee.Password);
                    dlg.P_Employee.Password = Encoding.Unicode.GetString(pass);
                    try
                    {
                        _dbContext.employees.Add(dlg.P_Employee);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Không thể thêm mới người dùng vào hệ thống " + Environment.NewLine + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    newRow = _tbSource.NewRow();
                    newRow[_cEmployeeID] = dlg.P_Employee.EmployeeID;
                    newRow[_cEmployeeName] = dlg.P_Employee.EmployeeName;
                    newRow[_cEmployeeCode] = dlg.P_Employee.EmployeeCode;
                    newRow[_cEmployeeRight] = CoffeeHelpers.GetEmployeeRightTitle(dlg.P_Employee);
                    newRow[_cBirthDay] = dlg.P_Employee.Birthday;
                    newRow[_cSex] = dlg.P_Employee.Sex;
                    newRow[_cSalary] = dlg.P_Employee.Salary;
                    newRow[_cReceiveDate] = dlg.P_Employee.EmployeeDate;
                    newRow[_cPlanWork] = dlg.P_Employee.planwork.PlanWorkName;
                    newRow[_cEmail] = dlg.P_Employee.Email;
                    newRow[_cPhone] = dlg.P_Employee.Telephone;
                    newRow[_cAddress] = dlg.P_Employee.Address;
                    newRow[_cNotes] = dlg.P_Employee.Notes;
                    newRow[_cLocked] = dlg.P_Employee.Locked;

                    _tbSource.Rows.Add(newRow);

                    //Ghi log
                    WriteLog("Thêm nhân viên " + dlg.P_Employee.EmployeeName);
                    log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + "(" + CoffeeHelpers.EmpLogin.EmployeeID + ") đã thêm nhân viên " + dlg.P_Employee.EmployeeName);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Add_ItemClick");
            }
        }

        private void barButtonItem_Update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddEditAccount dlg;
            DataRow updateRow;
            employee employee, updateEmployee;
            CoffeeHelpers.EmpRight empRight;
            string employeeRight;

            try
            {
                if (gridView_Employee.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có nhân viên nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
              
                updateRow = gridView_Employee.GetFocusedDataRow();

                updateEmployee = (from emp in _dbContext.employees.ToList() where emp.EmployeeID == Convert.ToInt32(updateRow[_cEmployeeID]) select emp).FirstOrDefault();

                employeeRight = updateRow[_cEmployeeRight].ToString();
                employee = new employee();

                employee.EmployeeID = Convert.ToInt32(updateRow[_cEmployeeID]);
                employee.EmployeeCode = updateRow[_cEmployeeCode].ToString();
                employee.EmployeeName = updateRow[_cEmployeeName].ToString();
                employee.EmployeeRight = CoffeeHelpers.GetEmployeeRight(updateRow[_cEmployeeRight].ToString());
                empRight = CoffeeHelpers.GetEmpRight(employee);

                if (CoffeeHelpers.EmpLogin.EmpRight == CoffeeHelpers.EmpRight.SupAdmin) //--- Quyền Quản lý
                {
                    if (empRight == CoffeeHelpers.EmpRight.Administrator || empRight == CoffeeHelpers.EmpRight.SupAdmin)
                    {
                        XtraMessageBox.Show("Bạn không có quyền chỉnh sửa thông tin người dùng có loại quyền '" + employeeRight + "'", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                employee.Birthday = Convert.ToDateTime(updateRow[_cBirthDay]);
                employee.EmployeeDate = Convert.ToDateTime(updateRow[_cReceiveDate]);
                employee.Email = updateRow[_cEmail].ToString();
                employee.Telephone = updateRow[_cPhone].ToString();
                employee.Address = updateRow[_cAddress].ToString();
                employee.Notes = updateRow[_cNotes].ToString();
                employee.Salary = Convert.ToDecimal(updateRow[_cSalary].ToString());
                employee.Sex = updateRow[_cSex].ToString();
                employee.Worktime = updateEmployee.Worktime;
                employee.Locked = Convert.ToInt32(updateRow[_cLocked]);

                dlg = new frm_AddEditAccount();
                dlg.P_Employee = employee;
                dlg.Text = "Sửa Nhân Viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (updateEmployee != null)
                    {
                        updateEmployee.EmployeeCode = dlg.P_Employee.EmployeeCode;
                        updateEmployee.EmployeeName = dlg.P_Employee.EmployeeName;
                        updateEmployee.EmployeeRight = dlg.P_Employee.EmployeeRight;

                        updateEmployee.Birthday = dlg.P_Employee.Birthday;
                        updateEmployee.EmployeeDate = dlg.P_Employee.EmployeeDate;
                        updateEmployee.Worktime = dlg.P_Employee.Worktime;
                        updateEmployee.Email = dlg.P_Employee.Email;
                        updateEmployee.Salary = dlg.P_Employee.Salary;
                        updateEmployee.Sex = dlg.P_Employee.Sex;
                        updateEmployee.Telephone = dlg.P_Employee.Telephone;
                        updateEmployee.Address = dlg.P_Employee.Address;
                        updateEmployee.Notes = dlg.P_Employee.Notes;
                        updateEmployee.Locked = dlg.P_Employee.Locked;

                        try
                        {
                            _dbContext.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Không thể cập nhật người dùng vào hệ thống" + Environment.NewLine + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        updateRow[_cEmployeeCode] = updateEmployee.EmployeeCode;
                        updateRow[_cEmployeeName] = updateEmployee.EmployeeName;
                        updateRow[_cEmployeeRight] = CoffeeHelpers.GetEmployeeRightTitle(updateEmployee);
                        updateRow[_cBirthDay] = updateEmployee.Birthday;
                        updateRow[_cReceiveDate] = updateEmployee.EmployeeDate;
                        updateRow[_cPlanWork] = updateEmployee.planwork.PlanWorkName;
                        updateRow[_cEmail] = updateEmployee.Email;
                        updateRow[_cSalary] = updateEmployee.Salary;
                        updateRow[_cSex] = updateEmployee.Sex;
                        updateRow[_cPhone] = updateEmployee.Telephone;
                        updateRow[_cAddress] = updateEmployee.Address;
                        updateRow[_cNotes] = updateEmployee.Notes;
                        updateRow[_cLocked] = updateEmployee.Locked;
                    }
                    //Ghi log
                    WriteLog("Sửa thông tin của " + updateEmployee.EmployeeName + "(" + updateEmployee.EmployeeID + ")");
                    log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + "(" + CoffeeHelpers.EmpLogin.EmployeeID + ") đã sửa thông tin của " + updateEmployee.EmployeeName + "(" + updateEmployee.EmployeeID + ")");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Update_ItemClick");
            }
        }

        private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string employeeRight;
            CoffeeHelpers.EmpRight empRight;
            DataRow deleteRow;
            employee employee, deleteEmployee;

            try
            {
                if (gridView_Employee.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có nhân viên nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                deleteRow = gridView_Employee.GetFocusedDataRow();
                employeeRight = deleteRow[_cEmployeeRight].ToString();
                employee = new employee();
                employee.EmployeeID = Convert.ToInt32(deleteRow[_cEmployeeID]);
                employee.EmployeeCode = deleteRow[_cEmployeeCode].ToString();
                employee.EmployeeName = deleteRow[_cEmployeeName].ToString();
                employee.EmployeeRight = CoffeeHelpers.GetEmployeeRight(deleteRow[_cEmployeeRight].ToString());
                empRight = CoffeeHelpers.GetEmpRight(employee);

                if (CoffeeHelpers.EmpLogin.EmpRight == CoffeeHelpers.EmpRight.SupAdmin) //--- Quyền Admin
                {
                    if (empRight == CoffeeHelpers.EmpRight.SupAdmin || empRight == CoffeeHelpers.EmpRight.Administrator)
                    {
                        XtraMessageBox.Show("Bạn không có quyền xóa thông tin nhân viên có loại quyền '" + employeeRight + "'", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                if (XtraMessageBox.Show("Bạn chắc chắn muốn xóa thông tin nhân viên này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var moes = from m in _dbContext.listorders where m.EmployeeID == employee.EmployeeID && m.Status == 1 select m;
                if (moes != null && moes.Count() > 0)
                {
                    XtraMessageBox.Show("Không thể xóa, nhân viên này đang tồn tại trong đơn hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                deleteEmployee = (from emp in _dbContext.employees where emp.EmployeeID == employee.EmployeeID select emp).FirstOrDefault();
                if (employee != null)
                {
                    try
                    {
                        _dbContext.employees.Remove(deleteEmployee);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Không thể xóa người dùng từ hệ thống" + Environment.NewLine + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    gridView_Employee.DeleteRow(gridView_Employee.GetSelectedRows()[0]);

                    //Ghi log
                    WriteLog("Xoá nhân viên " + deleteEmployee.EmployeeName + "(" + deleteEmployee.EmployeeID + ")");
                    log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + "(" + CoffeeHelpers.EmpLogin.EmployeeID + ") đã xoá nhân viên " + deleteEmployee.EmployeeName + "(" + deleteEmployee.EmployeeID + ")");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Delete_ItemClick");
            }
        }

        private void barButtonItem_ResetPassWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string employeeRight;
            CoffeeHelpers.EmpRight empRight;
            DataRow selectedRow;
            employee employee, setPassEmployee;

            try
            {
                if (gridView_Employee.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có nhân viên nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                selectedRow = gridView_Employee.GetFocusedDataRow();
                employeeRight = selectedRow[_cEmployeeRight].ToString();
                employee = new employee();
                employee.EmployeeID = Convert.ToInt32(selectedRow[_cEmployeeID]);
                employee.EmployeeCode = selectedRow[_cEmployeeCode].ToString();
                employee.EmployeeName = selectedRow[_cEmployeeName].ToString();
                employee.EmployeeRight = CoffeeHelpers.GetEmployeeRight(selectedRow[_cEmployeeRight].ToString());
                empRight = CoffeeHelpers.GetEmpRight(employee);

                if (CoffeeHelpers.EmpLogin.EmpRight == CoffeeHelpers.EmpRight.SupAdmin) //--- Quyền Admin
                {
                    if (empRight == CoffeeHelpers.EmpRight.SupAdmin || empRight == CoffeeHelpers.EmpRight.Administrator)
                    {
                        XtraMessageBox.Show("Bạn không có quyền cấp lại mật khẩu cho nhân viên có loại quyền '" + employeeRight + "'", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                if (XtraMessageBox.Show("Bạn có thật sự muốn cấp lại mật khẩu cho: '" + employee.EmployeeCode + "' ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }

                var _resetPass = (from d in _dbContext.employees where d.EmployeeCode == selectedRow[_cEmployeeCode].ToString() select d).FirstOrDefault();
                DateTime _timePass = (DateTime)_resetPass.Birthday;

                byte[] pass = CoffeeHelpers.ScramblePassword.Encode(_timePass.ToString("ddMMyy"));
                string newPass = Encoding.Unicode.GetString(pass);

                setPassEmployee = (from emp in _dbContext.employees where emp.EmployeeID == employee.EmployeeID select emp).FirstOrDefault();
                if (employee != null)
                {
                    setPassEmployee.Password = newPass;
                    try
                    {
                        _dbContext.SaveChanges();
                        XtraMessageBox.Show("Cấp lại mật khẩu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Ghi log
                        WriteLog("Cấp lại mật khẩu cho " + setPassEmployee.EmployeeName + "(" + setPassEmployee.EmployeeID + ")");

                        log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + "(" + CoffeeHelpers.EmpLogin.EmployeeID + ") cấp lại mật khẩu cho " + setPassEmployee.EmployeeName + "(" + setPassEmployee.EmployeeID + ")");
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Lỗi trong khi cấp lại mật khẩu" + Environment.NewLine + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_ResetPassWord_ItemClick");
            }
        }

        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Close_ItemClick");
            }
        }

        private void gridControl_Employee_DoubleClick(object sender, EventArgs e)
        {
            frm_AddEditAccount dlg;
            DataRow updateRow;
            employee employee, updateEmployee;
            CoffeeHelpers.EmpRight empRight;
            string employeeRight;

            try
            {
                if (gridView_Employee.SelectedRowsCount == 0)
                {
                    return;
                }

                updateRow = gridView_Employee.GetFocusedDataRow();

                updateEmployee = (from emp in _dbContext.employees.ToList() where emp.EmployeeID == Convert.ToInt32(updateRow[_cEmployeeID]) select emp).FirstOrDefault();

                employeeRight = updateRow[_cEmployeeRight].ToString();
                employee = new employee();

                employee.EmployeeID = Convert.ToInt32(updateRow[_cEmployeeID]);
                employee.EmployeeCode = updateRow[_cEmployeeCode].ToString();
                employee.EmployeeName = updateRow[_cEmployeeName].ToString();
                employee.EmployeeRight = CoffeeHelpers.GetEmployeeRight(updateRow[_cEmployeeRight].ToString());
                empRight = CoffeeHelpers.GetEmpRight(employee);

                if (CoffeeHelpers.EmpLogin.EmpRight == CoffeeHelpers.EmpRight.SupAdmin) //--- Quyền Quản lý
                {
                    if (empRight == CoffeeHelpers.EmpRight.Administrator || empRight == CoffeeHelpers.EmpRight.SupAdmin)
                    {
                        XtraMessageBox.Show("Bạn không có quyền chỉnh sửa thông tin người dùng có loại quyền '" + employeeRight + "'", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                employee.Birthday = Convert.ToDateTime(updateRow[_cBirthDay]);
                employee.EmployeeDate = Convert.ToDateTime(updateRow[_cReceiveDate]);
                employee.Email = updateRow[_cEmail].ToString();
                employee.Telephone = updateRow[_cPhone].ToString();
                employee.Address = updateRow[_cAddress].ToString();
                employee.Notes = updateRow[_cNotes].ToString();
                employee.Salary = Convert.ToDecimal(updateRow[_cSalary].ToString());
                employee.Sex = updateRow[_cSex].ToString();
                employee.Worktime = updateEmployee.Worktime;
                employee.Locked = Convert.ToInt32(updateRow[_cLocked]);

                dlg = new frm_AddEditAccount();
                dlg.P_Employee = employee;
                dlg.Text = "Sửa Nhân Viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                   
                    if (updateEmployee != null)
                    {
                        updateEmployee.EmployeeCode = dlg.P_Employee.EmployeeCode;
                        updateEmployee.EmployeeName = dlg.P_Employee.EmployeeName;
                        updateEmployee.EmployeeRight = dlg.P_Employee.EmployeeRight;

                        updateEmployee.Birthday = dlg.P_Employee.Birthday;
                        updateEmployee.EmployeeDate = dlg.P_Employee.EmployeeDate;
                        updateEmployee.Worktime = dlg.P_Employee.Worktime;
                        updateEmployee.Email = dlg.P_Employee.Email;
                        updateEmployee.Salary = dlg.P_Employee.Salary;
                        updateEmployee.Sex = dlg.P_Employee.Sex;
                        updateEmployee.Telephone = dlg.P_Employee.Telephone;
                        updateEmployee.Address = dlg.P_Employee.Address;
                        updateEmployee.Notes = dlg.P_Employee.Notes;
                        updateEmployee.Locked = dlg.P_Employee.Locked;

                        try
                        {
                            _dbContext.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show("Không thể cập nhật người dùng vào hệ thống" + Environment.NewLine + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        updateRow[_cEmployeeCode] = updateEmployee.EmployeeCode;
                        updateRow[_cEmployeeName] = updateEmployee.EmployeeName;
                        updateRow[_cEmployeeRight] = CoffeeHelpers.GetEmployeeRightTitle(updateEmployee);
                        updateRow[_cBirthDay] = updateEmployee.Birthday;
                        updateRow[_cReceiveDate] = updateEmployee.EmployeeDate;
                        updateRow[_cPlanWork] = updateEmployee.planwork.PlanWorkName;
                        updateRow[_cEmail] = updateEmployee.Email;
                        updateRow[_cSalary] = updateEmployee.Salary;
                        updateRow[_cSex] = updateEmployee.Sex;
                        updateRow[_cPhone] = updateEmployee.Telephone;
                        updateRow[_cAddress] = updateEmployee.Address;
                        updateRow[_cNotes] = updateEmployee.Notes;
                        updateRow[_cLocked] = updateEmployee.Locked;
                    }
                    //Ghi log
                    WriteLog("Sửa thông tin của " + updateEmployee.EmployeeName + "(" + updateEmployee.EmployeeID + ")");

                    log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + "(" + CoffeeHelpers.EmpLogin.EmployeeID + ") đã sửa thông tin của " + updateEmployee.EmployeeName + "(" + updateEmployee.EmployeeID + ")");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_Employee_DoubleClick");
            }
        }

        // Ghi log
        private void WriteLog(string action)
        {
            log lg;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                lg = new log();
                lg.employeename = CoffeeHelpers.EmpLogin.EmployeeName;
                lg.actiondate = DateTime.Now;
                lg.actions = action;

                _dbContext.logs.Add(lg);
                _dbContext.SaveChanges();
            }
            catch
            {
            }
        }
    }
}