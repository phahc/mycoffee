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
    public partial class frm_ChangePassWord : DevExpress.XtraEditors.XtraForm
    {
        public frm_ChangePassWord()
        {
            InitializeComponent();
        }

        private void frm_ChangePassWord_Load(object sender, EventArgs e)
        {

        }

        private void ChangePassword()
        {
            employee employee;
            mycoffeeEntities dbContext;

            try
            {
                if (string.IsNullOrEmpty(textEdit_NewPass.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng nhập vào mật khẩu mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_NewPass.Focus();
                    return;
                }
                if (textEdit_NewPass.Text.Length<6)
                {
                    XtraMessageBox.Show("Mật khẩu mới quá ngắn. Vui lòng nhập vào mật khẩu mới ít nhất 6 kí tự", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_NewPass.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textEdit_ConfirmNewPass.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng nhập vào xác nhận mật khẩu mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_ConfirmNewPass.Focus();
                    return;
                }
                if (textEdit_NewPass.Text != textEdit_ConfirmNewPass.Text)
                {
                    XtraMessageBox.Show("Xác nhận mật khẩu mới không đúng, vui lòng đánh lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                employee = dbContext.employees.Where(e => e.EmployeeID == CoffeeHelpers.EmpLogin.EmployeeID).FirstOrDefault();
                if (employee == null)
                    return;

                if (employee.Password == null)
                    employee.Password = "";

                string realpassword = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(employee.Password));
                if (realpassword != textEdit_OldPass.Text)
                {
                    XtraMessageBox.Show("Mật khẩu cũ không chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textEdit_OldPass.Focus();
                    return;
                }
                else
                {
                    byte[] bytes = CoffeeHelpers.ScramblePassword.Encode(textEdit_NewPass.Text);
                    employee.Password = Encoding.Unicode.GetString(bytes);

                    try
                    {
                        dbContext.SaveChanges();
                        XtraMessageBox.Show("Thay đổi mật khẩu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Thay đổi mật khẩu thất bại" + Environment.NewLine + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ChangePassword");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                ChangePassword();
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