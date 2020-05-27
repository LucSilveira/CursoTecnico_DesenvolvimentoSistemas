using System;

namespace Usando_celular
{
    public class Celular
    {
        
        public string corAparelho;

        public string modeloAparelho;

        public float tamanhoAparelho;

        public bool estadoAparelho;



        public bool LigarAparelho( string aparelho ){

            if(aparelho == "sim"){

                estadoAparelho = true;
            }else{

                estadoAparelho = false;
            }

            return estadoAparelho;
        }

        public bool DesligarAparelho( string aparelho ){

            if(aparelho == "sim"){

                estadoAparelho = false;
            }else{

                estadoAparelho = true;
            }

            return estadoAparelho;
        } 

        public string FazendoChamada( bool aparelho ){

            if(estadoAparelho){

                    Console.WriteLine("\nQual o número que deseja ligar? (Não precisa informar o DDD)");
                    int numeroTelefone = Int32.Parse(Console.ReadLine());

                    if(numeroTelefone.ToString().Length >= 8 && numeroTelefone.ToString().Length <= 9){

                        return "Realizando chamada";
                    }else{

                        return "Número inválido";
                    }
                    
            }else{

                return "Seu aparelho não está ligado";
            }
        }

        public string EnviarMensagem( bool aparelho ){

            if(estadoAparelho){

                    Console.WriteLine("\nQual o número que deseja enviar uma mensagem? (Não precisa informar o DDD)");
                    int numeroTelefone = Int32.Parse(Console.ReadLine());

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