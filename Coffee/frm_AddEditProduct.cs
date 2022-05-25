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
using DevExpress.XtraEditors.Controls;

namespace Coffee
{
    public partial class frm_AddEditProduct : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        private const string _waterMask = "--- Vui lòng chọn ---";

        public mycoffeeEntities _dbContext;
        public product  P_Product { get; set; }
        public string MadeInName { get; set; }
        public ImageList list_Image { get; set; }
        public Dictionary<int, int> _dic_images { get; set; }

        public DataTable _tbSource{get;set;}

        public DataTable _gettbSource;

        private const string _cID = "ID";
        private const string _cProductID = "ProductID";
        private const string _cProductName = "ProductName";
        private const string _cProductDetermine = "ProductDetermine";
        private const string _cQuantity = "Quantity";
        private const string _cDVT = "DVT";
        

        #region ColumnName

        private const string _cMadeInID = "MadeInID";
        private const string _cMadeInName = "MadeInName";

        private const string _cMenuID = "MenuID";
        private const string _cMenuName = "MenuName";

        private const string _cDVTID = "DVTID";
        private const string _cDVTName = "DVTName";
        private const string _cDVTIDCh = "DVTIDCh";
        private const string _cDVTNameCh = "DVTNameCh";

        int iconIndex = -1;
        int _DVT = -1;
        int _DVTChange = -1;
        #endregion //--- ColumnName

        #endregion //--- Fields

        #region Form Method
        public frm_AddEditProduct()
        {
            InitializeComponent();
        }

