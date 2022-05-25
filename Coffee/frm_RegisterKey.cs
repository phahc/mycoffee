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
    public partial class frm_RegisterKey : DevExpress.XtraEditors.XtraForm
    {
        public string _Key { get; set; }
        public string _day_Trial { get; set; }

        public frm_RegisterKey()
        {
            InitializeComponent();
        }

        private void frm_RegisterKey_Load(object sender, EventArgs e)
        {
            try
            {
                lbl_Trial.Text = _day_Trial;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_RegisterKey_Load");
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            try
            {
                _Key = textEdit_key.Text;

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Register_Click");
            }
        }

    }
}