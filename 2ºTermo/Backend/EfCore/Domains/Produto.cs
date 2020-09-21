using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore.Domains
{
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }

        // relacionamento com a tabela de pedido de iten (1 > N)
        public List<PedidoItem> PedidosItens { get; set; }
    }
}
