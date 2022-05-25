using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Coffee.Utils;
using Coffee.DataSet;
using Coffee.Reports;
using System.Linq;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraReports.UI;
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_PhieuThuChi : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public phieuthu PhieuThu { get; set; }
        public phieuchi PhieuChi { get; set; }
        public int _PhieuThu_PhieuChi { get; set; }//Phân biệt là thu hay chi(1: thu; 2: chi)
        public int maxCode { get; set; }
        public company company { get; set; }

        private DataSet_ThuChi ds = new DataSet_ThuChi();

        private const string _cCardCode = "CardCode";
        private const string _cDate = "Date";
        private const string _cReason = "Reason";
        private const string _cAttach = "Attach";
        private const string _cPerson = "Person";
        private const string _cMoney = "Money";
        private const string _cAddress = "Address";
        private const string _cSkin = "Skin";

        public frm_PhieuThuChi()
        {
            InitializeComponent();
        }

        private void frm_PhieuThuChi_Load(object sender, EventArgs e)
        {
            DateTime dtNow;
            try
            {
                dtNow = DateTime.Now;

                if (_PhieuThu_PhieuChi == 1)
                {
                    lbl_Title.Text = "Phiếu Thu";
                    if (PhieuThu.MaPT == 0)//Add phiếu thu
                    {
                        textEdit_Card.Text = "PT-"+dtNow.ToString("dd/MM/yy")+"-00"+ maxCode;
                        dateEdit_Date.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

                    }
                    else
                    {
                        textEdit_Card.Text = PhieuThu.PTCode;
                        dateEdit_Date.EditValue = PhieuThu.NgayThu;
                        textEdit_Reason.Text = PhieuThu.Reason;
                        textEdit_Dinhkem.Text = PhieuThu.DinhKem;
                        textEdit_NguoiNop.Text = PhieuThu.DoiTuongNop;
                        textEdit_Address.Text = PhieuThu.DiaChi;
                        textEdit_Money.EditValue = PhieuThu.SoTienTra_PT;
                        memoEdit_Notes.Text = PhieuThu.GhiChu;

                    }
                }
                else
                {
                    lbl_Title.Text = "Phiếu Chi";
                    if (PhieuChi.MaPC == 0)//Add phiếu chi
                    {
                        textEdit_Card.Text = "PC-" + dtNow.ToString("dd/MM/yy") + "-00" + maxCode;
                        dateEdit_Date.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                    }
                    else
                    {
                        textEdit_Card.Text = PhieuChi.PCCode;
                        dateEdit_Date.EditValue= PhieuChi.NgayChi;
                        textEdit_Reason.Text = PhieuChi.LyDo;
                        textEdit_Dinhkem.Text = PhieuChi.DinhKem;
                        textEdit_NguoiNop.Text = PhieuChi.DoiTuongChi;
                        textEdit_Address.Text = PhieuChi.DiaChi;
                        textEdit_Money.EditValue = PhieuChi.SoTienDaTra_PC;
                        memoEdit_Notes.Text = PhieuChi.GhiChu;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_PhieuThuChi_Load");
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            frm_ViewThuChi dlg;
            DataSet_ThuChi.DataTable_ThuChiRow row;
            try
            {
                if (string.IsNullOrEmpty(textEdit_Reason.Text) == true)
                {
                    XtraMessageBox.Show("Vui lòng nhập lý do", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(textEdit_NguoiNop.Text) == true)
                {
                    XtraMessageBox.Show("Vui lòng chọn đối tượng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToDecimal(textEdit_Money.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Chưa nhập số tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                row = ds.DataTable_ThuChi.NewDataTable_ThuChiRow();
                row[_cCardCode] ="Số: "+ textEdit_Card.Text;
                row[_cDate] = "Ngày " + dateEdit_Date.DateTime.Day + " tháng " + dateEdit_Date.DateTime.Month + " năm "+ dateEdit_Date.DateTime.Year;
                row[_cAttach] = "Đính kèm:     " + textEdit_Dinhkem.Text;
                if (_PhieuThu_PhieuChi == 2)
                {
                    row[_cReason] = "Lý do chi:     " + textEdit_Reason.Text;
                    row[_cPerson] = "Họ,tên người nhận tiền:     " + textEdit_NguoiNop.Text.ToUpper();
                }
                else
                {
                    row[_cReason] = "Lý do nộp:     " + textEdit_Reason.Text;
                    row[_cPerson] = "Họ,tên người nộp tiền:     " + textEdit_NguoiNop.Text.ToUpper();
                }
                row[_cAddress] = "Địa chỉ:     " + textEdit_Address.Text;
                row[_cMoney] = "Số tiền:     " + string.Format("{0:#,#}", textEdit_Money.EditValue) + " (vnđ)";

                ds.DataTable_ThuChi.AddDataTable_ThuChiRow(row);

                dlg = new frm_ViewThuChi();
                if (_PhieuThu_PhieuChi == 1)
                {
                    dlg.Text = "Phiếu Thu";
                }
                else
                {
                    dlg.Text = "Phiếu Chi";
                }

                XtraReport_ThuChi report = new XtraReport_ThuChi();
                report.RequestParameters = false;

                if(_PhieuThu_PhieuChi==1)
                {
                    report.Parameters["parameter_Cheque"].Value = "PHIẾU THU";
                }else{
                    report.Parameters["parameter_Cheque"].Value = "PHIẾU CHI";
                }
                report.Parameters["parameter_Address"].Value = "Địa chỉ: " + company.Address;
                report.Parameters["parameter_Company"].Value = "Đơn vị: "+company.CompanyName;
                report.Parameters["parameter_MoneyLeter"].Value = "(bằng chữ): " + So_chu(Convert.ToDouble(textEdit_Money.EditValue));
                report.Parameters["parameter_MST"].Value = "MST: "+company.MaSoThue;

                dlg._ds = ds;
                dlg._report = report;
                dlg.ShowDialog();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Print_Click");
            }
        }

        //Chuyển số thành chữ
        public static string So_chu(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";

            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";

            // Dau [+ , - ]
            if (gNum < 0)
                dau = "[-]";
            dau = "";

            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

            ///don vi hang mod 
            int im = m + 1;
            if (mod > 0)
                lso_chu = Tach(tach_mod).ToString().Trim() + " " + Donvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai

            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";

            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + Tach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + Donvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng chẵn.";

            return lso_chu.ToString().Trim();

        } 

        //Hàm chữ
        private static string Chu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }

        //Đơn vị
        private static string Donvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }

        //Tách chuỗi
        private static string Tach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + Chu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = Chu(tr.ToString().Trim()).Trim() + " trăm lẻ " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + Chu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi " + Chu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm " + Chu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười " + Chu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = Chu(tr.Trim()).Trim() + " trăm mười lăm ";

            }
            return Ktach;
        } 

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            { 
                if (string.IsNullOrEmpty(textEdit_Reason.Text) == true)
                {
                    XtraMessageBox.Show("Chưa có lý do", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(textEdit_NguoiNop.Text) == true)
                {
                    XtraMessageBox.Show("Vui lòng chọn đối tượng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToDecimal(textEdit_Money.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Chưa nhập số tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_PhieuThu_PhieuChi == 1)
                {
                    PhieuThu.PTCode = textEdit_Card.Text;
                    PhieuThu.NgayThu = dateEdit_Date.DateTime;
                    PhieuThu.Reason = textEdit_Reason.Text;
                    PhieuThu.SoTienTra_PT = Convert.ToDecimal(textEdit_Money.EditValue);
                    PhieuThu.DinhKem = textEdit_Dinhkem.Text;
                    PhieuThu.DiaChi = textEdit_Address.Text;
                    PhieuThu.DoiTuongNop = textEdit_NguoiNop.Text;
                    PhieuThu.GhiChu = memoEdit_Notes.Text;

                }
                else
                {
                    PhieuChi.PCCode = textEdit_Card.Text;
                    PhieuChi.NgayChi= dateEdit_Date.DateTime;
                    PhieuChi.LyDo= textEdit_Reason.Text;
                    PhieuChi.SoTienDaTra_PC= Convert.ToDecimal(textEdit_Money.EditValue);
                    PhieuChi.DinhKem = textEdit_Dinhkem.Text;
                    PhieuChi.DiaChi = textEdit_Address.Text;
                    PhieuChi.DoiTuongChi = textEdit_NguoiNop.Text;
                    PhieuChi.GhiChu = memoEdit_Notes.Text;
                }

                if (XtraMessageBox.Show("Bạn có muốn in phiếu không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                }
                else
                {
                    //In phiếu
                    PrintCheque();
                }

                DialogResult = DialogResult.OK;
                this.Close(); 
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Save_Click");
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
                XtraMessageBox.Show(ex.Message, "btn_Save_Click");
            }
        }

        private void slookUpEdit_MadeIn_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void textEdit_NguoiNop_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_NguoiNop_MouseUp");
            }
        }

        private void barButtonItem_Employee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_SelectPersonPhieuThu dlg;
            try
            {
                dlg = new frm_SelectPersonPhieuThu();
                dlg._emp_Cus_NCC = 1;
                dlg.Text = "Danh Sách Nhân viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    textEdit_NguoiNop.Text = dlg._EmployeeNode.Text;
                    textEdit_Address.Text = dlg._EmployeeNode.Tag.ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Employee_ItemClick");
            }
        }

        private void barButtonItem_Customer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_SelectPersonPhieuThu dlg;
            try
            {
                dlg = new frm_SelectPersonPhieuThu();
                dlg._emp_Cus_NCC = 2;
                dlg.Text = "Danh Sách Khách Hàng";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    textEdit_NguoiNop.Text = dlg._CustomerNode.Text;
                    textEdit_Address.Text = dlg._CustomerNode.Tag.ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Customer_ItemClick");
            }
        }

        private void barButtonItem_NCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_SelectPersonPhieuThu dlg;
            try
            {
                dlg = new frm_SelectPersonPhieuThu();
                dlg._emp_Cus_NCC = 3;
                dlg.Text = "Danh Sách Nhà Cung Cấp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    textEdit_NguoiNop.Text = dlg._NCCNode.Text;
                    textEdit_Address.Text = dlg._NCCNode.Tag.ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_NCC_ItemClick");
            }
        }

        private void barButtonItem_Other_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                textEdit_Address.Properties.ReadOnly = false;
                textEdit_NguoiNop.Properties.ReadOnly = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Other_ItemClick");
            }
        }

        private void dropDownButton_Person_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                barButtonItem_Employee.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_Customer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_NCC.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_Other.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                if (e.Button == MouseButtons.Left)
                {
                    barButtonItem_Employee.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem_Customer.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem_NCC.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem_Other.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    popupMenu_Person.ShowPopup(Control.MousePosition);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "dropDownButton_Person_MouseUp");
            }
        }


        //In phiếu
        private void PrintCheque()
        {
            frm_ViewThuChi dlg;
            DataSet_ThuChi.DataTable_ThuChiRow row;
            try
            {
                row = ds.DataTable_ThuChi.NewDataTable_ThuChiRow();
                row[_cCardCode] = "Số: " + textEdit_Card.Text;
                row[_cDate] = "Ngày " + dateEdit_Date.DateTime.Day + " tháng " + dateEdit_Date.DateTime.Month + " năm " + dateEdit_Date.DateTime.Year;
                row[_cAttach] = "Đính kèm:     " + textEdit_Dinhkem.Text;
                if (_PhieuThu_PhieuChi == 2)
                {
                    row[_cReason] = "Lý do chi:     " + textEdit_Reason.Text;
                    row[_cPerson] = "Họ,tên người nhận tiền:     " + textEdit_NguoiNop.Text.ToUpper();
                }
                else
                {
                    row[_cReason] = "Lý do nộp:     " + textEdit_Reason.Text;
                    row[_cPerson] = "Họ,tên người nộp tiền:     " + textEdit_NguoiNop.Text.ToUpper();
                }
                row[_cAddress] = "Địa chỉ:     " + textEdit_Address.Text;
                row[_cMoney] = "Số tiền:     " + string.Format("{0:#,#}", textEdit_Money.EditValue) + " (vnđ)";

                ds.DataTable_ThuChi.AddDataTable_ThuChiRow(row);

                dlg = new frm_ViewThuChi();
                if (_PhieuThu_PhieuChi == 1)
                {
                    dlg.Text = "Phiếu Thu";
                }
                else
                {
                    dlg.Text = "Phiếu Chi";
                }

                XtraReport_ThuChi report = new XtraReport_ThuChi();
                report.RequestParameters = false;

                if (_PhieuThu_PhieuChi == 1)
                {
                    report.Parameters["parameter_Cheque"].Value = "PHIẾU THU";
                }
                else
                {
                    report.Parameters["parameter_Cheque"].Value = "PHIẾU CHI";
                }
                report.Parameters["parameter_Address"].Value = "Địa chỉ: " + company.Address;
                report.Parameters["parameter_Company"].Value = "Đơn vị: " + company.CompanyName;
                report.Parameters["parameter_MoneyLeter"].Value = "(bằng chữ): " + So_chu(Convert.ToDouble(textEdit_Money.EditValue));
                report.Parameters["parameter_MST"].Value = "MST: " + company.MaSoThue;


                report.RequestParameters = false;
                report.Print();
                //dlg._ds = ds;
                //dlg._report = report;
                //dlg.ShowDialog();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "PrintCheque");
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frm_PhieuThuChi_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "frm_PhieuThuChi_MouseDown");
            }
        }

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