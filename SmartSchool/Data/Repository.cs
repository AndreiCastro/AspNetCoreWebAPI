﻿using Microsoft.EntityFrameworkCore;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Data
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

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        //Aluno
        #region No Assicrona
        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(ad => ad.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }

            //AsNoTracking serve para liberar a sessão após consulta, para atualização
            query = query.AsNoTracking().OrderBy(x => x.Id);
            return query.ToArray();
        }
        #endregion No Assicrona


        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(ad => ad.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }

            //AsNoTracking serve para liberar a sessão após consulta, para atualização
            query = query.AsNoTracking().OrderBy(x => x.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAllAlunoByDisciplinaId(int idDisciplina, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
            {
                query = query.Include(ad => ad.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id)
                                        .Where(y => y.AlunosDisciplinas.Any(d => d.DisciplinaId == idDisciplina));
            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoById(int idAluno, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
            {
                query = query.Include(ad => ad.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().Where(x => x.Id == idAluno);
            return await query.FirstOrDefaultAsync();
        }

        //Professor
        public async Task<Professor[]> GetAllProfessores(bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
            {
                query = query.Include(d => d.Disciplinas)
                             .ThenInclude(ad => ad.AlunosDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetAllProfessoreByDisciplinaId(int idDisciplina, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
            {
                query = query.Include(d => d.Disciplinas)
                             .ThenInclude(ad => ad.AlunosDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking().Where(x => x.Disciplinas.Any(y => y.AlunosDisciplinas
                                                                 .Any(z => z.DisciplinaId == idDisciplina)))
                                                                 .OrderBy(x => x.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorById(int idProfessor, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
            {
                query = query.Include(d => d.Disciplinas)
                             .ThenInclude(ad => ad.AlunosDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking().Where(x => x.Id == idProfessor);
            return await query.FirstOrDefaultAsync();
        }
    }
}
