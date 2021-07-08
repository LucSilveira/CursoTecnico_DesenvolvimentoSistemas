using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using DoLink.Infra.Data.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoLink.Infra.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        //Criando objeto de referência da entidade para o banco
        private readonly IMongoCollection<Administrador> _context;

        //Configurando a conexão com o banco de dados e a collection
        public AdminRepository(IDoLinkDatabaseSettings _settings)
        {
            //Criando a conexão com o banco de dados
            var _client = new MongoClient(_settings.ConnectionString);

            //Definindo qual o banco de dados que utilizaremos
            var _database = _client.GetDatabase(_settings.DatabaseName);

            //Pegando a referência da Collection desejada
            _context = _database.GetCollection<Administrador>("Usuario");
        }

        public async Task<Administrador> AlterarSenhaAdmin(Administrador admin)
        {
            try
            {
                await _context.ReplaceOneAsync(adm => adm.Id == admin.Id, admin);

                return admin;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<Administrador> BuscarAdmin(string _email)
        {
            try
            {
                var admin = await _context.Find<Administrador>(adm => adm.Email.ToLower() == _email.ToLower()).FirstOrDefaultAsync();

                return admin;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }
    }
}
