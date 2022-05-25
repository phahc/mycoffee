using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_Company : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public company P_Company { get; set; }
        public frm_Company()
        {
            InitializeComponent();
        }

        private void frm_Company_Load(object sender, EventArgs e)
        {
            try
            {
                textEdit_CompanyName.Text = P_Company.CompanyName;
                memoEdit_Address.Text = P_Company.Address;
                textEdit_Fax.Text = P_Company.Fax;
                textEdit_Tel.Text = P_Company.Phone;
                textEdit_MSThue.Text = P_Company.MaSoThue;
                timeEdit_From.EditValue= P_Company.StartTime;
                timeEdit_To.EditValue = P_Company.EndTime;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Company_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                P_Company.CompanyName = textEdit_CompanyName.Text;
                P_Company.Address = memoEdit_Address.Text;
                P_Company.Phone = textEdit_Tel.Text;
                P_Company.Fax = textEdit_Fax.Text;
                P_Company.MaSoThue = textEdit_MSThue.Text;
                P_Company.StartTime = timeEdit_From.Time;
                P_Company.EndTime = timeEdit_To.Time;

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