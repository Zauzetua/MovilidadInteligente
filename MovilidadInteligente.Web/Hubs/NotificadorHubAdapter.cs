using Microsoft.AspNetCore.SignalR;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Models;
using MovilidadInteligente.Domain.Entities;
using System;

namespace MovilidadInteligente.Web.Hubs
{
    public class NotificadorHubAdapter : INotificadorHub
    {
        private readonly IHubContext<MovilidadHub> _hubContext;

        public NotificadorHubAdapter(IHubContext<MovilidadHub> hubContext)
        {
            // inyecto el contexto de mi hub para poder enviar mensajes desde mi backend
            _hubContext = hubContext;
        }

        public async Task EnviarActualizacionVehiculoAsync(VehiculoDTO dto)
        {
            // disparo el evento 'ActualizarVehiculo' a todos los navegadores conectados
            await _hubContext.Clients.All.SendAsync("ActualizarVehiculo", dto);
        }

        public async Task EnviarViajeFinalizadoAsync(string vehiculoId)
        {
            await _hubContext.Clients.All.SendAsync("ViajeFinalizado", new
            {
                VehiculoId = vehiculoId,
                Fecha = DateTime.UtcNow
            });
        }
    }
}
