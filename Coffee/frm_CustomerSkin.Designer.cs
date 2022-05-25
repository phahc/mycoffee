namespace Coffee
{
    partial class frm_CustomerSkin
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
            this.gridControl_SmartLink = new DevExpress.XtraGrid.GridControl();
            this.gridView_SmartLink = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_SmartLinkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_SmartLinkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_MoneyLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Percent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem_Add = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Update = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemLookUpEdit_Customer = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_SmartLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SmartLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Customer)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_SmartLink
            // 
            this.gridControl_SmartLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_SmartLink.Location = new System.Drawing.Point(0, 24);
            this.gridControl_SmartLink.MainView = this.gridView_SmartLink;
            this.gridControl_SmartLink.Name = "gridControl_SmartLink";
            this.gridControl_SmartLink.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Customer});
            this.gridControl_SmartLink.Size = new System.Drawing.Size(559, 330);
            this.gridControl_SmartLink.TabIndex = 1;
            this.gridControl_SmartLink.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_SmartLink});
            // 
            // gridView_SmartLink
            // 
            this.gridView_SmartLink.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_SmartLinkID,
            this.c_SmartLinkName,
            this.c_MoneyLevel,
            this.c_Percent,
            this.c_Status});
            this.gridView_SmartLink.GridControl = this.gridControl_SmartLink;
            this.gridView_SmartLink.Name = "gridView_SmartLink";
            this.gridView_SmartLink.OptionsView.ShowGroupPanel = false;
            // 
            // c_SmartLinkID
            // 
            this.c_SmartLinkID.Caption = "Mã";
            this.c_SmartLinkID.FieldName = "SmartLinkID";
            this.c_SmartLinkID.Name = "c_SmartLinkID";
            this.c_SmartLinkID.OptionsColumn.AllowEdit = false;
            this.c_SmartLinkID.OptionsColumn.AllowFocus = false;
            // 
            // c_SmartLinkName
            // 
            this.c_SmartLinkName.Caption = "Cấp bậc";
            this.c_SmartLinkName.FieldName = "SmartLinkName";
            this.c_SmartLinkName.Name = "c_SmartLinkName";
            this.c_SmartLinkName.OptionsColumn.AllowEdit = false;
            this.c_SmartLinkName.OptionsColumn.AllowFocus = false;
            this.c_SmartLinkName.Visible = true;
            this.c_SmartLinkName.VisibleIndex = 0;
            this.c_SmartLinkName.Width = 143;
            // 
            // c_MoneyLevel
            // 
            this.c_MoneyLevel.Caption = "Mức tiền";
            this.c_MoneyLevel.FieldName = "MoneyLevel";
            this.c_MoneyLevel.Name = "c_MoneyLevel";
            this.c_MoneyLevel.OptionsColumn.AllowEdit = false;
            this.c_MoneyLevel.OptionsColumn.AllowFocus = false;
            this.c_MoneyLevel.Visible = true;
            this.c_MoneyLevel.VisibleIndex = 1;
            this.c_MoneyLevel.Width = 160;
            // 
            // c_Percent
            // 
            this.c_Percent.Caption = "Phần trăm chiết khấu";
            this.c_Percent.FieldName = "Percent";
            this.c_Percent.Name = "c_Percent";
            this.c_Percent.OptionsColumn.AllowEdit = false;
            this.c_Percent.OptionsColumn.AllowFocus = false;
            this.c_Percent.Visible = true;
            this.c_Percent.VisibleIndex = 2;
            this.c_Percent.Width = 134;
            // 
            // c_Status
            // 
            this.c_Status.Caption = "Tình trạng";
            this.c_Status.ColumnEdit = this.repositoryItemLookUpEdit_Customer;
            this.c_Status.FieldName = "Status";
            this.c_Status.Name = "c_Status";
            this.c_Status.OptionsColumn.AllowEdit = false;
            this.c_Status.OptionsColumn.AllowFocus = false;
            this.c_Status.Visible = true;
            this.c_Status.VisibleIndex = 3;
            this.c_Status.Width = 104;
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
            this.barButtonItem_Update,
            this.barButtonItem_Delete,
            this.barButtonItem_Close});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Add, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Update, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Delete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Close, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem_Add
            // 
            this.barButtonItem_Add.Caption = "Thêm";
            this.barButtonItem_Add.Glyph = global::Coffee.Properties.Resources.add_products;
            this.barButtonItem_Add.Id = 0;
            this.barButtonItem_Add.Name = "barButtonItem_Add";
            this.barButtonItem_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Add_ItemClick);
            // 
            // barButtonItem_Update
            // 
            this.barButtonItem_Update.Caption = "Sửa";
            this.barButtonItem_Update.Glyph = global::Coffee.Properties.Resources.Update;
            this.barButtonItem_Update.Id = 1;
            this.barButtonItem_Update.Name = "barButtonItem_Update";
            this.barButtonItem_Update.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Update_ItemClick);
            // 
            // barButtonItem_Delete
            // 
            this.barButtonItem_Delete.Caption = "Xoá";
            this.barButtonItem_Delete.Glyph = global::Coffee.Properties.Resources.delete_products;
            this.barButtonItem_Delete.Id = 2;
            this.barButtonItem_Delete.Name = "barButtonItem_Delete";
            this.barButtonItem_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Delete_ItemClick);
            // 
            // barButtonItem_Close
            // 
            this.barButtonItem_Close.Caption = "Thoát";
            this.barButtonItem_Close.Glyph = global::Coffee.Properties.Resources.Turn_off;
            this.barButtonItem_Close.Id = 3;
            this.barButtonItem_Close.Name = "barButtonItem_Close";
            this.barButtonItem_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Close_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(559, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 354);
            this.barDockControlBottom.Size = new System.Drawing.Size(559, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 330);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(559, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 330);
            // 
            // repositoryItemLookUpEdit_Customer
            // 
            this.repositoryItemLookUpEdit_Customer.AutoHeight = false;
            this.repositoryItemLookUpEdit_Customer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Customer.Name = "repositoryItemLookUpEdit_Customer";
            // 
            // frm_CustomerSkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 354);
            this.Controls.Add(this.gridControl_SmartLink);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "frm_CustomerSkin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_CustomerSkin";
            this.Load += new System.EventHandler(this.frm_CustomerSkin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_SmartLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SmartLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Customer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_SmartLink;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_SmartLink;
        private DevExpress.XtraGrid.Columns.GridColumn c_SmartLinkID;
        private DevExpress.XtraGrid.Columns.GridColumn c_SmartLinkName;
        private DevExpress.XtraGrid.Columns.GridColumn c_MoneyLevel;
        private DevExpress.XtraGrid.Columns.GridColumn c_Percent;
        private DevExpress.XtraGrid.Columns.GridColumn c_Status;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Add;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Update;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Delete;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Customer;

    }
}