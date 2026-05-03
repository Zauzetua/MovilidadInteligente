using System;

namespace MovilidadInteligente.Domain.Entities
{
    public class HistorialViaje
    {
        public string Id { get; set; }
        public string VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public string OrigenLocationId { get; set; }
        public Ubicacion OrigenLocation { get; set; }
        public string DestinoLocationId { get; set; }
        public Ubicacion DestinoLocation { get; set; }
        public string Estado { get; set; }
        public DateTime InicioUtc { get; set; }
        public DateTime? FinUtc { get; set; }
        public decimal? DistanciaKm { get; set; }
        public decimal? CostoEstimado { get; set; }

        public HistorialViaje() { }

        public HistorialViaje(
            string id,
            string vehiculoId,
            string origenLocationId,
            string destinoLocationId,
            string estado,
            DateTime inicioUtc,
            DateTime? finUtc,
            decimal? distanciaKm,
            decimal? costoEstimado)
        {
            Id = id;
            VehiculoId = vehiculoId;
            OrigenLocationId = origenLocationId;
            DestinoLocationId = destinoLocationId;
            Estado = estado;
            InicioUtc = inicioUtc;
            FinUtc = finUtc;
            DistanciaKm = distanciaKm;
            CostoEstimado = costoEstimado;
        }
    }
}
