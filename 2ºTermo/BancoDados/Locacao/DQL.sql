/* DQL - Data Query Language */

-- Usando o banco de dados
USE locacao;
GO

-- Selecionando os dados das tabelas
SELECT * FROM Marca;
SELECT * FROM Modelo;
SELECT * FROM DDD;
SELECT * FROM Telefone;
SELECT * FROM Cliente;
SELECT * FROM Veiculo;

-- selecionando dados com parametros
SELECT * FROM Marca WHERE IdMarca = 2;
SELECT * FROM Modelo WHERE IdModelo = 2;
SELECT * FROM DDD WHERE IdDDD = 1;
SELECT * FROM Telefone WHERE IdTelefone = 2;
SELECT * FROM Cliente WHERE IdCliente = 1;
SELECT * FROM Veiculo WHERE IdVeiculo = 1;

-- Selecionando dados com INNER JOIN
SELECT Marca.Nome as 'Marca', Modelo.Nome as 'Modelo', Veiculo.Cor, Veiculo.Placa, Veiculo.Ignicao, Cliente.Nome as 'Cliente' FROM Veiculo
	INNER JOIN Cliente ON Veiculo.IdCliente = Cliente.IdCliente
	INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo
	INNER JOIN Marca ON Modelo.IdMarca = Marca.IdMarca