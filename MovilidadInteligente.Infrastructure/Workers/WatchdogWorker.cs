using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovilidadInteligente.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Infrastructure.Workers
{
    public class WatchdogWorker : BackgroundService
    {
        private readonly ILogger<WatchdogWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public WatchdogWorker(ILogger<WatchdogWorker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Watchdog de conexiones iniciado...");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var monitoreoService = scope.ServiceProvider.GetRequiredService<MonitorearDesconexionesService>();

                        // ejecuto la limpieza de vehiculos caidos
                        await monitoreoService.EjecutarAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"""Error en el Watchdog: {ex.Message}""");
                }

                // el perro guardian se duerme 30 segundos antes de volver a revisar
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
        }
    }
}
