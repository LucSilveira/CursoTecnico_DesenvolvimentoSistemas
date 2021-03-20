using Carometro.Comum.Commands;
using Carometro.Comum.Enum;
using Carometro.Comum.Queries;
using Carometro.Dominio.Commands.Aluno;
using Carometro.Dominio.Handlers.Commands.Alunos;
using Carometro.Dominio.Handlers.Queries;
using Carometro.Dominio.Handlers.Queries.Alunos;
using Carometro.Dominio.Queries.Aluno;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Carometro.Api.Controllers
{
    [Route("v1/student")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public GenericQueryResult GetAll([FromServices] ListarAlunoQueryHandle handle)
        {
            ListarAlunoQuery query = new ListarAlunoQuery();

            var tipoAluno = HttpContext.User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.Role);

            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("search/rg/{value}")]
        [HttpGet]
        public GenericQueryResult GetSpecificStudentRg([FromServices] BuscarAlunoHandler _handle, string value)
        {
            BuscarAlunoQuery _query = new BuscarAlunoQuery(value);

            return (GenericQueryResult)_handle.Handle(_query);
        }

        [Route("search/id/{value}")]
        [HttpGet]
        [Authorize]
        public GenericQueryResult GetSpecificStudentId([FromServices] BuscarAlunoHandler _handle, Guid value)
        {
            BuscarAlunoQuery _query = new BuscarAlunoQuery(value);

            return (GenericQueryResult)_handle.Handle(_query);
        }

        [Route("signup")]
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult AddAluno(CadastrarAlunoCommand command, [FromServices] CadastrarAlunoHandler handle)
        {
            return(GenericCommandResult)handle.Handler(command);
        }

        [Route("update")]
        [HttpPut]
        [Authorize(Roles = "Administrador, Aluno")]
        public GenericCommandResult UpdateStudent(AlterarAlunoCommand command, [FromServices] AlterarAlunoHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("remove")]
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult DeleteStudent(ExcluirAlunoCommand command, [FromServices] ExcluirAlunoHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
