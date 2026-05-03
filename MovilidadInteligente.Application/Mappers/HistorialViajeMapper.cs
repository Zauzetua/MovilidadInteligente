using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovilidadInteligente.Application.Mappers
{
    public class HistorialViajeMapper
    {
        public static HistorialViajeDTO ToDTO(HistorialViaje historial)
        {
            return new HistorialViajeDTO
            {
                Id = historial.Id,
                VehiculoId = historial.VehiculoId,
                OrigenLocationId = historial.OrigenLocationId,
                DestinoLocationId = historial.DestinoLocationId,
                Estado = historial.Estado,
                InicioUtc = historial.InicioUtc,
                FinUtc = historial.FinUtc,
                DistanciaKm = historial.DistanciaKm,
                CostoEstimado = historial.CostoEstimado
            };
        }

        public static HistorialViaje ToEntity(HistorialViajeDTO historialDto)
        {
            return new HistorialViaje(
                historialDto.Id,
                historialDto.VehiculoId,
                historialDto.OrigenLocationId,
                historialDto.DestinoLocationId,
                historialDto.Estado,
                historialDto.InicioUtc,
                historialDto.FinUtc,
                historialDto.DistanciaKm,
                historialDto.CostoEstimado
            );
        }

        public static List<HistorialViajeDTO> ToDTOList(List<HistorialViaje> historiales)
        {
            return historiales.Select(ToDTO).ToList();
        }
    }
}
