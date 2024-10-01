CREATE DATABASE Ecommerce;
GO

USE Ecommerce;
GO

-- Criação da tabela Pedidos
CREATE TABLE Pedidos (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Status INT NOT NULL,
    PrecoTotal DECIMAL(18, 2) NOT NULL,
    Data DATETIME NOT NULL
);
GO

-- Criação da tabela Itens
CREATE TABLE Itens (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    PedidoId INT NOT NULL,
    Quantidade INT NOT NULL,
    Preco DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id)
);