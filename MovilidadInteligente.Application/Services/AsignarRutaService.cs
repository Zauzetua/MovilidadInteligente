using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Services
{
    public class AsignarRutaService
    {
        private readonly List<RutaPredeterminada> _rutasDisponibles;

        public AsignarRutaService()
        {
            /*
            _rutasDisponibles = new List<RutaPredeterminada>
            {
                new RutaPredeterminada
                {
                    Id = "R1", Nombre = "Avenida Principal", Origen = "Centro", Destino = "Universidad",
                    NivelTraficoActual = 8, // simulamos mucho trafico aqui
                    Coordenadas = new List<Coordenada> { new() { Latitud = 27.070, Longitud = -109.440 }, new Coordenada { Latitud = 27.075, Longitud = -109.445 } }
                },
                new RutaPredeterminada
                {
                    Id = "R2", Nombre = "Calles Traseras", Origen = "Centro", Destino = "Universidad",
                    NivelTraficoActual = 2, // ruta libre
                    Coordenadas = new List<Coordenada> { new() { Latitud = 27.071, Longitud = -109.441 }, new Coordenada { Latitud = 27.078, Longitud = -109.448 } }
                }
            };
            */
            _rutasDisponibles = new List<RutaPredeterminada>();
        }

        public async Task<RutaPredeterminada?> AsignarRuta(string origen, string destino)
        {
            var rutasPosibles = _rutasDisponibles.Where(RutaPredeterminada => RutaPredeterminada.Origen == origen && RutaPredeterminada.Destino == destino).ToList();

            if (!rutasPosibles.Any())
                return null;

            var rutaAsignada = rutasPosibles.OrderBy(RutaPredeterminada => RutaPredeterminada.NivelTraficoActual).FirstOrDefault();
            return rutaAsignada;
        }
    }
}
