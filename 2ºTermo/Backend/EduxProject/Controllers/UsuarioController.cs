using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduxProject.Domains;
using EduxProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduxProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //Instânciando nosso interface para fazer a chamada dos nossos métodos
        private readonly UsuarioRepository _repository;

        //Criando método construtor para que sempre que a classe for instânciada ela fazer
        //a conexão com nosso repository a partir dos nossos métodos do interface
        public UsuarioController()
        {
            _repository = new UsuarioRepository();
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> Get()
        {
            try
            {
                var _listaUsuario = await _repository.ListarUsuarios();

                if (_listaUsuario == null || _listaUsuario.Count == 0){

                    return NotFound("Nenhum usuário encontrado");
                }

                return Ok(_listaUsuario);

            }catch (Exception _e){

                return BadRequest(_e.Message);
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> Get(int id)
        {
            try
            {
                Usuarios _usuario = await _repository.BuscarUsuarioPorId(id);

                if (_usuario == null)
                {

                    return NotFound("Nenhum usuário encontrado");
                }

                return Ok(_usuario);

            }catch (Exception _e){

                return BadRequest(_e.Message);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<ActionResult<Usuarios>> Post([FromBody] Usuarios _usuario)
        {
            try
            {
                await _repository.CadastrarUsuario(_usuario);

                return Ok(_usuario);

            }catch (Exception _e){

                return BadRequest(_e.Message);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuarios>> Put(int id, [FromBody] Usuarios _usuario)
        {
            try
            {
                await _repository.AlterarUsuario(_usuario);

                return Ok(_usuario);

            }catch (DbUpdateConcurrencyException _e){

                var _validarUsuario = _repository.BuscarUsuarioPorId(id);

                if (_validarUsuario == null){

                    return NotFound("Usuário não encontrado");
                }

                return BadRequest(_e.Message);
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuarios>> Delete(int id)
        {
            try
            {
                Usuarios _usuarioProcurado = await _repository.BuscarUsuarioPorId(id);

                if (_usuarioProcurado == null){

                    return NotFound("Perfil não encontrado");
                }

                await _repository.ExcluirUsuario(_usuarioProcurado);

                return Ok(_usuarioProcurado);

            }catch (Exception _e){

                return BadRequest(_e.Message);
            }
        }
    }
}
