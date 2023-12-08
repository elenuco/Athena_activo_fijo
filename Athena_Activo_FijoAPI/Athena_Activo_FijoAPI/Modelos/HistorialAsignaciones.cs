using System.ComponentModel.DataAnnotations;

namespace Athena_Activo_FijoAPI.Modelos
{
    public class HistorialAsignaciones
    {
        [Key]
        public int Id_Historial_Asignaciones {  get; set; }
        [Required]
        public DateOnly FechaAsignacion { get; set; }
        [Required]
        public Personas Personas { get; set; }
        [Required]
        public ActivosFijos ActivosFijos { get; set; }
    }
}
