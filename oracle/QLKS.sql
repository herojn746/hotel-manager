use KhachSanTest;

create table TAIKHOAN(
    Ma_NV           varchar(20),
    Username        varchar(50)         unique not null,
    Password        varchar(50)         not null
);
alter table TAIKHOAN add constraint PR_KEY_TAIKHOAN primary key(Ma_NV);
    
    
    
create table NHANVIEN(
    Ma_NV           varchar2(20),
    Email           varchar2(50)        unique not null,
    SDT             varchar2(11)        unique not null,
    CMND            varchar2(12)        unique not null,
    HoTen           nvarchar2(50)       not null,
    NgaySinh        date                not null,
    ChucVu          nvarchar2(30)       not null
);
alter table NHANVIEN add constraint PR_KEY_NHANVIEN primary key(Ma_NV);



create table SDT_NV(
    Ma_NV           varchar(20),
    SDT             varchar(11)
);
alter table SDT_NV add constraint PR_KEY_SDT_NV primary key(Ma_NV, SDT);



create table ROOM(
    Ma_Phong        varchar2(20),
    Ten_Phong       nvarchar2(50)       not null,
    Gia             float               not null,
    Phi_Dat_Phong   float               not null,
    Tinh_Trang      number(1,0)         not null
);
alter table ROOM add constraint PR_KEY_ROOM primary key(Ma_Phong);



create table KHACHHANG(
    Ma_KH           varchar2(20),
    HoTen           nvarchar2(50)       not null,
    SDT             varchar2(11)        not null unique,
    CMND            varchar2(12)        not null unique,
    Gioi_Tinh       nvarchar2(3)        not null
);
alter table KHACHHANG add constraint PR_KEY_KHACHHANG primary key(Ma_KH);


create table SDT_KH(
    Ma_KH           varchar(20),
    SDT             varchar(11)
);
alter table SDT_KH add constraint PR_KEY_SDT_KH primary key(Ma_KH, SDT);


create table HOADON(
    Ma_HD           varchar2(20),
    Ma_KH           varchar2(20)        not null,
    Ma_NV           varchar2(20)        not null,
    SO_LUONG_PHONG  int                 not null,
    Ngay_Thanh_Toan date                null,
    TongTien        float               null,
    TinhTrang       number(1, 0)        not null
);
alter table HOADON add constraint PR_KEY_HOADON primary key(Ma_HD);



create table CT_HOADON(
    Ma_HD           varchar2(20),
    Ma_Phong        varchar2(20),
    Ngay_Dat_Coc    date                not null,
    Phi_Dat_Coc     float               not null,
    Giam_Gia        float               null,
    Check_In        date                not null,
    Check_Out       date                not null,
    ThanhTien       float               not null
);
alter table CT_HOADON add constraint PR_KEY_CT_HOADON primary key(Ma_HD, Ma_Phong);

--REFERENCES

alter table TAIKHOAN add constraint FK_TAIKHOAN_MA_NV foreign key(Ma_NV) references NHANVIEN(Ma_NV) on delete cascade;

alter table SDT_NV add constraint FK_SDT_MA_NV foreign key(Ma_NV) references NHANVIEN(Ma_NV) on delete cascade;

alter table CT_HOADON add constraint FK_CT_HOADON_Ma_HD foreign key(Ma_HD) references HOADON(Ma_HD) on delete cascade;
alter table CT_HOADON add constraint FK_CT_HOADON_Ma_Phong foreign key(Ma_Phong) references ROOM(Ma_Phong) on delete cascade;


alter table HOADON add constraint FK_HOADON_Ma_KH foreign key(Ma_KH) references KHACHHANG(Ma_KH) on delete cascade;
alter table HOADON add constraint FK_HOADDON_Ma_NV foreign key(Ma_NV) references NHANVIEN(Ma_NV) on delete cascade;

--INSERT FOR ROOM
insert into ROOM values('PH01',N'Phòng 1',500000,250000,0);
insert into ROOM values('PH02',N'Phòng 2',600000,300000,0);
insert into ROOM  values('PH03',N'Phòng 3',500000,250000,0);
insert into ROOM  values('PH04',N'Phòng 4',700000,350000,0);
insert into ROOM  values('PH05',N'Phòng 5',400000,200000,0);

