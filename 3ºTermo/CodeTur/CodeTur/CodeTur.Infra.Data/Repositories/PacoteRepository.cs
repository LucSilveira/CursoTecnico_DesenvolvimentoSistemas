using CodeTur.Dominio.Domains;
using CodeTur.Dominio.Repositories;
using CodeTur.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Infra.Data.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        //Definindo a chamada do context do banco de dados
        private readonly CodeTurContext _context;

        //Definindo que os métodos da classe, vão exigir nosso contexto
        public PacoteRepository(CodeTurContext _codeTurContext)
        {
            _context = _codeTurContext;
        }

        /// <summary>
        /// Método para listar os pacotes de acordo com seus status
        /// </summary>
        /// <param name="ativo">Status de ativação do pacote</param>
        /// <returns>Lista a cerca dos pacotes do sistema</returns>
        public IEnumerable<Pacote> ListarPacotes(bool? ativo)
        {
            if (ativo != null)
            {
                return _context.Pacotes.AsNoTracking().Include(pct => pct.Comentarios)
                                            .Where(pct => pct.Ativo == ativo).OrderBy(pct => pct.DataCriacao);
            }
            else
            {
                return _context.Pacotes.AsNoTracking().Include(pct => pct.Comentarios).OrderBy(pct => pct.DataCriacao);
            }
        }

        /// <summary>
        /// Método para buscar os dados de um pacote através do Id
        /// </summary>
        /// <param name="_idPacote">Código de identificação do pacote</param>
        /// <returns>Dados a cerca do pacote procurado</returns>
        public Pacote BuscarPacotePorId(Guid _idPacote)
        {
            return _context.Pacotes.FirstOrDefault(pct => pct.Id == _idPacote);
        }

        /// <summary>
        /// Método para buscar os dados de um pacote através do título
        /// </summary>
        /// <param name="_titulo">Título pertencente ao pacote</param>
        /// <returns>Dados a cerca do pacote procurado</returns>
        public Pacote BuscarPacotePorTitulo(string _titulo)
        {
            return _context.Pacotes.FirstOrDefault(pct => pct.Titulo.ToLower() == _titulo.ToLower());
        }

        /// <summary>
        /// Método para adicionar um novo pacote no sistema
        /// </summary>
        /// <param name="_pacote">Dados a serem cadastrados</param>
        public void AdicionarPacote(Pacote _pacote)
        {
            _context.Pacotes.Add(_pacote);
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para alterar os dados de um pacote
        /// </summary>
        /// <param name="_pacote">Novos dados a serem alterados</param>
        public void AlterarPacote(Pacote _pacote)
        {
            _context.Entry(_pacote).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Método para excluir um pacote do sistema
        /// </summary>
        /// <param name="_pacote">Dados referente ao pacote excluido</param>
        public void ExcluirPacote(Pacote _pacote)
        {
            if(_pacote.Comentarios != null)
            {
                _context.Comentarios.RemoveRange(_context.Comentarios.Where(cmt => cmt.IdPacote == _pacote.Id));
            }

            _context.Remove(_pacote);
            _context.SaveChanges();
        }
    }
}
