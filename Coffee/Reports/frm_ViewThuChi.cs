using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Coffee.DataSet;
using Coffee.Reports;

namespace Coffee.Reports
{
    public partial class frm_ViewThuChi : DevExpress.XtraEditors.XtraForm
    {
        public DataSet_ThuChi _ds;
        public XtraReport_ThuChi _report;

        public frm_ViewThuChi()
        {
            InitializeComponent();
        }

        private void frm_ViewThuChi_Load(object sender, EventArgs e)
        {
            try
            {
                _report.RequestParameters = false;
                _report.DataSource = _ds;
                _report.CreateDocument();

                printControl1.ShowPageMargins = false;
                printControl1.PrintingSystem = _report.PrintingSystem;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_ViewThuChi_Load");
            }
        }

    }
}