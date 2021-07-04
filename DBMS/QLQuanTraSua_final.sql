--Tạo database
CREATE DATABASE QLQuanTraSuaNEW
GO

USE QLQuanTraSuaNEW
GO

--Tạo bảng Quản lý
Create table dbo.QUANLY(
MaQL int primary key,
TenQL nvarchar(50) not NULL,
Email varchar(50) not NULL,
Tuoi int not NULL,
DiaChi nvarchar(100) not NULL,
SDT char(10) not NULL,
Luong int not NULL
)
GO

insert into QUANLY values(18110203,N'Huỳnh Nhựt Thiên','18110203@gmail.com',20,N'Quận Thủ Đức','0968892926',150000000)
insert into QUANLY values(18110205,N'Đinh Minh Thiện','18110205@gmail.com',20,N'Quận 9','0900000000',150000000)
GO

--Tạo bảng Chi Nhánh
Create table dbo.CHINHANH(
MaCN int primary key,
TenCN nvarchar(50) not NULL,
DiaChi nvarchar(100) not NULL,
SDT char(10) not NULL,
MaQL int references QUANLY(MaQL)
)
GO

insert into CHINHANH values(101,N'Milk Tea DoubleTee Cở Sở 1',N'Quận 1','0111222333',18110203)
insert into CHINHANH values(102,N'Milk Tea DoubleTee Cở Sở 2',N'Quận 2','0222111333',18110203)
insert into CHINHANH values(103,N'Milk Tea DoubleTee Cở Sở 3',N'Quận 3','0333222111',18110205)
GO

--Tạo bảng loại menu
Create table dbo.LOAIMENU(
MaLoai int primary key,
TenLoai nvarchar(100) not NULL
)
GO

insert into LOAIMENU values(1,N'Trà sữa')
insert into LOAIMENU values(2,N'Đá xay')
insert into LOAIMENU values(3,N'Topping')
GO

--Tạo bảng Menu
Create table dbo.MENU(
MaMon char(10) primary key,
MaLoai int references LOAIMENU(MaLoai),
TenMon nvarchar(100) not NULL,
Gia int not NULL,
SoLuongDaBan int not NULL default(0)
)
GO

insert into MENU values('TS01',1,N'Trà sữa Okinawa',35000,12)
insert into MENU values('TS02',1,N'Trà sữa Xoài',35000,5)
insert into MENU values('TS03',1,N'Trà sữa cà phê Okinawa',38000,9)
insert into MENU values('TS04',1,N'Trà sữa Okinawa (bọt sữa mịn)',38000,4)
insert into MENU values('TS05',1,N'Trà sữa Cà phê',35000,7)
insert into MENU values('TS06',1,N'Trà sữa Chocolate',38000,8)
insert into MENU values('TS07',1,N'Trà sữa Earl-Grey',38000,2)
insert into MENU values('TS08',1,N'Trà sữa Hokkaido',38000,16)
insert into MENU values('TS09',1,N'Trà sữa Khoai môn',35000,2)
insert into MENU values('TS10',1,N'Trà sữa Matcha đậu đỏ',38000,8)
insert into MENU values('TS11',1,N'Trà sữa Oolong',35000,3)
insert into MENU values('TS12',1,N'Trà sữa Oolong 3J',38000,2)
insert into MENU values('TS13',1,N'Trà sữa Pudding đậu đỏ',38000,7)
insert into MENU values('TS14',1,N'Trà sữa Sương Sáo',35000,6)
insert into MENU values('TS15',1,N'Trà sữa Trà đen',32000,5)
insert into MENU values('TS16',1,N'Trà sữa Trân châu đen',32000,18)
insert into MENU values('TS17',1,N'Trà sữa Trà xanh',32000,3)

insert into MENU values('DX01',2,N'Chocolate đá xay',30000,3)
insert into MENU values('DX02',2,N'Khoai môn đá xay',30000,2)
insert into MENU values('DX03',2,N'Matcha đá xay',30000,6)
insert into MENU values('DX04',2,N'Okinawa Oreo kem đá xay',32000,8)
insert into MENU values('DX05',2,N'Oreo Dâu đá xay',30000,3)
insert into MENU values('DX06',2,N'Xoài đá xay',30000,1)
insert into MENU values('DX07',2,N'Yakult đá xay',30000,2)

