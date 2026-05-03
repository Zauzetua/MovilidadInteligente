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
    public class UbicacionService : IUbicacionService
    {
        private readonly IUbicacionRepository _ubicacionRepository;

        public UbicacionService(IUbicacionRepository ubicacionRepository)
        {
            _ubicacionRepository = ubicacionRepository;
        }

        public async Task<IEnumerable<UbicacionDTO>> GetAllAsync()
        {
            var ubicaciones = await _ubicacionRepository.GetAllAsync();
            return ubicaciones.Select(u => UbicacionMapper.ToDTO(u)).ToList();
        }

        public async Task<UbicacionDTO> GetByIdAsync(string id)
        {
            var ubicacion = await _ubicacionRepository.GetByIdAsync(id);
            return UbicacionMapper.ToDTO(ubicacion);
        }

        public async Task<UbicacionDTO> CreateAsync(UbicacionDTO ubicacionDto)
        {
            var entidad = UbicacionMapper.ToEntity(ubicacionDto);
            var creada = await _ubicacionRepository.AddAsync(entidad);
            return UbicacionMapper.ToDTO(creada);
        }

        public async Task<UbicacionDTO> UpdateAsync(string id, UbicacionDTO ubicacionDto)
        {
            ubicacionDto.Id = id;
            var entidad = UbicacionMapper.ToEntity(ubicacionDto);
            var actualizada = await _ubicacionRepository.UpdateAsync(entidad);
            return UbicacionMapper.ToDTO(actualizada);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _ubicacionRepository.DeleteAsync(id);
        }
    }
}