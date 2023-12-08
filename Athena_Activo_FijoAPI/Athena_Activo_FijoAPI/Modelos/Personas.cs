using System.ComponentModel.DataAnnotations;

namespace Athena_Activo_FijoAPI.Modelos
{
    public class Personas
    {
        [Key]
        public int Id_Persona { get; set; }
        [Required]
        public string nombre {  get; set; }
        [Required]
        public string n_carnet {  get; set; }
        public AreasTrabajo AreasTrabajo { get; set; }
    }
}
