using DoLink.Comum.Commands;
using DoLink.Dominio.Entidades;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;
using DoLink.Comum.Utils;

namespace DoLink.Dominio.Commands.Profissionais
{
    public class CadastrarProfissionalCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(Nome, 3, "Nome de usuário", "O nome deve ter no mínimo 3 caractéres")
               .IsEmail(Email, "Email", "Informe um Email válido")
               .IsNewFormatCellPhone(Telefone, "Telefone", "Insira um número de telefone válido")
               .HasMinLen(Senha, 6, "Senha", "A senha deve ter no mínimo 6 caractéres")
            );
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
    }
}
