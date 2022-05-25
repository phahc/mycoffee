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
using TracerX;

namespace Coffee
{
    public partial class frm_DanhSachThuChi : DevExpress.XtraEditors.XtraForm
    {
        public company _COMPANY;

        private mycoffeeEntities _dbContext;
        private DataTable _tbSourceThu;
        private DataTable _tbSourceChi;
        private Point point = new Point();
        private int _selectTab=0;// 0: phiếu thu; 1: phiếu chi

        // Đối tượng Log cho lớp
        private static readonly Logger log = Logger.GetLogger(typeof(frm_DanhSachThuChi));

        private const string _cID = "ID";
        private const string _cHDNCode = "HDNCode";
        private const string _cDate = "Date";
        private const string _cReason = "Reason";
        private const string _cAttach = "Attach";
        private const string _cOwner = "Owner";
        private const string _cAddress = "Address";
        private const string _cMoney = "Money";
        private const string _cNotes = "Notes";

        public frm_DanhSachThuChi()
        {
            InitializeComponent();
        }

        private void frm_DanhSachThuChi_Load(object sender, EventArgs e)
        {
            DateTime dtNow;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                dtNow = DateTime.Now;

                //Phiếu chi
                dateEdit_From.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day,0, 0, 0);
                dateEdit_To.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);

