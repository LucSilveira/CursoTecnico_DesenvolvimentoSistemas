using Carometro.Comum.Commands;
using Carometro.Comum.Queries;
using Carometro.Dominio.Commands.ProfessorTurma;
using Carometro.Dominio.Handlers.Commands.ProssoresTurmas;
using Carometro.Dominio.Handlers.Queries.ProfessoresTurmas;
using Carometro.Dominio.Queries.ProfessorTurma;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carometro.Api.Controllers
{
    [Route("v1/teacher/class")]
    [ApiController]
    public class ProfessorTurmaController : ControllerBase
    {
        [HttpGet]
        public GenericQueryResult GetAllStudentClass([FromServices] ListarProfessoresTurmasHandler handle)
        {
            ListarProfessoresTurmasQuery query = new ListarProfessoresTurmasQuery();
            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("get/students/{value}")]
        [HttpGet]
        public GenericQueryResult GetAllStudentsClass([FromServices] ListarProfessoresDaTurmaHandler handle, Guid value)
        {
            ListarProfessoresDaTurmaQuery query = new ListarProfessoresDaTurmaQuery(value);
            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("get/classes/{value}")]
        [HttpGet]
        public GenericQueryResult GetAllClassesStudent([FromServices] ListarTurmasDoProfessorHandler handle, Guid value)
        {
            ListarTurmasDoProfessorQuery query = new ListarTurmasDoProfessorQuery(value);
            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("search/id/{value}")]
        [HttpGet]
        public GenericQueryResult GetSpecificStudentClass([FromServices] BuscarProfessorTurmaHandler handle, Guid value)
        {
            BuscarProfessorTurmaQuery query = new BuscarProfessorTurmaQuery(value);
            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("insert")]
        [HttpPost]
        public GenericCommandResult InsertStudentInClass(CadastrarProfessorTurmaCommand command, [FromServices] CadastrarProfessorTurmaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("update")]
        [HttpPut]
        public GenericCommandResult UpdateStudentInClass(AlterarProfessorTurmaCommand command, [FromServices] AlterarProfessorTurmaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("remove")]
        [HttpDelete]
        public GenericCommandResult DeleteStudentInClass(ExcluirProfessorTurmaCommand command, [FromServices] ExcluirProfessorTurmaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
