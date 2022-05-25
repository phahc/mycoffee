namespace Coffee
{
    partial class frm_AddEditIcon
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.pictureEdit_ICon = new DevExpress.XtraEditors.PictureEdit();
            this.textEdit_Link = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_Browser = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit_Skin = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.c_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.c_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_ICon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Link.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Skin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit_ICon
            // 
            this.pictureEdit_ICon.EditValue = "trống";
            this.pictureEdit_ICon.Location = new System.Drawing.Point(328, 78);
            this.pictureEdit_ICon.Name = "pictureEdit_ICon";
            this.pictureEdit_ICon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.pictureEdit_ICon.Properties.ReadOnly = true;
            this.pictureEdit_ICon.Properties.Tag = "Trống";
            this.pictureEdit_ICon.Size = new System.Drawing.Size(68, 56);
            this.pictureEdit_ICon.TabIndex = 0;
            // 
            // textEdit_Link
            // 
            this.textEdit_Link.Location = new System.Drawing.Point(83, 88);
            this.textEdit_Link.Name = "textEdit_Link";
            this.textEdit_Link.Properties.ReadOnly = true;
            this.textEdit_Link.Size = new System.Drawing.Size(189, 20);
            this.textEdit_Link.TabIndex = 1;
            // 
            // simpleButton_Browser
            // 
            this.simpleButton_Browser.Location = new System.Drawing.Point(278, 91);
            this.simpleButton_Browser.Name = "simpleButton_Browser";
            this.simpleButton_Browser.Size = new System.Drawing.Size(44, 17);
            this.simpleButton_Browser.TabIndex = 2;
            this.simpleButton_Browser.Text = "...";
            this.simpleButton_Browser.Click += new System.EventHandler(this.simpleButton_Browser_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(84, 140);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "Lưu";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(165, 140);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 4;
            this.btn_Close.Text = "Thoát";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(15, 91);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 15);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Đường dẫn";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(14, 117);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 15);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Nhóm hàng";
            // 
            // lookUpEdit_Skin
            // 
            this.lookUpEdit_Skin.Location = new System.Drawing.Point(82, 114);
            this.lookUpEdit_Skin.Name = "lookUpEdit_Skin";
            this.lookUpEdit_Skin.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lookUpEdit_Skin.Properties.Appearance.Options.UseFont = true;
            this.lookUpEdit_Skin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lookUpEdit_Skin.Properties.NullText = "Chọn dữ liệu";
            this.lookUpEdit_Skin.Properties.View = this.searchLookUpEdit1View;
            this.lookUpEdit_Skin.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lookUpEdit_Skin_Properties_ButtonClick);
            this.lookUpEdit_Skin.Size = new System.Drawing.Size(239, 22);
            this.lookUpEdit_Skin.TabIndex = 3;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.c_ID,
            this.c_Name});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // c_ID
            // 
            this.c_ID.Caption = "Mã";
            this.c_ID.FieldName = "ID";
            this.c_ID.Name = "c_ID";
            // 
            // c_Name
            // 
            this.c_Name.Caption = "Nhóm hàng";
            this.c_Name.FieldName = "Name";
            this.c_Name.Name = "c_Name";
            this.c_Name.Visible = true;
            this.c_Name.VisibleIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(398, 68);
            this.panelControl1.TabIndex = 6;
            this.panelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelControl1_MouseDown);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.EditValue = global::Coffee.Properties.Resources.write;
            this.pictureEdit1.Location = new System.Drawing.Point(3, 1);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(75, 65);
            this.pictureEdit1.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl3.Location = new System.Drawing.Point(84, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(200, 24);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "THÊM BIỂU TƯỢNG";
            // 
            // frm_AddEditIcon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 170);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.simpleButton_Browser);
            this.Controls.Add(this.textEdit_Link);
            this.Controls.Add(this.pictureEdit_ICon);
            this.Controls.Add(this.lookUpEdit_Skin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frm_AddEditIcon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Icon";
            this.Load += new System.EventHandler(this.frm_Icon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_ICon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Link.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit_Skin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit_ICon;
        private DevExpress.XtraEditors.TextEdit textEdit_Link;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Browser;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit lookUpEdit_Skin;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn c_ID;
        private DevExpress.XtraGrid.Columns.GridColumn c_Name;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}