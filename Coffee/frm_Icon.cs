using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
using System.IO;
using Coffee.Utils;
using System.Linq;
using System.Runtime.InteropServices;

namespace Coffee
{
    public partial class frm_Icon : DevExpress.XtraEditors.XtraForm
    {
        private mycoffeeEntities _dbContext;
        public ImageList _imageList { get; set; }
        public Dictionary<int, int> _dic_image { get; set; }
        int iconIndex = -1;
        int IdIcon = -1;

        public frm_Icon()
        {
            InitializeComponent();
        }

        private void frm_Icon_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGroupImage();   
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Icon_Load");
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                MySqlCommand cmd;
                FileStream fs;
                BinaryReader br;

                frm_AddEditIcon dlg;
                icon icons;

                try
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    icons = new icon();
                    dlg = new frm_AddEditIcon();
                    dlg._dbContext = _dbContext;
                    dlg.P_Icon = icons;
                    dlg.Text = "THÊM BIỂU TƯỢNG";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string FileName = dlg._link;
                        byte[] ImageData;
                        fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                        br = new BinaryReader(fs);
                        ImageData = br.ReadBytes((int)fs.Length);
                        br.Close();
                        fs.Close();

                        string CmdString = "INSERT INTO icon(IconName,IconSkin) VALUES(@IconName, @IconSkin)";
                        cmd = new MySqlCommand(CmdString, con);

                        cmd.Parameters.Add("@IconName", MySqlDbType.Blob);
                        cmd.Parameters.Add("@IconSkin", MySqlDbType.Int32, 11);

                        cmd.Parameters["@IconName"].Value = ImageData;
                        cmd.Parameters["@IconSkin"].Value = dlg.P_Icon.IconSkin;

                        con.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            MessageBox.Show("Lưu hình ảnh thành công!");
                        }
                        con.Close();

                        LoadImage();

                        LoadGroupImage();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Add_Click");
            }
        }

        // Load hình ảnh theo group
        private void LoadGroupImage()
        {
            List<menu> menus;
            ListViewGroup group;
            try
            {
                // Hình ảnh
                this.imageList_IconProduct = _imageList;

                this.listView_IconProduct.View = View.LargeIcon;
                //this.listView_IconMenu.Size = new Size(32, 32);
                this.listView_IconProduct.LargeImageList = this.imageList_IconProduct;

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                menus = (from mn in _dbContext.menus.ToList() select mn).ToList();

                if (menus != null && menus.Count > 0)
                {
                    foreach (menu m in menus)
                    {
                        group = new ListViewGroup("header", m.MenuCode);
                        listView_IconProduct.Groups.Add(group);
                        int t = 0;
                        foreach (var img in _dic_image)
                        {
                            if (img.Value == m.MenuID)// thuộc nhóm
                            {
                                ListViewItem item = new ListViewItem("", group);
                                item.ImageIndex = t;
                                item.Tag = img.Key;
                                this.listView_IconProduct.Items.Add(item);
                                this.listView_IconProduct.Tag = item.ImageIndex;
                            }
                            t++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadGroupImage");
            }
        }

        // Load biểu tượng
        private void LoadImage()
        {
            try
            {
                this.listView_IconProduct.Clear();

                _dic_image = new Dictionary<int, int>();
                _imageList.Images.Clear();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                List<icon> list = (from ic in _dbContext.icons.ToList() select ic).ToList();

                if (list != null && list.Count > 0)
                {
                    foreach (icon i in list)
                    {
                        FileStream FS1 = new FileStream("image" + i.idIcon + ".jpg", FileMode.Create);
                        byte[] blob = (byte[])i.IconName;
                        FS1.Write(blob, 0, blob.Length);
                        FS1.Close();
                        FS1 = null;

                        Image img = Image.FromFile("image" + i.idIcon + ".jpg");
                        img.Tag = i.IconSkin;

                        this._imageList.Images.Add(img);
                        this._imageList.Tag = i.IconSkin;

                        _dic_image.Add(i.idIcon, Convert.ToInt32(i.IconSkin));
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadImage");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            icon icons;
            try
            {
                if (checkIconUsed(IdIcon) == true)
                {
                    XtraMessageBox.Show("Không thể xóa. Biểu tượng đang dùng","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Bạn có chắc muốn xóa biểu tượng này?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                icons = (from ic in _dbContext.icons where ic.idIcon == IdIcon select ic).FirstOrDefault();
                if (icons != null)
                {
                    _dbContext.icons.Remove(icons);
                    _dbContext.SaveChanges();

                    imageList_IconProduct.Images.RemoveAt(iconIndex);
                    _dic_image.Remove(iconIndex);
                    listView_IconProduct.Items.RemoveAt(iconIndex);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Delete_Click");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Exit_Click");
            }
        }

        private bool checkIconUsed(int index)
        {
            bool result=false;
            List<product> products;
            List<donvitinh> dvts;
            
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                products = (from p in _dbContext.products.ToList() select p).ToList();
                dvts = (from dv in _dbContext.donvitinhs.ToList() select dv).ToList();

                if (products != null && products.Count > 0)
                {
                    foreach (product pr in products)
                    {
                        if (pr.ImageIndex == index)
                        {
                            result = true;
                            return result;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    if (dvts != null && dvts.Count > 0)
                    {
                        foreach (donvitinh dv in dvts)
                        {
                            if (dv.ImageIndex == index)
                            {
                                result = true;
                                return result;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        return result;
                    }
                    else
                    {
                        result = false;
                        return result;
                    }
                }
                else
                {
                    if (dvts != null && dvts.Count > 0)
                    {
                        foreach (donvitinh dv in dvts)
                        {
                            if (dv.ImageIndex == index)
                            {
                                result = true;
                                return result;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        return result;
                    }
                    else
                    {
                        result = false;
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkIconUsed");
            }
            return result;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelControl2_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "panelControl2_MouseDown");
            }
        }

       
        private void listView_IconProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection items = this.listView_IconProduct.SelectedItems;
                ListView.SelectedIndexCollection indexs = this.listView_IconProduct.SelectedIndices;
                if (items.Count > 0)
                { 
                    IdIcon =Convert.ToInt32(items[0].Tag);
                   
                }
                else
                { 
                    IdIcon = -1;
                }

                if (indexs.Count > 0)
                {
                    foreach (int index in indexs)
                    {
                        iconIndex = index;
                    }
                }
                else
                {
                    iconIndex = -1;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "listView_IconProduct_SelectedIndexChanged");
            }
        }
    }
}