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

namespace Coffee
{
    public partial class frm_MailReceiver : DevExpress.XtraEditors.XtraForm
    {

        #region Fields

        private mycoffeeEntities _dbContext;
        private DataTable _tbSource;

        #region ColumnName

        private const string _cEMail = "EMail";
        private const string _cName = "Name";
        private const string _cAutoSend = "AutoSend";
        private const string _cAutoSendDate = "AutoSendDate";

        private const string _cSMSKindID = "SMSKindID";
        private const string _cSMSKindDesc = "SMSKindDesc";

        #endregion //--- ColumnName

        #endregion //--- Fields

        public frm_MailReceiver()
        {
            InitializeComponent();
        }

        private void frm_MailReceiver_Load(object sender, EventArgs e)
        {
            try
            {
                //--- Tạo cấu trúc table MailReceiver
                _tbSource = CreateTableMailReceiverStruct();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                LoadMailReceiver();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frmMailReceiver_Load");
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {

            frm_AddEditMailReceiver dlg;
            DataRow newRow;

            try
            {
                dlg = new frm_AddEditMailReceiver();
                dlg.P_MailReceiver = new mailreceiver();
                dlg.Text = "Thêm Người Nhận EMail";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    _dbContext.mailreceivers.Add(dlg.P_MailReceiver);
                    _dbContext.SaveChanges();

                    newRow = _tbSource.NewRow();
                    newRow[_cEMail] = dlg.P_MailReceiver.Email;
                    newRow[_cName] = dlg.P_MailReceiver.Name;
                    newRow[_cAutoSend] = dlg.P_MailReceiver.AutoSend;
                    newRow[_cAutoSendDate] = dlg.P_MailReceiver.AutoSendDate.HasValue ? dlg.P_MailReceiver.AutoSendDate.Value.ToString("HH:mm:ss") : "";
                    _tbSource.Rows.Add(newRow);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Add_Click");
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            frm_AddEditMailReceiver dlg;
            mailreceiver mailReceiver, updateMailReceiver;
            DataRow updateRow;
            DateTime dtNow;
            TimeSpan ts;
            string emailOld;

            try
            {
                if (gridView_MailReceiver.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có thông tin người nhận mail nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dtNow = DateTime.Now;
                updateRow = gridView_MailReceiver.GetFocusedDataRow();
                emailOld = updateRow[_cEMail].ToString();
                mailReceiver = new mailreceiver();
                mailReceiver.Email = updateRow[_cEMail].ToString();
                mailReceiver.Name = updateRow[_cName].ToString();
                mailReceiver.AutoSend = Convert.ToInt32(updateRow[_cAutoSend]);
                if (string.IsNullOrEmpty(updateRow[_cAutoSendDate].ToString()))
                {
                    mailReceiver.AutoSendDate = null;
                }
                else
                {
                    ts = CoffeeHelpers.ParseTimeSpan(updateRow[_cAutoSendDate].ToString());
                    mailReceiver.AutoSendDate = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, ts.Hours, ts.Minutes, ts.Seconds);
                }

                dlg = new frm_AddEditMailReceiver();
                dlg.P_MailReceiver = mailReceiver;
                dlg.Text = "Sửa Người Nhận EMail";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                    updateMailReceiver = (from mr in _dbContext.mailreceivers where mr.Email == emailOld select mr).FirstOrDefault();
                    if (updateMailReceiver != null)
                    {
                        updateMailReceiver.Name = dlg.P_MailReceiver.Name;
                        updateMailReceiver.AutoSend = dlg.P_MailReceiver.AutoSend;
                        updateMailReceiver.AutoSendDate = dlg.P_MailReceiver.AutoSendDate;

                        _dbContext.SaveChanges();

                        updateRow[_cEMail] = updateMailReceiver.Email;
                        updateRow[_cName] = updateMailReceiver.Name;
                        updateRow[_cAutoSend] = updateMailReceiver.AutoSend;
                        updateRow[_cAutoSendDate] = updateMailReceiver.AutoSendDate.HasValue ? updateMailReceiver.AutoSendDate.Value.ToString("HH:mm:ss") : "";
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Update_Click");
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            DataRow deleteRow;
            mailreceiver mailReceiver;
            string email;

            try
            {
                if (gridView_MailReceiver.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có thông tin người nhận mail nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn chắc chắn muốn xóa thông tin người nhận mail này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                deleteRow = gridView_MailReceiver.GetFocusedDataRow();
                email = deleteRow[_cEMail].ToString();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                mailReceiver = (from mr in _dbContext.mailreceivers where mr.Email == email select mr).FirstOrDefault();
                if (mailReceiver != null)
                {
                    _dbContext.mailreceivers.Remove(mailReceiver);
                    _dbContext.SaveChanges();
                    gridView_MailReceiver.DeleteRow(gridView_MailReceiver.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Delete_Click");
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

        #region --- Helper ---

        /// <summary>
        /// Load MailReceiver
        /// </summary>
        private void LoadMailReceiver()
        {
            DataRow newRow;
            List<mailreceiver> mailReceivers;

            try
            {
                mailReceivers = (from mr in _dbContext.mailreceivers orderby mr.Name select mr).ToList();

                foreach (mailreceiver mailReceiver in mailReceivers)
                {
                    newRow = _tbSource.NewRow();
                    newRow[_cEMail] = mailReceiver.Email;
                    newRow[_cName] = mailReceiver.Name;
                    newRow[_cAutoSend] = mailReceiver.AutoSend;
                    newRow[_cAutoSendDate] = mailReceiver.AutoSendDate.HasValue ? mailReceiver.AutoSendDate.Value.ToString("HH:mm:ss") : "";
                    _tbSource.Rows.Add(newRow);
                }

                gridControl_MailReceiver.DataSource = _tbSource;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadSMSReceiver");
            }
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho table MailReceiver
        /// </summary>
        private DataTable CreateTableMailReceiverStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cEMail);
                tbSource.Columns.Add(_cName);
                tbSource.Columns.Add(_cAutoSend, typeof(bool));
                tbSource.Columns.Add(_cAutoSendDate);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cEMail] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableMailReceiverStruct");
                return tbSource;
            }
            return tbSource;
        }

        #endregion //--- Helper ---
    }
}