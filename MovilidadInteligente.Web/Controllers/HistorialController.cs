using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Models;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialController : ControllerBase
    {
        private readonly IHistorialViajeService _historialService;

        public HistorialController(IHistorialViajeService historialService)
        {
            _historialService = historialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialViajeDTO>>> GetAll()
        {
            var historiales = await _historialService.GetAllAsync();
            if (historiales == null || !historiales.Any())
                return NotFound();
            return Ok(historiales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialViajeDTO>> GetById(string id)
        {
            try
            {
                var historial = await _historialService.GetByIdAsync(id);
                return Ok(historial);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HistorialViajeDTO historialDto)
        {
            if (historialDto == null || string.IsNullOrWhiteSpace(historialDto.Id))
                return BadRequest(new { Error = "Payload invalido. El ID es requerido." });

            try
            {
                var creada = await _historialService.CreateAsync(historialDto);
                return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] HistorialViajeDTO historialDto)
        {
            if (historialDto == null)
                return BadRequest(new { Error = "Payload invalido." });

            try
            {
                var actualizada = await _historialService.UpdateAsync(id, historialDto);
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
                var deleted = await _historialService.DeleteAsync(id);
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
