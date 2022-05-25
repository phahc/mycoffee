using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace Coffee
{
    public partial class frm_ChooseProductForOrder : DevExpress.XtraEditors.XtraForm
    {

        public mycoffeeEntities _dbContext;
        public order_detail P_OrderDetail { get; set; }
        public int _checkAddOrDecrease { get; set; }//1: Add; 2: Update     

        public frm_ChooseProductForOrder()
        {
            InitializeComponent();
        }

        private void frm_ChooseProductForOrder_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_ChooseProductForOrder_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(spinEdit_Quantity.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng nhập số lượng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    spinEdit_Quantity.EditValue = 1;
                    return;
                }

                if (_checkAddOrDecrease == 1)
                {
                    P_OrderDetail.Date = DateTime.Now;
                }
                else
                {
                    if (Convert.ToInt32(spinEdit_Quantity.EditValue) >= P_OrderDetail.Quantity)
                    {
                        XtraMessageBox.Show("Số lượng giảm phải nhỏ hơn số lượng hiện có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        spinEdit_Quantity.EditValue = 1;
                        return;
                    }  
                }

                P_OrderDetail.Quantity = Convert.ToInt32(spinEdit_Quantity.EditValue);

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
    }
}