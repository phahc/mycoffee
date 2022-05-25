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
    public partial class frm_CustomerSkin : DevExpress.XtraEditors.XtraForm
    {
        private mycoffeeEntities _dbContext;
        private DataTable _tbSource;

        private const string _cSmartLinkID = "SmartLinkID";
        private const string _cSmartLinkName= "SmartLinkName";
        private const string _cMoneyLevel = "MoneyLevel";
        private const string _cPercent = "Percent";
        private const string _cStatus = "Status";

        public frm_CustomerSkin()
        {
            InitializeComponent();
        }

        private void frm_CustomerSkin_Load(object sender, EventArgs e)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                //khởi tạo cấu trúc cho gridview
                _tbSource = CreateTableStruct();

                LoadStatus();
                LoadSmartLink();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_CustomerSkin_Load");
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
                tbSource.Columns.Add(_cSmartLinkID);
                tbSource.Columns.Add(_cSmartLinkName);
                tbSource.Columns.Add(_cMoneyLevel);
                tbSource.Columns.Add(_cPercent);
                tbSource.Columns.Add(_cStatus);

                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cSmartLinkID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        //Load danh sách cấp bậc thẻ
        private void LoadSmartLink()
        {
            List<smartlink> smartlinks;
            DataRow row;
            try
            {
                smartlinks = (from lk in _dbContext.smartlinks.ToList() select lk).ToList();
                if (smartlinks != null && smartlinks.Count > 0)
                {
                    foreach(smartlink sm in smartlinks)
                    {
                        row = _tbSource.NewRow();
                        row[_cSmartLinkID] = sm.ID;
                        row[_cSmartLinkName] = sm.SmarkLink;
                        row[_cMoneyLevel] = sm.LevelMoney;
                        row[_cPercent] = sm.Percent_SmarkLink;
                        row[_cStatus] = sm.Status;

                        _tbSource.Rows.Add(row);
                    }

                    gridControl_SmartLink.DataSource = _tbSource;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadSmartLink");
            }
        }

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            smartlink smartlinks;
            frm_AddEditCustomerSkin dlg;
            DataRow newRow;
            try
            {
                dlg = new frm_AddEditCustomerSkin();
                smartlinks = new smartlink();
                dlg.P_SmartLink = smartlinks;
                dlg.Text = "Thêm Loại Thành Viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.smartlinks.Add(dlg.P_SmartLink);
                    _dbContext.SaveChanges();

                    newRow = _tbSource.NewRow();
                    newRow[_cSmartLinkID] = dlg.P_SmartLink.ID;
                    newRow[_cSmartLinkName] = dlg.P_SmartLink.SmarkLink;
                    newRow[_cMoneyLevel] = dlg.P_SmartLink.LevelMoney;
                    newRow[_cPercent] = dlg.P_SmartLink.Percent_SmarkLink;
                    newRow[_cStatus] = dlg.P_SmartLink.Status;

                    _tbSource.Rows.Add(newRow);
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Add_ItemClick");
            }
        }

        private void barButtonItem_Update_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            smartlink smartlinks;
            frm_AddEditCustomerSkin dlg;
            DataRow  focusRow;
            try
            {
                if (gridView_SmartLink.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn loại thành viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dlg = new frm_AddEditCustomerSkin();
                focusRow=gridView_SmartLink.GetFocusedDataRow();

                smartlinks = (from sm in _dbContext.smartlinks.ToList() where sm.SmarkLink == focusRow[_cSmartLinkName].ToString().Trim() select sm).FirstOrDefault();
                dlg.P_SmartLink = smartlinks;
                dlg.Text = "Sửa Loại Thành Viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    smartlinks.SmarkLink = dlg.P_SmartLink.SmarkLink;
                    smartlinks.LevelMoney = dlg.P_SmartLink.LevelMoney;
                    smartlinks.Status = dlg.P_SmartLink.Status;
                    smartlinks.Percent_SmarkLink = dlg.P_SmartLink.Percent_SmarkLink;

                    _dbContext.SaveChanges();

                    focusRow[_cSmartLinkName] = dlg.P_SmartLink.SmarkLink;
                    focusRow[_cMoneyLevel] = dlg.P_SmartLink.LevelMoney;
                    focusRow[_cPercent] = dlg.P_SmartLink.Percent_SmarkLink;
                    focusRow[_cStatus] = dlg.P_SmartLink.Status;

                    gridView_SmartLink.LayoutChanged();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Add_ItemClick");
            }
        }

        private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            smartlink smartlinks;
            DataRow focusRow;
            try
            {

                if (gridView_SmartLink.SelectedRowsCount<=0)
                {
                    XtraMessageBox.Show("Vui lòng chọn loại thành viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                focusRow = gridView_SmartLink.GetFocusedDataRow();

                smartlinks = (from sm in _dbContext.smartlinks.ToList() where sm.SmarkLink == focusRow[_cSmartLinkName].ToString().Trim() select sm).FirstOrDefault();
                if (smartlinks != null)
                {
                    smartlinks.Status =1;
                    _dbContext.SaveChanges();

                    gridView_SmartLink.DeleteRow(gridView_SmartLink.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Add_ItemClick");
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
                tbStatus.Rows.Add(2, "Tạm dừng");
                tbStatus.Rows.Add("", "Tất cả");

                repositoryItemLookUpEdit_Customer.DisplayMember = cStatusName;
                repositoryItemLookUpEdit_Customer.ValueMember = cStatusID;
                repositoryItemLookUpEdit_Customer.DataSource = tbStatus;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadStatus");
            }
        }
    }
}