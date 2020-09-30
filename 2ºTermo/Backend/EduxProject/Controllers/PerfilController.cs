using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxProject.Domains;
using EduxProject.Interfaces;
using EduxProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduxProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        //Instânciando nosso interface para fazer a chamada dos nossos métodos
        private readonly PerfilRepository _repository;

        //Criando método construtor para que sempre que a classe for instânciada ela fazer
        //a conexão com nosso repository a partir dos nossos métodos do interface
        public PerfilController()
        {
            _repository = new PerfilRepository();
        }

        // GET: api/<PerfilController>
        [HttpGet]
        public async Task<ActionResult<List<Perfils>>> Get()
        {
            try
            {
                var _listaPerfil = await _repository.ListarPerfils();

                if (_listaPerfil == null || _listaPerfil.Count == 0){

                    return NotFound("Nenhum perfil encontrado");
                }

                return Ok(_listaPerfil);

            }catch (Exception _e){

                return BadRequest(_e.Message);
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfils>> Get(int id)
        {
            try
            {
                Perfils _perfil = await _repository.BuscarPerfilPorId(id);

                if(_perfil == null){

                    return NotFound("Nenhum perfil encontrado");
                }

                return Ok(_perfil);

            }catch (Exception _e){

                return BadRequest(_e.Message);
            }
        }

        
        [HttpPost]
        public async Task<ActionResult<Perfils>> Post([FromBody]Perfils _perfil)
        {
            try
            {
                await _repository.CadastrarPerfil(_perfil);

                return Ok(_perfil);

            }catch (Exception _e){

                return BadRequest(_e.Message);
            }
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Perfils>> Put(int id, [FromBody] Perfils _perfil)
        {
            try
            {
                await _repository.AlterarPerfil(_perfil);

                return Ok(_perfil);

            }catch (DbUpdateConcurrencyException){

                var _validarPerfil = _repository.BuscarPerfilPorId(id);

                if(_validarPerfil == null){

                    return NotFound();
                }

                return BadRequest();
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Perfils>> Delete(int id)
        {
            try
            {
                Perfils _perfilProcurado = await _repository.BuscarPerfilPorId(id);

                if(_perfilProcurado == null){

                    return NotFound("Perfil não encontrado");
                }

                await _repository.ExcluirPerfil(_perfilProcurado);

                return Ok(_perfilProcurado);

            }catch (Exception _e){

                return BadRequest(_e.Message);
            }
        }
    }
}
