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
using TracerX;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_PaySheet : DevExpress.XtraEditors.XtraForm
    {
        #region Columns

        private const string _cEmployeeID = "EmployeeID";
        private const string _cEmployeeName = "EmployeeName";
        private const string _cEmployeeCode = "EmployeeCode";
        private const string _cEmployeeRight = "EmployeeRight";
        private const string _cReceiveDate = "ReceiveDate";
        private const string _cBirthDay = "BirthDay";
        private const string _cEmail = "Email";
        private const string _cPhone = "Phone";
        private const string _cAddress = "Address";
        private const string _cNotes = "Notes";
        private const string _cPassWord = "PassWord";
        private const string _cPlanWork = "PlanWork";

        private const string _waterMask = "--- Chọn";
        private const string _cPlanWorkID = "PlanWorkID";
        private const string _cPlanWorkName = "PlanWorkName";
        private const string _cPlanID = "PlanID";
        private const string _cPlanName = "PlanName";
        private const string _cStartTime = "StartTime";
        private const string _cEndTime = "EndTime";

        private const string _cBHYT = "BHYT";
        private const string _cAdvance = "Advance";
        private const string _cAllowance = "Allowance ";
        private const string _cReceive = "Receive";
        private const string _cOverTime = "OverTime";

        #endregion

        #region fields 

        private mycoffeeEntities _dbContext;
        DataTable _tbSource;
        // Đối tượng Log cho lớp
        private static readonly Logger log = Logger.GetLogger(typeof(frm_PaySheet));
        int _employeeID = -1;//Mã nhân viên
        // Đối tượng timer đóng ứng dụng
        private System.Threading.Timer _timerCloseApp = null;
        //Show Sologan
        DevExpress.Utils.WaitDialogForm dlg_sologan = null;

        decimal _Salary = 0;
        decimal _DaySalary = 0;
        decimal _Advance = 0;
        decimal _receiveSalary = 0;

        int _Furlough = 0;
        int _awol = 0;
        int _work = 0;
        int _default_max = 0;
        TreeNode node;

        #endregion

        #region Form Method
        public frm_PaySheet()
        {
            InitializeComponent();
        }

        private void frm_PaySheet_Load(object sender, EventArgs e)
        {
            DateTime dtNow;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dtNow = DateTime.Now;
                monthEdit_Employee.EditValue = DateTime.Now.Month;
                monthEdit_Salary.EditValue = DateTime.Now.Month;

                LoadPlanWork();

                LoadPlanWorkSalary();

                AddEmployeeByPhanWork();

                _tbSource = CreateTableStruct();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Appointment_Load");
            }
        }

        #endregion

        #region Helpers

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
                planwork = (from p in _dbContext.planworks.ToList() select p).ToList();

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

                //Nêu chỉ có 1 ca thì chọn lun
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

        private void LoadPlanWorkSalary()
        {
            List<planwork> planwork;
            DataTable tbSource;
            DataRow newRow;

            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                planwork = (from p in _dbContext.planworks.ToList() select p).ToList();

                tbSource = new DataTable();

                tbSource.Columns.Add(_cPlanID, typeof(int));
                tbSource.Columns.Add(_cPlanName);

                foreach (planwork p in planwork)
                {
                    newRow = tbSource.NewRow();

                    newRow[_cPlanID] = p.PlanWorkID;
                    newRow[_cPlanName] = p.PlanWorkName;

                    tbSource.Rows.Add(newRow);
                }

                //Nêu chỉ có 1 ca thì chọn lun
                int selectID = -1;
                if (planwork.Count == 1)
                {
                    selectID = planwork.FirstOrDefault().PlanWorkID;
                }
                else
                {
                    newRow = tbSource.NewRow();
                    newRow[_cPlanID] = -1;
                    newRow[_cPlanName] = _waterMask;
                    tbSource.Rows.InsertAt(newRow, 0);
                }

                slookUpEdit_PlanWorkSalary.Properties.DisplayMember = _cPlanName;
                slookUpEdit_PlanWorkSalary.Properties.ValueMember = _cPlanID;
                slookUpEdit_PlanWorkSalary.Properties.DataSource = tbSource;
                slookUpEdit_PlanWorkSalary.EditValue = selectID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadPlanWorkSalary");
            }
        }

        //Load thông tin nhân viên
        private void LoadInformationEmployee(int employeeID)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                //Nghỉ không xin phép
                var awol = (from aw in _dbContext.employeestates.ToList()
                            where aw.EmployeeID == employeeID && aw.Status == 2 && aw.Date.Month == Convert.ToInt32(monthEdit_Employee.EditValue)
                            group aw by aw.EmployeeID into gr
                            select gr.Count());

                //Nhỉ có phép
                var furlough = (from aw in _dbContext.employeestates.ToList()
                                where aw.EmployeeID == employeeID && aw.Status == 1 && aw.Date.Month == Convert.ToInt32(monthEdit_Employee.EditValue)
                                group aw by aw.EmployeeID into gr
                                select gr.Count());

                //Đi làm
                var work = (from aw in _dbContext.employeestates.ToList()
                            where aw.EmployeeID == employeeID && aw.Status == 0 && aw.Date.Month == Convert.ToInt32(monthEdit_Employee.EditValue)
                            group aw by aw.EmployeeID into gr
                            select gr.Count()
                                );


                if (furlough != null)
                {
                    _Furlough = furlough.FirstOrDefault().ToString() != null ? Convert.ToInt32(furlough.FirstOrDefault()) : 0;
                    spinEdit_Furlough.Text = _Furlough.ToString();
                }
                if (awol != null)
                {
                    _awol = awol.FirstOrDefault().ToString() != null ? Convert.ToInt32(awol.FirstOrDefault()) : 0;
                    spinEdit_Awol.Text = _awol.ToString();
                }
                if (work != null)
                {
                    _work = work.FirstOrDefault().ToString() != null ? Convert.ToInt32(work.FirstOrDefault()) : 0;
                    spinEdit_Work.Text = _work.ToString();
                }

                _DaySalary = Math.Round((Convert.ToDecimal(_Salary) / 30), 1);
                if (_DaySalary == 0)
                {
                    lbl_DayMoney.Text = string.Format("{0:#,#}", Convert.ToString(_DaySalary));
                }
                else
                {
                    lbl_DayMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_DaySalary));
                }

                //Tạm ứng trong tháng
                var advance = (from aw in _dbContext.advancemoneys.ToList()
                               where aw.EmployeeID == employeeID && aw.Date.Month == Convert.ToInt32(monthEdit_Employee.EditValue)
                               group aw by aw.EmployeeID into gr
                               select gr.Sum(s => s.Advance_Money));

                if (advance != null)
                {
                    lbl_Advance.Text = advance.FirstOrDefault().ToString() != null ? string.Format("{0:#,#}", Convert.ToDecimal(advance.FirstOrDefault())) : string.Format("{0:#,#}", Convert.ToDecimal("0"));
                }

                //Các khoảng tiền khác
                var pay_sheet = (from aw in _dbContext.pay_sheet.ToList()
                                 where aw.EmployeeID == employeeID && aw.Date.Month == Convert.ToInt32(monthEdit_Employee.EditValue)
                                 select aw).FirstOrDefault();
                if (pay_sheet != null)
                {
                    textEdit_BHYT.EditValue = Convert.ToDecimal(pay_sheet.BHYT);
                    textEdit_Overtime.EditValue = Convert.ToDecimal(pay_sheet.Over_Time);
                    textEdit_Allowance.EditValue = Convert.ToDecimal(pay_sheet.BHYT);
                }

                //Thực lãnh
                _receiveSalary = (_Salary +
                                           Convert.ToDecimal(textEdit_BHYT.EditValue) +
                                           Convert.ToDecimal(textEdit_Allowance.EditValue) +
                                           Convert.ToDecimal(textEdit_Overtime.EditValue)) -
                                           ((_awol * _DaySalary) + _Advance);
                if (_receiveSalary == 0)
                {
                    textEdit_Receive.Text = string.Format("{0:#,#}", Convert.ToString(_receiveSalary));
                }
                else
                {
                    textEdit_Receive.Text = string.Format("{0:#,#}", Convert.ToDecimal(_receiveSalary));
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadInformationEmployee");
            }
        }

        //Danh sách nhân vien theo ca
        private void AddEmployeeByPhanWork()
        {
            List<employee> listEmpls;
            TreeNode nodes;
            try
            {
                if (treeView_Employee.Nodes.Count > 0)
                {
                    treeView_Employee.Nodes.Clear();
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                listEmpls = (from em in _dbContext.employees.ToList() where em.Worktime == Convert.ToInt32(slookUpEdit_PlanWork.EditValue) && em.EmployeeRight!=CoffeeHelpers.EmpRight.Administrator.ToString() select em).ToList();

                if (listEmpls != null && listEmpls.Count > 0)
                {
                    foreach (employee item in listEmpls)
                    {
                        nodes = new TreeNode();
                        nodes.Name = item.EmployeeID.ToString();
                        nodes.Tag = item.EmployeeName.ToString() + "/" + item.Salary;

                        nodes.Text = item.EmployeeName.ToString() + " (" + item.EmployeeID + ")";

                        if (item.Sex == "Nam")
                        {
                            nodes.ImageIndex = 0;
                            nodes.SelectedImageIndex = 0;
                        }
                        else if (item.Sex == "Nữ")
                        {
                            nodes.ImageIndex = 1;
                            nodes.SelectedImageIndex = 1;
                        }
                        else
                        {
                            nodes.ImageIndex = 2;
                            nodes.SelectedImageIndex = 2;
                        }

                        treeView_Employee.Nodes.Add(nodes);
                    }

                    TreeNodeCollection selectnodes = treeView_Employee.Nodes;
                    treeView_Employee.SelectedNode = selectnodes[0];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddEmployeeByPhanWork");
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
                //Ghi long
                log.ErrorFormat("TimerCloseAppCallback", ex.Message);
            }
        }

        private void LoadInfomationEmployeeAfterSave(int month)
        {
            List<pay_sheet> listpays;
            DataRow row;
            DataTable tbSource;
            try
            {
                tbSource = CreateTableStruct();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                listpays = (from ls in _dbContext.pay_sheet.ToList() where ls.Date.Month == month select ls).ToList();

                if (listpays != null && listpays.Count > 0)
                {
                    foreach (pay_sheet p in listpays)
                    {
                        //Tạm ứng trong tháng
                        var advance = (from aw in _dbContext.advancemoneys.ToList()
                                       where aw.EmployeeID == p.EmployeeID && aw.Date.Month == Convert.ToInt32(monthEdit_Salary.EditValue)
                                       group aw by aw.EmployeeID into gr
                                       select gr.Sum(s => s.Advance_Money));
                        decimal _advance = 0;
                        if (advance != null)
                        {
                            _advance = advance.FirstOrDefault();
                        }
                        else
                        {
                            _advance = 0;
                        }

                        string BHYT = string.Format("{0:#,#}", Convert.ToDecimal(p.BHYT)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(p.BHYT)) : string.Format("{0:#,#}", Convert.ToString(p.BHYT));
                        string Advance = string.Format("{0:#,#}", Convert.ToDecimal(_advance.ToString())) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(_advance.ToString())) : string.Format("{0:#,#}", Convert.ToString(_advance.ToString()));
                        string OverTime = string.Format("{0:#,#}", Convert.ToDecimal(p.Over_Time)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(p.Over_Time)) : string.Format("{0:#,#}", Convert.ToString(p.Over_Time));
                        string Allowance = string.Format("{0:#,#}", Convert.ToDecimal(p.Allowance)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(p.Allowance)) : string.Format("{0:#,#}", Convert.ToString(p.Allowance));
                        string Receive = string.Format("{0:#,#}", Convert.ToDecimal(p.Receive)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(p.Receive)) : string.Format("{0:#,#}", Convert.ToString(p.Receive));

                        row = tbSource.NewRow();
                        row[_cEmployeeID] = p.EmployeeID;
                        row[_cEmployeeName] = p.employee.EmployeeName;
                        row[_cBHYT] = BHYT;
                        row[_cAdvance] = Advance;
                        row[_cOverTime] = OverTime;
                        row[_cAllowance] = Allowance;
                        row[_cReceive] = Receive;

                        tbSource.Rows.Add(row);
                    }

                    gridControl_PaySheet.DataSource = tbSource;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadInfomationEmployeeAfterSave");
            }
        }

        private void AddTimeWorkOfEmployee(int employeeID)
        {
            List<employeestate> emplState;
            int line_y = 1;
            int line_x = 0;
            int loop = 0;

            try
            {
                //Chieu rong cua xtraScrollable cho phep chu toi da ban co kich thuoc 105x105
                int maxTable = xtraScrollable_Work.Width / 90;
                _default_max = maxTable;

                //Xóa nếu có
                if (xtraScrollable_Work.Controls.Count > 0)
                {
                    for (int i = 0; i < xtraScrollable_Work.Controls.Count; i++)
                    {
                        xtraScrollable_Work.Controls.RemoveByKey(xtraScrollable_Work.Controls[i].Name);
                        i--;
                    }
                }

                //Đi làm
                emplState = (from aw in _dbContext.employeestates.ToList()
                             where aw.EmployeeID == employeeID && aw.Date.Month == Convert.ToInt32(monthEdit_Employee.EditValue)
                             select aw).ToList();

                if (emplState != null && emplState.Count > 0)
                {
                    int i = 2;
                    foreach (employeestate em in emplState)
                    {

                        if (loop == maxTable)
                        {
                            maxTable = _default_max * i;

                            line_x = 0;// Tra hoanh do ve 0
                            line_y = (line_y + 30) + 5;//Tung do tang len ban mot kich thuoc chieu cao cua hang truoc

                            //--Hang ban thu may
                            i++;
                        }

                        GroupControl Group_Work = new GroupControl();

                        Point p = new Point(((line_x) * 90) + 5, line_y);
                        Group_Work.Location = p;
                        Group_Work.Text = em.Date.ToString("dd/MM/yyyy");
                        Group_Work.Name = em.Date.ToString("dd/MM/yyyy");
                        Group_Work.Tag = em.EmployeeID;

                        Group_Work.Width = 90;
                        Group_Work.Height = 30;

                        Group_Work.LookAndFeel.UseDefaultLookAndFeel = false;
                        Group_Work.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        Font f = new Font("times new roman", 11.0f, System.Drawing.FontStyle.Bold);
                        Group_Work.AppearanceCaption.Font = f;
                        Group_Work.AppearanceCaption.ForeColor = Color.Maroon;
                        if (em.Status == 0)
                        {
                            Group_Work.Appearance.BackColor = Color.FromArgb(232, 232, 232);//Xám
                        }
                        else if (em.Status == 1)
                        {
                            Group_Work.Appearance.BackColor = Color.FromArgb(0, 238, 238);//Xanh
                        }
                        else
                        {
                            Group_Work.Appearance.BackColor = Color.FromArgb(255, 106, 106);//Hồng
                        }

                        xtraScrollable_Work.Controls.Add(Group_Work);

                        line_x++;
                        loop++;
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddTimeWorkOfEmployee");
            }
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho OrderDetail Main
        /// </summary>
        private DataTable CreateTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cEmployeeID);
                tbSource.Columns.Add(_cEmployeeName);
                tbSource.Columns.Add(_cBHYT);
                tbSource.Columns.Add(_cAllowance);
                tbSource.Columns.Add(_cAdvance);
                tbSource.Columns.Add(_cOverTime);
                tbSource.Columns.Add(_cReceive);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cEmployeeID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateOrderDetailMainableStruct");
                return tbSource;
            }
            return tbSource;
        }

        #endregion

        #region Action


        private void slookUpEdit_PlanWork_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                AddEmployeeByPhanWork();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "slookUpEdit_PlanWork_EditValueChanged");
            }
        }

        private void treeView_Employee_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                node = e.Node;

                string[] name = node.Tag.ToString().Split('/');
                label_EmployeeID.Text = node.Name;
                _employeeID = Convert.ToInt32(node.Name);
                label_EmployeeName.Text = name[0].ToString();
                _Salary = Convert.ToDecimal(name[1]);

                textEdit_Salary.Text = string.Format("{0:#,#}", Convert.ToDecimal(_Salary)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(_Salary)) : string.Format("{0:#,#}", Convert.ToString(_Salary));

                LoadInformationEmployee(Convert.ToInt32(node.Name));

                //Add chi tiết trạn thái các ngày làm việc trong tháng
                AddTimeWorkOfEmployee(Convert.ToInt32(node.Name));

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Employee_NodeMouseClick");
            }
        }



        private void textEdit_BHYT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Thực lãnh
                _receiveSalary = (_Salary +
                                           Convert.ToDecimal(textEdit_BHYT.EditValue) +
                                           Convert.ToDecimal(textEdit_Allowance.EditValue) +
                                           Convert.ToDecimal(textEdit_Overtime.EditValue)) -
                                           ((_awol * _DaySalary) + _Advance);
                if (_receiveSalary == 0)
                {
                    textEdit_Receive.Text = string.Format("{0:#,#}", Convert.ToString(_receiveSalary));
                }
                else
                {
                    textEdit_Receive.Text = string.Format("{0:#,#}", Convert.ToDecimal(_receiveSalary));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_BHYT_EditValueChanged");
            }
        }

        private void textEdit_Allowance_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Thực lãnh
                _receiveSalary = (_Salary +
                                           Convert.ToDecimal(textEdit_BHYT.EditValue) +
                                           Convert.ToDecimal(textEdit_Allowance.EditValue) +
                                           Convert.ToDecimal(textEdit_Overtime.EditValue)) -
                                           ((_awol * _DaySalary) + _Advance);
                if (_receiveSalary == 0)
                {
                    textEdit_Receive.Text = string.Format("{0:#,#}", Convert.ToString(_receiveSalary));
                }
                else
                {
                    textEdit_Receive.Text = string.Format("{0:#,#}", Convert.ToDecimal(_receiveSalary));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_Allowance_EditValueChanged");
            }
        }

        private void textEdit_Overtime_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Thực lãnh
                _receiveSalary = (_Salary +
                                           Convert.ToDecimal(textEdit_BHYT.EditValue) +
                                           Convert.ToDecimal(textEdit_Allowance.EditValue) +
                                           Convert.ToDecimal(textEdit_Overtime.EditValue)) -
                                           ((_awol * _DaySalary) + _Advance);
                if (_receiveSalary == 0)
                {
                    textEdit_Receive.Text = string.Format("{0:#,#}", Convert.ToString(_receiveSalary));
                }
                else
                {
                    textEdit_Receive.Text = string.Format("{0:#,#}", Convert.ToDecimal(_receiveSalary));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_Overtime_EditValueChanged");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            pay_sheet pay;
            DateTime dtNow = DateTime.Now;
            try
            {
                if (_employeeID == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                pay = new pay_sheet();
                pay = (from p in _dbContext.pay_sheet.ToList() where p.EmployeeID == _employeeID && p.Date.Month == Convert.ToInt32(monthEdit_Employee.EditValue) select p).FirstOrDefault();
                if (pay != null)
                {
                    pay.BHYT = Convert.ToDecimal(textEdit_BHYT.EditValue);
                    pay.Allowance = Convert.ToDecimal(textEdit_Allowance.EditValue);
                    pay.Over_Time = Convert.ToDecimal(textEdit_Overtime.EditValue);
                    pay.Date = new DateTime(dtNow.Year, Convert.ToInt32(monthEdit_Employee.EditValue), dtNow.Day, 0, 0, 0);
                    pay.Receive = Convert.ToDecimal(_receiveSalary);

                    _dbContext.SaveChanges();
                }
                else
                {
                    pay = new pay_sheet();
                    pay.EmployeeID = _employeeID;
                    pay.BHYT = Convert.ToDecimal(textEdit_BHYT.EditValue);
                    pay.Allowance = Convert.ToDecimal(textEdit_Allowance.EditValue);
                    pay.Over_Time = Convert.ToDecimal(textEdit_Overtime.EditValue);
                    pay.Date = new DateTime(dtNow.Year, Convert.ToInt32(monthEdit_Employee.EditValue), dtNow.Day, 0, 0, 0);
                    pay.Receive = Convert.ToDecimal(_receiveSalary);

                    _dbContext.pay_sheet.Add(pay);
                    _dbContext.SaveChanges();
                }

                dlg_sologan = new DevExpress.Utils.WaitDialogForm("Đang cập nhật", "Vui lòng chờ...", new Size(160, 50));
                _timerCloseApp = new System.Threading.Timer(TimerCloseAppCallback, null, 500, System.Threading.Timeout.Infinite);

                //Ghi log
                WriteLog("Chấm công cho nhân viên " + pay.employee.EmployeeName + "(" + pay.EmployeeID + ")");

                log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") " + "đã chấm công cho nhân viên " + pay.employee.EmployeeName + "(" + pay.EmployeeID + ")");

                //Danh sách lương nhân viên
                LoadInfomationEmployeeAfterSave(Convert.ToInt32(monthEdit_Employee.EditValue));

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

        private void monthEdit_Salary_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadInfomationEmployeeAfterSave(Convert.ToInt32(monthEdit_Salary.EditValue));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "monthEdit_Salary_SelectedIndexChanged");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Exit_Click");
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

        #endregion

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelControl11_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "panelControl1_MouseDown");
            }
        }

    }
}