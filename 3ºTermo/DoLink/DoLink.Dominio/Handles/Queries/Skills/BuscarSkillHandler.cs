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
    public class BuscarSkillHandler : Notifiable, IHandlerQuery<BuscarSkillQuery>
    {
        //Instânciando a interface que contém os métodos
        public readonly ISkillRepository _repository;

        //Aplicando a injeção de dependência dentro da classe
        public BuscarSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método para buscar uma skill específica 
        /// </summary>
        /// <param name="command">Dados a serem tradados para buscar uma skill</param>
        /// <returns>Dados de uma skill procurada</returns>
        public IQueryResult Handler(BuscarSkillQuery command)
        {
            //Validando dados informados
            command.Validate();

            //Verificando se o nome corresponde as especifícações
            if (command.Invalid)
            {
                return new GenericQueryResult(false, "Dados inválidos", command.Notifications);
            }

            //Consultando se a skill está cadastrada no banco de dados
            var skillExistente = _repository.BuscarSkill(command.Nome).Result;

            //Caso não exista retornamos a mensagem de erro
            if(skillExistente == null)
            {
                return new GenericQueryResult(false, "Skill não encontrada", null);
            }

            //Criamos a mascará para mostrar apenas os dados necessários
            var skillNameResult = new BuscarSkillResult
            {
                Id = skillExistente.Id,
                Nome = skillExistente.Nome
            };

            //Retornamos a skill procurada com sucesso
            return new GenericQueryResult(true, "Dados da skill", skillNameResult);
        }
    }
}
