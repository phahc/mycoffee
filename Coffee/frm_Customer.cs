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

namespace Coffee
{
    public partial class frm_Customer : DevExpress.XtraEditors.XtraForm
    {
        private mycoffeeEntities _dbContext;
        private DataTable _tbSource;
        public bool _fromPay { get;set; }

        private const string _cCustomerCode = "CustomerCode";
        private const string _cCustomerName = "CustomerName";
        private const string _cEmail = "Email";
        private const string _cPhone = "Phone";
        private const string _cPayed = "Payed";
        private const string _cStatus = "Status";
        private const string _cSmartLink = "SmartLink";
        private const string _cLevelCard = "LevelCard";

        public frm_Customer()
        {
            InitializeComponent();
        }

        private void frm_Customer_Load(object sender, EventArgs e)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                _tbSource = CreateTableStruct();

                LoadStatus();

                // Danh sách khách hàng
                LoadListCustomer();

                if (_fromPay == true)
                {
                    bar_Customer.Visible = false;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Customer_Load");
            }
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho gridView
        /// </summary>
        private DataTable CreateTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cCustomerCode);
                tbSource.Columns.Add(_cCustomerName);
                tbSource.Columns.Add(_cEmail);
                tbSource.Columns.Add(_cPhone);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cSmartLink);
                tbSource.Columns.Add(_cPayed);
                tbSource.Columns.Add(_cLevelCard);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        private void LoadListCustomer()
        {
            List<khachhang> Khs;
            DataRow row;
            try
            {

                Khs = (from kh in _dbContext.khachhangs.ToList() select kh).ToList();
                if (Khs != null && Khs.Count > 0)
                {
                    foreach(khachhang k in Khs)
                    {
                        row = _tbSource.NewRow();
                        row[_cCustomerCode] = k.KHCode;
                        row[_cCustomerName] = k.TENKH;
                        row[_cEmail] = k.Email;
                        row[_cPhone] = k.SDT;
                        row[_cPayed] = k.TotalMoney;
                        row[_cSmartLink] = k.SmarkLink;
                        row[_cLevelCard] = k.smartlink.SmarkLink;
                        row[_cStatus] = k.TINHTRANG;

                        _tbSource.Rows.Add(row);

                    }
                    gridControl_Customer.DataSource = _tbSource;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadListCustomer");
            }
        }

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddEditCustomer dlg;
            khachhang khs;
            DataRow row;
            try
            {
                dlg = new frm_AddEditCustomer();
                khs = new khachhang();
                dlg.P_Customer = khs;
                dlg._customer = "THÊM THÀNH VIÊN";
                dlg.Text = "Thêm Khách Hàng";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                    _dbContext.khachhangs.Add(dlg.P_Customer);
                    _dbContext.SaveChanges();

                    row = _tbSource.NewRow();
                    row[_cCustomerCode] = dlg.P_Customer.KHCode;
                    row[_cCustomerName] = dlg.P_Customer.TENKH;
                    row[_cEmail] = dlg.P_Customer.Email;
                    row[_cPhone] = dlg.P_Customer.SDT;
                    row[_cPayed] = dlg.P_Customer.TotalMoney;
                    row[_cSmartLink] = dlg.P_Customer.SmarkLink;
                    row[_cStatus] = dlg.P_Customer.TINHTRANG;
                    row[_cLevelCard] = dlg.P_Customer.smartlink.SmarkLink;

                    _tbSource.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Add_ItemClick");
            }
        }

        private void barButtonItem_Update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddEditCustomer dlg;
            DataRow focusRow;
            khachhang khs;
            try
            {
                if (gridView_Customer.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn khách hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_Customer.GetFocusedDataRow();
                khs = new khachhang();
                khs = (from kh in _dbContext.khachhangs.ToList() where kh.KHCode == focusRow[_cCustomerCode].ToString().Trim() select kh).FirstOrDefault();

                dlg = new frm_AddEditCustomer();
                dlg.P_Customer = khs;
                dlg._customer = "SỬATHÀNH VIÊN";
                dlg.Text = "Sửa Khách Hàng";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    khs.KHCode = dlg.P_Customer.KHCode;
                    khs.TENKH = dlg.P_Customer.TENKH;
                    khs.Email = dlg.P_Customer.Email;
                    khs.SDT = dlg.P_Customer.SDT;
                    khs.TotalMoney = dlg.P_Customer.TotalMoney;
                    khs.SmarkLink = dlg.P_Customer.SmarkLink;
                    khs.TINHTRANG = dlg.P_Customer.TINHTRANG;

                    _dbContext.SaveChanges();


                    focusRow[_cCustomerCode] = dlg.P_Customer.KHCode;
                    focusRow[_cCustomerName] = dlg.P_Customer.TENKH;
                    focusRow[_cEmail] = dlg.P_Customer.Email;
                    focusRow[_cPhone] = dlg.P_Customer.SDT;
                    focusRow[_cPayed] = dlg.P_Customer.TotalMoney;
                    focusRow[_cSmartLink] = dlg.P_Customer.SmarkLink;
                    focusRow[_cStatus] = dlg.P_Customer.TINHTRANG;
                    focusRow[_cLevelCard] = dlg.P_Customer.smartlink.SmarkLink;

                    gridView_Customer.LayoutChanged();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Update_ItemClick");
            }
        }

        private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            khachhang khs;
            DataRow deleteRow;
            try
            {
                if (gridView_Customer.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn khách hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                deleteRow = gridView_Customer.GetFocusedDataRow();
                khs = (from kh in _dbContext.khachhangs.ToList() where kh.KHCode == deleteRow[_cCustomerCode].ToString().Trim() select kh).FirstOrDefault();
                if (khs != null)
                {
                    khs.TINHTRANG = 2;
                    _dbContext.SaveChanges();

                    gridView_Customer.DeleteRow(gridView_Customer.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Delete_ItemClick");
            }
        }

        private void barButtonItem_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Close_ItemClick");
            }
        }

        private void gridControl_Customer_DoubleClick(object sender, EventArgs e)
        {
            frm_AddEditCustomer dlg;
            DataRow focusRow;
            khachhang khs;
            try
            {
                if (gridView_Customer.SelectedRowsCount <= 0)
                {
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_Customer.GetFocusedDataRow();
                khs = new khachhang();
                khs = (from kh in _dbContext.khachhangs.ToList() where kh.KHCode == focusRow[_cCustomerCode].ToString().Trim() select kh).FirstOrDefault();

                dlg = new frm_AddEditCustomer();
                dlg.P_Customer = khs;
                dlg.Text = "Sửa Khách Hàng";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    khs.KHCode = dlg.P_Customer.KHCode;
                    khs.TENKH = dlg.P_Customer.TENKH;
                    khs.Email = dlg.P_Customer.Email;
                    khs.SDT = dlg.P_Customer.SDT;
                    khs.TotalMoney = dlg.P_Customer.TotalMoney;
                    khs.SmarkLink = dlg.P_Customer.SmarkLink;
                    khs.TINHTRANG = dlg.P_Customer.TINHTRANG;

                    _dbContext.SaveChanges();


                    focusRow[_cCustomerCode] = dlg.P_Customer.KHCode;
                    focusRow[_cCustomerName] = dlg.P_Customer.TENKH;
                    focusRow[_cEmail] = dlg.P_Customer.Email;
                    focusRow[_cPhone] = dlg.P_Customer.SDT;
                    focusRow[_cPayed] = dlg.P_Customer.TotalMoney;
                    focusRow[_cSmartLink] = dlg.P_Customer.SmarkLink;
                    focusRow[_cStatus] = dlg.P_Customer.TINHTRANG;
                    focusRow[_cLevelCard] = dlg.P_Customer.smartlink.SmarkLink;

                    gridView_Customer.LayoutChanged();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_Customer_DoubleClick");
            }
        }

        /// <summary>
        /// Load danh status
        /// </summary>
        private void LoadStatus()
        {
            DataTable tbStatus;
            string cStatusID = "StatusID";
            string cStatusName = "StatusName";

            try
            {
                tbStatus = new DataTable();
                tbStatus.Columns.Add(cStatusID);
                tbStatus.Columns.Add(cStatusName);

                tbStatus.Rows.Add(1, "Đang dùng");
                tbStatus.Rows.Add(1, "Tạm khoá");
                tbStatus.Rows.Add("", "Tất cả");

                repositoryItemLookUpEdit_Cutomer.DisplayMember = cStatusName;
                repositoryItemLookUpEdit_Cutomer.ValueMember = cStatusID;
                repositoryItemLookUpEdit_Cutomer.DataSource = tbStatus;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadStatus");
            }
        }
    }
}