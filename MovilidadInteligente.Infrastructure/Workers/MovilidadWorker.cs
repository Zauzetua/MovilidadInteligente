using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Services;
using MovilidadInteligente.Domain.Entities;
using MQTTnet;
using System.Text;
using System.Text.Json;

namespace MovilidadInteligente.Infrastructure.Workers
{
    public class MovilidadWorker : BackgroundService
    {
        private IMqttClient _mqttClient;
        private readonly ILogger<MovilidadWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public MovilidadWorker(IMqttService mqttService, ILogger<MovilidadWorker> logger, IServiceProvider serviceProvider)
        {
            _mqttClient = mqttService.Client;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MovilidadWorker iniciado");

            var factory = new MqttClientFactory();
            _mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883)
                .Build();

            _mqttClient.ApplicationMessageReceivedAsync += async e =>
            {
                string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                _logger.LogInformation($"Mensaje recibido en topic {e.ApplicationMessage.Topic}: {payload}");
                try
                {
                    var opcionesJson = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var vehiculo = JsonSerializer.Deserialize<Vehiculo>(payload, opcionesJson);

                    if (vehiculo != null)
                    {
                        // creo un scope aislado para manejar esta coordenada sin chocar con otras
                        using (var scope = _serviceProvider.CreateScope())
                        {
                            // resuelvo mi caso de uso desde el scope fresco
                            var procesarService = scope.ServiceProvider.GetRequiredService<ProcesarTelemetriaService>();

                            // ejecuto mis reglas de negocio y actualizo la bd
                            await procesarService.EjecutarAsync(vehiculo);
                        }

                        _logger.LogInformation($"[Backend] Procese exitosamente el vehiculo: {vehiculo.Id}");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"[Backend] Error critico al procesar la telemetria: {ex.Message}");
                }
            };

            await _mqttClient.ConnectAsync(options, stoppingToken);

            var subscribeOptions = new MqttTopicFilterBuilder()
                .WithTopic("movilidad/zonas/#")
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
