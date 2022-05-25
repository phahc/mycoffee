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
    public partial class frm_AddEditOrder : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private const string _waterMask = "--- Vui lòng chọn ---";

        private mycoffeeEntities _dbContext;
        public order_detail P_OrderDetail { get; set; }
        public string _ProductName { get; set; }
        public bool _checkUpdateOrChange { get; set; }
        public DataTable _tbSource { get; set; }
        public int P_Quantity { get; set; }

        int _defaultQuantity = 0;//Số lượng đổi tối đa cho phép
        //Lưu danh sách muốn đổi
        int _countChanged = 1;

        private const string _cPrice = "Price";
        private const string _cProductID = "ProductID";
        private const string _cProductName = "ProductName";
        private const string _cProductCode = "ProductCode";
        private const string _cShortName = "ShortName";
        private const string _cNotes = "Notes";
        private const string _cStatus = "Status";
        private const string _cMadeInID = "MadeInID";
        private const string _cQuantity = "Quantity";
        private const string _cID = "ID";
        private const string _cOrderID = "OrderID";
        #endregion

        #region Form Method
        public frm_AddEditOrder()
        {
            InitializeComponent();
        }

        private void frm_AddEditOrder_Load(object sender, EventArgs e)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                lbl_Quantity.Text = P_OrderDetail.Quantity.ToString();

                _defaultQuantity = P_OrderDetail.Quantity;

                _tbSource = CreateOrderProductShortTableStruct();

                //Load danh sách sản phẩm
                LoadProduct();

                button_Save.Enabled = false;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditOrder_Load");
            }
        }
        #endregion

        #region Helpers
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
                product = (from p in _dbContext.products.ToList() where p.Status == 1 && p.ProductID != P_OrderDetail.ProductID select p).ToList();

                tbSource = new DataTable();
                tbSource.Columns.Add(_cProductID, typeof(int));
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cProductCode);
                tbSource.Columns.Add(_cShortName);
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
        /// Tạo cấu trúc mặc định cho OrderDetail thu gọn Main
        /// </summary>
        private DataTable CreateOrderProductShortTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cID);
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
        #endregion

        #region Actions
        private void button_Save_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                //P_OrderDetail.Quantity = Convert.ToInt32(spinEdit_QuantityChange.EditValue);

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

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            DataRow newRow, updateRow;
            try
            {
                int _finalP_Quantity = Convert.ToInt32(spinEdit_QuantityChange.EditValue) > Convert.ToInt32(lbl_Quantity.Text) ? Convert.ToInt32(lbl_Quantity.Text) : Convert.ToInt32(spinEdit_QuantityChange.EditValue);
                P_Quantity = P_Quantity + _finalP_Quantity;//Lấy tối đa chỉ bằng số lượng hiện có

                if (Convert.ToInt32(slookUpEdit_Product.EditValue) == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn sản phẩm muốn đổi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_tbSource != null)
                {
                    updateRow = gridView_OrderDetail.GetFocusedDataRow();
                    for (int i = 0; i < _tbSource.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(_tbSource.Rows[i][_cProductID]) == Convert.ToInt32(slookUpEdit_Product.EditValue))
                        {
                            gridView_OrderDetail.FocusedRowHandle = i;

                            int _quantityRemaining = Convert.ToInt32(lbl_Quantity.Text);
                            int _inputQuantity = Convert.ToInt32(spinEdit_QuantityChange.EditValue) > _quantityRemaining ? _quantityRemaining : Convert.ToInt32(spinEdit_QuantityChange.EditValue);
                            //int _quantityChange= Convert.ToInt32(updateRow[_cQuantity]) +_inputQuantity;

                            updateRow[_cQuantity] = Convert.ToInt32(updateRow[_cQuantity]) + _inputQuantity;

                            gridView_OrderDetail.LayoutChanged();

                            // Số lượng cần đổi còn lại
                            int _finalQuantity = Convert.ToInt32(lbl_Quantity.Text) - Convert.ToInt32(spinEdit_QuantityChange.EditValue);
                            lbl_Quantity.Text = _finalQuantity < 0 ? "0" : _finalQuantity.ToString();

                            spinEdit_QuantityChange.EditValue = 1;

                            if (Convert.ToInt32(lbl_Quantity.Text) <= 0)
                            {
                                btn_Ok.Enabled = false;
                            }
                            return;
                        }
                    }

                }
                if (Convert.ToInt32(spinEdit_QuantityChange.EditValue) > Convert.ToInt32(lbl_Quantity.Text))
                {
                    XtraMessageBox.Show("Số lượng đổi vượt số lượng tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                newRow = _tbSource.NewRow();
                newRow[_cID] = _countChanged;
                newRow[_cProductID] = Convert.ToInt32(slookUpEdit_Product.EditValue);
                newRow[_cProductName] = slookUpEdit_Product.Text;
                newRow[_cQuantity] = Convert.ToInt32(spinEdit_QuantityChange.EditValue);
                _tbSource.Rows.Add(newRow);

                gridControl_OrderDetail.DataSource = _tbSource;

                // Số lượng cần đổi còn lại
                lbl_Quantity.Text = (Convert.ToInt32(lbl_Quantity.Text) - Convert.ToInt32(spinEdit_QuantityChange.EditValue)).ToString();

                spinEdit_QuantityChange.EditValue = 1;

                //Nếu có danh sách muốn đổi mới được sử dụng đươc chức năng lưu
                if (gridView_OrderDetail.RowCount > 0)
                {
                    button_Save.Enabled = true;
                }

                if (Convert.ToInt32(lbl_Quantity.Text) <= 0)
                {
                    btn_Ok.Enabled = false;
                }
                _countChanged++;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Ok_Click");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            DataRow updateRow;
            try
            {
                updateRow = gridView_OrderDetail.GetFocusedDataRow();
                if (updateRow != null)
                {
                    int _subQuantity = Convert.ToInt32(updateRow[_cQuantity]) - Convert.ToInt32(spinEdit_QuantityChange.EditValue);
                    _subQuantity = _subQuantity > 0 ? _subQuantity : 0;

                    lbl_Quantity.Text = (Convert.ToInt32(lbl_Quantity.Text) + _subQuantity).ToString();

                    updateRow[_cQuantity] = Convert.ToInt32(spinEdit_QuantityChange.EditValue);

                    gridView_OrderDetail.LayoutChanged();

                    for (int i = 0; i < _tbSource.Rows.Count; i++)
                    {
                        if (_tbSource.Rows[i][_cProductID] == updateRow[_cProductID])
                        {
                            _tbSource.Rows[i][_cQuantity] = Convert.ToInt32(spinEdit_QuantityChange.EditValue);
                            break;
                        }
                    }
                }

                if (Convert.ToInt32(lbl_Quantity.Text) > 0)
                {
                    btn_Ok.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Update_Click");
            }
        }

        private void gridView_OrderDetail_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow updateRow;
            try
            {
                updateRow = gridView_OrderDetail.GetFocusedDataRow();
                if (updateRow != null)
                {
                    slookUpEdit_Product.EditValue = Convert.ToInt32(updateRow[_cProductID]);
                    spinEdit_QuantityChange.EditValue = Convert.ToInt32(updateRow[_cQuantity]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_OrderDetail_RowClick");
            }
        }

        private void slookUpEdit_Product_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                spinEdit_QuantityChange.EditValue = 1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "slookUpEdit_Product_EditValueChanged");
            }
        }
        #endregion

        // Di chuyển form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelControl2_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "panelControl2_MouseDown");
            }
        }
    }
}