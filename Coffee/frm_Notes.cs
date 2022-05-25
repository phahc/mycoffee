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
    public partial class frm_Notes : DevExpress.XtraEditors.XtraForm
    {
        public listorder P_Orders;

        public frm_Notes()
        {
            InitializeComponent();
        }

        private void frm_Notes_Load(object sender, EventArgs e)
        {
            try
            {
                memoEdit_Notes.Text = P_Orders.Notes;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Notes_Load");
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                P_Orders.Notes = memoEdit_Notes.Text;

                this.DialogResult = DialogResult.OK;
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
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Close_Click");
            }
        }
    }
}