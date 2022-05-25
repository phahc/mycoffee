namespace Coffee
{
    partial class frm_ViewOrderDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ViewOrderDetail));
            this.gridControl_OrderDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView_OrderDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_promote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_OrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_OrderDetail
            // 
            this.gridControl_OrderDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl_OrderDetail.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl_OrderDetail.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl_OrderDetail.Location = new System.Drawing.Point(0, 0);
            this.gridControl_OrderDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.gridControl_OrderDetail.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl_OrderDetail.MainView = this.gridView_OrderDetail;
            this.gridControl_OrderDetail.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl_OrderDetail.Name = "gridControl_OrderDetail";
            this.gridControl_OrderDetail.Size = new System.Drawing.Size(605, 276);
            this.gridControl_OrderDetail.TabIndex = 17;
            this.gridControl_OrderDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_OrderDetail});
            // 
            // gridView_OrderDetail
            // 
            this.gridView_OrderDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.c_Date,
            this.c_Price,
            this.c_promote});
            this.gridView_OrderDetail.GridControl = this.gridControl_OrderDetail;
            this.gridView_OrderDetail.Name = "gridView_OrderDetail";
            this.gridView_OrderDetail.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView_OrderDetail.OptionsView.ShowGroupPanel = false;
            this.gridView_OrderDetail.OptionsView.ShowViewCaption = true;
            this.gridView_OrderDetail.ViewCaption = "Chi tiết";
            this.gridView_OrderDetail.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView_OrderDetail_RowCellStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mã đơn hàng";
            this.gridColumn2.FieldName = "OrderID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Width = 124;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mã sản phẩm";
            this.gridColumn3.FieldName = "ProductID";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tên";
            this.gridColumn4.FieldName = "ProductName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 478;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Số lượng";
            this.gridColumn5.FieldName = "Quantity";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 212;
            // 
            // c_Date
            // 
            this.c_Date.Caption = "Ngày bán";
            this.c_Date.FieldName = "Date";
            this.c_Date.Name = "c_Date";
            this.c_Date.OptionsColumn.AllowEdit = false;
            this.c_Date.OptionsColumn.AllowFocus = false;
            this.c_Date.Visible = true;
            this.c_Date.VisibleIndex = 3;
            this.c_Date.Width = 312;
            // 
            // c_Price
            // 
            this.c_Price.Caption = "Giá";
            this.c_Price.FieldName = "Price";
            this.c_Price.Name = "c_Price";
            this.c_Price.OptionsColumn.AllowEdit = false;
            this.c_Price.OptionsColumn.AllowFocus = false;
            this.c_Price.Visible = true;
            this.c_Price.VisibleIndex = 2;
            this.c_Price.Width = 179;
            // 
            // c_promote
            // 
            this.c_promote.Caption = "Khuyến mãi";
            this.c_promote.FieldName = "Promote";
            this.c_promote.Name = "c_promote";
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = ((System.Drawing.Image)(resources.GetObject("button_Close.Image")));
            this.button_Close.Location = new System.Drawing.Point(281, 278);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 31);
            this.button_Close.TabIndex = 18;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_ViewOrderDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 311);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.gridControl_OrderDetail);
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "frm_ViewOrderDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ViewOrderDetail";
            this.Load += new System.EventHandler(this.frm_ViewOrderDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_OrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OrderDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_OrderDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_OrderDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn c_Date;
        private DevExpress.XtraGrid.Columns.GridColumn c_Price;
        private DevExpress.XtraGrid.Columns.GridColumn c_promote;
        private DevExpress.XtraEditors.SimpleButton button_Close;
    }
}