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
using System.IO;
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_SelectAddProduct : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public TreeNode _Node { get; set; }
        public ImageList list_Image { get; set; }

        public frm_SelectAddProduct()
        {
            InitializeComponent();
        }

        private void frm_SelectAddProduct_Load(object sender, EventArgs e)
        {
            try
            {
                this.imageList_Product = list_Image;

                AddMenuOnList();//Load danh sách nhóm hàng
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_SelectAddProduct_Load");
            }
        }

        private void AddMenuOnList()
        {
            List<menu> menus;
            TreeNode node;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                treeView_Menu.ImageList = this.imageList_Product;

                menus = (from m in _dbContext.menus.ToList() where m.Status != 2 select m).OrderBy(o => o.MenuCode).ToList();

                if (menus != null && menus.Count > 0)
                {

                    foreach (menu item in menus)
                    {
                        node = new TreeNode();
                        node.Name = item.MenuID.ToString();
                        node.Text = item.MenuCode;
                        node.ImageIndex = item.ImageIndex;
                        node.SelectedImageIndex = item.ImageIndex;
                        node.Tag = item.Status;

                        treeView_Menu.Nodes.Add(node);
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddMenuOnList");
            }
        }

        private void treeView_Menu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                _Node = e.Node;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Menu_NodeMouseClick");
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

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_OK_Click");
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

        private void treeView_Menu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {         
            try
            {
                _Node = e.Node;

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Menu_NodeMouseDoubleClick");
            }
        }
    }
}