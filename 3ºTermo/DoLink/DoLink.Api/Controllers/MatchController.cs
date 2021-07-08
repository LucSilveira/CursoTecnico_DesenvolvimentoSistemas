using DoLink.Comum.Queries;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Matchs;
using DoLink.Dominio.Handles.Commands.Matchs;
using DoLink.Dominio.Handles.Queries.Matchs;
using DoLink.Dominio.Queries.Matchs;
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
    [Route("v1/match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        //Instânciando os métodos contidos no repositório
        public readonly IMatchRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public MatchController(IMatchRepository repository)
        {
            _repository = repository;
        }

        [Route("search/{match}")]
        [HttpGet]
        public GenericQueryResult SearchSpecificMatchs([FromServices] BuscarMatchHandler handle, string match)
        {
            BuscarMatchQuery _query = new BuscarMatchQuery(match);
            return (GenericQueryResult)handle.Handler(_query);
        }

        [Authorize(Roles = "Profissional")]
        [HttpPost]
        public GenericCommandResult ConfirmMatch(CadastrarMatchCommand command, [FromServices] CadastrarMatchHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("remove/{match}")]
        [HttpDelete]
        public GenericCommandResult RemoveMatch(ExcluirMatchCommand command, [FromServices] ExcluirMatchHandler handle, string match)
        {
            command.Id = match;
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
