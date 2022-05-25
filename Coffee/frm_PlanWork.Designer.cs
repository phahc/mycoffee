namespace Coffee
{
    partial class frm_PlanWork
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
            this.gridControl_PlanWork = new DevExpress.XtraGrid.GridControl();
            this.gridView_PlanWork = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_PlanWorkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_PlanWorkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_StartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_EndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Notes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit_Notes = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.c_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Status = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.c_SystemKey = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.bar3 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_PlanWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_PlanWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit_Notes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_PlanWork
            // 
            this.gridControl_PlanWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_PlanWork.Location = new System.Drawing.Point(0, 24);
            this.gridControl_PlanWork.MainView = this.gridView_PlanWork;
            this.gridControl_PlanWork.Name = "gridControl_PlanWork";
            this.gridControl_PlanWork.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit_Notes,
            this.repositoryItemLookUpEdit_Status});
            this.gridControl_PlanWork.ShowOnlyPredefinedDetails = true;
            this.gridControl_PlanWork.Size = new System.Drawing.Size(629, 443);
            this.gridControl_PlanWork.TabIndex = 6;
            this.gridControl_PlanWork.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_PlanWork});
            this.gridControl_PlanWork.DoubleClick += new System.EventHandler(this.gridControl_PlanWork_DoubleClick);
            // 
            // gridView_PlanWork
            // 
            this.gridView_PlanWork.Appearance.FocusedRow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_PlanWork.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_PlanWork.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_PlanWork.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_PlanWork.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_PlanWork.Appearance.Row.Options.UseFont = true;
            this.gridView_PlanWork.Appearance.SelectedRow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_PlanWork.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView_PlanWork.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_PlanWork.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView_PlanWork.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gridView_PlanWork.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_PlanWork.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_PlanWorkID,
            this.c_PlanWorkName,
            this.c_StartTime,
            this.c_EndTime,
            this.c_Notes,
            this.c_Status,
            this.c_SystemKey});
            this.gridView_PlanWork.GridControl = this.gridControl_PlanWork;
            this.gridView_PlanWork.Name = "gridView_PlanWork";
            this.gridView_PlanWork.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_PlanWork.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView_PlanWork.OptionsView.RowAutoHeight = true;
            this.gridView_PlanWork.OptionsView.ShowAutoFilterRow = true;
            this.gridView_PlanWork.OptionsView.ShowGroupPanel = false;
            this.gridView_PlanWork.RowHeight = 22;
            // 
            // c_PlanWorkID
            // 
            this.c_PlanWorkID.Caption = "Mã ca";
            this.c_PlanWorkID.FieldName = "PlanWorkID";
            this.c_PlanWorkID.Name = "c_PlanWorkID";
            this.c_PlanWorkID.OptionsColumn.AllowEdit = false;
            this.c_PlanWorkID.OptionsColumn.AllowFocus = false;
            this.c_PlanWorkID.Visible = true;
            this.c_PlanWorkID.VisibleIndex = 0;
            this.c_PlanWorkID.Width = 120;
            // 
            // c_PlanWorkName
            // 
            this.c_PlanWorkName.Caption = "Tên ca";
            this.c_PlanWorkName.FieldName = "PlanWorkName";
            this.c_PlanWorkName.Name = "c_PlanWorkName";
            this.c_PlanWorkName.OptionsColumn.AllowEdit = false;
            this.c_PlanWorkName.OptionsColumn.AllowFocus = false;
            this.c_PlanWorkName.Visible = true;
            this.c_PlanWorkName.VisibleIndex = 1;
            this.c_PlanWorkName.Width = 306;
            // 
            // c_StartTime
            // 
            this.c_StartTime.Caption = "Ngày bắt đầu";
            this.c_StartTime.FieldName = "StartTime";
            this.c_StartTime.Name = "c_StartTime";
            this.c_StartTime.OptionsColumn.AllowEdit = false;
            this.c_StartTime.OptionsColumn.AllowFocus = false;
            this.c_StartTime.Visible = true;
            this.c_StartTime.VisibleIndex = 2;
            this.c_StartTime.Width = 189;
            // 
            // c_EndTime
            // 
            this.c_EndTime.Caption = "Ngày kết thúc";
            this.c_EndTime.FieldName = "EndTime";
            this.c_EndTime.Name = "c_EndTime";
            this.c_EndTime.OptionsColumn.AllowEdit = false;
            this.c_EndTime.OptionsColumn.AllowFocus = false;
            this.c_EndTime.Visible = true;
            this.c_EndTime.VisibleIndex = 3;
            this.c_EndTime.Width = 191;
            // 
            // c_Notes
            // 
            this.c_Notes.Caption = "Ghi chú";
            this.c_Notes.ColumnEdit = this.repositoryItemMemoEdit_Notes;
            this.c_Notes.FieldName = "Notes";
            this.c_Notes.Name = "c_Notes";
            this.c_Notes.OptionsColumn.AllowEdit = false;
            this.c_Notes.OptionsColumn.AllowFocus = false;
            this.c_Notes.Visible = true;
            this.c_Notes.VisibleIndex = 5;
            this.c_Notes.Width = 189;
            // 
            // repositoryItemMemoEdit_Notes
            // 
            this.repositoryItemMemoEdit_Notes.Name = "repositoryItemMemoEdit_Notes";
            // 
            // c_Status
            // 
            this.c_Status.Caption = "Trạng thái";
            this.c_Status.ColumnEdit = this.repositoryItemLookUpEdit_Status;
            this.c_Status.FieldName = "Status";
            this.c_Status.Name = "c_Status";
            this.c_Status.OptionsColumn.AllowEdit = false;
            this.c_Status.OptionsColumn.AllowFocus = false;
            this.c_Status.Visible = true;
            this.c_Status.VisibleIndex = 4;
            this.c_Status.Width = 185;
            // 
            // repositoryItemLookUpEdit_Status
            // 
            this.repositoryItemLookUpEdit_Status.AutoHeight = false;
            this.repositoryItemLookUpEdit_Status.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Status.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusName", "Trạng thái"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusID", "Mã trạng thái", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.repositoryItemLookUpEdit_Status.Name = "repositoryItemLookUpEdit_Status";
            // 
            // c_SystemKey
            // 
            this.c_SystemKey.Caption = "Hệ thống";
            this.c_SystemKey.FieldName = "SystemKey";
            this.c_SystemKey.Name = "c_SystemKey";
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
            this.barManager1.MaxItemId = 8;
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
            this.barButtonItem_Add.Id = 4;
            this.barButtonItem_Add.Name = "barButtonItem_Add";
            this.barButtonItem_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Add_ItemClick);
            // 
            // barButtonItem_Update
            // 
            this.barButtonItem_Update.Caption = "Sửa";
            this.barButtonItem_Update.Glyph = global::Coffee.Properties.Resources.Update;
            this.barButtonItem_Update.Id = 5;
            this.barButtonItem_Update.Name = "barButtonItem_Update";
            this.barButtonItem_Update.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Update_ItemClick);
            // 
            // barButtonItem_Delete
            // 
            this.barButtonItem_Delete.Caption = "Xoá";
            this.barButtonItem_Delete.Glyph = global::Coffee.Properties.Resources.delete_products;
            this.barButtonItem_Delete.Id = 6;
            this.barButtonItem_Delete.Name = "barButtonItem_Delete";
            this.barButtonItem_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Delete_ItemClick);
            // 
            // barButtonItem_Close
            // 
            this.barButtonItem_Close.Caption = "Thoát";
            this.barButtonItem_Close.Glyph = global::Coffee.Properties.Resources.Turn_off;
            this.barButtonItem_Close.Id = 7;
            this.barButtonItem_Close.Name = "barButtonItem_Close";
            this.barButtonItem_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Close_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(629, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 467);
            this.barDockControlBottom.Size = new System.Drawing.Size(629, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 443);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(629, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 443);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // frm_PlanWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 467);
            this.Controls.Add(this.gridControl_PlanWork);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "frm_PlanWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ca Làm Việc";
            this.Load += new System.EventHandler(this.frm_PlanWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_PlanWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_PlanWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit_Notes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_PlanWork;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_PlanWork;
        private DevExpress.XtraGrid.Columns.GridColumn c_PlanWorkID;
        private DevExpress.XtraGrid.Columns.GridColumn c_PlanWorkName;
        private DevExpress.XtraGrid.Columns.GridColumn c_StartTime;
        private DevExpress.XtraGrid.Columns.GridColumn c_EndTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Status;
        private DevExpress.XtraGrid.Columns.GridColumn c_Notes;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit_Notes;
        private DevExpress.XtraGrid.Columns.GridColumn c_Status;
        private DevExpress.XtraGrid.Columns.GridColumn c_SystemKey;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Add;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Update;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Delete;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
    }
}