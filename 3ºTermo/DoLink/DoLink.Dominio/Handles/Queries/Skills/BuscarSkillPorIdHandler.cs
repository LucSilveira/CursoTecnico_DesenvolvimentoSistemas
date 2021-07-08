using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Skills;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoLink.Dominio.Handles.Queries.Skills
{
    public class BuscarSkillPorIdHandler : Notifiable, IHandlerQuery<BuscarSkillPorIdQuery>
    {
        //Instânciando a interface que contém os métodos
        public readonly ISkillRepository _repository;

        //Aplicando a injeção de dependência dentro da classe
        public BuscarSkillPorIdHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método para buscar uma skill específica 
        /// </summary>
        /// <param name="command">Dados a serem tradados para buscar uma skill</param>
        /// <returns>Dados de uma skill procurada</returns>
        public IQueryResult Handler(BuscarSkillPorIdQuery command)
        {
            //Validando dados informados
            command.Validate();

            var _skillExistente = _repository.BuscarSkillEspecifica(command.Id.ToString()).Result;

            if (_skillExistente == null)
            {
                return new GenericQueryResult(false, "Skill não encontrada", null);
            }

            var skillIdResult = new BuscarSkillResult
            {
                Id = _skillExistente.Id,
                Nome = _skillExistente.Nome
            };

            return new GenericQueryResult(true, "Dados da skill", skillIdResult);
        }
    }
}
