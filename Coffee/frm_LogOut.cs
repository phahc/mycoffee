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
    public partial class frm_LogOut : DevExpress.XtraEditors.XtraForm
    {
        public bool _activeLogout { get; set; }
        public bool _cancel { get; set; }
        public bool _receivePlanWork { get; set; }

        public frm_LogOut()
        {
            InitializeComponent();
        }

        private void frm_LogOut_Load(object sender, EventArgs e)
        {
            try
            {
                button_ReportShift.Enabled = false;
                button_ReportDetails.Enabled = false;
                btn_Transfer.Enabled = false;

                if (_receivePlanWork == false)//Nếu không nhận ca
                {
                    if (CoffeeHelpers.EmpLogin.EmpRight != CoffeeHelpers.EmpRight.Operator)//Nếu là quản trị
                    {
                        button_ReportDetails.Enabled = true;//Được in báo cáo
                    }
                }
                else if(_receivePlanWork == true)//Đã nhận ca
                {
                    button_ReportShift.Enabled = true;
                    button_ReportDetails.Enabled = true;
                    btn_Transfer.Enabled = true;//Được giao ca
                }
                else if (_activeLogout == false)
                {
                    button_ReportShift.Enabled = false;
                    button_ReportDetails.Enabled = false;
                    btn_Transfer.Enabled = false;
                }
                else
                {
                    button_ReportShift.Enabled = true;
                    button_ReportDetails.Enabled = true;
                    btn_Transfer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_LogOut_Load");
            }
        }

        private void button_ReportDetails_Click(object sender, EventArgs e)
        {

        }

        private void button_ReportShift_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Logout 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Logout_Click(object sender, EventArgs e)
        {
            try
            {
                if (_receivePlanWork == true)
                {
                    var result=XtraMessageBox.Show("Bạn chưa giao ca. Bạn có muốn giao ca không ?", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    else if (result == DialogResult.No)
                    {
                        DialogResult = DialogResult.Cancel;
                        this.Close();
                        return;
                    }
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có chắc muốn đăng xuất ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                    DialogResult = DialogResult.Cancel;
                }
                
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Logout_Click");
            }
        }

        /// <summary>
        /// Logout và tao ca mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Transfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn giao ca này ?", "Thông Báo Giao Ca", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                _cancel = false;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Transfer_Click");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                _cancel = true;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Cancel_Click");
            }
        }
    }
}