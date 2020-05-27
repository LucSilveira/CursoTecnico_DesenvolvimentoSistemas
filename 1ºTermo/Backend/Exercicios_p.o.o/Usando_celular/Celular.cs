using System;

namespace Usando_celular
{
    public class Celular
    {
        
        public string corAparelho;

        public string modeloAparelho;

        public float tamanhoAparelho;

        public bool estadoAparelho;


        /// <summary>
        /// Método para interpretar se o usuário quer ligar o aparelho
        /// </summary>
        /// <param name="aparelho"></param>
        /// <returns>Celular ligado(sim/true) ou continuar desligado(não/false)</returns>
        public bool LigarAparelhoTraducao( string aparelhoLigado ){

            //Caso o usuário deseja ligar ou não
            if(aparelhoLigado == "sim"){

                estadoAparelho = true;
            }else{

                estadoAparelho = false;
            }

            return estadoAparelho;
        }

        /// <summary>
        /// Método para interpretar se o usuário quer desligar o aparelho
        /// </summary>
        /// <param name="aparelho"></param>
        /// <returns>Celular desligado(sim/true) ou continuar ligado(não/false)</returns>
        public bool DesligarAparelho( string aparelhoDesligado ){

            //Caso o usuário deseja desligar ou não
            if(aparelhoDesligado == "sim"){

                estadoAparelho = false;
            }else{

                estadoAparelho = true;
            }

            return estadoAparelho;
        } 

        /// <summary>
        /// Método para realizar uma ligação
        /// </summary>
        /// <param name="aparelho"></param>
        /// <returns>Se é possivel fazer a ligação ou não</returns>
        public string FazendoChamada( bool aparelho ){

            if(estadoAparelho){

                    Console.WriteLine("\nQual o número que deseja ligar? (Não precisa informar o DDD)");
                    int numeroTelefone = Int32.Parse(Console.ReadLine());

                    //Verificando se o número é compativél ou não
                    if(numeroTelefone.ToString().Length >= 8 && numeroTelefone.ToString().Length <= 9){

                        return "Realizando chamada";
                    }else{

                        return "Número inválido";
                    }
                    
            }else{

                return "Seu aparelho não está ligado";
            }
        }

        /// <summary>
        /// Método para realizar o envio de mansagem
        /// </summary>
        /// <param name="aparelho"></param>
        /// <returns>Se é possivel enviar uma mensagem ou não</returns>
        public string EnviarMensagem( bool aparelho ){

            if(estadoAparelho){

                    Console.WriteLine("\nQual o número que deseja enviar uma mensagem? (Não precisa informar o DDD)");
                    int numeroTelefone = Int32.Parse(Console.ReadLine());

                    //Verificando se o número é compativél ou não
                    if(numeroTelefone.ToString().Length >= 8 && numeroTelefone.ToString().Length <= 9){

                        return "Enviando mensagem";
                    }else{

                        return "Número não localizado";
                    }
                    
            }else{

                return "Seu aparelho não está ligado";
            }
        }
    }
}