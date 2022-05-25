namespace Coffee
{
    partial class frm_PlusTable
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraScrollable_Table = new DevExpress.XtraEditors.XtraScrollableControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.treeView_Areas = new System.Windows.Forms.TreeView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbl_Plus = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button_Save);
            this.panelControl1.Controls.Add(this.button_Close);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 424);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(725, 35);
            this.panelControl1.TabIndex = 0;
            // 
            // xtraScrollable_Table
            // 
            this.xtraScrollable_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollable_Table.Location = new System.Drawing.Point(2, 23);
            this.xtraScrollable_Table.Name = "xtraScrollable_Table";
            this.xtraScrollable_Table.Size = new System.Drawing.Size(535, 331);
            this.xtraScrollable_Table.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.treeView_Areas);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(180, 424);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Khu Vực";
            // 
            // treeView_Areas
            // 
            this.treeView_Areas.BackColor = System.Drawing.SystemColors.ControlLight;
            this.treeView_Areas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Areas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView_Areas.ForeColor = System.Drawing.Color.Maroon;
            this.treeView_Areas.Location = new System.Drawing.Point(2, 23);
            this.treeView_Areas.Name = "treeView_Areas";
            this.treeView_Areas.Size = new System.Drawing.Size(176, 399);
            this.treeView_Areas.TabIndex = 0;
            this.treeView_Areas.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Areas_NodeMouseClick);
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.xtraScrollable_Table);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 65);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(539, 356);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Danh Sách Bàn";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(180, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.62264F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.37736F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(545, 424);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.pictureEdit1);
            this.panelControl2.Controls.Add(this.lbl_Plus);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 3);
            this.panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(539, 56);
            this.panelControl2.TabIndex = 4;
            this.panelControl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl2_MouseDown);
            // 
            // lbl_Plus
            // 
            this.lbl_Plus.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Plus.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_Plus.Location = new System.Drawing.Point(87, 21);
            this.lbl_Plus.Name = "lbl_Plus";
            this.lbl_Plus.Size = new System.Drawing.Size(80, 24);
            this.lbl_Plus.TabIndex = 0;
            this.lbl_Plus.Text = "Gộp Bàn";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.Order_Table;
            this.pictureEdit1.Location = new System.Drawing.Point(6, 2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(73, 54);
            this.pictureEdit1.TabIndex = 2;
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(339, 2);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(80, 30);
            this.button_Save.TabIndex = 43;
            this.button_Save.Text = "Gộp";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(425, 2);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 30);
            this.button_Close.TabIndex = 44;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_PlusTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 459);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frm_PlusTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_PlusTable";
            this.Load += new System.EventHandler(this.frm_PlusTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollable_Table;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TreeView treeView_Areas;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lbl_Plus;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}