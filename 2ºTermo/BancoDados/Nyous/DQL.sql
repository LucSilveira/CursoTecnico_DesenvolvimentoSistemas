/* DQL - Data Query Language */

-- Usando o banco de dados
USE nyous;
GO

-- Listando todos os dados de todas as tabelas
SELECT * FROM Permissao;
SELECT * FROM Categoria;
SELECT * FROM Localizacao;
SELECT * FROM Usuario;
SELECT * FROM Evento;

-- Listando eventos com inner joins
SELECT * FROM Evento
	INNER JOIN Categoria ON Evento.IdCategoria = Categoria.IdCategoria
	INNER JOIN Localizacao ON Evento.IdLocalizacao = Localizacao.IdLocalizacao