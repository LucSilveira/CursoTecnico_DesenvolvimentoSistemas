using System.IO;

namespace Csv_file
{
    public class Produto
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }

        private const string PATH = "Database/Produto.csv";

        /// <summary>
        /// Método para criar o diretorio juntamente ao arquivo csv
        /// com os dados pertinentes do produto
        /// </summary>
        public Produto()
        {

            string pasta = PATH.Split('/')[0];

            if(!Directory.Exists(pasta))
            {

                Directory.CreateDirectory(pasta);
            }

            if(!File.Exists(PATH))
            {

                File.Create(PATH).Close();
            }
        }

        /// <summary>
        /// Método para adicionar linhas com os dados pertinentes dos
        /// produtos ao nosso arquivo csv
        /// </summary>
        /// <param name="prd"></param>
        public void Cadastrar(Produto prd)
        {

            string[] linha = new string[]
            {
                PrepararLinha(prd)
            };

            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Método para definir quais dados seram inseridos no arquivo csv
        /// </summary>
        /// <param name="prd"></param>
        /// <returns>Dados dos arquivos</returns>
        private string PrepararLinha(Produto prd)
        {

            return  $"Codigo={prd.Codigo}; Nome={prd.Nome}; Preco={prd.Preco}";
        }
    }
}