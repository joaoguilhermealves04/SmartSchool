using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }
        public AlunoDisciplina(int alunoId, Aluno aluno, int disciplinaId)
        {
            this.AlunoId = alunoId;

            this.DisciplinaId = disciplinaId;

        }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public DateTime Inicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public int? Nota { get; set; } = null;
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
