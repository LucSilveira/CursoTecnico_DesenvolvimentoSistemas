using Carometro.Comum.Commands;
using Carometro.Comum.Entidades;
using Carometro.Dominio.Commands.Admin;
using Carometro.Dominio.Commands.Usuario;
using Carometro.Dominio.Entidades;
using Carometro.Dominio.Handlers.Commands.Admins;
using Carometro.Dominio.Handlers.Commands.Usuarios;
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
    [Route("v1/account")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LogarCommand command, [FromServices] LogarHandler handle)
        {
            var resultado = (GenericCommandResult)handle.Handler(command);

            if (resultado.Sucesso)
            {
                var token = GerarJSONWebToken((Usuario)resultado.Data);

                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { token = token });
            }

            return new GenericCommandResult(true, resultado.Mensagem, resultado.Data);
        }

        [Route("reset/password")]
        [HttpPut]
        public GenericCommandResult ResetPassword(EsqueciSenhaCommand command, [FromServices] EsqueciSenhaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        [Route("update/password")]
        [HttpPut]
        public GenericCommandResult UpdatePassword(AlterarSenhaCommand command, [FromServices] AlterarSenhaHandler handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }

        // Criamos nosso método que vai gerar nosso Token
        private string GerarJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaCarometro"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.NomeUsuario),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
                new Claim("IdUsuario", userInfo.Id.ToString()),
                new Claim("Role", userInfo.TipoUsuario.ToString()),
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    "carometro",
                    "carometro",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
