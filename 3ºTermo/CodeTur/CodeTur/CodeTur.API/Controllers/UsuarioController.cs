using CodeTur.Comum.Commands;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Commands.Usuarios;
using CodeTur.Dominio.Domains;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Dominio.Queries.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeTur.API.Controllers
{
    [Route("v1/user")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// EndPoint para listar os usuários sistema
        /// </summary>
        /// <param name="_handle">Método para filtrar as informações da listagem de usuários</param>
        /// <returns>Lista com os usuários cadastrados</returns>
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public GenericQueryResult GetAllUsers([FromServices] ListarUsuariosHandle _handle)
        {
            ListarUsuariosQuery _query = new ListarUsuariosQuery();

            return (GenericQueryResult)_handle.Handle(_query);
        }
        
        /// <summary>
        /// EndPoint para buscar as informações de um usuário de acordo com o email
        /// </summary>
        /// <param name="_handle">Método para filtar as informações acerca da busca do usuário</param>
        /// <param name="value">Email do usuário a ser procurado</param>
        /// <returns>Dados pertinentes ao usuário procurado</returns>
        [Route("search/email/{value}")]
        [HttpGet]
        [Authorize]
        public GenericQueryResult GetSpecificUserEmail([FromServices] BuscarUsuarioHandle _handle, string value)
        {
            BuscarUsuarioQuery _query = new BuscarUsuarioQuery(value);

            return (GenericQueryResult)_handle.Handle(_query);
        }

        /// <summary>
        /// EndPoint para buscar as informações de um usuário de acordo com o id
        /// </summary>
        /// <param name="_handle">Método para filtrar as informações acerca da busca de usuário</param>
        /// <param name="value">Código de identificação do usuário</param>
        /// <returns>Dados pertinentes ao usuário procurado</returns>
        [Route("search/id/{value}")]
        [HttpGet]
        [Authorize]
        public GenericQueryResult GetSpecificUserId([FromServices] BuscarUsuarioHandle _handle, Guid value)
        {
            BuscarUsuarioQuery _query = new BuscarUsuarioQuery(value);

            return (GenericQueryResult)_handle.Handle(_query);
        }

        /// <summary>
        /// EndPoint responsável pela criação da conta de usuário
        /// </summary>
        /// <param name="_command">Comando responsável pela validação dos dados informados</param>
        /// <param name="_handler">Método responsável pela execução dos processos para criar um usuário</param>
        /// <returns>Dados do usuário cadastrado</returns>
        [Route("signup")]
        [HttpPost]
        public GenericCommandResult SignUp(CriarUsuarioCommand _command, [FromServices] CriarUsuarioHandle _handler)
        {
            return (GenericCommandResult)_handler.Handle(_command);
        }

        /// <summary>
        /// EndPoint responsável pela autenticação do usuário no sistema
        /// </summary>
        /// <param name="_command">Comando responsável pela validação dos dados informados</param>
        /// <param name="_handler">Método responsável pela execução dos processos pela autenticação do cliente</param>
        /// <returns>Código de autenticação de usuário</returns>
        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LogarCommand _command, [FromServices] LogarHandle _handler)
        {
            var result = (GenericCommandResult)_handler.Handle(_command);

            if (result.Sucesso)
            {
                var token = GenerateJSONWebToken((Usuario)result.Data);

                return new GenericCommandResult(result.Sucesso, result.Mensagem, new { token = token });
            }

            return new GenericCommandResult(false, result.Mensagem, result.Data);
        }

        /// <summary>
        /// EndPoint responsável pela inserção de um novo número de telefone do usuário
        /// </summary>
        /// <param name="_command">Comando responsável pela validação dos dados informados</param>
        /// <param name="_handle">Método responsável pela execução dos processos de adicionar um número de telefone</param>
        /// <returns>Novo número de telefone cadastrado</returns>
        [Route("insert/phone")]
        [HttpPut]
        public GenericCommandResult AddNewPhoneNumber(AdicionarTelefoneCommand _command, [FromServices] AdicionarTelefoneHandle _handle)
        {
            return (GenericCommandResult)_handle.Handle(_command);
        }

        /// <summary>
        /// EndPoint responsável pela alteração da senha de usuário
        /// </summary>
        /// <param name="_command">Comando responsável pela validação do email de usuário</param>
        /// <param name="_handle">Método responsável pela execução de gerar uma nova senha para o usuário</param>
        /// <returns>Nova senha gerada pelo sistema</returns>
        [Route("reset/password")]
        [HttpPost]
        public GenericCommandResult ResetPassword(EsqueciSenhaCommand _command, [FromServices] EsqueciSenhaHandle _handle)
        {
            return (GenericCommandResult)_handle.Handle(_command);
        }

        /// <summary>
        /// EndPoint responsável pela alteração dos dados de usuário
        /// </summary>
        /// <param name="_command">Comando responsável pela validação dos dados de usuário</param>
        /// <param name="_handle">Método responsável pela alteração dos dados de usuário</param>
        /// <returns>Dados do usuário alterado</returns>
        [Route("update/account")]
        [HttpPut]
        public GenericCommandResult UpdateAccount(AlterarUsuarioCommand _command, [FromServices] AlterarUsuarioHandle _handle)
        {
            return (GenericCommandResult)_handle.Handle(_command);
        }

        /// <summary>
        /// EndPoint responsável pela alteração da senha de usuário
        /// </summary>
        /// <param name="_command">Comando responsável pela validação da nova senha informada</param>
        /// <param name="_handle">Método responsável pela alteração da senha do usuário</param>
        /// <returns>Nova senha de usuário alterada</returns>
        [Route("update/password")]
        [HttpPut]
        public GenericCommandResult UpdatePassword(AlterarSenhaCommand _command, [FromServices] AlterarSenhaHandle _handle)
        {
            return (GenericCommandResult)_handle.Handle(_command);
        }

        /// <summary>
        /// EndPoint para excluir um usuário
        /// </summary>
        /// <param name="_command">Comando responsável pela validação do id do usuário</param>
        /// <param name="_handle">Método responsável pela exclusão do usuário</param>
        /// <param name="_id">Código de identificação do usuário</param>
        /// <returns>Dados a cerca do usuário excluido</returns>
        [Route("remove")]
        [HttpDelete]
        [Authorize]
        public GenericCommandResult DeleteUser(ExcluirUsuarioCommand _command, [FromServices] ExcluirUsuarioHandle _handle, Guid _id)
        {
            return (GenericCommandResult)_handle.Handle(_command);
        }

        //geração de token
        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CodeTurSecurityKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.NameId, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userInfo.TipoPerfil.ToString()),
                new Claim("IdUsuario", userInfo.Id.ToString()),
                new Claim("Role", userInfo.TipoPerfil.ToString())
            };

            var token = new JwtSecurityToken
                (
                    "codetur",
                    "codetur",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
