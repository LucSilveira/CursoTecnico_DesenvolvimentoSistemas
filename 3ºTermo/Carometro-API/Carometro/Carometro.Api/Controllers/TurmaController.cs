using Carometro.Comum.Commands;
using Carometro.Comum.Queries;
using Carometro.Dominio.Commands.Turma;
using Carometro.Dominio.Handlers.Commands.Turmas;
using Carometro.Dominio.Handlers.Queries.Turmas;
using Carometro.Dominio.Queries.Turma;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carometro.Api.Controllers
{
    [Route("v1/class")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        [HttpGet]
        public GenericQueryResult GetAllClasses([FromServices] ListarTurmasHandler handle)
        {
            ListaTurmaQuery _query = new ListaTurmaQuery();

            return (GenericQueryResult)handle.Handle(_query);
        }

        [Route("search/{id}")]
        [HttpGet]
        public GenericQueryResult GetSpecificClass(Guid id, [FromServices] BuscarTurmaHandler handle)
        {
            BuscarTurmaQuery query = new BuscarTurmaQuery(id);
            return (GenericQueryResult)handle.Handle(query);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult CreateNewClass(CadastrarTurmaCommand command, [FromServices] CadastrarTurmaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("update")]
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult  UpdateClass(AlterarTurmaCommand command, [FromServices] AlterarTurmaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("remove")]
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult DeleteClass(ExcluirTurmaCommand command, [FromServices] ExcluirTurmaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
