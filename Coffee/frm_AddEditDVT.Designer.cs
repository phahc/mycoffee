namespace Coffee
{
    partial class frm_AddEditDVT
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddEditDVT));
            this.textEdit_DVTName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.listView_IconDVT = new System.Windows.Forms.ListView();
            this.pictureEdit_ImageChoose = new DevExpress.XtraEditors.PictureEdit();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.imageList_DVT = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DVTName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_ImageChoose.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit_DVTName
            // 
            this.textEdit_DVTName.Location = new System.Drawing.Point(88, 12);
            this.textEdit_DVTName.Name = "textEdit_DVTName";
            this.textEdit_DVTName.Size = new System.Drawing.Size(189, 20);
            this.textEdit_DVTName.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(1, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 15);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tên đơn vị tính";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(88, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 15);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Biểu tượng";
            // 
            // listView_IconDVT
            // 
            this.listView_IconDVT.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listView_IconDVT.Location = new System.Drawing.Point(88, 57);
            this.listView_IconDVT.Name = "listView_IconDVT";
            this.listView_IconDVT.Size = new System.Drawing.Size(226, 197);
            this.listView_IconDVT.TabIndex = 51;
            this.listView_IconDVT.UseCompatibleStateImageBehavior = false;
            this.listView_IconDVT.SelectedIndexChanged += new System.EventHandler(this.listView_IconDVT_SelectedIndexChanged);
            // 
            // pictureEdit_ImageChoose
            // 
            this.pictureEdit_ImageChoose.Location = new System.Drawing.Point(6, 57);
            this.pictureEdit_ImageChoose.Name = "pictureEdit_ImageChoose";
            this.pictureEdit_ImageChoose.Properties.NullText = "Trống";
            this.pictureEdit_ImageChoose.Size = new System.Drawing.Size(69, 49);
            this.pictureEdit_ImageChoose.TabIndex = 52;
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = ((System.Drawing.Image)(resources.GetObject("button_Close.Image")));
            this.button_Close.Location = new System.Drawing.Point(168, 260);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 28);
            this.button_Close.TabIndex = 54;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = ((System.Drawing.Image)(resources.GetObject("button_Save.Image")));
            this.button_Save.Location = new System.Drawing.Point(88, 260);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 28);
            this.button_Save.TabIndex = 53;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // imageList_DVT
            // 
            this.imageList_DVT.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_DVT.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList_DVT.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frm_AddEditDVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 294);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.pictureEdit_ImageChoose);
            this.Controls.Add(this.listView_IconDVT);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit_DVTName);
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.Name = "frm_AddEditDVT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_DVT";
            this.Load += new System.EventHandler(this.frm_AddEditDVT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_DVTName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_ImageChoose.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit_DVTName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ListView listView_IconDVT;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_ImageChoose;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private System.Windows.Forms.ImageList imageList_DVT;

    }
}