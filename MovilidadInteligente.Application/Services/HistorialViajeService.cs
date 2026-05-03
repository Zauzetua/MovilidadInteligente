using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Mappers;
using MovilidadInteligente.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Services
{
    public class HistorialViajeService : IHistorialViajeService
    {
        private readonly IHistorialViajeRepository _historialRepository;

        public HistorialViajeService(IHistorialViajeRepository historialRepository)
        {
            _historialRepository = historialRepository;
        }

        public async Task<IEnumerable<HistorialViajeDTO>> GetAllAsync()
        {
            var historiales = await _historialRepository.GetAllAsync();
            return historiales.Select(HistorialViajeMapper.ToDTO).ToList();
        }

        public async Task<HistorialViajeDTO> GetByIdAsync(string id)
        {
            var historial = await _historialRepository.GetByIdAsync(id);
            return HistorialViajeMapper.ToDTO(historial);
        }

        public async Task<HistorialViajeDTO> CreateAsync(HistorialViajeDTO historialDto)
        {
            var entidad = HistorialViajeMapper.ToEntity(historialDto);
            var creada = await _historialRepository.AddAsync(entidad);
            return HistorialViajeMapper.ToDTO(creada);
        }

        public async Task<HistorialViajeDTO> UpdateAsync(string id, HistorialViajeDTO historialDto)
        {
            historialDto.Id = id;
            var entidad = HistorialViajeMapper.ToEntity(historialDto);
            var actualizada = await _historialRepository.UpdateAsync(entidad);
            return HistorialViajeMapper.ToDTO(actualizada);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _historialRepository.DeleteAsync(id);
        }
    }
}
