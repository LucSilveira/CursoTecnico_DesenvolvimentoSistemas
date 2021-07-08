using DoLink.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoLink.Dominio.Repositories
{
    public interface IAdminRepository
    {
        Task<Administrador> BuscarAdmin(string _email);
        Task<Administrador> AlterarSenhaAdmin(Administrador admin);
    }
}
