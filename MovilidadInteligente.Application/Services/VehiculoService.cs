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

        public async Task<VehiculoDTO> GetByIdAsync(string id)
        {
            var vehiculo = await _vehiculoRepository.ObtenerPorIdAsync(id);
            return VehiculoMapper.ToDTO(vehiculo);
        }

        public async Task<VehiculoDTO> CambiarEstadoVehiculo(string id, string nuevoEstado)
        {
            var vehiculo = await _vehiculoRepository.ObtenerPorIdAsync(id);
            if (vehiculo == null)
                throw new Exception($"Vehiculo con ID {id} no encontrado.");

            vehiculo.Estado = nuevoEstado;
            await _vehiculoRepository.ActualizarEstadoVehiculo(vehiculo);
            return VehiculoMapper.ToDTO(vehiculo);
        }

        public async Task<IEnumerable<VehiculoDTO>> ObtenerVehiculosDisponibles()
        {
            var vehiculos = await _vehiculoRepository.ObtenerVehiculosDisponiblesAsync();
            return vehiculos.Select(v => VehiculoMapper.ToDTO(v)).ToList();
        }

        public async Task<IEnumerable<VehiculoDTO>> ObtenerVehiculosMantenimientoAsync()
        {
            var vehiculos = await _vehiculoRepository.ObtenerVehiculosMantenimiento();
            return vehiculos.Select(v => VehiculoMapper.ToDTO(v)).ToList();
        }

        public async Task<VehiculoDTO> CreateAsync(VehiculoDTO vehiculoDto)
        {
            var entidad = VehiculoMapper.ToEntity(vehiculoDto);
            var creado = await _vehiculoRepository.AddAsync(entidad);
            return VehiculoMapper.ToDTO(creado);
        }
    }
}
