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
    public partial class frm_Table : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        public mycoffeeEntities _dbContext;
        private DataTable _tbSource;

        #region ColumnName
        private const string _cTableID= "TableID";
        private const string _cTableCode= "TableCode";
        private const string _cAreaID = "AreaID";
        private const string _cAreaCode = "AreaCode";
        private const string _cStatus = "Status";

        #endregion //--- ColumnName

        #endregion //--- Fields

        public frm_Table()
        {
            InitializeComponent();
        }

        private void frm_Table_Load(object sender, EventArgs e)
        {
            DataRow newRow;
            List<area_table> area_tbls ;

            try
            {
                //--- Tạo cấu trúc table mặc định
                _tbSource = CreateTableStruct();

                LoadTableStatus();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                area_tbls = (from p in _dbContext.area_table.ToList() select p).OrderByDescending(o => o.TableID).ToList();
                if (area_tbls != null && area_tbls.Count > 0)
                {
                    foreach (area_table tbl in area_tbls)
                    {
                        newRow = _tbSource.NewRow();
                        newRow[_cTableID] = tbl.TableID;
                        newRow[_cTableCode] = tbl.TableCode;
                        newRow[_cAreaID] = tbl.AreaID;
                        newRow[_cAreaCode] = tbl.area.AreaCode;
                        newRow[_cStatus] = tbl.Status;

                        _tbSource.Rows.Add(newRow);
                    }
                }
                gridControl_AreaTable.DataSource = _tbSource;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Table_Load");
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
                tbSource.Columns.Add(_cTableID);
                tbSource.Columns.Add(_cTableCode);
                tbSource.Columns.Add(_cAreaID);
                tbSource.Columns.Add(_cAreaCode);
                tbSource.Columns.Add(_cStatus);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cTableID] };
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
        private void LoadTableStatus()
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

                repositoryItemLookUpEdit_Status.DisplayMember = cStatusName;
                repositoryItemLookUpEdit_Status.ValueMember = cStatusID;
                repositoryItemLookUpEdit_Status.DataSource = tbStatus;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadTableStatus");
            }
        }

        private void gridView_AreaTable_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "gridView_AreaTable_RowCellStyle");
            }
        }

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddEditTable dlg;
            area_table area_tbl;
            DataRow row;
            try
            {
                dlg = new frm_AddEditTable();
                area_tbl = new area_table();
                dlg._dbContext = _dbContext;
                dlg.P_AreaTable = area_tbl;
                dlg.Text = "Thêm Mới Bàn";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.area_table.Add(dlg.P_AreaTable);
                    _dbContext.SaveChanges();

                    row = _tbSource.NewRow();
                    row[_cTableID] = dlg.P_AreaTable.TableID;
                    row[_cTableCode] = dlg.P_AreaTable.TableCode;
                    row[_cAreaID] = dlg.P_AreaTable.AreaID;
                    row[_cAreaCode] = dlg.P_AreaTable.area.AreaCode;
                    row[_cStatus] = dlg.P_AreaTable.Status;

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
            frm_AddEditTable dlg;
            area_table tbl, updateArea_Tbl;
            DataRow updateRow;
            try
            {
                if (gridView_AreaTable.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có bàn nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                updateRow = gridView_AreaTable.GetFocusedDataRow();
                tbl = new area_table();

                tbl.TableID = Convert.ToInt32(updateRow[_cTableID]);
                tbl.TableCode = updateRow[_cTableCode].ToString();
                tbl.AreaID = Convert.ToInt32(updateRow[_cAreaID]);
                tbl.Status = Convert.ToInt32(updateRow[_cStatus]);

                dlg = new frm_AddEditTable();
                dlg.P_AreaTable = tbl;
                dlg._dbContext = _dbContext;
                dlg.Text = "Sửa Bàn";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    updateArea_Tbl = (from ar in _dbContext.area_table.ToList() where ar.TableID == tbl.TableID select ar).FirstOrDefault();
                    if (updateArea_Tbl != null)
                    {
                        updateArea_Tbl.TableCode = dlg.P_AreaTable.TableCode;
                        updateArea_Tbl.AreaID = dlg.P_AreaTable.AreaID;
                        updateArea_Tbl.Status = dlg.P_AreaTable.Status;

                        _dbContext.SaveChanges();

                        updateRow[_cTableCode] = dlg.P_AreaTable.TableCode.ToString();
                        updateRow[_cAreaCode] = dlg.AreaCode.ToString();
                        updateRow[_cStatus] = dlg.P_AreaTable.Status;

                        gridView_AreaTable.LayoutChanged();
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Update_ItemClick");
            }
        }

        private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            area_table deleteAreaTbl;
            DataRow deleteRow;
            int TableID;
            try
            {
                if (gridView_AreaTable.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có bàn nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn chắc chắn muốn xóa bàn này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                deleteRow = gridView_AreaTable.GetFocusedDataRow();
                TableID = Convert.ToInt32(deleteRow[_cTableID]);

                deleteAreaTbl = (from mop in _dbContext.area_table.ToList() where mop.TableID == TableID select mop).FirstOrDefault();
                if (deleteAreaTbl != null)
                {
                    var table_order = from mop in _dbContext.listorders.ToList() where mop.TableID == deleteAreaTbl.TableID select mop;
                    if (table_order != null)
                    {
                        XtraMessageBox.Show("Không thể xóa, khu vực này đang tồn tại trong đơn hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _dbContext.area_table.Remove(deleteAreaTbl);
                    _dbContext.SaveChanges();
                    gridView_AreaTable.DeleteRow(gridView_AreaTable.GetSelectedRows()[0]);
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
    }
}