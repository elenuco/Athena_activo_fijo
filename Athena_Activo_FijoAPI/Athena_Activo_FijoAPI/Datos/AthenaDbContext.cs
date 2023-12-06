using Athena_Activo_FijoAPI.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Athena_Activo_FijoAPI.Datos
{
    public class AthenaDbContext :DbContext
    {
        public AthenaDbContext(DbContextOptions<AthenaDbContext> options) : base(options) 
        {
            
        }
        public DbSet<tipoActivo> tipo_activo {  get; set; }
    }
}
