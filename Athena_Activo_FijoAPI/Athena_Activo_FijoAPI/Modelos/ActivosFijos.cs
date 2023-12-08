using System.ComponentModel.DataAnnotations;

namespace Athena_Activo_FijoAPI.Modelos
{
    public class ActivosFijos
    {
        [Key]
        public int ID_activo_fijo {  get; set; }
        [Required]
        public  string codigo { get; set; }
        
        public  tipoActivo tipoActivo { get; set; }
        [Required]
        public  string Descipcion { get;set;}
    }
}
