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
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_AddEditProductPromote : DevExpress.XtraEditors.XtraForm
    {
        private const string _waterMask = "--- Vui lòng chọn ---";

        public mycoffeeEntities _dbContext;
        public promote P_Promote { get; set; }
        public promote_detail P_Promote_detail { get; set; }
        public CoffeeHelpers.OpenType P_OpenType { get; set; }
        public bool checkUpdateExist { get; set; }
        
        private const string _cPromoteID = "PromoteID";
        private const string _cPromoteName = "PromoteName";
        private const string _cStartDate = "StartDate";
        private const string _cEndDate = "EndDate";

       
        private const string _cPrice = "Price";
        private const string _cProductID = "ProductID";
        private const string _cProductName = "ProductName";
        private const string _cProductCode = "ProductCode";
        private const string _cShortName = "ShortName";
        private const string _cNotes = "Notes";
        private const string _cStatus = "Status";
        private const string _cMadeInID = "MadeInID";

        DateTime dtNow;

        public frm_AddEditProductPromote()
        {
            InitializeComponent();
        }

        private void frm_AddEditProductPromote_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProduct();

                if (P_OpenType == CoffeeHelpers.OpenType.AddEdit)
                {
                    textEdit_PromoteName.Properties.ReadOnly = true;
                    slookUpEdit_Product.Properties.ReadOnly = false;
                    textEdit_PricePromote.Properties.ReadOnly = false;
                    textEdit_PromoteName.Text = P_Promote.PromoteName;

                    if (P_Promote_detail.ID != 0)
                    {
                        slookUpEdit_Product.Properties.ReadOnly = true;
                        slookUpEdit_Product.EditValue = P_Promote_detail.ProductID;

                        var price = (from p in _dbContext.products.ToList() where p.ProductID == P_Promote_detail.ProductID select p.Price).FirstOrDefault();
                        textEdit_Price.EditValue = price;

                        textEdit_PricePromote.EditValue = P_Promote_detail.Price; 
                        dateEdit_StartDate.EditValue = P_Promote_detail.StartDate;
                        dateEdit_EndDate.EditValue = P_Promote_detail.EndDate;
                    }
                    else
                    {
                        slookUpEdit_Product.Properties.ReadOnly = false;
                        dtNow = DateTime.Now;
                        dateEdit_StartDate.DateTime = dtNow;
                        dateEdit_EndDate.DateTime = dtNow;
                        dateEdit_StartDate.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                        dateEdit_EndDate.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
                    }

                }
                else
                {
                    if (P_Promote.PromoteID == 0)
                    {
                        dtNow = DateTime.Now;
                        dateEdit_StartDate.DateTime = dtNow;
                        dateEdit_EndDate.DateTime = dtNow;
                        dateEdit_StartDate.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                        dateEdit_EndDate.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
                    }
                    else
                    {  
                        slookUpEdit_Product.Properties.ReadOnly = true;
                        textEdit_Price.Properties.ReadOnly = true;
                        textEdit_PricePromote.Properties.ReadOnly = true;

                        textEdit_PromoteName.Text = P_Promote.PromoteName;
                        dateEdit_StartDate.EditValue = P_Promote.StartDate;
                        dateEdit_EndDate.EditValue = P_Promote.EndDate;

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditProductPromote_Load");
            }
        }


        /// <summary>
        /// Load danh sách sản phẩm
        /// </summary>
        private void LoadProduct()
        {
            List<product> product;
            DataTable tbSource;
            DataRow newRow;

            try
            {
                textEdit_Price.Properties.ReadOnly = true;
                product = (from p in _dbContext.products.ToList() where p.Status == 1 select p).ToList();

                tbSource = new DataTable();
                tbSource.Columns.Add(_cProductID, typeof(int));
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cProductCode);
                tbSource.Columns.Add(_cPrice);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cNotes);
                tbSource.Columns.Add(_cMadeInID);

                foreach (product p in product)
                {
                    newRow = tbSource.NewRow();

                    newRow[_cProductID] = p.ProductID;
                    newRow[_cProductName] = p.ProductName;
                    newRow[_cProductCode] = p.ProductCode;
                    newRow[_cPrice] = p.Price;
                    newRow[_cStatus] = p.Status;
                    newRow[_cNotes] = p.Notes;
                    newRow[_cMadeInID] = p.MadeInID;

                    tbSource.Rows.Add(newRow);
                }

                newRow = tbSource.NewRow();
                newRow[_cProductID] = -1;
                newRow[_cProductName] = _waterMask;
                tbSource.Rows.InsertAt(newRow, 0);

                slookUpEdit_Product.Properties.DisplayMember = _cProductName;
                slookUpEdit_Product.Properties.ValueMember = _cProductID;
                slookUpEdit_Product.Properties.DataSource = tbSource;
                slookUpEdit_Product.EditValue = -1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadProduct");
            }
        }

        /// <summary>
        /// Kiểm tra tồn tại Sản phẩm
        /// </summary>
        /// <param name="moCode"></param>
        /// <returns> true: Tồn tại, false: Không tồn tại </returns>
        private bool CheckExistPromoteProducts(int promoteID, int productID)
        {
            try
            {
                var ps = (from p in _dbContext.promote_detail.ToList() where p.PromoteID == promoteID && p.ProductID == productID select p).FirstOrDefault();
                if (ps == null)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CheckExistPromoteProducts");
                return false;
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

        private void slookUpEdit_Product_EditValueChanged(object sender, EventArgs e)
        {
            try
            {               
               DataRow row = searchLookUpEdit1View.GetFocusedDataRow();
               if (row != null)
               {
                   textEdit_Price.EditValue = row[_cPrice];
               }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "slookUpEdit_Product_EditValueChanged");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
             bool checkUpate = false;
            try
            {
                if (P_OpenType == CoffeeHelpers.OpenType.None)
                {
                    if (P_Promote.PromoteID != 0)//Update 
                    {
                        checkUpate = true;
                        textEdit_PromoteName.Text = P_Promote.PromoteName;
                        dateEdit_StartDate.EditValue = P_Promote.StartDate;
                        dateEdit_EndDate.EditValue = P_Promote.EndDate;

                    }
                    if (checkUpate == false)
                    {
                        if (slookUpEdit_Product.Text == _waterMask)
                        {
                            XtraMessageBox.Show("Vui lòng chọn sản phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (textEdit_PricePromote.Text == "")
                        {
                            XtraMessageBox.Show("Vui lòng nhập giá khuyến mãi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (dateEdit_StartDate.DateTime > dateEdit_EndDate.DateTime)
                        {
                            XtraMessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (Convert.ToDouble(textEdit_Price.EditValue) < Convert.ToDouble(textEdit_PricePromote.EditValue))
                        {
                            XtraMessageBox.Show("Giá khuyến mãi phải nhỏ hơn giá gốc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        
                        P_Promote_detail.ProductID = Convert.ToInt32(slookUpEdit_Product.EditValue);
                        P_Promote_detail.StartDate = dateEdit_StartDate.DateTime;
                        P_Promote_detail.EndDate = dateEdit_EndDate.DateTime;
                        P_Promote_detail.Price = Convert.ToDecimal(textEdit_PricePromote.Text);
                    }
                    P_Promote.PromoteName = textEdit_PromoteName.Text.Trim();
                    P_Promote.StartDate = dateEdit_StartDate.DateTime;
                    P_Promote.EndDate = dateEdit_EndDate.DateTime;
                }
                else
                {
                   if(checkUpdateExist==false)
                   {                      
                        if (textEdit_PricePromote.Text == "")
                        {
                            XtraMessageBox.Show("Vui lòng nhập giá khuyến mãi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (Convert.ToDouble(textEdit_Price.EditValue) < Convert.ToDouble(textEdit_PricePromote.EditValue))
                        {
                            XtraMessageBox.Show("Giá khuyến mãi phải nhỏ hơn giá gốc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (dateEdit_StartDate.DateTime > dateEdit_EndDate.DateTime)
                        {
                            XtraMessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                       
                        if (P_Promote_detail.ID == 0)//Add
                        {
                            if (slookUpEdit_Product.Text == _waterMask)
                            {
                                XtraMessageBox.Show("Vui lòng chọn sản phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            
                            if (CheckExistPromoteProducts(P_Promote.PromoteID, Convert.ToInt32(slookUpEdit_Product.EditValue)) == true)
                            {
                                var row_mop = (from mop in _dbContext.promote_detail.ToList() where mop.ProductID == Convert.ToInt32(slookUpEdit_Product.EditValue) && mop.PromoteID == P_Promote.PromoteID select mop).FirstOrDefault();
                                if (row_mop.Deleted == 1)
                                {
                                    var Result =XtraMessageBox.Show("Sản phẩm khuyến mãi này đã tồn tại và đã bị xóa. Bạn có muốn khởi động lại sản phẩm này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    if (Result == DialogResult.OK)
                                    {
                                        this.Text = "Sửa Sản Phẩm";
                                        var row = (from mop in _dbContext.promote_detail.ToList() where mop.ProductID == Convert.ToInt32(slookUpEdit_Product.EditValue) && mop.PromoteID == P_Promote.PromoteID select mop).FirstOrDefault();
                                        if (row != null)
                                        {
                                            slookUpEdit_Product.Properties.ReadOnly = true;
                                            textEdit_PromoteName.EditValue = P_Promote.PromoteName;
                                            textEdit_PricePromote.EditValue = row.Price;
                                            dateEdit_StartDate.EditValue = row.StartDate;
                                            dateEdit_EndDate.EditValue = row.EndDate;
                                            P_Promote_detail.PromoteID = row.PromoteID;
                                            checkUpdateExist = true;
                                            return;
                                        }  
                                    }
                                    else
                                    {
                                        //-- Add new
                                        this.Text = "Thêm Sản Phẩm Vào Đơn Hàng";
                                        slookUpEdit_Product.Properties.ReadOnly = false;
                                        checkUpdateExist = false;
                                        return;
                                    }
                                }
                                var confirmResult = XtraMessageBox.Show("Sản phẩm đã tồn tại. Bạn có muốn chỉnh sửa sản phẩm này?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (confirmResult == DialogResult.OK)
                                {
                                    this.Text = "Sửa Sản Phẩm";
                                    var row = (from mop in _dbContext.promote_detail.ToList() where mop.ProductID == Convert.ToInt32(slookUpEdit_Product.EditValue) && mop.PromoteID == P_Promote.PromoteID select mop).FirstOrDefault();
                                    if (row != null)
                                    {
                                        slookUpEdit_Product.Properties.ReadOnly = true;
                                        textEdit_PromoteName.EditValue = P_Promote.PromoteName;
                                        textEdit_PricePromote.EditValue = row.Price;
                                        dateEdit_StartDate.EditValue = row.StartDate;
                                        dateEdit_EndDate.EditValue = row.EndDate;
                                        P_Promote_detail.PromoteID = row.PromoteID;
                                        checkUpdateExist = true;
                                        return;
                                    }
                                }
                                else
                                {
                                    //-- Add new
                                    this.Text = "Thêm Sản Phẩm Vào Đơn Hàng";
                                    slookUpEdit_Product.Properties.ReadOnly = false;
                                    checkUpdateExist = false;
                                    return;
                                }
                            }
                        }

                    }

                    P_Promote_detail.PromoteID = P_Promote.PromoteID;
                    P_Promote_detail.ProductID = Convert.ToInt32(slookUpEdit_Product.EditValue);
                    P_Promote_detail.StartDate = dateEdit_StartDate.DateTime;
                    P_Promote_detail.EndDate = dateEdit_EndDate.DateTime;
                    P_Promote_detail.Price = Convert.ToDecimal(textEdit_PricePromote.Text); 
                }

                DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Save_Click");
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelControl1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "panelControl1_MouseDown");
            }
        }

    }
}