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
    public class SkillRepository : ISkillRepository
    {
        //Criando objeto de referência da entidade para o banco
        private readonly IMongoCollection<Skill> _context;

        //Configurando a conexão com o banco de dados e a collection
        public SkillRepository(IDoLinkDatabaseSettings _settings)
        {
            //Criando a conexão com o banco de dados
            var _client = new MongoClient(_settings.ConnectionString);

            //Definindo qual o banco de dados que utilizaremos
            var _database = _client.GetDatabase(_settings.DatabaseName);

            //Pegando a referência da Collection desejada
            _context = _database.GetCollection<Skill>("Skill");
        }

        /// <summary>
        /// Método para listar as skills cadastradas
        /// </summary>
        /// <returns>Lista com as skills</returns>
        public async Task<List<Skill>> ListarSkills()
        {
            try
            {
                var skills = await _context.AsQueryable<Skill>().ToListAsync();

                return skills;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Método para buscar o código específico de uma skill
        /// </summary>
        /// <param name="_id">Código de identificação de uma skill</param>
        /// <returns>Dados referente a uma skill referente</returns>
        public async Task<Skill> BuscarSkillEspecifica(string _id)
        {
            try
            {
                var skill = await _context.FindSync<Skill>(skl => skl.Id == _id).FirstOrDefaultAsync();
                return (Skill)skill;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma skill específica
        /// </summary>
        /// <returns>Dados acerca da skill</returns>
        public async Task<Skill> BuscarSkill(string _nomeSkill)
        {
            try
            {
                var skill = await _context.Find<Skill>(skl => skl.Nome.ToLower() == _nomeSkill.ToLower()).FirstOrDefaultAsync();
                return (Skill)skill;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Método para cadastrar uma nova skill
        /// </summary>
        /// <param name="_skill">Dados a serem inseridos</param>
        /// <returns>Nova skill cadastrada</returns>
        public async Task<Skill> CadastrarSkill(Skill _skill)
        {
            try
            {
                await _context.InsertOneAsync(_skill);

                return _skill;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        /// <summary>
        /// Método para poder alterar o nome da skill desejada
        /// </summary>
        /// <returns>Dados da skill alterada</returns>
        public async Task<Skill> AlterarSkill(Skill _skill)
        {
            try
            {
                await _context.ReplaceOneAsync(skl => skl.Id == _skill.Id, _skill);

                return _skill;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        /// <summary>
        /// Método para excluir uma skill existente
        /// </summary>
        /// <param name="_skill">Dados da skill desejada</param>
        /// <returns>Dados excluidos</returns>
        public async Task<Skill> DeletarSkill(Skill _skill)
        {
            try
            {
                await _context.FindAsync<Skill>(skl => skl.Id == _skill.Id);

                await _context.DeleteOneAsync(c => c.Id == _skill.Id);

                return _skill;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }
    }
}
