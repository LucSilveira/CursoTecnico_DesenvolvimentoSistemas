using EduxProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categorias>> ListarCategorias();
        Task<Categorias> BuscarCategoriaPorId(int _idCategoria);
        Task<Categorias> CadastrarCategoria(Categorias _categoria);
        Task<Categorias> AlterarCategoria(Categorias _categoria);
        Task<Categorias> ExcluirCategoria(Categorias _categoria);
    }
}
