namespace Coffee
{
    partial class frm_MailReceiver
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
            this.gridView_SMSReceiverKind = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cRK_SMSReceiver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cRK_SMSKindID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cRK_SMSKindDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_MailReceiver = new DevExpress.XtraGrid.GridControl();
            this.gridView_MailReceiver = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_EMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_AutoSend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_AutoSendDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.button_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.button_Update = new DevExpress.XtraEditors.SimpleButton();
            this.button_Add = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SMSReceiverKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_MailReceiver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_MailReceiver)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView_SMSReceiverKind
            // 
            this.gridView_SMSReceiverKind.Appearance.FocusedRow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_SMSReceiverKind.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_SMSReceiverKind.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_SMSReceiverKind.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_SMSReceiverKind.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_SMSReceiverKind.Appearance.Row.Options.UseFont = true;
            this.gridView_SMSReceiverKind.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cRK_SMSReceiver,
            this.cRK_SMSKindID,
            this.cRK_SMSKindDesc});
            this.gridView_SMSReceiverKind.GridControl = this.gridControl_MailReceiver;
            this.gridView_SMSReceiverKind.Name = "gridView_SMSReceiverKind";
            this.gridView_SMSReceiverKind.OptionsView.ShowGroupPanel = false;
            this.gridView_SMSReceiverKind.RowHeight = 22;
            // 
            // cRK_SMSReceiver
            // 
            this.cRK_SMSReceiver.Caption = "SMSReceiver";
            this.cRK_SMSReceiver.FieldName = "SMSReceiver";
            this.cRK_SMSReceiver.Name = "cRK_SMSReceiver";
            this.cRK_SMSReceiver.OptionsColumn.ReadOnly = true;
            // 
            // cRK_SMSKindID
            // 
            this.cRK_SMSKindID.Caption = "SMSKindID";
            this.cRK_SMSKindID.FieldName = "SMSKindID";
            this.cRK_SMSKindID.Name = "cRK_SMSKindID";
            this.cRK_SMSKindID.OptionsColumn.ReadOnly = true;
            // 
            // cRK_SMSKindDesc
            // 
            this.cRK_SMSKindDesc.Caption = "Danh sách loại tin nhắn";
            this.cRK_SMSKindDesc.FieldName = "SMSKindDesc";
            this.cRK_SMSKindDesc.Name = "cRK_SMSKindDesc";
            this.cRK_SMSKindDesc.OptionsColumn.AllowEdit = false;
            this.cRK_SMSKindDesc.OptionsColumn.AllowFocus = false;
            this.cRK_SMSKindDesc.OptionsColumn.ReadOnly = true;
            this.cRK_SMSKindDesc.Visible = true;
            this.cRK_SMSKindDesc.VisibleIndex = 0;
            // 
            // gridControl_MailReceiver
            // 
            this.gridControl_MailReceiver.Location = new System.Drawing.Point(1, 0);
            this.gridControl_MailReceiver.MainView = this.gridView_MailReceiver;
            this.gridControl_MailReceiver.Name = "gridControl_MailReceiver";
            this.gridControl_MailReceiver.Size = new System.Drawing.Size(555, 372);
            this.gridControl_MailReceiver.TabIndex = 10;
            this.gridControl_MailReceiver.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_MailReceiver,
            this.gridView_SMSReceiverKind});
            // 
            // gridView_MailReceiver
            // 
            this.gridView_MailReceiver.Appearance.FocusedRow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_MailReceiver.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_MailReceiver.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_MailReceiver.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_MailReceiver.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView_MailReceiver.Appearance.Row.Options.UseFont = true;
            this.gridView_MailReceiver.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_EMail,
            this.c_Name,
            this.c_AutoSend,
            this.c_AutoSendDate});
            this.gridView_MailReceiver.GridControl = this.gridControl_MailReceiver;
            this.gridView_MailReceiver.Name = "gridView_MailReceiver";
            this.gridView_MailReceiver.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_MailReceiver.OptionsView.ShowGroupPanel = false;
            this.gridView_MailReceiver.RowHeight = 22;
            // 
            // c_EMail
            // 
            this.c_EMail.Caption = "Địa chỉ mail nhận";
            this.c_EMail.FieldName = "EMail";
            this.c_EMail.Name = "c_EMail";
            this.c_EMail.OptionsColumn.AllowEdit = false;
            this.c_EMail.OptionsColumn.AllowFocus = false;
            this.c_EMail.Visible = true;
            this.c_EMail.VisibleIndex = 0;
            this.c_EMail.Width = 189;
            // 
            // c_Name
            // 
            this.c_Name.Caption = "Tên người nhận";
            this.c_Name.FieldName = "Name";
            this.c_Name.Name = "c_Name";
            this.c_Name.OptionsColumn.AllowEdit = false;
            this.c_Name.OptionsColumn.AllowFocus = false;
            this.c_Name.Visible = true;
            this.c_Name.VisibleIndex = 1;
            this.c_Name.Width = 150;
            // 
            // c_AutoSend
            // 
            this.c_AutoSend.Caption = "Tự động nhận";
            this.c_AutoSend.FieldName = "AutoSend";
            this.c_AutoSend.Name = "c_AutoSend";
            this.c_AutoSend.OptionsColumn.AllowEdit = false;
            this.c_AutoSend.OptionsColumn.AllowFocus = false;
            this.c_AutoSend.Visible = true;
            this.c_AutoSend.VisibleIndex = 2;
            this.c_AutoSend.Width = 72;
            // 
            // c_AutoSendDate
            // 
            this.c_AutoSendDate.Caption = "Thời điểm nhận";
            this.c_AutoSendDate.FieldName = "AutoSendDate";
            this.c_AutoSendDate.Name = "c_AutoSendDate";
            this.c_AutoSendDate.OptionsColumn.AllowEdit = false;
            this.c_AutoSendDate.OptionsColumn.AllowFocus = false;
            this.c_AutoSendDate.Visible = true;
            this.c_AutoSendDate.VisibleIndex = 3;
            this.c_AutoSendDate.Width = 126;
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(371, 375);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 14;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Delete.Appearance.Options.UseFont = true;
            this.button_Delete.Image = global::Coffee.Properties.Resources.delete_products;
            this.button_Delete.Location = new System.Drawing.Point(288, 375);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 23);
            this.button_Delete.TabIndex = 13;
            this.button_Delete.Text = "Xóa";
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Update
            // 
            this.button_Update.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Update.Appearance.Options.UseFont = true;
            this.button_Update.Image = global::Coffee.Properties.Resources.Update;
            this.button_Update.Location = new System.Drawing.Point(205, 375);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(75, 23);
            this.button_Update.TabIndex = 12;
            this.button_Update.Text = "Sửa";
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Add
            // 
            this.button_Add.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.Appearance.Options.UseFont = true;
            this.button_Add.Image = global::Coffee.Properties.Resources.add_products;
            this.button_Add.Location = new System.Drawing.Point(122, 375);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 11;
            this.button_Add.Text = "Thêm";
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // frm_MailReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 403);
            this.Controls.Add(this.gridControl_MailReceiver);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Add);
            this.MaximizeBox = false;
            this.Name = "frm_MailReceiver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_MailReceiver";
            this.Load += new System.EventHandler(this.frm_MailReceiver_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_SMSReceiverKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_MailReceiver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_MailReceiver)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView_SMSReceiverKind;
        private DevExpress.XtraGrid.Columns.GridColumn cRK_SMSReceiver;
        private DevExpress.XtraGrid.Columns.GridColumn cRK_SMSKindID;
        private DevExpress.XtraGrid.Columns.GridColumn cRK_SMSKindDesc;
        private DevExpress.XtraGrid.GridControl gridControl_MailReceiver;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_MailReceiver;
        private DevExpress.XtraGrid.Columns.GridColumn c_EMail;
        private DevExpress.XtraGrid.Columns.GridColumn c_Name;
        private DevExpress.XtraGrid.Columns.GridColumn c_AutoSend;
        private DevExpress.XtraGrid.Columns.GridColumn c_AutoSendDate;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.SimpleButton button_Delete;
        private DevExpress.XtraEditors.SimpleButton button_Update;
        private DevExpress.XtraEditors.SimpleButton button_Add;
    }
}