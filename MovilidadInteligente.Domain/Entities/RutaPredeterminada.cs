using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Domain.Entities
{
    public class RutaPredeterminada
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string OrigenlocationId { get; set; }
        public Ubicacion OrigenlLocation { get; set; }
        public string DestinoLocationId { get; set; }
        public Ubicacion DestinoLocation { get; set; }
        public List<Coordenada> Coordenadas { get; set; } = new List<Coordenada>();
        public int NivelTraficoActual { get; set; }

        public RutaPredeterminada() { }

        public RutaPredeterminada(string id, string nombre, string origenlocationId, string destinoLocationId, List<Coordenada> coordenadas, int nivelTraficoActual = 0)
        {
            Id = id;
            Nombre = nombre;
            OrigenlocationId = origenlocationId;
            DestinoLocationId = destinoLocationId;
            Coordenadas = coordenadas ?? new List<Coordenada>();
            NivelTraficoActual = nivelTraficoActual;
        }
    }
}
