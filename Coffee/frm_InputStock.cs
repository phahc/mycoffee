using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Coffee.Utils;
using System.Linq;
using DevExpress.XtraBars;

namespace Coffee
{
    public partial class frm_InputStock : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private const string _waterMask = "--- Vui lòng chọn ---";

        public mycoffeeEntities _dbContext;
        public bool _checkAddOrUpdate { get; set; }
        public DataTable _tbSource { get; set; }
        public hoadonnhap P_HoaDonNhap { get; set; }
        public chitiethdn P_CTDonNhap { get; set; }
        public List<chitiethdn> ListCTDonNhap { get; set; }

        public DataTable listMenu { get; set; }//Giữ danh sách thực đơn


        #region ColumnName

        private const string _cProductID = "ProductID";
        private const string _cProductName = "ProductName";
        private const string _cProductCode = "ProductCode";
        private const string _cPrice = "Price";
        private const string _cInputPrice = "InputPrice";
        private const string _cLimit = "Limit";
        private const string _cDVT = "DVT";
        private const string _cStatus = "Status";
        private const string _cNotes = "Notes";
        private const string _cImageIndex = "ImageIndex";
        private const string _cImage = "Image";
        private const string _cQuantity = "Quantity";

        private const string _cDVTID = "DVTID";
        private const string _cDVTName = "DVTName";

        private const string _cMadeInID = "MadeInID";
        private const string _cProductSkin = "ProductSkin";
        private const string _cMadeInName = "MadeInName";


        private const string _cMenuID = "MenuID";
        private const string _cMenuName = "MenuName";
        private const string _cMenuCode = "MenuCode";

        TreeNode selectNode;//Menu đang chọn

        DateTime dtNow;

        #endregion //--- ColumnName

        #endregion //--- Fields

        public frm_InputStock()
        {
            InitializeComponent();
        }

        private void frm_InputStock_Load(object sender, EventArgs e)
        {
            try
            {
                string filePath = System.IO.Directory.GetCurrentDirectory();
                string path = filePath.Substring(0, filePath.Length - 9);

                DirectoryInfo dir = new DirectoryInfo(path + "Images\\Product\\32");

                foreach (FileInfo file in dir.GetFiles())
                {
                    try
                    {
                        this.imageList_Product.Images.Add(Image.FromFile(file.FullName));
                    }
                    catch
                    {
                        Console.WriteLine("This is not an image file");
                    }
                }

                _tbSource = CreateTableStruct();

                //Danh sách thực đơn
                AddMenuOnList();

                //Danh sách nhà cung cấp
                LoadMadeIn();

                if (P_HoaDonNhap.MAHDN == 0)//Add
                {
                    dtNow = DateTime.Now;
                    dateEdit_Date.DateTime = dtNow;

                    textEdit_HDCode.Text = "HDN-" + dtNow.ToString("dd/MM/yy") + "-00" + CoffeeHelpers.GetHoaDonNhapMaxCode() + 1;
                }
                else
                {
                    dateEdit_Date.EditValue = P_HoaDonNhap.NGAYNHAP;
                    textEdit_HDCode.Text = P_HoaDonNhap.HDNCode;
                    lookUpEdit_NCC.EditValue = P_HoaDonNhap.MANCC;
                    memoEdit_Notes.Text = P_HoaDonNhap.GHICHU;
                    textEdit_TotalMoney.EditValue = string.Format("{0:#,#}", Convert.ToString(P_HoaDonNhap.TIENDATRA));
                    textEdit_TotalMoney.EditValue = string.Format("{0:#,#}", Convert.ToString(P_HoaDonNhap.TIENPHAITRA));

                    if (P_HoaDonNhap.TIENDATRA < P_HoaDonNhap.TIENPHAITRA)//Có nợ nhà cung cấp
                    {
                        checkEdit_Tally.Checked = true;
                    }

                    DataRow row;
                    foreach (chitiethdn  ct in ListCTDonNhap)
                    {
                        row = _tbSource.NewRow();
                        row[_cProductID] = ct.product.ProductID;
                        row[_cProductName] = ct.product.ProductName;
                        row[_cQuantity] = ct.SOLUONGNHAP;
                        row[_cDVT] = ct.product.donvitinh.DONVITINH1;
                        row[_cPrice] = ct.GIANHAP;

                        _tbSource.Rows.Add(row);
                    }
                    gridControl_ProductStock.DataSource = _tbSource;
                }     
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_InputStock_Load");
            }
        }

