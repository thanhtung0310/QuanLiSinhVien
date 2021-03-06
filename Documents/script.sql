USE [master]
GO
/****** Object:  Database [SinhVien]    Script Date: 11/24/2016 7:10:10 AM ******/
CREATE DATABASE [SinhVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SinhVien', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SinhVien.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SinhVien_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\SinhVien_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SinhVien] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SinhVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SinhVien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SinhVien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SinhVien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SinhVien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SinhVien] SET ARITHABORT OFF 
GO
ALTER DATABASE [SinhVien] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SinhVien] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SinhVien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SinhVien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SinhVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SinhVien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SinhVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SinhVien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SinhVien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SinhVien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SinhVien] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SinhVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SinhVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SinhVien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SinhVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SinhVien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SinhVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SinhVien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SinhVien] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SinhVien] SET  MULTI_USER 
GO
ALTER DATABASE [SinhVien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SinhVien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SinhVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SinhVien] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SinhVien]
GO
/****** Object:  StoredProcedure [dbo].[DSSV_ThiLai]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DSSV_ThiLai]
@tenMH nvarchar(50)
as begin
declare @mamh nchar(10)
set @mamh=(select mamh from tblMonHoc where TenMH=@tenMH)
select k.MaSV,(s.hosv+''+s.tensv ) TenSv,d.TenLop
from tblSinhVien s,tblKetQua k,tblLopHocPhan l,tblLop d
where s.MaSV=k.MaSV and l.MaLHP=k.MaLHP and DiemTB<4 and l.MaMH=@mamh and d.MaLop=s.MaLop
end

GO
/****** Object:  StoredProcedure [dbo].[sp_BANGDIEM_LOP_Kyhoc]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_BANGDIEM_LOP_Kyhoc]
@maLop nchar(10),
@kyHoc int,
@namHoc int
as
begin
select q.MaSV,q.HoSV+' '+q.TenSV as TenSV,Q.GioiTinh,Q.NgaySinh,CONVERT(DECIMAL(4,2),sinhvien.DiemTL) AS 'Điểm tích lũy',sinhvien.tongTC tongTC from
(SELECT sv.ma 'MaSV',SUM(sv.diem*sv.tc)/sum(sv.tc) DiemTL, SUM(sv.tc) tongTC FROM
(select kq.MaSV ma,mh.mamh mamh,(case  when MAX(Diemtb) >=9 then 4 
													when MAX(Diemtb)>=8.5 then 3.7
													when MAX(Diemtb)>=8 then 3.5
													when MAX(Diemtb)>=7 then 3
													WHEN MAX(DiemTB)>=6.5 THEN 2.5
													when MAX(Diemtb)>=5.5 then 2
													when MAX(Diemtb)>=4 then 1
													else 0 end) diem,mh.tinchi tc,sum(case kq.MaLHP when null then 0 else 1 end ) lanthi from tblketqua kq join
(select a.MaMH mamh,a.MaLHP malhp,b.TenMH tenmh,b.SoTC tinchi from tblLopHocPhan a  join tblMonHoc b on a.MaMH=b.MaMH where a.NamHoc=@namHoc and a.Kyhoc=@kyHoc) mh on kq.MaLHP=mh.malhp
group by kq.MaSV,mh.mamh,mh.tinchi) SV
GROUP BY SV.ma) sinhvien
, tblSinhVien q where sinhvien.MaSV=q.MaSV and q.MaLop=@maLop
end


GO
/****** Object:  StoredProcedure [dbo].[sp_chuanHoaSV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_chuanHoaSV]
@maSV nchar(10),
@HOSV NVARCHAR(20),
@TENSV NVARCHAR(20),
@GIOITINH NVARCHAR(3),
@DIACHI NVARCHAR(50),
@NOISINH NVARCHAR(50)
as
begin
update tblSinhVien
set hosv=@hosv,
TenSV=@TENSV,
GioiTinh=@GIOITINH,
DiaChi=@DIACHI,
NoiSinh=@NOISINH
where masv=@masv
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DSDauSach]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DSDauSach]
as
begin
select a.MaDS,a.TenDS,b.TenTL,a.TenTG,a.NXB,str(a.SL1,5)+char(47)+str(a.SL2,3) SoLuong,a.GiaSach from tblDauSach a,tblTheLoai b where a.MaTL=B.MaTL 
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DSGiaoVien]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DSGiaoVien]
as
begin
select a.MaGV,a.HoGV,a.TenGV,a.TrinhDo,b.TenKhoa from tblGiaoVien a,tblKhoa b where a.MaKhoa=b.MaKhoa
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DSLHP]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE proc [dbo].[sp_DSLHP]
as
begin
SELECT a.MaLHP,C.TenMH,b.HoGV+ ' '+ b.TenGV as TenGV,a.KyHoc,a.NgayThi,a.NgayBatDau,a.NgayKetThuc,d.TenKhoa,a.NamHoc FROM tblLopHocPhan a,tblGiaoVien b,tblMonHoc c,tblKhoa d where a.MaGV=b.MaGV and a.MaMH=c.MaMH and c.MaKhoa=d.MaKhoa
end





GO
/****** Object:  StoredProcedure [dbo].[sp_DSLop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DSLop]
AS
BEGIN
select a.MaLop,a.TenLop,a.SiSo,b.TenKhoa from tblLop A,tblKhoa B where a.MaKhoa=b.MaKhoa
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DSMH]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DSMH]
as
begin
select TenMH FROM tblMonHoc
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DSSinhVien]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_DSSinhVien]
as
	begin 
		select a.MaSV,a.HoSV,a.TenSV,a.GioiTinh,a.NgaySinh,a.DiaChi,a.NoiSinh,b.TenLop,a.NgayNhapHoc from tblSinhVien a inner join tblLop b on a.MaLop=b.MaLop 
	end





GO
/****** Object:  StoredProcedure [dbo].[sp_DSSinhVien_Khoa]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [dbo].[sp_DSSinhVien_Khoa]
@tenKhoa nvarchar(50),
@namHoc int
as
begin
declare @maKhoa nchar(10)
set @maKhoa=(select MaKhoa from tblKhoa where @tenKhoa=TenKhoa)
select q.MaSV,q.HoSV+' '+q.TenSV as TenSV,Q.NgaySinh,p.TenLop,CONVERT(DECIMAL(4,2),sinhvien.DiemTL) DiemTL,'' GhiChu,sinhvien.LanThi,sinhvien.DieuKien from
(SELECT sv.ma 'MaSV',SUM(sv.diem*sv.tc)/sum(sv.tc) DiemTL, SUM(sv.tc) tongTC,max(sv.lanthi) lanthi,max(sv.dieukien) DieuKien FROM
(select kq.MaSV ma,mh.mamh mamh,(case  when MAX(Diemtb) >=9 then 4 
													when MAX(Diemtb)>=8.5 then 3.5
													when MAX(Diemtb)>=8 then 3.2
													when MAX(Diemtb)>=7 then 3
													when MAX(Diemtb)>=5.5 then 2
													when MAX(Diemtb)>=4 then 1
													else 0 end) diem,mh.tinchi tc,sum(case kq.MaLHP when null then 0 else 1 end ) lanthi,(case when max(diemtb)>=7 then 1 else 2 end) dieukien from tblketqua kq join
(select a.MaMH mamh,a.MaLHP malhp,b.TenMH tenmh,b.SoTC tinchi from tblLopHocPhan a  join tblMonHoc b on a.MaMH=b.MaMH where year(a.NgayThi)=@namHoc) mh on kq.MaLHP=mh.malhp
group by kq.MaSV,mh.mamh,mh.tinchi) SV
GROUP BY SV.ma) sinhvien,
 tblSinhVien q,
 tblLop P where sinhvien.MaSV=q.MaSV and q.MaLop=p.MaLop and p.MaKhoa=@maKhoa
 order by sinhvien.DiemTL desc
end




GO
/****** Object:  StoredProcedure [dbo].[sp_DSSV_Lop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_DSSV_Lop]
@tenLop nvarchar(50)
as
begin
declare @ma nchar(10)
set @ma = (select MaLop from tblLop where TenLop=@tenLop)
select MaSV,HoSV+' '+TenSV as TenSV,GioiTinh,NgaySinh,DiaChi,NgayNhapHoc from tblSinhVien where MaLop=@ma
end



GO
/****** Object:  StoredProcedure [dbo].[sp_kyHocSV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_kyHocSV]
@maSV nchar(10)
as
begin
select distinct a.KyHoc+YEAR(a.NgayThi)-year(b.NgayNhapHoc)-1 as KyHoc
 from tblLopHocPhan a,tblSinhVien b,tblKetQua c where c.MaLHP=a.MaLHP and b.MaSV=c.MaSV and b.MaSV=@maSV
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_LastMaDS]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LastMaDS]
as
begin
SELECT TOP(1) WITH TIES MaDS FROM tblDauSach
ORDER BY MaDS DESC
end

GO
/****** Object:  StoredProcedure [dbo].[sp_lastMaGV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_lastMaGV]
AS
begin
select TOP(1) WITH TIES MaGV from tblGiaoVien 
order by MaGV desc
end

GO
/****** Object:  StoredProcedure [dbo].[sp_lastMaLHP]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_lastMaLHP]
as
begin
select top(1) with ties MaLHP FROM tblLopHocPhan
ORDER BY MaLHP DESC
END


GO
/****** Object:  StoredProcedure [dbo].[sp_lastMaLop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_lastMaLop]
as
begin
select top(1) with ties MaLop from tblLop
order by MaLop desc
end

GO
/****** Object:  StoredProcedure [dbo].[sp_lastMaSV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_lastMaSV]
AS
BEGIN
SELECT TOP(1) WITH TIES MaSV FROM tblSinhVien
ORDER BY MaSV DESC
END

GO
/****** Object:  StoredProcedure [dbo].[sp_LHP]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE proc [dbo].[sp_LHP]
@maLHP nchar(10)
AS
BEGIN
select b.MaSV,b.HoSV+' '+ b.TenSV as TenSV,b.NgaySinh,b.NgayNhapHoc,a.DiemChuyenCan,a.DiemQuaTrinh,a.DiemThi,a.DiemTB from tblKetQua a inner join tblSinhVien b
on a.MaSV=b.MaSV and a.MaLHP=@maLHP
END






GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_Login]
@user nchar(20),
@pass nchar(20)
as
begin
select * from tblNhanVien where username=@user and password=@pass
end


GO
/****** Object:  StoredProcedure [dbo].[SP_maLop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_maLop]
@tenLop nvarchar(50)
as
begin
select malop from tblLop where TenLop=@tenLop
end

GO
/****** Object:  StoredProcedure [dbo].[sp_phieuDiem_Lop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_phieuDiem_Lop]
@tenLop nvarchar(50),
@kyHoc tinyint,
@namHoc int
as
begin
declare @maLop nchar(10) set @maLop=(select MaLop from tblLop where TenLop=@tenLop)
select q.MaSV,q.HoSV+' '+q.TenSV as TenSV,Q.GioiTinh,Q.NgaySinh,CONVERT(DECIMAL(4,2),sinhvien.DiemTL) AS DiemTL from
(SELECT sv.ma 'MaSV',SUM(sv.diem*sv.tc)/sum(sv.tc) DiemTL FROM
(select kq.MaSV ma,mh.mamh mamh,MAX(Diemtb) diem,mh.tinchi tc,sum(case kq.MaLHP when null then 0 else 1 end ) lanthi from tblketqua kq join
(select a.MaMH mamh,a.MaLHP malhp,b.TenMH tenmh,b.SoTC tinchi from tblLopHocPhan a  , tblMonHoc b where a.MaMH=b.MaMH and a.KyHoc=KyHoc and year(a.NgayThi)=@namHoc) mh on kq.MaLHP=mh.malhp
group by kq.MaSV,mh.mamh,mh.tinchi) SV
GROUP BY SV.ma) sinhvien, tblSinhVien q where sinhvien.MaSV=q.MaSV and q.MaLop=@maLop
end



GO
/****** Object:  StoredProcedure [dbo].[sp_phieuDiem_Lop_kyHoc]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_phieuDiem_Lop_kyHoc]
@maLop nchar(10),
@kyHoc int,
@namHoc int
as
begin
select q.MaSV,q.HoSV+' '+q.TenSV as TenSV,Q.GioiTinh,Q.NgaySinh,CONVERT(DECIMAL(4,2),sinhvien.DiemTL) from
(SELECT sv.ma 'MaSV',SUM(sv.diem*sv.tc)/sum(sv.tc) DiemTL FROM
(select kq.MaSV ma,mh.mamh mamh,MAX(Diemtb) diem,mh.tinchi tc,sum(case kq.MaLHP when null then 0 else 1 end ) lanthi from tblketqua kq join
(select a.MaMH mamh,a.MaLHP malhp,b.TenMH tenmh,b.SoTC tinchi from tblLopHocPhan a  join tblMonHoc b on a.MaMH=b.MaMH where a.KyHoc=@kyHoc and year(a.NamHoc)=@namHoc) mh on kq.MaLHP=mh.malhp
group by kq.MaSV,mh.mamh,mh.tinchi) SV
GROUP BY SV.ma) sinhvien, tblSinhVien q where sinhvien.MaSV=q.MaSV and q.MaLop=@maLop
end


GO
/****** Object:  StoredProcedure [dbo].[sp_phieuDiem_Lop_namHoc]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE proc [dbo].[sp_phieuDiem_Lop_namHoc]
@maLop nchar(10),
@namHoc int
as
begin
select q.MaSV,q.HoSV+' '+q.TenSV as TenSV,Q.GioiTinh,Q.NgaySinh,CONVERT(DECIMAL(4,2),sinhvien1.DiemTL) DiemTL1,CONVERT(DECIMAL(4,2),sinhvien2.DiemTL) DiemTL2,CONVERT(DECIMAL(4,2),sinhvien.DiemTL) DiemTL,sinhvien.tongTC from
(SELECT sv.ma 'MaSV',SUM(sv.diem*sv.tc)/sum(sv.tc) DiemTL, SUM(sv.tc) tongTC FROM
(select kq.MaSV ma,mh.mamh mamh,(case  when MAX(Diemtb) >=9 then 4 
													when MAX(Diemtb)>=8.5 then 3.7
													when MAX(Diemtb)>=8 then 3.5
													when MAX(Diemtb)>=7 then 3
													WHEN MAX(DiemTB)>=6.5 THEN 2.5
													when MAX(Diemtb)>=5.5 then 2
													when MAX(Diemtb)>=4 then 1
													else 0 end) diem,mh.tinchi tc,sum(case kq.MaLHP when null then 0 else 1 end ) lanthi from tblketqua kq join
(select a.MaMH mamh,a.MaLHP malhp,b.TenMH tenmh,b.SoTC tinchi from tblLopHocPhan a  join tblMonHoc b on a.MaMH=b.MaMH where a.NamHoc=@namHoc) mh on kq.MaLHP=mh.malhp
group by kq.MaSV,mh.mamh,mh.tinchi) SV
GROUP BY SV.ma) sinhvien left join
(SELECT sv.ma 'MaSV',SUM(sv.diem*sv.tc)/sum(sv.tc) DiemTL FROM
(select kq.MaSV ma,mh.mamh mamh,(case  when MAX(Diemtb) >=9 then 4 
													when MAX(Diemtb)>=8.5 then 3.7
													when MAX(Diemtb)>=8 then 3.5
													when MAX(Diemtb)>=7 then 3
													WHEN MAX(DiemTB)>=6.5 THEN 2.5
													when MAX(Diemtb)>=5.5 then 2
													when MAX(Diemtb)>=4 then 1
													else 0 end) diem,mh.tinchi tc,sum(case kq.MaLHP when null then 0 else 1 end ) lanthi from tblketqua kq join
(select a.MaMH mamh,a.MaLHP malhp,b.TenMH tenmh,b.SoTC tinchi from tblLopHocPhan a  join tblMonHoc b on a.MaMH=b.MaMH where a.NamHoc=@namHoc and a.KyHoc=1) mh on kq.MaLHP=mh.malhp
group by kq.MaSV,mh.mamh,mh.tinchi) SV
GROUP BY SV.ma) sinhvien1 on sinhvien.MaSV=sinhvien1.MaSV left join
(SELECT sv.ma 'MaSV',SUM(sv.diem*sv.tc)/sum(sv.tc) DiemTL FROM
(select kq.MaSV ma,mh.mamh mamh,(case  when MAX(Diemtb) >=9 then 4 
													when MAX(Diemtb)>=8.5 then 3.7
													when MAX(Diemtb)>=8 then 3.5
													when MAX(Diemtb)>=7 then 3
													WHEN MAX(DiemTB)>=6.5 THEN 2.5
													when MAX(Diemtb)>=5.5 then 2
													when MAX(Diemtb)>=4 then 1
													else 0 end) diem,mh.tinchi tc,sum(case kq.MaLHP when null then 0 else 1 end ) lanthi from tblketqua kq join
(select a.MaMH mamh,a.MaLHP malhp,b.TenMH tenmh,b.SoTC tinchi from tblLopHocPhan a  join tblMonHoc b on a.MaMH=b.MaMH where a.NamHoc=@namHoc and a.KyHoc=2) mh on kq.MaLHP=mh.malhp
group by kq.MaSV,mh.mamh,mh.tinchi) SV
GROUP BY SV.ma) sinhvien2 on sinhvien.MaSV=sinhvien2.MaSV,
 tblSinhVien q where sinhvien.MaSV=q.MaSV and q.MaLop=@maLop
end





GO
/****** Object:  StoredProcedure [dbo].[sp_Phieudiem_sv_kyhoc]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


 CREATE proc [dbo].[sp_Phieudiem_sv_kyhoc]
 @maSV nchar(10)
as
begin
select ab.MaLHP,ab.TenMH,ab.SoTC,ab.DiemChuyenCan,ab.DiemQuaTrinh,ab.DiemThi,ab.DiemTB,ab.KyHoc,ab.NamHoc,y.lanthi SoLanThi from
	(select a.MaLHP,c.TenMH,c.SoTC,a.DiemChuyenCan,A.DiemQuaTrinh,A.DiemThi,a.DiemTB,b.KyHoc + (b.NamHoc-YEAR(d.ngaynhaphoc)-1)*2as KyHoc,b.NamHoc from tblKetQua a,tblLopHocPhan b,tblMonHoc c,tblSinhVien d
	where a.MaLHP=b.MaLHP and b.MaMH=c.MaMH and a.MaSV=@maSV and a.MaSV=D.MaSV) ab,
	--
	(select tenmh, max(k.diemtb) DiemTbMax,sum(case s.MaLHP when null then 0 else 1 end ) lanthi
	from tblKetQua k,(select tenmh,MaLHP from tblLopHocPhan l,tblMonHoc m where l.MaMH=m.MaMH) s
	where k.MaLHP=s.MaLHP and MaSV=@maSV
	group by TenMH) y
	where ab.TenMH=y.TenMH and (ab.DiemTB=y.DiemTbMax or y.DiemTbMax is null)
	order by ab.KyHoc,ab.namhoc asc

end


GO
/****** Object:  StoredProcedure [dbo].[sp_phieuDiemSV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_phieuDiemSV]
@maSV nchar(10)
as
begin
select ab.MaLHP,ab.TenMH,ab.SoTC,ab.DiemChuyenCan,ab.DiemQuaTrinh,ab.DiemThi,ab.DiemTB,ab.KyHoc,ab.NamHoc,y.lanthi SoLanThi from
	(select a.MaLHP,c.TenMH,c.SoTC,a.DiemChuyenCan,A.DiemQuaTrinh,A.DiemThi,a.DiemTB,b.KyHoc + YEAR(b.NgayThi)-YEAR(d.ngaynhaphoc) -1 as KyHoc,year(b.NgayThi) NamHoc from tblKetQua a,tblLopHocPhan b,tblMonHoc c,tblSinhVien d
	where a.MaLHP=b.MaLHP and b.MaMH=c.MaMH and a.MaSV=@maSV and a.MaSV=D.MaSV) ab,
	--
	(select tenmh, max(k.diemtb) DiemTbMax,sum(case s.MaLHP when null then 0 else 1 end ) lanthi
	from tblKetQua k,(select tenmh,MaLHP from tblLopHocPhan l,tblMonHoc m where l.MaMH=m.MaMH) s
	where k.MaLHP=s.MaLHP and MaSV=@maSV
	group by TenMH) y
	where ab.TenMH=y.TenMH and (ab.DiemTB=y.DiemTbMax or y.DiemTbMax is null)
	order by ab.KyHoc,ab.namhoc asc

end


GO
/****** Object:  StoredProcedure [dbo].[sp_suaGV_HoGV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_suaGV_HoGV] @ma nvarchar(100), @t nchar(10)
as
begin
update tblGiaoVien
set HoGV =@t
where MaGV=@ma
end



GO
/****** Object:  StoredProcedure [dbo].[sp_suaGV_Khoa]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaGV_Khoa] @ma nchar(10) , @tenKhoa nvarchar(50)
as
begin
declare @maKhoa nchar(10)
set @maKhoa=(select MaKhoa from tblKhoa where TenKhoa=@tenKhoa)
update tblGiaoVien
set MaKhoa =@maKhoa
where MaGV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaGV_TenGV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_suaGV_TenGV] @ma nvarchar(100), @t nchar(10)
as
begin
update tblGiaoVien
set TenGV =@t
where MaGV=@ma
end


GO
/****** Object:  StoredProcedure [dbo].[sp_suaGV_TrinhDo]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaGV_TrinhDo] @ma nchar(10), @trinhDo nvarchar(50)
as
begin
update tblGiaoVien
set TrinhDo=@trinhDo
where MaGV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaLHP_date]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaLHP_date]
@maLHP nchar(10),
@ngaybt date,
@ngaykt date,
@ngaythi date
as
begin
	update tblLopHocPhan
	set NgayBatDau=@ngaybt,NgayKetThuc=@ngaykt,NgayThi=@ngaythi
	where MaLHP=@maLHP
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaLHP_GV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaLHP_GV]
@maLHP nchar(10),
@giaoVien nvarchar(50)
as
begin
	declare @m1 nchar(10) set @m1=(select MaGV from tblGiaoVien where @giaoVien=HoGV+' '+TenGV )
	update tblLopHocPhan
	set MaGV=@m1
	where MaLHP=@maLHP
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaLHP_KyHoc]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaLHP_KyHoc]
@maLHP nchar(10),
@kyHoc tinyint
as
begin
	update tblLopHocPhan
	set KyHoc=@kyHoc
	where MaLHP=@maLHP
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaLHP_MH]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaLHP_MH]
@maLHP nchar(10),
@monHoc nvarchar(50)
as
begin
	declare @m2 nchar(10) set @m2=(select MaMH from tblMonHoc where TenMH=@monHoc)
	update tblLopHocPhan
	set MaMH=@m2
	where MaLHP=@maLHP
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaLHP_NamHoc]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_suaLHP_NamHoc]
@maLHP nchar(10),
@namHoc int
as
begin
update tblLopHocPhan
SET NamHoc=@namHoc
WHERE MaLHP=@maLHP
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaLop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_suaLop] 
@malop nchar(10),
@tenlop nvarchar(50),
@tenkhoa nvarchar(50)
as
begin
declare @makhoa nchar(10)
set @makhoa=(select makhoa from tblKhoa where  tenKhoa=@tenkhoa)
update tblLop
set TenLop=@tenlop,MaKhoa=@makhoa
where MaLop=@malop
end


GO
/****** Object:  StoredProcedure [dbo].[sp_suaSV_DiaChi]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaSV_DiaChi] @t nvarchar(100),@ma nchar(10)
as 
begin
update tblSinhVien
set DiaChi=@t
where MaSV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaSV_GioiTinh]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaSV_GioiTinh] @t nvarchar(100),@ma nchar(10)
as 
begin
update tblSinhVien
set GioiTinh=@t
where MaSV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaSV_HoSV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaSV_HoSV] @ho nvarchar(100),@ma nchar(10)
as 
begin
update tblSinhVien
set HoSV=@ho
where MaSV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaSV_Lop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaSV_Lop] @tenLop nvarchar(50),@ma nchar(10)
as
begin
declare @maLop nchar(10) set @maLop=(select MaLop from tblLop where tenLop=@tenLop)
update tblSinhVien
set MaLop=@maLop
where MaSV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaSV_ngayNhapHoc]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaSV_ngayNhapHoc] @ngay date,@ma nchar(10)
as 
begin
update tblSinhVien
set NgayNhapHoc =@ngay
where MaSV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaSV_NgaySinh]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaSV_NgaySinh] @t date,@ma nchar(10)
as 
begin
update tblSinhVien
set NgaySinh=@t
where MaSV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaSV_NoiSinh]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaSV_NoiSinh] @t nvarchar(100),@ma nchar(10)
as 
begin
update tblSinhVien
set NoiSinh=@t
where MaSV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_suaSV_TenSV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_suaSV_TenSV] @t nvarchar(100),@ma nchar(10)
as 
begin
update tblSinhVien
set TenSV=@t
where MaSV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_tenGiaovien]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_tenGiaovien]
@tenKhoa nvarchar(50)
as
begin
select HoGV+' '+ TenGV from tblGiaoVien a , tblKhoa b where a.MaKhoa=b.MaKhoa  and b.TenKhoa=@tenKhoa
end



GO
/****** Object:  StoredProcedure [dbo].[sp_tenKhoa]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_tenKhoa]
as
begin
select tenKhoa from tblKhoa
end

GO
/****** Object:  StoredProcedure [dbo].[sp_tenKHoa_MH]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_tenKHoa_MH]
@monHoc nvarchar(50)
as
begin
	select TenKhoa from tblMonHoc a,tblKhoa b where a.MaKhoa=b.MaKhoa and a.TenMH=@monHoc
end


GO
/****** Object:  StoredProcedure [dbo].[sp_tenLop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_tenLop]
as
begin
select TenLop from tblLop
end

GO
/****** Object:  StoredProcedure [dbo].[sp_tenMH]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_tenMH]
@tenKhoa nvarchar(50)
as
begin
select a.TenMH from tblMonHoc a inner join tblKhoa b on a.MaKhoa=b.MaKhoa where b.TenKhoa= @TenKhoa
end



GO
/****** Object:  StoredProcedure [dbo].[sp_themDiem]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_themDiem]
@maSV nchar(10),
@maLHP nchar(10),
@dcc decimal,
@dqt decimal,
@dt decimal,
@dtb decimal
as
begin
update tblKetQua
set DiemChuyenCan=@dcc,DiemQuaTrinh=@dqt,DiemThi=@dt,DiemTB=@dtb
where MaSV=@maSV and MaLHP=@maLHP
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ThemDS]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemDS]
@maDS char(10),
@tenDS nvarchar(50),
@maTL char(10),
@sl1 int,
@sl2 int
as
begin
insert into tblDauSach(MaDS,TenDS,MaTL,SL1,SL2) values(@maDS,@tenDS,@maTL,@sl1,@sl2)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_themDSSV_LHP]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_themDSSV_LHP]
@tenLop nvarchar(50),
@maLHP nchar(10)
as
begin
declare @malop nchar(10)
set @malop= (select malop from tblLop where TenLop=@tenlop)
insert into tblKetQua(MaSV,MaLHP)
select s.MaSV,@maLHP
from (select masv from tblSinhVien where MaLop=@malop) as s

end


GO
/****** Object:  StoredProcedure [dbo].[sp_ThemGV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemGV]
@maGV nchar(10),
@hoGV nvarchar(50),
@tenGV nvarchar(50),
@tenKhoa nvarchar(50),
@trinhDo nvarchar(50)
as
begin
declare @maKhoa nchar(10)
set @maKhoa=(select MaKhoa from tblKhoa where TenKhoa=@tenKhoa)
insert into tblGiaoVien values(@maGV,@hoGV,@tenGV,@maKhoa,@trinhDo)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_themLHP]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_themLHP]
@maLHP nchar(10),
@monHoc nvarchar(50),
@giaoVien nvarchar(50),
@ngaybd date,
@ngaykt date,
@ngayThi date,
@kyHoc int,
@namhoc int
as
begin
	declare @m1 nchar(10) set @m1=(select MaGV from tblGiaoVien where @giaoVien=HoGV+' '+TenGV )
	declare @m2 nchar(10) set @m2=(select MaMH from tblMonHoc where TenMH=@monHoc)
	insert into tblLopHocPhan
	values(@maLHP,@m2,@m1,@ngaybd,@ngaykt,@ngayThi,@kyHoc,@namhoc)
end



GO
/****** Object:  StoredProcedure [dbo].[sp_themLop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_themLop] @malop nchar(10), @tenlop nvarchar(50), @siSo tinyint, @tenkhoa nvarchar(100)
as
begin
declare @makhoa nvarchar(10)
set @makhoa=(select makhoa from tblKhoa where  tenKhoa=@tenkhoa)
insert into tblLop
values (@malop,@tenlop,@siSo,@makhoa)
end 



GO
/****** Object:  StoredProcedure [dbo].[sp_themSV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [dbo].[sp_themSV]
@masv nchar(10),
@HOSV NVARCHAR(20),
@TENSV NVARCHAR(20),
@GIOITINH NVARCHAR(3),
@NGAYSINH DATE,
@DIACHI NVARCHAR(50),
@NOISINH NVARCHAR(50),
@MALOP nchar(10),
@NGAYNHAPHOC DATE
AS
BEGIN
INSERT INTO tblSinhVien VALUES(@masv,@HOSV,@TENSV,@GIOITINH,@NGAYSINH,@DIACHI,@NOISINH,@MALOP,@NGAYNHAPHOC)
END




GO
/****** Object:  StoredProcedure [dbo].[sp_themSV_LHP]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_themSV_LHP]
@maSV NCHAR(10),
@maLHP nchar(10)
as
begin
insert into tblKetQua(MaSV,MaLHP) values(@maSV,@maLHP)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_ThiLai]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_ThiLai]
@tenMH nvarchar(50)
as begin
declare @mamh nchar(10)
set @mamh=(select mamh from tblMonHoc where TenMH=@tenMH)
select s.MaSV,(s.hosv+' '+s.tensv ) TenSV,s.NgaySinh,d.TenLop
from tblSinhVien s,tblLop d,
(select kq.MaSV ma,mh.mamh mamh,max(DiemThi) diem,mh.tinchi tc from tblketqua kq join
(select a.MaMH mamh,a.MaLHP malhp,b.TenMH tenmh,b.SoTC tinchi from tblLopHocPhan a  join tblMonHoc b on a.MaMH=b.MaMH) mh on kq.MaLHP=mh.malhp
group by kq.MaSV,mh.mamh,mh.tinchi) SV
where sv.ma=s.MaSV and sv.mamh=@mamh and sv.diem<4 and s.MaLop=d.MaLop
end



GO
/****** Object:  StoredProcedure [dbo].[sp_timeLHP]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_timeLHP]
@maLHP INT
as
begin
select NgayBatDau, NgayKetThuc from tblLopHocPhan where MaLHP=@maLHP
end


GO
/****** Object:  StoredProcedure [dbo].[sp_timKiemSV_ho]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sp_timKiemSV_ho]
 @s nvarchar(50)
 as
 begin
 select * from tblSinhVien where HoSV like @s
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_timKiemSV_ten]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_timKiemSV_ten]
 @s nvarchar(50)
 as
 begin
 select * from tblSinhVien where TenSV like @s
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_xoaGV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_xoaGV]
@maGV nchar(10)
as
begin
delete from tblGiaoVien where MaGV=@maGV
end

GO
/****** Object:  StoredProcedure [dbo].[sp_xoaLHP]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_xoaLHP]
@maLHP nchar(10)
as
begin
	delete from tblLopHocPhan
	where MaLHP=@maLHP
end

GO
/****** Object:  StoredProcedure [dbo].[sp_xoaLop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_xoaLop] @malop nchar(10)
as
begin
delete from tblLop
where MaLop=@malop
end

GO
/****** Object:  StoredProcedure [dbo].[sp_XoaSV]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_XoaSV]
@ma nchar(10)
as
begin
delete from tblSinhVien
where MaSV=@ma
end

GO
/****** Object:  StoredProcedure [dbo].[sp_xoaSV_LHP]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_xoaSV_LHP]
@MASV nCHAR(10),
@maLHP nchar(10)
as
begin

delete from tblKetQua where MaLHP=@maLHP and MaSV=@masv
end


GO
/****** Object:  StoredProcedure [dbo].[sp_year_Khoa]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_year_Khoa]
@tenKhoa nvarchar(50)
as
begin
 select top(1) year(NgayNhapHoc) from tblSinhVien a,tblLop b, tblKhoa c
 where a.MaLop=b.MaLop and b.MaKhoa=c.MaKhoa and c.TenKhoa=@tenKhoa
 order by year(NgayNhapHoc) asc
 end

GO
/****** Object:  StoredProcedure [dbo].[themDiem]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[themDiem]
@maSV nchar(10),
@maLHP nchar(10),
@dcc decimal,
@dqt decimal,
@dt decimal,
@dtb decimal
as
begin
update tblKetQua
set DiemChuyenCan=@dcc,DiemQuaTrinh=@dqt,DiemThi=@dt,DiemTB=@dtb
where MaSV=@maSV and MaLHP=@maLHP
end

GO
/****** Object:  StoredProcedure [dbo].[Xoa_tblSinhVien]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Xoa_tblSinhVien] 
@ma nchar(10)
as
begin
delete from tblSinhVien
where MaSV=@ma
end

GO
/****** Object:  UserDefinedFunction [dbo].[max_banghi]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[max_banghi]
(@tenbang nvarchar(50))
returns int
as
begin
declare @soLuong int
	select @soLuong=(select top(1) with ties soLuong from
	(select count(MaSV) soLuong ,MaLop from tblSinhVien group by MaLop) sv
	order by sv.soLuong desc)
	return @soLuong
end

GO
/****** Object:  UserDefinedFunction [dbo].[Max_SV_LOP]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Max_SV_LOP] ()
returns NCHAR(10)
as
begin
declare @maLop NCHAR(10)
	select @maLop =(
	select b.MaLop from
	(select top(1) with ties soLuong from
	(select count(MaSV) soLuong ,MaLop from tblSinhVien group by MaLop) sv
	order by sv.soLuong desc) a,
	(select count(MaSV) soLuong ,MaLop from tblSinhVien group by MaLop) b where a.soLuong=b.soLuong)
	return @maLop
end

GO
/****** Object:  UserDefinedFunction [dbo].[Max_SV_LOP_2]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Max_SV_LOP_2] ()
returns NCHAR(10)
as
begin
declare @maLop NCHAR(10)
	select @maLop =(
	select b.MaLop from
	(select top(3) with ties soLuong from
	(select count(MaSV) soLuong ,MaLop from tblSinhVien group by MaLop) sv
	order by sv.soLuong desc) a,
	(select count(MaSV) soLuong ,MaLop from tblSinhVien group by MaLop) b where a.soLuong=b.soLuong)
	return @maLop
end

GO
/****** Object:  Table [dbo].[tblGiaoVien]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGiaoVien](
	[MaGV] [nchar](10) NOT NULL,
	[HoGV] [nvarchar](20) NULL,
	[TenGV] [nvarchar](20) NOT NULL,
	[MaKhoa] [nchar](10) NOT NULL,
	[TrinhDo] [nvarchar](50) NULL,
 CONSTRAINT [PK__tblGiaoV__2725AEF3E518D8EB] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblKetQua]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKetQua](
	[MaSV] [nchar](10) NOT NULL,
	[DiemThi] [decimal](5, 2) NULL,
	[MaLHP] [nchar](10) NOT NULL,
	[DiemChuyenCan] [decimal](5, 2) NULL,
	[DiemQuaTrinh] [decimal](5, 2) NULL,
	[DiemTB] [decimal](5, 2) NULL,
 CONSTRAINT [tblKetQua_maSV_maLHP] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC,
	[MaLHP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblKhoa]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhoa](
	[MaKhoa] [nchar](10) NOT NULL,
	[TenKhoa] [nvarchar](50) NOT NULL,
	[GioiThieu] [nvarchar](1000) NULL,
 CONSTRAINT [PK__tblKhoa__65390405C1F16C4E] PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLop]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLop](
	[MaLop] [nchar](10) NOT NULL,
	[TenLop] [nvarchar](50) NOT NULL,
	[SiSo] [tinyint] NULL,
	[MaKhoa] [nchar](10) NOT NULL,
 CONSTRAINT [PK__tblLop__3B98D2737B37A478] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLopHocPhan]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLopHocPhan](
	[MaLHP] [nchar](10) NOT NULL,
	[MaMH] [nchar](10) NOT NULL,
	[MaGV] [nchar](10) NOT NULL,
	[NgayBatDau] [date] NULL,
	[NgayKetThuc] [date] NULL,
	[NgayThi] [date] NULL,
	[KyHoc] [tinyint] NOT NULL,
	[NamHoc] [int] NULL,
 CONSTRAINT [PK__tblLopHo__3B9B9690091E3013] PRIMARY KEY CLUSTERED 
(
	[MaLHP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblMonHoc]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblMonHoc](
	[MaMH] [nchar](10) NOT NULL,
	[TenMH] [nvarchar](50) NOT NULL,
	[SoTC] [tinyint] NOT NULL,
	[SoTiet] [tinyint] NULL,
	[MaKhoa] [nchar](10) NOT NULL,
 CONSTRAINT [PK__tblMonHo__2725DFD9D98D836F] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[MaNV] [nchar](10) NOT NULL,
	[UserName] [nchar](20) NOT NULL,
	[PassWord] [nchar](20) NOT NULL,
	[HoNV] [nvarchar](50) NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[ChucVu] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblNhanVien] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSinhVien]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSinhVien](
	[MaSV] [nchar](10) NOT NULL,
	[HoSV] [nvarchar](50) NULL,
	[TenSV] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](3) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[NoiSinh] [nvarchar](50) NULL,
	[MaLop] [nchar](10) NOT NULL,
	[NgayNhapHoc] [date] NULL,
 CONSTRAINT [PK__tblSinhV__2725081AE1860D03] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[ds]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[ds](@maLop nchar(10))
returns table
as
return
(select * from tblSinhVien where MaLop=@maLop)

GO
/****** Object:  UserDefinedFunction [dbo].[Max_SV_LOP_3]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[Max_SV_LOP_3]()
returns table
as

	return 
	select b.MaLop from
	(select top(3) with ties soLuong from
	(select count(MaSV) soLuong ,MaLop from tblSinhVien group by MaLop) sv
	order by sv.soLuong desc) a,
	(select count(MaSV) soLuong ,MaLop from tblSinhVien group by MaLop) b where a.soLuong=b.soLuong


GO
/****** Object:  View [dbo].[BANGDIEM]    Script Date: 11/24/2016 7:10:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BANGDIEM] AS
SELECT S.MASV,N.MAMH,COUNT(MALHP) AS SOLANTHI,N.SOTC,MAX(DIEMTHI) AS DIEMTHI
FROM TBLSINHVIEN S,
(SELECT MASV,K.MALHP,SOTC,M.MAMH,DIEMTHI
FROM TBLKETQUA K,TBLMONHOC M,TBLLOPHOCPHAN H
WHERE K.MALHP=H.MALHP AND M.MAMH=H.MAMH) N
WHERE S.MASV=N.MASV
GROUP BY S.MASV,N.MAMH,N.SOTC


GO
INSERT [dbo].[tblGiaoVien] ([MaGV], [HoGV], [TenGV], [MaKhoa], [TrinhDo]) VALUES (N'GV0001    ', N'Nguyễn Quốc', N'Khánh', N'K00004    ', N'Thạc Sỹ')
INSERT [dbo].[tblGiaoVien] ([MaGV], [HoGV], [TenGV], [MaKhoa], [TrinhDo]) VALUES (N'GV0002    ', N'Hà Đại', N'Dương', N'K00004    ', N'Tiến Sỹ')
INSERT [dbo].[tblGiaoVien] ([MaGV], [HoGV], [TenGV], [MaKhoa], [TrinhDo]) VALUES (N'GV0003    ', N'Nguyễn Mai', N'Hường', N'K00003    ', N'Thạc Sỹ')
INSERT [dbo].[tblGiaoVien] ([MaGV], [HoGV], [TenGV], [MaKhoa], [TrinhDo]) VALUES (N'GV0004    ', N'Nguyễn Văn', N'Bắc', N'K00003    ', N'Thạc Sỹ')
INSERT [dbo].[tblGiaoVien] ([MaGV], [HoGV], [TenGV], [MaKhoa], [TrinhDo]) VALUES (N'GV0005    ', N'Lê Thị', N'Huyền', N'K00001    ', N'Thạc Sỹ')
INSERT [dbo].[tblGiaoVien] ([MaGV], [HoGV], [TenGV], [MaKhoa], [TrinhDo]) VALUES (N'GV0006    ', N'Đào Vân', N'Anh', N'K00004    ', N'Thạc Sỹ')
INSERT [dbo].[tblGiaoVien] ([MaGV], [HoGV], [TenGV], [MaKhoa], [TrinhDo]) VALUES (N'GV0007    ', N'Phạm Thành', N'Công', N'K00003    ', N'Thạc Sỹ')
INSERT [dbo].[tblGiaoVien] ([MaGV], [HoGV], [TenGV], [MaKhoa], [TrinhDo]) VALUES (N'GV0008    ', N'Lê Thanh', N'Tùng', N'K00001    ', N'Thạc Sỹ')
INSERT [dbo].[tblGiaoVien] ([MaGV], [HoGV], [TenGV], [MaKhoa], [TrinhDo]) VALUES (N'GV0009    ', N'Lê Thị', N'Trang', N'K00005    ', N'Thạc Sỹ')
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0002    ', CAST(3.00 AS Decimal(5, 2)), N'LHP0003   ', CAST(7.00 AS Decimal(5, 2)), CAST(7.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0002    ', CAST(3.00 AS Decimal(5, 2)), N'LHP0004   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0002    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0005   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.10 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0002    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0007   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0002    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0008   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0002    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0010   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0002    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0017   ', CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0002    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0018   ', CAST(6.00 AS Decimal(5, 2)), CAST(6.00 AS Decimal(5, 2)), CAST(6.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0003    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0003   ', CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0003    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0014   ', CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0004    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0007   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0004    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0011   ', CAST(8.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.90 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0004    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0005    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0007   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0005    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0011   ', CAST(7.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.80 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0005    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0007    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(6.00 AS Decimal(5, 2)), CAST(6.00 AS Decimal(5, 2)), CAST(6.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0007    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0013   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0008    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(7.00 AS Decimal(5, 2)), CAST(7.90 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0008    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0013   ', CAST(8.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(6.80 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0009    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(7.40 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0009    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0013   ', CAST(8.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(6.80 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0010    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0008   ', CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0011    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0008   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0013    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0003   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0013    ', CAST(3.00 AS Decimal(5, 2)), N'LHP0004   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0013    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0005   ', CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0013    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0007   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0013    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0008   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0013    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0010   ', CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.70 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0013    ', NULL, N'LHP0017   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0013    ', NULL, N'LHP0018   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0015    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0003   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0015    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0004   ', CAST(7.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(7.90 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0015    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0005   ', CAST(9.00 AS Decimal(5, 2)), CAST(7.00 AS Decimal(5, 2)), CAST(7.20 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0015    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0008   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0015    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0010   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(7.40 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0015    ', NULL, N'LHP0017   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0015    ', NULL, N'LHP0018   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0016    ', CAST(3.00 AS Decimal(5, 2)), N'LHP0003   ', CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(0.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0016    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0004   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0016    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0005   ', CAST(9.00 AS Decimal(5, 2)), CAST(7.00 AS Decimal(5, 2)), CAST(7.90 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0016    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0008   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0016    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0010   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.10 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0016    ', NULL, N'LHP0017   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0016    ', NULL, N'LHP0018   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0017    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0003   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0017    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0004   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0017    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0005   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(7.40 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0017    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0008   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.10 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0017    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0010   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(6.70 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0017    ', NULL, N'LHP0017   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0017    ', NULL, N'LHP0018   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0018    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0008   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0019    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0003   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0019    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0014   ', CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0020    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0003   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0020    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0004   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0020    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0005   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.80 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0020    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0008   ', CAST(9.00 AS Decimal(5, 2)), CAST(7.00 AS Decimal(5, 2)), CAST(7.90 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0020    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0010   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(6.70 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0020    ', NULL, N'LHP0017   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0020    ', NULL, N'LHP0018   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0021    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0007   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(6.90 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0021    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0011   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0021    ', CAST(5.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(6.20 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0023    ', NULL, N'LHP0017   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0023    ', NULL, N'LHP0018   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0024    ', NULL, N'LHP0017   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0024    ', NULL, N'LHP0018   ', NULL, NULL, NULL)
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0025    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0014   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0026    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0014   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0027    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0014   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0028    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0014   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(7.40 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0029    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0014   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(6.70 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0030    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0014   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.10 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0031    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0014   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0032    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0007   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0032    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0011   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0032    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0033    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0007   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0033    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0011   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0033    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0034    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0007   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0034    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0011   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0034    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0035    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0007   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.30 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0035    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0011   ', CAST(9.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.10 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0035    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(6.90 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0037    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(6.90 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0037    ', CAST(6.00 AS Decimal(5, 2)), N'LHP0013   ', CAST(8.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(6.80 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0038    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0038    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0013   ', CAST(8.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.20 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0039    ', CAST(9.00 AS Decimal(5, 2)), N'LHP0012   ', CAST(7.00 AS Decimal(5, 2)), CAST(8.00 AS Decimal(5, 2)), CAST(8.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0039    ', CAST(8.00 AS Decimal(5, 2)), N'LHP0013   ', CAST(8.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(8.20 AS Decimal(5, 2)))
INSERT [dbo].[tblKetQua] ([MaSV], [DiemThi], [MaLHP], [DiemChuyenCan], [DiemQuaTrinh], [DiemTB]) VALUES (N'SV0044    ', CAST(7.00 AS Decimal(5, 2)), N'LHP0011   ', CAST(9.00 AS Decimal(5, 2)), CAST(9.00 AS Decimal(5, 2)), CAST(7.60 AS Decimal(5, 2)))
INSERT [dbo].[tblKhoa] ([MaKhoa], [TenKhoa], [GioiThieu]) VALUES (N'K00001    ', N'Hóa Lý Kỹ Thuật', NULL)
INSERT [dbo].[tblKhoa] ([MaKhoa], [TenKhoa], [GioiThieu]) VALUES (N'K00002    ', N'Vô Tuyến', NULL)
INSERT [dbo].[tblKhoa] ([MaKhoa], [TenKhoa], [GioiThieu]) VALUES (N'K00003    ', N'Ngoại Ngữ', NULL)
INSERT [dbo].[tblKhoa] ([MaKhoa], [TenKhoa], [GioiThieu]) VALUES (N'K00004    ', N'Công Nghệ Thông Tin', NULL)
INSERT [dbo].[tblKhoa] ([MaKhoa], [TenKhoa], [GioiThieu]) VALUES (N'K00005    ', N'Tư Tưởng Mac-Lenin', NULL)
INSERT [dbo].[tblKhoa] ([MaKhoa], [TenKhoa], [GioiThieu]) VALUES (N'K00006    ', N'Cơ Khí', NULL)
INSERT [dbo].[tblKhoa] ([MaKhoa], [TenKhoa], [GioiThieu]) VALUES (N'K00007    ', N'Xây Dựng', NULL)
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00001    ', N'Lớp Vt1', 9, N'K00002    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00002    ', N'Lớp Vt2', 8, N'K00002    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00003    ', N'Lớp Hlkt1', 7, N'K00001    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00004    ', N'Lớp Hlkt2', 6, N'K00001    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00005    ', N'Lớp Nn1', 6, N'K00003    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00006    ', N'Lớp Nn2', 1, N'K00003    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00007    ', N'Lớp Th1', 1, N'K00004    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00008    ', N'Lớp Th2', 0, N'K00004    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00009    ', N'Lớp Tt1', 0, N'K00005    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00010    ', N'Lớp Tt2', 0, N'K00005    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00011    ', N'Lớp Ck1', 0, N'K00006    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00012    ', N'Lớp Ck2', 0, N'K00006    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00013    ', N'Lớp Xd1', 0, N'K00007    ')
INSERT [dbo].[tblLop] ([MaLop], [TenLop], [SiSo], [MaKhoa]) VALUES (N'L00014    ', N'Lớp Xd2', 0, N'K00007    ')
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0003   ', N'MH0003    ', N'GV0001    ', CAST(0x03390B00 AS Date), CAST(0x8C390B00 AS Date), CAST(0x91390B00 AS Date), 1, 2015)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0004   ', N'MH0002    ', N'GV0003    ', CAST(0x03390B00 AS Date), CAST(0x8C390B00 AS Date), CAST(0x91390B00 AS Date), 1, 2015)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0005   ', N'MH0006    ', N'GV0009    ', CAST(0x03390B00 AS Date), CAST(0x8C390B00 AS Date), CAST(0x91390B00 AS Date), 1, 2015)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0007   ', N'MH0002    ', N'GV0003    ', CAST(0x92390B00 AS Date), CAST(0x92390B00 AS Date), CAST(0x223A0B00 AS Date), 2, 2015)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0008   ', N'MH0001    ', N'GV0002    ', CAST(0x03390B00 AS Date), CAST(0x8C390B00 AS Date), CAST(0x91390B00 AS Date), 1, 2015)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0010   ', N'MH0007    ', N'GV0009    ', CAST(0xFF3A0B00 AS Date), CAST(0x793B0B00 AS Date), CAST(0x903B0B00 AS Date), 2, 2016)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0011   ', N'MH0009    ', N'GV0005    ', CAST(0x703A0B00 AS Date), CAST(0xF93A0B00 AS Date), CAST(0xFE3A0B00 AS Date), 1, 2016)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0012   ', N'MH0004    ', N'GV0007    ', CAST(0x703A0B00 AS Date), CAST(0xF93A0B00 AS Date), CAST(0xFE3A0B00 AS Date), 1, 2016)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0013   ', N'MH0003    ', N'GV0006    ', CAST(0x703A0B00 AS Date), CAST(0xF93A0B00 AS Date), CAST(0xFE3A0B00 AS Date), 1, 2016)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0014   ', N'MH0002    ', N'GV0003    ', CAST(0x703A0B00 AS Date), CAST(0xF93A0B00 AS Date), CAST(0xFE3A0B00 AS Date), 1, 2016)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0015   ', N'MH0006    ', N'GV0009    ', CAST(0xDE3B0B00 AS Date), CAST(0x353C0B00 AS Date), CAST(0x363C0B00 AS Date), 1, 2017)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0016   ', N'MH0007    ', N'GV0009    ', CAST(0xDE3B0B00 AS Date), CAST(0x333C0B00 AS Date), CAST(0x393C0B00 AS Date), 1, 2016)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0017   ', N'MH0008    ', N'GV0009    ', CAST(0xDE3B0B00 AS Date), CAST(0x353C0B00 AS Date), CAST(0x363C0B00 AS Date), 1, 2017)
INSERT [dbo].[tblLopHocPhan] ([MaLHP], [MaMH], [MaGV], [NgayBatDau], [NgayKetThuc], [NgayThi], [KyHoc], [NamHoc]) VALUES (N'LHP0018   ', N'MH0004    ', N'GV0007    ', CAST(0x493C0B00 AS Date), CAST(0x863C0B00 AS Date), CAST(0xA53C0B00 AS Date), 2, 2017)
INSERT [dbo].[tblMonHoc] ([MaMH], [TenMH], [SoTC], [SoTiet], [MaKhoa]) VALUES (N'MH0001    ', N'Lập Trình C', 3, NULL, N'K00004    ')
INSERT [dbo].[tblMonHoc] ([MaMH], [TenMH], [SoTC], [SoTiet], [MaKhoa]) VALUES (N'MH0002    ', N'Tiếng Anh', 3, NULL, N'K00003    ')
INSERT [dbo].[tblMonHoc] ([MaMH], [TenMH], [SoTC], [SoTiet], [MaKhoa]) VALUES (N'MH0003    ', N'Toán Chuyên Đề', 3, NULL, N'K00004    ')
INSERT [dbo].[tblMonHoc] ([MaMH], [TenMH], [SoTC], [SoTiet], [MaKhoa]) VALUES (N'MH0004    ', N'Tiếng Nga', 3, NULL, N'K00003    ')
INSERT [dbo].[tblMonHoc] ([MaMH], [TenMH], [SoTC], [SoTiet], [MaKhoa]) VALUES (N'MH0005    ', N'Cơ Sở Dữ Liệu', 3, NULL, N'K00004    ')
INSERT [dbo].[tblMonHoc] ([MaMH], [TenMH], [SoTC], [SoTiet], [MaKhoa]) VALUES (N'MH0006    ', N'Dân Tộc Học', 2, NULL, N'K00005    ')
INSERT [dbo].[tblMonHoc] ([MaMH], [TenMH], [SoTC], [SoTiet], [MaKhoa]) VALUES (N'MH0007    ', N'Chủ Nghĩa Xã Hội', 4, NULL, N'K00005    ')
INSERT [dbo].[tblMonHoc] ([MaMH], [TenMH], [SoTC], [SoTiet], [MaKhoa]) VALUES (N'MH0008    ', N'Triết 1', 4, NULL, N'K00005    ')
INSERT [dbo].[tblMonHoc] ([MaMH], [TenMH], [SoTC], [SoTiet], [MaKhoa]) VALUES (N'MH0009    ', N'Vật Lý 1', 4, NULL, N'K00001    ')
INSERT [dbo].[tblMonHoc] ([MaMH], [TenMH], [SoTC], [SoTiet], [MaKhoa]) VALUES (N'MH0010    ', N'Vật Lý 2', 4, NULL, N'K00001    ')
INSERT [dbo].[tblNhanVien] ([MaNV], [UserName], [PassWord], [HoNV], [TenNV], [ChucVu]) VALUES (N'NV001     ', N'admin               ', N'admin               ', N'ad', N'min', 1)
INSERT [dbo].[tblNhanVien] ([MaNV], [UserName], [PassWord], [HoNV], [TenNV], [ChucVu]) VALUES (N'5         ', N'user                ', N'user                ', N'user', N'1', 0)
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0001    ', N'Phạm Văn', N'Công', N'Nam', CAST(0x111D0B00 AS Date), N'Hà Nội', N'', N'L00007    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0002    ', N'Bạch Ngọc', N'Hiệp', N'Nam', CAST(0x111D0B00 AS Date), N'', N'', N'L00002    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0003    ', N'Nguyễn Quỳnh', N'Nga', N'Nữ', CAST(0x111D0B00 AS Date), N'', N'', N'L00001    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0004    ', N'Hà Thu', N'Hiền', N'Nữ', CAST(0xD11D0B00 AS Date), N'', N'', N'L00003    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0005    ', N'Nguyễn Hữu', N'Huy', N'Nam', CAST(0xA61D0B00 AS Date), N'', N'', N'L00003    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0007    ', N'Phạm Thị', N'Thu', N'Nữ', CAST(0x201D0B00 AS Date), N'', N'', N'L00004    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0008    ', N'Lê Thị', N'Huyền', N'Nữ', CAST(0x201D0B00 AS Date), N'', N'', N'L00004    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0009    ', N'Nguyễn Duy', N'Long', N'Nam', CAST(0x201D0B00 AS Date), N'', N'', N'L00004    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0010    ', N'Đặng Thị', N'Yến', N'Nữ', CAST(0x201D0B00 AS Date), N'', N'', N'L00005    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0011    ', N'Nguyễn Thu', N'Hường', N'Nữ', CAST(0x0A1D0B00 AS Date), N'', N'', N'L00005    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0013    ', N'Hà Thị', N'Trang', N'Nữ', CAST(0xED1C0B00 AS Date), N'', N'', N'L00002    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0015    ', N'Nguyễn Duy', N'Khánh', N'Nam', CAST(0x331E0B00 AS Date), N'', N'', N'L00002    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0016    ', N'Nguyễn Văn', N'Bắc', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00002    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0017    ', N'Nguyễn Xuân', N'Dân', N'Nam', CAST(0x111D0B00 AS Date), N'', N'', N'L00002    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0018    ', N'Nguyễn Văn', N'Tuyển', N'Nam', CAST(0x111D0B00 AS Date), N'', N'', N'L00005    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0019    ', N'Đặng Hữu', N'Thắng', N'Nam', CAST(0x111D0B00 AS Date), N'', N'', N'L00001    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0020    ', N'Nguyễn Thị', N'Thắm', N'Nữ', CAST(0x111D0B00 AS Date), N'', N'', N'L00002    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0021    ', N'Hà Xuân', N'Tùng', N'Nam', CAST(0x111D0B00 AS Date), N'', N'', N'L00003    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0023    ', N'Nguyễn Văn Tuấn', N'Anh', N'Nam', CAST(0x111D0B00 AS Date), N'', N'', N'L00002    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0024    ', N'Nguyễn Văn', N'Đại', N'Nam', CAST(0x111D0B00 AS Date), N'', N'', N'L00002    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0025    ', N'Lưu', N'Đức Anh', N'Nữ', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00001    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0026    ', N'Lưu Hoàng', N'Đạt', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00001    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0027    ', N'Nguyễn Văn', N'Ninh', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00001    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0028    ', N'Trần Thế', N'Duy', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00001    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0029    ', N'Diệp Lâm', N'Hiếu', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00001    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0030    ', N'Trần Văn', N'Nhân', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00001    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0031    ', N'Duy Văn', N'Bảnh', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00001    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0032    ', N'Hồ Sỹ', N'Việt', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00003    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0033    ', N'Nguyễn Thanh', N'Tùng', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00003    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0034    ', N'Lê Hải', N'Sơn', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00003    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0035    ', N'Nguyễn Thế', N'Công', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00003    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0037    ', N'Nguyễn Duy', N'Tùng Khánh', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00004    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0038    ', N'Phan Trọng', N'Duy', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00004    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0039    ', N'Lê Thanh', N'Tùng', N'Nam', CAST(0x0B1E0B00 AS Date), N'', N'', N'L00004    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0041    ', N'Vi Đình', N'Diệm', N'Nam', CAST(0xD11D0B00 AS Date), N'', N'', N'L00005    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0042    ', N'Nguyễn Quốc', N'Dũng', N'Nữ', CAST(0xD11D0B00 AS Date), N'', N'', N'L00005    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0043    ', N'Nguyễn Văn', N'Nhựt Trường', N'Nữ', CAST(0xD11D0B00 AS Date), N'', N'', N'L00005    ', CAST(0x02390B00 AS Date))
INSERT [dbo].[tblSinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [DiaChi], [NoiSinh], [MaLop], [NgayNhapHoc]) VALUES (N'SV0044    ', N'Phạm Quang', N'Hưng', N'Nam', CAST(0xD11D0B00 AS Date), N'', N'', N'L00006    ', CAST(0x02390B00 AS Date))
ALTER TABLE [dbo].[tblGiaoVien]  WITH CHECK ADD  CONSTRAINT [tblKhoa_tblGiaovien_fk] FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[tblKhoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[tblGiaoVien] CHECK CONSTRAINT [tblKhoa_tblGiaovien_fk]
GO
ALTER TABLE [dbo].[tblKetQua]  WITH CHECK ADD  CONSTRAINT [FK__tblKetQua__MaLHP__1EA48E88] FOREIGN KEY([MaLHP])
REFERENCES [dbo].[tblLopHocPhan] ([MaLHP])
GO
ALTER TABLE [dbo].[tblKetQua] CHECK CONSTRAINT [FK__tblKetQua__MaLHP__1EA48E88]
GO
ALTER TABLE [dbo].[tblKetQua]  WITH CHECK ADD  CONSTRAINT [FK__tblKetQua__MaSV__1DB06A4F] FOREIGN KEY([MaSV])
REFERENCES [dbo].[tblSinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[tblKetQua] CHECK CONSTRAINT [FK__tblKetQua__MaSV__1DB06A4F]
GO
ALTER TABLE [dbo].[tblLop]  WITH CHECK ADD  CONSTRAINT [tblKhoa_tblLop_fk] FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[tblKhoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[tblLop] CHECK CONSTRAINT [tblKhoa_tblLop_fk]
GO
ALTER TABLE [dbo].[tblLopHocPhan]  WITH CHECK ADD  CONSTRAINT [FK__tblLopHocP__MaGV__797309D9] FOREIGN KEY([MaGV])
REFERENCES [dbo].[tblGiaoVien] ([MaGV])
GO
ALTER TABLE [dbo].[tblLopHocPhan] CHECK CONSTRAINT [FK__tblLopHocP__MaGV__797309D9]
GO
ALTER TABLE [dbo].[tblLopHocPhan]  WITH CHECK ADD  CONSTRAINT [FK__tblLopHocP__MaMH__787EE5A0] FOREIGN KEY([MaMH])
REFERENCES [dbo].[tblMonHoc] ([MaMH])
GO
ALTER TABLE [dbo].[tblLopHocPhan] CHECK CONSTRAINT [FK__tblLopHocP__MaMH__787EE5A0]
GO
ALTER TABLE [dbo].[tblMonHoc]  WITH CHECK ADD  CONSTRAINT [FK__tblMonHoc__MaKho__6991A7CB] FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[tblKhoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[tblMonHoc] CHECK CONSTRAINT [FK__tblMonHoc__MaKho__6991A7CB]
GO
ALTER TABLE [dbo].[tblSinhVien]  WITH CHECK ADD  CONSTRAINT [tblLop_tblSinhVien_fk] FOREIGN KEY([MaLop])
REFERENCES [dbo].[tblLop] ([MaLop])
GO
ALTER TABLE [dbo].[tblSinhVien] CHECK CONSTRAINT [tblLop_tblSinhVien_fk]
GO
ALTER TABLE [dbo].[tblSinhVien]  WITH CHECK ADD  CONSTRAINT [CK__tblSinhVi__GioiT__108B795B] CHECK  (([GioiTinh]=N'Nữ' OR [GioiTinh]=N'Nam'))
GO
ALTER TABLE [dbo].[tblSinhVien] CHECK CONSTRAINT [CK__tblSinhVi__GioiT__108B795B]
GO
USE [master]
GO
ALTER DATABASE [SinhVien] SET  READ_WRITE 
GO
