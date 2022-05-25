namespace Coffee
{
    partial class frm_ChooseInPutStock
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
            this.spinEdit_Quantity = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Quantity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // spinEdit_Quantity
            // 
            this.spinEdit_Quantity.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_Quantity.Location = new System.Drawing.Point(60, 5);
            this.spinEdit_Quantity.Name = "spinEdit_Quantity";
            this.spinEdit_Quantity.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEdit_Quantity.Properties.Appearance.Options.UseFont = true;
            this.spinEdit_Quantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Quantity.Properties.EditFormat.FormatString = "d";
            this.spinEdit_Quantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit_Quantity.Properties.IsFloatValue = false;
            this.spinEdit_Quantity.Properties.Mask.EditMask = "d";
            this.spinEdit_Quantity.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spinEdit_Quantity.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_Quantity.Size = new System.Drawing.Size(92, 22);
            this.spinEdit_Quantity.TabIndex = 38;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(4, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 15);
            this.labelControl1.TabIndex = 41;
            this.labelControl1.Text = "Số lượng";
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = global::Coffee.Properties.Resources.Save;
            this.button_Save.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_Save.Location = new System.Drawing.Point(60, 31);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(43, 28);
            this.button_Save.TabIndex = 39;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.button_Close.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.button_Close.Location = new System.Drawing.Point(109, 31);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(43, 28);
            this.button_Close.TabIndex = 40;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frm_ChooseInPutStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 59);
            this.Controls.Add(this.spinEdit_Quantity);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ChooseInPutStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_ChooseInPutStock";
            this.Load += new System.EventHandler(this.frm_ChooseInPutStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Quantity.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spinEdit_Quantity;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
    }
}