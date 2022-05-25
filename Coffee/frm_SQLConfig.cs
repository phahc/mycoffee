using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Coffee.Utils;

namespace Coffee
{
    public partial class frm_SQLConfig : DevExpress.XtraEditors.XtraForm
    {
        public frm_SQLConfig()
        {
            InitializeComponent();
        }

        private void frm_SQLConfig_Load(object sender, EventArgs e)
        {

           CoffeeHelpers.DatabaseSettings dbSettings;

            try
            {
                dbSettings = CoffeeHelpers.LoadDatabaseSettings();

                if (dbSettings == null)
                {
                    XtraMessageBox.Show("Cấu hình kết nối database chưa được khai báo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dbSettings.CheckPrincipal) //Chứng thực = sql
                {
                    checkEdit_SQL.Checked = true;
                    checkEdit_Win.Checked = false;
                }
                else
                {
                    checkEdit_SQL.Checked = false;
                    checkEdit_Win.Checked = true;

                    textEdit_LoginName.Enabled = false;
                    textEdit_Password.Enabled = false;
                }
                textEdit_ServerName.Text = dbSettings.PrincipalServer.Trim();
                textEdit_DatabaseName.Text = dbSettings.DatabaseName.Trim();
                textEdit_LoginName.Text = dbSettings.LoginName.Trim();
                textEdit_Password.Text = dbSettings.Password.Trim();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frmSQLConfig_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            CoffeeHelpers.DatabaseSettings dbSettings;

            try
            {
                dbSettings = new CoffeeHelpers.DatabaseSettings();

                //----- Save new settings
                dbSettings.PrincipalServer = textEdit_ServerName.Text.Trim();
                dbSettings.LoginName = textEdit_LoginName.Text.Trim();
                dbSettings.Password = textEdit_Password.Text.Trim();
                dbSettings.DatabaseName = textEdit_DatabaseName.Text.Trim();
                if (checkEdit_SQL.Checked)
                    dbSettings.CheckPrincipal = true;
                else
                    dbSettings.CheckPrincipal = false;
                CoffeeHelpers.SaveDatabaseSettings(dbSettings);

                if (dbSettings.CheckPrincipal)
                    CoffeeHelpers.ConnectionString = string.Format("user id={0};Password={1};data source={2};initial catalog={3};", dbSettings.LoginName, dbSettings.Password, dbSettings.PrincipalServer, dbSettings.DatabaseName);
                else
                    CoffeeHelpers.ConnectionString = string.Format("data source={0};initial catalog={1};Integrated Security=SSPI;", dbSettings.PrincipalServer, dbSettings.DatabaseName);

                XtraMessageBox.Show("Lưu cấu hình Server Database thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Close_Click");
            }
        }

        private void button_TestConnection_Click(object sender, EventArgs e)
        {
            string connectionString = "";

            try
            {
                if (checkEdit_SQL.Checked)
                {
                    connectionString = string.Format("user id={0};Password={1};data source={2};initial catalog={3}",
                                       textEdit_LoginName.Text.Trim(), textEdit_Password.Text.Trim(), textEdit_ServerName.Text.Trim(),
                                       textEdit_DatabaseName.Text.Trim());
                }
                else
                {
                    connectionString = string.Format("data source={0};initial catalog={1};Integrated Security=SSPI;Connect Timeout=60",
                                       textEdit_ServerName.Text.Trim(), textEdit_DatabaseName.Text.Trim());
                }

                if (CoffeeHelpers.TestConnect(connectionString))
                {
                    XtraMessageBox.Show("Kết nối thành công vào Server Database", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Không thể kết nối vào Server Database", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_TestConnection_Click");
            }
        }

        private void checkEdit_SQL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit_SQL.Checked)
            {
                textEdit_LoginName.Enabled = true;
                textEdit_Password.Enabled = true;
            }
            else
            {
                textEdit_LoginName.Enabled = false;
                textEdit_Password.Enabled = false;
            }
        }
    }
}