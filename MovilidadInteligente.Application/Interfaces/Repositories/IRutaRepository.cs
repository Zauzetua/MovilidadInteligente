using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Repositories
{
    public interface IRutaRepository
    {
        Task<RutaPredeterminada> AddAsync(RutaPredeterminada ruta);
        Task<RutaPredeterminada> GetByIdAsync(string id);
        Task<IEnumerable<RutaPredeterminada>> GetAllAsync();
        Task<RutaPredeterminada> UpdateAsync(RutaPredeterminada ruta);
        Task<bool> DeleteAsync(string id);
        Task<IEnumerable<RutaPredeterminada>> GetByOriginDestinationAsync(string origenLocationId, string destinoLocationId);
    }
}
