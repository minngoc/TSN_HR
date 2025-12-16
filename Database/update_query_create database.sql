/* ============================================================
   1. Bảng Sơ yếu lý lịch
   ============================================================ */
CREATE TABLE so_yeu_ly_lich (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_so_yeu_ly_lich PRIMARY KEY,

    ma_so_yeu_ly_lich NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_so_yeu_ly_lich UNIQUE,

    ten_nv NVARCHAR(50) NOT NULL,
    ho_nv NVARCHAR(50) NOT NULL,
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
    hoc_van NVARCHAR(50) NULL,

    ma_tai_khoan VARCHAR(50) NULL,
    ngan_hang NVARCHAR(100) NULL,
    ma_so_thue VARCHAR(50) NULL,

    thanh_phan_gd NVARCHAR(100) NULL,
    ma_trang_phuc NVARCHAR(50) NULL,
    ma_giay NVARCHAR(50) NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL
);

/* ============================================================
   2. Bảng Bảo hiểm
   ============================================================ */
CREATE TABLE bao_hiem (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_bao_hiem PRIMARY KEY,

    ma_kcb_cu NVARCHAR(50) NULL,
    ten_kcb_cu NVARCHAR(200) NULL,

    ma_kcb_moi NVARCHAR(50) NULL,
    ten_kcb_moi NVARCHAR(200) NULL,

    so_bhxh VARCHAR(50) NULL,
    so_ksk VARCHAR(50) NULL,
    so_bhyt VARCHAR(50) NULL,

    ngay_bhtn DATE NULL,
    ngay_bhxh DATE NULL,

    thay_bhxh BIT NULL,
    so_the_cong_doan VARCHAR(50) NULL,

    ng_thu_viec DATE NULL,
    ng_vao_chinh_thuc DATE NULL,

    effective_from DATE NOT NULL,
    effective_to DATE NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL
);

/* ============================================================
   3. Bảng Bộ phận
   ============================================================ */
CREATE TABLE bo_phan (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_bo_phan PRIMARY KEY,

    ma_bo_phan NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_bo_phan UNIQUE,

    ten_bo_phan NVARCHAR(200) NOT NULL,

    co_so_id INT NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL
);
/* ============================================================
   4. Bảng Nhân viên
   ============================================================ */
CREATE TABLE nhan_vien (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_nhan_vien PRIMARY KEY,

    ma_nv NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_nhan_vien UNIQUE,

    ma_so_yeu_ly_lich INT NOT NULL,
    ma_thong_tin_bao_hiem INT NOT NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL,

    CONSTRAINT FK_nhan_vien_so_yeu_ly_lich
        FOREIGN KEY (ma_so_yeu_ly_lich)
        REFERENCES so_yeu_ly_lich(id),

    CONSTRAINT FK_nhan_vien_bao_hiem
        FOREIGN KEY (ma_thong_tin_bao_hiem)
        REFERENCES bao_hiem(id)
);
/* ============================================================
   5. Bảng Cơ sở
   ============================================================ */
CREATE TABLE co_so (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_co_so PRIMARY KEY,

    ma_co_so NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_co_so UNIQUE,

    ten_co_so NVARCHAR(200) NOT NULL,
    dia_chi NVARCHAR(300) NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL
);
/* ============================================================
   6. Bảng Chức vụ
   ============================================================ */
CREATE TABLE chuc_vu (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_chuc_vu PRIMARY KEY,

    ma_chuc_vu NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_chuc_vu UNIQUE,

    ten_chuc_vu NVARCHAR(200) NOT NULL,

    bo_phan_id INT NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL,

    CONSTRAINT FK_chuc_vu_bo_phan
        FOREIGN KEY (bo_phan_id)
        REFERENCES bo_phan(id)
);
/* ============================================================
   7. Bảng Loại hợp đồng
   ============================================================ */
CREATE TABLE loai_hop_dong (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_loai_hop_dong PRIMARY KEY,

    ma_loai NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_loai_hop_dong UNIQUE,

    ten_loai NVARCHAR(200) NOT NULL,
    loai_hdld NVARCHAR(100) NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL
);
/* ============================================================
   8. Bảng Hợp đồng
   ============================================================ */
CREATE TABLE hop_dong (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_hop_dong PRIMARY KEY,

    so_hdld NVARCHAR(50) NOT NULL
        CONSTRAINT UQ_hop_dong UNIQUE,

    nhan_vien_id INT NOT NULL,
    loai_hop_dong_id INT NOT NULL,

    so_hdld_l NVARCHAR(50) NULL,

    ky_hd_tu DATE NOT NULL,
    ky_hd_den DATE NULL,

    so_lan TINYINT NULL,

    ng_thoi_viec DATE NULL,
    so_quyet_dinh_thoi_viec NVARCHAR(50) NULL,
    ly_do_nghi NVARCHAR(300) NULL,

    tien_tro_cap NVARCHAR(50) NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL,

    CONSTRAINT FK_hop_dong_nhan_vien
        FOREIGN KEY (nhan_vien_id)
        REFERENCES nhan_vien(id),

    CONSTRAINT FK_hop_dong_loai_hop_dong
        FOREIGN KEY (loai_hop_dong_id)
        REFERENCES loai_hop_dong(id)
);
/* ============================================================
   9. Bảng Loại viên chức
   ============================================================ */
