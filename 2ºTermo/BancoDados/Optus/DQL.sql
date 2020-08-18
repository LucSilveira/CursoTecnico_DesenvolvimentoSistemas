/* DQL - Data Query Language */

-- Usando o banco de dados
USE Optus;

-- Selecionando dados de todas as tabelas
SELECT * FROM Artista;
SELECT * FROM Estilos;
SELECT * FROM Album;

-- Selecionando dados especificos em cada tabela atráves do Id (identificador)
SELECT * FROM Artista WHERE IdArtista = 2;
SELECT * FROM Estilos WHERE IdEstilo = 1;
SELECT * FROM Album WHERE IdAlbum = 1;

-- Selecionando dados com inner joins
/*SELECT aluno.Nome, materia.Titulo, trabalho.NotaTrabalho FROM trabalho
		INNER JOIN aluno ON trabalho.IdAluno = aluno.IdAluno
		INNER JOIN materia ON trabalho.idMateria = materia.IdMateria*/