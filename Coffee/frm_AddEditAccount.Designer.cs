namespace Coffee
{
    partial class frm_AddEditAccount
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.textEdit_EmployeeCode = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEdit_Right = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.textEdit_EmployeeName = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateEdit_BirthDay = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit_DateReceive = new DevExpress.XtraEditors.DateEdit();
            this.textEdit_Email = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Phone = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Address = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.slookUpEdit_PlanWork = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_PlanWorkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_PlanWorkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_StartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_EndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Notes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memoEdit_Notes = new DevExpress.XtraEditors.MemoEdit();
            this.radioButton_Male = new System.Windows.Forms.RadioButton();
            this.radioButton_Female = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textEdit_Salary = new DevExpress.XtraEditors.TextEdit();
            this.radioButton_Other = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.slookUpEdit_Locked = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._cLockeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_LockedName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EmployeeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Right.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_BirthDay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_BirthDay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DateReceive.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DateReceive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Phone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Address.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_PlanWork.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Notes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Salary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_Locked.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_EmployeeCode
            // 
            this.textEdit_EmployeeCode.Location = new System.Drawing.Point(108, 12);
            this.textEdit_EmployeeCode.Name = "textEdit_EmployeeCode";
            this.textEdit_EmployeeCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.textEdit_EmployeeCode.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_EmployeeCode.Properties.Appearance.Options.UseFont = true;
            this.textEdit_EmployeeCode.Properties.Mask.EditMask = "\\w+";
            this.textEdit_EmployeeCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEdit_EmployeeCode.Properties.MaxLength = 50;
            this.textEdit_EmployeeCode.Size = new System.Drawing.Size(201, 22);
            this.textEdit_EmployeeCode.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Họ tên nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên đăng nhập";
            // 
            // comboBoxEdit_Right
            // 
            this.comboBoxEdit_Right.Location = new System.Drawing.Point(108, 64);
            this.comboBoxEdit_Right.Name = "comboBoxEdit_Right";
            this.comboBoxEdit_Right.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEdit_Right.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEdit_Right.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEdit_Right.Properties.AppearanceDropDown.Options.UseFont = true;
            this.comboBoxEdit_Right.Properties.AppearanceFocused.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEdit_Right.Properties.AppearanceFocused.Options.UseFont = true;
            this.comboBoxEdit_Right.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", 20, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.comboBoxEdit_Right.Properties.Items.AddRange(new object[] {
            "Người dùng",
            "Quản trị"});
            this.comboBoxEdit_Right.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit_Right.Size = new System.Drawing.Size(201, 22);
            this.comboBoxEdit_Right.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Loại quyền";
            // 
            // textEdit_EmployeeName
            // 
            this.textEdit_EmployeeName.Location = new System.Drawing.Point(108, 38);
            this.textEdit_EmployeeName.Name = "textEdit_EmployeeName";
            this.textEdit_EmployeeName.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_EmployeeName.Properties.Appearance.Options.UseFont = true;
            this.textEdit_EmployeeName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_EmployeeName.Properties.MaxLength = 50;
            this.textEdit_EmployeeName.Size = new System.Drawing.Size(201, 22);
            this.textEdit_EmployeeName.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Năm sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Điện thoại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Địa chỉ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ngày nhận";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 274);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Ghi chú";
            // 
            // dateEdit_BirthDay
            // 
            this.dateEdit_BirthDay.EditValue = null;
            this.dateEdit_BirthDay.Location = new System.Drawing.Point(108, 92);
            this.dateEdit_BirthDay.Name = "dateEdit_BirthDay";
            this.dateEdit_BirthDay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_BirthDay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit_BirthDay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_BirthDay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_BirthDay.Size = new System.Drawing.Size(201, 20);
            this.dateEdit_BirthDay.TabIndex = 16;
            // 
            // dateEdit_DateReceive
            // 
            this.dateEdit_DateReceive.EditValue = null;
            this.dateEdit_DateReceive.Location = new System.Drawing.Point(108, 243);
            this.dateEdit_DateReceive.Name = "dateEdit_DateReceive";
            this.dateEdit_DateReceive.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_DateReceive.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateEdit_DateReceive.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_DateReceive.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_DateReceive.Size = new System.Drawing.Size(109, 20);
            this.dateEdit_DateReceive.TabIndex = 16;
            // 
            // textEdit_Email
            // 
            this.textEdit_Email.Location = new System.Drawing.Point(108, 166);
            this.textEdit_Email.Name = "textEdit_Email";
            this.textEdit_Email.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_Email.Size = new System.Drawing.Size(201, 20);
            this.textEdit_Email.TabIndex = 17;
            // 
            // textEdit_Phone
            // 
            this.textEdit_Phone.EditValue = 0;
            this.textEdit_Phone.Location = new System.Drawing.Point(108, 191);
            this.textEdit_Phone.Name = "textEdit_Phone";
            this.textEdit_Phone.Properties.Mask.EditMask = "(\\d?\\d?\\d?)\\d\\d\\d-\\d\\d\\d\\d";
            this.textEdit_Phone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.textEdit_Phone.Properties.Tag = 0;
            this.textEdit_Phone.Size = new System.Drawing.Size(201, 20);
            this.textEdit_Phone.TabIndex = 17;
            // 
            // textEdit_Address
            // 
            this.textEdit_Address.Location = new System.Drawing.Point(108, 217);
            this.textEdit_Address.Name = "textEdit_Address";
            this.textEdit_Address.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_Address.Size = new System.Drawing.Size(201, 20);
            this.textEdit_Address.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(218, 245);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Ca ";
            // 
            // slookUpEdit_PlanWork
            // 
            this.slookUpEdit_PlanWork.EditValue = "ttt";
            this.slookUpEdit_PlanWork.Location = new System.Drawing.Point(242, 241);
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
            this.slookUpEdit_PlanWork.Size = new System.Drawing.Size(67, 22);
            this.slookUpEdit_PlanWork.TabIndex = 38;
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
            // memoEdit_Notes
            // 
            this.memoEdit_Notes.Location = new System.Drawing.Point(108, 269);
            this.memoEdit_Notes.Name = "memoEdit_Notes";
            this.memoEdit_Notes.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit_Notes.Properties.Appearance.Options.UseFont = true;
            this.memoEdit_Notes.Properties.AppearanceFocused.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit_Notes.Properties.AppearanceFocused.Options.UseFont = true;
            this.memoEdit_Notes.Properties.MaxLength = 255;
            this.memoEdit_Notes.Size = new System.Drawing.Size(201, 86);
            this.memoEdit_Notes.TabIndex = 39;
            // 
            // radioButton_Male
            // 
            this.radioButton_Male.AutoSize = true;
            this.radioButton_Male.Checked = true;
            this.radioButton_Male.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Male.Location = new System.Drawing.Point(108, 116);
            this.radioButton_Male.Name = "radioButton_Male";
            this.radioButton_Male.Size = new System.Drawing.Size(50, 19);
            this.radioButton_Male.TabIndex = 46;
            this.radioButton_Male.TabStop = true;
            this.radioButton_Male.Text = "Nam";
            this.radioButton_Male.UseVisualStyleBackColor = true;
            // 
            // radioButton_Female
            // 
            this.radioButton_Female.AutoSize = true;
            this.radioButton_Female.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Female.Location = new System.Drawing.Point(188, 116);
            this.radioButton_Female.Name = "radioButton_Female";
            this.radioButton_Female.Size = new System.Drawing.Size(42, 19);
            this.radioButton_Female.TabIndex = 47;
            this.radioButton_Female.Text = "Nữ";
            this.radioButton_Female.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 15);
            this.label11.TabIndex = 45;
            this.label11.Text = "Tình trạng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 15);
            this.label12.TabIndex = 12;
            this.label12.Text = "Mức lương";
            // 
            // textEdit_Salary
            // 
            this.textEdit_Salary.Location = new System.Drawing.Point(108, 140);
            this.textEdit_Salary.Name = "textEdit_Salary";
            this.textEdit_Salary.Properties.Mask.EditMask = "n0";
            this.textEdit_Salary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_Salary.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textEdit_Salary.Size = new System.Drawing.Size(201, 20);
            this.textEdit_Salary.TabIndex = 17;
            // 
            // radioButton_Other
            // 
            this.radioButton_Other.AutoSize = true;
            this.radioButton_Other.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Other.Location = new System.Drawing.Point(255, 116);
            this.radioButton_Other.Name = "radioButton_Other";
            this.radioButton_Other.Size = new System.Drawing.Size(54, 19);
            this.radioButton_Other.TabIndex = 47;
            this.radioButton_Other.Text = "Khác";
            this.radioButton_Other.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 361);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 15);
            this.label13.TabIndex = 45;
            this.label13.Text = "Khóa";
            // 
            // slookUpEdit_Locked
            // 
            this.slookUpEdit_Locked.EditValue = "ttt";
            this.slookUpEdit_Locked.Location = new System.Drawing.Point(107, 358);
            this.slookUpEdit_Locked.Name = "slookUpEdit_Locked";
            this.slookUpEdit_Locked.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slookUpEdit_Locked.Properties.Appearance.Options.UseFont = true;
            this.slookUpEdit_Locked.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slookUpEdit_Locked.Properties.AppearanceDropDown.Options.UseFont = true;
            this.slookUpEdit_Locked.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slookUpEdit_Locked.Properties.NullText = "Chọn";
            this.slookUpEdit_Locked.Properties.PopupFormMinSize = new System.Drawing.Size(300, 0);
            this.slookUpEdit_Locked.Properties.PopupFormSize = new System.Drawing.Size(620, 0);
            this.slookUpEdit_Locked.Properties.ShowClearButton = false;
            this.slookUpEdit_Locked.Properties.ShowFooter = false;
            this.slookUpEdit_Locked.Properties.View = this.gridView1;
            this.slookUpEdit_Locked.Size = new System.Drawing.Size(202, 22);
            this.slookUpEdit_Locked.TabIndex = 38;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this._cLockeID,
            this.c_LockedName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // _cLockeID
            // 
            this._cLockeID.Caption = "Mã ";
            this._cLockeID.FieldName = "LockedID";
            this._cLockeID.Name = "_cLockeID";
            this._cLockeID.OptionsColumn.AllowEdit = false;
            this._cLockeID.OptionsColumn.AllowFocus = false;
            // 
            // c_LockedName
            // 
            this.c_LockedName.Caption = "Loại";
            this.c_LockedName.FieldName = "LockedName";
            this.c_LockedName.Name = "c_LockedName";
            this.c_LockedName.Visible = true;
            this.c_LockedName.VisibleIndex = 0;
            this.c_LockedName.Width = 534;
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(107, 394);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 31);
            this.button_Save.TabIndex = 14;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(188, 394);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 31);
            this.button_Close.TabIndex = 15;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_AddEditAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 428);
            this.Controls.Add(this.radioButton_Male);
            this.Controls.Add(this.radioButton_Other);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.radioButton_Female);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.memoEdit_Notes);
            this.Controls.Add(this.slookUpEdit_Locked);
            this.Controls.Add(this.slookUpEdit_PlanWork);
            this.Controls.Add(this.textEdit_Address);
            this.Controls.Add(this.textEdit_Phone);
            this.Controls.Add(this.textEdit_Salary);
            this.Controls.Add(this.textEdit_Email);
            this.Controls.Add(this.dateEdit_DateReceive);
            this.Controls.Add(this.dateEdit_BirthDay);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.textEdit_EmployeeCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxEdit_Right);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textEdit_EmployeeName);
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_AddEditAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_AddEditAccount";
            this.Load += new System.EventHandler(this.frm_AccountManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EmployeeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Right.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_BirthDay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_BirthDay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DateReceive.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_DateReceive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Phone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Address.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_PlanWork.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Notes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Salary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_Locked.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.TextEdit textEdit_EmployeeCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Right;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit textEdit_EmployeeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.DateEdit dateEdit_BirthDay;
        private DevExpress.XtraEditors.DateEdit dateEdit_DateReceive;
        private DevExpress.XtraEditors.TextEdit textEdit_Email;
        private DevExpress.XtraEditors.TextEdit textEdit_Phone;
        private DevExpress.XtraEditors.TextEdit textEdit_Address;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.SearchLookUpEdit slookUpEdit_PlanWork;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn c_PlanWorkID;
        private DevExpress.XtraGrid.Columns.GridColumn c_PlanWorkName;
        private DevExpress.XtraGrid.Columns.GridColumn c_StartTime;
        private DevExpress.XtraGrid.Columns.GridColumn c_EndTime;
        private DevExpress.XtraGrid.Columns.GridColumn c_Notes;
        private DevExpress.XtraEditors.MemoEdit memoEdit_Notes;
        private System.Windows.Forms.RadioButton radioButton_Male;
        private System.Windows.Forms.RadioButton radioButton_Female;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit textEdit_Salary;
        private System.Windows.Forms.RadioButton radioButton_Other;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.SearchLookUpEdit slookUpEdit_Locked;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn _cLockeID;
        private DevExpress.XtraGrid.Columns.GridColumn c_LockedName;
    }
}