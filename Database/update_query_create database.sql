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
   Bảng Hợp đồng - Contracts
=====================================================*/
CREATE TABLE contracts(
	id int identity (1,1) not null,
	contract_id varchar (10) not null constraint PK_contracts primary key,	-- mã hợp đồng
	contract_type nvarchar (200) not null,		-- loại hợp đồng
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
   Bảng Sơ yếu lí lịch nhân viên - Employee Records
=====================================================*/
CREATE TABLE employees_records(
	id int identity (1,1) not null,
	employee_record_id varchar (10) not null constraint PK_employees_records primary key,	-- mã sơ yếu lý lịch
	first_name nvarchar (20) not null,		-- tên nhan vien
	last_name nvarchar (20) not null,		-- họ và tên đệm
	gender nvarchar (10) not null,			-- giới tính
	birth_date date null,					-- ngày sinh DD/MM/YYYY
	birth_place nvarchar (200) null,		-- nơi sinh
	ethnicity nvarchar (20) null,			-- dân tộc
	religion nvarchar (50) NULL,            -- tôn giáo
	native_place nvarchar (200) null,		-- nguyên quán
	permanent_address nvarchar (300) null,  -- ĐC thường trú
	temporary_address nvarchar (300) NULL,	-- ĐC đang ở
	home_hone varchar (20) NULL,            -- số liên lạc nhà
	phone varchar (20) NULL,                -- Số liên lạc cá nhân
	dinh_muc tinyint null,					-- định mức
	citizen_id_number varchar (20) null,	-- CCCD/CMND
	citizen__id_issued_date date NULL,      -- ngày cấp
	citizen_id_issued_place nvarchar (200) NULL,   -- nơi cấp
	--passport
	created_date datetime2 (7) not null,
	updated_date datetime2 (7) not null,
	is_active  tinyint not null,				-- 1: đang hoạt động 0: ngừng hoạt động
);