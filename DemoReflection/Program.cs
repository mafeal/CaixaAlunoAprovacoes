using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace DemoReflection
{
    [Display(Name = "Escola Ada")]
    public class Ada
    {
        private Dictionary<int, string> Nomes = [];
        public int TotalAlunos => Nomes.Count;

        public void Matricular([Required][NotNull] string nome, int RA)
        {
            Nomes.Add(RA, nome);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var tipo = typeof(Ada);
            var metodo = tipo.GetMethods().FirstOrDefault(x => x.Name == nameof(Ada.Matricular));
            var parametros = metodo.GetParameters();
            foreach (var parametro in parametros)
            {
                Console.WriteLine($"Nome: {parametro.Name}  - Tipo: {parametro.ParameterType.Name} -    Obrigatório: {VerificaObrigatoriedade(parametro)}");
            }
        }

        private static string VerificaObrigatoriedade(ParameterInfo parametro)
        {
            var anotacoes = parametro.GetCustomAttributesData();
            var required = anotacoes.Any(x => x.AttributeType == typeof(RequiredAttribute));

            return required ? "SIM" : "Não";
        }
    }
}
