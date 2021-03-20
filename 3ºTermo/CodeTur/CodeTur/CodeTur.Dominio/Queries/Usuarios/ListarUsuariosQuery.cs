using CodeTur.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Queries.Usuarios
{
    /// <summary>
    /// Classe responsável pela validação das querys caso necessite de alguma particularidade
    /// </summary>
    public class ListarUsuariosQuery : IQuery
    {
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }

    public class ListarUsuarioResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QuantidadeComentarios { get; set; }
    }
}
