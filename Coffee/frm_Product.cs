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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.Collections;
using MySql.Data.MySqlClient;

namespace Coffee
{
    public partial class frm_Product : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        public mycoffeeEntities _dbContext;
        public bool _checkAddOrUpdate { get; set; }
        public DataTable _tbSource { get; set; }

        public DataTable listMenu { get; set; }//Giữ danh sách thực đơn
        // Hình ảnh
        public ImageList list_Image { get; set; }

        public Dictionary<int,int> _dic_images { get; set; }


        #region ColumnName

        private const string _cProductID = "ProductID";
        private const string _cProductName = "ProductName";
        private const string _cProductCode = "ProductCode";
        private const string _cPrice = "Price";
        private const string _cInputPrice = "InputPrice";
        private const string _cLimit= "Limit";
        private const string _cDVT = "DVT";
        private const string _cStatus = "Status";
        private const string _cNotes = "Notes";
        private const string _cImageIndex = "ImageIndex";
        private const string _cImage = "Image";
        private const string _cQuantity = "Quantity";
        private const string _cExChangeQuantity = "ExChangeQuantity";
        private const string _cExChangeDVT = "ExChangeDVT";
        private const string _cType = "Type";

        private const string _cDVTID= "DVTID";
        private const string _cDVTName = "DVTName";

        private const string _cMadeInID = "MadeInID";
        private const string _cProductSkin = "ProductSkin";
        private const string _cMadeInName = "MadeInName";


        private const string _cMenuID = "MenuID";
        private const string _cMenuName = "MenuName";
        private const string _cMenuCode = "MenuCode";

        TreeNode selectNode;//Menu đang chọn
        DataTable tbSource;
        
        #endregion //--- ColumnName

        #endregion //--- Fields
 
        #region Form Method
         public frm_Product()
        {
            InitializeComponent();
        }

        private void frm_Product_Load(object sender, EventArgs e)
        {
            DataRow newRow;
            List<product> products;

            try
            {

                listMenu = CreateListMenuTableStruct();
                tbSource = CreateListMenuTableStruct();

                _checkAddOrUpdate = false;

               // Danh sách hình ảnh
                this.imageList_Product = list_Image;

                //--- Tạo cấu trúc table mặc định
                _tbSource = CreateTableStruct();

                //Add menu
                AddMenuOnList();

                //Load trạng thái
                LoadProductsStatus();

                //Load phân loại
                LoadProductsSkin();

                //Load đơn vị tính
                LoadProductsDVT();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                products = (from p in _dbContext.products.ToList() select p).OrderBy(o => o.ProductCode).ToList();
                if (products != null && products.Count > 0)
                {
                    foreach (product product in products)
                    {

                        newRow = _tbSource.NewRow();
                        newRow[_cProductID] = product.ProductID;
                        newRow[_cProductName] = product.ProductName;
                        newRow[_cProductCode] = product.ProductCode;
                        newRow[_cProductSkin] = product.ProductSkin;
                        newRow[_cPrice] = product.Price;
                        newRow[_cInputPrice] = product.InputPrice;
                        newRow[_cLimit] = product.ExpiryDate;
                        newRow[_cDVT] = product.DVT;
                        newRow[_cStatus] = product.Status;
                        newRow[_cMadeInID] = product.MadeInID;
                        newRow[_cMadeInName] = product.madein.MadeInName;
                        newRow[_cNotes] = product.Notes;
                        newRow[_cExChangeQuantity] = product.ExchangeQuantity;
                        newRow[_cExChangeDVT] = product.ExchangeDVT;
                        newRow[_cType] = product.Type;
                        newRow[_cImageIndex] = product.ImageIndex;
                        newRow[_cImage] = imageList_Product.Images[product.ImageIndex];

                        _tbSource.Rows.Add(newRow);

                        gridView_Product.Columns[_cDVT].ImageIndex = product.donvitinh.ImageIndex;
                    }
                    //Tạo image lên GridView
                    RepositoryItemPictureEdit pictureEdit = gridControl_Product.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
                    pictureEdit.SizeMode = PictureSizeMode.Zoom;
                    pictureEdit.NullText = " ";
                    gridView_Product.Columns["Image"].ColumnEdit = pictureEdit;

                }
                gridControl_Product.DataSource = _tbSource;
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Product_Load");
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
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cProductCode);
                tbSource.Columns.Add(_cProductSkin);
                tbSource.Columns.Add(_cPrice);
                tbSource.Columns.Add(_cInputPrice);
                tbSource.Columns.Add(_cDVT);
                tbSource.Columns.Add(_cLimit);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cNotes);
                tbSource.Columns.Add(_cExChangeQuantity);
                tbSource.Columns.Add(_cExChangeDVT);
                tbSource.Columns.Add(_cType);
                tbSource.Columns.Add(_cMadeInID);
                tbSource.Columns.Add(_cMadeInName);
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

