using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// agrego cors aqui tambien porque ahora mi frontend le pegara al gateway, no a la api directa
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// inyecto yarp y le digo que lea mi appsettings.json
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// aplico mis politicas de cors
app.UseCors("PermitirFrontend");

// enciendo el enrutador del proxy
app.MapReverseProxy();

app.Run();