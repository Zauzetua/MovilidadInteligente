using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Domain.Entities
{
    public class Vehiculo
    {
        public string Id { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Combustible { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public DateTime UltimaActualizacion { get; set; }

        public Vehiculo(string id, double latitud, double longitud, int combustible, string tipo, string estado, DateTime ultimaActualizacion)
        {
            Id = id;
            Latitud = latitud;
            Longitud = longitud;
            Combustible = combustible;
            Tipo = tipo;
            Estado = estado;
            UltimaActualizacion = ultimaActualizacion;
        }

        public Vehiculo()
        {
        }
    }
}
