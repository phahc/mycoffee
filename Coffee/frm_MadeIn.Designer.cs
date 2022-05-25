namespace Coffee
{
    partial class frm_MadeIn
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
            this.gridControl_MadeIn = new DevExpress.XtraGrid.GridControl();
            this.gridView_MadeIn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_MadeInID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_MadeInName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_SystemKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_MadeIn = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
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
            this.repositoryItemLookUpEdit_MadeIn2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_MadeIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_MadeIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_MadeIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_MadeIn2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_MadeIn
            // 
            this.gridControl_MadeIn.Location = new System.Drawing.Point(-2, 28);
            this.gridControl_MadeIn.MainView = this.gridView_MadeIn;
            this.gridControl_MadeIn.Name = "gridControl_MadeIn";
            this.gridControl_MadeIn.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_MadeIn,
            this.repositoryItemLookUpEdit_MadeIn2});
            this.gridControl_MadeIn.Size = new System.Drawing.Size(450, 368);
            this.gridControl_MadeIn.TabIndex = 0;
            this.gridControl_MadeIn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_MadeIn});
            // 
            // gridView_MadeIn
            // 
            this.gridView_MadeIn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_MadeInID,
            this.c_MadeInName,
            this.c_Status,
            this.c_SystemKey});
            this.gridView_MadeIn.GridControl = this.gridControl_MadeIn;
            this.gridView_MadeIn.Name = "gridView_MadeIn";
            this.gridView_MadeIn.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_MadeIn.OptionsView.ShowGroupPanel = false;
            // 
            // c_MadeInID
            // 
            this.c_MadeInID.Caption = "Mã";
            this.c_MadeInID.FieldName = "MadeInID";
            this.c_MadeInID.Name = "c_MadeInID";
            this.c_MadeInID.OptionsColumn.AllowEdit = false;
            this.c_MadeInID.OptionsColumn.AllowFocus = false;
            this.c_MadeInID.Visible = true;
            this.c_MadeInID.VisibleIndex = 0;
            this.c_MadeInID.Width = 158;
            // 
            // c_MadeInName
            // 
            this.c_MadeInName.Caption = "Nhà cung cấp";
            this.c_MadeInName.FieldName = "MadeInName";
            this.c_MadeInName.Name = "c_MadeInName";
            this.c_MadeInName.OptionsColumn.AllowEdit = false;
            this.c_MadeInName.OptionsColumn.AllowFocus = false;
            this.c_MadeInName.Visible = true;
            this.c_MadeInName.VisibleIndex = 1;
            this.c_MadeInName.Width = 723;
            // 
            // c_Status
            // 
            this.c_Status.Caption = "Trạng thái";
            this.c_Status.ColumnEdit = this.repositoryItemLookUpEdit_MadeIn2;
            this.c_Status.FieldName = "Status";
            this.c_Status.Name = "c_Status";
            this.c_Status.OptionsColumn.AllowEdit = false;
            this.c_Status.OptionsColumn.AllowFocus = false;
            this.c_Status.Visible = true;
            this.c_Status.VisibleIndex = 2;
            this.c_Status.Width = 299;
            // 
            // c_SystemKey
            // 
            this.c_SystemKey.Caption = "Hệ thống";
            this.c_SystemKey.FieldName = "SystemKey";
            this.c_SystemKey.Name = "c_SystemKey";
            this.c_SystemKey.OptionsColumn.AllowEdit = false;
            this.c_SystemKey.OptionsColumn.AllowFocus = false;
            // 
            // repositoryItemLookUpEdit_MadeIn
            // 
            this.repositoryItemLookUpEdit_MadeIn.AutoHeight = false;
            this.repositoryItemLookUpEdit_MadeIn.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_MadeIn.Name = "repositoryItemLookUpEdit_MadeIn";
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
            this.barDockControlTop.Size = new System.Drawing.Size(448, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 395);
            this.barDockControlBottom.Size = new System.Drawing.Size(448, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 371);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(448, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 371);
            // 
            // repositoryItemLookUpEdit_MadeIn2
            // 
            this.repositoryItemLookUpEdit_MadeIn2.AutoHeight = false;
            this.repositoryItemLookUpEdit_MadeIn2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_MadeIn2.Name = "repositoryItemLookUpEdit_MadeIn2";
            // 
            // frm_MadeIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 395);
            this.Controls.Add(this.gridControl_MadeIn);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "frm_MadeIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_MadeIn";
            this.Load += new System.EventHandler(this.frm_MadeIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_MadeIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_MadeIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_MadeIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_MadeIn2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_MadeIn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_MadeIn;
        private DevExpress.XtraGrid.Columns.GridColumn c_MadeInID;
        private DevExpress.XtraGrid.Columns.GridColumn c_MadeInName;
        private DevExpress.XtraGrid.Columns.GridColumn c_Status;
        private DevExpress.XtraGrid.Columns.GridColumn c_SystemKey;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_MadeIn;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_MadeIn2;
    }
}