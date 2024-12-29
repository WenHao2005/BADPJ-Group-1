-- Table: Category
CREATE TABLE Category (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    SkinTone NVARCHAR(50) CHECK (SkinTone IN ('Fair', 'Medium', 'Olive', 'Dark')),
    BodyShape NVARCHAR(50) CHECK (BodyShape IN ('Hourglass', 'Pear', 'Apple', 'Rectangle', 'InvertedTriangle')),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- Table: Product
CREATE TABLE Product (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(18, 2) NOT NULL,
    StockQuantity INT NOT NULL,
    Brand NVARCHAR(255),
    Material NVARCHAR(255),
    Color NVARCHAR(50),
    Size NVARCHAR(10) CHECK (Size IN ('S', 'M', 'L', 'XL', 'XXL')),
    ImageUrl NVARCHAR(MAX),
    CategoryId INT,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Product_Category FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
);