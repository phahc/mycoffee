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
    public partial class frm_PlanWork : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        public mycoffeeEntities _dbContext;
        private DataTable _tbSource;

        private const string _cPlanWorkID = "PlanWorkID";
        private const string _cPlanWorkName = "PlanWorkName";
        private const string _cStartTime = "StartTime";
        private const string _cEndTime = "EndTime";
        private const string _cNotes = "Notes";
        private const string _cStatus = "Status";
        private const string _cSystemKey = "SystemKey";
        #endregion

        #region Form Method
        public frm_PlanWork()
        {
            InitializeComponent();
        }

        private void frm_PlanWork_Load(object sender, EventArgs e)
        {

            DataRow newRow;
            List<planwork> planwork;

            try
            {

                LoadPlanWorksStatus();
                //--- Tạo cấu trúc table mặc định
                _tbSource = CreateTableStruct();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                planwork = (from p in _dbContext.planworks.ToList() select p).OrderBy(o => o.PlanWorkName).ToList();
                if (planwork != null && planwork.Count > 0)
                {
                    foreach (planwork pl in planwork)
                    {
                        newRow = _tbSource.NewRow();
                        newRow[_cPlanWorkID] = pl.PlanWorkID;
                        newRow[_cPlanWorkName] = pl.PlanWorkName;
                        newRow[_cStartTime] = pl.StartTime;
                        newRow[_cEndTime] = pl.EndTime;
                        newRow[_cNotes] = pl.Notes;
                        newRow[_cStatus] = pl.Status;
                        newRow[_cSystemKey] = pl.SystemKey;
                        _tbSource.Rows.Add(newRow);
                    }
                }
                gridControl_PlanWork.DataSource = _tbSource;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_PlanWork_Load");
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
                tbSource.Columns.Add(_cPlanWorkID);
                tbSource.Columns.Add(_cPlanWorkName);
                tbSource.Columns.Add(_cStartTime);
                tbSource.Columns.Add(_cEndTime);
                tbSource.Columns.Add(_cNotes);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cSystemKey);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cPlanWorkID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Load danh sách PlanWorks status
        /// </summary>
        private void LoadPlanWorksStatus()
        {
            DataTable tbStatus;
            string cStatusID = "StatusID";
            string cStatusName = "StatusName";

            try
            {
                // Trạng thái sản phẩm
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
                XtraMessageBox.Show(ex.Message, "LoadProductsStatus");
            }
        }


        #endregion

        #region Actions
        #endregion

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddEditPlanWork dlg;
            planwork planwork;
            DataRow newRow;
            try
            {
                dlg = new frm_AddEditPlanWork();
                planwork = new planwork();
                dlg.P_Planwork = planwork;
                dlg.Text = "Thêm Ca Làm Việc";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                    _dbContext.planworks.Add(dlg.P_Planwork);
                    _dbContext.SaveChanges();

                    newRow = _tbSource.NewRow();
                    newRow[_cPlanWorkID] = dlg.P_Planwork.PlanWorkID;
                    newRow[_cPlanWorkName] = dlg.P_Planwork.PlanWorkName;
                    newRow[_cStartTime] = dlg.P_Planwork.StartTime;
                    newRow[_cEndTime] = dlg.P_Planwork.EndTime;
                    newRow[_cNotes] = dlg.P_Planwork.Notes;
                    newRow[_cStatus] = dlg.P_Planwork.Status;
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
            frm_AddEditPlanWork dlg;
            planwork updatePlanwork, planWork;
            DataRow updateRow;

            try
            {
                if (gridView_PlanWork.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có ca nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                updateRow = gridView_PlanWork.GetFocusedDataRow();
                planWork = new planwork();

                planWork.PlanWorkID = Convert.ToInt32(updateRow[_cPlanWorkID]);
                planWork.PlanWorkName = updateRow[_cPlanWorkName].ToString();
                planWork.StartTime = updateRow[_cStartTime].ToString();
                planWork.EndTime = updateRow[_cEndTime].ToString();
                planWork.Notes = updateRow[_cNotes].ToString();
                planWork.Status = Convert.ToInt32(updateRow[_cStatus]);

                dlg = new frm_AddEditPlanWork();
                dlg.P_Planwork = planWork;
                dlg.Text = "Sửa Ca Làm Việc";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    updatePlanwork = (from p in _dbContext.planworks.ToList() where p.PlanWorkID == planWork.PlanWorkID select p).FirstOrDefault();
                    if (updatePlanwork != null)
                    {
                        updatePlanwork.PlanWorkName = dlg.P_Planwork.PlanWorkName;
                        updatePlanwork.StartTime = dlg.P_Planwork.StartTime;
                        updatePlanwork.EndTime = dlg.P_Planwork.EndTime;
                        updatePlanwork.Notes = dlg.P_Planwork.Notes;
                        updatePlanwork.Status = dlg.P_Planwork.Status;

                        _dbContext.SaveChanges();

                        updateRow[_cPlanWorkName] = updatePlanwork.PlanWorkName;
                        updateRow[_cStartTime] = updatePlanwork.StartTime;
                        updateRow[_cEndTime] = updatePlanwork.EndTime;
                        updateRow[_cNotes] = updatePlanwork.Notes;
                        updateRow[_cStatus] = updatePlanwork.Status;

                        gridView_PlanWork.LayoutChanged();
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
            planwork deletePlanWork;
            DataRow deleteRow;
            int PlanWorkID;

            try
            {
                if (gridView_PlanWork.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có ca làm việc nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn chắc chắn muốn xóa ca làm việc này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                deleteRow = gridView_PlanWork.GetFocusedDataRow();

                if (Convert.ToInt32(deleteRow[_cSystemKey]) == 1)
                {
                    XtraMessageBox.Show("Không thể xóa dữ liệu thuộc về hệ thống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PlanWorkID = Convert.ToInt32(deleteRow[_cPlanWorkID]);

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                deletePlanWork = (from p in _dbContext.planworks.ToList() where p.PlanWorkID == PlanWorkID select p).FirstOrDefault();
                if (deletePlanWork != null)
                {
                    deletePlanWork.Status = 2;
                    _dbContext.SaveChanges();
                    gridView_PlanWork.DeleteRow(gridView_PlanWork.GetSelectedRows()[0]);
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

        private void gridControl_PlanWork_DoubleClick(object sender, EventArgs e)
        {
            frm_AddEditPlanWork dlg;
            planwork updatePlanwork, planWork;
            DataRow updateRow;

            try
            {
                if (gridView_PlanWork.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có ca nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                updateRow = gridView_PlanWork.GetFocusedDataRow();
                planWork = new planwork();

                planWork.PlanWorkID = Convert.ToInt32(updateRow[_cPlanWorkID]);
                planWork.PlanWorkName = updateRow[_cPlanWorkName].ToString();
                planWork.StartTime = updateRow[_cStartTime].ToString();
                planWork.EndTime = updateRow[_cEndTime].ToString();
                planWork.Notes = updateRow[_cNotes].ToString();
                planWork.Status = Convert.ToInt32(updateRow[_cStatus]);

                dlg = new frm_AddEditPlanWork();
                dlg.P_Planwork = planWork;
                dlg.Text = "Sửa Ca Làm Việc";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    updatePlanwork = (from p in _dbContext.planworks.ToList() where p.PlanWorkID == planWork.PlanWorkID select p).FirstOrDefault();
                    if (updatePlanwork != null)
                    {
                        updatePlanwork.PlanWorkName = dlg.P_Planwork.PlanWorkName;
                        updatePlanwork.StartTime = dlg.P_Planwork.StartTime;
                        updatePlanwork.EndTime = dlg.P_Planwork.EndTime;
                        updatePlanwork.Notes = dlg.P_Planwork.Notes;
                        updatePlanwork.Status = dlg.P_Planwork.Status;

                        _dbContext.SaveChanges();

                        updateRow[_cPlanWorkName] = updatePlanwork.PlanWorkName;
                        updateRow[_cStartTime] = updatePlanwork.StartTime;
                        updateRow[_cEndTime] = updatePlanwork.EndTime;
                        updateRow[_cNotes] = updatePlanwork.Notes;
                        updateRow[_cStatus] = updatePlanwork.Status;

                        gridView_PlanWork.LayoutChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_PlanWork_DoubleClick");
            }
        }

    }
}