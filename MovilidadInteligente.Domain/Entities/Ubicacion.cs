using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Domain.Entities
{
    public class Ubicacion
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
