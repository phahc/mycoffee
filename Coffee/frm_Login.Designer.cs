namespace Coffee
{
    partial class frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.checkEdit_Remember = new DevExpress.XtraEditors.CheckEdit();
            this.textEdit_Password = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_UserName = new DevExpress.XtraEditors.TextEdit();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.button_Login = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkEdit_Hide = new DevExpress.XtraEditors.CheckEdit();
            this.lbl_Trial = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_Remember.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_Hide.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit_Remember
            // 
            this.checkEdit_Remember.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkEdit_Remember.Location = new System.Drawing.Point(352, 244);
            this.checkEdit_Remember.Name = "checkEdit_Remember";
            this.checkEdit_Remember.Properties.Caption = "Ghi nhớ mật khẩu";
            this.checkEdit_Remember.Size = new System.Drawing.Size(110, 19);
            this.checkEdit_Remember.TabIndex = 37;
            // 
            // textEdit_Password
            // 
            this.textEdit_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEdit_Password.EditValue = "";
            this.textEdit_Password.Location = new System.Drawing.Point(354, 219);
            this.textEdit_Password.Name = "textEdit_Password";
            this.textEdit_Password.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_Password.Properties.Appearance.Options.UseFont = true;
            this.textEdit_Password.Properties.MaxLength = 20;
            this.textEdit_Password.Properties.PasswordChar = '*';
            this.textEdit_Password.Size = new System.Drawing.Size(182, 22);
            this.textEdit_Password.TabIndex = 32;
            this.textEdit_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit_Password_KeyDown);
            // 
            // textEdit_UserName
            // 
            this.textEdit_UserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textEdit_UserName.EditValue = "";
            this.textEdit_UserName.Location = new System.Drawing.Point(354, 191);
            this.textEdit_UserName.Name = "textEdit_UserName";
            this.textEdit_UserName.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_UserName.Properties.Appearance.Options.UseFont = true;
            this.textEdit_UserName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_UserName.Properties.MaxLength = 20;
            this.textEdit_UserName.Size = new System.Drawing.Size(182, 22);
            this.textEdit_UserName.TabIndex = 31;
            this.textEdit_UserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit_UserName_KeyDown);
            // 
            // button_Close
            // 
            this.button_Close.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(458, 269);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(78, 28);
            this.button_Close.TabIndex = 34;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Login
            // 
            this.button_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Login.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Login.Appearance.Options.UseFont = true;
            this.button_Login.Image = global::Coffee.Properties.Resources.Key;
            this.button_Login.Location = new System.Drawing.Point(354, 269);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(98, 28);
            this.button_Login.TabIndex = 33;
            this.button_Login.Text = "Đăng nhập";
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(262, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(289, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Mật khẩu";
            // 
            // checkEdit_Hide
            // 
            this.checkEdit_Hide.Location = new System.Drawing.Point(0, 300);
            this.checkEdit_Hide.Name = "checkEdit_Hide";
            this.checkEdit_Hide.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit_Hide.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.checkEdit_Hide.Properties.Appearance.Options.UseFont = true;
            this.checkEdit_Hide.Properties.Appearance.Options.UseForeColor = true;
            this.checkEdit_Hide.Properties.Caption = "Ẩn";
            this.checkEdit_Hide.Size = new System.Drawing.Size(75, 20);
            this.checkEdit_Hide.TabIndex = 38;
            this.checkEdit_Hide.CheckedChanged += new System.EventHandler(this.checkEdit_Hide_CheckedChanged);
            // 
            // lbl_Trial
            // 
            this.lbl_Trial.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Trial.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_Trial.Location = new System.Drawing.Point(230, 302);
            this.lbl_Trial.Name = "lbl_Trial";
            this.lbl_Trial.Size = new System.Drawing.Size(79, 16);
            this.lbl_Trial.TabIndex = 40;
            this.lbl_Trial.Text = "Bản dùng thử.";
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::Coffee.Properties.Resources.coffee;
            this.ClientSize = new System.Drawing.Size(544, 321);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_Trial);
            this.Controls.Add(this.checkEdit_Hide);
            this.Controls.Add(this.checkEdit_Remember);
            this.Controls.Add(this.textEdit_Password);
            this.Controls.Add(this.textEdit_UserName);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frm_Login_Load);
            this.SizeChanged += new System.EventHandler(this.frm_Login_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Login_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_Login_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_Remember.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_Hide.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit_Remember;
        private DevExpress.XtraEditors.TextEdit textEdit_Password;
        private DevExpress.XtraEditors.TextEdit textEdit_UserName;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.SimpleButton button_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.CheckEdit checkEdit_Hide;
        private DevExpress.XtraEditors.LabelControl lbl_Trial;


    }
}