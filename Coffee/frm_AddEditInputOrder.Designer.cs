namespace Coffee
{
    partial class frm_AddEditInputOrder
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
            this.sLookUpEdit_Employee = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_EmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_EmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_TotalMoney = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_ProductName = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit_OrderDate = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.sLookUpEdit_Employee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TotalMoney.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_OrderDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_OrderDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sLookUpEdit_Employee
            // 
            this.sLookUpEdit_Employee.EditValue = "";
            this.sLookUpEdit_Employee.Location = new System.Drawing.Point(80, 38);
            this.sLookUpEdit_Employee.Name = "sLookUpEdit_Employee";
            this.sLookUpEdit_Employee.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLookUpEdit_Employee.Properties.Appearance.Options.UseFont = true;
            this.sLookUpEdit_Employee.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sLookUpEdit_Employee.Properties.AppearanceDropDown.Options.UseFont = true;
            this.sLookUpEdit_Employee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sLookUpEdit_Employee.Properties.NullText = "Không có dữ liệu";
            this.sLookUpEdit_Employee.Properties.PopupFormMinSize = new System.Drawing.Size(300, 0);
            this.sLookUpEdit_Employee.Properties.PopupFormSize = new System.Drawing.Size(620, 0);
            this.sLookUpEdit_Employee.Properties.ShowClearButton = false;
            this.sLookUpEdit_Employee.Properties.ShowFooter = false;
            this.sLookUpEdit_Employee.Properties.View = this.gridView1;
            this.sLookUpEdit_Employee.Size = new System.Drawing.Size(201, 22);
            this.sLookUpEdit_Employee.TabIndex = 36;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_EmployeeID,
            this.c_EmployeeName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // c_EmployeeID
            // 
            this.c_EmployeeID.Caption = "Mã nhân viên";
            this.c_EmployeeID.FieldName = "EmployeeID";
            this.c_EmployeeID.Name = "c_EmployeeID";
            this.c_EmployeeID.OptionsColumn.AllowEdit = false;
            this.c_EmployeeID.OptionsColumn.AllowFocus = false;
            // 
            // c_EmployeeName
            // 
            this.c_EmployeeName.Caption = "Tên nhân viên";
            this.c_EmployeeName.FieldName = "EmployeeName";
            this.c_EmployeeName.Name = "c_EmployeeName";
            this.c_EmployeeName.Visible = true;
            this.c_EmployeeName.VisibleIndex = 0;
            this.c_EmployeeName.Width = 143;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(15, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 15);
            this.labelControl5.TabIndex = 38;
            this.labelControl5.Text = "Nhân viên";
            // 
            // textEdit_TotalMoney
            // 
            this.textEdit_TotalMoney.Location = new System.Drawing.Point(80, 66);
            this.textEdit_TotalMoney.Name = "textEdit_TotalMoney";
            this.textEdit_TotalMoney.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_TotalMoney.Properties.Appearance.Options.UseFont = true;
            this.textEdit_TotalMoney.Properties.AppearanceFocused.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_TotalMoney.Properties.AppearanceFocused.Options.UseFont = true;
            this.textEdit_TotalMoney.Properties.Mask.EditMask = "n2";
            this.textEdit_TotalMoney.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_TotalMoney.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textEdit_TotalMoney.Properties.MaxLength = 20;
            this.textEdit_TotalMoney.Properties.NullText = "0";
            this.textEdit_TotalMoney.Size = new System.Drawing.Size(201, 22);
            this.textEdit_TotalMoney.TabIndex = 35;
            // 
            // labelControl_ProductName
            // 
            this.labelControl_ProductName.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_ProductName.Location = new System.Drawing.Point(15, 69);
            this.labelControl_ProductName.Name = "labelControl_ProductName";
            this.labelControl_ProductName.Size = new System.Drawing.Size(52, 15);
            this.labelControl_ProductName.TabIndex = 37;
            this.labelControl_ProductName.Text = "Tổng tiền";
            // 
            // dateEdit_OrderDate
            // 
            this.dateEdit_OrderDate.EditValue = null;
            this.dateEdit_OrderDate.Location = new System.Drawing.Point(80, 6);
            this.dateEdit_OrderDate.Name = "dateEdit_OrderDate";
            this.dateEdit_OrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_OrderDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit_OrderDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_OrderDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_OrderDate.Size = new System.Drawing.Size(201, 20);
            this.dateEdit_OrderDate.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Ngày xuất";
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(80, 92);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 30);
            this.button_Save.TabIndex = 41;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(161, 92);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 30);
            this.button_Close.TabIndex = 42;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_AddEditInputOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 124);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.dateEdit_OrderDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sLookUpEdit_Employee);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.textEdit_TotalMoney);
            this.Controls.Add(this.labelControl_ProductName);
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.Name = "frm_AddEditInputOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_AddEditInputOrder";
            this.Load += new System.EventHandler(this.frm_AddEditInputOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sLookUpEdit_Employee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TotalMoney.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_OrderDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_OrderDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit sLookUpEdit_Employee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn c_EmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn c_EmployeeName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textEdit_TotalMoney;
        private DevExpress.XtraEditors.LabelControl labelControl_ProductName;
        private DevExpress.XtraEditors.DateEdit dateEdit_OrderDate;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
    }
}