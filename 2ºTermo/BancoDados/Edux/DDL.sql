/* DDL - Data Definition Language */

-- Criando o banco de dados
CREATE DATABASE Edux;
GO

-- Usando o banco de dados
USE Edux;
GO

-- Criando a tabela de escolas
CREATE TABLE Escola (
	IdEscola INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(30) NOT NULL
);

-- Criando a tabela de tipos de usuários
CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	TipoUsuario VARCHAR(10) NOT NULL
);

-- Criando a tabela de usuários
CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	NomeCompleto VARCHAR(100) NOT NULL,
	DataNascimento DATETIME,
	Sexo VARCHAR(1) NOT NULL,
	Email VARCHAR(80) NOT NULL,
	Senha VARCHAR(255) NOT NULL,

	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);

-- Criando a tabela de posts dos alunos
CREATE TABLE Post (
	IdPost INT PRIMARY KEY IDENTITY NOT NULL,
	DataPostagem DATETIME DEFAULT GETDATE(),
	Curtidas INT DEFAULT 0,
	Descricao VARCHAR(255),
	Imagem VARCHAR(255),

	IdAluno INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
);

-- Criando a tabela de comentarios
CREATE TABLE Comentario (
	IdComentario INT PRIMARY KEY IDENTITY NOT NULL,
	Comentario VARCHAR(255),
	Curtidas INT DEFAULT 0,

	IdAluno INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdPost INT FOREIGN KEY REFERENCES Post (IdPost)
);

-- Criando a tabela de temas das dicas
CREATE TABLE Tema (
	IdTema INT PRIMARY KEY IDENTITY NOT NULL,
	TituloTema VARCHAR(50) NOT NULL
);

-- Criando a tabela de dicas
CREATE TABLE Dica (
	IdDica INT PRIMARY KEY IDENTITY NOT NULL,
	Descricao VARCHAR(255) NOT NULL,

	IdTema INT FOREIGN KEY REFERENCES Tema (IdTema),
	IdProfessor INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
);

-- Criando a tabela de turnos de cursos
CREATE TABLE Turno (
	IdTurno INT PRIMARY KEY IDENTITY NOT NULL,
	Periodo VARCHAR(8) NOT NULL
);

-- Criando a tabela de cursos
CREATE TABLE Curso (
	IdCurso INT PRIMARY KEY IDENTITY NOT NULL,
	Titulo VARCHAR(100) NOT NULL,
	CargaHoraria INT NOT NULL,
	Descricao VARCHAR(255),

	IdTurno INT FOREIGN KEY REFERENCES Turno (IdTurno)
);

-- Criando a tabela de datas dos cursos
CREATE TABLE DataCurso (
	IdDataCurso INT PRIMARY KEY IDENTITY NOT NULL,
	DiaSemana INT,
	DataInicio DATETIME,
	DataTermino DATETIME,

	IdCurso INT FOREIGN KEY REFERENCES Curso (IdCurso)
);

-- Criando a tabela de turmas
CREATE TABLE Turma (
	IdTurma INT PRIMARY KEY IDENTITY NOT NULL,
	NumeroSala INT NOT NULL,
	CapacidadeAlunos INT NOT NULL,

	IdCurso INT FOREIGN KEY REFERENCES Curso (IdCurso)
);

-- Criando a tabela de categorias de objetivos
CREATE TABLE Categoria (
	IdCategoria INT PRIMARY KEY IDENTITY NOT NULL,
	TipoCategoria VARCHAR(50) NOT NULL,
);

-- Criando a tabela de objetivo
CREATE TABLE Objetivo (
	IdObjetivo INT PRIMARY KEY IDENTITY NOT NULL,
	Titulo VARCHAR(100) NOT NULL,
	Descricao VARCHAR(255) NOT NULL,

	IdCategoria INT FOREIGN KEY REFERENCES Categoria (IdCategoria)
);

/* CRIANDO AS TABELAS DE RELACIONAMENTOS N PARA N */

-- Criando a tabela de relação entre Escola e Professor
CREATE TABLE EscolaProfessor (
	IdEscolaProfessor INT PRIMARY KEY IDENTITY NOT NULL,

	IdProfessor INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdEscola INT FOREIGN KEY REFERENCES Escola (IdEscola)
);

-- Criandp a tabela de relação entre Turma e Aluno
CREATE TABLE TurmaAluno (
	IdTurmaAluno INT PRIMARY KEY IDENTITY NOT NULL,

	IdAluno INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdTurma INT FOREIGN KEY REFERENCES Turma (IdTurma)
);

-- Criando a tabela de relação entre Turma e Professor
CREATE TABLE TurmaProfessor (
	IdTurmaProfessor INT PRIMARY KEY IDENTITY NOT NULL,

	IdProfessor INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdTurma INT FOREIGN KEY REFERENCES Turma (IdTurma)
);

-- Criando a tabela de relação entre Objetivo e Curso
CREATE TABLE ObjetivoCurso (
	IdObjetivoCurso INT PRIMARY KEY IDENTITY NOT NULL,

	IdObjetivo INT FOREIGN KEY REFERENCES Objetivo (IdObjetivo),
	IdCurso INT FOREIGN KEY REFERENCES Curso (IdCurso)
);

-- Criando a tabela de relação entre Objetivo e Aluno
CREATE TABLE ObjetivoAluno (
	IdObjetivoAluno  INT PRIMARY KEY IDENTITY NOT NULL,
	DataEntrega DATETIME,
	Nota INT DEFAULT NULL,
	StatusObjetivo BIT DEFAULT NULL,

	IdObjetivoCurso INT FOREIGN KEY REFERENCES ObjetivoCurso (IdObjetivoCurso),
	IdAluno INT FOREIGN KEY REFERENCES Usuario (IdUsuario)
);