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
//