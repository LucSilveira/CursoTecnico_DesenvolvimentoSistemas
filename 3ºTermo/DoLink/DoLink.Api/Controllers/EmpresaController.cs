using DoLink.Comum.Queries;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Empresa;
using DoLink.Dominio.Commands.Empresas;
using DoLink.Dominio.Handles.Commands;
using DoLink.Dominio.Handles.Commands.Empresas;
using DoLink.Dominio.Handles.Queries.Empresas;
using DoLink.Dominio.Handles.Queries.Vagas;
using DoLink.Dominio.Queries.Empresa;
using DoLink.Dominio.Queries.Empresas;
using DoLink.Dominio.Queries.Vagas;
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
    [Route("v1/company")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        //Instânciando o tratamento dos nossos métodos com o    
        private readonly IEmpresaRepository _repository;

        public EmpresaController(IEmpresaRepository _empresaRepository)
        {
            _repository = _empresaRepository;
        }

        /// <summary>
        /// Método para listar todas as empresas cadastradas na aplicação
        /// </summary>
        /// <returns>Lista com todas as empresas do sistema</returns>
        [Authorize]
        [HttpGet]
        public GenericQueryResult ListAllCompany([FromServices] ListarEmpresaHandler handle)
        {
            ListarEmpresaQuery _query = new ListarEmpresaQuery();
            return (GenericQueryResult)handle.Handler(_query);
        }

        /// <summary>
        /// Método para listas as vagas de acordo com a empresa
        /// </summary>
        /// <returns>Lista com as vagas de uma empresa</returns>
        [Authorize]
        [Route("vagancy/{company}")]
        [HttpGet]
        public GenericQueryResult ListVagancy([FromServices] ListarVagaEmpresaHandler handle, string company)
        {
            ListarVagaEmpresaQuery _query = new ListarVagaEmpresaQuery(company);
            return (GenericQueryResult)handle.Handler(_query);
        }

        /// <summary>
        /// Método para buscar os dados de uma empresa específica
        /// </summary>
        /// <param name="handle">Parametros para buscar uma empresa</param>
        /// <param name="empresa">Processos para realizar a busca da empresa</param>
        /// <returns>Dados da empresa procurada</returns>
        [Authorize]
        [Route("search/cnpj/{empresa}")]
        [HttpGet]
        public GenericQueryResult GetByCnpj([FromServices] BuscarEmpresaHandler handle, string empresa)
        {
            BuscarEmpresaQuery _query = new BuscarEmpresaQuery(empresa);
                return (GenericQueryResult)handle.Handler(_query);
        }

        /// <summary>
        /// Método para buscar os dados de uma empresa específica
        /// </summary>
        /// <param name="handle">Parametros para buscar uma empresa</param>
        /// <param name="empresa">Processos para realizar a busca da empresa</param>
        /// <returns>Dados da empresa procurada</returns>
        [Authorize(Roles = "Empresa")]
        [Route("search/id/{empresa}")]
        [HttpGet]
        public GenericQueryResult GetById([FromServices] BuscarEmpresaHandler handle, string empresa)
        {
            BuscarEmpresaQuery _query = new BuscarEmpresaQuery(empresa);
            return (GenericQueryResult)handle.Handler(_query);
        }

        /// <summary>
        /// Método que Cadastra uma nova empresa na aplicação.
        /// </summary>
        /// <param name="command">Dados a serem processados</param>
        /// <param name="handle">Processos a serem realizados para o cadastro de empresa</param>
        /// <returns>Dados da empresa cadastrada</returns>
        [Route("signup")]
        [HttpPost]
        public GenericCommandResult SignUpCompany(CadastrarEmpresaCommand command, [FromServices] CadastrarEmpresaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método que altera uma empresa cadastrada
        /// </summary>
        /// <param name="command">Dados para alteração da empresa</param>
        /// <param name="handle">Tratativa dos dados para alteração do mesmo</param>
        /// <returns>Dados acerca da empresa alterado</returns>
        [Authorize(Roles = "Empresa")]
        [Route("update/general")]
        [HttpPut]
        public GenericCommandResult UpdateAccountGeneral([FromForm] AlterarEmpresaGeneralCommand command, [FromServices] AlterarEmpresaGeneralHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método para alterar os dados de uma empresa cadastrada
        /// </summary>
        /// <param name="command">Dados a serem alterados</param>
        /// <param name="handle">Processos para alterar os dados da empresa</param>
        /// <returns>Empresa com os dados alterados</returns>
        [Authorize(Roles = "Empresa")]
        [Route("update")]
        [HttpPut]
        public GenericCommandResult UpdateCompany([FromForm] AlterarEmpresaCommand command, [FromServices] AlterarEmpresaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método para alterar o cnpj da empresa
        /// </summary>
        /// <param name="command">Cnpj a ser alterado</param>
        /// <param name="handle">Processos para alterar os dados da empresa</param>
        /// <returns>Empresa com os dados alterados</returns>
        [Authorize(Roles = "Empresa")]
        [Route("update/cnpj")]
        [HttpPut]
        public GenericCommandResult UpdateCpnj(AlterarCnpjCommand command, [FromServices] AlterarCnpjHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método para alterar a descrição da empresa
        /// </summary>
        /// <param name="command">Nova descrição informada</param>
        /// <param name="handle">Processos para alterar os dados da empresa</param>
        /// <returns>Empresa com a descrição alterada</returns>
        [Authorize(Roles = "Empresa")]
        [Route("update/description")]
        [HttpPut]
        public GenericCommandResult UpdateDescricao(AlterarDescricaoEmpresaCommand command, [FromServices] AlterarDescricaoEmpresaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método para deletar uma empresa existente
        /// </summary>
        /// <param name="command">Dados para localizar uma empresa</param>
        /// <param name="handle">Processo para deletar uma empresa</param>
        /// <returns>Dados da empresa deletada</returns>
        [Authorize(Roles = "Empresa, Administrador")]
        [Route("remove")]
        [HttpDelete]
        public GenericCommandResult Delete(ExcluirEmpresaCommand command,[FromServices] ExcluirEmpresaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
