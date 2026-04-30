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


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();

builder.Services.AddSingleton<IMqttService, MqttService>();
builder.Services.AddHostedService<MovilidadWorker>();
builder.Services.AddScoped<ProcesarTelemetriaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
