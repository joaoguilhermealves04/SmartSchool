using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Models
{
    public class Aluno
    {
        internal object id;

        public Aluno()
        {
        }

        public Aluno(int id, string nome, string sobrenome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        public IEnumerable<AlunoDisciplina> AlunoDisciplina { get; set; }
    }
}
