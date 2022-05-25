namespace Coffee.Reports
{
    partial class frm_ViewPlanDay
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
            this.printControl_ViewPlanDay = new DevExpress.XtraPrinting.Control.PrintControl();
            this.textEdit_PathFile = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnreport_ExportFile = new DevExpress.XtraEditors.SimpleButton();
            this.btn_BrowserFilePath = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.button_Stop = new DevExpress.XtraEditors.SimpleButton();
            this.button_Print = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_PathFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnreport_ExportFile);
            this.panelControl1.Controls.Add(this.textEdit_PathFile);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.btn_BrowserFilePath);
            this.panelControl1.Controls.Add(this.btn_Close);
            this.panelControl1.Controls.Add(this.button_Stop);
            this.panelControl1.Controls.Add(this.button_Print);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 489);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(917, 38);
            this.panelControl1.TabIndex = 0;
            // 
            // printControl_ViewPlanDay
            // 
            this.printControl_ViewPlanDay.BackColor = System.Drawing.Color.Empty;
            this.printControl_ViewPlanDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printControl_ViewPlanDay.ForeColor = System.Drawing.Color.Empty;
            this.printControl_ViewPlanDay.IsMetric = false;
            this.printControl_ViewPlanDay.Location = new System.Drawing.Point(0, 0);
            this.printControl_ViewPlanDay.Name = "printControl_ViewPlanDay";
            this.printControl_ViewPlanDay.Size = new System.Drawing.Size(917, 489);
            this.printControl_ViewPlanDay.TabIndex = 1;
            this.printControl_ViewPlanDay.TooltipFont = new System.Drawing.Font("Tahoma", 8.25F);
            // 
            // textEdit_PathFile
            // 
            this.textEdit_PathFile.Enabled = false;
            this.textEdit_PathFile.Location = new System.Drawing.Point(64, 8);
            this.textEdit_PathFile.Name = "textEdit_PathFile";
            this.textEdit_PathFile.Properties.ReadOnly = true;
            this.textEdit_PathFile.Size = new System.Drawing.Size(191, 20);
            this.textEdit_PathFile.TabIndex = 51;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(5, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 15);
            this.labelControl2.TabIndex = 50;
            this.labelControl2.Text = "Thư mục :";
            // 
            // btnreport_ExportFile
            // 
            this.btnreport_ExportFile.Image = global::Coffee.Properties.Resources.pdf_icon_16x16;
            this.btnreport_ExportFile.Location = new System.Drawing.Point(306, 6);
            this.btnreport_ExportFile.Name = "btnreport_ExportFile";
            this.btnreport_ExportFile.Size = new System.Drawing.Size(75, 24);
            this.btnreport_ExportFile.TabIndex = 52;
            this.btnreport_ExportFile.Text = "Xuất pdf";
            this.btnreport_ExportFile.Click += new System.EventHandler(this.btnreport_ExportFile_Click);
            // 
            // btn_BrowserFilePath
            // 
            this.btn_BrowserFilePath.Image = global::Coffee.Properties.Resources.Folder;
            this.btn_BrowserFilePath.Location = new System.Drawing.Point(259, 6);
            this.btn_BrowserFilePath.Name = "btn_BrowserFilePath";
            this.btn_BrowserFilePath.Size = new System.Drawing.Size(41, 22);
            this.btn_BrowserFilePath.TabIndex = 49;
            this.btn_BrowserFilePath.Text = "...";
            this.btn_BrowserFilePath.Click += new System.EventHandler(this.btn_BrowserFilePath_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Appearance.Options.UseFont = true;
            this.btn_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.btn_Close.Location = new System.Drawing.Point(846, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(66, 30);
            this.btn_Close.TabIndex = 48;
            this.btn_Close.Text = "Thoát";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Stop.Appearance.Options.UseFont = true;
            this.button_Stop.Image = global::Coffee.Properties.Resources.Abort;
            this.button_Stop.Location = new System.Drawing.Point(486, 5);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(76, 30);
            this.button_Stop.TabIndex = 48;
            this.button_Stop.Text = "Kết thúc";
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Print
            // 
            this.button_Print.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Print.Appearance.Options.UseFont = true;
            this.button_Print.Image = global::Coffee.Properties.Resources.printer;
            this.button_Print.Location = new System.Drawing.Point(414, 5);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(66, 30);
            this.button_Print.TabIndex = 47;
            this.button_Print.Text = "In";
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click);
            // 
            // frm_ViewPlanDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 527);
            this.Controls.Add(this.printControl_ViewPlanDay);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.Name = "frm_ViewPlanDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_ViewPlanDay";
            this.Load += new System.EventHandler(this.frm_ViewPlanDay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_PathFile.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton button_Stop;
        private DevExpress.XtraEditors.SimpleButton button_Print;
        private DevExpress.XtraPrinting.Control.PrintControl printControl_ViewPlanDay;
        private DevExpress.XtraEditors.SimpleButton btnreport_ExportFile;
        private DevExpress.XtraEditors.TextEdit textEdit_PathFile;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_BrowserFilePath;
    }
}