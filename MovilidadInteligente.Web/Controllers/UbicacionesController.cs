using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Models;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionesController : ControllerBase
    {
        private readonly IUbicacionService _ubicacionService;

        public UbicacionesController(IUbicacionService ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UbicacionDTO>>> GetAll()
        {
            var ubicaciones = await _ubicacionService.GetAllAsync();
            if (ubicaciones == null || !ubicaciones.Any())
                return NotFound();
            return Ok(ubicaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UbicacionDTO>> GetById(string id)
        {
            try
            {
                var ubicacion = await _ubicacionService.GetByIdAsync(id);
                return Ok(ubicacion);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UbicacionDTO ubicacionDto)
        {
            if (ubicacionDto == null || string.IsNullOrWhiteSpace(ubicacionDto.Id))
                return BadRequest(new { Error = "Payload inválido. El ID es requerido." });

            try
            {
                var creada = await _ubicacionService.CreateAsync(ubicacionDto);
                return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UbicacionDTO ubicacionDto)
        {
            if (ubicacionDto == null)
                return BadRequest(new { Error = "Payload invalido." });

            try
            {
                var actualizada = await _ubicacionService.UpdateAsync(id, ubicacionDto);
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
                var deleted = await _ubicacionService.DeleteAsync(id);
                if (!deleted)
                    return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
