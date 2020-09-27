using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIJogo.Domains;
using APIJogo.Interfaces;
using APIJogo.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIJogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoRepository _repository;

        public JogosController()
        {
            _repository = new JogosRepository();
        }

        /// <summary>
        /// Método para listar os jogos cadastrados
        /// </summary>
        /// <returns>Lista com os jogos cadastrados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var _listJogos = _repository.ListarJogos();

                if(_listJogos.Count == 0)
                {
                    return NoContent();
                }

                return Ok(new
                {
                    totalCount = _listJogos.Count,
                    data = _listJogos
                });

            }catch (Exception _e){

                return BadRequest(_e.Message);
                throw;
            }
        }

        /// <summary>
        /// Método para buscar os dados pertinente de um jogo específico
        /// </summary>
        /// <param name="id">Código de identificação do jogo</param>
        /// <returns>Dados refente ao jogo buscado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Jogo _jogo = _repository.BuscarJogoId(id);

                if(_jogo == null)
                {
                    return NoContent();
                }

                return Ok(_jogo);

            }catch (Exception _e){

                return BadRequest(_e.Message);
                throw;
            }
        }

        /// <summary>
        /// Método para cadastrar um novo jogo
        /// </summary>
        /// <param name="_jogo">Dados a serem inseridos no jogo novo</param>
        /// <returns>Jogo cadastrado com os dados informados</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Jogo _jogo)
        {
            try
            {
                _repository.CadastrarJogo(_jogo);

                return Ok(_jogo);

            }catch (Exception _e){

                return BadRequest(_e.Message);
                throw;
            }
        }

        /// <summary>
        /// Método para alterar os dados de um jogo
        /// </summary>
        /// <param name="id">Código de identificação do jogo</param>
        /// <param name="_jogo">Dados a serem alterados do jogo</param>
        /// <returns>Jogo com os dados novos inseridos</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Jogo _jogo)
        {
            try
            {
                Jogo _jogoBuscado = _repository.BuscarJogoId(id);

                if(_jogoBuscado == null)
                {
                    return NotFound();
                }

                _repository.AlterarJogo(_jogo);

                return Ok(_jogo);

            }catch (Exception _e){

                return BadRequest(_e.Message);
                throw;
            }
        }

        /// <summary>
        /// Método para excluir um jogo
        /// </summary>
        /// <param name="id">Código de identificação do jogo</param>
        /// <returns>Jogo que foi excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Jogo _jogoBuscado = _repository.BuscarJogoId(id);

                if(_jogoBuscado == null)
                {
                    return NotFound();
                }

                _repository.ExcluirJogo(id);

                return Ok(_jogoBuscado);

            }catch (Exception _e){

                return BadRequest(_e.Message);
                throw;
            }
        }
    }
}
