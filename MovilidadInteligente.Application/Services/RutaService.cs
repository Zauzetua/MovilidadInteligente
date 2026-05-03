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
    public class RutaService : IRutaService
    {
        private readonly IRutaRepository _rutaRepository;

        public RutaService(IRutaRepository rutaRepository)
        {
            _rutaRepository = rutaRepository;
        }

        public async Task<IEnumerable<RutaDTO>> GetAllAsync()
        {
            var rutas = await _rutaRepository.GetAllAsync();
            return rutas.Select(r => RutaMapper.ToDTO(r)).ToList();
        }

        public async Task<RutaDTO> GetByIdAsync(string id)
        {
            var ruta = await _rutaRepository.GetByIdAsync(id);
            return RutaMapper.ToDTO(ruta);
        }

        public async Task<RutaDTO> CreateAsync(RutaDTO rutaDto)
        {
            var entidad = RutaMapper.ToEntity(rutaDto);
            var creada = await _rutaRepository.AddAsync(entidad);
            return RutaMapper.ToDTO(creada);
        }

        public async Task<RutaDTO> UpdateAsync(string id, RutaDTO rutaDto)
        {
            rutaDto.Id = id;
            var entidad = RutaMapper.ToEntity(rutaDto);
            var actualizada = await _rutaRepository.UpdateAsync(entidad);
            return RutaMapper.ToDTO(actualizada);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _rutaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RutaDTO>> GetByOriginDestinationAsync(string origenLocationId, string destinoLocationId)
        {
            var rutas = await _rutaRepository.GetByOriginDestinationAsync(origenLocationId, destinoLocationId);
            return rutas.Select(r => RutaMapper.ToDTO(r)).ToList();
        }
    }
}
