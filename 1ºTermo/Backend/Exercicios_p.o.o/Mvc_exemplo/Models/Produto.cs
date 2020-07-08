using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mvc_exemplo.Models
{
    public class Produto
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }

        private const string PATH = "DataBase/Produto.csv";

        public List<Produto> LerProdutos()
        {
            // Criando uma lista para guardar os retornos
            List<Produto> produtos = new List<Produto>();

            // Criando um array para salvar as linhas do arquivo .csv
            string[] linhas = File.ReadAllLines(PATH);

            foreach (string linha in linhas)
            {
                string[] dado = linha.Split(';');

                Produto p = new Produto();
                p.Codigo = Int32.Parse(Separar(dado[0]));
                p.Nome = Separar(dado[1]);
                p.Preco = float.Parse(Separar(dado[2]));

                produtos.Add(p);
            }

            produtos = produtos.OrderBy(y => y.Nome).ToList();

            return produtos;
        }

        public string Separar(string dado){

            return dado.Split('=')[1];
        }
    }
}