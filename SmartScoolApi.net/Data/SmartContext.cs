using Microsoft.EntityFrameworkCore;
using SmartScoolApi.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext>options):base(options){ }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }
        public DbSet<AlunoCurso> AlunoCursos { get; set; }
        public DbSet<Disciplina>Disciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new { AD.AlunoId, AD.DisciplinaId });
            builder.Entity<AlunoCurso>()
                .HasKey(AD => new { AD.AlunoId, AD.CursoId });

        }
    }
}
