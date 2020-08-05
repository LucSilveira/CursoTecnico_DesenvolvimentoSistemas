/* DML - Data Manipulation Language */

-- Inserindo dados em Artista
INSERT INTO Artista (Nome) VALUES
	('AC/DC'),
	('Pericles');

-- Inserindo dados em Estilos
INSERT INTO Estilos (Nome) VALUES
	('Metal'),
	('Samba');

-- Inserindo dados em Album
INSERT INTO Album (Nome, IdEstilos, IdArtista) VALUES
	('Back in Black', 1, 1),
	('Feito para Durar', 2, 2);