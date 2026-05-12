using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Models; // Ajusta el namespace a tus DTOs
using MovilidadInteligente.Domain.Entities;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MovilidadInteligente.Worker
{
    public class NotificadorHttpAdapter : INotificadorHub
    {
        private readonly HttpClient _httpClient;

        public NotificadorHttpAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task EnviarActualizacionVehiculoAsync(VehiculoDTO vehiculoDto)
        {
            // le pego a un endpoint interno de mi api para que ella dispare el signalr
            // uso fire-and-forget para no bloquear mi worker si la api anda lenta
            _ = _httpClient.PostAsJsonAsync("/api/internal/notificaciones/vehiculo", vehiculoDto);
        }

        public async Task EnviarViajeFinalizadoAsync(string vehiculoId)
        {
            _ = _httpClient.PostAsJsonAsync("/api/internal/notificaciones/viajefinalizado", vehiculoId);
        }
    }
}