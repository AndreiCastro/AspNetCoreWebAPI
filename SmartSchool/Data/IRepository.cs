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

        #region No Assincrona
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        #endregion No Assincrona

        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false);
        Task<Aluno[]> GetAllAlunoByDisciplinaId(int idDisciplina, bool includeProfessor = false);
        Task<Aluno> GetAlunoById(int idAluno, bool includeProfessor = false);

        Task<Professor[]> GetAllProfessores(bool includeAluno = false);
        Task<Professor[]> GetAllProfessoreByDisciplinaId(int idDisciplina, bool includeAluno = false);
        Task<Professor> GetProfessorById(int idProfessor, bool includeAluno = false);


    }
}
