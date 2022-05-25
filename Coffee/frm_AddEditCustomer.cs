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
    public partial class frm_AddEditCustomer : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public khachhang P_Customer { get; set; }
        public string _customer;

        public frm_AddEditCustomer()
        {
            InitializeComponent();
        }

        private void frm_AddEditCustomer_Load(object sender, EventArgs e)
        {
            int maxCode = 0;
            try
            {
                lbl_Customer.Text = _customer;

                //Load danh sách loại thẻ
                LoadSmartLink();

                maxCode = CoffeeHelpers.GetCustomerMaxCode();
                textEdit_BestLevel.Text="KH-00"+(maxCode);
                textEdit_NumberCard.Text = "KH-00" +(maxCode+1);
                if (P_Customer.MAKH == 0)//Add
                {
                    textEdit_BestLevel.Visible = false;
                    lbl_bestLevel.Visible = false;
                    textEdit_NumberCard.Enabled = false;
                    radioButton_CreateCard.Checked = true;
                    textEdit_Money.Enabled = false;
                    checkEdit_ChangeCode.Visible = false;
                }
                else
                {
                    textEdit_BestLevel.Visible = true;
                    lbl_bestLevel.Visible = true;
                    //textEdit_NumberCard.Enabled = true;
                    checkEdit_ChangeCode.Visible = true;

                    textEdit_CustomerName.Text = P_Customer.TENKH;
                    textEdit_NumberCard.Text = P_Customer.KHCode;
                    textEdit_Email.Text = P_Customer.Email;
                    textEdit_Phone.Text = P_Customer.SDT;
                    textEdit_Money.EditValue = string.Format("{0:#,#}",Convert.ToString(P_Customer.TotalMoney));
                    slookUpEdit_Level.EditValue = P_Customer.SmarkLink;

                    if (P_Customer.TINHTRANG == 1)
                    {
                        radioButton_CreateCard.Checked = true;
                    }
                    else
                    {
                        radioButton_LockCard.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditCustomer_Load");
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

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(textEdit_CustomerName.Text) == true)
                {
                    XtraMessageBox.Show("Vui lòng đặt tên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(slookUpEdit_Level.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn cấp bậc thẻ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (checkEdit_ChangeCode.Checked == true)
                {
                    if (checkExistSmartLink(textEdit_NumberCard.Text) == true)
                    {
                        XtraMessageBox.Show("Mã thẻ đã bị trùng. Vui lòng tham khảo mã thẻ cao nhất bên phải", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                
                P_Customer.KHCode = textEdit_NumberCard.Text;
                P_Customer.TENKH = textEdit_CustomerName.Text;
                P_Customer.Email = textEdit_Email.Text;
                P_Customer.SDT = textEdit_Phone.Text;
                P_Customer.TotalMoney =Convert.ToDecimal(textEdit_Money.EditValue);
                P_Customer.SmarkLink =Convert.ToInt32(slookUpEdit_Level.EditValue);
                if (radioButton_CreateCard.Checked == true)
                {
                    P_Customer.TINHTRANG = 1;
                }
                else
                {
                    P_Customer.TINHTRANG = 2;
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Save_Click");
            }
        }

        //Load danh sách cấp bậc thẻ
        private void LoadSmartLink()
        {
            DataTable tbSource;
            DataRow row;
            List<smartlink> links;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add("SmartLinkID");
                tbSource.Columns.Add("SmartLinkName");
                tbSource.Columns.Add("MoneyLevel");
                tbSource.Columns.Add("Percent");


                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                links=(from lk in _dbContext.smartlinks select lk).ToList();
                if(links!=null && links.Count>0)
                {
                    foreach(smartlink l in links)
                    {
                        row = tbSource.NewRow();
                        row["SmartLinkID"] = l.ID;
                        row["SmartLinkName"]=l.SmarkLink;
                        row["MoneyLevel"]=l.LevelMoney;
                        row["Percent"] = l.Percent_SmarkLink;

                        tbSource.Rows.Add(row);
                    }
                    row = tbSource.NewRow();
                    row["SmartLinkID"] = -1;
                    row["SmartLinkName"] = "Chọn mức...";
                    tbSource.Rows.InsertAt(row, 0);

                    slookUpEdit_Level.Properties.DisplayMember = "SmartLinkName";
                    slookUpEdit_Level.Properties.ValueMember = "SmartLinkID";
                    slookUpEdit_Level.Properties.DataSource = tbSource;
                    slookUpEdit_Level.EditValue = -1;
                }

                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadSmartLink");
            }
        }

        //Kiểm tra tồn tại mã thẻ
        private bool checkExistSmartLink(string NumberCard)
        {
            List<khachhang> khs;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                khs = (from sm in _dbContext.khachhangs select sm).ToList();
                if (khs != null && khs.Count > 0)
                {
                    foreach (khachhang m in khs)
                    {
                        if (m.KHCode== NumberCard.Trim())
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Close_Click");
                return false;
            }
        }

        private void checkEdit_ChangeCode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit_ChangeCode.Checked == true)
                {
                    textEdit_NumberCard.Enabled = true;
                }
                else
                {
                    textEdit_NumberCard.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkEdit_ChangeCode_CheckedChanged");
            }
        }

        private void slookUpEdit_Level_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            smartlink smartlinks;
            frm_AddEditCustomerSkin dlg;
            try
            {
                if (e.Button.Index != slookUpEdit_Level.Properties.Buttons[1].Index)
                {
                    return;
                }
                dlg = new frm_AddEditCustomerSkin();
                smartlinks = new smartlink();
                dlg.P_SmartLink = smartlinks;
                dlg.Text = "Thêm Loại Thành Viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.smartlinks.Add(dlg.P_SmartLink);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "slookUpEdit_Level_Properties_ButtonClick");
            }
        }

        // Di chuyển form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelControl2_MouseDown(object sender, MouseEventArgs e)
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