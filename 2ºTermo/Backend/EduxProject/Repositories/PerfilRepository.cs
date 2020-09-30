using EduxProject.Contexts;
using EduxProject.Domains;
using EduxProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        //Instânciando nossa conexão com o banco de dados
        private readonly EduxContext _contexto;

        //Defindo o método construtor, para sempre que a classe PerfilRepository seja instânciada
        //ela possa realizar a conexão com o nosso banco de dados;
        public PerfilRepository()
        {
            _contexto = new EduxContext();
        }

        public async Task<List<Perfils>> ListarPerfils()
        {
            try
            {
                return await _contexto.Perfils.ToListAsync();

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public async Task<Perfils> BuscarPerfilPorId(int _idPerfil)
        {
            try
            {
                return await _contexto.Perfils.FirstOrDefaultAsync(pf => pf.Id == _idPerfil);

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public async Task<Perfils> CadastrarPerfil(Perfils _perfil)
        {
            try
            {
                await _contexto.Perfils.AddAsync(_perfil);
                await _contexto.SaveChangesAsync();

                return _perfil;

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public async Task<Perfils> AlterarPerfil(Perfils _perfil)
        {
            try
            {
                _contexto.Entry(_perfil).State = EntityState.Modified;
                await _contexto.SaveChangesAsync();

                return _perfil;

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public async Task<Perfils> ExcluirPerfil(Perfils _perfil)
        {
            try
            {
                _contexto.Usuarios.RemoveRange(_contexto.Usuarios.Where(usr => usr.IdPerfil == _perfil.Id));
                _contexto.Perfils.Remove(_perfil);

                await _contexto.SaveChangesAsync();

                return _perfil;

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

    }
}
