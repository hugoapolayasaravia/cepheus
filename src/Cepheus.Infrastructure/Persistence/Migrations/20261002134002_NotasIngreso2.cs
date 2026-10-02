using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NotasIngreso2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotaIngresoDetalles",
                schema: "logistica",
                table: "NotaIngresoDetalles");

            migrationBuilder.DropIndex(
                name: "IX_NotaIngresoDetalles_PlantaCode_NotaIngresoCode_ItemNumber",
                schema: "logistica",
                table: "NotaIngresoDetalles");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "logistica",
                table: "NotaIngresoDetalles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotaIngresoDetalles",
                schema: "logistica",
                table: "NotaIngresoDetalles",
                columns: new[] { "PlantaCode", "NotaIngresoCode", "ItemNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotaIngresoDetalles",
                schema: "logistica",
                table: "NotaIngresoDetalles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "logistica",
                table: "NotaIngresoDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotaIngresoDetalles",
                schema: "logistica",
                table: "NotaIngresoDetalles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresoDetalles_PlantaCode_NotaIngresoCode_ItemNumber",
                schema: "logistica",
                table: "NotaIngresoDetalles",
                columns: new[] { "PlantaCode", "NotaIngresoCode", "ItemNumber" });
        }
    }
}
