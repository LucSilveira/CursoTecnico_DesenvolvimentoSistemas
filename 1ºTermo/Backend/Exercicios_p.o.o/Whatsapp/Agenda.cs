using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Whatsapp
{
    public class Agenda : IAgenda
    {
        public List<Contato> ListaDeContatos { get; set; }
        private const string PATH = "DataBase/AgendaContato.csv";
        private const string PathBackup = "DataBase/AgendaBackup.csv";


        /// <summary>
        /// Método para criação do arquivo Csv e diretório para armazena-lo
        /// </summary>
        public Agenda()
        {
            // Separando o caminho entre a pasta e o arquivo
            string pasta = PATH.Split('/')[0];

            // Verificando se o Directorio para armazenar nosso arquivo Csv existe
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            // Verificando se o nosso arquivo Csv existe
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }

            // Verificando se existe o arquivo de backup
            if(!File.Exists(PathBackup))
            {
                File.Create(PathBackup);
            }
        }
 
        /// <summary>
        /// Método para inserir linhas com os dados informados pelo usuário
        /// </summary>
        /// <param name="ctt">Contato informado</param>
        /// <returns>Dados capturados pelo contato informado</returns>
        public string InserirLinhaComDados(Contato _ctt)
        {
            return $"Nome={_ctt.Nome};Telefone={_ctt.Telefone}";
        }

        /// <summary>
        /// Método para separar os parametros com seus dados
        /// </summary>
        /// <param name="_dados">Dados passados através das informações das linhas do arquivo</param>
        /// <returns>Parametros separados pelo caracter '='</returns>
        public string SepararInformacoes(string _dados)
        {
            return _dados.Split('=')[1];
        }

        public void ExcluirContato(Contato _contato)
        {
            List<string> contatosBackup = new List<string>();

            using(StreamReader arquivoCsv = new StreamReader(PATH))
            {
                string linhaDoContato;
                while((linhaDoContato = arquivoCsv.ReadLine()) != null)
                {
                    contatosBackup.Add(linhaDoContato);
                }
            }

            contatosBackup.RemoveAll(x => x.Contains(_contato.Nome));

            InserirBackupContato(_contato);
            
            ReescreverCsv(contatosBackup);
        }

        public List<Contato> BuscarContato(string _nomeContato)
        {
            List<Contato> contatoBuscado;

            contatoBuscado = ListarContatos().FindAll(x => x.Nome == _nomeContato);

            return contatoBuscado;
        }

        public void ReescreverCsv(List<string> _backup)
        {
            using(StreamWriter armazenamento = new StreamWriter(PATH))
            {
                foreach (string linhasBackup in _backup)
                {
                    armazenamento.Write(linhasBackup + "\n");
                }
            }
        }

        /// <summary>
        /// Método para adicionar uma linha no nosso arquivo com
        /// os dados capturados do contato informado
        /// </summary>
        /// <param name="_contato">Dados pertinentes do contato</param>
        public void IncluirContato(Contato _contato)
        {
            string[] linhaComDados = new string[]
            {
                InserirLinhaComDados(_contato)
            };

            File.AppendAllLines(PATH, linhaComDados);
        }

        public void InserirBackupContato(Contato _contato)
        {
            string[] linhaComDados = new string[]
            {
                InserirLinhaComDados(_contato)
            };

            File.AppendAllLines(PathBackup, linhaComDados);
        }

        /// <summary>
        /// Método para listas os contatos desejados
        /// </summary>
        /// <returns>Lista com os contatos armazenados no csv</returns>
        public List<Contato> ListarContatos()
        {
            ListaDeContatos = new List<Contato>();

            // Criando um array para guardar as linhas que contém no arquivo .Csv
            string[] linhasDoArquivo = File.ReadAllLines(PATH);

            foreach (string linhas in linhasDoArquivo)
            {
                string[] dadosContato = linhas.Split(';');

                // passando os valores da split para o método construtor
                Contato ctt = new Contato(SepararInformacoes(dadosContato[0]), SepararInformacoes(dadosContato[1]));

                // Adicionando o contato a lista
                ListaDeContatos.Add(ctt);
            }

            // Fazendo um filtro para listar por ordem dos nomes dos contatos
            ListaDeContatos = ListaDeContatos.OrderBy(x => x.Nome).ToList();

            // retornando a nossa lista de contatos
            return ListaDeContatos;
        }

        public void AlterarContato(Contato _contatoAlterado)
        {
            List<string> linhasTotalArquivo = new List<string>();

            using (StreamReader arquivoCsv = new StreamReader(PATH))
            {
                string linhaArquivo;
                while((linhaArquivo = arquivoCsv.ReadLine()) != null)
                {
                    linhasTotalArquivo.Add(linhaArquivo);
                }
            }

            linhasTotalArquivo.RemoveAll(x => x.Split(';')[0].Split('=')[1] == _contatoAlterado.Nome);

            linhasTotalArquivo.Add(InserirLinhaComDados(_contatoAlterado));

            ReescreverCsv(linhasTotalArquivo);
        }
    }
}