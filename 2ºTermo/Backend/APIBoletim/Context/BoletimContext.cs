using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Context
{
    public class BoletimContext
    {
        // Instanciando a conexão com o banco de dados
        SqlConnection _connection = new SqlConnection();

        public BoletimContext()
        {
            _connection.ConnectionString = @"Data Source=LAPTOP-39CJ3N8P\SQLEXPRESS;Initial Catalog=boletim;User ID=sa;Password=sa132;";
        }

        // Verificando se a conexão do banco está fechada e depois a abre
        public SqlConnection Conectar()
        {
            if(_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }

            return _connection;
        }

        // Verificando se a conexão está aberta e depois a fecha
        public void Desconectar()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
