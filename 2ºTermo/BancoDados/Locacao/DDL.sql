/* DDL - Data Definition Language */

-- Criando o banco de dados
CREATE DATABASE locacao
GO

-- Usando o banco de dados
USE locacao
GO

-- Criando a tabela de marcas
CREATE TABLE Marca (
	IdMarca INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(30)
);

-- Criando a tabela de modelos
CREATE TABLE Modelo (
	IdModelo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50),

	IdMarca INT FOREIGN KEY REFERENCES Marca (IdMarca)
);

-- Criando a tabela de DDD´s
CREATE TABLE DDD (
	IdDDD INT PRIMARY KEY IDENTITY,
	Numero INT NOT NULL
);

-- Criando tabela de Telefone
CREATE TABLE Telefone (
	IdTelefone INT PRIMARY KEY IDENTITY,
	Numero INT,

	IdDDD INT FOREIGN KEY REFERENCES DDD (IdDDD)
);

-- Criando a tabela de clientes
CREATE TABLE Cliente (
	IdCliente INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50),
	Idade INT,

	IdTelefone INT FOREIGN KEY REFERENCES Telefone (IdTelefone)
);

-- Criando a tabela de veiculos
CREATE TABLE Veiculo (
	IdVeiculo INT PRIMARY KEY IDENTITY,
	Cor VARCHAR(20),
	Placa varchar(8),
	Ignicao BIT DEFAULT 0,

	IdModelo INT FOREIGN KEY REFERENCES Modelo (IdModelo),
	IdCliente INT FOREIGN KEY REFERENCES Cliente (IdCliente)
);