insert into MENU values('TP01',3,N'Combo 2 loại hạt',10000,3)
insert into MENU values('TP02',3,N'Combo 3 loại hạt',15000,6)
insert into MENU values('TP03',3,N'Đậu đỏ',10000,4)
insert into MENU values('TP04',3,N'Hạt é',10000,8)
insert into MENU values('TP05',3,N'Kem sữa',10000,9)
insert into MENU values('TP06',3,N'Nha đam',10000,3)
insert into MENU values('TP07',3,N'Sương sáo',10000,11)
insert into MENU values('TP08',3,N'Trân châu trắng vị dâu',10000,14)
insert into MENU values('TP09',3,N'Thạch Ai-yu',10000,5)
insert into MENU values('TP10',3,N'Thạch dừa',10000,9)
insert into MENU values('TP11',3,N'Thạch trái cây',10000,18)
insert into MENU values('TP12',3,N'Trân châu đen',10000,17)
insert into MENU values('TP13',3,N'Trân châu trắng',10000,10)
insert into MENU values('TP14',3,N'Pudding',15000,9)
GO

--Tạo bảng Nhân Viên
Create table dbo.NHANVIEN(
MaNV int primary key,
TenNV nvarchar(50) not NULL,
Email varchar(50) not NULL,
Tuoi int not NULL,
ChucVu nvarchar(20) NULL,
SDT char(10) not NULL,
DiaChi nvarchar(100) not NULL,
MaCN int references CHINHANH(MACN),
Luong int not NULL
)
GO

insert into NHANVIEN values(1001,N'Nguyễn Văn Chiến','chiennv@gmail.com',32,N'Pha Chế','0901010101',N'Quận 1',101,15000000)
insert into NHANVIEN values(1002,N'Đoàn Thị Mai Hương','huongdtm@gmail.com',31,N'Pha Chế','0902020202',N'Quận 2',102,12000000)
insert into NHANVIEN values(1003,N'Trần Hoàng Nhân','nhanth@gmail.com',35,N'Pha Chế','0903030303',N'Quận 3',103,12000000)
insert into NHANVIEN values(1004,N'Võ Hà Uyên Thư','thuvhu@gmail.com',25,N'Thu Ngân','0904040404',N'Quận 1',101,10000000)
insert into NHANVIEN values(1005,N'Võ Quang Tuấn','tuanvq@gmail.com',27,N'Thu Ngân','0905050505',N'Quận 2',102,10000000)
insert into NHANVIEN values(1006,N'Nguyễn Đức Chánh','chanhnd@gmail.com',20,N'Bảo vệ','0975724427',N'Quận 1',101,8000000)
insert into NHANVIEN values(1007,N'Hư Trúc','hut@gmail.com',25,N'Tạp Vụ','0907070707',N'Quận 3',103,7000000)
insert into NHANVIEN values(1008,N'Vương Ngữ Yên','yenvn@gmail.com',20,N'Tạp Vụ','0908080808',N'Quận 2',102,7000000)
insert into NHANVIEN values(1009,N'Đoàn Dự','doand@gmail.com',20,N'Tạp Vụ','0909090909',N'Quận 1',101,7000000)
insert into NHANVIEN values(1010,N'Mộ Dung Phục','phucmd@gmail.com',20,N'Tạp Vụ','0910101010',N'Quận 1',101,7000000)
insert into NHANVIEN values(1011,N'Tiêu Phong','tieup@gmail.com',27,N'Tạp Vụ','0901010111',N'Quận 2',102,7000000)
insert into NHANVIEN values(1012,N'Quách Tĩnh','tinhq@gmail.com',35,N'Part time','0901010112',N'Quận 2',102,7000000)
insert into NHANVIEN values(1013,N'Hoàng Dung','dungh@gmail.com',32,N'Part time','0901010113',N'Quận 1',101,7000000)
insert into NHANVIEN values(1014,N'Dương Quá','quad@gmail.com',20,N'Part time','0901010114',N'Quận 3',103,7000000)
GO

--Tạo bảng Phân Ca
Create table dbo.PHANCA(
MaNV int references NHANVIEN(MaNV),
MaCN int references CHINHANH(MaCN),
NgayLamViec datetime NULL,
GioLamViec int NULL,
primary key(MaNV, MaCN)
)
GO

