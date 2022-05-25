using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
namespace Form_LogOut
{
    public partial class LogOut : DevExpress.XtraEditors.XtraForm
    {
        public LogOut()
        {
            InitializeComponent();
        }

        private void LogOut_Load(object sender, EventArgs e)
        {
            try
            {
                //Chạy lại chương trình
                string exePath = Application.StartupPath + @"\Coffee.exe";
                System.Diagnostics.Process.Start(exePath, "");

                //Kết thúc mọi xử lý
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                Application.Exit();
            }
            catch (Exception ex)
            {

            }
        }
    }
}