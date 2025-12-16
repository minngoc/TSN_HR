/* =====================================================
   1. Bảng Sơ yếu lý lịch - employees_records
=====================================================*/
CREATE TABLE so_yeu_ly_lich (
    id INT IDENTITY(1,1) CONSTRAINT PK_so_yeu_ly_lich PRIMARY KEY,
    ma_so_yeu_ly_lich VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_so_yeu_ly_lich UNIQUE,
    ten_nv NVARCHAR(50) NOT NULL,
    ho_nv  NVARCHAR(50) NOT NULL,
    gioi_tinh NVARCHAR(10) NOT NULL,
    ngay_sinh DATE NULL,
    noi_sinh NVARCHAR(200) NULL,
    dan_toc NVARCHAR(50) NULL,
    ton_giao NVARCHAR(50) NULL,
    nguyen_quan NVARCHAR(200) NULL,
    thuong_tru NVARCHAR(300) NULL,
    dia_chi NVARCHAR(300) NULL,
    dien_thoai_home VARCHAR(20) NULL,
    dien_thoai VARCHAR(20) NULL,
    dinh_muc TINYINT NULL,
    so_cccd VARCHAR(20) NULL,
    ngay_cap DATE NULL,
    noi_cap NVARCHAR(200) NULL,
    passport NVARCHAR(20) NULL,
    chuyen_nganh NVARCHAR(100) NULL,
    trinh_do NVARCHAR(50) NULL,
    van_hoa NVARCHAR(50) NULL,
    ma_tai_khoan VARCHAR(50) NULL,
    card VARCHAR(30) NULL,
    ngan_hang NVARCHAR(100) NULL,
    thanh_phan_gd NVARCHAR(200) NULL,
    ma_trang_phuc NVARCHAR(10) NULL,
    ma_giay NVARCHAR(20) NULL,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);

/* =====================================================
   12. Bảng Thông tin bảo hiểm - insurance_info 
=====================================================*/
CREATE TABLE bao_hiem(
    id INT IDENTITY(1,1) CONSTRAINT PK_thong_tin_bao_hiem PRIMARY KEY,
    ma_kcb_cu  NVARCHAR(50) NULL,       -- mã khám chữa bệnh cũ
    ten_kcb_cu NVARCHAR(200) NULL,      -- tên khám chữa bệnh cũ
    ma_kcb_moi NVARCHAR(50) NULL,       -- mã khám chữa bệnh mới
    ten_kcb_moi NVARCHAR(200) NULL,     -- tên khám chữa bệnh mới
    so_bhxh NVARCHAR(20) NULL,          -- số BHXH
    so_ksk  NVARCHAR(20) NULL,          -- số khám sức khỏe
    so_bhyt NVARCHAR(20) NULL,          -- số BHYT
    ngay_bhtn DATE NULL,                -- ngày BHTN
    ngay_bhxh DATE NULL,                -- ngày BHXH
    thay_bhxh BIT NULL,                 -- đã thay đổi BHXH?
    so_the_cong_doan NVARCHAR(20) NULL,        -- số thẻ công đoàn
    ng_thu_viec DATE NULL,               -- ngày thử việc
    ng_vao_chinh_thuc DATE NULL,               -- ngày vào chính thức
    effective_from DATE NOT NULL,
    effective_to   DATE NULL,

    created_date DATETIME2(7) NOT NULL CONSTRAINT DF_thong_tin_bao_hiem_created DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL CONSTRAINT DF_thong_tin_bao_hiem_updated DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL CONSTRAINT DF_thong_tin_bao_hiem_is_active DEFAULT 1
);


/* =====================================================
   2. Bảng Nhân viên - nhan_vien
=====================================================*/
CREATE TABLE nhan_vien (
    id INT IDENTITY(1,1) CONSTRAINT PK_nhan_vien PRIMARY KEY,
    ma_nv VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_nhan_vien UNIQUE,
    ma_so_yeu_ly_lich INT NOT NULL,
    ma_thong_tin_bao_hiem INT not null,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);

ALTER TABLE nhan_vien ADD CONSTRAINT FK_nhan_vien_ma_so_yeu_ly_lich FOREIGN KEY (ma_so_yeu_ly_lich) REFERENCES so_yeu_ly_lich(id);
ALTER TABLE nhan_vien ADD CONSTRAINT FK_nhan_vien_ma_thong_tin_bao_hiem FOREIGN KEY (ma_thong_tin_bao_hiem) REFERENCES bao_hiem(id);


/* =====================================================
   3. Bảng cơ sở / cụm - co_so (MA_CUM)
=====================================================*/
CREATE TABLE co_so(
    id INT IDENTITY(1,1) CONSTRAINT PK_co_so PRIMARY KEY,
    ma_co_so VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_co_so UNIQUE,
    ten_co_so NVARCHAR(200) NOT NULL,
    dia_chi NVARCHAR(300) NULL,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);


