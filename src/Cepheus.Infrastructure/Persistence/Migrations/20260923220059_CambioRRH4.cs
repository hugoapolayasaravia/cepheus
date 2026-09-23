using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambioRRH4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trabajador_laboral_TiposPersonal_TipoPersonalCode",
                schema: "rrhh",
                table: "trabajador_laboral");

            migrationBuilder.DropTable(
                name: "TiposPersonal",
                schema: "rrhh");

            migrationBuilder.DropIndex(
                name: "IX_trabajador_laboral_TipoPersonalCode",
                schema: "rrhh",
                table: "trabajador_laboral");

            migrationBuilder.DropColumn(
                name: "TipoPersonalCode",
                schema: "rrhh",
                table: "trabajador_laboral");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipoPersonalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                type: "char(3)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TiposPersonal",
                schema: "rrhh",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPersonal", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_TipoPersonalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "TipoPersonalCode");

            migrationBuilder.AddForeignKey(
                name: "FK_trabajador_laboral_TiposPersonal_TipoPersonalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "TipoPersonalCode",
                principalSchema: "rrhh",
                principalTable: "TiposPersonal",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
