using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovilidadInteligente.Infrastructure.Data;
using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Infrastructure.Repositories;
using MovilidadInteligente.Application.Services;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Worker;
using MovilidadInteligente.Infrastructure.Workers;

var builder = Host.CreateApplicationBuilder(args);

// configuro mi base de datos leyendo el appsettings.json
// En tu Program.cs (API y Worker)
builder.Services.AddDbContext<MovilidadDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            // La magia está aquí: Habilita la resiliencia a errores transitorios
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5, // Intenta 5 veces
                maxRetryDelay: TimeSpan.FromSeconds(5), // Espera hasta 5 segundos entre intentos
                errorNumbersToAdd: null);
        }));

// registro mis repositorios y servicios principales
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IHistorialViajeService, HistorialViajeService>();
builder.Services.AddSingleton<IMqttService, MqttService>();
builder.Services.AddScoped<IHistorialViajeRepository, HistorialViajeRepository>();
builder.Services.AddScoped<ProcesarTelemetriaService>();

// configuro mi cliente http para avisarle a mi api que notifique por signalr
builder.Services.AddHttpClient<INotificadorHub, NotificadorHttpAdapter>(client =>
{
    // apunto a mi api gateway
    client.BaseAddress = new Uri("http://api:8080");
});

// agrego mi servicio en segundo plano
builder.Services.AddHostedService<MovilidadWorker>();

var host = builder.Build();
host.Run();