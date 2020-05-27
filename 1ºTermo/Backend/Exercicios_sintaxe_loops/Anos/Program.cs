using System;

namespace Anos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine ("Retornando a idade do usuário nos seguintes tópicos: Dias, Meses, Horas eMinutos\n");

            // Entrada de dados
            Console.WriteLine("Informe a data de seu nascimento");
            DateTime dataNascimento = new DateTime();
            dataNascimento = DateTime.Parse(Console.ReadLine());

            DateTime dataAtual = DateTime.Now;


            // Processamento

            //Validando se a data de nascimento não é maior do que hoje
            if(dataNascimento > DateTime.Now){
                Console.WriteLine("Data de aniversário inválida");

            }else{
                int anoUsuario = 0;
                int mesesUsuario = 0;
                int diasUsuario = 0;
                int horasUsuario = 0;
                int minutosUsuario = 0;

                // Calculando quantos anos possuí a pessoa
                anoUsuario = dataAtual.Year - dataNascimento.Year;

                // Verficando se a pessoa está fazendo aniversário neste mês
                if(dataAtual.Month ==  dataNascimento.Month){

                    mesesUsuario = anoUsuario * 12;

                // Verificando se a pessoa já fez aniversário neste mês
                }else if(dataAtual.Month > dataNascimento.Month){
                    
                    mesesUsuario += dataAtual.Month - dataNascimento.Month;

                // caso a pessoa ainda não fez aniversário neste mês
                }else{

                    anoUsuario -= 1;
                    mesesUsuario = anoUsuario * 12;
                    mesesUsuario += 12 - (dataNascimento.Month - dataAtual.Month);
                }

                //Caso a pessoa faça aniversário hoje
                diasUsuario = anoUsuario * 365;
                
                // Verificando se a pessoa já fez aniversário no dia de hoje
                if(dataAtual.Day > dataNascimento.Day){

                    diasUsuario += dataAtual.Day - dataNascimento.Day;
                
                // caso a pessoa ainda não fez aniversário no dia de hoje
                }else{

                    if(anoUsuario != 0){

                        mesesUsuario -= 1;
                        diasUsuario -= dataNascimento.Day - dataAtual.Day;
                    }else{

                        mesesUsuario -= 1;
                        diasUsuario = 365 - (dataNascimento.Day - dataAtual.Day);
                    }
                }

                // Calculando as horas da pessoa
                horasUsuario = (diasUsuario * 24) + dataAtual.Hour;

                minutosUsuario = (horasUsuario * 60) + dataAtual.Minute;

                Console.WriteLine("\n\nExibindo nossos resultados ...");
                Console.WriteLine($"Você possuí: " + anoUsuario + "anos vividos");
                Console.WriteLine($"Você possuí: " + diasUsuario + "dias vividos");
                Console.WriteLine($"Você possuí: " + mesesUsuario + "meses vividos");
                Console.WriteLine($"Você possuí: " + horasUsuario + "horas vividos");
                Console.WriteLine($"Você possuí: " + minutosUsuario + "minutos vividos\n");
            }
        }
    }
}
