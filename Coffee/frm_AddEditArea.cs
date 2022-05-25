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
    public partial class frm_AddEditArea : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public area P_Area { get; set; }

        public frm_AddEditArea()
        {
            InitializeComponent();
        }

        private void frm_AddEditArea_Load(object sender, EventArgs e)
        {
            try
            {
                if (P_Area.AreaID != 0)//Updtae
                {
                    textEdit_AreaName.EditValue = P_Area.AreaCode;
                    if (P_Area.Status == 2)
                    {
                        radioButton_Running.Checked = false;
                        radioButton_Stop.Checked = true;
                    }
                    else
                    {
                        radioButton_Running.Checked = true;
                        radioButton_Stop.Checked = false;
                    }
                    if (P_Area.SystemKey== 1)
                    {
                        radioButton_Running.Enabled = false;
                        radioButton_Stop.Enabled= false;
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditArea_Load");
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

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit_AreaName.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng đặt tên khu vực", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                P_Area.AreaCode = textEdit_AreaName.Text;

                if (radioButton_Running.Checked == true)
                {
                    P_Area.Status = 1;
                }
                else
                {
                    P_Area.Status = 2;
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Save_Click");
            }
        }
    }
}