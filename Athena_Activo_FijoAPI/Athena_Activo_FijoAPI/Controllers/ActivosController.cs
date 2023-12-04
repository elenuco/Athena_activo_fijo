using Athena_Activo_FijoAPI.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Athena_Activo_FijoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivosController : ControllerBase
    {
        public IEnumerable<Activos_Fijos> GetActivo_Fijos() { }
    }
}
