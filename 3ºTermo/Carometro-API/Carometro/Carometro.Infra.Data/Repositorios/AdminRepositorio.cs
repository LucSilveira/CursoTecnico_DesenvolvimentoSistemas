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
    public class AdminRepositorio : IAdminRepositorio
    {

        private readonly CarometroContext _context;
        public AdminRepositorio(CarometroContext context)
        {
            _context = context;
        }

        public void Cadastrar(Admin admin)
        {

            _context.Admins.Add(admin);
            _context.SaveChanges();

        }
        public IEnumerable<Admin> Listar(bool? ativo = null)
        {
            return _context.Admins
                                    .AsNoTracking()
                                    .OrderBy(x => x.DataCriacao)
                                    .ToList();
        }

        public Admin BuscarPorEmail(string email)
        {
            return _context.Admins.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public Admin BuscarPorId(Guid id)
        {
            return _context.Admins.FirstOrDefault(x => x.Id == id);
        }

        public void Alterar(Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Admin admin)
        {
            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }
    }
}
