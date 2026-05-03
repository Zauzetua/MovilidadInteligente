using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Repositories
{
    public interface IUbicacionRepository
    {
        Task<Ubicacion> AddAsync(Ubicacion ubicacion);
        Task<Ubicacion> GetByIdAsync(string id);
        Task<IEnumerable<Ubicacion>> GetAllAsync();
        Task<Ubicacion> UpdateAsync(Ubicacion ubicacion);
        Task<bool> DeleteAsync(string id);
    }
}
