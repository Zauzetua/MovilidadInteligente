using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovilidadInteligente.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPagos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaActualizacion",
                table: "Vehiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 12, 6, 45, 37, 736, DateTimeKind.Utc).AddTicks(1502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 3, 0, 21, 46, 320, DateTimeKind.Utc).AddTicks(5202));

            migrationBuilder.CreateTable(
                name: "HistorialViajes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehiculoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrigenLocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DestinoLocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InicioUtc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2026, 5, 12, 6, 45, 37, 736, DateTimeKind.Utc).AddTicks(8399)),
                    FinUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DistanciaKm = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    CostoEstimado = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialViajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialViajes_Ubicaciones_DestinoLocationId",
                        column: x => x.DestinoLocationId,
                        principalTable: "Ubicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistorialViajes_Ubicaciones_OrigenLocationId",
                        column: x => x.OrigenLocationId,
                        principalTable: "Ubicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistorialViajes_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HistorialViajeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Moneda = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValue: "MXN"),
                    Metodo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaUtc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "sysutcdatetime()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_HistorialViajes",
                        column: x => x.HistorialViajeId,
                        principalTable: "HistorialViajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialViajes_DestinoLocationId",
                table: "HistorialViajes",
                column: "DestinoLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialViajes_OrigenLocationId",
                table: "HistorialViajes",
                column: "OrigenLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialViajes_VehiculoId",
                table: "HistorialViajes",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_HistorialViajeId",
                table: "Pagos",
                column: "HistorialViajeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "HistorialViajes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaActualizacion",
                table: "Vehiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 3, 0, 21, 46, 320, DateTimeKind.Utc).AddTicks(5202),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 12, 6, 45, 37, 736, DateTimeKind.Utc).AddTicks(1502));
        }
    }
}
