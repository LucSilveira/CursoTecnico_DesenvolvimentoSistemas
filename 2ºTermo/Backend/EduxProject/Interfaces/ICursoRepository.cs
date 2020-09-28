using EduxProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Interfaces
{
    public interface ICursoRepository
    {
        Task<List<Cursos>> ListarCursos();
        Task<Cursos> BuscarCursoPorId(int _idCurso);
        Task<Cursos> CadastrarCurso(Cursos _curso);
        Task<Cursos> AlterarCurso(Cursos _curso);
        Task<Cursos> ExcluirCurso(Cursos _curso);
    }
}
