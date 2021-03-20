using CodeTur.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Queries.Pacotes
{
    /// <summary>
    /// Classe responsável pela validação das querys caso necessite de alguma particularidade
    /// </summary>
    public class ListarPacotesQuery : IQuery
    {
        public void Validar()
        {
            throw new NotImplementedException();
        }

        public bool? Ativo { get; set; } = null;
    }

    /// <summary>
    /// Classe responsável por definir quais os parametros serão exibidos nas nossas queries
    /// </summary>
    public class ListarPacotesResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
        public int QuantidadeComentarios { get; set; }
        public DateTime DataCriacao { get; set; }
    }
    
}
