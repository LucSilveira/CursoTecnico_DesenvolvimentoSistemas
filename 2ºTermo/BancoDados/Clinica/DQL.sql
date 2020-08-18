/* DQL - Data Query Language */

-- Usando o banco de dados
USE clinicaPets;

-- Selecionando dados de todas as tabelas
SELECT * FROM Clinica;
SELECT * FROM Tipo;
SELECT * FROM Raca;
SELECT * FROM Dono;
SELECT * FROM Pet;
SELECT * FROM Veterinario;
SELECT * FROM Atendimento;

-- Selecionando dados especificos em cada tabela atráves do Id (identificador)
SELECT * FROM Clinica WHERE IdClinica = 1;
SELECT * FROM Tipo WHERE IdTipo = 2;
SELECT * FROM Raca WHERE IdRaca = 3;
SELECT * FROM Dono WHERE IdDono = 1;
SELECT * FROM Pet WHERE IdPet = 2;
SELECT * FROM Veterinario WHERE IdVeterinario = 1;
SELECT * FROM Atendimento WHERE IdAtendimento = 2;

-- Selecionando dados com inner joins
SELECT Pet.Nome, Veterinario.Nome, Atendimento.DataAtendimento, Atendimento.Descricao FROM Atendimento
	INNER JOIN Pet ON Atendimento.IdPet = Pet.IdPet
	INNER JOIN Veterinario ON Atendimento.IdVeterinario = Veterinario.IdVeterinario;

SELECT Pet.Nome, Pet.DataNascimento, Raca.NomeRaca, Dono.NomeDono FROM Pet
	INNER JOIN Dono ON Pet.IdDono = Dono.IdDono
	INNER JOIN Raca ON Pet.IdRaca = Raca.IdRaca;