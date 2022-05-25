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
    public partial class frm_MadeIn : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        public mycoffeeEntities _dbContext;
        private DataTable _tbSource;

        private const string _cMadeInID = "MadeInID";
        private const string _cMadeInName = "MadeInName";
        private const string _cShortName = "ShortName";
        private const string _cStatus = "Status";
        private const string _cSystemKey = "SystemKey";
        #endregion

        #region Form Method
        public frm_MadeIn()
        {
            InitializeComponent();
        }
        private void frm_MadeIn_Load(object sender, EventArgs e)
        {
            try
            {
                DataRow newRow;
                List<madein> madeins;
                //--- Tạo cấu trúc table mặc định
                _tbSource = CreateTableStruct();

                LoadStatus();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                madeins = (from p in _dbContext.madeins.ToList() select p).OrderBy(o => o.MadeInID).ToList();
                if (madeins != null && madeins.Count > 0)
                {
                    foreach (madein md in madeins)
                    {
                        newRow = _tbSource.NewRow();
                        newRow[_cMadeInID] = md.MadeInID;
                        newRow[_cMadeInName] = md.MadeInName;
                        newRow[_cShortName] = md.ShortName;
                        newRow[_cStatus] = md.Status;
                        newRow[_cSystemKey] = md.SystemKey;

                        _tbSource.Rows.Add(newRow);
                    }
                }
                gridControl_MadeIn.DataSource = _tbSource;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_MadeIn_Load");
            }

        }
        #endregion

        #region Actions
        /// <summary>
        /// Tạo cấu trúc mặc định cho gridView
        /// </summary>
        private DataTable CreateTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cMadeInID, typeof(int));
                tbSource.Columns.Add(_cMadeInName);
                tbSource.Columns.Add(_cShortName);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cSystemKey);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cMadeInID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }
        #endregion

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddEditMadeIn dlg;
            madein madein;
            DataRow newRow;

            try
            {
                dlg = new frm_AddEditMadeIn();
                madein = new madein();
                dlg.P_madein = madein;
                dlg.Text = "Thêm Nhà Cung Cấp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    _dbContext.madeins.Add(dlg.P_madein);
                    _dbContext.SaveChanges();

                    newRow = _tbSource.NewRow();
                    newRow[_cMadeInID] = dlg.P_madein.MadeInID;
                    newRow[_cShortName] = dlg.P_madein.MadeInName;
                    newRow[_cShortName] = dlg.P_madein.ShortName;
                    newRow[_cStatus] = dlg.P_madein.Status;
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
            frm_AddEditMadeIn dlg;
            madein madein, updateMadeIn;
            DataRow row;
            try
            {
                row = gridView_MadeIn.GetFocusedDataRow();
                madein = new madein();
                madein.MadeInID = Convert.ToInt32(row[_cMadeInID]);
                madein.MadeInName = row[_cMadeInName].ToString();
                madein.ShortName = row[_cShortName].ToString();
                madein.Status = Convert.ToInt32(row[_cStatus]);

                if (Convert.ToInt32(row[_cMadeInID]) == 1)
                {
                    XtraMessageBox.Show("Không thể sửa dữ liệu thuộc về hệ thống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dlg = new frm_AddEditMadeIn();
                dlg.P_madein = madein;
                dlg.Text = "Sửa Nhà Cung Cấp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    updateMadeIn = (from m in _dbContext.madeins.ToList() where m.MadeInID == m.MadeInID select m).FirstOrDefault();

                    updateMadeIn.MadeInName = dlg.P_madein.MadeInName;
                    updateMadeIn.ShortName = dlg.P_madein.ShortName;
                    updateMadeIn.Status = dlg.P_madein.Status;

                    _dbContext.SaveChanges();

                    row[_cMadeInName] = dlg.P_madein.MadeInName;
                    row[_cShortName] = dlg.P_madein.ShortName;
                    row[_cStatus] = dlg.P_madein.Status;

                    gridView_MadeIn.LayoutChanged();

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Update_ItemClick");
            }
        }

        private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            madein deleteMadeIn;
            DataRow deleteRow;
            int MadeInID;

            try
            {
                if (gridView_MadeIn.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Chưa chọn nhà cung cấp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn chắc chắn muốn xóa nhà cung cấp này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                deleteRow = gridView_MadeIn.GetFocusedDataRow();

                if (Convert.ToInt32(deleteRow[_cSystemKey]) == 1)
                {
                    XtraMessageBox.Show("Không thể xóa dữ liệu thuộc về hệ thống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MadeInID = Convert.ToInt32(deleteRow[_cMadeInID]);


                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                deleteMadeIn = (from m in _dbContext.madeins.ToList() where m.MadeInID == MadeInID select m).FirstOrDefault();
                if (deleteMadeIn != null)
                {
                    deleteMadeIn.Status = 2;
                    _dbContext.SaveChanges();
                    gridView_MadeIn.DeleteRow(gridView_MadeIn.GetSelectedRows()[0]);
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

                repositoryItemLookUpEdit_MadeIn2.DisplayMember = cStatusName;
                repositoryItemLookUpEdit_MadeIn2.ValueMember = cStatusID;
                repositoryItemLookUpEdit_MadeIn2.DataSource = tbStatus;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadAreasStatus");
            }
        }
    }
}