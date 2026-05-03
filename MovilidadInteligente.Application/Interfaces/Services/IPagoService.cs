using MovilidadInteligente.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Services
{
    public interface IPagoService
    {
        Task<IEnumerable<PagoDTO>> GetAllAsync();
        Task<PagoDTO> GetByIdAsync(string id);
        Task<IEnumerable<PagoDTO>> GetByHistorialViajeIdAsync(string historialViajeId);
        Task<PagoDTO> CreateAsync(PagoDTO pagoDto);
        Task<PagoDTO> UpdateAsync(string id, PagoDTO pagoDto);
        Task<bool> DeleteAsync(string id);
    }
}
