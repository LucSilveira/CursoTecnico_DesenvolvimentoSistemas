using System.Collections.Generic;

namespace Whatsapp
{
    public interface IAgenda
    {
        void IncluirContato(Contato _contato);

        void ExcluirContato(Contato _contato);

        List<Contato> ListarContatos();

        void AlterarContato(Contato _contatoAlterado);
    }
}