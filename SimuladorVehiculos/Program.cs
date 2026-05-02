using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MQTTnet;

class Program
{
    static async Task Main(string[] args)
    {
        var factory = new MqttClientFactory();
        var client = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("localhost", 1883)
            .Build();

        await client.ConnectAsync(options);
        Console.WriteLine("Simulador Inteligente conectado al Broker.");

        string vehiculoId = "Scooter-Inteligente";
        int combustible = 100;

        // defino una ruta preestablecida (waypoints)
        // en un sistema real, estas las consultarias a tu API
        var ruta = new List<Coordenada>
{
    new Coordenada { Lat = 27.0812, Lon = -109.4438 },
    new Coordenada { Lat = 27.0805, Lon = -109.4445 },
    new Coordenada { Lat = 27.0798, Lon = -109.4452 },
    new Coordenada { Lat = 27.0791, Lon = -109.4460 },
    new Coordenada { Lat = 27.0784, Lon = -109.4467 },
    new Coordenada { Lat = 27.0777, Lon = -109.4475 }
};

        Console.WriteLine($"Iniciando viaje para {vehiculoId}...");

        // recorro la ruta punto por punto
        foreach (var punto in ruta)
        {
            // simulo que el motor consume bateria al avanzar
            combustible -= 2;

            var telemetria = new
            {
                Id = vehiculoId,
                Latitud = punto.Lat,
                Longitud = punto.Lon,
                Combustible = combustible,
                Estado = "En Ruta",
                Tipo = "Scooter"
            };

            string json = JsonSerializer.Serialize(telemetria);

            var message = new MqttApplicationMessageBuilder()
                .WithTopic("movilidad/zonas/norte")
                .WithPayload(json)
                .Build();

            await client.PublishAsync(message);
            Console.WriteLine($"[{vehiculoId}] Avanzo a ({punto.Lat}, {punto.Lon}) | Bateria: {combustible}%");

            // espero 3 segundos simulando el tiempo que le toma llegar al siguiente punto
            await Task.Delay(3000);
        }

        Console.WriteLine("El vehiculo ha llegado a su destino.");

        // aqui informamos que termino el viaje
        var reporteFinal = new
        {
            Id = vehiculoId,
            Latitud = ruta[^1].Lat, // tomo la ultima coordenada
            Longitud = ruta[^1].Lon,
            Combustible = combustible,
            Estado = "Disponible", // lo vuelvo a poner en renta
            Tipo = "Scooter"
        };

        var finalMessage = new MqttApplicationMessageBuilder()
            .WithTopic("movilidad/zonas/norte")
            .WithPayload(JsonSerializer.Serialize(reporteFinal))
            .Build();

        await client.PublishAsync(finalMessage);
    }
}

// clase auxiliar para mapear mi ruta
class Coordenada
{
    public double Lat { get; set; }
    public double Lon { get; set; }
}