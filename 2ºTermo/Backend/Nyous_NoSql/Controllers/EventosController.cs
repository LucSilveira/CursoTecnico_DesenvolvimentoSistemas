using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nyous_NoSql.Domains;
using Nyous_NoSql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous_NoSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventoRepository _repository;

        public EventosController(IEventoRepository eventoRepository)
        {
            _repository = eventoRepository;
        }

        [HttpPost]
        public ActionResult<EventoDomain> Create(EventoDomain evento)
        {
            try
            {
                _repository.AdicionarEvento(evento);
                return Ok(evento);
            }
            catch (Exception _e)
            {

                return BadRequest(_e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<EventoDomain>> Get()
        {
            try
            {
                return _repository.ListarEventos();
            }
            catch (Exception _e)
            {

                return BadRequest(_e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(string id)
        {
            try
            {
                _repository.RemoverEvento(id);
                return Ok();
            }
            catch (Exception _e)
            {

                return BadRequest(_e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<EventoDomain> Alterar(string id, EventoDomain evento)
        {
            try
            {
                evento.Id = id;

                _repository.AtualizarEvento(id, evento);
                return Ok(evento);
            }
            catch (Exception _e)
            {

                return BadRequest(_e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            try
            {
                var evento = _repository.BuscarPorId(id);
                return Ok(evento);
            }
            catch (Exception _e)
            {

                return BadRequest(_e.Message);
            }
        }
    }
}
