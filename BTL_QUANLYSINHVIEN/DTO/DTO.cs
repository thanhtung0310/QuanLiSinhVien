using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SinhVien_DTO
    {
        private string _maSV;

        public string MaSV
        {
            get { return _maSV; }
            set { _maSV = value; }
        }
        private string _hoSV;

        public string HoSV
        {
            get { return _hoSV; }
            set { _hoSV = value; }
        }
        private string _tenSV;

        public string TenSV
        {
            get { return _tenSV; }
            set { _tenSV = value; }
        }
        private string _gioiTinh;

        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }
        private DateTime _ngaySinh;

        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }
        private string _diaChi;

        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _noiSinh;

        public string NoiSinh
        {
            get { return _noiSinh; }
            set { _noiSinh = value; }
        }
        private string _maLop;

        public string MaLop
        {
            get { return _maLop; }
            set { _maLop = value; }
        }
        private DateTime _ngayNhapHoc;

        public DateTime NgayNhapHoc
        {
            get { return _ngayNhapHoc; }
            set { _ngayNhapHoc = value; }
        }
        public SinhVien_DTO(string maSV,string hoSV,string tenSV,string gioiTinh,DateTime ngaySinh,string diaChi,string noiSinh,string maLop,DateTime ngayNhapHoc)
        {
            MaSV = maSV;
            HoSV = hoSV;
            TenSV = tenSV;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            NoiSinh = noiSinh;
            MaLop = maLop;
            NgayNhapHoc = ngayNhapHoc;
        }
        public SinhVien_DTO(string maSV)
        {
            MaSV = maSV;
        }
    }
    public class GiaoVien_DTO
    {
        private string _maGV;

        public string MaGV
        {
            get { return _maGV; }
            set { _maGV = value; }
        }
        private string _hoGV;

        public string HoGV
        {
            get { return _hoGV; }
            set { _hoGV = value; }
        }
        private string _tenGV;

        public string TenGV
        {
            get { return _tenGV; }
            set { _tenGV = value; }
        }
        private string _maKhoa;

        public string MaKhoa
        {
            get { return _maKhoa; }
            set { _maKhoa = value; }
        }
        public GiaoVien_DTO(string maGV,string hoGV,string tenGV,string maKhoa)
        {
            MaGV = maGV;
            HoGV = hoGV;
            TenGV = tenGV;
            MaKhoa = maKhoa;
        }
    }
    public class KetQua_DTO
    {
        private string _maSV;

        public string MaSV
        {
            get { return _maSV; }
            set { _maSV = value; }
        }
        private decimal _diemThi;

        public decimal DiemThi
        {
            get { return _diemThi; }
            set { _diemThi = value; }
        }
        private string _maLHP;

        public string MaLHP
        {
            get { return _maLHP; }
            set { _maLHP = value; }
        }
        private decimal _diemQuaTrinh;

        public decimal DiemQuaTrinh
        {
            get { return _diemQuaTrinh; }
            set { _diemQuaTrinh = value; }
        }
        private decimal _diemChuyenCan;

        public decimal DiemChuyenCan
        {
            get { return _diemChuyenCan; }
            set { _diemChuyenCan = value; }
        }
        public KetQua_DTO(string maSV,decimal diemThi,string maLHP,decimal diemQuaTrinh,decimal diemChuyenCan)
        {
            MaSV = maSV;
            MaLHP = maLHP;
            DiemThi = diemThi;
            DiemQuaTrinh = diemQuaTrinh;
            DiemChuyenCan = diemChuyenCan;
        }
    }
    public class Khoa_DTO
    {
        private string _maKhoa;

        public string MaKhoa
        {
            get { return _maKhoa; }
            set { _maKhoa = value; }
        }
        private string _tenKhoa;

        public string TenKhoa
        {
            get { return _tenKhoa; }
            set { _tenKhoa = value; }
        }
        private string _gioiThieu;

        public string GioiThieu
        {
            get { return _gioiThieu; }
            set { _gioiThieu = value; }
        }
        public Khoa_DTO(string maKhoa,string tenKhoa,string gioiThieu)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
            GioiThieu = gioiThieu;
        }
    }
    public class Lop_DTO
    {
        private string _maLop;

        public string MaLop
        {
            get { return _maLop; }
            set { _maLop = value; }
        }
        private string _tenLop;

        public string TenLop
        {
            get { return _tenLop; }
            set { _tenLop = value; }
        }
        private int _siSo;

        public int SiSo
        {
            get { return _siSo; }
            set { _siSo = value; }
        }
        private string _maKhoa;

        public string MaKhoa
        {
            get { return _maKhoa; }
            set { _maKhoa = value; }
        }
        public Lop_DTO(string maLop,string tenLop,int siSo,string maKhoa)
        {
            MaLop = maLop;
            TenLop = tenLop;
            SiSo = siSo;
            MaKhoa = maKhoa;
        }
    }
    public class LopHocPhan_DTO
    {
        private string _maLHP;

        public string MaLHP
        {
            get { return _maLHP; }
            set { _maLHP = value; }
        }
        private string _maMH;

        public string MaMH
        {
            get { return _maMH; }
            set { _maMH = value; }
        }
        private string _maSV;

        public string MaSV
        {
            get { return _maSV; }
            set { _maSV = value; }
        }
        private DateTime _ngayBatDau;

        public DateTime NgayBatDau
        {
            get { return _ngayBatDau; }
            set { _ngayBatDau = value; }
        }
        private DateTime _ngayKetThuc;

        public DateTime NgayKetThuc
        {
            get { return _ngayKetThuc; }
            set { _ngayKetThuc = value; }
        }
        private DateTime _ngayThi;

        public DateTime NgayThi
        {
            get { return _ngayThi; }
            set { _ngayThi = value; }
        }
        private int _kyHoc;

        public int KyHoc
        {
            get { return _kyHoc; }
            set { _kyHoc = value; }
        }
        public LopHocPhan_DTO(string maLHP,string maMH,string maSV,DateTime ngayBatDau,DateTime ngayKetThuc,DateTime ngayThi, int kyHoc)
        {
            MaLHP = maLHP;
            MaMH = maMH;
            MaSV = maSV;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            NgayThi = ngayThi;
            KyHoc = kyHoc;
        }
    }
    public class MonHoc_DTO
    {
        private string _maMH;

        public string MaMH
        {
            get { return _maMH; }
            set { _maMH = value; }
        }
        private string _tenMH;

        public string TenMH
        {
            get { return _tenMH; }
            set { _tenMH = value; }
        }
        private int _soTC;

        public int SoTC
        {
            get { return _soTC; }
            set { _soTC = value; }
        }
        private int _soTiet;

        public int SoTiet
        {
            get { return _soTiet; }
            set { _soTiet = value; }
        }
        private string _maKhoa;

        public string MaKhoa
        {
            get { return _maKhoa; }
            set { _maKhoa = value; }
        }
        public MonHoc_DTO(string maMH,string tenMH, int soTC, int soTiet,string maKhoa)
        {
            MaMH = maMH;
            TenMH = tenMH;
            SoTC = soTC;
            SoTiet = soTiet;
            MaKhoa = maKhoa;
        }
    }
    public class NhanVien_DTO
    {
        private int _maNV;

        public int MaNV
        {
            get { return _maNV; }
            set { _maNV = value; }
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _passWord;

        public string PassWord
        {
            get { return _passWord; }
            set { _passWord = value; }
        }
        private string _hoNV;

        public string HoNV
        {
            get { return _hoNV; }
            set { _hoNV = value; }
        }
        private string _tenNV;

        public string TenNV
        {
            get { return _tenNV; }
            set { _tenNV = value; }
        }
        private string _chucVu;

        public string ChucVu
        {
            get { return _chucVu; }
            set { _chucVu = value; }
        }
        //public NhanVien_DTO(string maNV,string userName, string passWord,string hoNV, string tenNV, string chucVu)
        //{
        //    MaNV = maNV;
        //    UserName = userName;
        //    PassWord = passWord;
        //    HoNV = hoNV;
        //    TenNV = tenNV;
        //    ChucVu = chucVu;
        //}
    }
}
