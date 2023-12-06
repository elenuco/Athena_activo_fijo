using System.ComponentModel.DataAnnotations;

namespace Athena_Activo_FijoAPI.Modelos
{
    public class ActivosFijos
    {
        [Key]
        public int ID_tipo_activo {  get; set; }
        [Required]
        public  string codigo { get; set; }
        [Required]
        public  tipoActivo tipoActivo { get; set; }
        [Required]
        public  string Descipcion { get;set;}
    }
}
