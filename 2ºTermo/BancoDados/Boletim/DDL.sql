/*
	Comandos de criação de Banco
*/

CREATE DATABASE boletim;
go

/* Utilizando o banco criado */
USE boletim;
go

/* Criando a tabela de aluno */
CREATE TABLE aluno(
	IdAluno int primary key identity,
	Nome varchar(100) not null,
	RA varchar(20),
	Idade int
);

/* Criando a tabela de materias */
CREATE TABLE materia(
	IdMateria int primary key identity,
	Titulo varchar(50) not null
);


/* Criando a tabela de trabalhos */
CREATE TABLE trabalho(
	IdTrabalho int primary key identity,
	NotaTrabalho decimal,
	DataEntrega DATETIME,

	-- chamando as foreign keys
	IdAluno int foreign key references aluno (IdAluno),
	IdMateria int foreign key references materia (IdMateria)
);