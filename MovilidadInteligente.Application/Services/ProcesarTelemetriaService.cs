using MovilidadInteligente.Application.Interfaces.Repositories;
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

        public ProcesarTelemetriaService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task EjecutarAsync(Vehiculo vehiculo)
        {
            if(vehiculo == null )
                throw new ArgumentNullException(nameof(vehiculo));

            if(vehiculo.Combustible < 15)
            {
                vehiculo.Estado = "Necesita recarga";
            }
            else if(string.IsNullOrEmpty(vehiculo.Estado))
            {
                vehiculo.Estado = "En operacion";
            }

            await _vehiculoRepository.ActualizarTelemetriaAsync(vehiculo);

            // aqui inyectaremos tu interfaz INotificadorHub para empujar el objeto vehiculo al front
        }
    }
}
