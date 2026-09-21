using CaixaAlunoAprovacoesApp.Calculadoras;
using CaixaAlunoAprovacoesApp.Readers;
using System.Reflection;

namespace CaixaAlunoAprovacoesApp.Factories
{
    public static class CalculadoraMediasFactory
    {
        private static Dictionary<string, Type> tipos = [];
        static CalculadoraMediasFactory()
        {
            tipos = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsAssignableTo(typeof(ICalculadoraMedia)) &&
                            !x.IsInterface &&
                            !x.IsAbstract)
            .ToDictionary(x => x.GetCustomAttribute<NomeCalculadoraAttribute>()!.Algoritmo , x => x, StringComparer.OrdinalIgnoreCase);
        }

        public static ICalculadoraMedia Create(string nome)
        {
            tipos.TryGetValue(nome, out var tipo);
            var instancia = Activator.CreateInstance(tipo!) as ICalculadoraMedia;

            return instancia!;
        }
    }
}