        private void treeView_Product_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {

                if (e.Button == MouseButtons.Right)
                {
                    return;// Nếu click chuột phải thì không làm gì(chỉ hiện popup)
                }

                selectNode= e.Node;
                if (selectNode == null)
                {
                    return;
                }
                if (e.Button == MouseButtons.Left)
                {
                    barButtonItem_Add.Visibility = BarItemVisibility.Always;
                    barButtonItem_Add.Caption = "Thêm vào kho ";
                    Point pt = new Point(Control.MousePosition.X + 35, Control.MousePosition.Y);//Lệch phải
                    popupMenu_Product.ShowPopup(pt);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Product_NodeMouseClick");
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
            List<product> products;
            TreeNode node;
            try
            {
                selectNode = e.Node;

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
                    //Xoá thông tin cũ trên treeview product
                    treeView_Product.Nodes.Clear();

                    foreach (product product in products)
                    {
                        node = new TreeNode();
                        node.Name = product.ProductID.ToString();
                        node.Text = product.ProductName + "/ " + product.donvitinh.DONVITINH1 +"/ "+string.Format("{0:#,#}",Convert.ToString(product.InputPrice));
                        node.Tag = product.InputPrice;
                        node.ImageIndex = product.ImageIndex;
                        node.SelectedImageIndex = product.ImageIndex;

                        treeView_Product.Nodes.Add(node);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Menu_NodeMouseClick");
            }
        }

        private void checkEdit_Tally_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkEdit_Tally.Checked)
                {
                    lbl_Tally.Visible = true;
                    textEdit_MoneyPay.Visible = true;
                }
                else
                {
                    lbl_Tally.Visible = false;
                    textEdit_MoneyPay.Visible = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkEdit_Tally_CheckedChanged");
            }
        }

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

