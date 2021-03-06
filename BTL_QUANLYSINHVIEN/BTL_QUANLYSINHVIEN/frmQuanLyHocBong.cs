﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace BTL_QUANLYSINHVIEN
{
    public partial class frmQuanLyHocBong : Form
    {
        public string tenKhoa;
        public int namNhapHoc;
        int i1=1, i2=1, i3=1;
        public frmQuanLyHocBong()
        {
            InitializeComponent();
            // This line of code is generated by Data Source Configuration Wizard
            // Fill a SqlDataSource
        }

        private void frmQuanLyHocBong_Load(object sender, EventArgs e)
        {
            btnTieuChi.Enabled = false;
            tb1.Text = "1";
            tb2.Text = "1";
            tb3.Text = "1";
        }
        public void load()
        {
            string s1 = "Điểm tổng kết hạng {%rank%}\nKhông có môn nào tổng kết dưới 3.0\nHạnh kiểm tốt\nKhông có môn nào thi lại";
            string s;
            ToolTip t = new ToolTip();
            if (tb1.Text.Trim() == "1" || tb1.Text.Trim() == "")
            {
                s=s1.Replace("{%rank%}", "1");
                i1 = 1;
            }
            else
            {
                s=s1.Replace("{%rank%}", "1-" + tb1.Text.Trim());
                i1 = Convert.ToInt32(tb1.Text.Trim());
            }
            t.SetToolTip(lbTieuChi1, s);
            if (tb2.Text.Trim() == "1" || tb2.Text.Trim() == "")
            { 
                i2 = 1;
                s=s1.Replace("{%rank%}", (i1+i2).ToString());          
            }
            else
            {
                i2 = Convert.ToInt32(tb2.Text.Trim());
                s=s1.Replace("{%rank%}", (i1+1).ToString()+"-" + (i1+i2).ToString());
            }
            t.SetToolTip(lbTieuChi2, s);
            if (tb3.Text.Trim() == "1" || tb3.Text.Trim() == "")
            {
                i3 = 1;
                s=s1.Replace("{%rank%}", (i1 + i2+i3).ToString());
            }
            else
            {
                i3 = Convert.ToInt32(tb3.Text.Trim());
                s = s1.Replace("{%rank%}", (i1 + i2 + 1).ToString() + "-" + (i1 + i2 + i3).ToString());
            }
            t.SetToolTip(lbTieuChi3, s);          
            
        }
        public void loadInfo()
        {
            DataTable dtb = Khoa_BUS.LoadtenKhoa();
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                string name = dtb.Rows[i][0].ToString();
                cboKhoa.Items.Add(name);
            }
            cboKhoa.SelectedIndex = 0;
            tenKhoa = cboKhoa.Text;
            loadYear();
        }
        public void loadYear()
        {
            DataTable dtb1 = Khoa_BUS.year_Khoa(tenKhoa);
            namNhapHoc = Convert.ToInt32(dtb1.Rows[0][0].ToString());
            int namHienTai = DateTime.Now.Year;
            int namHoc = namNhapHoc;
            int t = cboNamHoc.Items.Count;
            for (int i = 0; i < t; i++)
            {
                cboNamHoc.Items.RemoveAt(0);
            }
            string nam = namHoc.ToString() + "-" + (namHoc + 1).ToString();
            namHoc++;
            cboNamHoc.Items.Add(nam);
            for (int i = 0; i < namHienTai - namNhapHoc - 1; i++)
            {
                nam = namHoc.ToString() + "-" + (namHoc + 1).ToString();
                namHoc++;
                cboNamHoc.Items.Add(nam);
            }
            cboNamHoc.SelectedIndex = 0;
        }
        private void tb1_Validated(object sender, EventArgs e)
        {
            load();
        }

        private void tb2_Validated(object sender, EventArgs e)
        {
            load();
        }

        private void tb3_Validated(object sender, EventArgs e)
        {
            load();
        }

        private void tb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnDSSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnTieuChi.Enabled = true;
            String[] catchuoi = cboNamHoc.Text.Split('-');
            int namHoc = Convert.ToInt32(catchuoi[1]);
            gcSV.RefreshDataSource();
            int t = bindingSource1.Count;
            for (int i = 0; i < t; i++)
                bindingSource1.RemoveAt(0);
            //MessageBox.Show(namHoc.ToString());
            load_DS(namHoc);
        }

        public void load_DS(int namHoc)
        {
            bindingSource1.DataSource = SinhVien_BUS.DSSV_Khoa(tenKhoa,namHoc);
            gcSV.DataSource = bindingSource1;
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            tenKhoa = cboKhoa.Text;
            loadYear();
        }

        private void btnDS_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvSV.RowCount; i++)
                gvSV.SetRowCellValue(i, colGhiChu, "");
            int t1 = 0;
            //if (i1 >= gvSV.RowCount)
            //    {
                    for (int  t = 0; t1 < gvSV.RowCount&&t<i1;t1++)
                    {
                        if(gvSV.GetRowCellValue(t1,colLanThi).ToString()=="1"&&gvSV.GetRowCellValue(t1,colDieuKien).ToString()=="1")
                        {
                            gvSV.SetRowCellValue(t1, colGhiChu, "Học bổng Lê Qúy Đôn");
                            t++;
                        }
                        else
                            gvSV.SetRowCellValue(t1, colGhiChu, "Không đủ điều kiện!");
                       // t1++;
                    }
          //   }

         //    else
         //    {
                    //for (int t=0; t1 < gvSV.RowCount&&t<i1;t1++ )
                    //{
                    //    if (gvSV.GetRowCellValue(t1, colLanThi).ToString() == "1")
                    //    {
                    //        gvSV.SetRowCellValue(t1, colGhiChu, "Học bổng Lê Qúy Đôn");
                    //        t++;
                    //    }
                    //    else
                    //        gvSV.SetRowCellValue(t1, colGhiChu, "Có thi lại!");
                    //}
                    //t2 = t1;
                    //if (i1 + i2 >= gvSV.RowCount)
                        for (int t=0; t1 < gvSV.RowCount&&t<i2; t1++)
                            if (gvSV.GetRowCellValue(t1, colLanThi).ToString() == "1" && gvSV.GetRowCellValue(t1, colDieuKien).ToString() == "1")
                            {
                                gvSV.SetRowCellValue(t1, colGhiChu, "Học bổng Loại A");
                                t++;
                            }
                            else
                                gvSV.SetRowCellValue(t1, colGhiChu, "Không đủ điều kiện!");

                   // else
                    //{
                    //    for (int t=0; t1<gvSV.RowCount&&t<i2; t1++)
                    //        if (gvSV.GetRowCellValue(t1, colLanThi).ToString() == "1")
                    //        {
                    //            gvSV.SetRowCellValue(t1, colGhiChu, "Học bổng Loại A");
                    //            t++;
                    //        }
                    //        else
                    //            gvSV.SetRowCellValue(t1, colGhiChu, "Có thi lại!");
                    //    if (i1 + i2 + i3 >= gvSV.RowCount)
                    //        for (int t=0; t1 < gvSV.RowCount&&t<i3; t1++)
                    //            if (gvSV.GetRowCellValue(t1, colLanThi).ToString() == "1")
                    //            {
                    //                gvSV.SetRowCellValue(t1, colGhiChu, "Học bổng Loại B");
                    //                t++;
                    //            }
                    //            else
                    //                gvSV.SetRowCellValue(t1, colGhiChu, "Có thi lại!");
                    //    else
                            for (int t = 0; t1 < gvSV.RowCount && t < i3; t1++)
                                if (gvSV.GetRowCellValue(t1, colLanThi).ToString() == "1" && gvSV.GetRowCellValue(t1, colDieuKien).ToString() == "1")
                                {
                                    gvSV.SetRowCellValue(t1, colGhiChu, "Học bổng Loại B");
                                    t++;
                                }
                                else
                                    gvSV.SetRowCellValue(t1, colGhiChu, "Không đủ điều kiện!");
                 //   }
              //  }
        }

        private void gvSV_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            tb1.Text = "1";
            tb2.Text = "1";
            tb3.Text = "1";
            nbcTieuChi.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
        }

        private void btnTieuChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            nbcTieuChi.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded;
        }

        private void btnXemDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gvSV.FocusedRowHandle >= 0)
            {
                frmDiemSinhVien f = new frmDiemSinhVien();
                f.MaSV = gvSV.GetFocusedRowCellValue(colMaSV).ToString();
                f.TenSV = gvSV.GetFocusedRowCellValue(colTenSV).ToString();
                f.loadInfo();
                f.Show();
            }
            else
                MessageBox.Show("Chọn sinh viên cần xem!");
        }
    }
}
