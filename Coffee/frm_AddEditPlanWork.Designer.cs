namespace Coffee
{
    partial class frm_AddEditPlanWork
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_PlanWorkName = new DevExpress.XtraEditors.TextEdit();
            this.timeEdit_Start = new DevExpress.XtraEditors.TimeEdit();
            this.timeEdit_End = new DevExpress.XtraEditors.TimeEdit();
            this.memoEdit_Notes = new DevExpress.XtraEditors.MemoEdit();
            this.radioButton_Running = new System.Windows.Forms.RadioButton();
            this.radioButton_Stop = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_PlanWorkName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_Start.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_End.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Notes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(11, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 15);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên ca";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(11, 102);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 15);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Bắt đầu";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(192, 102);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 15);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Kết thúc";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(10, 197);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 15);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Ghi chú";
            // 
            // textEdit_PlanWorkName
            // 
            this.textEdit_PlanWorkName.Location = new System.Drawing.Point(81, 73);
            this.textEdit_PlanWorkName.Name = "textEdit_PlanWorkName";
            this.textEdit_PlanWorkName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_PlanWorkName.Properties.MaxLength = 20;
            this.textEdit_PlanWorkName.Size = new System.Drawing.Size(277, 20);
            this.textEdit_PlanWorkName.TabIndex = 1;
            // 
            // timeEdit_Start
            // 
            this.timeEdit_Start.EditValue = new System.DateTime(2014, 8, 1, 12, 31, 30, 0);
            this.timeEdit_Start.Location = new System.Drawing.Point(81, 99);
            this.timeEdit_Start.Name = "timeEdit_Start";
            this.timeEdit_Start.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit_Start.Properties.Mask.EditMask = "t";
            this.timeEdit_Start.Size = new System.Drawing.Size(105, 20);
            this.timeEdit_Start.TabIndex = 2;
            // 
            // timeEdit_End
            // 
            this.timeEdit_End.EditValue = new System.DateTime(2014, 8, 1, 12, 31, 41, 0);
            this.timeEdit_End.Location = new System.Drawing.Point(244, 99);
            this.timeEdit_End.Name = "timeEdit_End";
            this.timeEdit_End.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit_End.Properties.Mask.EditMask = "t";
            this.timeEdit_End.Size = new System.Drawing.Size(113, 20);
            this.timeEdit_End.TabIndex = 3;
            // 
            // memoEdit_Notes
            // 
            this.memoEdit_Notes.Location = new System.Drawing.Point(81, 161);
            this.memoEdit_Notes.Name = "memoEdit_Notes";
            this.memoEdit_Notes.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit_Notes.Properties.Appearance.Options.UseFont = true;
            this.memoEdit_Notes.Properties.AppearanceFocused.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit_Notes.Properties.AppearanceFocused.Options.UseFont = true;
            this.memoEdit_Notes.Properties.MaxLength = 255;
            this.memoEdit_Notes.Size = new System.Drawing.Size(277, 100);
            this.memoEdit_Notes.TabIndex = 6;
            // 
            // radioButton_Running
            // 
            this.radioButton_Running.AutoSize = true;
            this.radioButton_Running.Checked = true;
            this.radioButton_Running.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Running.Location = new System.Drawing.Point(81, 130);
            this.radioButton_Running.Name = "radioButton_Running";
            this.radioButton_Running.Size = new System.Drawing.Size(84, 19);
            this.radioButton_Running.TabIndex = 4;
            this.radioButton_Running.TabStop = true;
            this.radioButton_Running.Text = "Đang dùng";
            this.radioButton_Running.UseVisualStyleBackColor = true;
            // 
            // radioButton_Stop
            // 
            this.radioButton_Stop.AutoSize = true;
            this.radioButton_Stop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Stop.Location = new System.Drawing.Point(192, 128);
            this.radioButton_Stop.Name = "radioButton_Stop";
            this.radioButton_Stop.Size = new System.Drawing.Size(80, 19);
            this.radioButton_Stop.TabIndex = 5;
            this.radioButton_Stop.Text = "Tạm dừng";
            this.radioButton_Stop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 132);
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
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(364, 66);
            this.panelControl1.TabIndex = 46;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseDown);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl5.Location = new System.Drawing.Point(80, 26);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(138, 24);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "CA LÀM VIỆC";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.office_calendar;
            this.pictureEdit1.Location = new System.Drawing.Point(4, 6);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(70, 55);
            this.pictureEdit1.TabIndex = 1;
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.Location = new System.Drawing.Point(117, 267);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 28);
            this.button_Save.TabIndex = 7;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.Location = new System.Drawing.Point(197, 267);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 28);
            this.button_Close.TabIndex = 8;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_AddEditPlanWork
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 297);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.radioButton_Running);
            this.Controls.Add(this.radioButton_Stop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.memoEdit_Notes);
            this.Controls.Add(this.timeEdit_End);
            this.Controls.Add(this.timeEdit_Start);
            this.Controls.Add(this.textEdit_PlanWorkName);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.Name = "frm_AddEditPlanWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ca Làm Việc";
            this.Load += new System.EventHandler(this.frm_AddEditPlanWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_PlanWorkName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_Start.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit_End.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Notes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEdit_PlanWorkName;
        private DevExpress.XtraEditors.TimeEdit timeEdit_Start;
        private DevExpress.XtraEditors.TimeEdit timeEdit_End;
        private DevExpress.XtraEditors.MemoEdit memoEdit_Notes;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private System.Windows.Forms.RadioButton radioButton_Running;
        private System.Windows.Forms.RadioButton radioButton_Stop;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}