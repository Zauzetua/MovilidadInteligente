using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Services;
using MovilidadInteligente.Domain.Entities;

namespace MovilidadInteligente.Web.Controllers
{
    public class TelemetriaLegacyController : ControllerBase
    {
        private readonly ILogger<TelemetriaLegacyController> _logger;
        private readonly ProcesarTelemetriaService _procesarTelemetriaService;

        public TelemetriaLegacyController(ILogger<TelemetriaLegacyController> logger, ProcesarTelemetriaService procesarTelemetriaService)
        {
            _logger = logger;
            _procesarTelemetriaService = procesarTelemetriaService;
        }

        
        [HttpPost("api/telemetria/legacy")]
        public async Task<IActionResult> Post([FromBody] Vehiculo vehiculo)
        {
            try
            {
                await _procesarTelemetriaService.EjecutarAsync(vehiculo);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar telemetría legacy");
                return StatusCode(500, "Error al procesar telemetría");
            }
        }

    }
}
