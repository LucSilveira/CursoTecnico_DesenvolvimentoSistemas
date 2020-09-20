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
    public class RacaController : ControllerBase
    {
        RacaRepositorie _repositorio = new RacaRepositorie();

        // GET: api/<RacaController>
        [HttpGet]
        public List<Raca> Get()
        {
            return _repositorio.ListarRacas();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return _repositorio.BuscarRaca(id);
        }

        // POST api/<RacaController>
        [HttpPost]
        public Raca Post([FromBody] Raca _raca)
        {
            return _repositorio.CadastrarRaca(_raca);
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public Raca Put(int id, [FromBody] Raca _raca)
        {
            return _repositorio.AlterarRaca(_raca, id);
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repositorio.ExcluirRaca(id);
        }
    }
}
