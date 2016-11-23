using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using BUS;
using DTO;

namespace BTL_QUANLYSINHVIEN
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Thong tin user
        public static NhanVien_DTO user = new NhanVien_DTO();
        #endregion
        #region các biến
        public string userName;
        public int chucVu=-1;
        public frmLogin dn=null;
        #endregion
        AddTab.TabAdd clsAddTab = new AddTab.TabAdd(); 
        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
            if (chucVu >= 0)
                AnMenu(true, chucVu);
            else AnMenu(false, 0);
           // if (SinhVien_BUS.KetNoi() == 1) MessageBox.Show("ket noi thanh cong");
            //else MessageBox.Show("Ket noi khong thanh cong");
        }


        //private void frmMain_Load(object sender, EventArgs e)
        //{
        //    //thay đổi giao diện skin
        //   // SkinHelper.InitSkinGallery(rgbiSkins, true);
        //   // DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.BonusSkins).Assembly);
        // //   DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.OfficeSkins).Assembly);       
        
        //}
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbSkins, true);
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle("Black");
         //   DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.BonusSkins).Assembly);
         //   DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.OfficeSkins).Assembly);       
            
        }
        #region Các hàm xử lý login và phân quyền

        public void AnMenu(bool logged, int QuyenHan = 1)
        {
            //Mac dinh la dang nhap thanh cong bat het cac Menu

            //
          //  string s = "SV0020";
            //string sub1 = s.Substring(0, 2);
            //string sub2 = s.Substring(2);
            //int ma = Convert.ToInt32(sub2) + 1;
            //string sub = "";
            //for (int i = 0; i < sub2.Length - ma.ToString().Length; i++)
            //    sub += "0";
            //sub += ma.ToString();
            //sub1 += sub;
            //return sub1 + sub;
         //   MessageBox.Show(s + " " + sub1);
            //MessageBox.Show(Convert.ToInt32("0010001").ToString());
            btnThongTinBanThan.Enabled = logged;
            btnDoiMatKhau.Enabled = logged;
            btnDanhSach.Enabled = logged;
          //  btnThoat.Enabled = logged;
            btnSinhVien.Enabled = logged;
            btnGiaoVien.Enabled = logged;
            btnLop.Enabled = logged;
            //btnPhanQuyen.Enabled = logged;
            btnLopHocPhan.Enabled = logged;
            xtraTabControl1.Enabled = logged;
            switch (QuyenHan)
            {
                case 1: break;
                case 0: HienThiNhanVien(); break;
            }
        }

      //  Hiển thị Menu với nhóm "Nhân Viên"
        private void HienThiNhanVien()
        {
            btnDanhSach.Enabled = false;
        }

        #endregion

        string[] fileNames, filePaths;
        private void btnNgheNhac_Click(object sender, EventArgs e)
        {
           // string[] fileNames, filePaths;
            if(openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                fileNames = openFileDialog1.SafeFileNames;
                filePaths = openFileDialog1.FileNames;
                foreach(string fileName in fileNames)
                {
                    lbNhac.Items.Add(fileName);
                }
                if(lbNhac.Items.Count>0)
                    axWindowsMediaPlayer1.URL = filePaths[0];
                axWindowsMediaPlayer1.settings.autoStart=true;
                
            }
        }

        private void lbNhac_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = filePaths[lbNhac.SelectedIndex];
        }
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {// Đóng tab đang focus trên TAb Cha
            xtraTabControl1.TabPages.RemoveAt(xtraTabControl1.SelectedTabPageIndex);
        }
        private void xtraTabControl1_ControlAdded(object sender, ControlEventArgs e)
        {// Khi add vào thì Focus tới ngay Tab vừa Add
            xtraTabControl1.SelectedTabPageIndex = xtraTabControl1.TabPages.Count - 1;
        }
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Quản Lý Sinh Viên")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {
               
                clsAddTab.AddTab(xtraTabControl1, "", "Quản Lý Sinh Viên", new frmSinhVien());
            }
         //   siInfo.Caption = "Nhân Viên : " + Utilities.user.MaNV + " || Bạn đang xem tab Đổi Mật khẩu";
  
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Quản Lý Giáo Viên")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {

                clsAddTab.AddTab(xtraTabControl1, "", "Quản Lý Giáo Viên", new frmGiaoVien());
            }
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            AnMenu(false);
        }

        private void btnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
        //Khởi tạo biến Continue
        Cont:
            //Kiểm tra xem form DangNhap được mở hay đóng, nếu đóng thì tạo mới
            if (dn == null || dn.IsDisposed)
                dn = new frmLogin();
            //dn.ShowDialog();
            //khi nhấn đăng nhập
            if (dn.ShowDialog() == DialogResult.OK)
            {
                  if (dn.chucVu == -1) goto Cont;
                  //Set lại menu theo quyền  
                  else AnMenu(true, dn.chucVu);
            }
                //khi nhấn thoát
            else dn.Hide();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Quản Lý Lớp Học Phần")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {

                clsAddTab.AddTab(xtraTabControl1, "", "Quản Lý Lớp Học Phần", new frmLopHocPhan());
            }
        }
        public string ChuanHoa(string st)
        {
            string st1 = "";
            st = st.Trim();
            while (st.Length != 0)
            {
                st += " ";
                int i = st.IndexOf(' ');
                string s = char.ToUpper(st[0]) + st.Substring(1, i);
                st1 += s;
                st = st.Substring(i + 1).Trim();
            }
            return st1.Trim();
        }

        private void btnLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            int t = 0;
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControl1.TabPages)
            {
                if (tab.Text == "Quản Lý Lớp")
                {
                    xtraTabControl1.SelectedTabPage = tab;
                    t = 1;
                }
            }
            if (t == 1)
            {

            }
            else
            {

                clsAddTab.AddTab(xtraTabControl1, "", "Quản Lý Lớp", new frmLop());
            }
        }
    }
}
