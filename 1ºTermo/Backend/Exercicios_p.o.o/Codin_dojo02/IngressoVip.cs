namespace Codin_dojo02
{
    public class IngressoVip : Ingresso
    {
        public float ValorAdicional { get; set; }

        public void ImprimirValorVip()
        {
            float resultado = Valor + ValorAdicional;
            System.Console.WriteLine($"Valor do ingresso adicional é R$:{resultado}");
        }
    }
}