--Tạo bảng khách hàng
Create table dbo.KHACHHANG(
MaKH int primary key,
TenKH nvarchar(50) not NULL,
Email varchar(50) not NULL,
Tuoi int NULL,
SDT char(10) NULL,
DiaChi nvarchar(100) NULL,
TongChiTieu int NULL default(0),
CapBac int NULL default(0),
)
GO

insert into KHACHHANG values(1, N'Tiểu Long Nữ', 'coco@gmail.com',20,'0912312312', N'Cổ Mộ, núi Toàn Chân', 2102000, 3)
insert into KHACHHANG values(2, N'Đoãn Chí Bình','yeumakhongdamnoi@gmail.com',22,'0912312333', N'Toàn Chân Giáo, núi Toàn Chân', 1560000, 2)
GO

--Tạo bảng Tài khoản
Create table dbo.TAIKHOANQL(
UserName varchar(50) not NULL,
Pass varchar(20) not null default(0),
MaQL int references QUANLY(MaQL),
primary key(MaQL)
)
GO

insert into TAIKHOANQL values('QL01','QuanLy123456789',18110203)
insert into TAIKHOANQL values('QL02','QuanLy123456789',18110205)
GO

Create table dbo.TAIKHOANKH(
UserName varchar(50) not NULL,
Pass varchar(20) not null default(0),
MaKH int references KHACHHANG(MaKH) not null,
primary key (MaKH)
)
GO

insert into TAIKHOANKH values('yeutrasua01','12345',1)
insert into TAIKHOANKH values('thichsuachua02','12345',2)
GO

Create table dbo.TAIKHOANNV(
UserName varchar(50) not NULL,
Pass varchar(20) not null default(0),
MaNV int references NHANVIEN(MaNV),
primary key(MaNV)
)
GO

insert into TAIKHOANNV values('NV01','NhanVien123456789',1001)
insert into TAIKHOANNV values('NV02','NhanVien123456789',1002)
GO

--Tạo bảng Hóa đơn
Create table dbo.HOADON(
MaHD int primary key,
MaKH int references KHACHHANG(MaKH),
MaCN int references CHINHANH(MaCN),
NgayXuatHD datetime not NULL,
TongGia int not NULL
)
GO

--Tạo bảng Chi Tiết Hóa Đơn
Create table dbo.CHITIETHD(
MaHD int references HOADON(MaHD),
MaMon char(10) references MENU(MaMon),
SoLuong int not null,
Gia int not NULL,
primary key(MaHD, MaMon)
)
GO



--------------Function--------------
--func tính tổng lương chi nhánh
Create function TongLuongCN (@MaCN int)
returns numeric(18,0)
as
begin
	declare @TongLuong numeric(18,0)
	select @TongLuong = Sum(Luong)
	from NHANVIEN
	where @MaCN = MaCN
	return @TongLuong
end
go
--test
select dbo.TongLuongCN(101)
select * from NHANVIEN

--func tính lương TB chi nhánh
Create function LuongTB_CN (@MaCN int)
returns numeric(18,0)
as
begin
	declare @LuongTB numeric(18,0)
	select @LuongTB = AVG(Luong)
	from NHANVIEN
	where @MaCN = MaCN
	return @LuongTB
end
--test
select dbo.LuongTB_CN(101)

--func tìm nhân viên theo mã chi nhánh
CREATE FUNCTION func_TimNV_ChiNhanh(@chinhanh int) 
RETURNS TABLE     
AS 
RETURN(SELECT MaNV,TenNV,Email ,Tuoi ,ChucVu ,NHANVIEN.SDT ,NHANVIEN.DiaChi ,NHANVIEN.MaCN ,Luong 
FROM NHANVIEN INNER JOIN CHINHANH
ON NHANVIEN.MaCN=CHINHANH.MaCN
WHERE CHINHANH.MaCN=@chinhanh
)

select * from dbo.func_TimNV_ChiNhanh(101)
select * from NHANVIEN




--Function tìm kiếm Khách Hàng theo TenKH
create function timkiemKH_TenKH(@TenKH nvarchar(50)) returns table
as
return (select *
		from KHACHHANG
		where KHACHHANG.TenKH like N'%'+@TenKH+'%')
go



--Function tìm kiếm Khách Hàng theo Email
create function timkiemKH_DiaChi(@Diachi varchar(50)) returns table
as
return (select *
		from KHACHHANG
		where KHACHHANG.DiaChi like N'%'+@Diachi+'%')
go