                lookUpEdit_NCC.Properties.DisplayMember = _cMadeInName;
                lookUpEdit_NCC.Properties.ValueMember = _cMadeInID;
                lookUpEdit_NCC.Properties.DataSource = tbSource;
                lookUpEdit_NCC.EditValue = selectID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadMadeIn");
            }
        }

        //Thêm mặt hàng vào kho
        private void barButtonItem_Add_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_ChooseInPutStock dlg;
            DataRow row;
            try
            {
                dlg = new frm_ChooseInPutStock();
                dlg.Text = "Số Lượng Nhập Kho";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string[] productName = selectNode.Text.Split('/');
                    bool checkExist = false;
                    foreach (DataRow r in _tbSource.Rows)
                    {
                        if (Convert.ToInt32(r[_cProductID]) == Convert.ToInt32(selectNode.Name))
                        {
                            r[_cQuantity] = Convert.ToInt32(r[_cQuantity]) + dlg._Quantity;
                            gridView_ProductStock.LayoutChanged();
                            checkExist = true;//Mặt hàng đã có
                            break;
                        }
                    }
                    if (checkExist == false)
                    {
                        row = _tbSource.NewRow();
                        row[_cProductID] = selectNode.Name;
                        row[_cProductName] = productName[0].ToString();
                        row[_cQuantity] = dlg._Quantity;
                        row[_cDVT] = productName[1].ToString().Trim();
                        row[_cPrice] = productName[2].ToString().Trim();

                        _tbSource.Rows.Add(row);
                    }

                    decimal total = Convert.ToDecimal(textEdit_TotalMoney.EditValue) + (Convert.ToDecimal(selectNode.Tag.ToString()) * dlg._Quantity);
                    textEdit_TotalMoney.EditValue = string.Format("{0:#,#}",Convert.ToString(total)); 
                }

                gridControl_ProductStock.DataSource = _tbSource;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Add_ItemClick");
            }
        }

        //Tạo cấu trúc cho gridView chi tiết Hoá Đơn Nhập
        private DataTable CreateTableStruct()
        {
            DataTable tbSource = null;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cQuantity);
                tbSource.Columns.Add(_cDVT);
                tbSource.Columns.Add(_cPrice);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        private void gridControl_ProductStock_Click(object sender, EventArgs e)
        {

        }

        private void gridControl_ProductStock_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                barButtonItem_AddStock.Visibility = BarItemVisibility.Never;
                barButtonItem_Down.Visibility = BarItemVisibility.Never;
                barButtonItem_Delete.Visibility = BarItemVisibility.Never;

                if (e.Button == MouseButtons.Left)
                {
                    barButtonItem_AddStock.Visibility = BarItemVisibility.Always;
                    barButtonItem_Down.Visibility = BarItemVisibility.Always;
                }
                else
                {
                    barButtonItem_Delete.Visibility = BarItemVisibility.Always;
                }

                popupMenu_Stock.ShowPopup(Control.MousePosition);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_ProductStock_MouseUp");
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(lookUpEdit_NCC.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (gridView_ProductStock.RowCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng thêm mặt hàng vào kho", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (P_HoaDonNhap.MAHDN == 0)
                {
                    //Thông tin của đơn hàng nhập
                    P_HoaDonNhap.MAHDN = CoffeeHelpers.GetHoaDonNhapMaxCode() + 1;
                }
                P_HoaDonNhap.HDNCode = textEdit_HDCode.Text;
                P_HoaDonNhap.MANCC = Convert.ToInt32(lookUpEdit_NCC.EditValue);
                P_HoaDonNhap.MANV = CoffeeHelpers.EmpLogin.EmployeeID;
                P_HoaDonNhap.NGAYNHAP = dateEdit_Date.DateTime;
                P_HoaDonNhap.TIENPHAITRA = Convert.ToDecimal(textEdit_TotalMoney.EditValue);

                if (checkEdit_Tally.Checked)
                {
                    P_HoaDonNhap.TIENDATRA = Convert.ToDecimal(textEdit_MoneyPay.EditValue);
                }
                else
                {
                    P_HoaDonNhap.TIENDATRA = Convert.ToDecimal(textEdit_TotalMoney.EditValue);
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Save_Click");
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

        private void barButtonItem_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow focusRow;
            try
            {
                focusRow = gridView_ProductStock.GetFocusedDataRow();
                foreach (DataRow rw in _tbSource.Rows)
                {
                    if (rw[_cProductID].ToString().Trim() == focusRow[_cProductID].ToString().Trim())
                    {
                        decimal money = Convert.ToDecimal(textEdit_TotalMoney.EditValue) - (Convert.ToInt32(focusRow[_cQuantity]) * Convert.ToDecimal(focusRow[_cPrice]));
                        textEdit_TotalMoney.EditValue = string.Format("{0:#,#}", Convert.ToString(money));

                        _tbSource.Rows.Remove(rw);
                        break;
                    }
                }
                gridView_ProductStock.LayoutChanged();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Delete_ItemClick");
            }
        }

        private void barButtonItem_AddStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow focusRow;
            frm_ChooseInPutStock dlg;
            try
            {
                dlg= new frm_ChooseInPutStock();
                
                focusRow = gridView_ProductStock.GetFocusedDataRow();
                dlg.Text="Số Lượng Thêm";
                if(dlg.ShowDialog()==DialogResult.OK)
                {
                    foreach (DataRow rw in _tbSource.Rows)
                    {
                        if (rw[_cProductID].ToString().Trim() == focusRow[_cProductID].ToString().Trim())
                        {
                            decimal money = Convert.ToDecimal(textEdit_TotalMoney.EditValue) + (dlg._Quantity * Convert.ToDecimal(focusRow[_cPrice]));
                            textEdit_TotalMoney.EditValue = string.Format("{0:#,#}", Convert.ToString(money));

                            rw[_cQuantity] =Convert.ToInt32(rw[_cQuantity])+ dlg._Quantity;
                            break;
                        }
                    }
                    gridView_ProductStock.LayoutChanged();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_AddStock_ItemClick");
            }
        }

        private void barButtonItem_Down_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow focusRow;
            frm_ChooseInPutStock dlg;
            try
            {
                dlg = new frm_ChooseInPutStock();

                focusRow = gridView_ProductStock.GetFocusedDataRow();
                dlg.Text = "Số Lượng Giảm";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataRow rw in _tbSource.Rows)
                    {
                        if (rw[_cProductID].ToString().Trim() == focusRow[_cProductID].ToString().Trim())
                        {
                            if (Convert.ToInt32(rw[_cQuantity]) - dlg._Quantity > 0)//Giá trị nhỏ nhất phải là 1. Nếu giảm về không thì không làm gì cả
                            {
                                decimal money = Convert.ToDecimal(textEdit_TotalMoney.EditValue) - (dlg._Quantity * Convert.ToDecimal(focusRow[_cPrice]));
                                textEdit_TotalMoney.EditValue = string.Format("{0:#,#}", Convert.ToString(money));

                                rw[_cQuantity] = Convert.ToInt32(rw[_cQuantity]) - dlg._Quantity;
                            }
                            break;
                        }
                    }

                    gridView_ProductStock.LayoutChanged();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Down_ItemClick");
            }
        }

        // Show tất cả mặt hàng
        private void btn_All_Click(object sender, EventArgs e)
        {
            List<product> products;
            TreeNode node;
            try
            {

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                products = (from p in _dbContext.products.ToList() select p).OrderBy(o => o.ProductCode).ToList();
                if (products != null && products.Count > 0)
                {
                    //Xoá thông tin cũ trên treeview product
                    treeView_Product.Nodes.Clear();

                    foreach (product product in products)
                    {
                        node = new TreeNode();
                        node.Name = product.ProductID.ToString();
                        node.Text = product.ProductName + "/ " + product.donvitinh.DONVITINH1 + "/ " + string.Format("{0:#,#}", Convert.ToString(product.InputPrice));
                        node.Tag = product.InputPrice;
                        node.ImageIndex = product.ImageIndex;
                        node.SelectedImageIndex = product.ImageIndex;

                        treeView_Product.Nodes.Add(node);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_All_Click");
            }
        }

        private void lookUpEdit_NCC_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frm_AddEditMadeIn dlg;
            madein madein;

            try
            {
                if (e.Button.Index != lookUpEdit_NCC.Properties.Buttons[1].Index)
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

                    //Danh sách nhà cung cấp
                    LoadMadeIn();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "lookUpEdit_NCC_Properties_ButtonClick");
            }
        }
    }
}