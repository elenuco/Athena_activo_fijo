using System.ComponentModel.DataAnnotations;

namespace Athena_Activo_FijoAPI.Modelos.DTO
{
    public class ActivosFijosDto
    {
        public int ID_activo_fijo { get; set; }
        [Required]
        public required string codigo { get; set; }
        [Required]
        public required int  tipoActivoId { get; set; }
        [Required]
        public required string Descipcion { get; set; }
    }
}
