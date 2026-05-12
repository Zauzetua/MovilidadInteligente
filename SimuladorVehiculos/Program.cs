using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
            Console.WriteLine(
                $"No fue posible obtener vehículos desde la API: {ex.Message}. Usando lista por defecto."
            );
            vehiculosIniciales = new List<VehiculoInicio>
            {
                new VehiculoInicio
                {
                    Id = "Scooter-001",
                    Lat = 27.070,
                    Lon = -109.440,
                },
                new VehiculoInicio
                {
                    Id = "Scooter-002",
                    Lat = 27.078,
                    Lon = -109.448,
                },
            };
        }

        var tareas = new List<Task>();

        foreach (var vehiculo in vehiculosIniciales)
        {
            // lanzamos un hilo independiente por cada vehiculo
            tareas.Add(
                IniciarSimuladorVehiculoAsync(
                    vehiculo.Id,
                    vehiculo.Lat,
                    vehiculo.Lon,
                    vehiculo.Combustible
                )
            );
        }

        // esperamos a que todos los hilos corran en paralelo
        await Task.WhenAll(tareas);
    }

    static async Task IniciarSimuladorVehiculoAsync(
        string vehiculoId,
        double latInicial,
        double lonInicial,
        int combustible
    )
    {
        var factory = new MqttClientFactory();
        var client = factory.CreateMqttClient();

        var options = new MqttClientOptionsBuilder()
            .WithTcpServer("mosquitto", 1883)
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

                await PublicarTelemetriaAsync(
                    client,
                    vehiculoId,
                    punto.Latitud,
                    punto.Longitud,
                    combustible,
                    "Ocupado"
                );

                await Task.Delay(2000);
            }

            Console.WriteLine($"[{vehiculoId}] [LLEGADA] Viaje finalizado.");
            var ultimoPunto = rutaAsignada.Coordenadas[^1];
            await PublicarTelemetriaAsync(
                client,
                vehiculoId,
                ultimoPunto.Latitud,
                ultimoPunto.Longitud,
                combustible,
                "Disponible"
            );
        };

        await client.ConnectAsync(options);

        await client.SubscribeAsync(
            new MqttClientSubscribeOptionsBuilder()
                .WithTopicFilter($"movilidad/vehiculos/{vehiculoId}")
                .Build()
        );

        Console.WriteLine($"[{vehiculoId}] Conectado y esperando instrucciones...");

        await PublicarTelemetriaAsync(
            client,
            vehiculoId,
            latInicial,
            lonInicial,
            combustible,
            "Disponible"
        );

        //mantener vivo el simulador
        await Task.Delay(Timeout.Infinite);
    }

    static async Task PublicarTelemetriaAsync(
        IMqttClient client,
        string id,
        double lat,
        double lon,
        int bat,
        string estado
    )
    {
        var json = JsonSerializer.Serialize(
            new
            {
                Id = id,
                Latitud = lat,
                Longitud = lon,
                Combustible = bat,
                Estado = estado,
            }
        );
        var message = new MqttApplicationMessageBuilder()
            .WithTopic("movilidad/zonas/norte")
            .WithPayload(json)
            .Build();

        await client.PublishAsync(message);
        Console.WriteLine($"[{id}] Publicando: {estado} | Bat: {bat}% | Pos: ({lat}, {lon})");
    }

    static async Task<List<VehiculoInicio>> ObtenerVehiculosDesdeApiAsync()
    {
        using var http = new HttpClient();
        http.Timeout = TimeSpan.FromSeconds(30);

        int maxReintentos = 6;
        int delaySegundos = 5; // keycloak tarda un poco en levantar, le doy paciencia
        bool tokenObtenido = false;

        for (int i = 1; i <= maxReintentos; i++)
        {
            try
            {
                // 1. intento obtener mi token de Keycloak
                var tokenResponse = await http.PostAsync(
                    "http://keycloak:8080/realms/MovilidadInteligente/protocol/openid-connect/token",
                    new FormUrlEncodedContent(
                        new[]
                        {
                            new KeyValuePair<string, string>("client_id", "movilidad-api"),
                            new KeyValuePair<string, string>("grant_type", "password"),
                            new KeyValuePair<string, string>("username", "profesor"),
                            new KeyValuePair<string, string>("password", "1234"),
                        }
                    )
                );

                if (tokenResponse.IsSuccessStatusCode)
                {
                    var tokenJson = await tokenResponse.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(tokenJson);
                    var token = doc.RootElement.GetProperty("access_token").GetString();

                    // le pego mi gafete a las peticiones del httpclient
                    http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        "Bearer",
                        token
                    );
                    tokenObtenido = true;
                    break; // salgo del ciclo porque ya tengo el token
                }
            }
            catch (HttpRequestException)
            {
                Console.WriteLine(
                    $"[Keycloak] Conexion rechazada. Intento {i} de {maxReintentos}. Esperando {delaySegundos}s..."
                );
                await Task.Delay(TimeSpan.FromSeconds(delaySegundos));
            }
        }

        if (!tokenObtenido)
        {
            Console.WriteLine(
                "Advertencia: No pude obtener el token despues de varios intentos. Fallara con 401."
            );
        }

        // 2. apunto a la api usando el nombre del contenedor
        var baseUrl =
            Environment.GetEnvironmentVariable("API_URL") ?? "http://api:8080/api/vehiculos";

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
                resultado.Add(
                    new VehiculoInicio
                    {
                        Id = v.Id,
                        Lat = v.Latitud,
                        Lon = v.Longitud,
                        Combustible = v.Combustible,
                        Estado = v.Estado,
                    }
                );
            }
        }
        return resultado;
    }

    class VehiculoDto
    {
        public string Id { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Combustible { get; set; }
        public string Estado { get; set; }
    }

    // clases auxiliares para inicializar y deserializar
    class VehiculoInicio
    {
        public string Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public int Combustible { get; set; }
        public string Estado { get; set; }
    }

    class RutaRecibida
    {
        public List<Punto> Coordenadas { get; set; }
    }

    class Punto
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
