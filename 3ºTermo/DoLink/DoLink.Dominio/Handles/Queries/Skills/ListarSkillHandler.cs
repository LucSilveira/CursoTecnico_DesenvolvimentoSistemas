using DoLink.Comum.Handlers.Contracts;
using DoLink.Comum.Queries;
using DoLink.Dominio.Queries.Skills;
using DoLink.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoLink.Dominio.Handles.Commands.Skills
{
    public class ListarSkillHandler : Notifiable, IHandlerQuery<ListarSkillQuery>
    {
        //Instânciando a interface que contém os métodos
        public readonly ISkillRepository _repository;

        //Aplicando a injeção de dependência dentro da classe
        public ListarSkillHandler(ISkillRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método para listar as skills cadastradas na aplicação
        /// </summary>
        /// <returns>Lista com as skills cadastradas</returns>
        public IQueryResult Handler(ListarSkillQuery command)
        {
            //Buscando no banco de dados as skills
            var _query = _repository.ListarSkills();
            
            //Verificando se não há skills cadastradas, caso não haja retornamos uma notificação
            if(_query == null)
            {
                return new GenericQueryResult(true, "Nenhuma skill foi cadastrada", null);
            }

            //Criando a mascara para cada objeto da lista, para retornar apenas os dados necessários
            var skills = _query.Result.Select(skl =>
            {
                return new ListarSkillsResult()
                {
                    Id = skl.Id,
                    Nome = skl.Nome,
                    hash = skl.Hash
                };
            });

            //Retornando com sucesso a lista de skills cadastradas
            return new GenericQueryResult(true, "Lista de skills", skills);
        }
    }
}
