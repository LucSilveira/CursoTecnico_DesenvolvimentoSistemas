using DoLink.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoLink.Dominio.Repositories
{
    public interface IEmpresaRepository
    {
        Task<List<Empresa>> ListarEmpresa();
        Task<Empresa> BuscarDadosEmpresa(string _idEmpresa);
        Task<Empresa> CadastrarEmpresa(Empresa _empresa);
        Task<Empresa> BuscarPorEmail(string email);
        Task<Empresa> BuscarEmpresaPorCpnj(string _cnpj);
        Task<Empresa> AlterarEmpresaRepositorie(string id,Empresa _empresa);
        Task<Empresa> ExcluirEmpresa(Empresa empresa);
    }         
}
