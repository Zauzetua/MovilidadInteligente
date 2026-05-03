using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Domain.Entities;

namespace MovilidadInteligente.Application.Mappers
{
    public class UbicacionMapper
    {
        public static UbicacionDTO ToDTO(Ubicacion ubicacion)
        {
            return new UbicacionDTO
            {
                Id = ubicacion.Id,
                Nombre = ubicacion.Nombre,
                Latitud = ubicacion.Latitud,
                Longitud = ubicacion.Longitud
            };
        }

        public static Ubicacion ToEntity(UbicacionDTO dto)
        {
            return new Ubicacion(
                dto.Id,
                dto.Nombre,
                dto.Latitud,
                dto.Longitud
            );
        }

        public static List<UbicacionDTO> ToDTOList(List<Ubicacion> ubicaciones)
        {
            return ubicaciones.Select(u => ToDTO(u)).ToList();
        }
    }
}
