/* DDL - Data Manipulation Language */

-- Criando banco de dados
CREATE DATABASE optus;
GO

-- Usando o banco de dados
USE optus;
GO

-- Criando tabela de Artista
CREATE TABLE Artista(
	IdArtista INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
);

-- Criando tabela de Estilos
CREATE TABLE Estilo(
	IdEstilo INT PRIMARY KEY IDENTITY,
	NomeEstilo VARCHAR(30)
);	

-- Criando tabela de Albuns
CREATE TABLE Album(
	IdAlbum INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(40),
	DataLancamento DATETIME,
	QuantidadeMusicas INT,
	DuracaoAlbum DECIMAL(10, 2),

	IdArtista INT FOREIGN KEY REFERENCES Artista (IdArtista)
);

-- Criando a tabela de estilos do album
CREATE TABLE EstilosAlbum (
	IdEstilosAlbum INT PRIMARY KEY IDENTITY,
	
	IdAlbum INT FOREIGN KEY REFERENCES Album (IdAlbum),
	IdEstilo INT FOREIGN KEY REFERENCES Estilo (IdEstilo)
);

-- Criando a tabela de Tipos de Usuarios
CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Permissao VARCHAR(20)
);	

-- Criando a tabela de Usuario
CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY,
	NomeUsuario VARCHAR(50),
	Email VARCHAR(155),
	Senha VARCHAR(155),

	IdTipoPermissao INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);