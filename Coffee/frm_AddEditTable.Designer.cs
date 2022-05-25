namespace Coffee
{
    partial class frm_AddEditTable
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
            this.radioButton_Running = new System.Windows.Forms.RadioButton();
            this.radioButton_Stop = new System.Windows.Forms.RadioButton();
            this.textEdit_TableName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.slookUpEdit_Area = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.c_AreaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_AreaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_Area.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton_Running
            // 
            this.radioButton_Running.AutoSize = true;
            this.radioButton_Running.Checked = true;
            this.radioButton_Running.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Running.Location = new System.Drawing.Point(101, 103);
            this.radioButton_Running.Name = "radioButton_Running";
            this.radioButton_Running.Size = new System.Drawing.Size(84, 19);
            this.radioButton_Running.TabIndex = 3;
            this.radioButton_Running.TabStop = true;
            this.radioButton_Running.Text = "Đang dùng";
            this.radioButton_Running.UseVisualStyleBackColor = true;
            // 
            // radioButton_Stop
            // 
            this.radioButton_Stop.AutoSize = true;
            this.radioButton_Stop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Stop.Location = new System.Drawing.Point(216, 104);
            this.radioButton_Stop.Name = "radioButton_Stop";
            this.radioButton_Stop.Size = new System.Drawing.Size(80, 19);
            this.radioButton_Stop.TabIndex = 4;
            this.radioButton_Stop.Text = "Tạm dừng";
            this.radioButton_Stop.UseVisualStyleBackColor = true;
            // 
            // textEdit_TableName
            // 
            this.textEdit_TableName.Location = new System.Drawing.Point(101, 49);
            this.textEdit_TableName.Name = "textEdit_TableName";
            this.textEdit_TableName.Properties.Mask.EditMask = "[a-zA-Z]\\w+";
            this.textEdit_TableName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEdit_TableName.Properties.MaxLength = 10;
            this.textEdit_TableName.Size = new System.Drawing.Size(233, 20);
            this.textEdit_TableName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tình trạng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Tên bàn";
            // 
            // slookUpEdit_Area
            // 
            this.slookUpEdit_Area.EditValue = "";
            this.slookUpEdit_Area.Location = new System.Drawing.Point(101, 75);
            this.slookUpEdit_Area.Name = "slookUpEdit_Area";
            this.slookUpEdit_Area.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slookUpEdit_Area.Properties.Appearance.Options.UseFont = true;
            this.slookUpEdit_Area.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slookUpEdit_Area.Properties.AppearanceDropDown.Options.UseFont = true;
            this.slookUpEdit_Area.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.slookUpEdit_Area.Properties.NullText = "Không có dữ liệu";
            this.slookUpEdit_Area.Properties.PopupFormMinSize = new System.Drawing.Size(300, 0);
            this.slookUpEdit_Area.Properties.PopupFormSize = new System.Drawing.Size(620, 0);
            this.slookUpEdit_Area.Properties.ShowClearButton = false;
            this.slookUpEdit_Area.Properties.ShowFooter = false;
            this.slookUpEdit_Area.Properties.View = this.searchLookUpEdit1View;
            this.slookUpEdit_Area.Size = new System.Drawing.Size(233, 22);
            this.slookUpEdit_Area.TabIndex = 2;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_AreaID,
            this.c_AreaCode});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(6, 78);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 15);
            this.labelControl4.TabIndex = 36;
            this.labelControl4.Text = "Khu vực";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(337, 46);
            this.panelControl1.TabIndex = 37;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl1.Location = new System.Drawing.Point(91, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "BÀN";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.Order_Table;
            this.pictureEdit1.Location = new System.Drawing.Point(12, 1);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(73, 40);
            this.pictureEdit1.TabIndex = 1;
            // 
            // c_AreaID
            // 
            this.c_AreaID.Caption = "Mã khu vực";
            this.c_AreaID.FieldName = "AreaID";
            this.c_AreaID.Name = "c_AreaID";
            this.c_AreaID.OptionsColumn.AllowEdit = false;
            this.c_AreaID.OptionsColumn.AllowFocus = false;
            // 
            // c_AreaCode
            // 
            this.c_AreaCode.Caption = "Tên khu vực";
            this.c_AreaCode.FieldName = "AreaCode";
            this.c_AreaCode.Name = "c_AreaCode";
            this.c_AreaCode.Visible = true;
            this.c_AreaCode.VisibleIndex = 0;
            this.c_AreaCode.Width = 143;
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(101, 135);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 31);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(182, 135);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 31);
            this.button_Close.TabIndex = 6;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_AddEditTable
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 169);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.slookUpEdit_Area);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.radioButton_Running);
            this.Controls.Add(this.radioButton_Stop);
            this.Controls.Add(this.textEdit_TableName);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Dark Side";
            this.Name = "frm_AddEditTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_AddEditTable";
            this.Load += new System.EventHandler(this.frm_AddEditTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_TableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_Area.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_Running;
        private System.Windows.Forms.RadioButton radioButton_Stop;
        private DevExpress.XtraEditors.TextEdit textEdit_TableName;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SearchLookUpEdit slookUpEdit_Area;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn c_AreaID;
        private DevExpress.XtraGrid.Columns.GridColumn c_AreaCode;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}