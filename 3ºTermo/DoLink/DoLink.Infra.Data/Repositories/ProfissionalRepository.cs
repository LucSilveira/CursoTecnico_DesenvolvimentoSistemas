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
    public class ProfissionalRepository : IProfissionalRepository
    {
        //Criando objeto de referência da entidade para o banco
        private readonly IMongoCollection<Profissional> _context;

        //Configurando a conexão com o banco de dados e a collection
        public ProfissionalRepository(IDoLinkDatabaseSettings _settings)
        {
            //Criando a conexão com o banco de dados
            var _client = new MongoClient(_settings.ConnectionString);

            //Definindo qual o banco de dados que utilizaremos
            var _database = _client.GetDatabase(_settings.DatabaseName);

            //Pegando a referência da Collection desejada
            _context = _database.GetCollection<Profissional>("Profissional");
        }

        // <summary>
        /// Método para listar os profissionais cadastrados
        /// </summary>
        /// <returns>Lista com os profissionais</returns>
        public async Task<List<Profissional>> ListarProfissional()
        {
            try
            {
                return await _context.AsQueryable<Profissional>().ToListAsync();
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Método para buscar um profissional pelo nome
        /// </summary>
        /// <param name="_id">Nome do profissional</param>
        /// <returns>Dados referente a um profissional procurado</returns>
        public async Task<Profissional> BuscarProfissional(string _cpfProfissional)
        {
            try
            {
                var profissional = await _context.FindSync<Profissional>(pfs => pfs.CPF.ToLower() == _cpfProfissional.ToLower()).FirstOrDefaultAsync();
                return (Profissional)profissional;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Método para buscar um profissional através de seu email
        /// </summary>
        /// <param name="_emailProfissional">Email do profissional</param>
        /// <returns>Dados a cerca do profissional procurado</returns>
        public async Task<Profissional> BuscarEmailProfissional(string _emailProfissional)
        {
            try
            {
                var profissional = await _context.Find<Profissional>(pfs => pfs.Email.ToLower() == _emailProfissional.ToLower()).FirstOrDefaultAsync();

                return profissional;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Método para buscar o código específico de um profissional
        /// </summary>
        /// <param name="_id">Código de identificação de um profissional</param>
        /// <returns>Dados referente ao prossional procurado</returns>
        public async Task<Profissional> BuscarProfissionalEspecifico(string _idProfissional)
        {
            try
            {
                var profissional = await _context.FindSync<Profissional>(pfs => pfs.Id == _idProfissional).FirstOrDefaultAsync();
                return (Profissional)profissional;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        /// <summary>
        /// Método para cadastrar um novo profissional
        /// </summary>
        /// <param name="_profissional">Dados a serem inseridos</param>
        /// <returns>novo profissional cadastrado</returns>
        public async Task<Profissional> CadastrarProfissional(Profissional _profissional)
        {
            try
            {
                await _context.InsertOneAsync(_profissional);
                return _profissional;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        /// <summary>
        /// Método para alterar os dados de um profissional
        /// </summary>
        /// <param name="_profissional"></param>
        /// <returns></returns>
        public async Task<Profissional> AlterarProfissional(Profissional _profissional)
        {
            try
            {
                await _context.ReplaceOneAsync(pfs => pfs.Id == _profissional.Id, _profissional);

                return _profissional;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        /// <summary>
        /// Método para excluir um profissional cadastrado
        /// </summary>
        /// <param name="_profissional">Dados do profissional</param>
        /// <returns>Dados do profissional deletado</returns>
        public async Task<Profissional> ExcluirProfissional(Profissional _profissional)
        {
            try
            {
                await _context.FindAsync<Profissional>(pfs => pfs.Id == _profissional.Id);

                await _context.DeleteOneAsync(c => c.Id == _profissional.Id);

                return _profissional;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }
    }
}
