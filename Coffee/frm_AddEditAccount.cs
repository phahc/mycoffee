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
    public partial class frm_AddEditAccount : DevExpress.XtraEditors.XtraForm
    {
        #region Properties

        public mycoffeeEntities _dbContext;
        public employee P_Employee { get; set; }

        private const string _waterMask = "--- Chọn";
        private const string _cPlanWorkID = "PlanWorkID";
        private const string _cPlanWorkName = "PlanWorkName";


        private const string _cStartTime = "StartTime";
        private const string _cEndTime = "EndTime";
        private const string _cNotes = "Notes";
        private const string _cSex = "Sex";
        private const string _cSalary = "Salary";

        private const string _male = "Nam";
        private const string _famale = "Nữ";
        private const string _other = "Khác";

        private const string _cLockedID = "LockedID";
        private const string _cLockedName= "LockedName";

        #endregion //--- Properties 

        #region Form MEthod
        public frm_AddEditAccount()
        {
            InitializeComponent();
        }

        private void frm_AccountManager_Load(object sender, EventArgs e)
        {
            string rightTitle;
            DateTime dtNow;
            try
            {
                //Load Ca làm việc
                LoadPlanWork();
                //Load trạng thái khóa
                LoadLockedStatus();

                dtNow = DateTime.Now;
                dateEdit_BirthDay.DateTime = dtNow;
                dateEdit_DateReceive.DateTime = dtNow;
                dateEdit_BirthDay.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                dateEdit_DateReceive.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

                comboBoxEdit_Right.SelectedIndex = 0; //--- Mặc định chọn quyền người dùng đầu tiên              
                if (P_Employee.EmployeeID != 0) //--- Cập nhật
                {
                    rightTitle = CoffeeHelpers.GetEmployeeRightTitle(P_Employee);
                    comboBoxEdit_Right.SelectedIndex = comboBoxEdit_Right.Properties.Items.IndexOf(rightTitle);
                    textEdit_EmployeeCode.Enabled = false;
                    if (CoffeeHelpers.EmpLogin.EmployeeRight == CoffeeHelpers.EmpRight.Administrator.ToString())
                    {
                        comboBoxEdit_Right.Properties.Items.Clear();

                        comboBoxEdit_Right.Properties.Items.Add(CoffeeHelpers.GetEmployeeRightTitle(CoffeeHelpers.EmpRight.Operator));
                        comboBoxEdit_Right.Properties.Items.Add(CoffeeHelpers.GetEmployeeRightTitle(CoffeeHelpers.EmpRight.SupAdmin));

                        //Administrator được sửa cả tên đăng nhập
                        textEdit_EmployeeCode.Enabled = true;

                        if (P_Employee.EmployeeRight == CoffeeHelpers.EmpRight.SupAdmin.ToString())
                        {
                            comboBoxEdit_Right.SelectedIndex = 1;
                        }
                        else
                        {
                            comboBoxEdit_Right.SelectedIndex = 0;
                        }

                    }
                    if (CoffeeHelpers.EmpLogin.EmployeeRight == CoffeeHelpers.EmpRight.SupAdmin.ToString())
                    {
                        comboBoxEdit_Right.Properties.Items.Clear();
                        comboBoxEdit_Right.Properties.Items.Add(CoffeeHelpers.GetEmployeeRightTitle(CoffeeHelpers.EmpRight.Operator));
                        comboBoxEdit_Right.SelectedIndex = 0;
                    }

                    textEdit_EmployeeName.Text = P_Employee.EmployeeName;
                    textEdit_EmployeeCode.Text = P_Employee.EmployeeCode;

                    dateEdit_BirthDay.EditValue = P_Employee.Birthday;
                    dateEdit_DateReceive.EditValue = P_Employee.EmployeeDate;
                    textEdit_Email.EditValue = P_Employee.Email;
                    textEdit_Phone.EditValue = P_Employee.Telephone;
                    textEdit_Address.EditValue = P_Employee.Address;
                    slookUpEdit_PlanWork.EditValue = P_Employee.Worktime;
                    memoEdit_Notes.EditValue = P_Employee.Notes;
                    textEdit_Salary.EditValue = string.Format("{0:#,#}",Convert.ToString(P_Employee.Salary));

                    if (P_Employee.Sex.ToLower() == "nam")
                    {
                        radioButton_Male.Checked = true;
                    }
                    if (P_Employee.Sex.ToLower() == "nữ")
                    {
                        radioButton_Female.Checked = true;
                    }
                    if (P_Employee.Sex.ToLower() == "khác")
                    {
                        radioButton_Other.Checked = true;
                    }
                    //Trạng thái khóa
                    slookUpEdit_Locked.EditValue = P_Employee.Locked;
                }
                else //--- Thêm mới
                {
                    if (CoffeeHelpers.EmpLogin.EmployeeRight == CoffeeHelpers.EmpRight.Administrator.ToString())
                    {
                        comboBoxEdit_Right.Properties.Items.Clear();

                        comboBoxEdit_Right.Properties.Items.Add(CoffeeHelpers.GetEmployeeRightTitle(CoffeeHelpers.EmpRight.Operator));
                        comboBoxEdit_Right.Properties.Items.Add(CoffeeHelpers.GetEmployeeRightTitle(CoffeeHelpers.EmpRight.SupAdmin));

                    }
                    else if (CoffeeHelpers.EmpLogin.EmployeeRight == CoffeeHelpers.EmpRight.SupAdmin.ToString())
                    {
                        comboBoxEdit_Right.Properties.Items.Clear();
                        comboBoxEdit_Right.Properties.Items.Add(CoffeeHelpers.GetEmployeeRightTitle(CoffeeHelpers.EmpRight.Operator));
                    }

                    //Trạng thái luôn được kích hoạt khi mới thêm
                    slookUpEdit_Locked.EditValue = 1;
                    slookUpEdit_Locked.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AccountManager_Load");
            }
        }

        #endregion

        #region Helpers
        private void SaveEmployee()
        {
            string employeeName, employeeCode, email, phone, address, notes, password;
            string sex = _famale;
            int planwork, locked;
            decimal salary;
            DateTime birthDay, dateReceive;
            bool checkExistEmployeeCode = true;

            try
            {
                employeeName = textEdit_EmployeeName.Text.Trim();
                employeeCode = textEdit_EmployeeCode.Text.Trim();
                birthDay = dateEdit_BirthDay.DateTime;
                dateReceive = dateEdit_DateReceive.DateTime;
                planwork = Convert.ToInt32(slookUpEdit_PlanWork.EditValue);
                email = textEdit_Email.Text.Trim();
                phone = textEdit_Phone.Text.Trim();
                address = textEdit_Address.Text.Trim();
                notes = memoEdit_Notes.Text.Trim();
                password = birthDay.ToString("ddMMyy");
                if (radioButton_Male.Checked == true)
                {
                    sex = _male;
                }
                if (radioButton_Female.Checked == true)
                {
                    sex = _famale;
                }
                if (radioButton_Other.Checked == true)
                {
                    sex = _other;
                }

                salary = Convert.ToDecimal(textEdit_Salary.EditValue);

                locked = Convert.ToInt32(slookUpEdit_Locked.EditValue);

                if (string.IsNullOrEmpty(employeeCode))
                {
                    XtraMessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_EmployeeCode.Focus();
                    return;
                }
                if (employeeCode.Length < 6)
                {
                    XtraMessageBox.Show("Vui lòng nhập tên đăng nhập ít nhất 6 kí tự", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_EmployeeCode.Focus();
                    return;
                }
                if (employeeCode.ToLower() == CoffeeHelpers.EmpRight.Administrator.ToString().ToLower())
                {
                    XtraMessageBox.Show("Không thể thêm mới tên đăng nhập là '" + CoffeeHelpers.EmpRight.Administrator.ToString() + "', vui lòng thêm tên đăng nhập khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(employeeName))
                {
                    XtraMessageBox.Show("Vui lòng nhập họ tên nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_EmployeeName.Focus();
                    return;
                }
                if (birthDay > dateReceive)
                {
                    XtraMessageBox.Show("Ngày sinh không thể lớn hơn ngày vào làm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (slookUpEdit_PlanWork.Text == _waterMask)
                {
                    XtraMessageBox.Show("Vui lòng chọn ca làm việc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (employeeName.ToLower() == CoffeeHelpers.EmpRight.Administrator.ToString().ToLower())
                {
                    XtraMessageBox.Show("Không thể thêm mới họ tên nhân viên là '" + CoffeeHelpers.EmpRight.Administrator.ToString() + "', vui lòng thêm họ tên nhân viên khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToDouble(textEdit_Salary.EditValue) < 0 || textEdit_Salary.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng nhập mức lương '" + CoffeeHelpers.EmpRight.Administrator.ToString() + "', vui lòng thêm họ tên nhân viên khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToDouble(textEdit_Salary.EditValue) == 0)
                {
                    if (XtraMessageBox.Show("Nhân viên này làm không lương ? '" + CoffeeHelpers.EmpRight.Administrator.ToString() + "', vui lòng thêm họ tên nhân viên khác", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) ;
                    {
                        return;
                    }
                }

                if (P_Employee.EmployeeID != 0) //--- Update
                {
                    if (P_Employee.EmployeeCode != employeeCode) //--- User thay đổi employeeCode
                        checkExistEmployeeCode = true;
                    else
                        checkExistEmployeeCode = false;
                }
                if (checkExistEmployeeCode == true)
                {
                    if (CheckExistEmployeeCode(employeeCode) == true) //--- Tồn tại employeeCode trong db
                    {
                        XtraMessageBox.Show("Tên đăng nhập đã bị trùng. Vui lòng đánh vào tên đăng nhập khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textEdit_EmployeeCode.Focus();
                        return;
                    }
                }

                P_Employee.EmployeeCode = employeeCode;
                P_Employee.EmployeeName = employeeName;
                P_Employee.EmployeeRight = comboBoxEdit_Right.SelectedIndex == 0 ? CoffeeHelpers.EmpRight.Operator.ToString() : CoffeeHelpers.EmpRight.SupAdmin.ToString();
                P_Employee.Birthday = birthDay;
                P_Employee.EmployeeDate = dateReceive;
                P_Employee.Worktime = planwork;
                P_Employee.Email = email;
                P_Employee.Sex = sex;
                P_Employee.Salary = salary;
                P_Employee.Address = address;
                P_Employee.Telephone = phone;
                P_Employee.Notes = notes;
                P_Employee.Password = password;
                P_Employee.Locked = locked;
                P_Employee.ChangeEmployeeCode = 2;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SaveEmployee");
            }
        }

        /// <summary>
        /// Kiểm tra tồn tại EmployeeCode
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns> true: Tồn tại, false: Không tồn tại </returns>
        private bool CheckExistEmployeeCode(string employeeCode)
        {
            try
            {
                var employees = from e in _dbContext.employees where e.EmployeeCode == employeeCode select e;
                if (employees == null || employees.Count() == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CheckExistEmployeeCode");
                return false;
            }
        }

        /// <summary>
        /// Load danh sách ca làm việc
        /// </summary>
        private void LoadPlanWork()
        {
            List<planwork> planwork;
            DataTable tbSource;
            DataRow newRow;

            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                planwork = (from p in _dbContext.planworks where p.Status == 1 select p).ToList();

                tbSource = new DataTable();

                tbSource.Columns.Add(_cPlanWorkID, typeof(int));
                tbSource.Columns.Add(_cPlanWorkName);
                tbSource.Columns.Add(_cStartTime);
                tbSource.Columns.Add(_cEndTime);
                tbSource.Columns.Add(_cNotes);

                foreach (planwork p in planwork)
                {
                    newRow = tbSource.NewRow();

                    newRow[_cPlanWorkID] = p.PlanWorkID;
                    newRow[_cPlanWorkName] = p.PlanWorkName;
                    newRow[_cStartTime] = p.StartTime;
                    newRow[_cEndTime] = p.EndTime;
                    newRow[_cNotes] = p.Notes;

                    tbSource.Rows.Add(newRow);
                }

                int selectID = -1;
                if (planwork.Count == 1)
                {
                    selectID = planwork.FirstOrDefault().PlanWorkID;
                }
                else
                {
                    newRow = tbSource.NewRow();
                    newRow[_cPlanWorkID] = -1;
                    newRow[_cPlanWorkName] = _waterMask;
                    tbSource.Rows.InsertAt(newRow, 0);
                }

                slookUpEdit_PlanWork.Properties.DisplayMember = _cPlanWorkName;
                slookUpEdit_PlanWork.Properties.ValueMember = _cPlanWorkID;
                slookUpEdit_PlanWork.Properties.DataSource = tbSource;
                slookUpEdit_PlanWork.EditValue = selectID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadPlanWork");
            }
        }

        /// <summary>
        /// Load trình trạng khóa
        /// </summary>
        private void LoadLockedStatus()
        {
            DataTable tbSource;
            DataRow newRow;

            try
            {
                tbSource = new DataTable();

                tbSource.Columns.Add(_cLockedID, typeof(int));
                tbSource.Columns.Add(_cLockedName);

                newRow = tbSource.NewRow();
                newRow[_cLockedID] = "1";
                newRow[_cLockedName] = "Đang kích hoạt";
                tbSource.Rows.Add(newRow);

                newRow = tbSource.NewRow();
                newRow[_cLockedID] = "2";
                newRow[_cLockedName] = "Đã khóa";
                tbSource.Rows.Add(newRow);



                slookUpEdit_Locked.Properties.DisplayMember = _cLockedName;
                slookUpEdit_Locked.Properties.ValueMember = _cLockedID;
                slookUpEdit_Locked.Properties.DataSource = tbSource;
                slookUpEdit_Locked.EditValue = 1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadLockedStatus");
            }
        }
        #endregion

        #region Actions
        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveEmployee();
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
                this.DialogResult = DialogResult.Cancel;
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