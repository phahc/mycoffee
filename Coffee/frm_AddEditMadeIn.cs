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
using Coffee.Utils;

namespace Coffee
{
    public partial class frm_AddEditMadeIn : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private mycoffeeEntities _dbContext;
        public madein P_madein { get; set; }
        #endregion

        #region Form Method
        public frm_AddEditMadeIn()
        {
            InitializeComponent();
        }

        private void frm_MadeIn_Load(object sender, EventArgs e)
        {
            try
            {
                if (P_madein.MadeInID != 0)
                {
                    LoadMadeIn();
                }
                else
                {
                    textEdit_ShortName.Text = "NCC-00" + CoffeeHelpers.GetNCCMaxCode() + 1;
                    radioButton_Running.Checked = true;//Đang dùng
                    radioButton_Running.Enabled = false;
                    radioButton_Stop.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_MadeIn_Load");
            }
        }
        #endregion

        #region Helpers
        //Load dữ liệu xuất xứ cần sửa
        private void LoadMadeIn()
        {
            try
            {
                textEdit_MadeIn.Text = P_madein.MadeInName.ToString();
                textEdit_ShortName.Text = P_madein.ShortName.ToString();
                if (P_madein.Status == 1)
                {
                    radioButton_Running.Checked = true;
                }
                else
                {
                    radioButton_Stop.Checked = true;
                }
                if (P_madein.SystemKey == 1)
                {
                    radioButton_Running.Enabled = false;
                    radioButton_Stop.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadMadeIn");
            }
        }
        #endregion

        #region Actions
        private void button_Save_Click(object sender, EventArgs e)
        {
            bool checkUpdate = false;
            try
            {
                if (P_madein.MadeInID != 0)//Update
                {
                    checkUpdate = true;
                }
                if (textEdit_MadeIn.Text == "")
                {
                    XtraMessageBox.Show("Tên nhà cung cấp trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (textEdit_ShortName.Text == "")
                {
                    XtraMessageBox.Show("Tên viết tắt trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (checkUpdate == false)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    madein _madein = (from m in _dbContext.madeins.ToList() where m.ShortName == textEdit_ShortName.Text select m).FirstOrDefault();

                    if (_madein != null)
                    {
                        XtraMessageBox.Show("Tên nhà cung cấp đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                P_madein.MadeInName = textEdit_MadeIn.Text.Trim();
                P_madein.ShortName = textEdit_ShortName.Text.Trim();
                if (radioButton_Running.Checked == true)
                {
                    P_madein.Status = 1;//Đang dùng
                }
                else
                {
                    P_madein.Status = 2;
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
        #endregion    

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