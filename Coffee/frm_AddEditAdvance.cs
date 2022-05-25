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
    public partial class frm_AddEditAdvance : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public advancemoney P_Advance { get; set; }
        private DateTime dtNow;

        public frm_AddEditAdvance()
        {
            InitializeComponent();
        }

        private void frm_AddEditAdvance_Load(object sender, EventArgs e)
        {
            try
            {
                dtNow = DateTime.Now;
                if (P_Advance.EmployeeID == 0)//Add
                {
                    dateEdit_Date.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

                }
                else
                {
                    dateEdit_Date.DateTime = P_Advance.Date;
                    textEdit_Reason.EditValue = P_Advance.Reason;
                    textEdit_Money.EditValue = P_Advance.Advance_Money;
                    memoEdit_Notes.EditValue = P_Advance.Notes;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditAdvance_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                if (textEdit_Money.Text == "" || Convert.ToInt32(textEdit_Money.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng nhập số tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                P_Advance.Date = dateEdit_Date.DateTime;
                P_Advance.Advance_Money = Convert.ToDecimal(textEdit_Money.EditValue);
                P_Advance.Notes = memoEdit_Notes.Text;
                P_Advance.Reason = textEdit_Reason.Text;
                
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