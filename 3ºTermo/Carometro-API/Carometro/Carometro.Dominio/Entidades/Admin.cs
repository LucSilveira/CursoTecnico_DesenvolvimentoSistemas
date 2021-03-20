using Carometro.Comum.Entidades;
using Carometro.Comum.Enum;
using Flunt.Br.Extensions;
using Flunt.Validations;
using System;

namespace Carometro.Dominio.Entidades
{
    public class Admin : Usuario
    {
        public Admin(string nomeUsuario, string email, string senha, string telefone)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nomeUsuario, 3, "Nome", "O Nome deve ter no mínimo 3 caractéres")
                .HasMaxLen(nomeUsuario, 40, "Nome", "O Nome deve ter no máximo 40 caractéres")
                .IsEmail(email, "Email", "Informe um Email válido")
                .IsNewFormatCellPhone(telefone, "Telefone", "Insira um Número de Telefone Válido")
                .HasMinLen(senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres")
                .HasMaxLen(senha, 60, "Senha", "A senha deve ter no mínimo 60 caractéres")
             );

            if (Valid)
            {

                NomeUsuario = nomeUsuario;
                Email = email;
                Senha = senha;
                Telefone = telefone;
                TipoUsuario = EnTipoUsuario.Administrador;
            }
        }

        public void AlterarAdmin(string nomeUsuario, string email, string telefone)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nomeUsuario, 3, "Nome", "O Nome deve ter no mínimo 3 caractéres")
                .HasMaxLen(nomeUsuario, 40, "Nome", "O Nome deve ter no máximo 40 caractéres")
                .IsEmail(email, "Email", "Informe um Email válido")
                .IsNewFormatCellPhone(telefone, "Telefone", "Insira um Número de Telefone Válido")
             );

            if (Valid)
            {

                NomeUsuario = nomeUsuario;
                Email = email;
                Telefone = telefone;
                DataAlteracao = DateTime.Now;
            }
        }

        public void Alterarsenha(string senha)
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
    }
}
