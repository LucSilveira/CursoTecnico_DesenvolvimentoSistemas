/* DML - Data Manipulation Language */

-- Usando o banco de dados
USE clinicaPets;
GO

-- Inserindo dados em clínicas
INSERT INTO Clinica (Endereco, Nome) VALUES
	('Rua: Euclides da Cunha', 'AnimaPet'),
	('Rua: Alvarez de Antonio', 'TrataPet');

-- Inserindo dados em Tipos de pets
INSERT INTO Tipo (Descricao) VALUES
	('Cachorro'),
	('Gato'),
	('Passaro');

-- Inserindo dados em Racas
INSERT INTO Raca (NomeRaca, IdTipoPet) VALUES
	('Biggle', 1),
	('Pitbull', 1),
	('Persa', 2),
	('Canário', 3);

--Inserindo dados em Donos
INSERT INTO Dono (NomeDono) VALUES
	('Lucas'),
	('Amanda');

-- Inserindo dados em Pets
INSERT INTO Pet (Nome, DataNascimento, IdRaca, IdDono) VALUES
	('Bob', '2015-02-22T00:00:00', 1, 1),
	('Max', '2012-05-20T00:00:00', 3, 2);

-- Inserindo dados em Veterinarios
INSERT INTO Veterinario (Nome, IdClinica) VALUES
	('Marcos', 1),
	('Laura', 2);

-- Inserindo dados em Atendimentos
INSERT INTO Atendimento (DataAtendimento, IdPet, IdVeterinario) VALUES
	('2020-04-22T08:30:00', 1, 2),
	('2020-03-15T18:30:00', 2, 1);

-- Atualizando informações que faltam
UPDATE Atendimento SET Descricao = 'Checagem de rotina' WHERE IdAtendimento = 1;
UPDATE Atendimento SET Descricao = 'Animal com complicações na vista' WHERE IdAtendimento = 2;