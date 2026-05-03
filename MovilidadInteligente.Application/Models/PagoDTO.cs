using System;

namespace MovilidadInteligente.Application.Models
{
    public class PagoDTO
    {
        public string Id { get; set; }
        public string HistorialViajeId { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; } = "MXN";
        public string Metodo { get; set; }
        public string Estado { get; set; }
        public string? Referencia { get; set; }
        public DateTime FechaUtc { get; set; }
    }
}
