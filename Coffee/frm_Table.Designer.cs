namespace Coffee
{
    partial class frm_Table
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
            this.barButtonItem_Update = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemLookUpEdit_Status = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView_AreaTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_TableID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_AreaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_TableCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_AreaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_AreaTable = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_AreaTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_AreaTable)).BeginInit();
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
            this.barDockControlTop.Size = new System.Drawing.Size(588, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 434);
            this.barDockControlBottom.Size = new System.Drawing.Size(588, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 410);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(588, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 410);
            // 
            // repositoryItemLookUpEdit_Status
            // 
            this.repositoryItemLookUpEdit_Status.AutoHeight = false;
            this.repositoryItemLookUpEdit_Status.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Status.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusID", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusName", "Tình trạng")});
            this.repositoryItemLookUpEdit_Status.Name = "repositoryItemLookUpEdit_Status";
            // 
            // gridView_AreaTable
            // 
            this.gridView_AreaTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_TableID,
            this.c_AreaID,
            this.c_TableCode,
            this.c_AreaCode,
            this.c_Status});
            this.gridView_AreaTable.GridControl = this.gridControl_AreaTable;
            this.gridView_AreaTable.Name = "gridView_AreaTable";
            this.gridView_AreaTable.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_AreaTable.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView_AreaTable.OptionsView.ShowAutoFilterRow = true;
            this.gridView_AreaTable.OptionsView.ShowGroupPanel = false;
            this.gridView_AreaTable.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_AreaTable_RowCellStyle);
            // 
            // c_TableID
            // 
            this.c_TableID.Caption = "Mã bàn";
            this.c_TableID.FieldName = "TableID";
            this.c_TableID.Name = "c_TableID";
            this.c_TableID.OptionsColumn.AllowEdit = false;
            this.c_TableID.OptionsColumn.AllowFocus = false;
            this.c_TableID.Visible = true;
            this.c_TableID.VisibleIndex = 0;
            this.c_TableID.Width = 118;
            // 
            // c_AreaID
            // 
            this.c_AreaID.Caption = "Mã khu vực";
            this.c_AreaID.FieldName = "AreaID";
            this.c_AreaID.Name = "c_AreaID";
            this.c_AreaID.OptionsColumn.AllowEdit = false;
            this.c_AreaID.OptionsColumn.AllowFocus = false;
            this.c_AreaID.Width = 242;
            // 
            // c_TableCode
            // 
            this.c_TableCode.Caption = "Tên bàn";
            this.c_TableCode.FieldName = "TableCode";
            this.c_TableCode.Name = "c_TableCode";
            this.c_TableCode.OptionsColumn.AllowEdit = false;
            this.c_TableCode.OptionsColumn.AllowFocus = false;
            this.c_TableCode.Visible = true;
            this.c_TableCode.VisibleIndex = 1;
            this.c_TableCode.Width = 580;
            // 
            // c_AreaCode
            // 
            this.c_AreaCode.Caption = "Tên khu vực";
            this.c_AreaCode.FieldName = "AreaCode";
            this.c_AreaCode.Name = "c_AreaCode";
            this.c_AreaCode.OptionsColumn.AllowEdit = false;
            this.c_AreaCode.OptionsColumn.AllowFocus = false;
            this.c_AreaCode.Visible = true;
            this.c_AreaCode.VisibleIndex = 2;
            this.c_AreaCode.Width = 185;
            // 
            // c_Status
            // 
            this.c_Status.Caption = "Tình trạng";
            this.c_Status.ColumnEdit = this.repositoryItemLookUpEdit_Status;
            this.c_Status.FieldName = "Status";
            this.c_Status.Name = "c_Status";
            this.c_Status.OptionsColumn.AllowEdit = false;
            this.c_Status.OptionsColumn.AllowFocus = false;
            this.c_Status.Visible = true;
            this.c_Status.VisibleIndex = 3;
            this.c_Status.Width = 297;
            // 
            // gridControl_AreaTable
            // 
            this.gridControl_AreaTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_AreaTable.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl_AreaTable.Location = new System.Drawing.Point(0, 24);
            this.gridControl_AreaTable.MainView = this.gridView_AreaTable;
            this.gridControl_AreaTable.Name = "gridControl_AreaTable";
            this.gridControl_AreaTable.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Status});
            this.gridControl_AreaTable.ShowOnlyPredefinedDetails = true;
            this.gridControl_AreaTable.Size = new System.Drawing.Size(588, 410);
            this.gridControl_AreaTable.TabIndex = 3;
            this.gridControl_AreaTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_AreaTable});
            // 
            // frm_Table
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 434);
            this.Controls.Add(this.gridControl_AreaTable);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "frm_Table";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Table";
            this.Load += new System.EventHandler(this.frm_Table_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_AreaTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_AreaTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
        private DevExpress.XtraGrid.GridControl gridControl_AreaTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_AreaTable;
        private DevExpress.XtraGrid.Columns.GridColumn c_TableID;
        private DevExpress.XtraGrid.Columns.GridColumn c_AreaID;
        private DevExpress.XtraGrid.Columns.GridColumn c_TableCode;
        private DevExpress.XtraGrid.Columns.GridColumn c_AreaCode;
        private DevExpress.XtraGrid.Columns.GridColumn c_Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Status;
    }
}