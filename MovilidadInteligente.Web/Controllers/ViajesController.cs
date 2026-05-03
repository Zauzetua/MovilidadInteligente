using Microsoft.AspNetCore.Mvc;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Application.Services;
using System;

namespace MovilidadInteligente.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViajesController : ControllerBase
    {
        private readonly IDespachadorVehiculos _despachadorVehiculos;
        private readonly CatalogoRutasService _catalogoRutasService;
        private readonly IHistorialViajeService _historialViajeService;

        public ViajesController(
            IDespachadorVehiculos despachadorVehiculos,
            CatalogoRutasService catalogoRutasService,
            IHistorialViajeService historialViajeService)
        {
            _despachadorVehiculos = despachadorVehiculos;
            _catalogoRutasService = catalogoRutasService;
            _historialViajeService = historialViajeService;
        }

        [HttpPost("iniciar")]
        public async Task<IActionResult> IniciarViaje([FromBody] PeticionViaje peticion)
        {
            var mejorRuta = await _catalogoRutasService.ObtenerRutaDinamica(peticion.Origen, peticion.Destino);

            if (mejorRuta == null) return NotFound("No hay rutas validas para esos puntos.");

            await _despachadorVehiculos.EnviarComandoRutaAsync(peticion.VehiculoId, mejorRuta);

            var historial = new HistorialViajeDTO
            {
                Id = Guid.NewGuid().ToString(),
                VehiculoId = peticion.VehiculoId,
                OrigenLocationId = peticion.Origen,
                DestinoLocationId = peticion.Destino,
                Estado = "En Progreso",
                InicioUtc = DateTime.UtcNow
            };

            await _historialViajeService.CreateAsync(historial);

            return Ok(new { Mensaje = $"Vehiculo {peticion.VehiculoId} despachado a {peticion.Destino}" });

        }
    }
}
