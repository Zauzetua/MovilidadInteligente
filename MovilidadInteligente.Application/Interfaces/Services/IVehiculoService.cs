using MovilidadInteligente.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Services
{
    public interface IVehiculoService
    {
        Task<IEnumerable<VehiculoDTO>> GetAllAsync();
        Task<VehiculoDTO> GetByIdAsync(string id);
        Task<VehiculoDTO> CambiarEstadoVehiculo(string id, string nuevoEstado);
        //Task<VehiculoDTO> CreateAsync(VehiculoDTO vehiculoDto);
        //Task<VehiculoDTO> UpdateAsync(int id, VehiculoDTO vehiculoDto);
        //Task<bool> DeleteAsync(int id);

    }
}
