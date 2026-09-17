using CaixaAlunoAprovacoesApp.DTO;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace CaixaAlunoAprovacoesApp
{
    public class Turma : IEnumerable<Aluno>
    {
        private List<Aluno> alunos = [];
        public int Ano { get; private set; }
        public string Disciplina { get; }

        public Turma()
        {
        }

        public Turma(string disciplina)
        {
            Disciplina = disciplina;
        }

        public IEnumerator<Aluno> GetEnumerator()
        {
            return alunos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Matricular([Required]IEnumerable<Aluno> alunos)
        {
            this.alunos.AddRange(alunos);
        }

        private int QuantidadeDeAlunos()
        {
            return alunos.Count;
        }
    }
}
