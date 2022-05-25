namespace Coffee
{
    partial class frm_AddEditMadeIn
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
            this.textEdit_MadeIn = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_ProductName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_ShortName = new DevExpress.XtraEditors.TextEdit();
            this.radioButton_Running = new System.Windows.Forms.RadioButton();
            this.radioButton_Stop = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MadeIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ShortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_MadeIn
            // 
            this.textEdit_MadeIn.Location = new System.Drawing.Point(96, 80);
            this.textEdit_MadeIn.Name = "textEdit_MadeIn";
            this.textEdit_MadeIn.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_MadeIn.Properties.Appearance.Options.UseFont = true;
            this.textEdit_MadeIn.Properties.AppearanceFocused.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_MadeIn.Properties.AppearanceFocused.Options.UseFont = true;
            this.textEdit_MadeIn.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_MadeIn.Properties.MaxLength = 20;
            this.textEdit_MadeIn.Size = new System.Drawing.Size(212, 22);
            this.textEdit_MadeIn.TabIndex = 1;
            // 
            // labelControl_ProductName
            // 
            this.labelControl_ProductName.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl_ProductName.Location = new System.Drawing.Point(6, 83);
            this.labelControl_ProductName.Name = "labelControl_ProductName";
            this.labelControl_ProductName.Size = new System.Drawing.Size(64, 15);
            this.labelControl_ProductName.TabIndex = 20;
            this.labelControl_ProductName.Text = "Tên xuất xứ";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(6, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 15);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "Mã";
            // 
            // textEdit_ShortName
            // 
            this.textEdit_ShortName.Location = new System.Drawing.Point(96, 52);
            this.textEdit_ShortName.Name = "textEdit_ShortName";
            this.textEdit_ShortName.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_ShortName.Properties.Appearance.Options.UseFont = true;
            this.textEdit_ShortName.Properties.AppearanceFocused.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_ShortName.Properties.AppearanceFocused.Options.UseFont = true;
            this.textEdit_ShortName.Properties.Mask.EditMask = "\\w+";
            this.textEdit_ShortName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEdit_ShortName.Properties.MaxLength = 20;
            this.textEdit_ShortName.Properties.ReadOnly = true;
            this.textEdit_ShortName.Size = new System.Drawing.Size(212, 22);
            this.textEdit_ShortName.TabIndex = 2;
            // 
            // radioButton_Running
            // 
            this.radioButton_Running.AutoSize = true;
            this.radioButton_Running.Checked = true;
            this.radioButton_Running.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Running.Location = new System.Drawing.Point(96, 107);
            this.radioButton_Running.Name = "radioButton_Running";
            this.radioButton_Running.Size = new System.Drawing.Size(84, 19);
            this.radioButton_Running.TabIndex = 3;
            this.radioButton_Running.TabStop = true;
            this.radioButton_Running.Text = "Đang dùng";
            this.radioButton_Running.UseVisualStyleBackColor = true;
            // 
            // radioButton_Stop
            // 
            this.radioButton_Stop.AutoSize = true;
            this.radioButton_Stop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Stop.Location = new System.Drawing.Point(211, 108);
            this.radioButton_Stop.Name = "radioButton_Stop";
            this.radioButton_Stop.Size = new System.Drawing.Size(80, 19);
            this.radioButton_Stop.TabIndex = 4;
            this.radioButton_Stop.Text = "Tạm dừng";
            this.radioButton_Stop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 45;
            this.label1.Text = "Tình trạng";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(320, 46);
            this.panelControl1.TabIndex = 46;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl2.Location = new System.Drawing.Point(76, 14);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(147, 22);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "NHÀ CUNG CẤP";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.home_blocked_128;
            this.pictureEdit1.Location = new System.Drawing.Point(6, 4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(64, 37);
            this.pictureEdit1.TabIndex = 1;
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(96, 132);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 30);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(177, 132);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 30);
            this.button_Close.TabIndex = 6;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_AddEditMadeIn
            // 
            this.Appearance.BackColor = System.Drawing.Color.PeachPuff;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 170);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.radioButton_Running);
            this.Controls.Add(this.radioButton_Stop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.textEdit_ShortName);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit_MadeIn);
            this.Controls.Add(this.labelControl_ProductName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_AddEditMadeIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_MadeIn";
            this.Load += new System.EventHandler(this.frm_MadeIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MadeIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ShortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_MadeIn;
        private DevExpress.XtraEditors.LabelControl labelControl_ProductName;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit_ShortName;
        private System.Windows.Forms.RadioButton radioButton_Running;
        private System.Windows.Forms.RadioButton radioButton_Stop;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;

    }
}