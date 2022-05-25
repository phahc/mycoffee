namespace Coffee
{
    partial class frm_ChangeNameLogin
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
            this.textEdit_ChangeName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_OldPass = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ChangeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_OldPass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_ChangeName
            // 
            this.textEdit_ChangeName.Location = new System.Drawing.Point(128, 42);
            this.textEdit_ChangeName.Name = "textEdit_ChangeName";
            this.textEdit_ChangeName.Properties.Mask.EditMask = "\\w+";
            this.textEdit_ChangeName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.textEdit_ChangeName.Properties.MaxLength = 20;
            this.textEdit_ChangeName.Size = new System.Drawing.Size(239, 20);
            this.textEdit_ChangeName.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(13, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 15);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tên đăng nhập mới";
            // 
            // textEdit_OldPass
            // 
            this.textEdit_OldPass.Location = new System.Drawing.Point(128, 68);
            this.textEdit_OldPass.Name = "textEdit_OldPass";
            this.textEdit_OldPass.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_OldPass.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.textEdit_OldPass.Properties.Appearance.Options.UseFont = true;
            this.textEdit_OldPass.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_OldPass.Properties.MaxLength = 50;
            this.textEdit_OldPass.Properties.PasswordChar = '*';
            this.textEdit_OldPass.Size = new System.Drawing.Size(239, 22);
            this.textEdit_OldPass.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Mật khẩu";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(13, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(333, 15);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Lưu ý: Bạn chỉ được đổi tên đăng nhập một lần duy nhất . Xin cảm ơn\r\n";
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(128, 96);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 28);
            this.button_Save.TabIndex = 14;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(208, 96);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 28);
            this.button_Close.TabIndex = 15;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_ChangeNameLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 128);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEdit_OldPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textEdit_ChangeName);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.Name = "frm_ChangeNameLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_ChangeNameLogin";
            this.Load += new System.EventHandler(this.frm_ChangeNameLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ChangeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_OldPass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_ChangeName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit_OldPass;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
    }
}