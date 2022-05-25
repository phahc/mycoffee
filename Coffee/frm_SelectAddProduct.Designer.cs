namespace Coffee
{
    partial class frm_SelectAddProduct
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
            this.imageList_Product = new System.Windows.Forms.ImageList(this.components);
            this.treeView_Menu = new System.Windows.Forms.TreeView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList_Product
            // 
            this.imageList_Product.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_Product.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_Product.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeView_Menu
            // 
            this.treeView_Menu.BackColor = System.Drawing.Color.PeachPuff;
            this.treeView_Menu.ImageIndex = 0;
            this.treeView_Menu.ImageList = this.imageList_Product;
            this.treeView_Menu.Location = new System.Drawing.Point(1, 53);
            this.treeView_Menu.Name = "treeView_Menu";
            this.treeView_Menu.SelectedImageIndex = 0;
            this.treeView_Menu.Size = new System.Drawing.Size(263, 277);
            this.treeView_Menu.TabIndex = 3;
            this.treeView_Menu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Menu_NodeMouseClick);
            this.treeView_Menu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Menu_NodeMouseDoubleClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(1, -1);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(266, 54);
            this.panelControl1.TabIndex = 4;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl1.Location = new System.Drawing.Point(59, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(200, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "CHỌN NHÓM HÀNG";
            // 
            // btn_Close
            // 
            this.btn_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.btn_Close.Location = new System.Drawing.Point(185, 336);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "Thoát";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Image = global::Coffee.Properties.Resources.Thumbs_up;
            this.btn_OK.Location = new System.Drawing.Point(98, 336);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(81, 23);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "Chấp nhận";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.benchmarking;
            this.pictureEdit1.Location = new System.Drawing.Point(4, 3);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(56, 48);
            this.pictureEdit1.TabIndex = 1;
            // 
            // frm_SelectAddProduct
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 362);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.treeView_Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frm_SelectAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn Nhóm Hàng";
            this.Load += new System.EventHandler(this.frm_SelectAddProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList_Product;
        private System.Windows.Forms.TreeView treeView_Menu;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_OK;
    }
}