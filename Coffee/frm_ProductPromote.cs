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
    public partial class frm_ProductPromote : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        public mycoffeeEntities _dbContext;
        private DataTable _tbPromoteSource;
        private DataTable _tbPromote_DetailSource;

        #region ColumnName

        private const string _cProductID = "ProductID";
        private const string _cProductName = "ProductName";
        private const string _cProductCode = "ProductCode";
        private const string _cPrice = "Price";
        private const string _cStartDate = "StartDate";
        private const string _cEndDate = "EndDate";
        private const string _cID = "ID";
        private const string _cPromoteID = "PromoteID";
        private const string _cPromoteName = "PromoteName";


        #endregion //--- ColumnName

        #endregion //--- Fields

        #region Form Method
        public frm_ProductPromote()
        {
            InitializeComponent();
        }

        private void frm_ProductPromote_Load(object sender, EventArgs e)
        {
            try
            {

                //Tạo cấu trúc bảng chương trình khuyến mãi
                LoadPromote();
                //--- Tạo cấu trúc table mặc định
                _tbPromote_DetailSource = CreateTablePromote_DetailStruct();


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_ProductPromote_Load");
            }
        }
        #endregion

        #region Helpers
        private void LoadPromote()
        {
            List<promote> promotes;
            DataRow newRow;
            try
            {
                //--- Tạo cấu trúc table mặc định
                _tbPromoteSource = CreateTablePromoteStruct();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                promotes = (from p in _dbContext.promotes.ToList()
                            where p.Deleted == 2 && p.StartDate.Month == DateTime.Now.Month &&
                                p.StartDate.Year == DateTime.Now.Year
                            select p).OrderByDescending(o => o.EndDate).ToList();

                if (promotes != null && promotes.Count > 0)
                {
                    foreach (promote promote in promotes)
                    {
                        newRow = _tbPromoteSource.NewRow();
                        newRow[_cPromoteID] = promote.PromoteID;
                        newRow[_cPromoteName] = promote.PromoteName;
                        newRow[_cStartDate] = promote.StartDate;
                        newRow[_cEndDate] = promote.EndDate;
                        _tbPromoteSource.Rows.Add(newRow);
                    }
                }
                gridControl_Promote.DataSource = _tbPromoteSource;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadPromote");
            }
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho gridView Promote
        /// </summary>
        private DataTable CreateTablePromoteStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cPromoteID);
                tbSource.Columns.Add(_cPromoteName);
                tbSource.Columns.Add(_cStartDate);
                tbSource.Columns.Add(_cEndDate);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cPromoteID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTablePromoteStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho gridView Promote_Detail
        /// </summary>
        private DataTable CreateTablePromote_DetailStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cID);
                tbSource.Columns.Add(_cPromoteID);
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cStartDate);
                tbSource.Columns.Add(_cEndDate);
                tbSource.Columns.Add(_cPrice);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTablePromote_DetailStruct");
                return tbSource;
            }
            return tbSource;
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
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cProductCode);
                tbSource.Columns.Add(_cPrice);
                tbSource.Columns.Add(_cStartDate);
                tbSource.Columns.Add(_cEndDate);
                tbSource.Columns.Add(_cPromoteID);
                tbSource.Columns.Add(_cPromoteName);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cProductID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }
        #endregion

        #region Actions
        private void button_Add_Click(object sender, EventArgs e)
        {
            frm_AddEditProductPromote dlg;
            promote promote;
            promote_detail promote_detail;
            DataRow newRow;

            try
            {
                dlg = new frm_AddEditProductPromote();
                promote = new promote();
                promote_detail = new promote_detail();
                dlg.P_Promote = promote;
                dlg.P_OpenType = CoffeeHelpers.OpenType.None;
                dlg.P_Promote_detail = promote_detail;
                dlg._dbContext = _dbContext;
                dlg.Text = "Thêm Chương Trình Khuyến Mãi";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    dlg.P_Promote.Deleted = 2;
                    _dbContext.promotes.Add(dlg.P_Promote);
                    _dbContext.SaveChanges();

                    //THêm vào bảng chi tiết khuyến mãi
                    dlg.P_Promote_detail.PromoteID = dlg.P_Promote.PromoteID;
                    dlg.P_Promote_detail.Deleted = 2;
                    _dbContext.promote_detail.Add(dlg.P_Promote_detail);
                    _dbContext.SaveChanges();

                    newRow = _tbPromoteSource.NewRow();
                    newRow[_cPromoteID] = dlg.P_Promote.PromoteID;
                    newRow[_cPromoteName] = dlg.P_Promote.PromoteName;
                    newRow[_cStartDate] = dlg.P_Promote.StartDate;
                    newRow[_cEndDate] = dlg.P_Promote.EndDate;

                    _tbPromoteSource.Rows.Add(newRow);

                    newRow = _tbPromote_DetailSource.NewRow();
                    newRow[_cID] = dlg.P_Promote_detail.ID;
                    newRow[_cPromoteID] = dlg.P_Promote.PromoteID;
                    newRow[_cProductID] = dlg.P_Promote_detail.product.ProductID;
                    newRow[_cProductName] = dlg.P_Promote_detail.product.ProductName;
                    newRow[_cStartDate] = dlg.P_Promote_detail.StartDate;
                    newRow[_cEndDate] = dlg.P_Promote_detail.EndDate;
                    newRow[_cPrice] = dlg.P_Promote_detail.Price;

                    _tbPromote_DetailSource.Rows.Add(newRow);
                    gridControl_ProductPromote.DataSource = _tbPromote_DetailSource;

                _back:
                    var confirmResult_New = XtraMessageBox.Show("Tiếp tục thêm?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirmResult_New == DialogResult.OK)
                    {
                        frm_AddEditProductPromote dlg_new;
                        DataRow rowSelect, rowDetail_select, newRow_New;
                        promote_detail promote_detail_New;
                        promote promote_New;

                        rowSelect = gridView_Promote.GetFocusedDataRow();
                        rowDetail_select = gridView_Product.GetFocusedDataRow();

                        promote_New = new promote();

                        promote_New.PromoteID = Convert.ToInt32(rowSelect[_cPromoteID]);
                        promote_New.PromoteName = rowSelect[_cPromoteName].ToString();

                        promote_detail_New = new promote_detail();
                        promote_detail_New.ID = 0;
                        promote_detail_New.ProductID = Convert.ToInt32(rowDetail_select[_cProductID]);

                        dlg_new = new frm_AddEditProductPromote();
                        dlg_new.P_Promote = promote_New;
                        dlg_new.P_Promote_detail = promote_detail_New;
                        dlg_new.P_OpenType = CoffeeHelpers.OpenType.AddEdit;
                        dlg_new._dbContext = _dbContext;
                        dlg_new.checkUpdateExist = false;
                        dlg_new.Text = "Thêm Sản Phẩm Khuyến Mãi";
                        if (dlg_new.ShowDialog() == DialogResult.OK)
                        {
                            if (dlg_new.checkUpdateExist == false)
                            {
                                dlg.P_Promote_detail.Deleted = 2;
                                _dbContext.promote_detail.Add(dlg_new.P_Promote_detail);

                                _dbContext.SaveChanges();

                                newRow_New = _tbPromote_DetailSource.NewRow();
                                newRow_New[_cID] = dlg_new.P_Promote_detail.ID;
                                newRow_New[_cPromoteID] = dlg_new.P_Promote.PromoteID;
                                newRow_New[_cProductID] = dlg_new.P_Promote_detail.product.ProductID;
                                newRow_New[_cProductName] = dlg_new.P_Promote_detail.product.ProductName;
                                newRow_New[_cStartDate] = dlg_new.P_Promote_detail.StartDate;
                                newRow_New[_cEndDate] = dlg_new.P_Promote_detail.EndDate;
                                newRow_New[_cPrice] = dlg_new.P_Promote_detail.Price;

                                _tbPromote_DetailSource.Rows.Add(newRow_New);

                                gridControl_ProductPromote.DataSource = _tbPromote_DetailSource;
                            }
                            else
                            {
                                promote_detail = (from p in _dbContext.promote_detail.ToList() where p.PromoteID == dlg_new.P_Promote_detail.PromoteID && p.Deleted == 1 select p).FirstOrDefault();

                                promote_detail.Deleted = 2;
                                promote_detail.Price = dlg_new.P_Promote_detail.Price;
                                promote_detail.StartDate = dlg_new.P_Promote_detail.StartDate;
                                promote_detail.EndDate = dlg_new.P_Promote_detail.EndDate;

                                _dbContext.SaveChanges();

                                //--- Select ngay sản phẩm đang chỉnh sửa
                                for (int i = 0; i < gridView_Product.RowCount; i++)
                                {
                                    if (gridView_Product.GetRowCellValue(i, _cID).ToString().Contains(dlg.P_Promote_detail.ID.ToString()) == true)
                                    {
                                        gridView_Product.FocusedRowHandle = i;
                                        continue;
                                    }
                                }

                                rowDetail_select[_cPrice] = dlg_new.P_Promote_detail.Price.ToString();
                                rowDetail_select[_cStartDate] = dlg_new.P_Promote_detail.StartDate;
                                rowDetail_select[_cEndDate] = dlg_new.P_Promote_detail.EndDate;

                                gridView_Product.LayoutChanged();
                            }
                            goto _back;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Add_Click");
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

        private void button_Update_Click(object sender, EventArgs e)
        {
            frm_AddEditProductPromote dlg;
            promote promote, updatePromote;
            DataRow promoteRow;
            try
            {
                promoteRow = gridView_Promote.GetFocusedDataRow();
                promote = new promote();
                promote.PromoteID = Convert.ToInt32(promoteRow[_cPromoteID]);
                promote.PromoteName = promoteRow[_cPromoteName].ToString();
                promote.StartDate = Convert.ToDateTime(promoteRow[_cStartDate].ToString());
                promote.EndDate = Convert.ToDateTime(promoteRow[_cEndDate].ToString());

                dlg = new frm_AddEditProductPromote();
                dlg.P_Promote = promote;
                dlg.P_OpenType = CoffeeHelpers.OpenType.None;
                dlg._dbContext = _dbContext;
                dlg.Text = "Sửa Chương Trình Khuyến Mãi";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    updatePromote = (from p in _dbContext.promotes.ToList() where p.PromoteID == promote.PromoteID select p).FirstOrDefault();
                    if (updatePromote != null)
                    {
                        updatePromote.PromoteID = promote.PromoteID;
                        updatePromote.PromoteName = dlg.P_Promote.PromoteName;
                        updatePromote.StartDate = dlg.P_Promote.StartDate;
                        updatePromote.EndDate = dlg.P_Promote.EndDate;

                        _dbContext.SaveChanges();

                        promoteRow[_cPromoteID] = promote.PromoteID;
                        promoteRow[_cPromoteName] = dlg.P_Promote.PromoteName;
                        promoteRow[_cStartDate] = dlg.P_Promote.StartDate;
                        promoteRow[_cEndDate] = dlg.P_Promote.EndDate;

                        gridView_Promote.LayoutChanged();
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
            DataRow promoteRow;
            try
            {
                promoteRow = gridView_Promote.GetFocusedDataRow();

                if (gridView_Promote.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có chương khuyến mãi nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn chắc chắn muốn xóa chương khuyến mãi này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                promote ps = (from p in _dbContext.promotes.ToList() where p.PromoteID == Convert.ToInt32(promoteRow[_cPromoteID]) select p).FirstOrDefault();
                if (ps != null)
                {
                    ps.Deleted = 1;
                    _dbContext.SaveChanges();
                    gridView_Promote.DeleteRow(gridView_Promote.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Delete_Click");
            }
        }

        private void btn_AddProducts_Click(object sender, EventArgs e)
        {
            frm_AddEditProductPromote dlg;
            DataRow rowSelect, rowDetail_select, newRow;
            promote_detail promote_detail;
            promote promote;
            try
            {
                if (gridView_Promote.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Không có chương trình khuyến mãi nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                rowSelect = gridView_Promote.GetFocusedDataRow();
                rowDetail_select = gridView_Product.GetFocusedDataRow();

            _back:

                promote = new promote();

                promote.PromoteID = Convert.ToInt32(rowSelect[_cPromoteID]);
                promote.PromoteName = rowSelect[_cPromoteName].ToString();
                promote.StartDate = Convert.ToDateTime(rowSelect[_cStartDate]);
                promote.EndDate = Convert.ToDateTime(rowSelect[_cEndDate]);

                promote_detail = new promote_detail();
                promote_detail.ID = 0;

                dlg = new frm_AddEditProductPromote();
                dlg.P_Promote = promote;
                dlg.P_Promote_detail = promote_detail;
                dlg.P_OpenType = CoffeeHelpers.OpenType.AddEdit;
                dlg.checkUpdateExist = false;
                dlg._dbContext = _dbContext;
                dlg.Text = "Thêm Sản Phẩm Khuyến Mãi";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.checkUpdateExist == false)
                    {
                        dlg.P_Promote_detail.Deleted = 2;
                        _dbContext.promote_detail.Add(dlg.P_Promote_detail);

                        _dbContext.SaveChanges();

                        newRow = _tbPromote_DetailSource.NewRow();

                        newRow[_cID] = dlg.P_Promote_detail.ID;
                        newRow[_cPromoteID] = dlg.P_Promote.PromoteID;
                        newRow[_cProductID] = dlg.P_Promote_detail.product.ProductID;
                        newRow[_cProductName] = dlg.P_Promote_detail.product.ProductName;
                        newRow[_cStartDate] = dlg.P_Promote_detail.StartDate;
                        newRow[_cEndDate] = dlg.P_Promote_detail.EndDate;
                        newRow[_cPrice] = dlg.P_Promote_detail.Price;

                        _tbPromote_DetailSource.Rows.Add(newRow);

                        gridControl_ProductPromote.DataSource = _tbPromote_DetailSource;
                    }
                    else
                    {
                        promote_detail = (from p in _dbContext.promote_detail.ToList() where p.PromoteID == dlg.P_Promote_detail.PromoteID && p.ProductID == dlg.P_Promote_detail.ProductID select p).FirstOrDefault();

                        promote_detail.Deleted = 2;
                        promote_detail.Price = dlg.P_Promote_detail.Price;
                        promote_detail.StartDate = dlg.P_Promote_detail.StartDate;
                        promote_detail.EndDate = dlg.P_Promote_detail.EndDate;

                        _dbContext.SaveChanges();

                        if (gridView_Product.RowCount <= 0)
                        {
                            List<promote_detail> promote_details;
                            _tbPromote_DetailSource = CreateTablePromote_DetailStruct();
                            promote_details = (from p in _dbContext.promote_detail.ToList() where p.PromoteID == Convert.ToInt32(rowSelect[_cPromoteID]) && p.Deleted == 2 select p).ToList();

                            if (promote_details != null)
                            {
                                foreach (var detail in promote_details)
                                {
                                    newRow = _tbPromote_DetailSource.NewRow();
                                    newRow[_cID] = detail.ID;
                                    newRow[_cPromoteID] = detail.PromoteID;
                                    newRow[_cProductID] = detail.ProductID;
                                    newRow[_cProductName] = detail.product.ProductName;
                                    newRow[_cStartDate] = detail.StartDate;
                                    newRow[_cEndDate] = detail.EndDate;
                                    newRow[_cPrice] = detail.Price;

                                    _tbPromote_DetailSource.Rows.Add(newRow);
                                }
                            }
                            gridControl_ProductPromote.DataSource = _tbPromote_DetailSource;
                        }

                        if (gridView_Product.RowCount <= 0)
                        {
                            List<promote_detail> promote_details;
                            _tbPromote_DetailSource = CreateTablePromote_DetailStruct();
                            promote_details = (from p in _dbContext.promote_detail.ToList() where p.PromoteID == Convert.ToInt32(rowSelect[_cPromoteID]) && p.Deleted == 1 select p).ToList();

                            if (promote_details != null)
                            {
                                foreach (var detail in promote_details)
                                {
                                    newRow = _tbPromote_DetailSource.NewRow();
                                    newRow[_cID] = detail.ID;
                                    newRow[_cPromoteID] = detail.PromoteID;
                                    newRow[_cProductID] = detail.ProductID;
                                    newRow[_cProductName] = detail.product.ProductName;
                                    newRow[_cStartDate] = detail.StartDate;
                                    newRow[_cEndDate] = detail.EndDate;
                                    newRow[_cPrice] = detail.Price;

                                    _tbPromote_DetailSource.Rows.Add(newRow);
                                }
                            }
                            gridControl_ProductPromote.DataSource = _tbPromote_DetailSource;
                        }
                        //--- Select ngay sản phẩm đang chỉnh sửa
                        for (int i = 0; i < gridView_Product.RowCount; i++)
                        {
                            if (gridView_Product.GetRowCellValue(i, _cID).ToString().Contains(dlg.P_Promote_detail.ID.ToString()) == true)
                            {
                                gridView_Product.FocusedRowHandle = i;
                                continue;
                            }
                        }

                        rowDetail_select = gridView_Product.GetFocusedDataRow();

                        rowDetail_select[_cPrice] = dlg.P_Promote_detail.Price.ToString();
                        rowDetail_select[_cStartDate] = dlg.P_Promote_detail.StartDate;
                        rowDetail_select[_cEndDate] = dlg.P_Promote_detail.EndDate;

                        gridView_Product.LayoutChanged();
                    }
                    var confirmResult_New = XtraMessageBox.Show("Tiếp tục thêm?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (confirmResult_New == DialogResult.OK)
                    {
                        goto _back;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_AddProducts_Click");
            }
        }

        private void btn_UpdateProducts_Click(object sender, EventArgs e)
        {
            frm_AddEditProductPromote dlg;
            promote promote;
            promote_detail promote_detail;
            DataRow promoteRow, promote_detailRow;
            try
            {
                if (gridView_Product.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có sản phẩm nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                promoteRow = gridView_Promote.GetFocusedDataRow();
                promote_detailRow = gridView_Product.GetFocusedDataRow();
                promote = new promote();
                promote_detail = new promote_detail();

                promote.PromoteID = Convert.ToInt32(promoteRow[_cPromoteID]);
                promote.PromoteName = promoteRow[_cPromoteName].ToString();
                promote.StartDate = Convert.ToDateTime(promoteRow[_cStartDate].ToString());
                promote.EndDate = Convert.ToDateTime(promoteRow[_cEndDate].ToString());

                promote_detail.ID = Convert.ToInt32(promote_detailRow[_cID]);
                promote_detail.ProductID = Convert.ToInt32(promote_detailRow[_cProductID]);
                promote_detail.Price = Convert.ToDecimal(promote_detailRow[_cPrice]);
                promote_detail.StartDate = Convert.ToDateTime(promote_detailRow[_cStartDate]);
                promote_detail.EndDate = Convert.ToDateTime(promote_detailRow[_cEndDate]);

                dlg = new frm_AddEditProductPromote();
                dlg.P_Promote = promote;
                dlg.P_Promote_detail = promote_detail;
                dlg.P_OpenType = CoffeeHelpers.OpenType.AddEdit;
                dlg.checkUpdateExist = false;
                dlg._dbContext = _dbContext;
                dlg.Text = "Sửa Sản Phẩm Khuyến Mãi";

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    promote_detail = (from p in _dbContext.promote_detail.ToList() where p.PromoteID == promote_detail.PromoteID && p.ProductID == promote_detail.ProductID select p).FirstOrDefault();
                    if (promote_detail != null)
                    {
                        promote_detail.Price = dlg.P_Promote_detail.Price;
                        promote_detail.StartDate = dlg.P_Promote_detail.StartDate;
                        promote_detail.EndDate = dlg.P_Promote_detail.EndDate;

                        _dbContext.SaveChanges();

                        promote_detailRow[_cPrice] = dlg.P_Promote_detail.Price;
                        promote_detailRow[_cStartDate] = dlg.P_Promote_detail.StartDate;
                        promote_detailRow[_cEndDate] = dlg.P_Promote_detail.EndDate;

                        gridView_Product.LayoutChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_UpdateProducts_Click");
            }
        }

        private void simpleButton_DelProducts_Click(object sender, EventArgs e)
        {
            DataRow productRow;
            try
            {
                productRow = gridView_Product.GetFocusedDataRow();

                if (gridView_Product.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có sản phẩm nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }

                promote_detail ps = (from p in _dbContext.promote_detail.ToList() where p.PromoteID == Convert.ToInt32(productRow[_cPromoteID]) && p.ProductID == Convert.ToInt32(productRow[_cProductID]) select p).FirstOrDefault();
                if (ps != null)
                {
                    ps.Deleted = 1;
                    _dbContext.SaveChanges();
                    gridView_Product.DeleteRow(gridView_Product.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "simpleButton_DelProducts_Click");
            }
        }

        private void gridView_Promote_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow row, rowFocus;
            List<promote_detail> promotes;
            try
            {
                if (e.RowHandle <= -1)
                    return;

                rowFocus = gridView_Promote.GetFocusedDataRow();
                _tbPromote_DetailSource = CreateTablePromote_DetailStruct();
                promotes = (from p in _dbContext.promote_detail.ToList() where p.PromoteID == Convert.ToInt32(rowFocus[_cPromoteID]) && p.Deleted == 2 select p).ToList();

                if (promotes != null)
                {
                    foreach (var promote in promotes)
                    {
                        row = _tbPromote_DetailSource.NewRow();
                        row[_cID] = promote.ID;
                        row[_cPromoteID] = promote.PromoteID;
                        row[_cProductID] = promote.ProductID;
                        row[_cProductName] = promote.product.ProductName;
                        row[_cStartDate] = promote.StartDate;
                        row[_cEndDate] = promote.EndDate;
                        row[_cPrice] = promote.Price;

                        _tbPromote_DetailSource.Rows.Add(row);
                    }
                }
                gridControl_ProductPromote.DataSource = _tbPromote_DetailSource;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Promote_RowClick");
            }
        }

        private void gridView_Promote_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view;
            DataRow row;
            DateTime dt = DateTime.Now;
            try
            {
                if (e.RowHandle <= -1)
                    return;
                view = sender as GridView;
                row = view.GetDataRow(e.RowHandle);
                if (dt.Date <= Convert.ToDateTime(row[_cEndDate]))//Còn khuyến mãi
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 0, 102);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Promote_RowCellStyle");
            }
        }
        #endregion

        private void gridControl_ProductPromote_DoubleClick(object sender, EventArgs e)
        {
            frm_AddEditProductPromote dlg;
            promote promote;
            promote_detail promote_detail;
            DataRow promoteRow, promote_detailRow;
            try
            {
                if (gridView_Product.SelectedRowsCount == 0)
                {
                   return;
                }
                promoteRow = gridView_Promote.GetFocusedDataRow();
                promote_detailRow = gridView_Product.GetFocusedDataRow();
                promote = new promote();
                promote_detail = new promote_detail();

                promote.PromoteID = Convert.ToInt32(promoteRow[_cPromoteID]);
                promote.PromoteName = promoteRow[_cPromoteName].ToString();
                promote.StartDate = Convert.ToDateTime(promoteRow[_cStartDate].ToString());
                promote.EndDate = Convert.ToDateTime(promoteRow[_cEndDate].ToString());

                promote_detail.ID = Convert.ToInt32(promote_detailRow[_cID]);
                promote_detail.ProductID = Convert.ToInt32(promote_detailRow[_cProductID]);
                promote_detail.Price = Convert.ToDecimal(promote_detailRow[_cPrice]);
                promote_detail.StartDate = Convert.ToDateTime(promote_detailRow[_cStartDate]);
                promote_detail.EndDate = Convert.ToDateTime(promote_detailRow[_cEndDate]);

                dlg = new frm_AddEditProductPromote();
                dlg.P_Promote = promote;
                dlg.P_Promote_detail = promote_detail;
                dlg.P_OpenType = CoffeeHelpers.OpenType.AddEdit;
                dlg.checkUpdateExist = false;
                dlg._dbContext = _dbContext;
                dlg.Text = "Sửa Sản Phẩm Khuyến Mãi";

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    promote_detail = (from p in _dbContext.promote_detail.ToList() where p.PromoteID == promote_detail.PromoteID && p.ProductID == promote_detail.ProductID select p).FirstOrDefault();
                    if (promote_detail != null)
                    {
                        promote_detail.Price = dlg.P_Promote_detail.Price;
                        promote_detail.StartDate = dlg.P_Promote_detail.StartDate;
                        promote_detail.EndDate = dlg.P_Promote_detail.EndDate;

                        _dbContext.SaveChanges();

                        promote_detailRow[_cPrice] = dlg.P_Promote_detail.Price;
                        promote_detailRow[_cStartDate] = dlg.P_Promote_detail.StartDate;
                        promote_detailRow[_cEndDate] = dlg.P_Promote_detail.EndDate;

                        gridView_Product.LayoutChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_ProductPromote_DoubleClick");
            }
        }

        private void gridControl_Promote_DoubleClick(object sender, EventArgs e)
        {
            frm_AddEditProductPromote dlg;
            promote promote, updatePromote;
            DataRow promoteRow;
            try
            {
                promoteRow = gridView_Promote.GetFocusedDataRow();
                promote = new promote();
                promote.PromoteID = Convert.ToInt32(promoteRow[_cPromoteID]);
                promote.PromoteName = promoteRow[_cPromoteName].ToString();
                promote.StartDate = Convert.ToDateTime(promoteRow[_cStartDate].ToString());
                promote.EndDate = Convert.ToDateTime(promoteRow[_cEndDate].ToString());

                dlg = new frm_AddEditProductPromote();
                dlg.P_Promote = promote;
                dlg.P_OpenType = CoffeeHelpers.OpenType.None;
                dlg._dbContext = _dbContext;
                dlg.Text = "Sửa Chương Trình Khuyến Mãi";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    updatePromote = (from p in _dbContext.promotes.ToList() where p.PromoteID == promote.PromoteID select p).FirstOrDefault();
                    if (updatePromote != null)
                    {
                        updatePromote.PromoteID = promote.PromoteID;
                        updatePromote.PromoteName = dlg.P_Promote.PromoteName;
                        updatePromote.StartDate = dlg.P_Promote.StartDate;
                        updatePromote.EndDate = dlg.P_Promote.EndDate;

                        _dbContext.SaveChanges();

                        promoteRow[_cPromoteID] = promote.PromoteID;
                        promoteRow[_cPromoteName] = dlg.P_Promote.PromoteName;
                        promoteRow[_cStartDate] = dlg.P_Promote.StartDate;
                        promoteRow[_cEndDate] = dlg.P_Promote.EndDate;

                        gridView_Promote.LayoutChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_Promote_DoubleClick");
            }
        }

    }
}