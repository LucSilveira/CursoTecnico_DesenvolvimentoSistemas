using System;

namespace Usando_celular
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criando um novo objeto celular
            Celular motorola = new Celular();

            //atribuindo as informações aos atributos do objeto
            motorola.corAparelho = "preto";
            motorola.modeloAparelho = "Moto G (segunda geração)";
            motorola.tamanhoAparelho = 4.3f;

            // Chamando o método para ver se o usuário deseja ligar o aparelho
            Console.WriteLine("Deseja ligar seu aparelho ?");
            motorola.estadoAparelho = motorola.LigarAparelhoTraducao(Console.ReadLine());

            // Loop para caso o usuário não queira desligar o aparelho
            do{

                //Verificando se o usuário deseja realizar alguma tarefa
                Console.WriteLine("\nDeseja usar alguma função do seu aparelho?");
                string opcaoUsar = Console.ReadLine();

                //Caso queira, mostrar as opções de atividades do sistema
                while(opcaoUsar == "sim"){
                    
                    int opcaoFuncao;
                    Console.WriteLine("\n\nO que você gostaria de fazer?");
                    Console.WriteLine("\nDeseja fazer uma ligação? (Digite 1)");
                    Console.WriteLine("Deseja enviar uma mensagem? (Digite 2)");
                    opcaoFuncao = Int16.Parse(Console.ReadLine());

                    switch(opcaoFuncao){

                        // Método para caso o usuário queira realizar uma ligação
                        case 1:

                            Console.WriteLine(motorola.FazendoChamada(motorola.estadoAparelho));
                            break;

                        // Método para caso o usuário queira encaminhar uma mensagem
                        case 2:

                            Console.WriteLine(motorola.EnviarMensagem(motorola.estadoAparelho));
                            break;

                        // Verificando se o usuário não queira realizar uma tarefa não listada
                        default:
                            Console.WriteLine("Função não reconhecida pelo sistema!");
                            break;
                    }

                    //Verificando se o usuário ainda queira realizar tarefas
                    Console.WriteLine("\nDeseja fazer outra função?");
                    opcaoUsar = Console.ReadLine();
                }

                //Verificando se o usuário queira desligar o aparelho ou não
                Console.WriteLine("\nDeseja desligar seu aparelho ?");
                motorola.estadoAparelho = motorola.DesligarAparelho(Console.ReadLine());

            }while(motorola.estadoAparelho);
        }
    }
}
