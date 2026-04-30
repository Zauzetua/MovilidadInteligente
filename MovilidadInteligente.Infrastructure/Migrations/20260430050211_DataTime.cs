using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovilidadInteligente.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaActualizacion",
                table: "Vehiculos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 4, 30, 5, 2, 11, 302, DateTimeKind.Utc).AddTicks(5792));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimaActualizacion",
                table: "Vehiculos");
        }
    }
}
