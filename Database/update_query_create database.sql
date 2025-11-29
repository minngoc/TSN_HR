/* =====================================================
   Bảng cơ sở - Facility
=====================================================*/
CREATE TABLE facilities(
	id int identity (1,1) not null,
	facility_id varchar (10) not null constraint PK_facilities primary key,	--mã cơ sở
	facility_name nvarchar (200) not null,		-- tên cơ sở
	facility_address nvarchar (300) null,		-- địa chỉ cơ sở
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng phòng ban - Departments
=====================================================*/
CREATE TABLE departments(
	id int identity (1,1) not null,
	department_id varchar (10) not null constraint PK_departments primary key,	-- mã phòng ban
	department_name nvarchar (200) not null,		-- tên phòng ban
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng Loại hợp đồng - Contract type
=====================================================*/
CREATE TABLE contract_type(
	id int identity (1,1) not null,
	MA_LOAI varchar (10) not null constraint PK_contract_type primary key,	-- mã loại hợp đồng
	TEN_LOAI nvarchar (200) not null,	-- ten loai hop dong: KXD thoi han / XD thoi han / Thoi viec
	LOAI_HDLD nvarchar (20) null,		-- loại HDLD: 36 thang
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng Hợp đồng - Contracts
=====================================================*/
CREATE TABLE contracts(
	id int identity (1,1) not null,
	SO_HDLD varchar (10) not null constraint PK_contracts primary key,	-- mã hợp đồng
	employee_id varchar (10) not null,			-- mã nhân viên
	SO_HDLD_L nvarchar (20) null,				-- mã hợp đồng lần trước
	MA_LOAI nvarchar (200) not null,	-- mã loại hợp đồng
	KY_HD_TU datetime2 (7) not null,	-- ký HDLD từ
	KY_HD_DEN datetime2 (7) not null,	-- ký HĐLD đến
	SO_LAN tinyint null,						-- số lần ký HĐLĐ
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng loại viên chức
=====================================================*/
CREATE TABLE loai_vien_chuc(
	id int identity (1,1) not null,
	ma_loai_vien_chuc varchar (10) not null constraint PK_loai_vien_chuc primary key,	-- mã loại viên chức
	ten_loai_vien_chuc nvarchar (200) not null,				-- tên ngạch
	quyet_dinh_xep_loai nvarchar (20) not null,				-- quyết định xếp loại
	ngay_quyet_dinh_xep_loai datetime2 (7) not null,		-- ngay xep loai
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng ngạch viên chức
=====================================================*/
CREATE TABLE ngach_vien_chuc(
	id int identity (1,1) not null,
	ma_ngach varchar (10) not null constraint PK_ngach_vien_chuc primary key,	-- mã ngạch
	ten_ngach nvarchar (200) not null,				-- tên ngạch
	chuyen_nganh_vien_chuc nvarchar (200) not null,	-- chuyên ngành viên chức
	quyet_dinh_ban_ngach nvarchar (100) null,		-- quyết định ban ngạch
	ngay_ban_ngach datetime2 (7) not null,			-- ngày ban ngạch
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng nghĩa vụ
=====================================================*/
CREATE TABLE nghia_vu(
	id int identity (1,1) not null,
	ma_nghia_vu varchar (10) not null constraint PK_nghia_vu primary key,	-- mã nghĩa vụ
	ten_nghia_vu nvarchar (200) not null,			-- tên nghĩa vụ
	loai_nghia_vu nvarchar (200) not null,			-- loại nghĩa vụ
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng mức lương - salary range
=====================================================*/
CREATE TABLE salary_range(
	id int identity (1,1) not null,
	salary_range_id varchar (10) not null constraint PK_salary_range primary key,	-- mã mức lương
	salary_rank decimal (18,2) not null,			-- bậc lương
	chuyen_nganh_vien_chuc nvarchar (200) not null,	-- chuyên ngành viên chức
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng lương - salary
=====================================================*/
CREATE TABLE salary(
	id int identity (1,1) not null,
	salary_id varchar (10) not null constraint PK_salary primary key,	-- mã lương
	salary_range_id decimal (18,2) not null,			-- mã mức lương
	chuyen_nganh_vien_chuc nvarchar (200) not null,	-- chuyên ngành viên chức
	ma_so_thue nvarchar (10) null,			-- mã số thuế
	tien_tro_cap decimal (18,2) null,		-- tiền trợ cấp
	gia_canh decimal (18,2) null,			-- giảm trừ gia cảnh
	tru_khac decimal (18,2) null,			-- giảm trừ khác
	nam_tham_nien decimal (18,2) null,		-- năm thâm niên
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng phụ cấp - EmployeeSalary allowance
=====================================================*/
CREATE TABLE salary(
	id int identity (1,1) not null,
	salary_id varchar (10) not null constraint PK_salary primary key,	-- mã lương
	salary_range_id decimal (18,2) not null,			-- mã mức lương
	chuyen_nganh_vien_chuc nvarchar (200) not null,	-- chuyên ngành viên chức
	ma_so_thue nvarchar (10) null,			-- mã số thuế
	tien_tro_cap decimal (18,2) null,		-- tiền trợ cấp
	gia_canh decimal (18,2) null,			-- giảm trừ gia cảnh
	tru_khac decimal (18,2) null,			-- giảm trừ khác
	nam_tham_nien decimal (18,2) null,		-- năm thâm niên
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng Nhân viên - Employees
=====================================================*/
CREATE TABLE employees(
	id int identity (1,1) not null,
	employee_id varchar (10) not null constraint PK_employees primary key,	-- mã nhân viên
	contract_id nvarchar (200) not null,		-- mã hợp đồng
	employee_record_id varchar (10) not null,	-- mã sơ yếu lý lịch
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng thông tin bảo hiểm - Insurance infor
=====================================================*/
CREATE TABLE insurance_info(
	id int identity (1,1) not null,
	insurance_info_id varchar (10) not null constraint PK_insurance_info Primary key, -- mã thông tin bảo hiển
	MA_NV varchar (10) not null,			-- mã nhân viên
	ma_kham_chua_benh_cu nvarchar (200) not null,	-- mã khám chữa bệnh cũ
	ten_kham_chua_benh_cu nvarchar (200) not null,	-- tên khám chữa bệnh cũ
	ma_kham_chua_benh_moi nvarchar (200) not null,	-- mã khám chữa bệnh mới
	ten_kham_chua_benh_moi nvarchar (200) not null,	-- tên khám chữa bệnh mới
	so_BHXH nvarchar (20) null,					-- số BHXH
	so_KSK nvarchar (20) null,					-- số khám sức khỏe
	so_BHYT nvarchar (20) null,					-- số BHYT
	ngay_BHTN datetime2 (7) not null,			-- ngày BHTN
	thay_BHXH tinyint null,						-- đã thay đổi BHXH chưa
	so_the_cong_doan nvarchar (20) null,		-- số thẻ công đoàn
	NG_TH_VIEC datetime2 (7) null,				-- ngày thử việc
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);

/* =====================================================
   Bảng Sơ yếu lí lịch nhân viên - Employee Records
=====================================================*/
CREATE TABLE employees_records(
	id int identity (1,1) not null,
	employee_record_id varchar (10) not null constraint PK_employees_records primary key,	-- mã sơ yếu lý lịch
	TEN_NV nvarchar (20) not null,		-- tên nhan vien
	HO_NV nvarchar (20) not null,		-- họ và tên đệm
	PHAI nvarchar (10) not null,			-- giới tính
	NG_SINH date null,					-- ngày sinh DD/MM/YYYY
	NOI_SINH nvarchar (200) null,		-- nơi sinh
	DAN_TOC nvarchar (20) null,			-- dân tộc
	TON_GIAO nvarchar (50) NULL,            -- tôn giáo
	NG_QUAN nvarchar (200) null,		-- nguyên quán
	THUONG_TRU nvarchar (300) null,  -- ĐC thường trú
	DIA_CHI nvarchar (300) NULL,	-- ĐC đang ở
	D_THOAI_H varchar (20) NULL,            -- số liên lạc nhà
	D_THOAI varchar (20) NULL,                -- Số liên lạc cá nhân
	dinh_muc tinyint null,					-- định mức
	CMND varchar (20) null,	-- CCCD/CMND
	NG_CAP date NULL,      -- ngày cấp
	NOI_CAP nvarchar (200) NULL,   -- nơi cấp
	PASSPORT nvarchar (20) null,	-- passport
	CH_NGANH nvarchar (100) null,				-- chuyên ngành
	TR_DO nvarchar (20) null,		-- trình độ
	VAN_HOA nvarchar (20) null,	-- văn hóa 12/12
	MA_TK varchar (50) NULL,         -- mã ngân hàng
	CARD varchar (30) null, -- số thẻ ngân hàng
	NG_HANG nvarchar (100) NULL,          -- tên ngân hàng
	TP_GD nvarchar (200) null,		-- thành phần GD
	MA_TP nvarchar (10) null,		-- mã thành phần
	MA_GIAY nvarchar (20) null,		-- mã giày
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);