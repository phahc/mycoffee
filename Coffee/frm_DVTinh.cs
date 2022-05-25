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
using System.IO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace Coffee
{
    public partial class frm_DVTinh : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        public ImageList list_Image { get; set; }

        private mycoffeeEntities _dbContext;
        private DataTable _tbSource;

        private const string _cDVTID = "DVTID";
        private const string _cDVTName = "DVTName";
        private const string _cImageIndex = "ImageIndex";
        private const string _cImage = "Image";

        #endregion

        public frm_DVTinh()
        {
            InitializeComponent();
        }

        private void frm_DVTinh_Load(object sender, EventArgs e)
        {
            List<donvitinh> dvts;
            DataRow newRow;
            try
            {
                //Tạo cấu trúc bảng đơn vị tính
                _tbSource = CreateTableStruct();

                // Hình ảnh
                 this.imageList_DVT = list_Image;
                 
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dvts = (from p in _dbContext.donvitinhs.ToList() select p).OrderBy(o => o.DONVITINH1).ToList();
                if (dvts != null && dvts.Count > 0)
                {
                    foreach (donvitinh dv in dvts)
                    {

                        newRow = _tbSource.NewRow();
                        newRow[_cDVTID] = dv.MADVT;
                        newRow[_cDVTName] = dv.DONVITINH1;
                        newRow[_cImageIndex] = dv.ImageIndex;
                        newRow[_cImage] = imageList_DVT.Images[dv.ImageIndex];

                        _tbSource.Rows.Add(newRow);

                    }
                    //Tạo image lên GridView
                    RepositoryItemPictureEdit pictureEdit = gridControl_DVT.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
                    pictureEdit.SizeMode = PictureSizeMode.Zoom;
                    pictureEdit.NullText = " ";
                    gridView_DVT.Columns["Image"].ColumnEdit = pictureEdit;
                }
                gridControl_DVT.DataSource = _tbSource;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_DVTinh_Load");
            }
        }

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddEditDVT dlg;
            donvitinh dvt;
            DataRow row;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dvt = new donvitinh();
                dlg = new frm_AddEditDVT();
                dlg.P_DVT = dvt;
                dlg.list_Image = this.imageList_DVT;
                dlg._dbContext = _dbContext;
                dlg.Text = "Thêm Đơn Vị Tính";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.donvitinhs.Add(dlg.P_DVT);
                    _dbContext.SaveChanges();

                    row = _tbSource.NewRow();
                    row[_cDVTID] = dlg.P_DVT.MADVT;
                    row[_cDVTName] = dlg.P_DVT.DONVITINH1;
                    row[_cImageIndex] = dlg.P_DVT.ImageIndex;
                    row[_cImage] = imageList_DVT.Images[dlg.P_DVT.ImageIndex];

                    _tbSource.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Add_ItemClick");
            }
        }

        private void barButtonItem_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            donvitinh dvt;
            DataRow focusRow;
            frm_AddEditDVT dlg;
            try
            {
                if (gridView_DVT.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn đơn vị tính muốn sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                focusRow = gridView_DVT.GetFocusedDataRow();
                dvt = new donvitinh();
                dlg = new frm_AddEditDVT();
                dvt.MADVT = Convert.ToInt32(focusRow[_cDVTID]);
                dvt.DONVITINH1 = focusRow[_cDVTName].ToString();
                dvt.ImageIndex = Convert.ToInt32(focusRow[_cImageIndex]);

                dlg.P_DVT = dvt;
                dlg.list_Image = this.imageList_DVT;
                dlg.Text = "Sửa Đơn Vị Tính";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    dvt = (from dv in _dbContext.donvitinhs.ToList() where dv.MADVT == dvt.MADVT select dv).FirstOrDefault();
                    if (dvt != null)
                    {
                        dvt.DONVITINH1 = dlg.P_DVT.DONVITINH1;
                        dvt.ImageIndex = dlg.P_DVT.ImageIndex;

                        _dbContext.SaveChanges();

                        focusRow[_cDVTName] = dlg.P_DVT.DONVITINH1;
                        focusRow[_cImageIndex] = dlg.P_DVT.ImageIndex;
                        focusRow[_cImage] = imageList_DVT.Images[dlg.P_DVT.ImageIndex];

                        gridView_DVT.LayoutChanged();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Edit_ItemClick");
            }
        }

        private void barButtonItem_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Exit_ItemClick");
            }
        }

        #region Helpers
         private DataTable CreateTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cDVTID);
                tbSource.Columns.Add(_cDVTName);
                tbSource.Columns.Add(_cImageIndex);
                tbSource.Columns.Add(_cImage, typeof(Image));
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cDVTID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }
        #endregion

         private void gridControl_DVT_DoubleClick(object sender, EventArgs e)
         {
             donvitinh dvt;
             DataRow focusRow;
             frm_AddEditDVT dlg;
             try
             {

                 if (gridView_DVT.SelectedRowsCount <= 0)
                 {
                     return;
                 }
               
                 focusRow = gridView_DVT.GetFocusedDataRow();
                 dvt = new donvitinh();
                 dlg = new frm_AddEditDVT();
                 dvt.MADVT = Convert.ToInt32(focusRow[_cDVTID]);
                 dvt.DONVITINH1 = focusRow[_cDVTName].ToString().Trim();
                 dvt.ImageIndex = Convert.ToInt32(focusRow[_cImageIndex]);

                 dlg.P_DVT = dvt;
                 dlg.list_Image = this.imageList_DVT;
                 dlg.Text = "Sửa Đơn Vị Tính";
                 if (dlg.ShowDialog() == DialogResult.OK)
                 {
                     _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                     dvt = (from dv in _dbContext.donvitinhs.ToList() where dv.MADVT == dvt.MADVT select dv).FirstOrDefault();
                     if (dvt != null)
                     {
                         dvt.DONVITINH1 = dlg.P_DVT.DONVITINH1;
                         dvt.ImageIndex = dlg.P_DVT.ImageIndex;

                         _dbContext.SaveChanges();

                         focusRow[_cDVTName] = dlg.P_DVT.DONVITINH1;
                         focusRow[_cImageIndex] = dlg.P_DVT.ImageIndex;
                         focusRow[_cImage] = imageList_DVT.Images[dlg.P_DVT.ImageIndex];

                         gridView_DVT.LayoutChanged();

                     }
                 }
             }
             catch (Exception ex)
             {
                 XtraMessageBox.Show(ex.Message, "gridControl_DVT_DoubleClick");
             }
         }

    }
}