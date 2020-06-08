using System;

namespace Exercico_override
{
    public class Relatorio
    {
        
        public DateTime data { get; set; }

        public virtual void MostrarRelatorio(){

            System.Console.WriteLine("Mostrar relatório geral");
        }
    }
}