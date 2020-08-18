/* DQL - Data Query Language */

-- Usando o banco de dados
USE clinicaPets;

-- Selecionando dados de todas as tabelas
SELECT * FROM Clinica;
SELECT * FROM Especie;
SELECT * FROM Raca;
SELECT * FROM Pet;
SELECT * FROM Veterinario;
SELECT * FROM Atendimento;

-- Selecionando dados especificos em cada tabela atráves do Id (identificador)
SELECT * FROM Clinica WHERE IdClinica = 1;
SELECT * FROM Especie WHERE IdEspecie = 2;
SELECT * FROM Raca WHERE IdRaca = 3;
SELECT * FROM Pet WHERE IdPet = 2;
SELECT * FROM Veterinario WHERE IdVeterinario = 1;
SELECT * FROM Atendimento WHERE IdAtendimento = 2;

-- Selecionando dados com inner joins
/*SELECT aluno.Nome, materia.Titulo, trabalho.NotaTrabalho FROM trabalho
		INNER JOIN aluno ON trabalho.IdAluno = aluno.IdAluno
		INNER JOIN materia ON trabalho.idMateria = materia.IdMateria*/