/* =====================================================
   4. Bảng phòng ban / bộ phận - bo_phan
=====================================================*/
CREATE TABLE bo_phan(
    id INT IDENTITY(1,1) CONSTRAINT PK_bo_phan PRIMARY KEY,
    ma_bo_phan VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_bo_phan UNIQUE,
    ten_bo_phan NVARCHAR(200) NOT NULL,
    co_so_id INT NULL,      -- bộ phận thuộc cơ sở
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);

ALTER TABLE bo_phan ADD CONSTRAINT FK_bo_phan_co_so FOREIGN KEY (co_so_id) REFERENCES co_so(id);


/* =====================================================
   5. Bảng Nhân viên - Bộ phận (N-N) - nhan_vien_bo_phan
=====================================================*/
CREATE TABLE nhan_vien_bo_phan (
    id INT IDENTITY(1,1) CONSTRAINT PK_nhan_vien_bo_phan PRIMARY KEY,
    nhan_vien_id INT NOT NULL,
    bo_phan_id   INT NOT NULL,
    is_primary   BIT NOT NULL DEFAULT 0,
    ma_quan_ly   INT NOT NULL,
    effective_from DATE NOT NULL,
    effective_to   DATE NULL,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);

ALTER TABLE nhan_vien_bo_phan ADD CONSTRAINT FK_nhan_vien_bo_phan_nhan_vien FOREIGN KEY (nhan_vien_id) REFERENCES nhan_vien(id);
ALTER TABLE nhan_vien_bo_phan ADD CONSTRAINT FK_nhan_vien_bo_phan_bo_phan FOREIGN KEY (bo_phan_id) REFERENCES bo_phan(id);


/* =====================================================
   6. Bảng Loại viên chức
=====================================================*/
CREATE TABLE loai_vien_chuc(
    id INT IDENTITY(1,1) CONSTRAINT PK_loai_vien_chuc PRIMARY KEY,
    ma_loai_vien_chuc VARCHAR(10) NOT NULL CONSTRAINT UQ_loai_vien_chuc_ma UNIQUE,
    ten_loai_vien_chuc NVARCHAR(200) NOT NULL,
    quyet_dinh_xep_loai NVARCHAR(50) NULL,
    ngay_quyet_dinh_xep_loai DATE NULL,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);


/* =====================================================
   7. Bảng Ngạch công viên chức
=====================================================*/
CREATE TABLE ngach_cong_vien_chuc(
    id INT IDENTITY(1,1) CONSTRAINT PK_ngach_cong_vien_chuc PRIMARY KEY,
    ma_ngach VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_ngach UNIQUE,
    ten_ngach NVARCHAR(200) NOT NULL,
    chuyen_nganh NVARCHAR(200) NOT NULL,
    loai_vien_chuc_id INT NULL,
    quyet_dinh_ban_ngach NVARCHAR(100) NULL,
    ngay_ban_ngach DATE NULL,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);

ALTER TABLE ngach_cong_vien_chuc ADD CONSTRAINT FK_ngach_cong_vien_chuc_loai_vien_chuc FOREIGN KEY (loai_vien_chuc_id) REFERENCES loai_vien_chuc(id);



/* =====================================================
   8. Bảng Nghiệp vụ
=====================================================*/
CREATE TABLE nghiep_vu(
    id INT IDENTITY(1,1) CONSTRAINT PK_nghiep_vu PRIMARY KEY,
    ma_nghiep_vu VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_nghiep_vu UNIQUE,
    ten_nghiep_vu NVARCHAR(200) NOT NULL,
    loai_nghiep_vu NVARCHAR(200) NOT NULL,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);


/* =====================================================
   9. Bảng Mức lương (ngạch/bậc) - muc_luong
=====================================================*/
CREATE TABLE muc_luong(
    id INT IDENTITY(1,1) CONSTRAINT PK_muc_luong PRIMARY KEY,
    ma_muc_luong VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_muc_luong UNIQUE,
    ngach_vien_chuc_id INT NOT NULL,        -- FK sang ngach cong vien chuc
    bac_luong TINYINT NOT NULL,
    he_so_luong DECIMAL(5,2) NOT NULL,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);

ALTER TABLE muc_luong ADD CONSTRAINT FK_muc_luong_ngach_vien_chuc FOREIGN KEY (ngach_vien_chuc_id) REFERENCES ngach_cong_vien_chuc(id);



/* =====================================================
   10. Bảng loại phụ cấp - phu_cap
=====================================================*/
CREATE TABLE phu_cap(
    id INT IDENTITY(1,1) CONSTRAINT PK_phu_cap PRIMARY KEY,
    ma_phu_cap VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_phu_cap UNIQUE,
    ten_phu_cap NVARCHAR(200) NOT NULL,
    mo_ta NVARCHAR(500) NULL,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);



