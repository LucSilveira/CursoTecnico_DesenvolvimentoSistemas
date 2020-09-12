using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBoletim.Domains;
using APIBoletim.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBoletim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        AlunoRepositorie _repositorie = new AlunoRepositorie();


        [HttpGet]
        public List<Aluno> Get()
        {
            return _repositorie.ListarAlunos();
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return _repositorie.BuscarAluno(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public Aluno Post([FromBody] Aluno _aluno)
        {
            return _repositorie.CadastrarAluno(_aluno);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public Aluno Put(int id, [FromBody] Aluno aluno)
        {
            return _repositorie.AlterarAluno(aluno, id);
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public Aluno Delete(int id)
        {
            return _repositorie.ExcluirAluno(id);
        }
    }
}
