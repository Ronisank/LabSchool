using LabSchoolWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LabSchoolWebApi.Context
{
    public class LabSchoolContext : DbContext
    {
        public LabSchoolContext(DbContextOptions<LabSchoolContext> options) : base(options) { }


        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Pedagogo> Pedagogos { get; set; }

    }
}




