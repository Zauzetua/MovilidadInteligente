using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Services;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MantenimientoController : ControllerBase
    {
        private readonly ObtenerVehiculosMantenimientoService _obtenerVehiculosMantenimientoService;

        public MantenimientoController(ObtenerVehiculosMantenimientoService obtenerVehiculosMantenimientoService)
        {
            _obtenerVehiculosMantenimientoService = obtenerVehiculosMantenimientoService;
        }

        [HttpGet("vehiculos-mantenimiento")]
        public async Task<IActionResult> ObtenerVehiculosMantenimiento()
        {
            var vehiculosMantenimiento = await _obtenerVehiculosMantenimientoService.EjecutarAsync();
            if (vehiculosMantenimiento == null || !vehiculosMantenimiento.Any())
            {
                return NotFound("No se encontraron vehículos en mantenimiento.");
            }
            return Ok(vehiculosMantenimiento);
        }

    }
}
