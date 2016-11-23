namespace BTL_QUANLYSINHVIEN
{
    partial class frmGiaoVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiaoVien));
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.nbcThongTin = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgThongTin = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMaGiaoVien = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.cboTrinhDo = new System.Windows.Forms.ComboBox();
            this.tbHoGiaoVien = new System.Windows.Forms.TextBox();
            this.cboTenKhoa = new System.Windows.Forms.ComboBox();
            this.tbTenGiaoVien = new System.Windows.Forms.TextBox();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnDSGiaoVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnCapNhat = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rib = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gcGiaoVien = new DevExpress.XtraGrid.GridControl();
            this.gvGiaoVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenGV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrinhDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenKhoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DSGVbindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbcThongTin)).BeginInit();
            this.nbcThongTin.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGiaoVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSGVbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Kỹ sư",
            "Thạc Sỹ",
            "Tiến Sỹ",
            "Phó Giáo Sư",
            "Giáo Sư"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.repositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // nbcThongTin
            // 
            this.nbcThongTin.ActiveGroup = this.nbgThongTin;
            this.nbcThongTin.Controls.Add(this.navBarGroupControlContainer1);
            this.nbcThongTin.Dock = System.Windows.Forms.DockStyle.Left;
            this.nbcThongTin.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgThongTin});
            this.nbcThongTin.Location = new System.Drawing.Point(0, 0);
            this.nbcThongTin.Name = "nbcThongTin";
            this.nbcThongTin.OptionsNavPane.ExpandedWidth = 318;
            this.nbcThongTin.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.nbcThongTin.Size = new System.Drawing.Size(318, 513);
            this.nbcThongTin.TabIndex = 2;
            this.nbcThongTin.Text = "Thông Tin";
            // 
            // nbgThongTin
            // 
            this.nbgThongTin.Caption = "Thông Tin";
            this.nbgThongTin.ControlContainer = this.navBarGroupControlContainer1;
            this.nbgThongTin.Expanded = true;
            this.nbgThongTin.GroupClientHeight = 80;
            this.nbgThongTin.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.nbgThongTin.Name = "nbgThongTin";
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.navBarGroupControlContainer1.Appearance.Options.UseBackColor = true;
            this.navBarGroupControlContainer1.Controls.Add(this.panelControl1);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(318, 410);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.tbMaGiaoVien);
            this.panelControl1.Controls.Add(this.btnLuu);
            this.panelControl1.Controls.Add(this.btnHuy);
            this.panelControl1.Controls.Add(this.cboTrinhDo);
            this.panelControl1.Controls.Add(this.tbHoGiaoVien);
            this.panelControl1.Controls.Add(this.cboTenKhoa);
            this.panelControl1.Controls.Add(this.tbTenGiaoVien);
            this.panelControl1.Location = new System.Drawing.Point(12, 17);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(300, 338);
            this.panelControl1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label5.Location = new System.Drawing.Point(18, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "Họ Giáo Viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(18, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tên Giáo Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(18, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mã Giáo Viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(18, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tên Khoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(18, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Trình độ học vấn";
            // 
            // tbMaGiaoVien
            // 
            this.tbMaGiaoVien.Location = new System.Drawing.Point(129, 33);
            this.tbMaGiaoVien.Name = "tbMaGiaoVien";
            this.tbMaGiaoVien.Size = new System.Drawing.Size(147, 21);
            this.tbMaGiaoVien.TabIndex = 0;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(64, 308);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(201, 308);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // cboTrinhDo
            // 
            this.cboTrinhDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrinhDo.FormattingEnabled = true;
            this.cboTrinhDo.Items.AddRange(new object[] {
            "Kỹ Sư",
            "Thạc Sỹ",
            "Tiến Sỹ",
            "Phó Giáo Sư",
            "Giáo Sư"});
            this.cboTrinhDo.Location = new System.Drawing.Point(129, 249);
            this.cboTrinhDo.Name = "cboTrinhDo";
            this.cboTrinhDo.Size = new System.Drawing.Size(147, 21);
            this.cboTrinhDo.TabIndex = 3;
            // 
            // tbHoGiaoVien
            // 
            this.tbHoGiaoVien.Location = new System.Drawing.Point(126, 82);
            this.tbHoGiaoVien.Name = "tbHoGiaoVien";
            this.tbHoGiaoVien.Size = new System.Drawing.Size(150, 21);
            this.tbHoGiaoVien.TabIndex = 1;
            // 
            // cboTenKhoa
            // 
            this.cboTenKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenKhoa.FormattingEnabled = true;
            this.cboTenKhoa.Location = new System.Drawing.Point(129, 197);
            this.cboTenKhoa.Name = "cboTenKhoa";
            this.cboTenKhoa.Size = new System.Drawing.Size(147, 21);
            this.cboTenKhoa.TabIndex = 4;
            // 
            // tbTenGiaoVien
            // 
            this.tbTenGiaoVien.Location = new System.Drawing.Point(126, 143);
            this.tbTenGiaoVien.Name = "tbTenGiaoVien";
            this.tbTenGiaoVien.Size = new System.Drawing.Size(150, 21);
            this.tbTenGiaoVien.TabIndex = 2;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.DrawGroupsBorder = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnThem,
            this.btnXoa,
            this.btnSua,
            this.btnDSGiaoVien,
            this.btnCapNhat});
            this.ribbonControl1.Location = new System.Drawing.Point(318, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(618, 75);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThem.Glyph")));
            this.btnThem.Id = 1;
            this.btnThem.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnThem.LargeGlyph")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXoa.Glyph")));
            this.btnXoa.Id = 2;
            this.btnXoa.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnXoa.LargeGlyph")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSua.Glyph")));
            this.btnSua.Id = 3;
            this.btnSua.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSua.LargeGlyph")));
            this.btnSua.Name = "btnSua";
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnDSGiaoVien
            // 
            this.btnDSGiaoVien.Caption = "Danh sách giáo viên";
            this.btnDSGiaoVien.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDSGiaoVien.Glyph")));
            this.btnDSGiaoVien.Id = 5;
            this.btnDSGiaoVien.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDSGiaoVien.LargeGlyph")));
            this.btnDSGiaoVien.Name = "btnDSGiaoVien";
            this.btnDSGiaoVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSGiaoVien_ItemClick);
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.rib,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Quản Lý";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDSGiaoVien);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "ribbonPage1";
            // 
            // rib
            // 
            this.rib.AllowTextClipping = false;
            this.rib.ItemLinks.Add(this.btnThem);
            this.rib.Name = "rib";
            this.rib.ShowCaptionButton = false;
            this.rib.Text = "ribbonPage2";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSua);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "ribbonPage1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnXoa);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            this.ribbonPageGroup3.Text = "ribbonPage3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnCapNhat);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // gcGiaoVien
            // 
            this.gcGiaoVien.DataMember = "CustomSqlQuery";
            this.gcGiaoVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcGiaoVien.Location = new System.Drawing.Point(318, 75);
            this.gcGiaoVien.MainView = this.gvGiaoVien;
            this.gcGiaoVien.Name = "gcGiaoVien";
            this.gcGiaoVien.Size = new System.Drawing.Size(618, 438);
            this.gcGiaoVien.TabIndex = 6;
            this.gcGiaoVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGiaoVien});
            // 
            // gvGiaoVien
            // 
            this.gvGiaoVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaGV,
            this.colHoGV,
            this.colTenGV,
            this.colTrinhDo,
            this.colTenKhoa});
            this.gvGiaoVien.GridControl = this.gcGiaoVien;
            this.gvGiaoVien.Name = "gvGiaoVien";
            this.gvGiaoVien.OptionsCustomization.AllowColumnMoving = false;
            this.gvGiaoVien.OptionsFind.AlwaysVisible = true;
            this.gvGiaoVien.OptionsFind.FindNullPrompt = "Tìm kiếm nhanh...";
            this.gvGiaoVien.OptionsView.ShowGroupPanel = false;
            this.gvGiaoVien.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvGiaoVien_FocusedRowChanged);
            this.gvGiaoVien.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvGiaoVien_ValidateRow);
            // 
            // colMaGV
            // 
            this.colMaGV.Caption = "Mã Giáo Viên";
            this.colMaGV.FieldName = "MaGV";
            this.colMaGV.Name = "colMaGV";
            this.colMaGV.OptionsColumn.ReadOnly = true;
            this.colMaGV.Visible = true;
            this.colMaGV.VisibleIndex = 0;
            this.colMaGV.Width = 99;
            // 
            // colHoGV
            // 
            this.colHoGV.Caption = "Họ Giáo Viên";
            this.colHoGV.FieldName = "HoGV";
            this.colHoGV.Name = "colHoGV";
            this.colHoGV.Visible = true;
            this.colHoGV.VisibleIndex = 1;
            this.colHoGV.Width = 167;
            // 
            // colTenGV
            // 
            this.colTenGV.Caption = "Tên Giáo Viên";
            this.colTenGV.FieldName = "TenGV";
            this.colTenGV.Name = "colTenGV";
            this.colTenGV.Visible = true;
            this.colTenGV.VisibleIndex = 2;
            this.colTenGV.Width = 158;
            // 
            // colTrinhDo
            // 
            this.colTrinhDo.Caption = "Trình độ học vấn";
            this.colTrinhDo.ColumnEdit = this.repositoryItemComboBox1;
            this.colTrinhDo.FieldName = "TrinhDo";
            this.colTrinhDo.Name = "colTrinhDo";
            this.colTrinhDo.Visible = true;
            this.colTrinhDo.VisibleIndex = 3;
            this.colTrinhDo.Width = 108;
            // 
            // colTenKhoa
            // 
            this.colTenKhoa.Caption = "Tên Khoa";
            this.colTenKhoa.ColumnEdit = this.repositoryItemComboBox2;
            this.colTenKhoa.FieldName = "TenKhoa";
            this.colTenKhoa.Name = "colTenKhoa";
            this.colTenKhoa.Visible = true;
            this.colTenKhoa.VisibleIndex = 4;
            this.colTenKhoa.Width = 149;
            // 
            // frmGiaoVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 513);
            this.Controls.Add(this.gcGiaoVien);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.nbcThongTin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGiaoVien";
            this.Text = "frmGiaoVien";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbcThongTin)).EndInit();
            this.nbcThongTin.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGiaoVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSGVbindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl nbcThongTin;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rib;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraGrid.GridControl gcGiaoVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGiaoVien;
        private DevExpress.XtraGrid.Columns.GridColumn colMaGV;
        private DevExpress.XtraGrid.Columns.GridColumn colHoGV;
        private DevExpress.XtraGrid.Columns.GridColumn colTenGV;
        private DevExpress.XtraGrid.Columns.GridColumn colTenKhoa;
        private DevExpress.XtraBars.BarButtonItem btnDSGiaoVien;
        private DevExpress.XtraGrid.Columns.GridColumn colTrinhDo;
        private System.Windows.Forms.BindingSource DSGVbindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraNavBar.NavBarGroup nbgThongTin;
        private DevExpress.XtraNavBar.NavBarGroupControlContainer navBarGroupControlContainer1;
        private System.Windows.Forms.TextBox tbTenGiaoVien;
        private System.Windows.Forms.TextBox tbHoGiaoVien;
        private System.Windows.Forms.TextBox tbMaGiaoVien;
        private System.Windows.Forms.ComboBox cboTenKhoa;
        private System.Windows.Forms.ComboBox cboTrinhDo;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private DevExpress.XtraBars.BarButtonItem btnCapNhat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;

    }
}