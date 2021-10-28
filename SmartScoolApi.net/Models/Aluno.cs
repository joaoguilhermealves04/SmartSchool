using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Models
{
    public class Aluno
    {
      

        public Aluno()
        {
        }

        public Aluno(int id, int matricula, string nome, string sobrenome,string telefone ,DateTime datanasc)
        {
            this.Id = id;
            this.Matricula = matricula;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
            this.DataNasc = datanasc;

        }

        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataMatricula { get; set; } = DateTime.Now;
        public DateTime ?DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;


        public IEnumerable<AlunoDisciplina> AlunoDisciplina { get; set; }
    }
}
