using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_EmployeeInformation : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public string _employeeCode { get; set; }


        public frm_EmployeeInformation()
        {
            InitializeComponent();
        }

        private void frm_EmployeeInformation_Load(object sender, EventArgs e)
        {
            employee emp;
            try
            {

                emp = (from em in _dbContext.employees.ToList() where em.EmployeeCode == _employeeCode select em).FirstOrDefault();

                if (emp != null)
                {
                    lbl_EmployeeName.Text = emp.EmployeeName;
                    lbl_EmployeeLogin.Text = emp.EmployeeCode;
                    lbl_Right.Text = emp.EmployeeRight;
                    lbl_Sex.Text = emp.Sex;
                    lbl_Salary.Text = emp.Salary.ToString();
                    lbl_PlankWork.Text = emp.planwork.PlanWorkName;
                    lbl_Phone.Text = emp.Telephone.ToString();
                    lbl_Email.Text = emp.Email;
                    lbl_DateWork.Text = emp.EmployeeDate.Value.ToString("dd/MM/yyyy");
                    lbl_Birthday.Text = emp.Birthday.Value.ToString("dd/MM/yyyy");
                    if (emp.Locked == 1)
                    {
                        lbl_Locked.Text = "Đang kích hoạt";
                    }
                    else
                    {
                        lbl_Locked.Text = "Đã khóa";
                    }
                    textEdit_Address.Text = emp.Address.ToString();
                    memoEdit_Notes.Text = emp.Notes;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_EmployeeInformation_Load");
            }
        }

        private void frm_EmployeeInformation_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.Size = new Size(665, 350);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_EmployeeInformation_SizeChanged");
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

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frm_EmployeeInformation_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "frm_EmployeeInformation_MouseDown");
            }
        }
    }
}