using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Linq;
using Coffee.Utils;
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_AddEditIcon : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public icon P_Icon { get; set; }
        public string _link { get; set; }

        public frm_AddEditIcon()
        {
            InitializeComponent();
        }

        private void frm_Icon_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProductSkin();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Icon_Load");
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textEdit_Link.Text))
                {
                    XtraMessageBox.Show("Vui lòng chọn hình ảnh","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (Convert.ToInt32(lookUpEdit_Skin.EditValue) <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn loại thực đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _link = textEdit_Link.Text;
                P_Icon.IconSkin = Convert.ToInt32(lookUpEdit_Skin.EditValue);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Save_Click");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Close_Click");
            }
        }

        private void simpleButton_Browser_Click(object sender, EventArgs e)
        {
            string filepath = "";
            try
            {
                OpenFileDialog fbd = new OpenFileDialog();
                DialogResult dr = fbd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    filepath = fbd.FileName;

                    if (filepath != "")
                    {
                        textEdit_Link.Text = filepath;
                    }

                    pictureEdit_ICon.Image = Image.FromFile(textEdit_Link.Text);
                }
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "simpleButton_Browser_Click");
            }
        }

        /// <summary>
        /// Load danh sách phân loại
        /// </summary>
        private void LoadProductSkin()
        {
            DataTable tbSource;
            DataRow newRow;
            List<menu> listMenu;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add("ID", typeof(int));
                tbSource.Columns.Add("Name");

                listMenu = (from me in _dbContext.menus.ToList() where me.Status == 1 select me).ToList();
                if (listMenu.Count > 0)
                {
                    foreach (menu item in listMenu)
                    {
                        newRow = tbSource.NewRow();
                        newRow["ID"] = item.MenuID;
                        newRow["Name"] = item.MenuCode;
                        tbSource.Rows.Add(newRow);
                    }
                }
                //Nếu danh sách chỉ có 1 thì hiện thị giá trị này
                int selectID = -1;
                if (listMenu.Count == 1)
                {
                    selectID = listMenu.FirstOrDefault().MenuID;
                }
                else
                {
                    newRow = tbSource.NewRow();
                    newRow["ID"] = -1;
                    newRow["Name"] = "Chọn dữ liệu";
                    tbSource.Rows.InsertAt(newRow, 0);
                }

                lookUpEdit_Skin.Properties.DisplayMember = "Name";
                lookUpEdit_Skin.Properties.ValueMember = "ID";
                lookUpEdit_Skin.Properties.DataSource = tbSource;
                lookUpEdit_Skin.EditValue = selectID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadProductSkin");
            }
        }

        private void lookUpEdit_Skin_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frm_AddEditMenu dlg;
            menu menus;
            try
            {
                if (e.Button.Index != lookUpEdit_Skin.Properties.Buttons[1].Index)
                {
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dlg = new frm_AddEditMenu();
                menus = new menu();
                dlg._dbContext = _dbContext;
                dlg.P_Menu = menus; ;
                dlg.Text = "Thêm Mới Nhóm Hàng";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext.menus.Add(dlg.P_Menu);
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "lookUpEdit_Skin_Properties_ButtonClick");
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