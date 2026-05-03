using System;

namespace MovilidadInteligente.Application.Models
{
    public class HistorialViajeDTO
    {
        public string Id { get; set; }
        public string VehiculoId { get; set; }
        public string OrigenLocationId { get; set; }
        public string DestinoLocationId { get; set; }
        public string Estado { get; set; }
        public DateTime InicioUtc { get; set; }
        public DateTime? FinUtc { get; set; }
        public decimal? DistanciaKm { get; set; }
        public decimal? CostoEstimado { get; set; }
    }
}
