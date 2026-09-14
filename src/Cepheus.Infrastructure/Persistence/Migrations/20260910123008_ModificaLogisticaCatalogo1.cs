using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModificaLogisticaCatalogo1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ubigeos",
                schema: "comun",
                table: "Ubigeos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Monedas",
                schema: "comun",
                table: "Monedas");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "comun",
                table: "Ubigeos");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "comun",
                table: "Monedas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ubigeos",
                schema: "comun",
                table: "Ubigeos",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Monedas",
                schema: "comun",
                table: "Monedas",
                column: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ubigeos",
                schema: "comun",
                table: "Ubigeos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Monedas",
                schema: "comun",
                table: "Monedas");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "comun",
                table: "Ubigeos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "comun",
                table: "Monedas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ubigeos",
                schema: "comun",
                table: "Ubigeos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Monedas",
                schema: "comun",
                table: "Monedas",
                column: "Id");
        }
    }
}
