CREATE TABLE [dbo].[Customers] (
    [CustomerID] INT IDENTITY(1,1) PRIMARY KEY,
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL UNIQUE,
    [Phone] NVARCHAR(15) NOT NULL,
    [Street] NVARCHAR(255) NULL,
    [PostalCode] NVARCHAR(6) NULL,
    [Gender] NVARCHAR(10) NULL
);
