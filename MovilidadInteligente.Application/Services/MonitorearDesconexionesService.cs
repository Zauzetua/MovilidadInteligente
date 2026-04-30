using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Services
{
    public class MonitorearDesconexionesService
    {
        private readonly IVehiculoRepository _repository;
        //private readonly INotificadorHub _notificador;

        public MonitorearDesconexionesService(IVehiculoRepository repository/*, INotificadorHub notificador*/)
        {
            _repository = repository;
            //_notificador = notificador;
        }

        public async Task EjecutarAsync()
        {
            var limiteInactividad = DateTime.UtcNow.AddMinutes(-1);
            var vehiculosInactivos = await _repository.ObtenerVehiculosInactivosAsync(limiteInactividad);

            foreach (var vehiculo in vehiculosInactivos)
            {
                vehiculo.Estado = "Desconectado";
                await _repository.ActualizarTelemetriaAsync(vehiculo);

                //var dto = VehiculoMapper.ToDTO(vehiculo);
                //await _notificador.EnviarActualizacionVehiculoAsync(dto);
            }
        }
    }
}
