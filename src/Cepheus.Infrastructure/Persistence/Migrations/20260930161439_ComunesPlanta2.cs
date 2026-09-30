using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ComunesPlanta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumeroRet",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldDefaultValue: "000-00000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroLet",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldDefaultValue: "000-00000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroGve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldDefaultValue: "000-00000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroFve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldDefaultValue: "000-00000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldDefaultValue: "000-00000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldDefaultValue: "000-00000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroBve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldDefaultValue: "000-00000");

            migrationBuilder.AlterColumn<string>(
                name: "GuiaNum",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "000-000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9,
                oldDefaultValue: "000-00000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumeroRet",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroLet",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroGve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroFve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroDve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroCve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroBve",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");

            migrationBuilder.AlterColumn<string>(
                name: "GuiaNum",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "000-00000",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValue: "000-000000");
        }
    }
}
