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
    public partial class frm_ChangeNameLogin : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public string _oldPass { get; set; }
        public string _changeCode { get; set; }

        public frm_ChangeNameLogin()
        {
            InitializeComponent();
        }

        private void frm_ChangeNameLogin_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_ChangeNameLogin_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textEdit_ChangeName.Text.Trim())==true)
                {
                    XtraMessageBox.Show("Vui lòng nhập tên đăng nhập mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_changeCode.Trim()==textEdit_ChangeName.Text.Trim())
                {
                    XtraMessageBox.Show("Giống tên đăng nhập cũ. Vui lòng chọn tên khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textEdit_ChangeName.Text.Trim().Length<6)
                {
                    XtraMessageBox.Show("Vui lòng nhập tên đăng nhập ít nhất 6 kí tự", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_oldPass.Trim()!=textEdit_OldPass.Text.Trim())
                {
                    XtraMessageBox.Show("Sai mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _changeCode = textEdit_ChangeName.Text.Trim();

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