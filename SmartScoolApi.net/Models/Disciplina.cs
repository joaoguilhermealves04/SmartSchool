using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Models
{
    public class Disciplina
    {
        public Disciplina() { }




        public Disciplina(int id, string nome, int professorId, Professor professor)
        {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;


        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargoHoraria { get; set; }
        public int? PrerequistoId { get; set; } = null;
        public Disciplina Prerequisto { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public int CursoId { get; set; }
        public Curso curso { get; set; }

        public IEnumerable<AlunoDisciplina> AlunoDisciplina { get; set; }
    }
}
