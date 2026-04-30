using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Application.Mappers;
using MovilidadInteligente.Application.Models;

namespace MovilidadInteligente.Application.Services
{
    public class ObtenerVehiculosMantenimientoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public ObtenerVehiculosMantenimientoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<List<VehiculoDTO>> EjecutarAsync()
        {
            var vehiculosMantenimiento = await _vehiculoRepository.ObtenerVehiculosMantenimiento();
            return VehiculoMapper.ToDTOList(vehiculosMantenimiento.ToList());

        }

    }
}
