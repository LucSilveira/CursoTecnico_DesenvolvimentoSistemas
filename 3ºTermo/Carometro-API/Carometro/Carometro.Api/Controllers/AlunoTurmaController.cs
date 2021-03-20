using Carometro.Comum.Commands;
using Carometro.Comum.Queries;
using Carometro.Dominio.Handlers.Commands.AlunosTurmas;
using Carometro.Dominio.Handlers.Queries.AlunosTurmas;
using Carometro.Dominio.Commands.AlunoTurma;
using Carometro.Dominio.Queries.AlunoTurma;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carometro.Dominio.Commands.ProfessorTurma;

namespace Carometro.Api.Controllers
{
    [Route("v1/student/class")]
    [ApiController]
    public class AlunoTurmaController : ControllerBase
    {
        [HttpGet]
        public GenericQueryResult GetAllStudentClass([FromServices] ListarAlunosTurmasHandler handle)
        {
            ListarAlunosTurmasQuery query = new ListarAlunosTurmasQuery();
            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("get/students/{value}")]
        [HttpGet]
        public GenericQueryResult GetAllStudentsClass([FromServices] ListarAlunosDaTurmaHandler handle, Guid value)
        {
            ListarAlunosDaTurmaQuery query = new ListarAlunosDaTurmaQuery(value);
            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("get/classes/{value}")]
        [HttpGet]
        public GenericQueryResult GetAllClassesStudent([FromServices] ListarTurmasDoAlunoHandler handle, Guid value)
        {
            ListarTurmasDoAlunoQuery query = new ListarTurmasDoAlunoQuery(value);
            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("search/id/{value}")]
        [HttpGet]
        public GenericQueryResult GetSpecificStudentClass([FromServices] BuscarAlunoTurmaHandler handle, Guid value)
        {
            BuscarAlunoTurmaQuery query = new BuscarAlunoTurmaQuery(value);
            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("insert")]
        [HttpPost]
        public GenericCommandResult InsertStudentInClass(CadastrarAlunoTurmaCommand command, [FromServices] CadastrarAlunoTurmaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("update")]
        [HttpPut]
        public GenericCommandResult UpdateStudentInClass(AlterarAlunoTurmaCommand command, [FromServices] AlterarAlunoTurmaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("remove")]
        [HttpDelete]
        public GenericCommandResult DeleteStudentInClass(ExcluirAlunoTurmaCommand command, [FromServices] ExcluirAlunoTurmaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
