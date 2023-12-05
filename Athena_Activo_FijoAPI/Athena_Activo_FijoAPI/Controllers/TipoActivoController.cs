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
    }
}
