using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambioRRH3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trabajador_seguro_TiposSeguroMedico_TipoSeguroMedicoCode",
                schema: "rrhh",
                table: "trabajador_seguro");

            migrationBuilder.DropTable(
                name: "TiposSeguroMedico",
                schema: "rrhh");

            migrationBuilder.DropIndex(
                name: "IX_trabajador_seguro_TipoSeguroMedicoCode",
                schema: "rrhh",
                table: "trabajador_seguro");

            migrationBuilder.DropColumn(
                name: "TipoSeguroMedicoCode",
                schema: "rrhh",
                table: "trabajador_seguro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoSeguroMedicoCode",
                schema: "rrhh",
                table: "trabajador_seguro",
                type: "char(3)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TiposSeguroMedico",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSeguroMedico", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_seguro_TipoSeguroMedicoCode",
                schema: "rrhh",
                table: "trabajador_seguro",
                column: "TipoSeguroMedicoCode");

            migrationBuilder.AddForeignKey(
                name: "FK_trabajador_seguro_TiposSeguroMedico_TipoSeguroMedicoCode",
                schema: "rrhh",
                table: "trabajador_seguro",
                column: "TipoSeguroMedicoCode",
                principalSchema: "rrhh",
                principalTable: "TiposSeguroMedico",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
