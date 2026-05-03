using System;

namespace MovilidadInteligente.Domain.Entities
{
    public class Pago
    {
        public string Id { get; set; }
        public string HistorialViajeId { get; set; }
        public HistorialViaje HistorialViaje { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; } = "MXN";
        public string Metodo { get; set; }
        public string Estado { get; set; }
        public string? Referencia { get; set; }
        public DateTime FechaUtc { get; set; } = DateTime.UtcNow;

        public Pago() { }

        public Pago(
            string id,
            string historialViajeId,
            decimal monto,
            string moneda,
            string metodo,
            string estado,
            string? referencia,
            DateTime fechaUtc)
        {
            Id = id;
            HistorialViajeId = historialViajeId;
            Monto = monto;
            Moneda = moneda;
            Metodo = metodo;
            Estado = estado;
            Referencia = referencia;
            FechaUtc = fechaUtc;
        }
    }
}
