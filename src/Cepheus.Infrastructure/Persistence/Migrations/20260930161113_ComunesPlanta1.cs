using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ComunesPlanta1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuiaNum",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000");

            migrationBuilder.AddColumn<string>(
                name: "NumeroBve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000");

            migrationBuilder.AddColumn<string>(
                name: "NumeroCve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000");

            migrationBuilder.AddColumn<string>(
                name: "NumeroDve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000");

            migrationBuilder.AddColumn<string>(
                name: "NumeroFve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000");

            migrationBuilder.AddColumn<string>(
                name: "NumeroGve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000");

            migrationBuilder.AddColumn<string>(
                name: "NumeroLet",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000");

            migrationBuilder.AddColumn<string>(
                name: "NumeroRet",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuiaNum",
                schema: "comun",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "NumeroBve",
                schema: "comun",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "NumeroCve",
                schema: "comun",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "NumeroDve",
                schema: "comun",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "NumeroFve",
                schema: "comun",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "NumeroGve",
                schema: "comun",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "NumeroLet",
                schema: "comun",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "NumeroRet",
                schema: "comun",
                table: "Plantas");
        }
    }
}
