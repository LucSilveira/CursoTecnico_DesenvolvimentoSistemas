using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Commands.Pacotes;
using CodeTur.Dominio.Handlers.Pacotes;
using CodeTur.Dominio.Queries.Pacotes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeTur.API.Controllers
{
    [Route("v1/package")]
    [ApiController]
    public class PacoteController : ControllerBase
    {
        /// <summary>
        /// EndPoint para listar os pacotes do sistema, por meio do seu status
        /// </summary>
        /// <param name="_handle">Método para filtar as informações de listagem</param>
        /// <returns>Lista com os pacotes cadastrados</returns>
        [HttpGet]
        [Authorize]
        public GenericQueryResult GetAllPackages([FromServices] ListarPacotesHandle _handle)
        {
            //Buscando o tipo de perfil do usuairo autenticado
            var _tipoUsuario = HttpContext.User.Claims.FirstOrDefault(usr => usr.Type == ClaimTypes.Role);
            //buscando dentro da claim do nosso token o tipo de perfil para validação

            ListarPacotesQuery _query = new ListarPacotesQuery();

            if (_tipoUsuario.Value.ToString() == EnTipoPerfil.Comum.ToString())
            {
                _query.Ativo = true;
            }

            return (GenericQueryResult)_handle.Handle(_query);
        }

        /// <summary>
        /// EndPoint para buscar os dados pertinentes ao pacote
        /// </summary>
        /// <param name="_handle">Método para filtar as informações a cerca da busca do pacote</param>
        /// <param name="value">Título do pacote a ser procurado</param>
        /// <returns>Dados referente ao pacote procurado</returns>
        [Route("search/title/{value}")]
        [HttpGet]
        [Authorize]
        public GenericQueryResult GetSpecificPackageTitle([FromServices] BuscarPacoteHandle _handle, string value)
        {
            BuscarPacoteQuery _query = new BuscarPacoteQuery(value);

            return (GenericQueryResult)_handle.Handle(_query);
        }

        /// <summary>
        /// EndPoint para buscar os dados pertinentes ao pacote
        /// </summary>
        /// <param name="_handle">Método para filtar as informações a cerca da busca do pacote</param>
        /// <param name="value">Código do pacote a ser procurado</param>
        /// <returns>Dados referente ao pacote procurado</returns>
        [Route("search/id/{value}")]
        [HttpGet]
        [Authorize]
        public GenericQueryResult GetSpecificPackageId([FromServices] BuscarPacoteHandle _handle, Guid value)
        {
            BuscarPacoteQuery _query = new BuscarPacoteQuery(value);

            return (GenericQueryResult)_handle.Handle(_query);
        }

        /// <summary>
        /// EndPoint para cadastrar um novo pacote no sistema
        /// </summary>
        /// <param name="_command">Comando para validar os dados referente ao novo pacote</param>
        /// <param name="_handle">Método para cadastrar o novo pacote</param>
        /// <returns>Dados a cerca do novo pacote criado</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult CreatePackage([FromForm] CriarPacoteCommand _command, [FromServices] CriarPacoteHandle _handle)
        {
            return (GenericCommandResult)_handle.Handle(_command);
        }

        /// <summary>
        /// EndPoint para alterar os dados referente a um pacote específico
        /// </summary>
        /// <param name="_command">Comando para validar os dados referente ao pacote</param>
        /// <param name="_handle">Método para alterar os dados de um pacote</param>
        /// <returns>Dados a cerca do pacote alterado</returns>
        [Route("update")]
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult UpdatePackage(AlterarPacoteCommand _command, [FromServices] AlterarPacoteHandle _handle)
        {
            return (GenericCommandResult)_handle.Handle(_command);
        }

        /// <summary>
        /// EndPoint para alterar a imagem referente a um pacote específico
        /// </summary>
        /// <param name="_command">Comando para validar os novos dados do pacote</param>
        /// <param name="_handle">Método para alterar a imagem do pacote</param>
        /// <returns>Dados a cerca do pacote alterado</returns>
        [Route("update/image")]
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult UpdateImagePackage([FromForm] AlterarImagemPacoteCommand _command, [FromServices] AlterarImagemPacoteHandle _handle)
        {
            return (GenericCommandResult)_handle.Handle(_command);
        }

        /// <summary>
        /// EndPoint para alterar o status de ativação do pacote
        /// </summary>
        /// <param name="_command">Comando para validar os novos dados do pacote</param>
        /// <param name="_handle">Método para alterar a imagem do pacote</param>
        /// <returns>Dados a cerca do novo pacote</returns>
        [Route("update/state")]
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult UpdateStatePackage(AlterarStatusPacoteCommand _command, [FromServices] AlterarStatusPacoteHandle _handle)
        {
            return (GenericCommandResult)_handle.Handle(_command);
        }

        /// <summary>
        /// EndPoint para excluir um pacote
        /// </summary>
        /// <param name="_command">Comando ara validar os dados do pacote</param>
        /// <param name="_handle">Método para excluir um pacote</param>
        /// <param name="_id">Código de identificação do pacote</param>
        /// <returns>Dados a cerca do pacote excluir</returns>
        [Route("remove")]
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public GenericCommandResult DeletePackage(ExcluirPacoteCommand _command, [FromServices] ExcluirPacoteHandle _handle, Guid _id)
        {
            return (GenericCommandResult)_handle.Handle(_command);
        }
    }
}
