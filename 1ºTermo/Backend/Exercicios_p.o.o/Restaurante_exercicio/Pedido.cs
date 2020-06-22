using System;

namespace Restaurante_exercicio
{
    public class Pedido
    {
        public string[] Itens { get; set; }

        public Cliente Cliente { get; set; }

        public Restaurante Restaurante { get; set; }

        public string FormatoPagamento { get; set; }

        public bool PedidoPago { get; set; }

        public DateTime HorarioPedido { get; set; }

        public string EntregarPedido(){

            HorarioPedido = DateTime.Now;

            string retorno = "Pedido entregue\n\n";
            retorno += Restaurante.MostrarDados();
            retorno += "\n" + Cliente.MostrarDados();
            retorno += "\n" + HorarioPedido;

            return retorno;

            // return $"Cliente : {Cliente.NomeCliente}, Restaurante : {Restaurante.NomeRestaurante}";
        }
    }
}