using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovilidadInteligente.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInserts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaActualizacion",
                table: "Vehiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 12, 7, 19, 42, 46, DateTimeKind.Utc).AddTicks(3416),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 12, 6, 45, 37, 736, DateTimeKind.Utc).AddTicks(1502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InicioUtc",
                table: "HistorialViajes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 12, 7, 19, 42, 47, DateTimeKind.Utc).AddTicks(1540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 12, 6, 45, 37, 736, DateTimeKind.Utc).AddTicks(8399));

            migrationBuilder.InsertData(
                table: "Ubicaciones",
                columns: new[] { "Id", "Latitud", "Longitud", "Nombre" },
                values: new object[,]
                {
                    { "prueba1-1777772764332", 27.100000000000001, -109.5, "Prueba1" },
                    { "U1", 27.071999999999999, -109.443, "Centro" },
                    { "U10", 27.055, -109.455, "Terminal" },
                    { "U2", 27.085000000000001, -109.45, "Norte" },
                    { "U3", 27.059999999999999, -109.44, "Sur" },
                    { "U4", 27.07, -109.42, "Este" },
                    { "U5", 27.07, -109.45999999999999, "Oeste" },
                    { "U6", 27.074999999999999, -109.435, "Hospital" },
                    { "U7", 27.079999999999998, -109.44499999999999, "Universidad" },
                    { "U8", 27.065000000000001, -109.43000000000001, "Parque" },
                    { "U9", 27.073, -109.438, "Plaza" }
                });

            migrationBuilder.InsertData(
                table: "Vehiculos",
                columns: new[] { "Id", "Combustible", "Estado", "Latitud", "Longitud", "Tipo", "UltimaActualizacion" },
                values: new object[,]
                {
                    { "Scooter-001", 88, "Disponible", 27.071999999999999, -109.443, "Scooter", new DateTime(2026, 5, 10, 3, 12, 10, 48, DateTimeKind.Unspecified).AddTicks(8365) },
                    { "Scooter-002", 88, "Disponible", 27.077999999999999, -109.44799999999999, "Scooter", new DateTime(2026, 5, 10, 3, 11, 52, 587, DateTimeKind.Unspecified).AddTicks(2180) },
                    { "V1", 47, "Disponible", 27.085000000000001, -109.45, "Auto", new DateTime(2026, 5, 10, 3, 11, 52, 27, DateTimeKind.Unspecified).AddTicks(798) },
                    { "V10", 43, "Disponible", 27.071999999999999, -109.443, "Camion", new DateTime(2026, 5, 10, 3, 11, 52, 612, DateTimeKind.Unspecified).AddTicks(9546) },
                    { "V2", 57, "Disponible", 27.085000000000001, -109.45, "Moto", new DateTime(2026, 5, 10, 3, 11, 52, 642, DateTimeKind.Unspecified).AddTicks(4875) },
                    { "V3", 44, "Disponible", 27.071999999999999, -109.443, "Auto", new DateTime(2026, 5, 10, 3, 11, 52, 396, DateTimeKind.Unspecified).AddTicks(542) },
                    { "V4", 90, "Disponible", 27.07, -109.42, "Camion", new DateTime(2026, 5, 10, 3, 11, 52, 505, DateTimeKind.Unspecified).AddTicks(2411) },
                    { "V5", 67, "Disponible", 27.071999999999999, -109.443, "Auto", new DateTime(2026, 5, 10, 3, 11, 52, 545, DateTimeKind.Unspecified).AddTicks(4565) },
                    { "V6", 34, "Disponible", 27.07, -109.45999999999999, "Moto", new DateTime(2026, 5, 10, 3, 11, 52, 285, DateTimeKind.Unspecified).AddTicks(467) },
                    { "V7", 76, "Disponible", 27.079999999999998, -109.44499999999999, "Auto", new DateTime(2026, 5, 10, 3, 11, 52, 476, DateTimeKind.Unspecified).AddTicks(5969) },
                    { "V8", 30, "Disponible", 27.065000000000001, -109.43000000000001, "Moto", new DateTime(2026, 5, 10, 3, 11, 52, 674, DateTimeKind.Unspecified).AddTicks(4411) },
                    { "V9", 74, "Disponible", 27.071999999999999, -109.443, "Auto", new DateTime(2026, 5, 10, 3, 11, 52, 373, DateTimeKind.Unspecified).AddTicks(4271) }
                });

            migrationBuilder.InsertData(
                table: "HistorialViajes",
                columns: new[] { "Id", "CostoEstimado", "DestinoLocationId", "DistanciaKm", "Estado", "FinUtc", "InicioUtc", "OrigenLocationId", "VehiculoId" },
                values: new object[,]
                {
                    { "0bbd1448-9cc9-4983-b7d2-c4fcf92bde3d", null, "U1", null, "En Progreso", null, new DateTime(2026, 5, 10, 3, 5, 48, 363, DateTimeKind.Unspecified).AddTicks(7172), "prueba1-1777772764332", "V4" },
                    { "2066aa6e-773a-4adf-9afd-3009c04fca3b", null, "U1", null, "En Progreso", null, new DateTime(2026, 5, 10, 3, 7, 21, 533, DateTimeKind.Unspecified).AddTicks(576), "prueba1-1777772764332", "V2" },
                    { "2696e4f2-da8a-495b-bd5e-ebdfe315ad65", null, "U1", null, "Finalizado", new DateTime(2026, 5, 4, 1, 23, 23, 671, DateTimeKind.Unspecified).AddTicks(7054), new DateTime(2026, 5, 4, 1, 23, 17, 592, DateTimeKind.Unspecified).AddTicks(3235), "prueba1-1777772764332", "V3" },
                    { "310ed534-8715-48bf-8625-3d7bf61be55e", null, "U1", null, "Finalizado", new DateTime(2026, 5, 10, 3, 12, 10, 91, DateTimeKind.Unspecified).AddTicks(9828), new DateTime(2026, 5, 10, 3, 12, 4, 81, DateTimeKind.Unspecified).AddTicks(9988), "prueba1-1777772764332", "Scooter-001" },
                    { "41f3bb58-91b8-48f3-8ebf-a79ad705bee2", null, "U1", null, "Finalizado", new DateTime(2026, 5, 10, 3, 9, 30, 691, DateTimeKind.Unspecified).AddTicks(4298), new DateTime(2026, 5, 10, 3, 9, 24, 598, DateTimeKind.Unspecified).AddTicks(6266), "prueba1-1777772764332", "Scooter-001" },
                    { "44b42372-8330-4964-a3af-507ccedf5280", null, "U2", null, "En Progreso", null, new DateTime(2026, 5, 5, 5, 58, 54, 439, DateTimeKind.Unspecified).AddTicks(6903), "U1", "Scooter-001" },
                    { "4b668085-6371-45fd-9b50-431ae2d1946c", null, "U7", null, "En Progreso", null, new DateTime(2026, 5, 10, 3, 3, 41, 331, DateTimeKind.Unspecified).AddTicks(1119), "U6", "V4" },
                    { "611500d3-35f8-4459-87be-54b31f7680db", null, "U3", null, "Finalizado", new DateTime(2026, 5, 5, 5, 59, 56, 271, DateTimeKind.Unspecified).AddTicks(1448), new DateTime(2026, 5, 5, 5, 59, 50, 183, DateTimeKind.Unspecified).AddTicks(7917), "U1", "V1" },
                    { "663e9a61-b4a1-4735-85bb-09ef8307b400", null, "U1", null, "Finalizado", new DateTime(2026, 5, 10, 3, 10, 57, 755, DateTimeKind.Unspecified).AddTicks(1233), new DateTime(2026, 5, 10, 3, 10, 51, 703, DateTimeKind.Unspecified).AddTicks(7285), "prueba1-1777772764332", "Scooter-001" },
                    { "736db446-6e5f-4590-8915-9973cc423fac", null, "U1", null, "Finalizado", new DateTime(2026, 5, 5, 5, 55, 34, 500, DateTimeKind.Unspecified).AddTicks(4121), new DateTime(2026, 5, 5, 5, 55, 28, 397, DateTimeKind.Unspecified).AddTicks(9584), "prueba1-1777772764332", "V7" },
                    { "8d3adc00-ed9e-40d9-857b-7923ff70a595", null, "U1", null, "Finalizado", new DateTime(2026, 5, 10, 3, 8, 37, 242, DateTimeKind.Unspecified).AddTicks(2646), new DateTime(2026, 5, 10, 3, 8, 31, 208, DateTimeKind.Unspecified).AddTicks(8291), "prueba1-1777772764332", "Scooter-001" },
                    { "95a371e0-50be-4b7e-82ca-6eac04cba9e2", null, "U4", null, "En Progreso", null, new DateTime(2026, 5, 10, 3, 4, 5, 590, DateTimeKind.Unspecified).AddTicks(392), "U2", "V3" },
                    { "ababe30e-4aa3-4b94-ab40-e073aeb85ec3", null, "U1", null, "Finalizado", new DateTime(2026, 5, 3, 4, 55, 9, 598, DateTimeKind.Unspecified).AddTicks(6384), new DateTime(2026, 5, 3, 4, 55, 3, 489, DateTimeKind.Unspecified).AddTicks(3104), "prueba1-1777772764332", "V6" },
                    { "af97e9e8-5176-4349-ba2f-b7089ba7bb73", null, "U2", null, "Finalizado", new DateTime(2026, 5, 5, 21, 10, 41, 690, DateTimeKind.Unspecified).AddTicks(5434), new DateTime(2026, 5, 5, 21, 10, 35, 545, DateTimeKind.Unspecified).AddTicks(7587), "U1", "V10" },
                    { "bb8aad59-c8bd-46ca-a26e-72975825802a", null, "U1", null, "Finalizado", new DateTime(2026, 5, 3, 22, 58, 51, 78, DateTimeKind.Unspecified).AddTicks(7468), new DateTime(2026, 5, 3, 22, 58, 44, 995, DateTimeKind.Unspecified).AddTicks(4889), "prueba1-1777772764332", "V7" },
                    { "d2b81ec5-aac7-4d7e-a165-ceb734aa5e70", null, "U7", null, "Finalizado", new DateTime(2026, 5, 10, 3, 3, 4, 612, DateTimeKind.Unspecified).AddTicks(2358), new DateTime(2026, 5, 10, 3, 2, 58, 508, DateTimeKind.Unspecified).AddTicks(684), "U6", "V7" },
                    { "d5aba4b5-c5ea-416b-8a7a-e0825880242e", null, "U2", null, "Finalizado", new DateTime(2026, 5, 5, 7, 24, 36, 126, DateTimeKind.Unspecified).AddTicks(3108), new DateTime(2026, 5, 5, 7, 24, 30, 33, DateTimeKind.Unspecified).AddTicks(7935), "U1", "V1" },
                    { "e1cc2e31-abf4-46c2-8105-9002c4397e5d", null, "U1", null, "Finalizado", new DateTime(2026, 5, 10, 2, 58, 37, 745, DateTimeKind.Unspecified).AddTicks(4914), new DateTime(2026, 5, 10, 2, 58, 31, 695, DateTimeKind.Unspecified).AddTicks(1448), "prueba1-1777772764332", "V10" },
                    { "e364d369-2f88-478c-8111-1a9dc1b42632", null, "U5", null, "Finalizado", new DateTime(2026, 5, 10, 3, 2, 8, 939, DateTimeKind.Unspecified).AddTicks(746), new DateTime(2026, 5, 10, 3, 2, 2, 897, DateTimeKind.Unspecified).AddTicks(5135), "U3", "V6" }
                });

            migrationBuilder.InsertData(
                table: "RutasPredeterminadas",
                columns: new[] { "Id", "DestinoLocationId", "Nombre", "OrigenlocationId" },
                values: new object[] { "prueba-a-centro-1777773184083", "U1", "Prueba a Centro", "prueba1-1777772764332" });

            migrationBuilder.InsertData(
                table: "RutasPredeterminadas",
                columns: new[] { "Id", "DestinoLocationId", "NivelTraficoActual", "Nombre", "OrigenlocationId" },
                values: new object[,]
                {
                    { "R1", "U2", 1, "Centro a Norte", "U1" },
                    { "R10", "U7", 2, "Hospital a Universidad ALT", "U6" },
                    { "R2", "U2", 2, "Centro a Norte ALT", "U1" },
                    { "R3", "U3", 1, "Centro a Sur", "U1" },
                    { "R4", "U3", 2, "Centro a Sur ALT", "U1" },
                    { "R5", "U4", 1, "Norte a Este", "U2" },
                    { "R6", "U4", 2, "Norte a Este ALT", "U2" },
                    { "R7", "U5", 1, "Sur a Oeste", "U3" },
                    { "R8", "U5", 2, "Sur a Oeste ALT", "U3" },
                    { "R9", "U7", 1, "Hospital a Universidad", "U6" }
                });

            migrationBuilder.InsertData(
                table: "Coordenadas",
                columns: new[] { "Id", "Latitud", "Longitud", "Orden", "RutaPredeterminadaId" },
                values: new object[,]
                {
                    { 1, 27.071999999999999, -109.443, 1, "R1" },
                    { 2, 27.077999999999999, -109.446, 2, "R1" },
                    { 3, 27.085000000000001, -109.45, 3, "R1" },
                    { 4, 27.071999999999999, -109.443, 1, "R2" },
                    { 5, 27.074000000000002, -109.44, 2, "R2" },
                    { 6, 27.077999999999999, -109.44199999999999, 3, "R2" },
                    { 7, 27.082000000000001, -109.447, 4, "R2" },
                    { 8, 27.085000000000001, -109.45, 5, "R2" },
                    { 9, 27.071999999999999, -109.443, 1, "R3" },
                    { 10, 27.065999999999999, -109.441, 2, "R3" },
                    { 11, 27.059999999999999, -109.44, 3, "R3" },
                    { 12, 27.071999999999999, -109.443, 1, "R4" },
                    { 13, 27.07, -109.438, 2, "R4" },
                    { 14, 27.065000000000001, -109.437, 3, "R4" },
                    { 15, 27.062000000000001, -109.43899999999999, 4, "R4" },
                    { 16, 27.059999999999999, -109.44, 5, "R4" },
                    { 17, 27.085000000000001, -109.45, 1, "R5" },
                    { 18, 27.077999999999999, -109.435, 2, "R5" },
                    { 19, 27.07, -109.42, 3, "R5" },
                    { 20, 27.085000000000001, -109.45, 1, "R6" },
                    { 21, 27.082999999999998, -109.44499999999999, 2, "R6" },
                    { 22, 27.079999999999998, -109.44, 3, "R6" },
                    { 23, 27.074999999999999, -109.43000000000001, 4, "R6" },
                    { 24, 27.07, -109.42, 5, "R6" },
                    { 25, 27.059999999999999, -109.44, 1, "R7" },
                    { 26, 27.065000000000001, -109.45, 2, "R7" },
                    { 27, 27.07, -109.45999999999999, 3, "R7" },
                    { 28, 27.059999999999999, -109.44, 1, "R8" },
                    { 29, 27.062000000000001, -109.44499999999999, 2, "R8" },
                    { 30, 27.065000000000001, -109.44799999999999, 3, "R8" },
                    { 31, 27.068000000000001, -109.455, 4, "R8" },
                    { 32, 27.07, -109.45999999999999, 5, "R8" },
                    { 33, 27.074999999999999, -109.435, 1, "R9" },
                    { 34, 27.077999999999999, -109.44, 2, "R9" },
                    { 35, 27.079999999999998, -109.44499999999999, 3, "R9" },
                    { 36, 27.074999999999999, -109.435, 1, "R10" },
                    { 37, 27.076000000000001, -109.438, 2, "R10" },
                    { 38, 27.077999999999999, -109.44199999999999, 3, "R10" },
                    { 39, 27.079000000000001, -109.444, 4, "R10" },
                    { 40, 27.079999999999998, -109.44499999999999, 5, "R10" },
                    { 41, 27.100000000000001, -109.5, 1, "prueba-a-centro-1777773184083" },
                    { 42, 27.199999999999999, -109.59999999999999, 2, "prueba-a-centro-1777773184083" },
                    { 43, 27.071999999999999, -109.443, 3, "prueba-a-centro-1777773184083" }
                });

            migrationBuilder.InsertData(
                table: "Pagos",
                columns: new[] { "Id", "Estado", "FechaUtc", "HistorialViajeId", "Metodo", "Moneda", "Monto", "Referencia" },
                values: new object[,]
                {
                    { "pago-1777849190243-jgftk", "Completado", new DateTime(2026, 5, 3, 22, 59, 50, 269, DateTimeKind.Unspecified).AddTicks(5688), "bb8aad59-c8bd-46ca-a26e-72975825802a", "Efectivo", "MXN", 20.13m, null },
                    { "pago-1777857825020-v5edd", "Completado", new DateTime(2026, 5, 4, 1, 23, 45, 42, DateTimeKind.Unspecified).AddTicks(7677), "ababe30e-4aa3-4b94-ab40-e073aeb85ec3", "Efectivo", "MXN", 0.08m, null },
                    { "pago-1777960664627-u1v2g", "Completado", new DateTime(2026, 5, 5, 5, 57, 44, 655, DateTimeKind.Unspecified).AddTicks(7160), "2696e4f2-da8a-495b-bd5e-ebdfe315ad65", "Efectivo", "MXN", 100.00m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Coordenadas",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "0bbd1448-9cc9-4983-b7d2-c4fcf92bde3d");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "2066aa6e-773a-4adf-9afd-3009c04fca3b");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "310ed534-8715-48bf-8625-3d7bf61be55e");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "41f3bb58-91b8-48f3-8ebf-a79ad705bee2");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "44b42372-8330-4964-a3af-507ccedf5280");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "4b668085-6371-45fd-9b50-431ae2d1946c");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "611500d3-35f8-4459-87be-54b31f7680db");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "663e9a61-b4a1-4735-85bb-09ef8307b400");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "736db446-6e5f-4590-8915-9973cc423fac");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "8d3adc00-ed9e-40d9-857b-7923ff70a595");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "95a371e0-50be-4b7e-82ca-6eac04cba9e2");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "af97e9e8-5176-4349-ba2f-b7089ba7bb73");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "d2b81ec5-aac7-4d7e-a165-ceb734aa5e70");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "d5aba4b5-c5ea-416b-8a7a-e0825880242e");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "e1cc2e31-abf4-46c2-8105-9002c4397e5d");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "e364d369-2f88-478c-8111-1a9dc1b42632");

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: "pago-1777849190243-jgftk");

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: "pago-1777857825020-v5edd");

            migrationBuilder.DeleteData(
                table: "Pagos",
                keyColumn: "Id",
                keyValue: "pago-1777960664627-u1v2g");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "U10");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "U8");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "U9");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "Scooter-002");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "V5");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "V8");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "V9");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "2696e4f2-da8a-495b-bd5e-ebdfe315ad65");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "ababe30e-4aa3-4b94-ab40-e073aeb85ec3");

            migrationBuilder.DeleteData(
                table: "HistorialViajes",
                keyColumn: "Id",
                keyValue: "bb8aad59-c8bd-46ca-a26e-72975825802a");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "prueba-a-centro-1777773184083");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "R1");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "R10");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "R2");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "R3");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "R4");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "R5");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "R6");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "R7");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "R8");

            migrationBuilder.DeleteData(
                table: "RutasPredeterminadas",
                keyColumn: "Id",
                keyValue: "R9");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "Scooter-001");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "V1");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "V10");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "V2");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "V4");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "prueba1-1777772764332");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "U1");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "U2");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "U3");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "U4");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "U5");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "U6");

            migrationBuilder.DeleteData(
                table: "Ubicaciones",
                keyColumn: "Id",
                keyValue: "U7");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "V3");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "V6");

            migrationBuilder.DeleteData(
                table: "Vehiculos",
                keyColumn: "Id",
                keyValue: "V7");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaActualizacion",
                table: "Vehiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 12, 6, 45, 37, 736, DateTimeKind.Utc).AddTicks(1502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 12, 7, 19, 42, 46, DateTimeKind.Utc).AddTicks(3416));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InicioUtc",
                table: "HistorialViajes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 12, 6, 45, 37, 736, DateTimeKind.Utc).AddTicks(8399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 12, 7, 19, 42, 47, DateTimeKind.Utc).AddTicks(1540));
        }
    }
}
