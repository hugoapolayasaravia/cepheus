using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambioRRH1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trabajador_laboral_CategoriasOcupacionales_CategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral");

            migrationBuilder.DropForeignKey(
                name: "FK_trabajador_laboral_SubCategoriasOcupacionales_SubCategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral");

            migrationBuilder.DropTable(
                name: "CategoriasOcupacionales",
                schema: "rrhh");

            migrationBuilder.DropTable(
                name: "SubCategoriasOcupacionales",
                schema: "rrhh");

            migrationBuilder.DropIndex(
                name: "IX_trabajador_laboral_CategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral");

            migrationBuilder.DropIndex(
                name: "IX_trabajador_laboral_SubCategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral");

            migrationBuilder.DropColumn(
                name: "CategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral");

            migrationBuilder.DropColumn(
                name: "SubCategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                type: "char(3)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                type: "char(3)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriasOcupacionales",
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
                    table.PrimaryKey("PK_CategoriasOcupacionales", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoriasOcupacionales",
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
                    table.PrimaryKey("PK_SubCategoriasOcupacionales", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_CategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "CategoriaOcupacionalCode");

            migrationBuilder.CreateIndex(
                name: "IX_trabajador_laboral_SubCategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "SubCategoriaOcupacionalCode");

            migrationBuilder.AddForeignKey(
                name: "FK_trabajador_laboral_CategoriasOcupacionales_CategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "CategoriaOcupacionalCode",
                principalSchema: "rrhh",
                principalTable: "CategoriasOcupacionales",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_trabajador_laboral_SubCategoriasOcupacionales_SubCategoriaOcupacionalCode",
                schema: "rrhh",
                table: "trabajador_laboral",
                column: "SubCategoriaOcupacionalCode",
                principalSchema: "rrhh",
                principalTable: "SubCategoriasOcupacionales",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
