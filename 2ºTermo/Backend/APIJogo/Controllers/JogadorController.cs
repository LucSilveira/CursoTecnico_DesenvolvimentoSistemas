using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIJogo.Domains;
using APIJogo.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIJogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private readonly JogadorRepository _repository;

        public JogadorController()
        {
            _repository = new JogadorRepository();
        }

        /// <summary>
        /// Método para listas os jogadores cadastrados no sistema
        /// </summary>
        /// <returns>Lista com os jogadores</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var _jogadores = _repository.ListarJogadores();

                if(_jogadores.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_jogadores);

            }catch (Exception _e){

                return BadRequest(_e.Message);
                throw;
            }
        }

        /// <summary>
        /// Método para buscar os dados especificos de um jogador
        /// </summary>
        /// <param name="id">Código de identificação do jogador</param>
        /// <returns>Dados do jogador</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var _jogador = _repository.BuscarJogadorId(id);

                if(_jogador == null)
                {
                    return NotFound();
                }

                return Ok(_jogador);

            }catch (Exception _e) {

                return BadRequest(_e.Message);
                throw;
            }
        }

        /// <summary>
        /// Método para cadastrar um novo jogador com seus devidos jogos
        /// </summary>
        /// <param name="_jogador">Dados do jogador</param>
        /// <returns>Jogador com os dados cadastrados</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Jogador _jogador)
        {
            try
            {
                Jogador jogador = _repository.CadastrarJogador(_jogador);

                return Ok(jogador);

            }catch (Exception _e){

                return BadRequest(new
                {
                    statusCode = 400,
                    error = _e.Message,
                    data = _jogador
                });
                throw;
            }
        }

        // PUT api/<JogadorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// Método para excluir um jogador
        /// </summary>
        /// <param name="id">Código de identificação do jogador</param>
        /// <returns>Dados do jogador excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Jogador _jogadorBuscado = _repository.BuscarJogadorId(id);

                if(_jogadorBuscado == null)
                {
                    return NotFound();
                }

                _repository.ExcluirJogador(id);

                return Ok(_jogadorBuscado);

            }catch (Exception _e){

                return BadRequest(_e.Message);
                throw;
            }
        }
    }
}
