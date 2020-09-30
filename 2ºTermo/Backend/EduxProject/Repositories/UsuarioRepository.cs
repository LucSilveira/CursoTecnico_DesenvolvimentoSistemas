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
    public class UsuarioRepository : IUsuarioRepository
    {
        //Instânciando nossa conexão com o banco de dados
        private readonly EduxContext _contexto;

        //Defindo o método construtor, para sempre que a classe UsuarioRepository seja instânciada
        //ela possa realizar a conexão com o nosso banco de dados;
        public UsuarioRepository()
        {
            _contexto = new EduxContext();
        }

        public async Task<List<Usuarios>> ListarUsuarios()
        {
            try
            {
                List<Usuarios> _listaUsuario = await _contexto.Usuarios.Include("IdPerfilNavigation")
                                                                            .ToListAsync();

                foreach(var usuario in _listaUsuario)
                {
                    usuario.IdPerfilNavigation.Usuarios = null;
                }

                return _listaUsuario;

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public async Task<Usuarios> BuscarUsuarioPorId(int _idUsuario)
        {
            try
            {
                return await _contexto.Usuarios.Include(usr => usr.IdPerfilNavigation.Permissao)
                                                .FirstOrDefaultAsync(usr => usr.Id == _idUsuario);

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public async Task<Usuarios> CadastrarUsuario(Usuarios _usuario)
        {
            try
            {
                await _contexto.Usuarios.AddAsync(_usuario);

                if(_usuario.IdPerfilNavigation.Permissao == "Professor"){

                    foreach(ProfessoresTurmas _turmaProfessor in _usuario.ProfessoresTurmas){

                        _usuario.ProfessoresTurmas.Add(new ProfessoresTurmas {

                            IdUsuario = _usuario.Id,
                            IdTurma = _turmaProfessor.Id
                        });
                    }
                }

                if(_usuario.IdPerfilNavigation.Permissao == "Aluno"){

                    foreach(AlunosTurmas _turmaAluno in _usuario.AlunosTurmas){

                        _usuario.AlunosTurmas.Add(new AlunosTurmas {

                            IdUsuario = _usuario.Id,
                            IdTurma = _turmaAluno.Id
                        });
                    }
                }

                await _contexto.SaveChangesAsync();

                return _usuario;

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public async Task<Usuarios> AlterarUsuario(Usuarios _usuario)
        {
            try
            {
                _contexto.Entry(_usuario).State = EntityState.Modified;
                await _contexto.SaveChangesAsync();

                return _usuario;

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }

        public async Task<Usuarios> ExcluirUsuario(Usuarios _usuario)
        {
            try
            {
                _contexto.ProfessoresTurmas.RemoveRange(_contexto.ProfessoresTurmas.Where(pft => pft.IdUsuario == _usuario.Id));
                _contexto.AlunosTurmas.RemoveRange(_contexto.AlunosTurmas.Where(alt => alt.IdUsuario == _usuario.Id));
                _contexto.ObjetivosAlunos.RemoveRange(_contexto.ObjetivosAlunos.Where(oba => oba.IdAlunoTurmaNavigation.IdUsuario == _usuario.Id));
                _contexto.Usuarios.Remove(_usuario);

                await _contexto.SaveChangesAsync();

                return _usuario;

            }catch (Exception _e){

                throw new Exception(_e.Message);
            }
        }
    }
}
