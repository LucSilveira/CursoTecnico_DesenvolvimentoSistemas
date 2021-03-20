using Carometro.Dominio.Entidades;
using Carometro.Dominio.Repositorios;
using Carometro.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Infra.Data.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly CarometroContext _context;

        public AlunoRepositorio(CarometroContext context)
        {
            _context = context;
        }

        public void Cadastrar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public ICollection<Aluno> Listar()
        {
            return _context.Alunos.AsNoTracking()
                                    .OrderBy(x => x.DataCriacao)
                                    .ToList();
        }

        public Aluno BuscarPorEmail(string email)
        {
            return _context.Alunos.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public Aluno BuscarPorRg(string rg)
        {
            return _context.Alunos.FirstOrDefault(x => x.Rg == rg);
        }

        public Aluno BuscarPorId(Guid idAluno)
        {
            return _context.Alunos.FirstOrDefault(x => x.Id == idAluno);
        }

        public void Alterar(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }
    }
}
