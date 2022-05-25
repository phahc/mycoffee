namespace Coffee.Reports
{
    partial class frm_ViewDemo
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
            this.printControl1 = new DevExpress.XtraPrinting.Control.PrintControl();
            this.SuspendLayout();
            // 
            // printControl1
            // 
            this.printControl1.BackColor = System.Drawing.Color.Empty;
            this.printControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printControl1.ForeColor = System.Drawing.Color.Empty;
            this.printControl1.IsMetric = false;
            this.printControl1.Location = new System.Drawing.Point(0, 0);
            this.printControl1.Name = "printControl1";
            this.printControl1.Size = new System.Drawing.Size(644, 470);
            this.printControl1.TabIndex = 0;
            this.printControl1.TooltipFont = new System.Drawing.Font("Tahoma", 8.25F);
            // 
            // frm_ViewDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 470);
            this.Controls.Add(this.printControl1);
            this.Name = "frm_ViewDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_ViewDemo";
            this.Load += new System.EventHandler(this.frm_ViewDemo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPrinting.Control.PrintControl printControl1;
    }
}