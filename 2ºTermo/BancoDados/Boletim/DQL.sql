/* DQL - Data Query Language */

-- Usando nosso banco de dados
USE boletim;

-- Selecionando todos os dados das tabelas
SELECT * FROM Aluno;
SELECT * FROM Materia;
SELECT * FROM Trabalho;

-- Selecionando dados especificos em cada tabela atráves do Id (identificador)
SELECT * FROM aluno WHERE IdAluno = 2;
SELECT * FROM materia WHERE IdMateria = 1;
SELECT * FROM trabalho WHERE IdTrabalho = 1;

-- Selecionando dados aleatorios de cada tabela
SELECT * FROM aluno WHERE Nome = 'Lucas';
SELECT * FROM materia WHERE Titulo = 'Lógica';
SELECT * FROM trabalho WHERE NotaTrabalho = 8.80;

-- Selecionando dados atráves do LIKE (especie de filtro)
SELECT * FROM aluno WHERE RA LIKE 'R%'; /* % - significa qualquer coisa */

-- Selecionando dados atráves do ORDER BY
SELECT * FROM aluno ORDER BY Idade DESC;

-- Selecionando dados com parametros
SELECT * FROM aluno WHERE IdAluno > 1 AND IdAluno < 4;

-- Selecionando dados com inner joins
SELECT aluno.Nome, materia.Titulo, trabalho.NotaTrabalho FROM trabalho
		INNER JOIN aluno ON trabalho.IdAluno = aluno.IdAluno
		INNER JOIN materia ON trabalho.idMateria = materia.IdMateria
