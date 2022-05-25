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
    public partial class frm_PlusTable : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        public mycoffeeEntities _dbContext;
        public listorder P_ListOrder { get; set; }
        public int _AreaID { get; set; }
        public List<int> _listOrder { get; set; }
        public int _PlusOrChange { get; set; }//Phân biệt là hành động gộp hay chuyển bàn(1: gộp; 2: chuyển)
        public CoffeeHelpers.Config _config { get; set; }

        public int _tableID { get; set; }
        public string _tableCode { get; set; }

        private CheckEdit checkTable;
         private RadioButton radioTable;
        private List<CheckEdit> Group_ListTable = new List<CheckEdit>();
         private List<RadioButton> Group_ListTableChange = new List<RadioButton>();

        #endregion

        #region Form Method

        public frm_PlusTable()
        {
            InitializeComponent();
        }

        private void frm_PlusTable_Load(object sender, EventArgs e)
        {
            try
            {
                _listOrder = new List<int>();
                lbl_Plus.Text = this.Text;
                //Load danh sách khu vực
                AddAreas();

                if (_PlusOrChange == 1)//Gộp bàn
                {
                    //Danh sách bàn đang bán, trừ bàn đã chọn
                    AddTable_Plus(_AreaID);
                    button_Save.Text = "Gộp";
                }
                else
                {
                    AddTable_Change(_AreaID);//Chuyển bàn
                    button_Save.Text = "Chuyển";
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_PlusTable_Load");
            }
        }
        #endregion

        #region Helpers
        //Danh sách bàn theo khu vực (Gộp)
        private void AddTable_Plus(int areaID)
        {
            int maxTable = 0;
            int _default_maxTable = 0;
            List<listorder> listOrders;
            int line_y = 1;
            int line_x = 0;
            int loop = 0;

            try
            {
                if (xtraScrollable_Table.Controls.Count > 0)
                {
                    xtraScrollable_Table.Controls.Clear();
                }

                //Chieu rong cua xtraScrollable cho phep chu toi da ban co kich thuoc 105x105
                maxTable = xtraScrollable_Table.Width / 90;
                _default_maxTable = maxTable;

                listOrders = (from o in _dbContext.listorders.ToList() where o.area_table.AreaID == areaID && o.Status == 1 && o.OrderID != P_ListOrder.OrderID select o).ToList();
                if (listOrders != null && listOrders.Count > 0)
                {

                    int i = 2;
                    foreach (listorder or in listOrders)
                    {
                        //Số bàn tối đa cho phép trên dòng
                        if (loop == maxTable)
                        {
                            maxTable = _default_maxTable * i;

                            line_x = 0;// Tra hoanh do ve 0
                            line_y = (line_y + 90) + 5;//Tung do tang len ban mot kich thuoc chieu cao cua hang truoc

                            //--Hang ban thu may
                            i++;
                        }

                        checkTable = new CheckEdit();
                        PictureBox picture = new PictureBox();

                        Point pt = new Point(((line_x) * 90) + 5, line_y);
                        Point p = new Point(((line_x) * 90) + 5, line_y+75);

                        picture.Location = pt;
                        picture.Image = Coffee.Properties.Resources.coffee_table;
                        picture.Width = 75;
                        picture.Height = 75;

                        checkTable.Location = p;
                        checkTable.Text = or.area_table.TableCode;
                        checkTable.Name = "Order" + or.OrderID.ToString();
                        checkTable.Tag = or.OrderID.ToString();
                        checkTable.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        Font f = new Font("times new roman", 11.0f, System.Drawing.FontStyle.Bold);
                        checkTable.Checked = false;
                        //checkTable.AppearanceCaption.Font = f;
                        //checkTable.AppearanceCaption.ForeColor = Color.Maroon;
                        checkTable.Width = 90;
                        checkTable.Height = 20;
                        checkTable.CheckedChanged += new EventHandler(checkTable_CheckedChanged);//Sự kiện showpopup khi clcik


                        Group_ListTable.Add(checkTable);
                        xtraScrollable_Table.Controls.Add(picture);
                        xtraScrollable_Table.Controls.Add(checkTable);

                        line_x++;// Tang hoanh do

                        // Lap so ban
                        loop++;


                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddTable");
            }
        }

        //Danh sách bàn theo khu vực (Chuyển): Chỉ load danh sách bàn trống
        private void AddTable_Change(int areaID)
        {
            int maxTable = 0;
            int _default_maxTable = 0;
            List<area_table> tables;
            int line_y = 1;
            int line_x = 0;
            int loop = 0;

            try
            {
                if (xtraScrollable_Table.Controls.Count > 0)
                {
                    xtraScrollable_Table.Controls.Clear();
                }

                //Chieu rong cua xtraScrollable cho phep chu toi da ban co kich thuoc 105x105
                maxTable = xtraScrollable_Table.Width / 90;
                _default_maxTable = maxTable;

                tables = (from tb in _dbContext.area_table.ToList() where tb.Empty == 1 && tb.AreaID == areaID select tb).ToList();
                if (tables != null && tables.Count > 0)
                {

                    int i = 2;
                    foreach (area_table tb in tables)
                    {
                        //Số bàn tối đa cho phép trên dòng
                        if (loop == maxTable)
                        {
                            maxTable = _default_maxTable * i;

                            line_x = 0;// Tra hoanh do ve 0
                            line_y = (line_y + 90) + 5;//Tung do tang len ban mot kich thuoc chieu cao cua hang truoc

                            //--Hang ban thu may
                            i++;
                        }

                        radioTable= new RadioButton();
                        PictureBox picture = new PictureBox();

                        Point pt = new Point(((line_x) * 90) + 5, line_y);
                        Point p = new Point(((line_x) * 90) + 5, line_y+75);

                        picture.Location = pt;
                        picture.Image = Coffee.Properties.Resources.coffee_table;
                        picture.Width = 75;
                        picture.Height = 75;

                        radioTable.Location = p;
                        radioTable.Text = tb.TableCode;
                        radioTable.Name = tb.TableID.ToString();
                        radioTable.Tag = tb.TableID.ToString();
                        //radioTable.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        Font f = new Font("times new roman", 11.0f, System.Drawing.FontStyle.Bold);
                        radioTable.Checked = false;
                        //checkTable.AppearanceCaption.Font = f;
                        //checkTable.AppearanceCaption.ForeColor = Color.Maroon;
                        radioTable.Width = 90;
                        radioTable.Height = 20;
                        radioTable.CheckedChanged += new EventHandler(radioTable_CheckedChanged);//Sự kiện showpopup khi clcik


                        Group_ListTableChange.Add(radioTable);
                        xtraScrollable_Table.Controls.Add(picture);
                        xtraScrollable_Table.Controls.Add(radioTable);

                        line_x++;// Tang hoanh do

                        // Lap so ban
                        loop++;


                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddTable");
            }
        }

        //Danh Sách khu vực
        private void AddAreas()
        {
            List<area> areas;
            TreeNode node;
            try
            {              
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                areas = (from ar in _dbContext.areas.ToList() where ar.Status == 1 orderby ar.AreaID select ar).ToList();
                
                if (areas != null && areas.Count > 0)
                {
                    int i = 0;
                    foreach (area ar in areas)
                    {
                        if (i == _config.MaxArea)// Dãy tối đa cho phép
                        {
                            break;
                        }
                        node = new TreeNode();
                        node.Name = ar.AreaID.ToString();
                        node.Text = ar.AreaCode;
                        treeView_Areas.Nodes.Add(node);
                        i++;          
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddAreas");
            }
        }
        #endregion

        #region Actions
        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (_PlusOrChange == 1)
                {
                    string _tb = "Tất cả các món của ";
                    for (int i = 0; i < _listOrder.Count; i++)
                    {
                        for (int j = 0; j < xtraScrollable_Table.Controls.Count; j++)
                        {
                            if (_listOrder[i].ToString().Trim() == Group_ListTable[j].Tag.ToString().Trim())
                            {
                                _tb += Group_ListTable[j].Text + ", ";
                                break;
                            }
                        }
                    }
                    _tb = _tb.Trim().Substring(0, _tb.Length - 2);
                    _tb += " sẽ được chuyển vào " + P_ListOrder.area_table.TableCode + ".Bạn có muốn gộp không?";

                    if (XtraMessageBox.Show(_tb, "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    string _tb = P_ListOrder.area_table.TableCode + " sẽ được chuyển sang " + _tableCode + ". Bạn có chắc muốn chuyển?";
                    if (XtraMessageBox.Show(_tb, "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
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

        private void checkTable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit ch = sender as CheckEdit;
                if (ch.Checked == true)
                {
                    _listOrder.Add(Convert.ToInt32(ch.Tag));
                }
                else
                {
                    for (int i = 0; i < _listOrder.Count; i++)
                    {
                        if (_listOrder[i] == Convert.ToInt32(ch.Tag))
                        {
                            _listOrder.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkTable_CheckedChanged");
            }
        }

        private void radioTable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton ch = sender as RadioButton;
                if (ch.Checked == true)
                {
                    _tableID = Convert.ToInt32(ch.Name.ToString());
                    _tableCode = ch.Text;
                } 
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkTable_CheckedChanged");
            }
        }
        #endregion

        private void treeView_Areas_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectNode;
            try
            {
                selectNode = e.Node;

                if (selectNode == null)
                {
                    return;
                }
                if (_PlusOrChange == 1)
                {
                    AddTable_Plus(Convert.ToInt32(selectNode.Name));
                }
                else
                {
                    AddTable_Change(Convert.ToInt32(selectNode.Name));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Areas_NodeMouseClick");
            }
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
    }
}