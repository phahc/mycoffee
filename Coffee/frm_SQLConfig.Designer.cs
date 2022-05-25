namespace Coffee
{
    partial class frm_SQLConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SQLConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkEdit_SQL = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit_Win = new DevExpress.XtraEditors.CheckEdit();
            this.textEdit_LoginName = new DevExpress.XtraEditors.TextEdit();
            this.button_TestConnection = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textEdit_Password = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_DatabaseName = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_ServerName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_SQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_Win.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_LoginName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DatabaseName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ServerName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkEdit_SQL);
            this.groupBox1.Controls.Add(this.checkEdit_Win);
            this.groupBox1.Controls.Add(this.textEdit_LoginName);
            this.groupBox1.Controls.Add(this.button_TestConnection);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textEdit_Password);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Crimson;
            this.groupBox1.Location = new System.Drawing.Point(15, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 126);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentication Mode";
            // 
            // checkEdit_SQL
            // 
            this.checkEdit_SQL.Enabled = false;
            this.checkEdit_SQL.Location = new System.Drawing.Point(15, 99);
            this.checkEdit_SQL.Name = "checkEdit_SQL";
            this.checkEdit_SQL.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit_SQL.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.checkEdit_SQL.Properties.Appearance.Options.UseFont = true;
            this.checkEdit_SQL.Properties.Appearance.Options.UseForeColor = true;
            this.checkEdit_SQL.Properties.Caption = "MySQL Server Authetication";
            this.checkEdit_SQL.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit_SQL.Properties.RadioGroupIndex = 2;
            this.checkEdit_SQL.Size = new System.Drawing.Size(192, 20);
            this.checkEdit_SQL.TabIndex = 5;
            this.checkEdit_SQL.TabStop = false;
            this.checkEdit_SQL.CheckedChanged += new System.EventHandler(this.checkEdit_SQL_CheckedChanged);
            // 
            // checkEdit_Win
            // 
            this.checkEdit_Win.Enabled = false;
            this.checkEdit_Win.Location = new System.Drawing.Point(15, 77);
            this.checkEdit_Win.Name = "checkEdit_Win";
            this.checkEdit_Win.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit_Win.Properties.Appearance.ForeColor = System.Drawing.Color.Crimson;
            this.checkEdit_Win.Properties.Appearance.Options.UseFont = true;
            this.checkEdit_Win.Properties.Appearance.Options.UseForeColor = true;
            this.checkEdit_Win.Properties.Caption = "Windows Anthentication";
            this.checkEdit_Win.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit_Win.Properties.RadioGroupIndex = 2;
            this.checkEdit_Win.Size = new System.Drawing.Size(172, 20);
            this.checkEdit_Win.TabIndex = 4;
            this.checkEdit_Win.TabStop = false;
            // 
            // textEdit_LoginName
            // 
            this.textEdit_LoginName.Location = new System.Drawing.Point(106, 22);
            this.textEdit_LoginName.Name = "textEdit_LoginName";
            this.textEdit_LoginName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textEdit_LoginName.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_LoginName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.textEdit_LoginName.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_LoginName.Properties.Appearance.Options.UseFont = true;
            this.textEdit_LoginName.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_LoginName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_LoginName.Properties.MaxLength = 1000;
            this.textEdit_LoginName.Size = new System.Drawing.Size(185, 22);
            this.textEdit_LoginName.TabIndex = 1;
            // 
            // button_TestConnection
            // 
            this.button_TestConnection.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_TestConnection.Appearance.Options.UseFont = true;
            this.button_TestConnection.Location = new System.Drawing.Point(213, 82);
            this.button_TestConnection.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.button_TestConnection.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.button_TestConnection.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button_TestConnection.Name = "button_TestConnection";
            this.button_TestConnection.Size = new System.Drawing.Size(78, 25);
            this.button_TestConnection.TabIndex = 0;
            this.button_TestConnection.Text = "Thử kết nối";
            this.button_TestConnection.Click += new System.EventHandler(this.button_TestConnection_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Login Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password";
            // 
            // textEdit_Password
            // 
            this.textEdit_Password.Location = new System.Drawing.Point(106, 51);
            this.textEdit_Password.Name = "textEdit_Password";
            this.textEdit_Password.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textEdit_Password.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_Password.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.textEdit_Password.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_Password.Properties.Appearance.Options.UseFont = true;
            this.textEdit_Password.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_Password.Properties.MaxLength = 1000;
            this.textEdit_Password.Properties.PasswordChar = '*';
            this.textEdit_Password.Size = new System.Drawing.Size(185, 22);
            this.textEdit_Password.TabIndex = 3;
            // 
            // textEdit_DatabaseName
            // 
            this.textEdit_DatabaseName.Location = new System.Drawing.Point(135, 35);
            this.textEdit_DatabaseName.Name = "textEdit_DatabaseName";
            this.textEdit_DatabaseName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textEdit_DatabaseName.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_DatabaseName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.textEdit_DatabaseName.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_DatabaseName.Properties.Appearance.Options.UseFont = true;
            this.textEdit_DatabaseName.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_DatabaseName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_DatabaseName.Properties.MaxLength = 1000;
            this.textEdit_DatabaseName.Size = new System.Drawing.Size(189, 22);
            this.textEdit_DatabaseName.TabIndex = 10;
            // 
            // textEdit_ServerName
            // 
            this.textEdit_ServerName.Location = new System.Drawing.Point(135, 6);
            this.textEdit_ServerName.Name = "textEdit_ServerName";
            this.textEdit_ServerName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.textEdit_ServerName.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit_ServerName.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.textEdit_ServerName.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_ServerName.Properties.Appearance.Options.UseFont = true;
            this.textEdit_ServerName.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit_ServerName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_ServerName.Properties.MaxLength = 1000;
            this.textEdit_ServerName.Size = new System.Drawing.Size(189, 22);
            this.textEdit_ServerName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Database Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "MySQL Server Name";
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off1;
            this.button_Close.Location = new System.Drawing.Point(173, 200);
            this.button_Close.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 27);
            this.button_Close.TabIndex = 13;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = ((System.Drawing.Image)(resources.GetObject("button_Save.Image")));
            this.button_Save.Location = new System.Drawing.Point(89, 200);
            this.button_Save.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 27);
            this.button_Save.TabIndex = 12;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // frm_SQLConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 232);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.textEdit_DatabaseName);
            this.Controls.Add(this.textEdit_ServerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SQLConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_SQLConfig";
            this.Load += new System.EventHandler(this.frm_SQLConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_SQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_Win.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_LoginName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DatabaseName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_ServerName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.CheckEdit checkEdit_SQL;
        private DevExpress.XtraEditors.CheckEdit checkEdit_Win;
        private DevExpress.XtraEditors.TextEdit textEdit_LoginName;
        private DevExpress.XtraEditors.SimpleButton button_TestConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit textEdit_Password;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.TextEdit textEdit_DatabaseName;
        private DevExpress.XtraEditors.TextEdit textEdit_ServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}