using System;

namespace TryCath_exercicio
{
    public class Permissao
    {
        private bool acesso { get; set; }

        public void Autorizacao(){

            try{

                System.Console.WriteLine("Acessar aplicação?");
                System.Console.WriteLine("True ou False");
                acesso = Boolean.Parse(Console.ReadLine());
            
            }catch(System.Exception){

                System.Console.WriteLine("Erro nas informações inseridas");
                throw;
            }
        }
    }
}