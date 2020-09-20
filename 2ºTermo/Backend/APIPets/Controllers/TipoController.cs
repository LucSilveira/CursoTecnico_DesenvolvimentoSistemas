using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPets.Domains;
using APIPets.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        TipoRepositorie _repositorie = new TipoRepositorie();

        // GET: api/<TipoPetController>
        [HttpGet]
        public List<Tipo> Get()
        {
            return _repositorie.ListaTipos();
        }

        // GET api/<TipoPetController>/5
        [HttpGet("{id}")]
        public Tipo Get(int id)
        {
            return _repositorie.ListarTipo(id);
        }

        // POST api/<TipoPetController>
        [HttpPost]
        public Tipo Post([FromBody] Tipo _tipo)
        {
            return _repositorie.CadastrarTipo(_tipo);
        }

        // PUT api/<TipoPetController>/5
        [HttpPut("{id}")]
        public Tipo Put(int id, [FromBody] Tipo _tipo)
        {
            return _repositorie.AlterarTipo(_tipo, id);
        }

        // DELETE api/<TipoPetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repositorie.ExcluirTipo(id);
        }
    }
}
