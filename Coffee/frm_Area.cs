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
using DevExpress.XtraGrid.Views.Grid;

namespace Coffee
{
    public partial class frm_Area : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        public mycoffeeEntities _dbContext;
        private DataTable _tbSource;

        #region ColumnName

        private const string _cAreaID = "AreaID";
        private const string _cAreaCode = "AreaCode";
        private const string _cStatus = "Status";
        private const string _cSystemKey = "SystemKey";

        #endregion //--- ColumnName

        #endregion //--- Fields

        #region Form Method
        public frm_Area()
        {
            InitializeComponent();
        }

        private void frm_Area_Load(object sender, EventArgs e)
        {
            DataRow newRow;
            List<area> areas;

            try
            {
                //--- Tạo cấu trúc table mặc định
                _tbSource = CreateTableStruct();

                LoadAreasStatus();

                LoadAreaDeleted();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                areas = (from p in _dbContext.areas.ToList() select p).OrderBy(o => o.AreaCode).ToList();
                if (areas != null && areas.Count > 0)
                {
                    foreach (area area in areas)
                    {
                        newRow = _tbSource.NewRow();
                        newRow[_cAreaID] = area.AreaID;
                        newRow[_cAreaCode] = area.AreaCode;
                        newRow[_cStatus] = area.Status;
                        newRow[_cSystemKey] = area.SystemKey;
                        _tbSource.Rows.Add(newRow);
                    }
                }
                gridControl_Area.DataSource = _tbSource;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Area_Load");
            }
        }

        #endregion

