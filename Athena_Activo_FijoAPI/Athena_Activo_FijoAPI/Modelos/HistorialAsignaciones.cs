namespace Athena_Activo_FijoAPI.Modelos
{
    public class HistorialAsignaciones
    {
        public int Id_Historial_Asignaciones {  get; set; }
        public DateOnly FechaAsignacion { get; set; }
        public Personas Personas { get; set; }
        public ActivosFijos ActivosFijos { get; set; }
    }
}
