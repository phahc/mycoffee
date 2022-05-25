namespace Coffee
{
    partial class frm_Customer
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
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl_Customer = new DevExpress.XtraGrid.GridControl();
            this.gridView_Customer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_SmartLink = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Payed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.s_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Cutomer = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.c_Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_CustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_CustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_CustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_LevelCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar_Customer = new DevExpress.XtraBars.Bar();
            this.barButtonItem_Add = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Update = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Customer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Cutomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 24);
            this.barDockControlTop.Size = new System.Drawing.Size(766, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 418);
            this.barDockControlBottom.Size = new System.Drawing.Size(766, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 394);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(766, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 394);
            // 
            // gridControl_Customer
            // 
            this.gridControl_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Customer.Location = new System.Drawing.Point(0, 24);
            this.gridControl_Customer.MainView = this.gridView_Customer;
            this.gridControl_Customer.MenuManager = this.barManager1;
            this.gridControl_Customer.Name = "gridControl_Customer";
            this.gridControl_Customer.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Cutomer});
            this.gridControl_Customer.Size = new System.Drawing.Size(766, 394);
            this.gridControl_Customer.TabIndex = 11;
            this.gridControl_Customer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Customer});
            this.gridControl_Customer.DoubleClick += new System.EventHandler(this.gridControl_Customer_DoubleClick);
            // 
            // gridView_Customer
            // 
            this.gridView_Customer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_SmartLink,
            this.c_Payed,
            this.s_Status,
            this.c_Email,
            this.c_CustomerName,
            this.c_CustomerCode,
            this.c_CustomerID,
            this.c_Phone,
            this.c_LevelCard});
            this.gridView_Customer.GridControl = this.gridControl_Customer;
            this.gridView_Customer.Name = "gridView_Customer";
            this.gridView_Customer.OptionsView.ShowGroupPanel = false;
            // 
            // c_SmartLink
            // 
            this.c_SmartLink.Caption = "Mã thẻ";
            this.c_SmartLink.FieldName = "SmartLink";
            this.c_SmartLink.Name = "c_SmartLink";
            this.c_SmartLink.OptionsColumn.AllowEdit = false;
            this.c_SmartLink.OptionsColumn.AllowFocus = false;
            this.c_SmartLink.Visible = true;
            this.c_SmartLink.VisibleIndex = 2;
            this.c_SmartLink.Width = 60;
            // 
            // c_Payed
            // 
            this.c_Payed.Caption = "Tiền đã thanh toán";
            this.c_Payed.FieldName = "Payed";
            this.c_Payed.Name = "c_Payed";
            this.c_Payed.OptionsColumn.AllowEdit = false;
            this.c_Payed.OptionsColumn.AllowFocus = false;
            this.c_Payed.Visible = true;
            this.c_Payed.VisibleIndex = 4;
            this.c_Payed.Width = 124;
            // 
            // s_Status
            // 
            this.s_Status.Caption = "Tình trạng";
            this.s_Status.ColumnEdit = this.repositoryItemLookUpEdit_Cutomer;
            this.s_Status.FieldName = "Status";
            this.s_Status.Name = "s_Status";
            this.s_Status.OptionsColumn.AllowEdit = false;
            this.s_Status.OptionsColumn.AllowFocus = false;
            this.s_Status.Visible = true;
            this.s_Status.VisibleIndex = 7;
            this.s_Status.Width = 98;
            // 
            // repositoryItemLookUpEdit_Cutomer
            // 
            this.repositoryItemLookUpEdit_Cutomer.AutoHeight = false;
            this.repositoryItemLookUpEdit_Cutomer.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Cutomer.Name = "repositoryItemLookUpEdit_Cutomer";
            // 
            // c_Email
            // 
            this.c_Email.Caption = "Email";
            this.c_Email.FieldName = "Email";
            this.c_Email.Name = "c_Email";
            this.c_Email.OptionsColumn.AllowEdit = false;
            this.c_Email.OptionsColumn.AllowFocus = false;
            this.c_Email.Visible = true;
            this.c_Email.VisibleIndex = 6;
            this.c_Email.Width = 88;
            // 
            // c_CustomerName
            // 
            this.c_CustomerName.Caption = "Tên khách hàng";
            this.c_CustomerName.FieldName = "CustomerName";
            this.c_CustomerName.Name = "c_CustomerName";
            this.c_CustomerName.OptionsColumn.AllowEdit = false;
            this.c_CustomerName.OptionsColumn.AllowFocus = false;
            this.c_CustomerName.Visible = true;
            this.c_CustomerName.VisibleIndex = 1;
            this.c_CustomerName.Width = 102;
            // 
            // c_CustomerCode
            // 
            this.c_CustomerCode.Caption = "Mã KH";
            this.c_CustomerCode.FieldName = "CustomerCode";
            this.c_CustomerCode.Name = "c_CustomerCode";
            this.c_CustomerCode.OptionsColumn.AllowEdit = false;
            this.c_CustomerCode.OptionsColumn.AllowFocus = false;
            this.c_CustomerCode.Visible = true;
            this.c_CustomerCode.VisibleIndex = 0;
            this.c_CustomerCode.Width = 98;
            // 
            // c_CustomerID
            // 
            this.c_CustomerID.Caption = "Mã KH";
            this.c_CustomerID.FieldName = "CustomerID";
            this.c_CustomerID.Name = "c_CustomerID";
            this.c_CustomerID.OptionsColumn.AllowEdit = false;
            this.c_CustomerID.OptionsColumn.AllowFocus = false;
            this.c_CustomerID.Width = 146;
            // 
            // c_Phone
            // 
            this.c_Phone.Caption = "Điện thoại";
            this.c_Phone.FieldName = "Phone";
            this.c_Phone.Name = "c_Phone";
            this.c_Phone.OptionsColumn.AllowEdit = false;
            this.c_Phone.OptionsColumn.AllowFocus = false;
            this.c_Phone.Visible = true;
            this.c_Phone.VisibleIndex = 5;
            this.c_Phone.Width = 89;
            // 
            // c_LevelCard
            // 
            this.c_LevelCard.Caption = "Mức thẻ";
            this.c_LevelCard.FieldName = "LevelCard";
            this.c_LevelCard.Name = "c_LevelCard";
            this.c_LevelCard.OptionsColumn.AllowEdit = false;
            this.c_LevelCard.OptionsColumn.AllowFocus = false;
            this.c_LevelCard.Visible = true;
            this.c_LevelCard.VisibleIndex = 3;
            this.c_LevelCard.Width = 89;
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar_Customer});
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem_Add,
            this.barButtonItem_Update,
            this.barButtonItem_Delete,
            this.barButtonItem_Close});
            this.barManager2.MainMenu = this.bar_Customer;
            this.barManager2.MaxItemId = 4;
            // 
            // bar_Customer
            // 
            this.bar_Customer.BarName = "Main menu";
            this.bar_Customer.DockCol = 0;
            this.bar_Customer.DockRow = 0;
            this.bar_Customer.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar_Customer.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Add, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Update, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Delete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Close, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar_Customer.OptionsBar.MultiLine = true;
            this.bar_Customer.OptionsBar.UseWholeRow = true;
            this.bar_Customer.Text = "Main menu";
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
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(766, 24);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 418);
            this.barDockControl2.Size = new System.Drawing.Size(766, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 24);
            this.barDockControl3.Size = new System.Drawing.Size(0, 394);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(766, 24);
            this.barDockControl4.Size = new System.Drawing.Size(0, 394);
            // 
            // frm_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 418);
            this.Controls.Add(this.gridControl_Customer);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "frm_Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Customer";
            this.Load += new System.EventHandler(this.frm_Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Customer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Cutomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl_Customer;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Customer;
        private DevExpress.XtraGrid.Columns.GridColumn c_SmartLink;
        private DevExpress.XtraGrid.Columns.GridColumn c_Payed;
        private DevExpress.XtraGrid.Columns.GridColumn s_Status;
        private DevExpress.XtraGrid.Columns.GridColumn c_Email;
        private DevExpress.XtraGrid.Columns.GridColumn c_CustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn c_CustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn c_CustomerID;
        private DevExpress.XtraGrid.Columns.GridColumn c_Phone;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar_Customer;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Add;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Update;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Delete;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
        private DevExpress.XtraGrid.Columns.GridColumn c_LevelCard;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Cutomer;
    }
}