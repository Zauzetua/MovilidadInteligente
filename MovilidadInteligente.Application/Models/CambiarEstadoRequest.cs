using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Models
{
    public class CambiarEstadoRequest
    {
        public string IdVehiculo { get; set; }
        public string NuevoEstado { get; set; }
    }
}
