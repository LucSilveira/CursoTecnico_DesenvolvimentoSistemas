namespace Exercico_override
{
    public class RelatorioMensal : Relatorio
    {
        
        public override void MostrarRelatorio(){

            base.MostrarRelatorio();

            System.Console.WriteLine("\nMostrando relatório por mês\n");
        }
    }
}