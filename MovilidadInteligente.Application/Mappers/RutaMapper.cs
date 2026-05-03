using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Domain.Entities;

namespace MovilidadInteligente.Application.Mappers
{
    public class RutaMapper
    {
        public static RutaDTO ToDTO(RutaPredeterminada ruta)
        {
            return new RutaDTO
            {
                Id = ruta.Id,
                Nombre = ruta.Nombre,
                OrigenlocationId = ruta.OrigenlocationId,
                DestinoLocationId = ruta.DestinoLocationId,
                NivelTraficoActual = ruta.NivelTraficoActual,
                Coordenadas = ruta.Coordenadas?.Select(c => new CoordenadaDTO
                {
                    Id = c.Id,
                    Latitud = c.Latitud,
                    Longitud = c.Longitud,
                    Orden = c.Orden
                }).ToList() ?? new List<CoordenadaDTO>(),
                OrigenlLocation = ruta.OrigenlLocation != null ? UbicacionMapper.ToDTO(ruta.OrigenlLocation) : null,
                DestinoLocation = ruta.DestinoLocation != null ? UbicacionMapper.ToDTO(ruta.DestinoLocation) : null
            };
        }

        public static RutaPredeterminada ToEntity(RutaDTO dto)
        {
            var coordenadas = dto.Coordenadas?.Select((c, index) => new Coordenada
            {
                Latitud = c.Latitud,
                Longitud = c.Longitud,
                Orden = c.Orden > 0 ? c.Orden : index
            }).ToList() ?? new List<Coordenada>();

            return new RutaPredeterminada(
                dto.Id,
                dto.Nombre,
                dto.OrigenlocationId,
                dto.DestinoLocationId,
                coordenadas,
                dto.NivelTraficoActual
            );
        }

        public static List<RutaDTO> ToDTOList(List<RutaPredeterminada> rutas)
        {
            return rutas.Select(r => ToDTO(r)).ToList();
        }
    }
}
