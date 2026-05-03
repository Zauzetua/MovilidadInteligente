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
        private readonly CatalogoRutasService _catalogoRutasService;

        public ViajesController(AsignarRutaService asignarRutaService, IDespachadorVehiculos despachadorVehiculos, CatalogoRutasService catalogoRutasService)
        {
            _asignarRutaService = asignarRutaService;
            _despachadorVehiculos = despachadorVehiculos;
            _catalogoRutasService = catalogoRutasService;
        }

        [HttpPost("iniciar")]
        public async Task<IActionResult> IniciarViaje([FromBody] PeticionViaje peticion)
        {
            var mejorRuta = _catalogoRutasService.ObtenerRutaDinamica(peticion.Origen, peticion.Destino);

            if (mejorRuta == null) return NotFound("No hay rutas validas para esos puntos.");

            await _despachadorVehiculos.EnviarComandoRutaAsync(peticion.VehiculoId, mejorRuta);

            return Ok(new { Mensaje = $"Vehiculo {peticion.VehiculoId} despachado a {peticion.Destino}" });

        }
    }
}
