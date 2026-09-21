namespace CaixaAlunoAprovacoesApp.Calculadoras
{
    public partial class Algoritmos 
    {
        public const string Aritmetica = nameof(Aritmetica);
    }

    [NomeCalculadora(Algoritmos.Aritmetica)]
    public class CalculadoraMediaAritmetica : ICalculadoraMedia
    {
        public decimal Calcular(decimal[] notas)
            => notas.Average();
    }
}
