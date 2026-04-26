using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Application.Interfaces.Services
{
    public class IMqttService
    {
        public IMqttClient Client { get; }
    }
}
