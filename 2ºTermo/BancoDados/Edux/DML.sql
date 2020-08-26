/* DML - Data Manipulation Language */

-- Usando o banco de dados
USE Edux;
GO

-- Inserindo dados na tabela de escolas
INSERT INTO Escola (Nome) VALUES
	('Escola SENAI de Informática');

-- Inserindo dados na tabela de tipos de usuário
INSERT INTO TipoUsuario (TipoUsuario) VALUES
	('Professor'),
	('Aluno');

-- Inserindo dados na tabela de usuários
INSERT INTO Usuario (NomeCompleto, DataNascimento, Sexo, Email, Senha, IdTipoUsuario) VALUES
	('Paulo Brandao', '2000-01-10T00:00:00', 'M', 'paulobrandao@gmail.com', 'paulo123', 1),
	('Carlos Tsukamoto', '2000-02-02T00:00:00', 'M', 'tsukamoto@gmail.com', 'tsuka123', 1),
	('Lucas Silveira', '2001-02-03T00:00:00', 'M', 'lucassilveira@hotmail.com', 'lucas123', 2),
	('Matheus Belloni', '2002-01-01T00:00:00', 'M', 'matheusbelloni@hotmail.com', 'belloni123', 2);


-- Inserindo dados na tabela de post
INSERT INTO Post (Descricao, Imagem, IdAluno) VALUES
	('Projeto envolvelvendo a criação de um sistema', 'imagemProjeto.jpg', 3);


-- Inserindo dados na tabela de comentários de post
INSERT INTO Comentario (Comentario, IdAluno, IdPost) VALUES
	('Muito bacana esse projeto', 2, 1);


-- Inserindo dados na tabela de temas da dicas
INSERT INTO Tema (TituloTema) VALUES 
	('Dica sobre lógica de programação'),
	('Dica sobre cabeamento estruturado');


-- Inserindo dados na tabela de dicas
INSERT INTO Dica (Descricao, IdTema, IdProfessor) VALUES
	('Fique atento aos passos a passos necessários', 1, 1),
	('Organize bem a estrutura de cabos de seu servidor', 2, 2);


-- Inserindo dados na tabela de turnos dos cursos
INSERT INTO Turno (Periodo) VALUES
	('Matutino'),
	('Diurno'),
	('Noturno');


-- Inserindo dados na tabela de cursos
INSERT INTO Curso (Titulo, CargaHoraria, Descricao, IdTurno) VALUES
	('Desenvolvimento de Sistemas', 600, 'Curso legal', 1),
	('Redes de computadores', 600, 'Curso complicado', 2);


-- Inserindo dados na tabela de data de cursos
INSERT INTO DataCurso (DiaSemana, DataInicio, DataTermino, IdCurso) VALUES 
	(2, '2020-01-01T07:00:00', '2021-07-12T12:00:00', 1),
	(4, '2020-01-01T07:00:00', '2021-07-12T12:00:00', 2);


-- Inserindo dados na tabela de turma
INSERT INTO Turma (NumeroSala, CapacidadeAlunos, IdCurso) VALUES
	(10, 28, 1),
	(07, 30, 2);


-- Inserindo dados na tabela de categorias de objetivos
INSERT INTO Categoria (TipoCategoria) VALUES
	('Desejável'),
	('Crítico'),
	('Oculto');


-- Inserindo dados na tabela de objetivos
INSERT INTO Objetivo (Titulo, Descricao, IdCategoria) VALUES
	('Demonstrar boa organização', 'Organizar os cabos do servidor, organizadamente e sem bagunça', 1),
	('Demonstar bom raciocínio lógico', 'Demonstrar fácil acimilação com o sistema', 3),
	('Executar o servidor', 'Demonstrar as capacidades necessárias para subir no ar um servidor', 2),
	('Conectar o frontend com a API', 'Demonstrar dominio sobre a construção da API e conecta-lá com o front', 2),
	('Não Faltar a nenhuma aula', 'Demonstrar senso de responsabilidade e comparecer a todas as aulas', 3);


/* INSERINDO DADOS NAS TABELAS DE N > N */

-- Inserindo dados na tabela de escolas do professor
INSERT INTO EscolaProfessor (IdProfessor, IdEscola) VALUES
	(1, 1),
	(2, 1);


-- Inserindo dados na tabela de turmas de alunos
INSERT INTO TurmaAluno (IdAluno, IdTurma) VALUES
	(3, 1), (3, 2),
	(4, 1), (4, 2);


-- Inserindo dados na tabela de turmas do professor
INSERT INTO TurmaProfessor (IdProfessor, IdTurma) VALUES
	(1, 1), (1, 2),
	(2, 1), (2, 2);


-- Inserindo dados na tabela de objetivo por curso
INSERT INTO ObjetivoCurso (IdObjetivo, IdCurso) VALUES
	(2, 1), (4, 1),
	(1, 2), (3, 2);


-- Inserindo dados na tabela de objetivo por aluno
INSERT INTO ObjetivoAluno (DataEntrega, IdObjetivoCurso, IdAluno) VALUES 
	('2020-08-26T09:30:00', 1, 3),
	( '2020-08-27T00:00:00', 2, 4);