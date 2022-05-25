using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO.Ports;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Coffee.Utils
{
    public class CoffeeHelpers
    {
        #region Fields

        public static string ConnectionString;
        public static EmployeeLogin EmpLogin;
        public static Config Conf;
        public static RegisterKeys Register;

        #endregion //--- Fields

        public static DatabaseSettings LoadDatabaseSettings()
        {
            DatabaseSettings result = null;
            string currentDir, dataString, key;
            StreamReader reader;
            int indexOfSpace;

            try
            {
                result = new DatabaseSettings();

                //----- Load other settings from application directory  
                currentDir = Application.StartupPath;
                if (currentDir != null)
                {
                    reader = File.OpenText(Path.Combine(currentDir, "databaseSetting.cfg"));
                    if (reader == null)
                        return null;

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "PrincipalServer")
                        result.PrincipalServer = dataString.Substring(indexOfSpace + 1);

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "CheckPrincipal")
                        result.CheckPrincipal = bool.Parse(dataString.Substring(indexOfSpace + 1));

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "LoginName")
                        result.LoginName = dataString.Substring(indexOfSpace + 1);

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "Password")
                        result.Password = dataString.Substring(indexOfSpace + 1);

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "DataName")
                        result.DatabaseName = dataString.Substring(indexOfSpace + 1);

                    reader.Close();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadDatabaseSettings");
                return null;
            }
        }

        public static bool SaveDatabaseSettings(DatabaseSettings dbS)
        {
            string currentDir, dataString;
            StreamWriter writer;

            try
            {
                if (dbS == null)
                    return false;
                //----- Save settings to file
                currentDir = Application.StartupPath;
                if (currentDir != null)
                {
                    File.SetAttributes(Path.Combine(currentDir, "databaseSetting.cfg"), FileAttributes.Normal);
                    writer = File.CreateText(Path.Combine(currentDir, "databaseSetting.cfg"));
                    if (writer == null)
                        return false;
                    dataString = "PrincipalServer " + dbS.PrincipalServer;
                    writer.WriteLine(dataString);
                    dataString = "CheckPrincipal " + dbS.CheckPrincipal.ToString();
                    writer.WriteLine(dataString);
                    dataString = "LoginName " + dbS.LoginName;
                    writer.WriteLine(dataString);
                    dataString = "Password " + dbS.Password;
                    writer.WriteLine(dataString);
                    dataString = "DataName " + dbS.DatabaseName;
                    writer.WriteLine(dataString);
                    writer.Flush();
                    writer.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SaveDatabaseSettings");
                return false;
            }
        }

        public static Config LoadConfig()
        {
            Config result = null;
            string currentDir, dataString, key;
            StreamReader reader;
            int indexOfSpace;

            try
            {
                result = new Config();

                //----- Load other settings from application directory  
                currentDir = Application.StartupPath;
                if (currentDir != null)
                {
                    reader = File.OpenText(Path.Combine(currentDir, "config.cfg"));
                    if (reader == null)
                        return null;

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "MaxLine")
                        result.MaxArea = Convert.ToInt32(dataString.Substring(indexOfSpace + 1));

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "PathFileReport")
                        result.PathFileReport = dataString.Substring(indexOfSpace + 1);

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "PrintReportAtTime")
                        result.PrintReportAtTime = ParseTimeSpan(dataString.Substring(indexOfSpace + 1));
 
                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "MailServer")
                        result.MailServer = dataString.Substring(indexOfSpace + 1);

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "MailServerPort")
                        result.MailServerPort = Convert.ToInt32(dataString.Substring(indexOfSpace + 1));

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "SenderMail")
                        result.SenderMail = dataString.Substring(indexOfSpace + 1);

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "MailPassword")
                        result.MailPassword = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(dataString.Substring(indexOfSpace + 1)));

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "Title")
                        result.Title = dataString.Substring(indexOfSpace + 1);

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "Content")
                        result.Content = dataString.Substring(indexOfSpace + 1);

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "UseSSL")
                        result.UseSSL = Convert.ToBoolean(dataString.Substring(indexOfSpace + 1));

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "ApplicationColor")
                        result.ApplicationColor = dataString.Substring(indexOfSpace + 1);

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "Tally")
                        result.Tally =Convert.ToBoolean(dataString.Substring(indexOfSpace + 1));

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "SavePass")
                        result.SavePass = Convert.ToBoolean(dataString.Substring(indexOfSpace + 1));

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "ShowPlanMoney")
                        result.ShowPlanMoney = Convert.ToBoolean(dataString.Substring(indexOfSpace + 1));

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    if (key == "ShowDetailPlan")
                        result.ShowDetailPlan = Convert.ToBoolean(dataString.Substring(indexOfSpace + 1));

                    reader.Close();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadConfig");
                return null;
            }
        }

        public static bool SaveConfig(Config config)
        {
            string currentDir, dataString;
            StreamWriter writer;

            try
            {
                if (config == null)
                    return false;
                //----- Save settings to file
                currentDir = Application.StartupPath;
                if (currentDir != null)
                {
                    File.SetAttributes(Path.Combine(currentDir, "config.cfg"), FileAttributes.Normal);
                    writer = File.CreateText(Path.Combine(currentDir, "config.cfg"));
                    if (writer == null)
                        return false; 
                    dataString = "MaxLine " + config.MaxArea;
                    writer.WriteLine(dataString);
                    dataString = "PathFileReport " + config.PathFileReport;
                    writer.WriteLine(dataString);
                    dataString = "PrintReportAtTime " + config.PrintReportAtTime;
                    writer.WriteLine(dataString);
                    dataString = "MailServer " + config.MailServer;
                    writer.WriteLine(dataString);
                    dataString = "MailServerPort " + config.MailServerPort;
                    writer.WriteLine(dataString);
                    dataString = "SenderMail " + config.SenderMail;
                    writer.WriteLine(dataString);

                    byte[] pass = CoffeeHelpers.ScramblePassword.Encode(config.MailPassword);
                    string password = Encoding.Unicode.GetString(pass);

                    dataString = "MailPassword " + password;
                    writer.WriteLine(dataString);
                    dataString = "Title " + config.Title;
                    writer.WriteLine(dataString);
                    dataString = "Content " + config.Content;
                    writer.WriteLine(dataString);
                    dataString = "UseSSL " + config.UseSSL;
                    writer.WriteLine(dataString);
                    dataString = "ApplicationColor " +config.ApplicationColor;
                    writer.WriteLine(dataString);
                    dataString = "Tally " + config.Tally;
                    writer.WriteLine(dataString);
                    dataString = "SavePass " + config.SavePass;
                    writer.WriteLine(dataString);
                    dataString = "ShowPlanMoney " + config.ShowPlanMoney;
                    writer.WriteLine(dataString);
                    dataString = "ShowDetailPlan " + config.ShowDetailPlan;
                    writer.WriteLine(dataString);

                    writer.Flush();
                    writer.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SaveConfig");
                return false;
            }
        }

        public static RegisterKeys LoadRegisterKey()
        {
            RegisterKeys result = null;
            string currentDir, dataString, key;
            StreamReader reader;
            int indexOfSpace;

            try
            {
                result = new RegisterKeys();

                //----- Load other settings from application directory  
                currentDir = Application.StartupPath;
                if (currentDir != null)
                {
                    reader = File.OpenText(Path.Combine(currentDir, "register.cfg"));
                    if (reader == null)
                        return null;

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                   // dataString = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(dataString.Trim()));
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    key = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(key));
                    if (key == "user")
                        result.User = dataString.Substring(indexOfSpace + 1);

                    result.User = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(dataString.Substring(indexOfSpace + 1)));

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                   // dataString = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(dataString.Trim()));
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    key = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(key));
                    if (key == "register")
                        result.RegisterKey = dataString.Substring(indexOfSpace + 1);

                    result.RegisterKey= CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(dataString.Substring(indexOfSpace + 1)));

                    dataString = reader.ReadLine();
                    if (dataString == null)
                        return null;
                   // dataString = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(dataString.Trim()));
                    indexOfSpace = dataString.IndexOf(' ', 0);
                    key = dataString.Substring(0, indexOfSpace);
                    key = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(key));
                    if (key == "date")
                        result.Date = dataString.Substring(indexOfSpace + 1);

                    result.Date = CoffeeHelpers.ScramblePassword.Decode(Encoding.Unicode.GetBytes(dataString.Substring(indexOfSpace + 1)));

                    reader.Close();
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool SaveRegisterKey(RegisterKeys key)
        {
            string currentDir, dataString;
            StreamWriter writer;

            try
            {
                if (key == null)
                    return false;
                //----- Save settings to file
                currentDir = Application.StartupPath;
                if (currentDir != null)
                {
                    File.SetAttributes(Path.Combine(currentDir, "register.cfg"), FileAttributes.Normal);
                    writer = File.CreateText(Path.Combine(currentDir, "register.cfg"));
                    if (writer == null)
                        return false;

                    byte[] pass = CoffeeHelpers.ScramblePassword.Encode(key.User);
                    string userContent = Encoding.Unicode.GetString(pass);
                    pass = CoffeeHelpers.ScramblePassword.Encode("user");
                    string user = Encoding.Unicode.GetString(pass);
                    dataString = user+" " + userContent;
                    writer.WriteLine(dataString);

                    pass = CoffeeHelpers.ScramblePassword.Encode(key.RegisterKey);
                    string keyContent = Encoding.Unicode.GetString(pass);
                    pass = CoffeeHelpers.ScramblePassword.Encode("register");
                    string userKey = Encoding.Unicode.GetString(pass);
                    dataString = userKey + " " + keyContent;
                    writer.WriteLine(dataString);

                    pass = CoffeeHelpers.ScramblePassword.Encode( key.Date);
                    string dateContent = Encoding.Unicode.GetString(pass);
                    pass = CoffeeHelpers.ScramblePassword.Encode("date");
                    string date = Encoding.Unicode.GetString(pass);
                    dataString = date + " " + dateContent;
                    writer.WriteLine(dataString);

                    writer.Flush();
                    writer.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SaveRegisterKey");
                return false;
            }
        }

        public static TimeSpan ParseTimeSpan(string time)
        {
            string[] stime;

            try
            {
                stime = time.Split(':');
                if (stime.Length != 3)
                {
                    return new TimeSpan(0, 0, 0);
                }
                return new TimeSpan(Convert.ToInt32(stime[0]), Convert.ToInt32(stime[1]), Convert.ToInt32(stime[2]));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ParseTimeSpan");
                return new TimeSpan(0, 0, 0);
            }
        }

          //--- Lấy title quyền từ enum EmpRight
        public static string GetEmployeeRightTitle(EmpRight empRight)
        {            
            EmpRightTitle empRightTitle= new EmpRightTitle();

            try
            {
                switch (empRight)
                {
                    case EmpRight.Administrator:
                        return empRightTitle.Administrator;
                    case EmpRight.SupAdmin:
                        return empRightTitle.Admin; 
                    case EmpRight.Operator:
                        return empRightTitle.Operator;
                    default:
                        return empRightTitle.Unknown; 
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetEmployeeRightTitle");
                return empRightTitle.Unknown;
            }         
        }

        //--- Lấy title quyền từ class Employee
        public static string GetEmployeeRightTitle(employee employee)
        {
            EmpRightTitle empRightTitle = new EmpRightTitle();
            EmpRight empRight = EmpRight.Operator;

            try
            {
                if (employee.EmployeeRight == EmpRight.Administrator.ToString())
                {
                    empRight = EmpRight.Administrator;
                }
                else if (employee.EmployeeRight == EmpRight.SupAdmin.ToString())
                {
                    empRight = EmpRight.SupAdmin;
                }
                else if (employee.EmployeeRight == EmpRight.Operator.ToString())
                {
                    empRight = EmpRight.Operator;
                }
                return GetEmployeeRightTitle(empRight);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetEmployeeRightTitle");
                return empRightTitle.Unknown;
            }
        }

        //--- Lấy quyền db từ title right
        public static string GetEmployeeRight(string employeeRightTitle)
        {
            EmpRightTitle empRightTitle = new EmpRightTitle();

            try
            {
                if (employeeRightTitle == empRightTitle.Administrator)
                {
                    return EmpRight.Administrator.ToString();
                }
                else if (employeeRightTitle == empRightTitle.Admin)
                {
                    return EmpRight.SupAdmin.ToString();
                }
                else if(employeeRightTitle == empRightTitle.Operator)
                {
                    return EmpRight.Operator.ToString();
                }               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetEmployeeRight");
                return empRightTitle.Unknown;
            }
            return empRightTitle.Unknown;
        }      

        //--- Lấy enum EmpRight từ class Employee
        public static EmpRight GetEmpRight(employee employee)
        {
            try
            {
                if (employee.EmployeeRight == EmpRight.Administrator.ToString())
                {   
                    return EmpRight.Administrator;
                }
                else if (employee.EmployeeRight == EmpRight.SupAdmin.ToString())
                {
                    return EmpRight.SupAdmin;
                }
                else if (employee.EmployeeRight == EmpRight.Operator.ToString())
                {
                    return EmpRight.Operator;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetEmpRight");
                return EmpRight.Operator;
            }
            return EmpRight.Operator;
        }

        /// <summary>
        /// Lấy mã khách hàng lớn nhất
        /// </summary>

        //--- Lấy mã khách hàng lớn nhất
        public static int GetCustomerMaxCode()
        {
            mycoffeeEntities dbContext;
            List<int> customer;

            try
            {
                dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                customer = (from p in dbContext.khachhangs orderby p.MAKH descending select p.MAKH).ToList();
                if (customer == null || customer.Count == 0)
                    return 0;

                return customer[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetCustomerMaxCode");
                return 0;
            }
        }

        /// <summary>
        /// Lấy mã sản phẩm lớn nhất
        /// </summary>
      
        //--- Lấy mã sản phẩm lớn nhất
        public static int GetProductMaxCode()
        {
            mycoffeeEntities dbContext;
            List<int> products;

            try
            {
                dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                products = (from p in dbContext.products orderby p.ProductID descending select p.ProductID).ToList();
                if (products == null || products.Count == 0)
                    return 0;

                return products[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetProductMaxCode");
                return 0;
            }
        }

        //--- Lấy mã sản phẩm lớn nhất
        public static int GetOrderMaxCode()
        {
            mycoffeeEntities dbContext;
            List<int> orders;

            try
            {
                dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                orders = (from p in dbContext.listorders orderby p.OrderID descending select p.OrderID).ToList();
                if (orders == null || orders.Count == 0)
                    return 0;

                return orders[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetOrderMaxCode");
                return 0;
            }
        }

        //--- Lấy mã phiếu thu lớn nhất
        public static int GetPhieuThuMaxCode()
        {
            mycoffeeEntities dbContext;
            List<int> phieuthus;

            try
            {
                dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                phieuthus = (from p in dbContext.phieuthus orderby p.MaPT descending select p.MaPT).ToList();
                if (phieuthus == null || phieuthus.Count == 0)
                    return 0;

                return phieuthus[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetPhieuThuMaxCode");
                return 0;
            }
        }

        //--- Lấy mã phiếu chi lớn nhất
        public static int GetPhieuChiMaxCode()
        {
            mycoffeeEntities dbContext;
            List<int> phieuchi;

            try
            {
                dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                phieuchi = (from p in dbContext.phieuchis orderby p.MaPC descending select p.MaPC).ToList();
                if (phieuchi == null || phieuchi.Count == 0)
                    return 0;

                return phieuchi[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetPhieuChiMaxCode");
                return 0;
            }
        }


        //--- Lấy mã hoá đơn nhập lớn nhất
        public static int GetHoaDonNhapMaxCode()
        {
            mycoffeeEntities dbContext;
            List<int> hdn;

            try
            {
                dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                hdn = (from p in dbContext.hoadonnhaps orderby p.MAHDN descending select p.MAHDN).ToList();
                if (hdn == null || hdn.Count == 0)
                    return 0;

                return hdn[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetHoaDOnNhapMaxCode");
                return 0;
            }
        }

        //--- Lấy mã nhà cung cấp lớn nhất
        public static int GetNCCMaxCode()
        {
            mycoffeeEntities dbContext;
            List<int> ncc;

            try
            {
                dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                ncc = (from p in dbContext.madeins orderby p.MadeInID descending select p.MadeInID).ToList();
                if (ncc == null || ncc.Count == 0)
                    return 0;

                return ncc[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetNCCMaxCode");
                return 0;
            }
        }

        public static ShiftRange GetShiftRange(DateTime dt, Shift shift)
        {
            ShiftRange shiftRange = null;

            try
            {
                //•	Ca 1 : 10h -> 18h (ngày hiện tại)
                //•	Ca 2 : 18h -> 02h (ngày hôm sau)
                //•	Ca 3 : 02h -> 10h (ngày hôm sau)
                shiftRange = new ShiftRange();
                switch (shift)
                {
                    case Shift.Shift1:
                        shiftRange.BeginTime = new DateTime(dt.Year, dt.Month, dt.Day, 10, 0, 0);
                        shiftRange.EndTime = new DateTime(dt.Year, dt.Month, dt.Day, 17, 59, 59);
                        break;
                    case Shift.Shift2:
                        shiftRange.BeginTime = new DateTime(dt.Year, dt.Month, dt.Day, 18, 0, 0);
                        //shiftRange.EndTime = new DateTime(dt.Year, dt.Month, dt.Day + 1, 1, 59, 59);
                        shiftRange.EndTime = new DateTime(dt.Year, dt.Month, dt.Day, 1, 59, 59);
                        shiftRange.EndTime = shiftRange.EndTime.AddDays(1);
                        break;
                    case Shift.Shift3:
                        //shiftRange.BeginTime = new DateTime(dt.Year, dt.Month, dt.Day + 1, 2, 0, 0);
                        shiftRange.BeginTime = new DateTime(dt.Year, dt.Month, dt.Day, 2, 0, 0);
                        shiftRange.BeginTime = shiftRange.BeginTime.AddDays(1);
                        //shiftRange.EndTime = new DateTime(dt.Year, dt.Month, dt.Day + 1, 9, 59, 59);
                        shiftRange.EndTime = new DateTime(dt.Year, dt.Month, dt.Day, 9, 59, 59);
                        shiftRange.EndTime = shiftRange.EndTime.AddDays(1);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetShiftRange");
                return shiftRange;
            }
            return shiftRange;
        }

        public static string GetShiftString(Shift shift)
        {
            try
            {
                switch (shift)
                {
                    case Shift.Shift1:
                        return "A";
                    case Shift.Shift2:
                        return "B";
                    case Shift.Shift3:
                        return "C";
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GetShiftString");
                return "";
            }
            return "";
    }

        public static bool TestConnect(string mysqlConnection)
        {
            //SqlConnection connection = null;
            MySqlConnection connection = null;

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = mysqlConnection;
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        public class ShiftRange
        {
            public DateTime BeginTime { get; set; }
            public DateTime EndTime { get; set; }
        }

        public static class ScramblePassword
        {
            public static byte[] Encode(string password)
            {
                byte[] key, IV;

                try
                {
                    //----- Lấy giá trị của key và IV cố định
                    GetSecret(out key, out IV);

                    //----- Tạo ra một đối tượng RC2CryptoServiceProvider mới
                    RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();

                    //----- Lấy encryptor
                    ICryptoTransform encryptor = rc2CSP.CreateEncryptor(key, IV);

                    //----- Mã hóa dữ liệu như một mãng byte và lưu vào memory
                    MemoryStream msEncrypt = new MemoryStream();
                    CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

                    //----- Chuyển password thành mãng byte
                    byte[] toEncrypt = Encoding.Default.GetBytes(password);

                    //----- Write all data to the crypto stream and flush it.
                    csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
                    csEncrypt.FlushFinalBlock();

                    //----- Get encrypted array of bytes.
                    byte[] encrypted = msEncrypt.ToArray();

                    return encrypted;
                }
                catch (Exception)
                {
                    return null;
                }
            }

            public static string Decode(byte[] encrypted)
            {
                byte[] key, IV;

                try
                {
                    if (encrypted == null || encrypted.Length == 0)
                        return "";

                    //----- Lấy giá trị của key và IV cố định
                    GetSecret(out key, out IV);

                    RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
                    //----- Tạo ra decryptor dùng cùng key và IV
                    ICryptoTransform decryptor = rc2CSP.CreateDecryptor(key, IV);

                    //----- Giải mã password
                    MemoryStream msDecrypt = new MemoryStream(encrypted);
                    CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

                    //----- Đọc những byte đã được mã hóa và lưu vào StringBuilder
                    StringBuilder sb = new StringBuilder();

                    int b = 0;

                    do
                    {
                        b = csDecrypt.ReadByte();

                        if (b != -1)
                        {
                            sb.Append((char)b);
                        }

                    } while (b != -1);

                    return sb.ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }

            private static bool GetSecret(out byte[] key, out byte[] IV)
            {
                bool result = false;
                key = null;
                IV = null;

                try
                {
                    key = new byte[16];
                    key[0] = 208;
                    key[1] = 173;
                    key[2] = 164;
                    key[3] = 39;
                    key[4] = 240;
                    key[5] = 211;
                    key[6] = 178;
                    key[7] = 153;
                    key[8] = 243;
                    key[9] = 119;
                    key[10] = 110;
                    key[11] = 151;
                    key[12] = 180;
                    key[13] = 143;
                    key[14] = 2;
                    key[15] = 65;

                    IV = new byte[8];
                    IV[0] = 129;
                    IV[1] = 178;
                    IV[2] = 80;
                    IV[3] = 120;
                    IV[4] = 210;
                    IV[5] = 5;
                    IV[6] = 40;
                    IV[7] = 201;

                    return result;
                }
                catch (Exception)
                {
                    return result;
                }
            }
        }

        public class EmployeeLogin
        {
            public int EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public string EmployeeCode { get; set; }
            public string EmployeeRight { get; set; }
            public EmpRight EmpRight { get; set; }
            public DateTime LoginDateTime { get; set; }
        }

        public class DatabaseSettings
        {
            public string PrincipalServer;
            public bool CheckPrincipal;
            public string LoginName;
            public string Password;
            public string DatabaseName;
        }

        public class RegisterKeys
        {
            public string User;
            public string RegisterKey;
            public string Date;
        }

        public class Config
        {
            // Số băng chuyền được hiển thị
            public int MaxArea;
            // Đường dẫn chứa báo cáo
            public string PathFileReport;
            // Thời gian tự động in báo cáo trong ngày
            public TimeSpan PrintReportAtTime;
            // Mail Server
            public string MailServer;
            // Mail Server Port
            public int MailServerPort;
            // Sender Mail
            public string SenderMail;
            // Password Sender Mail
            public string MailPassword;
            // Tiêu đề mail
            public string Title;
            // Nội dung mail
            public string Content;
            // Có sử dụng SSL hay không
            public bool UseSSL;
            // Màu sắc ứng dụng
            public string ApplicationColor;
            // Cho phép ghi nợ
            public bool Tally;
            // Cho phép nhớ mật khẩu
            public bool SavePass;
            // Cho phép hiển thị thông tin doanh thu
            public bool ShowPlanMoney;
            // Cho phép hiển thị thông tin chi tiết kế hoạch ngày
            public bool ShowDetailPlan;
        }

        // Lưu những loại quyền của nhân viên
        public enum EmpRight
        {
            Administrator,
            SupAdmin,
            Operator
        }

        public class EmpRightTitle
        {
            public string Unknown = "Unknown";
            public string Administrator = "Quản trị hệ thống";
            public string Admin = "Quản lý";
            public string Operator = "Người dùng";

        }

        // Ca làm việc
        public enum Shift
        {
            Shift1 = 1,
            Shift2 = 2,
            Shift3 = 3
        }

        // Lớp chứa thông tin sản xuất của một sản phẩm
        public class ProductInfo
        {
            // Tên sản phẩm
            public string ProductName { get; set; }
            // Số lượng dự xuất
            public int PlanQuantity { get; set; }
            // Số lượng thực
            public int RealQuantity { get; set; }
        }

        // Lớp chứa dữ liệu gởi mail
        public class MailData
        {
            // Địa chỉ người nhận
            public string Receiver { get; set; }
            // File cần đính kèm
            public string File { get; set; }
            // Thời điểm gởi dùng ghi log
            public DateTime DateLog { get; set; }

            public MailData(string receiver, string file, DateTime dateLog)
            {
                Receiver = receiver;
                File = file;
                DateLog = dateLog;
            }
        }

        public enum OpenType
        {
            None,
            AddEdit,// Thêm sản phẩm
            UpdateExist// Cho phép sửa khi trùng
        }
    }
}
