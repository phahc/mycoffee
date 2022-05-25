using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Coffee.Utils;
using System.Threading;
using TracerX;
using System.Linq;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraBars;
using System.Resources;
using System.Reflection;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Repository;

namespace Coffee
{
    public partial class frm_InputOrder : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        public int _configMaxArea { get; set; }
        public ImageList list_Image { get; set; }

        mycoffeeEntities _dbContext;
        // Đối tượng Log cho lớp
        private static readonly Logger log = Logger.GetLogger(typeof(frm_MainCoffee));

        private DataTable _tbSourceTable;//Bàn trống
        private DataTable _tbSourceListOrder;//Bàn đang bán
        private DataTable _tbSourceOrderDetail;//Chi tiết đơn hàng(bàn)

        private GroupControl Group_Table;
        private PictureEdit Picture_table;
        private RadioButton RadioControl_Area;
        int maxOrderID = 0;
        int _default_maxTable = 0;//Số bàn tối đa trên dòng

        private List<GroupControl> Group_ListTable = new List<GroupControl>();
        private List<PictureEdit> Picture_ListTable = new List<PictureEdit>();
        private List<RadioButton> Radion_Area = new List<RadioButton>();

        DataTable tbProduct;//Giữ danh sách sản phẩm
        DataTable tbMenu;//Giữ danh mục thự đơn
        List<TreeNode> treeNode;//Giữ các node cha trong tree Sản phẩm

        int areaIDChecked = -1;
        int orderIDSelected = -1;
        string _childNode = "childNode";
        PictureEdit Order_Pre = new PictureEdit();
        // Đối tượng timer đóng ứng dụng
        private System.Threading.Timer _timerCloseApp = null;
        //Show Sologan
        DevExpress.Utils.WaitDialogForm dlg_wait = null;
        #endregion

        #region Columns
        private const string _cAreaID = "AreaID";
        private const string _cAreaCode = "AreaCode";
        private const string _cStatus = "Status";
        private const string _cTableID = "TableID";
        private const string _cTableCode = "TableCode";

        private const string _cID = "ID";
        private const string _cOrderID = "OrderID";
        private const string _cProductName = "ProductName";
        private const string _cProductID = "ProductID";
        private const string _cQuantity = "Quantity";
        private const string _cDate = "Date";
        private const string _cPrice = "Price";
        private const string _cPromote = "Promote";

        private const string _cEmployeeID = "EmployeeID";
        private const string _cEmployeeName = "EmployeeName";
        private const string _cMoneyCreadit = "MoneyCredit";

        private const string _cShortName = "ShortName";
        private const string _cProductCode = "ProductCode";
        private const string _cNotes = "Notes";
        private const string _cImageIndex = "ImageIndex";
        private const string _cImage = "Image";

        private const string _cMadeInID = "MadeInID";
        private const string _cProductSkin = "ProductSkin";
        private const string _cMadeInName = "MadeInName";

        private const string _cMenuID = "MenuID";
        private const string _cMenuCode = "MenuCode";

        private const string _cOrderCode = "OrderCode";
        private const string _cTotal_Money = "Total_Money";

       
        #endregion

        #region Form Method
        public frm_InputOrder()
        {
            InitializeComponent();
        }

