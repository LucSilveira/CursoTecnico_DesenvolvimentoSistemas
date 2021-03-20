using CodeTur.Comum.Domain;
using CodeTur.Comum.Enum;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Domains
{
    public class Usuario : BaseDomain
    {
        /// <summary>
        /// Construtor responsável por fazer a validação dos paramêtros do objeto usuário
        /// </summary>
        /// <param name="nome">Nome do usuário</param>
        /// <param name="email">Email de contato</param>
        /// <param name="senha">Senha de autorização</param>
        /// <param name="tipoPerfil">Perfil de acesso do usuário</param>
        public Usuario(string nome, string email, string senha, EnTipoPerfil tipoPerfil)
        {
            //Adicionando um contrato na aplicação para validação dos parametros
            //informados acerca do objeto usuário
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 3, "Nome", "O nome deve possuir no mínimo 3 caracteres")
                .HasMaxLen(nome, 50, "Nome", "O nome deve possuir no máximo 50 caracteres")
                .IsEmail(email, "Email", "Informe um email válido")
                .HasMinLen(senha, 6, "Senha", "A senha deve possuir no mínimo 6 caracteres")
                .HasMaxLen(senha, 80, "Senha", "A senha deve possuir no máximo 80 caracteres")
            );

            //Verificando se todos os atributos estão corretos
            //para atribuir a um novo objeto usuário
            if (Valid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                TipoPerfil = tipoPerfil;
            }
        }

        /// <summary>
        /// Método para adicionar um número de telefone ao usuário
        /// </summary>
        /// <param name="telefone">Número de telefone do cliente</param>
        public void AdicionarTelefone(string telefone)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNewFormatCellPhone(telefone, "Telefone", "Informe um telefone válido")
            );

            if (Valid)
            {
                Telefone = telefone;
            }
        }

        /// <summary>
        /// Método para alterar a senha do usuário
        /// </summary>
        /// <param name="senha">Nova senha informada</param>
        public void AlterarSenha(string senha)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(senha, 6, "Senha", "A senha deve possuir no mínimo 6 caracteres")
                .HasMaxLen(senha, 80, "Senha", "A senha deve possuir no máximo 80 caracteres")
            );

            if (Valid)
            {
                Senha = senha;
            }
        }

        /// <summary>
        /// Método para alterar os dados do usuário
        /// </summary>
        /// <param name="nome">Novo nome informado</param>
        /// <param name="email">Possível email adicionado ou alterado</param>
        public void AlterarUsuario(string nome, string email)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 3, "Nome", "O nome deve possuir no mínimo 3 caracteres")
                .HasMaxLen(nome, 50, "Nome", "O nome deve possuir no máximo 50 caracteres")
                .IsEmail(email, "Email", "Informe um email válido")
            );

            if (Valid)
            {
                Nome = nome;
                Email = email;
            }
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Telefone { get; private set; }
        public EnTipoPerfil TipoPerfil { get; private set; }

        //Adicionando um parametro de lista de comentários, para que possa
        //ser possivel acessar os comentários realizados por um usuário
        public IReadOnlyCollection<Comentario> Comentarios { get; set; }
    }
}
