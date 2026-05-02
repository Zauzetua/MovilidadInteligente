using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Application.Services;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViajesController : ControllerBase
    {
        private readonly AsignarRutaService _asignarRutaService;
        private readonly IDespachadorVehiculos _despachadorVehiculos;

        public ViajesController(AsignarRutaService asignarRutaService, IDespachadorVehiculos despachadorVehiculos)
        {
            _asignarRutaService = asignarRutaService;
            _despachadorVehiculos = despachadorVehiculos;
        }

        [HttpPost("iniciar")]
        public async Task<IActionResult> IniciarViaje([FromBody] PeticionViaje peticion)
        {
            var mejorRuta = await _asignarRutaService.AsignarRuta(peticion.Origen, peticion.Destino);

            if (mejorRuta == null) return NotFound("No hay rutas validas para esos puntos.");

            // 2. le mandamos la orden al vehiculo por mqtt
            await _despachadorVehiculos.EnviarComandoRutaAsync(peticion.VehiculoId, mejorRuta);

            // nota: aqui tambien actualizarias el estado del vehiculo a "Ocupado" en BD

            return Ok(new { Mensaje = $"Vehiculo {peticion.VehiculoId} despachado a {peticion.Destino}" });

        }
    }
}
