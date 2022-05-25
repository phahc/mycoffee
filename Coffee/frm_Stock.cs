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
using System.IO;

namespace Coffee
{
    public partial class frm_Stock : DevExpress.XtraEditors.XtraForm
    {
        public ImageList list_Image { get; set; }

        private mycoffeeEntities _dbContext;

        private const string _cMenuID = "MenuID";
        private const string _cMenuName = "MenuName";
        private const string _cMenuCode = "MenuCode";
        private const string _cImageIndex = "ImageIndex";
        private const string _cImage = "Image";
        private const string _cStatus = "Status";

         private const string _cProductID = "ProductID";
        private const string _cProductName = "ProductName";
        private const string _cDVT = "DVT";
        private const string _cTonKho = "TonKho";

        private const string _cDate = "Date";
        private const string _cInputQuantity = "InputQuantity";
        private const string _cOutPutQuantity = "OutPutQuantity";
        private const string _cSoPhieu = "SoPhieu";

        TreeNode selectNode;

        public frm_Stock()
        {
            InitializeComponent();
        }

        private void frm_Stock_Load(object sender, EventArgs e)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                this.imageList_Menu = list_Image;
                //Nhóm hàng
                AddMenuOnList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Stock_Load");
            }
        }

        //Danh sách chủng loại sản phẩm
        private void AddMenuOnList()
        {
            List<menu> menus;
            TreeNode node;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                treeView_Menu.ImageList = this.imageList_Menu;

                menus = (from m in _dbContext.menus.ToList() select m).OrderByDescending(o => o.MenuID).ToList();

                if (menus != null && menus.Count > 0)
                {
                    foreach (menu item in menus)
                    {
                        node = new TreeNode();
                        node.Name = item.MenuID.ToString();
                        node.Text = item.MenuCode;
                        node.ImageIndex = item.ImageIndex;
                        node.SelectedImageIndex = item.ImageIndex;
                        node.Tag = item.Status;

                        treeView_Menu.Nodes.Add(node);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddMenuOnList");
            }
        }

        private void treeView_Menu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                selectNode = e.Node;
                //Load danh sách mặt hàng
                LoadListProductInStock(selectNode);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Menu_NodeMouseClick");
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

        private void btn_All_Click(object sender, EventArgs e)
        {
            List<tonkho> tk;
            DataTable _tbSource;
            DataRow row;
            try
            {
                _tbSource = CreateTableStruct();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                tk = (from k in _dbContext.tonkhoes.ToList() select k).ToList();
                if (tk != null && tk.Count > 0)
                {
                    foreach (tonkho k in tk)
                    {
                        row = _tbSource.NewRow();
                        row[_cProductID] = k.product.ProductID;
                        row[_cProductName] = k.product.ProductName;
                        row[_cDVT] = k.product.donvitinh.DONVITINH1;
                        row[_cTonKho] = k.SOLUONGTON;

                        _tbSource.Rows.Add(row);

                    }
                    gridControl_Stock.DataSource = _tbSource;
                }
                else
                {
                    gridControl_Stock.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_All_Click");
            }
        }

        //Load thông tin của mặt hàng trong kho
        private void LoadListProductInStock(TreeNode node)
        {
            List<tonkho> tk;
            DataTable _tbSource;
            DataRow row;
            try
            {
                _tbSource = CreateTableStruct();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                tk = (from k in _dbContext.tonkhoes.ToList() where k.product.ProductSkin == Convert.ToInt32(node.Name) select k).ToList();
                if (tk != null && tk.Count > 0)
                {
                    foreach (tonkho k in tk)
                    {
                        row = _tbSource.NewRow();
                        row[_cProductID]=k.product.ProductID;
                        row[_cProductName] = k.product.ProductName;
                        row[_cDVT] = k.product.donvitinh.DONVITINH1;
                        row[_cTonKho] = k.SOLUONGTON;

                        _tbSource.Rows.Add(row);

                    }
                    gridControl_Stock.DataSource = _tbSource;
                }
                else
                {
                    gridControl_Stock.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadListProductInStock");
            }
        }

        //Load thông tin chi tiết xuất hàng
        private void LoadOutputPutProduct(int productID)
        {
            DataTable _tbSource;
            DataRow row;
            try
            {
                _tbSource = CreateTableOutStockStruct();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                var info = (from orderDetail in _dbContext.order_detail.ToList() 
                            where orderDetail.ProductID==productID
                            orderby orderDetail.Date descending
                            select orderDetail);

                if (info != null)
                {
                    foreach (var item in info)
                    {
                        row = _tbSource.NewRow();
                        row[_cDate] = item.Date.ToString("dd/MM/yyyy");
                        row[_cSoPhieu] = item.listorder.Ordercode;
                        row[_cOutPutQuantity] = item.Quantity;
                        _tbSource.Rows.Add(row);
                    }
                    gridControl_OutPut.DataSource = _tbSource;
                }
                else
                {
                    gridControl_OutPut.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadInputAndOutPutProduct");
            }
        }

        //Load thông tin chi tiết nhập hàng
        private void LoadInputPutProduct(int productID)
        {
            DataTable _tbSource;
            DataRow row;
            try
            {
                _tbSource = CreateTableInStockStruct();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                var info = (from hd in _dbContext.chitiethdns.ToList() 
                            where hd.MAMH==productID
                            orderby hd.hoadonnhap.NGAYNHAP descending
                            select hd);

                if (info != null)
                {
                    foreach (var item in info)
                    {
                        row = _tbSource.NewRow();
                        row[_cDate] = item.hoadonnhap.NGAYNHAP.Value.ToString("dd/MM/yyyy");
                        row[_cSoPhieu] = item.hoadonnhap.HDNCode;
                        row[_cInputQuantity] = item.SOLUONGNHAP;
                        _tbSource.Rows.Add(row);
                    }
                    gridControl_InPut.DataSource = _tbSource;
                }
                else
                {
                    gridControl_InPut.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadInputAndOutPutProduct");
            }
        }

        //Tạo cấu trúc cho gridview
        private DataTable CreateTableStruct()
        {
            DataTable tbSource = null;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cDVT);
                tbSource.Columns.Add(_cTonKho);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadListProductInStock");
                return tbSource;
            }
            return tbSource;
        }

        //Tạo cấu trúc cho gridview
        private DataTable CreateTableInStockStruct()
        {
            DataTable tbSource = null;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cDate);
                tbSource.Columns.Add(_cSoPhieu);
                tbSource.Columns.Add(_cInputQuantity);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableInStockStruct");
                return tbSource;
            }
            return tbSource;
        }

        private DataTable CreateTableOutStockStruct()
        {
            DataTable tbSource = null;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cDate);
                tbSource.Columns.Add(_cSoPhieu);
                tbSource.Columns.Add(_cOutPutQuantity);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableOutStockStruct");
                return tbSource;
            }
            return tbSource;
        }

        private void gridView_Stock_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow focusRow;
            try
            {
                if (e.RowHandle<=0)
                {return;}
                if (gridView_Stock.RowCount <= 0)
                { return; }

                focusRow = gridView_Stock.GetFocusedDataRow();

                //Load thông tin chi tiết nhập hàng
                LoadInputPutProduct(Convert.ToInt32(focusRow[_cProductID]));

                //Load thông tin chi tiết xuất hàng
                LoadOutputPutProduct(Convert.ToInt32(focusRow[_cProductID]));

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Stock_RowClick");
            }
        }

        private void gridView_Stock_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow focusRow;
            try
            {
                if (e.FocusedRowHandle <= 0)
                { return; }
                if (gridView_Stock.RowCount <= 0)
                { return; }

                focusRow = gridView_Stock.GetFocusedDataRow();

                //Load thông tin chi tiết nhập hàng
                LoadInputPutProduct(Convert.ToInt32(focusRow[_cProductID]));

                //Load thông tin chi tiết xuất hàng
                LoadOutputPutProduct(Convert.ToInt32(focusRow[_cProductID]));

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Stock_FocusedRowChanged");
            }
        }

        private void gridView_Stock_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view;
            DataRow row;
            try
            {
                if (e.RowHandle <= -1)
                    return;
                view = sender as GridView;
                row = view.GetDataRow(e.RowHandle);
                if (Convert.ToInt32(row[_cTonKho]) <= 20)//Sắp hết hàng
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 0, 102);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Promote_RowCellStyle");
            }
        }

    }
}