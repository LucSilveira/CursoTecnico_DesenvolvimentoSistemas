/* DDL - Data Definition Language */

-- Criando o banco de dados
CREATE DATABASE Edux;
GO

-- Usando o banco de dados
USE Edux;
GO

-- Criando a tabela de Instituição
CREATE TABLE Instituicoes (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(255),
	Logradouro VARCHAR(255),
	Numero VARCHAR(255),
	Complemento VARCHAR(255),
	Bairro VARCHAR(255),
	Cidade VARCHAR(255),
	UF VARCHAR(2),
	CEP VARCHAR(15)
);

-- Criando a tabela de Curso
CREATE TABLE Cursos (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Titulo VARCHAR(255),

	IdInstituicao INT FOREIGN KEY REFERENCES Instituicoes (Id)
);

-- Criando a tabela de Turma
CREATE TABLE Turmas (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Descricao VARCHAR(255),

	IdCurso INT FOREIGN KEY REFERENCES Cursos (Id)
);

-- Criando a tabela de Categoria
CREATE TABLE Categorias (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Tipo VARCHAR(255)
);

-- Criando a tabela de Objetivo
CREATE TABLE Objetivos (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Descricao VARCHAR(255),

	IdCategoria INT FOREIGN KEY REFERENCES Categorias (Id)
);

-- Criando a tabela de Perfil
CREATE TABLE Perfils (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Permissao VARCHAR(10)
);

-- Criando a tabela de Usuario
CREATE TABLE Usuarios (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(255),
	Email VARCHAR(100),
	Senha VARCHAR(255),
	DataCadastro DateTime DEFAULT GETDATE(),
	DataUltimoAcesso DateTime,
	
	IdPerfil INT FOREIGN KEY REFERENCES Perfils (Id)
);

-- Criando a tabela de Dica
CREATE TABLE Dicas (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Texto VARCHAR(255),
	Imagem VARCHAR(255),

	IdUsuario INT FOREIGN KEY REFERENCES Usuarios (Id)
);

-- Criando a tabela de Curtida
CREATE TABLE Curtidas (
	Id INT PRIMARY KEY IDENTITY NOT NULL,

	IdDica INT FOREIGN KEY REFERENCES Dicas (Id),
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios (Id)
);

-- Criando a tabela de AlunoTurma
CREATE TABLE AlunosTurmas (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Matricula VARCHAR(50),

	IdUsuario INT FOREIGN KEY REFERENCES Usuarios (Id),
	IdTurma INT FOREIGN KEY REFERENCES Turmas (Id)
);

-- Criando a tabela de AlunoTurma
CREATE TABLE ProfessoresTurmas (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Matricula VARCHAR(50),

	IdUsuario INT FOREIGN KEY REFERENCES Usuarios (Id),
	IdTurma INT FOREIGN KEY REFERENCES Turmas (Id)
);

-- Criando a tabela de ObjetivoAluno
CREATE TABLE ObjetivosAlunos (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Nota DECIMAL(10, 2) DEFAULT NULL,
	DataAlcancado DateTime DEFAULT NULL,

	IdAlunoTurma INT FOREIGN KEY REFERENCES AlunosTurmas (Id),
	IdObjetivo INT FOREIGN KEY REFERENCES Objetivos (Id)
);