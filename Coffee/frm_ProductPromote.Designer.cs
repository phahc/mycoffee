namespace Coffee
{
    partial class frm_ProductPromote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProductPromote));
            this.gridControl_ProductPromote = new DevExpress.XtraGrid.GridControl();
            this.gridView_Product = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_pPromoteID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_StartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_EndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit_Notes = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemLookUpEdit_Status = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.button_Add = new DevExpress.XtraEditors.SimpleButton();
            this.button_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.button_Update = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_Promote = new DevExpress.XtraGrid.GridControl();
            this.gridView_Promote = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_PromoteID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_PromoteName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_pEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_pStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btn_AddProducts = new DevExpress.XtraEditors.SimpleButton();
            this.btn_UpdateProducts = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_DelProducts = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ProductPromote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit_Notes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Promote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Promote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_ProductPromote
            // 
            this.gridControl_ProductPromote.Location = new System.Drawing.Point(364, 0);
            this.gridControl_ProductPromote.MainView = this.gridView_Product;
            this.gridControl_ProductPromote.Name = "gridControl_ProductPromote";
            this.gridControl_ProductPromote.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit_Notes,
            this.repositoryItemLookUpEdit_Status});
            this.gridControl_ProductPromote.ShowOnlyPredefinedDetails = true;
            this.gridControl_ProductPromote.Size = new System.Drawing.Size(511, 402);
            this.gridControl_ProductPromote.TabIndex = 6;
            this.gridControl_ProductPromote.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Product});
            this.gridControl_ProductPromote.DoubleClick += new System.EventHandler(this.gridControl_ProductPromote_DoubleClick);
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
            this.ID,
            this.c_ProductID,
            this.c_ProductName,
            this.c_ProductCode,
            this.c_Price,
            this.c_pPromoteID,
            this.c_StartDate,
            this.c_EndDate});
            this.gridView_Product.GridControl = this.gridControl_ProductPromote;
            this.gridView_Product.Name = "gridView_Product";
            this.gridView_Product.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_Product.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView_Product.OptionsView.RowAutoHeight = true;
            this.gridView_Product.OptionsView.ShowAutoFilterRow = true;
            this.gridView_Product.OptionsView.ShowGroupPanel = false;
            this.gridView_Product.OptionsView.ShowViewCaption = true;
            this.gridView_Product.RowHeight = 22;
            this.gridView_Product.ViewCaption = "Sản phẩm khuyến mãi";
            // 
            // ID
            // 
            this.ID.Caption = "Mã";
            this.ID.FieldName = "ID";
            this.ID.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.AllowFocus = false;
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
            this.c_ProductName.VisibleIndex = 0;
            this.c_ProductName.Width = 220;
            // 
            // c_ProductCode
            // 
            this.c_ProductCode.Caption = "Mã SP";
            this.c_ProductCode.FieldName = "ProductCode";
            this.c_ProductCode.Name = "c_ProductCode";
            this.c_ProductCode.OptionsColumn.AllowEdit = false;
            this.c_ProductCode.OptionsColumn.AllowFocus = false;
            this.c_ProductCode.Width = 182;
            // 
            // c_Price
            // 
            this.c_Price.Caption = "Giá";
            this.c_Price.FieldName = "Price";
            this.c_Price.Name = "c_Price";
            this.c_Price.OptionsColumn.AllowEdit = false;
            this.c_Price.OptionsColumn.AllowFocus = false;
            this.c_Price.Visible = true;
            this.c_Price.VisibleIndex = 3;
            this.c_Price.Width = 173;
            // 
            // c_pPromoteID
            // 
            this.c_pPromoteID.Caption = "Mã khuyến mãi";
            this.c_pPromoteID.FieldName = "PromoteID";
            this.c_pPromoteID.Name = "c_pPromoteID";
            this.c_pPromoteID.OptionsColumn.AllowEdit = false;
            this.c_pPromoteID.OptionsColumn.AllowFocus = false;
            // 
            // c_StartDate
            // 
            this.c_StartDate.Caption = "Ngày bắt đầu";
            this.c_StartDate.FieldName = "StartDate";
            this.c_StartDate.Name = "c_StartDate";
            this.c_StartDate.OptionsColumn.AllowEdit = false;
            this.c_StartDate.OptionsColumn.AllowFocus = false;
            this.c_StartDate.Visible = true;
            this.c_StartDate.VisibleIndex = 1;
            this.c_StartDate.Width = 214;
            // 
            // c_EndDate
            // 
            this.c_EndDate.Caption = "Ngày kết thúc";
            this.c_EndDate.FieldName = "EndDate";
            this.c_EndDate.Name = "c_EndDate";
            this.c_EndDate.OptionsColumn.AllowEdit = false;
            this.c_EndDate.OptionsColumn.AllowFocus = false;
            this.c_EndDate.Visible = true;
            this.c_EndDate.VisibleIndex = 2;
            this.c_EndDate.Width = 220;
            // 
            // repositoryItemMemoEdit_Notes
            // 
            this.repositoryItemMemoEdit_Notes.Name = "repositoryItemMemoEdit_Notes";
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
            // button_Add
            // 
            this.button_Add.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.Appearance.Options.UseFont = true;
            this.button_Add.Image = global::Coffee.Properties.Resources.add_products;
            this.button_Add.Location = new System.Drawing.Point(12, 404);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 30);
            this.button_Add.TabIndex = 10;
            this.button_Add.Text = "Thêm";
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Delete.Appearance.Options.UseFont = true;
            this.button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("button_Delete.Image")));
            this.button_Delete.Location = new System.Drawing.Point(174, 404);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 30);
            this.button_Delete.TabIndex = 12;
            this.button_Delete.Text = "Xóa";
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Update
            // 
            this.button_Update.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Update.Appearance.Options.UseFont = true;
            this.button_Update.Image = ((System.Drawing.Image)(resources.GetObject("button_Update.Image")));
            this.button_Update.Location = new System.Drawing.Point(93, 404);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(75, 30);
            this.button_Update.TabIndex = 11;
            this.button_Update.Text = "Sửa";
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(799, 403);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 31);
            this.button_Close.TabIndex = 13;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // gridControl_Promote
            // 
            this.gridControl_Promote.Location = new System.Drawing.Point(-2, 0);
            this.gridControl_Promote.MainView = this.gridView_Promote;
            this.gridControl_Promote.Name = "gridControl_Promote";
            this.gridControl_Promote.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemLookUpEdit1});
            this.gridControl_Promote.ShowOnlyPredefinedDetails = true;
            this.gridControl_Promote.Size = new System.Drawing.Size(360, 402);
            this.gridControl_Promote.TabIndex = 6;
            this.gridControl_Promote.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Promote});
            this.gridControl_Promote.DoubleClick += new System.EventHandler(this.gridControl_Promote_DoubleClick);
            // 
            // gridView_Promote
            // 
            this.gridView_Promote.Appearance.FocusedRow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Promote.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Promote.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Promote.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_Promote.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Promote.Appearance.Row.Options.UseFont = true;
            this.gridView_Promote.Appearance.SelectedRow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Promote.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView_Promote.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Promote.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView_Promote.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gridView_Promote.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_Promote.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_PromoteID,
            this.c_PromoteName,
            this.c_pEndDate,
            this.c_pStartDate});
            this.gridView_Promote.GridControl = this.gridControl_Promote;
            this.gridView_Promote.Name = "gridView_Promote";
            this.gridView_Promote.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_Promote.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView_Promote.OptionsView.RowAutoHeight = true;
            this.gridView_Promote.OptionsView.ShowAutoFilterRow = true;
            this.gridView_Promote.OptionsView.ShowGroupPanel = false;
            this.gridView_Promote.OptionsView.ShowViewCaption = true;
            this.gridView_Promote.RowHeight = 22;
            this.gridView_Promote.ViewCaption = "Chương trình khuyến mãi";
            this.gridView_Promote.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_Promote_RowClick);
            this.gridView_Promote.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_Promote_RowCellStyle);
            // 
            // c_PromoteID
            // 
            this.c_PromoteID.Caption = "Mã khuyến mãi";
            this.c_PromoteID.FieldName = "PromoteID";
            this.c_PromoteID.Name = "c_PromoteID";
            this.c_PromoteID.OptionsColumn.AllowEdit = false;
            this.c_PromoteID.OptionsColumn.AllowFocus = false;
            // 
            // c_PromoteName
            // 
            this.c_PromoteName.Caption = "Tên Khuyến Mãi";
            this.c_PromoteName.FieldName = "PromoteName";
            this.c_PromoteName.Name = "c_PromoteName";
            this.c_PromoteName.OptionsColumn.AllowEdit = false;
            this.c_PromoteName.OptionsColumn.AllowFocus = false;
            this.c_PromoteName.Visible = true;
            this.c_PromoteName.VisibleIndex = 0;
            this.c_PromoteName.Width = 555;
            // 
            // c_pEndDate
            // 
            this.c_pEndDate.Caption = "Ngày kết thúc";
            this.c_pEndDate.FieldName = "EndDate";
            this.c_pEndDate.Name = "c_pEndDate";
            this.c_pEndDate.OptionsColumn.AllowEdit = false;
            this.c_pEndDate.OptionsColumn.AllowFocus = false;
            this.c_pEndDate.Visible = true;
            this.c_pEndDate.VisibleIndex = 2;
            this.c_pEndDate.Width = 310;
            // 
            // c_pStartDate
            // 
            this.c_pStartDate.Caption = "Ngày bắt đầu";
            this.c_pStartDate.FieldName = "StartDate";
            this.c_pStartDate.Name = "c_pStartDate";
            this.c_pStartDate.OptionsColumn.AllowEdit = false;
            this.c_pStartDate.OptionsColumn.AllowFocus = false;
            this.c_pStartDate.Visible = true;
            this.c_pStartDate.VisibleIndex = 1;
            this.c_pStartDate.Width = 315;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusName", "Trạng thái"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusID", "Mã trạng thái", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // btn_AddProducts
            // 
            this.btn_AddProducts.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddProducts.Appearance.Options.UseFont = true;
            this.btn_AddProducts.Image = global::Coffee.Properties.Resources.add_products;
            this.btn_AddProducts.Location = new System.Drawing.Point(408, 404);
            this.btn_AddProducts.Name = "btn_AddProducts";
            this.btn_AddProducts.Size = new System.Drawing.Size(111, 30);
            this.btn_AddProducts.TabIndex = 47;
            this.btn_AddProducts.Text = "Thêm sản phẩm";
            this.btn_AddProducts.Click += new System.EventHandler(this.btn_AddProducts_Click);
            // 
            // btn_UpdateProducts
            // 
            this.btn_UpdateProducts.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UpdateProducts.Appearance.Options.UseFont = true;
            this.btn_UpdateProducts.Image = ((System.Drawing.Image)(resources.GetObject("btn_UpdateProducts.Image")));
            this.btn_UpdateProducts.Location = new System.Drawing.Point(525, 404);
            this.btn_UpdateProducts.Name = "btn_UpdateProducts";
            this.btn_UpdateProducts.Size = new System.Drawing.Size(110, 30);
            this.btn_UpdateProducts.TabIndex = 48;
            this.btn_UpdateProducts.Text = "Sửa sản phẩm";
            this.btn_UpdateProducts.Click += new System.EventHandler(this.btn_UpdateProducts_Click);
            // 
            // simpleButton_DelProducts
            // 
            this.simpleButton_DelProducts.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton_DelProducts.Appearance.Options.UseFont = true;
            this.simpleButton_DelProducts.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton_DelProducts.Image")));
            this.simpleButton_DelProducts.Location = new System.Drawing.Point(641, 404);
            this.simpleButton_DelProducts.Name = "simpleButton_DelProducts";
            this.simpleButton_DelProducts.Size = new System.Drawing.Size(105, 30);
            this.simpleButton_DelProducts.TabIndex = 49;
            this.simpleButton_DelProducts.Text = "Xóa sản phẩm";
            this.simpleButton_DelProducts.Click += new System.EventHandler(this.simpleButton_DelProducts_Click);
            // 
            // frm_ProductPromote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 436);
            this.Controls.Add(this.btn_AddProducts);
            this.Controls.Add(this.btn_UpdateProducts);
            this.Controls.Add(this.simpleButton_DelProducts);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.gridControl_Promote);
            this.Controls.Add(this.gridControl_ProductPromote);
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.Name = "frm_ProductPromote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_ProductPromote";
            this.Load += new System.EventHandler(this.frm_ProductPromote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ProductPromote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit_Notes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Promote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Promote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_ProductPromote;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Product;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn c_Price;
        private DevExpress.XtraGrid.Columns.GridColumn c_pPromoteID;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit_Notes;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Status;
        private DevExpress.XtraEditors.SimpleButton button_Add;
        private DevExpress.XtraEditors.SimpleButton button_Delete;
        private DevExpress.XtraEditors.SimpleButton button_Update;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraGrid.Columns.GridColumn c_StartDate;
        private DevExpress.XtraGrid.Columns.GridColumn c_EndDate;
        private DevExpress.XtraGrid.GridControl gridControl_Promote;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Promote;
        private DevExpress.XtraGrid.Columns.GridColumn c_PromoteID;
        private DevExpress.XtraGrid.Columns.GridColumn c_PromoteName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn c_pEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn c_pStartDate;
        private DevExpress.XtraEditors.SimpleButton btn_AddProducts;
        private DevExpress.XtraEditors.SimpleButton btn_UpdateProducts;
        private DevExpress.XtraEditors.SimpleButton simpleButton_DelProducts;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
    }
}