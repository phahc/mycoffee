using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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
namespace Coffee
{
    public partial class frm_ViewOrderDetail : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public order_detail P_OrderDetail { get; set; }

        private const string _cID = "ID";
        private const string _cOrderID = "OrderID";
        private const string _cProductName = "ProductName";
        private const string _cProductID = "ProductID";
        private const string _cQuantity = "Quantity";
        private const string _cDate = "Date";
        private const string _cPrice = "Price";
        private const string _cPromote = "Promote";

        public frm_ViewOrderDetail()
        {
            InitializeComponent();
        }

        private void frm_ViewOrderDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (P_OrderDetail.ProductID != 0)
                {
                    LoadOrderDetail(P_OrderDetail.OrderID, P_OrderDetail.ProductID);
                }
                else
                {
                    //Load tất cả
                    Load_AllOrderDetail(P_OrderDetail.OrderID);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_ViewOrderDetail_Load");
            }
        }


        //Load thông tin chi tiết đơn hàng
        private void LoadOrderDetail(int orderID, int productID)
        {
            DataTable _tbSource;
            DataRow newRow;
            try
            {
                _tbSource = CreateOrderDetailMainableStruct();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                // Thêm thông tin chi tiết
                var order_details = (from p in _dbContext.order_detail.ToList()
                                     where p.OrderID == orderID && p.ProductID == productID
                                     select p).OrderByDescending(a => a.Date);// Giảm theo ngày

                int _isCount = 0;
                if (order_details != null)
                {
                    foreach (var item in order_details)
                    {
                        _isCount++;
                        newRow = _tbSource.NewRow();
                        newRow[_cID] = _isCount;
                        newRow[_cOrderID] = orderID;
                        newRow[_cProductID] = item.ProductID;
                        newRow[_cProductName] = item.product.ProductName;
                        newRow[_cQuantity] = item.Quantity;
                        newRow[_cDate] = item.Date;
                        newRow[_cPrice] = item.Price;
                        newRow[_cPromote] = item.Promote;
                        _tbSource.Rows.Add(newRow);
                    }

                    gridControl_OrderDetail.DataSource = _tbSource;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadOrderDetail");
            }
        }

        //Load thông tin chi tiết đơn hàng
        private void Load_AllOrderDetail(int orderID)
        {
            DataTable _tbSource;
            DataRow newRow;
            try
            {
                _tbSource = CreateOrderDetailMainableStruct();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                // Thêm thông tin chi tiết
                var order_details = (from p in _dbContext.order_detail.ToList()
                                     where p.OrderID == orderID
                                     select p).OrderByDescending(a => a.Date);// Giảm theo ngày

                int _isCount = 0;
                if (order_details != null)
                {
                    foreach (var item in order_details)
                    {
                        _isCount++;
                        newRow = _tbSource.NewRow();
                        newRow[_cID] = _isCount;
                        newRow[_cOrderID] = orderID;
                        newRow[_cProductID] = item.ProductID;
                        newRow[_cProductName] = item.product.ProductName;
                        newRow[_cQuantity] = item.Quantity;
                        newRow[_cDate] = item.Date;
                        newRow[_cPrice] = item.Price;
                        newRow[_cPromote] = item.Promote;
                        _tbSource.Rows.Add(newRow);
                    }

                    gridControl_OrderDetail.DataSource = _tbSource;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Load_AllOrderDetail");
            }
        }

        /// <summary>
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
                tbSource.Columns.Add(_cDate);
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

        private void gridView_OrderDetail_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view;
            DataRow row;
            try
            {
                if (e.RowHandle <= -1)
                    return;
                view = sender as GridView;
                row = view.GetDataRow(e.RowHandle);
                if (row[_cPromote].ToString() == "Khuyến mãi")//Nếu tính theo giá khuyến mãi thì đổi màu
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 0, 102);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_OrderDetail_RowCellStyle");
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
    }
}