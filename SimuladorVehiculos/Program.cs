using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MQTTnet;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Iniciando Enjambre de Simuladores IoT...");

        List<VehiculoInicio> vehiculosIniciales;

        // Intentar obtener la lista desde la API; si falla, caer al hardcodeado.
        try
        {
            vehiculosIniciales = await ObtenerVehiculosDesdeApiAsync();
            if (vehiculosIniciales == null || vehiculosIniciales.Count == 0)
                throw new Exception("API devolvió lista vacía");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"No fue posible obtener vehículos desde la API: {ex.Message}. Usando lista por defecto.");
            vehiculosIniciales = new List<VehiculoInicio>
            {
                new VehiculoInicio { Id = "Scooter-001", Lat = 27.070, Lon = -109.440 },
                new VehiculoInicio { Id = "Scooter-002", Lat = 27.078, Lon = -109.448 }
            };
        }

        var tareas = new List<Task>();

        foreach (var vehiculo in vehiculosIniciales)
        {
            // lanzamos un hilo independiente por cada vehiculo
            tareas.Add(IniciarSimuladorVehiculoAsync(vehiculo.Id, vehiculo.Lat, vehiculo.Lon, vehiculo.Combustible));
        }

        // esperamos a que todos los hilos corran en paralelo
        await Task.WhenAll(tareas);
    }

    static async Task IniciarSimuladorVehiculoAsync(string vehiculoId, double latInicial, double lonInicial, int combustible)
    {
        var factory = new MqttClientFactory();
        var client = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("localhost", 1883)
            .WithClientId($"Simulador_{vehiculoId}")
            .Build();

        client.ApplicationMessageReceivedAsync += async e =>
        {
            string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

            if (string.IsNullOrEmpty(payload))
                return;

            Console.WriteLine($"\n[{vehiculoId}] [ORDEN RECIBIDA] Iniciando viaje...");

            var rutaAsignada = JsonSerializer.Deserialize<RutaRecibida>(payload);

            if (rutaAsignada?.Coordenadas == null || rutaAsignada.Coordenadas.Count == 0)
            {
                Console.WriteLine($"[{vehiculoId}] Ruta invalida");
                return;
            }

            foreach (var punto in rutaAsignada.Coordenadas)
            {
                combustible -= 1;

                await PublicarTelemetriaAsync(client, vehiculoId, punto.Latitud, punto.Longitud, combustible, "Ocupado");

                await Task.Delay(2000);
            }

            Console.WriteLine($"[{vehiculoId}] [LLEGADA] Viaje finalizado.");
            var ultimoPunto = rutaAsignada.Coordenadas[^1];
            await PublicarTelemetriaAsync(client, vehiculoId, ultimoPunto.Latitud, ultimoPunto.Longitud, combustible, "Disponible");
        };

        await client.ConnectAsync(options);

        await client.SubscribeAsync(
            new MqttClientSubscribeOptionsBuilder()
                .WithTopicFilter($"movilidad/vehiculos/{vehiculoId}")
                .Build()
        );

        Console.WriteLine($"[{vehiculoId}] Conectado y esperando instrucciones...");

        await PublicarTelemetriaAsync(client, vehiculoId, latInicial, lonInicial, combustible, "Disponible");

        //CLAVE: mantener vivo el simulador
        await Task.Delay(Timeout.Infinite);
    }

    static async Task PublicarTelemetriaAsync(IMqttClient client, string id, double lat, double lon, int bat, string estado)
    {
        var json = JsonSerializer.Serialize(new { Id = id, Latitud = lat, Longitud = lon, Combustible = bat, Estado = estado });
        var message = new MqttApplicationMessageBuilder().WithTopic("movilidad/zonas/norte").WithPayload(json).Build();

        await client.PublishAsync(message);
        Console.WriteLine($"[{id}] Publicando: {estado} | Bat: {bat}% | Pos: ({lat}, {lon})");
    }
    static async Task<List<VehiculoInicio>> ObtenerVehiculosDesdeApiAsync()
    {
        using var http = new HttpClient();
        http.Timeout = TimeSpan.FromSeconds(30);
        var baseUrl = Environment.GetEnvironmentVariable("API_URL") ?? "http://localhost:5150/api/vehiculos";
        var resp = await http.GetAsync(baseUrl);
        resp.EnsureSuccessStatusCode();
        var json = await resp.Content.ReadAsStringAsync();
        var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var lista = JsonSerializer.Deserialize<List<VehiculoDto>>(json, opciones);
        var resultado = new List<VehiculoInicio>();
        if (lista != null)
        {
            foreach (var v in lista)
            {
                resultado.Add(new VehiculoInicio { Id = v.Id, Lat = v.Latitud, Lon = v.Longitud, Combustible = v.Combustible, Estado = v.Estado });
            }
        }
        return resultado;
    }

    class VehiculoDto { public string Id { get; set; } public double Latitud { get; set; } public double Longitud { get; set; } public int Combustible { get; set; } public string Estado { get; set; } }

    // clases auxiliares para inicializar y deserializar
    class VehiculoInicio { public string Id { get; set; } public double Lat { get; set; } public double Lon { get; set; } public int Combustible { get; set; } public string Estado { get; set; } }
    class RutaRecibida { public List<Punto> Coordenadas { get; set; } }
    class Punto { public double Latitud { get; set; } public double Longitud { get; set; } }
}