using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Repositorios
{
    public interface IProfessorRepositorio
    {
        IEnumerable<Professor> ListarProfessores();
        Professor BuscarProfessorPorEmail(string _email);
        Professor BuscarProfessorPorId(Guid _idProfessor);
        void AdicionarProfessor(Professor _professor);
        void AlterarProfessor(Professor _professor);
        void ExcluirProfessor(Professor _professor);
    }
}
