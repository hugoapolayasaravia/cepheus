using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambioFAC2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonTypeTemp",
                schema: "facturacion",
                table: "Clientes",
                type: "char(1)",
                nullable: true);

            migrationBuilder.Sql("""
        UPDATE [facturacion].[Clientes]
        SET [PersonTypeTemp] =
            CASE [PersonType]
                WHEN 0 THEN 'E'
                WHEN 1 THEN 'N'
                ELSE 'N'
            END;
        """);

            migrationBuilder.DropColumn(
                name: "PersonType",
                schema: "facturacion",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "PersonTypeTemp",
                schema: "facturacion",
                table: "Clientes",
                newName: "PersonType");

            migrationBuilder.AlterColumn<string>(
                name: "PersonType",
                schema: "facturacion",
                table: "Clientes",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonTypeTemp",
                schema: "facturacion",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.Sql("""
        UPDATE [facturacion].[Clientes]
        SET [PersonTypeTemp] =
            CASE [PersonType]
                WHEN 'E' THEN 0
                WHEN 'N' THEN 1
                ELSE 0
            END;
        """);

            migrationBuilder.DropColumn(
                name: "PersonType",
                schema: "facturacion",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "PersonTypeTemp",
                schema: "facturacion",
                table: "Clientes",
                newName: "PersonType");

            migrationBuilder.AlterColumn<int>(
                name: "PersonType",
                schema: "facturacion",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
