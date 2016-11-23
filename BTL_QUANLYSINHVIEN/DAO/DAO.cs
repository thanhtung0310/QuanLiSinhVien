using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using DTO;

namespace DAO
{
    public class sqlConnectionData
    {
        public static SqlConnection connection()
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SinhVien;Integrated Security=True");
            return cnn;
        }
    }
    public class SinhVien_DAO
    {
        //Load danh sách sinh viên
        public static DataTable LoadDSSinhVien()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlCommand cmd = new SqlCommand("sp_DSSinhVien", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            cnn.Close();
            return dtb;

        }
        //thêm sinh viên
        public static void themSV(SinhVien_DTO sv)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_themSV",sv.MaSV,sv.HoSV,sv.TenSV,sv.GioiTinh,sv.NgaySinh,sv.DiaChi,sv.NoiSinh,sv.MaLop,sv.NgayNhapHoc);
            cnn.Close();
            //   DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_themSV").Tables[0];
        }
        //sửa sinh viên
        public static void suaSV(SinhVien_DTO sv)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaSV", sv.HoSV, sv.TenSV, sv.GioiTinh, sv.NgaySinh, sv.DiaChi, sv.NoiSinh, sv.MaLop);
            cnn.Close();
        }
        //xóa sinh viên
        public static void xoaSV(string maSV)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_xoaSV",maSV);
            cnn.Close();
        }
        //sửa họ sinh viên
        public static void suaSV_HoSV(string maSV,string hoSV)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaSV_HoSV",hoSV, maSV);
            cnn.Close();
        }
        //sửa tên sinh viên
        public static void suaSV_TenSV(string maSV, string tenSV)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaSV_TenSV", tenSV, maSV);
            cnn.Close();
        }
        //sửa giới tính
        public static void suaSV_GioiTinh(string maSV, string s)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaSV_GioiTinh", s, maSV);
            cnn.Close();
        }
        //sửa ngày sinh 
        public static void suaSV_NgaySinh(string maSV, DateTime s)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaSV_ngaysinh", s, maSV);
            cnn.Close();
        }
        public static void suaSV_NgayNhapHoc(string maSV, DateTime s)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaSV_ngayNhapHoc", s, maSV);
            cnn.Close();
        }
        //sửa địa chỉ
        public static void suaSV_DiaChi(string maSV, string s)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaSV_DiaChi", s, maSV);
            cnn.Close();
        }
        //sửa nơi sinh 
        public static void suaSV_NoiSinh(string maSV, string s)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaSV_NoiSinh", s, maSV);
            cnn.Close();
        }
        //sửa lớp
        public static void suaSV_Lop(string maSV, string s)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaSV_Lop", s, maSV);
            cnn.Close();
        }
        //lấy mã sv cuối cùng
        public static string LastMaSV()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_lastMaSV").Tables[0];
            cnn.Close();
            return dtb.Rows[0][0].ToString();
        }
        //chuẩn hóa sinh viên
        public static void chuanHoa(string maSV,string hoSV, string tenSV,string gioiTinh,string diaChi,string noiSinh)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_chuanHoaSV", maSV,hoSV, tenSV,gioiTinh,diaChi, noiSinh);
            cnn.Close();
        }
        //thêm điểm
        public static void ThemDiem(string maSV,string maLHP,decimal dcc,decimal dqt,decimal dt,decimal dtb)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_themDiem", maSV, maLHP,dcc,dqt,dt,dtb);
            cnn.Close();
        }
        //xem phiếu điểm các kỳ of sinh viên
        public static DataTable phieuDiemSV(string maSV)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_phieuDiemSV", maSV).Tables[0];
            cnn.Close();
            return dtb;
        }
        //xem phiếu điểm các kỳ of sinh viên theo kỳ học
        public static DataTable phieuDiemSV_kyHoc(string maSV,int kyHoc)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_phieuDiemSV_kyHoc", maSV,kyHoc).Tables[0];
            cnn.Close();
            return dtb;
        }
        //hiện ra các kỳ học of  1 sinh viên
        public static DataTable kyHocSV(string ma)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_kyHocSV", ma).Tables[0];
            cnn.Close();
            return dtb;
        }
        //danh sách sv khoa
        public static DataTable DSSV_Khoa(string s,int year)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_DSSinhVien_Khoa", s,year).Tables[0];
            cnn.Close();
            return dtb;
        }
        
    }
    public class NhanVien_DAO
    {
        public static DataTable Login(string userName,string passWord)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_Login", userName,passWord).Tables[0];
            //if (dtb.Rows.Count > 0)
            //{
            //    //MessageBox.Show("đăng nhập thành công");
            //    //SqlHelper.ExecuteNonQuery(cnn, "sp_trangThai", ten, 1);
            //    if (dtb.Rows[0][0].ToString() == "1")
            //        return 1;
            //    else return 0;
            //}
            //else
            //    return -1;
            cnn.Close();
            return dtb;
        }
    }
    public class LopHocPhan_DAO
    {
        public static DataTable LoadDSLopHocPhan()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlCommand cmd = new SqlCommand("sp_DSLHP", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            cnn.Close();
            return dtb;
        }
        public static DataTable LoadLopHocPhan(string maLHP)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_LHP", maLHP).Tables[0];
            cnn.Close();
            return dtb;
        }

        public static DataTable TimeLHP(string maLHP)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_timeLHP", maLHP).Tables[0];
            cnn.Close();
            return dtb;
        }
        //LẤY MÃ lhp cuối cùng
        public static string LastMaLHP()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_lastMaLHP").Tables[0];
            cnn.Close();
            return dtb.Rows[0][0].ToString();
        }
        //thêm LHP
        public static void themLHP(string maLHP,string monHoc,string giaoVien,DateTime ngayBD,DateTime ngayKT,DateTime ngayThi,int kyHoc)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_themLHP", maLHP, monHoc, giaoVien, ngayBD, ngayKT, ngayThi, kyHoc);
            cnn.Close();
        }
        //sửa LHP môn học
        public static void suaLHP_MH(string maLHP,string s)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaLHP_MH", maLHP, s);
            cnn.Close();
        }
        //sửa LHP giáo viên
        public static void suaLHP_GV(string maLHP, string s)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaLHP_GV", maLHP, s);
            cnn.Close();
        }
        //sửa LHP ngày bđ,ngày kt,ngày thi
        public static void suaLHP_date(string maLHP, DateTime ngaybd,DateTime ngaykt, DateTime ngayThi)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaLHP_date", maLHP, ngaybd,ngaykt,ngayThi);
            cnn.Close();
        }
        //sửa kỳ học
        public static void suaLHP_KyHoc(string maLHP, int kyHoc)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaLHP_KyHoc", maLHP, kyHoc);
            cnn.Close();
        }
        //xóa LHP
        public static void xoaLHP(string maLHP)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_xoaLHP", maLHP);
            cnn.Close();
        }
        //xóa sinh viên trong LHP
        public static void xoaSV_LHP(string maSV,string maLHP)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_xoaSV_LHP", maSV,maLHP);
            cnn.Close();
        } 
        //thêm list sinh viên vào LHP
        public static void themDSSV_LHP(string tenLop,string maLHP)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_themDSSV_LHP", tenLop, maLHP);
            cnn.Close();
        }

    }
    public class Lop_DAO
    {
        public static DataTable tenLop()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_tenLop").Tables[0];
            cnn.Close();
            return dtb;
        }
        public static string maLop(string tenLop)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_maLop",tenLop).Tables[0];
            cnn.Close();
            return dtb.Rows[0][0].ToString();
        }
        public static DataTable PhieuDiem_Lop(string tenlop,int kyHoc,int namHoc)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_phieuDiem_Lop",tenlop,kyHoc,namHoc).Tables[0];
            cnn.Close();
            return dtb;
        }
        public static DataTable DSSV_Lop(string tenlop)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_DSSV_Lop", tenlop).Tables[0];
            cnn.Close();
            return dtb;
        }
        //danh sách lớp
        public static DataTable DSLop()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_DSLop").Tables[0];
            cnn.Close();
            return dtb;
        }
        //thêm lớp
        public static void themLop(string maLop,string tenLop,string tenKhoa)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_themLop", maLop,tenLop,0,tenKhoa);
            cnn.Close();
        }
        //sửa lớp
        public static void suaLop(string maLop,string tenLop,string tenKhoa)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaLop", maLop, tenLop,tenKhoa);
            cnn.Close();
        }
        //xóa lớp
        public static void xoaLop(string maLop)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_xoaLop", maLop);
            cnn.Close();
        }
        //LẤY MÃ lớp cuối cùng
        public static string LastMaLop()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_lastMaLop").Tables[0];
            cnn.Close();
            return dtb.Rows[0][0].ToString();
        }
        //danh sách sv trong 1 lớp, phiếu điểm
        public static DataTable phieuDiemLop_namHoc(string maLop, int namHoc)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_phieuDiem_Lop_namHoc", maLop,namHoc).Tables[0];
            cnn.Close();
            return dtb;
        }

    }
    public class GiaoVien_DAO
    {
        public static DataTable DSGiaoVien()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_DSGiaoVien").Tables[0];
            cnn.Close();
            return dtb;
        }
        public static DataTable tenGiaoVien(string tenKhoa)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_tenGiaovien",tenKhoa).Tables[0];
            cnn.Close();
            return dtb;
        }
        public static string LastMaGV()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_lastMaGV").Tables[0];
            cnn.Close();
            return dtb.Rows[0][0].ToString();
        }
        public static void themGV(string maGV,string hoGV,string tenGV, string tenKhoa,string trinhDo)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_themGV", maGV, hoGV, tenGV, tenKhoa, trinhDo);
            cnn.Close();
            //   DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_themSV").Tables[0];
        }
        public static void suaGV_HoGV(string maGV, string hoGV)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaGV_HoGV", maGV, hoGV);
            cnn.Close();
        }
        public static void suaSV_TenGV(string maGV, string TenGV)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaSV_TenGV", maGV, TenGV);
            cnn.Close();
        }
        public static void suaGV_Khoa(string maGV, string tenKhoa)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaGV_Khoa", maGV, tenKhoa);
            cnn.Close();
        }
        public static void suaGV_TrinhDo(string maGV, string trinhDo)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_suaGV_TrinhDo", maGV,trinhDo);
            cnn.Close();
        }
        public static void xoaGV(string maGV)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            SqlHelper.ExecuteNonQuery(cnn, "sp_xoaGV", maGV);
            cnn.Close();
        }
    }
    public class Khoa_DAO
    {
        public static DataTable tenKhoa()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_tenKhoa").Tables[0];
            cnn.Close();
            return dtb;
        }
        public static DataTable tenKhoa_MH(string monHoc)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_tenKhoa_MH",monHoc).Tables[0];
            cnn.Close();
            return dtb;
        }
        //lấy ngày nhập học sinh viên đầu tiên của khoa
        public static DataTable year_Khoa(string s)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_year_Khoa", s).Tables[0];
            cnn.Close();
            return dtb;
        }
    }
    public class MonHoc_DAO
    {
        public static int maMH(string tenMH)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_maMH", tenMH).Tables[0];
            cnn.Close();
            if (dtb.Rows.Count == 0)
                return 0;           //không có môn học đó
            return Convert.ToInt32(dtb.Rows[0][0]);     
        }
        public static DataTable tenMH(string tenKhoa)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_tenMH",tenKhoa).Tables[0];
            cnn.Close();
            return dtb;
        }
        //danh sách thi lại theo môn
        public static DataTable DSThiLai(string s)
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_ThiLai", s).Tables[0];
            cnn.Close();
            return dtb;
        }
        public static DataTable DSMH()
        {
            SqlConnection cnn = sqlConnectionData.connection();
            DataTable dtb = SqlHelper.ExecuteDataset(cnn, "sp_DSMH").Tables[0];
            cnn.Close();
            return dtb;
        }
        
    }
}
