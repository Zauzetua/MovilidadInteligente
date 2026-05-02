using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Services;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionesController : ControllerBase
    {
        private readonly UbicacionesService _ubicacionesService;

        public UbicacionesController(UbicacionesService ubicacionesService)
        {
            _ubicacionesService = ubicacionesService;
        }

        // GET: api/ubicaciones
        [HttpGet]
        public IActionResult Get()
        {
            var ubicaciones = _ubicacionesService.ObtenerTodas();
            return Ok(ubicaciones);
        }
    }
}
