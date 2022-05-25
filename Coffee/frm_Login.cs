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
    public partial class frm_Login : DevExpress.XtraEditors.XtraForm
    {
        private bool _isLogout = false;

        public bool _LogOut { get; set; }
        public bool _changEmployeeCode { get; set; }
        public string _savePassWord { get; set; }
        public string _saveCodeLogin { get; set; }
        public CoffeeHelpers.Config _Config { get; set; }
        public string lbl_Register { get; set; }


        private int _countWrongPassWord_Lock = 0;

        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            try
            {
                if (_isLogout)
                {
                    //--- Nếu là mở form khi user bấm giao ca thì không fill employeeCode từ biến WinCounterHelpers.EmployeeLogin
                    return;
                }
                if (CoffeeHelpers.EmpLogin != null && _LogOut != true)
                {
                    textEdit_UserName.Text = CoffeeHelpers.EmpLogin.EmployeeCode;
                    textEdit_UserName.Enabled = false;
                }
                else
                {
                    textEdit_UserName.EditValue = null;
                    textEdit_UserName.Enabled = true;
                }

                //Chưa kích hoạt chức năng nhớ mật khẩu
                if (_Config.SavePass == false)
                {
                    checkEdit_Remember.Enabled = false;
                }

                lbl_Trial.Text = lbl_Register;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Login_Load");
            }
        }

        private void LogIn()
        {
            mycoffeeEntities dbContext;
            frm_SQLConfig dlg;
            employee employee;
            CoffeeHelpers.EmployeeLogin employeeLogin;
            string userName;
            string realpassword;

            try
            {
                if (string.IsNullOrEmpty(textEdit_UserName.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập vào tên đăng nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_UserName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textEdit_Password.Text))
                {
                    XtraMessageBox.Show("Vui lòng nhập vào mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_Password.Focus();
                    return;
                }

                //--- Kiểm tra kết nối Database
                if (!CoffeeHelpers.TestConnect(CoffeeHelpers.ConnectionString))
                {
                    XtraMessageBox.Show("Không thể kết nối vào Server Database, vui lòng cấu hình lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //--- Hiển thị form cấu hình
                    dlg = new frm_SQLConfig();
                    if (dlg.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                userName = textEdit_UserName.Text;
                _saveCodeLogin = userName.Trim();

                dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                employee = dbContext.employees.Where(e => e.EmployeeCode == userName).FirstOrDefault();
                if (employee == null)
                {
                    XtraMessageBox.Show("Tên đăng nhập không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textEdit_UserName.Focus();
                    return;
                }

                //realpassword = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(employee.Password));
                //_savePassWord = realpassword;
                if (employee.Password == textEdit_Password.Text)
                {
                    employeeLogin = new CoffeeHelpers.EmployeeLogin();
                    employeeLogin.EmployeeID = employee.EmployeeID;
                    employeeLogin.EmployeeCode = employee.EmployeeCode;
                    employeeLogin.EmployeeName = employee.EmployeeName;
                    employeeLogin.EmployeeRight = employee.EmployeeRight;
                    employeeLogin.EmpRight = CoffeeHelpers.GetEmpRight(employee);

                    if (employee.Locked == 2)
                    {
                        XtraMessageBox.Show("Tài khoản của bạn đã bị khóa. Liên hệ quản lý để mở khóa ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (employee.ChangeEmployeeCode == 1)
                    {
                        _changEmployeeCode = true;
                    }
                    else
                    {
                        _changEmployeeCode = false;
                    }

                    //--- Chỉ khi nào user giao ca hoặc khi mở chương trình lên thì mới cập nhật lại biến EmployeeLogin
                    if (_isLogout == true || CoffeeHelpers.EmpLogin == null)
                    {
                        CoffeeHelpers.EmpLogin = employeeLogin;
                    }

                    this.DialogResult = DialogResult.OK;
                    _LogOut = false;
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Mật khẩu không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textEdit_Password.Focus();
                    _countWrongPassWord_Lock++;
                }
                if (_countWrongPassWord_Lock == 3)
                {
                    employee.Locked = 2;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Login");
            }
        }

        private void frm_Login_SizeChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    this.Size = new Size(600,400);
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, "frm_Login_SizeChanged");
            //}
        }

        private void checkEdit_Remember_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_Config.SavePass == false)
                {
                    XtraMessageBox.Show("Vui lòng liên hệ quản trị hệ thống để kích hoạt chức năng nhớ mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkEdit_Remember_CheckedChanged");
            }
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            try
            {
                LogIn();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Login_Click");
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

        private void checkEdit_Hide_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit_Hide.Checked)
                {
                    this.WindowState = FormWindowState.Minimized;
                    checkEdit_Hide.Checked = false;
                }
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

        private void frm_Login_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "frm_Login_MouseDown");
            }
        }

        private void frm_Login_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    LogIn();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Login_KeyDown");
            }
        }

        private void textEdit_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    LogIn();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_UserName_KeyDown");
            }
        }

        private void textEdit_Password_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    LogIn();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_Password_KeyDown");
            }
        }
    }
}