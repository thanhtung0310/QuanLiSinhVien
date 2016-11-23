namespace BTL_QUANLYSINHVIEN
{
    partial class frmQuanLyHocBong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyHocBong));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDSSV = new DevExpress.XtraBars.BarButtonItem();
            this.btnTieuChi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXemDiem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.abc = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.label1 = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.nbcTieuChi = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgTieuChi = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDS = new System.Windows.Forms.Button();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lbTieuChi3 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lbTieuChi2 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lbTieuChi1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.gcSV = new DevExpress.XtraGrid.GridControl();
            this.gvSV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenLop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemTL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLanThi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDieuKien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNamHoc = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbcTieuChi)).BeginInit();
            this.nbcTieuChi.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnDSSV,
            this.btnTieuChi,
            this.btnXemDiem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(813, 96);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnDSSV
            // 
            this.btnDSSV.Caption = "Danh sách Sinh viên";
            this.btnDSSV.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDSSV.Glyph")));
            this.btnDSSV.Id = 1;
            this.btnDSSV.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDSSV.LargeGlyph")));
            this.btnDSSV.Name = "btnDSSV";
            this.btnDSSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSSV_ItemClick);
            // 
            // btnTieuChi
            // 
            this.btnTieuChi.Caption = "Tiêu chí xét học bổng";
            this.btnTieuChi.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTieuChi.Glyph")));
            this.btnTieuChi.Id = 2;
            this.btnTieuChi.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTieuChi.LargeGlyph")));
            this.btnTieuChi.Name = "btnTieuChi";
            this.btnTieuChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTieuChi_ItemClick);
            // 
            // btnXemDiem
            // 
            this.btnXemDiem.Caption = "Xem điểm Sinh viên";
            this.btnXemDiem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXemDiem.Glyph")));
            this.btnXemDiem.Id = 3;
            this.btnXemDiem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnXemDiem.LargeGlyph")));
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemDiem_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.abc});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "                    Thông tin Khoa                     ";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDSSV);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnXemDiem);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Sinh viên";
            // 
            // abc
            // 
            this.abc.AllowTextClipping = false;
            this.abc.ItemLinks.Add(this.btnTieuChi);
            this.abc.Name = "abc";
            this.abc.ShowCaptionButton = false;
            this.abc.Text = "Tiêu chí xét học bổng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên Khoa";
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(92, 16);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(131, 21);
            this.cboKhoa.TabIndex = 2;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
            // 
            // nbcTieuChi
            // 
            this.nbcTieuChi.ActiveGroup = this.nbgTieuChi;
            this.nbcTieuChi.Controls.Add(this.navBarGroupControlContainer1);
            this.nbcTieuChi.Dock = System.Windows.Forms.DockStyle.Right;
            this.nbcTieuChi.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgTieuChi});
            this.nbcTieuChi.Location = new System.Drawing.Point(776, 96);
            this.nbcTieuChi.Name = "nbcTieuChi";
            this.nbcTieuChi.OptionsNavPane.ExpandedWidth = 228;
            this.nbcTieuChi.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
            this.nbcTieuChi.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nbcTieuChi.Size = new System.Drawing.Size(37, 479);
            this.nbcTieuChi.TabIndex = 4;
            this.nbcTieuChi.Text = "Tiêu chí xét học bổng";
            // 
            // nbgTieuChi
            // 
            this.nbgTieuChi.Caption = "Tiêu chí xét học bổng";
            this.nbgTieuChi.ControlContainer = this.navBarGroupControlContainer1;
            this.nbgTieuChi.Expanded = true;
            this.nbgTieuChi.GroupClientHeight = 376;
            this.nbgTieuChi.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgTieuChi.Name = "nbgTieuChi";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer1.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer1.Controls.Add(this.btnHuy);
            this.navBarGroupControlContainer1.Controls.Add(this.btnDS);
            this.navBarGroupControlContainer1.Controls.Add(this.groupControl3);
            this.navBarGroupControlContainer1.Controls.Add(this.groupControl2);
            this.navBarGroupControlContainer1.Controls.Add(this.groupControl1);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(228, 376);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(141, 340);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDS
            // 
            this.btnDS.Location = new System.Drawing.Point(30, 340);
            this.btnDS.Name = "btnDS";
            this.btnDS.Size = new System.Drawing.Size(75, 23);
            this.btnDS.TabIndex = 3;
            this.btnDS.Text = "Danh sách";
            this.btnDS.UseVisualStyleBackColor = true;
            this.btnDS.Click += new System.EventHandler(this.btnDS_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.lbTieuChi3);
            this.groupControl3.Controls.Add(this.label4);
            this.groupControl3.Controls.Add(this.tb3);
            this.groupControl3.Location = new System.Drawing.Point(3, 232);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(222, 92);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Học bổng loại B";
            // 
            // lbTieuChi3
            // 
            this.lbTieuChi3.AutoSize = true;
            this.lbTieuChi3.Location = new System.Drawing.Point(27, 67);
            this.lbTieuChi3.Name = "lbTieuChi3";
            this.lbTieuChi3.Size = new System.Drawing.Size(51, 13);
            this.lbTieuChi3.TabIndex = 3;
            this.lbTieuChi3.TabStop = true;
            this.lbTieuChi3.Text = "Điều kiện";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số lượng";
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(124, 34);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(67, 21);
            this.tb3.TabIndex = 0;
            this.tb3.Validated += new System.EventHandler(this.tb3_Validated);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lbTieuChi2);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.tb2);
            this.groupControl2.Location = new System.Drawing.Point(3, 119);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(222, 92);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Học bổng loại A";
            // 
            // lbTieuChi2
            // 
            this.lbTieuChi2.AutoSize = true;
            this.lbTieuChi2.Location = new System.Drawing.Point(27, 68);
            this.lbTieuChi2.Name = "lbTieuChi2";
            this.lbTieuChi2.Size = new System.Drawing.Size(51, 13);
            this.lbTieuChi2.TabIndex = 3;
            this.lbTieuChi2.TabStop = true;
            this.lbTieuChi2.Text = "Điều kiện";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số lượng";
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(124, 34);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(67, 21);
            this.tb2.TabIndex = 0;
            this.tb2.Validated += new System.EventHandler(this.tb2_Validated);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lbTieuChi1);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.tb1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(222, 92);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Học bổng Lê Qúy Đôn";
            // 
            // lbTieuChi1
            // 
            this.lbTieuChi1.AutoSize = true;
            this.lbTieuChi1.Location = new System.Drawing.Point(27, 67);
            this.lbTieuChi1.Name = "lbTieuChi1";
            this.lbTieuChi1.Size = new System.Drawing.Size(51, 13);
            this.lbTieuChi1.TabIndex = 2;
            this.lbTieuChi1.TabStop = true;
            this.lbTieuChi1.Tag = "";
            this.lbTieuChi1.Text = "Điều kiện";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lượng";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(124, 34);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(67, 21);
            this.tb1.TabIndex = 0;
            this.tb1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb1_KeyPress);
            this.tb1.Validated += new System.EventHandler(this.tb1_Validated);
            // 
            // gcSV
            // 
            this.gcSV.DataMember = "CustomSqlQuery";
            this.gcSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSV.Location = new System.Drawing.Point(0, 96);
            this.gcSV.MainView = this.gvSV;
            this.gcSV.MenuManager = this.ribbonControl1;
            this.gcSV.Name = "gcSV";
            this.gcSV.Size = new System.Drawing.Size(776, 479);
            this.gcSV.TabIndex = 5;
            this.gcSV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSV});
            // 
            // gvSV
            // 
            this.gvSV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaSV,
            this.colTenSV,
            this.colNgaySinh,
            this.colTenLop,
            this.colDiemTL,
            this.colGhiChu,
            this.colLanThi,
            this.colDieuKien});
            this.gvSV.GridControl = this.gcSV;
            this.gvSV.Name = "gvSV";
            this.gvSV.OptionsFind.AllowFindPanel = false;
            this.gvSV.OptionsFind.AlwaysVisible = true;
            this.gvSV.OptionsFind.FindNullPrompt = "Tìm kiếm nhanh...";
            this.gvSV.OptionsView.ShowGroupPanel = false;
            this.gvSV.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvSV_ValidateRow);
            // 
            // colMaSV
            // 
            this.colMaSV.Caption = "Mã Sinh viên";
            this.colMaSV.FieldName = "MaSV";
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.Visible = true;
            this.colMaSV.VisibleIndex = 0;
            this.colMaSV.Width = 65;
            // 
            // colTenSV
            // 
            this.colTenSV.Caption = "Họ tên Sinh viên";
            this.colTenSV.FieldName = "TenSV";
            this.colTenSV.Name = "colTenSV";
            this.colTenSV.Visible = true;
            this.colTenSV.VisibleIndex = 1;
            this.colTenSV.Width = 129;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Caption = "Ngày Sinh";
            this.colNgaySinh.FieldName = "NgaySinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 2;
            this.colNgaySinh.Width = 68;
            // 
            // colTenLop
            // 
            this.colTenLop.Caption = "Tên Lớp";
            this.colTenLop.FieldName = "TenLop";
            this.colTenLop.Name = "colTenLop";
            this.colTenLop.Visible = true;
            this.colTenLop.VisibleIndex = 3;
            this.colTenLop.Width = 104;
            // 
            // colDiemTL
            // 
            this.colDiemTL.Caption = "Điểm Tích lũy";
            this.colDiemTL.FieldName = "DiemTL";
            this.colDiemTL.Name = "colDiemTL";
            this.colDiemTL.Visible = true;
            this.colDiemTL.VisibleIndex = 4;
            this.colDiemTL.Width = 82;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi Chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 5;
            this.colGhiChu.Width = 119;
            // 
            // colLanThi
            // 
            this.colLanThi.Caption = "Lần Thi";
            this.colLanThi.FieldName = "LanThi";
            this.colLanThi.Name = "colLanThi";
            // 
            // colDieuKien
            // 
            this.colDieuKien.Caption = "Điều kiện";
            this.colDieuKien.FieldName = "DieuKien";
            this.colDieuKien.Name = "colDieuKien";
            this.colDieuKien.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Năm học";
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.FormattingEnabled = true;
            this.cboNamHoc.Location = new System.Drawing.Point(92, 45);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(131, 21);
            this.cboNamHoc.TabIndex = 8;
            // 
            // frmQuanLyHocBong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 575);
            this.Controls.Add(this.cboNamHoc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gcSV);
            this.Controls.Add(this.nbcTieuChi);
            this.Controls.Add(this.cboKhoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmQuanLyHocBong";
            this.Text = "Quản lý học bổng";
            this.Load += new System.EventHandler(this.frmQuanLyHocBong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbcTieuChi)).EndInit();
            this.nbcTieuChi.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
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
        private DevExpress.XtraBars.BarButtonItem btnDSSV;
        private DevExpress.XtraBars.BarButtonItem btnTieuChi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup abc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboKhoa;
        private DevExpress.XtraNavBar.NavBarControl nbcTieuChi;
        private DevExpress.XtraNavBar.NavBarGroup nbgTieuChi;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb1;
        private DevExpress.XtraGrid.GridControl gcSV;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSV;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.LinkLabel lbTieuChi3;
        private System.Windows.Forms.LinkLabel lbTieuChi2;
        private System.Windows.Forms.LinkLabel lbTieuChi1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSV;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSV;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLop;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboNamHoc;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDS;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemTL;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colLanThi;
        private DevExpress.XtraGrid.Columns.GridColumn colDieuKien;
        private DevExpress.XtraBars.BarButtonItem btnXemDiem;
    }
}