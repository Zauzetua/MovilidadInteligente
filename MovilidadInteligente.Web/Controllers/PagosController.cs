using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Models;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IPagoService _pagoService;

        public PagosController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        // GET api/pagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagoDTO>>> GetAll()
        {
            var pagos = await _pagoService.GetAllAsync();
            if (pagos == null || !pagos.Any())
                return NotFound();
            return Ok(pagos);
        }

        // GET api/pagos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PagoDTO>> GetById(string id)
        {
            try
            {
                var pago = await _pagoService.GetByIdAsync(id);
                return Ok(pago);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET api/pagos/por-viaje/{historialViajeId}
        [HttpGet("por-viaje/{historialViajeId}")]
        public async Task<ActionResult<IEnumerable<PagoDTO>>> GetByHistorialViaje(string historialViajeId)
        {
            var pagos = await _pagoService.GetByHistorialViajeIdAsync(historialViajeId);
            return Ok(pagos);
        }

        // POST api/pagos
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PagoDTO pagoDto)
        {
            if (pagoDto == null || string.IsNullOrWhiteSpace(pagoDto.Id))
                return BadRequest(new { Error = "Payload inválido. El ID es requerido." });

            if (string.IsNullOrWhiteSpace(pagoDto.HistorialViajeId))
                return BadRequest(new { Error = "El HistorialViajeId es requerido." });

            if (pagoDto.Monto <= 0)
                return BadRequest(new { Error = "El monto debe ser mayor a 0." });

            if (string.IsNullOrWhiteSpace(pagoDto.Metodo))
                return BadRequest(new { Error = "El método de pago es requerido." });

            if (string.IsNullOrWhiteSpace(pagoDto.Estado))
                pagoDto.Estado = "Completado";

            if (string.IsNullOrWhiteSpace(pagoDto.Moneda))
                pagoDto.Moneda = "MXN";

            try
            {
                var creado = await _pagoService.CreateAsync(pagoDto);
                return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // PUT api/pagos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] PagoDTO pagoDto)
        {
            if (pagoDto == null)
                return BadRequest(new { Error = "Payload inválido." });

            try
            {
                var actualizado = await _pagoService.UpdateAsync(id, pagoDto);
                return Ok(actualizado);
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

        // POST api/pagos/{id}/cancelar  — actualiza solo el estado a Cancelado
        [HttpPost("{id}/cancelar")]
        public async Task<IActionResult> Cancelar(string id)
        {
            try
            {
                var pago = await _pagoService.GetByIdAsync(id);
                pago.Estado = "Cancelado";
                var actualizado = await _pagoService.UpdateAsync(id, pago);
                return Ok(actualizado);
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

        // DELETE api/pagos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var deleted = await _pagoService.DeleteAsync(id);
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
