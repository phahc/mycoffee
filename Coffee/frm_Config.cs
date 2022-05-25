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
    public partial class frm_Config : DevExpress.XtraEditors.XtraForm
    {
        string[] arr_ColorCode = { "Office 2010 Silver", "Caramel", "Stardust", "Dark Side", "Darkroom", "Office 2010 Black", "Pumpkin", "Money Twins", "Office 2010 Blue", "Office 2007 Blue", "Glass Oceans", "Office 2007 Green", "Xmas 2008 Blue", "Liquid Sky", "Summer 2008", "Springtime", "Valentine", "Office 2007 Pink", "London Liquid Sky", "McSkin", "The Asphalt World" };
        string[] arr_ColorName = { "Bạc", "Nâu", "Sương mù", "Đen bóng", "Đen 1", "Đen Office 2010", "Đen 2", "Xanh dương", "Xanh Office 2010", "Xanh Office 2007", "Màu biển", "Xanh lá Office 2007", "Xanh tuyết", "Màu trời", "Mùa hè", "Xanh lá nhạt", "Valentine", "Hồng Office 2007", "Xám mây(Mặc định)", "Xám 1", "Xám 2" };

        public frm_Config()
        {
            InitializeComponent();
        }

        private void frm_Config_Load(object sender, EventArgs e)
        {
            CoffeeHelpers.Config config;
            try
            {
                // Ổ đĩa trừ ổ hệ thống
                string[] drives = System.IO.Directory.GetLogicalDrives();
                //--- Trừ ổ đĩa hệ thống
                if (drives != null)
                {
                    textEdit_PathFileReport.Text = drives[1].ToString();
                }


                // Load danh sách màu sắc
                LoadApplicationColor();

                config = CoffeeHelpers.LoadConfig();

                if (config == null)
                {
                    XtraMessageBox.Show("Cấu hình thông số hệ thống chưa được khai báo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    for (int i = 0; i < arr_ColorCode.Length; i++)
                    {
                        if (arr_ColorCode[i].Contains(config.ApplicationColor.Trim()) == true)
                        {
                            slookUpEdit_Color.EditValue = i;
                            break;
                        }
                    }   
                    spinEdit_MaxArea.Text = config.MaxArea.ToString();
                    textEdit_PathFileReport.Text = config.PathFileReport;
                    textEdit_PrintReportAtTime.Text = config.PrintReportAtTime.ToString();
                    textEdit_MailServer.Text = config.MailServer.ToString();
                    textEdit_MailServerPort.Text = config.MailServerPort.ToString();
                    textEdit_SenderMail.Text = config.SenderMail.ToString();
                    textEdit_MailPassword.Text = config.MailPassword.ToString();
                    textEdit_Title.Text = config.Title.ToString();
                    memoEdit_Content.Text = config.Content.ToString();
                    UseSSL.Checked = config.UseSSL;
                    checkEdit_GhiNo.Checked = config.Tally;
                    checkEdit_SavePass.Checked = config.SavePass;
                    checkEdit_ShowPlanMoney.Checked = config.ShowPlanMoney;
                    checkEdit_ShowDetailPlan.Checked = config.ShowDetailPlan;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Config_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            CoffeeHelpers.Config config;
            try
            {
                if (Convert.ToInt32(slookUpEdit_Color.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn màu cho ứng dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                config = new CoffeeHelpers.Config();

                //--- Save new Config
                config.MaxArea= Convert.ToInt32(spinEdit_MaxArea.Value);
                config.ApplicationColor =arr_ColorCode[Convert.ToInt32(slookUpEdit_Color.EditValue)];
                config.PathFileReport = textEdit_PathFileReport.Text;
                config.PrintReportAtTime = CoffeeHelpers.ParseTimeSpan(textEdit_PrintReportAtTime.Text);
                config.MailServer = textEdit_MailServer.Text.Trim();
                config.MailServerPort = Convert.ToInt32(textEdit_MailServerPort.Text);
                config.SenderMail = textEdit_SenderMail.Text.Trim();
                config.MailPassword = textEdit_MailPassword.Text.Trim();
                config.Title = textEdit_Title.Text.Trim();
                config.Content = memoEdit_Content.Text.Trim();
                config.UseSSL = UseSSL.Checked;
                config.Tally = checkEdit_GhiNo.Checked;
                config.SavePass = checkEdit_SavePass.Checked;
                config.ShowPlanMoney = checkEdit_ShowPlanMoney.Checked;
                config.ShowDetailPlan = checkEdit_ShowDetailPlan.Checked;

                CoffeeHelpers.SaveConfig(config);
                CoffeeHelpers.Conf = config;
                XtraMessageBox.Show("Lưu cấu hình thông số hệ thống thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        //Tạo danh sách màu cho ứng dụng
        private void LoadApplicationColor()
        {
            DataTable tbSource;
            DataRow newRow;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add("ID", typeof(int));
                tbSource.Columns.Add("Code");
                tbSource.Columns.Add("Name");

                for (int i = 0; i < arr_ColorCode.Length; i++)
                {
                    newRow = tbSource.NewRow();
                    newRow["ID"]=i.ToString();
                    newRow["Code"] = arr_ColorCode[i].Trim();
                    newRow["Name"] = arr_ColorName[i].Trim();

                    tbSource.Rows.Add(newRow);
                }
                newRow = tbSource.NewRow();
                newRow["ID"] = 0;
                newRow["Code"] = arr_ColorCode[0].Trim();
                newRow["Name"] = arr_ColorName[0].Trim();
                tbSource.Rows.InsertAt(newRow, 0);

                slookUpEdit_Color.Properties.DisplayMember = "Name";
                slookUpEdit_Color.Properties.ValueMember = "ID";
                slookUpEdit_Color.Properties.DataSource = tbSource;
                slookUpEdit_Color.EditValue = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"LoadApplicationColor");
            }
        }

        private void button_Browser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderWindows;

            try
            {
                folderWindows = new FolderBrowserDialog();
                folderWindows.ShowNewFolderButton = false;
                folderWindows.Description = "Chọn đường dẫn chứa báo cáo...";
                folderWindows.RootFolder = Environment.SpecialFolder.Desktop;

                if (folderWindows.ShowDialog() == DialogResult.OK)
                {
                    textEdit_PathFileReport.Text = folderWindows.SelectedPath + "\\";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Browser_Click");
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