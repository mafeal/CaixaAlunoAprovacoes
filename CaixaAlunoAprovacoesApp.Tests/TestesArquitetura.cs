using CaixaAlunoAprovacoesApp.Calculadoras;
using System.Reflection;
using Xunit.Abstractions;

namespace CaixaAlunoAprovacoesApp.Tests
{
    public class TestesArquitetura
    {
        private readonly ITestOutputHelper outputHelper;
        public TestesArquitetura(ITestOutputHelper outputHelper)
            => this.outputHelper = outputHelper;

        [Fact]
        public void TodaCalculadora_TemPrefixo_CalculadoraMedia()
        {
            var implementacoesConcretas = typeof(ICalculadoraMedia).Assembly.GetTypes()
                                .Where(x => x.IsAssignableTo(typeof(ICalculadoraMedia)) &&
                                            !x.IsInterface &&
                                            !x.IsAbstract);

            foreach (var implementacao in implementacoesConcretas)
            {
                if (!implementacao.Name.StartsWith("CalculadoraMedia"))
                {
                    var mensagem = $"O nome do tipo {implementacao.FullName} não começa com o prefixo CalculadoraMedia";
                    outputHelper.WriteLine(mensagem);
                    Assert.Fail(mensagem);
                }
            }
        }

        [Fact]
        public void AnotacaoNomeDaCalculadora_SoPodeSerUsada_EmImplementacoesDeCalculadora()
        {
            var tiposAnotados = typeof(ICalculadoraMedia).Assembly.GetTypes()
                .Where(x => x.GetCustomAttribute<NomeCalculadoraAttribute>() != null &&
                            !x.IsInterface &&
                            !x.IsAbstract);

            var naoEhImplementacao = tiposAnotados.Any(x => !x.IsAssignableTo(typeof(ICalculadoraMedia)));
            Assert.False(naoEhImplementacao, "Alguma classe anotada com " +
                "[NomeCalculadoraAttribute] não implementa ICalculadoraMedia");
        }
    }
}
