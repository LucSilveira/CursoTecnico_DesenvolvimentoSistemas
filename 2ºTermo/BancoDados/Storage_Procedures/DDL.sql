/* Exercíco Storaged Procedures */ 

/* DDL - Data Definition Language */

-- Criando o banco de dados
CREATE DATABASE exercicioStorage;
Go

-- Usando o banco de dados criado
USE exercicioStorage;
GO

-- Criando a tabela de alunos
CREATE TABLE Aluno (
	IdAluno INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
);