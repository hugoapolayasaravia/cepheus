using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Contabilidad3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PilotFlag",
                schema: "contabilidad",
                table: "CuentasContables",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.AlterColumn<string>(
                name: "GainsLossesFlag",
                schema: "contabilidad",
                table: "CuentasContables",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.AlterColumn<string>(
                name: "AcmFlag",
                schema: "contabilidad",
                table: "CuentasContables",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PilotFlag",
                schema: "contabilidad",
                table: "CuentasContables",
                type: "char(1)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GainsLossesFlag",
                schema: "contabilidad",
                table: "CuentasContables",
                type: "char(1)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AcmFlag",
                schema: "contabilidad",
                table: "CuentasContables",
                type: "char(1)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);
        }
    }
}
