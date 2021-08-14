using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Data
{
   public  interface IRepository
    {
        void Add<T>(T entity) where T : class; //Isso significa: Que o add espera uma class, e usa essa classe como parametro
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunoByDisciplinaId(int idDisciplina, bool includeProfessor = false);
        Aluno GetAlunoById(int idAluno, bool includeProfessor = false);

        Professor[] GetAllProfessores(bool includeAluno = false);
        Professor[] GetAllProfessoreByDisciplinaId(int idDisciplina, bool includeAluno = false);
        Professor GetProfessorById(int idProfessor, bool includeAluno = false);


    }
}
