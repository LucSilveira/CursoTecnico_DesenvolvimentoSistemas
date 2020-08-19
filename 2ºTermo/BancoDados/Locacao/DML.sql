/* DML - Data Manipulation Language */

--Usando o banco de dados
USE locacao
GO

-- Inserindo dados em marcas
INSERT INTO Marca (Nome) VALUES 
	('Honda'),
	('Ford');

-- Inserindo dados em modelos
INSERT INTO Modelo (Nome, IdMarca) VALUES
	('Civic', 1),
	('Fiesta', 2);

-- Inserindo dados em ddd
INSERT INTO DDD (Numero) VALUES
	(11),
	(18);

-- Inserindo dados em telefone
INSERT INTO Telefone (Numero, IdDDD) VALUES
	(980571547, 1),
	(985678542, 2);

-- Inserindo dados em cliente
INSERT INTO Cliente (Nome, Idade, IdTelefone) VALUES
	('Marcos', 25, 2),
	('Amanda', 21, 1);

-- Inserindo dados em veiculo
INSERT INTO Veiculo (Cor, Placa, Ignicao, IdModelo, IdCliente) VALUES
	('Vermelho', 'jfg4875', 1, 2, 1),
	('Prata', 'adf8759', 0, 1, 2);