        private void frm_AddEditProduct_Load(object sender, EventArgs e)
        {
            List<menu> menus;
            ListViewGroup group;
            try
            {
                //Tạo cấu trúc cho gridview định lượng
                _tbSource = CreateTableStruct();

                // Hình ảnh
                this.imageList_IconProduct = list_Image;

                this.listView_IconProduct.View = View.LargeIcon;
                //this.listView_IconMenu.Size = new Size(32, 32);
                this.listView_IconProduct.LargeImageList = this.imageList_IconProduct;

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                menus = (from mn in _dbContext.menus.ToList() select mn).ToList();

                if (menus != null && menus.Count > 0)
                {
                    foreach (menu m in menus)
                    {
                        group = new ListViewGroup("header", m.MenuCode);
                        listView_IconProduct.Groups.Add(group);
                        int t = 0;
                        foreach (var img in _dic_images)
                        {
                            if (img.Value == m.MenuID)// thuộc nhóm
                            {
                                ListViewItem item = new ListViewItem("", group);
                                item.ImageIndex = t;
                                this.listView_IconProduct.Items.Add(item);
                                this.listView_IconProduct.Tag = item.ImageIndex;
                            }

                            t++;
                        }
                    }
                }
                
                //--- Load thông tin nhà sản xuất vào control editor
                LoadMadeIn();

                //Load thông tin đơn vị tính
                LoadDVT();

                //Dơn vị tính cho danh sách định lượng
                LoadProductsDetermineDVT();

                //Load phân loại sản phẩm
                LoadProductSkin();

                //Load thông tin sản phẩm
                LoadInfomationProduct();

                //--- Không cho phép chỉnh sửa mã code
                //spinEdit_ProductCode.Properties.ReadOnly = true;
                if (P_Product.ProductID == 0) //--- Insert
                {                 
                    //--- Lấy mã lớn nhất tăng lên 1
                    //spinEdit_ProductCode.Text = (CoffeeHelpers.GetProductMaxCode() + 1).ToString();
                    textEdit_ProductCode.EditValue = "SP-00" + (CoffeeHelpers.GetProductMaxCode() + 1).ToString();

                    sLookUpEdit_Skin.EditValue = P_Product.ProductSkin;
                    sLookUpEdit_Skin.Properties.ReadOnly = true;
                    sLookUpEdit_Skin.Properties.Buttons[1].Enabled = false;

                    dateEdit_Limit.DateTime = DateTime.Now;

                    if (iconIndex != -1)
                    {
                        //Hiển thị lên PictureEdit
                        Bitmap image = new Bitmap(imageList_IconProduct.Images[iconIndex]);
                        pictureEdit_ImageChoose.Image = image;
                    }

                    radioButton_SaleAndSave.Checked = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditProduct_Load");
            }
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Load danh sách nhà cung cấp
        /// </summary>
        private void LoadMadeIn()
        {
            List<madein> madeins;
            DataTable tbSource;
            DataRow newRow;

            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                madeins = (from p in _dbContext.madeins.ToList() select p).ToList();

                tbSource = new DataTable();
                tbSource.Columns.Add(_cMadeInID, typeof(int));
                tbSource.Columns.Add(_cMadeInName);

                foreach (madein md in madeins)
                {
                    newRow = tbSource.NewRow();
                    newRow[_cMadeInID] = md.MadeInID;
                    newRow[_cMadeInName] = md.MadeInName;
                    tbSource.Rows.Add(newRow);
                }
                //Nếu danh sách chỉ có 1 thì hiện thị giá trị này
                int selectID = -1;

                if (madeins.Count == 1)
                {
                    selectID = madeins.FirstOrDefault().MadeInID;
                }
                else
                {
                    newRow = tbSource.NewRow();
                    newRow[_cMadeInID] = -1;
                    newRow[_cMadeInName] = _waterMask;
                    tbSource.Rows.InsertAt(newRow, 0);
                }

                slookUpEdit_MadeIn.Properties.DisplayMember = _cMadeInName;
                slookUpEdit_MadeIn.Properties.ValueMember = _cMadeInID;
                slookUpEdit_MadeIn.Properties.DataSource = tbSource;
                slookUpEdit_MadeIn.EditValue = selectID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadMadeIn");
            }
        }

        /// <summary>
        /// Load danh sách đơn vị tính
        /// </summary>
        private void LoadDVT()
        {
            List<donvitinh> dvt;

            try
            {

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dvt = (from p in _dbContext.donvitinhs.ToList() select p).ToList();

                if (dvt != null && dvt.Count > 0)
                {
                    imageComboBoxEdit_DVT.Properties.Items.Add(new ImageComboBoxItem("Chọn", -1, -1));
                    foreach (donvitinh md in dvt)
                    {
                        imageComboBoxEdit_DVT.Properties.Items.Add(new ImageComboBoxItem(md.DONVITINH1.ToString(), md.MADVT, md.ImageIndex));
                        imageComboBoxEdit_DVT.Properties.SmallImages = imageList_IconProduct;
                    }
                    imageComboBoxEdit_DVT.SelectedIndex = imageComboBoxEdit_DVT.Properties.Items.Count - 1;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadDVT");
            }
        }

        /// <summary>
        /// Load danh sách đơn vị tính
        /// </summary>
        private void LoadDVTDetermine()
        {
            List<donvitinh> dvt;

            try
            {
                if (imageComboBoxEdit_DVTChange.Properties.Items.Count > 0)
                {
                    imageComboBoxEdit_DVTChange.Properties.Items.Clear();
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                dvt = (from p in _dbContext.donvitinhs.ToList() where p.MADVT != Convert.ToInt32(imageComboBoxEdit_DVT.EditValue) select p).ToList();

                if (dvt != null && dvt.Count > 0)
                {
                    imageComboBoxEdit_DVTChange.Properties.Items.Add(new ImageComboBoxItem("Chọn", -1, -1));
                    foreach (donvitinh md in dvt)
                    {
                        imageComboBoxEdit_DVTChange.Properties.Items.Add(new ImageComboBoxItem(md.DONVITINH1.ToString(), md.MADVT, md.ImageIndex));
                        imageComboBoxEdit_DVTChange.Properties.SmallImages = imageList_IconProduct;
                    }
                    imageComboBoxEdit_DVTChange.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadDVTDetermine");
            }
        }

        /// <summary>
        /// Load danh sách phân loại
        /// </summary>
        private void LoadProductSkin()
        {
            DataTable tbSource;
            DataRow newRow;
            List<menu> listMenu;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cMenuID, typeof(int));
                tbSource.Columns.Add(_cMenuName);

                listMenu = (from me in _dbContext.menus.ToList() where me.Status == 1 select me).ToList();
                if (listMenu.Count > 0)
                {
                    foreach (menu item in listMenu)
                    {
                        newRow = tbSource.NewRow();
                        newRow[_cMenuID] = item.MenuID;
                        newRow[_cMenuName] = item.MenuCode;
                        tbSource.Rows.Add(newRow);
                    }
                }
                //Nếu danh sách chỉ có 1 thì hiện thị giá trị này
                int selectID = -1;
                if (listMenu.Count == 1)
                {
                    selectID = listMenu.FirstOrDefault().MenuID;
                }
                else
                {
                    newRow = tbSource.NewRow();
                    newRow[_cMenuID] = -1;
                    newRow[_cMenuName] = _waterMask;
                    tbSource.Rows.InsertAt(newRow, 0);
                }

                sLookUpEdit_Skin.Properties.DisplayMember = _cMenuName;
                sLookUpEdit_Skin.Properties.ValueMember = _cMenuID;
                sLookUpEdit_Skin.Properties.DataSource = tbSource;
                sLookUpEdit_Skin.EditValue = selectID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadProductSkin");
            }
        }


        /// <summary>
        /// Load thông tin product vào control editor
        /// </summary>
        private void LoadInfomationProduct()
        {
            try
            {
                //spinEdit_ProductCode.Text = P_Product.ProductID.ToString();
                if (P_Product.ProductID == 0)
                {
                    radio_Visable.Checked = false;
                    radio_Enable.Checked = true;

                    labelControl_Status.Visible = false;
                    radio_Enable.Visible = false;
                    radio_Visable.Visible = false;
                }
                else
                {
                    labelControl_Status.Visible = true;
                    radio_Enable.Visible = true;
                    radio_Visable.Visible = true;

                    if (P_Product.Status == 2)
                    {
                        radio_Visable.Checked = true;
                        radio_Enable.Checked = false;
                    }
                    else
                    {
                        radio_Visable.Checked = false;
                        radio_Enable.Checked = true;
                    }

                    if (P_Product.Type == 1)
                    {
                        radioButton_Product.Checked = true;//Mặt hàng
                    }
                    else if (P_Product.Type == 2)
                    {
                        radioButton_SaleAndSave.Checked = true;//Mặt hàng kiêm vật tư
                    }
                    else if (P_Product.Type == 3)
                    {
                        radioButton_DemandSave.Checked = true;//Vật tư
                    }
                    else
                    {
                        radioButton_services.Checked = true;//Dịch vụ
                    }


                    textEdit_ProductName.Text = P_Product.ProductName;
                    sLookUpEdit_Skin.EditValue = P_Product.ProductSkin;
                    slookUpEdit_MadeIn.EditValue = P_Product.MadeInID;
                    textEdit_ProductCode.Text = P_Product.ProductCode;
                    textEdit_Price.EditValue = P_Product.Price != null ? P_Product.Price : 0;
                    textEdit_InputPrice.EditValue = P_Product.InputPrice != null ? P_Product.InputPrice : 0;
                    imageComboBoxEdit_DVT.EditValue = P_Product.DVT;
                    imageComboBoxEdit_DVTChange.EditValue = P_Product.ExchangeDVT;
                    textEdit_QuantityDVT.EditValue = P_Product.ExchangeQuantity;
                    dateEdit_Limit.DateTime = Convert.ToDateTime(P_Product.ExpiryDate);
                    memoEdit_Notes.Text = P_Product.Notes;
                    listView_IconProduct.Items[P_Product.ImageIndex].Selected = true;
                    iconIndex = P_Product.ImageIndex;

                    //Load danh sách định lượng lên gridview
                    gridControl_Determine.DataSource = _gettbSource;

                    if (_gettbSource.Rows.Count > 0)
                    {
                        _tbSource = _gettbSource;
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadInfomationProduct");
            }
        }

        /// <summary>
        /// Kiểm tra tồn tại ShortName
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns> true: Tồn tại, false: Không tồn tại </returns>
        private bool CheckExistShortName(string productCode)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var products = from p in _dbContext.products.ToList() where p.ProductCode == productCode select p;
                if (products == null || products.Count() == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CheckExistShortName");
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra tồn tại ProductName
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns> true: Tồn tại, false: Không tồn tại </returns>
        private bool CheckExistProductName(string productName)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var products = from p in _dbContext.products.ToList() where p.ProductName == productName select p;
                if (products == null || products.Count() == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CheckExistProductName");
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra tồn tại ProductCode
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns> true: Tồn tại, false: Không tồn tại </returns>
        private bool CheckExistProductCode(string productCode)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var products = from p in _dbContext.products.ToList() where p.ProductCode == productCode select p;
                if (products == null || products.Count() == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CheckExistProductCode");
                return false;
            }
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho gridView Xuất xứ
        /// </summary>
        private DataTable CreateTableMadeInStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cMadeInID);
                tbSource.Columns.Add(_cMadeInName);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cMadeInID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableMadeInStruct");
                return tbSource;
            }
            return tbSource;
        }
        #endregion

        #region Actions
        private void button_Save_Click(object sender, EventArgs e)
        {
            bool checkExistProductCode = true;
            bool checkExistProductName = true;
            bool checkExistShortName = true;

            try
            {
                //if (Convert.ToInt32(spinEdit_ProductCode.Value) <= 0)
                //{
                //    XtraMessageBox.Show("Vui lòng khai báo mã sản phẩm nằm trong khoảng (1 -> 254)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    spinEdit_ProductCode.Focus();
                //    return;
                //}
                if (P_Product.ProductID != 0) //--- Update
                {
                    if (P_Product.ProductName != textEdit_ProductName.Text.Trim()) //--- User thay đổi productName
                        checkExistProductName = true;
                    else
                        checkExistProductName = false;

                    if (P_Product.ProductCode != textEdit_ProductCode.Text.Trim()) //--- User thay đổi shortName
                        checkExistShortName = true;
                    else
                        checkExistShortName = false;

                    if (P_Product.ProductCode != textEdit_ProductCode.ToString()) //--- User thay đổi productCode
                        checkExistProductCode = true;
                    else
                        checkExistProductCode = false;
                }
                if (checkExistProductCode == true)
                {
                    //if (CheckExistProductCode(spinEdit_ProductCode.Text) == true) //--- Tồn tại productCode trong db
                    //{
                    //    XtraMessageBox.Show("Mã sản phẩm đã bị trùng. Vui lòng đánh vào mã sản phẩm khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    spinEdit_ProductCode.Focus();
                    //    return;
                    //}
                }
                if (string.IsNullOrEmpty(textEdit_ProductName.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng nhập vào tên sản phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_ProductName.Focus();
                    return;
                }

                if (checkExistProductName == true)
                {
                    if (CheckExistProductName(textEdit_ProductName.Text.Trim()) == true) //--- Tồn tại productName trong db
                    {
                        XtraMessageBox.Show("Tên sản phẩm đã bị trùng. Vui lòng đánh vào tên sản phẩm khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textEdit_ProductName.Focus();
                        return;
                    }
                }
                if (string.IsNullOrEmpty(textEdit_ProductCode.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng nhập vào tên viết tắt của sản phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_ProductCode.Focus();
                    return;
                }
                if (Convert.ToInt32(slookUpEdit_MadeIn.EditValue) == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn xuất xứ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(sLookUpEdit_Skin.EditValue) == -1)
                {
                    XtraMessageBox.Show("Vui lòng phân loại sản phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (checkExistShortName == true)
                {
                    if (CheckExistShortName(textEdit_ProductCode.Text.Trim()) == true) //--- Tồn tại shortName trong db
                    {
                        XtraMessageBox.Show("Tên viết tắt của sản phẩm đã bị trùng. Vui lòng đánh vào tên viết tắt khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textEdit_ProductCode.Focus();
                        return;
                    }
                }
                if (Convert.ToInt32(textEdit_Price.EditValue) <= 0 || string.IsNullOrEmpty(textEdit_Price.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng nhập giá", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_Price.Focus();
                    return;
                }
                if (Convert.ToInt32(imageComboBoxEdit_DVT.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn đơn vị tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (iconIndex == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn biểu tượng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(imageComboBoxEdit_DVTChange.EditValue) >0 && Convert.ToInt32(textEdit_QuantityDVT.Text) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng nhập số lượng quy đổi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                P_Product.ProductName = textEdit_ProductName.Text.Trim();
                P_Product.ProductCode = textEdit_ProductCode.Text;
                P_Product.Price = Convert.ToInt32(textEdit_Price.EditValue);
                P_Product.InputPrice = Convert.ToInt32(textEdit_InputPrice.Text.Trim());
                P_Product.ProductSkin = Convert.ToInt32(sLookUpEdit_Skin.EditValue);
                P_Product.DVT = Convert.ToInt32(imageComboBoxEdit_DVT.EditValue);
                P_Product.ExchangeDVT = Convert.ToInt32(imageComboBoxEdit_DVTChange.EditValue);
                P_Product.ExchangeQuantity = Convert.ToInt32(textEdit_QuantityDVT.EditValue);
                P_Product.ExpiryDate = dateEdit_Limit.DateTime != null ? dateEdit_Limit.DateTime : DateTime.Now;

                if (radio_Enable.Checked == true)
                    P_Product.Status = 1;
                else
                    P_Product.Status = 2;

                if (radioButton_Product.Checked == true)
                {
                    P_Product.Type = 1;//Mặt hàng
                }
                else if (radioButton_SaleAndSave.Checked == true)
                {
                    P_Product.Type = 2;//Mặt hàng kiêm vật tư
                }
                else if (radioButton_DemandSave.Checked == true)
                {
                    P_Product.Type = 3;//Vật tư
                }
                else
                {
                    P_Product.Type = 4;//Dịch vụ
                }

                P_Product.MadeInID = Convert.ToInt32(slookUpEdit_MadeIn.EditValue);
                MadeInName = slookUpEdit_MadeIn.Text;
                P_Product.Notes = memoEdit_Notes.Text.Trim();
                P_Product.ImageIndex = iconIndex;

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Save_Click");
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

        private void textEdit_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar) ||
                char.IsSymbol(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) ||
                char.IsPunctuation(e.KeyChar))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_Price_KeyPress");
            }
        }

        private void listView_IconProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedIndexCollection indexes = this.listView_IconProduct.SelectedIndices;
                if (indexes.Count > 0)
                {
                    foreach (int index in indexes)
                    {
                        iconIndex = index;

                        //Hiển thị lên PictureEdit
                        Bitmap image = new Bitmap(imageList_IconProduct.Images[index]);
                        pictureEdit_ImageChoose.Image = image;
                    }
                }
                else
                {
                    iconIndex = -1;
                    pictureEdit_ImageChoose.Image = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "listView_IconProduct_SelectedIndexChanged");
            }
        }

        private void radioButton_Product_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton_Product.Checked == true)
                {
                    xtraTabPage_DinhLuong.PageVisible = true;
                }
                else
                {
                    xtraTabPage_DinhLuong.PageVisible = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "radioButton_Product_CheckedChanged");
            }
        }

        private void radioButton_SaleAndSave_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton_SaleAndSave.Checked == true)
                {
                    xtraTabPage_DinhLuong.PageVisible = false;  
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "radioButton_Product_CheckedChanged");
            }
        }

        private void imageComboBoxEdit_DVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ImageComboBoxEdit editor = sender as ImageComboBoxEdit;
                _DVT = Convert.ToInt32(editor.EditValue);

                if (Convert.ToInt32(imageComboBoxEdit_DVT.EditValue) != -1)
                {
                    //Load thông tin đơn vị quy đổi
                    LoadDVTDetermine();
                }
                else
                {
                    imageComboBoxEdit_DVTChange.Properties.Items.Clear();
                    imageComboBoxEdit_DVTChange.Properties.Items.Add(new ImageComboBoxItem("Chọn", -1, -1));
                    lbl_Determine.Text = "Quy đổi (=>)";
                    textEdit_QuantityDVT.Enabled = false;
                }
                _DVT = Convert.ToInt32(imageComboBoxEdit_DVT.EditValue);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "imageComboBoxEdit_DVT_SelectedIndexChanged");
            }
        }

