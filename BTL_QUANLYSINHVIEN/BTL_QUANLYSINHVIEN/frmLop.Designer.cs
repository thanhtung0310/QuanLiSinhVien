namespace BTL_QUANLYSINHVIEN
{
    partial class frmLop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLop));
            this.nbcDSLop = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgThongTin = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.gcDSLop = new DevExpress.XtraGrid.GridControl();
            this.gvDSLop = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaLop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenLop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDSLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnThemLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnSuaLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoaLop = new DevExpress.XtraBars.BarButtonItem();
            this.btnXemDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnCapNhat = new DevExpress.XtraBars.BarButtonItem();
            this.btnXemDiemLop = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cboTenKhoa = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.tbSiSo = new System.Windows.Forms.TextBox();
            this.tbTenLop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaLop = new System.Windows.Forms.TextBox();
            this.nbcLop = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgLop = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.DSLopbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LopbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gcLop = new DevExpress.XtraGrid.GridControl();
            this.gvLop = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNhapHoc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nbcDSLop)).BeginInit();
            this.nbcDSLop.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDSLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbcLop)).BeginInit();
            this.nbcLop.SuspendLayout();
            this.navBarGroupControlContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DSLopbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LopbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLop)).BeginInit();
            this.SuspendLayout();
            // 
            // nbcDSLop
            // 
            this.nbcDSLop.ActiveGroup = this.nbgThongTin;
            this.nbcDSLop.Controls.Add(this.navBarGroupControlContainer1);
            this.nbcDSLop.Dock = System.Windows.Forms.DockStyle.Left;
            this.nbcDSLop.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgThongTin});
            this.nbcDSLop.Location = new System.Drawing.Point(0, 0);
            this.nbcDSLop.Name = "nbcDSLop";
            this.nbcDSLop.OptionsNavPane.ExpandedWidth = 428;
            this.nbcDSLop.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
            this.nbcDSLop.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nbcDSLop.Size = new System.Drawing.Size(37, 480);
            this.nbcDSLop.TabIndex = 3;
            this.nbcDSLop.Text = "Danh Sách Lớp";
            // 
            // nbgThongTin
            // 
            this.nbgThongTin.Caption = "Danh Sách Lớp";
            this.nbgThongTin.ControlContainer = this.navBarGroupControlContainer1;
            this.nbgThongTin.Expanded = true;
            this.nbgThongTin.GroupClientHeight = 377;
            this.nbgThongTin.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgThongTin.Name = "nbgThongTin";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer1.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer1.Controls.Add(this.gcDSLop);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(428, 377);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // gcDSLop
            // 
            this.gcDSLop.DataMember = "CustomSqlQuery";
            this.gcDSLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDSLop.Location = new System.Drawing.Point(0, 0);
            this.gcDSLop.MainView = this.gvDSLop;
            this.gcDSLop.MenuManager = this.ribbonControl1;
            this.gcDSLop.Name = "gcDSLop";
            this.gcDSLop.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gcDSLop.Size = new System.Drawing.Size(428, 377);
            this.gcDSLop.TabIndex = 5;
            this.gcDSLop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDSLop});
            // 
            // gvDSLop
            // 
            this.gvDSLop.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaLop,
            this.colTenLop,
            this.colSiSo,
            this.colTenKhoa});
            this.gvDSLop.GridControl = this.gcDSLop;
            this.gvDSLop.Name = "gvDSLop";
            this.gvDSLop.OptionsFind.AlwaysVisible = true;
            this.gvDSLop.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gvDSLop.OptionsView.ShowGroupPanel = false;
            this.gvDSLop.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDSLop_FocusedRowChanged);
            this.gvDSLop.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvDSLop_ValidateRow);
            // 
            // colMaLop
            // 
            this.colMaLop.Caption = "Mã Lớp";
            this.colMaLop.FieldName = "MaLop";
            this.colMaLop.Name = "colMaLop";
            this.colMaLop.OptionsColumn.ReadOnly = true;
            this.colMaLop.Visible = true;
            this.colMaLop.VisibleIndex = 0;
            this.colMaLop.Width = 56;
            // 
            // colTenLop
            // 
            this.colTenLop.Caption = "Tên Lớp";
            this.colTenLop.FieldName = "TenLop";
            this.colTenLop.Name = "colTenLop";
            this.colTenLop.Visible = true;
            this.colTenLop.VisibleIndex = 1;
            this.colTenLop.Width = 151;
            // 
            // colSiSo
            // 
            this.colSiSo.Caption = "Sĩ Số";
            this.colSiSo.FieldName = "SiSo";
            this.colSiSo.Name = "colSiSo";
            this.colSiSo.OptionsColumn.ReadOnly = true;
            this.colSiSo.Visible = true;
            this.colSiSo.VisibleIndex = 2;
            this.colSiSo.Width = 80;
            // 
            // colTenKhoa
            // 
            this.colTenKhoa.Caption = "Tên Khoa";
            this.colTenKhoa.ColumnEdit = this.repositoryItemComboBox1;
            this.colTenKhoa.FieldName = "TenKhoa";
            this.colTenKhoa.Name = "colTenKhoa";
            this.colTenKhoa.Visible = true;
            this.colTenKhoa.VisibleIndex = 3;
            this.colTenKhoa.Width = 123;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.DrawGroupsBorder = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnDSLop,
            this.btnThemLop,
            this.btnSuaLop,
            this.btnXoaLop,
            this.btnXemDiem,
            this.btnCapNhat,
            this.btnXemDiemLop});
            this.ribbonControl1.Location = new System.Drawing.Point(37, 0);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1038, 75);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnDSLop
            // 
            this.btnDSLop.Caption = "Danh Sách Lớp";
            this.btnDSLop.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDSLop.Glyph")));
            this.btnDSLop.Id = 1;
            this.btnDSLop.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDSLop.LargeGlyph")));
            this.btnDSLop.Name = "btnDSLop";
            this.btnDSLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSLop_ItemClick);
            // 
            // btnThemLop
            // 
            this.btnThemLop.Caption = "Thêm";
            this.btnThemLop.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThemLop.Glyph")));
            this.btnThemLop.Id = 2;
            this.btnThemLop.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnThemLop.LargeGlyph")));
            this.btnThemLop.Name = "btnThemLop";
            this.btnThemLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemLop_ItemClick);
            // 
            // btnSuaLop
            // 
            this.btnSuaLop.Caption = "Sửa";
            this.btnSuaLop.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSuaLop.Glyph")));
            this.btnSuaLop.Id = 3;
            this.btnSuaLop.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSuaLop.LargeGlyph")));
            this.btnSuaLop.Name = "btnSuaLop";
            this.btnSuaLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSuaLop_ItemClick);
            // 
            // btnXoaLop
            // 
            this.btnXoaLop.Caption = "Xóa";
            this.btnXoaLop.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXoaLop.Glyph")));
            this.btnXoaLop.Id = 4;
            this.btnXoaLop.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnXoaLop.LargeGlyph")));
            this.btnXoaLop.Name = "btnXoaLop";
            this.btnXoaLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoaLop_ItemClick);
            // 
            // btnXemDiem
            // 
            this.btnXemDiem.Caption = "Xem Điểm Sinh Viên";
            this.btnXemDiem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXemDiem.Glyph")));
            this.btnXemDiem.Id = 5;
            this.btnXemDiem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnXemDiem.LargeGlyph")));
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemDiem_ItemClick);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Caption = "Cập nhật Dữ liệu";
            this.btnCapNhat.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Glyph")));
            this.btnCapNhat.Id = 7;
            this.btnCapNhat.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.LargeGlyph")));
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCapNhat_ItemClick);
            // 
            // btnXemDiemLop
            // 
            this.btnXemDiemLop.Caption = "Xem điểm Lớp";
            this.btnXemDiemLop.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXemDiemLop.Glyph")));
            this.btnXemDiemLop.Id = 8;
            this.btnXemDiemLop.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnXemDiemLop.LargeGlyph")));
            this.btnXemDiemLop.Name = "btnXemDiemLop";
            this.btnXemDiemLop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemDiemLop_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDSLop);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnThemLop);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnSuaLop);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnXoaLop);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnXemDiem);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnXemDiemLop);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnCapNhat);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cboTenKhoa);
            this.panelControl1.Controls.Add(this.btnLuu);
            this.panelControl1.Controls.Add(this.btnHuy);
            this.panelControl1.Controls.Add(this.tbSiSo);
            this.panelControl1.Controls.Add(this.tbTenLop);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.tbMaLop);
            this.panelControl1.Location = new System.Drawing.Point(3, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(221, 216);
            this.panelControl1.TabIndex = 9;
            // 
            // cboTenKhoa
            // 
            this.cboTenKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenKhoa.FormattingEnabled = true;
            this.cboTenKhoa.Location = new System.Drawing.Point(75, 124);
            this.cboTenKhoa.Name = "cboTenKhoa";
            this.cboTenKhoa.Size = new System.Drawing.Size(130, 21);
            this.cboTenKhoa.TabIndex = 32;
            // 
            // btnLuu
            // 
            this.btnLuu.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnLuu.Location = new System.Drawing.Point(21, 169);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 31;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnHuy.Location = new System.Drawing.Point(130, 169);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 30;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // tbSiSo
            // 
            this.tbSiSo.Location = new System.Drawing.Point(75, 85);
            this.tbSiSo.Name = "tbSiSo";
            this.tbSiSo.ReadOnly = true;
            this.tbSiSo.Size = new System.Drawing.Size(130, 21);
            this.tbSiSo.TabIndex = 5;
            // 
            // tbTenLop
            // 
            this.tbTenLop.Location = new System.Drawing.Point(75, 47);
            this.tbTenLop.Name = "tbTenLop";
            this.tbTenLop.Size = new System.Drawing.Size(130, 21);
            this.tbTenLop.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Khoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sĩ Số";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Lớp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Lớp";
            // 
            // tbMaLop
            // 
            this.tbMaLop.Location = new System.Drawing.Point(75, 13);
            this.tbMaLop.Name = "tbMaLop";
            this.tbMaLop.ReadOnly = true;
            this.tbMaLop.Size = new System.Drawing.Size(130, 21);
            this.tbMaLop.TabIndex = 1;
            // 
            // nbcLop
            // 
            this.nbcLop.ActiveGroup = this.nbgLop;
            this.nbcLop.Controls.Add(this.navBarGroupControlContainer2);
            this.nbcLop.Dock = System.Windows.Forms.DockStyle.Left;
            this.nbcLop.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgLop});
            this.nbcLop.Location = new System.Drawing.Point(37, 75);
            this.nbcLop.Name = "nbcLop";
            this.nbcLop.OptionsNavPane.ExpandedWidth = 232;
            this.nbcLop.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nbcLop.Size = new System.Drawing.Size(232, 405);
            this.nbcLop.TabIndex = 10;
            this.nbcLop.Text = "Thông tin Lớp";
            // 
            // nbgLop
            // 
            this.nbgLop.Caption = "Thông tin lớp";
            this.nbgLop.ControlContainer = this.navBarGroupControlContainer2;
            this.nbgLop.Expanded = true;
            this.nbgLop.GroupClientHeight = 235;
            this.nbgLop.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgLop.Name = "nbgLop";
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer2.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer2.Controls.Add(this.panelControl1);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(232, 302);
            this.navBarGroupControlContainer2.TabIndex = 0;
            // 
            // gcLop
            // 
            this.gcLop.DataMember = "CustomSqlQuery";
            this.gcLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLop.Location = new System.Drawing.Point(269, 75);
            this.gcLop.MainView = this.gvLop;
            this.gcLop.MenuManager = this.ribbonControl1;
            this.gcLop.Name = "gcLop";
            this.gcLop.Size = new System.Drawing.Size(806, 405);
            this.gcLop.TabIndex = 16;
            this.gcLop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLop});
            // 
            // gvLop
            // 
            this.gvLop.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaSV,
            this.colTenSV,
            this.colGioiTinh,
            this.colNgaySinh,
            this.colDiaChi,
            this.colNgayNhapHoc});
            this.gvLop.GridControl = this.gcLop;
            this.gvLop.Name = "gvLop";
            this.gvLop.OptionsFind.AlwaysVisible = true;
            this.gvLop.OptionsFind.FindNullPrompt = "Tìm kiếm nhanh...";
            this.gvLop.OptionsView.ShowGroupPanel = false;
            // 
            // colMaSV
            // 
            this.colMaSV.Caption = "Mã Sinh Viên";
            this.colMaSV.FieldName = "MaSV";
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.Visible = true;
            this.colMaSV.VisibleIndex = 0;
            // 
            // colTenSV
            // 
            this.colTenSV.Caption = "Tên Sinh Viên";
            this.colTenSV.FieldName = "TenSV";
            this.colTenSV.Name = "colTenSV";
            this.colTenSV.Visible = true;
            this.colTenSV.VisibleIndex = 1;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.Caption = "Giới Tính";
            this.colGioiTinh.FieldName = "GioiTinh";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.Visible = true;
            this.colGioiTinh.VisibleIndex = 2;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Caption = "Ngày Sinh";
            this.colNgaySinh.FieldName = "NgaySinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 3;
            // 
            // colDiaChi
            // 
            this.colDiaChi.Caption = "Địa Chỉ";
            this.colDiaChi.FieldName = "DiaChi";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 4;
            // 
            // colNgayNhapHoc
            // 
            this.colNgayNhapHoc.Caption = "Ngày nhập học";
            this.colNgayNhapHoc.FieldName = "NgayNhapHoc";
            this.colNgayNhapHoc.Name = "colNgayNhapHoc";
            this.colNgayNhapHoc.Visible = true;
            this.colNgayNhapHoc.VisibleIndex = 5;
            // 
            // frmLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 480);
            this.Controls.Add(this.gcLop);
            this.Controls.Add(this.nbcLop);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.nbcDSLop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLop";
            this.Text = "frmLop";
            this.Load += new System.EventHandler(this.frmLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nbcDSLop)).EndInit();
            this.nbcDSLop.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDSLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDSLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbcLop)).EndInit();
            this.nbcLop.ResumeLayout(false);
            this.navBarGroupControlContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DSLopbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LopbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl nbcDSLop;
        private DevExpress.XtraNavBar.NavBarGroup nbgThongTin;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox cboTenKhoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox tbSiSo;
        private System.Windows.Forms.TextBox tbTenLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaLop;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl gcDSLop;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDSLop;
        private DevExpress.XtraGrid.Columns.GridColumn colMaLop;
        private DevExpress.XtraGrid.Columns.GridColumn colTenLop;
        private DevExpress.XtraGrid.Columns.GridColumn colSiSo;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhoa;
        private DevExpress.XtraBars.BarButtonItem btnDSLop;
        private DevExpress.XtraBars.BarButtonItem btnThemLop;
        private DevExpress.XtraBars.BarButtonItem btnSuaLop;
        private DevExpress.XtraBars.BarButtonItem btnXoaLop;
        private DevExpress.XtraBars.BarButtonItem btnXemDiem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraNavBar.NavBarControl nbcLop;
        private DevExpress.XtraNavBar.NavBarGroup nbgLop;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer2;
        private System.Windows.Forms.BindingSource DSLopbindingSource;
        private System.Windows.Forms.BindingSource LopbindingSource;
        private DevExpress.XtraBars.BarButtonItem btnCapNhat;
        private DevExpress.XtraGrid.GridControl gcLop;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLop;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSV;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSV;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNhapHoc;
        private DevExpress.XtraBars.BarButtonItem btnXemDiemLop;
    }
}