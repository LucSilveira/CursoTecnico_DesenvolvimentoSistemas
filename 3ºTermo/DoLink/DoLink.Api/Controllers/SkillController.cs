using DoLink.Comum.Queries;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Skill;
using DoLink.Dominio.Commands.Skills;
using DoLink.Dominio.Handles.Commands.Skills;
using DoLink.Dominio.Handles.Queries.Skills;
using DoLink.Dominio.Queries.Skills;
using DoLink.Dominio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoLink.Api.Controllers
{
    [Authorize]
    [Route("v1/skills")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        //Instânciando os métodos contidos no repositório
        public readonly ISkillRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public SkillController(ISkillRepository _empresaRepository)
        {
            _repository = _empresaRepository;
        }

        /// <summary>
        /// Método para listar as skills existente
        /// </summary>
        /// <param name="command">Dados para a listagem de uma skill</param>
        /// <param name="handle">Tratativa dos dados para listagem do mesmo</param>
        /// <returns>Listas cerca das skills</returns>
        [HttpGet]
        public GenericQueryResult ListAllSkills([FromServices] ListarSkillHandler handle)
        {
            ListarSkillQuery _query = new ListarSkillQuery();

            return (GenericQueryResult)handle.Handler(_query);
        }

        /// <summary>
        /// Método para buscar uma skill existente
        /// </summary>
        /// <param name="command">Dados para a busca de uma skill</param>
        /// <param name="handle">Tratativa dos dados para localização do mesmo</param>
        /// <returns>Dados a cerca da skill procurada</returns>
        [Route("search/name/{skill}")]
        [HttpGet]
        public GenericQueryResult GetSpecific([FromServices] BuscarSkillHandler handle, string skill)
        {
            BuscarSkillQuery _query = new BuscarSkillQuery(skill);

            return (GenericQueryResult)handle.Handler(_query);
        }

        /// <summary>
        /// Método para buscar uma skill existente
        /// </summary>
        /// <param name="command">Dados para a busca de uma skill</param>
        /// <param name="handle">Tratativa dos dados para localização do mesmo</param>
        /// <returns>Dados a cerca da skill procurada</returns>
        [Route("search/id/{skill}")]
        [HttpGet]
        public GenericQueryResult GetSpecificById([FromServices] BuscarSkillPorIdHandler handle, string skill)
        {
            BuscarSkillPorIdQuery _query = new BuscarSkillPorIdQuery(skill);

            return (GenericQueryResult)handle.Handler(_query);
        }

        /// <summary>
        /// Método que Cadastra uma nova skill na aplicação.
        /// </summary>
        /// <param name="command">Dados para criação da skill</param>
        /// <param name="handle">Tratativa dos dados para criação do mesmo</param>
        /// <returns>Dados acerca da skill</returns>
        [Authorize(Roles = "Administrador")]
        [Route("create")]
        [HttpPost]
        public GenericCommandResult CrateSkill(CadastrarSkillCommand command, [FromServices] CadastrarSkillHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método para alterar uma skill existente
        /// </summary>
        /// <param name="command">Dados para a alteração de uma skill</param>
        /// <param name="handle">Tratativa dos dados para alteração do mesmo</param>
        /// <returns>Dados a cerca da skill alterada</returns>
        [Authorize(Roles = "Administrador")]
        [Route("update")]
        [HttpPut]
        public GenericCommandResult UpdateSkill(AlterarSkillCommand command, [FromServices] AlterarSkillHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método para excluir uma skill existente
        /// </summary>
        /// <param name="command">Dados para a exclusão de uma skill</param>
        /// <param name="handle">Tratativa dos dados para exclusão do mesmo</param>
        /// <returns>Dados a cerca da skill excluida</returns>
        [Authorize(Roles = "Administrador")]
        [Route("delete")]
        [HttpDelete]
        public GenericCommandResult RemoveSkill(ExcluirSkillCommand command, [FromServices] ExcluirSkillHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