        private void imageComboBoxEdit_DVTChange_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ImageComboBoxEdit editor = sender as ImageComboBoxEdit;
                _DVTChange = Convert.ToInt32(editor.EditValue);
                if (_DVT == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn đơn vị tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_DVTChange != -1)
                {
                    lbl_Determine.Text = "Quy đổi ( " + imageComboBoxEdit_DVT.Text + " => " + imageComboBoxEdit_DVTChange.Text + " )";
                    textEdit_QuantityDVT.Enabled = true;
                }
                else
                {
                    lbl_Determine.Text = "Quy đổi (=>)";
                    textEdit_QuantityDVT.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "imageComboBoxEdit_DVTChange_SelectedIndexChanged");
            }
        }
        #endregion

        private void imageComboBoxEdit_DVT_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frm_AddEditDVT dlg;
            donvitinh dvt;
            try
            {
                if (e.Button.Index != imageComboBoxEdit_DVT.Properties.Buttons[1].Index)
                {
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dvt = new donvitinh();
                dlg = new frm_AddEditDVT();
                dlg.P_DVT = dvt;
                dlg._dbContext = _dbContext;
                dlg.list_Image = list_Image;
                dlg.Text = "Thêm Đơn Vị Tính";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.donvitinhs.Add(dlg.P_DVT);
                    _dbContext.SaveChanges();

                    LoadDVT();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "imageComboBoxEdit_DVT_Properties_ButtonClick");
            }
        }

        private void slookUpEdit_MadeIn_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frm_AddEditMadeIn dlg;
            madein madein;

            try
            {
                if (e.Button.Index != slookUpEdit_MadeIn.Properties.Buttons[1].Index)
                {
                    return;
                }

                dlg = new frm_AddEditMadeIn();
                madein = new madein();
                dlg.P_madein = madein;
                dlg.Text = "Thêm Nhà Cung Cấp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    _dbContext.madeins.Add(dlg.P_madein);
                    _dbContext.SaveChanges();

                    LoadMadeIn();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "slookUpEdit_MadeIn_Properties_ButtonClick");
            }
        }

        private void btn_DetermineAdd_Click(object sender, EventArgs e)
        {
            DataRow row;
            determine determine;
            frm_SelectProductToStock dlg;
            try
            {
                dlg = new frm_SelectProductToStock();
                determine = new determine();
                dlg._dbContext = _dbContext;
                dlg.P_Deterine = determine;
                dlg.list_Image = list_Image;
                dlg.Text = "Thêm Định Lượng";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //Lưu lại danh sách định lượng cho sản phẩm này
                    row = _tbSource.NewRow();
                    row[_cProductID] = dlg.P_Deterine.ProcductDetermine;
                    row[_cQuantity] = dlg.P_Deterine.Quantity;
                    row[_cProductName] = dlg._ProductName;
                    row[_cDVT] = dlg._DVT.ToString();

                    _tbSource.Rows.Add(row);
                }
                gridControl_Determine.DataSource = _tbSource;
                
               // determine= new Determine();
               //determine
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_DetermineAdd_Click");
            }
        }

        private void btn_DetermineUpdate_Click(object sender, EventArgs e)
        {
            DataRow focusRow;
            frm_ChooseInPutStock dlg;
            try
            {
                if (gridView_Determine.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn mặt hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                focusRow = gridView_Determine.GetFocusedDataRow();

                dlg = new frm_ChooseInPutStock();
                dlg.Text = "Số Lượng";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataRow rw in _tbSource.Rows)
                    {
                        if (Convert.ToInt32(rw[_cProductID]) == Convert.ToInt32(focusRow[_cProductID]))
                        {
                            rw[_cQuantity] = dlg._Quantity;

                            focusRow[_cQuantity]=dlg._Quantity;

                            gridView_Determine.LayoutChanged();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_DetermineUpdate_Click");
            }
        }

        private void btn_DetermineDelete_Click(object sender, EventArgs e)
        {
            DataRow focusRow;
            try
            {
                if (gridView_Determine.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn mặt hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                focusRow = gridView_Determine.GetFocusedDataRow();
                foreach (DataRow rw in _tbSource.Rows)
                {
                    if (Convert.ToInt32(rw[_cProductID]) == Convert.ToInt32(focusRow[_cProductID]))
                    {
                        _tbSource.Rows.Remove(rw);
                        gridView_Determine.LayoutChanged();
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_DetermineDelete_Click");
            }
        }

        //Tạo cấu trúc cho gridview
        private DataTable CreateTableStruct()
        {
            DataTable tbSource= null;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cQuantity);
                tbSource.Columns.Add(_cDVT);
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
        private void LoadProductsDetermineDVT()
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
                    }
                    repositoryItemLookUpEdit_DVT.DisplayMember = "DVT";
                    repositoryItemLookUpEdit_DVT.ValueMember = "ID";
                    repositoryItemLookUpEdit_DVT.DataSource = tbSource;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadProductsDetermineDVT");
            }
        }

        private void sLookUpEdit_Skin_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            frm_AddEditMenu dlg;
            menu menus;
            try
            {
                if (e.Button.Index != sLookUpEdit_Skin.Properties.Buttons[1].Index)
                {
                    return;
                }


                dlg = new frm_AddEditMenu();
                menus = new menu();
                dlg._dbContext = _dbContext;
                dlg.P_Menu = menus; ;
                dlg.Text = "Thêm Mới Thực Đơn";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.menus.Add(dlg.P_Menu);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "sLookUpEdit_Skin_Properties_ButtonClick");
            }
        }
    }
}