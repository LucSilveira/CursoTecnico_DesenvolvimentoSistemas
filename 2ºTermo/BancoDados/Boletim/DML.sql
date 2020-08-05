/* Conectando com o banco de dados boletim */
USE boletim;

/* Manipulando os valores das tabelas atrav�s das DQLs */

-- Inserindo dados na tabela Aluno
INSERT INTO Aluno (Nome, RA, Idade) values ('Lucas', 'R123', 19), ('Antonio', 'R321', 34);

-- Inserindo dados na tabela Materia
INSERT INTO Materia (Titulo) values ('Matem�tica'), ('L�gica');

-- Inserindo dados na tabela Trabalho
INSERT INTO Trabalho (NotaTrabalho, DataEntrega, IdAluno, idMateria) values (9.80, '2020-07-25T23:59:59', 2, 1);

/* Atualizando dados */

-- Atualizando nota de trabalho
UPDATE Trabalho SET NotaTrabalho = 8.80 WHERE IdTrabalho = 1;

-- Deletando dados da tabela trabalho
DELETE Trabalho WHERE IdTrabalho = 3;

