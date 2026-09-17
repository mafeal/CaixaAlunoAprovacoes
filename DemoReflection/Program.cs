using CaixaAlunoAprovacoesApp;
using CaixaAlunoAprovacoesApp.DTO;
using System.Globalization;
using System.Reflection;

namespace DemoReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tipo de Dados pra guardar informações SOBRE TIPOS DE DADOS
            var tipo = typeof(Turma);
            var turma = Activator.CreateInstance<Turma>();

            var propriedades = tipo.GetProperties();
            var propriedadeAno = propriedades.FirstOrDefault(x => x.Name == nameof(Turma.Ano));
            propriedadeAno.SetValue(turma, 1987);

            //var propriedadeDisciplina = propriedades.FirstOrDefault(x => x.Name == nameof(Turma.Disciplina));
            //propriedadeDisciplina.SetValue(turma, "POO 2");
            var fields = tipo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var disciplinaField = fields.FirstOrDefault(x => x.Name.Contains(nameof(Turma.Disciplina)) && x.Name.EndsWith("BackingField"));
            disciplinaField.SetValue(turma, "POO 2");

            Console.WriteLine(turma.Disciplina);

            IEnumerable<Aluno> alunos = [new Aluno { RA = "123456", Nome = "Paulo" }, new Aluno { RA = "654321", Nome = "Ricardo" }];
            var metodoMatricular = tipo.GetMethods().FirstOrDefault(x => x.Name == nameof(Turma.Matricular));
            metodoMatricular.Invoke(turma, [alunos]);

            foreach (var aluno in turma)
            {
                Console.WriteLine($"{aluno.Nome}");
            }

            var mostrarQuantidade = tipo.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x => x.Name == "QuantidadeDeAlunos");
            var quantidade = mostrarQuantidade.Invoke(turma, null);
            Console.WriteLine($"Turma com {quantidade} alunos");

            /*
            var propriedades = tipoTurma.GetProperties();
            Console.WriteLine("Propriedades:");
            foreach (var propriedade in propriedades)
                Console.WriteLine($"Nome: {propriedade.Name} - Tipo: {propriedade.PropertyType.Name}");

            Console.WriteLine("Metodos:");
            var metodos = tipoTurma.GetMethods();
            foreach (var metodo in metodos)
            {
                Console.WriteLine($"Nome: {metodo.Name} - Numero Parametros: {metodo.GetParameters().Length}");
                Console.WriteLine($"Tipo de Retorno: {metodo.ReturnType}");
            }
            */
        }
    }
}
