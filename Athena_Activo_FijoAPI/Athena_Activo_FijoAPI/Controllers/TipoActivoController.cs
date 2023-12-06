using Athena_Activo_FijoAPI.Datos;
using Athena_Activo_FijoAPI.Modelos;
using Athena_Activo_FijoAPI.Modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Athena_Activo_FijoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoActivoController : ControllerBase
    {
        [HttpGet]
        public ActionResult <IEnumerable<TipoActivoDto>>GetTipoActivos()
        {
            return Ok( TipoActivoStore.tipoActivoList);
        }
        [HttpGet("ID_tipo_activo:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TipoActivoDto> GetTipoActivos(int ID_tipo_activo) {
            if (ID_tipo_activo == 0)
            {
                return BadRequest();
            }
            var tipoActivo = TipoActivoStore.tipoActivoList.FirstOrDefault(Id => Id.ID_tipo_activo == ID_tipo_activo);
            if (tipoActivo == null)
            {
                return NotFound();
            }
            return Ok(tipoActivo);
        
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipoActivoDto> CrearTipoActivo([FromBody] TipoActivoDto tipoActivo)
        {
            try
            {
                if (tipoActivo == null)
                {
                    return BadRequest(tipoActivo);
                }

                // Asegúrate de que tipoActivoList no sea nulo
                if (TipoActivoStore.tipoActivoList == null)
                {
                    TipoActivoStore.tipoActivoList = new List<TipoActivoDto>();
                }

                // Asigna un nuevo ID de acuerdo a tus necesidades
                tipoActivo.ID_tipo_activo = ObtenerNuevoId();

                // Agrega el nuevo tipoActivo a la lista
                TipoActivoStore.tipoActivoList.Add(tipoActivo);

                // Usa CreatedAtAction en lugar de CreatedAtRoute
                return CreatedAtAction("GetTipoActivos", new { id = tipoActivo.ID_tipo_activo }, tipoActivo);
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante la creación
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno: {ex.Message}");
            }
        }

        private int ObtenerNuevoId()
        {
            // Implementa la lógica para obtener un nuevo ID, por ejemplo, incrementar el último ID existente.
            if (TipoActivoStore.tipoActivoList.Any())
            {
                return TipoActivoStore.tipoActivoList.Max(caf => caf.ID_tipo_activo) + 1;
            }
            else
            {
                return 1; // Si la lista está vacía, comienza desde 1
            }
        }

    }
}
