using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Services;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutasController : ControllerBase
    {
        private readonly AsignarRutaService _asignarRutaService;
        private readonly CatalogoRutasService _catalogoRutasService;

        public RutasController(AsignarRutaService asignarRutaService, CatalogoRutasService catalogoRutasService)
        {
            _asignarRutaService = asignarRutaService;
            _catalogoRutasService = catalogoRutasService;
        }

        [HttpGet("optima")]
        public IActionResult ObtenerRutaOptima([FromQuery] string origen, [FromQuery] string destino)
        {
            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
                return BadRequest("El origen y destino son requeridos.");

            var rutaOptima = _catalogoRutasService.ObtenerRutaDinamica(origen, destino);
            if (rutaOptima == null)
                return NotFound("No se encontraron rutas disponibles para el origen y destino especificados.");

            return Ok(rutaOptima);
        }

        [HttpGet("predeterminadas")]
        public IActionResult ObtenerRutasPredeterminadas()
        {
            var rutas = _catalogoRutasService.ObtenerRutasPredeterminadas();
            return Ok(rutas);
        }

    }
}
