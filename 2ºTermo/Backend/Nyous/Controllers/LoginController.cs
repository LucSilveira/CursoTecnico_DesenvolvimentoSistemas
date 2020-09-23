using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Nyous.Contexts;
using Nyous.Domains;

namespace Nyous.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        NyousContext _context = new NyousContext();

        //Definindo uma variável para percorrer nossos métodos com as configurações obtidas
        private IConfiguration _config;

        // Método construtor para passar as configurações
        public LoginController(IConfiguration _configuration)
        {
            _config = _configuration;
        }

        private Usuario AuthenticateUser(Usuario _login)
        {
            return _context.Usuario.Include(usr => usr.IdAcessoNavigation)
                                        .FirstOrDefault(user => user.Email == _login.Email && user.Senha == _login.Senha);
        }


    }
}