--select * from dbo.timkiemKH_TenKH(N'Nữ')

--Drop function timkiemKH_TenKH
--Drop function timKiemNV_func
--go


go


--Function top 5 món bán chạy nhất
create function top5Mon_func() returns table
as
return (SELECT Top(5) *
		FROM MENU
		ORDER BY SoLuongDaBan DESC)
go

SELECT * from dbo.top5Mon_func()



--Function top 5 khách hàng mua nhiều nhất

create function top5KH_func() returns table
as
return (SELECT Top(5) *
		FROM KHACHHANG
		ORDER BY TongChiTieu DESC)
go

SELECT * from top5KH_func()




--------------Trigger--------------
--trigger tăng lương người quản lý khi tăng lương nhân viên thuộc chi nhánh(+=50% lượng tiền được tăng của nhân viên)
Create trigger TangLuongQL on NHANVIEN
after update
as
declare @new int, @old int, @MaNV int
select @MaNV = ol.MaNV, @new = ne.Luong, @old = ol.Luong
from inserted as ne, deleted as ol
where ne.MaNV = ol.MaNV
if(@new > @old)
begin
	declare @MaQL int
	select @MaQL = CN.MaQL
	from CHINHANH as CN, NHANVIEN as NV
	where NV.MaCN = CN.MaCN and NV.MaNV = @MaNV

	update QUANLY set Luong = Luong + 0.5 * (@new - @old) where MaQL = @MaQL
end
go
--trigger tăng lương người quản lý khi có thêm nhân viên mới vào chi nhánh (+=10% lương của nhân viên mới)
Create trigger TangLuongQLnew on NHANVIEN
after insert
as
declare @new int, @MaNV int
select @MaNV = ne.MaNV, @new = ne.Luong
from inserted as ne
begin
	declare @MaQL int
	select @MaQL = CN.MaQL
	from CHINHANH as CN, NHANVIEN as NV
	where NV.MaCN = CN.MaCN and NV.MaNV = @MaNV

	update QUANLY set Luong = Luong + 0.1 * @new where MaQL = @MaQL
end
go

--Trigger tăng bậc cho khách hàng theo tổng chi tiêu
Create trigger TangBacKH on KHACHHANG
after update
as
declare @MaKH int, @newCT int, @oldCT int, @Capbac int
select @MaKH = ne.MaKH, @newCT = ne.TongChiTieu, @oldCT = ol.TongChiTieu, @Capbac = ol.CapBac
from inserted as ne, deleted as ol
where ne.MaKH = ol.MaKH
BEGIN
	declare @chenhlech int;
	set @chenhlech = @newCT - @oldCT
	if(@chenhlech > 0)
	begin
		declare @tang int
		set @tang = @chenhlech/500000
		set @Capbac = @Capbac + @tang
		update KHACHHANG set CapBac = @Capbac where MaKH = @MaKH
	end
END
go


--trigger bảng TAIKHOANQL
create trigger KiemtraTKQL on TAIKHOANQL
after insert
as
declare @newtk varchar(50), @maql int
select @newtk = UserName, @maql = MaQL
from inserted
begin
	declare @ma int
	set @ma = 0

	select @ma = MaKH
	from TAIKHOANKH
	where UserName = @newtk

	select @ma = MaNV
	from TAIKHOANNV
	where UserName = @newtk

	if(@ma != 0)
	begin
		delete from TAIKHOANQL where MaQL = @maql
		delete from QUANLY where MaQL = @maql
	end
end
go

--test
--select * from TAIKHOANQL
--select * from QUANLY

--insert into QUANLY values(123,N'noname','18110205@gmail.com',20,N'Quận 9','0900000000',150000000)
--insert into TAIKHOANQL values('thiendm','12345', 123)

--drop trigger KiemtraTKQL

--delete from TAIKHOANQL where MaQL = 123
--go
--

--trigger bảng TAIKHOANNV
create trigger KiemtraTKNV on TAIKHOANNV
after insert
as
declare @newtk varchar(50), @manv int
select @newtk = UserName, @manv = MaNV
from inserted
begin
	declare @ma int
	set @ma = 0

	select @ma = MaQL
	from TAIKHOANQL
	where UserName = @newtk

	select @ma = MaKH
	from TAIKHOANKH
	where UserName = @newtk

	if(@ma != 0)
	begin
		delete from TAIKHOANNV where MaNV = @manv
		delete from NHANVIEN where MaNV = @manv
	end
