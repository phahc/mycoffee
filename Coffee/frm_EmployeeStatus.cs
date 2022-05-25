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
    public partial class frm_EmployeeStatus : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        public mycoffeeEntities _dbContext;
        public employee P_Employee { get; set; }
        DataTable _tbSource;

        private GroupControl Group_Employee;
        private RadioButton Radio_Employee;

        private List<GroupControl> Group_ListEmployee;
        private List<EmployeeStatus> Radion_ListEmployee;

        // Đối tượng timer đóng ứng dụng
        private System.Threading.Timer _timerCloseApp = null;
        //Show Sologan
        DevExpress.Utils.WaitDialogForm dlg_sologan = null;
        #endregion

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
        private const string _cStartTime = "StartTime";
        private const string _cEndTime = "EndTime";

        #endregion

        #region Form Method
        public frm_EmployeeStatus()
        {
            InitializeComponent();
        }

        private void frm_EmployeeStatus_Load(object sender, EventArgs e)
        {
            DateTime dtNow;
            try
            {
                dtNow = DateTime.Now;
                lbl_Date.Text = "Ngày " + dtNow.Day + " tháng " + dtNow.Month + " năm "+ dtNow.Year;

                //Danh sách ca làm việc
                LoadPlanWork();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_EmployeeStatus_Load");
            }
        }

        private void TimerCloseAppCallback(object state)
        {
            try
            {
                this.BeginInvoke(new Action(() => { dlg_sologan.Close(); _timerCloseApp = null; }));
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TimerCloseAppCallback");
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
        #endregion

        #region Actions
        private void button_Save_Click(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            employeestate emplState;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                emplState = new employeestate();
                if (Radion_ListEmployee != null && Radion_ListEmployee.Count > 0)
                {
                    for (int i = 0; i < Radion_ListEmployee.Count / 3; i++)
                    {
                        emplState = (from em in _dbContext.employeestates.ToList() where em.EmployeeID == Convert.ToInt32(Radion_ListEmployee[i * 3].EmployeeID) && em.Date.Day == dtNow.Day && 
                                         em.Date.Month == dtNow.Month && em.Date.Year == dtNow.Year select em).FirstOrDefault();
                        if (emplState != null)
                        {
                            emplState.Status = Radion_ListEmployee[i * 3].statusVaue;//Vì trạng thái giống nhau, nên chỉ lấy trạng thái đầu tiên
                            _dbContext.SaveChanges();
                        }
                        else
                        {
                            emplState = new employeestate();
                            emplState.EmployeeID = Convert.ToInt32(Radion_ListEmployee[i * 3].EmployeeID);
                            emplState.Status = Radion_ListEmployee[i* 3].statusVaue;
                            emplState.Date = DateTime.Now;
                            emplState.Notes = "";

                            _dbContext.employeestates.Add(emplState);
                            _dbContext.SaveChanges();

                        }
                    }
                }

                dlg_sologan = new DevExpress.Utils.WaitDialogForm("Đang cập nhật", "Vui lòng chờ...", new Size(160, 50));
                _timerCloseApp = new System.Threading.Timer(TimerCloseAppCallback, null, 500, System.Threading.Timeout.Infinite);

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


        int _default_max = 0;
        private void slookUpEdit_PlanWork_EditValueChanged(object sender, EventArgs e)
        {
            List<employee> employee;
            List<employeestate> employee_state;
            int line_y = 1;
            int line_x = 0;
            int loop = 0;

            try
            {
                Group_ListEmployee = new List<GroupControl>();
                Radion_ListEmployee = new List<EmployeeStatus>();

                groupControl_Employee.Text = "Danh sách nhân viên " + slookUpEdit_PlanWork.Text;

                //Chieu rong cua xtraScrollable cho phep chu toi da ban co kich thuoc 105x105
                int maxTable = xtraScrollable_EmployeeState.Width / 460;
                _default_max = maxTable;

                //Xóa nếu có
                if (xtraScrollable_EmployeeState.Controls.Count > 0)
                {
                    for (int i = 0; i < xtraScrollable_EmployeeState.Controls.Count; i++)
                    {
                        xtraScrollable_EmployeeState.Controls.RemoveByKey(xtraScrollable_EmployeeState.Controls[i].Name);
                        i--;
                    }
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                employee = (from emp in _dbContext.employees.ToList() where emp.Worktime == Convert.ToInt32(slookUpEdit_PlanWork.EditValue) && emp.EmployeeRight != CoffeeHelpers.EmpRight.Administrator.ToString() select emp).ToList();
                if (employee != null)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    _tbSource = new DataTable();

                    _tbSource.Columns.Add(_cEmployeeID, typeof(int));
                    _tbSource.Columns.Add(_cEmployeeName);

                    int emplCount = 0;
                    foreach (employee em in employee)
                    {

                        int i = 2;
                        if (loop == maxTable)
                        {
                            maxTable = _default_max * i;

                            line_x = 0;// Tra hoanh do ve 0
                            line_y = (line_y + 50) + 5;//Tung do tang len ban mot kich thuoc chieu cao cua hang truoc

                            //--Hang ban thu may
                            i++;
                        }

                        Group_Employee = new GroupControl();

                        Point p = new Point(((line_x) * 460) + 5, line_y);
                        Group_Employee.Location = p;
                        Group_Employee.Text = em.EmployeeName;
                        Group_Employee.Name = "Order" + em.EmployeeID;
                        Group_Employee.Tag = em.EmployeeID;
                        Group_Employee.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        Font f = new Font("times new roman", 11.0f, System.Drawing.FontStyle.Bold);
                        Group_Employee.AppearanceCaption.Font = f;
                        Group_Employee.AppearanceCaption.ForeColor = Color.Maroon;
                        Group_Employee.Width = 460;
                        Group_Employee.Height = 50;

                        string _text = "Đi làm";
                        for (int t = 0; t < 3; t++)
                        {
                            switch (t)
                            {
                                case 0:
                                    _text = "Đi làm";
                                    break;
                                case 1:
                                    _text = "Vắng có phép";
                                    break;
                                case 2:
                                    _text = "Vắng không phép";
                                    break;
                                default:
                                    _text = "Đi làm";
                                    break;
                            }

                            Radio_Employee = new RadioButton();
                            Point p1 = new Point((t * 150) + 5, 25);
                            Radio_Employee.Location = p1;
                            Radio_Employee.Width = 150;
                            Radio_Employee.Height = 20;
                            Radio_Employee.Text = _text;
                            Radio_Employee.Name = t + em.EmployeeID.ToString();

                            EmployeeStatus empl = new EmployeeStatus();
                            empl.EmployeeID = em.EmployeeID;
                            empl.Status = Radio_Employee;
                            empl.statusVaue = t;

                            Radion_ListEmployee.Add(empl);

                            if (t == 0)
                            {
                                Radio_Employee.Checked = true;
                            }

                            Radio_Employee.MouseUp += new MouseEventHandler(RadioEmployee_CheckedChange);//Sự kiện showpopup khi clcik

                            Group_Employee.Controls.Add(Radio_Employee);
                            if (t == 2)
                            {
                                employee_state = (from _emst in _dbContext.employeestates.ToList() 
                                                  where em.EmployeeID == _emst.EmployeeID &&
                                                      _emst.Date.Day == DateTime.Now.Day && _emst.Date.Month == DateTime.Now.Month && _emst.Date.Year == DateTime.Now.Year
                                                  select _emst).ToList();
                                if (employee_state != null && employee_state.Count > 0)
                                {
                                    foreach (employeestate _em in employee_state)
                                    {
                                        for (int j = 0; j < 3; j++)//Update cả 3 trạng thái trong list về giống nhau
                                        {
                                            if (Radion_ListEmployee[(emplCount * 3) + j].EmployeeID == _em.EmployeeID)
                                            {
                                                Radion_ListEmployee[(emplCount * 3) + j].statusVaue = _em.Status;
                                            }

                                            if (j == 2)
                                            {
                                                Radion_ListEmployee[(emplCount * 3) + _em.Status].Status.Checked = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        Group_ListEmployee.Add(Group_Employee);
                        xtraScrollable_EmployeeState.Controls.Add(Group_Employee);

                        Group_Employee.LookAndFeel.UseDefaultLookAndFeel = false;
                        Group_Employee.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

                        line_x++;// Tang hoanh do

                        // Lap so ban
                        loop++;

                        emplCount++;

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "slookUpEdit_PlanWork_EditValueChanged");
            }
        }

        private void RadioEmployee_CheckedChange(object sender, EventArgs e)
        {
            try
            {
                RadioButton em = sender as RadioButton;
                int status = Convert.ToInt32(em.Name.Substring(0, 1));
                int employeeID = Convert.ToInt32(em.Name.Substring(1));
                for (int i = 0; i < Radion_ListEmployee.Count / 3; i++)
                {
                    if (Radion_ListEmployee[(i * 3) + status].EmployeeID == employeeID)
                    {
                        for (int j = 0; j < 3; j++)//Update 3 trạng thái trong list của 1 nhân viên thành giống nhau
                        {
                            Radion_ListEmployee[(i * 3) + j].statusVaue = status;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "RadioEmployee_CheckedChange");
            }
        }

        #endregion

        /// <summary>
        /// Load danh sách trạng thái điểm danh
        /// </summary>
        public class EmployeeStatus
        {
            public int EmployeeID;
            public RadioButton Status;
            public int statusVaue;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelControl1_MouseDown(object sender, MouseEventArgs e)
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