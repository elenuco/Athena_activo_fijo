using System.ComponentModel.DataAnnotations;

namespace Athena_Activo_FijoAPI.Modelos
{
    public class Athena
    {
        [Key]
        public int ID_Athena { get; set; }
        public ActivosFijos ActivosFijos { get; set; }
        public tipoActivo tipoActivo { get; set; }
        public Asignaciones Asignaciones { get; set; }
    }
}
