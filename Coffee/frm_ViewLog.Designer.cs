namespace Coffee
{
    partial class frm_ViewLog
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
            this.dateTimePicker_EndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_BeginTime = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Employee = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Print = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl_ViewLog = new DevExpress.XtraGrid.GridControl();
            this.gridView_ViewLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_Time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Action = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Employee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ViewLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ViewLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker_EndTime
            // 
            this.dateTimePicker_EndTime.CustomFormat = "HH\':\'mm\':\'ss dd\'/\'MM\'/\'yyyy";
            this.dateTimePicker_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_EndTime.Location = new System.Drawing.Point(246, 25);
            this.dateTimePicker_EndTime.Name = "dateTimePicker_EndTime";
            this.dateTimePicker_EndTime.Size = new System.Drawing.Size(158, 21);
            this.dateTimePicker_EndTime.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ lúc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(216, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến";
            // 
            // dateTimePicker_BeginTime
            // 
            this.dateTimePicker_BeginTime.CustomFormat = "HH\':\'mm\':\'ss dd\'/\'MM\'/\'yyyy";
            this.dateTimePicker_BeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_BeginTime.Location = new System.Drawing.Point(54, 25);
            this.dateTimePicker_BeginTime.Name = "dateTimePicker_BeginTime";
            this.dateTimePicker_BeginTime.Size = new System.Drawing.Size(158, 21);
            this.dateTimePicker_BeginTime.TabIndex = 1;
            // 
            // comboBox_Employee
            // 
            this.comboBox_Employee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Employee.FormattingEnabled = true;
            this.comboBox_Employee.Location = new System.Drawing.Point(410, 25);
            this.comboBox_Employee.Name = "comboBox_Employee";
            this.comboBox_Employee.Size = new System.Drawing.Size(167, 21);
            this.comboBox_Employee.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(415, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhân viên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.dateTimePicker_EndTime);
            this.groupBox1.Controls.Add(this.comboBox_Employee);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker_BeginTime);
            this.groupBox1.Location = new System.Drawing.Point(0, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 60);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xem lịch sử";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(593, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(588, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thao tác";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.Appearance.Options.UseFont = true;
            this.btn_Refresh.Image = global::Coffee.Properties.Resources.Refresh;
            this.btn_Refresh.Location = new System.Drawing.Point(219, 516);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(97, 25);
            this.btn_Refresh.TabIndex = 13;
            this.btn_Refresh.Text = "Làm mới";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.Appearance.Options.UseFont = true;
            this.btn_Print.Image = global::Coffee.Properties.Resources.printer;
            this.btn_Print.Location = new System.Drawing.Point(328, 516);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(97, 25);
            this.btn_Print.TabIndex = 11;
            this.btn_Print.Text = "Báo cáo";
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Appearance.Options.UseFont = true;
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.btn_Close.Location = new System.Drawing.Point(437, 516);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(97, 25);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.Text = "Đóng";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // gridControl_ViewLog
            // 
            this.gridControl_ViewLog.Location = new System.Drawing.Point(0, 64);
            this.gridControl_ViewLog.MainView = this.gridView_ViewLog;
            this.gridControl_ViewLog.Name = "gridControl_ViewLog";
            this.gridControl_ViewLog.Size = new System.Drawing.Size(775, 447);
            this.gridControl_ViewLog.TabIndex = 14;
            this.gridControl_ViewLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_ViewLog});
            // 
            // gridView_ViewLog
            // 
            this.gridView_ViewLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_Time,
            this.c_Action,
            this.c_Employee});
            this.gridView_ViewLog.GridControl = this.gridControl_ViewLog;
            this.gridView_ViewLog.Name = "gridView_ViewLog";
            this.gridView_ViewLog.OptionsView.ShowGroupPanel = false;
            // 
            // c_Time
            // 
            this.c_Time.Caption = "Thời điểm";
            this.c_Time.FieldName = "Time";
            this.c_Time.Name = "c_Time";
            this.c_Time.OptionsColumn.AllowEdit = false;
            this.c_Time.OptionsColumn.AllowFocus = false;
            this.c_Time.Visible = true;
            this.c_Time.VisibleIndex = 0;
            this.c_Time.Width = 258;
            // 
            // c_Action
            // 
            this.c_Action.Caption = "Hành động";
            this.c_Action.FieldName = "Action";
            this.c_Action.Name = "c_Action";
            this.c_Action.OptionsColumn.AllowEdit = false;
            this.c_Action.OptionsColumn.AllowFocus = false;
            this.c_Action.Visible = true;
            this.c_Action.VisibleIndex = 2;
            this.c_Action.Width = 680;
            // 
            // c_Employee
            // 
            this.c_Employee.Caption = "Nhân viên";
            this.c_Employee.FieldName = "Employee";
            this.c_Employee.Name = "c_Employee";
            this.c_Employee.OptionsColumn.AllowEdit = false;
            this.c_Employee.OptionsColumn.AllowFocus = false;
            this.c_Employee.Visible = true;
            this.c_Employee.VisibleIndex = 1;
            this.c_Employee.Width = 242;
            // 
            // frm_ViewLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 546);
            this.Controls.Add(this.gridControl_ViewLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_Close);
            this.MaximizeBox = false;
            this.Name = "frm_ViewLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_ViewLog";
            this.Load += new System.EventHandler(this.frm_ViewLog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ViewLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_ViewLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_EndTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_BeginTime;
        private System.Windows.Forms.ComboBox comboBox_Employee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btn_Refresh;
        private DevExpress.XtraEditors.SimpleButton btn_Print;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraGrid.GridControl gridControl_ViewLog;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_ViewLog;
        private DevExpress.XtraGrid.Columns.GridColumn c_Time;
        private DevExpress.XtraGrid.Columns.GridColumn c_Action;
        private DevExpress.XtraGrid.Columns.GridColumn c_Employee;
    }
}