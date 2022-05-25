namespace Coffee
{
    partial class frm_SelectProductToStock
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
            this.groupControl_Product = new DevExpress.XtraEditors.GroupControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Product = new DevExpress.XtraGrid.GridControl();
            this.gridView_Product = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_ProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_ImageIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Image = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_DVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_DVT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemMemoEdit_Notes = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemLookUpEdit_Status = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit_Skin = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemImageComboBox_DVT = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Choose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_Search = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.treeView_Menu = new System.Windows.Forms.TreeView();
            this.imageList_Product = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Product)).BeginInit();
            this.groupControl_Product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_DVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit_Notes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Skin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox_DVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Search.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl_Product
            // 
            this.groupControl_Product.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl_Product.AppearanceCaption.Options.UseFont = true;
            this.groupControl_Product.Controls.Add(this.panelControl3);
            this.groupControl_Product.Controls.Add(this.panelControl2);
            this.groupControl_Product.Controls.Add(this.panelControl1);
            this.groupControl_Product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_Product.Location = new System.Drawing.Point(174, 0);
            this.groupControl_Product.Name = "groupControl_Product";
            this.groupControl_Product.Size = new System.Drawing.Size(397, 387);
            this.groupControl_Product.TabIndex = 17;
            this.groupControl_Product.Text = "Danh Sách Sản Phẩm";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridControl_Product);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 57);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(393, 296);
            this.panelControl3.TabIndex = 2;
            // 
            // gridControl_Product
            // 
            this.gridControl_Product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Product.Location = new System.Drawing.Point(2, 2);
            this.gridControl_Product.MainView = this.gridView_Product;
            this.gridControl_Product.Name = "gridControl_Product";
            this.gridControl_Product.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit_Notes,
            this.repositoryItemLookUpEdit_Status,
            this.repositoryItemLookUpEdit_Skin,
            this.repositoryItemImageComboBox_DVT,
            this.repositoryItemLookUpEdit_DVT});
            this.gridControl_Product.ShowOnlyPredefinedDetails = true;
            this.gridControl_Product.Size = new System.Drawing.Size(389, 292);
            this.gridControl_Product.TabIndex = 8;
            this.gridControl_Product.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Product});
            this.gridControl_Product.DoubleClick += new System.EventHandler(this.gridControl_Product_DoubleClick);
            // 
            // gridView_Product
            // 
            this.gridView_Product.Appearance.FocusedRow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Product.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView_Product.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Product.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView_Product.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Product.Appearance.Row.Options.UseFont = true;
            this.gridView_Product.Appearance.SelectedRow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Product.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView_Product.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView_Product.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView_Product.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.gridView_Product.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_Product.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_ProductID,
            this.c_ProductName,
            this.c_ProductCode,
            this.c_ImageIndex,
            this.c_Image,
            this.c_DVT});
            this.gridView_Product.GridControl = this.gridControl_Product;
            this.gridView_Product.Name = "gridView_Product";
            this.gridView_Product.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_Product.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView_Product.OptionsView.ShowAutoFilterRow = true;
            this.gridView_Product.OptionsView.ShowGroupPanel = false;
            this.gridView_Product.RowHeight = 22;
            // 
            // c_ProductID
            // 
            this.c_ProductID.Caption = "Mã sản phẩm";
            this.c_ProductID.FieldName = "ProductID";
            this.c_ProductID.Name = "c_ProductID";
            this.c_ProductID.OptionsColumn.AllowEdit = false;
            this.c_ProductID.OptionsColumn.AllowFocus = false;
            this.c_ProductID.Width = 69;
            // 
            // c_ProductName
            // 
            this.c_ProductName.Caption = "Tên sản phẩm";
            this.c_ProductName.FieldName = "ProductName";
            this.c_ProductName.Name = "c_ProductName";
            this.c_ProductName.OptionsColumn.AllowEdit = false;
            this.c_ProductName.OptionsColumn.AllowFocus = false;
            this.c_ProductName.Visible = true;
            this.c_ProductName.VisibleIndex = 1;
            this.c_ProductName.Width = 646;
            // 
            // c_ProductCode
            // 
            this.c_ProductCode.Caption = "Mã SP";
            this.c_ProductCode.FieldName = "ProductCode";
            this.c_ProductCode.Name = "c_ProductCode";
            this.c_ProductCode.OptionsColumn.AllowEdit = false;
            this.c_ProductCode.OptionsColumn.AllowFocus = false;
            this.c_ProductCode.Width = 101;
            // 
            // c_ImageIndex
            // 
            this.c_ImageIndex.Caption = "Mã icon";
            this.c_ImageIndex.FieldName = "ImageIndex";
            this.c_ImageIndex.Name = "c_ImageIndex";
            // 
            // c_Image
            // 
            this.c_Image.Caption = "Biểu tượng";
            this.c_Image.FieldName = "Image";
            this.c_Image.Name = "c_Image";
            this.c_Image.OptionsColumn.AllowEdit = false;
            this.c_Image.OptionsColumn.AllowFocus = false;
            this.c_Image.Visible = true;
            this.c_Image.VisibleIndex = 0;
            this.c_Image.Width = 241;
            // 
            // c_DVT
            // 
            this.c_DVT.Caption = "Đơn vị tính";
            this.c_DVT.ColumnEdit = this.repositoryItemLookUpEdit_DVT;
            this.c_DVT.FieldName = "DVT";
            this.c_DVT.Name = "c_DVT";
            this.c_DVT.OptionsColumn.AllowEdit = false;
            this.c_DVT.OptionsColumn.AllowFocus = false;
            this.c_DVT.Visible = true;
            this.c_DVT.VisibleIndex = 2;
            this.c_DVT.Width = 293;
            // 
            // repositoryItemLookUpEdit_DVT
            // 
            this.repositoryItemLookUpEdit_DVT.AutoHeight = false;
            this.repositoryItemLookUpEdit_DVT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_DVT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Mã", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DVT", "Đơn vị tính")});
            this.repositoryItemLookUpEdit_DVT.Name = "repositoryItemLookUpEdit_DVT";
            // 
            // repositoryItemMemoEdit_Notes
            // 
            this.repositoryItemMemoEdit_Notes.Name = "repositoryItemMemoEdit_Notes";
            // 
            // repositoryItemLookUpEdit_Status
            // 
            this.repositoryItemLookUpEdit_Status.AutoHeight = false;
            this.repositoryItemLookUpEdit_Status.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Status.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusName", "Trạng thái"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StatusID", "Mã trạng thái", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.repositoryItemLookUpEdit_Status.Name = "repositoryItemLookUpEdit_Status";
            // 
            // repositoryItemLookUpEdit_Skin
            // 
            this.repositoryItemLookUpEdit_Skin.AutoHeight = false;
            this.repositoryItemLookUpEdit_Skin.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Skin.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SkinID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SkinName", "Phân loại")});
            this.repositoryItemLookUpEdit_Skin.Name = "repositoryItemLookUpEdit_Skin";
            // 
            // repositoryItemImageComboBox_DVT
            // 
            this.repositoryItemImageComboBox_DVT.AutoHeight = false;
            this.repositoryItemImageComboBox_DVT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox_DVT.Name = "repositoryItemImageComboBox_DVT";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btn_Close);
            this.panelControl2.Controls.Add(this.btn_Choose);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(2, 353);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(393, 32);
            this.panelControl2.TabIndex = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.btn_Close.Location = new System.Drawing.Point(256, 5);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.Text = "Thoát";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Choose
            // 
            this.btn_Choose.Image = global::Coffee.Properties.Resources.add_products;
            this.btn_Choose.Location = new System.Drawing.Point(175, 5);
            this.btn_Choose.Name = "btn_Choose";
            this.btn_Choose.Size = new System.Drawing.Size(75, 23);
            this.btn_Choose.TabIndex = 0;
            this.btn_Choose.Text = "Chọn";
            this.btn_Choose.Click += new System.EventHandler(this.btn_Choose_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.textEdit_Search);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(393, 34);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tìm kiếm";
            // 
            // textEdit_Search
            // 
            this.textEdit_Search.Location = new System.Drawing.Point(51, 5);
            this.textEdit_Search.Name = "textEdit_Search";
            this.textEdit_Search.Size = new System.Drawing.Size(199, 20);
            this.textEdit_Search.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.treeView_Menu);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(174, 387);
            this.groupControl1.TabIndex = 16;
            this.groupControl1.Text = "Phân loại";
            // 
            // treeView_Menu
            // 
            this.treeView_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Menu.ImageIndex = 0;
            this.treeView_Menu.ImageList = this.imageList_Product;
            this.treeView_Menu.Location = new System.Drawing.Point(2, 23);
            this.treeView_Menu.Name = "treeView_Menu";
            this.treeView_Menu.SelectedImageIndex = 0;
            this.treeView_Menu.Size = new System.Drawing.Size(170, 362);
            this.treeView_Menu.TabIndex = 0;
            this.treeView_Menu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Menu_NodeMouseClick);
            // 
            // imageList_Product
            // 
            this.imageList_Product.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_Product.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_Product.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frm_SelectProductToStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 387);
            this.Controls.Add(this.groupControl_Product);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.Name = "frm_SelectProductToStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_SelectProductToStock";
            this.Load += new System.EventHandler(this.frm_SelectProductToStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Product)).EndInit();
            this.groupControl_Product.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_DVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit_Notes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Skin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox_DVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Search.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl_Product;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridControl_Product;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Product;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductID;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductName;
        private DevExpress.XtraGrid.Columns.GridColumn c_ProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn c_ImageIndex;
        private DevExpress.XtraGrid.Columns.GridColumn c_Image;
        private DevExpress.XtraGrid.Columns.GridColumn c_DVT;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_DVT;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit_Notes;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Skin;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox_DVT;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_Choose;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit_Search;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TreeView treeView_Menu;
        private System.Windows.Forms.ImageList imageList_Product;
    }
}