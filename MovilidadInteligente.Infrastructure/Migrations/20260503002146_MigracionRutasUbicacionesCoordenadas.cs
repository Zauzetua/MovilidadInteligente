using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovilidadInteligente.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionRutasUbicacionesCoordenadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaActualizacion",
                table: "Vehiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 5, 3, 0, 21, 46, 320, DateTimeKind.Utc).AddTicks(5202),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 4, 30, 5, 2, 11, 302, DateTimeKind.Utc).AddTicks(5792));

            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RutasPredeterminadas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OrigenlocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DestinoLocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NivelTraficoActual = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutasPredeterminadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RutasPredeterminadas_Ubicaciones_DestinoLocationId",
                        column: x => x.DestinoLocationId,
                        principalTable: "Ubicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RutasPredeterminadas_Ubicaciones_OrigenlocationId",
                        column: x => x.OrigenlocationId,
                        principalTable: "Ubicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coordenadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RutaPredeterminadaId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordenadas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordenadas_RutasPredeterminadas_RutaPredeterminadaId",
                        column: x => x.RutaPredeterminadaId,
                        principalTable: "RutasPredeterminadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coordenadas_RutaPredeterminadaId",
                table: "Coordenadas",
                column: "RutaPredeterminadaId");

            migrationBuilder.CreateIndex(
                name: "IX_RutasPredeterminadas_DestinoLocationId",
                table: "RutasPredeterminadas",
                column: "DestinoLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RutasPredeterminadas_OrigenlocationId",
                table: "RutasPredeterminadas",
                column: "OrigenlocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordenadas");

            migrationBuilder.DropTable(
                name: "RutasPredeterminadas");

            migrationBuilder.DropTable(
                name: "Ubicaciones");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaActualizacion",
                table: "Vehiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 5, 2, 11, 302, DateTimeKind.Utc).AddTicks(5792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 5, 3, 0, 21, 46, 320, DateTimeKind.Utc).AddTicks(5202));
        }
    }
}
