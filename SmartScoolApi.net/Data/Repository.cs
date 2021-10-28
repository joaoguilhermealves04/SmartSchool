using Microsoft.EntityFrameworkCore;
using SmartScoolApi.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Aluno[] GetAllAlunoByDisciplinaId(int disciplinaid, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplina)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id)
                                        .Where(aluno => aluno.AlunoDisciplina.Any(aluno => aluno.DisciplinaId == disciplinaid));
            return query.ToArray();

        }

        public Aluno[] GetAllALunos(bool includeDisciplina)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeDisciplina)
            {
                query = query.Include(a => a.AlunoDisciplina)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Professor[] GetAllProfessores(bool includeAluno)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(al => al.AlunoDisciplina)
                             .ThenInclude(alu => alu.Aluno);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);


            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaid, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(al => al.AlunoDisciplina)
                             .ThenInclude(alu => alu.Aluno);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id)
                                        .Where(profiessor => profiessor.Disciplinas.Any(d => d.AlunoDisciplina
                                        .Any(ad => disciplinaid == disciplinaid)));


            return query.ToArray();
        }

        public Aluno GetAlunoById(int id, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplina)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id)
                                        .Where(aluno => aluno.Id == aluno.Id);
            return query.FirstOrDefault();
        }

        public Professor GetProfessorById(int id, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(al => al.AlunoDisciplina)
                             .ThenInclude(alu => alu.Aluno);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id)
                                       .Where(profiessor => profiessor.Id == id);

            return query.FirstOrDefault();

        }

        public bool SaveChanger<T>(T entity) where T : class
        {
            return (_context.SaveChanges() > 0);
        }

        public bool SaveChanger()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Updata<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
