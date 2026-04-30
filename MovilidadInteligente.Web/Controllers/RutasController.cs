using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Services;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutasController : ControllerBase
    {
        private readonly AsignarRutaService _asignarRutaService;

        public RutasController(AsignarRutaService asignarRutaService)
        {
            _asignarRutaService = asignarRutaService;
        }

        [HttpGet("optima")]
        public IActionResult ObtenerRutaOptima([FromQuery] string origen, [FromQuery] string destino)
        {
            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
                return BadRequest("El origen y destino son requeridos.");

            var rutaOptima = _asignarRutaService.AsignarRuta(origen, destino);
            if (rutaOptima == null)
                return NotFound("No se encontraron rutas disponibles para el origen y destino especificados.");

            return Ok(rutaOptima);
        }

    }
}
