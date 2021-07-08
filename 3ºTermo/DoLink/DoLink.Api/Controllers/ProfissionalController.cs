using DoLink.Comum.Queries;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Profissionais;
using DoLink.Dominio.Handles.Commands.Profissionais;
using DoLink.Dominio.Handles.Queries.Profissionais;
using DoLink.Dominio.Queries.Profissionais;
using DoLink.Dominio.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoLink.Api.Controllers
{
    [Route("v1/professional")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        //Instânciando os métodos contidos no repositório
        public readonly IProfissionalRepository _repository;

        //Criando a injeção de dependência na classe para utilização dos nossos métodos
        public ProfissionalController(IProfissionalRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Método para listar os profissionais cadastrados
        /// </summary>
        /// <returns>Lista com todos os profissionais</returns>
        [Authorize]
        [HttpGet]
        public GenericQueryResult ListProfessional([FromServices] ListarProfissionaisHandler handle)
        {
            ListarProfissionalQuery query = new ListarProfissionalQuery();

            return (GenericQueryResult)handle.Handler(query);
        }

        /// <summary>
        /// Método para buscar um profissional existente
        /// </summary>
        /// <param name="command">Dados para a busca de um profissional</param>
        /// <param name="handle">Tratativa dos dados para localização do mesmo</param>
        /// <returns>Dados a cerca do profissional procurado</returns>
        [Authorize]
        [Route("search/cpf/{professional}")]
        [HttpGet]
        public GenericQueryResult GetSpecificCpf([FromServices] BuscarProfissionalHandler handle, string professional)
        {
            BuscarProfissionalQuery _query = new BuscarProfissionalQuery(professional);

            return (GenericQueryResult)handle.Handler(_query);
        }

        /// <summary>
        /// Método para buscar um profissional por meio do seu id
        /// </summary>
        /// <param name="professional">código de identificação do profissional</param>
        /// <returns>dados a cerca do profissional</returns>
        [Authorize]
        [Route("search/id/{professional}")]
        [HttpGet]
        public GenericQueryResult GetSpecificId([FromServices] BuscarProfissionalHandler handle, string professional)
        {
            BuscarProfissionalQuery _query = new BuscarProfissionalQuery(professional);
            return (GenericQueryResult)handle.Handler(_query);
        }

        /// <summary>
        /// Método que Cadastra um novo profissional na aplicação.
        /// </summary>
        /// <param name="command">Dados para criação do profissional</param>
        /// <param name="handle">Tratativa dos dados para criação do mesmo</param>
        /// <returns>Dados acerca do profissional</returns>
        [Route("signup")]
        [HttpPost]
        public GenericCommandResult CrateProfessional(CadastrarProfissionalCommand command, [FromServices] CadastrarProfissionalHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método que altera um profissional cadastrado
        /// </summary>
        /// <param name="command">Dados para alteração do profissional</param>
        /// <param name="handle">Tratativa dos dados para alteração do mesmo</param>
        /// <returns>Dados acerca do profissional alterado</returns>
        [Authorize(Roles = "Profissional")]
        [Route("update")]
        [HttpPut]
        public GenericCommandResult UpdateAccount(AlterarProfissionalCommand command, [FromServices] AlterarProfissionalHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método que altera um profissional cadastrado por mobile
        /// </summary>
        /// <param name="command">Dados para alteração do profissional</param>
        /// <param name="handle">Tratativa dos dados para alteração do mesmo</param>
        /// <returns>Dados acerca do profissional alterado</returns>
        [Authorize(Roles = "Profissional")]
        [Route("update/general")]
        [HttpPut]
        public GenericCommandResult UpdateAccountGeneral(AlterarProfissionalMobileCommand command, [FromServices] AlterarProfissionalMobileHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método parar alterar o cpf de um profissional
        /// </summary>
        /// <param name="command">Dados a serem processados (cpf)</param>
        /// <param name="handle">Processos de tratamento para alteração do cpf</param>
        /// <returns>Dados do profissional com o cpf alterado</returns>
        [Authorize(Roles = "Profissional, Administrador")]
        [Route("update/cpf")]
        [HttpPut]
        public GenericCommandResult UpdateCpf(AlterarCpfProfissionalCommand command, [FromServices] AlterarCpfProfissionalHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método para alterar as skills de um profissional
        /// </summary>
        /// <param name="command">Dados a cerca das skills alteradas</param>
        /// <param name="handle">Processos para alterar as skills de um profissional</param>
        /// <returns>Dados a cerca das skills alteradas de um profissional</returns>
        [Authorize(Roles = "Profissional")]
        [Route("update/skills")]
        [HttpPut]
        public GenericCommandResult UpdateSkills(AlterarSkillsProfissionalCommand command, [FromServices] AlterarSkillsProfissionalHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método que excluir um profissional na aplicação.
        /// </summary>
        /// <param name="command">Dados para exclusão do profissional</param>
        /// <param name="handle">Tratativa dos dados para exclusão do mesmo</param>
        /// <returns>Dados acerca do profissional excluido</returns>
        [Authorize(Roles = "Profissional, Administrador")]
        [Route("remove")]
        [HttpDelete]
        public GenericCommandResult RemoveAccount(ExcluirProfissionalCommand command, [FromServices] ExcluirProfissionalHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
