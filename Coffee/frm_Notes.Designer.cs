namespace Coffee
{
    partial class frm_Notes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit_Notes = new DevExpress.XtraEditors.MemoEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Notes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 28);
            this.panel1.TabIndex = 0;
            // 
            // btn_Close
            // 
            this.btn_Close.Image = global::Coffee.Properties.Resources.Turn_off;
            this.btn_Close.Location = new System.Drawing.Point(196, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.Text = "Thoát";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Image = global::Coffee.Properties.Resources.Save;
            this.btn_Save.Location = new System.Drawing.Point(115, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // memoEdit_Notes
            // 
            this.memoEdit_Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit_Notes.EditValue = "";
            this.memoEdit_Notes.Location = new System.Drawing.Point(0, 0);
            this.memoEdit_Notes.Name = "memoEdit_Notes";
            this.memoEdit_Notes.Size = new System.Drawing.Size(404, 169);
            this.memoEdit_Notes.TabIndex = 1;
            // 
            // frm_Notes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 197);
            this.Controls.Add(this.memoEdit_Notes);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Notes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Notes";
            this.Load += new System.EventHandler(this.frm_Notes_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit_Notes.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.MemoEdit memoEdit_Notes;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
    }
}