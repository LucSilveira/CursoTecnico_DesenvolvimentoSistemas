using System;

namespace Usando_celular
{
    class Program
    {
        static void Main(string[] args)
        {
            Celular motorola = new Celular();

            motorola.corAparelho = "preto";
            motorola.modeloAparelho = "Moto G (segunda geração)";
            motorola.tamanhoAparelho = 4.3f;

            Console.WriteLine("Deseja ligar seu aparelho ?");
            motorola.estadoAparelho = motorola.LigarAparelho(Console.ReadLine());

            do{

                Console.WriteLine("\nDeseja usar alguma função do seu aparelho?");
                string opcaoUsar = Console.ReadLine();

                while(opcaoUsar == "sim"){
                    
                    int opcaoFuncao;
                    Console.WriteLine("\n\nO que você gostaria de fazer?");
                    Console.WriteLine("\nDeseja fazer uma ligação? (Digite 1)");
                    Console.WriteLine("Deseja enviar uma mensagem? (Digite 2)");
                    opcaoFuncao = Int16.Parse(Console.ReadLine());

                    switch(opcaoFuncao){

                        case 1:

                            Console.WriteLine(motorola.FazendoChamada(motorola.estadoAparelho));
                            break;

                        case 2:

                            Console.WriteLine(motorola.EnviarMensagem(motorola.estadoAparelho));
                            break;

                        default:
                            Console.WriteLine("Função não reconhecida pelo sistema!");
                            break;
                    }

                    Console.WriteLine("\nDeseja fazer outra função?");
                    opcaoUsar = Console.ReadLine();
                }


                Console.WriteLine("\nDeseja desligar seu aparelho ?");
                motorola.estadoAparelho = motorola.DesligarAparelho(Console.ReadLine());

            }while(motorola.estadoAparelho);
        }
    }
}
