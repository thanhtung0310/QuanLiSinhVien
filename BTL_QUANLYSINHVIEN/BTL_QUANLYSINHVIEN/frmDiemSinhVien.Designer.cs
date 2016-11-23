namespace BTL_QUANLYSINHVIEN
{
    partial class frmDiemSinhVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiemSinhVien));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnXemDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnNhapDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuuDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuy = new DevExpress.XtraBars.BarButtonItem();
            this.btnXuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcSV = new DevExpress.XtraGrid.GridControl();
            this.gvSV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaLHP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemChuyenCan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemQuaTrinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemTB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKyHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnamhoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLanThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.f = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cboKyHoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTenSV = new System.Windows.Forms.TextBox();
            this.tbMaSV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SVbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SVbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.DrawGroupsBorder = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnXemDiem,
            this.btnNhapDiem,
            this.btnLuuDiem,
            this.btnHuy,
            this.btnXuatExcel,
            this.btnRefresh});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(828, 75);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnXemDiem
            // 
            this.btnXemDiem.Caption = "Xem Điểm";
            this.btnXemDiem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXemDiem.Glyph")));
            this.btnXemDiem.Id = 2;
            this.btnXemDiem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnXemDiem.LargeGlyph")));
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemDiem_ItemClick);
            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.Caption = "Nhập Điểm";
            this.btnNhapDiem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnNhapDiem.Glyph")));
            this.btnNhapDiem.Id = 3;
            this.btnNhapDiem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnNhapDiem.LargeGlyph")));
            this.btnNhapDiem.Name = "btnNhapDiem";
            // 
            // btnLuuDiem
            // 
            this.btnLuuDiem.Caption = "Lưu Điểm";
            this.btnLuuDiem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLuuDiem.Glyph")));
            this.btnLuuDiem.Id = 4;
            this.btnLuuDiem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLuuDiem.LargeGlyph")));
            this.btnLuuDiem.Name = "btnLuuDiem";
            // 
            // btnHuy
            // 
            this.btnHuy.Caption = "Hủy";
            this.btnHuy.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHuy.Glyph")));
            this.btnHuy.Id = 5;
            this.btnHuy.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnHuy.LargeGlyph")));
            this.btnHuy.Name = "btnHuy";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Caption = "Xuất Excel \r\nPhiếu điểm Sinh Viên";
            this.btnXuatExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Glyph")));
            this.btnXuatExcel.Id = 6;
            this.btnXuatExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.LargeGlyph")));
            this.btnXuatExcel.Name = "btnXuatExcel";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup1,
            this.ribbonPageGroup4,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonrnParoupPageGroupribbonPageGrogeGroup13ribbup13ribbonPageGroup1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnXemDiem);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNhapDiem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnLuuDiem);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnHuy);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "ribbonPageGroup4";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnXuatExcel);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRefresh);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbon2PageGroup2";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gcSV
            // 
            this.gcSV.DataMember = "CustomSqlQuery";
            this.gcSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSV.Location = new System.Drawing.Point(0, 75);
            this.gcSV.MainView = this.gvSV;
            this.gcSV.Name = "gcSV";
            this.gcSV.Size = new System.Drawing.Size(828, 450);
            this.gcSV.TabIndex = 2;
            this.gcSV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSV});
            // 
            // gvSV
            // 
            this.gvSV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaLHP,
            this.colTenMH,
            this.colSoTC,
            this.colDiemChuyenCan,
            this.colDiemQuaTrinh,
            this.colDiemThi,
            this.colDiemTB,
            this.colKyHoc,
            this.colnamhoc,
            this.colSoLanThi});
            this.gvSV.GridControl = this.gcSV;
            this.gvSV.Name = "gvSV";
            this.gvSV.OptionsView.ShowGroupPanel = false;
            this.gvSV.OptionsView.ShowViewCaption = true;
            this.gvSV.ViewCaption = "Phiếu Điểm Sinh Viên";
            // 
            // colMaLHP
            // 
            this.colMaLHP.Caption = "Mã LHP";
            this.colMaLHP.FieldName = "MaLHP";
            this.colMaLHP.Name = "colMaLHP";
            this.colMaLHP.OptionsColumn.ReadOnly = true;
            this.colMaLHP.Visible = true;
            this.colMaLHP.VisibleIndex = 0;
            this.colMaLHP.Width = 84;
            // 
            // colTenMH
            // 
            this.colTenMH.Caption = "Tên môn học";
            this.colTenMH.FieldName = "TenMH";
            this.colTenMH.Name = "colTenMH";
            this.colTenMH.OptionsColumn.ReadOnly = true;
            this.colTenMH.Visible = true;
            this.colTenMH.VisibleIndex = 1;
            this.colTenMH.Width = 176;
            // 
            // colSoTC
            // 
            this.colSoTC.Caption = "Số TC";
            this.colSoTC.FieldName = "SoTC";
            this.colSoTC.Name = "colSoTC";
            this.colSoTC.OptionsColumn.ReadOnly = true;
            this.colSoTC.Visible = true;
            this.colSoTC.VisibleIndex = 2;
            this.colSoTC.Width = 50;
            // 
            // colDiemChuyenCan
            // 
            this.colDiemChuyenCan.Caption = "Điểm Chuyên Cần";
            this.colDiemChuyenCan.FieldName = "DiemChuyenCan";
            this.colDiemChuyenCan.Name = "colDiemChuyenCan";
            this.colDiemChuyenCan.Visible = true;
            this.colDiemChuyenCan.VisibleIndex = 3;
            this.colDiemChuyenCan.Width = 105;
            // 
            // colDiemQuaTrinh
            // 
            this.colDiemQuaTrinh.Caption = "Điểm Quá Trình";
            this.colDiemQuaTrinh.FieldName = "DiemQuaTrinh";
            this.colDiemQuaTrinh.Name = "colDiemQuaTrinh";
            this.colDiemQuaTrinh.Visible = true;
            this.colDiemQuaTrinh.VisibleIndex = 4;
            this.colDiemQuaTrinh.Width = 92;
            // 
            // colDiemThi
            // 
            this.colDiemThi.Caption = "Điểm Thi";
            this.colDiemThi.FieldName = "DiemThi";
            this.colDiemThi.Name = "colDiemThi";
            this.colDiemThi.Visible = true;
            this.colDiemThi.VisibleIndex = 5;
            this.colDiemThi.Width = 73;
            // 
            // colDiemTB
            // 
            this.colDiemTB.Caption = "Điểm Trung Bình";
            this.colDiemTB.FieldName = "DiemTB";
            this.colDiemTB.Name = "colDiemTB";
            this.colDiemTB.OptionsColumn.ReadOnly = true;
            this.colDiemTB.Visible = true;
            this.colDiemTB.VisibleIndex = 6;
            this.colDiemTB.Width = 87;
            // 
            // colKyHoc
            // 
            this.colKyHoc.Caption = "Kỳ Học";
            this.colKyHoc.FieldName = "KyHoc";
            this.colKyHoc.Name = "colKyHoc";
            this.colKyHoc.OptionsColumn.ReadOnly = true;
            this.colKyHoc.Visible = true;
            this.colKyHoc.VisibleIndex = 7;
            this.colKyHoc.Width = 43;
            // 
            // colnamhoc
            // 
            this.colnamhoc.FieldName = "namhoc";
            this.colnamhoc.Name = "colnamhoc";
            // 
            // colSoLanThi
            // 
            this.colSoLanThi.Caption = "Số Lần Thi";
            this.colSoLanThi.FieldName = "SoLanThi";
            this.colSoLanThi.Name = "colSoLanThi";
            this.colSoLanThi.OptionsColumn.ReadOnly = true;
            this.colSoLanThi.Visible = true;
            this.colSoLanThi.VisibleIndex = 8;
            this.colSoLanThi.Width = 62;
            // 
            // f
            // 
            this.f.AutoSize = true;
            this.f.Location = new System.Drawing.Point(5, 17);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(67, 13);
            this.f.TabIndex = 3;
            this.f.Text = "Mã Sinh Viên";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cboKyHoc);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.tbTenSV);
            this.panelControl1.Controls.Add(this.tbMaSV);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.f);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(399, 68);
            this.panelControl1.TabIndex = 4;
            // 
            // cboKyHoc
            // 
            this.cboKyHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKyHoc.FormattingEnabled = true;
            this.cboKyHoc.Items.AddRange(new object[] {
            "Tất cả"});
            this.cboKyHoc.Location = new System.Drawing.Point(289, 13);
            this.cboKyHoc.Name = "cboKyHoc";
            this.cboKyHoc.Size = new System.Drawing.Size(95, 21);
            this.cboKyHoc.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Kỳ học";
            // 
            // tbTenSV
            // 
            this.tbTenSV.Location = new System.Drawing.Point(82, 44);
            this.tbTenSV.Name = "tbTenSV";
            this.tbTenSV.ReadOnly = true;
            this.tbTenSV.Size = new System.Drawing.Size(143, 21);
            this.tbTenSV.TabIndex = 6;
            // 
            // tbMaSV
            // 
            this.tbMaSV.Location = new System.Drawing.Point(82, 14);
            this.tbMaSV.Name = "tbMaSV";
            this.tbMaSV.ReadOnly = true;
            this.tbMaSV.Size = new System.Drawing.Size(86, 21);
            this.tbMaSV.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên Sinh Viên";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 7;
            this.btnRefresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.LargeGlyph")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // frmDiemSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 525);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gcSV);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDiemSinhVien";
            this.Text = "frmDiemSinhVien";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SVbindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnXemDiem;
        private DevExpress.XtraBars.BarButtonItem btnNhapDiem;
        private DevExpress.XtraBars.BarButtonItem btnLuuDiem;
        private DevExpress.XtraBars.BarButtonItem btnHuy;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.GridControl gcSV;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSV;
        private DevExpress.XtraGrid.Columns.GridColumn colMaLHP;
        private DevExpress.XtraGrid.Columns.GridColumn colTenMH;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTC;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemChuyenCan;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemQuaTrinh;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemThi;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemTB;
        private DevExpress.XtraGrid.Columns.GridColumn colKyHoc;
        private DevExpress.XtraGrid.Columns.GridColumn colnamhoc;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLanThi;
        private System.Windows.Forms.Label f;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox tbTenSV;
        private System.Windows.Forms.TextBox tbMaSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource SVbindingSource;
        private DevExpress.XtraBars.BarButtonItem btnXuatExcel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.ComboBox cboKyHoc;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;

    }
}