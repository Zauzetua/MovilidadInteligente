using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Mappers;
using MovilidadInteligente.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;


        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<IEnumerable<VehiculoDTO>> GetAllAsync()
        {
            var vehiculos = await _vehiculoRepository.ObtenerTodosAsync();
            return vehiculos.Select(v => VehiculoMapper.ToDTO(v)).ToList();
        }

        public async Task<VehiculoDTO> GetByIdAsync(int id)
        {
            var vehiculo = await _vehiculoRepository.ObtenerPorIdAsync(id.ToString());
            return VehiculoMapper.ToDTO(vehiculo);
        }
    }
}
