using MovilidadInteligente.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Repositories
{
    public interface IPagoRepository
    {
        Task<Pago> AddAsync(Pago pago);
        Task<Pago> GetByIdAsync(string id);
        Task<IEnumerable<Pago>> GetAllAsync();
        Task<IEnumerable<Pago>> GetByHistorialViajeIdAsync(string historialViajeId);
        Task<Pago> UpdateAsync(Pago pago);
        Task<bool> DeleteAsync(string id);
    }
}
