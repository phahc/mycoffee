namespace Coffee
{
    partial class frm_EmployeeStatus
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.slookUpEdit_PlanWork = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl_Employee = new DevExpress.XtraEditors.GroupControl();
            this.xtraScrollable_EmployeeState = new DevExpress.XtraEditors.XtraScrollableControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Date = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.c_PlanWorkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_PlanWorkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_StartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_EndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Notes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_PlanWork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Employee)).BeginInit();
            this.groupControl_Employee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(287, 75);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 15);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Chọn ca";
            // 
            // slookUpEdit_PlanWork
            // 
            this.slookUpEdit_PlanWork.EditValue = "ttt";
            this.slookUpEdit_PlanWork.Location = new System.Drawing.Point(337, 72);
            this.slookUpEdit_PlanWork.Name = "slookUpEdit_PlanWork";
            this.slookUpEdit_PlanWork.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slookUpEdit_PlanWork.Properties.Appearance.Options.UseFont = true;
            this.slookUpEdit_PlanWork.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slookUpEdit_PlanWork.Properties.AppearanceDropDown.Options.UseFont = true;
            this.slookUpEdit_PlanWork.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slookUpEdit_PlanWork.Properties.NullText = "Chọn";
            this.slookUpEdit_PlanWork.Properties.PopupFormMinSize = new System.Drawing.Size(300, 0);
            this.slookUpEdit_PlanWork.Properties.PopupFormSize = new System.Drawing.Size(620, 0);
            this.slookUpEdit_PlanWork.Properties.ShowClearButton = false;
            this.slookUpEdit_PlanWork.Properties.ShowFooter = false;
            this.slookUpEdit_PlanWork.Properties.View = this.searchLookUpEdit1View;
            this.slookUpEdit_PlanWork.Size = new System.Drawing.Size(188, 22);
            this.slookUpEdit_PlanWork.TabIndex = 1;
            this.slookUpEdit_PlanWork.EditValueChanged += new System.EventHandler(this.slookUpEdit_PlanWork_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.searchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_PlanWorkID,
            this.c_PlanWorkName,
            this.c_StartTime,
            this.c_EndTime,
            this.c_Notes});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl_Employee
            // 
            this.groupControl_Employee.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Employee.Appearance.Options.UseFont = true;
            this.groupControl_Employee.Controls.Add(this.xtraScrollable_EmployeeState);
            this.groupControl_Employee.Location = new System.Drawing.Point(1, 100);
            this.groupControl_Employee.Name = "groupControl_Employee";
            this.groupControl_Employee.Size = new System.Drawing.Size(837, 331);
            this.groupControl_Employee.TabIndex = 44;
            this.groupControl_Employee.Text = "Danh sách nhân viên";
            // 
            // xtraScrollable_EmployeeState
            // 
            this.xtraScrollable_EmployeeState.Appearance.BackColor = System.Drawing.Color.Ivory;
            this.xtraScrollable_EmployeeState.Appearance.Options.UseBackColor = true;
            this.xtraScrollable_EmployeeState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.xtraScrollable_EmployeeState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollable_EmployeeState.Location = new System.Drawing.Point(2, 21);
            this.xtraScrollable_EmployeeState.Name = "xtraScrollable_EmployeeState";
            this.xtraScrollable_EmployeeState.Size = new System.Drawing.Size(833, 308);
            this.xtraScrollable_EmployeeState.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.lbl_Date);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(839, 65);
            this.panelControl1.TabIndex = 47;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl3.Location = new System.Drawing.Point(96, 22);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(121, 24);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "ĐIỂM DANH";
            // 
            // lbl_Date
            // 
            this.lbl_Date.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Date.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Date.Location = new System.Drawing.Point(592, 22);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(126, 22);
            this.lbl_Date.TabIndex = 2;
            this.lbl_Date.Text = "Ngày 11/9/2014";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.users;
            this.pictureEdit1.Location = new System.Drawing.Point(5, 3);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(85, 58);
            this.pictureEdit1.TabIndex = 1;
            // 
            // c_PlanWorkID
            // 
            this.c_PlanWorkID.Caption = "Mã Ca";
            this.c_PlanWorkID.FieldName = "PlanWorkID";
            this.c_PlanWorkID.Name = "c_PlanWorkID";
            this.c_PlanWorkID.OptionsColumn.AllowEdit = false;
            this.c_PlanWorkID.OptionsColumn.AllowFocus = false;
            // 
            // c_PlanWorkName
            // 
            this.c_PlanWorkName.Caption = "Tên ca";
            this.c_PlanWorkName.FieldName = "PlanWorkName";
            this.c_PlanWorkName.Name = "c_PlanWorkName";
            this.c_PlanWorkName.Visible = true;
            this.c_PlanWorkName.VisibleIndex = 0;
            this.c_PlanWorkName.Width = 534;
            // 
            // c_StartTime
            // 
            this.c_StartTime.Caption = "Thời gian bắt đầu";
            this.c_StartTime.FieldName = "StartTime";
            this.c_StartTime.Name = "c_StartTime";
            this.c_StartTime.Visible = true;
            this.c_StartTime.VisibleIndex = 1;
            this.c_StartTime.Width = 348;
            // 
            // c_EndTime
            // 
            this.c_EndTime.Caption = "Thời gian kết thúc";
            this.c_EndTime.FieldName = "EndTime";
            this.c_EndTime.Name = "c_EndTime";
            this.c_EndTime.Visible = true;
            this.c_EndTime.VisibleIndex = 2;
            this.c_EndTime.Width = 298;
            // 
            // c_Notes
            // 
            this.c_Notes.Caption = "Ghi chú";
            this.c_Notes.FieldName = "Notes";
            this.c_Notes.Name = "c_Notes";
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(404, 433);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(84, 31);
            this.button_Save.TabIndex = 6;
            this.button_Save.Text = "Xác nhận";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(761, 433);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 31);
            this.button_Close.TabIndex = 7;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_EmployeeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 466);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl_Employee);
            this.Controls.Add(this.slookUpEdit_PlanWork);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frm_EmployeeStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Điểm Danh";
            this.Load += new System.EventHandler(this.frm_EmployeeStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_PlanWork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Employee)).EndInit();
            this.groupControl_Employee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.SearchLookUpEdit slookUpEdit_PlanWork;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn c_PlanWorkID;
        private DevExpress.XtraGrid.Columns.GridColumn c_PlanWorkName;
        private DevExpress.XtraGrid.Columns.GridColumn c_StartTime;
        private DevExpress.XtraGrid.Columns.GridColumn c_EndTime;
        private DevExpress.XtraGrid.Columns.GridColumn c_Notes;
        private DevExpress.XtraEditors.GroupControl groupControl_Employee;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollable_EmployeeState;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lbl_Date;
    }
}