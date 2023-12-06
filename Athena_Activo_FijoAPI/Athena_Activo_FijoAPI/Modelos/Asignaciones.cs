using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Athena_Activo_FijoAPI.Modelos
{
    public class Asignaciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Asignaciones { get; set; }
        public Personas Personas { get; set; }
        public ActivosFijos ActivosFijos { get; set; }
    }
}
