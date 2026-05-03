using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovilidadInteligente.Domain.Entities
{
    public class Coordenada
    {
        public int Id { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Orden { get; set; }
        public string RutaPredeterminadaId { get; set; }
        [JsonIgnore]
        public RutaPredeterminada RutaPredeterminada { get; set; }

        public Coordenada() { }

        public Coordenada(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }
    }
}
