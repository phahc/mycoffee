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
    public partial class frm_AddEditMailReceiver : DevExpress.XtraEditors.XtraForm
    {

        #region Fields

        public mycoffeeEntities _dbContext;
        private const int _size = 30;
        private const string _smsAutoSendDateDefault = "00:00:00";

        #endregion //--- Fields

        #region Properties

        public mailreceiver P_MailReceiver { get; set; }

        #endregion //--- Properties

        public frm_AddEditMailReceiver()
        {
            InitializeComponent();
        }

        private void frm_AddEditMailReceiver_Load(object sender, EventArgs e)
        {
            try
            {
                checkEdit_AutoSend_CheckedChanged(null, null);
                //--- Load thông tin MailReceiver vào control editor
                LoadMailReceiver();

                if (!string.IsNullOrEmpty(P_MailReceiver.Email)) //--- Update
                {
                    textEdit_EMail.Properties.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frmAddEditMailReceiver_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            bool checkExistMailReceiver = true;
            string email, name;
            DateTime dtNow;
            TimeSpan ts;

            try
            {
                dtNow = DateTime.Now;
                email = textEdit_EMail.Text.Trim();
                name = textEdit_Name.Text.Trim();

                if (string.IsNullOrEmpty(email))
                {
                    XtraMessageBox.Show("Vui lòng nhập vào địa chỉ email nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_EMail.Focus();
                    return;
                }
                if (!string.IsNullOrEmpty(P_MailReceiver.Email)) //--- Update
                {
                    if (P_MailReceiver.Email != email) //--- User thay đổi email
                        checkExistMailReceiver = true;
                    else
                        checkExistMailReceiver = false;
                }
                if (checkExistMailReceiver == true)
                {
                    if (CheckExistMailReceiver(email) == true) //--- Tồn tại email trong db
                    {
                        XtraMessageBox.Show("Địa chỉ email nhận đã bị trùng. Vui lòng đánh vào địa chỉ email khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textEdit_EMail.Focus();
                        return;
                    }
                }
                if (string.IsNullOrEmpty(name))
                {
                    XtraMessageBox.Show("Vui lòng nhập vào tên người nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_Name.Focus();
                    return;
                }

                P_MailReceiver.Email = email;
                P_MailReceiver.Name = name;
                P_MailReceiver.AutoSend = 1;
                if (checkEdit_AutoSend.Checked == true)
                {
                    ts = CoffeeHelpers.ParseTimeSpan(textEdit_AutoSendDate.Text.Trim());
                    P_MailReceiver.AutoSendDate = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, ts.Hours, ts.Minutes, ts.Seconds);
                }
                else
                {
                    P_MailReceiver.AutoSendDate = null;
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

        private void checkEdit_AutoSend_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit_AutoSend.Checked == true)
                {
                    labelControl_AutoSendDate.Visible = true;
                    textEdit_AutoSendDate.Visible = true;
                    button_Save.Location = new Point(button_Save.Location.X, button_Save.Location.Y + _size);
                    button_Close.Location = new Point(button_Close.Location.X, button_Close.Location.Y + _size);
                    this.Size = new Size(this.Size.Width, this.Size.Height + _size);
                }
                else //--- checkEdit_AutoSend.Checked == false
                {
                    labelControl_AutoSendDate.Visible = false;
                    textEdit_AutoSendDate.Visible = false;
                    button_Save.Location = new Point(button_Save.Location.X, button_Save.Location.Y - _size);
                    button_Close.Location = new Point(button_Close.Location.X, button_Close.Location.Y - _size);
                    this.Size = new Size(this.Size.Width, this.Size.Height - _size);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkEdit_AutoSend_CheckedChanged");
            }
        }


        #region --- Helper ---

        /// <summary>
        /// Load thông tin mailReceiver vào control editor
        /// </summary>
        private void LoadMailReceiver()
        {
            try
            {
                textEdit_EMail.Text = P_MailReceiver.Email;
                textEdit_Name.Text = P_MailReceiver.Name;
                if (P_MailReceiver.AutoSend == 1)
                {
                    checkEdit_AutoSend.Checked = true;
                }
                else
                {
                    checkEdit_AutoSend.Checked = false;
                }
                textEdit_AutoSendDate.Text = P_MailReceiver.AutoSendDate.HasValue ? P_MailReceiver.AutoSendDate.Value.ToString("HH:mm:ss") : _smsAutoSendDateDefault;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadMailReceiver");
            }
        }

        /// <summary>
        /// Kiểm tra tồn tại MailReceiver
        /// </summary>
        /// <param name="email"></param>
        /// <returns> true: Tồn tại, false: Không tồn tại </returns>
        private bool CheckExistMailReceiver(string email)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var mailReceivers = from mr in _dbContext.mailreceivers where mr.Email == email select mr;
                if (mailReceivers == null || mailReceivers.Count() == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CheckExistMailReceiver");
                return false;
            }
        }

        #endregion //--- Helper ---

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