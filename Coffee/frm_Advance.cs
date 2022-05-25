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
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_Advance : DevExpress.XtraEditors.XtraForm
    {
        #region Suport

        public company company;
        private mycoffeeEntities _dbContext;
        TreeNode selectNode;
        private DataTable _tbSource;

        private const string _cEmployeeID = "EmployeeID";
        private const string _cDate = "Date";
        private const string _cReason = "Reason";
        private const string _cMoney = "Money";
        private const string _cMoneyValue = "MoneyValue";
        private const string _cNotes = "Notes";

        decimal advance = 0;
        decimal existMoney = 0;
        decimal salary = 0;
        decimal _daySalary = 0;

        private DataSet_ThuChi ds = new DataSet_ThuChi();

        private const string _cCardCode = "CardCode";
        private const string _cAttach = "Attach";
        private const string _cPerson = "Person";
        private const string _cAddress = "Address";
        private const string _cSkin = "Skin";

        string _address = "";//Lấy dịa chỉ nhân viến xuất phiếu tạm ứng

        #endregion
       
        #region Form Method

        public frm_Advance()
        {
            InitializeComponent();

        }

        private void frm_Advance_Load(object sender, EventArgs e)
        {
            try
            {
                //Khơi tạo cấu trúc cho bảng ứng lương
                _tbSource = CreateAdvanceTableStruct();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                //Add danh sách nhân viên lên treeView
                AddEmployee();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Advance_Load");
            }
        }

        #endregion

        #region Helpers

        //Danh sách nhân viên
        private void AddEmployee()
        {
            List<employee> listEmpls;
            TreeNode nodes;
            try
            {
                if (treeView_Employee.Nodes.Count > 0)
                {
                    treeView_Employee.Nodes.Clear();
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                listEmpls = (from em in _dbContext.employees.ToList() where em.EmployeeRight!=CoffeeHelpers.EmpRight.Administrator.ToString() select em).ToList();

                if (listEmpls != null && listEmpls.Count > 0)
                {
                    foreach (employee item in listEmpls)
                    {
                        nodes = new TreeNode();
                        nodes.Name = item.EmployeeID.ToString();
                        nodes.Tag = item.EmployeeName.ToString() + "/" + item.Salary;
                        if (item.Sex == "Nam")
                        {
                            nodes.ImageIndex = 0;
                            nodes.SelectedImageIndex = 0;
                        }
                        else if (item.Sex == "Nữ")
                        {
                            nodes.ImageIndex = 1;
                            nodes.SelectedImageIndex = 1;
                        }
                        else
                        {
                            nodes.ImageIndex = 2;
                            nodes.SelectedImageIndex = 2;
                        }
                        nodes.Text = item.EmployeeName.ToString() + " (" + item.EmployeeID + ")";

                        treeView_Employee.Nodes.Add(nodes);
                    }

                    TreeNodeCollection selectnodes = treeView_Employee.Nodes;
                    treeView_Employee.SelectedNode = selectnodes[0];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddEmployee");
            }
        }

        private void LoadInformationAdvance(TreeNode node)
        {
            List<advancemoney> moneys;
            DataRow row;
            try
            {
                advance = 0;
                existMoney = 0;

                //Tạo cấu trúc cho bảng Advance
                _tbSource = CreateAdvanceTableStruct();

                selectNode = node;

                //Lương căn bản
                string[] arrSalary = selectNode.Tag.ToString().Split('/');
                salary = Convert.ToDecimal(arrSalary[1]);
                _daySalary = salary / 30;

                groupControl_Advance.Text = "Chi tiết ứng lương của " + arrSalary[0].ToString();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                moneys = (from m in _dbContext.advancemoneys.ToList() where m.EmployeeID == Convert.ToInt32(selectNode.Name) select m).ToList();

                //Hiện thông tin tạm ứng

                if (moneys != null && moneys.Count > 0)
                {
                    foreach (advancemoney mn in moneys)
                    {
                        row = _tbSource.NewRow();
                        row[_cEmployeeID] = mn.EmployeeID;
                        row[_cDate] = mn.Date;
                        row[_cMoney] = string.Format("{0:#,#}", Convert.ToDecimal(mn.Advance_Money)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(mn.Advance_Money)) : string.Format("{0:#,#}", Convert.ToString(mn.Advance_Money));
                        row[_cReason] = mn.Reason;
                        row[_cNotes] = mn.Notes;
                        row[_cMoneyValue] = mn.Advance_Money;

                        _tbSource.Rows.Add(row);

                        advance = advance + Convert.ToDecimal(mn.Advance_Money);

                        _address = mn.employee.Address;
                    }
                    gridControl_Advance.DataSource = _tbSource;
    
                    //Nghỉ không xin phép
                    var awol = (from aw in _dbContext.employeestates.ToList() 
                                where aw.EmployeeID == Convert.ToInt32(selectNode.Name) && aw.Status == 2 && aw.Date.Month == DateTime.Now.Month
                                group aw by aw.EmployeeID into gr
                                select gr.Count());

                    if (awol != null && awol.FirstOrDefault() > 0)
                    {
                        existMoney = (salary - advance) - (_daySalary * awol.FirstOrDefault());
                        lbl_Off.Text = awol.FirstOrDefault().ToString();
                    }
                    else
                    {
                        existMoney = salary - advance;
                        lbl_Off.Text = "0";
                    }

                    lbl_Advanced.Text = string.Format("{0:#,#}", Convert.ToDecimal(advance)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(advance)) : string.Format("{0:#,#}", Convert.ToString(advance));
                    lbl_ExistMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(existMoney)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(existMoney)) : string.Format("{0:#,#}", Convert.ToString(existMoney));

                }
                else
                {
                    _tbSource = null;
                    gridControl_Advance.DataSource = _tbSource;

                    //Nghỉ không xin phép
                    var awol = (from aw in _dbContext.employeestates.ToList() 
                                where aw.EmployeeID == Convert.ToInt32(selectNode.Name) && aw.Status == 2 && aw.Date.Month == DateTime.Now.Month
                                group aw by aw.EmployeeID into gr
                                select gr.Count());

                    if (awol != null && awol.FirstOrDefault() > 0)
                    {
                        _daySalary = salary / 30;
                        existMoney = (salary - advance) - (_daySalary * awol.FirstOrDefault());
                        lbl_Off.Text = awol.FirstOrDefault().ToString();
                    }
                    else
                    {
                        existMoney = salary - advance;
                        lbl_Off.Text = "0";
                    }

                    lbl_Advanced.Text = string.Format("{0:#,#}", Convert.ToDecimal(advance)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(advance)) : string.Format("{0:#,#}", Convert.ToString(advance));
                    lbl_ExistMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(existMoney)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(existMoney)) : string.Format("{0:#,#}", Convert.ToString(existMoney));
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadInformationAdvance");
            }
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho AdvanceMoney
        /// </summary>
        private DataTable CreateAdvanceTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cEmployeeID);
                tbSource.Columns.Add(_cDate);
                tbSource.Columns.Add(_cReason);
                tbSource.Columns.Add(_cNotes);
                tbSource.Columns.Add(_cMoney);
                tbSource.Columns.Add(_cMoneyValue);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateAdvanceTableStruct");
                return tbSource;
            }
            return tbSource;
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

        #endregion

        #region Action

        private void button_Add_Click(object sender, EventArgs e)
        {
            frm_AddEditAdvance dlg;
            advancemoney money;
            frm_SelectEmployeeAdvance dldAdd;
            DataSet_ThuChi.DataTable_ThuChiRow row;
            frm_ViewThuChi dlg_V;
            try
            {
                dldAdd = new frm_SelectEmployeeAdvance();
                dldAdd.Text = "Chọn Nhân Viên Tạm Ứng Lương";
                if (dldAdd.ShowDialog() == DialogResult.OK)
                {
                    selectNode = dldAdd._EmployeeNode;
                }
                else
                {
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dlg = new frm_AddEditAdvance();
                money = new advancemoney();
                dlg._dbContext = _dbContext;
                dlg.P_Advance = money;
                dlg.Text = "Thêm Tạm Ứng Lương Cho Nhân Viên " + selectNode.Text;
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    dlg.P_Advance.EmployeeID = Convert.ToInt32(selectNode.Name);
                    _dbContext.advancemoneys.Add(dlg.P_Advance);
                    _dbContext.SaveChanges();

                    //Load lại thông tin tạm ứng của nhân viên vừa thêm
                    LoadInformationAdvance(selectNode);

                    //Xuất phiếu thu
                    row = ds.DataTable_ThuChi.NewDataTable_ThuChiRow();
                    row[_cCardCode] = "Số: " + "PC-" +DateTime.Now.ToString("dd/MM/yy")+"-00"+ CoffeeHelpers.GetPhieuChiMaxCode() + 1;
                    row[_cDate] = "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                    row[_cAttach] = "Đính kèm:     ";

                    row[_cReason] = "Lý do chi:     " + dlg.P_Advance.Reason;
                    row[_cPerson] = "Họ,tên người nhận tiền:     " + selectNode.Text.ToUpper();

                    row[_cAddress] = "Địa chỉ:     " + _address;
                    row[_cMoney] = "Số tiền:     " + string.Format("{0:#,#}", dlg.P_Advance.Advance_Money) != "" ? string.Format("{0:#,#}", dlg.P_Advance.Advance_Money) : string.Format("{0:#,#}", Convert.ToString(dlg.P_Advance.Advance_Money)) + " (vnđ)";

                    ds.DataTable_ThuChi.AddDataTable_ThuChiRow(row);

                    dlg_V = new frm_ViewThuChi();
                    dlg_V.Text = "Phiếu Chi";

                    XtraReport_ThuChi report = new XtraReport_ThuChi();
                    report.RequestParameters = false;
                    report.Parameters["parameter_Cheque"].Value = "PHIẾU CHI";
                    report.Parameters["parameter_Address"].Value = "Địa chỉ: " + company.Address;
                    report.Parameters["parameter_Company"].Value = "Đơn vị: " + company.CompanyName;
                    report.Parameters["parameter_MoneyLeter"].Value = "(bằng chữ): " + So_chu(Convert.ToDouble(dlg.P_Advance.Advance_Money));
                    report.Parameters["parameter_MST"].Value = "MST: " + company.MaSoThue;

                    dlg_V._ds = ds;
                    dlg_V._report = report;
                    dlg_V.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Add_Click");
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            advancemoney money, updateRow;
            DataRow focusRow;
            frm_AddEditAdvance dlg;
            try
            {
                if (selectNode == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (gridView_Advance.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn khoản lương tạm ứng muốn sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_Advance.GetFocusedDataRow();

                money = new advancemoney();
                money.EmployeeID = Convert.ToInt32(focusRow[_cEmployeeID]);
                money.Date = Convert.ToDateTime(focusRow[_cDate]);
                money.Advance_Money = Convert.ToDecimal(focusRow[_cMoneyValue]);
                money.Reason = focusRow[_cReason].ToString();
                money.Notes = focusRow[_cNotes].ToString();

                dlg = new frm_AddEditAdvance();
                dlg.P_Advance = money;
                dlg._dbContext = _dbContext;
                dlg.Text = "Sửa Tạm Ứng Lương Của Nhân Viên " + selectNode.Text;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    updateRow = (from mn in _dbContext.advancemoneys.ToList() where mn.EmployeeID == Convert.ToInt32(focusRow[_cEmployeeID]) select mn).FirstOrDefault();
                    if (updateRow != null)
                    {
                        updateRow.Date = dlg.P_Advance.Date;
                        updateRow.Advance_Money = dlg.P_Advance.Advance_Money;
                        updateRow.Reason = dlg.P_Advance.Reason;
                        updateRow.Notes = dlg.P_Advance.Notes;

                        _dbContext.SaveChanges();

                        //Thông tin ứng tiền
                        advance = (advance - Convert.ToDecimal(focusRow[_cMoneyValue])) + dlg.P_Advance.Advance_Money;
                        existMoney = (existMoney + Convert.ToDecimal(focusRow[_cMoneyValue])) - dlg.P_Advance.Advance_Money;

                        focusRow[_cMoney] = string.Format("{0:#,#}", Convert.ToDecimal(dlg.P_Advance.Advance_Money)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(dlg.P_Advance.Advance_Money)) : string.Format("{0:#,#}", Convert.ToString(dlg.P_Advance.Advance_Money));
                        focusRow[_cMoneyValue] = dlg.P_Advance.Advance_Money;
                        focusRow[_cDate] = dlg.P_Advance.Date;
                        focusRow[_cReason] = dlg.P_Advance.Reason.ToString();
                        focusRow[_cNotes] = dlg.P_Advance.Notes.ToString();

                        gridView_Advance.LayoutChanged();

                        lbl_Advanced.Text = string.Format("{0:#,#}", Convert.ToDecimal(advance)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(advance)) : string.Format("{0:#,#}", Convert.ToString(advance));
                        lbl_ExistMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(existMoney)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(existMoney)) : string.Format("{0:#,#}", Convert.ToString(existMoney));
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Update_Click");
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            advancemoney money;
            DataRow deleteRow;
            try
            {
                if (selectNode == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (gridView_Advance.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn khoản lương tạm ứng muốn xoá", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Bạn có chắc muốn xoá khoản tạm ứng này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                deleteRow = gridView_Advance.GetFocusedDataRow();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                money = (from mn in _dbContext.advancemoneys.ToList() where mn.EmployeeID == Convert.ToInt32(deleteRow[_cEmployeeID]) && mn.Date == Convert.ToDateTime(deleteRow[_cDate]) select mn).FirstOrDefault();
                if (money != null)
                {
                    _dbContext.advancemoneys.Remove(money);
                    _dbContext.SaveChanges();

                    //Thông tin ứng tiền
                    advance = (advance - Convert.ToDecimal(deleteRow[_cMoneyValue]));
                    existMoney = salary - advance;

                    lbl_Advanced.Text = string.Format("{0:#,#}", Convert.ToDecimal(advance)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(advance)) : string.Format("{0:#,#}", Convert.ToString(advance));
                    lbl_ExistMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(existMoney)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(existMoney)) : string.Format("{0:#,#}", Convert.ToString(existMoney));

                    //update tren grid
                    gridView_Advance.DeleteRow(gridView_Advance.GetSelectedRows()[0]);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Delete_Click");
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

        private void treeView_Employee_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                LoadInformationAdvance(e.Node);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Employee_NodeMouseClick");
            }
        }

        #endregion

        private void gridControl_Advance_DoubleClick(object sender, EventArgs e)
        {
            advancemoney money, updateRow;
            DataRow focusRow;
            frm_AddEditAdvance dlg;
            try
            {
                if (selectNode == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (gridView_Advance.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn khoản lương tạm ứng muốn sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_Advance.GetFocusedDataRow();

                money = new advancemoney();
                money.EmployeeID = Convert.ToInt32(focusRow[_cEmployeeID]);
                money.Date = Convert.ToDateTime(focusRow[_cDate]);
                money.Advance_Money = Convert.ToDecimal(focusRow[_cMoneyValue]);
                money.Reason = focusRow[_cReason].ToString();
                money.Notes = focusRow[_cNotes].ToString();

                dlg = new frm_AddEditAdvance();
                dlg.P_Advance = money;
                dlg._dbContext = _dbContext;
                dlg.Text = "Sửa Tạm Ứng Lương Của Nhân Viên " + selectNode.Text;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    updateRow = (from mn in _dbContext.advancemoneys.ToList() where mn.EmployeeID == Convert.ToInt32(focusRow[_cEmployeeID]) select mn).FirstOrDefault();
                    if (updateRow != null)
                    {
                        updateRow.Date = dlg.P_Advance.Date;
                        updateRow.Advance_Money = dlg.P_Advance.Advance_Money;
                        updateRow.Reason = dlg.P_Advance.Reason;
                        updateRow.Notes = dlg.P_Advance.Notes;

                        _dbContext.SaveChanges();

                        //Thông tin ứng tiền
                        advance = (advance - Convert.ToDecimal(focusRow[_cMoneyValue])) + dlg.P_Advance.Advance_Money;
                        existMoney = (existMoney + Convert.ToDecimal(focusRow[_cMoneyValue])) - dlg.P_Advance.Advance_Money;

                        focusRow[_cMoney] = string.Format("{0:#,#}", Convert.ToDecimal(dlg.P_Advance.Advance_Money)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(dlg.P_Advance.Advance_Money)) : string.Format("{0:#,#}", Convert.ToString(dlg.P_Advance.Advance_Money));
                        focusRow[_cMoneyValue] = dlg.P_Advance.Advance_Money;
                        focusRow[_cDate] = dlg.P_Advance.Date;
                        focusRow[_cReason] = dlg.P_Advance.Reason.ToString();
                        focusRow[_cNotes] = dlg.P_Advance.Notes.ToString();

                        gridView_Advance.LayoutChanged();

                        lbl_Advanced.Text = string.Format("{0:#,#}", Convert.ToDecimal(advance)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(advance)) : string.Format("{0:#,#}", Convert.ToString(advance));
                        lbl_ExistMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(existMoney)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(existMoney)) : string.Format("{0:#,#}", Convert.ToString(existMoney));
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_Advance_DoubleClick");
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frm_Advance_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "frm_Advance_MouseDown");
            }
        }

        private void panelControl3_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "panelControl3_MouseDown");
            }
        }

    }
}