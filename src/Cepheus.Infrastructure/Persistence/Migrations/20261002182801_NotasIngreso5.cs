using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NotasIngreso5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaIngresos_MotivosDevolucion_MotivoDevolucionCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.CreateTable(
                name: "MotivosDevolucionArticulo",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    AffectsStock = table.Column<bool>(type: "bit", nullable: false),
                    EsVenta = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosDevolucionArticulo", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotivosDevolucionArticulo_Code",
                schema: "logistica",
                table: "MotivosDevolucionArticulo",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaIngresos_MotivosDevolucionArticulo_MotivoDevolucionCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "MotivoDevolucionCode",
                principalSchema: "logistica",
                principalTable: "MotivosDevolucionArticulo",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaIngresos_MotivosDevolucionArticulo_MotivoDevolucionCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.DropTable(
                name: "MotivosDevolucionArticulo",
                schema: "logistica");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaIngresos_MotivosDevolucion_MotivoDevolucionCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "MotivoDevolucionCode",
                principalSchema: "comun",
                principalTable: "MotivosDevolucion",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
