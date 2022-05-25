namespace Coffee
{
    partial class frm_AddEditCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddEditCustomer));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.textEdit_BestLevel = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_NumberCard = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Email = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_CustomerName = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Phone = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Money = new DevExpress.XtraEditors.TextEdit();
            this.radioButton_CreateCard = new System.Windows.Forms.RadioButton();
            this.radioButton_LockCard = new System.Windows.Forms.RadioButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_bestLevel = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.slookUpEdit_Level = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_SmartLinkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_SmartLinkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_MoneyLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Percent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkEdit_ChangeCode = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.lbl_Customer = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BestLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NumberCard.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Email.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_CustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Phone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Money.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_Level.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ChangeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_BestLevel
            // 
            this.textEdit_BestLevel.Location = new System.Drawing.Point(228, 100);
            this.textEdit_BestLevel.Name = "textEdit_BestLevel";
            this.textEdit_BestLevel.Properties.ReadOnly = true;
            this.textEdit_BestLevel.Size = new System.Drawing.Size(108, 20);
            this.textEdit_BestLevel.TabIndex = 0;
            // 
            // textEdit_NumberCard
            // 
            this.textEdit_NumberCard.Enabled = false;
            this.textEdit_NumberCard.Location = new System.Drawing.Point(106, 101);
            this.textEdit_NumberCard.Name = "textEdit_NumberCard";
            this.textEdit_NumberCard.Size = new System.Drawing.Size(116, 20);
            this.textEdit_NumberCard.TabIndex = 0;
            // 
            // textEdit_Email
            // 
            this.textEdit_Email.Location = new System.Drawing.Point(106, 153);
            this.textEdit_Email.Name = "textEdit_Email";
            this.textEdit_Email.Size = new System.Drawing.Size(227, 20);
            this.textEdit_Email.TabIndex = 2;
            // 
            // textEdit_CustomerName
            // 
            this.textEdit_CustomerName.Location = new System.Drawing.Point(106, 127);
            this.textEdit_CustomerName.Name = "textEdit_CustomerName";
            this.textEdit_CustomerName.Size = new System.Drawing.Size(230, 20);
            this.textEdit_CustomerName.TabIndex = 1;
            // 
            // textEdit_Phone
            // 
            this.textEdit_Phone.Location = new System.Drawing.Point(106, 179);
            this.textEdit_Phone.Name = "textEdit_Phone";
            this.textEdit_Phone.Properties.Mask.EditMask = "(\\d?\\d?\\d?)\\d\\d\\d-\\d\\d\\d\\d";
            this.textEdit_Phone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.textEdit_Phone.Size = new System.Drawing.Size(175, 20);
            this.textEdit_Phone.TabIndex = 3;
            // 
            // textEdit_Money
            // 
            this.textEdit_Money.Location = new System.Drawing.Point(106, 205);
            this.textEdit_Money.Name = "textEdit_Money";
            this.textEdit_Money.Properties.Mask.EditMask = "n0";
            this.textEdit_Money.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_Money.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textEdit_Money.Properties.NullText = "0";
            this.textEdit_Money.Size = new System.Drawing.Size(175, 20);
            this.textEdit_Money.TabIndex = 4;
            // 
            // radioButton_CreateCard
            // 
            this.radioButton_CreateCard.AutoSize = true;
            this.radioButton_CreateCard.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_CreateCard.Location = new System.Drawing.Point(106, 259);
            this.radioButton_CreateCard.Name = "radioButton_CreateCard";
            this.radioButton_CreateCard.Size = new System.Drawing.Size(66, 19);
            this.radioButton_CreateCard.TabIndex = 6;
            this.radioButton_CreateCard.TabStop = true;
            this.radioButton_CreateCard.Text = "Cấp thẻ";
            this.radioButton_CreateCard.UseVisualStyleBackColor = true;
            // 
            // radioButton_LockCard
            // 
            this.radioButton_LockCard.AutoSize = true;
            this.radioButton_LockCard.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_LockCard.Location = new System.Drawing.Point(223, 259);
            this.radioButton_LockCard.Name = "radioButton_LockCard";
            this.radioButton_LockCard.Size = new System.Drawing.Size(74, 19);
            this.radioButton_LockCard.TabIndex = 7;
            this.radioButton_LockCard.TabStop = true;
            this.radioButton_LockCard.Text = "Khoá thẻ";
            this.radioButton_LockCard.UseVisualStyleBackColor = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.button_Close);
            this.panelControl1.Controls.Add(this.button_Save);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 282);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(345, 38);
            this.panelControl1.TabIndex = 2;
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = ((System.Drawing.Image)(resources.GetObject("button_Close.Image")));
            this.button_Close.Location = new System.Drawing.Point(186, 6);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 28);
            this.button_Close.TabIndex = 9;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = ((System.Drawing.Image)(resources.GetObject("button_Save.Image")));
            this.button_Save.Location = new System.Drawing.Point(106, 6);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 28);
            this.button_Save.TabIndex = 8;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // lbl_bestLevel
            // 
            this.lbl_bestLevel.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bestLevel.Location = new System.Drawing.Point(228, 79);
            this.lbl_bestLevel.Name = "lbl_bestLevel";
            this.lbl_bestLevel.Size = new System.Drawing.Size(86, 15);
            this.lbl_bestLevel.TabIndex = 3;
            this.lbl_bestLevel.Text = "Mã thẻ cao nhất";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(8, 103);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 15);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Số thẻ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(8, 130);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(90, 15);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Tên khách hàng";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(8, 155);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(31, 15);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Email";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(8, 182);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 15);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Điện thoại";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(8, 208);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(77, 15);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "Đã thanh toán";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Location = new System.Drawing.Point(8, 261);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(79, 15);
            this.labelControl7.TabIndex = 3;
            this.labelControl7.Text = "Tình trạng thẻ";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(8, 234);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(62, 15);
            this.labelControl8.TabIndex = 3;
            this.labelControl8.Text = "Cấp bậc thẻ";
            // 
            // slookUpEdit_Level
            // 
            this.slookUpEdit_Level.Location = new System.Drawing.Point(106, 232);
            this.slookUpEdit_Level.Name = "slookUpEdit_Level";
            this.slookUpEdit_Level.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slookUpEdit_Level.Properties.Appearance.Options.UseFont = true;
            this.slookUpEdit_Level.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.slookUpEdit_Level.Properties.NullText = "Chọn cấp bậc";
            this.slookUpEdit_Level.Properties.View = this.searchLookUpEdit1View;
            this.slookUpEdit_Level.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.slookUpEdit_Level_Properties_ButtonClick);
            this.slookUpEdit_Level.Size = new System.Drawing.Size(175, 22);
            this.slookUpEdit_Level.TabIndex = 5;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_SmartLinkID,
            this.c_SmartLinkName,
            this.c_MoneyLevel,
            this.c_Percent});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // c_SmartLinkID
            // 
            this.c_SmartLinkID.Caption = "Mã";
            this.c_SmartLinkID.FieldName = "SmartLinkID";
            this.c_SmartLinkID.Name = "c_SmartLinkID";
            // 
            // c_SmartLinkName
            // 
            this.c_SmartLinkName.Caption = "Cấp bậc";
            this.c_SmartLinkName.FieldName = "SmartLinkName";
            this.c_SmartLinkName.Name = "c_SmartLinkName";
            this.c_SmartLinkName.Visible = true;
            this.c_SmartLinkName.VisibleIndex = 0;
            // 
            // c_MoneyLevel
            // 
            this.c_MoneyLevel.Caption = "Mức tiền";
            this.c_MoneyLevel.FieldName = "MoneyLevel";
            this.c_MoneyLevel.Name = "c_MoneyLevel";
            this.c_MoneyLevel.Visible = true;
            this.c_MoneyLevel.VisibleIndex = 1;
            // 
            // c_Percent
            // 
            this.c_Percent.Caption = "Phần trăm chiết khấu";
            this.c_Percent.FieldName = "Percent";
            this.c_Percent.Name = "c_Percent";
            this.c_Percent.Visible = true;
            this.c_Percent.VisibleIndex = 2;
            // 
            // checkEdit_ChangeCode
            // 
            this.checkEdit_ChangeCode.Location = new System.Drawing.Point(104, 80);
            this.checkEdit_ChangeCode.Name = "checkEdit_ChangeCode";
            this.checkEdit_ChangeCode.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit_ChangeCode.Properties.Appearance.Options.UseFont = true;
            this.checkEdit_ChangeCode.Properties.Caption = "cho phép đổi số thẻ";
            this.checkEdit_ChangeCode.Size = new System.Drawing.Size(118, 19);
            this.checkEdit_ChangeCode.TabIndex = 5;
            this.checkEdit_ChangeCode.CheckedChanged += new System.EventHandler(this.checkEdit_ChangeCode_CheckedChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.pictureEdit1);
            this.panelControl2.Controls.Add(this.lbl_Customer);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(345, 73);
            this.panelControl2.TabIndex = 8;
            this.panelControl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl2_MouseDown);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.group_edit_128;
            this.pictureEdit1.Location = new System.Drawing.Point(6, 6);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(79, 61);
            this.pictureEdit1.TabIndex = 1;
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Customer.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_Customer.Location = new System.Drawing.Point(102, 30);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(179, 24);
            this.lbl_Customer.TabIndex = 0;
            this.lbl_Customer.Text = "SỬA THÀNH VIÊN";
            // 
            // frm_AddEditCustomer
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 320);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.checkEdit_ChangeCode);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbl_bestLevel);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.radioButton_LockCard);
            this.Controls.Add(this.radioButton_CreateCard);
            this.Controls.Add(this.textEdit_CustomerName);
            this.Controls.Add(this.textEdit_Money);
            this.Controls.Add(this.textEdit_Phone);
            this.Controls.Add(this.textEdit_Email);
            this.Controls.Add(this.textEdit_NumberCard);
            this.Controls.Add(this.textEdit_BestLevel);
            this.Controls.Add(this.slookUpEdit_Level);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.Name = "frm_AddEditCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_AddEditCustomer";
            this.Load += new System.EventHandler(this.frm_AddEditCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_BestLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_NumberCard.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Email.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_CustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Phone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Money.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_Level.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ChangeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_BestLevel;
        private DevExpress.XtraEditors.TextEdit textEdit_NumberCard;
        private DevExpress.XtraEditors.TextEdit textEdit_Email;
        private DevExpress.XtraEditors.TextEdit textEdit_CustomerName;
        private DevExpress.XtraEditors.TextEdit textEdit_Phone;
        private DevExpress.XtraEditors.TextEdit textEdit_Money;
        private System.Windows.Forms.RadioButton radioButton_CreateCard;
        private System.Windows.Forms.RadioButton radioButton_LockCard;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.LabelControl lbl_bestLevel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SearchLookUpEdit slookUpEdit_Level;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn c_SmartLinkID;
        private DevExpress.XtraGrid.Columns.GridColumn c_SmartLinkName;
        private DevExpress.XtraGrid.Columns.GridColumn c_MoneyLevel;
        private DevExpress.XtraGrid.Columns.GridColumn c_Percent;
        private DevExpress.XtraEditors.CheckEdit checkEdit_ChangeCode;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl lbl_Customer;

    }
}