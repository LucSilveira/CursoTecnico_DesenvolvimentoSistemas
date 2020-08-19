/* DQL - Data Query Language */

-- Usando o banco de dados
USE Optus;

-- Selecionando dados de todas as tabelas
SELECT * FROM Artista;
SELECT * FROM Estilo;
SELECT * FROM Album;
SELECT * FROM EstilosAlbum;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;

-- Selecionando dados especificos em cada tabela atráves do Id (identificador)
SELECT * FROM Artista WHERE IdArtista = 2;
SELECT * FROM Estilo WHERE IdEstilo = 1;
SELECT * FROM Album WHERE IdAlbum = 1;
SELECT * FROM EstilosAlbum WHERE IdEstilosAlbum = 2;
SELECT * FROM TipoUsuario WHERE IdTipoUsuario = 1;
SELECT * FROM Usuario WHERE IdUsuario = 2;

-- Selecionando dados com inner joins
SELECT Album.Nome as 'Album', Artista.Nome as 'Artista', Estilo.NomeEstilo as 'Estilo do Album' FROM EstilosAlbum
	INNER JOIN Album ON EstilosAlbum.IdAlbum = Album.IdAlbum
	INNER JOIN Estilo ON EstilosAlbum.IdEstilo = Estilo.IdEstilo
	INNER JOIN Artista ON Album.IdArtista = Artista.IdArtista