CREATE TABLE loai_vien_chuc (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_loai_vien_chuc PRIMARY KEY,

    ma_loai_vien_chuc NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_loai_vien_chuc UNIQUE,

    ten_loai_vien_chuc NVARCHAR(200) NOT NULL,

    quyet_dinh_xep_loai NVARCHAR(50) NULL,
    ngay_quyet_dinh_xep_loai DATE NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL
);
/* ============================================================
   10. Bảng Ngạch công viên chức
   ============================================================ */
CREATE TABLE ngach_cong_vien_chuc (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_ngach_cong_vien_chuc PRIMARY KEY,

    ma_ngach NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_ngach_cong_vien_chuc UNIQUE,

    ten_ngach NVARCHAR(200) NOT NULL,
    chuyen_nganh NVARCHAR(200) NOT NULL,

    loai_vien_chuc_id INT NULL,

    quyet_dinh_ban_ngach NVARCHAR(50) NULL,
    ngay_ban_ngach DATE NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL,

    CONSTRAINT FK_ngach_cong_vien_chuc_loai_vien_chuc
        FOREIGN KEY (loai_vien_chuc_id)
        REFERENCES loai_vien_chuc(id)
);
/* ============================================================
   11. Bảng Mức lương
   ============================================================ */
CREATE TABLE muc_luong (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_muc_luong PRIMARY KEY,

    ma_muc_luong NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_muc_luong UNIQUE,

    ngach_vien_chuc_id INT NOT NULL,

    bac_luong TINYINT NOT NULL,
    he_so_luong DECIMAL(10,2) NOT NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL,

    CONSTRAINT FK_muc_luong_ngach_cong_vien_chuc
        FOREIGN KEY (ngach_vien_chuc_id)
        REFERENCES ngach_cong_vien_chuc(id)
);
/* ============================================================
   12. Bảng Lương
   ============================================================ */
CREATE TABLE luong (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_luong PRIMARY KEY,

    ma_luong NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_luong UNIQUE,

    nhan_vien_id INT NOT NULL,
    muc_luong_id INT NOT NULL,

    ma_thue NVARCHAR(50) NULL,

    gia_canh DECIMAL(18,2) NULL,
    tru_khac DECIMAL(18,2) NULL,
    nam_tham_nien DECIMAL(18,2) NULL,

    effective_from DATE NOT NULL,
    effective_to DATE NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL,

    CONSTRAINT FK_luong_nhan_vien
        FOREIGN KEY (nhan_vien_id)
        REFERENCES nhan_vien(id),

    CONSTRAINT FK_luong_muc_luong
        FOREIGN KEY (muc_luong_id)
        REFERENCES muc_luong(id)
);
/* ============================================================
   13. Bảng Nghiệp vụ
   ============================================================ */
CREATE TABLE nghiep_vu (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_nghiep_vu PRIMARY KEY,

    ma_nghiep_vu NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_nghiep_vu UNIQUE,

    ten_nghiep_vu NVARCHAR(200) NOT NULL,
    loai_nghiep_vu NVARCHAR(100) NOT NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL
);
/* ============================================================
   14. Bảng Nhân viên - Bộ phận
   ============================================================ */
CREATE TABLE nhan_vien_bo_phan (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_nhan_vien_bo_phan PRIMARY KEY,

    nhan_vien_id INT NOT NULL,
    bo_phan_id INT NOT NULL,

    is_primary BIT NOT NULL,
    ma_quan_ly INT NOT NULL,

    effective_from DATE NOT NULL,
    effective_to DATE NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL,

    CONSTRAINT FK_nhan_vien_bo_phan_nhan_vien
        FOREIGN KEY (nhan_vien_id)
        REFERENCES nhan_vien(id),

    CONSTRAINT FK_nhan_vien_bo_phan_bo_phan
        FOREIGN KEY (bo_phan_id)
        REFERENCES bo_phan(id)
);
/* ============================================================
   15. Bảng Phụ cấp
   ============================================================ */
CREATE TABLE phu_cap (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_phu_cap PRIMARY KEY,

    ma_phu_cap NVARCHAR(20) NOT NULL
        CONSTRAINT UQ_phu_cap UNIQUE,

    ten_phu_cap NVARCHAR(200) NOT NULL,
    mo_ta NVARCHAR(300) NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL
);
/* ============================================================
   16. Bảng Nhân viên - Phụ cấp
   ============================================================ */
CREATE TABLE nhan_vien_phu_cap (
    id INT IDENTITY(1,1)
        CONSTRAINT PK_nhan_vien_phu_cap PRIMARY KEY,

    nhan_vien_id INT NOT NULL,
    phu_cap_id INT NOT NULL,

    effective_from DATE NOT NULL,
    effective_to DATE NULL,

    created_date DATETIME NOT NULL,
    updated_date DATETIME NOT NULL,
    is_active BIT NOT NULL,

    CONSTRAINT FK_nhan_vien_phu_cap_nhan_vien
        FOREIGN KEY (nhan_vien_id)
        REFERENCES nhan_vien(id),

    CONSTRAINT FK_nhan_vien_phu_cap_phu_cap
        FOREIGN KEY (phu_cap_id)
        REFERENCES phu_cap(id)
);

insert into co_so(ma_co_so, ten_co_so, dia_chi)
values ('CS00', N'Khách sạn Tân Sơn Nhất', N'202 Hoàng Văn Thụ, phường Đức Nhuận, TP Hồ Chí Minh');

insert into bo_phan (ma_bo_phan, ten_bo_phan, co_so_id)
values (N'M00',N'TCHCCT',1);

insert into chuc_vu (ma_chuc_vu, ten_chuc_vu, bo_phan_id)
values (N'GM1', N'Giam doc', 1);