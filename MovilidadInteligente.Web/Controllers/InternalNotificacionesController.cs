using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Web.Hubs; 

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/internal/notificaciones")]
    public class InternalNotificacionesController : ControllerBase
    {
        private readonly IHubContext<MovilidadHub> _hubContext;

        public InternalNotificacionesController(IHubContext<MovilidadHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("vehiculo")]
        public async Task<IActionResult> NotificarVehiculo([FromBody] VehiculoDTO vehiculo)
        {
            // recibo el aviso de mi worker y lo escupo a mis clientes web
            await _hubContext.Clients.All.SendAsync("ActualizarVehiculo", vehiculo);
            return Ok();
        }

        [HttpPost("viajefinalizado")]
        public async Task<IActionResult> NotificarViajeFinalizado([FromBody] string vehiculoId)
        {
            await _hubContext.Clients.All.SendAsync("ViajeFinalizado", new
            {
                VehiculoId = vehiculoId,
                Fecha = DateTime.UtcNow
            });
            return Ok();
        }
    }
}