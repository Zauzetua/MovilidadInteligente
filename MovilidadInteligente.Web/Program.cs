using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovilidadInteligente.Application.Interfaces.Repositories;
using MovilidadInteligente.Application.Interfaces.Services;
using MovilidadInteligente.Application.Services;
using MovilidadInteligente.Infrastructure.Data;
using MovilidadInteligente.Infrastructure.Repositories;
using MovilidadInteligente.Infrastructure.Services;
using MovilidadInteligente.Infrastructure.Workers;
using MovilidadInteligente.Web.Hubs;
using MQTTnet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MovilidadDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            // La magia está aquí: Habilita la resiliencia a errores transitorios
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5, // Intenta 5 veces
                maxRetryDelay: TimeSpan.FromSeconds(5), // Espera hasta 5 segundos entre intentos
                errorNumbersToAdd: null
            );
        }
    )
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        policy =>
        {
            policy
                .WithOrigins("http://localhost")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials(); // esto es obligatorio para que SignalR funcione
        }
    );
});

builder.Services.AddSignalR();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IUbicacionRepository, UbicacionRepository>();
builder.Services.AddScoped<IRutaRepository, RutaRepository>();
builder.Services.AddScoped<IHistorialViajeRepository, HistorialViajeRepository>();
builder.Services.AddScoped<IPagoRepository, PagoRepository>();

builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<IUbicacionService, UbicacionService>();
builder.Services.AddScoped<IRutaService, RutaService>();
builder.Services.AddScoped<IHistorialViajeService, HistorialViajeService>();
builder.Services.AddScoped<IPagoService, PagoService>();

//builder.Services.AddScoped<AsignarRutaService>();
builder.Services.AddScoped<CatalogoRutasService>();

builder.Services.AddSingleton<IMqttService, MqttService>();

//builder.Services.AddHostedService<WatchdogWorker>();
builder.Services.AddScoped<ProcesarTelemetriaService>();
builder.Services.AddScoped<MonitorearDesconexionesService>();
builder.Services.AddScoped<ObtenerVehiculosMantenimientoService>();
builder.Services.AddScoped<INotificadorHub, NotificadorHubAdapter>();
builder.Services.AddScoped<IDespachadorVehiculos, MqttDespachadorService>();

//builder.Services.AddScoped<INotificadorHub>();

//JWT
// configuramos la autenticacion con JWT
builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Jwt:Authority"];
        options.Audience = builder.Configuration["Jwt:Audience"];

        // apagamos la exigencia de https porque estamos en localhost
        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuers = new[]
            {
                "http://localhost:8080/realms/MovilidadInteligente",
                "http://keycloak:8080/realms/MovilidadInteligente",
            },
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
        };
    });

// habilitamos la autorizacion
builder.Services.AddAuthorization();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MovilidadDbContext>();
    var randomDelay = new Random().Next(0, 3000);
    System.Threading.Thread.Sleep(randomDelay);
    try
    {
    dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Una API ya levanto la DB o trono: {ex.Message}");
    }
}
app.UseRouting();

app.UseCors("AllowAll");
app.MapHub<MovilidadHub>("/hubs/movilidad");
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
