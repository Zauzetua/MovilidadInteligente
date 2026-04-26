using MovilidadInteligente.Application.Interfaces.Services;
using MQTTnet;

namespace MovilidadInteligente.Application.Services
{
    public class MqttService : IMqttService
    {
        public IMqttClient Client { get; private set; }

        public MqttService()
        {
            var factory = new MqttClientFactory();
            Client = factory.CreateMqttClient();
        }
    }
}
