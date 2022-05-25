namespace Coffee
{
    partial class frm_AddEditOrder
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
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Update = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl_ChangeProduct = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_OrderDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView_OrderDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this._ProductNae = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Quantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.slookUpEdit_Product = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_MadeInID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_MadeInName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Notes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinEdit_QuantityChange = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Quantity = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_ChangeProduct)).BeginInit();
            this.panelControl_ChangeProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_OrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_Product.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_QuantityChange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(34, 79);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 15);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Số lượng hiện có";
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(34, 3);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 29);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(196, 3);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 29);
            this.button_Close.TabIndex = 7;
            this.button_Close.Text = "Hủy";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.button_Close);
            this.panelControl1.Controls.Add(this.btn_Update);
            this.panelControl1.Controls.Add(this.button_Save);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 359);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(294, 35);
            this.panelControl1.TabIndex = 41;
            // 
            // btn_Update
            // 
            this.btn_Update.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Appearance.Options.UseFont = true;
            this.btn_Update.Image = global::Coffee.Properties.Resources.Refresh;
            this.btn_Update.Location = new System.Drawing.Point(115, 3);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 29);
            this.btn_Update.TabIndex = 6;
            this.btn_Update.Text = "Cập nhật";
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // panelControl_ChangeProduct
            // 
            this.panelControl_ChangeProduct.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelControl_ChangeProduct.Appearance.Options.UseBackColor = true;
            this.panelControl_ChangeProduct.Controls.Add(this.gridControl_OrderDetail);
            this.panelControl_ChangeProduct.Controls.Add(this.btn_Ok);
            this.panelControl_ChangeProduct.Controls.Add(this.slookUpEdit_Product);
            this.panelControl_ChangeProduct.Controls.Add(this.spinEdit_QuantityChange);
            this.panelControl_ChangeProduct.Controls.Add(this.labelControl3);
            this.panelControl_ChangeProduct.Controls.Add(this.labelControl2);
            this.panelControl_ChangeProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_ChangeProduct.Location = new System.Drawing.Point(0, 105);
            this.panelControl_ChangeProduct.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl_ChangeProduct.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl_ChangeProduct.Name = "panelControl_ChangeProduct";
            this.panelControl_ChangeProduct.Size = new System.Drawing.Size(294, 254);
            this.panelControl_ChangeProduct.TabIndex = 42;
            // 
            // gridControl_OrderDetail
            // 
            this.gridControl_OrderDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl_OrderDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl_OrderDetail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl_OrderDetail.Location = new System.Drawing.Point(2, 60);
            this.gridControl_OrderDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gridControl_OrderDetail.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl_OrderDetail.MainView = this.gridView_OrderDetail;
            this.gridControl_OrderDetail.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl_OrderDetail.Name = "gridControl_OrderDetail";
            this.gridControl_OrderDetail.Size = new System.Drawing.Size(290, 192);
            this.gridControl_OrderDetail.TabIndex = 4;
            this.gridControl_OrderDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_OrderDetail});
            // 
            // gridView_OrderDetail
            // 
            this.gridView_OrderDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cProductID,
            this._ProductNae,
            this.c_Quantity});
            this.gridView_OrderDetail.GridControl = this.gridControl_OrderDetail;
            this.gridView_OrderDetail.Name = "gridView_OrderDetail";
            this.gridView_OrderDetail.OptionsView.ShowGroupPanel = false;
            this.gridView_OrderDetail.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView_OrderDetail_RowClick);
            // 
            // cProductID
            // 
            this.cProductID.Caption = "Mã sản phẩm";
            this.cProductID.FieldName = "ProductID";
            this.cProductID.Name = "cProductID";
            // 
            // _ProductNae
            // 
            this._ProductNae.Caption = "Tên";
            this._ProductNae.FieldName = "ProductName";
            this._ProductNae.Name = "_ProductNae";
            this._ProductNae.OptionsColumn.AllowEdit = false;
            this._ProductNae.OptionsColumn.AllowFocus = false;
            this._ProductNae.Visible = true;
            this._ProductNae.VisibleIndex = 0;
            this._ProductNae.Width = 689;
            // 
            // c_Quantity
            // 
            this.c_Quantity.Caption = "Số lượng";
            this.c_Quantity.FieldName = "Quantity";
            this.c_Quantity.Name = "c_Quantity";
            this.c_Quantity.OptionsColumn.AllowEdit = false;
            this.c_Quantity.OptionsColumn.AllowFocus = false;
            this.c_Quantity.Visible = true;
            this.c_Quantity.VisibleIndex = 1;
            this.c_Quantity.Width = 367;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ok.Appearance.Options.UseFont = true;
            this.btn_Ok.Image = global::Coffee.Properties.Resources.Fall;
            this.btn_Ok.Location = new System.Drawing.Point(207, 33);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(59, 20);
            this.btn_Ok.TabIndex = 3;
            this.btn_Ok.Text = "Chọn";
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // slookUpEdit_Product
            // 
            this.slookUpEdit_Product.EditValue = "";
            this.slookUpEdit_Product.Location = new System.Drawing.Point(74, 5);
            this.slookUpEdit_Product.Name = "slookUpEdit_Product";
            this.slookUpEdit_Product.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slookUpEdit_Product.Properties.Appearance.Options.UseFont = true;
            this.slookUpEdit_Product.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slookUpEdit_Product.Properties.AppearanceDropDown.Options.UseFont = true;
            this.slookUpEdit_Product.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slookUpEdit_Product.Properties.NullText = "Không có dữ liệu";
            this.slookUpEdit_Product.Properties.PopupFormMinSize = new System.Drawing.Size(300, 0);
            this.slookUpEdit_Product.Properties.PopupFormSize = new System.Drawing.Size(620, 0);
            this.slookUpEdit_Product.Properties.ShowClearButton = false;
            this.slookUpEdit_Product.Properties.ShowFooter = false;
            this.slookUpEdit_Product.Properties.View = this.searchLookUpEdit1View;
            this.slookUpEdit_Product.Size = new System.Drawing.Size(208, 22);
            this.slookUpEdit_Product.TabIndex = 1;
            this.slookUpEdit_Product.EditValueChanged += new System.EventHandler(this.slookUpEdit_Product_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.searchLookUpEdit1View.Appearance.HeaderPanel.Options.UseFont = true;
            this.searchLookUpEdit1View.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.searchLookUpEdit1View.Appearance.Row.Options.UseFont = true;
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_MadeInID,
            this.c_MadeInName,
            this.c_ProductID,
            this.c_ProductName,
            this.c_ShortName,
            this.c_ProductCode,
            this.c_Price,
            this.c_Status,
            this.c_Notes});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // c_MadeInID
            // 
            this.c_MadeInID.Caption = "Mã xuất xứ";
            this.c_MadeInID.FieldName = "MadeInID";
            this.c_MadeInID.Name = "c_MadeInID";
            this.c_MadeInID.OptionsColumn.AllowEdit = false;
            this.c_MadeInID.OptionsColumn.AllowFocus = false;
            // 
            // c_MadeInName
            // 
            this.c_MadeInName.Caption = "Tên xuất xứ";
            this.c_MadeInName.FieldName = "MadeInName";
            this.c_MadeInName.Name = "c_MadeInName";
            this.c_MadeInName.Width = 143;
            // 
            // c_ProductID
            // 
            this.c_ProductID.Caption = "Mã Sản Phẩm";
            this.c_ProductID.FieldName = "ProductID";
            this.c_ProductID.Name = "c_ProductID";
            // 
            // c_ProductName
            // 
            this.c_ProductName.Caption = "Tên Sản Phẩm";
            this.c_ProductName.FieldName = "ProductName";
            this.c_ProductName.Name = "c_ProductName";
            this.c_ProductName.Visible = true;
            this.c_ProductName.VisibleIndex = 0;
            this.c_ProductName.Width = 371;
            // 
            // c_ShortName
            // 
            this.c_ShortName.Caption = "Tên Viết Tắt";
            this.c_ShortName.FieldName = "ShortName";
            this.c_ShortName.Name = "c_ShortName";
            this.c_ShortName.Visible = true;
            this.c_ShortName.VisibleIndex = 1;
            this.c_ShortName.Width = 325;
            // 
            // c_ProductCode
            // 
            this.c_ProductCode.Caption = "ProductCode";
            this.c_ProductCode.FieldName = "ProductCode";
            this.c_ProductCode.Name = "c_ProductCode";
            // 
            // c_Price
            // 
            this.c_Price.Caption = "Giá";
            this.c_Price.FieldName = "Price";
            this.c_Price.Name = "c_Price";
            this.c_Price.Visible = true;
            this.c_Price.VisibleIndex = 2;
            this.c_Price.Width = 484;
            // 
            // c_Status
            // 
            this.c_Status.Caption = "Trạng  thái";
            this.c_Status.FieldName = "Status";
            this.c_Status.Name = "c_Status";
            // 
            // c_Notes
            // 
            this.c_Notes.Caption = "Ghi chú";
            this.c_Notes.FieldName = "Notes";
            this.c_Notes.Name = "c_Notes";
            // 
            // spinEdit_QuantityChange
            // 
            this.spinEdit_QuantityChange.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_QuantityChange.Location = new System.Drawing.Point(74, 33);
            this.spinEdit_QuantityChange.Name = "spinEdit_QuantityChange";
            this.spinEdit_QuantityChange.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_QuantityChange.Properties.DisplayFormat.FormatString = "d";
            this.spinEdit_QuantityChange.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_QuantityChange.Properties.Mask.EditMask = "d";
            this.spinEdit_QuantityChange.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spinEdit_QuantityChange.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_QuantityChange.Size = new System.Drawing.Size(121, 20);
            this.spinEdit_QuantityChange.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(12, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 15);
            this.labelControl3.TabIndex = 43;
            this.labelControl3.Text = "Số lượng";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(12, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 15);
            this.labelControl2.TabIndex = 44;
            this.labelControl2.Text = "Chọn món";
            // 
            // lbl_Quantity
            // 
            this.lbl_Quantity.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Quantity.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_Quantity.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbl_Quantity.Location = new System.Drawing.Point(147, 74);
            this.lbl_Quantity.Name = "lbl_Quantity";
            this.lbl_Quantity.Size = new System.Drawing.Size(11, 24);
            this.lbl_Quantity.TabIndex = 43;
            this.lbl_Quantity.Text = "0";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.pictureEdit1);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(294, 66);
            this.panelControl2.TabIndex = 44;
            this.panelControl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl2_MouseDown);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.Actions_svn_update_icon;
            this.pictureEdit1.Location = new System.Drawing.Point(6, 4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(71, 57);
            this.pictureEdit1.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl4.Location = new System.Drawing.Point(97, 27);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(93, 24);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "ĐỔI MÓN";
            // 
            // frm_AddEditOrder
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 394);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.lbl_Quantity);
            this.Controls.Add(this.panelControl_ChangeProduct);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.Name = "frm_AddEditOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_AddEditOrder";
            this.Load += new System.EventHandler(this.frm_AddEditOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_ChangeProduct)).EndInit();
            this.panelControl_ChangeProduct.ResumeLayout(false);
            this.panelControl_ChangeProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_OrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slookUpEdit_Product.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_QuantityChange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl_ChangeProduct;
        private DevExpress.XtraEditors.SearchLookUpEdit slookUpEdit_Product;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn c_MadeInID;
        private DevExpress.XtraGrid.Columns.GridColumn c_MadeInName;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn c_ShortName;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn c_Price;
        private DevExpress.XtraGrid.Columns.GridColumn c_Status;
        private DevExpress.XtraGrid.Columns.GridColumn c_Notes;
        private DevExpress.XtraEditors.SpinEdit spinEdit_QuantityChange;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridControl_OrderDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_OrderDetail;
        private DevExpress.XtraGrid.Columns.GridColumn cProductID;
        private DevExpress.XtraGrid.Columns.GridColumn _ProductNae;
        private DevExpress.XtraGrid.Columns.GridColumn c_Quantity;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.LabelControl lbl_Quantity;
        private DevExpress.XtraEditors.SimpleButton btn_Update;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;

    }
}