end
go

--trigger bảng TAIKHOANKH
create trigger KiemtraTKKH on TAIKHOANKH
after insert
as
declare @newtk varchar(50), @makh int
select @newtk = UserName, @makh = MaKH
from inserted
begin
	declare @ma int
	set @ma = 0

	select @ma = MaQL
	from TAIKHOANQL
	where UserName = @newtk

	select @ma = MaNV
	from TAIKHOANNV
	where UserName = @newtk

	if(@ma != 0)
	begin
		delete from TAIKHOANKH where MaKH = @makh
		delete from KHACHHANG where MaKH = @makh
	end
end
go

--để không trùng tài khoản trên cùng 1 bảng
--bảng TAIKHOANQL
ALTER TABLE TAIKHOANQL
ADD CONSTRAINT MyUniqueConstraint UNIQUE(UserName)
GO
--bảng TAIKHOANKH
ALTER TABLE TAIKHOANKH
ADD CONSTRAINT MyUniqueConstraintKH UNIQUE(UserName)
GO
--bảng TAIKHOANNV
ALTER TABLE TAIKHOANNV
ADD CONSTRAINT MyUniqueConstraintNV UNIQUE(UserName)
GO



--------------PROCEDURE-------------
CREATE PROCEDURE TimMonAn_Gia
@gia int
AS
BEGIN	
	SELECT * 
	from MENU
	where MENU.Gia <= @gia
END
go

--Exec TimMonAn_Gia 30000

CREATE PROCEDURE TimNV_Luong
@luong int
AS
BEGIN	
	SELECT * 
	from NHANVIEN
	where NHANVIEN.Luong <= @luong
END
go

--drop proc TimNV_Luong
--Exec TimNV_Luong 

CREATE PROCEDURE TimKH_TongChiTieu
@tongchitieu int
AS
BEGIN	
	SELECT * 
	from KHACHHANG
	where KHACHHANG.TongChiTieu <= @tongchitieu
END
go


--proc kết hợp transaction xóa quản lý
Create proc XoaQuanLy
@maql int
as
begin
	Set XACT_ABORT ON
	BEGIN TRANSACTION
		update CHINHANH set MaQL = NULL where MaQL = @maql
		delete from TAIKHOANQL where MaQL = @maql
		delete from QUANLY where MaQL = @maql
	COMMIT
end

--Procedure Thêm Khách Hàng
create procedure themKH_proc @makh int,@tenkh nvarchar(50),@email varchar(50),@tuoi int,@sdt char(10),@diachi nvarchar(50), @tongchitieu int, @capbac int
as
begin
	insert into KhachHang values(@makh,@tenkh,@email,@tuoi,@sdt,@diachi,@tongchitieu,@capbac)
end

--Procedure Thêm tài khoản Khách Hàng
create procedure themAKH_proc @taikhoan varchar(50),@matkhau varchar(20),@makh int
as
begin
	insert into TAIKHOANKH values(@taikhoan,@matkhau,@makh)
end


--view hiện Danh sách hóa đơn
CREATE VIEW DSHD
AS
SELECT *
FROM HOADON
go

--tạo view chi tiết hóa đơn
Create View CTHoaDon
as
select CT.MaHD as Ma_Hoa_Don, 
	   CT.MaMon as Ma_Mon, 
	   M.TenMon as Ten_Mon, 
	   CT.SoLuong as So_Luong, 
	   CT.Gia as Gia, 
	   HD.MaCN as Ma_Chi_Nhanh, 
	   HD.NgayXuatHD as Ngay_xuat_Hoa_don
from MENU as M, CHITIETHD as CT, HOADON as HD
where CT.MaMon = M.MaMon and CT.MaHD = HD.MaHD
go

--tạo proc xuất hóa đơn
Create proc XuatHoaDon 
@MaHD int
as
select * from CTHoaDon where Ma_Hoa_Don = @MaHD
go



