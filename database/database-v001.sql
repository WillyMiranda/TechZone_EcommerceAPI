USE techzone_db;

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
//