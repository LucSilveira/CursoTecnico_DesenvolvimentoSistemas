using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCore.Domains;
using EfCore.Interfaces;
using EfCore.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProdutosController()
        {
            _repository = new ProdutoRepository();
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public List<Produto> Get()
        {
            return _repository.ListarPodutos();
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public Produto Get(Guid id)
        {
            return _repository.BuscarProdutoId(id);
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public Produto Post([FromBody] Produto _produto)
        {
            return _repository.CadastrarProduto(_produto);
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public Produto Put(Guid id, [FromBody] Produto _produto)
        {
            return _repository.AlterarProduto(_produto);
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.ExcluirProduto(id);
        }
    }
}