/* =====================================================
   11. Lương nhân viên - luong
=====================================================*/
CREATE TABLE luong(
    id INT IDENTITY(1,1) CONSTRAINT PK_luong PRIMARY KEY,
    ma_luong VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_luong UNIQUE,
    nhan_vien_id INT NOT NULL,          -- FK NV
    muc_luong_id INT NOT NULL,          -- FK mức lương (ngạch/bậc)
    ma_thue NVARCHAR(20) NULL,          -- MST nếu lưu theo hồ sơ lương
    gia_canh DECIMAL(18,2) NULL,        -- giảm trừ gia cảnh
    tru_khac DECIMAL(18,2) NULL,        -- giảm trừ khác
    nam_tham_nien DECIMAL(18,2) NULL,   -- năm thâm niên
    effective_from DATE NOT NULL,       -- ngày hiệu lực
    effective_to   DATE NULL,           -- ngày hết hiệu lực
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);

ALTER TABLE luong ADD CONSTRAINT FK_luong_nhan_vien FOREIGN KEY (nhan_vien_id) REFERENCES nhan_vien(id);
ALTER TABLE luong ADD CONSTRAINT FK_luong_muc_luong FOREIGN KEY (muc_luong_id) REFERENCES muc_luong(id);


/* =====================================================
   12. Bảng Phụ cấp theo nhân viên (N-N)
=====================================================*/
CREATE TABLE nhan_vien_phu_cap(
    id INT IDENTITY(1,1) CONSTRAINT PK_nhan_vien_phu_cap PRIMARY KEY,
    nhan_vien_id INT NOT NULL,
    phu_cap_id INT NOT NULL,
    effective_from DATE NOT NULL,
    effective_to   DATE NULL,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);

ALTER TABLE nhan_vien_phu_cap ADD CONSTRAINT FK_nhan_vien_phu_cap_nhan_vien FOREIGN KEY (nhan_vien_id) REFERENCES nhan_vien(id);
ALTER TABLE nhan_vien_phu_cap ADD CONSTRAINT FK_nhan_vien_phu_cap_phu_cap FOREIGN KEY (phu_cap_id) REFERENCES phu_cap(id);


/* =====================================================
   13. Bảng Loại hợp đồng - loai_hop_dong
=====================================================*/
CREATE TABLE loai_hop_dong(
    id INT IDENTITY(1,1) CONSTRAINT PK_loai_hop_dong PRIMARY KEY,
    ma_loai VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_loai_hop_dong UNIQUE,
    ten_loai NVARCHAR(200) NOT NULL,
    loai_hdld NVARCHAR(50) NULL,        -- 12 thang, 36 thang
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);


/* =====================================================
   14. Bảng Hợp đồng - hop_dong
=====================================================*/
CREATE TABLE hop_dong(
    id INT IDENTITY(1,1) CONSTRAINT PK_hop_dong PRIMARY KEY,
    so_hdld NVARCHAR(50) NOT NULL CONSTRAINT UQ_hop_dong_so UNIQUE, -- số hợp đồng
    nhan_vien_id INT NOT NULL,          -- FK NV
    loai_hop_dong_id INT NOT NULL,      -- FK loại HĐ
    SO_HDLD_L NVARCHAR(50) NULL,        -- số HĐ lần trước
    KY_HD_TU DATE NOT NULL,
    KY_HD_DEN DATE NULL,   
    SO_LAN TINYINT NULL,                 -- số lần tái ký
    ng_thoi_viec date null,             -- ngày thôi việc
    so_quyet_dinh_thoi_viec nvarchar(100) null,
    ly_do_nghi nvarchar(200) null,
    tien_tro_cap nvarchar(20) null,
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);

ALTER TABLE hop_dong ADD CONSTRAINT FK_hop_dong_nhan_vien FOREIGN KEY (nhan_vien_id) REFERENCES nhan_vien(id);
ALTER TABLE hop_dong ADD CONSTRAINT FK_hop_dong_loai_hop_dong FOREIGN KEY (loai_hop_dong_id) REFERENCES loai_hop_dong(id);


/* =====================================================
   16. Bảng chức vụ / bộ phận - chuc_vu
=====================================================*/
CREATE TABLE chuc_vu(
    id INT IDENTITY(1,1) CONSTRAINT PK_chuc_vu PRIMARY KEY,
    ma_chuc_vu VARCHAR(10) NOT NULL CONSTRAINT UQ_ma_chuc_vu UNIQUE,
    ten_chuc_vu NVARCHAR(200) NOT NULL,
    bo_phan_id INT NULL,      -- chức vụ trong bộ phận
    created_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_date DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    is_active BIT NOT NULL DEFAULT 1
);

ALTER TABLE chuc_vu ADD CONSTRAINT FK_chuc_vu_bo_phan FOREIGN KEY (bo_phan_id) REFERENCES bo_phan(id);

insert into co_so(ma_co_so, ten_co_so, dia_chi)
values ('CS00', N'Khách sạn Tân Sơn Nhất', N'202 Hoàng Văn Thụ, phường Đức Nhuận, TP Hồ Chí Minh');

insert into bo_phan (ma_bo_phan, ten_bo_phan, co_so_id)
values (N'M00',N'TCHCCT',1);

insert into chuc_vu (ma_chuc_vu, ten_chuc_vu, bo_phan_id)
values (N'GM1', N'Giam doc', 1);