                //Phiếu thu
                dateEdit_FromThu.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 0, 0, 0);
                dateEdit_ToThu.DateTime = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);

                ////Load danh sach phieu thu
                //LoadPhieuThu(dateEdit_From.DateTime, dateEdit_To.DateTime);

                //// Load danh sach phieu chi
                //LoadPhieuChi(dateEdit_From.DateTime, dateEdit_To.DateTime);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_DanhSachThuChi_Load");
            }
        }
      
        // Danh sách phiếu thu
        private void LoadPhieuThu(DateTime StartDate, DateTime EndDate)
        {
            List<phieuthu> phieuthu;
            DateTime start,end;
            DataRow row;
            try
            {
                if (StartDate == null || EndDate == null)
                {
                    gridControl_PhieuThu.DataSource = null;
                    return;
                }
                _tbSourceThu= CreateTableStruct();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                start= new DateTime(StartDate.Year,StartDate.Month,StartDate.Day,0,0,0);
                end= new DateTime(EndDate.Year,EndDate.Month,EndDate.Day,23,59,59);

                phieuthu = (from pt in _dbContext.phieuthus.ToList() where pt.NgayThu >= start && pt.NgayThu <= end select pt).ToList();

                if (phieuthu != null && phieuthu.Count > 0)
                {
                    foreach (phieuthu pt in phieuthu)
                    {
                        row = _tbSourceThu.NewRow();
                        row[_cID] = pt.MaPT;
                        row[_cHDNCode] = pt.PTCode;
                        row[_cDate] = pt.NgayThu;
                        row[_cReason] = pt.Reason;
                        row[_cAttach] = pt.DinhKem;
                        row[_cOwner] = pt.DoiTuongNop;
                        row[_cAddress] = pt.DiaChi;
                        row[_cMoney] = pt.SoTienTra_PT;
                        row[_cNotes] = pt.GhiChu;

                        _tbSourceThu.Rows.Add(row);
                    }
                    gridControl_PhieuThu.DataSource = _tbSourceThu;
                }
                else
                {
                    gridControl_PhieuThu.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadPhieuThu");
            }
        }

        //Load danh sach Phieu chi
        private void LoadPhieuChi(DateTime StartDate, DateTime EndDate)
        {
            List<phieuchi> phieuchi;
            DateTime start, end;
            DataRow row;
            try
            {
                if (StartDate == null || EndDate == null)
                {
                    gridControl_PhieuChi.DataSource = null;
                    return;
                }

                
                _tbSourceChi = CreateTableStruct();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                start = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 0, 0, 0);
                end = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 59);
                phieuchi = (from pc in _dbContext.phieuchis.ToList() where pc.NgayChi >= start && pc.NgayChi <= end select pc).ToList();

                if (phieuchi != null && phieuchi.Count > 0)
                {
                    foreach (phieuchi pc in phieuchi)
                    {
                        row = _tbSourceChi.NewRow();
                        row[_cID] = pc.MaPC;
                        row[_cHDNCode] = pc.PCCode;
                        row[_cDate] = pc.NgayChi;
                        row[_cReason] = pc.LyDo;
                        row[_cAttach] = pc.DinhKem;
                        row[_cOwner] = pc.DoiTuongChi;
                        row[_cAddress] = pc.DiaChi;
                        row[_cMoney] = pc.SoTienDaTra_PC;
                        row[_cNotes] = pc.GhiChu;

                        _tbSourceChi.Rows.Add(row);
                    }
                    gridControl_PhieuChi.DataSource = _tbSourceChi;
                }
                else
                {
                    gridControl_PhieuThu.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadPhieuChi");
            }
        }

        //Tao cau truc cho GridView
        private DataTable CreateTableStruct()
        {
            DataTable tbSource=null;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cID);
                tbSource.Columns.Add(_cHDNCode);
                tbSource.Columns.Add(_cDate);
                tbSource.Columns.Add(_cReason);
                tbSource.Columns.Add(_cAttach);
                tbSource.Columns.Add(_cOwner);
                tbSource.Columns.Add(_cAddress);
                tbSource.Columns.Add(_cMoney);
                tbSource.Columns.Add(_cNotes);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableThuStruct");
                return tbSource;
            }
            return tbSource;
        }

        private void dateEdit_From_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateEdit_To.DateTime == null || dateEdit_To.DateTime.Year<=0001)
                {
                    return;
                }

                // Load danh sach phieu chi
                LoadPhieuChi(dateEdit_From.DateTime, dateEdit_To.DateTime);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "dateEdit_From_EditValueChanged");
            }
        }

        private void dateEdit_To_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateEdit_From.DateTime == null || dateEdit_From.DateTime.Year <= 0001)
                {
                    return;
                }

                // Load danh sach phieu chi
                LoadPhieuChi(dateEdit_From.DateTime, dateEdit_To.DateTime);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "dateEdit_To_EditValueChanged");
            }
        }

        private void dateEdit_FromThu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateEdit_ToThu.DateTime == null || dateEdit_ToThu.DateTime.Year <= 0001)
                {
                    return;
                }
                //Load danh sach phieu thu
                LoadPhieuThu(dateEdit_FromThu.DateTime, dateEdit_ToThu.DateTime);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "dateEdit_FromThu_EditValueChanged");
            }
        }

        private void dateEdit_ToThu_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateEdit_FromThu.DateTime == null || dateEdit_FromThu.DateTime.Year <= 0001)
                {
                    return;
                }
                //Load danh sach phieu thu
                LoadPhieuThu(dateEdit_FromThu.DateTime, dateEdit_ToThu.DateTime);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "dateEdit_ToThu_EditValueChanged");
            }
        }

        private void btn_AddPhieuThu_Click(object sender, EventArgs e)
        {
            frm_PhieuThuChi dlg;
            phieuthu pts;
            DataRow row;
            try
            {
                dlg = new frm_PhieuThuChi();
                pts = new phieuthu();
                dlg.maxCode = CoffeeHelpers.GetPhieuThuMaxCode() + 1;//Mã lớn nhất cộng thêm 1
                dlg._PhieuThu_PhieuChi = 1;//Phiếu thu
                dlg.PhieuThu = pts;
                dlg.company = _COMPANY;
                dlg.Text = "Phiếu Thu";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                    _dbContext.phieuthus.Add(dlg.PhieuThu);
                    _dbContext.SaveChanges();

                    row = _tbSourceThu.NewRow();
                    row[_cID] = dlg.PhieuThu.MaPT;
                    row[_cHDNCode] =dlg.PhieuThu.PTCode;
                    row[_cDate] = dlg.PhieuThu.NgayThu;
                    row[_cReason] = dlg.PhieuThu.Reason;
                    row[_cAttach] = dlg.PhieuThu.DinhKem;
                    row[_cOwner] = dlg.PhieuThu.DoiTuongNop;
                    row[_cAddress] = dlg.PhieuThu.DiaChi;
                    row[_cMoney] = dlg.PhieuThu.SoTienTra_PT;
                    row[_cNotes] = dlg.PhieuThu.GhiChu;

                    _tbSourceThu.Rows.Add(row);

                    gridControl_PhieuThu.DataSource = _tbSourceThu;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_AddPhieuThu_Click");
            }
        }

        private void btn_SuaPhieuThu_Click(object sender, EventArgs e)
        {
            phieuthu thu;
            DataRow focusRow;
            frm_PhieuThuChi dlg;
            try
            {
                if (gridView_PhieuThu.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn phiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                thu = new phieuthu();
                focusRow = gridView_PhieuThu.GetFocusedDataRow();

                thu.MaPT = Convert.ToInt32(focusRow[_cID]);
                thu.NgayThu = Convert.ToDateTime(focusRow[_cDate]);
                thu.PTCode=focusRow[_cHDNCode].ToString();
                thu.Reason = focusRow[_cReason].ToString();
                thu.DinhKem = focusRow[_cAttach].ToString();
                thu.DoiTuongNop = focusRow[_cOwner].ToString();
                thu.DiaChi = focusRow[_cAddress].ToString();
                thu.SoTienTra_PT = Convert.ToDecimal(focusRow[_cMoney]);
                thu.GhiChu = focusRow[_cNotes].ToString();

                dlg = new frm_PhieuThuChi();
                dlg.PhieuThu = thu;
                dlg._PhieuThu_PhieuChi = 1;
                dlg.company = _COMPANY;
                dlg.Text = "Sửa Phiếu Thu";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    thu.NgayThu = dlg.PhieuThu.NgayThu;
                    thu.Reason = dlg.PhieuThu.Reason;
                    thu.SoTienTra_PT = dlg.PhieuThu.SoTienTra_PT;
                    thu.DoiTuongNop = dlg.PhieuThu.DoiTuongNop;
                    thu.DiaChi=dlg.PhieuThu.DiaChi;
                    thu.DinhKem= dlg.PhieuThu.DinhKem;
                    thu.GhiChu = dlg.PhieuThu.GhiChu;
                    _dbContext.SaveChanges();

                    //GridView
                    focusRow[_cDate] = dlg.PhieuThu.NgayThu;
                    focusRow[_cReason] = dlg.PhieuThu.Reason;
                    focusRow[_cMoney] = dlg.PhieuThu.SoTienTra_PT;
                    focusRow[_cOwner] = dlg.PhieuThu.DoiTuongNop;
                    focusRow[_cAddress] = dlg.PhieuThu.DiaChi;
                    focusRow[_cAttach] = dlg.PhieuThu.DinhKem;
                    focusRow[_cNotes] = dlg.PhieuThu.GhiChu;

                    gridView_PhieuThu.LayoutChanged();

                    // Ghi log
                    WriteLog("Sửa phiếu thu có mã phiếu là: " + focusRow[_cHDNCode].ToString());

                    log.Info("Lúc " + DateTime.Now + ", nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " sửa phiếu thu có mã phiếu là: " + focusRow[_cHDNCode].ToString());
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_SuaPhieuThu_Click");
            }
        }

        private void btn_XoaPhieuThu_Click(object sender, EventArgs e)
        {
            phieuthu pt;
            DataRow focusRow;
            try
            {
                if (gridView_PhieuThu.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn phiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có muốn xoá phiếu thu này vĩnh viễn ra khỏi hệ thống không?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }

                focusRow = gridView_PhieuThu.GetFocusedDataRow();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                pt = (from p in _dbContext.phieuthus.ToList() where p.MaPT == Convert.ToInt32(focusRow[_cID]) select p).FirstOrDefault();
                if (pt != null)
                {
                    _dbContext.phieuthus.Remove(pt);
                    _dbContext.SaveChanges();

                    foreach (DataRow rw in _tbSourceThu.Rows)
                    {
                        if (Convert.ToInt32(focusRow[_cID]) == pt.MaPT)
                        {
                            _tbSourceThu.Rows.Remove(rw);
                            gridView_PhieuThu.LayoutChanged();

                            // Ghi log
                            WriteLog("Xoá phiếu thu có mã phiếu là: " + focusRow[_cHDNCode].ToString());

                            log.Info("Lúc " + DateTime.Now + ", nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " xoá phiếu thu có mã phiếu là: " + focusRow[_cHDNCode].ToString());
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_XoaPhieuThu_Click");
            }
        }

        private void btn_ThemPhieuChi_Click(object sender, EventArgs e)
        {
            frm_PhieuThuChi dlg;
            phieuchi pcs;
            DataRow row;
            try
            {
                dlg = new frm_PhieuThuChi();
                pcs = new phieuchi();
                dlg.maxCode = CoffeeHelpers.GetPhieuChiMaxCode() + 1;//Mã lớn nhất cộng thêm 1
                dlg._PhieuThu_PhieuChi = 2;//Phiếu thu
                dlg.PhieuChi = pcs;
                dlg.company = _COMPANY;
                dlg.Text = "Phiếu Chi";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                    _dbContext.phieuchis.Add(dlg.PhieuChi);
                    _dbContext.SaveChanges();

                    row = _tbSourceChi.NewRow();
                    row[_cHDNCode] = dlg.PhieuChi.PCCode;
                    row[_cDate] = dlg.PhieuChi.NgayChi;
                    row[_cReason] = dlg.PhieuChi.LyDo;
                    row[_cAttach] = dlg.PhieuChi.DinhKem;
                    row[_cOwner] = dlg.PhieuChi.DoiTuongChi;
                    row[_cAddress] = dlg.PhieuChi.DiaChi;
                    row[_cMoney] = dlg.PhieuChi.SoTienDaTra_PC;
                    row[_cNotes] = dlg.PhieuChi.GhiChu;

                    _tbSourceChi.Rows.Add(row);

                    gridControl_PhieuChi.DataSource = _tbSourceChi;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_ThemPhieuChi_Click");
            }
        }

        private void btn_SuaPhieuChi_Click(object sender, EventArgs e)
        {
            phieuchi chi;
            DataRow focusRow;
            frm_PhieuThuChi dlg;
            try
            {
                if (gridView_PhieuChi.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn phiếu", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                chi = new phieuchi();
                focusRow = gridView_PhieuChi.GetFocusedDataRow();

                chi.MaPC= Convert.ToInt32(focusRow[_cID]);
                chi.NgayChi = Convert.ToDateTime(focusRow[_cDate]);
                chi.PCCode = focusRow[_cHDNCode].ToString();
                chi.LyDo = focusRow[_cReason].ToString();
                chi.DinhKem = focusRow[_cAttach].ToString();
                chi.DoiTuongChi = focusRow[_cOwner].ToString();
                chi.DiaChi = focusRow[_cAddress].ToString();
                chi.SoTienDaTra_PC= Convert.ToDecimal(focusRow[_cMoney]);
                chi.GhiChu = focusRow[_cNotes].ToString();

                dlg = new frm_PhieuThuChi();
                dlg.PhieuChi = chi;
                dlg._PhieuThu_PhieuChi = 2;
                dlg.company = _COMPANY;
                dlg.Text = "Sửa Phiếu Thu";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    chi.NgayChi = dlg.PhieuChi.NgayChi;
                    chi.LyDo = dlg.PhieuChi.LyDo;
                    chi.SoTienDaTra_PC = dlg.PhieuChi.SoTienDaTra_PC;
                    chi.DoiTuongChi = dlg.PhieuChi.DoiTuongChi;
                    chi.DiaChi = dlg.PhieuChi.DiaChi;
                    chi.DinhKem = dlg.PhieuChi.DinhKem;
                    chi.GhiChu = dlg.PhieuChi.GhiChu;
                    _dbContext.SaveChanges();

                    //GridView
                    focusRow[_cDate] = dlg.PhieuChi.NgayChi;
                    focusRow[_cReason] = dlg.PhieuChi.LyDo;
                    focusRow[_cMoney] = dlg.PhieuChi.SoTienDaTra_PC;
                    focusRow[_cOwner] = dlg.PhieuChi.DoiTuongChi;
                    focusRow[_cAddress] = dlg.PhieuChi.DiaChi;
                    focusRow[_cAttach] = dlg.PhieuChi.DinhKem;
                    focusRow[_cNotes] = dlg.PhieuChi.GhiChu;

                    gridView_PhieuChi.LayoutChanged();

                    // Ghi log
                    WriteLog("Sửa phiếu chi có mã phiếu là: " + focusRow[_cHDNCode].ToString());

                    log.Info("Lúc " + DateTime.Now + ", nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " sửa phiếu chi có mã phiếu là: " + focusRow[_cHDNCode].ToString());

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_SuaPhieuChi_Click");
            }
        }

        private void btn_XoaPhieuChi_Click(object sender, EventArgs e)
        {
            phieuchi pc;
            DataRow focusRow;
            try
            {
                if (gridView_PhieuThu.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn phiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (XtraMessageBox.Show("Bạn có muốn xoá phiếu chi này vĩnh viễn ra khỏi hệ thống không?", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }

                focusRow = gridView_PhieuChi.GetFocusedDataRow();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                pc = (from p in _dbContext.phieuchis.ToList() where p.MaPC == Convert.ToInt32(focusRow[_cID]) select p).FirstOrDefault();
                if (pc != null)
                {
                    _dbContext.phieuchis.Remove(pc);
                    _dbContext.SaveChanges();

                    foreach (DataRow rw in _tbSourceThu.Rows)
                    {
                        if (Convert.ToInt32(focusRow[_cID]) == pc.MaPC)
                        {
                            _tbSourceChi.Rows.Remove(rw);
                            gridView_PhieuChi.LayoutChanged();

                            // Ghi log
                            WriteLog("Xoá phiếu chi có mã phiếu là: " + focusRow[_cHDNCode].ToString());

                            log.Info("Lúc " + DateTime.Now + ", nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " xoá phiếu chi có mã phiếu là: " + focusRow[_cHDNCode].ToString());

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_XoaPhieuChi_Click");
            }
        }

        private void gridControl_PhieuChi_DoubleClick(object sender, EventArgs e)
        {
            phieuchi chi;
            DataRow focusRow;
            frm_PhieuThuChi dlg;
            try
            {
                if (gridView_PhieuChi.SelectedRowsCount <= 0)
                { return;}

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                chi = new phieuchi();
                focusRow = gridView_PhieuChi.GetFocusedDataRow();

                chi.MaPC = Convert.ToInt32(focusRow[_cID]);
                chi.NgayChi = Convert.ToDateTime(focusRow[_cDate]);
                chi.PCCode = focusRow[_cHDNCode].ToString();
                chi.LyDo = focusRow[_cReason].ToString();
                chi.DinhKem = focusRow[_cAttach].ToString();
                chi.DoiTuongChi = focusRow[_cOwner].ToString();
                chi.DiaChi = focusRow[_cAddress].ToString();
                chi.SoTienDaTra_PC = Convert.ToDecimal(focusRow[_cMoney]);
                chi.GhiChu = focusRow[_cNotes].ToString();

                dlg = new frm_PhieuThuChi();
                dlg.PhieuChi = chi;
                dlg._PhieuThu_PhieuChi = 2;
                dlg.company = _COMPANY;
                dlg.Text = "Sửa Phiếu Thu";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    chi.NgayChi = dlg.PhieuChi.NgayChi;
                    chi.LyDo = dlg.PhieuChi.LyDo;
                    chi.SoTienDaTra_PC = dlg.PhieuChi.SoTienDaTra_PC;
                    chi.DoiTuongChi = dlg.PhieuChi.DoiTuongChi;
                    chi.DiaChi = dlg.PhieuChi.DiaChi;
                    chi.DinhKem = dlg.PhieuChi.DinhKem;
                    chi.GhiChu = dlg.PhieuChi.GhiChu;
                    _dbContext.SaveChanges();

                    //GridView
                    focusRow[_cDate] = dlg.PhieuChi.NgayChi;
                    focusRow[_cReason] = dlg.PhieuChi.LyDo;
                    focusRow[_cMoney] = dlg.PhieuChi.SoTienDaTra_PC;
                    focusRow[_cOwner] = dlg.PhieuChi.DoiTuongChi;
                    focusRow[_cAddress] = dlg.PhieuChi.DiaChi;
                    focusRow[_cAttach] = dlg.PhieuChi.DinhKem;
                    focusRow[_cNotes] = dlg.PhieuChi.GhiChu;

                    gridView_PhieuChi.LayoutChanged();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_PhieuChi_DoubleClick");
            }
        }

        private void gridControl_PhieuThu_DoubleClick(object sender, EventArgs e)
        {
            phieuthu thu;
            DataRow focusRow;
            frm_PhieuThuChi dlg;
            try
            {
                if (gridView_PhieuThu.SelectedRowsCount <= 0)
                {
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                thu = new phieuthu();
                focusRow = gridView_PhieuThu.GetFocusedDataRow();

                thu.MaPT = Convert.ToInt32(focusRow[_cID]);
                thu.NgayThu = Convert.ToDateTime(focusRow[_cDate]);
                thu.PTCode = focusRow[_cHDNCode].ToString();
                thu.Reason = focusRow[_cReason].ToString();
                thu.DinhKem = focusRow[_cAttach].ToString();
                thu.DoiTuongNop = focusRow[_cOwner].ToString();
                thu.DiaChi = focusRow[_cAddress].ToString();
                thu.SoTienTra_PT = Convert.ToDecimal(focusRow[_cMoney]);
                thu.GhiChu = focusRow[_cNotes].ToString();

                dlg = new frm_PhieuThuChi();
                dlg.PhieuThu = thu;
                dlg._PhieuThu_PhieuChi = 1;
                dlg.company = _COMPANY;
                dlg.Text = "Sửa Phiếu Thu";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    thu.NgayThu = dlg.PhieuThu.NgayThu;
                    thu.Reason = dlg.PhieuThu.Reason;
                    thu.SoTienTra_PT = dlg.PhieuThu.SoTienTra_PT;
                    thu.DoiTuongNop = dlg.PhieuThu.DoiTuongNop;
                    thu.DiaChi = dlg.PhieuThu.DiaChi;
                    thu.DinhKem = dlg.PhieuThu.DinhKem;
                    thu.GhiChu = dlg.PhieuThu.GhiChu;
                    _dbContext.SaveChanges();

                    //GridView
                    focusRow[_cDate] = dlg.PhieuThu.NgayThu;
                    focusRow[_cReason] = dlg.PhieuThu.Reason;
                    focusRow[_cMoney] = dlg.PhieuThu.SoTienTra_PT;
                    focusRow[_cOwner] = dlg.PhieuThu.DoiTuongNop;
                    focusRow[_cAddress] = dlg.PhieuThu.DiaChi;
                    focusRow[_cAttach] = dlg.PhieuThu.DinhKem;
                    focusRow[_cNotes] = dlg.PhieuThu.GhiChu;

                    gridView_PhieuThu.LayoutChanged();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_PhieuThu_DoubleClick");
            }
        }

        // Di chuyển form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panelControl3_MouseDown(object sender, MouseEventArgs e)
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
                XtraMessageBox.Show(ex.Message, "panelControl3_MouseDown");
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

        // Ghi log
        private void WriteLog(string action)
        {
            log lg;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                lg = new log();
                lg.employeename = CoffeeHelpers.EmpLogin.EmployeeName;
                lg.actiondate = DateTime.Now;
                lg.actions = action;

                _dbContext.logs.Add(lg);
                _dbContext.SaveChanges();
            }
            catch
            {
            }
        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void barListItem1_ListItemClick(object sender, DevExpress.XtraBars.ListItemClickEventArgs e)
        {

        }

        private void btn_More_Click(object sender, EventArgs e)
        {
            try
            {
                popupMenu_Phieu.ShowPopup(Control.MousePosition);
                point = Control.MousePosition;
                _selectTab = 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_More_Click");
            }
        }

        private void btn_MoreChi_Click(object sender, EventArgs e)
        {
            try
            {
                popupMenu_Phieu.ShowPopup(Control.MousePosition);
                point = Control.MousePosition;
                _selectTab = 1;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "btn_MoreChi_Click");
            }
        }

        // Hôm nay
        private void barButtonItem_Today_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime today;
            try
            {
                today = DateTime.Now;
                if (_selectTab == 0)
                {
                    dateEdit_FromThu.DateTime = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
                    dateEdit_ToThu.DateTime = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);
                }
                else
                {
                    dateEdit_From.DateTime = new DateTime(today.Year, today.Month, today.Day, 0, 0, 0);
                    dateEdit_To.DateTime = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Today_ItemClick");
            }
        }
        // Hôm qua
        private void barButtonItem_Yesterday_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            DateTime yesterday;
            try
            {
                yesterday = DateTime.Today.AddDays(-1);
                if (_selectTab == 0)
                {
                    dateEdit_FromThu.DateTime = new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 0, 0, 0);
                    dateEdit_ToThu.DateTime = new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 23, 59, 59);
                }
                else
                {
                    dateEdit_From.DateTime = new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 0, 0, 0);
                    dateEdit_To.DateTime = new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 23, 59, 59);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Yesterday_ItemClick");
            }
        }

        // Tuần này
        private void barButtonItem_Week_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DateTime date = DateTime.Today;
                while (date.DayOfWeek != DayOfWeek.Monday)
                {
                    date = date.AddDays(-1);
                }

                DateTime startDate = date;
                DateTime endDate = date.AddDays(6);

                if (_selectTab == 0)
                {
                    dateEdit_FromThu.DateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                    dateEdit_ToThu.DateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
                }
                else
                {
                    dateEdit_From.DateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                    dateEdit_To.DateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Week_ItemClick");
            }
        }

        // Tuần trước
        private void barButtonItem_LastWeek_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DateTime date = DateTime.Now.AddDays(-7);
                while (date.DayOfWeek != DayOfWeek.Monday)
                {
                    date = date.AddDays(-1);
                }

                DateTime startDate = date;
                DateTime endDate = date.AddDays(6);
                if (_selectTab == 0)
                {
                    dateEdit_FromThu.DateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                    dateEdit_ToThu.DateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
                }
                else
                {
                    dateEdit_From.DateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);
                    dateEdit_To.DateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_LastWeek_ItemClick");
            }
        }

        // Tháng này
        private void barButtonItem_Month_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int maxDateOfMonth = 30;
            DateTime today= DateTime.Now;
            try
            {
                maxDateOfMonth=DateTime.DaysInMonth(today.Year, today.Month);
                if (_selectTab == 0)
                {
                    dateEdit_FromThu.DateTime = new DateTime(today.Year, today.Month, 1, 0, 0, 0);
                    dateEdit_ToThu.DateTime = new DateTime(today.Year, today.Month, maxDateOfMonth, 23, 59, 59);
                }
                else
                {
                    dateEdit_From.DateTime = new DateTime(today.Year, today.Month, 1, 0, 0, 0);
                    dateEdit_To.DateTime = new DateTime(today.Year, today.Month, maxDateOfMonth, 23, 59, 59);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Month_ItemClick");
            }
        }

        // Tháng trước
        private void barButtonItem_LastMonth_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime today= DateTime.Now;
            int maxDateOfMonth = 30;
            try
            {
                var first = today.AddMonths(-1);
                maxDateOfMonth = DateTime.DaysInMonth(today.Year, first.Month);
                if (_selectTab == 0)
                {
                    dateEdit_FromThu.DateTime = new DateTime(today.Year, first.Month, 1, 0, 0, 0);
                    dateEdit_ToThu.DateTime = new DateTime(today.Year, first.Month, maxDateOfMonth, 23, 59, 59);
                }
                else
                {
                    dateEdit_From.DateTime = new DateTime(today.Year, first.Month, 1, 0, 0, 0);
                    dateEdit_To.DateTime = new DateTime(today.Year, first.Month, maxDateOfMonth, 23, 59, 59);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_LastMonth_ItemClick");
            }
        }

        // Quý hiện tại
        private void barButtonItem_Quy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime dtNow;
            try
            {
                dtNow = DateTime.Now;

                int quy = dtNow.Month / 3;
                if (_selectTab == 0)
                {
                    gridControl_PhieuThu.DataSource = DanhSachPhieuTheoQuy(quy);
                }
                else
                {
                    gridControl_PhieuChi.DataSource = DanhSachPhieuTheoQuy(quy);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Quy_ItemClick");
            }
        }

        //  Quý trước
        private void barButtonItem_QuyTruoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime dtNow;
            try
            {
                dtNow = DateTime.Now;

                int quy = (dtNow.Month / 3)-1;
                if (quy <= 0)
                {
                    XtraMessageBox.Show("Thất bại. Đây là quý đầu tiên của năm","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (_selectTab == 0)
                {
                    gridControl_PhieuThu.DataSource = DanhSachPhieuTheoQuy(quy);
                }
                else
                {
                    gridControl_PhieuChi.DataSource = DanhSachPhieuTheoQuy(quy);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_QuyTruoc_ItemClick");
            }
        }

        // Năm nay
        private void barButtonItem_Year_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime today = DateTime.Now;
            try
            {
                if (_selectTab == 0)
                {
                    dateEdit_FromThu.DateTime = new DateTime(today.Year, 1, 1, 0, 0, 0);
                    dateEdit_ToThu.DateTime = new DateTime(today.Year, 12, 31, 23, 59, 59);
                }
                else
                {
                    dateEdit_From.DateTime = new DateTime(today.Year, 1, 1, 0, 0, 0);
                    dateEdit_To.DateTime = new DateTime(today.Year, 12, 31, 23, 59, 59);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Year_ItemClick");
            }
        }

        // Năm trước
        private void barButtonItem_LastYear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime today = DateTime.Now;
            try
            {
                if (_selectTab == 0)
                {
                    dateEdit_FromThu.DateTime = new DateTime(today.Year - 1, 1, 1, 0, 0, 0);
                    dateEdit_ToThu.DateTime = new DateTime(today.Year - 1, 12, 31, 23, 59, 59);
                }
                else
                {
                    dateEdit_From.DateTime = new DateTime(today.Year - 1, 1, 1, 0, 0, 0);
                    dateEdit_To.DateTime = new DateTime(today.Year - 1, 12, 31, 23, 59, 59);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_LastYear_ItemClick");
            }
        }

        // Chọn tháng
        private void barButtonItem_ChooseMonth_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                popupMenu_Month.ShowPopup(point);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_ChooseMonth_ItemClick");
            }
        }

        // Chọn quý
        private void barButtonItem_ChonQuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                popupMenu_Quy.ShowPopup(point);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_ChonQuy_ItemClick");
            }
        }

        // Danh sách phiếu theo quý
        private DataTable DanhSachPhieuTheoQuy(int quy)
        {
            DataTable tbSource= new DataTable();
            List<phieuthu> phieuthu;
            List<phieuchi> phieuchi;
            DateTime startDate, endDate, dtNow;
            int startFor=1;
            DataRow row;

            try
            {
                tbSource = CreateTableStruct();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                int endDay = 30;
                switch(quy)
                {
                    case 1:
                        startFor = 1;
                        endDay = 31;
                        break;
                    case 2:
                        startFor = 4;
                        endDay = 30;
                        break;
                    case 3:
                        startFor = 7;
                        endDay = 30;
                        break;
                    case 4:
                        startFor = 10;
                        endDay = 31;
                        break;
                }

                int endMonth = startFor + 2;
                dtNow = DateTime.Now;
                startDate = new DateTime(dtNow.Year, startFor, 1, 0, 0, 0);
                endDate = new DateTime(dtNow.Year, endMonth, endDay, 23, 59, 59);

                if (_selectTab == 0)// Phiếu thu
                {
                    phieuthu = (from pt in _dbContext.phieuthus.ToList() where pt.NgayThu >= startDate && pt.NgayThu <= endDate select pt).ToList();

                    if (phieuthu != null && phieuthu.Count > 0)
                    {
                        foreach (phieuthu pt in phieuthu)
                        {
                            row = tbSource.NewRow();
                            row[_cID] = pt.MaPT;
                            row[_cHDNCode] = pt.PTCode;
                            row[_cDate] = pt.NgayThu;
                            row[_cReason] = pt.Reason;
                            row[_cAttach] = pt.DinhKem;
                            row[_cOwner] = pt.DoiTuongNop;
                            row[_cAddress] = pt.DiaChi;
                            row[_cMoney] = pt.SoTienTra_PT;
                            row[_cNotes] = pt.GhiChu;

                            tbSource.Rows.Add(row);
                        }
                        return tbSource;
                    }
                }
                else
                {
                    phieuchi = (from pc in _dbContext.phieuchis.ToList() where pc.NgayChi >= startDate && pc.NgayChi <= endDate select pc).ToList();

                    if (phieuchi != null && phieuchi.Count > 0)
                    {
                        foreach (phieuchi pc in phieuchi)
                        {
                            row = tbSource.NewRow();
                            row[_cID] = pc.MaPC;
                            row[_cHDNCode] = pc.PCCode;
                            row[_cDate] = pc.NgayChi;
                            row[_cReason] = pc.LyDo;
                            row[_cAttach] = pc.DinhKem;
                            row[_cOwner] = pc.DoiTuongChi;
                            row[_cAddress] = pc.DiaChi;
                            row[_cMoney] = pc.SoTienDaTra_PC;
                            row[_cNotes] = pc.GhiChu;

                            tbSource.Rows.Add(row);
                        }
                        return tbSource;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "DanhSachPhieuTheoQuy");
            }
            return tbSource;
        }

        // Danh sách phiếu theo tháng
        private void DanhSachPhieuTheoThang(int thang)
        {
            int maxDateOfMonth = 30;
            DateTime today;
            try
            {
                today = DateTime.Now;
                maxDateOfMonth = DateTime.DaysInMonth(today.Year, thang);
                if (_selectTab == 0)
                {
                    dateEdit_FromThu.DateTime = new DateTime(today.Year, thang, 1, 0, 0, 0);
                    dateEdit_ToThu.DateTime = new DateTime(today.Year, thang, maxDateOfMonth, 23, 59, 59);
                }
                else
                {
                    dateEdit_From.DateTime = new DateTime(today.Year, thang, 1, 0, 0, 0);
                    dateEdit_To.DateTime = new DateTime(today.Year, thang, maxDateOfMonth, 23, 59, 59);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "DanhSachPhieuTheoThang");
            }
        }

        private void barButtonItem_1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_1_ItemClick");
            }
        }

        private void barButtonItem_2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(2);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_2_ItemClick");
            }
        }

        private void barButtonItem_3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(3);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_3_ItemClick");
            }
        }

        private void barButtonItem_4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(4);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_4_ItemClick");
            }
        }

        private void barButtonItem_5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(5);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_5_ItemClick");
            }
        }

        private void barButtonItem_6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(6);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_6_ItemClick");
            }
        }

        private void barButtonItem_7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(7);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_7_ItemClick");
            }
        }

        private void barButtonItem_8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(8);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_8_ItemClick");
            }
        }

        private void barButtonItem_9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(9);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_9_ItemClick");
            }
        }

        private void barButtonItem_10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(10);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_10_ItemClick");
            }
        }

        private void barButtonItem_11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(12);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_11_ItemClick");
            }
        }

        private void barButtonItem_12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DanhSachPhieuTheoThang(12);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_12_ItemClick");
            }
        }

        private void barButtonItem_Q1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_selectTab == 0)
                {
                    gridControl_PhieuThu.DataSource = DanhSachPhieuTheoQuy(1);
                }
                else
                {
                    gridControl_PhieuChi.DataSource = DanhSachPhieuTheoQuy(1);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Q1_ItemClick");
            }
        }

        private void barButtonItem_Q2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_selectTab == 0)
                {
                    gridControl_PhieuThu.DataSource = DanhSachPhieuTheoQuy(2);
                }
                else
                {
                    gridControl_PhieuChi.DataSource = DanhSachPhieuTheoQuy(2);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Q2_ItemClick");
            }
        }

        private void barButtonItem_Q3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_selectTab == 0)
                {
                    gridControl_PhieuThu.DataSource = DanhSachPhieuTheoQuy(3);
                }
                else
                {
                    gridControl_PhieuChi.DataSource = DanhSachPhieuTheoQuy(3);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Q3_ItemClick");
            }
        }

        private void barButtonItem_Q4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_selectTab == 0)
                {
                    gridControl_PhieuThu.DataSource = DanhSachPhieuTheoQuy(4);
                }
                else
                {
                    gridControl_PhieuChi.DataSource = DanhSachPhieuTheoQuy(4);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Q4_ItemClick");
            }
        }
    }
}