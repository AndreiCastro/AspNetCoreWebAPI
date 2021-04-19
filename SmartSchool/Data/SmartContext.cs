using Microsoft.EntityFrameworkCore;
using SmartSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunoDisciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }

        //Relação de N pra N
        protected override void OnModeCreating(ModelBuilder builder)
        {
            //dizendo que o AlunoDisciplina tem id das tabelas Aluno e Disciplina (olhando a classe fica mais compreensível)
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new { AD.AlunoId, AD.DisciplinaId });
        }
    }

}
