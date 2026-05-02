using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovilidadInteligente.Application.Services
{
    public class CatalogoRutasService
    {
        private readonly List<RutaPredeterminada> _rutasDisponibles;
        private readonly Random _random;

        public CatalogoRutasService()
        {
            _random = new Random();

            //Esto hay que cambiarlo por una consulta a base de datos o un servicio externo que nos de las rutas disponibles
            _rutasDisponibles = new List<RutaPredeterminada>
{
    // 1
    new RutaPredeterminada
    {
        Id = "R1-A",
        Origen = "Centro",
        Destino = "ITSON Navojoa",
        Nombre = "Boulevard",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0730, -109.4445),
            new Coordenada(27.0745, -109.4455),
            new Coordenada(27.0760, -109.4465),
            new Coordenada(27.0780, -109.4480),
            new Coordenada(27.0800, -109.4495),
            new Coordenada(27.0815, -109.4510)
        }
    },
    new RutaPredeterminada
    {
        Id = "R1-B",
        Origen = "Centro",
        Destino = "ITSON Navojoa",
        Nombre = "Calles internas",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0730, -109.4445),
            new Coordenada(27.0725, -109.4425),
            new Coordenada(27.0740, -109.4410),
            new Coordenada(27.0765, -109.4435),
            new Coordenada(27.0790, -109.4470),
            new Coordenada(27.0815, -109.4510)
        }
    },

    // 2
    new RutaPredeterminada
    {
        Id = "R2-A",
        Origen = "Centro",
        Destino = "Plaza 5 de Mayo",
        Nombre = "Directa",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0730, -109.4445),
            new Coordenada(27.0725, -109.4435),
            new Coordenada(27.0718, -109.4428),
            new Coordenada(27.0710, -109.4420)
        }
    },
    new RutaPredeterminada
    {
        Id = "R2-B",
        Origen = "Centro",
        Destino = "Plaza 5 de Mayo",
        Nombre = "Alterna",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0730, -109.4445),
            new Coordenada(27.0735, -109.4430),
            new Coordenada(27.0720, -109.4415),
            new Coordenada(27.0710, -109.4420)
        }
    },

    // 3
    new RutaPredeterminada
    {
        Id = "R3-A",
        Origen = "Plaza 5 de Mayo",
        Destino = "Hospital General",
        Nombre = "Principal",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0710, -109.4420),
            new Coordenada(27.0725, -109.4435),
            new Coordenada(27.0740, -109.4450),
            new Coordenada(27.0760, -109.4465),
            new Coordenada(27.0775, -109.4475)
        }
    },
    new RutaPredeterminada
    {
        Id = "R3-B",
        Origen = "Plaza 5 de Mayo",
        Destino = "Hospital General",
        Nombre = "Alterna",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0710, -109.4420),
            new Coordenada(27.0705, -109.4400),
            new Coordenada(27.0730, -109.4415),
            new Coordenada(27.0755, -109.4450),
            new Coordenada(27.0775, -109.4475)
        }
    },

    // 4
    new RutaPredeterminada
    {
        Id = "R4-A",
        Origen = "Hospital General",
        Destino = "Soriana",
        Nombre = "Directa",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0775, -109.4475),
            new Coordenada(27.0785, -109.4480),
            new Coordenada(27.0795, -109.4490)
        }
    },
    new RutaPredeterminada
    {
        Id = "R4-B",
        Origen = "Hospital General",
        Destino = "Soriana",
        Nombre = "Alterna",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0775, -109.4475),
            new Coordenada(27.0770, -109.4455),
            new Coordenada(27.0785, -109.4470),
            new Coordenada(27.0795, -109.4490)
        }
    },

    // 5
    new RutaPredeterminada
    {
        Id = "R5-A",
        Origen = "Soriana",
        Destino = "Zona Industrial",
        Nombre = "Principal",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0795, -109.4490),
            new Coordenada(27.0810, -109.4505),
            new Coordenada(27.0825, -109.4520),
            new Coordenada(27.0840, -109.4535),
            new Coordenada(27.0850, -109.4550)
        }
    },
    new RutaPredeterminada
    {
        Id = "R5-B",
        Origen = "Soriana",
        Destino = "Zona Industrial",
        Nombre = "Alterna",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0795, -109.4490),
            new Coordenada(27.0790, -109.4465),
            new Coordenada(27.0815, -109.4485),
            new Coordenada(27.0835, -109.4515),
            new Coordenada(27.0850, -109.4550)
        }
    },

    // 6
    new RutaPredeterminada
    {
        Id = "R6-A",
        Origen = "Centro",
        Destino = "Central de Autobuses",
        Nombre = "Sur directa",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0730, -109.4445),
            new Coordenada(27.0710, -109.4430),
            new Coordenada(27.0695, -109.4415),
            new Coordenada(27.0680, -109.4400)
        }
    },
    new RutaPredeterminada
    {
        Id = "R6-B",
        Origen = "Centro",
        Destino = "Central de Autobuses",
        Nombre = "Alterna",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0730, -109.4445),
            new Coordenada(27.0725, -109.4460),
            new Coordenada(27.0700, -109.4440),
            new Coordenada(27.0680, -109.4400)
        }
    },

    // 7
    new RutaPredeterminada
    {
        Id = "R7-A",
        Origen = "Central de Autobuses",
        Destino = "Unidad Deportiva",
        Nombre = "Este",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0680, -109.4400),
            new Coordenada(27.0695, -109.4385),
            new Coordenada(27.0710, -109.4370),
            new Coordenada(27.0720, -109.4350)
        }
    },
    new RutaPredeterminada
    {
        Id = "R7-B",
        Origen = "Central de Autobuses",
        Destino = "Unidad Deportiva",
        Nombre = "Alterna",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0680, -109.4400),
            new Coordenada(27.0685, -109.4375),
            new Coordenada(27.0705, -109.4360),
            new Coordenada(27.0720, -109.4350)
        }
    },

    // 8
    new RutaPredeterminada
    {
        Id = "R8-A",
        Origen = "Unidad Deportiva",
        Destino = "Parque Infantil",
        Nombre = "Directa",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0720, -109.4350),
            new Coordenada(27.0712, -109.4360),
            new Coordenada(27.0705, -109.4375)
        }
    },
    new RutaPredeterminada
    {
        Id = "R8-B",
        Origen = "Unidad Deportiva",
        Destino = "Parque Infantil",
        Nombre = "Alterna",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0720, -109.4350),
            new Coordenada(27.0730, -109.4365),
            new Coordenada(27.0715, -109.4380),
            new Coordenada(27.0705, -109.4375)
        }
    },

    // 9
    new RutaPredeterminada
    {
        Id = "R9-A",
        Origen = "Parque Infantil",
        Destino = "Colonia Reforma",
        Nombre = "Principal",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0705, -109.4375),
            new Coordenada(27.0730, -109.4395),
            new Coordenada(27.0755, -109.4405),
            new Coordenada(27.0785, -109.4415)
        }
    },
    new RutaPredeterminada
    {
        Id = "R9-B",
        Origen = "Parque Infantil",
        Destino = "Colonia Reforma",
        Nombre = "Alterna",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0705, -109.4375),
            new Coordenada(27.0710, -109.4350),
            new Coordenada(27.0745, -109.4385),
            new Coordenada(27.0785, -109.4415)
        }
    },

    // 10
    new RutaPredeterminada
    {
        Id = "R10-A",
        Origen = "Colonia Reforma",
        Destino = "ITSON Navojoa",
        Nombre = "Directa",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0785, -109.4415),
            new Coordenada(27.0800, -109.4450),
            new Coordenada(27.0815, -109.4510)
        }
    },
    new RutaPredeterminada
    {
        Id = "R10-B",
        Origen = "Colonia Reforma",
        Destino = "ITSON Navojoa",
        Nombre = "Alterna",
        Coordenadas = new List<Coordenada>
        {
            new Coordenada(27.0785, -109.4415),
            new Coordenada(27.0775, -109.4430),
            new Coordenada(27.0795, -109.4470),
            new Coordenada(27.0815, -109.4510)
        }
    }
};
        }

        public RutaPredeterminada ObtenerRutaDinamica(string origen, string destino)
        {
            // 1. filtramos todas las rutas que nos llevan al destino solicitado
            var rutasPosibles = _rutasDisponibles
                .Where(r => r.Origen == origen && r.Destino == destino)
                .ToList();

            if (!rutasPosibles.Any()) return null;

            // 2. si solo hay una, pues ni modo, mandamos esa
            if (rutasPosibles.Count == 1) return rutasPosibles.First();

            // 3. la asignacion dinamica: simulamos cual tiene menos trafico en este momento
            var rutaSeleccionada = rutasPosibles
                .Select(ruta => new
                {
                    Ruta = ruta,
                    // simulamos un nivel de trafico del 1 al 100
                    NivelTrafico = _random.Next(1, 101)
                })
                .OrderBy(x => x.NivelTrafico) // elegimos la que tenga el numero mas bajo
                .First();

            Console.WriteLine($"[Ruteo Dinamico] Asignada: {rutaSeleccionada.Ruta.Nombre} (Trafico: {rutaSeleccionada.NivelTrafico}%)");

            return rutaSeleccionada.Ruta;
        }

        public IEnumerable<RutaPredeterminada> ObtenerRutasPredeterminadas()
        {
            return _rutasDisponibles;
        }

        public Task OcuparRuta(string rutaId)
        {
            var ruta = _rutasDisponibles.FirstOrDefault(r => r.Id == rutaId);
            if (ruta == null)
            {
                Console.WriteLine($"Ruta {rutaId} no encontrada.");
                return Task.CompletedTask;
            }
            ruta.NivelTraficoActual++;
            Console.WriteLine($"Ruta {rutaId} marcada como ocupada.");
            return Task.CompletedTask;
        }

        public Task LiberarRuta(string rutaId)
        {
            var ruta = _rutasDisponibles.FirstOrDefault(r => r.Id == rutaId);
            if (ruta == null)
            {
                Console.WriteLine($"Ruta {rutaId} no encontrada.");
                return Task.CompletedTask;
            }
            ruta.NivelTraficoActual = Math.Max(0, ruta.NivelTraficoActual - 1);
            Console.WriteLine($"Ruta {rutaId} liberada.");
            return Task.CompletedTask;
        }
    }
}