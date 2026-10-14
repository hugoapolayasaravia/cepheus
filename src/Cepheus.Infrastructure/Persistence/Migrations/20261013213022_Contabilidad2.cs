using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Contabilidad2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoAnexoCode",
                schema: "contabilidad",
                table: "CuentasContables",
                type: "char(3)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoAnexoCode",
                schema: "contabilidad",
                table: "CuentasContables",
                type: "char(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(3)",
                oldNullable: true);
        }
    }
}
