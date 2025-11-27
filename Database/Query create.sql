CREATE TABLE dbo.Branches (
    BranchID    INT IDENTITY(1,1) PRIMARY KEY,
    BranchCode  VARCHAR(20)  NOT NULL UNIQUE,      -- VD: TSN
    BranchName  NVARCHAR(200) NOT NULL,           
    Address     NVARCHAR(300) NULL,
    IsActive    BIT NOT NULL DEFAULT 1,           -- 1: còn dùng, 0: ngưng
    CreatedAt   DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE dbo.Employees (
    EmployeeID          INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeCode        VARCHAR(20)   NOT NULL UNIQUE,  -- Mã NV: 000123
    FirstName           NVARCHAR(50) NOT NULL,          -- Tên
    LastName            NVARCHAR(50) NOT NULL,          -- Họ + tên lót
    FullName            AS (LastName + N' ' + FirstName) PERSISTED,

    Gender              NVARCHAR(10) NULL,              -- Nam/Nữ
    BirthDate           DATE NULL,
    BirthPlace          NVARCHAR(100) NULL,             -- Nơi sinh
    NativePlace         NVARCHAR(200) NULL,             -- Nguyên quán

    Nation              NVARCHAR(50) NULL,              -- Dân tộc
    Religion            NVARCHAR(50) NULL,              -- Tôn giáo

    IDNumber            VARCHAR(20)  NULL,              -- CMND/CCCD
    IDIssuedDate        DATE NULL,
    IDIssuedPlace       NVARCHAR(100) NULL,

    PermanentAddress    NVARCHAR(300) NULL,             -- Thường trú
    TemporaryAddress    NVARCHAR(300) NULL,             -- Tạm trú

    Phone               VARCHAR(20)  NULL,
    Email               VARCHAR(100) NULL,

    TaxCode             VARCHAR(50)  NULL,              -- Mã số thuế
    BankAccount         VARCHAR(50)  NULL,
    BankName            NVARCHAR(100) NULL,

    BranchID            INT NULL,
    DepartmentID        INT NULL,
    PositionID          INT NULL,

    StartDate           DATE NULL,                      -- Ngày vào làm
    Status              TINYINT NOT NULL DEFAULT 1,     -- 1: đang làm, 0: nghỉ, 2: thử việc

    CreatedAt           DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt           DATETIME2 NULL
);

CREATE TABLE dbo.Contracts (
    ContractID      INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID      INT NOT NULL,
    ContractNo      NVARCHAR(50) NULL,          
    ContractType    NVARCHAR(50) NULL,          -- Thử việc / XĐTH / KXĐTH...
    StartDate       DATE NOT NULL,
    EndDate         DATE NULL,
    SignedDate      DATE NULL,
    Notes           NVARCHAR(500) NULL,
    IsCurrent       BIT NOT NULL DEFAULT 1,     -- 1: HĐ hiện tại
    CreatedAt       DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE dbo.Departments (
    DepartmentID    INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentCode  VARCHAR(20)   NOT NULL UNIQUE,    
    DepartmentName  NVARCHAR(200) NOT NULL,
    BranchID        INT NULL,                         
    IsActive        BIT NOT NULL DEFAULT 1,
    CreatedAt       DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE dbo.Positions (
    PositionID    INT IDENTITY(1,1) PRIMARY KEY,
    PositionCode  VARCHAR(20)   NOT NULL UNIQUE,   
    PositionName  NVARCHAR(200) NOT NULL,          
    IsActive      BIT NOT NULL DEFAULT 1,
    CreatedAt     DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

--Foreign Key

ALTER TABLE dbo.Employees
ADD CONSTRAINT FK_Employees_Departments
    FOREIGN KEY (DepartmentID) REFERENCES dbo.Departments(DepartmentID);

ALTER TABLE dbo.Employees
ADD CONSTRAINT FK_Employees_Branches
    FOREIGN KEY (BranchID) REFERENCES dbo.Branches(BranchID);

ALTER TABLE dbo.Employees
ADD CONSTRAINT FK_Employees_Positions
    FOREIGN KEY (PositionID) REFERENCES dbo.Positions(PositionID);

ALTER TABLE dbo.Departments
ADD CONSTRAINT FK_Departments_Branches
    FOREIGN KEY (BranchID) REFERENCES dbo.Branches(BranchID);

ALTER TABLE dbo.Contracts
ADD CONSTRAINT FK_Contracts_Employees
    FOREIGN KEY (EmployeeID) REFERENCES dbo.Employees(EmployeeID);

