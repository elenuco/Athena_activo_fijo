using System.ComponentModel.DataAnnotations;

namespace Athena_Activo_FijoAPI.Modelos
{
    public class AreasTrabajo
    {
        [Key]
        public int id {  get; set; }
        [Required]
        public string name { get; set; }
    }
}
