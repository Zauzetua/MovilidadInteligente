using MovilidadInteligente.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Repositories
{
    public interface IHistorialViajeRepository
    {
        Task<HistorialViaje> AddAsync(HistorialViaje historial);
        Task<HistorialViaje> GetByIdAsync(string id);
        Task<IEnumerable<HistorialViaje>> GetAllAsync();
        Task<HistorialViaje?> GetActivoPorVehiculoAsync(string vehiculoId);
        Task<HistorialViaje> UpdateAsync(HistorialViaje historial);
        Task<bool> DeleteAsync(string id);
    }
}
