namespace Coffee
{
    partial class frm_AddEditMailReceiver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddEditMailReceiver));
            this.textEdit_AutoSendDate = new DevExpress.XtraEditors.TextEdit();
            this.checkEdit_AutoSend = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl_AutoSendDate = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_Name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_Name = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_EMail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_EMail = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_AutoSendDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_AutoSend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_AutoSendDate
            // 
            this.textEdit_AutoSendDate.EditValue = "00:00:00";
            this.textEdit_AutoSendDate.Location = new System.Drawing.Point(99, 131);
            this.textEdit_AutoSendDate.Name = "textEdit_AutoSendDate";
            this.textEdit_AutoSendDate.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_AutoSendDate.Properties.Appearance.Options.UseFont = true;
            this.textEdit_AutoSendDate.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.textEdit_AutoSendDate.Properties.Mask.EditMask = "([01][0-9]|2[0-3]):[0-5]\\d:[0-5]\\d";
            this.textEdit_AutoSendDate.Properties.Mask.IgnoreMaskBlank = false;
            this.textEdit_AutoSendDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEdit_AutoSendDate.Properties.MaxLength = 8;
            this.textEdit_AutoSendDate.Size = new System.Drawing.Size(219, 22);
            this.textEdit_AutoSendDate.TabIndex = 16;
            // 
            // checkEdit_AutoSend
            // 
            this.checkEdit_AutoSend.Location = new System.Drawing.Point(97, 108);
            this.checkEdit_AutoSend.Name = "checkEdit_AutoSend";
            this.checkEdit_AutoSend.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit_AutoSend.Properties.Appearance.Options.UseFont = true;
            this.checkEdit_AutoSend.Properties.Caption = "Tự động nhận t/nhắn";
            this.checkEdit_AutoSend.Size = new System.Drawing.Size(140, 20);
            this.checkEdit_AutoSend.TabIndex = 14;
            this.checkEdit_AutoSend.CheckedChanged += new System.EventHandler(this.checkEdit_AutoSend_CheckedChanged);
            // 
            // labelControl_AutoSendDate
            // 
            this.labelControl_AutoSendDate.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_AutoSendDate.Location = new System.Drawing.Point(6, 134);
            this.labelControl_AutoSendDate.Name = "labelControl_AutoSendDate";
            this.labelControl_AutoSendDate.Size = new System.Drawing.Size(85, 15);
            this.labelControl_AutoSendDate.TabIndex = 15;
            this.labelControl_AutoSendDate.Text = "Thời điểm nhận";
            // 
            // textEdit_Name
            // 
            this.textEdit_Name.Location = new System.Drawing.Point(99, 84);
            this.textEdit_Name.Name = "textEdit_Name";
            this.textEdit_Name.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_Name.Properties.Appearance.Options.UseFont = true;
            this.textEdit_Name.Properties.AppearanceFocused.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_Name.Properties.AppearanceFocused.Options.UseFont = true;
            this.textEdit_Name.Properties.MaxLength = 20;
            this.textEdit_Name.Size = new System.Drawing.Size(219, 22);
            this.textEdit_Name.TabIndex = 13;
            // 
            // labelControl_Name
            // 
            this.labelControl_Name.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_Name.Location = new System.Drawing.Point(6, 87);
            this.labelControl_Name.Name = "labelControl_Name";
            this.labelControl_Name.Size = new System.Drawing.Size(87, 15);
            this.labelControl_Name.TabIndex = 12;
            this.labelControl_Name.Text = "Tên người nhận";
            // 
            // textEdit_EMail
            // 
            this.textEdit_EMail.Location = new System.Drawing.Point(99, 59);
            this.textEdit_EMail.Name = "textEdit_EMail";
            this.textEdit_EMail.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_EMail.Properties.Appearance.Options.UseFont = true;
            this.textEdit_EMail.Properties.AppearanceFocused.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_EMail.Properties.AppearanceFocused.Options.UseFont = true;
            this.textEdit_EMail.Properties.MaxLength = 50;
            this.textEdit_EMail.Size = new System.Drawing.Size(219, 22);
            this.textEdit_EMail.TabIndex = 11;
            // 
            // labelControl_EMail
            // 
            this.labelControl_EMail.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_EMail.Location = new System.Drawing.Point(6, 62);
            this.labelControl_EMail.Name = "labelControl_EMail";
            this.labelControl_EMail.Size = new System.Drawing.Size(87, 15);
            this.labelControl_EMail.TabIndex = 10;
            this.labelControl_EMail.Text = "Đ/chỉ mail nhận";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(321, 49);
            this.panelControl1.TabIndex = 19;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl1.Location = new System.Drawing.Point(75, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(135, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "NHẬN EMAIL";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(7, 3);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(62, 43);
            this.pictureEdit1.TabIndex = 1;
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(99, 159);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 26);
            this.button_Save.TabIndex = 17;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(182, 159);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 26);
            this.button_Close.TabIndex = 18;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_AddEditMailReceiver
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 195);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.textEdit_AutoSendDate);
            this.Controls.Add(this.checkEdit_AutoSend);
            this.Controls.Add(this.labelControl_AutoSendDate);
            this.Controls.Add(this.textEdit_Name);
            this.Controls.Add(this.labelControl_Name);
            this.Controls.Add(this.textEdit_EMail);
            this.Controls.Add(this.labelControl_EMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.Name = "frm_AddEditMailReceiver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_AddEditMailReceiver";
            this.Load += new System.EventHandler(this.frm_AddEditMailReceiver_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_AutoSendDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_AutoSend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_EMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.TextEdit textEdit_AutoSendDate;
        private DevExpress.XtraEditors.CheckEdit checkEdit_AutoSend;
        private DevExpress.XtraEditors.LabelControl labelControl_AutoSendDate;
        private DevExpress.XtraEditors.TextEdit textEdit_Name;
        private DevExpress.XtraEditors.LabelControl labelControl_Name;
        private DevExpress.XtraEditors.TextEdit textEdit_EMail;
        private DevExpress.XtraEditors.LabelControl labelControl_EMail;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}