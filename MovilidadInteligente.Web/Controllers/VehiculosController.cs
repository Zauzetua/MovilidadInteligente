using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Models;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculosController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehiculoDTO>>> GetAll()
        {
            var vehiculos = await _vehiculoService.GetAllAsync();
            if (vehiculos == null || !vehiculos.Any())
            {
                return NotFound();
            }
            return Ok(vehiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehiculoDTO>> GetById(string id)
        {
            var vehiculo = await _vehiculoService.GetByIdAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return Ok(vehiculo);
        }

        [HttpPost("CambiarEstado")]
        public async Task<IActionResult> CambiarEstado([FromBody] CambiarEstadoRequest request)
        {
            try
            {
                await _vehiculoService.CambiarEstadoVehiculo(request.IdVehiculo, request.NuevoEstado);
                return Ok(new { Mensaje = $"Estado del vehiculo {request.IdVehiculo} cambiado a {request.NuevoEstado}" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

    }
}
