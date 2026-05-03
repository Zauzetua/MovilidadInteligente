using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Domain.Entities;
using System;

namespace MovilidadInteligente.Application.Mappers
{
    public class PagoMapper
    {
        public static PagoDTO ToDTO(Pago pago)
        {
            return new PagoDTO
            {
                Id = pago.Id,
                HistorialViajeId = pago.HistorialViajeId,
                Monto = pago.Monto,
                Moneda = pago.Moneda,
                Metodo = pago.Metodo,
                Estado = pago.Estado,
                Referencia = pago.Referencia,
                FechaUtc = pago.FechaUtc
            };
        }

        public static Pago ToEntity(PagoDTO dto)
        {
            return new Pago(
                dto.Id,
                dto.HistorialViajeId,
                dto.Monto,
                dto.Moneda ?? "MXN",
                dto.Metodo,
                dto.Estado,
                dto.Referencia,
                dto.FechaUtc == default ? DateTime.UtcNow : dto.FechaUtc
            );
        }
    }
}
