using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovilidadInteligente.Application.Interfaces.Services;
using MQTTnet;
using System.Text;

namespace MovilidadInteligente.Infrastructure.Workers
{
    public class MovilidadWorker : BackgroundService
    {
        private IMqttClient _mqttClient;
        private readonly ILogger<MovilidadWorker> _logger;

        public MovilidadWorker(IMqttService mqttService, ILogger<MovilidadWorker> logger)
        {
            _mqttClient = mqttService.Client;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MovilidadWorker iniciado");

            var factory = new MqttClientFactory();
            _mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("broker.hivemq.com", 1883)
                .Build();

            _mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                _logger.LogInformation($"Mensaje recibido en topic {e.ApplicationMessage.Topic}: {payload}");
                return Task.CompletedTask;
            };

            await _mqttClient.ConnectAsync(options, stoppingToken);

            var subscribeOptions = new MqttTopicFilterBuilder()
                .WithTopic("movilidad/Inteligente")
                .Build();

            await _mqttClient.SubscribeAsync(subscribeOptions, stoppingToken);

            _logger.LogInformation("MovilidadWorker conectado al broker MQTT y suscrito al topic 'movilidad/inteligente'");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }

            await _mqttClient.DisconnectAsync();
        }
    }
}
