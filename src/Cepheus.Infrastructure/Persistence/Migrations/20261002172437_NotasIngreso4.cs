using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NotasIngreso4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MotivoDevolucionCode",
                schema: "logistica",
                table: "NotaIngresos",
                type: "char(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MotivoDevolucionCode",
                schema: "logistica",
                table: "NotaIngresos",
                type: "char(2)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(2)",
                oldMaxLength: 2,
                oldNullable: true);
        }
    }
}
