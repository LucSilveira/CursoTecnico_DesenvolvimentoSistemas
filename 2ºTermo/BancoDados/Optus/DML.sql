/* DML - Data Manipulation Language */

-- Usando o banco de dados
USE optus;
GO

-- Inserindo dados em Artista
INSERT INTO Artista (Nome) VALUES
	('AC/DC'),
	('Deja vu');

-- Inserindo dados em Estilos
INSERT INTO Estilo (NomeEstilo) VALUES
	('Metal'),
	('Forró');

-- Inserindo dados em Album
INSERT INTO Album (Nome, DataLancamento, QuantidadeMusicas, DuracaoAlbum, IdArtista) VALUES
	('Back in Black', '1980-07-25T00:00:00.000', 12, 30.00, 1),
	('Deja vu', '1970-03-11T00:00:00.000', 8, 32.50, 2);

-- Inserindo dados em Estilos do Album
INSERT INTO EstilosAlbum (IdAlbum, IdEstilo) VALUES 
	(1, 1),
	(2, 2);

-- Inserindo dados em Tipos de Usuarios
INSERT INTO TipoUsuario (Permissao) VALUES
	('Administrador'),
	('Comum');

-- Inserindo dados em usuario
INSERT INTO Usuario (NomeUsuario, Email, Senha, IdTipoPermissao) VALUES
	('Lucas', 'lucas@email.com', 'lucas132', 1),
	('Amanda', 'amanda@gmail.com', 'amanda132', 2);