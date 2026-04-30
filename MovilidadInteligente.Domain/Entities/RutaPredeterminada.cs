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
        public string Origen { get; set; }
        public string Destino { get; set; }

        public List<Coordenada> Coordenadas { get; set; } = new List<Coordenada>();
        public int NivelTraficoActual { get; set; }
    }
}
