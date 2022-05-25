namespace Coffee
{
    partial class frm_SelectEmployeeAdvance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SelectEmployeeAdvance));
            this.treeView_Employee = new System.Windows.Forms.TreeView();
            this.imageList_Employee = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView_Employee
            // 
            this.treeView_Employee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_Employee.BackColor = System.Drawing.Color.PeachPuff;
            this.treeView_Employee.ImageIndex = 0;
            this.treeView_Employee.ImageList = this.imageList_Employee;
            this.treeView_Employee.Location = new System.Drawing.Point(3, 60);
            this.treeView_Employee.Name = "treeView_Employee";
            this.treeView_Employee.SelectedImageIndex = 0;
            this.treeView_Employee.Size = new System.Drawing.Size(277, 303);
            this.treeView_Employee.TabIndex = 2;
            this.treeView_Employee.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Employee_NodeMouseClick);
            this.treeView_Employee.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Employee_NodeMouseDoubleClick);
            // 
            // imageList_Employee
            // 
            this.imageList_Employee.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Employee.ImageStream")));
            this.imageList_Employee.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Employee.Images.SetKeyName(0, "Male.png");
            this.imageList_Employee.Images.SetKeyName(1, "Female.png");
            this.imageList_Employee.Images.SetKeyName(2, "People.png");
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.treeView_Employee, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.57377F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.42623F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 366);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(277, 51);
            this.panelControl1.TabIndex = 3;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl1.Location = new System.Drawing.Point(65, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(117, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "NHÂN VIÊN";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.profile;
            this.pictureEdit1.Location = new System.Drawing.Point(5, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(54, 52);
            this.pictureEdit1.TabIndex = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.btn_Close.Location = new System.Drawing.Point(171, 372);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Thoát";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Image = global::Coffee.Properties.Resources.Thumbs_up;
            this.btn_OK.Location = new System.Drawing.Point(84, 372);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(81, 23);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "Chấp nhận";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frm_SelectEmployeeAdvance
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 399);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frm_SelectEmployeeAdvance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_SelectEmployeeAdvance";
            this.Load += new System.EventHandler(this.frm_SelectEmployeeAdvance_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_SelectEmployeeAdvance_MouseDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_Employee;
        private System.Windows.Forms.ImageList imageList_Employee;
        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}