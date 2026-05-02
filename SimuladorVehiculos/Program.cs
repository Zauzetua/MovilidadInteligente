using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MQTTnet;

class Program
{
    static async Task Main(string[] args)
    {
        var factory = new MqttClientFactory();
        var client = factory.CreateMqttClient();

        string miVehiculoId = "Scooter-001";
        int miBateria = 100;

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("localhost", 1883)
            .Build();

        // 1. definimos que hara el simulador cuando le llegue un mensaje de la API
        client.ApplicationMessageReceivedAsync += async e =>
        {

            string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

            //Por si llega un mensaje vacio o con formato incorrecto, evitamos que el simulador se caiga
            if (payload == null)
                return;

            Console.WriteLine($"\n[ORDEN RECIBIDA] Iniciando viaje...");

            // deserializamos la ruta que nos mando el backend
            var rutaAsignada = JsonSerializer.Deserialize<RutaRecibida>(payload);

            if (rutaAsignada?.Coordenadas == null || rutaAsignada.Coordenadas.Count == 0)
            {
                Console.WriteLine("Ruta invalida");
                return;
            }

            // comenzamos a movernos por las coordenadas
            foreach (var punto in rutaAsignada.Coordenadas)
            {
                miBateria -= 1; // desgastamos bateria

                // publicamos telemetria (como ya lo hacia antes)
                await PublicarTelemetriaAsync(client, miVehiculoId, punto.Latitud, punto.Longitud, miBateria, "Ocupado");

                await Task.Delay(2000); // 2 segundos entre cada punto
            }

            Console.WriteLine("[LLEGADA] Viaje finalizado. Esperando nueva orden...");
            // al terminar, avisamos que volvemos a estar disponibles
            await PublicarTelemetriaAsync(client, miVehiculoId, rutaAsignada.Coordenadas[^1].Latitud, rutaAsignada.Coordenadas[^1].Longitud, miBateria, "Disponible");

        };

        await client.ConnectAsync(options);

        // 2. nos suscribimos a nuestro propio canal de comandos
        var subscribeOptions = new MqttClientSubscribeOptionsBuilder()
            .WithTopicFilter($"movilidad/vehiculos/{miVehiculoId}")
            .Build();

        await client.SubscribeAsync(subscribeOptions);

        Console.WriteLine($"[{miVehiculoId}] Conectado y esperando instrucciones en el paradero...");

        // publicamos nuestro estado inicial disponible
        await PublicarTelemetriaAsync(client, miVehiculoId, 27.070, -109.440, miBateria, "Disponible");

        // evitamos que la consola se cierre
        Console.ReadLine();
    }

    static async Task PublicarTelemetriaAsync(IMqttClient client, string id, double lat, double lon, int bat, string estado)
    {
        var json = JsonSerializer.Serialize(new { Id = id, Latitud = lat, Longitud = lon, Combustible = bat, Estado = estado });
        var message = new MqttApplicationMessageBuilder().WithTopic("movilidad/zonas/norte").WithPayload(json).Build();
        await client.PublishAsync(message);
        Console.WriteLine($"Publicando: {estado} | Bat: {bat}% | Pos: ({lat}, {lon})");
    }
}

// clases auxiliares para deserializar el json de la ruta
class RutaRecibida { public List<Punto> Coordenadas { get; set; } }
class Punto { public double Latitud { get; set; } public double Longitud { get; set; } }