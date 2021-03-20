using Carometro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carometro.Dominio.Repositorios
{
    public interface IAdminRepositorio
    {
        void Cadastrar(Admin admin);
        void Alterar(Admin admin);
        IEnumerable<Admin> Listar(bool? ativo = null);
        Admin BuscarPorEmail(string email);
        Admin BuscarPorId(Guid id);
        void Excluir(Admin admin);
    }
}
