using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Resources;
using System.Reflection;
using Coffee.Utils;
using System.Linq;

namespace Coffee
{
    public partial class frm_AddEditMenu : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public menu P_Menu { get; set; }
        public ImageList list_Image { get; set; }
        public Dictionary<int, int> _dic_images { get; set; }

        int iconIndex = -1;
        public frm_AddEditMenu()
        {
            InitializeComponent();
        }

        private void frm_AddEditMenu_Load(object sender, EventArgs e)
        {
            List<menu> menus;
            ListViewGroup group;
            try
            {
                this.imageList_IconMenu=list_Image;

                this.listView_IconMenu.View = View.LargeIcon;
                //this.listView_IconMenu.Size = new Size(32, 32);
                this.listView_IconMenu.LargeImageList = this.imageList_IconMenu;

                //for (int j = 0; j < this.imageList_IconMenu.Images.Count; j++)
                //{
                //    ListViewItem item = new ListViewItem();
                //    item.ImageIndex = j;
                //    this.listView_IconMenu.Items.Add(item);
                //    this.listView_IconMenu.Tag = item.ImageIndex;
                //}

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                menus = (from mn in _dbContext.menus.ToList() select mn).ToList();

                if (menus != null && menus.Count > 0)
                {
                    foreach (menu m in menus)
                    {
                        group = new ListViewGroup("header", m.MenuCode);
                        listView_IconMenu.Groups.Add(group);

                        //for (int j = 0; j < list_Image.Images.Count; j++)
                        //{
                        //    if (_dic_images.Keys== m.MenuID)// thuộc nhóm
                        //    {
                        //        ListViewItem item = new ListViewItem("", group);
                        //        item.ImageIndex = j;
                        //        this.listView_IconMenu.Items.Add(item);
                        //        this.listView_IconMenu.Tag = item.ImageIndex;
                        //    }
                        //}

                        int t = 0;
                        foreach (var img in _dic_images)
                        {
                           if (img.Value== m.MenuID)// thuộc nhóm
                           {
                               ListViewItem item = new ListViewItem("", group);
                               item.ImageIndex = t;
                               this.listView_IconMenu.Items.Add(item);
                               this.listView_IconMenu.Tag = item.ImageIndex;
                           }

                           t++;
                        }
                    }
                }


                if (P_Menu.MenuID != 0)//Updtae
                {
                    textEdit_MenuName.EditValue = P_Menu.MenuCode;
                    iconIndex = P_Menu.ImageIndex;
                    if (P_Menu.Status == 2)
                    {
                        radioButton_Running.Checked = false;
                        radioButton_Stop.Checked = true;
                    }
                    else
                    {
                        radioButton_Running.Checked = true;
                        radioButton_Stop.Checked = false;
                    }
                    if (P_Menu.SystemKey== 1)
                    {
                        radioButton_Running.Enabled = false;
                        radioButton_Stop.Enabled = false;
                    }

                    if (iconIndex != -1)
                    {
                        listView_IconMenu.Items[iconIndex].Selected= true;
                        listView_IconMenu.Items[iconIndex].ForeColor = System.Drawing.Color.FromArgb(0 ,134, 139);
                        //Hiển thị lên PictureEdit
                        Bitmap image = new Bitmap(imageList_IconMenu.Images[iconIndex]);
                        pictureEdit_ImageChoose.Image = image;
                    }
                }
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditMenu_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textEdit_MenuName.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng đặt tên thực đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (iconIndex==-1)
                {
                    XtraMessageBox.Show("Vui lòng chọn biểu tượng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                P_Menu.MenuCode = textEdit_MenuName.Text;

                if (radioButton_Running.Checked == true)
                {
                    P_Menu.Status = 1;
                }
                else
                {
                    P_Menu.Status = 2;
                }
                P_Menu.ImageIndex = iconIndex;

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

        private void listView_IconMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedIndexCollection indexes = this.listView_IconMenu.SelectedIndices;
                if (indexes.Count > 0)
                {
                    foreach (int index in indexes)
                    {
                        iconIndex = index;

                        //Hiển thị lên PictureEdit
                        Bitmap image = new Bitmap(imageList_IconMenu.Images[index]);
                        pictureEdit_ImageChoose.Image = image;
                    }
                }
                else
                {
                    iconIndex = -1;

                    pictureEdit_ImageChoose.Image = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "listView_IconMenu_SelectedIndexChanged");
            }
        }
    }
}