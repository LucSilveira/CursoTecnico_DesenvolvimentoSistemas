using APIBoletim.Context;
using APIBoletim.Domains;
using APIBoletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Repositories
{
    public class AlunoRepositorie : IAluno
    {
        // Chamando o BoletimContext para fazer a conexão com o nosso banco de dados
        BoletimContext _conexao = new BoletimContext();

        // Responsavel por colocar comando proprios do SQL no nosso arquivo
        SqlCommand _command = new SqlCommand();

        public List<Aluno> ListarAlunos()
        {
            // Abrindo a conexão com o banco de dados
           _command.Connection = _conexao.Conectar();

            _command.CommandText = "SELECT * FROM aluno";

            SqlDataReader dados = _command.ExecuteReader();

            // Criando a lista com os alunos encontrados no banco
            List<Aluno> _listaAlunos = new List<Aluno>();

            while(dados.Read())
            {
                _listaAlunos.Add(

                    // Criando um novo aluno dentro da lista
                    new Aluno()
                    {
                        IdAluno = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        RA = dados.GetValue(2).ToString(),
                        Idade = Convert.ToInt32(dados.GetValue(3)),
                    }
                );
            }

            // Fechando a conexão com o banco de dados
            _conexao.Desconectar();

            return _listaAlunos;
        }

        public Aluno BuscarAluno(int _idAluno)
        {
            // Abrindo a conexão com o banco de dados
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "SELECT * FROM aluno WHERE IdAluno = @id";

            _command.Parameters.AddWithValue("@id", _idAluno);

            SqlDataReader dado = _command.ExecuteReader();

            Aluno _aluno = new Aluno();

            while(dado.Read())
            {
                _aluno.IdAluno = Convert.ToInt32(dado.GetValue(0));
                _aluno.Nome = dado.GetValue(1).ToString();
                _aluno.RA = dado.GetValue(2).ToString();
                _aluno.Idade = Convert.ToInt32(dado.GetValue(3));
            }

            // Fechando a conexão com o banco de dados
            _conexao.Desconectar();

            return _aluno;
        }

        public Aluno CadastrarAluno(Aluno _aluno)
        {
            // Abrindo a conexão com o banco de dados
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "INSERT INTO aluno (Nome, RA, Idade) VALUES " +
                "(@Nome, @RA, @Idade)";

            _command.Parameters.AddWithValue("@Nome", _aluno.Nome);
            _command.Parameters.AddWithValue("@RA", _aluno.RA);
            _command.Parameters.AddWithValue("@Idade", _aluno.Idade);

            // Definindo que a query definida não é uma consulta usual
            _command.ExecuteNonQuery();

            // Fechando a conexão com o banco de dados
            _conexao.Desconectar();

            return _aluno;
        }

        public Aluno AlterarAluno(Aluno _aluno, int _idAluno)

        {
            // Abrindo a conexão com o banco de dados
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "UPDATE aluno SET " +
                "Nome = @nome, RA = @ra, Idade = @idade " +
                "WHERE IdAluno = @id";

            _command.Parameters.AddWithValue("@id", _idAluno);
            _command.Parameters.AddWithValue("@nome", _aluno.Nome);
            _command.Parameters.AddWithValue("@ra", _aluno.RA);
            _command.Parameters.AddWithValue("@idade", _aluno.Idade);

            // Definindo que a query definida não é uma consulta usual
            _command.ExecuteNonQuery();


            // Fechando a conexão com o banco de dados
            _conexao.Desconectar();

            return _aluno;
        }

        public void ExcluirAluno(int _idAluno)
        {
            // Abrindo a conexão com o banco de dados
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "DELETE FROM aluno WHERE IdAluno = @id";

            _command.Parameters.AddWithValue("@id", _idAluno);
             
            // Definindo que a query definida não é uma consulta usual
            _command.ExecuteNonQuery();

            // Fechando a conexão com o banco de dados
            _conexao.Desconectar();
        }

    }
}
