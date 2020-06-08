namespace Exercico_override
{
    public class RelatorioAnual : Relatorio
    {

        public override void MostrarRelatorio(){

            base.MostrarRelatorio();

            System.Console.WriteLine("\nMostrando relatório por ano\n");
        }   
    }
}