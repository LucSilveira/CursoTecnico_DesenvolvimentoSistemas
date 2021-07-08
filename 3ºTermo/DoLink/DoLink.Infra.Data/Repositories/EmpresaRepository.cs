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
    public class EmpresaRepository : IEmpresaRepository
    {
        //Criando objeto de referência da entidade para o banco
        private readonly IMongoCollection<Empresa> _context;

        public EmpresaRepository(IDoLinkDatabaseSettings _settings)
        {
            //Criando a conexão com o banco de dados
            var _client = new MongoClient(_settings.ConnectionString);

            //Definindo qual o banco de dados que utilizaremos
            var _database = _client.GetDatabase(_settings.DatabaseName);

            //Pegando a referência da Collection desejada
            _context = _database.GetCollection<Empresa>("Empresa");
        }

        public async Task<List<Empresa>> ListarEmpresa()
        {
            try
            {
                return  await _context.AsQueryable().ToListAsync();

            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<Empresa> BuscarDadosEmpresa(string _idEmpresa)
        {
            try
            {
                return  await _context.FindSync(x => x.Id == _idEmpresa).FirstOrDefaultAsync();

            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<Empresa> CadastrarEmpresa(Empresa _empresa)
        {
            try
            {
                await _context.InsertOneAsync(_empresa);

                return _empresa;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<Empresa> AlterarEmpresaRepositorie(string id,Empresa _empresa)
        {
            try
            {
                 await _context.ReplaceOneAsync(x => x.Id == id, _empresa);
                return _empresa;
            }
            catch (Exception _e)
            {
                throw new Exception(_e.Message);
            }
        }

        public async Task<Empresa> ExcluirEmpresa(Empresa empresa)
        {
            try
            {
                await _context.DeleteOneAsync(x => x.Id == empresa.Id);
                return empresa;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
            
        }

        public async Task<Empresa> BuscarPorEmail(string email)
        {
            try
            {
                return await _context.FindSync(x => x.Email == email).FirstOrDefaultAsync();

            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<Empresa> BuscarEmpresaPorCpnj(string _cnpj)
        {
            try
            {
                return await _context.FindSync(em => em.CNPJ == _cnpj).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
