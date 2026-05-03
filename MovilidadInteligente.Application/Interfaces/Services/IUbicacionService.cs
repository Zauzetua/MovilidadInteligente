using MovilidadInteligente.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Services
{
    public interface IUbicacionService
    {
        Task<IEnumerable<UbicacionDTO>> GetAllAsync();
        Task<UbicacionDTO> GetByIdAsync(string id);
        Task<UbicacionDTO> CreateAsync(UbicacionDTO ubicacionDto);
        Task<UbicacionDTO> UpdateAsync(string id, UbicacionDTO ubicacionDto);
        Task<bool> DeleteAsync(string id);
    }
}
