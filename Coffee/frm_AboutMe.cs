using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;

namespace Coffee
{
    public partial class frm_AboutMe : DevExpress.XtraEditors.XtraForm
    {
        public frm_AboutMe()
        {
            InitializeComponent();
        }

        private void linkLabel_Facebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("https://www.facebook.com/khoa.huynh.39589149");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "linkLabel_Facebook_LinkClicked");
            }
        }

        private void frm_AboutMe_Load(object sender, EventArgs e)
        {
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }
    }
}