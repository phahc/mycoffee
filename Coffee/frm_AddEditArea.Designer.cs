namespace Coffee
{
    partial class frm_AddEditArea
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textEdit_AreaName = new DevExpress.XtraEditors.TextEdit();
            this.radioButton_Stop = new System.Windows.Forms.RadioButton();
            this.radioButton_Running = new System.Windows.Forms.RadioButton();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_AreaName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên khu vực";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tình trạng";
            // 
            // textEdit_AreaName
            // 
            this.textEdit_AreaName.Location = new System.Drawing.Point(110, 7);
            this.textEdit_AreaName.Name = "textEdit_AreaName";
            this.textEdit_AreaName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_AreaName.Properties.MaxLength = 6;
            this.textEdit_AreaName.Size = new System.Drawing.Size(170, 20);
            this.textEdit_AreaName.TabIndex = 0;
            // 
            // radioButton_Stop
            // 
            this.radioButton_Stop.AutoSize = true;
            this.radioButton_Stop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Stop.Location = new System.Drawing.Point(200, 34);
            this.radioButton_Stop.Name = "radioButton_Stop";
            this.radioButton_Stop.Size = new System.Drawing.Size(80, 19);
            this.radioButton_Stop.TabIndex = 2;
            this.radioButton_Stop.Text = "Tạm dừng";
            this.radioButton_Stop.UseVisualStyleBackColor = true;
            // 
            // radioButton_Running
            // 
            this.radioButton_Running.AutoSize = true;
            this.radioButton_Running.Checked = true;
            this.radioButton_Running.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Running.Location = new System.Drawing.Point(110, 33);
            this.radioButton_Running.Name = "radioButton_Running";
            this.radioButton_Running.Size = new System.Drawing.Size(84, 19);
            this.radioButton_Running.TabIndex = 1;
            this.radioButton_Running.TabStop = true;
            this.radioButton_Running.Text = "Đang dùng";
            this.radioButton_Running.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(110, 62);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 31);
            this.button_Save.TabIndex = 3;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(191, 62);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 31);
            this.button_Close.TabIndex = 4;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_AddEditArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 98);
            this.Controls.Add(this.radioButton_Running);
            this.Controls.Add(this.radioButton_Stop);
            this.Controls.Add(this.textEdit_AreaName);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.Name = "frm_AddEditArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Khu vực";
            this.Load += new System.EventHandler(this.frm_AddEditArea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_AreaName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.TextEdit textEdit_AreaName;
        private System.Windows.Forms.RadioButton radioButton_Stop;
        private System.Windows.Forms.RadioButton radioButton_Running;
    }
}