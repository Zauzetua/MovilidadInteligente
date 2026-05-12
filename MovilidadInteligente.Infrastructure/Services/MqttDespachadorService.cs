using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Domain.Entities;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovilidadInteligente.Infrastructure.Services
{
    public class MqttDespachadorService : IDespachadorVehiculos
    {
        private readonly IMqttClient mqttClient;
        private readonly IVehiculoService _vehiculoService;

        public MqttDespachadorService(IMqttService mqttService, IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
            mqttClient = mqttService.Client;
            var factory = new MqttClientFactory();
            mqttClient = factory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("mosquitto", 1883)
                .Build();
            mqttClient.ConnectAsync(options).Wait();
        }

        public async Task EnviarComandoRutaAsync(string idVehiculo, RutaPredeterminada ruta)
        {
            var vehiculo = await _vehiculoService.GetByIdAsync(idVehiculo);
            if (vehiculo == null)
                throw new Exception($"Vehiculo con ID {idVehiculo} no encontrado.");

            if (vehiculo.Estado != "Disponible")
                throw new Exception($"Vehiculo con ID {idVehiculo} no está disponible. Estado actual: {vehiculo.Estado}");
            // creamos un topico unico para que solo ese vehiculo escuche
            string topico = $"movilidad/vehiculos/{idVehiculo}";

            // serializamos la ruta a json
            string payload = JsonSerializer.Serialize(ruta);

            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topico)
                .WithPayload(payload)
                .Build();

            // disparamos el mensaje hacia el broker
            await mqttClient.PublishAsync(message);

            //Marcar el vehiculo como ocupao
            await _vehiculoService.CambiarEstadoVehiculo(idVehiculo, "Ocupado");


        }
    }
}
