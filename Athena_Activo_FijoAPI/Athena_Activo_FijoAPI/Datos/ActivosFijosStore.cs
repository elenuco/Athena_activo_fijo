using Athena_Activo_FijoAPI.Modelos;
using Athena_Activo_FijoAPI.Modelos.DTO;

namespace Athena_Activo_FijoAPI.Datos
{
    public static class ActivosFijosStore
    {
        public static List<ActivosFijosDto> ActivosFijosList = new List<ActivosFijosDto> {
          new ActivosFijosDto{ codigo="HP0001",tipoActivo=new tipoActivo(), Descipcion="Laptop"}
        };
    }
}
