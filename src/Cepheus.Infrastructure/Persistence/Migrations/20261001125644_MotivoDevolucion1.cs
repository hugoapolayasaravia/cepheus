using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MotivoDevolucion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_MotivosDevolucion_Code",
                schema: "comun",
                table: "MotivosDevolucion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MotivosDevolucion",
                schema: "comun",
                table: "MotivosDevolucion");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "comun",
                table: "MotivosDevolucion");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "comun",
                table: "MotivosDevolucion",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "EsVenta",
                schema: "comun",
                table: "MotivosDevolucion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotivosDevolucion",
                schema: "comun",
                table: "MotivosDevolucion",
                column: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MotivosDevolucion",
                schema: "comun",
                table: "MotivosDevolucion");

            migrationBuilder.DropColumn(
                name: "EsVenta",
                schema: "comun",
                table: "MotivosDevolucion");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "comun",
                table: "MotivosDevolucion",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "comun",
                table: "MotivosDevolucion",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MotivosDevolucion_Code",
                schema: "comun",
                table: "MotivosDevolucion",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotivosDevolucion",
                schema: "comun",
                table: "MotivosDevolucion",
                column: "Id");
        }
    }
}
