USE techzone_db;
-- identity (la usadas, se debe usar migración. Estan tablas son para fines de información)
CREATE TABLE `aspnetroles` (
  `Id` binary(16) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `aspnetusers` (
  `Id` binary(16) NOT NULL,
  `Name` longtext NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `UpdatedAt` datetime(6) DEFAULT NULL,
  `LastAccessAt` datetime(6) DEFAULT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

CREATE TABLE `aspnetuserroles` (
  `UserId` binary(16) NOT NULL,
  `RoleId` binary(16) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_uca1400_ai_ci;

-- Entidades Fuertes
DELIMITER //
CREATE TABLE Categories (
	Id BINARY(16) NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Image VARCHAR(255) NULL,
    IsDeleted BIT DEFAULT b'0',
    IsActive BIT DEFAULT b'1',
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL
);
//
-- Entidades Débiles
DELIMITER //
CREATE TABLE SubCategories (
	Id BINARY(16) NOT NULL PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Image VARCHAR(255) NULL,
    IsDeleted BIT DEFAULT b'0',
    IsActive BIT DEFAULT b'1',
    CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    CategoryId BINARY(16) NOT NULL,
    FOREIGN KEY(CategoryId) REFERENCES Categories(Id)
);

CREATE TABLE Products (
	Id BINARY(16) NOT NULL PRIMARY KEY,
    Sku VARCHAR(30) NOT NULL,
    Name VARCHAR(50) NOT NULL,
    Price DECIMAL(16,2) NOT NULL,
    Cost DECIMAL(16,2) NOT NULL,
    Image VARCHAR(255) NOT NULL,
    Stock  DECIMAL(16,2) NOT NULL,
    MinimunStock DECIMAL(5,2) NOT NULL,
    FreeShipping BIT NOT NULL DEFAULT b'0',
    Featured BIT NOT NULL DEFAULT b'0',
    Description TEXT NOT NULL,
    Specifications TEXT NOT NULL,
    IsDeleted BIT NOT NULL DEFAULT b'0',
    IsActive BIT NOT NULL DEFAULT b'1',
	CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    CategoryId BINARY(16) NOT NULL,
    SubCategoryId BINARY(16) NULL,
    FOREIGN KEY(CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY(SubCategoryId) REFERENCES SubCategories(Id)
);

CREATE TABLE Reviews(
	Id BINARY(16) NOT NULL PRIMARY KEY,
    Comment TEXT NULL,
    Rating INT(1) NULL,
    IsDeleted BIT NOT NULL DEFAULT b'0',
    IsActive BIT NOT NULL DEFAULT b'1',
	CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    ProductId BINARY(16) NOT NULL,
    UserId BINARY(16) NOT NULL,
    FOREIGN KEY(ProductId) REFERENCES Products(Id),
    FOREIGN KEY(UserId) REFERENCES AspNetUsers(Id)
);

CREATE TABLE Sell(
	Id BINARY(16) NOT NULL PRIMARY KEY,
    Correlative INT NOT NULL,
    Date DATETIME NOT NULL,
    `Type` ENUM('CF','CCF','EXP') NOT NULL,
    `Condition` ENUM('CREDIT','CASH','CREDIT_CARD') NOT NULL,
    `Status` ENUM('PROCESSING','SHIPPED','DELIVERED', 'FAILED', 'CANCELED') NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT b'0',
    IsActive BIT NOT NULL DEFAULT b'1',
	CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    UserId BINARY(16) NOT NULL,
    FOREIGN KEY(UserId) REFERENCES AspNetUsers(Id)
);

CREATE TABLE SellDetails(
	Id BINARY(16) NOT NULL PRIMARY KEY,
    Quantity DECIMAL(10,2) NOT NULL,
    UnitPrice DECIMAL(16,2) NOT NULL,
    VAT DECIMAL(16,2) NOT NULL,
	IsDeleted BIT NOT NULL DEFAULT b'0',
    IsActive BIT NOT NULL DEFAULT b'1',
	CreatedAt DATETIME NOT NULL,
    UpdatedAt DATETIME NULL,
    SellId BINARY(16) NOT NULL,
    ProductId BINARY(16) NOT NULL,
    FOREIGN KEY(SellId) REFERENCES Sell(Id),
    FOREIGN KEY(ProductId) REFERENCES Products(Id)
);
//