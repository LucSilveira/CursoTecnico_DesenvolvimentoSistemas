using APIBoletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Interfaces
{
    interface IAluno
    {
        List<Aluno> ListarAlunos();
        Aluno CadastrarAluno(Aluno _aluno);
        Aluno BuscarAluno(int _idAluno);
        Aluno AlterarAluno(Aluno _aluno, int _idAluno);
        Aluno ExcluirAluno(int _idAluno);
    }
}
