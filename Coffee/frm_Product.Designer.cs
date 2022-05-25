namespace Coffee
{
    partial class frm_Product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Product));
            this.button_Add = new DevExpress.XtraEditors.SimpleButton();
            this.button_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.button_Update = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.imageList_Product = new System.Windows.Forms.ImageList(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView_Menu = new System.Windows.Forms.TreeView();
            this.btn_All = new DevExpress.XtraEditors.SimpleButton();
            this.popupMenu_Menu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem_Add = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Edit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Del = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl_Product = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Product = new DevExpress.XtraGrid.GridControl();
            this.gridView_Product = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Status = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.c_Notes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit_Notes = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.c_MadeInID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_MadeInName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductSkin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Skin = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.c_ImageIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Image = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_InputPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Limit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_DVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_DVT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.c_ExChangeQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ExChangeDVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.C_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox_DVT = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu_Menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Product)).BeginInit();
            this.groupControl_Product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit_Notes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Skin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_DVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox_DVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Add
            // 
            this.button_Add.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.Appearance.Options.UseFont = true;
            this.button_Add.Image = ((System.Drawing.Image)(resources.GetObject("button_Add.Image")));
            this.button_Add.Location = new System.Drawing.Point(256, 2);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 29);
            this.button_Add.TabIndex = 6;
            this.button_Add.Text = "Thêm";
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Delete.Appearance.Options.UseFont = true;
            this.button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("button_Delete.Image")));
            this.button_Delete.Location = new System.Drawing.Point(418, 2);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 29);
            this.button_Delete.TabIndex = 8;
            this.button_Delete.Text = "Xóa";
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Update
            // 
            this.button_Update.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Update.Appearance.Options.UseFont = true;
            this.button_Update.Image = ((System.Drawing.Image)(resources.GetObject("button_Update.Image")));
            this.button_Update.Location = new System.Drawing.Point(337, 2);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(75, 29);
            this.button_Update.TabIndex = 7;
            this.button_Update.Text = "Sửa";
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = ((System.Drawing.Image)(resources.GetObject("button_Close.Image")));
            this.button_Close.Location = new System.Drawing.Point(772, 2);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 29);
            this.button_Close.TabIndex = 9;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // imageList_Product
            // 
            this.imageList_Product.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList_Product.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_Product.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.tableLayoutPanel1);
            this.groupControl1.Controls.Add(this.btn_All);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(200, 558);
            this.groupControl1.TabIndex = 3;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(196, 510);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // treeView_Menu
            // 
            this.treeView_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Menu.ImageIndex = 0;
            this.treeView_Menu.ImageList = this.imageList_Product;
            this.treeView_Menu.Location = new System.Drawing.Point(3, 3);
            this.treeView_Menu.Name = "treeView_Menu";
            this.treeView_Menu.SelectedImageIndex = 0;
            this.treeView_Menu.Size = new System.Drawing.Size(190, 504);
            this.treeView_Menu.StateImageList = this.imageList_Product;
            this.treeView_Menu.TabIndex = 0;
            this.treeView_Menu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Menu_NodeMouseClick);
            this.treeView_Menu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView_Menu_MouseUp);
            // 
            // btn_All
            // 
            this.btn_All.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_All.Image = global::Coffee.Properties.Resources.Eye;
            this.btn_All.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btn_All.Location = new System.Drawing.Point(2, 23);
            this.btn_All.Name = "btn_All";
            this.btn_All.Size = new System.Drawing.Size(196, 23);
            this.btn_All.TabIndex = 1;
            this.btn_All.Text = "Tất cả";
            this.btn_All.Click += new System.EventHandler(this.btn_All_Click);
            // 
            // popupMenu_Menu
            // 
            this.popupMenu_Menu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Add),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Edit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Del)});
            this.popupMenu_Menu.Manager = this.barManager1;
            this.popupMenu_Menu.Name = "popupMenu_Menu";
            // 
            // barButtonItem_Add
            // 
            this.barButtonItem_Add.Caption = "Thêm thực đơn";
            this.barButtonItem_Add.Glyph = global::Coffee.Properties.Resources.add_products;
            this.barButtonItem_Add.Id = 0;
            this.barButtonItem_Add.Name = "barButtonItem_Add";
            this.barButtonItem_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Add_ItemClick);
            // 
            // barButtonItem_Edit
            // 
            this.barButtonItem_Edit.Caption = "Sửa";
            this.barButtonItem_Edit.Glyph = global::Coffee.Properties.Resources.Update;
            this.barButtonItem_Edit.Id = 1;
            this.barButtonItem_Edit.Name = "barButtonItem_Edit";
            this.barButtonItem_Edit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Edit_ItemClick);
            // 
            // barButtonItem_Del
            // 
            this.barButtonItem_Del.Caption = "Xoá";
            this.barButtonItem_Del.Glyph = global::Coffee.Properties.Resources.delete_products;
            this.barButtonItem_Del.Id = 2;
            this.barButtonItem_Del.Name = "barButtonItem_Del";
            this.barButtonItem_Del.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Del_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem_Add,
            this.barButtonItem_Edit,
            this.barButtonItem_Del});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1059, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 558);
            this.barDockControlBottom.Size = new System.Drawing.Size(1059, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 558);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1059, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 558);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button_Update);
            this.panelControl1.Controls.Add(this.button_Delete);
            this.panelControl1.Controls.Add(this.button_Close);
            this.panelControl1.Controls.Add(this.button_Add);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(200, 523);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(859, 35);
            this.panelControl1.TabIndex = 14;
            // 
            // groupControl_Product
            // 
            this.groupControl_Product.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Product.AppearanceCaption.Options.UseFont = true;
            this.groupControl_Product.Controls.Add(this.gridControl_Product);
            this.groupControl_Product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_Product.Location = new System.Drawing.Point(200, 0);
            this.groupControl_Product.Name = "groupControl_Product";
            this.groupControl_Product.Size = new System.Drawing.Size(859, 523);
            this.groupControl_Product.TabIndex = 15;
            this.groupControl_Product.Text = "Danh Sách Sản Phẩm";
            // 
            // gridControl_Product
            // 
            this.gridControl_Product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Product.Location = new System.Drawing.Point(2, 23);
            this.gridControl_Product.MainView = this.gridView_Product;
            this.gridControl_Product.Name = "gridControl_Product";
            this.gridControl_Product.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit_Notes,
            this.repositoryItemLookUpEdit_Status,
            this.repositoryItemLookUpEdit_Skin,
            this.repositoryItemImageComboBox_DVT,
            this.repositoryItemLookUpEdit_DVT});
            this.gridControl_Product.ShowOnlyPredefinedDetails = true;
            this.gridControl_Product.Size = new System.Drawing.Size(855, 498);
            this.gridControl_Product.TabIndex = 7;
            this.gridControl_Product.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Product});
            this.gridControl_Product.DoubleClick += new System.EventHandler(this.gridControl_Product_DoubleClick);
            // 
            // gridView_Product
            // 
            this.gridView_Product.Appearance.FocusedRow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Product.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Product.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Product.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_Product.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Product.Appearance.Row.Options.UseFont = true;
            this.gridView_Product.Appearance.SelectedRow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Product.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView_Product.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Product.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView_Product.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gridView_Product.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_Product.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_ProductID,
            this.c_ProductName,
            this.c_ProductCode,
            this.c_Price,
            this.c_Status,
            this.c_Notes,
            this.c_MadeInID,
            this.c_MadeInName,
            this.c_ProductSkin,
            this.c_ImageIndex,
            this.c_Image,
            this.c_InputPrice,
            this.c_Limit,
            this.c_DVT,
            this.c_ExChangeQuantity,
            this.c_ExChangeDVT,
            this.C_Type});
            this.gridView_Product.GridControl = this.gridControl_Product;
            this.gridView_Product.Name = "gridView_Product";
            this.gridView_Product.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_Product.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView_Product.OptionsView.ShowAutoFilterRow = true;
            this.gridView_Product.OptionsView.ShowGroupPanel = false;
            this.gridView_Product.RowHeight = 22;
            // 
            // c_ProductID
            // 
            this.c_ProductID.Caption = "Mã sản phẩm";
            this.c_ProductID.FieldName = "ProductID";
            this.c_ProductID.Name = "c_ProductID";
            this.c_ProductID.OptionsColumn.AllowEdit = false;
            this.c_ProductID.OptionsColumn.AllowFocus = false;
            this.c_ProductID.Width = 69;
            // 
            // c_ProductName
            // 
            this.c_ProductName.Caption = "Tên sản phẩm";
            this.c_ProductName.FieldName = "ProductName";
            this.c_ProductName.Name = "c_ProductName";
            this.c_ProductName.OptionsColumn.AllowEdit = false;
            this.c_ProductName.OptionsColumn.AllowFocus = false;
            this.c_ProductName.Visible = true;
            this.c_ProductName.VisibleIndex = 2;
            this.c_ProductName.Width = 276;
            // 
            // c_ProductCode
            // 
            this.c_ProductCode.Caption = "Mã SP";
            this.c_ProductCode.FieldName = "ProductCode";
            this.c_ProductCode.Name = "c_ProductCode";
            this.c_ProductCode.OptionsColumn.AllowEdit = false;
            this.c_ProductCode.OptionsColumn.AllowFocus = false;
            this.c_ProductCode.Visible = true;
            this.c_ProductCode.VisibleIndex = 0;
            this.c_ProductCode.Width = 85;
            // 
            // c_Price
            // 
            this.c_Price.Caption = "Giá bán";
            this.c_Price.FieldName = "Price";
            this.c_Price.Name = "c_Price";
            this.c_Price.OptionsColumn.AllowEdit = false;
            this.c_Price.OptionsColumn.AllowFocus = false;
            this.c_Price.Visible = true;
            this.c_Price.VisibleIndex = 5;
            this.c_Price.Width = 146;
            // 
            // c_Status
            // 
            this.c_Status.Caption = "Trạng thái";
            this.c_Status.ColumnEdit = this.repositoryItemLookUpEdit_Status;
            this.c_Status.FieldName = "Status";
            this.c_Status.Name = "c_Status";
            this.c_Status.OptionsColumn.AllowEdit = false;
            this.c_Status.OptionsColumn.AllowFocus = false;
            this.c_Status.Width = 66;
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
            // c_Notes
            // 
            this.c_Notes.Caption = "Ghi chú";
            this.c_Notes.ColumnEdit = this.repositoryItemMemoEdit_Notes;
            this.c_Notes.FieldName = "Notes";
            this.c_Notes.Name = "c_Notes";
            this.c_Notes.OptionsColumn.AllowEdit = false;
            this.c_Notes.OptionsColumn.AllowFocus = false;
            this.c_Notes.Width = 103;
            // 
            // repositoryItemMemoEdit_Notes
            // 
            this.repositoryItemMemoEdit_Notes.Name = "repositoryItemMemoEdit_Notes";
            // 
            // c_MadeInID
            // 
            this.c_MadeInID.Caption = "Xuất xứ";
            this.c_MadeInID.FieldName = "MadeInID";
            this.c_MadeInID.Name = "c_MadeInID";
            this.c_MadeInID.OptionsColumn.AllowEdit = false;
            this.c_MadeInID.OptionsColumn.AllowFocus = false;
            // 
            // c_MadeInName
            // 
            this.c_MadeInName.Caption = "Nhà cung cấp";
            this.c_MadeInName.FieldName = "MadeInName";
            this.c_MadeInName.Name = "c_MadeInName";
            this.c_MadeInName.OptionsColumn.AllowEdit = false;
            this.c_MadeInName.OptionsColumn.AllowFocus = false;
            this.c_MadeInName.Width = 153;
            // 
            // c_ProductSkin
            // 
            this.c_ProductSkin.Caption = "Nhóm hàng";
            this.c_ProductSkin.ColumnEdit = this.repositoryItemLookUpEdit_Skin;
            this.c_ProductSkin.FieldName = "ProductSkin";
            this.c_ProductSkin.Name = "c_ProductSkin";
            this.c_ProductSkin.OptionsColumn.AllowEdit = false;
            this.c_ProductSkin.OptionsColumn.AllowFocus = false;
            this.c_ProductSkin.Visible = true;
            this.c_ProductSkin.VisibleIndex = 6;
            this.c_ProductSkin.Width = 133;
            // 
            // repositoryItemLookUpEdit_Skin
            // 
            this.repositoryItemLookUpEdit_Skin.AutoHeight = false;
            this.repositoryItemLookUpEdit_Skin.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Skin.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SkinID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SkinName", "Phân loại")});
            this.repositoryItemLookUpEdit_Skin.Name = "repositoryItemLookUpEdit_Skin";
            // 
            // c_ImageIndex
            // 
            this.c_ImageIndex.Caption = "Mã icon";
            this.c_ImageIndex.FieldName = "ImageIndex";
            this.c_ImageIndex.Name = "c_ImageIndex";
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
            this.c_Image.Width = 74;
            // 
            // c_InputPrice
            // 
            this.c_InputPrice.Caption = "Giá nhập";
            this.c_InputPrice.FieldName = "InputPrice";
            this.c_InputPrice.Name = "c_InputPrice";
            this.c_InputPrice.OptionsColumn.AllowEdit = false;
            this.c_InputPrice.OptionsColumn.AllowFocus = false;
            this.c_InputPrice.Visible = true;
            this.c_InputPrice.VisibleIndex = 4;
            this.c_InputPrice.Width = 164;
            // 
            // c_Limit
            // 
            this.c_Limit.Caption = "Hạn dùng";
            this.c_Limit.FieldName = "Limit";
            this.c_Limit.Name = "c_Limit";
            this.c_Limit.OptionsColumn.AllowEdit = false;
            this.c_Limit.OptionsColumn.AllowFocus = false;
            this.c_Limit.Visible = true;
            this.c_Limit.VisibleIndex = 7;
            this.c_Limit.Width = 198;
            // 
            // c_DVT
            // 
            this.c_DVT.Caption = "Đơn vị tính";
            this.c_DVT.ColumnEdit = this.repositoryItemLookUpEdit_DVT;
            this.c_DVT.FieldName = "DVT";
            this.c_DVT.Name = "c_DVT";
            this.c_DVT.OptionsColumn.AllowEdit = false;
            this.c_DVT.OptionsColumn.AllowFocus = false;
            this.c_DVT.Visible = true;
            this.c_DVT.VisibleIndex = 3;
            this.c_DVT.Width = 104;
            // 
            // repositoryItemLookUpEdit_DVT
            // 
            this.repositoryItemLookUpEdit_DVT.AutoHeight = false;
            this.repositoryItemLookUpEdit_DVT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_DVT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DVT", "Đơn vị tính")});
            this.repositoryItemLookUpEdit_DVT.Name = "repositoryItemLookUpEdit_DVT";
            // 
            // c_ExChangeQuantity
            // 
            this.c_ExChangeQuantity.Caption = "Số lượng quy đổi";
            this.c_ExChangeQuantity.FieldName = "ExChangeQuantity";
            this.c_ExChangeQuantity.Name = "c_ExChangeQuantity";
            this.c_ExChangeQuantity.OptionsColumn.AllowEdit = false;
            this.c_ExChangeQuantity.OptionsColumn.AllowFocus = false;
            // 
            // c_ExChangeDVT
            // 
            this.c_ExChangeDVT.Caption = "Đơn vị định lượng";
            this.c_ExChangeDVT.FieldName = "ExChangeDVT";
            this.c_ExChangeDVT.Name = "c_ExChangeDVT";
            // 
            // C_Type
            // 
            this.C_Type.Caption = "Loại hàng";
            this.C_Type.FieldName = "Type";
            this.C_Type.Name = "C_Type";
            // 
            // repositoryItemImageComboBox_DVT
            // 
            this.repositoryItemImageComboBox_DVT.AutoHeight = false;
            this.repositoryItemImageComboBox_DVT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox_DVT.Name = "repositoryItemImageComboBox_DVT";
            this.repositoryItemImageComboBox_DVT.SmallImages = this.imageList_Product;
            // 
            // barManager2
            // 
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.MaxItemId = 0;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(1059, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 558);
            this.barDockControl2.Size = new System.Drawing.Size(1059, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 558);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1059, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 558);
            // 
            // frm_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 558);
            this.Controls.Add(this.groupControl_Product);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.MaximizeBox = false;
            this.Name = "frm_Product";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Product";
            this.Load += new System.EventHandler(this.frm_Product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu_Menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Product)).EndInit();
            this.groupControl_Product.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit_Notes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Skin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_DVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox_DVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton button_Add;
        private DevExpress.XtraEditors.SimpleButton button_Delete;
        private DevExpress.XtraEditors.SimpleButton button_Update;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private System.Windows.Forms.ImageList imageList_Product;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TreeView treeView_Menu;
        private DevExpress.XtraBars.PopupMenu popupMenu_Menu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Add;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Edit;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.GroupControl groupControl_Product;
        private DevExpress.XtraGrid.GridControl gridControl_Product;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Product;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn c_Price;
        private DevExpress.XtraGrid.Columns.GridColumn c_Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Status;
        private DevExpress.XtraGrid.Columns.GridColumn c_Notes;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit_Notes;
        private DevExpress.XtraGrid.Columns.GridColumn c_MadeInID;
        private DevExpress.XtraGrid.Columns.GridColumn c_MadeInName;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductSkin;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Skin;
        private DevExpress.XtraGrid.Columns.GridColumn c_ImageIndex;
        private DevExpress.XtraGrid.Columns.GridColumn c_Image;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn c_InputPrice;
        private DevExpress.XtraGrid.Columns.GridColumn c_Limit;
        private DevExpress.XtraGrid.Columns.GridColumn c_DVT;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox_DVT;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_DVT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btn_All;
        private DevExpress.XtraGrid.Columns.GridColumn c_ExChangeQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn c_ExChangeDVT;
        private DevExpress.XtraGrid.Columns.GridColumn C_Type;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Del;
    }
}