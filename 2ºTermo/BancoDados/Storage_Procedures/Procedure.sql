/* Storage Procedures */

-- Usando o banco de dados
USE exercicioStorage;
GO

-- Criando o procedures da aplicação
CREATE PROCEDURE Busca
	@CampoBusca VARCHAR(50)
AS
SELECT
	IdAluno, Nome
FROM
	Aluno
WHERE
	Nome = @CampoBusca
EXECUTE
	Busca 'Lucas'

-- Deletando o procedure criado
DROP PROCEDURE Busca