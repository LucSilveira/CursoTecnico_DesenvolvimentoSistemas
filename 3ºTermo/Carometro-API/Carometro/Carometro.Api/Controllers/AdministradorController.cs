using Carometro.Comum.Commands;
using Carometro.Comum.Entidades;
using Carometro.Comum.Queries;
using Carometro.Dominio.Commands.Admin;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Handlers.Commands.Admins;
using Carometro.Dominio.Handlers.Queries.Admins;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Api.Controllers
{
    [Route("v1/admin")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        [HttpGet]
        public GenericQueryResult GetAllAdmins([FromServices] ListarAdminHandler handle)
        {
            ListarAdminQuery query = new ListarAdminQuery();
            return (GenericQueryResult)handle.Handle(query);
        }

        [Route("search/id/{value}")]
        [HttpGet]
        public GenericQueryResult GetSpecificAdmin(Guid value, [FromServices] BuscarAdminHandler handle)
        {
            BuscarAdminQuery query = new BuscarAdminQuery(value);
            return (GenericQueryResult)handle.Handle(query);
        }

        /// <summary>
        /// Método que Cadastra um Novo Administrador na Aplicação.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="handle"></param>
        /// <returns>Data do Adm</returns>
        [Route("signup")]
        [HttpPost]
        public GenericCommandResult SignUpAdmin(CadastrarContaCommand command, [FromServices] CadastrarContaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("update")]
        [HttpPut]
        public GenericCommandResult UpdateAdmin(AlterarContaCommand command, [FromServices] AlterarContaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("remove")]
        [HttpDelete]
        public GenericCommandResult RemoveAdmin(ExcluirContaCommand command, [FromServices] ExcluirContaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
