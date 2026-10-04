using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrdenServicio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrdenesServicio_PlantaCode_FechaProceso",
                schema: "logistica",
                table: "OrdenesServicio");

            migrationBuilder.DropColumn(
                name: "FechaProceso",
                schema: "logistica",
                table: "OrdenesServicio");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_PlantaCode_CreatedAt",
                schema: "logistica",
                table: "OrdenesServicio",
                columns: new[] { "PlantaCode", "CreatedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrdenesServicio_PlantaCode_CreatedAt",
                schema: "logistica",
                table: "OrdenesServicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaProceso",
                schema: "logistica",
                table: "OrdenesServicio",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_PlantaCode_FechaProceso",
                schema: "logistica",
                table: "OrdenesServicio",
                columns: new[] { "PlantaCode", "FechaProceso" });
        }
    }
}
