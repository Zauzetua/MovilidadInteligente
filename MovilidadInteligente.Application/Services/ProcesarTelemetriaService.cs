using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Mappers;
using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Services
{
    public class ProcesarTelemetriaService
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly INotificadorHub _notificadorHub;
        private readonly IHistorialViajeRepository _historialViajeRepository;

        public ProcesarTelemetriaService(
            IVehiculoRepository vehiculoRepository,
            INotificadorHub notificadorHub,
            IHistorialViajeRepository historialViajeRepository
            )
        {
            _vehiculoRepository = vehiculoRepository;
            _notificadorHub = notificadorHub;
            _historialViajeRepository = historialViajeRepository;
        }

        public async Task EjecutarAsync(Vehiculo vehiculo)
        {
            var vehiculoExistente = await _vehiculoRepository.ObtenerPorIdAsync(vehiculo.Id);
            if (vehiculoExistente == null)
            {
                // si el vehiculo no existe en mi bd, ignoro el mensaje
                return;
            }

            var estadoAnterior = vehiculoExistente.Estado;
            vehiculoExistente.Latitud = vehiculo.Latitud;
            vehiculoExistente.Longitud = vehiculo.Longitud;
            vehiculoExistente.Combustible = vehiculo.Combustible;

            if (vehiculo.Combustible < 15)
            {
                vehiculo.Estado = "Necesita recarga";
            }
            else if (!string.IsNullOrEmpty(vehiculo.Estado))
            {
                vehiculoExistente.Estado = vehiculo.Estado;
            }

            vehiculoExistente.UltimaActualizacion = DateTime.UtcNow;

            await _vehiculoRepository.ActualizarTelemetriaAsync(vehiculoExistente);

            var dto = VehiculoMapper.ToDTO(vehiculoExistente);

            await _notificadorHub.EnviarActualizacionVehiculoAsync(dto);

            if (string.Equals(estadoAnterior, "Ocupado", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(vehiculoExistente.Estado, "Ocupado", StringComparison.OrdinalIgnoreCase))
            {
                var historialActivo = await _historialViajeRepository.GetActivoPorVehiculoAsync(vehiculoExistente.Id);
                if (historialActivo != null)
                {
                    historialActivo.Estado = "Finalizado";
                    historialActivo.FinUtc = DateTime.UtcNow;
                    await _historialViajeRepository.UpdateAsync(historialActivo);
                }

                await _notificadorHub.EnviarViajeFinalizadoAsync(vehiculoExistente.Id);
            }
        }
    }
}
