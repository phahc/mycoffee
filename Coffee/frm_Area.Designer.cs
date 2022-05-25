namespace Coffee
{
    partial class frm_Area
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.button_Add = new DevExpress.XtraEditors.SimpleButton();
            this.button_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.button_Update = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.repositoryItemLookUpEdit_Status = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridView_Area = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_AreaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_AreaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_SystemKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl_Area = new DevExpress.XtraGrid.GridControl();
            this.repositoryItemLookUpEdit_Deleted = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Area)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Area)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Deleted)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button_Add);
            this.panelControl1.Controls.Add(this.button_Delete);
            this.panelControl1.Controls.Add(this.button_Update);
            this.panelControl1.Controls.Add(this.button_Close);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 325);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(493, 37);
            this.panelControl1.TabIndex = 0;
            // 
            // button_Add
            // 
            this.button_Add.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.Appearance.Options.UseFont = true;
            this.button_Add.Image = global::Coffee.Properties.Resources.add_products;
            this.button_Add.Location = new System.Drawing.Point(155, 4);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 29);
            this.button_Add.TabIndex = 10;
            this.button_Add.Text = "Thêm";
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Delete.Appearance.Options.UseFont = true;
            this.button_Delete.Image = global::Coffee.Properties.Resources.Remove;
            this.button_Delete.Location = new System.Drawing.Point(317, 4);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 29);
            this.button_Delete.TabIndex = 12;
            this.button_Delete.Text = "Xóa";
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Update
            // 
            this.button_Update.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Update.Appearance.Options.UseFont = true;
            this.button_Update.Image = global::Coffee.Properties.Resources.Update;
            this.button_Update.Location = new System.Drawing.Point(236, 4);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(75, 29);
            this.button_Update.TabIndex = 11;
            this.button_Update.Text = "Sửa";
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(413, 4);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 29);
            this.button_Close.TabIndex = 13;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
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
            // gridView_Area
            // 
            this.gridView_Area.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_AreaID,
            this.c_AreaCode,
            this.c_Status,
            this.c_SystemKey});
            this.gridView_Area.GridControl = this.gridControl_Area;
            this.gridView_Area.Name = "gridView_Area";
            this.gridView_Area.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_Area.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView_Area.OptionsView.ShowAutoFilterRow = true;
            this.gridView_Area.OptionsView.ShowGroupPanel = false;
            // 
            // c_AreaID
            // 
            this.c_AreaID.Caption = "Mã khu vực";
            this.c_AreaID.FieldName = "AreaID";
            this.c_AreaID.Name = "c_AreaID";
            this.c_AreaID.OptionsColumn.AllowEdit = false;
            this.c_AreaID.OptionsColumn.AllowFocus = false;
            this.c_AreaID.Visible = true;
            this.c_AreaID.VisibleIndex = 0;
            this.c_AreaID.Width = 169;
            // 
            // c_AreaCode
            // 
            this.c_AreaCode.Caption = "Tên khu vực";
            this.c_AreaCode.FieldName = "AreaCode";
            this.c_AreaCode.Name = "c_AreaCode";
            this.c_AreaCode.OptionsColumn.AllowEdit = false;
            this.c_AreaCode.OptionsColumn.AllowFocus = false;
            this.c_AreaCode.Visible = true;
            this.c_AreaCode.VisibleIndex = 1;
            this.c_AreaCode.Width = 555;
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
            this.c_Status.VisibleIndex = 2;
            this.c_Status.Width = 270;
            // 
            // c_SystemKey
            // 
            this.c_SystemKey.Caption = "Dữ liệu hệ thống";
            this.c_SystemKey.FieldName = "SystemKey";
            this.c_SystemKey.Name = "c_SystemKey";
            // 
            // gridControl_Area
            // 
            this.gridControl_Area.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Area.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl_Area.Location = new System.Drawing.Point(0, 0);
            this.gridControl_Area.MainView = this.gridView_Area;
            this.gridControl_Area.Name = "gridControl_Area";
            this.gridControl_Area.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Status,
            this.repositoryItemLookUpEdit_Deleted});
            this.gridControl_Area.ShowOnlyPredefinedDetails = true;
            this.gridControl_Area.Size = new System.Drawing.Size(493, 325);
            this.gridControl_Area.TabIndex = 1;
            this.gridControl_Area.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Area});
            this.gridControl_Area.DoubleClick += new System.EventHandler(this.gridControl_Area_DoubleClick);
            // 
            // repositoryItemLookUpEdit_Deleted
            // 
            this.repositoryItemLookUpEdit_Deleted.AutoHeight = false;
            this.repositoryItemLookUpEdit_Deleted.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Deleted.Name = "repositoryItemLookUpEdit_Deleted";
            // 
            // frm_Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 362);
            this.Controls.Add(this.gridControl_Area);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.Name = "frm_Area";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Area";
            this.Load += new System.EventHandler(this.frm_Area_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Area)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Area)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Deleted)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton button_Add;
        private DevExpress.XtraEditors.SimpleButton button_Delete;
        private DevExpress.XtraEditors.SimpleButton button_Update;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Status;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Area;
        private DevExpress.XtraGrid.Columns.GridColumn c_AreaID;
        private DevExpress.XtraGrid.Columns.GridColumn c_AreaCode;
        private DevExpress.XtraGrid.Columns.GridColumn c_Status;
        private DevExpress.XtraGrid.GridControl gridControl_Area;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Deleted;
        private DevExpress.XtraGrid.Columns.GridColumn c_SystemKey;

    }
}