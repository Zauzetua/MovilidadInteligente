using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Mappers;
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

        public ProcesarTelemetriaService(
            IVehiculoRepository vehiculoRepository,
            INotificadorHub notificadorHub
            )
        {
            _vehiculoRepository = vehiculoRepository;
            _notificadorHub = notificadorHub;
        }

        public async Task EjecutarAsync(Vehiculo vehiculo)
        {
            ArgumentNullException.ThrowIfNull(vehiculo);

            if (vehiculo.Combustible < 15)
            {
                vehiculo.Estado = "Necesita recarga";
            }
            else if (string.IsNullOrEmpty(vehiculo.Estado))
            {
                vehiculo.Estado = "En operacion";
            }

            vehiculo.UltimaActualizacion = DateTime.UtcNow;

            await _vehiculoRepository.ActualizarTelemetriaAsync(vehiculo);

            var dto = VehiculoMapper.ToDTO(vehiculo);

            await _notificadorHub.EnviarActualizacionVehiculoAsync(dto);
        }
    }
}
