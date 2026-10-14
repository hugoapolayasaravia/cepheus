using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CAMBIOSLOGISTICA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UX_MovimientosArticulo_Reversa",
                schema: "logistica",
                table: "MovimientosArticulo");

            migrationBuilder.DropCheckConstraint(
                name: "CK_MovimientosArticulo_Cantidad_Positiva",
                schema: "logistica",
                table: "MovimientosArticulo");

            migrationBuilder.DropCheckConstraint(
                name: "CK_MovimientosArticulo_Tipo",
                schema: "logistica",
                table: "MovimientosArticulo");

            migrationBuilder.DropColumn(
                name: "Amount",
                schema: "logistica",
                table: "SaldosMensualesArticulo");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoVale",
                schema: "logistica",
                table: "NotaIngresos",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantaOrigenCode",
                schema: "logistica",
                table: "NotaIngresos",
                type: "char(2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValeTransferenciaCode",
                schema: "logistica",
                table: "NotaIngresos",
                type: "char(7)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CierreBloqueos",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    UltimoUso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CierreBloqueos", x => x.PlantaCode);
                });

            migrationBuilder.CreateTable(
                name: "PeriodosIgv",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: true),
                    PorcentajeIgv = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodosIgv", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresos_ValeTransferencia",
                schema: "logistica",
                table: "NotaIngresos",
                columns: new[] { "PlantaOrigenCode", "ValeTransferenciaCode" });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosArticulo_ReversaDeMovimientoId",
                schema: "logistica",
                table: "MovimientosArticulo",
                column: "ReversaDeMovimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodosIgv_FechaInicio",
                schema: "comun",
                table: "PeriodosIgv",
                column: "FechaInicio",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NotaIngresos_Vales_PlantaOrigenCode_ValeTransferenciaCode",
                schema: "logistica",
                table: "NotaIngresos",
                columns: new[] { "PlantaOrigenCode", "ValeTransferenciaCode" },
                principalSchema: "logistica",
                principalTable: "Vales",
                principalColumns: new[] { "PlantaCode", "Code" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaIngresos_Vales_PlantaOrigenCode_ValeTransferenciaCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.DropTable(
                name: "CierreBloqueos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "PeriodosIgv",
                schema: "comun");

            migrationBuilder.DropIndex(
                name: "IX_NotaIngresos_ValeTransferencia",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosArticulo_ReversaDeMovimientoId",
                schema: "logistica",
                table: "MovimientosArticulo");

            migrationBuilder.DropColumn(
                name: "PlantaOrigenCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.DropColumn(
                name: "ValeTransferenciaCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoVale",
                schema: "logistica",
                table: "NotaIngresos",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                schema: "logistica",
                table: "SaldosMensualesArticulo",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "ROUND([Quantity] * [AverageCost], 2)",
                stored: true);

            migrationBuilder.CreateIndex(
                name: "UX_MovimientosArticulo_Reversa",
                schema: "logistica",
                table: "MovimientosArticulo",
                column: "ReversaDeMovimientoId",
                unique: true,
                filter: "[ReversaDeMovimientoId] IS NOT NULL");

            migrationBuilder.AddCheckConstraint(
                name: "CK_MovimientosArticulo_Cantidad_Positiva",
                schema: "logistica",
                table: "MovimientosArticulo",
                sql: "[Cantidad] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_MovimientosArticulo_Tipo",
                schema: "logistica",
                table: "MovimientosArticulo",
                sql: "[Tipo] IN (1, 2)");
        }
    }
}
