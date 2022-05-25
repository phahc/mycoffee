namespace Coffee
{
    partial class frm_AccountManager
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
            this.gridControl_Employee = new DevExpress.XtraGrid.GridControl();
            this.gridView_Employee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_EmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_EmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_EmployeeRight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_BirthDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ReceiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Notes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_PlanWork = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Sex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Salary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Locked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Locked = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.popupMenu_Employee = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem_EmployeeDetail = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.barButtonItem_Add = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Update = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Delete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_ResetPassWord = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Close = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Locked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu_Employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_Employee
            // 
            this.gridControl_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Employee.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControl_Employee.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl_Employee.Location = new System.Drawing.Point(0, 24);
            this.gridControl_Employee.MainView = this.gridView_Employee;
            this.gridControl_Employee.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControl_Employee.Name = "gridControl_Employee";
            this.gridControl_Employee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Locked});
            this.gridControl_Employee.Size = new System.Drawing.Size(920, 427);
            this.gridControl_Employee.TabIndex = 40;
            this.gridControl_Employee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Employee});
            this.gridControl_Employee.DoubleClick += new System.EventHandler(this.gridControl_Employee_DoubleClick);
            // 
            // gridView_Employee
            // 
            this.gridView_Employee.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Employee.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_Employee.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Employee.Appearance.Row.Options.UseFont = true;
            this.gridView_Employee.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView_Employee.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView_Employee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_EmployeeID,
            this.c_EmployeeCode,
            this.c_EmployeeName,
            this.c_EmployeeRight,
            this.c_BirthDay,
            this.c_ReceiveDate,
            this.c_Email,
            this.c_Phone,
            this.c_Address,
            this.c_Notes,
            this.c_PlanWork,
            this.c_Sex,
            this.c_Salary,
            this.c_Locked});
            this.gridView_Employee.GridControl = this.gridControl_Employee;
            this.gridView_Employee.Name = "gridView_Employee";
            this.gridView_Employee.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_Employee.OptionsView.ShowAutoFilterRow = true;
            this.gridView_Employee.OptionsView.ShowGroupPanel = false;
            this.gridView_Employee.RowHeight = 22;
            this.gridView_Employee.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_Employee_RowCellStyle);
            this.gridView_Employee.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gridView_Employee_MouseUp);
            // 
            // c_EmployeeID
            // 
            this.c_EmployeeID.Caption = "gridColumn1";
            this.c_EmployeeID.FieldName = "EmployeeID";
            this.c_EmployeeID.Name = "c_EmployeeID";
            this.c_EmployeeID.OptionsColumn.AllowEdit = false;
            this.c_EmployeeID.OptionsColumn.AllowFocus = false;
            // 
            // c_EmployeeCode
            // 
            this.c_EmployeeCode.Caption = "Tên đăng nhập";
            this.c_EmployeeCode.FieldName = "EmployeeCode";
            this.c_EmployeeCode.Name = "c_EmployeeCode";
            this.c_EmployeeCode.OptionsColumn.AllowEdit = false;
            this.c_EmployeeCode.OptionsColumn.AllowFocus = false;
            this.c_EmployeeCode.Visible = true;
            this.c_EmployeeCode.VisibleIndex = 0;
            this.c_EmployeeCode.Width = 122;
            // 
            // c_EmployeeName
            // 
            this.c_EmployeeName.Caption = "Họ tên đầy đủ";
            this.c_EmployeeName.FieldName = "EmployeeName";
            this.c_EmployeeName.Name = "c_EmployeeName";
            this.c_EmployeeName.OptionsColumn.AllowEdit = false;
            this.c_EmployeeName.OptionsColumn.AllowFocus = false;
            this.c_EmployeeName.Visible = true;
            this.c_EmployeeName.VisibleIndex = 1;
            this.c_EmployeeName.Width = 128;
            // 
            // c_EmployeeRight
            // 
            this.c_EmployeeRight.Caption = "Quyền";
            this.c_EmployeeRight.FieldName = "EmployeeRight";
            this.c_EmployeeRight.Name = "c_EmployeeRight";
            this.c_EmployeeRight.OptionsColumn.AllowEdit = false;
            this.c_EmployeeRight.OptionsColumn.AllowFocus = false;
            this.c_EmployeeRight.Visible = true;
            this.c_EmployeeRight.VisibleIndex = 2;
            this.c_EmployeeRight.Width = 104;
            // 
            // c_BirthDay
            // 
            this.c_BirthDay.Caption = "Ngày sinh";
            this.c_BirthDay.FieldName = "BirthDay";
            this.c_BirthDay.Name = "c_BirthDay";
            this.c_BirthDay.OptionsColumn.AllowEdit = false;
            this.c_BirthDay.OptionsColumn.AllowFocus = false;
            this.c_BirthDay.Visible = true;
            this.c_BirthDay.VisibleIndex = 3;
            this.c_BirthDay.Width = 93;
            // 
            // c_ReceiveDate
            // 
            this.c_ReceiveDate.Caption = "Ngày nhận";
            this.c_ReceiveDate.FieldName = "ReceiveDate";
            this.c_ReceiveDate.Name = "c_ReceiveDate";
            this.c_ReceiveDate.OptionsColumn.AllowEdit = false;
            this.c_ReceiveDate.OptionsColumn.AllowFocus = false;
            this.c_ReceiveDate.Visible = true;
            this.c_ReceiveDate.VisibleIndex = 6;
            this.c_ReceiveDate.Width = 98;
            // 
            // c_Email
            // 
            this.c_Email.Caption = "Email";
            this.c_Email.FieldName = "Email";
            this.c_Email.Name = "c_Email";
            this.c_Email.OptionsColumn.AllowEdit = false;
            this.c_Email.OptionsColumn.AllowFocus = false;
            this.c_Email.Visible = true;
            this.c_Email.VisibleIndex = 8;
            this.c_Email.Width = 86;
            // 
            // c_Phone
            // 
            this.c_Phone.Caption = "Điện thoại";
            this.c_Phone.FieldName = "Phone";
            this.c_Phone.Name = "c_Phone";
            this.c_Phone.OptionsColumn.AllowEdit = false;
            this.c_Phone.OptionsColumn.AllowFocus = false;
            this.c_Phone.Visible = true;
            this.c_Phone.VisibleIndex = 9;
            this.c_Phone.Width = 107;
            // 
            // c_Address
            // 
            this.c_Address.Caption = "Địa chỉ";
            this.c_Address.FieldName = "Address";
            this.c_Address.Name = "c_Address";
            this.c_Address.OptionsColumn.AllowEdit = false;
            this.c_Address.OptionsColumn.AllowFocus = false;
            this.c_Address.Visible = true;
            this.c_Address.VisibleIndex = 10;
            this.c_Address.Width = 109;
            // 
            // c_Notes
            // 
            this.c_Notes.Caption = "Ghi chú";
            this.c_Notes.FieldName = "Notes";
            this.c_Notes.Name = "c_Notes";
            this.c_Notes.OptionsColumn.AllowEdit = false;
            this.c_Notes.OptionsColumn.AllowFocus = false;
            this.c_Notes.Visible = true;
            this.c_Notes.VisibleIndex = 11;
            this.c_Notes.Width = 106;
            // 
            // c_PlanWork
            // 
            this.c_PlanWork.Caption = "Ca làm việc";
            this.c_PlanWork.FieldName = "PlanWork";
            this.c_PlanWork.Name = "c_PlanWork";
            this.c_PlanWork.OptionsColumn.AllowEdit = false;
            this.c_PlanWork.OptionsColumn.AllowFocus = false;
            this.c_PlanWork.Visible = true;
            this.c_PlanWork.VisibleIndex = 7;
            this.c_PlanWork.Width = 84;
            // 
            // c_Sex
            // 
            this.c_Sex.Caption = "Giới tính";
            this.c_Sex.FieldName = "Sex";
            this.c_Sex.Name = "c_Sex";
            this.c_Sex.OptionsColumn.AllowEdit = false;
            this.c_Sex.OptionsColumn.AllowFocus = false;
            this.c_Sex.Visible = true;
            this.c_Sex.VisibleIndex = 4;
            this.c_Sex.Width = 68;
            // 
            // c_Salary
            // 
            this.c_Salary.Caption = "Mức lương";
            this.c_Salary.FieldName = "Salary";
            this.c_Salary.Name = "c_Salary";
            this.c_Salary.OptionsColumn.AllowEdit = false;
            this.c_Salary.OptionsColumn.AllowFocus = false;
            this.c_Salary.Visible = true;
            this.c_Salary.VisibleIndex = 5;
            // 
            // c_Locked
            // 
            this.c_Locked.Caption = "Khóa";
            this.c_Locked.ColumnEdit = this.repositoryItemLookUpEdit_Locked;
            this.c_Locked.FieldName = "Locked";
            this.c_Locked.Name = "c_Locked";
            this.c_Locked.OptionsColumn.AllowEdit = false;
            this.c_Locked.OptionsColumn.AllowFocus = false;
            this.c_Locked.Visible = true;
            this.c_Locked.VisibleIndex = 12;
            // 
            // repositoryItemLookUpEdit_Locked
            // 
            this.repositoryItemLookUpEdit_Locked.AutoHeight = false;
            this.repositoryItemLookUpEdit_Locked.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Locked.Name = "repositoryItemLookUpEdit_Locked";
            // 
            // popupMenu_Employee
            // 
            this.popupMenu_Employee.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_EmployeeDetail)});
            this.popupMenu_Employee.Manager = this.barManager1;
            this.popupMenu_Employee.Name = "popupMenu_Employee";
            // 
            // barButtonItem_EmployeeDetail
            // 
            this.barButtonItem_EmployeeDetail.Caption = "Chi tiết...";
            this.barButtonItem_EmployeeDetail.Glyph = global::Coffee.Properties.Resources.List;
            this.barButtonItem_EmployeeDetail.Id = 0;
            this.barButtonItem_EmployeeDetail.Name = "barButtonItem_EmployeeDetail";
            this.barButtonItem_EmployeeDetail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_EmployeeDetail_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem_EmployeeDetail});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 24);
            this.barDockControlTop.Size = new System.Drawing.Size(920, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 451);
            this.barDockControlBottom.Size = new System.Drawing.Size(920, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 427);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(920, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 427);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barManager2
            // 
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar5});
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem_Add,
            this.barButtonItem_Update,
            this.barButtonItem_Delete,
            this.barButtonItem_ResetPassWord,
            this.barButtonItem_Close});
            this.barManager2.MainMenu = this.bar5;
            this.barManager2.MaxItemId = 5;
            // 
            // bar5
            // 
            this.bar5.BarName = "Main menu";
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Add, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Update, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Delete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_ResetPassWord, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem_Close, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar5.OptionsBar.MultiLine = true;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Main menu";
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
            // barButtonItem_ResetPassWord
            // 
            this.barButtonItem_ResetPassWord.Caption = "Cấp lại mật khẩu";
            this.barButtonItem_ResetPassWord.Glyph = global::Coffee.Properties.Resources.Refresh;
            this.barButtonItem_ResetPassWord.Id = 3;
            this.barButtonItem_ResetPassWord.Name = "barButtonItem_ResetPassWord";
            this.barButtonItem_ResetPassWord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_ResetPassWord_ItemClick);
            // 
            // barButtonItem_Close
            // 
            this.barButtonItem_Close.Caption = "Thoát";
            this.barButtonItem_Close.Glyph = global::Coffee.Properties.Resources.Turn_off;
            this.barButtonItem_Close.Id = 4;
            this.barButtonItem_Close.Name = "barButtonItem_Close";
            this.barButtonItem_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Close_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(920, 24);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 451);
            this.barDockControl2.Size = new System.Drawing.Size(920, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 24);
            this.barDockControl3.Size = new System.Drawing.Size(0, 427);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(920, 24);
            this.barDockControl4.Size = new System.Drawing.Size(0, 427);
            // 
            // frm_AccountManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 451);
            this.Controls.Add(this.gridControl_Employee);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.Name = "frm_AccountManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_AccountManager";
            this.Load += new System.EventHandler(this.frm_AccountManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Locked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu_Employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_Employee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn c_EmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn c_EmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn c_EmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn c_EmployeeRight;
        private DevExpress.XtraGrid.Columns.GridColumn c_BirthDay;
        private DevExpress.XtraGrid.Columns.GridColumn c_ReceiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn c_Email;
        private DevExpress.XtraGrid.Columns.GridColumn c_Phone;
        private DevExpress.XtraGrid.Columns.GridColumn c_Address;
        private DevExpress.XtraGrid.Columns.GridColumn c_Notes;
        private DevExpress.XtraGrid.Columns.GridColumn c_PlanWork;
        private DevExpress.XtraGrid.Columns.GridColumn c_Sex;
        private DevExpress.XtraGrid.Columns.GridColumn c_Salary;
        private DevExpress.XtraGrid.Columns.GridColumn c_Locked;
        private DevExpress.XtraBars.PopupMenu popupMenu_Employee;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_EmployeeDetail;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Locked;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Add;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Update;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Delete;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_ResetPassWord;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_Close;
    }
}