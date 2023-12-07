using System.ComponentModel.DataAnnotations;

namespace Athena_Activo_FijoAPI.Modelos.DTO
{
    public class TipoActivoDto
    {
        [Key]
        public int ID_tipo_activo { get; set; }
        [Required]
        public  string nombre { get; set; }
    }
}