--INSERT FOR NHANVIEN
insert into NHANVIEN values('NV01','minh@gmail.com','0987786545','079203307429',N'Ph?m Ng?c Minh',TO_DATE('2000/11/25', 'yyyy/mm/dd'),N'Nhân viên');
insert into NHANVIEN values('NV02','phong@gmail.com','0345485421','024206307429',N'Ph?m Phong',TO_DATE('1999/05/06', 'yyyy/mm/dd'),N'Nhân viên');
insert into NHANVIEN values('NV03','ngoc@gmail.com','0985556545','072203387429',N'Nguy?n Th? Ng?c',TO_DATE('1995/02/25', 'yyyy/mm/dd'),N'Qu?n lý');
insert into NHANVIEN values('NV04','tam@gmail.com','0344970661','072203384428',N'Bùi Minh Tâm',TO_DATE('2001/10/20', 'yyyy/mm/dd'),N'Nhân viên');
insert into NHANVIEN values('NV05','quynh@gmail.com','0822756548','020003807422',N'Phan M?nh Qu?nh ',TO_DATE('1997/07/15', 'yyyy/mm/dd'),N'Nhân viên');

--INSERT FOR SDT_NV
insert into SDT_NV values('NV01','0987786545');
insert into SDT_NV values('NV02','0345485421');
insert into SDT_NV values('NV03','0985556545');
insert into SDT_NV values('NV04','0344970661');
insert into SDT_NV values('NV05','0822756548');

--INSERT FOR KHACHHANG
insert into KHACHHANG values('KH01',N'Nguy?n Thanh Tùng','0821786336','022233356429',N'Nam');
insert into KHACHHANG values('KH02',N'Nguy?n Hoàng S?n','0123766111','098757156429',N'Nam');
insert into KHACHHANG values('KH03',N'Ph?m Th? H??ng','0397955155','042131432533',N'N?');
insert into KHACHHANG values('KH04',N'Tr?n Minh Th?','0868909532','023452345266',N'N?');
insert into KHACHHANG values('KH05',N'Ph?m V?n Hùng','0721114587','023140412352',N'Nam');

--INSERT FOR SDT KHACHHANG
insert into SDT_KH values('KH01','0821786336');
insert into SDT_KH values('KH02','0123766111');
insert into SDT_KH values('KH03','0397955155');
insert into SDT_KH values('KH04','0868909532');
insert into SDT_KH values('KH05','0721114587');

--INSERT FOR TAIKHOAN
insert into TAIKHOAN values('NV01','user1','123');
insert into TAIKHOAN values('NV02','user2','123');
insert into TAIKHOAN values('NV03','admin1','123');
insert into TAIKHOAN values('NV04','user3','123');
insert into TAIKHOAN values('NV05','user4','123');

--INSERT FOR HOADON
insert into HOADON values('HD01','KH01','NV01',1,TO_DATE('2023/02/25', 'yyyy/mm/dd'),500000,1);
insert into HOADON values('HD02','KH02','NV02',1,TO_DATE('2023/02/27', 'yyyy/mm/dd'),600000,1);

--INSERT FOR CT_HOADON
insert into CT_HOADON values('HD01','PH01',TO_DATE('2023/02/23', 'yyyy/mm/dd'),250000,0,TO_DATE('2023/02/24', 'yyyy/mm/dd'),TO_DATE('2023/02/25', 'yyyy/mm/dd'),250000);
insert into CT_HOADON values('HD02','PH02',TO_DATE('2023/02/20', 'yyyy/mm/dd'),300000,0,TO_DATE('2023/02/26', 'yyyy/mm/dd'),TO_DATE('2023/02/27', 'yyyy/mm/dd'),300000);


-----Index
--- truy van các phong theo tinh trang
CREATE INDEX room_index ON ROOM(Tinh_Tran);

---truy van thong tin nhan vien
CREATE INDEX tt_index ON NHANVIEN(HoTen,NgaySinh);

---Truy xuat hoa don 
CREATE INDEX hd_index ON HOADON(TinhTrang);

--truy xuat thông tin khách hàng theo tên
CREATE INDEX kh_index ON KHACHHANG(HoTen);



-- ========================================================= --

-- ROOM --

-- LOAD TABLE --
CREATE OR REPLACE FUNCTION display_room_info_func
RETURN SYS_REFCURSOR
AS
    table_cursor SYS_REFCURSOR;
BEGIN
    OPEN table_cursor 
    FOR
    SELECT * FROM ROOM;
    RETURN table_cursor;
END display_room_info_func;

-- THÊM PHÒNG MOI --

CREATE OR REPLACE PROCEDURE ADD_ROOM(   maPhong      in varchar, 
                                        tenPhong     in varchar2, 
                                        giaPhong     in float, 
                                        phiDatPhong  in float)
