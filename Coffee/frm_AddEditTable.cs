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
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_AddEditTable : DevExpress.XtraEditors.XtraForm
    {
        #region Fields

        private const string _waterMask = "--- Vui lòng chọn ---";

        public mycoffeeEntities _dbContext;
        public area_table P_AreaTable { get; set; }
        public string AreaCode { get; set; }

        #region ColumnName

        private const string _cAreaID = "AreaID";
        private const string _cAreaCode = "AreaCode";

        #endregion //--- ColumnName

        #endregion //--- Fields

        public frm_AddEditTable()
        {
            InitializeComponent();
        }

        private void frm_AddEditTable_Load(object sender, EventArgs e)
        {
            try
            {
                //Load khu vực
                LoadListAreas();

                if (P_AreaTable.TableID != 0)//Update
                {
                    textEdit_TableName.Text = P_AreaTable.TableCode.ToString();
                    slookUpEdit_Area.EditValue = P_AreaTable.AreaID;
                    if (P_AreaTable.Status == 1)
                    {
                        radioButton_Running.Checked = true;
                    }
                    else
                    {
                        radioButton_Stop.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditTable_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit_TableName.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng đặt tên bàn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(slookUpEdit_Area.EditValue)==-1)
                {
                    XtraMessageBox.Show("Vui lòng chọn khu vực", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                P_AreaTable.TableCode = textEdit_TableName.Text;
                P_AreaTable.AreaID = Convert.ToInt32(slookUpEdit_Area.EditValue);
                AreaCode = slookUpEdit_Area.Text;
                P_AreaTable.Empty = 1;

                if (radioButton_Running.Checked == true)
                {
                    P_AreaTable.Status = 1;
                }
                else
                {
                    P_AreaTable.Status = 2;
                }

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

        /// <summary>
        /// Load danh sách khu vực
        /// </summary>
        private void LoadListAreas()
        {
            List<area> areas;
            DataTable tbSource;
            DataRow newRow;

            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                areas = (from p in _dbContext.areas.ToList() where p.Status == 1 select p).ToList();

                tbSource = new DataTable();
                tbSource.Columns.Add(_cAreaID, typeof(int));
                tbSource.Columns.Add(_cAreaCode);

                foreach (area ar in areas)
                {
                    newRow = tbSource.NewRow();
                    newRow[_cAreaID] = ar.AreaID;
                    newRow[_cAreaCode] = ar.AreaCode;
                    tbSource.Rows.Add(newRow);
                }

                //Nếu chỉ có 1 thì chọn ngay trường này
                int selectID = -1;
                if (areas.Count > 0)
                {
                    selectID = areas.FirstOrDefault().AreaID;
                }
                else
                {
                    newRow = tbSource.NewRow();
                    newRow[_cAreaID] = -1;
                    newRow[_cAreaCode] = _waterMask;
                    tbSource.Rows.InsertAt(newRow, 0);
                }
                
                slookUpEdit_Area.Properties.DisplayMember = _cAreaCode;
                slookUpEdit_Area.Properties.ValueMember = _cAreaID;
                slookUpEdit_Area.Properties.DataSource = tbSource;
                slookUpEdit_Area.EditValue = selectID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadListAreas");
            }
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelControl1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "panelControl1_MouseDown");
            }
        }
    }
}