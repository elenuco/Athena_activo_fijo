using System.ComponentModel.DataAnnotations;

namespace Athena_Activo_FijoAPI.Modelos
{
    public class ActivosFijos
    {
        [Required]
        public required string codigo { get; set; }
        [Required]
        public required tipoActivo tipoActivoId { get; set; }
        [Required]
        public required string Descipcion { get;set;}
    }
}
