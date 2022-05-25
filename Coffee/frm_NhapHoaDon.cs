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
using TracerX;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Coffee
{
    public partial class frm_NhapHoaDon : DevExpress.XtraEditors.XtraForm
    {

        // Đối tượng Log cho lớp
        private static readonly Logger log = Logger.GetLogger(typeof(frm_NhapHoaDon));

        private mycoffeeEntities _dbContext;
        private DataTable _tbSource;
        private DataTable _tbSourceCTHD;

        private const string _cDate = "Date";
        private const string _cTotalMoney = "TotalMoney";
        private const string _cPayed = "Payed";
        private const string _cHDCode = "HDCode";
        private const string _cHDNID = "HDNID";
        private const string _cNHACC = "NHACC";

        private const string _cProductID = "ProductID";
        private const string _cProductName = "ProductName";
        private const string _cPrice = "Price";
        private const string _cMoney = "Money";
        private const string _cQuantity = "Quantity";


        public frm_NhapHoaDon()
        {
            InitializeComponent();
        }

        private void frm_Stock_Load(object sender, EventArgs e)
        {
            try
            {
                //Tạo cấu trúc cho gridview
                _tbSource = CreateTableStruct();
                _tbSourceCTHD = CreateTableCTStruct();

                //Load danh sách hoá đơn nhập
                Load_HoaDonNhap();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "frm_Stock_Load");
            }
        }

        private void barButtonItem_Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_InputStock dlg;
            hoadonnhap hdn;
            chitiethdn ct;
            tonkho tk;
            DataRow row;
            product product;

            try
            {
                hdn= new hoadonnhap();
                ct= new chitiethdn();
                tk= new tonkho();
                dlg = new frm_InputStock();
                dlg.P_HoaDonNhap = hdn;
                dlg.P_CTDonNhap = ct;
                dlg.Text = "Thêm Hàng Vào Kho";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                    //Thêm hoá đơn nhập
                    _dbContext.hoadonnhaps.Add(dlg.P_HoaDonNhap);
                    _dbContext.SaveChanges();

                    //GridView hoá đơn nhập
                    row = _tbSource.NewRow();
                    row[_cHDNID] = dlg.P_HoaDonNhap.MAHDN;
                    row[_cNHACC] = dlg.P_HoaDonNhap.MANCC;
                    row[_cDate] = dlg.P_HoaDonNhap.NGAYNHAP;
                    row[_cTotalMoney] = dlg.P_HoaDonNhap.TIENPHAITRA;
                    row[_cPayed] = dlg.P_HoaDonNhap.TIENDATRA;
                    row[_cHDCode] = dlg.P_HoaDonNhap.HDNCode;

                    _tbSource.Rows.Add(row);

                    gridControl_HDN.DataSource = _tbSource;

                    //Thêm chi tiết hoá đơn nhập
                    foreach (DataRow r in dlg._tbSource.Rows)
                    {
                        //Số lượng quy đổi
                        product = (from p in _dbContext.products.ToList() where p.ProductID == Convert.ToInt32(r[_cProductID]) select p).FirstOrDefault();
                        if (product != null)
                        {
                            if (product.ExchangeQuantity > 0)
                            {
                                r[_cQuantity] = product.ExchangeQuantity;//Nếu mặt hàng có định lượng thì lấy giá trị định lượng
                            }
                        }

                        ct.MAHDN = CoffeeHelpers.GetHoaDonNhapMaxCode();
                        ct.MAMH = Convert.ToInt32(r[_cProductID]);
                        ct.GIANHAP = Convert.ToDecimal(r[_cPrice]);
                        ct.SOLUONGNHAP = Convert.ToInt32(r[_cQuantity]);

                        MySqlCommand cmd = new MySqlCommand();
                        MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                        cmd = con.CreateCommand();
                        //Cập nhật tiền khuyến mãi
                        cmd.CommandText = "Insert Into chitiethdn(MAHDN,MAMH,GIANHAP,SOLUONGNHAP) Values('"+ct.MAHDN+"','"+ct.MAMH+"','"+ct.GIANHAP+"','"+ct.SOLUONGNHAP+"')";

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        //_dbContext.ExecuteCommand("Insert Into CHITIETHDN(MAHDN,MAMH,GIANHAP,SOLUONGNHAP) Values({0},{1},{2},{3})",ct.MAHDN,ct.MAMH,ct.GIANHAP,ct.SOLUONGNHAP);

                        //Gridview chi tiết hoá đơn nhập
                        row = _tbSourceCTHD.NewRow();
                        row[_cProductID] = Convert.ToInt32(r[_cProductID]);
                        row[_cProductName] = r[_cProductName];
                        row[_cQuantity] = Convert.ToInt32(r[_cQuantity]);
                        row[_cPrice] = Convert.ToDecimal(r[_cPrice]);
                        row[_cMoney] = Convert.ToInt32(r[_cQuantity]) *Convert.ToDecimal(r[_cPrice]);

                        //Thêm vào tồn kho
                        tk = (from k in _dbContext.tonkhoes.ToList() where k.MAMH == Convert.ToInt32(r[_cProductID]) select k).FirstOrDefault();
                        if (tk != null)//Update
                        {
                            tk.SOLUONGNHAP = tk.SOLUONGNHAP + Convert.ToInt32(r[_cQuantity]);
                            tk.SOLUONGTON = tk.SOLUONGTON + Convert.ToInt32(r[_cQuantity]);

                            cmd = new MySqlCommand();
                            con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                            cmd = con.CreateCommand();
                            //Cập nhật tiền khuyến mãi
                            cmd.CommandText = "Update tonkho SET NGAYTHANG='" + tk.NGAYTHANG +"', SOLUONGNHAP='" + tk.SOLUONGNHAP + "',SOLUONGTON='" + tk.SOLUONGTON + "' where MAMH='" + Convert.ToInt32(r[_cProductID]) + "'";

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                           // _dbContext.ExecuteCommand("Update TONKHO SET NGAYTHANG={0}, SOLUONGNHAP={1} where MAMH={2}",tk.NGAYTHANG,tk.SOLUONGNHAP,Convert.ToInt32(r[_cProductID]));
                        }
                        else//Add
                        {
                            tk = new tonkho();
                            tk.NGAYTHANG = dlg.P_HoaDonNhap.NGAYNHAP.Value.ToString("dd/MM/yyyy HH:mm:ss");
                            tk.MAMH = Convert.ToInt32(r[_cProductID]);
                            tk.SOLUONGDAU = 0;
                            tk.SOLUONGNHAP = Convert.ToInt32(r[_cQuantity]);
                            tk.SOLUONGTON = Convert.ToInt32(r[_cQuantity]);

                            cmd = new MySqlCommand();
                            con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                            cmd = con.CreateCommand();
                            //Cập nhật tiền khuyến mãi
                            cmd.CommandText = "Insert Into tonkho(NGAYTHANG,MAMH,SOLUONGNHAP,SOLUONGTON) Values('"+tk.NGAYTHANG+"','"+tk.MAMH+"','"+ tk.SOLUONGNHAP+"','"+tk.SOLUONGTON+"')";

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            //_dbContext.ExecuteCommand("Insert Into TONKHO(NGAYTHANG,MAMH,SOLUONGNHAP) Values({0},{1},{2})", tk.NGAYTHANG,tk.MAMH, tk.SOLUONGNHAP);
                        }
                        
                    }
                    // Ghi log
                    WriteLog("Nhập kho có mã phiếu là: " + dlg.P_HoaDonNhap.HDNCode.ToString());

                    log.Info("Lúc " + DateTime.Now + ", nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " nhập kho có mã phiếu là: " + dlg.P_HoaDonNhap.HDNCode.ToString());
                }         
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Add_ItemClick");
            }
        }

        private void barButtonItem_UpdateStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_InputStock dlg;
            List<chitiethdn> ct;
            hoadonnhap hd;
            DataRow focusRow;
            chitiethdn cthd;
            tonkho tk;

            try
            {

                if (gridView_HDN.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn hoá đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                focusRow = gridView_HDN.GetFocusedDataRow();
                ct = (from c in _dbContext.chitiethdns.ToList() where c.MAHDN == Convert.ToInt32(focusRow[_cHDNID]) select c).ToList();
                hd = (from h in _dbContext.hoadonnhaps.ToList() where h.MAHDN == Convert.ToInt32(focusRow[_cHDNID]) select h).FirstOrDefault();

                dlg = new frm_InputStock();
                dlg.ListCTDonNhap = ct;
                dlg.P_HoaDonNhap = hd;
                dlg.Text = "Sửa Thông Tin Nhập Kho";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //Cập nhật thông tin phiếu nhập
                    hd.MANCC = dlg.P_HoaDonNhap.MANCC;
                    hd.NGAYNHAP = dlg.P_HoaDonNhap.NGAYNHAP;
                    hd.TIENPHAITRA = dlg.P_HoaDonNhap.TIENPHAITRA;
                    hd.TIENDATRA = dlg.P_HoaDonNhap.TIENDATRA;
                    hd.GHICHU = dlg.P_HoaDonNhap.GHICHU;
                    _dbContext.SaveChanges();

                    foreach (DataRow rw in _tbSource.Rows)
                    {
                        if (rw[_cHDCode].ToString().Trim() == focusRow[_cHDCode].ToString().Trim())
                        {
                            rw[_cNHACC] = dlg.P_HoaDonNhap.MANCC;
                            rw[_cDate] = dlg.P_HoaDonNhap.NGAYNHAP;
                            rw[_cTotalMoney] = dlg.P_HoaDonNhap.TIENPHAITRA;
                            rw[_cPayed] = dlg.P_HoaDonNhap.TIENDATRA;

                            gridView_HDN.LayoutChanged();
                            break;
                        }
                    }

                    //Thông tin chi tiết phiếu nhập
                    foreach (DataRow r in _tbSourceCTHD.Rows)
                    {
                        int i = 0;
                        bool exist = false;//Kiểm tra mặt hàng này tồn tại hay chưa
                        //Thêm vào tồn kho
                        tk = (from k in _dbContext.tonkhoes.ToList() where k.MAMH == Convert.ToInt32(r[_cProductID]) select k).FirstOrDefault();
                        foreach (DataRow rw in dlg._tbSource.Rows)//Nếu có thì update
                        {
                            if (r[_cProductID].ToString().Trim() == dlg._tbSource.Rows[i][_cProductID].ToString().Trim())
                            {
                                cthd = (from d in _dbContext.chitiethdns.ToList() where d.MAHDN == Convert.ToInt32(r[_cHDNID]) && d.MAMH == Convert.ToInt32(r[_cProductID].ToString().Trim()) select d).FirstOrDefault();
                                if (cthd != null)
                                {
                                    cthd.SOLUONGNHAP = Convert.ToInt32(rw[_cQuantity]);
                                    _dbContext.SaveChanges();

                                    //Cập nhật trên gridView
                                    foreach (DataRow rws in _tbSourceCTHD.Rows)
                                    {
                                        if (Convert.ToInt32(rws[_cProductID]) == Convert.ToInt32(rw[_cProductID]))
                                        {
                                            rws[_cQuantity] = Convert.ToInt32(rw[_cQuantity]);
                                            gridView_CTHDN.LayoutChanged();
                                            break;
                                        }
                                    }

                                    //Kho
                                    if (tk != null)//Update
                                    {
                                        tk.SOLUONGNHAP = (tk.SOLUONGNHAP - Convert.ToInt32(r[_cQuantity])) + Convert.ToInt32(rw[_cQuantity]);
                                        tk.SOLUONGTON = (tk.SOLUONGTON - Convert.ToInt32(r[_cQuantity])) + Convert.ToInt32(rw[_cQuantity]);

                                        MySqlCommand cmd = new MySqlCommand();
                                        MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                                        cmd = con.CreateCommand();
                                        //Cập nhật tiền khuyến mãi
                                        cmd.CommandText = "Update tonkho SET NGAYTHANG='" + tk.NGAYTHANG + "', SOLUONGNHAP='" + tk.SOLUONGNHAP + "', SOLUONGTON='" + tk.SOLUONGTON + "' where MAMH='" + Convert.ToInt32(r[_cProductID]) + "'";

                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                        //_dbContext.ExecuteCommand("Update TONKHO SET NGAYTHANG={0}, SOLUONGNHAP={1} where MAMH={2}", tk.NGAYTHANG, tk.SOLUONGNHAP, Convert.ToInt32(r[_cProductID]));
                                    }
                                }
                                exist = true;
                                break;
                            }
                            i++;
                        }
                        if (exist == false)//Xoá
                        {
                            cthd = new chitiethdn();
                            cthd = (from d in _dbContext.chitiethdns.ToList() where d.MAHDN == Convert.ToInt32(r[_cHDNID]) && d.MAMH == Convert.ToInt32(r[_cProductID].ToString().Trim()) select d).FirstOrDefault();
                            if (cthd != null)
                            {
                                _dbContext.chitiethdns.Remove(cthd);
                                _dbContext.SaveChanges();

                                //Xoá trên gridView
                                foreach (DataRow rw in _tbSourceCTHD.Rows)
                                {
                                    if (Convert.ToInt32(rw[_cProductID]) == cthd.MAMH)
                                    {
                                        _tbSourceCTHD.Rows.Remove(rw);
                                        gridView_CTHDN.DeleteRow(gridView_CTHDN.GetSelectedRows()[0]);
                                        gridView_CTHDN.LayoutChanged();
                                        break;
                                    }
                                }

                                //Kho
                                tk.SOLUONGNHAP = (tk.SOLUONGNHAP - Convert.ToInt32(r[_cQuantity]));
                                tk.SOLUONGTON = (tk.SOLUONGTON- Convert.ToInt32(r[_cQuantity]));

                                MySqlCommand cmd = new MySqlCommand();
                                MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                                cmd = con.CreateCommand();
                                //Cập nhật tiền khuyến mãi
                                cmd.CommandText = "Update tonkho SET NGAYTHANG='" + tk.NGAYTHANG + "', SOLUONGNHAP='" + tk.SOLUONGNHAP + "', SOLUONGTON='" + tk.SOLUONGTON + "' where MAMH='" + Convert.ToInt32(r[_cProductID]) + "'";

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                //_dbContext.ExecuteCommand("Update TONKHO SET NGAYTHANG={0}, SOLUONGNHAP={1} where MAMH={2}", tk.NGAYTHANG, tk.SOLUONGNHAP, Convert.ToInt32(r[_cProductID]));
                            }
                        }
                    }

                    //Add lại mặt hàng nếu có mặt hàng mới
                    foreach (DataRow r in dlg._tbSource.Rows)
                    {
                        int i = 0;
                        bool exist = false;//Kiểm tra mặt hàng này tồn tại hay chưa
                        foreach (DataRow rw in _tbSourceCTHD.Rows)
                        {
                            if (r[_cProductID] == dlg._tbSource.Rows[i][_cProductID])
                            {
                                exist = true;
                                break;
                            }
                            i++;
                        }
                        if (exist == false)//Thêm mới record
                        {
                            cthd = new chitiethdn();
                            cthd.MAHDN = Convert.ToInt32(focusRow[_cHDNID]);
                            cthd.MAMH = Convert.ToInt32(r[_cProductID]);
                            cthd.GIANHAP = Convert.ToDecimal(r[_cPrice]);
                            cthd.SOLUONGNHAP = Convert.ToInt32(r[_cQuantity]);

                            MySqlCommand cmd = new MySqlCommand();
                            MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                            cmd = con.CreateCommand();
                            //Cập nhật tiền khuyến mãi
                            cmd.CommandText = "Insert Into chitiethdn(MAHDN,MAMH,GIANHAP,SOLUONGNHAP) Values('"+cthd.MAHDN+"','"+cthd.MAMH+"','"+cthd.GIANHAP+"','"+cthd.SOLUONGNHAP+"')";

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            //_dbContext.ExecuteCommand("Insert Into CHITIETHDN(MAHDN,MAMH,GIANHAP,SOLUONGNHAP) Values({0},{1},{2},{3})", cthd.MAHDN, cthd.MAMH, cthd.GIANHAP, cthd.SOLUONGNHAP);

                            //Cập nhật trên gridView
                            DataRow newRow;
                            newRow = _tbSourceCTHD.NewRow();
                            newRow[_cHDNID] = Convert.ToInt32(focusRow[_cHDNID]);
                            newRow[_cProductID] = Convert.ToInt32(r[_cProductID]);
                            newRow[_cProductName] = r[_cProductName];
                            newRow[_cQuantity] = Convert.ToInt32(r[_cQuantity]);
                            newRow[_cPrice] = r[_cPrice];
                            newRow[_cMoney] = Convert.ToInt32(r[_cQuantity]) * Convert.ToDecimal(r[_cPrice]);

                            _tbSourceCTHD.Rows.Add(newRow);

                            //Thêm vào kho
                            tk = new tonkho();
                            tk.NGAYTHANG = dlg.P_HoaDonNhap.NGAYNHAP.Value.ToString("dd/MM/yyyy HH:mm:ss");
                            tk.MAMH = Convert.ToInt32(r[_cProductID]);
                            tk.SOLUONGDAU = 0;
                            tk.SOLUONGNHAP = Convert.ToInt32(r[_cQuantity]);
                            tk.SOLUONGTON = Convert.ToInt32(r[_cQuantity]);

                            cmd = new MySqlCommand();
                            con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                            cmd = con.CreateCommand();
                            //Cập nhật tiền khuyến mãi
                            cmd.CommandText = "Insert Into tonkho(NGAYTHANG,MAMH,SOLUONGNHAP,SOLUONGTON) Values('"+tk.NGAYTHANG+"','"+tk.MAMH+"','"+tk.SOLUONGNHAP+"','"+tk.SOLUONGTON+"')";

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                           // _dbContext.ExecuteCommand("Insert Into TONKHO(NGAYTHANG,MAMH,SOLUONGNHAP) Values({0},{1},{2})", tk.NGAYTHANG, tk.MAMH, tk.SOLUONGNHAP);
                        }
                    }
                }
                // Ghi log
                WriteLog("Sửa phiếu nhập kho có mã phiếu là: " + focusRow[_cHDCode].ToString());

                log.Info("Lúc " + DateTime.Now + ", nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " sửa phiếu nhập kho có mã phiếu là: " + focusRow[_cHDCode].ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_UpdateStock_ItemClick");
            }
        }

        private void gridControl_HDN_DoubleClick(object sender, EventArgs e)
        {
            frm_InputStock dlg;
            List<chitiethdn> ct;
            hoadonnhap hd;
            DataRow focusRow;
            chitiethdn cthd;
            tonkho tk;

            try
            {

                if (gridView_HDN.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn hoá đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);

                focusRow = gridView_HDN.GetFocusedDataRow();
                ct = (from c in _dbContext.chitiethdns.ToList() where c.MAHDN == Convert.ToInt32(focusRow[_cHDNID]) select c).ToList();
                hd = (from h in _dbContext.hoadonnhaps.ToList() where h.MAHDN == Convert.ToInt32(focusRow[_cHDNID]) select h).FirstOrDefault();

                dlg = new frm_InputStock();
                dlg.ListCTDonNhap = ct;
                dlg.P_HoaDonNhap = hd;
                dlg.Text = "Sửa Thông Tin Nhập Kho";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //Cập nhật thông tin phiếu nhập
                    hd.MANCC = dlg.P_HoaDonNhap.MANCC;
                    hd.NGAYNHAP = dlg.P_HoaDonNhap.NGAYNHAP;
                    hd.TIENPHAITRA = dlg.P_HoaDonNhap.TIENPHAITRA;
                    hd.TIENDATRA = dlg.P_HoaDonNhap.TIENDATRA;
                    hd.GHICHU = dlg.P_HoaDonNhap.GHICHU;
                    _dbContext.SaveChanges();

                    foreach (DataRow rw in _tbSource.Rows)
                    {
                        if (rw[_cHDCode].ToString().Trim() == focusRow[_cHDCode].ToString().Trim())
                        {
                            rw[_cNHACC] = dlg.P_HoaDonNhap.MANCC;
                            rw[_cDate] = dlg.P_HoaDonNhap.NGAYNHAP;
                            rw[_cTotalMoney] = dlg.P_HoaDonNhap.TIENPHAITRA;
                            rw[_cPayed] = dlg.P_HoaDonNhap.TIENDATRA;

                            gridView_HDN.LayoutChanged();
                            break;
                        }
                    }

                    //Thông tin chi tiết phiếu nhập
                    foreach (DataRow r in _tbSourceCTHD.Rows)
                    {
                        int i = 0;
                        bool exist = false;//Kiểm tra mặt hàng này tồn tại hay chưa
                        //Thêm vào tồn kho
                        tk = (from k in _dbContext.tonkhoes.ToList() where k.MAMH == Convert.ToInt32(r[_cProductID]) select k).FirstOrDefault();
                        foreach (DataRow rw in dlg._tbSource.Rows)//Nếu có thì update
                        {
                            if (r[_cProductID].ToString().Trim() == dlg._tbSource.Rows[i][_cProductID].ToString().Trim())
                            {
                                cthd = (from d in _dbContext.chitiethdns.ToList() where d.MAHDN == Convert.ToInt32(r[_cHDNID]) && d.MAMH == Convert.ToInt32(r[_cProductID].ToString().Trim()) select d).FirstOrDefault();
                                if (cthd != null)
                                {
                                    cthd.SOLUONGNHAP = Convert.ToInt32(rw[_cQuantity]);
                                    _dbContext.SaveChanges();

                                    //Cập nhật trên gridView
                                    foreach (DataRow rws in _tbSourceCTHD.Rows)
                                    {
                                        if (Convert.ToInt32(rws[_cProductID]) == Convert.ToInt32(rw[_cProductID]))
                                        {
                                            rws[_cQuantity] = Convert.ToInt32(rw[_cQuantity]);
                                            gridView_CTHDN.LayoutChanged();
                                            break;
                                        }
                                    }

                                    //Kho
                                    if (tk != null)//Update
                                    {
                                        tk.SOLUONGNHAP = (tk.SOLUONGNHAP - Convert.ToInt32(r[_cQuantity])) + Convert.ToInt32(rw[_cQuantity]);
                                        tk.SOLUONGTON = (tk.SOLUONGTON - Convert.ToInt32(r[_cQuantity])) + Convert.ToInt32(rw[_cQuantity]);

                                        MySqlCommand cmd = new MySqlCommand();
                                        MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                                        cmd = con.CreateCommand();
                                        //Cập nhật tiền khuyến mãi
                                        cmd.CommandText = "Update tonkho SET NGAYTHANG='" + tk.NGAYTHANG + "', SOLUONGNHAP='" + tk.SOLUONGNHAP + "', SOLUONGTON='" + tk.SOLUONGTON + "' where MAMH='" + Convert.ToInt32(r[_cProductID]) + "'";

                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                        //_dbContext.ExecuteCommand("Update TONKHO SET NGAYTHANG={0}, SOLUONGNHAP={1} where MAMH={2}", tk.NGAYTHANG, tk.SOLUONGNHAP, Convert.ToInt32(r[_cProductID]));
                                    }
                                }
                                exist = true;
                                break;
                            }
                            i++;
                        }
                        if (exist == false)//Xoá
                        {
                            cthd = new chitiethdn();
                            cthd = (from d in _dbContext.chitiethdns.ToList() where d.MAHDN == Convert.ToInt32(r[_cHDNID]) && d.MAMH == Convert.ToInt32(r[_cProductID].ToString().Trim()) select d).FirstOrDefault();
                            if (cthd != null)
                            {
                                _dbContext.chitiethdns.Remove(cthd);
                                _dbContext.SaveChanges();

                                //Xoá trên gridView
                                foreach (DataRow rw in _tbSourceCTHD.Rows)
                                {
                                    if (Convert.ToInt32(rw[_cProductID]) == cthd.MAMH)
                                    {
                                        _tbSourceCTHD.Rows.Remove(rw);
                                        gridView_CTHDN.DeleteRow(gridView_CTHDN.GetSelectedRows()[0]);
                                        gridView_CTHDN.LayoutChanged();
                                        break;
                                    }
                                }

                                //Kho
                                tk.SOLUONGNHAP = (tk.SOLUONGNHAP - Convert.ToInt32(r[_cQuantity]));
                                tk.SOLUONGTON = (tk.SOLUONGTON - Convert.ToInt32(r[_cQuantity]));

                                MySqlCommand cmd = new MySqlCommand();
                                MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                                cmd = con.CreateCommand();
                                //Cập nhật tiền khuyến mãi
                                cmd.CommandText = "Update tonkho SET NGAYTHANG='" + tk.NGAYTHANG + "', SOLUONGNHAP='" + tk.SOLUONGNHAP + "', SOLUONGTON='" + tk.SOLUONGTON + "' where MAMH='" + Convert.ToInt32(r[_cProductID]) + "'";

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                //_dbContext.ExecuteCommand("Update TONKHO SET NGAYTHANG={0}, SOLUONGNHAP={1} where MAMH={2}", tk.NGAYTHANG, tk.SOLUONGNHAP, Convert.ToInt32(r[_cProductID]));
                            }
                        }
                    }

                    //Add lại mặt hàng nếu có mặt hàng mới
                    foreach (DataRow r in dlg._tbSource.Rows)
                    {
                        int i = 0;
                        bool exist = false;//Kiểm tra mặt hàng này tồn tại hay chưa
                        foreach (DataRow rw in _tbSourceCTHD.Rows)
                        {
                            if (r[_cProductID] == dlg._tbSource.Rows[i][_cProductID])
                            {
                                exist = true;
                                break;
                            }
                            i++;
                        }
                        if (exist == false)//Thêm mới record
                        {
                            cthd = new chitiethdn();
                            cthd.MAHDN = Convert.ToInt32(focusRow[_cHDNID]);
                            cthd.MAMH = Convert.ToInt32(r[_cProductID]);
                            cthd.GIANHAP = Convert.ToDecimal(r[_cPrice]);
                            cthd.SOLUONGNHAP = Convert.ToInt32(r[_cQuantity]);

                            MySqlCommand cmd = new MySqlCommand();
                            MySqlConnection con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                            cmd = con.CreateCommand();
                            //Cập nhật tiền khuyến mãi
                            cmd.CommandText = "Insert Into chitiethdn(MAHDN,MAMH,GIANHAP,SOLUONGNHAP) Values('" + cthd.MAHDN + "','" + cthd.MAMH + "','" + cthd.GIANHAP + "','" + cthd.SOLUONGNHAP + "')";

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            //_dbContext.ExecuteCommand("Insert Into CHITIETHDN(MAHDN,MAMH,GIANHAP,SOLUONGNHAP) Values({0},{1},{2},{3})", cthd.MAHDN, cthd.MAMH, cthd.GIANHAP, cthd.SOLUONGNHAP);

                            //Cập nhật trên gridView
                            DataRow newRow;
                            newRow = _tbSourceCTHD.NewRow();
                            newRow[_cHDNID] = Convert.ToInt32(focusRow[_cHDNID]);
                            newRow[_cProductID] = Convert.ToInt32(r[_cProductID]);
                            newRow[_cProductName] = r[_cProductName];
                            newRow[_cQuantity] = Convert.ToInt32(r[_cQuantity]);
                            newRow[_cPrice] = r[_cPrice];
                            newRow[_cMoney] = Convert.ToInt32(r[_cQuantity]) * Convert.ToDecimal(r[_cPrice]);

                            _tbSourceCTHD.Rows.Add(newRow);

                            //Thêm vào kho
                            tk = new tonkho();
                            tk.NGAYTHANG = dlg.P_HoaDonNhap.NGAYNHAP.Value.ToString("dd/MM/yyyy HH:mm:ss");
                            tk.MAMH = Convert.ToInt32(r[_cProductID]);
                            tk.SOLUONGDAU = 0;
                            tk.SOLUONGNHAP = Convert.ToInt32(r[_cQuantity]);
                            tk.SOLUONGTON = Convert.ToInt32(r[_cQuantity]);

                            cmd = new MySqlCommand();
                            con = new MySqlConnection(CoffeeHelpers.ConnectionString);
                            cmd = con.CreateCommand();
                            //Cập nhật tiền khuyến mãi
                            cmd.CommandText = "Insert Into tonkho(NGAYTHANG,MAMH,SOLUONGNHAP,SOLUONGTON) Values('" + tk.NGAYTHANG + "','" + tk.MAMH + "','" + tk.SOLUONGNHAP + "','" + tk.SOLUONGTON + "')";

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            // _dbContext.ExecuteCommand("Insert Into TONKHO(NGAYTHANG,MAMH,SOLUONGNHAP) Values({0},{1},{2})", tk.NGAYTHANG, tk.MAMH, tk.SOLUONGNHAP);
                        }
                    }
                }
                // Ghi log
                WriteLog("Sửa phiếu nhập kho có mã phiếu là: " + focusRow[_cHDCode].ToString());

                log.Info("Lúc " + DateTime.Now + ", nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " sửa phiếu nhập kho có mã phiếu là: " + focusRow[_cHDCode].ToString());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridControl_HDN_DoubleClick");
            }
        }

        private void barButtonItem_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Exit_ItemClick");
            }
        }

        private void barButtonItem_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            hoadonnhap hdn;
            List<chitiethdn> ct;
            DataRow focusRow;
            try
            {
                if (gridView_HDN.SelectedRowsCount <= 0)
                {
                    XtraMessageBox.Show("Vui lòng chọn phiếu muốn xoá", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                if (XtraMessageBox.Show("Phiếu nhập kho này sẽ bị xoá vĩnh viễn. Bạn có chắc muốn xoá ?", "Xoá Phiếu Nhập Kho", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                focusRow = gridView_HDN.GetFocusedDataRow();
                hdn = (from hd in _dbContext.hoadonnhaps.ToList() where hd.HDNCode == focusRow[_cHDCode].ToString().Trim() select hd).FirstOrDefault();
                if (hdn != null)
                {
                    ct = (from c in _dbContext.chitiethdns.ToList() where c.MAHDN == hdn.MAHDN select c).ToList();
                    if (ct != null && ct.Count > 0)
                    {
                        //Xoá chi tiết phiếu nhập kho
                        foreach (chitiethdn cthd in ct)
                        {
                            _dbContext.chitiethdns.Remove(cthd);
                            _dbContext.SaveChanges();
                            gridView_CTHDN.DeleteRow(gridView_CTHDN.GetSelectedRows()[0]);
                        }
                    }

                    //Xoá phiếu nhập
                    _dbContext.hoadonnhaps.Remove(hdn);
                    _dbContext.SaveChanges();

                    // Ghi log
                    WriteLog("Xoá phiếu nhập kho có mã phiếu là: " + focusRow[_cHDCode].ToString());

                    log.Info("Lúc " + DateTime.Now + ", nhân viên " + CoffeeHelpers.EmpLogin.EmployeeName + " xoá phiếu nhập kho có mã phiếu là: " + focusRow[_cHDCode].ToString());

                    gridView_HDN.DeleteRow(gridView_HDN.GetSelectedRows()[0]);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "barButtonItem_Delete_ItemClick");
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

        //Tạo cấu trúc cho gridView Hoá Đơn Nhập
        private DataTable CreateTableStruct()
        {
            DataTable tbSource=null;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cHDNID);
                tbSource.Columns.Add(_cNHACC);
                tbSource.Columns.Add(_cDate);
                tbSource.Columns.Add(_cTotalMoney);
                tbSource.Columns.Add(_cPayed);
                tbSource.Columns.Add(_cHDCode);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableStruct");
                return tbSource;
            }
            return tbSource;
        }

        //Tạo cấu trúc cho gridView Chi tiết Hoá Đơn Nhập
        private DataTable CreateTableCTStruct()
        {
            DataTable tbSource = null;
            try
            {
                tbSource = new DataTable();
                tbSource.Columns.Add(_cHDNID);
                tbSource.Columns.Add(_cProductID);
                tbSource.Columns.Add(_cProductName);
                tbSource.Columns.Add(_cQuantity);
                tbSource.Columns.Add(_cPrice);
                tbSource.Columns.Add(_cMoney);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "CreateTableCTStruct");
                return tbSource;
            }
            return tbSource;
        }

        //Load danh sách hoá đơn nhập
        private void Load_HoaDonNhap()
        {
            List<hoadonnhap> listhd;
            DataRow row;
            try
            {
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                listhd = (from hd in _dbContext.hoadonnhaps.ToList() select hd).ToList();
                if (listhd != null && listhd.Count > 0)
                {
                    foreach(hoadonnhap hd in listhd)
                    {
                        row = _tbSource.NewRow();
                        row[_cHDNID] = hd.MAHDN;
                        row[_cDate] = hd.NGAYNHAP;
                        row[_cTotalMoney] = hd.TIENPHAITRA;
                        row[_cPayed] = hd.TIENDATRA;
                        row[_cHDCode] = hd.HDNCode;

                        _tbSource.Rows.Add(row);
                    }
                    gridControl_HDN.DataSource = _tbSource;
                }
             
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Load_HoaDonNhap");
            }
        }

        //Load danh sách mặt hàng theo hoá đơn nhập
        private void LoadProductByOrder(int HDNID)
        {
            List<chitiethdn> ctNhaps;
            DataRow row;

            try
            {
                _tbSourceCTHD = CreateTableCTStruct();
                _dbContext = new mycoffeeEntities(CoffeeHelpers.ConnectionString);
                ctNhaps = (from hd in _dbContext.chitiethdns.ToList() where hd.MAHDN == HDNID select hd).ToList();
                if (ctNhaps != null && ctNhaps.Count > 0)
                {
                    foreach (chitiethdn ct in ctNhaps)
                    {
                        row = _tbSourceCTHD.NewRow();
                        row[_cHDNID] = HDNID;
                        row[_cProductID] = ct.MAMH;
                        row[_cProductName] = ct.product.ProductName;
                        row[_cQuantity] = ct.SOLUONGNHAP;
                        row[_cPrice] = ct.GIANHAP;
                        row[_cMoney] = ct.SOLUONGNHAP * ct.GIANHAP;

                        _tbSourceCTHD.Rows.Add(row);
                    }
                    gridControl_CTHDN.DataSource = _tbSourceCTHD;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "LoadProductByOrder");
            }
        }

        private void gridView_HDN_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow focusRow;
            try
            {
                focusRow = gridView_HDN.GetFocusedDataRow();
                if (Convert.ToInt32(focusRow[_cTotalMoney]) == 0)
                {
                    textEdit_TotalMoney.EditValue = string.Format("{0:#,#}",focusRow[_cTotalMoney]);
                }
                else
                {
                    textEdit_TotalMoney.EditValue = string.Format("{0:#,#}", Convert.ToDecimal(focusRow[_cTotalMoney]));
                }
               
                LoadProductByOrder(Convert.ToInt32(focusRow[_cHDNID]));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "gridView_HDN_RowClick");
            }
        }
    }
}