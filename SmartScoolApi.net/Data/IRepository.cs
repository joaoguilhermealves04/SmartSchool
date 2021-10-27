using SmartScoolApi.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartScoolApi.net.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Updata<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;
   

        // Get Aluno ==Consulta

        Aluno[] GetAllALunos( bool includeProfessor = false);
        Aluno[] GetAllAlunoByDisciplinaId(int Disciplinaid, bool includeProfessor = false);
        Aluno GetAlunoById(int id, bool includeProfessor = false);

        //Get Professor == Consulta

        Professor[] GetAllProfessores(bool includeAluno);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaid, bool includeAluno = false);
        Professor  GetProfessorById(int id, bool includeAluno = false);
        bool SaveChanger<T>(T entity) where T : class;
        bool SaveChanger();
    }
}
