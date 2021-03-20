using CodeTur.Dominio.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Repositories
{
    /// <summary>
    /// Interface do pacote com os métodos contidos para os pacotes
    /// </summary>
    public interface IPacoteRepository
    {
                /// <summary>
        /// Listar todos os pacote de acordo com seu status
        /// </summary>
        /// <param name="ativo">Status de ativação dos pacotes</param>
        /// <returns>Lista com os pacotes de acordo com o status</returns>
        IEnumerable<Pacote> ListarPacotes(bool? ativo = null);

        /// <summary>
        /// Busca por um pacote específico
        /// </summary>
        /// <param name="_titulo">Novo do pacote desejado</param>
        /// <returns>Dados referente ao pacote</returns>
        Pacote BuscarPacotePorTitulo(string _titulo);

        /// <summary>
        /// Busca por um pacote específico
        /// </summary>
        /// <param name="_idPacote">Código de identificação do pacote</param>
        /// <returns>Dados referente ao pacote</returns>
        Pacote BuscarPacotePorId(Guid _idPacote);

        /// <summary>
        /// Adicionar um novo pacote
        /// </summary>
        /// <param name="_pacote">Dados relativos ao novo pacote</param>
        void AdicionarPacote(Pacote _pacote);

        /// <summary>
        /// Alterar os dados do pacote especificado
        /// </summary>
        /// <param name="_pacote">Novos dados do pacote</param>
        void AlterarPacote(Pacote _pacote);

        /// <summary>
        /// Excluir pacote do sistema
        /// </summary>
        /// <param name="_pacote">ados do pacote a serem excluidos</param>
        void ExcluirPacote(Pacote _pacote);
    }
}
