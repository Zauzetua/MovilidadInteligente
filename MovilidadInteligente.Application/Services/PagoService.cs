using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Mappers;
using MovilidadInteligente.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Services
{
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _pagoRepository;

        public PagoService(IPagoRepository pagoRepository)
        {
            _pagoRepository = pagoRepository;
        }

        public async Task<IEnumerable<PagoDTO>> GetAllAsync()
        {
            var pagos = await _pagoRepository.GetAllAsync();
            return pagos.Select(PagoMapper.ToDTO).ToList();
        }

        public async Task<PagoDTO> GetByIdAsync(string id)
        {
            var pago = await _pagoRepository.GetByIdAsync(id);
            return PagoMapper.ToDTO(pago);
        }

        public async Task<IEnumerable<PagoDTO>> GetByHistorialViajeIdAsync(string historialViajeId)
        {
            var pagos = await _pagoRepository.GetByHistorialViajeIdAsync(historialViajeId);
            return pagos.Select(PagoMapper.ToDTO).ToList();
        }

        public async Task<PagoDTO> CreateAsync(PagoDTO pagoDto)
        {
            var entidad = PagoMapper.ToEntity(pagoDto);
            var creado = await _pagoRepository.AddAsync(entidad);
            return PagoMapper.ToDTO(creado);
        }

        public async Task<PagoDTO> UpdateAsync(string id, PagoDTO pagoDto)
        {
            pagoDto.Id = id;
            var entidad = PagoMapper.ToEntity(pagoDto);
            var actualizado = await _pagoRepository.UpdateAsync(entidad);
            return PagoMapper.ToDTO(actualizado);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _pagoRepository.DeleteAsync(id);
        }
    }
}
