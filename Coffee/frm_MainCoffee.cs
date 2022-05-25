using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Coffee.Utils;
using System.Threading;
using TracerX;
using System.Linq;
using System.IO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraBars;
using System.Resources;
using System.Reflection;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Repository;
using Coffee.Reports;
using System.Management;
using Coffee.DataSet;
using System.Net.Mail;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Security.AccessControl;
using Microsoft.Win32;

namespace Coffee
{
    public partial class frm_MainCoffee : DevExpress.XtraEditors.XtraForm
    {

        #region Fields
        mycoffeeEntities _dbContext;
        // Đối tượng Log cho lớp
        private static readonly Logger log = Logger.GetLogger(typeof(frm_MainCoffee));

        // Thông báo user muốn kết thúc chương trình
        private bool exit = false;

        private DataTable _tbSourceTable;//Bàn trống
        private DataTable _tbSourceArea;//Khu vực
        private DataTable _tbSourceListOrder;//Bàn đang bán
        private DataTable _tbSourceOrderDetail;//Chi tiết đơn hàng(bàn)

        private GroupControl Group_Table;
        private PictureEdit Picture_table;
        private RadioButton RadioControl_Area;
        TreeNode selectNodeTable;// Khi chọn vào bàn trống
        int maxOrderID = 0;
        bool _ActiveButtonPay = false;//Trạng thái đã tạo ngân quỹ kế hoạch trong ngày chưa (False: Chưa, True: Có rồi)
        int _default_maxTable = 0;//Số bàn tối đa trên dòng
        string _defaultPassLogin = "";
        string _defaultCodeLogin = "";
        bool _checkCopyRight = false;
        string day_Trial = "";
        string day_TrialRegisterForm = "";

        private List<GroupControl> Group_ListTable = new List<GroupControl>();
        private List<PictureEdit> Picture_ListTable = new List<PictureEdit>();
        private List<RadioButton> Radion_Area = new List<RadioButton>();

        DataTable tbProduct;//Giữ danh sách sản phẩm
        DataTable tbMenu;//Giữ danh mục thự đơn
        List<TreeNode> treeNode;//Giữ các node cha trong tree Sản phẩm

        int areaIDChecked = -1;
        int orderIDSelected = -1;
        string _childNode = "childNode";
        PictureEdit Order_Pre = new PictureEdit();
        CoffeeHelpers.RegisterKeys _registerKey;
        bool _checkHideProduct = false;

        // Timer xuât báo cáo tự động
        private TaskScheduler.TaskScheduler taskScheduler;
        // Đối tượng timer đóng ứng dụng
        private System.Threading.Timer _timerCloseApp = null;
        //Show Sologan
        DevExpress.Utils.WaitDialogForm dlg_sologan = null;

        CoffeeHelpers.Config config;

        decimal _planMoney = 0;
        decimal _totalMoney = 0;
        decimal _creditMoney = 0;
        decimal _payMoney = 0;
        decimal _MoneyPromote = 0;
        bool _receivePlanWork = false;// Trạng thái nhận ca hay không

        private string _skinName = "London Liquid Sky";

        string[] arr_ColorCode = { "Office 2010 Silver", "Caramel", "Stardust", "Dark Side", "Darkroom", "Office 2010 Black", "Pumpkin", "Money Twins", "Office 2010 Blue", "Office 2007 Blue", "Glass Oceans", "Office 2007 Green", "Xmas 2008 Blue", "Liquid Sky", "Summer 2008", "Springtime", "Valentine", "Office 2007 Pink", "London Liquid Sky", "McSkin", "The Asphalt World" };

        private DataSet_HoaDonThanhToan ds = new DataSet_HoaDonThanhToan();

        private company companys;
        private List<company> listCompany;
        private Dictionary<int, int> dic_images;



        #endregion

        #region Columns
        private const string _cAreaID = "AreaID";
        private const string _cAreaCode = "AreaCode";
        private const string _cStatus = "Status";
        private const string _cTableID = "TableID";
        private const string _cTableCode = "TableCode";

        private const string _cID = "ID";
        private const string _cOrderID = "OrderID";
        private const string _cProductName = "ProductName";
        private const string _cProductID = "ProductID";
        private const string _cQuantity = "Quantity";
        private const string _cDate = "Date";
        private const string _cPrice = "Price";
        private const string _cMoneyPromote = "MoneyPromote";
        
        private const string _cPromote = "Promote";
        private const string _cLimit = "Limit";
        private const string _cDVT = "DVT";
        private const string _cInputPrice = "InputPrice";

        private const string _cEmployeeID = "EmPloyeeID";
        private const string _cEmployeeName = "EmployeeName";
        private const string _cMoneyCreadit = "MoneyCredit";

        private const string _cShortName = "ShortName";
        private const string _cProductCode = "ProductCode";
        private const string _cNotes = "Notes";
        private const string _cImageIndex = "ImageIndex";
        private const string _cImage = "Image";

        private const string _cMadeInID = "MadeInID";
        private const string _cProductSkin = "ProductSkin";
        private const string _cMadeInName = "MadeInName";


        private const string _cMenuID = "MenuID";
        private const string _cMenuCode = "MenuCode";

        private const string _cOrderCode = "OrderCode";
        private const string _cTotal_Money = "Total_Money";
        #endregion

        #region My Sologan
        //Login
        private string _first_morningLogin = "làm việc tốt. Đã rạng sáng";//1h sáng - 4h sáng login
        private string _morningLogin = "ngày mới làm việc hiệu quả";//4h sáng - 10h sáng login
        private string _afternoonLogin = "buổi trưa vui vẻ nhé";//10h trưa - 13h chiều
        private string _everningLogin = "buổi chiều nhiều niềm vui";//13h chiều - 18h tối
        private string _nightLogin = "buổi tối làm việc thành công";//18h tối - 22h tối login
        private string _nightAfterLogin = "quản lý tốt, đêm đã về khuya";//22h khuya - 1h sáng

        //Logout
        private string _first_morningLogout = "Một ngày làm việc vất vả. Gửi lời chúc ngon giấc đến";//1h sáng - 4h sáng login
        private string _morningLogout = "Buổi sáng tốt lành.Hẹn gặp lại";//4h sáng - 10h sáng login
        private string _afternoonLog0ut = "Chúc buổi trưa ngon miệng nhé";//10h trưa - 13h chiều
        private string _everningLogout = "Hẹn gặp lại";//13h chiều - 18h tối
        private string _nightLogout = "Buổi tối tốt lành nhé";//18h tối - 22h tối login
        private string _nightAfterLogout = "Khuya rồi.Một đêm ngon giấc nhé";//22h khuya - 1h sáng

        #endregion

        #region Form Method
        public frm_MainCoffee()
        {
            InitializeComponent();

            //Lấy màu cho ứng dụng
            config = CoffeeHelpers.LoadConfig();
            for (int i = 0; i < arr_ColorCode.Length; i++)
            {
                if (config.ApplicationColor.Trim() == arr_ColorCode[i].Trim())
                {
                    _skinName = arr_ColorCode[i].Trim();
                    break;
                }
            }

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = _skinName;

        }

        private void frm_MainCoffee_Load(object sender, EventArgs e)
        {
            TaskScheduler.TaskScheduler.TriggerItem triggerItem;
            CoffeeHelpers.DatabaseSettings dbSettings;
            frm_Login dlgLogin;
            DateTime dtNow, dtBegin, dtEnd;
            DateTime dtLoginTime = DateTime.Now;

            try
            {
                //Kiểm tra bản quyền
                _registerKey = CoffeeHelpers.LoadRegisterKey();
                checkCopyRight(_registerKey);

                dtNow = DateTime.Now;
                dtBegin = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                dtEnd = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);

                dbSettings = CoffeeHelpers.LoadDatabaseSettings();
                if (dbSettings == null)
                {
                    XtraMessageBox.Show("Cấu hình kết nối database chưa được khai báo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                else
                {
                    if (dbSettings.CheckPrincipal)
                        CoffeeHelpers.ConnectionString = string.Format("user id={0};Password={1};data source={2};initial catalog={3};", dbSettings.LoginName, dbSettings.Password, dbSettings.PrincipalServer, dbSettings.DatabaseName);
                    else
                        CoffeeHelpers.ConnectionString = string.Format("data source={0};initial catalog={1};Integrated Security=SSPI;", dbSettings.PrincipalServer, dbSettings.DatabaseName);
                }
                //--- Hiển thị xtraMessageBox với font là Times New Roman
                DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                config = CoffeeHelpers.LoadConfig();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
    
                companys = new company();

                listCompany = (from cf in _dbContext.companies.ToList() select cf).ToList();

                // insert dữ liệu giả
                if (listCompany == null || listCompany.Count <= 0)
                {
                    companys.CompanyName = "Coffee_";
                    companys.Address = " TP Hồ Chí Minh";
                    companys.Phone = "083 123456";
                    companys.Fax = "123345677";
                    companys.StartTime = DateTime.Now.ToLocalTime();
                    companys.EndTime = DateTime.Now.ToLocalTime();
                    companys.MaSoThue = "1234566777888";

                    _dbContext.companies.Add(companys);
                    _dbContext.SaveChanges();

                }
                else
                {
                    companys = listCompany.FirstOrDefault();
                }

                //--- Mở form đăng nhập
                dlgLogin = new frm_Login();
                dlgLogin._Config = config;
                dlgLogin.lbl_Register = day_Trial;
                dlgLogin.Text = "Đăng Nhập - " + companys.CompanyName;
                if (dlgLogin.ShowDialog() == DialogResult.OK)
                {
                    //Ghi log
                    WriteLog("Vào hệ thống");

                    log.Info("Lúc " + DateTime.Now + ". Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") đã vào hệ thống");
                }
                else
                {
                    this.Close();
                    return;
                }

                // Gán tên cho thread chính
                Thread.CurrentThread.Name = "MainThread";

                // Không cho phép dữ liệu chuẩn trong text file
                Logger.StandardData.TextFileTraceLevel = TracerX.TraceLevel.Off;

                // Cấu hình ghi log cho text file
                Logger.TextFileLogging.Directory = @"%EXEDIR%\Logs";
                Logger.TextFileLogging.AppendIfSmallerThanMb = 1;
                Logger.TextFileLogging.MaxSizeMb = 10;
                Logger.TextFileLogging.Archives = 99;
                Logger.TextFileLogging.CircularStartSizeKb = 0;
                Logger.TextFileLogging.CircularStartDelaySeconds = 0;
                Logger.Root.TextFileTraceLevel = TracerX.TraceLevel.Info;
                Logger.TextFileLogging.FormatString = "{time:MM/dd/yyyy HH:mm:ss.fff} {level} {thname} {logger}+{method} {ind}{msg}";
                Logger.TextFileLogging.Open();

                // Không cho phép dữ liệu chuẩn trong binary file
                Logger.StandardData.FileTraceLevel = TracerX.TraceLevel.Off;
                // Cấu hình ghi log cho binary file
                Logger.FileLogging.Directory = @"%EXEDIR%\Logs";
                Logger.FileLogging.AppendIfSmallerThanMb = 1;
                Logger.FileLogging.MaxSizeMb = 10;
                Logger.FileLogging.Archives = 99;
                Logger.FileLogging.CircularStartSizeKb = 0;
                Logger.FileLogging.CircularStartDelaySeconds = 0;
                Logger.Root.FileTraceLevel = TracerX.TraceLevel.Info;
                Logger.FileLogging.Open();

                // Ẩn mã hệ thống
                if (CoffeeHelpers.EmpLogin.EmpRight == CoffeeHelpers.EmpRight.Administrator)
                {
                    ribbonPageGroup_SystemCode.Visible = true;//Nếu là administrator thì hiển thị mã hệ thống
                }
                // Người dùng
                if (CoffeeHelpers.EmpLogin.EmpRight == CoffeeHelpers.EmpRight.Operator)
                {
                    ribbonPage_Config.Visible = false;
                    ribbonPage_Create.Visible = false;
                    ribbonPage_Report.Visible = false;

                    ribbonPageGroup_Tool_Employee.Visible = false;
                    barButtonItem_DSThuChi.Visibility = BarItemVisibility.Never;
                    ribbonPageGroup_Tool_Plan.Visible = false;
                }

                this.Text += " " + companys.CompanyName + " - " + CoffeeHelpers.EmpLogin.EmployeeCode + " (" + CoffeeHelpers.GetEmployeeRightTitle(CoffeeHelpers.EmpLogin.EmpRight) + ") " + day_Trial;

                if (day_Trial == "")
                {
                    //Không hiện button đăng kí bản quyền
                    barButtonItem_CopyRight.Visibility = BarItemVisibility.Never;
                }

                if (config.ShowPlanMoney == false)
                {
                    // Ẩn thông tin doanh thu
                    panel_PlanMoney.Visible = false;
                }
                else
                {
                    panel_PlanMoney.Visible = true;
                }
                if (config.ShowDetailPlan == false)
                {
                    //Ẩn thông tin chi tiết kế hoạch ngày
                    groupControl_PlanDay.Visible = false;
                }
                else
                {
                    groupControl_PlanDay.Visible = true;
                }

                // Mã hệ thống
                barEditItem_SystemCode.EditValue = GetCPUId();

                // Giữ lại password khi login
                _defaultPassLogin = dlgLogin._savePassWord;
                _defaultCodeLogin = dlgLogin._saveCodeLogin;

                // Đổi tên đăng nhập chỉ 1 lần
                if (dlgLogin._changEmployeeCode == true)
                {
                    btn_updateLoginName.Visibility = BarItemVisibility.Never;//bar đổi tên đăng nhập
                }
                else
                {
                    btn_updateLoginName.Visibility = BarItemVisibility.Always;
                }

                // Khởi tạo tableSource danh sách thu gọn của chi tiết đơn hàng
                _tbSourceOrderDetail = CreateOrderProductShortTableStruct();

                // Load danh sách khu vực
                LoadAreaData();

                // Load danh sách sản phẩm
                Load_CrateProduct();

                //Load cảnh báo có nhận ca đang chờ giao hay không
                LoadReceive_PlanWork();

                // Load thông tin doanh thu của từng nhân vien trực
                Load_CreditOfEmployee();

                // Khởi tạo timer xuất báo cáo tự động
                taskScheduler = new TaskScheduler.TaskScheduler();
                triggerItem = new TaskScheduler.TaskScheduler.TriggerItem();
                triggerItem.Tag = null;
                triggerItem.StartDate = DateTime.Now;
                triggerItem.EndDate = DateTime.MaxValue;
                triggerItem.TriggerTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).Add(config.PrintReportAtTime);
                triggerItem.TriggerSettings.Daily.Interval = 1;
                triggerItem.OnTrigger += new TaskScheduler.TaskScheduler.TriggerItem.OnTriggerEventHandler(SchedulerCallback);
                triggerItem.Enabled = true;
                taskScheduler.AddTrigger(triggerItem);

                // Khởi tạo timer gởi mail tự động
                List<mailreceiver> mailRecievers =(from mail in _dbContext.mailreceivers.ToList() where mail.AutoSend == 1 select mail).ToList();
                foreach (mailreceiver mailReciever in mailRecievers)
                {
                    if (mailReciever.AutoSendDate.HasValue == true)
                    {
                        triggerItem = new TaskScheduler.TaskScheduler.TriggerItem();
                        triggerItem.Tag = mailReciever.Email;
                        triggerItem.StartDate = DateTime.Now;
                        triggerItem.EndDate = DateTime.MaxValue;
                        triggerItem.TriggerTime = mailReciever.AutoSendDate.Value;
                        triggerItem.TriggerSettings.Daily.Interval = 1;
                        triggerItem.OnTrigger += new TaskScheduler.TaskScheduler.TriggerItem.OnTriggerEventHandler(SchedulerCallback);
                        triggerItem.Enabled = true;
                        taskScheduler.AddTrigger(triggerItem);
                    }
                }
                taskScheduler.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_MainCoffee_Load");
            }
        }

