using MovilidadInteligente.Domain.Entities;
using System.Collections.Generic;

namespace MovilidadInteligente.Application.Services
{
    public class UbicacionesService
    {
        private readonly List<Ubicacion> _ubicaciones;

        public UbicacionesService()
        {
            // simulamos una tabla de la base de datos con nuestras estaciones
            _ubicaciones = new List<Ubicacion>
{
    new Ubicacion { Id = "UB-01", Nombre = "Centro", Latitud = 27.0730, Longitud = -109.4445 },
    new Ubicacion { Id = "UB-02", Nombre = "ITSON Navojoa", Latitud = 27.0815, Longitud = -109.4510 },
    new Ubicacion { Id = "UB-03", Nombre = "Plaza 5 de Mayo", Latitud = 27.0710, Longitud = -109.4420 },
    new Ubicacion { Id = "UB-04", Nombre = "Hospital General", Latitud = 27.0775, Longitud = -109.4475 },
    new Ubicacion { Id = "UB-05", Nombre = "Soriana", Latitud = 27.0795, Longitud = -109.4490 },
    new Ubicacion { Id = "UB-06", Nombre = "Unidad Deportiva", Latitud = 27.0720, Longitud = -109.4350 },
    new Ubicacion { Id = "UB-07", Nombre = "Central de Autobuses", Latitud = 27.0680, Longitud = -109.4400 },
    new Ubicacion { Id = "UB-08", Nombre = "Colonia Reforma", Latitud = 27.0785, Longitud = -109.4415 },
    new Ubicacion { Id = "UB-09", Nombre = "Parque Infantil", Latitud = 27.0705, Longitud = -109.4375 },
    new Ubicacion { Id = "UB-10", Nombre = "Zona Industrial", Latitud = 27.0850, Longitud = -109.4550 }
};
        }

        public IEnumerable<Ubicacion> ObtenerTodas()
        {
            return _ubicaciones;
        }
    }
}