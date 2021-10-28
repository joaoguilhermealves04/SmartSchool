using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Models
{
    public class Curso
    {
        public Curso() { }
        public Curso(int id ,string nome)
        {
            this.Id = id;
            this.nome = nome;
        }
        public int Id { get; set; }
        public string nome { get; set; }
        public IEnumerable<Disciplina>Disciplinas { get; set; }
    }
}
