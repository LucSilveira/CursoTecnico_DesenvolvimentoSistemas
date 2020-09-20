using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Context
{
    public class PetsContext
    {
        // Instância do contexto com o banco de dados
        SqlConnection _connection = new SqlConnection();

        public PetsContext()
        {
            _connection.ConnectionString = @"Data Source= DESKTOP-E34QQ0G\SQLEXPRESS;Initial Catalog=clinicaPets;User ID=sa;Password=sa132";

        }

        public SqlConnection Conectar()
        {
            if(_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }

        public void Desconectar()
        {
            if(_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
