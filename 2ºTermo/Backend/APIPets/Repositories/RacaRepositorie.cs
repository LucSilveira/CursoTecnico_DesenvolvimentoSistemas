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
    public class RacaRepositorie : IRaca
    {

        PetsContext _conexao = new PetsContext();

        SqlCommand _command = new SqlCommand();

        public List<Raca> ListarRacas()
        {
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = _command.ExecuteReader();

            List<Raca> _listaRacas = new List<Raca>();

            while(dados.Read())
            {
                _listaRacas.Add(

                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        NomeRaca = dados.GetValue(1).ToString(),
                        IdTipoRaca = Convert.ToInt32(dados.GetValue(2)),
                    }
                );
            }

            _conexao.Desconectar();

            return _listaRacas;
        }


        public Raca BuscarRaca(int _idRaca)
        {
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";

            _command.Parameters.AddWithValue("@id", _idRaca);

            SqlDataReader dado = _command.ExecuteReader();

            Raca _raca = new Raca();

            while (dado.Read())
            {
                _raca.IdRaca = Convert.ToInt32(dado.GetValue(0));
                _raca.NomeRaca = dado.GetValue(1).ToString();
                _raca.IdTipoRaca = Convert.ToInt32(dado.GetValue(2));
            }

            _conexao.Desconectar();

            return _raca;
        }

        public Raca CadastrarRaca(Raca _raca)
        {
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "INSERT INTO Raca (NomeRaca, IdTipoRaca) VALUES (@nomeRaca, @idTipo)";

            _command.Parameters.AddWithValue("@nomeRaca", _raca.NomeRaca);
            _command.Parameters.AddWithValue("@idTipo", _raca.IdTipoRaca);

            // Definindo que a instrução não é uma query
            _command.ExecuteNonQuery();

            return _raca;
        }

        public Raca AlterarRaca(Raca _raca, int _idRaca)
        {
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "UPDATE Raca SET NomeRaca = @nomeRaca, IdTipoRaca = @idTipo WHERE IdTipo = @id";

            _command.Parameters.AddWithValue("@id", _idRaca);
            _command.Parameters.AddWithValue("@nomeRaca", _raca.NomeRaca);
            _command.Parameters.AddWithValue("@idTipo", _raca.IdTipoRaca);

            _command.ExecuteNonQuery();

            _conexao.Desconectar();

            return _raca;
        }

        public void ExcluirRaca(int _idRaca)
        {
            _command.Connection = _conexao.Conectar();

            _command.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";

            _command.Parameters.AddWithValue("@id", _idRaca);

            _command.ExecuteNonQuery();

            _conexao.Desconectar();
        }
    }
}
