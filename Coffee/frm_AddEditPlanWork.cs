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
    public partial class frm_AddEditPlanWork : DevExpress.XtraEditors.XtraForm
    {
        public planwork P_Planwork { get; set; }

        public frm_AddEditPlanWork()
        {
            InitializeComponent();
        }

        private void frm_AddEditPlanWork_Load(object sender, EventArgs e)
        {
            try
            {
                LoadInfomationPlanWork();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditPlanWork_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit_PlanWorkName.EditValue==null)
                {
                    XtraMessageBox.Show("Vui lòng khai báo tên ca làm việc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (timeEdit_Start.Time > timeEdit_End.Time)
                {
                    XtraMessageBox.Show("Thời gian bắt đầu phải nhỏ hơn kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                P_Planwork.PlanWorkName = textEdit_PlanWorkName.EditValue.ToString();
                P_Planwork.StartTime = timeEdit_Start.Text;
                P_Planwork.EndTime = timeEdit_End.Text;
                P_Planwork.Notes= memoEdit_Notes.Text;
                if (radioButton_Running.Checked == true)
                {
                    P_Planwork.Status = 1;//Đang dùng
                }
                else
                {
                    P_Planwork.Status = 2;
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

        /// <summary>
        /// Load thông tin product vào control editor
        /// </summary>
        private void LoadInfomationPlanWork()
        {
            try
            {
                if (P_Planwork.PlanWorkID != 0)
                {
                    textEdit_PlanWorkName.EditValue = P_Planwork.PlanWorkName;
                    timeEdit_Start.EditValue = P_Planwork.StartTime;
                    timeEdit_End.EditValue = P_Planwork.EndTime;
                    memoEdit_Notes.Text = P_Planwork.Notes;
                    if (P_Planwork.Status == 1)
                    {
                        radioButton_Running.Checked = true;
                    }
                    else
                    {
                        radioButton_Stop.Checked = true;
                    }
                    if (P_Planwork.SystemKey == 1)
                    {
                        radioButton_Stop.Enabled = false;
                        radioButton_Running.Enabled = false;
                    }
                }
                else
                {
                    radioButton_Running.Checked = true;//Đang dùng
                    radioButton_Running.Enabled = false;
                    radioButton_Stop.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadInfomationPlanWork");
            }
        }

        // Di chuyển form
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