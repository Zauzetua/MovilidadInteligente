using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Models
{
    public class VehiculoDTO
    {
        public string Id { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Combustible { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
}
