
namespace CaixaAlunoAprovacoesApp.Calculadoras
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class NomeCalculadoraAttribute : Attribute
    {
        public NomeCalculadoraAttribute(string Algoritmo)
        {
            this.Algoritmo = Algoritmo;
        }

        public string Algoritmo { get; }
    }
}