using System;

namespace EstruturaDados_uber
{
    class Program
    {
        static void Main(string[] args)
        {
            Passageiro passageiro = new Passageiro();

            Console.WriteLine("Digite seu login:");
            string login = Console.ReadLine();

            Console.WriteLine("Digite sua senha:");
            string senha = Console.ReadLine();

            passageiro.Login(login, senha);

            if(passageiro.TokenLogin != "" && passageiro.TokenLogin != null)
            {
                Console.WriteLine("Login Autorizado!");

                // Instaciamento do motorista
                Motorista motorista = new Motorista();
                motorista.Nome = "Carlos";
                motorista.Placa = "ABC-1234";
                motorista.Carro = "Gol";

                // Cadastrando uma conta de motorista
                passageiro.Nome = "Lucas Silveira";
                passageiro.Idade = 19;
                passageiro.LocalizacaoAtual = "Rua da prata, 132";

                // Salvando um cartão para o usuário
                Cartao cartao = new Cartao();
                cartao.Cadastrar();

                passageiro.SolicitarMotorista();
                motorista.AceitarPassageiro(passageiro.Nome);

                // Iniciando uma corrida
                Corrida corrida = new Corrida();
                corrida.LocalInicio = passageiro.LocalizacaoAtual;
                corrida.LocalChegada = "Av do Estados, 123";
                corrida.Motorista = motorista.Nome;
                corrida.Passageiro = passageiro.Nome;

                string resposta = "Não chegamos";

                while(resposta != "Sim")
                {
                    Console.WriteLine("Você chegou ao seu destino? (Digite sim ou não)");
                    resposta = Console.ReadLine();
                }

                // Finalizando a corrida
                corrida.StatusCorrida = "Finalizada";
                passageiro.Pagar(corrida.StatusCorrida);
                motorista.ReceberPagamento(corrida.StatusCorrida);

                // Realizamos o pagamento
                Pagamento pagamento= new Pagamento();
                pagamento.Data = DateTime.Now;
                pagamento.StatusPagamento = "Pago";

                Console.WriteLine("Corrida finalizada");
                Console.WriteLine("Status corrida: " + corrida.StatusCorrida);
                Console.WriteLine("Status pagamento: " + pagamento.StatusPagamento);
                Console.WriteLine("Data e hora: " + pagamento.Data);
                Console.WriteLine("Motorista: " + motorista.Nome);
            
            }
            else
            {
                Console.WriteLine("Não é possível utilizar o app");
            }
        }
    }
}