        #region Helpers
        /// <summary>
        /// Tạo cấu trúc mặc định cho gridView
        /// </summary>
        private DataTable CreateTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cAreaID);
                tbSource.Columns.Add(_cAreaCode);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cSystemKey);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cAreaID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Load danh sách Products status
        /// </summary>
        private void LoadAreasStatus()
        {
            DataTable tbStatus;
            string cStatusID = "StatusID";
            string cStatusName = "StatusName";

            try
            {
                tbStatus = new DataTable();
                tbStatus.Columns.Add(cStatusID);
                tbStatus.Columns.Add(cStatusName);

                tbStatus.Rows.Add(1, "Hoạt động");
                tbStatus.Rows.Add(2, "Tạm dừng");
                tbStatus.Rows.Add("", "Tất cả");

                repositoryItemLookUpEdit_Status.DisplayMember = cStatusName;
                repositoryItemLookUpEdit_Status.ValueMember = cStatusID;
                repositoryItemLookUpEdit_Status.DataSource = tbStatus;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadAreasStatus");
            }
        }

        /// <summary>
        /// Load danh sách Area Deleted
        /// </summary>
        private void LoadAreaDeleted()
        {
            DataTable tbDeleted;
            string cStatusID = "StatusID";
            string cStatusName = "StatusName";

            try
            {
                tbDeleted = new DataTable();
                tbDeleted.Columns.Add(cStatusID);
                tbDeleted.Columns.Add(cStatusName);

                tbDeleted.Rows.Add(1, "Đang dùng");
                tbDeleted.Rows.Add(2, "Đã xóa");
                tbDeleted.Rows.Add("", "Tất cả");

                repositoryItemLookUpEdit_Deleted.DisplayMember = cStatusName;
                repositoryItemLookUpEdit_Deleted.ValueMember = cStatusID;
                repositoryItemLookUpEdit_Deleted.DataSource = tbDeleted;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadMenuDeleted");
            }
        }
        #endregion

        #region Actions
        private void button_Add_Click(object sender, EventArgs e)
        {
            frm_AddEditArea dlg;
            area area;
            DataRow row;
            try
            {
                dlg = new frm_AddEditArea();
                area = new area();
                dlg._dbContext = _dbContext;
                dlg.P_Area = area;
                dlg.Text = "Thêm Mới Khu Vực";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.areas.Add(dlg.P_Area);
                    _dbContext.SaveChanges();

                    row = _tbSource.NewRow();
                    row[_cAreaID] = dlg.P_Area.AreaID;
                    row[_cAreaCode] = dlg.P_Area.AreaCode;
                    row[_cStatus] = dlg.P_Area.Status;

                    _tbSource.Rows.Add(row);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Add_Click");
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            frm_AddEditArea dlg;
            area area, updateArea;
            DataRow updateRow;
            try
            {
                if (gridView_Area.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có khu vực nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                updateRow = gridView_Area.GetFocusedDataRow();

                area = new area();

                area.AreaID = Convert.ToInt32(updateRow[_cAreaID]);
                area.AreaCode = updateRow[_cAreaCode].ToString();
                area.Status = Convert.ToInt32(updateRow[_cStatus]);

                dlg = new frm_AddEditArea();
                dlg.P_Area = area;
                dlg._dbContext = _dbContext;
                dlg.Text = "Sửa Khu Vực";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    updateArea = (from ar in _dbContext.areas.ToList() where ar.AreaID == area.AreaID select ar).FirstOrDefault();
                    if (updateArea != null)
                    {
                        updateArea.AreaCode = dlg.P_Area.AreaCode;
                        updateArea.Status = dlg.P_Area.Status;

                        _dbContext.SaveChanges();

                        updateRow[_cAreaCode] = dlg.P_Area.AreaCode.ToString();
                        updateRow[_cStatus] = dlg.P_Area.Status;

                        gridView_Area.LayoutChanged();
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
            area deleteArea;
            DataRow deleteRow;
            int AreaID;
            try
            {
                if (gridView_Area.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có khu vực nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn chắc chắn muốn xóa khu vực này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                deleteRow = gridView_Area.GetFocusedDataRow();

                if (Convert.ToInt32(deleteRow[_cSystemKey]) == 1)
                {
                    XtraMessageBox.Show("Bạn không được phép xóa dữ liệu hệ thống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AreaID = Convert.ToInt32(deleteRow[_cAreaID]);

                deleteArea = (from a in _dbContext.areas.ToList() where a.AreaID == AreaID select a).FirstOrDefault();
                if (deleteArea != null)
                {
                    deleteArea.Status = 2;
                    _dbContext.SaveChanges();
                    gridView_Area.DeleteRow(gridView_Area.GetSelectedRows()[0]);
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
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Close_Click");
            }
        }

        private void gridView_Area_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view;
            DataRow row;
            int areaStatus;
            try
            {
                view = sender as GridView;
                row = view.GetDataRow(e.RowHandle);
                if (row == null)
                    return;
                areaStatus = Convert.ToInt32(row[_cStatus]);

                #region RowStyle

                #endregion //--- RowStyle

                switch (areaStatus)
                {
                    case 1:
                        break;
                    case 2://--- Tạm dừng (Xám) 
                        e.Appearance.BackColor = Color.FromArgb(181, 181, 181);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Area_RowCellStyle");
            }
        }
        #endregion

        private void gridControl_Area_DoubleClick(object sender, EventArgs e)
        {
            frm_AddEditArea dlg;
            area area, updateArea;
            DataRow updateRow;
            try
            {
                if (gridView_Area.SelectedRowsCount == 0)
                {
                    return;
                }
                updateRow = gridView_Area.GetFocusedDataRow();

                area = new area();

                area.AreaID = Convert.ToInt32(updateRow[_cAreaID]);
                area.AreaCode = updateRow[_cAreaCode].ToString();
                area.Status = Convert.ToInt32(updateRow[_cStatus]);

                dlg = new frm_AddEditArea();
                dlg.P_Area = area;
                dlg._dbContext = _dbContext;
                dlg.Text = "Sửa Khu Vực";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    updateArea = (from ar in _dbContext.areas.ToList() where ar.AreaID == area.AreaID select ar).FirstOrDefault();
                    if (updateArea != null)
                    {
                        updateArea.AreaCode = dlg.P_Area.AreaCode;
                        updateArea.Status = dlg.P_Area.Status;

                        _dbContext.SaveChanges();

                        updateRow[_cAreaCode] = dlg.P_Area.AreaCode.ToString();
                        updateRow[_cStatus] = dlg.P_Area.Status;

                        gridView_Area.LayoutChanged();
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_Area_DoubleClick");
            }
        }
    }
}
