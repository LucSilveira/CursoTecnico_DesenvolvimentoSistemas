using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Domains
{
    public class Produto
    {
        // Para questão de segurança da aplicação é usado o Guid
        // para evitar que seja identificado o id do objeto e evitar infrações de segurança
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        public Produto()
        {
            Id = Guid.NewGuid();
        }
    }
}