--Exec themAKH_proc 'taikhoan','12345',6
--insert into TAIKHOANKH values('yeutrasua01','12345',1)
--Exec themKH_proc 3,N'Thiên','t@gmail.com',20,'0968892926',N'Đồng Tháp',0,0
--drop proc themKH_proc
--------------Phân Quyền--------------
--Tạo role quản lý
Create Role QuanLy
--Grant all to QuanLy with grant option
Grant select, alter, control, insert, delete, update on QUANLY to QuanLy with grant option
Grant select, alter, control, insert, delete, update on CHINHANH to QuanLy with grant option
Grant select, alter, control, insert, delete, update on NHANVIEN to QuanLy with grant option
Grant select, alter, control, insert, delete, update on KHACHHANG to QuanLy with grant option
Grant select, alter, control, insert, delete, update on MENU to QuanLy with grant option
Grant select, alter, control, insert, delete, update on HOADON to QuanLy with grant option
Grant select, alter, control, insert, delete, update on CHITIETHD to QuanLy with grant option
Grant select, alter, control, insert, delete, update on KHUYENMAI to QuanLy with grant option
Grant select, alter, control, insert, delete, update on LOAIMENU to QuanLy with grant option
Grant select, alter, control, insert, delete, update on TAIKHOANKH to QuanLy with grant option
Grant select, alter, control, insert, delete, update on TAIKHOANQL to QuanLy with grant option
Grant select, alter, control, insert, delete, update on TAIKHOANNV to QuanLy with grant option
Grant select, alter, control, insert, delete, update on PHANCA to QuanLy with grant option
Grant exec on dbo.XoaQuanLy to QuanLy with grant option					--trans/proc
Grant exec on dbo.TongLuongCN to QuanLy with grant option				--func
Grant exec on dbo.LuongTB_CN to QuanLy with grant option				--func

Grant select on dbo.top5KH_func to QuanLy with grant option				--func
Grant select on dbo.top5Mon_func to QuanLy with grant option			--func
Grant select on dbo.timkiemKH_TenKH to QuanLy with grant option			--func
Grant select on dbo.timkiemKH_DiaChi to QuanLy with grant option		--func
Grant select on dbo.func_TimNV_ChiNhanh to QuanLy with grant option		--func

Grant exec on dbo.TimKH_TongChiTieu to QuanLy with grant option			--proc
Grant exec on dbo.TimNV_Luong to QuanLy with grant option				--proc
Grant exec on dbo.TimMonAn_Gia to QuanLy with grant option				--proc

--cấp quyền - Quản Lý - view
Grant select, alter, control, insert, delete, update  on DSHD to QuanLy with grant option
Grant select, alter, control, insert, delete, update  on CTHoaDon to QuanLy with grant option
Grant exec on dbo.XuatHoaDon to QuanLy with grant option


go

--Tạo role nhân viên
Create Role NhanVien
--Grant all to NhanVien with grant option
Grant select, insert, delete, update on KHACHHANG to NhanVien with grant option
Grant select, insert, delete, update on HOADON to NhanVien with grant option
Grant select, insert, delete, update on CHITIETHD to NhanVien with grant option
Grant select, insert, delete, update on MENU to NhanVien with grant option
Grant select on NHANVIEN to NhanVien with grant option
Grant select on KHUYENMAI to NhanVien with grant option
Grant select on TAIKHOANNV to NhanVien with grant option
Grant select on TAIKHOANKH to NhanVien with grant option
Grant exec on dbo.TimKH_TongChiTieu to NhanVien with grant option			--proc
Grant exec on dbo.TimMonAn_Gia to NhanVien with grant option				--proc

--cấp quyền - NhanVien - view
Grant select, alter, control, insert, delete, update  on DSHD to NhanVien with grant option
Grant select, alter, control, insert, delete, update  on CTHoaDon to NhanVien with grant option
Grant exec on dbo.XuatHoaDon to NhanVien with grant option
go


--Tạo login cho Quản lý
Create Login QL01 with password= 'QuanLy123456789'
Create Login QL02 with password= 'QuanLy123456789'
--Tạo user cho Quản lý
Create User QL01 for Login QL01
Create User QL02 for Login QL02
--Thêm member vào role QuanLy
exec sp_addrolemember'QuanLy','QL01'
exec sp_addrolemember'QuanLy','QL02'
go

--Tạo login cho Nhân viên
Create Login NV01 with password= 'NhanVien123456789'
Create Login NV02 with password= 'NhanVien123456789'
--Tạo user cho Nhân viên
Create User NV01 for Login NV01
Create User NV02 for Login NV02
--Thêm member vào role NhanVien
exec sp_addrolemember'NhanVien','NV01'
exec sp_addrolemember'NhanVien','NV02'
go
