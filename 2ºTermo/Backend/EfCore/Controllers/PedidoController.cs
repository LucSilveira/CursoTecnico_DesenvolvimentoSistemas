using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCore.Domains;
using EfCore.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _repository;

        public PedidoController()
        {
            _repository = new PedidoRepository();
        }

        // GET: api/<PedidoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var _pedidos = _repository.ListarPedidos();

                if(_pedidos.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_pedidos);

            }catch (Exception){

                throw;
            }
        }

        // GET api/<PedidoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var _pedido = _repository.BuscarPorId(id);

                if (_pedido == null)
                {
                    return NotFound();
                }

                return Ok(_pedido);

            }catch (Exception){

                throw;
            }
        }

        // POST api/<PedidoController>
        [HttpPost]
        public IActionResult Post(List<PedidoItem> _pedidosItens)
        {
            try
            {
                Pedido _pedido = _repository.CadastrarProduto(_pedidosItens);

                return Ok(_pedido);

            }catch (Exception){

                throw;
            }
        }

        // PUT api/<PedidoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
