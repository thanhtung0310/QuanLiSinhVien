namespace BTL_QUANLYSINHVIEN
{
    partial class frmPhieuDiemLop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuDiemLop));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnXemDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXuatExcel = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.cboNamHoc = new System.Windows.Forms.ComboBox();
            this.tbLop = new System.Windows.Forms.TextBox();
            this.gcLop = new DevExpress.XtraGrid.GridControl();
            this.gvLop = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenSV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemTL1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemTL2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiemTL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltongTC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LopbindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LopbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Lớp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Năm học";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnXemDiem,
            this.btnXuatExcel});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(764, 96);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
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
            // btnXuatExcel
            // 
            this.btnXuatExcel.Caption = "Xuất Excel\r\nPhiếu điểm Lớp";
            this.btnXuatExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.Glyph")));
            this.btnXuatExcel.Id = 3;
            this.btnXuatExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnXuatExcel.LargeGlyph")));
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXuatExcel_ItemClick);
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
            this.ribbonPageGroup1.Text = "                                      Thông tin                                  " +
    "    ";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnXemDiem);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnXuatExcel);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "                         Chức năng                  ";
            // 
            // cboNamHoc
            // 
            this.cboNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNamHoc.FormattingEnabled = true;
            this.cboNamHoc.Location = new System.Drawing.Point(109, 43);
            this.cboNamHoc.Name = "cboNamHoc";
            this.cboNamHoc.Size = new System.Drawing.Size(139, 21);
            this.cboNamHoc.TabIndex = 5;
            // 
            // tbLop
            // 
            this.tbLop.Location = new System.Drawing.Point(109, 9);
            this.tbLop.Name = "tbLop";
            this.tbLop.ReadOnly = true;
            this.tbLop.Size = new System.Drawing.Size(139, 20);
            this.tbLop.TabIndex = 3;
            // 
            // gcLop
            // 
            this.gcLop.DataMember = "CustomSqlQuery";
            this.gcLop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLop.Location = new System.Drawing.Point(0, 96);
            this.gcLop.MainView = this.gvLop;
            this.gcLop.MenuManager = this.ribbonControl1;
            this.gcLop.Name = "gcLop";
            this.gcLop.Size = new System.Drawing.Size(764, 452);
            this.gcLop.TabIndex = 5;
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
            this.colDiemTL1,
            this.colDiemTL2,
            this.colDiemTL,
            this.coltongTC});
            this.gvLop.GridControl = this.gcLop;
            this.gvLop.Name = "gvLop";
            // 
            // colMaSV
            // 
            this.colMaSV.Caption = "Mã Sinh Viên";
            this.colMaSV.FieldName = "MaSV";
            this.colMaSV.Name = "colMaSV";
            this.colMaSV.Visible = true;
            this.colMaSV.VisibleIndex = 0;
            this.colMaSV.Width = 89;
            // 
            // colTenSV
            // 
            this.colTenSV.Caption = "Tên Sinh Viên";
            this.colTenSV.FieldName = "TenSV";
            this.colTenSV.Name = "colTenSV";
            this.colTenSV.Visible = true;
            this.colTenSV.VisibleIndex = 1;
            this.colTenSV.Width = 148;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.Caption = "Giới Tính";
            this.colGioiTinh.FieldName = "GioiTinh";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.Visible = true;
            this.colGioiTinh.VisibleIndex = 2;
            this.colGioiTinh.Width = 74;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.Caption = "Ngày Sinh";
            this.colNgaySinh.FieldName = "NgaySinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 3;
            this.colNgaySinh.Width = 105;
            // 
            // colDiemTL1
            // 
            this.colDiemTL1.Caption = "Kỳ 1";
            this.colDiemTL1.FieldName = "DiemTL1";
            this.colDiemTL1.Name = "colDiemTL1";
            this.colDiemTL1.Visible = true;
            this.colDiemTL1.VisibleIndex = 4;
            this.colDiemTL1.Width = 94;
            // 
            // colDiemTL2
            // 
            this.colDiemTL2.Caption = "Kỳ 2";
            this.colDiemTL2.FieldName = "DiemTL2";
            this.colDiemTL2.Name = "colDiemTL2";
            this.colDiemTL2.Visible = true;
            this.colDiemTL2.VisibleIndex = 5;
            this.colDiemTL2.Width = 80;
            // 
            // colDiemTL
            // 
            this.colDiemTL.Caption = "Cả năm";
            this.colDiemTL.FieldName = "DiemTL";
            this.colDiemTL.Name = "colDiemTL";
            this.colDiemTL.Visible = true;
            this.colDiemTL.VisibleIndex = 6;
            this.colDiemTL.Width = 80;
            // 
            // coltongTC
            // 
            this.coltongTC.Caption = "Tổng số TC";
            this.coltongTC.FieldName = "tongTC";
            this.coltongTC.Name = "coltongTC";
            this.coltongTC.Visible = true;
            this.coltongTC.VisibleIndex = 7;
            this.coltongTC.Width = 89;
            // 
            // frmPhieuDiemLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 548);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboNamHoc);
            this.Controls.Add(this.gcLop);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPhieuDiemLop";
            this.Text = "frmPhieuDiemLop";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LopbindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnXemDiem;
        private DevExpress.XtraBars.BarButtonItem btnXuatExcel;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private System.Windows.Forms.ComboBox cboNamHoc;
        private System.Windows.Forms.TextBox tbLop;
        private DevExpress.XtraGrid.GridControl gcLop;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLop;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSV;
        private DevExpress.XtraGrid.Columns.GridColumn colTenSV;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemTL1;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemTL2;
        private DevExpress.XtraGrid.Columns.GridColumn colDiemTL;
        private DevExpress.XtraGrid.Columns.GridColumn coltongTC;
        private System.Windows.Forms.BindingSource LopbindingSource;
    }
}