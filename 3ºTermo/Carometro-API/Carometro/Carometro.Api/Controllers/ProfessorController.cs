using Carometro.Comum.Commands;
using Carometro.Comum.Queries;
using Carometro.Dominio.Commands.Professor;
using Carometro.Dominio.Handlers.Commands.Professores;
using Carometro.Dominio.Handlers.Queries.Professores;
using Carometro.Dominio.Queries.Professor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Carometro.Api.Controllers
{
    [Route("v1/teacher")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public GenericQueryResult GetAllTeachers([FromServices] ListarProfessorHandler _handle)
        {
            ListarProfessorQuery _query = new ListarProfessorQuery();

            return (GenericQueryResult)_handle.Handle(_query);
        }

        [Route("search/email/{value}")]
        [HttpGet]
        [Authorize]
        public GenericQueryResult GetSpecificTeacherEmail([FromServices] BuscarProfessorHandler _handle, string value)
        {
            BuscarProfessorQuery _query = new BuscarProfessorQuery(value);

            return (GenericQueryResult)_handle.Handle(_query);
        }

        [Route("search/id/{value}")]
        [HttpGet]
        [Authorize]
        public GenericQueryResult GetSpecificTeacherId([FromServices] BuscarProfessorHandler _handle, Guid value)
        {
            BuscarProfessorQuery _query = new BuscarProfessorQuery(value);

            return (GenericQueryResult)_handle.Handle(_query);
        }

        [Route("signup")]
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult AddTeacher(CadastrarProfessorCommand command, [FromServices] CadastrarProfessorHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("update")]
        [HttpPut]
        [Authorize(Roles = "Administrador, Professor")]
        public GenericCommandResult UpdateTeacher(AlterarProfessorCommand command, [FromServices] AlterarProfessorHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("remove")]
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult DeleteTeacher(ExcluirProfessorCommand command, [FromServices] ExcluirProfessorHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
