using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAO;

namespace BUS
{
    public class SinhVien_BUS
    {
        public static int KetNoi()
        {
            return sqlConnectionData.connection() == null ? 0 : 1;
        }
        //Load danh sách sinh viên
        public static DataTable DanhSachSV()
        {
            return SinhVien_DAO.LoadDSSinhVien();
        } 
        //thêm sinh viên
        public static void themSV(SinhVien_DTO sv)
        {
            SinhVien_DAO.themSV(sv);
        }
        //sửa sinh viên
        public static void suaSV(SinhVien_DTO sv)
        {
            SinhVien_DAO.suaSV(sv);
        }
        //sửa họ sinh viên
        public static void suaSV_HoSV(string maSV,string s)
        {
            SinhVien_DAO.suaSV_HoSV(maSV, s);
        }
        //sửa tên sinh viên
         public static void suaSV_TenSV(string maSV,string s)
        {
            SinhVien_DAO.suaSV_TenSV(maSV, s);
        }
        //sửa giới tính
         public static void suaSV_GioiTinh(string maSV, string s)
         {
             SinhVien_DAO.suaSV_GioiTinh(maSV, s);
         }
        //sửa ngày Sinh 
         public static void suaSV_NgaySinh(string maSV, DateTime s)
         {
             SinhVien_DAO.suaSV_NgaySinh(maSV, s);
         }
         public static void suaSV_NgayNhapHoc(string maSV, DateTime s)
         {
             SinhVien_DAO.suaSV_NgayNhapHoc(maSV, s);
         }
        //sửa địa chỉ
         public static void suaSV_DiaChi(string maSV, string s)
         {
             SinhVien_DAO.suaSV_DiaChi(maSV, s);
         }
        //sửa nơi Sinh
         public static void suaSV_NoiSinh(string maSV, string s)
         {
             SinhVien_DAO.suaSV_NoiSinh(maSV, s);
         }
        //sửa lớp
         public static void suaSV_Lop(string maSV, string s)
         {
             SinhVien_DAO.suaSV_Lop(maSV, s);
         }
        //xóa sinh viên
        public static void xoaSV(string maSV)
        {
            SinhVien_DAO.xoaSV(maSV);
        }
        public static string LastMaSV()
        {
            return SinhVien_DAO.LastMaSV();
        }
        public static void chuanHoaSV(string maSV,string hoSV, string tenSV,string gioiTinh,string diaChi,string noiSinh)
        {
             SinhVien_DAO.chuanHoa(maSV, hoSV, tenSV, gioiTinh, diaChi, noiSinh);
        }
        //PHIÉU điểm sv
        public static DataTable phieuDiemSV(string maSV)
        {
            return SinhVien_DAO.phieuDiemSV(maSV);
        }
        //xem phiếu điểm các kỳ of sinh viên theo kỳ học
        public static DataTable phieuDiemSV_kyHoc(string maSV, int kyHoc)
        {
            return SinhVien_DAO.phieuDiemSV_kyHoc(maSV, kyHoc);
        }
        //thêm điểm
        public static void ThemDiem(string maSV, string maLHP, decimal dcc, decimal dqt, decimal dt, decimal dtb)
        {
            SinhVien_DAO.ThemDiem(maSV, maLHP, dcc, dqt, dt, dtb);
        }
        //hiện ra các kỳ học of  1 sinh viên
        public static DataTable kyHocSV(string ma)
        {
            return SinhVien_DAO.kyHocSV(ma);
        }
        //danh sách sv khoa
        public static DataTable DSSV_Khoa(string s, int year)
        {
            return SinhVien_DAO.DSSV_Khoa(s,year);
        }
    }
    public class NhanVien_BUS
    {
        public static DataTable Login(string userName, string passWord)
        {
            return NhanVien_DAO.Login(userName,passWord);
        }
    }
    public class LopHocPhan_BUS
    {
        public static DataTable DanhSachLHP()
        {
            return LopHocPhan_DAO.LoadDSLopHocPhan();
        }
        public static DataTable LHP(string maLHP)
        {
            return LopHocPhan_DAO.LoadLopHocPhan(maLHP);
        }
        public static DataTable timeLHP(string maLHP)
        {
            return LopHocPhan_DAO.TimeLHP(maLHP);
        }
        //
        public static string LastMaLHP()
        {
            return LopHocPhan_DAO.LastMaLHP();
        }
        //thêm LHP
        public static void themLHP(string maLHP,string monHoc,string giaoVien,DateTime ngayBD,DateTime ngayKT,DateTime ngayThi,int kyHoc)
        {
            LopHocPhan_DAO.themLHP(maLHP, monHoc, giaoVien, ngayBD, ngayKT, ngayThi, kyHoc);
        }
        //sửa LHP môn học
        public static void suaLHP_MH(string maLHP, string s)
        {
            LopHocPhan_DAO.suaLHP_MH(maLHP, s);
        }
        //sửa LHP giáo viên
        public static void suaLHP_GV(string maLHP, string s)
        {
            LopHocPhan_DAO.suaLHP_GV(maLHP, s);
        }
        //sửa LHP ngày bđ,ngày kt,ngày thi
        public static void suaLHP_date(string maLHP, DateTime ngaybd, DateTime ngaykt, DateTime ngayThi)
        {
            LopHocPhan_DAO.suaLHP_date(maLHP, ngaybd, ngaykt, ngayThi);
        }
        //sửa kỳ học
        public static void suaLHP_KyHoc(string maLHP, int kyHoc)
        {
            LopHocPhan_DAO.suaLHP_KyHoc(maLHP, kyHoc);
        }
        //xóa LHP
        public static void xoaLHP(string maLHP)
        {
            LopHocPhan_DAO.xoaLHP(maLHP);
        }
        //xóa sinh viên trong LHP
        public static void xoaSV_LHP(string tenSV, string maLHP)
        {
            LopHocPhan_DAO.xoaSV_LHP(tenSV, maLHP);
        }
        //thêm list sinh viên vào LHP
        public static void themDSSV_LHP(string tenLop, string maLHP)
        {
            LopHocPhan_DAO.themDSSV_LHP(tenLop, maLHP);
        }


    }
    public class Lop_BUS
    {
        public static DataTable LoadtenLop()
        {
            return Lop_DAO.tenLop();
        }
        public static string maLop(string tenLop)
        {
            return Lop_DAO.maLop(tenLop);
        }
        public static DataTable DSSV_Lop(string tenLop)
        {
            return Lop_DAO.DSSV_Lop(tenLop);
        }
        public static DataTable phieuDiem_Lop(string tenlop,int kyHoc,int namHoc)
        {
            return Lop_DAO.PhieuDiem_Lop(tenlop,kyHoc,namHoc);
        }
        public static DataTable DSLop()
        {
            return Lop_DAO.DSLop();
        }
        //thêm lớp
        public static void themLop(string maLop, string tenLop, string tenKhoa)
        {
            Lop_DAO.themLop(maLop, tenLop, tenKhoa);
        }
        //sửa lớp
        public static void suaLop(string maLop, string tenLop,string tenKhoa)
        {
            Lop_DAO.suaLop(maLop, tenLop,tenKhoa);
        }
        //xóa lớp
        public static void xoaLop(string maLop)
        {
            Lop_DAO.xoaLop(maLop);
        }
        public static string lastMaLop()
        {
            return Lop_DAO.LastMaLop();
        }
        //danh sách sv trong 1 lớp, phiếu điểm
        public static DataTable phieuDiemLop_namHoc(string maLop, int namHoc)
        {
            return Lop_DAO.phieuDiemLop_namHoc(maLop, namHoc);
        }
    }
    public class Khoa_BUS
    {
        public static DataTable LoadtenKhoa()
        {
            return Khoa_DAO.tenKhoa();
        }
        public static DataTable TenKhoa_MH(string monHoc)
        {
            return Khoa_DAO.tenKhoa_MH(monHoc);
        }
        //lấy ngày nhập học sinh viên đầu tiên của khoa
        public static DataTable year_Khoa(string s)
        {
            return Khoa_DAO.year_Khoa(s);
        }
    }
    public class GiaoVien_BUS
    {
        public static DataTable LoadDSGiaoVien()
        {
            return GiaoVien_DAO.DSGiaoVien();
        }
        public static DataTable LoadtenGiaoVien(string tenKhoa)
        {
            return GiaoVien_DAO.tenGiaoVien(tenKhoa);
        }
        public static string LastMaGV()
        {
            return GiaoVien_DAO.LastMaGV();
        }
        public static void themGV(string maGV,string hoGV,string tenGV, string tenKhoa,string trinhDo)
        {
            GiaoVien_DAO.themGV(maGV, hoGV, tenGV, tenKhoa, trinhDo);
        }
        public static void suaGV_HoGV(string maGV, string hoGV)
        {
            GiaoVien_DAO.suaGV_HoGV(maGV, hoGV);
        }
        public static void suaSV_TenGV(string maGV, string TenGV)
        {
            GiaoVien_DAO.suaSV_TenGV(maGV, TenGV);
        }
        public static void suaGV_Khoa(string maGV, string tenKhoa)
        {
            GiaoVien_DAO.suaGV_Khoa(maGV, tenKhoa);
        }
        public static void suaGV_TrinhDo(string maGV, string trinhDo)
        {
            GiaoVien_DAO.suaGV_TrinhDo(maGV, trinhDo);
        }
        public static void xoaGV(string maGV)
        {
            GiaoVien_DAO.xoaGV(maGV);
        }
    }
    public class MonHoc_BUS
    {
        public static DataTable LoadtenMH(string tenKhoa)
        {
            return MonHoc_DAO.tenMH(tenKhoa);
        }
        public static DataTable DSThiLai(string s)
        {
            return MonHoc_DAO.DSThiLai(s);
        }
        public static DataTable DSMH()
        {
            return MonHoc_DAO.DSMH();
        }
    }
}
