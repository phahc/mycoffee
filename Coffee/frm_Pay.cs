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
using Coffee.DataSet;
using Coffee.Reports;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraReports.UI;
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_Pay : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public DataSet_HoaDonThanhToan ds;
        public decimal P_TotalMoney { get; set; }
        public decimal P_ReturnMoney { get; set; }
        public decimal P_CustomerMoney { get; set; }
        public decimal P_ChietKhau { get; set; }
        public decimal P_Promote { get; set; }
        public decimal P_MustPay { get; set; }
        public string P_OrderCode { get; set; }
        public string P_TableName { get; set; }
        public company P_Company { get; set; }
        public CoffeeHelpers.Config _config { get; set; }
        public string P_KHCode { get; set; }
        public bool checkCustomer { get; set; }

        public string P_Notes { get; set; }

        decimal moneys = 0;

        public frm_Pay()
        {
            InitializeComponent();
        }

        private void frm_Pay_Load(object sender, EventArgs e)
        {
            try
            {
                P_MustPay = P_TotalMoney - P_Promote;

                textEdit_Pay.EditValue = string.Format("{0:#,#}", P_TotalMoney);
                textEdit_Promote.EditValue = string.Format("{0:#,#}", P_Promote);
                textEdit_MustPay.EditValue = string.Format("{0:#,#}", P_MustPay);
                textEdit_MoneyCostumer.EditValue = string.Format("{0:#,#}", "0");

                lbl_TablePay.Text = P_TableName;

                //Chưa kích hoạt chức năng ghi nợ
                if (_config.Tally == false)
                {
                    checkEdit_Tally.Visible = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Pay_Load");
            }
        }

        private void frm_Pay_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit_SmarkLink.Checked == true)
                {
                   // this.Size = new Size(452, 350);
                }
                else
                {
                   // this.Size = new Size(452, 230);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Pay_SizeChanged");
            }
        }

        private void checkEdit_SmarkLink_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                checkCustomer = checkEdit_SmarkLink.Checked;

                if (checkEdit_SmarkLink.Checked == true)
                {
                    textEdit_CustomerID.Enabled = true;
                    btn_listCustomer.Visible = true;
                }
                else
                {
                    textEdit_CustomerID.Text = "";
                    textEdit_CustomerID.Enabled = false;
                    btn_listCustomer.Visible = false;
                    
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkEdit_Notes_CheckedChanged");
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textEdit_Return.EditValue) < 0 && checkEdit_Tally.Checked==false)
                {
                    if (XtraMessageBox.Show("Khách hàng trả thiếu tiền. Bạn muốn thanh toán đơn hàng này không ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                if (lbl_Owner.Text == "Không rõ" && checkEdit_SmarkLink.Checked==true)
                {
                    XtraMessageBox.Show("Khách hàng này chưa có thẻ thành viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
          
                P_ReturnMoney = Convert.ToDecimal(P_ReturnMoney);
                P_CustomerMoney = Convert.ToDecimal(textEdit_MoneyCostumer.EditValue);
                P_KHCode = textEdit_CustomerID.Text;
                P_MustPay = Convert.ToDecimal(textEdit_MustPay.EditValue);
                P_ChietKhau = Convert.ToDecimal(lbl_Percent.Text);

                //In hoá đơn thanh toán
                SetReportSource(ds);

                DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_OK_Click");
            }
        }

        private void textEdit_MoneyCostumer_EditValueChanged(object sender, EventArgs e)
        {
            khachhang kh;
            decimal _defaultMoney = 0;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                P_CustomerMoney = Convert.ToDecimal(textEdit_MoneyCostumer.EditValue);
                P_ReturnMoney =( Convert.ToDecimal(textEdit_MoneyCostumer.EditValue) - P_MustPay)+ Convert.ToDecimal(lbl_Percent.Text);
                textEdit_Return.EditValue = string.Format("{0:#,#}", P_ReturnMoney);


                if (P_ReturnMoney < 0)
                {
                    btn_OK.Enabled = false;
                }
                else
                {
                    btn_OK.Enabled = true;
                }

                if (checkEdit_SmarkLink.Checked == true)
                {
                    btn_OK.Enabled = true;
                    moneys = 0;
                    kh = (from k in _dbContext.khachhangs.ToList() where k.KHCode == textEdit_CustomerID.Text.Trim() && k.TINHTRANG == 1 select k).FirstOrDefault();
                    if (kh != null)
                    {
                        lbl_Owner.Text = kh.TENKH;
                        lbl_Skin.Text = kh.smartlink.SmarkLink;

                        moneys = (P_MustPay * (decimal)kh.smartlink.Percent_SmarkLink) / 100;//Chiết khấu từ số tiền phải thu chứ không phải tổng tiền
                        P_ChietKhau = moneys;
                        lbl_Percent.Text = string.Format("{0:#,#}", Convert.ToDecimal(moneys));//Tiền chiết khấu

                        //Cập nhật lại tổng tiền phải thu
                        _defaultMoney = P_MustPay - moneys;
                        textEdit_MustPay.EditValue = string.Format("{0:#,#}", Convert.ToDecimal(_defaultMoney));
                    }
                    else
                    {
                        lbl_Owner.Text = "Không rõ";
                        lbl_Skin.Text = "Không rõ";
                        P_ChietKhau = 0;
                        lbl_Percent.Text = string.Format("{0:#,#}", Convert.ToDecimal("0"));//Tiền chiết khấu

                        textEdit_MustPay.EditValue = string.Format("{0:#,#}", P_TotalMoney);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_MoneyCostumer_EditValueChanged");
            }
        }

        private void textEdit_CustomerID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
            try
            {
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_CustomerID_EditValueChanging");
            }
        }

        private void textEdit_CustomerID_EditValueChanged(object sender, EventArgs e)
        {
            khachhang kh;
            decimal _defaultMoney = 0;
            try
            {
                btn_OK.Enabled = true;

                moneys = 0;
                P_CustomerMoney = Convert.ToDecimal(textEdit_MoneyCostumer.EditValue);
                P_ReturnMoney = (Convert.ToDecimal(textEdit_MoneyCostumer.EditValue) - P_MustPay) + Convert.ToDecimal(lbl_Percent.Text);
                textEdit_Return.EditValue = string.Format("{0:#,#}", P_ReturnMoney);

                kh = (from k in _dbContext.khachhangs.ToList() where k.KHCode == textEdit_CustomerID.Text.Trim() && k.TINHTRANG == 1 select k).FirstOrDefault();
                if (kh != null)
                {
                    lbl_Owner.Text = kh.TENKH;
                    lbl_Skin.Text = kh.smartlink.SmarkLink;

                    moneys = (P_MustPay * (decimal)kh.smartlink.Percent_SmarkLink) / 100;//Chiết khấu từ số tiền phải thu chứ không phải tổng tiền
                    P_ChietKhau = moneys;
                    lbl_Percent.Text = string.Format("{0:#,#}", Convert.ToDecimal(moneys));//Tiền chiết khấu

                    //Cập nhật lại tổng tiền phải thu
                    _defaultMoney = P_MustPay - moneys;
                    textEdit_MustPay.EditValue = string.Format("{0:#,#}", Convert.ToDecimal(_defaultMoney));
                }
                else
                {
                    lbl_Owner.Text = "Không rõ";
                    lbl_Skin.Text = "Không rõ";
                    P_ChietKhau = 0;
                    lbl_Percent.Text = string.Format("{0:#,#}", "0");//Tiền chiết khấu

                    textEdit_MustPay.EditValue = string.Format("{0:#,#}", Convert.ToDecimal(P_MustPay));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_CustomerID_EditValueChanged");
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                SetReportSource(ds);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Print_Click");
            }
        }

        private void SetReportSource(DataSet_HoaDonThanhToan dataset)
        {
            try
            {
                XtraReport_XuatHoaDonThanhToan report = new XtraReport_XuatHoaDonThanhToan();
                report.RequestParameters = false;
                report.Parameters["parameter_Date"].Value = "Ngay :" + DateTime.Now;
                report.Parameters["parameter_CompanyName"].Value = P_Company.CompanyName;
                report.Parameters["parameter_Address"].Value = P_Company.Address;
                report.Parameters["parameter_Phone"].Value = "Tel: " + P_Company.Phone + " - " + "Fax: " + P_Company.Fax;
                report.Parameters["parameter_MSThue"].Value = "Ma so thue: "+P_Company.MaSoThue;
                report.Parameters["parameter_TimeOpen"].Value = "Giờ mở cửa từ: " + P_Company.StartTime + " đến " + P_Company.EndTime;
                report.Parameters["parameter_EmployeeName"].Value = "Nhan vien: " + CoffeeHelpers.EmpLogin.EmployeeName;
                report.Parameters["parameter_OrderCode"].Value = "So HD: " + P_OrderCode;
                report.Parameters["parameter_ChietKhau"].Value = Convert.ToDecimal(lbl_Percent.Text) != 0 ? string.Format("{0:#,#}", Convert.ToDecimal(lbl_Percent.Text)) : string.Format("{0:#,#}", "0");
                report.Parameters["parameter_PhaiThu"].Value = Convert.ToDecimal(textEdit_MustPay.EditValue) != 0 ? string.Format("{0:#,#}", Convert.ToDecimal(textEdit_MustPay.EditValue)) : string.Format("{0:#,#}", "0"); ;
                report.Parameters["parameter_CustomerMoney"].Value = Convert.ToDecimal(textEdit_MoneyCostumer.EditValue) != 0 ? string.Format("{0:#,#}", Convert.ToDecimal(textEdit_MoneyCostumer.EditValue)) : string.Format("{0:#,#}", "0");
                report.Parameters["parameter_ReturnMoney"].Value = Convert.ToDecimal(textEdit_Return.EditValue) != 0 ? string.Format("{0:#,#}", Convert.ToDecimal(textEdit_Return.EditValue)) : string.Format("{0:#,#}", "0");

                report.DataSource = dataset;
                report.CreateDocument();

                frm_ViewDemo dlg = new frm_ViewDemo();
                dlg.rp = report;
                dlg.ShowDialog();
                //report.Print();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SetReportSource");
            }
        }

        private void checkEdit_Tally_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_config.Tally == false)
                {
                    XtraMessageBox.Show("Vui lòng liên hệ quản trị hệ thống để kích hoạt chức năng ghi nợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (lbl_Owner.Text == "Không rõ")
                {
                    XtraMessageBox.Show("Khách hàng này không phải thành viên. Không được phép ghi nợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkEdit_Tally_CheckedChanged");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Close_Click");
            }
        }

        private void btn_listCustomer_Click(object sender, EventArgs e)
        {
            frm_Customer dlg;
            try
            {
                dlg = new frm_Customer();
                dlg._fromPay = true;
                dlg.Text = "Xem Danh Sách Thành Viên";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Close_Click");
            }
        }

        private void textEdit_MustPay_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                P_CustomerMoney = Convert.ToDecimal(textEdit_MoneyCostumer.EditValue);
                P_ReturnMoney = (Convert.ToDecimal(textEdit_MoneyCostumer.EditValue) - P_MustPay) + Convert.ToDecimal(lbl_Percent.Text);
                textEdit_Return.EditValue = string.Format("{0:#,#}", P_ReturnMoney);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_MustPay_EditValueChanged");
            }
        }

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
                XtraMessageBox.Show(ex.Message, "panelControl2_MouseDown");
            }
        }
    }
}