AS
BEGIN
    INSERT INTO ROOM
    VALUES(maPhong, tenPhong, giaPhong, phiDatPhong, 0);
    
    COMMIT;
    EXCEPTION
    WHEN OTHERS THEN
    ROLLBACK;
    RAISE;
END;
ALTER TABLE ROOM MODIFY Tinh_Trang NUMBER(1, 0) DEFAULT 0;

EXEC ADD_ROOM('PH09', N'Phòng 06', 20000, 20000);


-- XOA PHONG --

CREATE OR REPLACE PROCEDURE XOA_ROOM(maPhong in varchar)
AS 
BEGIN
    DELETE FROM ROOM WHERE Ma_Phong = maPhong;
    
    COMMIT;
    EXCEPTION
    WHEN OTHERS THEN
    ROLLBACK;
    RAISE;
END;

-- CAP NHAT PHONG

CREATE OR REPLACE PROCEDURE edit_room(
  p_ma_phong IN ROOM.Ma_Phong%TYPE,
  p_ten_phong IN ROOM.Ten_Phong%TYPE,
  p_gia IN ROOM.Gia%TYPE,
  p_phi_dat_phong IN ROOM.Phi_Dat_Phong%TYPE
) AS
BEGIN
  UPDATE ROOM SET
    Ten_Phong = p_ten_phong,
    Gia = p_gia,
    Phi_Dat_Phong = p_phi_dat_phong
  WHERE Ma_Phong = p_ma_phong;
  COMMIT; -- tùy ch?n: l?u các thay ??i trên b?ng ROOM 
EXCEPTION
  WHEN OTHERS THEN
    ROLLBACK;
    RAISE;
END;



-- ========================================================= --


-- LOGIN HANDLE --


--Check username and password NHANVIEN
 SET SERVEROUTPUT ON;
CREATE OR REPLACE PROCEDURE check_account(
    p_username IN VARCHAR2,
    p_password IN VARCHAR2,
    p_result OUT INT
)
AS
    v_count INT;
BEGIN
    SELECT COUNT(*) INTO v_count FROM TAIKHOAN WHERE Username = p_username AND Password = p_password;
    IF v_count > 0 THEN
        p_result := 1;
    ELSE
        p_result := 0;
    END IF;
END;
-----Call
DECLARE
amount INT;
BEGIN
check_account('user1','123', amount);
dbms_output.put_line(amount);
END;




-----Return name NHANVIEN
CREATE OR REPLACE PROCEDURE get_nhanvien_name (
    p_nhanvien_id IN VARCHAR2,
    p_nhanvien_name OUT NVARCHAR2
)
AS
BEGIN
    SELECT HOTEN INTO p_nhanvien_name FROM NHANVIEN,TAIKHOAN WHERE NHANVIEN.MA_NV=TAIKHOAN.MA_NV AND USERNAME = p_nhanvien_id;
END;
----Call procedure 
DECLARE
    v_nhanvien_name NVARCHAR2(50);
BEGIN
    get_nhanvien_name('user1', v_nhanvien_name);
    DBMS_OUTPUT.put_line(v_nhanvien_name);
END;



-- ========================================================= --

-- KHACH HANG --

-- LOAD TABLE --
CREATE OR REPLACE FUNCTION get_table_KhachHang_func
RETURN SYS_REFCURSOR
AS
    table_cursor SYS_REFCURSOR;
BEGIN
    OPEN table_cursor 
    FOR
    SELECT * FROM KHACHHANG;
    RETURN table_cursor;
END get_table_KhachHang_func;


 -- Them KHACH HANG --
CREATE OR REPLACE PROCEDURE add_KhachHang(  maKH in varchar2, 
                                            tenKH in nvarchar2,     
                                            sdt in varchar2, 
                                            cmnd in varchar2, 
                                            gioiTinh nvarchar2, 
                                            result out int)
AS
BEGIN
    INSERT INTO KHACHHANG VALUES(maKH, tenKH, sdt, cmnd, gioiTinh);
    SELECT count(*) INTO result FROM KHACHHANG WHERE Ma_KH = maKH;
END;


-- CAP NHAT KHAC HANG --
CREATE OR REPLACE PROCEDURE UPDATE_KHACHHANG (
  i_Ma_KH IN VARCHAR2,
  i_HoTen IN NVARCHAR2,
  i_SDT IN VARCHAR2,
  i_CMND IN VARCHAR2,
  i_Gioi_Tinh IN NVARCHAR2
)
IS
BEGIN
  UPDATE KHACHHANG
  SET HoTen = i_HoTen,
      SDT = i_SDT,
      CMND = i_CMND,
      Gioi_Tinh = i_Gioi_Tinh
  WHERE Ma_KH = i_Ma_KH;
  COMMIT;
