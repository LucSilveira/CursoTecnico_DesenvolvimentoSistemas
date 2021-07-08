using DoLink.Comum.Enum;
using DoLink.Dominio.Entidades;
using DoLink.Dominio.Repositories;
using DoLink.Infra.Data.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoLink.Infra.Data.Repositories
{
    public class VagaRepository : IVagaRepository
    {
        private readonly IMongoCollection<Vaga> _context;

        public VagaRepository(IDoLinkDatabaseSettings _settings)
        {
            //Criando a conexão com o banco de dados
            var _client = new MongoClient(_settings.ConnectionString);

            //Definindo qual o banco de dados que utilizaremos
            var _database = _client.GetDatabase(_settings.DatabaseName);

            //Pegando a referência da Collection desejada
            _context = _database.GetCollection<Vaga>("Vaga");
        }


        public async Task<List<Vaga>> ListarVaga()
        {
            try
            {
                return _context.AsQueryable().ToList();

            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<List<Vaga>> ListarVagaEmpresa(string _idEmpresa)
        {
            try
            {
                return _context.AsQueryable().Where(vg => vg.IdEmpresa == _idEmpresa).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<Vaga>> ListarVagaPorStatus(EnStatusVaga status)
        {
            try
            {
                return _context.AsQueryable().Where(vg => vg.Status == status).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<Vaga>> Prematch(Profissional _profissional)
        {
            try
            {
                List<Vaga> _listVagas = new List<Vaga>();
                var context = new List<Vaga>();

                context = _context.AsQueryable<Vaga>().Where(vg => vg.Status == EnStatusVaga.Padrao).ToList(); //.Where(x => _profissional.Hash.Contains(x.HashRequeridas))

                foreach(Vaga vaga in context)
                {
                    var hashRequeridas = vaga.HashRequeridas.Split('|');
                    int contador = 0;

                    for(int i = 0; i < hashRequeridas.Length - 1; i++)
                    {
                        if (_profissional.Hash.Contains(hashRequeridas[i]))
                        {
                            contador++;
                        }
                    }

                    if(contador == hashRequeridas.Length - 1)
                    {
                        _listVagas.Add(vaga);
                    }
                }

                return _listVagas;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }
        
        public async Task<Vaga> BuscarDadosVaga(string _idVaga)
        {
            try
            {
                return await _context.FindSync(x => x.Id == _idVaga).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Vaga>> BuscarPorTitulo(string titulo)
        {
            try
            {
                return _context.AsQueryable().Where(vg => vg.Titulo == titulo).ToList();
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<Vaga> CadastrarVaga(Vaga _vaga)
        {
            try
            {
                await _context.InsertOneAsync(_vaga);

                return _vaga;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            };
        }

        public async Task<Vaga> AlterarVagaRepositorie(string id, Vaga _vaga)
        {
            try
            {
                await _context.ReplaceOneAsync(x => x.Id == id, _vaga);
                return _vaga;
            }
            catch (Exception _e)
            {
                throw new Exception(_e.Message);
            }
        }

        public async Task<Vaga> ExcluirVaga(Vaga vaga)
        {
            try
            {
                await _context.DeleteOneAsync(x => x.Id == vaga.Id);
                return vaga;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }
    }
}
