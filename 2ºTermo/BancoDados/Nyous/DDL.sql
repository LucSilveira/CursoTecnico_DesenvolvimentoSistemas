/* NYOUS - Eventos */

/* DDL - Data Definition Language */

-- Criando o banco de dados da aplicação
CREATE DATABASE nyous;
GO

-- Usando o banco de dados criado
USE nyous;
GO

-- Criando tabela de permissão de usuário
CREATE TABLE Permissao (
	IdPermissao INT PRIMARY KEY IDENTITY NOT NULL,
	TipoPermissao VARCHAR(50) NOT NULL,
);

-- Criando tabela de categorias de eventos
CREATE TABLE Categoria (
	IdCategoria INT PRIMARY KEY IDENTITY NOT NULL,
	Titulo VARCHAR(50) NOT NULL
);

-- Criando tabela de localização de evento
CREATE TABLE Localizacao (
	IdLocalizacao INT PRIMARY KEY IDENTITY NOT NULL,
	Logradouro VARCHAR(255) NOT NULL,
	Numero VARCHAR(10),
	Complemento VARCHAR(30),
	Bairro VARCHAR(50),
	Cidade VARCHAR(50),
	UF VARCHAR(2),
	CEP VARCHAR(10)
);

-- Criando tabela de usuarios
CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Email VARCHAR(80) NOT NULL,
	Senha VARCHAR(255) NOT NULL,
	DataNascimento DATETIME,

	IdPermissao INT FOREIGN KEY REFERENCES Permissao (IdPermissao) /* Definir qual a permissao que o usuário irá possuir */
);

-- Criando tabela de eventos
CREATE TABLE Evento (
	IdEvento INT PRIMARY KEY IDENTITY NOT NULL,
	TituloEvento VARCHAR(100) NOT NULL,
	DataEvento DATETIME, 
	AcessoRestrito BINARY DEFAULT 0,
	Descricao VARCHAR(255) NOT NULL,
	Capacidade INT NOT NULL,

	IdCategoria INT FOREIGN KEY REFERENCES Categoria (IdCategoria), /* Definir qual a categoria do evento */
	IdLocalizacao INT FOREIGN KEY REFERENCES Localizacao (IdLocalizacao) /* Definindo qual a localizacao do evento */
);
select * from categoria
-- Criando tabela de convites
CREATE TABLE Convite (
	IdConvite INT PRIMARY KEY IDENTITY NOT NULL,
	Confirmado BIT DEFAULT NULL,

	IdEvento INT FOREIGN KEY REFERENCES Evento (IdEvento), /* Definir qual o evento que estara no convite */
	IdUsuarioEmissor INT FOREIGN KEY REFERENCES Usuario (IdUsuario), /* Definir qual o usuário enviara o convite */
	IdUsuarioConvidado INT FOREIGN KEY REFERENCES Usuario (IdUsuario) /* Definir qual é o usuário convidado */
);

-- Criando tabela de presenças
CREATE TABLE Presenca (
	IdPresenca INT PRIMARY KEY IDENTITY NOT NULL,
	Confirmado BIT DEFAULT NULL,

	IdEvento INT FOREIGN KEY REFERENCES Evento (IdEvento), /* Definir qual o evento que sera realizado */
	IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario), /* Definir qual o usuário estara no evento */
);