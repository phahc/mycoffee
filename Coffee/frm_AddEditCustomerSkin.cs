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
    public partial class frm_AddEditCustomerSkin : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public smartlink P_SmartLink { get; set; }


        public frm_AddEditCustomerSkin()
        {
            InitializeComponent();
        }

        private void frm_AddEditCustomerSkin_Load(object sender, EventArgs e)
        {
            try
            {
                if (P_SmartLink.ID == 0)
                {
                    radioButton_Use.Checked = true;
                }
                else
                {
                    textEditSmartLinkName.Text = P_SmartLink.SmarkLink;
                    textEdit_MoneyLevel.EditValue = P_SmartLink.LevelMoney;
                    textEdit_Percent.EditValue = P_SmartLink.Percent_SmarkLink;
                    if (P_SmartLink.Status == 1)
                    {
                        radioButton_Use.Checked = true;
                    }
                    else
                    {
                        radioButton_NotUse.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditCustomerSkin_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (P_SmartLink.ID == 0)
                {
                    if (checkExistName(textEditSmartLinkName.Text) == true)
                    {
                        XtraMessageBox.Show("Tên phân loại đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (string.IsNullOrEmpty(textEditSmartLinkName.Text) == true)
                {
                    XtraMessageBox.Show("Vui lòng đặt tên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(textEdit_MoneyLevel.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng đặt mức tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(textEdit_Percent.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng đặt phần trăm chiết khấu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                P_SmartLink.SmarkLink = textEditSmartLinkName.Text;
                P_SmartLink.LevelMoney =Convert.ToDecimal(textEdit_MoneyLevel.EditValue);
                P_SmartLink.Percent_SmarkLink = Convert.ToDouble(textEdit_Percent.EditValue);

                if (radioButton_Use.Checked == true)
                {
                    P_SmartLink.Status = 1;
                }
                else
                {
                    P_SmartLink.Status = 2;
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

        //Kiểm tra trùng tên
        private bool checkExistName(string name)
        {
            List<smartlink> smartLinks;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                smartLinks=(from sm in _dbContext.smartlinks select sm).ToList();
                if(smartLinks!=null && smartLinks.Count>0)
                {
                    foreach (smartlink m in smartLinks)
                    {
                        if (m.SmarkLink == name.Trim())
                        {
                            return true;
                        }
                    }
                    return false;
                }else{
                    return false;
               }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Close_Click");
                return false;
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

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }
    }
}