END;

BEGIN
  UPDATE_KHACHHANG('KH05', N'Nguy?n V?n A', '0123456789', '123456789012', 'Nam');
END;

-- XOA KHACH HANG --
CREATE OR REPLACE PROCEDURE DELETE_KHACHHANG (
  i_Ma_KH IN VARCHAR2
)
IS
BEGIN
  DELETE FROM KHACHHANG
  WHERE Ma_KH = i_Ma_KH;
  COMMIT;
END;


-- ========================================================= --

-- NHAN VIEN --

-- LOAD TABLE --
CREATE OR REPLACE FUNCTION display_NhanVien_info_func
RETURN SYS_REFCURSOR
AS
    table_cursor SYS_REFCURSOR;
BEGIN
    OPEN table_cursor 
    FOR
    SELECT * FROM NHANVIEN;
    RETURN table_cursor;
END display_NhanVien_info_func;


 -- THEM NHAN VIEN --

CREATE OR REPLACE PROCEDURE them_nhanvien (
    MA_NV IN VARCHAR2,
    EMAIL IN VARCHAR2,
    SDT IN VARCHAR2,
    CMND IN VARCHAR2,
    HOTEN IN NVARCHAR2,
    NGAYSINH IN DATE,
    CHUCVU IN NVARCHAR2
)
AS
BEGIN
    INSERT INTO nhanvien (MA_NV, EMAIL, SDT, CMND, HOTEN, NGAYSINH, CHUCVU)
    VALUES (MA_NV, EMAIL, SDT, CMND, HOTEN, NGAYSINH, CHUCVU);
    COMMIT;
END;

   exec them_nhanvien('NV06', 'nv1@gami.com', '0123456789', '123456789', N'Nguyen Van A', TO_DATE('2001/07/25', 'yyyy/mm/dd'), N'Nhan vien');

select * from nhanvien;



-- XOA NHAN VIEN --
CREATE OR REPLACE PROCEDURE xoa_nhanvien (
    p_Ma_NV IN VARCHAR2
)
AS
BEGIN
    DELETE FROM NHANVIEN WHERE Ma_NV = p_Ma_NV;
    COMMIT;
END;

---thuc thi procedure xoa nhanvien
 exec  xoa_nhanvien('NV06');
 
 select * from nhanvien;
 
 -- UPDATE NHAN VIEN --
CREATE OR REPLACE PROCEDURE sua_nhanvien (
    p_Ma_NV IN VARCHAR2,
    p_Email IN VARCHAR2,
    p_SDT IN VARCHAR2,
    p_CMND IN VARCHAR2,
    p_HoTen IN NVARCHAR2,
    p_NgaySinh IN DATE,
    p_ChucVu IN NVARCHAR2
)
AS
BEGIN
    UPDATE NHANVIEN
    SET Email = p_Email,
        SDT = p_SDT,
        CMND = p_CMND,
        HoTen = p_HoTen,
        NgaySinh = p_NgaySinh,
        ChucVu = p_ChucVu
    WHERE Ma_NV = p_Ma_NV;
    COMMIT;
END;


----TIM KIEM NHAN VIEN THEO MA
CREATE OR REPLACE PROCEDURE search_employee_by_id(
    p_employee_id NVARCHAR2,
    p_refcursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_refcursor FOR 
        SELECT *
        FROM NhanVien
        WHERE Ma_NV = p_employee_id;
END;


-- SECURITY --

CREATE OR REPLACE FUNCTION deny_room_access_func (
   schema_name VARCHAR2,
   table_name VARCHAR2
) RETURN VARCHAR2 
IS
   v_policy VARCHAR2 (100) := '1=2'; 
BEGIN
   IF (table_name = 'ROOM') THEN
      v_policy := '1=2'; -- không cho phép truy c?p
   END IF;
   RETURN v_policy;
END deny_room_access_func;


BEGIN
   DBMS_RLS.ADD_POLICY (
      object_schema   => 'HUUNAM66TEST',
      object_name     => 'ROOM',
      policy_name     => 'deny_room_access_policy',
      function_schema => 'HUUNAM66TEST',  -- Tên schema ch?a hàm ki?m tra chính sách
      policy_function => 'deny_room_access_func',
      statement_types => 'SELECT, INSERT, UPDATE, DELETE',
      update_check    => true,
      enable          => TRUE);
END;

BEGIN
DBMS_RLS.DROP_POLICY('HUUNAM66TEST', 'ROOM', 'deny_room_access_policy');
END;
SELECT * FROM ROOM;

