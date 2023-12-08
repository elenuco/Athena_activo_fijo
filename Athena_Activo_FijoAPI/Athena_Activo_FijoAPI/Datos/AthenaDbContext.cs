using Athena_Activo_FijoAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Athena_Activo_FijoAPI.Datos
{
    public class AthenaDbContext : DbContext
    {
        public AthenaDbContext() { }

        public AthenaDbContext(DbContextOptions<AthenaDbContext> options) : base(options) { }

        public DbSet<Athena> Athena { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Athena>().HasData(
                new ActivosFijos()
                {
                    ID_activo_fijo = 1,
                    codigo = "MAC0002",
                    Descipcion="Laptop marca mac"

                }
                );
        }
    }

}
