namespace Coffee
{
    partial class frm_AddEditMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddEditMenu));
            this.radioButton_Running = new System.Windows.Forms.RadioButton();
            this.radioButton_Stop = new System.Windows.Forms.RadioButton();
            this.textEdit_MenuName = new DevExpress.XtraEditors.TextEdit();
            this.button_Save = new DevExpress.XtraEditors.SimpleButton();
            this.button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView_IconMenu = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList_IconMenu = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pictureEdit_ImageChoose = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MenuName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_ImageChoose.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton_Running
            // 
            this.radioButton_Running.AutoSize = true;
            this.radioButton_Running.Checked = true;
            this.radioButton_Running.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Running.Location = new System.Drawing.Point(101, 37);
            this.radioButton_Running.Name = "radioButton_Running";
            this.radioButton_Running.Size = new System.Drawing.Size(84, 19);
            this.radioButton_Running.TabIndex = 2;
            this.radioButton_Running.TabStop = true;
            this.radioButton_Running.Text = "Đang dùng";
            this.radioButton_Running.UseVisualStyleBackColor = true;
            // 
            // radioButton_Stop
            // 
            this.radioButton_Stop.AutoSize = true;
            this.radioButton_Stop.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Stop.Location = new System.Drawing.Point(216, 38);
            this.radioButton_Stop.Name = "radioButton_Stop";
            this.radioButton_Stop.Size = new System.Drawing.Size(80, 19);
            this.radioButton_Stop.TabIndex = 3;
            this.radioButton_Stop.Text = "Tạm dừng";
            this.radioButton_Stop.UseVisualStyleBackColor = true;
            // 
            // textEdit_MenuName
            // 
            this.textEdit_MenuName.Location = new System.Drawing.Point(101, 12);
            this.textEdit_MenuName.Name = "textEdit_MenuName";
            this.textEdit_MenuName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.textEdit_MenuName.Properties.MaxLength = 20;
            this.textEdit_MenuName.Size = new System.Drawing.Size(195, 20);
            this.textEdit_MenuName.TabIndex = 1;
            // 
            // button_Save
            // 
            this.button_Save.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Appearance.Options.UseFont = true;
            this.button_Save.Image = ((System.Drawing.Image)(resources.GetObject("button_Save.Image")));
            this.button_Save.Location = new System.Drawing.Point(102, 183);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 31);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Lưu";
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Close.Appearance.Options.UseFont = true;
            this.button_Close.Image = ((System.Drawing.Image)(resources.GetObject("button_Close.Image")));
            this.button_Close.Location = new System.Drawing.Point(183, 183);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 31);
            this.button_Close.TabIndex = 6;
            this.button_Close.Text = "Thoát";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Tình trạng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "Tên thực đơn";
            // 
            // listView_IconMenu
            // 
            this.listView_IconMenu.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listView_IconMenu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colIndex,
            this.columnHeader1});
            this.listView_IconMenu.GridLines = true;
            this.listView_IconMenu.LargeImageList = this.imageList_IconMenu;
            this.listView_IconMenu.Location = new System.Drawing.Point(101, 63);
            this.listView_IconMenu.Name = "listView_IconMenu";
            this.listView_IconMenu.Size = new System.Drawing.Size(269, 114);
            this.listView_IconMenu.TabIndex = 5;
            this.listView_IconMenu.UseCompatibleStateImageBehavior = false;
            this.listView_IconMenu.SelectedIndexChanged += new System.EventHandler(this.listView_IconMenu_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.DisplayIndex = 1;
            this.colName.Text = "Biểu tượng";
            // 
            // colIndex
            // 
            this.colIndex.DisplayIndex = 0;
            this.colIndex.Text = "Vị trí";
            // 
            // imageList_IconMenu
            // 
            this.imageList_IconMenu.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList_IconMenu.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList_IconMenu.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 38;
            this.label3.Text = "Biểu tượng";
            // 
            // pictureEdit_ImageChoose
            // 
            this.pictureEdit_ImageChoose.Location = new System.Drawing.Point(12, 100);
            this.pictureEdit_ImageChoose.Name = "pictureEdit_ImageChoose";
            this.pictureEdit_ImageChoose.Properties.NullText = "Trống";
            this.pictureEdit_ImageChoose.Size = new System.Drawing.Size(70, 61);
            this.pictureEdit_ImageChoose.TabIndex = 46;
            // 
            // frm_AddEditMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 217);
            this.Controls.Add(this.pictureEdit_ImageChoose);
            this.Controls.Add(this.listView_IconMenu);
            this.Controls.Add(this.radioButton_Running);
            this.Controls.Add(this.radioButton_Stop);
            this.Controls.Add(this.textEdit_MenuName);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.LookAndFeel.SkinName = "Dark Side";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_AddEditMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_AddEditMenu";
            this.Load += new System.EventHandler(this.frm_AddEditMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_MenuName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_ImageChoose.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_Running;
        private System.Windows.Forms.RadioButton radioButton_Stop;
        private DevExpress.XtraEditors.TextEdit textEdit_MenuName;
        private DevExpress.XtraEditors.SimpleButton button_Save;
        private DevExpress.XtraEditors.SimpleButton button_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView_IconMenu;
        private System.Windows.Forms.ImageList imageList_IconMenu;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_ImageChoose;
    }
}