        private void frm_InputOrder_Load(object sender, EventArgs e)
        {
            DateTime dtNow, dtBegin, dtEnd;
            DateTime dtLoginTime = DateTime.Now;

            try
            {
                dtNow = DateTime.Now;
                dtBegin = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);

                //Khởi tạo tableSource danh sách thu gọn của chi tiết đơn hàng
                _tbSourceOrderDetail = CreateOrderProductShortTableStruct();
                _tbSourceListOrder = CreateOrderTableStruct();

                imageList_Product = list_Image;

                //Load danh sách khu vực
                LoadAreaData();

                //Load danh sách sản phẩm
                Load_CrateProduct();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_InputOrder_Load");
            }
        }

        private void frm_MainCoffee_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (areaIDChecked != -1)
                {
                    //Load danh sách bàn đang bán
                    LoadOrderTable_FromTableSource(areaIDChecked);
                }
                if (orderIDSelected != -1)
                {
                    //Thao tác click chọn đơn hàng
                    SelectOrder_Click(orderIDSelected);

                    //Thông tin chi tiết đơn hàng
                    LoadOrderAndProduct(orderIDSelected);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_MainCoffee_SizeChanged");
            }
        }
        #endregion

        #region Helpers
        //Danh sách khu vực
        /// <summary>
        /// Danh sách khu vực
        /// </summary>
        private void LoadAreaData()
        {
            List<area> areas;
            int line_y = xtraScrollable_Area.Height / 5;
            int line_x = 0;
            xtraScrollable_Area.VerticalScroll.Visible = false;
            try
            {
                if (xtraScrollable_Area.Controls.Count > 0)
                {
                    xtraScrollable_Area.Controls.Clear();
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                areas = (from ar in _dbContext.areas.ToList() where ar.Status == 1 orderby ar.AreaID select ar).ToList();

                int loop = 1;
                if (areas != null && areas.Count > 0)
                {
                    foreach (area ar in areas)
                    {
                        RadioControl_Area = new RadioButton();

                        Point p = new Point(((line_x) * 100) + 10, line_y);
                        RadioControl_Area.Location = p;
                        RadioControl_Area.Text = ar.AreaCode.ToString();
                        RadioControl_Area.Name = "Area" + ar.AreaID.ToString();
                        Font f = new Font("times new roman", 11.0f, System.Drawing.FontStyle.Bold);
                        RadioControl_Area.Font = f;
                        RadioControl_Area.ForeColor = Color.FromArgb(205, 38, 38);
                        RadioControl_Area.Width = 100;
                        RadioControl_Area.Height = 20;
                        line_x++;

                        RadioControl_Area.CheckedChanged += new EventHandler(RadioChecked_Change);
                        Radion_Area.Add(RadioControl_Area);
                        xtraScrollable_Area.Controls.Add(RadioControl_Area);

                        // Cấu hình hệ thống cho phép số khu vực tối đa
                        if (loop == _configMaxArea)
                        {
                            break;
                        }
                        loop++;
                    }

                    Radion_Area[0].Checked = true;
                    areaIDChecked = Convert.ToInt32(Radion_Area[0].Name.Substring(4));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadAreaData");
            }
        }

        private void LoadOrderTable_FromTableSource(int areaID)
        {
            // List<ListOrder> listOrders;
            int line_y = 1;
            int line_x = 0;
            int loop = 0;

            try
            {
                //Chieu rong cua xtraScrollable cho phep chu toi da ban co kich thuoc 105x105
                int maxTable = xtraScrollable_TableActive.Width / 95;
                _default_maxTable = maxTable;

                //Xóa bàn nếu có
                if (xtraScrollable_TableActive.Controls.Count > 0)
                {
                    for (int i = 0; i < xtraScrollable_TableActive.Controls.Count; i++)
                    {
                        xtraScrollable_TableActive.Controls.RemoveByKey(xtraScrollable_TableActive.Controls[i].Name);
                        i--;
                    }
                }

                Group_ListTable = null;
                Group_ListTable = new List<GroupControl>();

                Picture_ListTable = null;
                Picture_ListTable = new List<PictureEdit>();

                if (_tbSourceListOrder.Rows.Count > 0)
                {
                    int i = 2;
                    foreach (DataRow row in _tbSourceListOrder.Rows)
                    {
                        //Số bàn tối đa cho phép trên dòng
                        if (loop == maxTable)
                        {
                            maxTable = _default_maxTable * i;

                            line_x = 0;// Tra hoanh do ve 0
                            line_y = (line_y + 97) + 5;//Tung do tang len ban mot kich thuoc chieu cao cua hang truoc

                            //--Hang ban thu may
                            i++;
                        }

                        Group_Table = new GroupControl();
                        Picture_table = new PictureEdit();

                        Point p = new Point(((line_x) * 97) + 5, line_y);
                        Group_Table.Location = p;
                        Group_Table.Text = row[_cTableCode].ToString();
                        Group_Table.Name = "Order" + row[_cOrderID].ToString();
                        Group_Table.Tag = row[_cOrderID].ToString();
                        Group_Table.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        Font f = new Font("times new roman", 11.0f, System.Drawing.FontStyle.Bold);
                        Group_Table.AppearanceCaption.Font = f;
                        Group_Table.AppearanceCaption.ForeColor = Color.Maroon;
                        Group_Table.Width = 97;
                        Group_Table.Height = 100;
                        Group_Table.BackColor = System.Drawing.Color.Transparent;
                        Group_Table.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;

                        Picture_ListTable.Add(Picture_table);
                        Group_Table.Controls.Add(Picture_table);
                        Picture_table.Name = "Image" + row[_cOrderID].ToString();
                        Picture_table.Tag = row[_cTableCode].ToString().ToLower();
                        Picture_table.Dock = DockStyle.Fill;
                        Picture_table.Image = Coffee.Properties.Resources.Coffee_break_icon;
                        Picture_table.Properties.ShowMenu = false;//Không cho click phải chuột
                        Picture_table.BackColor = System.Drawing.Color.Transparent;
                        Picture_table.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        Picture_table.Click += new EventHandler(TableActive_Click);
                        Picture_table.MouseUp += new MouseEventHandler(pictureEdit_MouseUp);//Sự kiện showpopup khi clcik

                        Group_ListTable.Add(Group_Table);
                        xtraScrollable_TableActive.Controls.Add(Group_Table);

                        Group_Table.LookAndFeel.UseDefaultLookAndFeel = false;
                        Group_Table.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

                        line_x++;// Tang hoanh do

                        // Lap so ban
                        loop++;

                        //Chọn đơn hàng
                        SelectOrder_Click(Convert.ToInt32(row[_cOrderID]));

                        //Thông tin chi tiết đơn hàng
                        LoadOrderAndProduct(Convert.ToInt32(row[_cOrderID]));
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadOrderTable_FromTableSource");
            }
        }

        //Load danh sách bàn trống
        /// <summary>
        /// Load danh sách bàn trống
        /// </summary>
        /// <param name="areaID"></param>
        private void LoadListTableEmpty(int areaID)
        {
            List<area_table> area_tbl;
            DataRow row;
            try
            {
                //Khởi tạo tbSource
                _tbSourceTable = CreateArea_TableStruct();

                treeView_TableEmpty.Nodes.Clear();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                area_tbl = (from tb in _dbContext.area_table.ToList() where tb.AreaID == areaID select tb).ToList();

                if (area_tbl != null && area_tbl.Count > 0)
                {
                    foreach (var item in area_tbl)
                    {
                        treeView_TableEmpty.Nodes.Add(item.TableID.ToString(), item.TableCode, item.ImageIndex, item.ImageIndex);

                        row = _tbSourceTable.NewRow();
                        row[_cTableID] = item.TableID;
                        row[_cTableCode] = item.TableCode;
                        row[_cAreaID] = item.AreaID;
                        row[_cStatus] = item.Status;
                        row[_cImageIndex] = item.ImageIndex;

                        _tbSourceTable.Rows.Add(row);

                    }

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadListTableEmpty");
            }
        }

        #region PictureEdit Event

        private void TableActive_Click(object sender, EventArgs e)
        {
            try
            {
                PictureEdit image = sender as PictureEdit;
                int orID = Convert.ToInt32(image.Name.Substring(5));
                orderIDSelected = orID;
                if (image != null)
                {
                    if (Order_Pre != null)
                    {
                        Order_Pre.Image = Coffee.Properties.Resources.Coffee_break_icon;
                    }
                    Order_Pre = image;
                    image.Image = Coffee.Properties.Resources.coffeecup_red;
                    groupControl_OrderDetail.Text = "Nội dung thực đơn " + image.Tag;

                    foreach (DataRow rw in _tbSourceListOrder.Rows)
                    {
                        if (Convert.ToInt32(rw[_cOrderID]) == orderIDSelected)
                        {
                            //Load danh sách nhân viên
                            LoadEmployees();

                            dateEdit_Date.EditValue = Convert.ToDateTime(rw[_cDate]);
                            sLookUpEdit_UpdateEmployee.EditValue = Convert.ToInt32(rw[_cEmployeeID]);
                            textEdit_UpdateTotalMoney.EditValue = Convert.ToDecimal(rw[_cTotal_Money]);
                            textEdit_TotalMoney.Text = string.Format("{0:C}", Convert.ToDecimal(rw[_cTotal_Money]));// Tổng tiền về 0 khi mới thanh toán

                            break;
                        }
                    }

                    //Thông tin chi tiết đơn hàng
                    LoadOrderAndProduct(orderIDSelected);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TableActive_Click");
            }
        }

        #endregion

        private void TimerCloseAppCallback(object state)
        {
            try
            {
                this.BeginInvoke(new Action(() => { dlg_wait.Close(); _timerCloseApp = null; }));
            }
            catch (Exception ex)
            {
                // Xuất ra file log
                log.Error("Hàm TimerCloseAppCallback đã phát ra Exception ", ex.Message);
            }
        }

        //Load thông tin  đơn hàng
        private void LoadOrderAndProduct(int OrderID)
        {
            DataRow newRow;
            try
            {

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                _tbSourceOrderDetail = CreateOrderProductShortTableStruct();
                // Tổng tiền
                var order = (from o in _dbContext.listorders.ToList() where o.OrderID == OrderID select o).FirstOrDefault();
                float TotalMobey = 0;
                if (order != null)
                {
                    TotalMobey = (float)order.Total_Money;
                }

                textEdit_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(TotalMobey));// Tổng tiền về 0 khi mới thanh toán

                // Thêm thông tin chi tiết
                var order_details = (from p in _dbContext.order_detail.ToList()
                                     where p.OrderID == OrderID
                                     group p by p.ProductID into gr
                                     select new
                                     {
                                         pKey = gr.Key,
                                         Quantity = gr.Sum(g => g.Quantity)
                                     }).OrderByDescending(o => o.Quantity);// Giảm theo số lượng

                int _isCount = _tbSourceOrderDetail.Rows.Count;
                if (order_details != null)
                {
                    foreach (var item in order_details)
                    {
                        var rowData = (from p in _dbContext.products.ToList()
                                       where p.ProductID == item.pKey
                                       select p).FirstOrDefault();

                        _isCount++;
                        newRow = _tbSourceOrderDetail.NewRow();
                        newRow[_cID] = _isCount;
                        newRow[_cOrderID] = OrderID;
                        newRow[_cProductID] = rowData.ProductID;
                        newRow[_cProductName] = rowData.ProductName;
                        newRow[_cQuantity] = item.Quantity;

                        _tbSourceOrderDetail.Rows.Add(newRow);
                    }

                    gridControl_Order.DataSource = _tbSourceOrderDetail;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadOrderAndProduct");
            }
        }


        /// <summary>
        /// Load danh sách nhân viên
        /// </summary>
        private void LoadEmployees()
        {
            DataRow row;
            List<employee> employees;
            DataTable _tbSource;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                _tbSource = new DataTable();
                _tbSource.Columns.Add(_cEmployeeID);
                _tbSource.Columns.Add(_cEmployeeName);

                employees = (from em in _dbContext.employees.ToList() where em.EmployeeRight != CoffeeHelpers.EmpRight.Administrator.ToString() select em).ToList();
                if (employees != null && employees.Count > 0)
                {
                    foreach (employee emp in employees)
                    {
                        row = _tbSource.NewRow();
                        row[_cEmployeeID] = emp.EmployeeID;
                        row[_cEmployeeName] = emp.EmployeeName;

                        _tbSource.Rows.Add(row);
                    }

                    row = _tbSource.NewRow();
                    row[_cEmployeeID] = -1;
                    row[_cEmployeeName] = "Chọn nhân viên...";
                    _tbSource.Rows.InsertAt(row, 0);

                    sLookUpEdit_UpdateEmployee.Properties.DisplayMember = _cEmployeeName;
                    sLookUpEdit_UpdateEmployee.Properties.ValueMember = _cEmployeeID;
                    sLookUpEdit_UpdateEmployee.Properties.DataSource = _tbSource;
                    sLookUpEdit_UpdateEmployee.EditValue = -1;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadEmployees");
            }
        }

        //Danh sách sản phẩm trên Main
        /// <summary>
        /// Tạo cây sản phẩm
        /// </summary>
        private void Load_CrateProduct()
        {
            List<menu> listMenu;
            List<product> products;
            //List<TreeNode> treeNode;
            TreeNode parentNodes, childNode;
            DataRow newRow;
            try
            {

                if (treeView_ProductTable.Nodes.Count > 0)
                {
                    treeView_ProductTable.Nodes.Clear();
                }

                tbProduct = CreateTableProductStruct();
                tbMenu = CreateTableMenuStruct();

                treeNode = null;
                treeNode = new List<TreeNode>();

                treeView_ProductTable.ImageList = this.imageList_Product;

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                listMenu = (from me in _dbContext.menus.ToList() where me.Status == 1 select me).ToList();
                if (listMenu != null && listMenu.Count > 0)
                {
                    foreach (menu item in listMenu)
                    {
                        parentNodes = treeView_ProductTable.Nodes.Add(item.MenuID.ToString(), item.MenuCode, item.ImageIndex, item.ImageIndex);
                        parentNodes.Tag = item.MenuID.ToString();
                        treeNode.Add(parentNodes);

                        //Lưu lại tableSource
                        newRow = tbMenu.NewRow();
                        newRow[_cMenuID] = item.MenuID;
                        newRow[_cMenuCode] = item.MenuCode;
                        newRow[_cStatus] = item.Status;
                        newRow[_cImageIndex] = item.ImageIndex;
                        newRow[_cImage] = imageList_Product.Images[item.ImageIndex];
                        tbMenu.Rows.Add(newRow);
                    }

                }

                products = (from p in _dbContext.products.ToList() where p.Status == 1 select p).ToList();// Chỉ load những sản phẩm còn hàng

                if (products != null && products.Count > 0)
                {
                    foreach (product item in products)
                    {
                        for (int i = 0; i < treeNode.Count; i++)
                        {
                            if (treeNode[i].Tag.ToString() == item.ProductSkin.ToString())
                            {
                                childNode = treeNode[i].Nodes.Add(item.ProductID.ToString(), item.ProductName.ToString(), item.ImageIndex, item.ImageIndex);
                                childNode.Tag = _childNode;
                                break;
                            }
                        }

                        //Lưu lại tableSource
                        newRow = tbProduct.NewRow();
                        newRow[_cProductID] = item.ProductID;
                        newRow[_cProductName] = item.ProductName;
                        newRow[_cProductCode] = item.ProductCode;
                        newRow[_cProductSkin] = item.ProductSkin;
                        newRow[_cPrice] = item.Price;
                        newRow[_cStatus] = item.Status;
                        newRow[_cMadeInID] = item.MadeInID;
                        newRow[_cMadeInName] = item.madein.MadeInName;
                        newRow[_cNotes] = item.Notes;
                        newRow[_cImageIndex] = item.ImageIndex;
                        newRow[_cImage] = imageList_Product.Images[item.ImageIndex];

                        tbProduct.Rows.Add(newRow);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadProductTable");
            }
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho gridView
        /// </summary>
        private DataTable CreateTableProductStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cShortName);
                tbSource.Columns.Add(_cProductCode);
                tbSource.Columns.Add(_cProductSkin);
                tbSource.Columns.Add(_cPrice);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cNotes);
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
        /// Tạo cấu trúc mặc định cho gridView
        /// </summary>
        private DataTable CreateTableMenuStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cMenuID);
                tbSource.Columns.Add(_cMenuCode);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cImageIndex);
                tbSource.Columns.Add(_cImage, typeof(Image));
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cMenuID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho OrderDetail thu gọn Main
        /// </summary>
        private DataTable CreateOrderProductShortTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cID);
                tbSource.Columns.Add(_cOrderID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cQuantity);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateOrderProductShortTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho OrderDetail Main
        /// </summary>
        private DataTable CreateOrderDetailMainableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cID);
                tbSource.Columns.Add(_cOrderID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cQuantity);
                tbSource.Columns.Add(_cDate, typeof(DateTime));
                tbSource.Columns.Add(_cPrice);
                tbSource.Columns.Add(_cPromote);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateOrderDetailMainableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho Area
        /// </summary>
        private DataTable CreateAreaTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cAreaID);
                tbSource.Columns.Add(_cAreaCode);
                tbSource.Columns.Add(_cStatus);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cAreaID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateAreaTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho 
        /// </summary>
        private DataTable CreateOrderTableStruct()
        {
            DataTable tbSource = null;

            try
            {

                tbSource = new DataTable();
                tbSource.Columns.Add(_cOrderID);
                tbSource.Columns.Add(_cTableID);
                tbSource.Columns.Add(_cTableCode);
                tbSource.Columns.Add(_cAreaID);
                tbSource.Columns.Add(_cOrderCode);
                tbSource.Columns.Add(_cEmployeeID);
                tbSource.Columns.Add(_cDate);
                tbSource.Columns.Add(_cTotal_Money);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cOrderID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateOrderTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho Table
        /// </summary>
        private DataTable CreateArea_TableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cTableID);
                tbSource.Columns.Add(_cTableCode);
                tbSource.Columns.Add(_cAreaID);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cImageIndex);

                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cTableID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateArea_TableStruct");
                return tbSource;
            }
            return tbSource;
        }

        // Ghi log
        private void WriteLog(string action)
        {
            log lg;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                lg = new log();
                lg.employeename = CoffeeHelpers.EmpLogin.EmployeeName;
                lg.actiondate = DateTime.Now;
                lg.actions = action;

                _dbContext.logs.Add(lg);
                _dbContext.SaveChanges();
            }
            catch
            {
            }
        }
        #endregion

        #region Actions
        private void barButton_AreaTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
 
        private void pictureEdit_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {    
                if (e.Button == MouseButtons.Left)
                {
                    barButtonItem_Update.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                
                popupMenu_OrderTable.ShowPopup(Control.MousePosition);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "pictureEdit_MouseUp");
            }
        }

        //Check chọn khu vực
        private void RadioChecked_Change(object sender, EventArgs e)
        {   
            try
            {
                RadioButton rb = sender as RadioButton;
                if (rb != null)
                {
                    treeView_TableEmpty.Nodes.Clear();
                    int AreaID = Convert.ToInt32(rb.Name.Trim().Substring(4));
                    areaIDChecked = AreaID;

                    // Load danh sách bàn trống
                    LoadListTableEmpty(AreaID);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "RadioChecked_Change");
            }
        }

        // Thao tác click chọn đơn hàng
        /// <summary>
        /// Thao tác click chọn đơn hàng
        /// </summary>
        /// <param name="OrderID"></param>
        private void SelectOrder_Click(int OrderID)
        {
            try
            {
                Order_Pre.Image = Coffee.Properties.Resources.Coffee_break_icon;
                PictureEdit focus = new PictureEdit();
                string tableName = "";
                for (int i = 0; i < Picture_ListTable.Count; i++)
                {
                    if (Picture_ListTable[i].Name == "Image" + OrderID)
                    {
                        focus = Picture_ListTable[i];
                        tableName = Picture_ListTable[i].Tag.ToString();
                        break;
                    }
                }
                Order_Pre = focus;
                focus.Image = Coffee.Properties.Resources.coffeecup_red;
                groupControl_OrderDetail.Text = "Nội dung thực đơn " + tableName.ToLower();
                orderIDSelected = OrderID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SelectOrder_Click");
            }
        }

        private void gridView_OrderDetail_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow focusRow;
            try
            {
                focusRow = gridView_Order.GetFocusedDataRow();
                int OrderID= Convert.ToInt32(focusRow["OrderID"]);
                int ProductID= Convert.ToInt32(focusRow["ProductID"]);
            }
            catch (Exception ex)
            {
                 XtraMessageBox.Show(ex.Message, "gridView_OrderDetail_RowClick");
            }
        }

        private void btn_EndPlanDay_ItemClick(object sender, ItemClickEventArgs e)
        {
             frm_PlanDay dlg;
             try
             {
                 _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                 dlg = new frm_PlanDay();
                 if (dlg.ShowDialog() == DialogResult.OK)
                 {
                     //Bỏ kích hoạt chức năng thanh toán
                     btn_Finish.Enabled = false;
                 }
             }
             catch (Exception ex)
             {
                 XtraMessageBox.Show(ex.Message, "btn_EndPlanDay_ItemClick");
             }
        }  

        private void btn_InputOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_InputOrder_ItemClick");
            }
        }

        private void btn_Default_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Default_ItemClick");
            }
        }

        private void frm_InputOrder_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (areaIDChecked != -1)
                {
                    //Load danh sách bàn đang bán
                    LoadOrderTable_FromTableSource(areaIDChecked);
                }
                if (orderIDSelected != -1)
                {
                    //Thao tác click chọn đơn hàng
                    SelectOrder_Click(orderIDSelected);

                    //Thông tin chi tiết đơn hàng
                    LoadOrderAndProduct(orderIDSelected);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_InputOrder_SizeChanged");
            }
        }

        private void panelControl_TableActive_SizeChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (areaIDChecked != -1)
                {
                    //Load danh sách bàn đang bán
                    LoadOrderTable_FromTableSource(areaIDChecked);
                }

                if (orderIDSelected != -1)
                {
                    //Thao tác click chọn đơn hàng
                    SelectOrder_Click(orderIDSelected);

                    //Thông tin chi tiết đơn hàng
                    LoadOrderAndProduct(orderIDSelected);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "panelControl_TableActive_SizeChanged");
            }
        }

        private void treeView_TableEmpty_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectNode;
            int tableID, orderID;
            string tableCode, OrderCode;
            listorder order;
            DataRow newRow;
            frm_AddEditInputOrder dlg;

            try
            {
                selectNode = e.Node;

                order = new listorder();

                if (selectNode == null)
                    return;

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                DateTime dtNow = DateTime.Now;
                dtNow = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);

                dlg = new frm_AddEditInputOrder();
                dlg._Date = dtNow;

                dlg.P_ListOrder = order;
                dlg.Text = "Tạo Hoá Đơn " + e.Node.Text;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tableID = Convert.ToInt32(selectNode.Name);
                    tableCode = selectNode.Text;

                    orderID = maxOrderID;

                    OrderCode = "DH-" + orderID + "_0" + tableID + "_0" + areaIDChecked;

                    order.TableID = tableID;
                    order.Ordercode = OrderCode;
                    order.StartDate = dlg.P_ListOrder.StartDate;
                    order.EndDate = dlg.P_ListOrder.StartDate;
                    order.Notes = null;
                    order.EmployeeID = dlg.P_ListOrder.EmployeeID;
                    order.Total_Money = dlg.P_ListOrder.Total_Money;
                    order.Status = 2;//Đã thanh toán
                    order.EmployeeTransfer = dlg.P_ListOrder.EmployeeID;

                    //Tạo đơn hàng
                    _dbContext.listorders.Add(order);
                    _dbContext.SaveChanges();

                    treeView_TableEmpty.Nodes.Remove(selectNode);//Xoá bàn trống

                    //Chọn mã đơn hàng cho đơn hàng vừa khởi tạo
                    orderIDSelected = CoffeeHelpers.GetOrderMaxCode();

                    //Hiện tổng tiền
                    textEdit_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(dlg.P_ListOrder.Total_Money)) != "" ? string.Format("{0:#,#}", Convert.ToDecimal(dlg.P_ListOrder.Total_Money)) : string.Format("{0:#,#}", Convert.ToString(dlg.P_ListOrder.Total_Money));// Tổng tiền về 0 khi mới thanh toán

                    newRow = _tbSourceListOrder.NewRow();//Thêm vào source bàn dang bán
                    newRow[_cOrderID] = orderIDSelected;
                    newRow[_cTableID] = tableID;
                    newRow[_cTableCode] = tableCode;
                    newRow[_cOrderCode] = OrderCode;
                    newRow[_cEmployeeID] = dlg.P_ListOrder.EmployeeID;
                    newRow[_cAreaID] = areaIDChecked;
                    newRow[_cDate] = dlg.P_ListOrder.StartDate;
                    newRow[_cTotal_Money] = dlg.P_ListOrder.Total_Money;
                    _tbSourceListOrder.Rows.Add(newRow);

                    //Thêm bàn đang bán
                    LoadOrderTable_FromTableSource(areaIDChecked);//Cập nhật giao diện bàn dang bán từ source

                    //Click chọn đơn hàng
                    SelectOrder_Click(orderIDSelected);

                    //Thông tin chi tiết đơn hàng
                    LoadOrderAndProduct(orderIDSelected);

                    //Lưu lại mã đơn hàng lớn nhất
                    maxOrderID = CoffeeHelpers.GetOrderMaxCode() + 1;

                    //Không chuyển khu vực
                    xtraScrollable_Area.Enabled = false;

                   //Ghi long
                    WriteLog("Nhập đơn hàng "+OrderCode +" của ngày "+dlg.P_ListOrder.StartDate);

                    log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + "(" + CoffeeHelpers.EmpLogin.EmployeeID + ") đã nhập đơn hàng "+OrderCode +" của ngày "+dlg.P_ListOrder.StartDate);
  
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_CreateTable_ItemClick");
            }

        }



        private void treeView_ProductTable_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectNodeProduct;
            order_detail orderDetail;
            frm_ChooseProductForOrder dlg;
            DateTime dt = DateTime.Now;
            DataRow newRow;

            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;// Nếu click chuột phải thì không làm gì(chỉ hiện popup)
                }
                if (orderIDSelected != -1)
                {
                    selectNodeProduct = e.Node;

                    if (selectNodeProduct == null || selectNodeProduct.Tag.ToString() != _childNode)
                    {
                        return;
                    }

                    orderDetail = new order_detail();
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                    dlg = new frm_ChooseProductForOrder();

                    dlg.P_OrderDetail = orderDetail;
                    dlg._checkAddOrDecrease = 1;
                    dlg._dbContext = _dbContext;
                    dlg.Text = "Thêm " + e.Node.Text;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        DateTime _date= new DateTime();
                        foreach (DataRow row in _tbSourceListOrder.Rows)
                        {
                            if (Convert.ToInt32(row[_cOrderID]) == orderIDSelected)
                            {
                                _date = Convert.ToDateTime(row[_cDate]);
                                break;
                            }
                        }

                        dlg.P_OrderDetail.OrderID = orderIDSelected;
                        dlg.P_OrderDetail.Promote = "Đã kiểm tra";
                        dlg.P_OrderDetail.Date = _date;
                        dlg.P_OrderDetail.ProductID = Convert.ToInt32(selectNodeProduct.Name);
                        _dbContext.order_detail.Add(dlg.P_OrderDetail);
                        _dbContext.SaveChanges();

                        //--- Select ngay sản phẩm đang thêm
                        bool exist = false;
                        for (int i = 0; i < gridView_Order.RowCount; i++)
                        {
                            if (gridView_Order.GetRowCellValue(i, _cProductID).ToString().Contains(selectNodeProduct.Name) == true)
                            {
                                gridView_Order.FocusedRowHandle = i;
                                exist = true;
                                break;
                            }
                        }
                        if (exist == true)//Nếu sản phẩm này đã có
                        {
                            newRow = gridView_Order.GetFocusedDataRow();
                            newRow[_cQuantity] = Convert.ToInt32(newRow[_cQuantity]) + dlg.P_OrderDetail.Quantity;

                            gridView_Order.LayoutChanged();

                        }
                        else
                        {
                            newRow = _tbSourceOrderDetail.NewRow();
                            newRow[_cID] = dlg.P_OrderDetail.ID;
                            newRow[_cOrderID] = dlg.P_OrderDetail.OrderID;
                            newRow[_cProductID] = dlg.P_OrderDetail.ProductID;
                            newRow[_cProductName] = e.Node.Text;
                            newRow[_cQuantity] = dlg.P_OrderDetail.Quantity;

                            _tbSourceOrderDetail.Rows.Add(newRow);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_ProductTable_NodeMouseClick");
            }
        }

        private void barButtonItem_Update_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                panelControl_UpdateOrder.Visible = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Update_ItemClick");
            }
        }

        //Huỷ đơn hàng
        private void barButtonItem_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            listorder orders;
            area_table tables;
            List<order_detail> orderDetail;
            try
            {
                if (XtraMessageBox.Show("Tất cả thực đơn của bàn này sẽ bị hủy. Bạn có chắc muốn xóa bàn này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                orders = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();
                if (orders != null)
                {
                    //Cập nhật bàn này về trống
                    tables = (from t in _dbContext.area_table.ToList() where t.TableID == orders.TableID select t).FirstOrDefault();
                    if (tables != null)
                    {
                        tables.Empty = 1;
                        _dbContext.SaveChanges();

                        //Add lại danh sách bàn trống
                        treeView_TableEmpty.Nodes.Add(orders.TableID.ToString(), orders.area_table.TableCode, orders.area_table.ImageIndex, orders.area_table.ImageIndex);

                        //Xóa chi tiết đơn hàng
                        orderDetail = (from od in _dbContext.order_detail.ToList() where od.OrderID == orderIDSelected select od).ToList();
                        if (orderDetail != null && orderDetail.Count > 0)
                        {
                            foreach (order_detail o in orderDetail)
                            {
                                _dbContext.order_detail.Remove(o);
                                _dbContext.SaveChanges();
                            }
                        }


                        //Load lại danh sách bàn đang bán
                        int i = 0;
                        foreach (DataRow r in _tbSourceListOrder.Rows)
                        {
                            if (Convert.ToInt32(r[_cOrderID]) == orders.OrderID)
                            {
                                _tbSourceListOrder.Rows.Remove((r));
                                break;
                            }
                            i++;
                        }

                        //Xóa đơn hàng
                        _dbContext.listorders.Remove(orders);
                        _dbContext.SaveChanges();

                        LoadOrderTable_FromTableSource(areaIDChecked);

                        panelControl_UpdateOrder.Visible = false;

                        if (xtraScrollable_TableActive.Controls.Count <= 0)
                        {
                            xtraScrollable_Area.Enabled = true;
                            textEdit_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal("0"));// Tổng tiền về 0 khi mới thanh toán
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Delete_ItemClick");
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            try
            {
                panelControl_UpdateOrder.Visible = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Delete_ItemClick");
            }
        }

        private void btn_DeleteOrderDetail_Click(object sender, EventArgs e)
        {
            order_detail deleteRow;
            DataRow focusRow;
            try
            {
                if (gridView_Order.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn món", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa món này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }

                focusRow = gridView_Order.GetFocusedDataRow();
                deleteRow = (from o in _dbContext.order_detail.ToList() where o.OrderID == Convert.ToInt32(focusRow[_cOrderID]) && o.ProductID == Convert.ToInt32(focusRow[_cProductID]) select o).FirstOrDefault();

                if (deleteRow != null)
                {
                    _dbContext.order_detail.Remove(deleteRow);
                    _dbContext.SaveChanges();
                    gridView_Order.DeleteRow(gridView_Order.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_DeleteOrderDetail_Click");
            }
        }

        private void gridView_Order_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo hi;
            DataRow focusRow;

            try
            {
                hi = gridView_Order.CalcHitInfo(e.Location);

                barButtonItem_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_Down.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (gridView_Order.SelectedRowsCount > 0)
                {
                    focusRow = gridView_Order.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            barButtonItem_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barButtonItem_Down.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                    }
                }
                popupMenu_OrderDetail.ShowPopup(Control.MousePosition);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Order_MouseUp");
            }
        }

        private void barButtonItem_Add_ItemClick(object sender, ItemClickEventArgs e)
        {
             order_detail orderDetail;
            frm_ChooseProductForOrder dlg;
            DataRow focusRow;
            DateTime dt = DateTime.Now;

            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_Order.GetFocusedDataRow();

                dlg = new frm_ChooseProductForOrder();
                orderDetail = new order_detail();

                dlg.P_OrderDetail = orderDetail;
                dlg._checkAddOrDecrease = 1;
                dlg._dbContext = _dbContext;
                dlg.Text = "Thêm Món " + focusRow[_cProductName];
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    DateTime _date = new DateTime();
                    foreach (DataRow row in _tbSourceListOrder.Rows)
                    {
                        if (Convert.ToInt32(row[_cOrderID]) == Convert.ToInt32(focusRow[_cOrderID]))
                        {
                            _date = Convert.ToDateTime(row[_cDate]);
                            break;
                        }
                    }

                    dlg.P_OrderDetail.OrderID = orderIDSelected;
                    dlg.P_OrderDetail.Promote = "Đã kiểm tra";
                    dlg.P_OrderDetail.Date = _date;
                    dlg.P_OrderDetail.OrderID = Convert.ToInt32(focusRow[_cOrderID]);
                    dlg.P_OrderDetail.ProductID = Convert.ToInt32(focusRow[_cProductID]);
                    _dbContext.order_detail.Add(dlg.P_OrderDetail);
                    _dbContext.SaveChanges();

                    focusRow[_cQuantity] = Convert.ToInt32(focusRow[_cQuantity]) + dlg.P_OrderDetail.Quantity;
                    gridView_Order.LayoutChanged();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Add_ItemClick");
            }
        }

        private void barButtonItem_Down_ItemClick(object sender, ItemClickEventArgs e)
        {
            order_detail orderDetail;
            listorder order;
            frm_ChooseProductForOrder dlg;
            DataRow focusRow;
            decimal TotalMoney = 0;
            DateTime dt = DateTime.Now;
            int _Quantity = 0;

            try
            {

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_Order.GetFocusedDataRow();

                dlg = new frm_ChooseProductForOrder();
                orderDetail = new order_detail();

                orderDetail.OrderID = Convert.ToInt32(focusRow[_cOrderID]);
                orderDetail.ProductID = Convert.ToInt32(focusRow[_cProductID]);
                orderDetail.Quantity = Convert.ToInt32(focusRow[_cQuantity]);

                dlg.P_OrderDetail = orderDetail;
                dlg._checkAddOrDecrease = 2;
                dlg._dbContext = _dbContext;
                dlg.Text = "Giảm Món " + focusRow[_cProductName];
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    //Lấy tổng tiền hiện tại của đơn hàng
                    order = (from o in _dbContext.listorders.ToList() where o.OrderID == Convert.ToInt32(focusRow[_cOrderID]) select o).FirstOrDefault();
                    if (order != null)
                    {
                        TotalMoney = (decimal)order.Total_Money;
                    }

                    //Cập nhật chi tiết đơn hàng
                    //_dbContext.ExecuteCommand("Update Order_Detail Set Quantity={0} Where OrderID={1} And ProductID={2}", dlg.P_OrderDetail.Quantity, orderIDSelected, Convert.ToInt32(focusRow[_cProductID]));
                    for (int i = dlg.P_OrderDetail.Quantity; i >= 0; i--)
                    {
                        orderDetail = (from o in _dbContext.order_detail.ToList() where o.OrderID == Convert.ToInt32(focusRow[_cOrderID]) && o.ProductID == Convert.ToInt32(focusRow[_cProductID]) select o).FirstOrDefault();
                        dt = orderDetail.Date;//Lưu ngày khuyến mãi
                        if (orderDetail != null)
                        {
                            if (orderDetail.Quantity < i)//Số lượng của row nhỏ hơn số lượng muốn giảm thì xóa ngay 
                            {
                                _Quantity = orderDetail.Quantity;
                                focusRow[_cQuantity] = Convert.ToInt32(focusRow[_cQuantity]) - orderDetail.Quantity;
                                _dbContext.order_detail.Remove(orderDetail);
                                _dbContext.SaveChanges();

                            }
                            else if (orderDetail.Quantity == i)
                            {
                                _Quantity = orderDetail.Quantity;
                                focusRow[_cQuantity] = Convert.ToInt32(focusRow[_cQuantity]) - orderDetail.Quantity;
                                _dbContext.order_detail.Remove(orderDetail);
                                _dbContext.SaveChanges();
                                i = 0;//Thoát. Xóa xong
                            }
                            else if (orderDetail.Quantity > i)
                            {
                                _Quantity = i;
                                focusRow[_cQuantity] = Convert.ToInt32(focusRow[_cQuantity]) - i;
                                orderDetail.Quantity = Convert.ToInt32(focusRow[_cQuantity]);
                                _dbContext.SaveChanges();
                                i = 0;//Thoát. Xóa xong
                            }  
                            gridView_Order.LayoutChanged();
                        }
                        else
                        {
                            i = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Down_ItemClick");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                if (xtraScrollable_TableActive.Controls.Count > 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn ''Đã xong'' trước khi thoát", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Close_Click");
            }
        }

        private void btn_Finish_Click(object sender, EventArgs e)
        {
            
            try
            {
                //Xóa bàn nếu có
                if (xtraScrollable_TableActive.Controls.Count > 0)
                {

                    dlg_wait = new DevExpress.Utils.WaitDialogForm("Đang hoàn tất các hoá đơn", "Vui lòng chờ...", new Size(177, 50));
                    _timerCloseApp = new System.Threading.Timer(TimerCloseAppCallback, null, 1000, System.Threading.Timeout.Infinite);

                    for (int i = 0; i < xtraScrollable_TableActive.Controls.Count; i++)
                    {
                        if (_tbSourceListOrder.Rows.Count > 0)
                        {
                            int count = 0;
                            foreach (DataRow row in _tbSourceListOrder.Rows)
                            {
                                if (Convert.ToInt32(xtraScrollable_TableActive.Controls[i].Tag) == Convert.ToInt32(row[_cOrderID]))
                                {
                                    _tbSourceListOrder.Rows.RemoveAt(count);
                                    break;
                                }
                                count++;
                            }
                        }
                        xtraScrollable_TableActive.Controls.RemoveByKey(xtraScrollable_TableActive.Controls[i].Name);
                        i--;
                    }
                    panelControl_UpdateOrder.Visible = false;
                    xtraScrollable_Area.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Finish_Click");
            }
        }

        //Update đơn hàng nhập vào
        private void button_Save_Click(object sender, EventArgs e)
        {
            listorder orders;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                orders = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();
                orders.StartDate =dateEdit_Date.DateTime;
                orders.EndDate = dateEdit_Date.DateTime;
                orders.EmployeeID =Convert.ToInt32(sLookUpEdit_UpdateEmployee.EditValue);
                orders.Total_Money = Convert.ToDecimal(textEdit_UpdateTotalMoney.EditValue);

                _dbContext.SaveChanges();

                //Update cho tbSource
                foreach (DataRow row in _tbSourceListOrder.Rows)
                {
                    if (Convert.ToInt32(row[_cOrderID]) == orderIDSelected)
                    {
                        row[_cEmployeeID] = Convert.ToInt32(sLookUpEdit_UpdateEmployee.EditValue);
                        row[_cTotal_Money] = Convert.ToDecimal(textEdit_UpdateTotalMoney.EditValue);
                        row[_cDate] = dateEdit_Date.DateTime;

                        textEdit_TotalMoney.Text = string.Format("{0:C}", Convert.ToDecimal(textEdit_UpdateTotalMoney.EditValue));// Tổng tiền về 0 khi mới thanh toán
                        break;
                    }
                }

                dlg_wait = new DevExpress.Utils.WaitDialogForm("Cập nhật đơn hàng", "Vui lòng chờ...", new Size(167, 50));
                _timerCloseApp = new System.Threading.Timer(TimerCloseAppCallback, null, 500, System.Threading.Timeout.Infinite);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Save_Click");
            }
        }

        private void frm_InputOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (xtraScrollable_TableActive.Controls.Count > 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn ''Đã xong'' trước khi thoát", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_InputOrder_FormClosing");
            }
        }

        #endregion

        private void treeView_TableEmpty_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}