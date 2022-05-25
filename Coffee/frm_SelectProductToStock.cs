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
    public partial class frm_SelectProductToStock : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public product P_product { get; set; }
        public determine P_Deterine { get; set; }
        public string _ProductName { get; set; }
        public int _DVT { get; set; }
        public ImageList list_Image { get; set; }

        private const string _cProductID = "ProductID";
        private const string _cProductName = "ProductName";
        private const string _cProductCode = "ProductCode";
        private const string _cDVT = "DVT";
        private const string _cImageIndex = "ImageIndex";
        private const string _cImage = "Image";

        public frm_SelectProductToStock()
        {
            InitializeComponent();
        }

        private void frm_SelectProductToStock_Load(object sender, EventArgs e)
        {
            try
            {
                this.imageList_Product = list_Image;

                //Add menu
                AddMenuOnList();

                //Load đơn vị tính
                LoadProductsDVT();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_SelectProductToStock_Load");
            }
        }

        private void btn_Choose_Click(object sender, EventArgs e)
        {
            DataRow focusRow;
            try
            {
                if (gridView_Product.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn mặt hàng định lượng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                focusRow = gridView_Product.GetFocusedDataRow();
                P_Deterine.ProcductDetermine = Convert.ToInt32(focusRow[_cProductID]);
                P_Deterine.Quantity = 1;
                _ProductName = focusRow[_cProductName].ToString();
                _DVT = Convert.ToInt32(focusRow[_cDVT]);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Choose_Click");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Close_Click");
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

                treeView_Menu.ImageList = this.imageList_Product;
               
                menus = (from m in _dbContext.menus.ToList() where m.Status == 1 select m).OrderByDescending(o => o.MenuID).ToList();//Lấy các menu đang được sử dụng

                node = new TreeNode();
                node.Name = "0";
                node.Text = "Tất cả";
                node.ImageIndex = -1;
                node.SelectedImageIndex = -1;
                treeView_Menu.Nodes.Add(node);

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
                tbSource.Columns.Add(_cDVT);
                tbSource.Columns.Add(_cImageIndex);
                tbSource.Columns.Add(_cImage, typeof(Image));
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cProductID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        private void treeView_Menu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            List<product> products;
            DataRow newRow;
            DataTable tbSource;
            TreeNode selectNode;
            try
            {
                selectNode = e.Node;
                tbSource = CreateTableStruct();
                groupControl_Product.Text = "Sản phẩm của nhóm hàng " + selectNode.Text;

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                if (Convert.ToInt32(selectNode.Name) != 0)
                {
                    products = (from p in _dbContext.products.ToList() where p.ProductSkin == Convert.ToInt32(selectNode.Name) select p).OrderBy(o => o.ProductCode).ToList();
                }
                else
                {
                    products = (from p in _dbContext.products.ToList() select p).OrderBy(o => o.ProductCode).ToList();
                }
                if (products != null && products.Count > 0)
                {
                    foreach (product product in products)
                    {
                        newRow = tbSource.NewRow();
                        newRow[_cProductID] = product.ProductID;
                        newRow[_cProductName] = product.ProductName;
                        newRow[_cProductCode] = product.ProductCode;  
                        newRow[_cDVT] = product.DVT;
                        newRow[_cImageIndex] = product.ImageIndex;
                        newRow[_cImage] = imageList_Product.Images[product.ImageIndex];

                        tbSource.Rows.Add(newRow);
                    }
                    //Tạo image lên GridView
                    RepositoryItemPictureEdit pictureEdit = gridControl_Product.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
                    pictureEdit.SizeMode = PictureSizeMode.Zoom;
                    pictureEdit.NullText = " ";
                    gridView_Product.Columns["Image"].ColumnEdit = pictureEdit;
                }
                gridControl_Product.DataSource = tbSource;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Menu_NodeMouseClick");
            }
        }

        /// <summary>
        /// Load danh sách Products status
        /// </summary>
        private void LoadProductsDVT()
        {
            List<donvitinh> dvts;
            DataTable tbSource;
            DataRow row;
            try
            {

                tbSource = new DataTable();
                tbSource.Columns.Add("ID");
                tbSource.Columns.Add("DVT");

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dvts = (from dv in _dbContext.donvitinhs select dv).ToList();

                if (dvts != null && dvts.Count > 0)
                {
                    foreach (donvitinh item in dvts)
                    {
                        row = tbSource.NewRow();
                        row["ID"] = item.MADVT;
                        row["DVT"] = item.DONVITINH1;

                        tbSource.Rows.Add(row);
                        //repositoryItemImageComboBox_DVT.Items.Add(new ImageComboBoxItem(item.DONVITINH1.ToString(), item.MADVT, item.ImageIndex));
                        //repositoryItemImageComboBox_DVT.SmallImages = imageList_Product;
                    }
                    repositoryItemLookUpEdit_DVT.DisplayMember = "DVT";
                    repositoryItemLookUpEdit_DVT.ValueMember = "ID";
                    repositoryItemLookUpEdit_DVT.DataSource = tbSource;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadProductsStatus");
            }
        }

        private void gridControl_Product_DoubleClick(object sender, EventArgs e)
        {
            DataRow focusRow;
            try
            {
                if (gridView_Product.SelectedRowsCount <= 0)
                {
                    return;
                }
                focusRow = gridView_Product.GetFocusedDataRow();
                P_Deterine.ProcductDetermine = Convert.ToInt32(focusRow[_cProductID]);
                P_Deterine.Quantity = 1;
                _ProductName = focusRow[_cProductName].ToString();
                _DVT = Convert.ToInt32(focusRow[_cDVT]);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_Product_DoubleClick");
            }
        }
    }
}