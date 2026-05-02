using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Services
{
    public interface IDespachadorVehiculos
    {
        Task EnviarComandoRutaAsync(string idVehiculo, RutaPredeterminada ruta);
    }
}
