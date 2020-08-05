/* DDL - Data Manipulation Language */

-- Criando banco de dados
CREATE DATABASE Optus;
GO

-- Usando o banco de dados
USE Optus;
GO

-- Criando tabela de Artista
CREATE TABLE Artista(
	IdArtista INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
);

-- Criando tabela de Estilos
CREATE TABLE Estilos(
	IdEstilo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(30)
);	

-- Criando tabela de Albuns
CREATE TABLE Album(
	IdAlbum INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(40),

	IdEstilos INT FOREIGN KEY REFERENCES Estilos (IdEstilo),
	IdArtista INT FOREIGN KEY REFERENCES Artista (IdArtista)
);