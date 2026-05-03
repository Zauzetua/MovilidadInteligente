using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovilidadInteligente.Application.Services
{
    public class CatalogoRutasService
    {
        private readonly IRutaRepository _rutaRepository;

        public CatalogoRutasService(IRutaRepository rutaRepository)
        {
            _rutaRepository = rutaRepository;
        }

        public async Task<RutaPredeterminada> ObtenerRutaDinamica(string origenLocationId, string destinoLocationId)
        {
            var rutas = await _rutaRepository.GetByOriginDestinationAsync(origenLocationId, destinoLocationId);
            if (rutas == null || !rutas.Any())
            {
                Console.WriteLine($"No se encontraron rutas para origen {origenLocationId} y destino {destinoLocationId}.");
                return null;
            }
            //Escoger la que tenga menor trafico
            var rutaSeleccionada = rutas.OrderBy(r => r.NivelTraficoActual).First();
            Console.WriteLine($"Ruta seleccionada: {rutaSeleccionada.Id} con trafico actual: {rutaSeleccionada.NivelTraficoActual}");
            return rutaSeleccionada;
        }

        public async Task<IEnumerable<RutaPredeterminada>> ObtenerRutasPredeterminadas()
        {
            var rutas = await _rutaRepository.GetAllAsync();
            Console.WriteLine($"Rutas predeterminadas disponibles: {rutas.Count()}");
            return rutas;
        }

        public async Task OcuparRuta(string rutaId)
        {
            var ruta = await _rutaRepository.GetByIdAsync(rutaId);
            if (ruta == null)
            {
                Console.WriteLine($"Ruta {rutaId} no encontrada.");
                return;
            }
            ruta.NivelTraficoActual += 1;
            await _rutaRepository.UpdateAsync(ruta);
            Console.WriteLine($"Ruta {rutaId} ocupada. Nivel de trafico actual: {ruta.NivelTraficoActual}");

        }

        public async Task LiberarRuta(string rutaId)
        {
            var ruta = await _rutaRepository.GetByIdAsync(rutaId);
            if (ruta == null)
            {
                Console.WriteLine($"Ruta {rutaId} no encontrada.");
                return;
            }
            ruta.NivelTraficoActual = Math.Max(0, ruta.NivelTraficoActual - 1);
            await _rutaRepository.UpdateAsync(ruta);
            Console.WriteLine($"Ruta {rutaId} liberada. Nivel de trafico actual: {ruta.NivelTraficoActual}");

        }
    }
}
