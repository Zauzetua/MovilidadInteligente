using Microsoft.EntityFrameworkCore;
using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Services;
using MovilidadInteligente.Infrastructure.Data;
using MovilidadInteligente.Infrastructure.Repositories;
using MovilidadInteligente.Infrastructure.Workers;
using MQTTnet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MovilidadDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        //Cambiar aqui puerto de tu frontend, si es diferente
        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // esto es obligatorio para que SignalR funcione
    });
});

builder.Services.AddSignalR();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IVehiculoService, VehiculoService>();


builder.Services.AddSingleton<IMqttService, MqttService>();
builder.Services.AddHostedService<MovilidadWorker>();
builder.Services.AddScoped<ProcesarTelemetriaService>();

var app = builder.Build();

app.UseCors("AllowAll");
// app.MapHub<MovilidadHub>("/hubs/movilidad");
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