        private void frm_MainCoffee_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (CoffeeHelpers.EmpLogin != null)
                {
                    if (_receivePlanWork == true)
                    {
                        var result = XtraMessageBox.Show("Bạn chưa giao ca. Bạn có muốn giao ca trước khi thoát không?", "Thông Báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            StartRestarter(getSologan_Logout(DateTime.Now), 320, 50);//Tắt không giao ca
                        }
                        else if (result == DialogResult.Yes)// Tiến hành giao ca rồi thoát
                        {
                            _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                            money_trading money_tradings = (from md in _dbContext.money_trading.ToList() where md.ReceiveByEmployeeID == CoffeeHelpers.EmpLogin.EmployeeID select md).OrderByDescending(m => m.ReceiveDate).FirstOrDefault();
                            decimal _CreditMoney = money_tradings.MoneyCredit;

                            //Thêm thông tin ca mới
                            money_tradings = new money_trading();
                            money_tradings.EmployeeID = CoffeeHelpers.EmpLogin.EmployeeID;
                            money_tradings.TotalMoney = _CreditMoney;
                            money_tradings.MoneyCredit = _CreditMoney;
                            money_tradings.ReceiveByEmployeeID = CoffeeHelpers.EmpLogin.EmployeeID;
                            money_tradings.ReceiveByEmployeeName = CoffeeHelpers.EmpLogin.EmployeeName;
                            money_tradings.StartDate = DateTime.Now;
                            //moneys.EndDate = null;
                            money_tradings.Status = 1;

                            _dbContext.money_trading.Add(money_tradings);
                            _dbContext.SaveChanges();

                            //Ghi log
                            WriteLog("Đã giao ca thành công với số tiền bàn giao là " + money_tradings.MoneyCredit + " (vnđ)");

                            log.Info("Lúc " + DateTime.Now + ". Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") đã giao ca thành công với số tiền bàn giao là " + money_tradings.MoneyCredit + " (vnđ)");

                            string _messges = "Bạn đã bàn giao xong số tiền " + money_tradings.MoneyCredit + " (vnđ), " + getSologan_Logout(DateTime.Now);
                            //Tiến hành Logout
                            StartRestarter(_messges, 570, 50);
                            //Kết thúc mọi xử lý
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                            Application.Exit();
                        }
                        else
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    else// TÌnh trạng chưa nhận ca
                    {
                        if (XtraMessageBox.Show("Bạn có chắc chắn muốn tắt chương trình?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            e.Cancel = true;
                            return;
                        }
                        else
                        {
                            StartRestarter(getSologan_Logout(DateTime.Now), 320, 50);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_MainCoffee_FormClosing");
            }
        }

        private void frm_MainCoffee_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (areaIDChecked != -1)
                {
                    //Load danh sách bàn đang bán
                    //LoadOrderTableData(areaIDChecked);
                    LoadOrderTable_FromTableSource(areaIDChecked);
                }
                if (orderIDSelected != -1)
                {
                    //Thao tác click chọn đơn hàng
                    SelectOrder_Click(orderIDSelected);

                    //Thông tin chi tiết đơn hàng
                    LoadOrderAndProduct(orderIDSelected);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_MainCoffee_SizeChanged");
            }
        }
        #endregion

        #region Helpers

        #region Function
        //Phân quyền theo nhân viên
        private void SetRightForEmployees()
        {
            List<managermenu> menus;
            managerright rights;
            try
            {
                //Ẩn tất cả
                ribbonPage_Config.Visible = false;
                ribbonPage_Create.Visible = false;
                ribbonPage_Tool.Visible = false;
                ribbonPage_Report.Visible = false;
                ribbonPage_Skin.Visible = false;

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                menus = (from mn in _dbContext.managermenus.ToList() where mn.EmployeeID == CoffeeHelpers.EmpLogin.EmployeeID select mn).ToList();
                if (menus != null && menus.Count > 0)//Nếu tồn tại menu này
                {
                    int i = 1;// vị trí menu chính
                    foreach (managermenu mn in menus)//Duyệt menu con
                    {
                        if (mn.Status == 1)
                        {
                            switch (i)
                            {
                                case 1:
                                    ribbonPage_Config.Visible = true;
                                    break;
                                case 2:
                                    ribbonPage_Create.Visible = true;
                                    break;
                                case 3:
                                    ribbonPage_Tool.Visible = true;
                                    break;
                                case 4:
                                    ribbonPage_Report.Visible = true;
                                    break;
                                case 5:
                                    ribbonPage_Skin.Visible = true;
                                    break;
                            }
                            rights = (from right in _dbContext.managerrights.ToList() where right.MenuID == mn.ID select right).FirstOrDefault();


                            if (rights != null )
                            {
                           
                            }
                        }

                        i++;
                    }
                }
                else
                {
                    //Chưa phân quyền ẩn tất cả
                    ribbonPage_Config.Visible = false;
                    ribbonPage_Create.Visible = false;
                    ribbonPage_Tool.Visible = false;
                    ribbonPage_Report.Visible = false;
                    ribbonPage_Skin.Visible = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SetRightForEmployees");
            }
        }

        /// <summary>
        /// Tạo sologan khi login
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string getSologan_Login(DateTime dt)
        {
            string _sologan = _first_morningLogin;
            string _employeeName = "Chúc " + CoffeeHelpers.EmpLogin.EmployeeName + " ";
            try
            {
                if (dt.Hour >= 1 && dt.Hour < 4)
                {
                    _sologan = _employeeName + _first_morningLogin;//Rạng sáng
                }
                else if (dt.Hour >= 4 && dt.Hour < 10)
                {
                    _sologan = _employeeName + _morningLogin;//Sáng
                }
                else if (dt.Hour >= 10 && dt.Hour < 13)
                {
                    _sologan = _employeeName + _afternoonLogin;//Trưa
                }
                else if (dt.Hour >= 13 && dt.Hour < 18)
                {
                    _sologan = _employeeName + _everningLogin;//chiều
                }
                else if (dt.Hour >= 18 && dt.Hour < 22)
                {
                    _sologan = _employeeName + _nightLogin;//Tối
                }
                else
                {
                    _sologan = _employeeName + _nightAfterLogin;//Khuya
                }
                return _sologan;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "getSologan_Login");
                return "";
            }
        }

        /// <summary>
        /// Tạo sologan khi logout
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private string getSologan_Logout(DateTime dt)
        {
            string _sologan = _first_morningLogout;
            string _employeeName = " " + CoffeeHelpers.EmpLogin.EmployeeName;
            try
            {
                if (dt.Hour >= 1 && dt.Hour < 4)
                {
                    _sologan = _first_morningLogout + _employeeName;//Rạng sáng
                }
                else if (dt.Hour >= 4 && dt.Hour < 10)
                {
                    _sologan = _morningLogout + _employeeName;//Sáng
                }
                else if (dt.Hour >= 10 && dt.Hour < 13)
                {
                    _sologan = _afternoonLog0ut + _employeeName;//Trưa
                }
                else if (dt.Hour >= 13 && dt.Hour < 18)
                {
                    _sologan = _everningLogout + _employeeName;//chiều
                }
                else if (dt.Hour >= 18 && dt.Hour < 22)
                {
                    _sologan = _nightLogout + _employeeName;//Tối
                }
                else
                {
                    _sologan = _nightAfterLogout + _employeeName;//Khuya
                }
                return _sologan;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "getSologan_Logout");
                return "";
            }
        }

        private void Logout()
        {
            money_trading money_tradings;
            try
            {

                frm_LogOut Logout = new frm_LogOut();

                Logout._activeLogout = _ActiveButtonPay;
                Logout._receivePlanWork = _receivePlanWork;
                Logout._cancel = false;
                Logout.Text = "Giao Ca";
                if (Logout.ShowDialog() == DialogResult.OK)
                {
                    decimal _CreditMoney = 0;
                    if (Logout._cancel == false)//Chọn thao tác giao ca. không phải thao tác hủy hành động(_cancel==true)
                    {
                        _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                        money_tradings = (from md in _dbContext.money_trading.ToList() where md.ReceiveByEmployeeID == CoffeeHelpers.EmpLogin.EmployeeID select md).OrderByDescending(m => m.ReceiveDate).FirstOrDefault();
                        _CreditMoney = money_tradings.MoneyCredit;

                        //Thêm thông tin ca mới
                        money_tradings = new money_trading();
                        money_tradings.EmployeeID = CoffeeHelpers.EmpLogin.EmployeeID;
                        money_tradings.TotalMoney = _CreditMoney;
                        money_tradings.MoneyCredit = _CreditMoney;
                        money_tradings.ReceiveByEmployeeID = CoffeeHelpers.EmpLogin.EmployeeID;
                        money_tradings.ReceiveByEmployeeName = CoffeeHelpers.EmpLogin.EmployeeName;
                        money_tradings.StartDate = DateTime.Now;
                        //moneys.EndDate = null;
                        money_tradings.Status = 1;

                        _dbContext.money_trading.Add(money_tradings);
                        _dbContext.SaveChanges();

                        //Ghi log
                        WriteLog("Đã giao ca thành công với số tiền bàn giao là " + money_tradings.MoneyCredit + " (vnđ)");

                        log.Info("Lúc " + DateTime.Now + ". Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") đã giao ca thành công với số tiền bàn giao là " + money_tradings.MoneyCredit + " (vnđ)");

                        string _messges = "Bạn đã bàn giao xong số tiền " + money_tradings.MoneyCredit + " (vnđ), " + getSologan_Logout(DateTime.Now);
                        //Tiến hành Logout
                        StartRestarter(_messges, 570, 50);
                        //Kết thúc mọi xử lý
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        Application.Exit();

                    }//Nếu chọn thao tác Hủy thì sẽ không làm gì
                }
                else
                {
                    //Tiến hành Logout
                    StartRestarter("Vui lòng chờ...", 167, 50);
                    //Kết thúc mọi xử lý
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Logout");
            }
        }

        private void StartRestarter(string _sologan, int width, int height)
        {
            try
            {
                //Ghi log
                WriteLog("Đăng xuất");

                log.Info("Lúc " + DateTime.Now + ". Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") đã đăng xuất");

                //dlg_sologan = new DevExpress.Utils.WaitDialogForm("Đang tắt chương trình", _sologan, new Size(520, 50));
                //_timerCloseApp = new System.Threading.Timer(TimerCloseAppCallback, null, 5000, System.Threading.Timeout.Infinite);

                //Thread.Sleep(5000);
                string exePath = Application.StartupPath + @"\Form_LogOut.exe";
                // Xuất ra file log
                log.Info("!!!!!!!!!!!!!!!!!!!!!!!!! Bắt đầu khởi động ứng dụng Form_LogOut !!!!!!!!!!!!!!!!!!!!!!!!!");
                System.Diagnostics.Process.Start(exePath, "");
            }
            catch (Exception ex)
            {
                // Xuất ra file log
                log.Error("Hàm StartRestarter đã phát ra Exception ", ex.Message);
            }
        }

        //Danh sách khu vực
        /// <summary>
        /// Danh sách khu vực
        /// </summary>
        private void LoadAreaData()
        {
            List<area> areas;
            int line_y = xtraScrollable_Area.Height / 5;
            int line_x = 0;
            xtraScrollable_Area.VerticalScroll.Visible = false;
            try
            {
                if (xtraScrollable_Area.Controls.Count > 0)
                {
                    xtraScrollable_Area.Controls.Clear();
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                areas = (from ar in _dbContext.areas.ToList() where ar.Status == 1 orderby ar.AreaID select ar).ToList();

                int loop = 1;
                if (areas != null && areas.Count > 0)
                {
                    foreach (area ar in areas)
                    {
                        RadioControl_Area = new RadioButton();

                        Point p = new Point(((line_x) * 100) + 10, line_y);
                        RadioControl_Area.Location = p;
                        RadioControl_Area.Text = ar.AreaCode.ToString();
                        RadioControl_Area.Name = "Area" + ar.AreaID.ToString();
                        Font f = new Font("times new roman", 11.0f, System.Drawing.FontStyle.Bold);
                        RadioControl_Area.Font = f;
                        RadioControl_Area.ForeColor = Color.FromArgb(205, 38, 38);
                        RadioControl_Area.Width = 100;
                        RadioControl_Area.Height = 20;
                        line_x++;

                        RadioControl_Area.CheckedChanged += new EventHandler(RadioChecked_Change);
                        Radion_Area.Add(RadioControl_Area);
                        xtraScrollable_Area.Controls.Add(RadioControl_Area);

                        // Cấu hình hệ thống cho phép số khu vực tối đa
                        if (loop == config.MaxArea)
                        {
                            break;
                        }
                        loop++;
                    }

                    Radion_Area[0].Checked = true;
                    areaIDChecked = Convert.ToInt32(Radion_Area[0].Name.Substring(4));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadAreaData");
            }
        }

        //Danh sách bàn đang bán
        /// <summary>
        /// Danh sách bàn đang bán
        /// </summary>
        /// <param name="areaID"></param>
        /// 
        private void LoadOrderTableData(int areaID)
        {
            // List<ListOrder> listOrders;
            int line_y = 1;
            int line_x = 0;
            int loop = 0;
            DataRow newRow;


            try
            {
                //Chieu rong cua xtraScrollable cho phep chu toi da ban co kich thuoc 105x105
                int maxTable = xtraScrollable_TableActive.Width / 95;
                _default_maxTable = maxTable;

                _tbSourceListOrder = CreateOrderTableStruct();
                //Xóa bàn nếu có
                if (xtraScrollable_TableActive.Controls.Count > 0)
                {
                    for (int i = 0; i < xtraScrollable_TableActive.Controls.Count; i++)
                    {
                        xtraScrollable_TableActive.Controls.RemoveByKey(xtraScrollable_TableActive.Controls[i].Name);
                        i--;
                    }
                }

                Group_ListTable = null;
                Group_ListTable = new List<GroupControl>();

                Picture_ListTable = null;
                Picture_ListTable = new List<PictureEdit>();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                var listOrders = (from o in _dbContext.listorders.ToList()
                                  where o.Status == 1 && o.area_table.AreaID == areaID && o.area_table.Status == 1 && o.area_table.Empty == 2
                                  orderby o.TableID
                                  select new
                                  {
                                      o.OrderID,
                                      o.area_table.TableID,
                                      o.area_table.TableCode,
                                      o.area_table.AreaID,
                                      o.Ordercode,
                                      o.Total_Money
                                  });

                if (listOrders != null)
                {
                    int i = 2;
                    foreach (var item in listOrders)
                    {
                        //Số bàn tối đa cho phép trên dòng
                        if (loop == maxTable)
                        {
                            maxTable = _default_maxTable * i;

                            line_x = 0;// Tra hoanh do ve 0
                            line_y = (line_y + 97) + 5;//Tung do tang len ban mot kich thuoc chieu cao cua hang truoc

                            //--Hang ban thu may
                            i++;
                        }

                        Group_Table = new GroupControl();
                        Picture_table = new PictureEdit();

                        Point p = new Point(((line_x) * 97) + 5, line_y);
                        Group_Table.Location = p;
                        Group_Table.Text = item.TableCode;
                        Group_Table.Name = "Order" + item.OrderID.ToString();
                        Group_Table.Tag = item.OrderID.ToString();
                        Group_Table.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        Font f = new Font("times new roman", 11.0f, System.Drawing.FontStyle.Bold);
                        Group_Table.AppearanceCaption.Font = f;
                        Group_Table.AppearanceCaption.ForeColor = Color.Maroon;
                        Group_Table.Width = 97;
                        Group_Table.Height = 100;
                        Group_Table.BackColor = System.Drawing.Color.Transparent;
                        Group_Table.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;

                        Picture_ListTable.Add(Picture_table);
                        Group_Table.Controls.Add(Picture_table);
                        Picture_table.Name = "Image" + item.OrderID.ToString();
                        Picture_table.Tag = item.TableCode.ToLower().ToString();
                        Picture_table.Dock = DockStyle.Fill;
                        Picture_table.Image = Coffee.Properties.Resources.coffee_table;
                        Picture_table.Properties.ShowMenu = false;//Không cho click phải chuột
                        Picture_table.BackColor = System.Drawing.Color.Transparent;
                        Picture_table.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        Picture_table.Click += new EventHandler(TableActive_Click);
                        Picture_table.MouseUp += new MouseEventHandler(pictureEdit_MouseUp);//Sự kiện showpopup khi clcik

                        Group_ListTable.Add(Group_Table);
                        xtraScrollable_TableActive.Controls.Add(Group_Table);

                        Group_Table.LookAndFeel.UseDefaultLookAndFeel = false;
                        Group_Table.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

                        line_x++;// Tang hoanh do

                        // Lap so ban
                        loop++;

                        //Chọn đơn hàng
                        SelectOrder_Click(item.OrderID);

                        //Thông tin chi tiết đơn hàng
                        LoadOrderAndProduct(item.OrderID);

                        //Giữ lại trong tableSource
                        newRow = _tbSourceListOrder.NewRow();
                        newRow[_cOrderID] = item.OrderID;
                        newRow[_cOrderCode] = item.Ordercode;
                        newRow[_cTableCode] = item.TableCode;
                        newRow[_cTableID] = item.TableID;
                        newRow[_cAreaID] = item.AreaID;
                        newRow[_cTotal_Money] = item.Total_Money;

                        _tbSourceListOrder.Rows.Add(newRow);

                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadAreaData");
            }
        }

        private void LoadOrderTable_FromTableSource(int areaID)
        {
            // List<ListOrder> listOrders;
            int line_y = 1;
            int line_x = 0;
            int loop = 0;

            try
            {
                //Chieu rong cua xtraScrollable cho phep chu toi da ban co kich thuoc 105x105
                int maxTable = xtraScrollable_TableActive.Width / 95;
                _default_maxTable = maxTable;

                //Xóa bàn nếu có
                if (xtraScrollable_TableActive.Controls.Count > 0)
                {
                    for (int i = 0; i < xtraScrollable_TableActive.Controls.Count; i++)
                    {
                        xtraScrollable_TableActive.Controls.RemoveByKey(xtraScrollable_TableActive.Controls[i].Name);
                        i--;
                    }
                }

                Group_ListTable = null;
                Group_ListTable = new List<GroupControl>();

                Picture_ListTable = null;
                Picture_ListTable = new List<PictureEdit>();

                // _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                //var listOrders = (from o in _dbContext.ListOrders
                //                  where o.Status == true && o.Area_Table.AreaID == areaID && o.Area_Table.Status == 1 && o.Area_Table.Empty == false
                //                  orderby o.TableID
                //                  select new
                //                  {
                //                      o.OrderID,
                //                      o.Area_Table.TableID,
                //                      o.Area_Table.TableCode,
                //                      o.Area_Table.AreaID,
                //                      o.OrderCode,
                //                      o.Total_Money
                //                  });

                if (_tbSourceListOrder.Rows.Count > 0)
                {
                    int i = 2;
                    foreach (DataRow row in _tbSourceListOrder.Rows)
                    {
                        //Số bàn tối đa cho phép trên dòng
                        if (loop == maxTable)
                        {
                            maxTable = _default_maxTable * i;

                            line_x = 0;// Tra hoanh do ve 0
                            line_y = (line_y + 97) + 5;//Tung do tang len ban mot kich thuoc chieu cao cua hang truoc

                            //--Hang ban thu may
                            i++;
                        }

                        Group_Table = new GroupControl();
                        Picture_table = new PictureEdit();

                        Point p = new Point(((line_x) * 97) + 5, line_y);
                        Group_Table.Location = p;
                        Group_Table.Text = row[_cTableCode].ToString();
                        Group_Table.Name = "Order" + row[_cOrderID].ToString();
                        Group_Table.Tag = row[_cOrderID].ToString();
                        Group_Table.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                        Font f = new Font("times new roman", 11.0f, System.Drawing.FontStyle.Bold);
                        Group_Table.AppearanceCaption.Font = f;
                        Group_Table.AppearanceCaption.ForeColor = Color.Maroon;
                        Group_Table.Width = 97;
                        Group_Table.Height = 100;
                        Group_Table.BackColor = System.Drawing.Color.Transparent;
                        Group_Table.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;

                        Picture_ListTable.Add(Picture_table);
                        Group_Table.Controls.Add(Picture_table);
                        Picture_table.Name = "Image" + row[_cOrderID].ToString();
                        Picture_table.Tag = row[_cTableCode].ToString().ToLower();
                        Picture_table.Dock = DockStyle.Fill;
                        Picture_table.Image = Coffee.Properties.Resources.coffee_table;
                        Picture_table.Properties.ShowMenu = false;//Không cho click phải chuột
                        Picture_table.BackColor = System.Drawing.Color.Transparent;
                        Picture_table.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                        Picture_table.Click += new EventHandler(TableActive_Click);
                        Picture_table.MouseUp += new MouseEventHandler(pictureEdit_MouseUp);//Sự kiện showpopup khi clcik

                        Group_ListTable.Add(Group_Table);
                        xtraScrollable_TableActive.Controls.Add(Group_Table);

                        Group_Table.LookAndFeel.UseDefaultLookAndFeel = false;
                        Group_Table.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

                        line_x++;// Tang hoanh do

                        // Lap so ban
                        loop++;

                        //Chọn đơn hàng
                        SelectOrder_Click(Convert.ToInt32(row[_cOrderID]));

                        //Thông tin chi tiết đơn hàng
                        LoadOrderAndProduct(Convert.ToInt32(row[_cOrderID]));
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadOrderTable_FromTableSource");
            }
        }

        //Load danh sách bàn trống
        /// <summary>
        /// Load danh sách bàn trống
        /// </summary>
        /// <param name="areaID"></param>
        private void LoadListTableEmpty(int areaID)
        {
            List<area_table> area_tbl;
            DataRow row;
            try
            {
                //Khởi tạo tbSource
                _tbSourceTable = CreateArea_TableStruct();

                treeView_TableEmpty.Nodes.Clear();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                area_tbl = (from tb in _dbContext.area_table.ToList() where tb.AreaID == areaID && tb.Empty == 1 select tb).ToList();

                if (area_tbl != null && area_tbl.Count > 0)
                {
                    foreach (var item in area_tbl)
                    {
                        treeView_TableEmpty.Nodes.Add(item.TableID.ToString(), item.TableCode, item.ImageIndex, item.ImageIndex);

                        row = _tbSourceTable.NewRow();
                        row[_cTableID] = item.TableID;
                        row[_cTableCode] = item.TableCode;
                        row[_cAreaID] = item.AreaID;
                        row[_cStatus] = item.Status;
                        row[_cImageIndex] = item.ImageIndex;

                        _tbSourceTable.Rows.Add(row);

                    }

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadListTableEmpty");
            }
        }

        #region PictureEdit Event

        private void pictureEdit_MouseUp(object sender, MouseEventArgs e)
        {
            List<order_detail> orderDetail;
            try
            {

                barButtonItem_Plus.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_Split.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_Pay.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_CancelOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (e.Button == MouseButtons.Left && _ActiveButtonPay == true)
                {
                    orderDetail = (from or in _dbContext.order_detail.ToList() where or.OrderID == orderIDSelected select or).ToList();
                    if (orderDetail != null && orderDetail.Count > 0)
                    {
                        barButtonItem_Pay.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if (_ActiveButtonPay == true)
                    {
                        if (gridView_Order.RowCount <= 0)//Trạng thái thanh toán. Nếu chưa có sản phẩm nào thì mờ đi
                        {
                            btn_Pay.Enabled = false;
                            barButtonItem_Pay.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                        else
                        {
                            btn_Pay.Enabled = true;
                            barButtonItem_Pay.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                    }
                    else
                    {
                        barButtonItem_Pay.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    barButtonItem_Plus.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem_Split.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem_CancelOrder.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }

                Point pt = new Point(Control.MousePosition.X, Control.MousePosition.Y + 35);//Lệch xuống
                popupMenu_OrderTable.ShowPopup(pt);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "pictureEdit_MouseUp");
            }
        }

        private void TableActive_Click(object sender, EventArgs e)
        {

            try
            {
                PictureEdit image = sender as PictureEdit;
                int orID = Convert.ToInt32(image.Name.Substring(5));
                orderIDSelected = orID;
                if (image != null)
                {
                    if (Order_Pre != null)
                    {
                        Order_Pre.Image = Coffee.Properties.Resources.coffee_table;
                    }
                    Order_Pre = image;
                    image.Image = Coffee.Properties.Resources.Notary_icon;
                    groupControl_OrderDetail.Text = "Nội dung thực đơn " + image.Tag;

                    //Thông tin chi tiết đơn hàng
                    LoadOrderAndProduct(orderIDSelected);

                    if (gridView_Order.RowCount <= 0)//Trạng thái thanh toán. Nếu chưa có sản phẩm nào thì mờ đi
                    {
                        btn_Pay.Enabled = false;
                    }
                    else
                    {
                        btn_Pay.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "TableActive_Click");
            }
        }

        #endregion

        //Load thông tin  đơn hàng
        private void LoadOrderAndProduct(int OrderID)
        {
            DataRow newRow;     
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                _tbSourceOrderDetail = CreateOrderProductShortTableStruct();
                _MoneyPromote = 0;
                // Tổng tiền
                var order = (from o in _dbContext.listorders.ToList() where o.OrderID == OrderID && o.Status == 1 select o).FirstOrDefault();
                decimal TotalMoney = 0;
                if (order != null)
                {
                    TotalMoney = (decimal)order.Total_Money;
                }

                // Thêm thông tin chi tiết
                var order_details = (from p in _dbContext.order_detail.ToList()
                                     where p.OrderID == OrderID
                                     group p by p.ProductID into gr
                                     select new
                                     {
                                         pKey = gr.Key,
                                         Quantity = gr.Sum(g => g.Quantity),
                                         SumMoney=gr.Sum(g=>g.Price)
                                     }).OrderByDescending(o => o.Quantity);// Giảm theo số lượng

                int _isCount = _tbSourceOrderDetail.Rows.Count;
                if (order_details != null)
                {
                    foreach (var item in order_details)
                    {
                        var rowData = (from p in _dbContext.products.ToList()
                                       where p.ProductID == item.pKey
                                       select p).FirstOrDefault();

                        var details = (from p in _dbContext.order_detail.ToList()
                                       where p.ProductID == item.pKey && p.Promote == "Khuyến mãi" && p.OrderID == orderIDSelected
                                       group p by p.ProductID into gr
                                       select new
                                       {
                                           pKey = gr.Key,
                                           SumMoney = gr.Sum(g => g.Price),
                                           SumMoneyPromote = gr.Sum(g => g.PricePromote)
                                       }).FirstOrDefault();// Giảm theo số lượng

                        _isCount++;
                        newRow = _tbSourceOrderDetail.NewRow();
                        newRow[_cID] = _isCount;
                        newRow[_cOrderID] = OrderID;
                        newRow[_cProductID] = rowData.ProductID;
                        newRow[_cProductName] = rowData.ProductName;
                        newRow[_cQuantity] = item.Quantity;
                        newRow[_cPrice] = item.SumMoney;
                        if (details != null)
                        {
                            newRow[_cMoneyPromote] = details.SumMoneyPromote;
                            _MoneyPromote = _MoneyPromote + details.SumMoneyPromote;
                        }
                        else
                        {
                            newRow[_cMoneyPromote] = 0;
                        }

                        _tbSourceOrderDetail.Rows.Add(newRow);
                    }

                    gridControl_Order.DataSource = _tbSourceOrderDetail;
                   
                }

                _payMoney = TotalMoney < 0 ? 0 : TotalMoney;
                if (_payMoney == 0)
                {
                    lbl_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToString(_payMoney));
                }
                else
                {
                    lbl_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_payMoney));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadOrderAndProduct");
            }
        }

        //Load thông tin doanh thu của từng nhân viên
        private void Load_CreditOfEmployee()
        {
            DataTable tbsource;
            List<money_trading> moneyTradings;
            DataRow newRow;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                moneyTradings = (from mn in _dbContext.money_trading.ToList() select mn).ToList();
                if (moneyTradings != null && moneyTradings.Count > 0)
                {
                    tbsource = new DataTable();
                    tbsource.Columns.Add(_cEmployeeID);
                    tbsource.Columns.Add(_cEmployeeName);
                    tbsource.Columns.Add(_cMoneyCreadit);

                    foreach (money_trading item in moneyTradings)
                    {
                        newRow = tbsource.NewRow();
                        newRow[_cEmployeeID] = item.EmployeeID;
                        newRow[_cEmployeeName] = item.employee.EmployeeName;
                        newRow[_cMoneyCreadit] = item.MoneyCredit;

                        tbsource.Rows.Add(newRow);
                    }
                    gridControl_MoneyTradingEmployee.DataSource = tbsource;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Load_CreditOfEmployee");
            }
        }

        //Check chọn khu vực
        private void RadioChecked_Change(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = sender as RadioButton;
                if (rb != null)
                {
                    treeView_TableEmpty.Nodes.Clear();
                    int AreaID = Convert.ToInt32(rb.Name.Trim().Substring(4));
                    areaIDChecked = AreaID;

                    // Load danh sách bàn trống
                    LoadListTableEmpty(AreaID);

                    // Danh sách bàn đang bán nếu có
                    LoadOrderTableData(AreaID);
                    // LoadOrderTable_FromTableSource(AreaID);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "RadioChecked_Change");
            }
        }

        private void TimerCloseAppCallback(object state)
        {
            try
            {
                this.BeginInvoke(new Action(() => { dlg_sologan.Close(); _timerCloseApp = null; }));
            }
            catch (Exception ex)
            {
                // Xuất ra file log
                log.Error("Hàm TimerCloseAppCallback đã phát ra Exception ", ex.Message);
            }
        }

        private void SchedulerCallback(object sender, TaskScheduler.TaskScheduler.OnTriggerEventArgs e)
        {
            string fileName_TH;
            TaskScheduler.TaskScheduler.TriggerItem triggerItem;
            frm_ViewPlanDay rep = new frm_ViewPlanDay();
            //StringBuilder sb;
            DateTime now, dateLog;
            //DateTime now, bTime, eTime, dateLog;
            mycoffeeEntities db;
            //SMSLog smsLog;
            maillog mailLog;

            try
            {
                triggerItem = sender as TaskScheduler.TaskScheduler.TriggerItem;
                now = DateTime.Now;
                if (triggerItem.Tag == null)
                {
                    if (Directory.Exists(config.PathFileReport) == true)
                    {
                        fileName_TH = "BaoCao_" + now.ToString("dd_MM_yyyy") + string.Format("_{0:d2}_{1:d2}_{2:d2}", config.PrintReportAtTime.Hours, config.PrintReportAtTime.Minutes, config.PrintReportAtTime.Seconds);
                        fileName_TH = Path.Combine(config.PathFileReport, fileName_TH) + ".pdf";

                        if (File.Exists(fileName_TH) == false)
                        {
                            rep.SetReportSource_SendToEmail(fileName_TH);
                        }
                    }
                    else
                    {
                        // Xuất ra log file
                        log.ErrorFormat("Thư mục lưu file báo cáo xuất hàng tự động {0} không tồn tại", CoffeeHelpers.Conf.PathFileReport);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(triggerItem.Tag.ToString()) == false)
                    {
                        db = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                        if (triggerItem.Tag.ToString().Contains("@") == true)
                        {
                            if (Directory.Exists(config.PathFileReport) == true)
                            {
                                // Kiểm tra xem ngày hôm nay đã gởi mail hay chưa. Tránh gởi lại khi chương trình được chạy lại
                                dateLog = new DateTime(now.Year, now.Month, now.Day, triggerItem.TriggerTime.Hour, triggerItem.TriggerTime.Minute, triggerItem.TriggerTime.Second);
                                mailLog = db.maillogs.Where(mailL => mailL.email == triggerItem.Tag.ToString() && mailL.sentdate == dateLog).FirstOrDefault();
                                if (mailLog == null)
                                {
                                    fileName_TH = "BaoCao_" + now.ToString("dd_MM_yyyy_HH_mm_ss");
                                    rep.SetReportSource_SendToEmail(Path.Combine(config.PathFileReport, fileName_TH) + ".pdf");
                                    SendMail(triggerItem.Tag.ToString(), Path.Combine(config.PathFileReport, fileName_TH) + ".pdf", dateLog);
                                }
                            }
                            else
                            {
                                // Xuất ra log file
                                log.ErrorFormat("Thư mục lưu file báo cáo xuất hàng tự động {0} không tồn tại nên không tạo ra file tạm dùng gởi mail", config.PathFileReport);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xuất ra log file
                log.Error("SchedulerCallback đã phát ra exception ", ex.Message);
            }
        }

        // Yêu cầu gởi mail đến địa chỉ xác định
        private void SendMail(string receiver, string file, DateTime dateLog)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(SendMailThread, new Coffee.Utils.CoffeeHelpers.MailData(receiver, file, dateLog));
            }
            catch (Exception ex)
            {
                // Xuất ra log file
                log.Error("SendMail đã phát ra exception ", ex.Message);
            }
        }

        // Thực hiện gởi mail từ tiến trình của ThreadPool
        private void SendMailThread(object obj)
        {
            SmtpClient smtpClient;
            Coffee.Utils.CoffeeHelpers.MailData mailData;
            MailMessage mail;
            mycoffeeEntities db = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
            maillog mailLog;

            try
            {
                mailData = obj as Coffee.Utils.CoffeeHelpers.MailData;

                if (string.IsNullOrEmpty(mailData.Receiver) || string.IsNullOrEmpty(mailData.File))
                    return;
                if (File.Exists(mailData.File) == false)
                    return;

             

                smtpClient = new SmtpClient(config.MailServer);
                smtpClient.Port = config.MailServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(config.SenderMail, config.MailPassword);
                smtpClient.EnableSsl = config.UseSSL;
                mail = new MailMessage();
                mail.From = new MailAddress(config.SenderMail);
                mail.To.Add(mailData.Receiver);
                mail.Subject = config.Title;
                mail.Body = config.Content;
                mail.Attachments.Add(new Attachment(mailData.File));
                smtpClient.Send(mail);

                // Xóa file Excel
                mail.Dispose();
                File.Delete(mailData.File);

                // Xuất ra log file
                log.InfoFormat("Đã gởi file {0} đến {1}", mailData.File, mailData.Receiver);
                // Ghi log vào Database
                mailLog = new maillog { email = mailData.Receiver, sentdate = mailData.DateLog, success = 1 };
                db.maillogs.Add(mailLog);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                // Xuất ra log file
                log.Error("SendMailThread đã phát ra exception ", ex.Message);
            }
        }

        private void LoadReceive_PlanWork()
        {
            List<money_trading> money_tradings;
            money_trading moneys;

            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                money_tradings = (from mn in _dbContext.money_trading.ToList() select mn).ToList();
                if (money_tradings != null && money_tradings.Count > 0)
                {
                    //Ke hoach da duoc tao.Nen se an menu tao ke hoach ngay
                    btn_PlanDay.Enabled = false;
                    btn_UpdatePlanDay.Enabled = true;//Kich hoat update ke hoach
                    btn_EndPlanDay.Enabled = true;//Kich hoat jet thuc ke hoach
                    _ActiveButtonPay = true;//Kich hoat chuc nang popup thanh toan(có kế hoạch rồi)

                    // Tien ke hoach
                    _planMoney = money_tradings[0].TotalMoney;
                    textEdit_PlanMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_planMoney));

                    // Tong thu
                    _totalMoney = money_tradings[money_tradings.Count - 1].MoneyCredit;
                    textEdit_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_totalMoney));

                    //Doanh thu ngay
                    _creditMoney = _totalMoney - _planMoney;
                    textEdit_MoneyCredit.Text = string.Format("{0:#,#}", Convert.ToDecimal(_creditMoney));

                    //Cho phép thao tác
                    tableLayoutPanel_Main.Enabled = true;

                    foreach (money_trading item in money_tradings)
                    {
                        if (item.Status == 1)//
                        {
                            if (XtraMessageBox.Show("Có ca đang chờ nhận. Bạn có muốn nhận ca này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                            {
                                return;
                            }
                            _receivePlanWork = true;//Đã nhận ca
                            //Update trạng thái ca trước thành đã giao (false)
                            moneys = (from money in _dbContext.money_trading.ToList() where money.Status == 1 select money).FirstOrDefault();

                            moneys.Status = 2;
                            moneys.ReceiveByEmployeeID = CoffeeHelpers.EmpLogin.EmployeeID;
                            moneys.ReceiveByEmployeeName = CoffeeHelpers.EmpLogin.EmployeeName;
                            moneys.ReceiveDate = DateTime.Now;
                            _dbContext.SaveChanges();

                            //Ghi log
                            WriteLog("Nhận ca");

                            log.Info("Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") nhận ca lúc " + DateTime.Now.ToString());
                            break;
                        }
                        else if (money_tradings[money_tradings.Count - 1].ReceiveByEmployeeID == CoffeeHelpers.EmpLogin.EmployeeID && money_tradings[money_tradings.Count - 1].Status == 2)//Trạng thái chưa giao ca từ khi nhận ca của user này
                        {
                            _receivePlanWork = true;
                        }
                    }

                    //string _messges = getSologan_Login(DateTime.Now);
                    //dlg_sologan = new DevExpress.Utils.WaitDialogForm("Chào mừng đăng nhập", _messges, new Size(320, 50));
                    //_timerCloseApp = new System.Threading.Timer(TimerCloseAppCallback, null, 3000, System.Threading.Timeout.Infinite);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadReceive_PlanWork");
            }
        }

        /// <summary>
        /// Return processorId from first CPU in machine
        /// </summary>
        /// <returns>[string] ProcessorId</returns>
        public string GetCPUId()
        {
            string cpuInfo = String.Empty;
            //create an instance of the Managemnet class with the
            //Win32_Processor class
            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            //create a ManagementObjectCollection to loop through
            ManagementObjectCollection objCol = mgmt.GetInstances();
            //start our loop for all processors found
            foreach (ManagementObject obj in objCol)
            {
                if (cpuInfo == String.Empty)
                {
                    // only return cpuInfo from first CPU
                    cpuInfo = obj.Properties["ProcessorId"].Value.ToString();
                }
            }
            return cpuInfo;
        }

        private bool Check_Key(string _Key)
        {
            try
            {
                if (_Key == "" || _Key == null)
                {
                    return false;
                }

                string[] seperate_filelds = _Key.Split('-');
                string Product_Key = "";
                if (seperate_filelds.Length > 0)
                {
                    for (int i = 0; i < seperate_filelds.Length; i++)
                    {
                        Product_Key += seperate_filelds[i];
                    }
                }

                byte[] bytes = Encoding.ASCII.GetBytes(Product_Key);
                string KEY = string.Empty;

                KEY += Product_Key[15];//0
                KEY += Product_Key[14];//1
                KEY += Product_Key[8];//2
                KEY += Product_Key[19];//3
                KEY += Product_Key[6];//4
                KEY += Product_Key[11];//5
                KEY += Product_Key[4];//6
                KEY += Product_Key[12];//7
                KEY += Product_Key[2];//8
                KEY += Product_Key[3];//9
                KEY += Product_Key[13];//10
                KEY += Product_Key[17];//11
                KEY += Product_Key[7];//12
                KEY += Product_Key[10];//13
                KEY += Product_Key[1];//14
                KEY += Product_Key[0];//15
                KEY += Product_Key[16];//16
                KEY += Product_Key[5];//17
                KEY += Product_Key[18];//18
                KEY += Product_Key[9];//19

                string _systemkey = GetCPUId().Trim();

                if (_systemkey == KEY.Substring(0, _systemkey.Length))
                {
                    //Đúng mã cpu
                    return true;
                }
                else //Hết hạn dùng thử
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Check_Key");
                return false;
            }
        }

        /// <summary>
        /// A Temporary variable.
        /// </summary>
        private string temp = "";

        /// <summary>
        /// Sets the new date +31 days add for trial.
        /// </summary>
        public void SetNewDate(int day)
        {
            try
            {
                DateTime newDate = DateTime.Now.AddDays(day);
                temp = newDate.ToLongDateString();
                StoreDate(temp);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SetNewDate");
            }
        }

        /// <summary>
        /// Checks if expire or NOT.
        /// </summary>
        public void Expired()
        {
            try
            {
                string d = "";
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\vCoffee"))
                {
                    // Nếu chưa đăng kí thông tin dùng thử
                    if (key == null)
                    {
                        SetNewDate(31);
                    }

                    d = (String)Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\myCoffee").GetValue("Date");
                }
                DateTime now = DateTime.Parse(d);
                int day = (now.Subtract(DateTime.Now)).Days;
                if (day > 30)
                {
                    if (MessageBox.Show("Đã kết thúc thời gian dùng thử. Bạn có muốn kích hoạt bản quyền ?", "Hết hạn dùng thử!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                    /* Fill with more code, once it has expired, what will happen nex! */
                    _back:
                        frm_RegisterKey dlg = new frm_RegisterKey();
                        dlg._day_Trial = day_TrialRegisterForm;
                        dlg.Text = "Nhập Key Bản Quyền";
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            if (Check_Key(dlg._Key) == false)
                            {
                                goto _back;
                            }
                            string[] _listKey = dlg._Key.Split('-');
                            _registerKey = new CoffeeHelpers.RegisterKeys();
                            _registerKey.User = GetCPUId();
                            _registerKey.RegisterKey = _listKey[0] + _listKey[1] + _listKey[2] + _listKey[3] + _listKey[4];
                            _registerKey.Date = DateTime.Now.ToString("dd/MM/yyyy");

                            CoffeeHelpers.SaveRegisterKey(_registerKey);

                            CoffeeHelpers.Register = _registerKey;
                            _checkCopyRight = true;
                        }
                        else
                        {
                            //Kết thúc mọi xử lý
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                            Application.Exit();
                        }
                    }

                    Environment.Exit(0);
                }
                else if (0 < day && day <= 30)
                {
                    string daysLeft = string.Format(" ***Phiên bản dùng thử. Thời gian dùng thử còn lại {0} ngày.", now.Subtract(DateTime.Now).Days);
                    //MessageBox.Show(daysLeft);
                    day_Trial = daysLeft;
                    day_TrialRegisterForm = now.Subtract(DateTime.Now).Days + " ngày.";
                }
                else if (day <= 0)//Đã hết hạn
                {
                /* Fill with more code, once it has expired, what will happen nex! */
                _back:
                    frm_RegisterKey dlg = new frm_RegisterKey();
                    dlg._day_Trial = day_TrialRegisterForm;
                    dlg.Text = "Nhập Key Bản Quyền";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (Check_Key(dlg._Key) == false)
                        {
                            goto _back;
                        }
                        string[] _listKey = dlg._Key.Split('-');
                        _registerKey = new CoffeeHelpers.RegisterKeys();
                        _registerKey.User = GetCPUId();
                        _registerKey.RegisterKey = _listKey[0] + _listKey[1] + _listKey[2] + _listKey[3] + _listKey[4];
                        _registerKey.Date = DateTime.Now.ToString("dd/MM/yyyy");

                        CoffeeHelpers.SaveRegisterKey(_registerKey);

                        CoffeeHelpers.Register = _registerKey;
                        _checkCopyRight = true;
                    }
                    else
                    {
                        //Kết thúc mọi xử lý
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Expired");
                Application.Exit();
            }
        }

        /// <summary>
        /// Stores the new date value in registry.
        /// </summary>
        /// <param name="value"></param>
        private void StoreDate(string value)
        {
            try
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\vCoffee", RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    //Phân quyền
                    string user = Environment.UserDomainName + "\\" + Environment.UserName;

                    RegistrySecurity sc = new RegistrySecurity();
                    sc.AddAccessRule(new RegistryAccessRule(user, RegistryRights.WriteKey | RegistryRights.ChangePermissions | RegistryRights.ReadKey,
                                                              InheritanceFlags.None,
                                                              PropagationFlags.None,
                                                              AccessControlType.Allow));

                    key.SetValue("Date", value, Microsoft.Win32.RegistryValueKind.String);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "StoreDate");
                Application.Exit();
            }
        }


        public string GetRegistryValue(string key, string name)
        {
            string retVal = "";

            // Open the registry key, always in HKLM.
            RegistryKey rootkey = Registry.LocalMachine;
            // Open a sub key for reading.
            Debug.WriteLine("Key: " + key);
            RegistryKey subkey = rootkey.OpenSubKey(key);
            // If the RegistryKey doesn't exist return null
            if (subkey == null)
            {
                return retVal;
            }
            else
            {
                try
                {
                    Debug.WriteLine("Subkey: " + name);
                    // Check for proper registry value data type
                    RegistryValueKind valKind = subkey.GetValueKind(name);
                    if (valKind == RegistryValueKind.DWord || valKind == RegistryValueKind.String)
                        retVal = subkey.GetValue(name).ToString();
                }
                catch (Exception ex)
                {

                }
            }
            return retVal;
        }



        //Kiểm tra bản quyền
        private void checkCopyRight(CoffeeHelpers.RegisterKeys _registerKey)
        {
            try
            {
                //Nếu lần đầu cài đặt thì insert thông tin giả vào. Trong đó ngày là ngày hiện tại
                if (_registerKey == null)
                {
                    _registerKey = new CoffeeHelpers.RegisterKeys();
                    _registerKey.User = GetCPUId();
                    _registerKey.RegisterKey = "NRYR4TFHD8UH9DHSDLD7";
                    _registerKey.Date = DateTime.Now.ToString("dd/MM/yyyy");

                    CoffeeHelpers.SaveRegisterKey(_registerKey);

                    CoffeeHelpers.Register = _registerKey;

                    //Kích hoạt dùng thử
                    SetNewDate(31);
                }
                else
                {
                    if (_registerKey.RegisterKey.Length > 19)
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(_registerKey.RegisterKey);
                        string KEY = string.Empty;
                        KEY += _registerKey.RegisterKey[0];
                        KEY += _registerKey.RegisterKey[1];
                        KEY += _registerKey.RegisterKey[2];
                        KEY += _registerKey.RegisterKey[3];
                        KEY += "-";
                        KEY += _registerKey.RegisterKey[4];
                        KEY += _registerKey.RegisterKey[5];
                        KEY += _registerKey.RegisterKey[6];
                        KEY += _registerKey.RegisterKey[7];
                        KEY += "-";
                        KEY += _registerKey.RegisterKey[8];
                        KEY += _registerKey.RegisterKey[9];
                        KEY += _registerKey.RegisterKey[10];
                        KEY += _registerKey.RegisterKey[11];
                        KEY += "-";
                        KEY += _registerKey.RegisterKey[12];
                        KEY += _registerKey.RegisterKey[13];
                        KEY += _registerKey.RegisterKey[14];
                        KEY += _registerKey.RegisterKey[15];
                        KEY += "-";
                        KEY += _registerKey.RegisterKey[16];
                        KEY += _registerKey.RegisterKey[17];
                        KEY += _registerKey.RegisterKey[18];
                        KEY += _registerKey.RegisterKey[19];

                        if (Check_Key(KEY) == true)//Bản quyền thành công
                        {
                            if (_registerKey.Date == "")
                            {
                                _registerKey.Date = DateTime.Now.ToString("dd/MM/yyyy");
                                CoffeeHelpers.SaveRegisterKey(_registerKey);

                                CoffeeHelpers.Register = _registerKey;
                            }
                            ////Cập nhật ngày dùng thử thành 0
                            //SetNewDate(0);

                            // Đã có bản quyền
                            day_Trial = "";
                        }
                        else
                        {
                            //Kiểm tra bản dùng thử hết hạn hay chưa
                            //Expired();
                        }
                    }
                    else
                    {
                        //Kiểm tra bản dùng thử hết hạn hay chưa
                        //Expired();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkCopyRight");
                Application.Exit();
            }
        }

        #endregion
        
        #region Create Table
        //Danh sách sản phẩm trên Main
        /// <summary>
        /// Tạo cây sản phẩm
        /// </summary>
        private void Load_CrateProduct()
        {
            List<menu> listMenu;
            List<product> products;
            //List<TreeNode> treeNode;
            TreeNode parentNodes, childNode;
            DataRow newRow;
            try
            {

                if (treeView_ProductTable.Nodes.Count > 0)
                {
                    treeView_ProductTable.Nodes.Clear();
                }

                tbProduct = CreateTableProductStruct();
                tbMenu = CreateTableMenuStruct();

                treeNode = null;
                treeNode = new List<TreeNode>();

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                LoadImage();

                listMenu = (from me in _dbContext.menus.ToList() where me.Status == 1 select me).ToList();
                if (listMenu != null && listMenu.Count > 0)
                {
                    foreach (menu item in listMenu)
                    {
                        parentNodes = treeView_ProductTable.Nodes.Add(item.MenuID.ToString(), item.MenuCode, item.ImageIndex, item.ImageIndex);
                        parentNodes.Tag = item.MenuID.ToString();
                        treeNode.Add(parentNodes);

                        //Lưu lại tableSource
                        newRow = tbMenu.NewRow();
                        newRow[_cMenuID] = item.MenuID;
                        newRow[_cMenuCode] = item.MenuCode;
                        newRow[_cStatus] = item.Status;
                        newRow[_cImageIndex] = item.ImageIndex;
                        //newRow[_cImage] = imageList_Product.Images[item.ImageIndex];
                        tbMenu.Rows.Add(newRow);
                    }

                }

                products = (from p in _dbContext.products where p.Status == 1 select p).ToList();// Chỉ load những sản phẩm còn hàng

                if (products != null && products.Count > 0)
                {
                    int index = 0;
                    foreach (product item in products)
                    {
                        for (int i = 0; i < treeNode.Count; i++)
                        {
                            if (treeNode[i].Tag.ToString() == item.ProductSkin.ToString())
                            {
                                childNode = treeNode[i].Nodes.Add(item.ProductID.ToString(), item.ProductName.ToString(), item.ImageIndex, item.ImageIndex);
                                childNode.Tag = _childNode;
                                break;
                            }
                        }

                        //Lưu lại tableSource
                        newRow = tbProduct.NewRow();
                        newRow[_cProductID] = item.ProductID;
                        newRow[_cProductName] = item.ProductName;
                        newRow[_cProductCode] = item.ProductCode;
                        newRow[_cProductSkin] = item.ProductSkin;
                        newRow[_cPrice] = item.Price;
                        newRow[_cInputPrice] = item.InputPrice;
                        newRow[_cLimit] = item.ExpiryDate;
                        newRow[_cDVT] = item.DVT;
                        newRow[_cStatus] = item.Status;
                        newRow[_cMadeInID] = item.MadeInID;
                        newRow[_cMadeInName] = item.madein.MadeInName;
                        newRow[_cNotes] = item.Notes;
                        newRow[_cImageIndex] = item.ImageIndex;
                        newRow[_cImage] = imageList_Product.Images[item.ImageIndex];

                        tbProduct.Rows.Add(newRow);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadProductTable");
            }
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho gridView
        /// </summary>
        private DataTable CreateTableProductStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cShortName);
                tbSource.Columns.Add(_cProductCode);
                tbSource.Columns.Add(_cProductSkin);
                tbSource.Columns.Add(_cPrice);
                tbSource.Columns.Add(_cInputPrice);
                tbSource.Columns.Add(_cDVT);
                tbSource.Columns.Add(_cLimit);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cNotes);
                tbSource.Columns.Add(_cMadeInID);
                tbSource.Columns.Add(_cMadeInName);
                tbSource.Columns.Add(_cImageIndex);
                tbSource.Columns.Add(_cImage, typeof(Image));
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cProductID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho gridView
        /// </summary>
        private DataTable CreateTableMenuStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cMenuID);
                tbSource.Columns.Add(_cMenuCode);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cImageIndex);
                tbSource.Columns.Add(_cImage, typeof(Image));
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cMenuID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho OrderDetail thu gọn Main
        /// </summary>
        private DataTable CreateOrderProductShortTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cID);
                tbSource.Columns.Add(_cOrderID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cQuantity);
                tbSource.Columns.Add(_cPrice);
                tbSource.Columns.Add(_cMoneyPromote);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateOrderProductShortTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho OrderDetail Main
        /// </summary>
        private DataTable CreateOrderDetailMainableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cID);
                tbSource.Columns.Add(_cOrderID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cQuantity);
                tbSource.Columns.Add(_cDate, typeof(DateTime));
                tbSource.Columns.Add(_cPrice);
                tbSource.Columns.Add(_cPromote);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateOrderDetailMainableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho Area
        /// </summary>
        private DataTable CreateAreaTableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cAreaID);
                tbSource.Columns.Add(_cAreaCode);
                tbSource.Columns.Add(_cStatus);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cAreaID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateAreaTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho 
        /// </summary>
        private DataTable CreateOrderTableStruct()
        {
            DataTable tbSource = null;

            try
            {

                tbSource = new DataTable();
                tbSource.Columns.Add(_cOrderID);
                tbSource.Columns.Add(_cTableID);
                tbSource.Columns.Add(_cTableCode);
                tbSource.Columns.Add(_cAreaID);
                tbSource.Columns.Add(_cOrderCode);
                tbSource.Columns.Add(_cTotal_Money);
                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cOrderID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateOrderTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        /// <summary>
        /// Tạo cấu trúc mặc định cho Table
        /// </summary>
        private DataTable CreateArea_TableStruct()
        {
            DataTable tbSource = null;

            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cTableID);
                tbSource.Columns.Add(_cTableCode);
                tbSource.Columns.Add(_cAreaID);
                tbSource.Columns.Add(_cStatus);
                tbSource.Columns.Add(_cImageIndex);

                tbSource.PrimaryKey = new DataColumn[] { tbSource.Columns[_cTableID] };
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateArea_TableStruct");
                return tbSource;
            }
            return tbSource;
        }
        #endregion

        #endregion

        #region Actions

        #region barButton
        private void barButton_SQL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_SQLConfig dlg;
            frm_Login dlgLogin;

            try
            {
                dlgLogin = new frm_Login();
                dlgLogin._Config = config;
                if (dlgLogin.ShowDialog() == DialogResult.OK)
                {
                    dlg = new frm_SQLConfig();
                    dlg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_SQLConfig_ItemClick");
            }
        }

        private void barButton_ConfigSystem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_Config dlg;
            frm_Login dlgLogin;
            TaskScheduler.TaskScheduler.TriggerItem triggerItem;

            try
            {
                dlgLogin = new frm_Login();
                dlgLogin._Config = config;
                
                if (dlgLogin.ShowDialog() == DialogResult.OK)
                {
                    dlg = new frm_Config();
                    dlg.Text = "Cấu Hình Hệ Thống";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        config = CoffeeHelpers.LoadConfig();

                        //Load màu cho ứng dụng
                        SetColorForApplication(config.ApplicationColor);

                        //Load lại danh sách khu vực
                        LoadAreaData();

                        // Kiểm tra ẩn hiện thông tin doanh thu
                        if (config.ShowPlanMoney == true)
                        {
                            panel_PlanMoney.Visible = true;
                        }
                        else
                        {
                            panel_PlanMoney.Visible = false;
                        }
                        // Kiểm tra ẩn hiện thông tin chi tiết kế hoạch ngày
                        if (config.ShowDetailPlan == true)
                        {
                            groupControl_PlanDay.Visible = true;
                        }
                        else
                        {
                            groupControl_PlanDay.Visible = false;
                        }
                    }
                    // Xóa trigger báo cáo
                    for (int i = 0; i < taskScheduler.TriggerItems.Count; i++)
                    {
                        triggerItem = taskScheduler.TriggerItems[i];
                        if (triggerItem.Tag == null)
                        {
                            taskScheduler.TriggerItems.Remove(triggerItem);
                            break;
                        }
                    }
                    // Tạo lại các trigger báo cáo
                    triggerItem = new TaskScheduler.TaskScheduler.TriggerItem();
                    triggerItem.Tag = null;
                    triggerItem.StartDate = DateTime.Now;
                    triggerItem.EndDate = DateTime.MaxValue;
                    triggerItem.TriggerTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).Add(config.PrintReportAtTime);
                    triggerItem.TriggerSettings.Daily.Interval = 1;
                    triggerItem.OnTrigger += new TaskScheduler.TaskScheduler.TriggerItem.OnTriggerEventHandler(SchedulerCallback);
                    triggerItem.Enabled = true;
                    taskScheduler.AddTrigger(triggerItem);

                    //Ghi log
                    WriteLog("Sửa thông số hệ thống");

                    log.Info("Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + "(" + CoffeeHelpers.EmpLogin.EmployeeID + ")" + " sửa thông số hệ thống lúc " + DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_ConfigSystem_ItemClick");
            }
        }

        private void barButton_ChangePass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ChangePassWord dlg;
            try
            {
                dlg = new frm_ChangePassWord();
                dlg.Text = "Đổi Mật Khẩu Đăng Nhập";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    StartRestarter("Bạn đợi đăng nhập lại", 167, 50);
                    //Kết thúc mọi xử lý
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_ChangePass_ItemClick");
            }
        }

        private void barButton_Product_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_Product dlg;
            TreeNode parentNodes, childNode;
            try
            {
                dlg = new frm_Product();
                dlg.list_Image = this.imageList_Product;
                dlg._dic_images = dic_images;
                dlg.Text = "Sản Phẩm";
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                    if (dlg._checkAddOrUpdate == true)
                    {
                        if (tbProduct.Rows.Count != dlg._tbSource.Rows.Count && tbMenu.Rows.Count == dlg.listMenu.Rows.Count)//Chỉ sửa sản phẩm
                        {
                            tbProduct = new DataTable();
                            tbMenu = new DataTable();

                            tbProduct = dlg._tbSource;
                            tbMenu = dlg.listMenu;

                            if (tbMenu.Rows.Count > 0)
                            {
                                int i = 0;
                                foreach (DataRow item in tbMenu.Rows)
                                {
                                    parentNodes = treeView_ProductTable.Nodes[i];
                                    parentNodes.Nodes.Clear();//Xoá

                                    if (tbProduct.Rows.Count > 0)//Add lại
                                    {
                                        foreach (DataRow it in tbProduct.Rows)
                                        {
                                            if (parentNodes.Tag.ToString() == it[_cProductSkin].ToString())
                                            {
                                                childNode = parentNodes.Nodes.Add(it[_cProductID].ToString(), it[_cProductName].ToString(), Convert.ToInt32(it[_cImageIndex]), Convert.ToInt32(it[_cImageIndex]));
                                                childNode.Tag = _childNode;
                                            }
                                        }
                                    }

                                    i++;
                                }
                            }
                        }
                        if (tbMenu.Rows.Count > dlg.listMenu.Rows.Count)//Có thực đơn bị xoá
                        {
                            tbProduct = new DataTable();
                            //tbMenu = dlg.listMenu;
                            tbProduct = dlg._tbSource;

                            if (tbMenu.Rows.Count > 0)
                            {
                                int i = 0;
                                foreach (DataRow item in tbMenu.Rows)
                                {
                                    if (i < dlg.listMenu.Rows.Count)
                                    {
                                        if (item[_cMenuID] == dlg.listMenu.Rows[i][_cMenuID])
                                        {
                                            parentNodes = treeView_ProductTable.Nodes[i];
                                            parentNodes.Nodes.Clear();//Xoá

                                            if (tbProduct.Rows.Count > 0)//Add lại
                                            {
                                                foreach (DataRow it in tbProduct.Rows)
                                                {
                                                    if (parentNodes.Tag.ToString() == it[_cProductSkin].ToString())
                                                    {
                                                        childNode = parentNodes.Nodes.Add(it[_cProductID].ToString(), it[_cProductName].ToString(), Convert.ToInt32(it[_cImageIndex]), Convert.ToInt32(it[_cImageIndex]));
                                                        childNode.Tag = _childNode;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        treeView_ProductTable.Nodes[i].Remove();//Thực đơn này đạ bị xoá
                                    }
                                    i++;
                                }
                                tbMenu = new DataTable();
                                tbMenu = dlg.listMenu;
                            }
                        }
                        if (tbMenu.Rows.Count < dlg.listMenu.Rows.Count)//Thêm thực đơn
                        {
                            tbProduct = new DataTable();
                            //tbMenu = dlg.listMenu;
                            tbProduct = dlg._tbSource;

                            if (dlg.listMenu.Rows.Count > 0)
                            {
                                int i = 0;
                                foreach (DataRow item in dlg.listMenu.Rows)
                                {
                                    if (i < tbMenu.Rows.Count)
                                    {
                                        if (item[_cMenuID] == tbMenu.Rows[i][_cMenuID])
                                        {
                                            parentNodes = treeView_ProductTable.Nodes[i];
                                            parentNodes.Nodes.Clear();//Xoá

                                            if (tbProduct.Rows.Count > 0)//Add lại
                                            {
                                                foreach (DataRow it in tbProduct.Rows)
                                                {
                                                    if (parentNodes.Tag.ToString() == it[_cProductSkin].ToString())
                                                    {
                                                        childNode = parentNodes.Nodes.Add(it[_cProductID].ToString(), it[_cProductName].ToString(), Convert.ToInt32(it[_cImageIndex]), Convert.ToInt32(it[_cImageIndex]));
                                                        childNode.Tag = _childNode;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        parentNodes = new TreeNode();
                                        parentNodes.Name = dlg.listMenu.Rows[i][_cMenuID].ToString();
                                        parentNodes.Text = dlg.listMenu.Rows[i][_cMenuCode].ToString();
                                        //parentNodes.Tag = dlg.listMenu.Rows[i][_cMenuID];
                                        parentNodes.ImageIndex = Convert.ToInt32(dlg.listMenu.Rows[i][_cImageIndex]);
                                        parentNodes.SelectedImageIndex = Convert.ToInt32(dlg.listMenu.Rows[i][_cImageIndex]);

                                        treeView_ProductTable.Nodes.Add(parentNodes);//Thực đơn này mới thêm
                                        parentNodes.Tag = Convert.ToInt32(dlg.listMenu.Rows[i][_cMenuID]);

                                        if (tbProduct.Rows.Count > 0)//Add lại
                                        {
                                            foreach (DataRow it in tbProduct.Rows)
                                            {
                                                if (parentNodes.Tag.ToString() == it[_cProductSkin].ToString())
                                                {
                                                    childNode = parentNodes.Nodes.Add(it[_cProductID].ToString(), it[_cProductName].ToString(), Convert.ToInt32(it[_cImageIndex]), Convert.ToInt32(it[_cImageIndex]));
                                                    childNode.Tag = _childNode;
                                                }
                                            }
                                        }
                                    }
                                    i++;
                                }

                                tbMenu = new DataTable();
                                tbMenu = dlg.listMenu;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_Product_ItemClick");
            }
        }

        private void barButton_MadeIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_MadeIn dlg;
            try
            {
                dlg = new frm_MadeIn();
                dlg.Text = "Nhà Cung Cấp";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_MadeIn_ItemClick");
            }
        }

        private void barButton_Promote_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ProductPromote dlg;
            try
            {
                dlg = new frm_ProductPromote();
                dlg.Text = "Sản Phẩm Khuyến Mãi";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_Promote_ItemClick");
            }
        }

        private void barButton_EmployStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_EmployeeStatus dlg;
            List<employee> employees;
            try
            {
                employees = (from emp in _dbContext.employees.ToList() select emp).ToList();
                if (employees.Count <= 0)
                {
                    XtraMessageBox.Show("Danh sách nhân viên trống. Vui lòng khai báo nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frm_AccountManager dlg_Account = new frm_AccountManager();
                    dlg_Account.Text = "Danh Sách Nhân Viên";
                    dlg_Account.ShowDialog();
                    return;
                }

                dlg = new frm_EmployeeStatus();
                dlg._dbContext = _dbContext;
                dlg.Text = "Điểm Danh Nhân Viên";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_EmployStatus_ItemClick");
            }
        }

        private void barButton_CoffeeSites_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_Company dlg;
            company company;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dlg = new frm_Company();
                company = new company();
                company = (from c in _dbContext.companies.ToList() where c.ID == 1 select c).FirstOrDefault();
                dlg.P_Company = company;
                dlg.Text = "Thông Tin Cửa Hàng";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    company.CompanyName = dlg.P_Company.CompanyName;
                    company.Address = dlg.P_Company.Address;
                    company.Phone = dlg.P_Company.Phone;
                    company.Fax = dlg.P_Company.Fax;
                    company.StartTime = dlg.P_Company.StartTime;
                    company.EndTime=dlg.P_Company.EndTime;
                    company.MaSoThue = dlg.P_Company.MaSoThue;

                    _dbContext.SaveChanges();
                }
                this.Text = "Quản Lý " + dlg.P_Company.CompanyName + " - " + CoffeeHelpers.EmpLogin.EmployeeCode + " (" + CoffeeHelpers.GetEmployeeRightTitle(CoffeeHelpers.EmpLogin.EmpRight) + ")";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_CoffeeSites_ItemClick");
            }
        }

        private void barButton_PlanWork_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_PlanWork dlg;
            try
            {
                dlg = new frm_PlanWork();
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_PlanWork_ItemClick");
            }
        }

        private void barButton_Table_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_Table dlg;
            try
            {
                dlg = new frm_Table();
                dlg.Text = "Danh Sách Bàn";
                if (dlg.ShowDialog() == DialogResult.Cancel)
                {
                    //Load danh sách bàn trống
                    LoadListTableEmpty(areaIDChecked);

                    //Load danh sách bàn
                    LoadOrderTableData(areaIDChecked);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_Table_ItemClick");
            }
        }

        private void barButton_AreaTable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_Area dlg;
            try
            {
                dlg = new frm_Area();
                dlg.Text = "Danh Sách Khu Vực";
                if (dlg.ShowDialog() == DialogResult.Cancel)
                {
                    //--- thực hiện load lại khu vực
                    for (int i = 0; i < Radion_Area.Count; i++)
                    {
                        xtraScrollable_Area.Controls.RemoveByKey(Radion_Area[i].Name);
                    }
                    _tbSourceArea = null;
                    Radion_Area = null;
                    Radion_Area = new List<RadioButton>();

                    _tbSourceArea = CreateAreaTableStruct();

                    LoadAreaData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_AreaTable_ItemClick");
            }
        }

        private void barButtonItem_AllDetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow row;
            frm_ViewOrderDetail dlg;
            order_detail orderDetail;
            try
            {
                row = gridView_Order.GetFocusedDataRow();
                if (row != null)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    dlg = new frm_ViewOrderDetail();
                    orderDetail = new order_detail();

                    orderDetail.OrderID = orderIDSelected;
                    orderDetail.ProductID = 0;
                    dlg.P_OrderDetail = orderDetail;
                    dlg._dbContext = _dbContext;
                    dlg.Text = "Danh Sách Chi Tiết Tất Cả Món";
                    dlg.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_AllDetail_ItemClick");
            }
        }

        private void barButtonItem_DVT_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_DVTinh dlg;
            try
            {
                dlg = new frm_DVTinh();
                dlg.list_Image = this.imageList_Product;
                dlg.Text = "Danh Mục Đơn Vị Tính";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_DVT_ItemClick");
            }
        }
 
        #endregion

        #region PopupItem

        
        #endregion

        #region Buttons
        // Thao tác click chọn đơn hàng
        /// <summary>
        /// Thao tác click chọn đơn hàng
        /// </summary>
        /// <param name="OrderID"></param>
        private void SelectOrder_Click(int OrderID)
        {
            try
            {
                Order_Pre.Image = Coffee.Properties.Resources.coffee_table;
                PictureEdit focus = new PictureEdit();
                string tableName = "";
                for (int i = 0; i < Picture_ListTable.Count; i++)
                {
                    if (Picture_ListTable[i].Name == "Image" + OrderID)
                    {
                        focus = Picture_ListTable[i];
                        tableName = Picture_ListTable[i].Tag.ToString();
                        break;
                    }
                }
                Order_Pre = focus;
                focus.Image = Coffee.Properties.Resources.Notary_icon;
                groupControl_OrderDetail.Text = "Nội dung thực đơn " + tableName.ToLower();
                orderIDSelected = OrderID;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SelectOrder_Click");
            }
        }

        #region Color Application

        // Thiết lập màu cho ứng dụng
        private void SetColorForApplication(string skin_name)
        {
            try
            {
                // Nếu màu không tồn tại thì lấy màu hiện tại
                for (int i = 0; i < arr_ColorCode.Length; i++)
                {
                    if (skin_name.Trim() == arr_ColorCode[i].Trim())
                    {
                        DevExpress.UserSkins.BonusSkins.Register();
                        DevExpress.Skins.SkinManager.EnableFormSkins();
                        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = skin_name.Trim();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SetColorForApplication");
            }
        }

        // Màu bạc
        private void barButton_ColorSliver_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_ColorSliver_ItemClick");
            }
        }

        // Màu nâu
        private void barButton_ColorBrown_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_ColorBrown_ItemClick");
            }
        }

        // Màu sương mù
        private void barButton_ColorO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_ColorO_ItemClick");
            }
        }

