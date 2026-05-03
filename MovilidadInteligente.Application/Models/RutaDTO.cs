namespace MovilidadInteligente.Application.Models
{
    public class RutaDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string OrigenlocationId { get; set; }
        public string DestinoLocationId { get; set; }
        public List<CoordenadaDTO> Coordenadas { get; set; } = new List<CoordenadaDTO>();
        public int NivelTraficoActual { get; set; }

        // Opcional: para respuestas que incluyen datos de ubicaciones
        public UbicacionDTO OrigenlLocation { get; set; }
        public UbicacionDTO DestinoLocation { get; set; }
    }
}
