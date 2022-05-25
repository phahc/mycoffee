namespace Coffee
{
    partial class frm_NhapHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem_Add = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_UpdateStock = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Exit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem_Update = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl_HDN = new DevExpress.XtraGrid.GridControl();
            this.gridView_HDN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_HDNID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_TotalMoney = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_HDCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Payed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textEdit_TotalMoney = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl_CTHDN = new DevExpress.XtraGrid.GridControl();
            this.gridView_CTHDN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Money = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_HDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_HDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TotalMoney.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_CTHDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CTHDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem_Add,
            this.barButtonItem_Delete,
            this.barButtonItem_UpdateStock,
            this.barButtonItem_Exit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Add, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_UpdateStock, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Delete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Exit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem_Add
            // 
            this.barButtonItem_Add.Caption = "Thêm phiếu";
            this.barButtonItem_Add.Glyph = global::Coffee.Properties.Resources.add_products;
            this.barButtonItem_Add.Id = 0;
            this.barButtonItem_Add.Name = "barButtonItem_Add";
            this.barButtonItem_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Add_ItemClick);
            // 
            // barButtonItem_UpdateStock
            // 
            this.barButtonItem_UpdateStock.Caption = "Sửa phiếu";
            this.barButtonItem_UpdateStock.Glyph = global::Coffee.Properties.Resources.Update;
            this.barButtonItem_UpdateStock.Id = 7;
            this.barButtonItem_UpdateStock.Name = "barButtonItem_UpdateStock";
            this.barButtonItem_UpdateStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_UpdateStock_ItemClick);
            // 
            // barButtonItem_Delete
            // 
            this.barButtonItem_Delete.Caption = "Xoá phiếu";
            this.barButtonItem_Delete.Glyph = global::Coffee.Properties.Resources.delete_products;
            this.barButtonItem_Delete.Id = 2;
            this.barButtonItem_Delete.Name = "barButtonItem_Delete";
            this.barButtonItem_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Delete_ItemClick);
            // 
            // barButtonItem_Exit
            // 
            this.barButtonItem_Exit.Caption = "Thoát";
            this.barButtonItem_Exit.Glyph = global::Coffee.Properties.Resources.Turn_off;
            this.barButtonItem_Exit.Id = 8;
            this.barButtonItem_Exit.Name = "barButtonItem_Exit";
            this.barButtonItem_Exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Exit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1134, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 532);
            this.barDockControlBottom.Size = new System.Drawing.Size(1134, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 508);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1134, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 508);
            // 
            // barButtonItem_Update
            // 
            this.barButtonItem_Update.Caption = "Sửa phiếu";
            this.barButtonItem_Update.Glyph = global::Coffee.Properties.Resources.Update;
            this.barButtonItem_Update.Id = 1;
            this.barButtonItem_Update.Name = "barButtonItem_Update";
            // 
            // barButtonItem_Close
            // 
            this.barButtonItem_Close.Caption = "Thoát";
            this.barButtonItem_Close.Glyph = global::Coffee.Properties.Resources.Turn_off;
            this.barButtonItem_Close.Id = 3;
            this.barButtonItem_Close.Name = "barButtonItem_Close";
            // 
            // gridControl_HDN
            // 
            this.gridControl_HDN.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl_HDN.Location = new System.Drawing.Point(3, 3);
            this.gridControl_HDN.MainView = this.gridView_HDN;
            this.gridControl_HDN.MenuManager = this.barManager1;
            this.gridControl_HDN.Name = "gridControl_HDN";
            this.gridControl_HDN.Size = new System.Drawing.Size(456, 502);
            this.gridControl_HDN.TabIndex = 0;
            this.gridControl_HDN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_HDN,
            this.gridView1});
            this.gridControl_HDN.DoubleClick += new System.EventHandler(this.gridControl_HDN_DoubleClick);
            // 
            // gridView_HDN
            // 
            this.gridView_HDN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_HDNID,
            this.c_Date,
            this.c_TotalMoney,
            this.c_HDCode,
            this.c_Payed});
            this.gridView_HDN.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView_HDN.GridControl = this.gridControl_HDN;
            this.gridView_HDN.Name = "gridView_HDN";
            this.gridView_HDN.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_HDN.OptionsView.ShowAutoFilterRow = true;
            this.gridView_HDN.OptionsView.ShowGroupPanel = false;
            this.gridView_HDN.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_HDN_RowClick);
            // 
            // c_HDNID
            // 
            this.c_HDNID.Caption = "Mã hoá đơn nhập";
            this.c_HDNID.FieldName = "HDNID";
            this.c_HDNID.Name = "c_HDNID";
            this.c_HDNID.OptionsColumn.AllowEdit = false;
            this.c_HDNID.OptionsColumn.AllowFocus = false;
            // 
            // c_Date
            // 
            this.c_Date.Caption = "Ngày";
            this.c_Date.FieldName = "Date";
            this.c_Date.Name = "c_Date";
            this.c_Date.OptionsColumn.AllowEdit = false;
            this.c_Date.OptionsColumn.AllowFocus = false;
            this.c_Date.Visible = true;
            this.c_Date.VisibleIndex = 0;
            this.c_Date.Width = 293;
            // 
            // c_TotalMoney
            // 
            this.c_TotalMoney.Caption = "Tổng tiền";
            this.c_TotalMoney.DisplayFormat.FormatString = "c2";
            this.c_TotalMoney.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.c_TotalMoney.FieldName = "TotalMoney";
            this.c_TotalMoney.Name = "c_TotalMoney";
            this.c_TotalMoney.OptionsColumn.AllowEdit = false;
            this.c_TotalMoney.OptionsColumn.AllowFocus = false;
            this.c_TotalMoney.Visible = true;
            this.c_TotalMoney.VisibleIndex = 1;
            this.c_TotalMoney.Width = 248;
            // 
            // c_HDCode
            // 
            this.c_HDCode.Caption = "Số phiếu";
            this.c_HDCode.FieldName = "HDCode";
            this.c_HDCode.Name = "c_HDCode";
            this.c_HDCode.OptionsColumn.AllowEdit = false;
            this.c_HDCode.OptionsColumn.AllowFocus = false;
            this.c_HDCode.Visible = true;
            this.c_HDCode.VisibleIndex = 3;
            this.c_HDCode.Width = 404;
            // 
            // c_Payed
            // 
            this.c_Payed.Caption = "Tiền đã trả";
            this.c_Payed.DisplayFormat.FormatString = "c2";
            this.c_Payed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.c_Payed.FieldName = "Payed";
            this.c_Payed.Name = "c_Payed";
            this.c_Payed.OptionsColumn.AllowEdit = false;
            this.c_Payed.OptionsColumn.AllowFocus = false;
            this.c_Payed.Visible = true;
            this.c_Payed.VisibleIndex = 2;
            this.c_Payed.Width = 235;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl_HDN;
            this.gridView1.Name = "gridView1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl_HDN, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 508);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textEdit_TotalMoney);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(666, 38);
            this.panelControl1.TabIndex = 1;
            // 
            // textEdit_TotalMoney
            // 
            this.textEdit_TotalMoney.AllowDrop = true;
            this.textEdit_TotalMoney.Location = new System.Drawing.Point(481, 9);
            this.textEdit_TotalMoney.MenuManager = this.barManager1;
            this.textEdit_TotalMoney.Name = "textEdit_TotalMoney";
            this.textEdit_TotalMoney.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_TotalMoney.Properties.Appearance.Options.UseFont = true;
            this.textEdit_TotalMoney.Properties.Mask.EditMask = "n0";
            this.textEdit_TotalMoney.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_TotalMoney.Size = new System.Drawing.Size(140, 26);
            this.textEdit_TotalMoney.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(627, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 15);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "(vnđ)";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl1.Location = new System.Drawing.Point(350, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(125, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "TỔNG CỘNG:";
            // 
            // gridControl_CTHDN
            // 
            this.gridControl_CTHDN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_CTHDN.Location = new System.Drawing.Point(3, 47);
            this.gridControl_CTHDN.MainView = this.gridView_CTHDN;
            this.gridControl_CTHDN.MenuManager = this.barManager1;
            this.gridControl_CTHDN.Name = "gridControl_CTHDN";
            this.gridControl_CTHDN.Size = new System.Drawing.Size(666, 458);
            this.gridControl_CTHDN.TabIndex = 0;
            this.gridControl_CTHDN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_CTHDN,
            this.gridView2});
            // 
            // gridView_CTHDN
            // 
            this.gridView_CTHDN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_ProductID,
            this.c_ProductName,
            this.c_Quantity,
            this.c_Price,
            this.c_Money});
            this.gridView_CTHDN.GridControl = this.gridControl_CTHDN;
            this.gridView_CTHDN.Name = "gridView_CTHDN";
            this.gridView_CTHDN.OptionsView.ShowGroupPanel = false;
            // 
            // c_ProductID
            // 
            this.c_ProductID.Caption = "Mã sản phẩm";
            this.c_ProductID.FieldName = "ProductID";
            this.c_ProductID.Name = "c_ProductID";
            this.c_ProductID.OptionsColumn.AllowEdit = false;
            this.c_ProductID.OptionsColumn.AllowFocus = false;
            // 
            // c_ProductName
            // 
            this.c_ProductName.Caption = "Mặt hàng";
            this.c_ProductName.FieldName = "ProductName";
            this.c_ProductName.Name = "c_ProductName";
            this.c_ProductName.OptionsColumn.AllowEdit = false;
            this.c_ProductName.OptionsColumn.AllowFocus = false;
            this.c_ProductName.Visible = true;
            this.c_ProductName.VisibleIndex = 0;
            // 
            // c_Quantity
            // 
            this.c_Quantity.Caption = "Số lượng";
            this.c_Quantity.FieldName = "Quantity";
            this.c_Quantity.Name = "c_Quantity";
            this.c_Quantity.OptionsColumn.AllowEdit = false;
            this.c_Quantity.OptionsColumn.AllowFocus = false;
            this.c_Quantity.Visible = true;
            this.c_Quantity.VisibleIndex = 1;
            // 
            // c_Price
            // 
            this.c_Price.Caption = "Đơn giá";
            this.c_Price.FieldName = "Price";
            this.c_Price.Name = "c_Price";
            this.c_Price.OptionsColumn.AllowEdit = false;
            this.c_Price.OptionsColumn.AllowFocus = false;
            this.c_Price.Visible = true;
            this.c_Price.VisibleIndex = 2;
            // 
            // c_Money
            // 
            this.c_Money.Caption = "Thành tiền";
            this.c_Money.FieldName = "Money";
            this.c_Money.Name = "c_Money";
            this.c_Money.OptionsColumn.AllowEdit = false;
            this.c_Money.OptionsColumn.AllowFocus = false;
            this.c_Money.Visible = true;
            this.c_Money.VisibleIndex = 3;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl_CTHDN;
            this.gridView2.Name = "gridView2";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.gridControl_CTHDN, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(462, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.823529F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.17647F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(672, 508);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // frm_NhapHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 532);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "frm_NhapHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Stock";
            this.Load += new System.EventHandler(this.frm_Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_HDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_HDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TotalMoney.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_CTHDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CTHDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Add;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Delete;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Update;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraGrid.GridControl gridControl_CTHDN;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_CTHDN;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn c_Quantity;
        private DevExpress.XtraGrid.Columns.GridColumn c_Price;
        private DevExpress.XtraGrid.Columns.GridColumn c_Money;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit_TotalMoney;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl_HDN;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_HDN;
        private DevExpress.XtraGrid.Columns.GridColumn c_HDNID;
        private DevExpress.XtraGrid.Columns.GridColumn c_Date;
        private DevExpress.XtraGrid.Columns.GridColumn c_TotalMoney;
        private DevExpress.XtraGrid.Columns.GridColumn c_HDCode;
        private DevExpress.XtraGrid.Columns.GridColumn c_Payed;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_UpdateStock;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Exit;
    }
}