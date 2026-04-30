using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Mappers
{
    public class VehiculoMapper
    {
        public static VehiculoDTO ToDTO(Vehiculo vehiculo)
        {
            return new VehiculoDTO
            {
                Id = vehiculo.Id,
                Latitud = vehiculo.Latitud,
                Longitud = vehiculo.Longitud,
                Estado = vehiculo.Estado,
                Combustible = vehiculo.Combustible,
                Tipo = vehiculo.Tipo
            };
        }

        public static Vehiculo ToEntity(VehiculoDTO vehiculoDto)
        {
            return new Vehiculo(
                vehiculoDto.Id,
               vehiculoDto.Latitud,
                vehiculoDto.Longitud,
                vehiculoDto.Combustible,
                vehiculoDto.Tipo,
                vehiculoDto.Estado
            );
        }
    }
}
