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
    public partial class frm_SelectEmployeeAdvance : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public TreeNode _EmployeeNode { get; set; }

        public frm_SelectEmployeeAdvance()
        {
            InitializeComponent();
        }

        private void frm_SelectEmployeeAdvance_Load(object sender, EventArgs e)
        {
            try
            {

                AddEmployee();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_SelectEmployeeAdvance_Load");
            }
        }

        //Danh sách nhân viên
        private void AddEmployee()
        {
            List<employee> listEmpls;
            TreeNode nodes;
            try
            {
                if (treeView_Employee.Nodes.Count > 0)
                {
                    treeView_Employee.Nodes.Clear();
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                listEmpls = (from em in _dbContext.employees.ToList() where em.EmployeeRight!=CoffeeHelpers.EmpRight.Administrator.ToString() select em).ToList();

                if (listEmpls != null && listEmpls.Count > 0)
                {
                    foreach (employee  item in listEmpls)
                    {
                        nodes = new TreeNode();
                        nodes.Name = item.EmployeeID.ToString();
                        nodes.Tag = item.EmployeeName.ToString() + "/" + item.Salary;
                        if (item.Sex == "Nam")
                        {
                            nodes.ImageIndex = 0;
                            nodes.SelectedImageIndex = 0;
                        }
                        else if (item.Sex == "Nữ")
                        {
                            nodes.ImageIndex = 1;
                            nodes.SelectedImageIndex = 1;
                        }
                        else
                        {
                            nodes.ImageIndex = 2;
                            nodes.SelectedImageIndex = 2;
                        }
                        nodes.Text = item.EmployeeName.ToString() + " (" + item.EmployeeID + ")";

                        treeView_Employee.Nodes.Add(nodes);
                    }

                    TreeNodeCollection selectnodes = treeView_Employee.Nodes;
                    treeView_Employee.SelectedNode = selectnodes[0];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddEmployee");
            }
        }

        private void treeView_Employee_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                _EmployeeNode = e.Node;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Employee_NodeMouseClick");
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
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Close_Click");
            }
        }

        private void treeView_Employee_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                _EmployeeNode = e.Node;

                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Employee_NodeMouseDoubleClick");
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void frm_SelectEmployeeAdvance_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "frm_SelectEmployeeAdvance_MouseDown");
            }
        }

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