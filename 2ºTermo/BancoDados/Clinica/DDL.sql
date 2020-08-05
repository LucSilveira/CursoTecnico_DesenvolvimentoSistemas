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

-- Tabela das Especies
CREATE TABLE Especie(
	IdEspecie INT PRIMARY KEY IDENTITY,
	NomeEspecie VARCHAR(50)
);

-- Tabela de Racas
CREATE TABLE Raca(
	IdRaca INT PRIMARY KEY IDENTITY,
	NomeRaca VARCHAR(50),

	IdEspecie INT FOREIGN KEY REFERENCES Especie (IdEspecie)
);

-- Tabela de Pets
CREATE TABLE Pet(
	IdPet INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(30),
	DataNascimento DATETIME,

	IdRaca INT FOREIGN KEY REFERENCES Raca (IdRaca)
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

	IdPet INT FOREIGN KEY REFERENCES Pet (IdPet),
	IdVeterinario INT FOREIGN KEY REFERENCES Veterinario (IdVeterinario)
);