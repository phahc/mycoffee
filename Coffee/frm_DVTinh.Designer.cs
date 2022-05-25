namespace Coffee
{
    partial class frm_DVTinh
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
            this.barButtonItem_Edit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Exit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem_Update = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.gridControl_DVT = new DevExpress.XtraGrid.GridControl();
            this.gridView_DVT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMADVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDONVITINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ImageIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Image = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList_DVT = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DVT)).BeginInit();
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
            this.barButtonItem_Close,
            this.barButtonItem_Edit,
            this.barButtonItem_Exit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Add, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Edit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Exit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            // barButtonItem_Edit
            // 
            this.barButtonItem_Edit.Caption = "Sửa";
            this.barButtonItem_Edit.Glyph = global::Coffee.Properties.Resources.Update;
            this.barButtonItem_Edit.Id = 5;
            this.barButtonItem_Edit.Name = "barButtonItem_Edit";
            this.barButtonItem_Edit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Edit_ItemClick);
            // 
            // barButtonItem_Exit
            // 
            this.barButtonItem_Exit.Caption = "Thoát";
            this.barButtonItem_Exit.Glyph = global::Coffee.Properties.Resources.Turn_off;
            this.barButtonItem_Exit.Id = 6;
            this.barButtonItem_Exit.Name = "barButtonItem_Exit";
            this.barButtonItem_Exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Exit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(393, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 360);
            this.barDockControlBottom.Size = new System.Drawing.Size(393, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 336);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(393, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 336);
            // 
            // barButtonItem_Update
            // 
            this.barButtonItem_Update.Caption = "Sửa";
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
            // gridControl_DVT
            // 
            this.gridControl_DVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DVT.Location = new System.Drawing.Point(0, 24);
            this.gridControl_DVT.MainView = this.gridView_DVT;
            this.gridControl_DVT.Name = "gridControl_DVT";
            this.gridControl_DVT.Size = new System.Drawing.Size(393, 336);
            this.gridControl_DVT.TabIndex = 4;
            this.gridControl_DVT.UseEmbeddedNavigator = true;
            this.gridControl_DVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DVT});
            this.gridControl_DVT.DoubleClick += new System.EventHandler(this.gridControl_DVT_DoubleClick);
            // 
            // gridView_DVT
            // 
            this.gridView_DVT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMADVT,
            this.colDONVITINH,
            this.c_ImageIndex,
            this.c_Image});
            this.gridView_DVT.GridControl = this.gridControl_DVT;
            this.gridView_DVT.Name = "gridView_DVT";
            this.gridView_DVT.OptionsBehavior.Editable = false;
            this.gridView_DVT.OptionsSelection.MultiSelect = true;
            this.gridView_DVT.OptionsView.ShowAutoFilterRow = true;
            this.gridView_DVT.OptionsView.ShowGroupPanel = false;
            // 
            // colMADVT
            // 
            this.colMADVT.Caption = "Mã ĐVT";
            this.colMADVT.FieldName = "DVTID";
            this.colMADVT.Name = "colMADVT";
            this.colMADVT.OptionsColumn.AllowEdit = false;
            this.colMADVT.OptionsColumn.ReadOnly = true;
            this.colMADVT.Width = 93;
            // 
            // colDONVITINH
            // 
            this.colDONVITINH.Caption = "Đơn Vị Tính";
            this.colDONVITINH.FieldName = "DVTName";
            this.colDONVITINH.Name = "colDONVITINH";
            this.colDONVITINH.OptionsColumn.AllowEdit = false;
            this.colDONVITINH.OptionsColumn.AllowFocus = false;
            this.colDONVITINH.Visible = true;
            this.colDONVITINH.VisibleIndex = 0;
            this.colDONVITINH.Width = 321;
            // 
            // c_ImageIndex
            // 
            this.c_ImageIndex.Caption = "Biểu tượng";
            this.c_ImageIndex.FieldName = "ImageIndex";
            this.c_ImageIndex.Name = "c_ImageIndex";
            this.c_ImageIndex.OptionsColumn.AllowEdit = false;
            this.c_ImageIndex.OptionsColumn.AllowFocus = false;
            this.c_ImageIndex.Width = 145;
            // 
            // c_Image
            // 
            this.c_Image.Caption = "Biểu tượng";
            this.c_Image.FieldName = "Image";
            this.c_Image.Name = "c_Image";
            this.c_Image.OptionsColumn.AllowEdit = false;
            this.c_Image.OptionsColumn.AllowFocus = false;
            this.c_Image.Visible = true;
            this.c_Image.VisibleIndex = 1;
            this.c_Image.Width = 154;
            // 
            // imageList_DVT
            // 
            this.imageList_DVT.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_DVT.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_DVT.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frm_DVTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 360);
            this.Controls.Add(this.gridControl_DVT);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "frm_DVTinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_DVTinh";
            this.Load += new System.EventHandler(this.frm_DVTinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DVT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl_DVT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DVT;
        private DevExpress.XtraGrid.Columns.GridColumn colMADVT;
        private DevExpress.XtraGrid.Columns.GridColumn colDONVITINH;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Add;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Update;
        private DevExpress.XtraGrid.Columns.GridColumn c_ImageIndex;
        private DevExpress.XtraGrid.Columns.GridColumn c_Image;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
        private System.Windows.Forms.ImageList imageList_DVT;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Edit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Exit;
    }
}