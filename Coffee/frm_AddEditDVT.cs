using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using Coffee.Utils;
using System.Linq;

namespace Coffee
{
    public partial class frm_AddEditDVT : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public donvitinh P_DVT { get; set; }
        public ImageList list_Image { get; set; }

        int iconIndex = -1;

        public frm_AddEditDVT()
        {
            InitializeComponent();
        }

        private void frm_AddEditDVT_Load(object sender, EventArgs e)
        {
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                this.imageList_DVT = list_Image;
                this.listView_IconDVT.View = View.LargeIcon;
                //this.listView_IconMenu.Size = new Size(32, 32);
                this.listView_IconDVT.LargeImageList = this.imageList_DVT;

                for (int j = 0; j < this.imageList_DVT.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    this.listView_IconDVT.Items.Add(item);
                    this.listView_IconDVT.Tag = item.ImageIndex;
                }
                if (P_DVT.MADVT != 0)//Update
                {
                    textEdit_DVTName.EditValue = P_DVT.DONVITINH1;
                    listView_IconDVT.Items[P_DVT.ImageIndex].Selected = true;
                    iconIndex = P_DVT.ImageIndex;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_AddEditDVT_Load");
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textEdit_DVTName.Text.Trim()))
                {
                    XtraMessageBox.Show("Vui lòng nhập vào tên đơn vị tính", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit_DVTName.Focus();
                    return;
                }
                if (iconIndex == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn biểu tượng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (P_DVT.MADVT == 0)//Add
                {
                    if (checkExistDVT(textEdit_DVTName.Text) == true)
                    {
                        XtraMessageBox.Show("Đơn vị tính này đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                P_DVT.DONVITINH1 = textEdit_DVTName.EditValue.ToString();
                P_DVT.ImageIndex = iconIndex;

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

        private void listView_IconDVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedIndexCollection indexes = this.listView_IconDVT.SelectedIndices;
                if (indexes.Count > 0)
                {
                    foreach (int index in indexes)
                    {
                        iconIndex = index;

                        //Hiển thị lên PictureEdit
                        Bitmap image = new Bitmap(imageList_DVT.Images[index]);
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
                XtraMessageBox.Show(ex.Message, "listView_IconDVT_SelectedIndexChanged");
            }
        }

        private bool checkExistDVT(string DVTName)
        {
            List<donvitinh> dvts;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                dvts = (from dv in _dbContext.donvitinhs.ToList() select dv).ToList();
                if (dvts != null && dvts.Count > 0)
                {
                    foreach (donvitinh d in dvts)
                    {
                        if (d.DONVITINH1.Trim() == DVTName.Trim())
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkExistDVT");
                return false;
            }
        }
    }
}