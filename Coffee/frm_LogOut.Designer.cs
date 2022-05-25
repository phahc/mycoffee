namespace Coffee
{
    partial class frm_LogOut
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
            this.button_Logout = new DevExpress.XtraEditors.SimpleButton();
            this.button_ReportDetails = new DevExpress.XtraEditors.SimpleButton();
            this.button_ReportShift = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Transfer = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // button_Logout
            // 
            this.button_Logout.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Logout.Appearance.Options.UseFont = true;
            this.button_Logout.Location = new System.Drawing.Point(11, 141);
            this.button_Logout.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.button_Logout.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button_Logout.Name = "button_Logout";
            this.button_Logout.Size = new System.Drawing.Size(141, 42);
            this.button_Logout.TabIndex = 4;
            this.button_Logout.Text = "Đăng xuất";
            this.button_Logout.Click += new System.EventHandler(this.button_Logout_Click);
            // 
            // button_ReportDetails
            // 
            this.button_ReportDetails.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ReportDetails.Appearance.Options.UseFont = true;
            this.button_ReportDetails.Location = new System.Drawing.Point(12, 55);
            this.button_ReportDetails.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.button_ReportDetails.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button_ReportDetails.Name = "button_ReportDetails";
            this.button_ReportDetails.Size = new System.Drawing.Size(141, 42);
            this.button_ReportDetails.TabIndex = 2;
            this.button_ReportDetails.Text = "In báo cáo chi tiết";
            this.button_ReportDetails.Click += new System.EventHandler(this.button_ReportDetails_Click);
            // 
            // button_ReportShift
            // 
            this.button_ReportShift.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ReportShift.Appearance.Options.UseFont = true;
            this.button_ReportShift.Location = new System.Drawing.Point(12, 12);
            this.button_ReportShift.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.button_ReportShift.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button_ReportShift.Name = "button_ReportShift";
            this.button_ReportShift.Size = new System.Drawing.Size(141, 42);
            this.button_ReportShift.TabIndex = 1;
            this.button_ReportShift.Text = "In biên bản giao ca";
            this.button_ReportShift.Click += new System.EventHandler(this.button_ReportShift_Click);
            // 
            // btn_Transfer
            // 
            this.btn_Transfer.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Transfer.Appearance.Options.UseFont = true;
            this.btn_Transfer.Location = new System.Drawing.Point(11, 98);
            this.btn_Transfer.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_Transfer.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_Transfer.Name = "btn_Transfer";
            this.btn_Transfer.Size = new System.Drawing.Size(141, 42);
            this.btn_Transfer.TabIndex = 3;
            this.btn_Transfer.Text = "Giao ca";
            this.btn_Transfer.Click += new System.EventHandler(this.btn_Transfer_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.Appearance.Options.UseFont = true;
            this.btn_Cancel.Image = global::Coffee.Properties.Resources.Turn_off;
            this.btn_Cancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_Cancel.Location = new System.Drawing.Point(11, 184);
            this.btn_Cancel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btn_Cancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(141, 42);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Hủy";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // frm_LogOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(164, 228);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Transfer);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.button_Logout);
            this.Controls.Add(this.button_ReportDetails);
            this.Controls.Add(this.button_ReportShift);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_LogOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_LogOut";
            this.Load += new System.EventHandler(this.frm_LogOut_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton button_Logout;
        private DevExpress.XtraEditors.SimpleButton button_ReportDetails;
        private DevExpress.XtraEditors.SimpleButton button_ReportShift;
        private DevExpress.XtraEditors.SimpleButton btn_Transfer;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
    }
}