/* DQL - Data Query Language */

-- Usando o banco de dados
USE Edux;
GO

-- Selecionando os dados de todas as tabelas com relacionamento 1 > N
SELECT * FROM Escola;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;
SELECT * FROM Post;
SELECT * FROM Comentario;
SELECT * FROM Tema;
SELECT * FROM Dica;
SELECT * FROM Turno;
SELECT * FROM Curso;
SELECT * FROM DataCurso;
SELECT * FROM Turma;
SELECT * FROM Categoria;
SELECT * FROM Objetivo;

-- Selecionando os dados das tabelas com relacionamento de N > N
SELECT * FROM EscolaProfessor;
SELECT * FROM TurmaAluno;
SELECT * FROM TurmaProfessor;
SELECT * FROM ObjetivoCurso;
SELECT * FROM ObjetivoAluno;


/* Selecionando os dados via INNER JOIN para identificar o fluxo de dados */

-- INNER JOIN sobre as tabelas de relacionamentos 1 > N

-- relação entre Tipos de usuários e Usuários
SELECT TipoUsuario.TipoUsuario, Usuario.NomeCompleto FROM Usuario
	INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario

-- relação entre Post e Comentarios
SELECT Post.Descricao, Post.Imagem, Post.Curtidas, Comentario.Comentario FROM Comentario
	INNER JOIN Post ON Comentario.IdPost = Post.IdPost

-- relação entre Dicas e Tema de dicas
SELECT Tema.TituloTema, Dica.Descricao FROM Dica
	INNER JOIN Tema ON Dica.IdTema = Tema.IdTema

-- relação entre Curso, Turma, Turno e a Data do curso
SELECT Curso.Titulo, Curso.Descricao, Turno.Periodo, Turma.CapacidadeAlunos as 'Vagas', DataCurso.DiaSemana, DataCurso.DataInicio, DataCurso.DataTermino FROM DataCurso
	INNER JOIN Curso ON DataCurso.IdCurso = Curso.IdCurso
	INNER JOIN Turno ON Curso.IdTurno = Turno.IdTurno
	INNER JOIN Turma ON Curso.IdCurso = Turma.IdCurso

-- relação entre Objetivo e Categoria
SELECT Categoria.TipoCategoria, Objetivo.Descricao, Objetivo.Titulo FROM Objetivo
	INNER JOIN Categoria ON Objetivo.IdCategoria = Categoria.IdCategoria


-- INNER JOIN sobre as tabelas de relação N > N

-- relação entre Escolas e Professores
SELECT Usuario.NomeCompleto, Escola.Nome as 'Escola' FROM EscolaProfessor
	INNER JOIN Usuario ON EscolaProfessor.IdProfessor = Usuario.IdUsuario
	INNER JOIN Escola ON EscolaProfessor.IdEscola = Escola.IdEscola

-- relação entre Turmas e Alunos
SELECT Usuario.NomeCompleto, Curso.Titulo as 'Curso' FROM TurmaAluno
	INNER JOIN Usuario ON TurmaAluno.IdAluno = Usuario.IdUsuario
	INNER JOIN Turma ON TurmaAluno.IdTurma = Turma.IdTurma
	INNER JOIN Curso ON Turma.IdCurso = Curso.IdCurso

-- relação entre Turmas e Professores
select Usuario.NomeCompleto, Turma.NumeroSala, Curso.Titulo, Curso.Descricao, Turno.Periodo FROM TurmaProfessor
	INNER JOIN Usuario ON TurmaProfessor.IdProfessor = Usuario.IdUsuario
	INNER JOIN Turma ON TurmaProfessor.IdTurma = Turma.IdTurma
	INNER JOIN Curso ON Turma.IdTurma = Curso.IdCurso
	INNER JOIN Turno ON Curso.IdTurno = Turno.IdTurno

-- relação entre Objetivos e Cursos
SELECT Objetivo.Titulo, Objetivo.Descricao, Curso.Titulo, Categoria.TipoCategoria FROM ObjetivoCurso
	INNER JOIN Objetivo ON ObjetivoCurso.IdObjetivo = Objetivo.IdObjetivo
	INNER JOIN Curso ON ObjetivoCurso.IdCurso = Curso.IdCurso
	INNER JOIN Categoria ON Objetivo.IdCategoria = Categoria.IdCategoria

-- relação entre Objetivos e Alunos
SELECT Objetivo.Titulo, Objetivo.Descricao, Usuario.NomeCompleto, ObjetivoAluno.StatusObjetivo, ObjetivoAluno.Nota, ObjetivoAluno.DataEntrega, Categoria.TipoCategoria FROM ObjetivoAluno
	INNER JOIN ObjetivoCurso ON ObjetivoAluno.IdObjetivoCurso = ObjetivoCurso.IdObjetivoCurso
	INNER JOIN Objetivo ON ObjetivoCurso.IdObjetivo = Objetivo.IdObjetivo
	INNER JOIN Usuario ON ObjetivoAluno.IdAluno = Usuario.IdUsuario
	INNER JOIN Categoria ON Objetivo.IdCategoria = Categoria.IdCategoria

/* Funções para a contagem de onjetivos concluidos */

-- Utilizando a função COUNT para contagem
SELECT COUNT(StatusObjetivo) FROM ObjetivoAluno WHERE ObjetivoAluno.StatusObjetivo = 1;