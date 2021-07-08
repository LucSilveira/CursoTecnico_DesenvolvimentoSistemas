using DoLink.Comum.Queries;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Vaga;
using DoLink.Dominio.Commands.Vagas;
using DoLink.Dominio.Handles.Commands.Vagas;
using DoLink.Dominio.Handles.Queries.Vagas;
using DoLink.Dominio.Queries.Vagas;
using DoLink.Dominio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DoLink.Api.Controllers
{
    [Authorize]
    [Route("v1/vagancy")]
    [ApiController]
    public class VagaController : ControllerBase
    {
        public readonly IVagaRepository _vagaRepository;

        public VagaController(IVagaRepository _repository)
        {
            _vagaRepository = _repository;
        }

        /// <summary>
        /// Método para listar todas as vagas cadastradas no sistema
        /// </summary>
        /// <returns>Lista com as vagas cadastradas</returns>
        [HttpGet]
        public GenericQueryResult ListAllVagas([FromServices] ListarVagaHandler handler)
        {
            ListarVagaQuery _query = new ListarVagaQuery();
            return (GenericQueryResult)handler.Handler(_query);
        }

        [Route("status")]
        [HttpGet]
        public GenericQueryResult ListVagancyStatus([FromServices] ListarVagaStatusHandler handler)
        {
            ListaVagaStatusQuery _query = new ListaVagaStatusQuery();
            return (GenericQueryResult)handler.Handler(_query);
        }

        [Route("prematch/{profissional}")]
        [HttpGet]
        public GenericQueryResult ListMatch([FromServices] ListaPreMatchHandler handle, string profissional)
        {
            ListaPreMatchQuery _query = new ListaPreMatchQuery(profissional);
            return (GenericQueryResult)handle.Handler(_query);
        }

        [Route("search/title/{vagancy}")]
        [HttpGet]
        public GenericQueryResult GetByTitle([FromServices] BuscarVagaHandler handle, string vagancy)
        {
            BuscarVagaQuery _query = new BuscarVagaQuery(vagancy);
            return (GenericQueryResult)handle.Handler(_query);
        }

        [Route("search/id/{vagancy}")]
        [HttpGet]
        public GenericQueryResult GetById([FromServices] BuscarVagaPorIdHandler handle, string vagancy)
        {
            BuscarVagaPorIdQuery _query = new BuscarVagaPorIdQuery(vagancy);
            return (GenericQueryResult)handle.Handler(_query);
        }

        [Authorize(Roles = "Empresa")]
        [Route("update/expirationDate")]
        [HttpPut]
        public GenericCommandResult UpdateExpirationDate(AlterarDataValidacaoCommand command, [FromServices] AlterarDataVencimentoHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Authorize(Roles = "Empresa")]
        [Route("create")]
        [HttpPost]
        public GenericCommandResult SignUpCompany(CadastrarVagaCommand command, [FromServices] CadastrarVagaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Authorize(Roles = "Empresa")]
        [Route("update")]
        [HttpPut]
        public GenericCommandResult UpdateVaga(AlterarVagaCommand command, [FromServices] AlterarVagaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Authorize(Roles = "Empresa")]
        [Route("update/state")]
        [HttpPut]

        public GenericCommandResult UpdateStats(AlterarStatusVagaCommand command, [FromServices] AlterarStatusVagaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Authorize(Roles = "Empresa")]
        [Route("update/skills")]
        [HttpPut]
        public GenericCommandResult UpdateSkills(AlterarSkillsVagaCommand command, [FromServices] AlterarSkillVagaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Authorize(Roles = "Empresa")]
        [Route("remove")]
        [HttpDelete]
        public GenericCommandResult DeleteVaga(ExcluirVagaCommand command, [FromServices] ExcluirVagaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
