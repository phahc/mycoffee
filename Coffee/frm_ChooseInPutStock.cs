using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Coffee
{
    public partial class frm_ChooseInPutStock : DevExpress.XtraEditors.XtraForm
    {
        public int _Quantity { get; set; }

        public frm_ChooseInPutStock()
        {
            InitializeComponent();
        }

        private void frm_ChooseInPutStock_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_ChooseInPutStock_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                _Quantity = Convert.ToInt32(spinEdit_Quantity.EditValue);

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