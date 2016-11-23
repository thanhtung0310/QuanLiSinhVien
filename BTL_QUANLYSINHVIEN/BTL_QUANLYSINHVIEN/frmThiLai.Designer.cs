namespace BTL_QUANLYSINHVIEN
{
    partial class frmThiLai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThiLai));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDS = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMH = new System.Windows.Forms.ComboBox();
            this.gcSV = new DevExpress.XtraGrid.GridControl();
            this.gvSV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenLop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.DrawGroupsBorder = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnDS});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(694, 75);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnDS
            // 
            this.btnDS.Caption = "Danh sách Sinh viên";
            this.btnDS.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDS.Glyph")));
            this.btnDS.Id = 1;
            this.btnDS.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDS.LargeGlyph")));
            this.btnDS.Name = "btnDS";
            this.btnDS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDS_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "                                                              ";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDS);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Môn học";
            // 
            // cboMH
            // 
            this.cboMH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMH.FormattingEnabled = true;
            this.cboMH.Location = new System.Drawing.Point(79, 31);
            this.cboMH.Name = "cboMH";
            this.cboMH.Size = new System.Drawing.Size(131, 21);
            this.cboMH.TabIndex = 2;
            // 
            // gcSV
            // 
            this.gcSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSV.Location = new System.Drawing.Point(0, 75);
            this.gcSV.MainView = this.gvSV;
            this.gcSV.MenuManager = this.ribbonControl1;
            this.gcSV.Name = "gcSV";
            this.gcSV.Size = new System.Drawing.Size(694, 455);
            this.gcSV.TabIndex = 3;
            this.gcSV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSV});
            // 
            // gvSV
            // 
            this.gvSV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaSV,
            this.colTenSV,
            this.colNgaySinh,
            this.colTenLop});
            this.gvSV.GridControl = this.gcSV;
            this.gvSV.Name = "gvSV";
            this.gvSV.OptionsFind.AllowFindPanel = false;
            this.gvSV.OptionsFind.AlwaysVisible = true;
            this.gvSV.OptionsFind.FindNullPrompt = "Tìm kiếm nhanh...";
            this.gvSV.OptionsView.ShowGroupPanel = false;
            // 
            // colMaSV
            // 
            this.colMaSV.Caption = "Mã Sinh viên";
            this.colMaSV.FieldName = "MaSV";
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.Visible = true;
            this.colMaSV.VisibleIndex = 0;
            // 
            // colTenSV
            // 
            this.colTenSV.Caption = "Họ tên Sinh viên";
            this.colTenSV.FieldName = "TenSV";
            this.colTenSV.Name = "colTenSV";
            this.colTenSV.Visible = true;
            this.colTenSV.VisibleIndex = 1;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Caption = "Ngày Sinh";
            this.colNgaySinh.FieldName = "NgaySinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 2;
            // 
            // colTenLop
            // 
            this.colTenLop.Caption = "Tên Lớp";
            this.colTenLop.FieldName = "TenLop";
            this.colTenLop.Name = "colTenLop";
            this.colTenLop.Visible = true;
            this.colTenLop.VisibleIndex = 3;
            // 
            // frmThiLai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 530);
            this.Controls.Add(this.gcSV);
            this.Controls.Add(this.cboMH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmThiLai";
            this.Text = "Danh sách Sinh viên thi lại";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnDS;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMH;
        private DevExpress.XtraGrid.GridControl gcSV;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSV;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSV;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSV;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLop;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}