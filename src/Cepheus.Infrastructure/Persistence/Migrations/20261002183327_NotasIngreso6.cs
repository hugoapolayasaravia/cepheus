using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NotasIngreso6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsVenta",
                schema: "logistica",
                table: "MotivosDevolucionArticulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsVenta",
                schema: "logistica",
                table: "MotivosDevolucionArticulo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
