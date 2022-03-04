using Models;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<AgendamentoProcedimento> AgendamentoProcedimentos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql("Server=localhost;User Id=root;Database=dentista");
    }

}