using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Repositories
{
    public interface IVehiculoRepository
    {
        Task ActualizarTelemetriaAsync(Vehiculo vehiculo);
        Task<Vehiculo> ObtenerPorIdAsync(string id);
        Task<IEnumerable<Vehiculo>> ObtenerTodosAsync();
        Task<IEnumerable<Vehiculo>> ObtenerVehiculosInactivosAsync(DateTime limiteInactividad);
        Task<IEnumerable<Vehiculo>> ObtenerVehiculosMantenimiento();
        Task<Vehiculo> ActualizarEstadoVehiculo(Vehiculo vehiculo);
    }
}
