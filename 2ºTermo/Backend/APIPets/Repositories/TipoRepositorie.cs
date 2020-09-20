using APIPets.Context;
using APIPets.Domains;
using APIPets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Repositories
{
    public class TipoRepositorie : ITipo
    {
        // Chamando o PetsContext para fazer o conexão com o banco
        PetsContext _conexao = new PetsContext();

        // Responsável por colocar comando do Sql na aplicação
        SqlCommand _command = new SqlCommand();

        public List<Tipo> ListaTipos()
        {
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "SELECT * FROM Tipo";

            SqlDataReader dados = _command.ExecuteReader();

            List<Tipo> _listaTipos = new List<Tipo>();

            while(dados.Read())
            {
                _listaTipos.Add(

                    //Criando um novo tipo dentro da lista
                    new Tipo()
                    {
                        IdTipo = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                );
            }

            _conexao.Desconectar();

            return _listaTipos;
        }

        public Tipo ListarTipo(int _idTipo)
        {
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "SELECT * FROM Tipo WHERE IdTipo = @id";

            _command.Parameters.AddWithValue("@id", _idTipo);

            SqlDataReader dado = _command.ExecuteReader();

            Tipo _tipo = new Tipo();

            while(dado.Read())
            {
                _tipo.IdTipo = Convert.ToInt32(dado.GetValue(0));
                _tipo.Descricao = dado.GetValue(1).ToString();
            }

            _conexao.Desconectar();

            return _tipo;
        }

        public Tipo CadastrarTipo(Tipo _tipo)
        {
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "INSERT INTO Tipo (Descricao) VALUES (@descricao)";

            _command.Parameters.AddWithValue("@descricao", _tipo.Descricao);

            // Definindo que a instrução não é uma query
            _command.ExecuteNonQuery();

            return _tipo;
        }

        public Tipo AlterarTipo(Tipo _tipo, int _idTipo)
        {
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "UPDATE Tipo SET Descricao = @descricao WHERE IdTipo = @id";

            _command.Parameters.AddWithValue("@id", _idTipo);
            _command.Parameters.AddWithValue("@descricao", _tipo.Descricao);

            _command.ExecuteNonQuery();

            _conexao.Desconectar();

            return _tipo;
        }

        public void ExcluirTipo(int _idTipo)
        {
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "DELETE FROM Tipo WHERE IdTipo = @id";

            _command.Parameters.AddWithValue("@id", _idTipo);

            _command.ExecuteNonQuery();

            _conexao.Desconectar();
        }

    }
}
