using MovilidadInteligente.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Services
{
    public interface IRutaService
    {
        Task<IEnumerable<RutaDTO>> GetAllAsync();
        Task<RutaDTO> GetByIdAsync(string id);
        Task<RutaDTO> CreateAsync(RutaDTO rutaDto);
        Task<RutaDTO> UpdateAsync(string id, RutaDTO rutaDto);
        Task<bool> DeleteAsync(string id);
        Task<IEnumerable<RutaDTO>> GetByOriginDestinationAsync(string origenLocationId, string destinoLocationId);
    }
}
