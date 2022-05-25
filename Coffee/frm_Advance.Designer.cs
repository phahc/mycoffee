namespace Coffee
{
    partial class frm_Advance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Advance));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.treeView_Employee = new System.Windows.Forms.TreeView();
            this.imageList_Employee = new System.Windows.Forms.ImageList(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_ExistMoney = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Off = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Advanced = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl_Advance = new DevExpress.XtraEditors.GroupControl();
            this.gridControl_Advance = new DevExpress.XtraGrid.GridControl();
            this.gridView_Advance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_EmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Reason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Money = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Notes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_MoneyValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.button_Update = new DevExpress.XtraEditors.SimpleButton();
            this.button_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.button_Add = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Advance)).BeginInit();
            this.groupControl_Advance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Advance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Advance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.treeView_Employee);
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(225, 487);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Nhân viên";
            // 
            // treeView_Employee
            // 
            this.treeView_Employee.BackColor = System.Drawing.SystemColors.MenuBar;
            this.treeView_Employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Employee.ImageIndex = 0;
            this.treeView_Employee.ImageList = this.imageList_Employee;
            this.treeView_Employee.Location = new System.Drawing.Point(2, 59);
            this.treeView_Employee.Name = "treeView_Employee";
            this.treeView_Employee.SelectedImageIndex = 0;
            this.treeView_Employee.Size = new System.Drawing.Size(221, 426);
            this.treeView_Employee.TabIndex = 1;
            this.treeView_Employee.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Employee_NodeMouseClick);
            // 
            // imageList_Employee
            // 
            this.imageList_Employee.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Employee.ImageStream")));
            this.imageList_Employee.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Employee.Images.SetKeyName(0, "Male.png");
            this.imageList_Employee.Images.SetKeyName(1, "Female.png");
            this.imageList_Employee.Images.SetKeyName(2, "People.png");
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.textEdit1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 23);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(221, 36);
            this.panelControl2.TabIndex = 0;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "Tìm kiếm...";
            this.textEdit1.Location = new System.Drawing.Point(10, 7);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new System.Drawing.Size(206, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.lbl_ExistMoney);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.lbl_Off);
            this.groupControl2.Controls.Add(this.lbl_Advanced);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(2, 23);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(549, 91);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Thông tin";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(463, 72);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(91, 15);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Đơn vị tiền tệ: vnđ";
            // 
            // lbl_ExistMoney
            // 
            this.lbl_ExistMoney.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ExistMoney.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_ExistMoney.Location = new System.Drawing.Point(89, 62);
            this.lbl_ExistMoney.Name = "lbl_ExistMoney";
            this.lbl_ExistMoney.Size = new System.Drawing.Size(8, 19);
            this.lbl_ExistMoney.TabIndex = 0;
            this.lbl_ExistMoney.Text = "0";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl2.Location = new System.Drawing.Point(18, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 19);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Còn lại";
            // 
            // lbl_Off
            // 
            this.lbl_Off.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Off.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_Off.Location = new System.Drawing.Point(397, 27);
            this.lbl_Off.Name = "lbl_Off";
            this.lbl_Off.Size = new System.Drawing.Size(8, 19);
            this.lbl_Off.TabIndex = 0;
            this.lbl_Off.Text = "0";
            // 
            // lbl_Advanced
            // 
            this.lbl_Advanced.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Advanced.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbl_Advanced.Location = new System.Drawing.Point(89, 29);
            this.lbl_Advanced.Name = "lbl_Advanced";
            this.lbl_Advanced.Size = new System.Drawing.Size(8, 19);
            this.lbl_Advanced.TabIndex = 0;
            this.lbl_Advanced.Text = "0";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl3.Location = new System.Drawing.Point(18, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 19);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Đã ứng";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl1.Location = new System.Drawing.Point(226, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(165, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Số ngày nghỉ không phép";
            // 
            // groupControl_Advance
            // 
            this.groupControl_Advance.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Advance.AppearanceCaption.Options.UseFont = true;
            this.groupControl_Advance.Controls.Add(this.gridControl_Advance);
            this.groupControl_Advance.Controls.Add(this.groupControl2);
            this.groupControl_Advance.Controls.Add(this.panelControl1);
            this.groupControl_Advance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_Advance.Location = new System.Drawing.Point(3, 62);
            this.groupControl_Advance.Name = "groupControl_Advance";
            this.groupControl_Advance.Size = new System.Drawing.Size(553, 422);
            this.groupControl_Advance.TabIndex = 2;
            this.groupControl_Advance.Text = "Chi tiết ứng lương";
            // 
            // gridControl_Advance
            // 
            this.gridControl_Advance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Advance.Location = new System.Drawing.Point(2, 114);
            this.gridControl_Advance.MainView = this.gridView_Advance;
            this.gridControl_Advance.Name = "gridControl_Advance";
            this.gridControl_Advance.Size = new System.Drawing.Size(549, 267);
            this.gridControl_Advance.TabIndex = 1;
            this.gridControl_Advance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Advance});
            this.gridControl_Advance.DoubleClick += new System.EventHandler(this.gridControl_Advance_DoubleClick);
            // 
            // gridView_Advance
            // 
            this.gridView_Advance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_EmployeeID,
            this.c_Date,
            this.c_Reason,
            this.c_Money,
            this.c_Notes,
            this.c_MoneyValue});
            this.gridView_Advance.GridControl = this.gridControl_Advance;
            this.gridView_Advance.Name = "gridView_Advance";
            this.gridView_Advance.OptionsView.ShowGroupPanel = false;
            // 
            // c_EmployeeID
            // 
            this.c_EmployeeID.Caption = "Mã NV";
            this.c_EmployeeID.FieldName = "EmployeeID";
            this.c_EmployeeID.Name = "c_EmployeeID";
            this.c_EmployeeID.OptionsColumn.AllowEdit = false;
            this.c_EmployeeID.OptionsColumn.AllowFocus = false;
            this.c_EmployeeID.Visible = true;
            this.c_EmployeeID.VisibleIndex = 0;
            this.c_EmployeeID.Width = 69;
            // 
            // c_Date
            // 
            this.c_Date.Caption = "Ngày ứng";
            this.c_Date.FieldName = "Date";
            this.c_Date.Name = "c_Date";
            this.c_Date.OptionsColumn.AllowEdit = false;
            this.c_Date.OptionsColumn.AllowFocus = false;
            this.c_Date.Visible = true;
            this.c_Date.VisibleIndex = 2;
            this.c_Date.Width = 118;
            // 
            // c_Reason
            // 
            this.c_Reason.Caption = "Lý do";
            this.c_Reason.FieldName = "Reason";
            this.c_Reason.Name = "c_Reason";
            this.c_Reason.OptionsColumn.AllowEdit = false;
            this.c_Reason.OptionsColumn.AllowFocus = false;
            this.c_Reason.Visible = true;
            this.c_Reason.VisibleIndex = 3;
            this.c_Reason.Width = 123;
            // 
            // c_Money
            // 
            this.c_Money.Caption = "Số tiền";
            this.c_Money.FieldName = "Money";
            this.c_Money.Name = "c_Money";
            this.c_Money.OptionsColumn.AllowEdit = false;
            this.c_Money.OptionsColumn.AllowFocus = false;
            this.c_Money.Visible = true;
            this.c_Money.VisibleIndex = 1;
            this.c_Money.Width = 118;
            // 
            // c_Notes
            // 
            this.c_Notes.Caption = "Ghi chú";
            this.c_Notes.FieldName = "Notes";
            this.c_Notes.Name = "c_Notes";
            this.c_Notes.OptionsColumn.AllowEdit = false;
            this.c_Notes.OptionsColumn.AllowFocus = false;
            this.c_Notes.Visible = true;
            this.c_Notes.VisibleIndex = 4;
            // 
            // c_MoneyValue
            // 
            this.c_MoneyValue.Caption = "Số tiền";
            this.c_MoneyValue.FieldName = "MoneyValue";
            this.c_MoneyValue.Name = "c_MoneyValue";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button_Close);
            this.panelControl1.Controls.Add(this.button_Update);
            this.panelControl1.Controls.Add(this.button_Delete);
            this.panelControl1.Controls.Add(this.button_Add);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 381);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(549, 39);
            this.panelControl1.TabIndex = 0;
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = ((System.Drawing.Image)(resources.GetObject("button_Close.Image")));
            this.button_Close.Location = new System.Drawing.Point(469, 5);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 29);
            this.button_Close.TabIndex = 12;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Update
            // 
            this.button_Update.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Update.Appearance.Options.UseFont = true;
            this.button_Update.Image = ((System.Drawing.Image)(resources.GetObject("button_Update.Image")));
            this.button_Update.Location = new System.Drawing.Point(233, 5);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(75, 29);
            this.button_Update.TabIndex = 10;
            this.button_Update.Text = "Sửa";
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Delete.Appearance.Options.UseFont = true;
            this.button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("button_Delete.Image")));
            this.button_Delete.Location = new System.Drawing.Point(314, 5);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 29);
            this.button_Delete.TabIndex = 11;
            this.button_Delete.Text = "Xóa";
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Add
            // 
            this.button_Add.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.Appearance.Options.UseFont = true;
            this.button_Add.Image = ((System.Drawing.Image)(resources.GetObject("button_Add.Image")));
            this.button_Add.Location = new System.Drawing.Point(152, 5);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 29);
            this.button_Add.TabIndex = 9;
            this.button_Add.Text = "Thêm";
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl_Advance, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(225, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.11499F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.88501F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 487);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.Controls.Add(this.pictureEdit1);
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 3);
            this.panelControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(553, 53);
            this.panelControl3.TabIndex = 3;
            this.panelControl3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl3_MouseDown);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.money_3;
            this.pictureEdit1.Location = new System.Drawing.Point(5, 4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(75, 46);
            this.pictureEdit1.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl4.Location = new System.Drawing.Point(91, 22);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(131, 24);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "ỨNG LƯƠNG";
            // 
            // frm_Advance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 487);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupControl1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Advance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Advance";
            this.Load += new System.EventHandler(this.frm_Advance_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_Advance_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Advance)).EndInit();
            this.groupControl_Advance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Advance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Advance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl lbl_ExistMoney;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbl_Advanced;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl_Advance;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton button_Update;
        private DevExpress.XtraEditors.SimpleButton button_Delete;
        private DevExpress.XtraEditors.SimpleButton button_Add;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.GridControl gridControl_Advance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Advance;
        private DevExpress.XtraGrid.Columns.GridColumn c_EmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn c_Date;
        private DevExpress.XtraGrid.Columns.GridColumn c_Reason;
        private DevExpress.XtraGrid.Columns.GridColumn c_Money;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private System.Windows.Forms.TreeView treeView_Employee;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.ImageList imageList_Employee;
        private DevExpress.XtraGrid.Columns.GridColumn c_Notes;
        private DevExpress.XtraEditors.LabelControl lbl_Off;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn c_MoneyValue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}