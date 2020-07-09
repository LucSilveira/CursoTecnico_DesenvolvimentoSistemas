using System;
using System.Collections.Generic;

namespace Whatsapp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variaveis que serão usadas
            string nomeContato;
            string telefoneContato;
            List<Contato> listaContatos;

            Console.WriteLine("Bem vindo ao projeto Whatsapp console\n");

            Agenda agendaContato = new Agenda();

            int opcaoSelecionada;
            do{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n(leia atentamente as opções de ações de acordo com o menu)");
                Console.ResetColor();
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Opção ( 1 )\t-\tAdicionar um novo contato");
                Console.WriteLine("Opção ( 2 )\t-\tVer meus contatos");
                Console.WriteLine("Opção ( 3 )\t-\tEnviar mensagem para um contato");
                Console.WriteLine("Opção ( 4 )\t-\tAlterar dados de um contato");
                Console.WriteLine("Opção ( 5 )\t-\tExcluir um contato");
                Console.WriteLine("Opção ( 6 )\t-\tFechar o aplicativo");
                Console.ResetColor();
                opcaoSelecionada = Int16.Parse(Console.ReadLine());

                switch (opcaoSelecionada)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInforme os dados do contato...\n");
                        Console.ResetColor();

                        Console.WriteLine("Insira um nome para o contato:");
                        nomeContato = Console.ReadLine();

                        Console.WriteLine($"\nInsira o número de telefone de {nomeContato}:");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("(informar o ddd junto ao telefone, exemplo 119...)");
                        Console.ResetColor();
                        telefoneContato = "+55" + Console.ReadLine();

                        Contato novoContato = new Contato(nomeContato, telefoneContato);
                        agendaContato.IncluirContato(novoContato);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n\nAdicionando contato:\t{nomeContato}, {telefoneContato}");
                        Console.WriteLine("Adicionado com sucesso...");
                        Console.ResetColor();
                        break;

                    case 2:
                        Console.WriteLine("\nListando seus contatos...\n");

                        listaContatos = agendaContato.ListarContatos();

                        foreach (Contato _contato in listaContatos)
                        {
                            Console.WriteLine($"Nome: {_contato.Nome}, telefone: {_contato.Telefone}");
                        }
                                               
                        break;

                    case 3:
                        Console.WriteLine("\nInforme o nome do contato que queira enviar uma mensagem:");
                        nomeContato = Console.ReadLine();

                        Console.WriteLine("\nInsira a mensagem que deseja enviar:");
                        string textoMensagem = Console.ReadLine();

                        listaContatos = agendaContato.BuscarContato(nomeContato);
                        Mensagem mensagem = new Mensagem();

                        foreach (Contato _contato in listaContatos)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"\n\n{mensagem.EnviarMenagem(_contato, textoMensagem)}");
                            Console.ResetColor();
                        }

                        break;

                    case 4:
                        Console.WriteLine("\nInforme o nome do contato que queira atualizar os dados:");
                        nomeContato = Console.ReadLine();

                        listaContatos = agendaContato.BuscarContato(nomeContato);

                        foreach (Contato _contato in listaContatos)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"\nDados do contato: {_contato.Nome}, {_contato.Telefone}");
                            Console.ResetColor();
                        }

                        Console.WriteLine("\nInforme os dados que queira alterar, seja o nome ou telefone");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("(separe os dados a serem alterados po vírgula, exemplo (Fulano, 119...))");
                        Console.WriteLine("(caso não queire alterar algum dado, informe o dado que já esteja em uso, exemplo ('Nome do contato', 119...))");
                        Console.ResetColor();
                        string[] dadosInformados = Console.ReadLine().Split(", ");

                        Console.WriteLine("\nDados antigos do contato...");

                        foreach (Contato _contato in listaContatos)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"Contato: {_contato.Nome}, telefone: {_contato.Telefone}");
                            Console.ResetColor();
                        }

                        Contato _contatoAlterado = new Contato(dadosInformados[0], dadosInformados[1]);

                        Console.WriteLine("\nNovos dados do contato...");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Contato: {_contatoAlterado.Nome}, telefone: {_contatoAlterado.Telefone}");
                        Console.ResetColor();

                        agendaContato.AlterarContato(_contatoAlterado);

                        Console.WriteLine($"\nAtualizado com sucesso ");
                        break;

                    case 5:
                        Console.WriteLine("\nInforme o nome do contato que deseja excluir:");
                        nomeContato = Console.ReadLine();

                        listaContatos = agendaContato.BuscarContato(nomeContato);

                        foreach (Contato _contato in listaContatos)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"\nExcluindo contato: {_contato.Nome}, {_contato.Telefone}");

                            agendaContato.ExcluirContato(_contato);
                        }

                        Console.WriteLine("\nContato excluido com sucesso...");
                        Console.ResetColor();
                        break;

                    case 6:
                        Console.WriteLine("\nFechando aplicativo...\tMuito obrigado, volte sempre;\n");
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }


            }while(opcaoSelecionada != 6);
        }
    }
}
