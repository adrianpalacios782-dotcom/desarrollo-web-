CREATE DATABASE TechInventoryDb;
GO
USE TechInventoryDb;
GO

CREATE TABLE Equipos (
    Id INT PRIMARY KEY IDENTITY (1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Marca NVARCHAR(50) NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    Stock INT NOT NULL
);
