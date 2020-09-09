using APIBoletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Interfaces
{
    interface IAluno
    {
        List<Aluno> ListarAluno();
        Aluno CadastrarAluno(Aluno _aluno);
        Aluno BuscarAluno(int _idAluno);
        Aluno AlterarAluno(Aluno _aluno);
        Aluno ExcluirAluno(Aluno _aluno);
    }
}
