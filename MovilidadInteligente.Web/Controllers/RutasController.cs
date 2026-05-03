using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Application.Services;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutasController : ControllerBase
    {
        private readonly IRutaService _rutaService;
        private readonly CatalogoRutasService _catalogoRutasService;

        public RutasController(IRutaService rutaService, CatalogoRutasService catalogoRutasService)
        {
            _rutaService = rutaService;
            _catalogoRutasService = catalogoRutasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RutaDTO>>> GetAll()
        {
            var rutas = await _rutaService.GetAllAsync();
            if (rutas == null || !rutas.Any())
                return NotFound();
            return Ok(rutas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RutaDTO>> GetById(string id)
        {
            try
            {
                var ruta = await _rutaService.GetByIdAsync(id);
                return Ok(ruta);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<RutaDTO>>> GetByOriginDestination([FromQuery] string origen, [FromQuery] string destino)
        {
            if (string.IsNullOrWhiteSpace(origen) || string.IsNullOrWhiteSpace(destino))
                return BadRequest(new { Error = "Parámetros 'origen' y 'destino' son requeridos." });

            try
            {
                var rutas = await _rutaService.GetByOriginDestinationAsync(origen, destino);
                if (rutas == null || !rutas.Any())
                    return NotFound();
                return Ok(rutas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RutaDTO rutaDto)
        {
            if (rutaDto == null || string.IsNullOrWhiteSpace(rutaDto.Id))
                return BadRequest(new { Error = "Payload inválido. El ID es requerido." });

            try
            {
                var creada = await _rutaService.CreateAsync(rutaDto);
                return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] RutaDTO rutaDto)
        {
            if (rutaDto == null)
                return BadRequest(new { Error = "Payload inválido." });

            try
            {
                var actualizada = await _rutaService.UpdateAsync(id, rutaDto);
                return Ok(actualizada);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var deleted = await _rutaService.DeleteAsync(id);
                if (!deleted)
                    return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // Metodos legacy (deprecated, maar mantenidos para compatibilidad)
        [HttpGet("optima")]
        public async Task<IActionResult> ObtenerRutaOptima([FromQuery] string origen, [FromQuery] string destino)
        {
            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino))
                return BadRequest("El origen y destino son requeridos.");

            var rutaOptima = await _catalogoRutasService.ObtenerRutaDinamica(origen, destino);
            if (rutaOptima == null)
                return NotFound("No se encontraron rutas disponibles para el origen y destino especificados.");

            return Ok(rutaOptima);
        }

        [HttpGet("predeterminadas")]
        public async Task<IActionResult> ObtenerRutasPredeterminadas()
        {
            var rutas = await _catalogoRutasService.ObtenerRutasPredeterminadas();
            return Ok(rutas);
        }
    }
}

