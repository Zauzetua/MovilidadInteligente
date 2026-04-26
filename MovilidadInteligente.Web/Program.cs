using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Services;
using MovilidadInteligente.Infrastructure.Workers;
using MQTTnet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IMqttService, MqttService>();
builder.Services.AddHostedService<MovilidadWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
