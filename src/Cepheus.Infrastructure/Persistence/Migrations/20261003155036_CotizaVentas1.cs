using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CotizaVentas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAnchorage",
                schema: "facturacion",
                table: "CotizacionesMetradoDetalle");

            migrationBuilder.AddColumn<int>(
                name: "Anchorage",
                schema: "facturacion",
                table: "CotizacionesMetradoDetalle",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anchorage",
                schema: "facturacion",
                table: "CotizacionesMetradoDetalle");

            migrationBuilder.AddColumn<bool>(
                name: "HasAnchorage",
                schema: "facturacion",
                table: "CotizacionesMetradoDetalle",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }
    }
}
