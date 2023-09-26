using Microsoft.EntityFrameworkCore;
using SmartSchool.Models;

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
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(@"Data Source=ANDREI\SQLEXPRESS; Initial Catalog=SmartSchollApp; Integrated Security=SSPI;");
        //    optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SmartSchollApp;Data Source=DESKTOP-5EUU7OI\SQLEXPRESS");
        //}

        //Relação de N pra N
        protected void OnModeCreating(ModelBuilder builder)
        {
            //dizendo que o AlunoDisciplina tem id das tabelas Aluno e Disciplina (olhando a classe fica mais compreensível)
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new { AD.AlunoId, AD.DisciplinaId });
            
            builder.Entity<AlunoCurso>()
                .HasKey(AC => new { AC.AlunoId, AC.CursoId });
        }
    }

}
