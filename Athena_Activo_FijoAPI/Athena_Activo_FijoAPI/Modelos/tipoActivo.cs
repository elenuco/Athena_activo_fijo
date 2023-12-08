using System.ComponentModel.DataAnnotations;

namespace Athena_Activo_FijoAPI.Modelos
{
    public class tipoActivo
    {
        [Key]
        public int ID_tipo_activo { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
