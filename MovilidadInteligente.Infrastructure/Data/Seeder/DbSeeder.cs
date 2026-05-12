using Microsoft.EntityFrameworkCore;
using MovilidadInteligente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovilidadInteligente.Infrastructure.Data.Seeder
{
    public static class DbSeeder
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // Ubicaciones (Dependencia de Rutas y Viajes)
            modelBuilder.Entity<Ubicacion>().HasData(
                new Ubicacion { Id = "prueba1-1777772764332", Nombre = "Prueba1", Latitud = 27.1, Longitud = -109.5 },
                new Ubicacion { Id = "U1", Nombre = "Centro", Latitud = 27.072, Longitud = -109.443 },
                new Ubicacion { Id = "U10", Nombre = "Terminal", Latitud = 27.055, Longitud = -109.455 },
                new Ubicacion { Id = "U2", Nombre = "Norte", Latitud = 27.085, Longitud = -109.45 },
                new Ubicacion { Id = "U3", Nombre = "Sur", Latitud = 27.06, Longitud = -109.44 },
                new Ubicacion { Id = "U4", Nombre = "Este", Latitud = 27.07, Longitud = -109.42 },
                new Ubicacion { Id = "U5", Nombre = "Oeste", Latitud = 27.07, Longitud = -109.46 },
                new Ubicacion { Id = "U6", Nombre = "Hospital", Latitud = 27.075, Longitud = -109.435 },
                new Ubicacion { Id = "U7", Nombre = "Universidad", Latitud = 27.08, Longitud = -109.445 },
                new Ubicacion { Id = "U8", Nombre = "Parque", Latitud = 27.065, Longitud = -109.43 },
                new Ubicacion { Id = "U9", Nombre = "Plaza", Latitud = 27.073, Longitud = -109.438 }
            );

            // Rutas Predeterminadas (Dependen de Ubicaciones)
            modelBuilder.Entity<RutaPredeterminada>().HasData(
                new RutaPredeterminada { Id = "prueba-a-centro-1777773184083", Nombre = "Prueba a Centro", OrigenlocationId = "prueba1-1777772764332", DestinoLocationId = "U1", NivelTraficoActual = 0 },
                new RutaPredeterminada { Id = "R1", Nombre = "Centro a Norte", OrigenlocationId = "U1", DestinoLocationId = "U2", NivelTraficoActual = 1 },
                new RutaPredeterminada { Id = "R10", Nombre = "Hospital a Universidad ALT", OrigenlocationId = "U6", DestinoLocationId = "U7", NivelTraficoActual = 2 },
                new RutaPredeterminada { Id = "R2", Nombre = "Centro a Norte ALT", OrigenlocationId = "U1", DestinoLocationId = "U2", NivelTraficoActual = 2 },
                new RutaPredeterminada { Id = "R3", Nombre = "Centro a Sur", OrigenlocationId = "U1", DestinoLocationId = "U3", NivelTraficoActual = 1 },
                new RutaPredeterminada { Id = "R4", Nombre = "Centro a Sur ALT", OrigenlocationId = "U1", DestinoLocationId = "U3", NivelTraficoActual = 2 },
                new RutaPredeterminada { Id = "R5", Nombre = "Norte a Este", OrigenlocationId = "U2", DestinoLocationId = "U4", NivelTraficoActual = 1 },
                new RutaPredeterminada { Id = "R6", Nombre = "Norte a Este ALT", OrigenlocationId = "U2", DestinoLocationId = "U4", NivelTraficoActual = 2 },
                new RutaPredeterminada { Id = "R7", Nombre = "Sur a Oeste", OrigenlocationId = "U3", DestinoLocationId = "U5", NivelTraficoActual = 1 },
                new RutaPredeterminada { Id = "R8", Nombre = "Sur a Oeste ALT", OrigenlocationId = "U3", DestinoLocationId = "U5", NivelTraficoActual = 2 },
                new RutaPredeterminada { Id = "R9", Nombre = "Hospital a Universidad", OrigenlocationId = "U6", DestinoLocationId = "U7", NivelTraficoActual = 1 }
            );

            // Coordenadas (Dependen de Rutas Predeterminadas)
            modelBuilder.Entity<Coordenada>().HasData(
                new Coordenada { Id = 1, Latitud = 27.072, Longitud = -109.443, Orden = 1, RutaPredeterminadaId = "R1" },
                new Coordenada { Id = 2, Latitud = 27.078, Longitud = -109.446, Orden = 2, RutaPredeterminadaId = "R1" },
                new Coordenada { Id = 3, Latitud = 27.085, Longitud = -109.45, Orden = 3, RutaPredeterminadaId = "R1" },
                new Coordenada { Id = 4, Latitud = 27.072, Longitud = -109.443, Orden = 1, RutaPredeterminadaId = "R2" },
                new Coordenada { Id = 5, Latitud = 27.074, Longitud = -109.44, Orden = 2, RutaPredeterminadaId = "R2" },
                new Coordenada { Id = 6, Latitud = 27.078, Longitud = -109.442, Orden = 3, RutaPredeterminadaId = "R2" },
                new Coordenada { Id = 7, Latitud = 27.082, Longitud = -109.447, Orden = 4, RutaPredeterminadaId = "R2" },
                new Coordenada { Id = 8, Latitud = 27.085, Longitud = -109.45, Orden = 5, RutaPredeterminadaId = "R2" },
                new Coordenada { Id = 9, Latitud = 27.072, Longitud = -109.443, Orden = 1, RutaPredeterminadaId = "R3" },
                new Coordenada { Id = 10, Latitud = 27.066, Longitud = -109.441, Orden = 2, RutaPredeterminadaId = "R3" },
                new Coordenada { Id = 11, Latitud = 27.06, Longitud = -109.44, Orden = 3, RutaPredeterminadaId = "R3" },
                new Coordenada { Id = 12, Latitud = 27.072, Longitud = -109.443, Orden = 1, RutaPredeterminadaId = "R4" },
                new Coordenada { Id = 13, Latitud = 27.07, Longitud = -109.438, Orden = 2, RutaPredeterminadaId = "R4" },
                new Coordenada { Id = 14, Latitud = 27.065, Longitud = -109.437, Orden = 3, RutaPredeterminadaId = "R4" },
                new Coordenada { Id = 15, Latitud = 27.062, Longitud = -109.439, Orden = 4, RutaPredeterminadaId = "R4" },
                new Coordenada { Id = 16, Latitud = 27.06, Longitud = -109.44, Orden = 5, RutaPredeterminadaId = "R4" },
                new Coordenada { Id = 17, Latitud = 27.085, Longitud = -109.45, Orden = 1, RutaPredeterminadaId = "R5" },
                new Coordenada { Id = 18, Latitud = 27.078, Longitud = -109.435, Orden = 2, RutaPredeterminadaId = "R5" },
                new Coordenada { Id = 19, Latitud = 27.07, Longitud = -109.42, Orden = 3, RutaPredeterminadaId = "R5" },
                new Coordenada { Id = 20, Latitud = 27.085, Longitud = -109.45, Orden = 1, RutaPredeterminadaId = "R6" },
                new Coordenada { Id = 21, Latitud = 27.083, Longitud = -109.445, Orden = 2, RutaPredeterminadaId = "R6" },
                new Coordenada { Id = 22, Latitud = 27.08, Longitud = -109.44, Orden = 3, RutaPredeterminadaId = "R6" },
                new Coordenada { Id = 23, Latitud = 27.075, Longitud = -109.43, Orden = 4, RutaPredeterminadaId = "R6" },
                new Coordenada { Id = 24, Latitud = 27.07, Longitud = -109.42, Orden = 5, RutaPredeterminadaId = "R6" },
                new Coordenada { Id = 25, Latitud = 27.06, Longitud = -109.44, Orden = 1, RutaPredeterminadaId = "R7" },
                new Coordenada { Id = 26, Latitud = 27.065, Longitud = -109.45, Orden = 2, RutaPredeterminadaId = "R7" },
                new Coordenada { Id = 27, Latitud = 27.07, Longitud = -109.46, Orden = 3, RutaPredeterminadaId = "R7" },
                new Coordenada { Id = 28, Latitud = 27.06, Longitud = -109.44, Orden = 1, RutaPredeterminadaId = "R8" },
                new Coordenada { Id = 29, Latitud = 27.062, Longitud = -109.445, Orden = 2, RutaPredeterminadaId = "R8" },
                new Coordenada { Id = 30, Latitud = 27.065, Longitud = -109.448, Orden = 3, RutaPredeterminadaId = "R8" },
                new Coordenada { Id = 31, Latitud = 27.068, Longitud = -109.455, Orden = 4, RutaPredeterminadaId = "R8" },
                new Coordenada { Id = 32, Latitud = 27.07, Longitud = -109.46, Orden = 5, RutaPredeterminadaId = "R8" },
                new Coordenada { Id = 33, Latitud = 27.075, Longitud = -109.435, Orden = 1, RutaPredeterminadaId = "R9" },
                new Coordenada { Id = 34, Latitud = 27.078, Longitud = -109.44, Orden = 2, RutaPredeterminadaId = "R9" },
                new Coordenada { Id = 35, Latitud = 27.08, Longitud = -109.445, Orden = 3, RutaPredeterminadaId = "R9" },
                new Coordenada { Id = 36, Latitud = 27.075, Longitud = -109.435, Orden = 1, RutaPredeterminadaId = "R10" },
                new Coordenada { Id = 37, Latitud = 27.076, Longitud = -109.438, Orden = 2, RutaPredeterminadaId = "R10" },
                new Coordenada { Id = 38, Latitud = 27.078, Longitud = -109.442, Orden = 3, RutaPredeterminadaId = "R10" },
                new Coordenada { Id = 39, Latitud = 27.079, Longitud = -109.444, Orden = 4, RutaPredeterminadaId = "R10" },
                new Coordenada { Id = 40, Latitud = 27.08, Longitud = -109.445, Orden = 5, RutaPredeterminadaId = "R10" },
                new Coordenada { Id = 41, Latitud = 27.1, Longitud = -109.5, Orden = 1, RutaPredeterminadaId = "prueba-a-centro-1777773184083" },
                new Coordenada { Id = 42, Latitud = 27.2, Longitud = -109.6, Orden = 2, RutaPredeterminadaId = "prueba-a-centro-1777773184083" },
                new Coordenada { Id = 43, Latitud = 27.072, Longitud = -109.443, Orden = 3, RutaPredeterminadaId = "prueba-a-centro-1777773184083" }
            );

            // Vehiculos
            modelBuilder.Entity<Vehiculo>().HasData(
                new Vehiculo { Id = "Scooter-001", Latitud = 27.072, Longitud = -109.443, Combustible = 88, Tipo = "Scooter", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:12:10.0488365") },
                new Vehiculo { Id = "Scooter-002", Latitud = 27.078, Longitud = -109.448, Combustible = 88, Tipo = "Scooter", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.5872180") },
                new Vehiculo { Id = "V1", Latitud = 27.085, Longitud = -109.45, Combustible = 47, Tipo = "Auto", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.0270798") },
                new Vehiculo { Id = "V10", Latitud = 27.072, Longitud = -109.443, Combustible = 43, Tipo = "Camion", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.6129546") },
                new Vehiculo { Id = "V2", Latitud = 27.085, Longitud = -109.45, Combustible = 57, Tipo = "Moto", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.6424875") },
                new Vehiculo { Id = "V3", Latitud = 27.072, Longitud = -109.443, Combustible = 44, Tipo = "Auto", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.3960542") },
                new Vehiculo { Id = "V4", Latitud = 27.07, Longitud = -109.42, Combustible = 90, Tipo = "Camion", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.5052411") },
                new Vehiculo { Id = "V5", Latitud = 27.072, Longitud = -109.443, Combustible = 67, Tipo = "Auto", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.5454565") },
                new Vehiculo { Id = "V6", Latitud = 27.07, Longitud = -109.46, Combustible = 34, Tipo = "Moto", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.2850467") },
                new Vehiculo { Id = "V7", Latitud = 27.08, Longitud = -109.445, Combustible = 76, Tipo = "Auto", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.4765969") },
                new Vehiculo { Id = "V8", Latitud = 27.065, Longitud = -109.43, Combustible = 30, Tipo = "Moto", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.6744411") },
                new Vehiculo { Id = "V9", Latitud = 27.072, Longitud = -109.443, Combustible = 74, Tipo = "Auto", Estado = "Disponible", UltimaActualizacion = DateTime.Parse("2026-05-10T03:11:52.3734271") }
            );

            // Historial de Viajes (Dependen de Vehiculos y Ubicaciones)
            modelBuilder.Entity<HistorialViaje>().HasData(
                new HistorialViaje { Id = "0bbd1448-9cc9-4983-b7d2-c4fcf92bde3d", VehiculoId = "V4", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "En Progreso", InicioUtc = DateTime.Parse("2026-05-10T03:05:48.3637172"), FinUtc = null, DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "2066aa6e-773a-4adf-9afd-3009c04fca3b", VehiculoId = "V2", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "En Progreso", InicioUtc = DateTime.Parse("2026-05-10T03:07:21.5330576"), FinUtc = null, DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "2696e4f2-da8a-495b-bd5e-ebdfe315ad65", VehiculoId = "V3", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-04T01:23:17.5923235"), FinUtc = DateTime.Parse("2026-05-04T01:23:23.6717054"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "310ed534-8715-48bf-8625-3d7bf61be55e", VehiculoId = "Scooter-001", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-10T03:12:04.0819988"), FinUtc = DateTime.Parse("2026-05-10T03:12:10.0919828"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "41f3bb58-91b8-48f3-8ebf-a79ad705bee2", VehiculoId = "Scooter-001", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-10T03:09:24.5986266"), FinUtc = DateTime.Parse("2026-05-10T03:09:30.6914298"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "44b42372-8330-4964-a3af-507ccedf5280", VehiculoId = "Scooter-001", OrigenLocationId = "U1", DestinoLocationId = "U2", Estado = "En Progreso", InicioUtc = DateTime.Parse("2026-05-05T05:58:54.4396903"), FinUtc = null, DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "4b668085-6371-45fd-9b50-431ae2d1946c", VehiculoId = "V4", OrigenLocationId = "U6", DestinoLocationId = "U7", Estado = "En Progreso", InicioUtc = DateTime.Parse("2026-05-10T03:03:41.3311119"), FinUtc = null, DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "611500d3-35f8-4459-87be-54b31f7680db", VehiculoId = "V1", OrigenLocationId = "U1", DestinoLocationId = "U3", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-05T05:59:50.1837917"), FinUtc = DateTime.Parse("2026-05-05T05:59:56.2711448"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "663e9a61-b4a1-4735-85bb-09ef8307b400", VehiculoId = "Scooter-001", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-10T03:10:51.7037285"), FinUtc = DateTime.Parse("2026-05-10T03:10:57.7551233"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "736db446-6e5f-4590-8915-9973cc423fac", VehiculoId = "V7", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-05T05:55:28.3979584"), FinUtc = DateTime.Parse("2026-05-05T05:55:34.5004121"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "8d3adc00-ed9e-40d9-857b-7923ff70a595", VehiculoId = "Scooter-001", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-10T03:08:31.2088291"), FinUtc = DateTime.Parse("2026-05-10T03:08:37.2422646"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "95a371e0-50be-4b7e-82ca-6eac04cba9e2", VehiculoId = "V3", OrigenLocationId = "U2", DestinoLocationId = "U4", Estado = "En Progreso", InicioUtc = DateTime.Parse("2026-05-10T03:04:05.5900392"), FinUtc = null, DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "ababe30e-4aa3-4b94-ab40-e073aeb85ec3", VehiculoId = "V6", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-03T04:55:03.4893104"), FinUtc = DateTime.Parse("2026-05-03T04:55:09.5986384"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "af97e9e8-5176-4349-ba2f-b7089ba7bb73", VehiculoId = "V10", OrigenLocationId = "U1", DestinoLocationId = "U2", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-05T21:10:35.5457587"), FinUtc = DateTime.Parse("2026-05-05T21:10:41.6905434"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "bb8aad59-c8bd-46ca-a26e-72975825802a", VehiculoId = "V7", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-03T22:58:44.9954889"), FinUtc = DateTime.Parse("2026-05-03T22:58:51.0787468"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "d2b81ec5-aac7-4d7e-a165-ceb734aa5e70", VehiculoId = "V7", OrigenLocationId = "U6", DestinoLocationId = "U7", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-10T03:02:58.5080684"), FinUtc = DateTime.Parse("2026-05-10T03:03:04.6122358"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "d5aba4b5-c5ea-416b-8a7a-e0825880242e", VehiculoId = "V1", OrigenLocationId = "U1", DestinoLocationId = "U2", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-05T07:24:30.0337935"), FinUtc = DateTime.Parse("2026-05-05T07:24:36.1263108"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "e1cc2e31-abf4-46c2-8105-9002c4397e5d", VehiculoId = "V10", OrigenLocationId = "prueba1-1777772764332", DestinoLocationId = "U1", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-10T02:58:31.6951448"), FinUtc = DateTime.Parse("2026-05-10T02:58:37.7454914"), DistanciaKm = null, CostoEstimado = null },
                new HistorialViaje { Id = "e364d369-2f88-478c-8111-1a9dc1b42632", VehiculoId = "V6", OrigenLocationId = "U3", DestinoLocationId = "U5", Estado = "Finalizado", InicioUtc = DateTime.Parse("2026-05-10T03:02:02.8975135"), FinUtc = DateTime.Parse("2026-05-10T03:02:08.9390746"), DistanciaKm = null, CostoEstimado = null }
            );

            // Pagos (Dependen de Historial de Viajes)
            modelBuilder.Entity<Pago>().HasData(
                new Pago { Id = "pago-1777849190243-jgftk", HistorialViajeId = "bb8aad59-c8bd-46ca-a26e-72975825802a", Monto = 20.13m, Moneda = "MXN", Metodo = "Efectivo", Estado = "Completado", Referencia = null, FechaUtc = DateTime.Parse("2026-05-03T22:59:50.2695688") },
                new Pago { Id = "pago-1777857825020-v5edd", HistorialViajeId = "ababe30e-4aa3-4b94-ab40-e073aeb85ec3", Monto = 0.08m, Moneda = "MXN", Metodo = "Efectivo", Estado = "Completado", Referencia = null, FechaUtc = DateTime.Parse("2026-05-04T01:23:45.0427677") },
                new Pago { Id = "pago-1777960664627-u1v2g", HistorialViajeId = "2696e4f2-da8a-495b-bd5e-ebdfe315ad65", Monto = 100.00m, Moneda = "MXN", Metodo = "Efectivo", Estado = "Completado", Referencia = null, FechaUtc = DateTime.Parse("2026-05-05T05:57:44.6557160") }
            );
        }
    }
}