        /// <summary>
        /// Tạo cấu trúc mặc định cho 
        /// </summary>
        private DataTable CreateListMenuTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cMenuID);
                tbSource.Columns.Add(_cMenuCode);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cImageIndex);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cMenuID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateListMenuTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Load danh sách Products status
        /// </summary>
        private void LoadProductsStatus()
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

                tbStatus.Rows.Add(1, "Còn hàng");
                tbStatus.Rows.Add(2, "Hết hàng");
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

        /// <summary>
        /// Load danh sách Products status
        /// </summary>
        private void LoadProductsSkin()
        {
            DataTable tbProSkin;
            string cSkinID = "SkinID";
            string cSkinName = "SkinName";
            List<menu> menus;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                // Phân loại sản phẩm
                tbProSkin = new DataTable();
                tbProSkin.Columns.Add(cSkinID);
                tbProSkin.Columns.Add(cSkinName);
                menus = (from m in _dbContext.menus.ToList() where m.Status == 1 select m).ToList();

                int Id = 0;
                if (menus != null)
                {
                    foreach (menu item in menus)
                    {
                        Id++;
                        tbProSkin.Rows.Add(item.MenuID, item.MenuCode);
                    }
                }

                repositoryItemLookUpEdit_Skin.DisplayMember = cSkinName;
                repositoryItemLookUpEdit_Skin.ValueMember = cSkinID;
                repositoryItemLookUpEdit_Skin.DataSource = tbProSkin;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadProductsStatus");
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
                dvts = (from dv in _dbContext.donvitinhs.ToList() select dv).ToList();

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

        //Danh sách chủng loại sản phẩm
        private void AddMenuOnList()
        {
            List<menu> menus;
            DataRow row;
            TreeNode node;
            try
            {
                treeView_Menu.ImageList = this.imageList_Product;

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
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

                        if (item.Status != 2)//Các menu không dùng sẽ không add
                        {
                            row = listMenu.NewRow();
                            row[_cMenuID] = item.MenuID;
                            row[_cMenuCode] = item.MenuCode;
                            row[_cStatus] = item.Status;
                            row[_cImageIndex] = item.ImageIndex;

                            listMenu.Rows.Add(row);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddMenuOnList");
            }
        }

        #endregion

        #region Actions
        private void button_Add_Click(object sender, EventArgs e)
        {
            frm_AddEditProduct dlg;
            product product;
            DataRow newRow;
            int maxCode;
            frm_SelectAddProduct dlgAdd;
            DataTable tbSource;
            determine determine;

            try
            {
                dlgAdd = new frm_SelectAddProduct();
                if (dlgAdd.ShowDialog() == DialogResult.OK)
                {
                    tbSource = CreateTableStruct();

                    dlg = new frm_AddEditProduct();
                    product = new product();
                    product.ProductSkin = Convert.ToInt32(dlgAdd._Node.Name);
                    dlg.P_Product = product;
                    dlg.list_Image = this.imageList_Product;
                    dlg._dic_images = _dic_images;
                    dlg.Text = "Thêm Sản Phẩm";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                        //--- Lấy mã code lớn nhất để insert vào db (không lấy mã bên from AddEdit vì có thể bị trùng)
                        maxCode = CoffeeHelpers.GetProductMaxCode() + 1;
                        dlg.P_Product.ProductCode = "SP-000" + maxCode;
                        _dbContext.products.Add(dlg.P_Product);
                        _dbContext.SaveChanges();

                        //Giữ thông tin gửi trả về form chính
                        newRow = _tbSource.NewRow();
                        newRow[_cProductID] = dlg.P_Product.ProductID;
                        newRow[_cProductName] = dlg.P_Product.ProductName;
                        newRow[_cProductCode] = dlg.P_Product.ProductCode;
                        newRow[_cPrice] = dlg.P_Product.Price;
                        newRow[_cInputPrice] = dlg.P_Product.InputPrice;
                        newRow[_cLimit] = dlg.P_Product.ExpiryDate;
                        newRow[_cDVT] = dlg.P_Product.DVT;
                        newRow[_cStatus] = dlg.P_Product.Status;
                        newRow[_cNotes] = dlg.P_Product.Notes;
                        newRow[_cMadeInID] = dlg.P_Product.MadeInID;
                        newRow[_cMadeInName] = dlg.MadeInName;
                        newRow[_cProductSkin] = dlg.P_Product.ProductSkin;
                        newRow[_cImageIndex] = dlg.P_Product.ImageIndex;
                        newRow[_cImage] = imageList_Product.Images[dlg.P_Product.ImageIndex];
                        _tbSource.Rows.Add(newRow);

                        //Hiển thị giao diện. Không gửi qua form chính
                        newRow = tbSource.NewRow();
                        newRow[_cProductID] = dlg.P_Product.ProductID;
                        newRow[_cProductName] = dlg.P_Product.ProductName;
                        newRow[_cProductCode] = dlg.P_Product.ProductCode;
                        newRow[_cPrice] = dlg.P_Product.Price;
                        newRow[_cInputPrice] = dlg.P_Product.InputPrice;
                        newRow[_cLimit] = dlg.P_Product.ExpiryDate;
                        newRow[_cDVT] = dlg.P_Product.DVT;
                        newRow[_cStatus] = dlg.P_Product.Status;
                        newRow[_cNotes] = dlg.P_Product.Notes;
                        newRow[_cMadeInID] = dlg.P_Product.MadeInID;
                        newRow[_cMadeInName] = dlg.MadeInName;
                        newRow[_cProductSkin] = dlg.P_Product.ProductSkin;
                        newRow[_cImageIndex] = dlg.P_Product.ImageIndex;
                        newRow[_cImage] = imageList_Product.Images[dlg.P_Product.ImageIndex];
                        tbSource.Rows.Add(newRow);

                        //Có thay đổi
                        _checkAddOrUpdate = true;

                        tbSource=dlg._tbSource;
                        //Thêm vào bảng định lượng
                        if (tbSource.Rows.Count > 0)
                        {
                            determine = new determine();
                            foreach (DataRow r in tbSource.Rows)
                            {
                                determine.ProductID = Convert.ToInt32(dlg.P_Product.ProductID);
                                determine.ProcductDetermine = Convert.ToInt32(r[_cProductID]);
                                determine.Quantity = Convert.ToInt32(r[_cQuantity]);

                               // _dbContext.ExecuteCommand("Insert Into Determine(ProductID,ProcductDetermine,Quantity) Values({0},{1},{2})",determine.ProductID,determine.ProcductDetermine,determine.Quantity);

                                MySqlCommand cmd = new MySqlCommand();
                                MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                                cmd = con.CreateCommand();
                                //Cập nhật tiền khuyến mãi
                                cmd.CommandText = "Insert Into determine(ProductID,ProcductDetermine,Quantity) Values('"+determine.ProductID+"','"+determine.ProcductDetermine+"','"+determine.Quantity+"')";

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                    else
                    {
                        _checkAddOrUpdate = false;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Add_Click");
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            frm_AddEditProduct dlg;
            product updateProduct, product;
            DataRow updateRow,newRow;
            DataTable tbSourceIUpdate;
            List<determine> listDetermine;
            determine determine;

            try
            {
                if (selectNode != null && selectNode.Tag.ToString() == "2")
                {
                    XtraMessageBox.Show("Nhóm hàng này đã không còn được sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (gridView_Product.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có mặt hàng nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                updateRow = gridView_Product.GetFocusedDataRow();
                product = new product();
                product.ProductID = Convert.ToInt32(updateRow[_cProductID]);
                product.ProductCode = updateRow[_cProductCode].ToString();
                product.ProductName = updateRow[_cProductName].ToString();
                product.Price = Convert.ToInt32(updateRow[_cPrice]);
                product.InputPrice = Convert.ToInt32(updateRow[_cInputPrice]);

                if (updateRow[_cLimit].ToString() == "")
                {
                    updateRow[_cLimit] = "1900-01-01 00:00:00";
                }

                product.ExpiryDate = Convert.ToDateTime(updateRow[_cLimit]);
                product.DVT = Convert.ToInt32(updateRow[_cDVT]);
                product.Status = Convert.ToInt32(updateRow[_cStatus]);
                product.MadeInID = Convert.ToInt32(updateRow[_cMadeInID]);
                product.ProductSkin = Convert.ToInt32(updateRow[_cProductSkin]);
                product.Notes = updateRow[_cNotes].ToString();
                product.ExchangeQuantity = Convert.ToInt32(updateRow[_cExChangeQuantity]);
                product.ExchangeDVT = Convert.ToInt32(updateRow[_cExChangeDVT]);
                product.Type = Convert.ToInt32(updateRow[_cType]);
                product.ImageIndex = Convert.ToInt32(updateRow[_cImageIndex].ToString());

                tbSourceIUpdate = new DataTable();
                tbSourceIUpdate.Columns.Add(_cProductID);
                tbSourceIUpdate.Columns.Add(_cProductName);
                tbSourceIUpdate.Columns.Add(_cQuantity);
                tbSourceIUpdate.Columns.Add(_cDVT);

                //Lấy danh sách định lượng
                listDetermine = (from d in _dbContext.determines.ToList() where d.ProductID == Convert.ToInt32(updateRow[_cProductID]) select d).ToList();
                if (listDetermine != null && listDetermine.Count > 0)
                {
                    foreach (determine dt in listDetermine)
                    {
                        newRow = tbSourceIUpdate.NewRow();
                        newRow[_cProductID]=dt.ProcductDetermine;
                        newRow[_cProductName]=dt.product.ProductName;
                        newRow[_cQuantity]=dt.Quantity;
                        newRow[_cDVT]=dt.product.donvitinh.MADVT;

                        tbSourceIUpdate.Rows.Add(newRow);
                    }
                }

                dlg = new frm_AddEditProduct();
                dlg._gettbSource = tbSourceIUpdate;
                dlg.P_Product = product;
                dlg.list_Image = this.imageList_Product;
                dlg._dic_images = _dic_images;
                dlg.Text = "Sửa Mặt Hàng";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    updateProduct = (from p in _dbContext.products.ToList() where p.ProductID == product.ProductID select p).FirstOrDefault();
                    if (updateProduct != null)
                    {
                        updateProduct.ProductName = dlg.P_Product.ProductName;
                        updateProduct.ProductCode = dlg.P_Product.ProductCode;
                        updateProduct.Price = dlg.P_Product.Price;
                        updateProduct.InputPrice = dlg.P_Product.InputPrice;
                        updateProduct.ExpiryDate = dlg.P_Product.ExpiryDate;
                        updateProduct.Status = dlg.P_Product.Status;
                        updateProduct.MadeInID = dlg.P_Product.MadeInID;
                        updateProduct.ProductSkin = dlg.P_Product.ProductSkin;
                        updateProduct.Notes = dlg.P_Product.Notes;
                        updateProduct.ImageIndex = dlg.P_Product.ImageIndex;
                        updateProduct.ExchangeQuantity = dlg.P_Product.ExchangeQuantity;
                        updateProduct.ExchangeDVT = dlg.P_Product.ExchangeDVT;
                        updateProduct.Type = dlg.P_Product.Type;

                        _dbContext.SaveChanges();

                        updateRow[_cProductName] = updateProduct.ProductName;
                        updateRow[_cProductCode] = updateProduct.ProductCode;
                        updateRow[_cPrice] = updateProduct.Price;
                        updateRow[_cInputPrice] = updateProduct.InputPrice;
                        updateRow[_cLimit] = updateProduct.ExpiryDate;
                        updateRow[_cStatus] = updateProduct.Status;
                        updateRow[_cMadeInID] = updateProduct.MadeInID;
                        updateRow[_cProductSkin] = updateProduct.ProductSkin;
                        updateRow[_cMadeInName] = updateProduct.madein.MadeInName;
                        updateRow[_cNotes] = updateProduct.Notes;
                        updateRow[_cExChangeQuantity] = updateProduct.ExchangeQuantity;
                        updateRow[_cExChangeDVT] = updateProduct.ExchangeDVT;
                        updateRow[_cType] = updateProduct.Type;
                        updateRow[_cImageIndex] = updateProduct.ImageIndex;
                        updateRow[_cImage] = imageList_Product.Images[product.ImageIndex];

                        gridView_Product.LayoutChanged();

                        //Xoá định lượng trước đó
                        foreach (determine dt in listDetermine)
                        {
                            _dbContext.determines.Remove(dt);
                            _dbContext.SaveChanges();
                        }

                        // Add lại định lượng
                        foreach (DataRow r in dlg._tbSource.Rows)
                        {
                            determine = new determine();
                            determine.ProductID = Convert.ToInt32(updateRow[_cProductID]);
                            determine.ProcductDetermine = Convert.ToInt32(r[_cProductID]);
                            determine.Quantity = Convert.ToInt32(r[_cQuantity]);

                            _dbContext.determines.Add(determine);
                            _dbContext.SaveChanges();
                        }

                        //Có thay đổi
                        _checkAddOrUpdate = true;
                    }
                    else
                    {
                        _checkAddOrUpdate = false;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Update_Click");
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Close_Click");
            }
        }

        private void gridView_Product_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view;
            DataRow row;
            int proStatus;
            try
            {
                view = sender as GridView;
                row = view.GetDataRow(e.RowHandle);
                if (row == null)
                    return;
                proStatus = Convert.ToInt32(row[_cStatus]);

                #region RowStyle

                #endregion //--- RowStyle

                switch (proStatus)
                {
                    case 1:
                        break;
                    case 2://--- Hết hàng (Xám)  
                        e.Appearance.BackColor = Color.FromArgb(181, 181, 181);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Product_RowCellStyle");
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            product deleteProduct;
            DataRow deleteRow;
            int productID;

            try
            {
                if (gridView_Product.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có sản phẩm nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                deleteRow = gridView_Product.GetFocusedDataRow();
                productID = Convert.ToInt32(deleteRow[_cProductID]);

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var moes = from mop in _dbContext.order_detail.ToList() where mop.ProductID == productID select mop;
                if (moes != null && moes.Count() > 0)
                {
                    XtraMessageBox.Show("Không thể xóa, sản phẩm này đang tồn tại trong đơn hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                deleteProduct = (from p in _dbContext.products.ToList() where p.ProductID == productID select p).FirstOrDefault();
                if (deleteProduct != null)
                {
                    //_dbContext.Products.Remove(deleteProduct);
                    deleteProduct.Status = 2;
                    _dbContext.SaveChanges();
                    gridView_Product.DeleteRow(gridView_Product.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Delete_Click");
            }
        }

        private void treeView_Menu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            List<product> products;
            DataRow newRow;
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
                        newRow[_cProductSkin] = product.ProductSkin;
                        newRow[_cPrice] = product.Price;
                        newRow[_cInputPrice] = product.InputPrice;
                        newRow[_cLimit] = product.ExpiryDate;
                        newRow[_cDVT] = product.DVT;
                        newRow[_cStatus] = product.Status;
                        newRow[_cMadeInID] = product.MadeInID;
                        newRow[_cMadeInName] = product.madein.MadeInName;
                        newRow[_cNotes] = product.Notes;
                        newRow[_cExChangeQuantity] = product.ExchangeQuantity;
                        newRow[_cExChangeDVT] = product.ExchangeDVT;
                        newRow[_cType] = product.Type;
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

                //Hiện popup sửa
                barButtonItem_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                Point pt = new Point(Control.MousePosition.X + 35, Control.MousePosition.Y);//Lệch phải
                popupMenu_Menu.ShowPopup(pt);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Menu_NodeMouseClick");
            }
        }

        //Thêm thực đơn
        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddEditMenu dlg;
            menu menus;
            DataRow row;
            TreeNode node;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dlg = new frm_AddEditMenu();
                menus = new menu();
                dlg._dbContext = _dbContext;
                dlg._dic_images = _dic_images;
                dlg.list_Image = this.imageList_Product;
                dlg.P_Menu = menus; ;
                dlg.Text = "Thêm Mới Thực Đơn";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.menus.Add(dlg.P_Menu);
                    _dbContext.SaveChanges();

                    if (dlg.P_Menu.Status != 2)//THực đơn tạm dừng sẽ không được add
                    {
                        row = listMenu.NewRow();
                        row[_cMenuID] = dlg.P_Menu.MenuID;
                        row[_cMenuCode] = dlg.P_Menu.MenuCode;
                        row[_cStatus] = dlg.P_Menu.Status;
                        row[_cImageIndex] = dlg.P_Menu.ImageIndex;
                        listMenu.Rows.Add(row);
                    }

                    node = new TreeNode();
                    node.Name = dlg.P_Menu.MenuID.ToString();
                    node.Text = dlg.P_Menu.MenuCode;
                    node.ImageIndex = dlg.P_Menu.ImageIndex;
                    node.SelectedImageIndex = dlg.P_Menu.ImageIndex;
                    node.Tag = dlg.P_Menu.Status;

                    treeView_Menu.Nodes.Add(node);

                    _checkAddOrUpdate = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Add_ItemClick");
            }
        }

        //Sửa thực đơn
        private void barButtonItem_Edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AddEditMenu dlg;
            menu menus, updateMenu;
            try
            {
                if (selectNode == null)
                {
                    XtraMessageBox.Show("Không có thực đơn nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                menus = new menu();

                menus.MenuID = Convert.ToInt32(selectNode.Name);
                menus.MenuCode = selectNode.Text;
                menus.Status = Convert.ToInt32(selectNode.Tag);
                menus.ImageIndex = Convert.ToInt32(selectNode.ImageIndex);

                dlg = new frm_AddEditMenu();
                dlg.P_Menu = menus;
                dlg.list_Image = this.imageList_Product;
                dlg._dic_images = _dic_images;
                dlg._dbContext = _dbContext;
                dlg.Text = "Sửa Thực Đơn";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    updateMenu = (from m in _dbContext.menus.ToList() where m.MenuID == menus.MenuID select m).FirstOrDefault();
                    if (updateMenu != null)
                    {
                        updateMenu.MenuCode = dlg.P_Menu.MenuCode;
                        updateMenu.Status = dlg.P_Menu.Status;
                        updateMenu.ImageIndex = dlg.P_Menu.ImageIndex;

                        _dbContext.SaveChanges();

                        foreach (DataRow r in listMenu.Rows)
                        {
                            if (Convert.ToInt32(r[_cMenuID]) == menus.MenuID)
                            {
                                r[_cMenuCode] = dlg.P_Menu.MenuCode.ToString();
                                r[_cStatus] = dlg.P_Menu.Status;
                                r[_cImageIndex] = dlg.P_Menu.ImageIndex;

                                selectNode.Text = dlg.P_Menu.MenuCode;
                                selectNode.Tag = dlg.P_Menu.Status;
                                selectNode.ImageIndex = dlg.P_Menu.ImageIndex;
                                selectNode.SelectedImageIndex = dlg.P_Menu.ImageIndex;

                                break;
                            }
                        }
                        _checkAddOrUpdate = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Edit_ItemClick");
            }
        }

        // Xoá thực đơn
        private void barButtonItem_Del_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            product products;
            menu menus;

            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                products = (from p in _dbContext.products.ToList() where p.ProductSkin == Convert.ToInt32(selectNode.Name) select p).FirstOrDefault();
                if (products != null)
                {
                    XtraMessageBox.Show("Không thể xoá thực đơn này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                menus = (from mn in _dbContext.menus.ToList() where mn.MenuID == Convert.ToInt32(selectNode.Name) select mn).FirstOrDefault();
                if (menus != null)
                {
                    _dbContext.menus.Remove(menus);
                    _dbContext.SaveChanges();


                    treeView_Menu.Nodes.Remove(selectNode);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Del_ItemClick");
            }
        }

        private void treeView_Menu_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    return;
                }
                barButtonItem_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (e.Button == MouseButtons.Right)
                {
                    barButtonItem_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    Point pt = new Point(Control.MousePosition.X + 35, Control.MousePosition.Y);//Lệch phải
                    popupMenu_Menu.ShowPopup(pt);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Menu_MouseUp");
            }
        }

        #endregion

        private void gridControl_Product_DoubleClick(object sender, EventArgs e)
        {
            frm_AddEditProduct dlg;
            product updateProduct, product;
            DataRow updateRow, newRow;
            DataTable tbSource;
            List<determine> listDetermine;

            try
            {
                if (selectNode != null && selectNode.Tag.ToString() == "2")
                {
                    XtraMessageBox.Show("Nhóm hàng này đã không còn được sử dụng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                updateRow = gridView_Product.GetFocusedDataRow();
                product = new product();
                product.ProductID = Convert.ToInt32(updateRow[_cProductID]);
                product.ProductCode = updateRow[_cProductCode].ToString();
                product.ProductName = updateRow[_cProductName].ToString();
                product.Price = Convert.ToInt32(updateRow[_cPrice]);
                product.InputPrice = Convert.ToInt32(updateRow[_cInputPrice]);

                if (updateRow[_cLimit].ToString() == "")
                {
                    updateRow[_cLimit] = "1900-01-01 00:00:00";
                }

                product.ExpiryDate = Convert.ToDateTime(updateRow[_cLimit]);
                product.DVT = Convert.ToInt32(updateRow[_cDVT]);
                product.Status = Convert.ToInt32(updateRow[_cStatus]);
                product.MadeInID = Convert.ToInt32(updateRow[_cMadeInID]);
                product.ProductSkin = Convert.ToInt32(updateRow[_cProductSkin]);
                product.Notes = updateRow[_cNotes].ToString();
                product.ExchangeQuantity = Convert.ToInt32(updateRow[_cExChangeQuantity]);
                product.ExchangeDVT = Convert.ToInt32(updateRow[_cExChangeDVT]);
                product.Type = Convert.ToInt32(updateRow[_cType]);
                product.ImageIndex = Convert.ToInt32(updateRow[_cImageIndex].ToString());

                tbSource = new DataTable();
                //Lấy danh sách định lượng
                listDetermine = (from d in _dbContext.determines.ToList() where d.ProductID == Convert.ToInt32(updateRow[_cProductID]) select d).ToList();
                if (listDetermine != null && listDetermine.Count > 0)
                {

                    tbSource.Columns.Add(_cProductID);
                    tbSource.Columns.Add(_cProductName);
                    tbSource.Columns.Add(_cQuantity);
                    tbSource.Columns.Add(_cDVT);

                    foreach (determine dt in listDetermine)
                    {
                        newRow = tbSource.NewRow();
                        newRow[_cProductID] = dt.ProcductDetermine;
                        newRow[_cProductName] = dt.product.ProductName;
                        newRow[_cQuantity] = dt.Quantity;
                        newRow[_cDVT] = dt.product.donvitinh.MADVT;

                        tbSource.Rows.Add(newRow);
                    }
                }

                dlg = new frm_AddEditProduct();
                dlg._gettbSource = tbSource;
                dlg.P_Product = product;
                dlg.list_Image = imageList_Product;
                dlg._dic_images = _dic_images;
                dlg.Text = "Sửa Mặt Hàng";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    updateProduct = (from p in _dbContext.products.ToList() where p.ProductID == product.ProductID select p).FirstOrDefault();
                    if (updateProduct != null)
                    {
                        updateProduct.ProductName = dlg.P_Product.ProductName;
                        updateProduct.ProductCode = dlg.P_Product.ProductCode;
                        updateProduct.Price = dlg.P_Product.Price;
                        updateProduct.InputPrice = dlg.P_Product.InputPrice;
                        updateProduct.ExpiryDate = dlg.P_Product.ExpiryDate;
                        updateProduct.Status = dlg.P_Product.Status;
                        updateProduct.MadeInID = dlg.P_Product.MadeInID;
                        updateProduct.ProductSkin = dlg.P_Product.ProductSkin;
                        updateProduct.Notes = dlg.P_Product.Notes;
                        updateProduct.ImageIndex = dlg.P_Product.ImageIndex;
                        updateProduct.ExchangeQuantity = dlg.P_Product.ExchangeQuantity;
                        updateProduct.ExchangeDVT = dlg.P_Product.ExchangeDVT;
                        updateProduct.Type = dlg.P_Product.Type;

                        _dbContext.SaveChanges();

                        updateRow[_cProductName] = updateProduct.ProductName;
                        updateRow[_cProductCode] = updateProduct.ProductCode;
                        updateRow[_cPrice] = updateProduct.Price;
                        updateRow[_cInputPrice] = updateProduct.InputPrice;
                        updateRow[_cLimit] = updateProduct.ExpiryDate;
                        updateRow[_cStatus] = updateProduct.Status;
                        updateRow[_cMadeInID] = updateProduct.MadeInID;
                        updateRow[_cProductSkin] = updateProduct.ProductSkin;
                        updateRow[_cMadeInName] = updateProduct.madein.MadeInName;
                        updateRow[_cNotes] = updateProduct.Notes;
                        updateRow[_cExChangeQuantity] = updateProduct.ExchangeQuantity;
                        updateRow[_cExChangeDVT] = updateProduct.ExchangeDVT;
                        updateRow[_cType] = updateProduct.Type;
                        updateRow[_cImageIndex] = updateProduct.ImageIndex;
                        updateRow[_cImage] = imageList_Product.Images[product.ImageIndex];

                        gridView_Product.LayoutChanged();

                        //Có thay đổi
                        _checkAddOrUpdate = true;
                    }
                    else
                    {
                        _checkAddOrUpdate = false;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Update_Click");
            }
        }

        private void btn_All_Click(object sender, EventArgs e)
        {
            List<product> products;
            DataRow newRow;
            try
            {
                tbSource = CreateTableStruct();
                groupControl_Product.Text = "Tất cả mặt hàng";

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                products = (from p in _dbContext.products.ToList() select p).OrderBy(o => o.ProductCode).ToList();
                if (products != null && products.Count > 0)
                {
                    foreach (product product in products)
                    {
                        newRow = tbSource.NewRow();
                        newRow[_cProductID] = product.ProductID;
                        newRow[_cProductName] = product.ProductName;
                        newRow[_cProductCode] = product.ProductCode;
                        newRow[_cProductSkin] = product.ProductSkin;
                        newRow[_cPrice] = product.Price;
                        newRow[_cInputPrice] = product.InputPrice;
                        newRow[_cLimit] = product.ExpiryDate;
                        newRow[_cDVT] = product.DVT;
                        newRow[_cStatus] = product.Status;
                        newRow[_cMadeInID] = product.MadeInID;
                        newRow[_cMadeInName] = product.madein.MadeInName;
                        newRow[_cNotes] = product.Notes;
                        newRow[_cExChangeQuantity] = product.ExchangeQuantity;
                        newRow[_cExChangeDVT] = product.ExchangeDVT;
                        newRow[_cType] = product.Type;
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
                XtraMessageBox.Show(ex.Message, "btn_All_Click");
            }
        }

    }
}