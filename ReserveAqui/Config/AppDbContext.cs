using Microsoft.EntityFrameworkCore;
using ReserveAqui.Models;

namespace ReserveAqui.Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<InstituicaoModel> Instituicoes { get; set; }
        public DbSet<AdministradorModel> Administradores { get; set; }
        public DbSet<MaterialModel> Materiais { get; set; }
        public DbSet<SalaModel> Salas { get; set; }
        public DbSet<ProfessorModel> Professores { get; set; }
        public DbSet<ReservaSalaModel> ReservaSalas { get; set; }
        public DbSet<ReservaMaterialModel> ReservaMateriais { get; set; }
        

        
    }
}
