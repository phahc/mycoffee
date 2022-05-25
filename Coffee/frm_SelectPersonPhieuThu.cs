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
    public partial class frm_SelectPersonPhieuThu : DevExpress.XtraEditors.XtraForm
    {
        public mycoffeeEntities _dbContext;
        public TreeNode _EmployeeNode { get; set; }
        public TreeNode _CustomerNode { get; set; }
        public TreeNode _NCCNode { get; set; }
        public int _emp_Cus_NCC;//Nếu bằng 1: Nhân viên; 2: khách hàng; 3: Nhà cung cấp

        private TreeNode selectNode= null;

        public frm_SelectPersonPhieuThu()
        {
            InitializeComponent();
        }

        private void frm_SelectPersonPhieuThu_Load(object sender, EventArgs e)
        {
            try
            {
                if (_emp_Cus_NCC == 1)
                {
                    AddEmployee();
                }
                else if (_emp_Cus_NCC == 2)
                {
                    AddCustomer();
                }
                else
                {
                    AddNCC();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_SelectPersonPhieuThu_Load");
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectNode == null)
                {
                    return;
                }

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
                    foreach (employee item in listEmpls)
                    {
                        nodes = new TreeNode();
                        nodes.Name = item.EmployeeID.ToString();
                        nodes.Tag = item.Address!=null?item.Address:"";
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
                    _EmployeeNode = selectnodes[0];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddEmployee");
            }
        }

        //Danh khách hàng
        private void AddCustomer()
        {
            List<khachhang> listCustomer;
            TreeNode nodes;
            try
            {
                if (treeView_Employee.Nodes.Count > 0)
                {
                    treeView_Employee.Nodes.Clear();
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                listCustomer = (from em in _dbContext.khachhangs select em).ToList();

                if (listCustomer != null && listCustomer.Count > 0)
                {
                    foreach (khachhang item in listCustomer)
                    {
                        nodes = new TreeNode();
                        nodes.Name = item.MAKH.ToString();
                        nodes.Tag = item.DIACHI!=null?item.DIACHI:"";
                        nodes.ImageIndex = 2;
                        nodes.SelectedImageIndex = 2;
                        nodes.Text = item.TENKH;

                        treeView_Employee.Nodes.Add(nodes);
                    }

                    TreeNodeCollection selectnodes = treeView_Employee.Nodes;
                    treeView_Employee.SelectedNode = selectnodes[0];
                    _CustomerNode = selectnodes[0];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddCustomer");
            }
        }

        //Danh sách nhà cung cấp
        private void AddNCC()
        {
            List<madein> listNCC;
            TreeNode nodes;
            try
            {
                if (treeView_Employee.Nodes.Count > 0)
                {
                    treeView_Employee.Nodes.Clear();
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                listNCC = (from em in _dbContext.madeins select em).ToList();

                if (listNCC != null && listNCC.Count > 0)
                {
                    foreach (madein item in listNCC)
                    {
                        nodes = new TreeNode();
                        nodes.Name = item.MadeInID.ToString();
                        nodes.Tag = item.Address!=null?item.Address:"";
                        nodes.ImageIndex = 2;
                        nodes.SelectedImageIndex = 2;
                        nodes.Text = item.MadeInName;

                        treeView_Employee.Nodes.Add(nodes);
                    }

                    TreeNodeCollection selectnodes = treeView_Employee.Nodes;
                    treeView_Employee.SelectedNode = selectnodes[0];
                    _NCCNode = selectnodes[0];
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AddNCC");
            }
        }

        private void treeView_Employee_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                selectNode = e.Node;

                if (_emp_Cus_NCC == 1)
                {
                    _EmployeeNode = e.Node;
                }
                else if (_emp_Cus_NCC == 2)
                {
                    _CustomerNode = e.Node;
                }
                else
                {
                    _NCCNode = e.Node;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_Employee_NodeMouseClick");
            }
        }

        private void treeView_Employee_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                selectNode = e.Node;

                if (_emp_Cus_NCC == 1)
                {
                    _EmployeeNode = e.Node;
                }
                else if (_emp_Cus_NCC == 2)
                {
                    _CustomerNode = e.Node;
                }
                else
                {
                    _NCCNode = e.Node;
                }
                if (selectNode == null)
                {
                    return;
                }

                DialogResult = DialogResult.OK;
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

        private void frm_SelectPersonPhieuThu_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "frm_SelectPersonPhieuThu_MouseDown");
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