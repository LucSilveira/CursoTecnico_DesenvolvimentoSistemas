/* Exercício da Clínica de Pets*/

/* DML - Data Manipulation Language */

CREATE DATABASE clinicaPets;
GO

USE clinicaPets;
GO

-- Tabela de Clinicas
CREATE TABLE Clinica(
	IdClinica INT PRIMARY KEY IDENTITY,
	Endereco VARCHAR(100),
	Nome VARCHAR(30)
);

-- Tabela dos Tipos de pets
CREATE TABLE Tipo(
	IdTipo INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR(50)
);

-- Tabela de Racas
CREATE TABLE Raca(
	IdRaca INT PRIMARY KEY IDENTITY,
	NomeRaca VARCHAR(50),

	IdTipoPet INT FOREIGN KEY REFERENCES Tipo (IdTipo)
);

-- Tabela de Donos
CREATE TABLE Dono(
	IdDono INT PRIMARY KEY IDENTITY,
	NomeDono VARCHAR(30)
)

-- Tabela de Pets
CREATE TABLE Pet(
	IdPet INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(30),
	DataNascimento DATETIME,

	IdRaca INT FOREIGN KEY REFERENCES Raca (IdRaca),
	IdDono INT FOREIGN KEY REFERENCES Dono (IdDono)
);

-- Tabela de Veterinarios
CREATE TABLE Veterinario(
	IdVeterinario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(30),

	IdClinica INT FOREIGN KEY REFERENCES Clinica (IdClinica)
);

-- Tabela dos Atendimentos
CREATE TABLE Atendimento(
	IdAtendimento INT PRIMARY KEY IDENTITY,
	DataAtendimento DATETIME,
	Descricao varchar(155),

	IdPet INT FOREIGN KEY REFERENCES Pet (IdPet),
	IdVeterinario INT FOREIGN KEY REFERENCES Veterinario (IdVeterinario)
);