using Athena_Activo_FijoAPI.Datos;
using Athena_Activo_FijoAPI.Modelos;
using Athena_Activo_FijoAPI.Modelos.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Athena_Activo_FijoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoActivoController : ControllerBase
    {
        private readonly ILogger<TipoActivoController> logger;
        public TipoActivoController(ILogger<TipoActivoController> logger)
        {

            this.logger = logger;

        }
        [HttpGet]
        public ActionResult <IEnumerable<TipoActivoDto>>GetTipoActivos()
        {
            this.logger.LogInformation("Obtener los tipos de activos");
            return Ok( TipoActivoStore.tipoActivoList);
        }
        [HttpGet("ID_tipo_activo:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TipoActivoDto> GetTipoActivos(int ID_tipo_activo) {
            if (ID_tipo_activo == 0)
            {
                this.logger.LogError("Error al traer los tipos de activos"+ ID_tipo_activo);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (TipoActivoStore.tipoActivoList.FirstOrDefault(Tav=>Tav.nombre.ToLower()==tipoActivo.nombre.ToLower())!=null)
            {
                ModelState.AddModelError("NombreExiste", "¡El tipo Activo con ese nombre ya Existe");
                return BadRequest(ModelState);
            }
            try
            {
                if (tipoActivo == null)
                {
                    return BadRequest(tipoActivo);
                }

                if (TipoActivoStore.tipoActivoList == null)
                {
                    TipoActivoStore.tipoActivoList = new List<TipoActivoDto>();
                }

                tipoActivo.ID_tipo_activo = ObtenerNuevoId();

                TipoActivoStore.tipoActivoList.Add(tipoActivo);

                return CreatedAtAction("GetTipoActivos", new { id = tipoActivo.ID_tipo_activo }, tipoActivo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno: {ex.Message}");
            }
        }

        private int ObtenerNuevoId()
        {
            if (TipoActivoStore.tipoActivoList.Any())
            {
                return TipoActivoStore.tipoActivoList.Max(caf => caf.ID_tipo_activo) + 1;
            }
            else
            {
                return 1; 
            }
        }

        [HttpDelete("{ID_tipo_activo:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteTipoActivo(int ID_tipo_activo)
        {
            if (ID_tipo_activo==0)
            {
                return BadRequest();
            }
            var tipoActivos = TipoActivoStore.tipoActivoList.FirstOrDefault(TaD=>TaD.ID_tipo_activo== ID_tipo_activo);
            if (tipoActivos==null)
            {
                return NotFound();
            }
            TipoActivoStore.tipoActivoList.Remove(tipoActivos);
            return NoContent();
        }

        [HttpPatch("{ID_tipo_activo:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialTipoActivo(int ID_tipo_activo, JsonPatchDocument <TipoActivoDto> patchTipoActivo)
        {
            if (patchTipoActivo == null || ID_tipo_activo==0)
            {
                return BadRequest();
            }
            var TActivo=TipoActivoStore.tipoActivoList.FirstOrDefault(TaP=>TaP.ID_tipo_activo==ID_tipo_activo);
            patchTipoActivo.ApplyTo(TActivo);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
        [HttpPut("{ID_tipo_activo:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateTipoActivo(int ID_tipo_activo, [FromBody] TipoActivoDto tipoActivo)
        {
            if (tipoActivo == null || ID_tipo_activo != tipoActivo.ID_tipo_activo)
            {
                return BadRequest();
            }
            var TActivo = TipoActivoStore.tipoActivoList.FirstOrDefault(TaP => TaP.ID_tipo_activo == ID_tipo_activo);
            TActivo.nombre = tipoActivo.nombre;
            return NoContent();
        }
    }
}
