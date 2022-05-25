using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Coffee.Reports;
namespace Coffee.Reports
{
    public partial class frm_ViewDemo : DevExpress.XtraEditors.XtraForm
    {
        public XtraReport_XuatHoaDonThanhToan rp = new XtraReport_XuatHoaDonThanhToan();
        public frm_ViewDemo()
        {
            InitializeComponent();
        }

        private void frm_ViewDemo_Load(object sender, EventArgs e)
        {
            printControl1.ShowPageMargins = false;
            printControl1.PrintingSystem = rp.PrintingSystem;
        }
    }
}