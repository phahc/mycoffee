namespace Coffee
{
    partial class frm_Stock
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView_Menu = new System.Windows.Forms.TreeView();
            this.imageList_Menu = new System.Windows.Forms.ImageList(this.components);
            this.btn_All = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_InPut = new DevExpress.XtraGrid.GridControl();
            this.gridView_InPut = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_InputQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_SoPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_OutPut = new DevExpress.XtraGrid.GridControl();
            this.gridView_OutPut = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_DateOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_OutPutQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Stock = new DevExpress.XtraGrid.GridControl();
            this.gridView_Stock = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_DVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_TonKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_InPut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_InPut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_OutPut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OutPut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Stock)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.tableLayoutPanel1);
            this.groupControl1.Controls.Add(this.btn_All);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(239, 554);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Nhóm hàng";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.treeView_Menu, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(235, 506);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // treeView_Menu
            // 
            this.treeView_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Menu.ImageIndex = 0;
            this.treeView_Menu.ImageList = this.imageList_Menu;
            this.treeView_Menu.Location = new System.Drawing.Point(3, 3);
            this.treeView_Menu.Name = "treeView_Menu";
            this.treeView_Menu.SelectedImageIndex = 0;
            this.treeView_Menu.Size = new System.Drawing.Size(229, 500);
            this.treeView_Menu.TabIndex = 0;
            this.treeView_Menu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Menu_NodeMouseClick);
            // 
            // imageList_Menu
            // 
            this.imageList_Menu.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_Menu.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_Menu.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btn_All
            // 
            this.btn_All.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_All.Image = global::Coffee.Properties.Resources.Eye;
            this.btn_All.Location = new System.Drawing.Point(2, 23);
            this.btn_All.Name = "btn_All";
            this.btn_All.Size = new System.Drawing.Size(235, 23);
            this.btn_All.TabIndex = 0;
            this.btn_All.Text = "Tất cả";
            this.btn_All.Click += new System.EventHandler(this.btn_All_Click);
            // 
            // gridControl_InPut
            // 
            this.gridControl_InPut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_InPut.Location = new System.Drawing.Point(2, 23);
            this.gridControl_InPut.MainView = this.gridView_InPut;
            this.gridControl_InPut.Name = "gridControl_InPut";
            this.gridControl_InPut.Size = new System.Drawing.Size(360, 212);
            this.gridControl_InPut.TabIndex = 0;
            this.gridControl_InPut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_InPut});
            // 
            // gridView_InPut
            // 
            this.gridView_InPut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_Date,
            this.c_InputQuantity,
            this.c_SoPhieu});
            this.gridView_InPut.GridControl = this.gridControl_InPut;
            this.gridView_InPut.Name = "gridView_InPut";
            this.gridView_InPut.OptionsView.ShowGroupPanel = false;
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
            // 
            // c_InputQuantity
            // 
            this.c_InputQuantity.Caption = "Số lượng nhập";
            this.c_InputQuantity.FieldName = "InputQuantity";
            this.c_InputQuantity.Name = "c_InputQuantity";
            this.c_InputQuantity.OptionsColumn.AllowEdit = false;
            this.c_InputQuantity.OptionsColumn.AllowFocus = false;
            this.c_InputQuantity.Visible = true;
            this.c_InputQuantity.VisibleIndex = 2;
            // 
            // c_SoPhieu
            // 
            this.c_SoPhieu.Caption = "Số phiếu";
            this.c_SoPhieu.FieldName = "SoPhieu";
            this.c_SoPhieu.Name = "c_SoPhieu";
            this.c_SoPhieu.OptionsColumn.AllowEdit = false;
            this.c_SoPhieu.OptionsColumn.AllowFocus = false;
            this.c_SoPhieu.Visible = true;
            this.c_SoPhieu.VisibleIndex = 1;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.gridControl_InPut);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl3.Location = new System.Drawing.Point(2, 2);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(364, 237);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Nhập kho";
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
            this.barButtonItem_Close});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Close, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem_Close
            // 
            this.barButtonItem_Close.Caption = "Thoát";
            this.barButtonItem_Close.Glyph = global::Coffee.Properties.Resources.Turn_off;
            this.barButtonItem_Close.Id = 1;
            this.barButtonItem_Close.Name = "barButtonItem_Close";
            this.barButtonItem_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Close_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(953, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 578);
            this.barDockControlBottom.Size = new System.Drawing.Size(953, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 554);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(953, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 554);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl4);
            this.panelControl1.Controls.Add(this.groupControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(239, 337);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(714, 241);
            this.panelControl1.TabIndex = 7;
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.Controls.Add(this.gridControl_OutPut);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(366, 2);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(346, 237);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "Xuất kho";
            // 
            // gridControl_OutPut
            // 
            this.gridControl_OutPut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_OutPut.Location = new System.Drawing.Point(2, 23);
            this.gridControl_OutPut.MainView = this.gridView_OutPut;
            this.gridControl_OutPut.Name = "gridControl_OutPut";
            this.gridControl_OutPut.Size = new System.Drawing.Size(342, 212);
            this.gridControl_OutPut.TabIndex = 1;
            this.gridControl_OutPut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_OutPut});
            // 
            // gridView_OutPut
            // 
            this.gridView_OutPut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_DateOut,
            this.c_OutPutQuantity,
            this.gridColumn1});
            this.gridView_OutPut.GridControl = this.gridControl_OutPut;
            this.gridView_OutPut.Name = "gridView_OutPut";
            this.gridView_OutPut.OptionsView.ShowGroupPanel = false;
            // 
            // c_DateOut
            // 
            this.c_DateOut.Caption = "Ngày";
            this.c_DateOut.FieldName = "Date";
            this.c_DateOut.Name = "c_DateOut";
            this.c_DateOut.OptionsColumn.AllowEdit = false;
            this.c_DateOut.OptionsColumn.AllowFocus = false;
            this.c_DateOut.Visible = true;
            this.c_DateOut.VisibleIndex = 0;
            // 
            // c_OutPutQuantity
            // 
            this.c_OutPutQuantity.Caption = "Số lượng xuất";
            this.c_OutPutQuantity.FieldName = "OutPutQuantity";
            this.c_OutPutQuantity.Name = "c_OutPutQuantity";
            this.c_OutPutQuantity.OptionsColumn.AllowEdit = false;
            this.c_OutPutQuantity.OptionsColumn.AllowFocus = false;
            this.c_OutPutQuantity.Visible = true;
            this.c_OutPutQuantity.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số phiếu";
            this.gridColumn1.FieldName = "SoPhieu";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.gridControl_Stock);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(239, 24);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(714, 313);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "Tồn kho";
            // 
            // gridControl_Stock
            // 
            this.gridControl_Stock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Stock.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Stock.MainView = this.gridView_Stock;
            this.gridControl_Stock.Name = "gridControl_Stock";
            this.gridControl_Stock.Size = new System.Drawing.Size(710, 288);
            this.gridControl_Stock.TabIndex = 1;
            this.gridControl_Stock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Stock});
            // 
            // gridView_Stock
            // 
            this.gridView_Stock.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_ProductName,
            this.c_DVT,
            this.c_TonKho,
            this.c_ProductID});
            this.gridView_Stock.GridControl = this.gridControl_Stock;
            this.gridView_Stock.Name = "gridView_Stock";
            this.gridView_Stock.OptionsView.ShowGroupPanel = false;
            this.gridView_Stock.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_Stock_RowClick);
            this.gridView_Stock.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_Stock_RowCellStyle);
            this.gridView_Stock.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView_Stock_FocusedRowChanged);
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
            // c_DVT
            // 
            this.c_DVT.Caption = "Đơn vị tính";
            this.c_DVT.FieldName = "DVT";
            this.c_DVT.Name = "c_DVT";
            this.c_DVT.OptionsColumn.AllowEdit = false;
            this.c_DVT.OptionsColumn.AllowFocus = false;
            this.c_DVT.Visible = true;
            this.c_DVT.VisibleIndex = 1;
            // 
            // c_TonKho
            // 
            this.c_TonKho.Caption = "Số lượng tồn";
            this.c_TonKho.FieldName = "TonKho";
            this.c_TonKho.Name = "c_TonKho";
            this.c_TonKho.OptionsColumn.AllowEdit = false;
            this.c_TonKho.OptionsColumn.AllowFocus = false;
            this.c_TonKho.Visible = true;
            this.c_TonKho.VisibleIndex = 2;
            // 
            // c_ProductID
            // 
            this.c_ProductID.Caption = "Mã hàng";
            this.c_ProductID.FieldName = "ProductID";
            this.c_ProductID.Name = "c_ProductID";
            // 
            // frm_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 578);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "frm_Stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tồn Kho";
            this.Load += new System.EventHandler(this.frm_Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_InPut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_InPut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_OutPut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OutPut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Stock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TreeView treeView_Menu;
        private DevExpress.XtraGrid.GridControl gridControl_InPut;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_InPut;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imageList_Menu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btn_All;
        private DevExpress.XtraGrid.Columns.GridColumn c_Date;
        private DevExpress.XtraGrid.Columns.GridColumn c_InputQuantity;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl_Stock;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Stock;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn c_DVT;
        private DevExpress.XtraGrid.Columns.GridColumn c_TonKho;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl gridControl_OutPut;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_OutPut;
        private DevExpress.XtraGrid.Columns.GridColumn c_DateOut;
        private DevExpress.XtraGrid.Columns.GridColumn c_OutPutQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn c_SoPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}