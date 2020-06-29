using System.IO;

namespace Csv_file
{
    public class Produto
    {
        
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }


        // private const string PATH = "Database/produto.csv";
        private const string FullPath = @"C:\Users\lucas\Desktop\DEV-SENAI\1ºTermo\Backend\Exercicios_p.o.o\Csv_file\DataBase";
        private const string FileName = @"C:\Users\lucas\Desktop\DEV-SENAI\1ºTermo\Backend\Exercicios_p.o.o\Csv_file\DataBase\Produto.csv";


        /// <summary>
        /// Método para criar o diretorio juntamente ao arquivo csv
        /// com os dados pertinentes do produto
        /// </summary>
        public Produto(){

            if(!Directory.Exists(FullPath)){

                Directory.CreateDirectory(FullPath);
            }

            if(!File.Exists(FileName)){

                File.Create(FileName).Close();
                System.IO.Path.Combine(FullPath, FileName);
            }
        }


        /// <summary>
        /// Método para adicionar linhas com os dados pertinentes dos
        /// produtos ao nosso arquivo csv
        /// </summary>
        /// <param name="prd"></param>
        public void Cadastrar(Produto prd){

            string[] linha = new string[] {

                PrepararLinha(prd)
            };

            File.AppendAllLines(FileName, linha);
        }


        /// <summary>
        /// Método para definir quais dados seram inseridos no arquivo csv
        /// </summary>
        /// <param name="prd"></param>
        /// <returns>Dados dos arquivos</returns>
        private string PrepararLinha(Produto prd){

            return  $"Codigo={prd.Codigo}; Nome={prd.Nome}; Preco={prd.Preco}";
        }
    }
}