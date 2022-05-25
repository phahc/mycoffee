namespace Coffee
{
    partial class frm_AddEditAdvance
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
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit_Date = new DevExpress.XtraEditors.DateEdit();
            this.memoEdit_Notes = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_Money = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Reason = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Date.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Date.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Notes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Money.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Reason.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(396, 43);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseDown);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.dollars;
            this.pictureEdit1.Location = new System.Drawing.Point(6, 6);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(67, 32);
            this.pictureEdit1.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.labelControl6.Location = new System.Drawing.Point(74, 15);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(184, 22);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "CHI TIẾT TẠM ỨNG";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.button_Save);
            this.panelControl2.Controls.Add(this.button_Close);
            this.panelControl2.Controls.Add(this.dateEdit_Date);
            this.panelControl2.Controls.Add(this.memoEdit_Notes);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.textEdit_Money);
            this.panelControl2.Controls.Add(this.textEdit_Reason);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 43);
            this.panelControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(396, 210);
            this.panelControl2.TabIndex = 1;
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(129, 176);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 30);
            this.button_Save.TabIndex = 11;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(210, 176);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 30);
            this.button_Close.TabIndex = 12;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // dateEdit_Date
            // 
            this.dateEdit_Date.EditValue = null;
            this.dateEdit_Date.Location = new System.Drawing.Point(74, 14);
            this.dateEdit_Date.Name = "dateEdit_Date";
            this.dateEdit_Date.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_Date.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_Date.Size = new System.Drawing.Size(145, 20);
            this.dateEdit_Date.TabIndex = 9;
            // 
            // memoEdit_Notes
            // 
            this.memoEdit_Notes.Location = new System.Drawing.Point(74, 74);
            this.memoEdit_Notes.Name = "memoEdit_Notes";
            this.memoEdit_Notes.Size = new System.Drawing.Size(312, 96);
            this.memoEdit_Notes.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(12, 76);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(43, 15);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Ghi chú";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(12, 43);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 15);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Lý do";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(225, 17);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 15);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Số tiền";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 15);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Ngày";
            // 
            // textEdit_Money
            // 
            this.textEdit_Money.Location = new System.Drawing.Point(269, 15);
            this.textEdit_Money.Name = "textEdit_Money";
            this.textEdit_Money.Properties.Mask.EditMask = "n2";
            this.textEdit_Money.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit_Money.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.textEdit_Money.Properties.NullText = "0";
            this.textEdit_Money.Size = new System.Drawing.Size(117, 20);
            this.textEdit_Money.TabIndex = 2;
            // 
            // textEdit_Reason
            // 
            this.textEdit_Reason.Location = new System.Drawing.Point(74, 41);
            this.textEdit_Reason.Name = "textEdit_Reason";
            this.textEdit_Reason.Size = new System.Drawing.Size(312, 20);
            this.textEdit_Reason.TabIndex = 2;
            // 
            // frm_AddEditAdvance
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 253);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_AddEditAdvance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Advance";
            this.Load += new System.EventHandler(this.frm_AddEditAdvance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Date.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Date.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Notes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Money.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Reason.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.DateEdit dateEdit_Date;
        private DevExpress.XtraEditors.MemoEdit memoEdit_Notes;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit_Money;
        private DevExpress.XtraEditors.TextEdit textEdit_Reason;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}