        // Màu đen mặc định
        private void barButton_BlackDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_BlackDefault_ItemClick");
            }
        }

        // Màu đen 1
        private void barButton_Black1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_Black1_ItemClick");
            }
        }

        // Màu đen 2
        private void barButton_Black2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_Black2_ItemClick");
            }
        }

        // Màu đen Office 2010
        private void barButton_BlackOffice2010_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_BlackOffice2010_ItemClick");
            }
        }

        // Màu xanh dương
        private void barButtonColor_Blue_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonColor_Blue_ItemClick");
            }
        }

        // Màu xanh biển
        private void barButton_Ocean_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_Ocean_ItemClick");
            }
        }

        // Màu trời
        private void barButton_BlueSky_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_BlueSky_ItemClick");
            }
        }

        // Xanh tuyết
        private void barButton_BulexMas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_BulexMas_ItemClick");
            }
        }

        // Mùa hè
        private void barButton_BlueSummer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_BlueSummer_ItemClick");
            }
        }

        // Xanh lá nhạt
        private void barButton_Green_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_Green_ItemClick");
            }
        }

        // Xanh Office 2010
        private void barButton_BlueOffice2010_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_BlueOffice2010_ItemClick");
            }
        }
        // Xanh Office 2007
        private void barButton_BlueOffice2007_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_BlueOffice2007_ItemClick");
            }
        }

        // Xanh lá nhạt Offcie 2007
        private void barButton_GreenOffice2007_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_GreenOffice2007_ItemClick");
            }
        }

        // Xám mây
        private void barButton_McSkinSky_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_McSkinSky_ItemClick");
            }
        }
        // Xám 1
        private void barButton_McSkin1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_McSkin1_ItemClick");
            }
        }

        // Xám 2
        private void barButton_McSkin2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_McSkin2_ItemClick");
            }
        }

        // Hồng Valentine
        private void barButton_Valentine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_Valentine_ItemClick");
            }
        }

        // Hồng Office 2007
        private void barButton_PinkOffice2007_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SetColorForApplication(e.Item.Tag.ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_PinkOffice2007_ItemClick");
            }
        }

        #endregion

        private void treeView_ProductTable_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selectNodeProduct;
            order_detail orderDetail;
            listorder order;
            List<promote_detail> promteDetail;
            frm_ChooseProductForOrder dlg;
            decimal TotalMoney = 0;//Tổng tiền
            DateTime dt = DateTime.Now;
            DataRow newRow;
            product product;
            tonkho tk;
            List<determine> determines;

            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    return;// Nếu click chuột phải thì không làm gì(chỉ hiện popup)
                }
               

                selectNodeProduct = e.Node;

                if (orderIDSelected == -1 && selectNodeProduct.Tag.ToString() == _childNode)
                {
                    //XtraMessageBox.Show("Vui lòng chọn bàn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (selectNodeProduct == null || selectNodeProduct.Tag.ToString() != _childNode)
                {
                    return;
                }

                orderDetail = new order_detail();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                //dlg = new frm_ChooseProductForOrder();

                //dlg.P_OrderDetail = orderDetail;
                //dlg._checkAddOrDecrease = 1;
                //dlg._dbContext = _dbContext;
                //dlg.Text = "Thêm " + e.Node.Text;
                //if (dlg.ShowDialog() == DialogResult.OK)
                //{
                    //Lấy tổng tiền hiện tại của đơn hàng
                    order = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();
                    if (order != null)
                    {
                        TotalMoney = (decimal)order.Total_Money;
                    }

                    product = (from p in _dbContext.products.ToList() where p.ProductID == Convert.ToInt32(selectNodeProduct.Name) select p).FirstOrDefault();

                    //Lấy giá của sản phẩm này . Ưu tiên chọn trong bảng khuyến mãi trước. Nếu không thuộc diện khuyến mãi thì lấy giá gốc
                    promteDetail = (from pr in _dbContext.promote_detail.ToList()
                                    where pr.ProductID == Convert.ToInt32(selectNodeProduct.Name) &&
                                        pr.EndDate >= dt && pr.Deleted == 2 && pr.promote.Deleted == 2
                                    select pr).ToList();

                    if (promteDetail != null && promteDetail.Count > 0)
                    {
                        foreach (promote_detail item in promteDetail)
                        {
                            //TotalMoney = TotalMoney + (dlg.P_OrderDetail.Quantity * (decimal)item.Price);
                            orderDetail.PricePromote = (1 * ((decimal)item.product.Price - (decimal)item.Price));
                            _MoneyPromote = _MoneyPromote + (1 * ((decimal)item.product.Price - (decimal)item.Price));//Tiền khuyến mãi của món này
                            orderDetail.Promote = "Khuyến mãi";
                        }
                    }
                    else
                    {
                        if (product != null)
                        {
                            orderDetail.PricePromote = 0;
                            _MoneyPromote = _MoneyPromote + 0;
                            orderDetail.Promote = "Bình thường";
                        }
                    }

                    TotalMoney = TotalMoney + (1 * (decimal)product.Price);
                       
                    //Cập nhật tổng tiền vào đơn hàng
                    order.Total_Money = TotalMoney < 0 ? 0 : TotalMoney;
                    _dbContext.SaveChanges();

                    //Hiện tổng tiền
                    _payMoney = TotalMoney < 0 ? 0 : TotalMoney;
                    lbl_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_payMoney));
                    //lbl_TotalMoney.EditValue = TotalMoney < 0 ? 0 : TotalMoney;

                    orderDetail.Price = Convert.ToDecimal(product.Price);
                    orderDetail.OrderID = orderIDSelected;
                    orderDetail.Quantity = 1;
                    orderDetail.ProductID = Convert.ToInt32(selectNodeProduct.Name);
                    _dbContext.order_detail.Add(orderDetail);
                    _dbContext.SaveChanges();

                    //--- Select ngay sản phẩm đang thêm
                    bool exist = false;
                    for (int i = 0; i < gridView_Order.RowCount; i++)
                    {
                        if (gridView_Order.GetRowCellValue(i, _cProductID).ToString().Contains(selectNodeProduct.Name) == true)
                        {
                            gridView_Order.FocusedRowHandle = i;
                            exist = true;
                            break;
                        }
                    }
                    if (exist == true)//Nếu sản phẩm này đã có
                    {
                        newRow = gridView_Order.GetFocusedDataRow();
                        newRow[_cQuantity] = Convert.ToInt32(newRow[_cQuantity]) + 1;

                        gridView_Order.LayoutChanged();

                        foreach (DataRow r in _tbSourceOrderDetail.Rows)
                        {
                            if (Convert.ToInt32(r[_cProductID]) == orderDetail.ProductID)
                            {
                                r[_cMoneyPromote] = Convert.ToDecimal(r[_cMoneyPromote]) + (orderDetail.Price - orderDetail.PricePromote);
                                break;
                            }
                        }
                    }
                    else
                    {
                        newRow = _tbSourceOrderDetail.NewRow();
                        newRow[_cID] = orderDetail.ID;
                        newRow[_cOrderID] = orderDetail.OrderID;
                        newRow[_cProductID] = orderDetail.ProductID;
                        newRow[_cProductName] = e.Node.Text;
                        newRow[_cQuantity] = 1;
                        newRow[_cPrice] = orderDetail.Price;
                        newRow[_cMoneyPromote] = orderDetail.PricePromote;
                          
                        _tbSourceOrderDetail.Rows.Add(newRow);
                    }

                    //Xử lý kho

                    //Định lượng
                    determines = (from dtmine in _dbContext.determines.ToList() where dtmine.ProductID == Convert.ToInt32(selectNodeProduct.Name) select dtmine).ToList();
                    if (determines != null && determines.Count > 0)//Có định lượng
                    {
                        foreach(determine m in determines)
                        {
                            tk = new tonkho();
                            tk = (from k in _dbContext.tonkhoes.ToList() where k.MAMH == m.ProcductDetermine select k).FirstOrDefault();
                            if (tk != null)
                            {
                                tk.SOLUONGXUAT = tk.SOLUONGXUAT + 1;
                                tk.SOLUONGTON = tk.SOLUONGNHAP - tk.SOLUONGXUAT;
                                _dbContext.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        tk = new tonkho();
                        tk = (from k in _dbContext.tonkhoes.ToList() where k.MAMH == Convert.ToInt32(selectNodeProduct.Name) select k).FirstOrDefault();
                        if (tk != null)
                        {
                            tk.SOLUONGXUAT = tk.SOLUONGXUAT + 1;
                            tk.SOLUONGTON = tk.SOLUONGNHAP - tk.SOLUONGXUAT;
                            _dbContext.SaveChanges();
                        }
                    }

                    //Ghi log
                    WriteLog("Thêm sản phẩm " + e.Node.Text + " với số lượng là " + orderDetail.Quantity + " vào đơn hàng có mã là " + orderDetail.OrderID);

                    log.Info("Lúc " + DateTime.Now + ". Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ")" + "thêm sản phẩm " + e.Node.Text + "với số lượng là " + 1 + " vào đơn hàng có mã là " + orderDetail.OrderID);
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_ProductTable_NodeMouseClick");
            }
        }

        private void button_UpdateProductOrder_Click(object sender, EventArgs e)
        {
            order_detail orderDetail;
            List<promote_detail> promteDetail;
            listorder order;
            DataRow updateRow;
            frm_AddEditOrder dlg;
            DataTable tb = new DataTable();
            decimal TotalMoney = 0;
            decimal price = 0;
            string _promote = "Khuyến mãi";
            DateTime dt = DateTime.Now;
            int _Quantity = 0;
            product product;

            try
            {
                if (gridView_Order.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn món", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                updateRow = gridView_Order.GetFocusedDataRow();
                orderDetail = new order_detail();
                orderDetail.OrderID = Convert.ToInt32(updateRow[_cOrderID]);
                orderDetail.ProductID = Convert.ToInt32(updateRow[_cProductID]);
                orderDetail.Quantity = Convert.ToInt32(updateRow[_cQuantity]);

                dlg = new frm_AddEditOrder();
                dlg.P_OrderDetail = orderDetail;
                dlg.P_Quantity = 0;
                dlg._ProductName = updateRow[_cProductName].ToString();
                dlg._checkUpdateOrChange = false;
                dlg.Text = "Cập Nhật Món " + dlg._ProductName;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tb = dlg._tbSource;
                    _MoneyPromote = 0;
                    //Lấy tổng tiền hiện tại của đơn hàng
                    order = (from o in _dbContext.listorders.ToList() where o.OrderID == Convert.ToInt32(updateRow[_cOrderID]) select o).FirstOrDefault();
                    if (order != null)
                    {
                        TotalMoney = (decimal)order.Total_Money;
                    }

                    for (int j = 0; j < tb.Rows.Count; j++)
                    {

                        product = (from p in _dbContext.products.ToList() where p.ProductID == Convert.ToInt32(tb.Rows[j][_cProductID]) select p).FirstOrDefault();
                        //Lấy giá của sản phẩm này . 
                        //Ưu tiên chọn trong bảng khuyến mãi trước. Nếu không thuộc diện khuyến mãi thì lấy giá gốc
                        promteDetail = (from pr in _dbContext.promote_detail.ToList()

                                        where pr.ProductID == Convert.ToInt32(tb.Rows[j][_cProductID]) &&
                                            pr.EndDate >= dt && pr.Deleted == 2 && pr.promote.Deleted == 2
                                        select pr).ToList();

                        if (promteDetail != null && promteDetail.Count > 0)
                        {
                            foreach (promote_detail item in promteDetail)
                            {
                                _MoneyPromote =Convert.ToInt32(tb.Rows[j][_cQuantity]) * ((decimal)item.product.Price - (decimal)item.Price);//Tiền khuyến mãi của món này
                                _promote = "Khuyến mãi";
                            }
                        }
                        else
                        {
                            if (product != null)
                            {         
                                _MoneyPromote = 0;//Tiền khuyến mãi của món này
                                _promote = "Bình thường";
                            }
                        }

                        TotalMoney = TotalMoney + (Convert.ToInt32(tb.Rows[j][_cQuantity]) * (decimal)product.Price);
                        price = product.Price != null ? Convert.ToDecimal(product.Price):0;

                        //Cập nhật tổng tiền vào đơn hàng
                        TotalMoney = TotalMoney < 0 ? 0 : TotalMoney;
                       // _dbContext.ExecuteCommand("Update ListOrder Set Total_Money={0} where OrderID={1}", TotalMoney, order.OrderID);
                        MySqlCommand cmd = new MySqlCommand();
                        MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                        cmd = con.CreateCommand();
                        //Cập nhật tiền khuyến mãi
                        cmd.CommandText = "Update listorder Set Total_Money='"+TotalMoney+"' where OrderID='"+order.OrderID+"'";


                        _payMoney = TotalMoney < 0 ? 0 : TotalMoney;
                        lbl_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_payMoney));

                        cmd.CommandText = "Insert Into order_detail(OrderID,ProductID,Quantity,Price,PricePromote,Date,Promote) Values('"+order.OrderID+"','"+Convert.ToInt32(tb.Rows[j][_cProductID])+"','"+Convert.ToInt32(tb.Rows[j][_cQuantity])+"','"+price+"','"+_MoneyPromote+"','"+dt+"','"+_promote+"')";

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                      

                       // _dbContext.ExecuteCommand("Insert Into Order_Detail(OrderID,ProductID,Quantity,Price,PricePromote,Date,Promote) Values({0},{1},{2},{3},{4},{5},{6})", order.OrderID, Convert.ToInt32(tb.Rows[j][_cProductID]), Convert.ToInt32(tb.Rows[j][_cQuantity]), price, _MoneyPromote, dt, _promote);

                    }

                    ///////////////////////////////-----------XÓA------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    //Cập nhật chi tiết đơn hàng
                    //_dbContext.ExecuteCommand("Update Order_Detail Set Quantity={0} Where OrderID={1} And ProductID={2}", dlg.P_OrderDetail.Quantity, orderIDSelected, Convert.ToInt32(focusRow[_cProductID]));
                    for (int i = dlg.P_Quantity; i >= 0; i--)
                    {
                        orderDetail = (from o in _dbContext.order_detail.ToList() where o.OrderID == Convert.ToInt32(updateRow[_cOrderID]) && o.ProductID == Convert.ToInt32(updateRow[_cProductID]) select o).FirstOrDefault();
                        dt = orderDetail.Date;//Lưu ngày khuyến mãi
                        if (orderDetail != null)
                        {
                            if (orderDetail.Quantity < i)//Số lượng của row nhỏ hơn số lượng muốn giảm thì xóa ngay 
                            {
                                _Quantity = orderDetail.Quantity;
                                updateRow[_cQuantity] = Convert.ToInt32(updateRow[_cQuantity]) - orderDetail.Quantity;
                                _dbContext.order_detail.Remove(orderDetail);
                                _dbContext.SaveChanges();

                            }
                            else if (orderDetail.Quantity == i)
                            {
                                _Quantity = orderDetail.Quantity;
                                updateRow[_cQuantity] = Convert.ToInt32(updateRow[_cQuantity]) - orderDetail.Quantity;
                                _dbContext.order_detail.Remove(orderDetail);
                                _dbContext.SaveChanges();
                                i = 0;//Thoát. Xóa xong
                            }
                            else if (orderDetail.Quantity > i)
                            {
                                _Quantity = i;
                                updateRow[_cQuantity] = Convert.ToInt32(updateRow[_cQuantity]) - i;
                                orderDetail.Quantity = Convert.ToInt32(updateRow[_cQuantity]);
                                _dbContext.SaveChanges();
                                i = 0;//Thoát. Xóa xong
                            }

                            product = (from p in _dbContext.products.ToList() where p.ProductID == Convert.ToInt32(updateRow[_cProductID]) select p).FirstOrDefault();
                            ////Lấy giá của sản phẩm này . 
                            //Ưu tiên chọn trong bảng khuyến mãi trước. Nếu không thuộc diện khuyến mãi thì lấy giá gốc
                            promteDetail = (from pr in _dbContext.promote_detail.ToList()
                                            where pr.ProductID == Convert.ToInt32(updateRow[_cProductID]) &&
                                                pr.EndDate >= dt && pr.Deleted == 2 && pr.promote.Deleted == 2
                                            select pr).ToList();

                            if (promteDetail != null && promteDetail.Count > 0)
                            {
                                foreach (promote_detail item in promteDetail)
                                {
                                    _MoneyPromote = orderDetail.PricePromote - (_Quantity *((decimal)item.product.Price - (decimal)item.Price));//Tiền khuyến mãi của món này
                                }
                            }
                            else
                            {                                
                                if (product != null)
                                {
                                    _MoneyPromote = orderDetail.PricePromote - 0;//Tiền khuyến mãi của món này
                                }
                            }

                            //Cập nhật tiền khuyến mãi
                           // _dbContext.ExecuteCommand("Update Order_Detail Set PricePromote={0} where OrderID={1} And ProductID={2}",_MoneyPromote,Convert.ToInt32(updateRow[_cOrderID]),Convert.ToInt32(updateRow[_cProductID]));

                            //TotalMoney = TotalMoney - (_Quantity * (decimal)product.Price);
        
                            ////Cập nhật tổng tiền vào đơn hàng
                            //order.Total_Money = TotalMoney < 0 ? 0 : TotalMoney;
                            //_dbContext.SaveChanges();
                            //_dbContext.ExecuteCommand("Update ListOrder Set Total_Money={0} where OrderID={1}",TotalMoney,Convert.ToInt32(updateRow[_cOrderID]));


                            MySqlCommand cmd = new MySqlCommand();
                            MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                            cmd = con.CreateCommand();
                            //Cập nhật tiền khuyến mãi
                            cmd.CommandText = "Update order_detail Set PricePromote='"+_MoneyPromote+"' where OrderID='"+Convert.ToInt32(updateRow[_cOrderID])+"' And ProductID='"+Convert.ToInt32(updateRow[_cProductID])+"'";


                            TotalMoney = TotalMoney - (_Quantity * (decimal)product.Price);

                            //Cập nhật tổng tiền vào đơn hàng
                            order.Total_Money = TotalMoney < 0 ? 0 : TotalMoney;

                            cmd.CommandText = "Update listorder Set Total_Money='"+TotalMoney+"' where OrderID='"+Convert.ToInt32(updateRow[_cOrderID])+"'";

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();


                            _payMoney = TotalMoney < 0 ? 0 : TotalMoney;
                            lbl_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_payMoney));

                            gridView_Order.LayoutChanged();

                            //Cập nhật tbSource
                            foreach (DataRow r in _tbSourceOrderDetail.Rows)
                            {
                                if (Convert.ToInt32(r[_cProductID]) == Convert.ToInt32(updateRow[_cProductID]))
                                {
                                    r[_cMoneyPromote] = _MoneyPromote;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            i = 0;
                        }
                    }

                    //Load lại danh sách
                    LoadOrderAndProduct(orderIDSelected);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_UpdateProductOrder_Click");
            }
        }

        private void btn_DeleteOrderDetail_Click(object sender, EventArgs e)
        {
            List<order_detail> deleteRow;
            listorder order;
            DataRow focusRow;
            DateTime dt;
            decimal TotalMoney = 0;
            product product;

            try
            {
                if (gridView_Order.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn món", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa món này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_Order.GetFocusedDataRow();
                deleteRow = (from o in _dbContext.order_detail.ToList() where o.OrderID == orderIDSelected && o.ProductID == Convert.ToInt32(focusRow[_cProductID]) select o).ToList();


                if (deleteRow != null && deleteRow.Count > 0)
                {
                    foreach (order_detail de in deleteRow)
                    {
                        //Lấy tổng tiền hiện tại của đơn hàng
                        order = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();
                        if (order != null)
                        {
                            TotalMoney = (decimal)order.Total_Money;
                        }

                        dt = de.Date;

                        ////Lấy giá của sản phẩm này . 
                        ////Ưu tiên chọn trong bảng khuyến mãi trước. Nếu không thuộc diện khuyến mãi thì lấy giá gốc
                        //promteDetail = (from pr in _dbContext.Promote_Details
                        //                where pr.ProductID == Convert.ToInt32(focusRow[_cProductID]) &&
                        //                    pr.EndDate >= dt && pr.Deleted == false && pr.Promote.Deleted == false
                        //                select pr).ToList();

                        //if (promteDetail != null && promteDetail.Count > 0)
                        //{
                        //    foreach (Promote_Detail item in promteDetail)
                        //    {
                        //        TotalMoney = TotalMoney - (de.Quantity * (decimal)item.Price);
                        //    }
                        //}
                        //else
                        //{
                        //    var product = (from p in _dbContext.Products where p.ProductID == Convert.ToInt32(focusRow[_cProductID]) select p).FirstOrDefault();
                        //    if (product != null)
                        //    {
                        //        TotalMoney = TotalMoney - (de.Quantity * (decimal)product.Price);
                        //    }
                        //}

                        product = (from p in _dbContext.products.ToList() where p.ProductID == Convert.ToInt32(focusRow[_cProductID]) select p).FirstOrDefault();
                        if (product != null)
                        {
                            TotalMoney = TotalMoney - (de.Quantity * (decimal)product.Price);
                        }

                        //Cập nhật tổng tiền vào đơn hàng
                        order.Total_Money = TotalMoney < 0 ? 0 : TotalMoney;
                        _dbContext.SaveChanges();

                        _payMoney = TotalMoney < 0 ? 0 : TotalMoney;
                        lbl_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_payMoney));

                        _dbContext.order_detail.Remove(de);
                        _dbContext.SaveChanges();
                    }                   
                    gridView_Order.DeleteRow(gridView_Order.GetSelectedRows()[0]);
                }


                LoadOrderAndProduct(orderIDSelected);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_DeleteOrderDetail_Click");
            }
        }

        private void btn_Employee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_AccountManager dlg;
            List<planwork> planwork;
            try
            {
                planwork = (from p in _dbContext.planworks.ToList() select p).ToList();
                if (planwork.Count <= 0)
                {
                    XtraMessageBox.Show("Danh sách ca làm việc trống. Vui lòng khai báo ca làm việc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frm_PlanWork dlg_PlanWork = new frm_PlanWork();
                    dlg_PlanWork.Text = "Danh Sách Ca Làm Việc";
                    dlg_PlanWork.ShowDialog();
                    return;
                }
                dlg = new frm_AccountManager();
                dlg.Text = "Nhân Viên";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Employee_ItemClick");
            }
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            try
            {
                Logout();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "button_Logout_Click");
            }
        }

        private void btn_PlanDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PlanDay dlg;
            money_trading moneys;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dlg = new frm_PlanDay();
                moneys = new money_trading();

                moneys.TotalMoney = 0;
                dlg.P_PlanDay = moneys;
                dlg.Text = "Lập Kế Hoạch";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //Thêm mới kế hoạch
                    dlg.P_PlanDay.Status = 1;
                    dlg.P_PlanDay.EmployeeID = CoffeeHelpers.EmpLogin.EmployeeID;
                    dlg.P_PlanDay.ReceiveByEmployeeID = CoffeeHelpers.EmpLogin.EmployeeID;
                    dlg.P_PlanDay.ReceiveByEmployeeName = CoffeeHelpers.EmpLogin.EmployeeName;
                    _dbContext.money_trading.Add(dlg.P_PlanDay);
                    _dbContext.SaveChanges();

                    //Hiên lên giao diện

                    _planMoney = _planMoney + dlg.P_PlanDay.TotalMoney;
                    _totalMoney = _totalMoney + dlg.P_PlanDay.TotalMoney;
                    _creditMoney = 0;

                    textEdit_PlanMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_planMoney));
                    textEdit_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_planMoney));
                    textEdit_MoneyCredit.Text = string.Format("{0:#,#}", Convert.ToDecimal("0"));

                    btn_PlanDay.Enabled = false;
                    btn_UpdatePlanDay.Enabled = true;
                    btn_EndPlanDay.Enabled = true;

                    tableLayoutPanel_Main.Enabled = true;
                    _ActiveButtonPay = true;

                    //Ghi log
                    WriteLog("Tạo ngân quỹ là " + dlg.P_PlanDay.TotalMoney);

                    log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " đã tạo ngân quỹ là " + dlg.P_PlanDay.TotalMoney);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_PlanDay_ItemClick");
            }
        }

        //Sửa kế hoạch
        private void btn_UpdatePlanDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PlanDay dlg;
            money_trading moneys,updateMoney;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dlg = new frm_PlanDay();
                moneys = new money_trading();

                moneys.TotalMoney = Convert.ToDecimal(_totalMoney);
                dlg.P_PlanDay = moneys;
                dlg.Text = "Sửa Ngân Quỹ";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    moneys = (from mn in _dbContext.money_trading.ToList() select mn).FirstOrDefault();
                    updateMoney = (from mn in _dbContext.money_trading.ToList() select mn).OrderByDescending(a => a.ID).FirstOrDefault();
                    //Hiên lên giao diện
                    _planMoney = moneys.TotalMoney + dlg.P_PlanDay.MoneyCredit;
                    _totalMoney = updateMoney.MoneyCredit + dlg.P_PlanDay.MoneyCredit;
                    _creditMoney = _totalMoney - _planMoney;

                    textEdit_PlanMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_planMoney));
                    textEdit_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_totalMoney));
                    textEdit_MoneyCredit.Text = string.Format("{0:#,#}", Convert.ToDecimal(_creditMoney));


                    updateMoney.TotalMoney = _planMoney;
                    updateMoney.MoneyCredit = _totalMoney;
                    moneys.Notes = dlg.P_PlanDay.Notes;
                    _dbContext.SaveChanges();

                    //Ghi log
                    WriteLog("Sửa ngân quỹ");

                    log.Info("Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") sửa ngân quỹ lúc " + DateTime.Now.ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_UpdatePlanDay_ItemClick");
            }
        }

        private void btn_EndPlanDay_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_ViewPlanDay dlg;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dlg = new frm_ViewPlanDay();
                if (xtraScrollable_TableActive.Controls.Count > 0)
                {
                    dlg._checkEndPlanDay = true;
                }
                else
                {
                    dlg._checkEndPlanDay = false;
                }
                dlg.Text = "Chi Tiết Doanh Thu Hôm Nay";
                if (dlg.ShowDialog() == DialogResult.OK)
                {


                    MySqlCommand cmd = new MySqlCommand();
                    MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                    cmd = con.CreateCommand();
                    //Cập nhật tiền khuyến mãi
                    cmd.CommandText = "Delete from money_trading";

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //_dbContext.ExecuteCommand("Delete Money_Trading");

                    //Bỏ kích hoạt chức năng thanh toán
                    btn_Pay.Enabled = false;
                    barButtonItem_Pay.Visibility = BarItemVisibility.Never;
                    _ActiveButtonPay = false;
                    _receivePlanWork = false;// Đã hết ca trong ngày

                    btn_PlanDay.Enabled = true;
                    btn_UpdatePlanDay.Enabled = false;

                    //Ghi log
                    WriteLog("Kết thúc kế hoạch ngày");

                    log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + "(" + CoffeeHelpers.EmpLogin.EmployeeID + ")" + " kết thúc kế hoạch trong ngày");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_EndPlanDay_ItemClick");
            }
        }

        private void panelControl_TableActive_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (areaIDChecked != -1)
                {
                    //Load danh sách bàn đang bán
                    LoadOrderTable_FromTableSource(areaIDChecked);
                }

                if (orderIDSelected != -1)
                {
                    //Thao tác click chọn đơn hàng
                    SelectOrder_Click(orderIDSelected);

                    //Thông tin chi tiết đơn hàng
                    LoadOrderAndProduct(orderIDSelected);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "panelControl_TableActive_SizeChanged");
            }
        }

        private void textEdit_TotalMoney_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textEdit_MoneyCredit.Text = string.Format("{0:#,#}", Convert.ToDecimal(Convert.ToDecimal(_totalMoney) - Convert.ToDecimal(_planMoney)));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "textEdit_TotalMoney_TextChanged");
            }
        }

        private void btn_InputOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_InputOrder dlg;
            try
            {
                dlg = new frm_InputOrder();
                dlg._configMaxArea = config.MaxArea;
                dlg.list_Image = this.imageList_Product;
                dlg.Text = "Nhập Hoá Đơn Đã Thanh Toán";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_InputOrder_ItemClick");
            }
        }

        private void btn_Default_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Default_ItemClick");
            }
        }

        private void btn_updateLoginName_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_ChangeNameLogin dlg;
            employee emp;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dlg = new frm_ChangeNameLogin();
                dlg._oldPass = _defaultPassLogin;
                dlg._changeCode = _defaultCodeLogin;
                dlg.Text = "Đổi Tên Đăng Nhập";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    emp = (from em in _dbContext.employees.ToList() where em.EmployeeID == CoffeeHelpers.EmpLogin.EmployeeID select em).FirstOrDefault();
                    emp.EmployeeCode = dlg._changeCode;
                    emp.ChangeEmployeeCode = 1;
                    _dbContext.SaveChanges();

                    StartRestarter("Bạn đợi đăng nhập lại", 167, 50);
                    //Kết thúc mọi xử lý
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_InputOrder_ItemClick");
            }
        }

        private void btn_PlusTable_Click(object sender, EventArgs e)
        {
            frm_PlusTable dlg;
            listorder listOrders, defaulOrders;

            List<order_detail> list_Detail;
            int _defaultSelect = orderIDSelected;
            try
            {
                if (orderIDSelected == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn bàn", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                dlg = new frm_PlusTable();
                defaulOrders = new listorder();

                defaulOrders = (from o in _dbContext.listorders.ToList() where o.OrderID == _defaultSelect select o).FirstOrDefault();

                dlg.P_ListOrder = defaulOrders;
                dlg._AreaID = areaIDChecked;
                dlg._config = config;
                dlg._PlusOrChange = 1;
                dlg._dbContext = _dbContext;
                dlg.Text = "GỘP BÀN";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg._listOrder.Count > 0)
                    {

                        for (int i = 0; i < dlg._listOrder.Count; i++)
                        {
                            listOrders = (from o in _dbContext.listorders.ToList() where o.OrderID == Convert.ToInt32(dlg._listOrder[i]) select o).FirstOrDefault();

                            //Cập nhật tổng tiền cho đơn hàng được gộp
                            defaulOrders.Total_Money = defaulOrders.Total_Money + listOrders.Total_Money;
                            _dbContext.SaveChanges();

                            list_Detail = (from ls in _dbContext.order_detail.ToList() where ls.OrderID == Convert.ToInt32(dlg._listOrder[i]) select ls).ToList();

                            if (list_Detail != null && list_Detail.Count > 0)
                            {
                                foreach (order_detail or in list_Detail)
                                {
                                    or.OrderID = orderIDSelected;// Tiến hành gộp
                                    _dbContext.SaveChanges();
                                }
                            }
                            //Xoá bàn khỏi danh sách đơn hàng

                            MySqlCommand cmd = new MySqlCommand();
                            MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                            cmd = con.CreateCommand();
                            //Cập nhật tiền khuyến mãi
                            cmd.CommandText = "Delete from listorder where OrderID='" + Convert.ToInt32(dlg._listOrder[i]) + "'";

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            //_dbContext.ExecuteCommand("Delete ListOrder where OrderID={0}", Convert.ToInt32(dlg._listOrder[i]));

                            //Load lại danh sách bàn đang bán
                            int j = 0;
                            foreach (DataRow r in _tbSourceListOrder.Rows)
                            {
                                if (Convert.ToInt32(r[_cOrderID]) == Convert.ToInt32(dlg._listOrder[i]))
                                {
                                    _tbSourceListOrder.Rows.Remove((r));
                                    break;
                                }
                                j++;
                            }

                            //Ghi log
                            WriteLog("Gộp bàn");

                            log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") tiến hành gộp bàn");

                            //Làm mói danh sách bàn đang bán
                            LoadOrderTable_FromTableSource(areaIDChecked);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_PlusTable_Click");
            }
        }

        // Ghi log
        private void WriteLog(string action)
        {
            log lg;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                lg = new log();
                lg.employeename = CoffeeHelpers.EmpLogin.EmployeeName;
                lg.actiondate= DateTime.Now;
                lg.actions = action;

                _dbContext.logs.Add(lg);
                _dbContext.SaveChanges();
            }
            catch
            {
            }
        }

        private void btn_Pay_Click(object sender, EventArgs e)
        {
            frm_Pay dlg;
            listorder order;
            area_table areaTable;
            money_trading money_tradings;
            DataSet_HoaDonThanhToan.DataTable_HoaDonThanhToanRow row;
            khachhang khs;
            List<smartlink> smlinks;

            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                ds = new DataSet_HoaDonThanhToan();
                money_tradings = (from mn in _dbContext.money_trading.ToList() where mn.ReceiveByEmployeeID == CoffeeHelpers.EmpLogin.EmployeeID select mn).OrderByDescending(d => d.ReceiveDate).FirstOrDefault();

                if (money_tradings != null)
                {

                    if (money_tradings.EmployeeID != CoffeeHelpers.EmpLogin.EmployeeID)
                    {
                        XtraMessageBox.Show("Không được phép thanh toán. Bạn chưa nhận ca này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (orderIDSelected == -1)
                    {
                        XtraMessageBox.Show("Không có bàn nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (gridView_Order.RowCount <= 0)
                    {
                        XtraMessageBox.Show("Bàn chưa có món nào", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int i = 1;
                    foreach (DataRow r in _tbSourceOrderDetail.Rows)
                    {
                        row = ds.DataTable_HoaDonThanhToan.NewDataTable_HoaDonThanhToanRow();
                        row.ID = i;
                        row.ProductName = r[_cProductName].ToString();
                        row.Quantity = r[_cQuantity].ToString();
                        row.Price =(Convert.ToInt32(r[_cPrice].ToString()) / Convert.ToInt32(r[_cQuantity]))!=0?string.Format("{0:#,#}", Convert.ToDecimal((Convert.ToInt32(r[_cPrice].ToString()) / Convert.ToInt32(r[_cQuantity])).ToString())):string.Format("{0:#,#}", "0");;
                        row.Money =Convert.ToInt32(r[_cPrice].ToString())!=0? string.Format("{0:#,#}", Convert.ToDecimal(r[_cPrice].ToString())):string.Format("{0:#,#}", "0");
                        row.MoneyPromote =Convert.ToInt32(r[_cMoneyPromote].ToString())!=0? string.Format("{0:#,#}", Convert.ToDecimal(r[_cMoneyPromote].ToString())):string.Format("{0:#,#}", "0");;
                        ds.DataTable_HoaDonThanhToan.AddDataTable_HoaDonThanhToanRow(row);
                        i++;
                    }

                    order = new listorder();
                    order = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();

                    dlg = new frm_Pay();
                    dlg.ds = ds;
                    dlg._dbContext = _dbContext;
                    dlg.P_Promote = _MoneyPromote;
                    dlg.P_Company = companys;
                    dlg.P_OrderCode = order.Ordercode;
                    dlg._config = config;
                    dlg.P_TableName = order.area_table.TableCode;
                    dlg.P_TotalMoney = order.Total_Money;
                    dlg.Text = "THANH TOÁN ĐƠN HÀNG";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        order.Status = 2;
                        order.EndDate = DateTime.Now;
                        order.Notes = dlg.P_Notes;
                        order.EmployeeTransfer = CoffeeHelpers.EmpLogin.EmployeeID;
                        _dbContext.SaveChanges();

                        areaTable = (from ar in _dbContext.area_table.ToList() where ar.TableID == order.TableID select ar).FirstOrDefault();
                        areaTable.Empty = 1;
                        _dbContext.SaveChanges();

                        //Cập nhật tổng doanh thu
                        _totalMoney = ((money_tradings.MoneyCredit + dlg.P_MustPay));
                        textEdit_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_totalMoney));

                        //Cập nhật lại tổng tiền cho đơn hàng
                        order.Total_Money = dlg.P_MustPay;
                        if (dlg.P_ReturnMoney >= 0)
                        {
                            order.MoneyPayed = dlg.P_MustPay;
                        }
                        else
                        {
                            order.MoneyPayed=(dlg.P_MustPay-dlg.P_CustomerMoney);
                        }
                        //chiết khấu
                        order.PercentMoney = dlg.P_ChietKhau;
                        order.KhachHang = dlg.P_KHCode;

                        _dbContext.SaveChanges();

                        //Update tổng doanh thu
                        money_tradings.MoneyCredit = (money_tradings.MoneyCredit + dlg.P_MustPay);
                        _dbContext.SaveChanges();

                        //Cập nhật khoản tiền cho khách hàng
                        if (dlg.checkCustomer == true)
                        {
                            khs = (from kh in _dbContext.khachhangs.ToList() where kh.KHCode.Trim() == dlg.P_KHCode select kh).FirstOrDefault();
                            smlinks = (from sm in _dbContext.smartlinks.ToList() select sm).ToList();
                            if (khs != null)
                            {
                                khs.TotalMoney = khs.TotalMoney + dlg.P_MustPay;

                                //Xem số tiền tích luỹ của khách đã ở ngưỡng nào để thay đổi cấp bậc thành viên
                                foreach (smartlink m in smlinks)
                                {
                                    if (khs.TotalMoney >= m.LevelMoney)
                                    {
                                        khs.SmarkLink = m.ID;
                                    }
                                }

                                _dbContext.SaveChanges();
                            }
                        }

                        //Danh sách chi tiết về rỗng
                        gridControl_Order.DataSource = null;
                        groupControl_OrderDetail.Text = "Nội dung thực đơn";

                        lbl_TotalMoney.Text = string.Format("{0:#,#}", "0");// Tổng tiền về 0 khi mới thanh toán

                        //Load lại danh sách bàn trống
                        treeView_TableEmpty.Nodes.Add(order.TableID.ToString(), order.area_table.TableCode, order.area_table.ImageIndex, order.area_table.ImageIndex);

                        //Load lại danh sách bàn đang bán
                        LoadOrderTableData(areaIDChecked);

                        //Load thông tin doanh thu của từng nhân vien trực
                        Load_CreditOfEmployee();

                        // Ghi log
                        WriteLog("thanh toán đơn hàng " + order.Ordercode + " có số tiền là " + dlg.P_MustPay + " (vnđ)");

                        log.Info("Lúc " + DateTime.Now + ". Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") thanh toán đơn hàng " + order.Ordercode + " có số tiền là " + dlg.P_MustPay + " (vnđ)");

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_Pay_Click");
            }
        }

        private void checkEdit_Hide_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "checkEdit_Hide_CheckedChanged");
            }
        }

        //Thanh toán đơn hàng
        private void barButtonItem_Pay_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_Pay dlg;
            listorder order;
            area_table areaTable;
            money_trading money_tradings;
            DataSet_HoaDonThanhToan.DataTable_HoaDonThanhToanRow row;
            khachhang khs;
            List<smartlink> smlinks;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                ds = new DataSet_HoaDonThanhToan();
                money_tradings = (from mn in _dbContext.money_trading.ToList() where mn.ReceiveByEmployeeID == CoffeeHelpers.EmpLogin.EmployeeID select mn).OrderByDescending(d => d.ReceiveDate).FirstOrDefault();

                if (money_tradings != null)
                {

                    if (money_tradings.EmployeeID != CoffeeHelpers.EmpLogin.EmployeeID)
                    {
                        XtraMessageBox.Show("Không được phép thanh toán. Bạn chưa nhận ca này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (orderIDSelected == -1)
                    {
                        XtraMessageBox.Show("Không có bàn nào được chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (gridView_Order.RowCount <= 0)
                    {
                        XtraMessageBox.Show("Bàn chưa có món nào", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int i = 1;
                    foreach (DataRow r in _tbSourceOrderDetail.Rows)
                    {
                        row = ds.DataTable_HoaDonThanhToan.NewDataTable_HoaDonThanhToanRow();
                        row.ID = i;
                        row.ProductName = r[_cProductName].ToString();
                        row.Quantity = r[_cQuantity].ToString();
                        row.Price = (Convert.ToInt32(r[_cPrice].ToString()) / Convert.ToInt32(r[_cQuantity])) != 0 ? string.Format("{0:#,#}", Convert.ToDecimal((Convert.ToInt32(r[_cPrice].ToString()) / Convert.ToInt32(r[_cQuantity])).ToString())) : string.Format("{0:#,#}", "0"); ;
                        row.Money = Convert.ToInt32(r[_cPrice].ToString()) != 0 ? string.Format("{0:#,#}", Convert.ToDecimal(r[_cPrice].ToString())) : string.Format("{0:#,#}", "0");
                        row.MoneyPromote = Convert.ToInt32(r[_cMoneyPromote].ToString()) != 0 ? string.Format("{0:#,#}", Convert.ToDecimal(r[_cMoneyPromote].ToString())) : string.Format("{0:#,#}", "0"); ;
                        ds.DataTable_HoaDonThanhToan.AddDataTable_HoaDonThanhToanRow(row);
                        i++;
                    }

                    order = new listorder();
                    order = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();

                    dlg = new frm_Pay();
                    dlg.ds = ds;
                    dlg._dbContext = _dbContext;
                    dlg.P_Promote = _MoneyPromote;
                    dlg.P_Company = companys;
                    dlg.P_OrderCode = order.Ordercode;
                    dlg._config = config;
                    dlg.P_TableName = order.area_table.TableCode;
                    dlg.P_TotalMoney = order.Total_Money;
                    dlg.Text = "THANH TOÁN ĐƠN HÀNG";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        order.Status = 2;
                        order.EndDate = DateTime.Now;
                        order.Notes = dlg.P_Notes;
                        order.EmployeeTransfer = CoffeeHelpers.EmpLogin.EmployeeID;
                        _dbContext.SaveChanges();

                        areaTable = (from ar in _dbContext.area_table.ToList() where ar.TableID == order.TableID select ar).FirstOrDefault();
                        areaTable.Empty = 1;
                        _dbContext.SaveChanges();

                        //Cập nhật tổng doanh thu
                        _totalMoney = ((money_tradings.MoneyCredit + dlg.P_MustPay));
                        textEdit_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_totalMoney));

                        //Cập nhật lại tổng tiền cho đơn hàng
                        order.Total_Money = dlg.P_MustPay;
                        if (dlg.P_ReturnMoney >= 0)
                        {
                            order.MoneyPayed = dlg.P_MustPay;
                        }
                        else
                        {
                            order.MoneyPayed = (dlg.P_MustPay - dlg.P_CustomerMoney);
                        }
                        //chiết khấu
                        order.PercentMoney = dlg.P_ChietKhau;
                        order.KhachHang = dlg.P_KHCode;

                        _dbContext.SaveChanges();

                        //Update tổng doanh thu
                        money_tradings.MoneyCredit = (money_tradings.MoneyCredit + dlg.P_MustPay);
                        _dbContext.SaveChanges();

                        //Cập nhật khoản tiền cho khách hàng
                        if (dlg.checkCustomer == true)
                        {
                            khs = (from kh in _dbContext.khachhangs.ToList() where kh.KHCode.Trim() == dlg.P_KHCode select kh).FirstOrDefault();
                            smlinks = (from sm in _dbContext.smartlinks.ToList() select sm).ToList();
                            if (khs != null)
                            {
                                khs.TotalMoney = khs.TotalMoney + dlg.P_MustPay;

                                //Xem số tiền tích luỹ của khách đã ở ngưỡng nào để thay đổi cấp bậc thành viên
                                foreach (smartlink m in smlinks)
                                {
                                    if (khs.TotalMoney >= m.LevelMoney)
                                    {
                                        khs.SmarkLink = m.ID;
                                    }
                                }

                                _dbContext.SaveChanges();
                            }
                        }

                        //Danh sách chi tiết về rỗng
                        gridControl_Order.DataSource = null;
                        groupControl_OrderDetail.Text = "Nội dung thực đơn";

                        lbl_TotalMoney.Text = string.Format("{0:#,#}", "0");// Tổng tiền về 0 khi mới thanh toán

                        //Load lại danh sách bàn trống
                        treeView_TableEmpty.Nodes.Add(order.TableID.ToString(), order.area_table.TableCode, order.area_table.ImageIndex, order.area_table.ImageIndex);

                        //Load lại danh sách bàn đang bán
                        LoadOrderTableData(areaIDChecked);

                        //Load thông tin doanh thu của từng nhân vien trực
                        Load_CreditOfEmployee();

                        //Ghi log
                        WriteLog("Thanh toán đơn hàng " + order.Ordercode + " có số tiền là " + dlg.P_MustPay + " (vnđ)");

                        log.Info("Lúc " + DateTime.Now + ". Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") thanh toán đơn hàng " + order.Ordercode + " có số tiền là " + dlg.P_MustPay + " (vnđ)");

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Pay_ItemClick");
            }
        }

        private void btn_HideProduct_Click(object sender, EventArgs e)
        {
            bool temp;
            try
            {
                if (_checkHideProduct == false)
                {
                    groupControl_ListProduct.Visible = false;
                    btn_HideProduct.Text = "Hiện thực đơn";
                    btn_HideProduct.Image = Coffee.Properties.Resources.Back;
                    temp = true;
                }
                else
                {
                    groupControl_ListProduct.Visible = true;
                    btn_HideProduct.Text = "Ẩn thực đơn";
                    btn_HideProduct.Image = Coffee.Properties.Resources.Forward;
                    temp = false;
                }
                _checkHideProduct = temp;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_HideProduct_Click");
            }
        }

        private void gridView_OrderDetail_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow focusRow;
            try
            {
                focusRow = gridView_Order.GetFocusedDataRow();
                int OrderID = Convert.ToInt32(focusRow["OrderID"]);
                int ProductID = Convert.ToInt32(focusRow["ProductID"]);

                //gridView_OrderDetail.ViewCaption = "Chi tiết của món " + focusRow["ProductName"];

                // LoadOrderDetail( OrderID, ProductID);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_OrderDetail_RowClick");
            }
        }



        private void gridView_Order_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo hi;
            DataRow focusRow;

            try
            {
                hi = gridView_Order.CalcHitInfo(e.Location);

                barButtonItem_AddQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_decreaseQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_Detail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_AllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                if (gridView_Order.SelectedRowsCount > 0)
                {
                    focusRow = gridView_Order.GetFocusedDataRow();

                    if (focusRow != null)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            barButtonItem_AddQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barButtonItem_decreaseQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                        //--- Chỉ hiển thị popup khi user nhấp phải
                        if (e.Button == MouseButtons.Right)
                        {


                            //barButtonItem_AddQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            //barButtonItem_decreaseQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barButtonItem_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barButtonItem_Detail.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barButtonItem_AllDetail.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                    }
                }
                popupMenu_OrderDetail.ShowPopup(Control.MousePosition);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_Order_MouseUp");
            }
        }



        private void treeView_ProductTable_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                barButtonItem_DetailList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_ShortList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem_AddMenu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                if (e.Button == MouseButtons.Right)
                {
                    barButtonItem_DetailList.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItem_ShortList.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    if (CoffeeHelpers.EmpLogin.EmpRight!= CoffeeHelpers.EmpRight.Operator)
                    {
                        barButtonItem_AddMenu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }

                    popupMenu_Product.ShowPopup(Control.MousePosition);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_ProductTable_MouseUp");
            }
        }

        //Show popup tạo bàn
        private void treeView_TableEmpty_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {

                if (e.Button == MouseButtons.Right)
                {
                    return;// Nếu click chuột phải thì không làm gì(chỉ hiện popup)
                }

                selectNodeTable = e.Node;
                if (selectNodeTable == null)
                {
                    return;
                }
                if (e.Button == MouseButtons.Left)
                {
                    barButtonItem_CreateTable.Visibility = BarItemVisibility.Always;
                    barButtonItem_CreateTable.Caption = "Mở " + selectNodeTable.Text;
                    Point pt = new Point(Control.MousePosition.X + 35, Control.MousePosition.Y);//Lệch phải
                    popupMenu_Table.ShowPopup(pt);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "treeView_TableEmpty_NodeMouseClick");
            }
        }
        #endregion

        #endregion

        #region Popup

        //Thêm
        private void barButtonItem_AddQuantity_ItemClick(object sender, ItemClickEventArgs e)
        {
            order_detail orderDetail;
            listorder order;
            List<promote_detail> promteDetail;
            //frm_ChooseProductForOrder dlg;
            DataRow focusRow;
            decimal TotalMoney = 0;
            DateTime dt = DateTime.Now;
            product product;

            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_Order.GetFocusedDataRow();

                //dlg = new frm_ChooseProductForOrder();
                orderDetail = new order_detail();

                product = (from p in _dbContext.products.ToList() where p.ProductID == Convert.ToInt32(focusRow[_cProductID]) select p).FirstOrDefault();
                //Lấy tổng tiền hiện tại của đơn hàng
                order = (from o in _dbContext.listorders.ToList() where o.OrderID == Convert.ToInt32(focusRow[_cOrderID]) select o).FirstOrDefault();
                if (order != null)
                {
                    TotalMoney = (decimal)order.Total_Money;
                }

                //Lấy giá của sản phẩm này . 
                //Ưu tiên chọn trong bảng khuyến mãi trước. Nếu không thuộc diện khuyến mãi thì lấy giá gốc
                promteDetail = (from pr in _dbContext.promote_detail.ToList()
                                where pr.ProductID == Convert.ToInt32(focusRow[_cProductID]) &&
                                    pr.EndDate >= dt && pr.Deleted == 2 && pr.promote.Deleted == 2
                                select pr).ToList();
                if (promteDetail != null && promteDetail.Count > 0)
                {
                    foreach (promote_detail item in promteDetail)
                    {
                        orderDetail.PricePromote = 1 * (decimal)item.Price;
                        _MoneyPromote = _MoneyPromote + (1 * ((decimal)item.product.Price - (decimal)item.Price));//Tiền khuyến mãi của món này
                        orderDetail.Price = (decimal)item.Price;
                        orderDetail.Promote = "Khuyến mãi";
                    }
                }
                else
                {
                    if (product != null)
                    {
                        orderDetail.PricePromote = 0;
                        _MoneyPromote = _MoneyPromote + 0;//Tiền khuyến mãi của món này
                        orderDetail.Price = (decimal)product.Price;
                        orderDetail.Promote = "Bình thường";
                    }
                }
                TotalMoney = TotalMoney + (1 * (decimal)product.Price);

                //Cập nhật tổng tiền vào đơn hàng
                order.Total_Money = TotalMoney < 0 ? 0 : TotalMoney;
                _dbContext.SaveChanges();

                _payMoney = TotalMoney < 0 ? 0 : TotalMoney;
                lbl_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_payMoney));
                orderDetail.Quantity = 1;
                orderDetail.OrderID = Convert.ToInt32(focusRow[_cOrderID]);
                orderDetail.ProductID = Convert.ToInt32(focusRow[_cProductID]);
                _dbContext.order_detail.Add(orderDetail);
                _dbContext.SaveChanges();

                focusRow[_cQuantity] = Convert.ToInt32(focusRow[_cQuantity]) + 1;
                gridView_Order.LayoutChanged();

                foreach (DataRow r in _tbSourceOrderDetail.Rows)
                {
                    if (Convert.ToInt32(r[_cProductID]) == orderDetail.ProductID)
                    {
                        r[_cMoneyPromote] = Convert.ToDecimal(r[_cMoneyPromote]) + (orderDetail.Price - orderDetail.PricePromote);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_AddQuantity_ItemClick");
            }
        }

        //Giảm
        private void barButtonItem_decreaseQuantity_ItemClick(object sender, ItemClickEventArgs e)
        {
            order_detail orderDetail;
            listorder  order;
            List<promote_detail> promteDetail;
            frm_ChooseProductForOrder dlg;
            DataRow focusRow;
            decimal TotalMoney = 0;
            DateTime dt = DateTime.Now;
            int _Quantity = 0;
            product product;

            try
            {

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_Order.GetFocusedDataRow();

                //dlg = new frm_ChooseProductForOrder();
                orderDetail = new order_detail();

                orderDetail.OrderID = Convert.ToInt32(focusRow[_cOrderID]);
                orderDetail.ProductID = Convert.ToInt32(focusRow[_cProductID]);
                orderDetail.Quantity = Convert.ToInt32(focusRow[_cQuantity]);

                //Lấy tổng tiền hiện tại của đơn hàng
                order = (from o in _dbContext.listorders.ToList() where o.OrderID == Convert.ToInt32(focusRow[_cOrderID]) select o).FirstOrDefault();
                if (order != null)
                {
                    TotalMoney = (decimal)order.Total_Money;
                }
                orderDetail = (from o in _dbContext.order_detail.ToList() where o.OrderID == Convert.ToInt32(focusRow[_cOrderID]) && o.ProductID == Convert.ToInt32(focusRow[_cProductID]) select o).FirstOrDefault();
                dt = orderDetail.Date;//Lưu ngày khuyến mãi
                if (orderDetail != null)
                {
                    _Quantity = orderDetail.Quantity;
                    focusRow[_cQuantity] = Convert.ToInt32(focusRow[_cQuantity]) - 1;

                    _dbContext.order_detail.Remove(orderDetail);
                    _dbContext.SaveChanges();

                    if (Convert.ToInt32(focusRow[_cQuantity]) == 0)
                    {
                        gridView_Order.DeleteRow(gridView_Order.GetSelectedRows()[0]);
                    }

                    product = (from p in _dbContext.products.ToList() where p.ProductID == orderDetail.ProductID select p).FirstOrDefault();
                    //Lấy giá của sản phẩm này . 
                    //Ưu tiên chọn trong bảng khuyến mãi trước. Nếu không thuộc diện khuyến mãi thì lấy giá gốc
                    promteDetail = (from pr in _dbContext.promote_detail.ToList()
                                    where pr.ProductID == orderDetail.ProductID &&
                                        pr.EndDate >= dt && pr.Deleted == 2 && pr.promote.Deleted == 2
                                    select pr).ToList();

                    if (promteDetail != null && promteDetail.Count > 0)
                    {
                        foreach (promote_detail item in promteDetail)
                        {
                            _MoneyPromote = orderDetail.PricePromote - (orderDetail.Quantity * ((decimal)item.product.Price - (decimal)item.Price));//Tiền khuyến mãi của món này
                        }
                    }
                    else
                    {
                        if (product != null)
                        {
                            orderDetail.PricePromote = 0;
                            _MoneyPromote = orderDetail.PricePromote - 0;//Tiền khuyến mãi của món này
                        }
                    }

                    MySqlCommand cmd = new MySqlCommand();
                    MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                    cmd = con.CreateCommand();
                    //Cập nhật tiền khuyến mãi
                    cmd.CommandText="Update order_detail Set PricePromote='"+_MoneyPromote+"' where OrderID='"+orderDetail.OrderID+"' And ProductID='"+orderDetail.ProductID+"'";

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    TotalMoney = TotalMoney - (_Quantity * (decimal)product.Price);

                    //Cập nhật tổng tiền vào đơn hàng
                    order.Total_Money = TotalMoney < 0 ? 0 : TotalMoney;
                    _dbContext.SaveChanges();

                    _payMoney = TotalMoney < 0 ? 0 : TotalMoney;
                    lbl_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_payMoney));

                    gridView_Order.LayoutChanged();


                    //Cập nhật tbSource
                    foreach (DataRow r in _tbSourceOrderDetail.Rows)
                    {
                        if (Convert.ToInt32(r[_cProductID]) == orderDetail.ProductID)
                        {
                            r[_cMoneyPromote] = Convert.ToDecimal(r[_cMoneyPromote]) - (orderDetail.Price - orderDetail.PricePromote);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_decreaseQuantity_ItemClick");
            }
        }

        //Xóa
        private void barButtonItem_Delete_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<order_detail> deleteRow;
            listorder order;
            DataRow focusRow;
            DateTime dt;
            decimal TotalMoney = 0;
            product product;

            try
            {
                if (gridView_Order.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn món", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa món này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_Order.GetFocusedDataRow();
                deleteRow = (from o in _dbContext.order_detail.ToList() where o.OrderID == orderIDSelected && o.ProductID == Convert.ToInt32(focusRow[_cProductID]) select o).ToList();


                if (deleteRow != null && deleteRow.Count > 0)
                {
                    foreach (order_detail de in deleteRow)
                    {
                        //Lấy tổng tiền hiện tại của đơn hàng
                        order = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();
                        if (order != null)
                        {
                            TotalMoney = (decimal)order.Total_Money;
                        }

                        dt = de.Date;

                        product = (from p in _dbContext.products.ToList() where p.ProductID == Convert.ToInt32(focusRow[_cProductID]) select p).FirstOrDefault();
                        if (product != null)
                        {
                            TotalMoney = TotalMoney - (de.Quantity * (decimal)product.Price);
                        }

                        //Cập nhật tổng tiền vào đơn hàng
                        order.Total_Money = TotalMoney < 0 ? 0 : TotalMoney;
                        _dbContext.SaveChanges();

                        _payMoney = TotalMoney < 0 ? 0 : TotalMoney;
                        lbl_TotalMoney.Text = string.Format("{0:#,#}", Convert.ToDecimal(_payMoney));

                        _dbContext.order_detail.Remove(de);
                        _dbContext.SaveChanges();
                    }
                    gridView_Order.DeleteRow(gridView_Order.GetSelectedRows()[0]);
                }

                LoadOrderAndProduct(orderIDSelected);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Delete_ItemClick");
            }
        }

        private void gridView_OrderDetail_MouseUp(object sender, MouseEventArgs e)
        {
            GridHitInfo hi;
            DataRow focusRow;

            try
            {
                hi = gridView_Order.CalcHitInfo(e.Location);
                //--- Chỉ hiển thị popup khi user nhấp phải
                if (e.Button == MouseButtons.Right)
                {
                    barButtonItem_AddQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem_decreaseQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItem_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    if (gridView_Order.SelectedRowsCount > 0)
                    {
                        focusRow = gridView_Order.GetFocusedDataRow();

                        if (focusRow != null)
                        {
                            barButtonItem_AddQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barButtonItem_decreaseQuantity.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                            barButtonItem_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        }
                    }
                    popupMenu_OrderDetail.ShowPopup(Control.MousePosition);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_OrderDetail_MouseUp");
            }
        }

        //Chi tiết danh sách
        private void barButtonItem_DetailList_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (TreeNode node in treeView_ProductTable.Nodes)
                {
                    if (node.Parent == null)
                    {
                        node.ExpandAll();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_DetailList_ItemClick");
            }
        }
        //Thu gọn danh sách
        private void barButtonItem_ShortList_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (TreeNode node in treeView_ProductTable.Nodes)
                {
                    if (node.Parent == null)
                    {
                        node.Collapse();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_ShortList_ItemClick");
            }
        }
        //Thêm thực đơn
        private void barButtonItem_AddMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_Product dlg;
            try
            {
                dlg = new frm_Product();
                dlg.list_Image = this.imageList_Product;
                dlg.Text = "Thêm Thực Đơn";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_AddMenu_ItemClick");
            }
        }
        //Tạo bàn
        private void barButtonItem_CreateTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            TreeNode selectNode;
            int tableID, orderID;
            string tableCode, OrderCode;
            listorder order;
            area_table area_tbl;
            DataRow newRow;

            try
            {
                selectNode = selectNodeTable;

                order = new listorder();

                if (selectNode == null)
                    return;

                tableID = Convert.ToInt32(selectNode.Name);
                tableCode = selectNode.Text;

                orderID = maxOrderID;

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                area_tbl = (from tbl in _dbContext.area_table.ToList() where tbl.TableID == tableID && tbl.Empty == 1 select tbl).FirstOrDefault();

                if (area_tbl != null)
                {
                    OrderCode = "DH-" + orderID + "_0" + tableID + "_0" + area_tbl.AreaID;

                    order.TableID = tableID;
                    order.Ordercode = OrderCode;
                    order.StartDate = DateTime.Now;
                    order.EndDate = null;
                    order.Notes = null;
                    order.EmployeeID = CoffeeHelpers.EmpLogin.EmployeeID;
                    order.Total_Money = 0;
                    order.Status = 1;
                    order.EmployeeTransfer = CoffeeHelpers.EmpLogin.EmployeeID;

                    //Tạo đơn hàng
                    _dbContext.listorders.Add(order);
                    _dbContext.SaveChanges();

                    //Cập nhật trạng thái bàn về đang bán

                    MySqlCommand cmd = new MySqlCommand();
                    MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                    cmd = con.CreateCommand();
                    //Cập nhật tiền khuyến mãi
                    cmd.CommandText = "Update area_table Set Empty='2' where TableID='"+tableID+"'";

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                   // _dbContext.ExecuteCommand("Update Area_Table Set Empty={0} where TableID={1}", false, tableID);

                    treeView_TableEmpty.Nodes.Remove(selectNode);//Xoá bàn trống

                    //Chọn mã đơn hàng cho đơn hàng vừa khởi tạo
                    orderIDSelected = CoffeeHelpers.GetOrderMaxCode();

                    newRow = _tbSourceListOrder.NewRow();//Thêm vào source bàn dang bán
                    newRow[_cOrderID] = orderIDSelected;
                    newRow[_cTableID] = tableID;
                    newRow[_cTableCode] = tableCode;
                    newRow[_cOrderCode] = OrderCode;
                    newRow[_cAreaID] = areaIDChecked;
                    newRow[_cTotal_Money] = 0;
                    _tbSourceListOrder.Rows.Add(newRow);

                    //Thêm bàn đang bán
                    //LoadOrderTableData(areaIDChecked);
                    LoadOrderTable_FromTableSource(areaIDChecked);//Cập nhật giao diện bàn dang bán từ source

                    //Click chọn đơn hàng
                    SelectOrder_Click(orderIDSelected);

                    //Thông tin chi tiết đơn hàng
                    LoadOrderAndProduct(orderIDSelected);

                    //Lưu lại mã đơn hàng lớn nhất
                    maxOrderID = CoffeeHelpers.GetOrderMaxCode() + 1;

                    lbl_TotalMoney.Text = "0";

                    //Ghi log
                    WriteLog("Tạo đơn hàng " + OrderCode);

                    log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + "(" + CoffeeHelpers.EmpLogin.EmployeeID + ")" + "đã tạo đơn hàng " + OrderCode);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_CreateTable_ItemClick");
            }

        }

        private void barButtonItem_Plus_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PlusTable dlg;
            listorder listOrders, defaulOrders;

            List<order_detail> list_Detail;
            int _defaultSelect = orderIDSelected;
            try
            {
                if (orderIDSelected == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn bàn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                dlg = new frm_PlusTable();
                defaulOrders = new listorder();

                defaulOrders = (from o in _dbContext.listorders.ToList() where o.OrderID == _defaultSelect select o).FirstOrDefault();

                dlg.P_ListOrder = defaulOrders;
                dlg._AreaID = areaIDChecked;
                dlg._config = config;
                dlg._PlusOrChange = 1;
                dlg._dbContext = _dbContext;
                dlg.Text = "GỘP BÀN";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg._listOrder.Count > 0)
                    {

                        for (int i = 0; i < dlg._listOrder.Count; i++)
                        {
                            listOrders = (from o in _dbContext.listorders.ToList() where o.OrderID == Convert.ToInt32(dlg._listOrder[i]) select o).FirstOrDefault();

                            //Cập nhật tổng tiền cho đơn hàng được gộp
                            defaulOrders.Total_Money = defaulOrders.Total_Money + listOrders.Total_Money;
                            _dbContext.SaveChanges();

                            list_Detail = (from ls in _dbContext.order_detail.ToList() where ls.OrderID == Convert.ToInt32(dlg._listOrder[i]) select ls).ToList();

                            if (list_Detail != null && list_Detail.Count > 0)
                            {
                                foreach (order_detail or in list_Detail)
                                {
                                    or.OrderID = orderIDSelected;// Tiến hành gộp
                                    _dbContext.SaveChanges();
                                }
                            }
                            //Xoá bàn khỏi danh sách đơn hàng

                            MySqlCommand cmd = new MySqlCommand();
                            MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                            cmd = con.CreateCommand();
                            //Cập nhật tiền khuyến mãi
                            cmd.CommandText = "Delete from listorder where OrderID='" + Convert.ToInt32(dlg._listOrder[i]) + "'";

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            //_dbContext.ExecuteCommand("Delete ListOrder where OrderID={0}", Convert.ToInt32(dlg._listOrder[i]));

                            //Load lại danh sách bàn đang bán
                            int j = 0;
                            foreach (DataRow r in _tbSourceListOrder.Rows)
                            {
                                if (Convert.ToInt32(r[_cOrderID]) == Convert.ToInt32(dlg._listOrder[i]))
                                {
                                    _tbSourceListOrder.Rows.Remove((r));
                                    break;
                                }
                                j++;
                            }

                            //Ghi log
                            WriteLog("Gộp bàn");

                            log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") tiến hành gộp bàn");

                            //Làm mói danh sách bàn đang bán
                            LoadOrderTable_FromTableSource(areaIDChecked);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Plus_ItemClick");
            }
        }

        private void barButton_Salary_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PaySheet dlg;
            try
            {
                dlg = new frm_PaySheet();
                dlg.Text = "Chấm Lương Nhân Viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_Salary_ItemClick");
            }
        }

        private void barButtonItem_Advance_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_Advance dlg;
            try
            {
                dlg = new frm_Advance();
                dlg.company = companys;
                dlg.Text = "Tạm Ứng Lương Cho Nhân Viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Advance_ItemClick");
            }
        }

        private void barButtonItem_Detail_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow row;
            frm_ViewOrderDetail dlg;
            order_detail orderDetail;
            try
            {
                row = gridView_Order.GetFocusedDataRow();
                if (row != null)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    dlg = new frm_ViewOrderDetail();
                    orderDetail = new order_detail();

                    orderDetail.OrderID = Convert.ToInt32(row[_cOrderID]);
                    orderDetail.ProductID = Convert.ToInt32(row[_cProductID]);
                    dlg.P_OrderDetail = orderDetail;
                    dlg._dbContext = _dbContext;
                    dlg.Text = "Danh Sách Chi Tiết Của Món " + row[_cProductName];
                    dlg.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Detail_ItemClick");
            }
        }

        //Hủy bàn
        private void barButtonItem_CancelOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            listorder orders;
            area_table  tables;
            List<order_detail> orderDetail;
            try
            {
                if (XtraMessageBox.Show("Tất cả thực đơn của bàn này sẽ bị hủy. Bạn có chắc muốn xóa bàn này ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                orders = (from o in _dbContext.listorders where o.OrderID == orderIDSelected select o).FirstOrDefault();
                if (orders != null)
                {
                    //Cập nhật bàn này về trống
                    tables = (from t in _dbContext.area_table.ToList() where t.TableID == orders.TableID select t).FirstOrDefault();
                    if (tables != null)
                    {
                        tables.Empty = 1;
                        _dbContext.SaveChanges();

                        //Add lại danh sách bàn trống
                        treeView_TableEmpty.Nodes.Add(orders.TableID.ToString(), orders.area_table.TableCode, orders.area_table.ImageIndex, orders.area_table.ImageIndex);

                        //Xóa chi tiết đơn hàng
                        orderDetail = (from od in _dbContext.order_detail.ToList() where od.OrderID == orderIDSelected select od).ToList();
                        if (orderDetail != null && orderDetail.Count > 0)
                        {
                            foreach (order_detail o in orderDetail)
                            {
                                _dbContext.order_detail.Remove(o);
                                _dbContext.SaveChanges();
                            }
                        }


                        //Load lại danh sách bàn đang bán
                        int i = 0;
                        foreach (DataRow r in _tbSourceListOrder.Rows)
                        {
                            if (Convert.ToInt32(r[_cOrderID]) == orders.OrderID)
                            {
                                _tbSourceListOrder.Rows.Remove((r));
                                break;
                            }
                            i++;
                        }

                        //Ghi log
                        WriteLog("Huỷ đơn hàng " + orders.Ordercode);

                        log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") huỷ đơn hàng " + orders.Ordercode);
               
                        //Xóa đơn hàng

                        //_dbContext.listorders.Remove(orders);
                        //_dbContext.SaveChanges();

                        MySqlCommand cmd = new MySqlCommand();
                        MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                        cmd = con.CreateCommand();
                        cmd.CommandText = "Delete from listorder where OrderID='" + orderIDSelected + "'";

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        lbl_TotalMoney.Text = "0";
                        gridControl_Order.DataSource = null;

                        LoadOrderTable_FromTableSource(areaIDChecked);

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_CancelOrder_ItemClick");
            }
        }
        #endregion

        private void barButtonItem_CustomerSkin_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_CustomerSkin dlg;
            try
            {
                dlg = new frm_CustomerSkin();
                dlg.Text = "Phân Loại Thành Viên";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_CustomerSkin_ItemClick");
            }
        }

        private void barButtonItem_Customer_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_Customer dlg;
            try
            {
                dlg = new frm_Customer();
                dlg.Text = "Danh Sách Khách Hàng";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Customer_ItemClick");
            }
        }

        private void btn_SplitTable_Click(object sender, EventArgs e)
        {
            frm_PlusTable dlg;
            listorder defaulOrders,listOrders;
            area_table tables;
            DataRow newRow;
            try
            {
                if (orderIDSelected == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn bàn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                dlg = new frm_PlusTable();
                defaulOrders = new listorder();

                defaulOrders = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();

                dlg.P_ListOrder = defaulOrders;
                dlg._AreaID = areaIDChecked;
                dlg._config = config;
                dlg._tableCode = defaulOrders.area_table.TableCode;
                dlg._PlusOrChange = 2;
                dlg._dbContext = _dbContext;
                dlg.Text = "CHUYỂN BÀN";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    listOrders = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();

                    //Cập nhật bàn hoàn lại thành bàn trống
                    tables = (from tb in _dbContext.area_table.ToList() where tb.TableID == listOrders.TableID select tb).FirstOrDefault();
                    tables.Empty = 1;
                    _dbContext.SaveChanges();

                    int t = 0;
                    foreach (DataRow row in _tbSourceListOrder.Rows)
                    {
                        if (Convert.ToInt32(row[_cTableID]) == listOrders.TableID)
                        {
                            _tbSourceListOrder.Rows.Remove(row);
                            break;
                        }
                        t++;
                    }

                    //Cập nhật bàn được chuyển tới thành bàn đang bán
                    tables = (from tb in _dbContext.area_table.ToList() where tb.TableID == dlg._tableID select tb).FirstOrDefault();
                    tables.Empty = 2;
                    _dbContext.SaveChanges();

                    newRow = _tbSourceListOrder.NewRow();
                    newRow[_cOrderID] = listOrders.OrderID;
                    newRow[_cOrderCode] = listOrders.Ordercode;
                    newRow[_cTableCode] = tables.TableCode;
                    newRow[_cTableID] = tables.TableID;
                    newRow[_cAreaID] = tables.AreaID;
                    newRow[_cTotal_Money] = listOrders.Total_Money;

                    _tbSourceListOrder.Rows.Add(newRow);

                    //Cập nhật lại bàn
                    listOrders.TableID = dlg._tableID;
                    _dbContext.SaveChanges();

                    //Ghi log
                    WriteLog("Chuyển bàn");

                    log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") tiến hành chuyển bàn");

                    //Load danh sách bàn trống
                    LoadListTableEmpty(areaIDChecked);

                    //Làm mói danh sách bàn đang bán
                    LoadOrderTable_FromTableSource(areaIDChecked);                   
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_SplitTable_Click");
            }
        }

        private void barButtonItem_Split_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PlusTable dlg;
            listorder defaulOrders, listOrders;
            area_table tables;
            DataRow newRow;
            try
            {
                if (orderIDSelected == -1)
                {
                    XtraMessageBox.Show("Vui lòng chọn bàn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                dlg = new frm_PlusTable();
                defaulOrders = new listorder();

                defaulOrders = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();

                dlg.P_ListOrder = defaulOrders;
                dlg._AreaID = areaIDChecked;
                dlg._config = config;
                dlg._tableCode = defaulOrders.area_table.TableCode;
                dlg._PlusOrChange = 2;
                dlg._dbContext = _dbContext;
                dlg.Text = "Chuyển Bàn";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                    listOrders = (from o in _dbContext.listorders.ToList() where o.OrderID == orderIDSelected select o).FirstOrDefault();

                    //Cập nhật bàn hoàn lại thành bàn trống
                    tables = (from tb in _dbContext.area_table.ToList() where tb.TableID == listOrders.TableID select tb).FirstOrDefault();
                    tables.Empty = 1;
                    _dbContext.SaveChanges();

                    int t = 0;
                    foreach (DataRow row in _tbSourceListOrder.Rows)
                    {
                        if (Convert.ToInt32(row[_cTableID]) == listOrders.TableID)
                        {
                            _tbSourceListOrder.Rows.Remove(row);
                            break;
                        }
                        t++;
                    }

                    //Cập nhật bàn được chuyển tới thành bàn đang bán
                    tables = (from tb in _dbContext.area_table.ToList() where tb.TableID == dlg._tableID select tb).FirstOrDefault();
                    tables.Empty = 2;
                    _dbContext.SaveChanges();

                    newRow = _tbSourceListOrder.NewRow();
                    newRow[_cOrderID] = listOrders.OrderID;
                    newRow[_cOrderCode] = listOrders.Ordercode;
                    newRow[_cTableCode] = tables.TableCode;
                    newRow[_cTableID] = tables.TableID;
                    newRow[_cAreaID] = tables.AreaID;
                    newRow[_cTotal_Money] = listOrders.Total_Money;

                    _tbSourceListOrder.Rows.Add(newRow);

                    //Cập nhật lại bàn
                    listOrders.TableID = dlg._tableID;
                    _dbContext.SaveChanges();

                    //Ghi log
                    WriteLog("Chuyển bàn");

                    log.Info("Lúc " + DateTime.Now + " Nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " (" + CoffeeHelpers.EmpLogin.EmployeeID + ") tiến hành chuyển bàn");

                    //Load danh sách bàn trống
                    LoadListTableEmpty(areaIDChecked);

                    //Làm mói danh sách bàn đang bán
                    LoadOrderTable_FromTableSource(areaIDChecked);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Split_ItemClick");
            }
        }

        private void barButtonItem_PhieuThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PhieuThuChi dlg;
            phieuthu pts;
            try
            {
                dlg = new frm_PhieuThuChi();
                pts = new phieuthu();
                dlg.maxCode = CoffeeHelpers.GetPhieuThuMaxCode() + 1;//Mã lớn nhất cộng thêm 1
                dlg._PhieuThu_PhieuChi = 1;//Phiếu thu
                dlg.PhieuThu = pts;
                dlg.company = companys;
                dlg.Text = "Phiếu Thu";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                    _dbContext.phieuthus.Add(dlg.PhieuThu);
                    _dbContext.SaveChanges();

                    // Ghi log
                    WriteLog("Tạo phiếu thu. Lý do: " + dlg.PhieuThu.Reason);

                    log.Info("Lúc " + DateTime.Now + ", nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " tạo phiếu thu. Lý do: "+ dlg.PhieuThu.Reason);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_PhieuThu_ItemClick");
            }
        }

        private void barButtonItem_PhieuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_PhieuThuChi dlg;
            phieuchi pcs;
            try
            {
                dlg = new frm_PhieuThuChi();
                pcs = new phieuchi();
                dlg.maxCode = CoffeeHelpers.GetPhieuChiMaxCode() + 1;//Mã lớn nhất cộng thêm 1
                dlg._PhieuThu_PhieuChi = 2;//Phiếu thu
                dlg.PhieuChi = pcs;
                dlg.company = companys;
                dlg.Text = "Phiếu Chi";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                    _dbContext.phieuchis.Add(dlg.PhieuChi);
                    _dbContext.SaveChanges();

                    // Ghi log
                    WriteLog("Tạo phiếu chi. Lý do: " + dlg.PhieuChi.LyDo);

                    log.Info("Lúc " + DateTime.Now + ", nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " tạo phiếu chi. Lý do: " + dlg.PhieuChi.LyDo);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_PhieuChi_ItemClick");
            }
        }

        private void barButtonItem_InputStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_NhapHoaDon dlg;
            try
            {
                dlg = new frm_NhapHoaDon();
                dlg.Text = "Thông Tin Hoá Đơn Nhập Kho";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_InputStock_ItemClick");
            }
        }

        private void barButtonItem_TonKho_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_Stock dlg;
            try
            {
                dlg = new frm_Stock();
                dlg.list_Image = this.imageList_Product;
                dlg.Text = "Thông Tin Kho Hàng";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_TonKho_ItemClick");
            }
        }

        private void barButtonItem_DSThuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_DanhSachThuChi dlg;
            try
            {
                dlg = new frm_DanhSachThuChi();
                dlg._COMPANY = companys;
                dlg.Text = "Danh Sách Phiếu Thu - Chi";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_DSThuChi_ItemClick");
            }
        }

        private void barButton_EmailReceiver_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_MailReceiver dlg;
            TaskScheduler.TaskScheduler.TriggerItem triggerItem;
            mycoffeeEntities dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

            try
            {
                dlg = new frm_MailReceiver();
                dlg.ShowDialog();
                // Xóa các trigger gởi mail
                for (int i = 0; i < taskScheduler.TriggerItems.Count; i++)
                {
                    triggerItem = taskScheduler.TriggerItems[i];
                    if (triggerItem.Tag != null && triggerItem.Tag.ToString().Contains('@') == true)
                    {
                        taskScheduler.TriggerItems.Remove(triggerItem);
                        i--;
                    }
                }
                // Tạo lại các trigger gởi mail
                IQueryable<mailreceiver> mailRecievers = dbContext.mailreceivers.Where(mail => mail.AutoSend == 1);
                foreach (mailreceiver mailReciever in mailRecievers)
                {
                    if (mailReciever.AutoSendDate.HasValue == true)
                    {
                        triggerItem = new TaskScheduler.TaskScheduler.TriggerItem();
                        triggerItem.Tag = mailReciever.Email;
                        triggerItem.StartDate = DateTime.Now;
                        triggerItem.EndDate = DateTime.MaxValue;
                        triggerItem.TriggerTime = mailReciever.AutoSendDate.Value;
                        triggerItem.TriggerSettings.Daily.Interval = 1;
                        triggerItem.OnTrigger += new TaskScheduler.TaskScheduler.TriggerItem.OnTriggerEventHandler(SchedulerCallback);
                        triggerItem.Enabled = true;
                        taskScheduler.AddTrigger(triggerItem);
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButton_EmailReceiver_ItemClick");
            }
        }

        private void barButtonItem_ViewLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_ViewLog dlg;
            try
            {
                dlg = new frm_ViewLog();
                dlg.Text = "Lịch Sử Thao Tác";
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_ViewLog_ItemClick");
            }
        }

        private void barButtonItem_CopyRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                _back:
                frm_RegisterKey dlg = new frm_RegisterKey();
                dlg._day_Trial = day_TrialRegisterForm;
                dlg.Text = "Đăng Ký Bản Quyền";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (Check_Key(dlg._Key) == false)
                    {
                        XtraMessageBox.Show("Key không hiệu lực", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        goto _back;
                    }
                    string[] _listKey = dlg._Key.Split('-');
                    _registerKey = new CoffeeHelpers.RegisterKeys();
                    _registerKey.User = GetCPUId();
                    _registerKey.RegisterKey = _listKey[0] + _listKey[1] + _listKey[2] + _listKey[3] + _listKey[4];
                    _registerKey.Date = DateTime.Now.ToString("dd/MM/yyyy");

                    CoffeeHelpers.SaveRegisterKey(_registerKey);

                    CoffeeHelpers.Register = _registerKey;

                    XtraMessageBox.Show("Kích hoạt bản quyền thành công, vui lòng đăng nhập lại. Xin cảm ơn quý khách hàng đã dùng sản phẩm.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Kết thúc mọi xử lý
                    StartRestarter("Đang tắt chương trình", 167, 50);

                    //Kết thúc mọi xử lý
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    Application.Exit();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_CopyRight_ItemClick");
            }
        }

        private void barButtonItem_AboutMe_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_AboutMe dlg;
            try
            {
                dlg = new frm_AboutMe();
                dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_AboutMe_ItemClick");
            }
        }

        private void barButtonItem_ICon_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_Icon dlg;
            try
            {
                dlg = new frm_Icon();
                dlg._imageList = this.imageList_Product;
                dlg._dic_image = dic_images;
                dlg.Text = "DANH SÁCH BIỂU TƯỢNG";
                if (dlg.ShowDialog() == DialogResult.Cancel)
                {
                    //LoadImage();
                    // Load danh sách sản phẩm
                    Load_CrateProduct();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_ICon_ItemClick");
            }
        }

        // Load biểu tượng
        private void LoadImage()
        {
            dic_images = new Dictionary<int, int>();
            Image img;
            try
            {
                //imageList_Product.Images.Clear();
                //img = Image.FromFile("");
                //imageList_Product.Images.Add(img);
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                List<icon> list = (from ic in _dbContext.icons.ToList() select ic).ToList();

                if (list != null && list.Count > 0)
                {
                    foreach(icon i in list)
                    {
                        FileStream FS1 = new FileStream("image" + i.idIcon + ".jpg", FileMode.Create);
                        byte[] blob = (byte[])i.IconName;
                        FS1.Write(blob, 0, blob.Length);
                        FS1.Close();
                        FS1 = null;

                        img =  Image.FromFile("image" + i.idIcon + ".jpg");
                        img.Tag = i.IconSkin;
                        
                        this.imageList_Product.Images.Add(img);
                        this.imageList_Product.Tag = i.IconSkin;

                        dic_images.Add(i.idIcon, Convert.ToInt32(i.IconSkin));
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadImage");
            }
        }
    }
}