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
    public class MatchRepository : IMatchRepository
    {
        //Criando objeto de referência da entidade para o banco
        private readonly IMongoCollection<Match> _context;

        //Configurando a conexão com o banco de dados e a collection
        public MatchRepository(IDoLinkDatabaseSettings _settings)
        {
            //Criando a conexão com o banco de dados
            var _client = new MongoClient(_settings.ConnectionString);

            //Definindo qual o banco de dados que utilizaremos
            var _database = _client.GetDatabase(_settings.DatabaseName);

            //Pegando a referência da Collection desejada
            _context = _database.GetCollection<Match>("Match");
        }

        public async Task<List<Match>> ListaDeMatchsProfissional(string _idProfissional)
        {
            try
            {
                return _context.AsQueryable().Where(vg => vg.IdProfissional == _idProfissional).ToList();
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<List<Match>> ListaDeMatchsVaga(string _idVaga)
        {
            try
            {
                return _context.AsQueryable().Where(vg => vg.IdVaga == _idVaga).OrderByDescending(x => x.NivelAcesso).ToList();
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<Match> BuscarMatch(string _idProfissional, string _idVaga)
        {
            try
            {
                var match = await _context.FindSync<Match>(mt => mt.IdProfissional == _idProfissional && mt.IdVaga == _idVaga).FirstOrDefaultAsync();

                return (Match)match;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<Match> BuscarMatchEspecifico(string _idMatch)
        {
            try
            {
                var match = await _context.FindSync<Match>(mt => mt.Id == _idMatch).FirstOrDefaultAsync();

                return (Match)match;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<Match> CadastrarMatch(Match _match)
        {
            try
            {
                await _context.InsertOneAsync(_match);

                return _match;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Match> ExcluirMatch(Match _match)
        {
            try
            {
                await _context.DeleteOneAsync(x => x.Id == _match.Id);

                return _match;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<Match> BuscarMatchPorVaga(string _idVaga)
        {
            try
            {
                var match = await _context.FindSync<Match>(x => x.IdVaga == _idVaga).FirstOrDefaultAsync();

                return (Match)match;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public async Task<Match> BuscarMatchPorProfissional(string _idProfissional)
        {
            try
            {
                var match = await _context.FindSync<Match>(x => x.IdProfissional == _idProfissional).FirstOrDefaultAsync();

                return (Match)match;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public int VerificarNivelPreferencia(Profissional profissional, Vaga vaga)
        {
            try
            {
                int nivel = 0;

                if(vaga.HashDesejaveis != null)
                {
                    var hashDesejadas = vaga.HashDesejaveis.Split('|');

                    int contador = 0;

                    for (int i = 0; i < hashDesejadas.Length - 1; i++)
                    {
                        if (profissional.Hash.Contains(hashDesejadas[i]))
                        {
                            contador++;
                        }
                    }

                    if (contador == hashDesejadas.Length - 1)
                    {
                        nivel = 2;
                    }
                }

                if (nivel == 2 && profissional.FaixaSalarial == vaga.FaixaSalarial)
                {
                    nivel = 3;
                }

                if (nivel == 0 && profissional.FaixaSalarial == vaga.FaixaSalarial)
                {
                    nivel = 1;
                }

                return nivel;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }
    }
}
