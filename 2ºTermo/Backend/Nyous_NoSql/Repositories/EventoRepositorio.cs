using MongoDB.Driver;
using Nyous_NoSql.Contexts;
using Nyous_NoSql.Domains;
using Nyous_NoSql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous_NoSql.Repositories
{
    public class EventoRepositorio : IEventoRepository
    {
        private readonly IMongoCollection<EventoDomain> _eventos;

        public EventoRepositorio(INyousDatabaseSettings settings)
        {
            //definindo qual é a conexão com o banco
            var client = new MongoClient(settings.ConnectionString);

            //definindo qual o banco de dados desejado
            var database = client.GetDatabase(settings.DatabaseName);

            //definindo qual a collection (tabela) que utilizaremos
            _eventos = database.GetCollection<EventoDomain>(settings.EventosCollectionName);
        }

        public void AdicionarEvento(EventoDomain evento)
        {
            try
            {
                _eventos.InsertOne(evento);

            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public void AtualizarEvento(string id, EventoDomain evento)
        {
            try
            {
                _eventos.ReplaceOne(c => c.Id == id, evento);
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public EventoDomain BuscarPorId(string id)
        {
            try
            {
                return _eventos.Find<EventoDomain>(e => e.Id == id).First();
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public List<EventoDomain> ListarEventos()
        {
            try
            {
                return _eventos.AsQueryable<EventoDomain>().ToList();

            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public void RemoverEvento(string id)
        {
            try
            {
                _eventos.Find<EventoDomain>(e => e.Id == id).First();

                _eventos.DeleteOne(c => c.Id == id);
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }
    }
}
