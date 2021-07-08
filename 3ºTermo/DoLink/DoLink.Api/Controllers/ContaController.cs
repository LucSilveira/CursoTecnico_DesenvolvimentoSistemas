using DoLink.Comum.Entidades;
using DoLink.Comum.Queries;
using DoLink.Dominio.Commands;
using DoLink.Dominio.Commands.Conta;
using DoLink.Dominio.Handles.Commands.Conta;
using DoLink.Dominio.Handles.Queries.Conta;
using DoLink.Dominio.Queries.Conta;
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

namespace DoLink.Api.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        /// <summary>
        /// Método para procurar um usuário por email
        /// </summary>
        /// <returns>Dados do usuário com o email</returns>
        [Route("search/{email}")]
        [HttpGet]
        public GenericQueryResult SearchEmail([FromServices] BuscarEmailHandler handle, string email)
        {
            BuscarEmailQuery _query = new BuscarEmailQuery(email);
            return (GenericQueryResult)handle.Handler(_query);
        }


        /// <summary>
        /// Método para criar a autenticação do sistema
        /// </summary>
        /// <param name="command">Dados a serem processados</param>
        /// <param name="handle">Processos que serão realizados</param>
        /// <returns>Código para autenticação</returns>
        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LogarCommand command, [FromServices] LogarHandler handle)
        {
            var _resultado = (GenericCommandResult)handle.Handler(command);

            if (_resultado.Sucesso)
            {
                var token = GerarJSONWebToken((Usuario)_resultado.Data);

                return new GenericCommandResult(_resultado.Sucesso, _resultado.Mensagem, new { token = token });
            }

            return new GenericCommandResult(true, _resultado.Mensagem, _resultado.Data);
        }

        /// <summary>
        /// Método para resetar a senha
        /// </summary>
        /// <param name="command">Dados para localizar o usuário</param>
        /// <param name="handle">Processamento para confecção de uma nova senha</param>
        /// <returns>Dados a cerca da senha gerada</returns>
        [Route("reset/password")]
        [HttpPut]
        public GenericCommandResult ResetPassword(EsqueciMinhaSenhaCommand command, [FromServices] EsqueciMinhaSenhaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        /// <summary>
        /// Método para alterar a senha dos usuários
        /// </summary>
        /// <param name="command">Dados para localizar e alterar o usuário</param>
        /// <param name="handle">Processamento para alteração da senha</param>
        /// <returns>Usuário com dados alterados</returns>
        [Route("update/password")]
        [HttpPut]
        public GenericCommandResult UpdatePassword(AlterarSenhaCommand command, [FromServices] AlterarSenhaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        // Criamos nosso método que vai gerar nosso Token
        private string GerarJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaDoLink"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userInfo.TipoPerfil.ToString()),
                new Claim("Id", userInfo.Id.ToString()),
                new Claim("Roles", userInfo.TipoPerfil.ToString()),
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    "dolink",
                    "dolink",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
