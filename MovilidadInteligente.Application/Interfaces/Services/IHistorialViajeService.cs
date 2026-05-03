using MovilidadInteligente.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Services
{
    public interface IHistorialViajeService
    {
        Task<IEnumerable<HistorialViajeDTO>> GetAllAsync();
        Task<HistorialViajeDTO> GetByIdAsync(string id);
        Task<HistorialViajeDTO> CreateAsync(HistorialViajeDTO historialDto);
        Task<HistorialViajeDTO> UpdateAsync(string id, HistorialViajeDTO historialDto);
        Task<bool> DeleteAsync(string id);
    }
}
