using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PasswordReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCostUsd",
                schema: "logistica",
                table: "StockArticulos",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCost",
                schema: "logistica",
                table: "StockArticulos",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageCost",
                schema: "logistica",
                table: "StockArticulos",
                type: "decimal(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CierreIncidencias",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    PeriodCode = table.Column<string>(type: "char(6)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    DocumentoCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mensaje = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CierreIncidencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CierreIncidencias_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CierreIncidencias_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CierreRevaluaciones",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    PeriodCode = table.Column<string>(type: "char(6)", nullable: false),
                    Origen = table.Column<int>(type: "int", nullable: false),
                    DocumentoCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: true),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    PrecioAnterior = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    PrecioNuevo = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    TotalAnterior = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalNuevo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CierreRevaluaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosArticulo",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "date", nullable: false),
                    PeriodCode = table.Column<string>(type: "char(6)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Origen = table.Column<int>(type: "int", nullable: false),
                    DocumentoCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CostoUnitario = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CostoUnitarioUsd = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    StockPosterior = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CostoPromedioPosterior = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    EsReversion = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ReversaDeMovimientoId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosArticulo", x => x.Id);
                    table.CheckConstraint("CK_MovimientosArticulo_Cantidad_Positiva", "[Cantidad] > 0");
                    table.CheckConstraint("CK_MovimientosArticulo_Tipo", "[Tipo] IN (1, 2)");
                    table.ForeignKey(
                        name: "FK_MovimientosArticulo_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosArticulo_MovimientosArticulo_ReversaDeMovimientoId",
                        column: x => x.ReversaDeMovimientoId,
                        principalSchema: "logistica",
                        principalTable: "MovimientosArticulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosArticulo_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                schema: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TokenHash = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "admin",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsablesObra",
                schema: "facturacion",
                columns: table => new
                {
                    ClienteCode = table.Column<string>(type: "char(5)", nullable: false),
                    ObraCode = table.Column<string>(type: "char(3)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsablesObra", x => new { x.ClienteCode, x.ObraCode, x.Code });
                    table.ForeignKey(
                        name: "FK_ResponsablesObra_Obras_ClienteCode_ObraCode",
                        columns: x => new { x.ClienteCode, x.ObraCode },
                        principalSchema: "facturacion",
                        principalTable: "Obras",
                        principalColumns: new[] { "ClienteCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaldosMensualesArticulo",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    PeriodCode = table.Column<string>(type: "char(6)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    AverageCost = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    IncomingQuantity = table.Column<decimal>(type: "decimal(14,2)", nullable: false, defaultValue: 0m),
                    OutgoingQuantity = table.Column<decimal>(type: "decimal(14,2)", nullable: false, defaultValue: 0m),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "ROUND([Quantity] * [AverageCost], 2)", stored: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaldosMensualesArticulo", x => new { x.PlantaCode, x.PeriodCode, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_SaldosMensualesArticulo_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaldosMensualesArticulo_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CierreIncidencias_ArticuloCode",
                schema: "logistica",
                table: "CierreIncidencias",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_CierreIncidencias_Periodo",
                schema: "logistica",
                table: "CierreIncidencias",
                columns: new[] { "PlantaCode", "PeriodCode", "Tipo" });

            migrationBuilder.CreateIndex(
                name: "IX_CierreRevaluaciones_Periodo",
                schema: "logistica",
                table: "CierreRevaluaciones",
                columns: new[] { "PlantaCode", "PeriodCode" });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosArticulo_ArticuloCode",
                schema: "logistica",
                table: "MovimientosArticulo",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosArticulo_Documento",
                schema: "logistica",
                table: "MovimientosArticulo",
                columns: new[] { "PlantaCode", "Origen", "DocumentoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosArticulo_Kardex",
                schema: "logistica",
                table: "MovimientosArticulo",
                columns: new[] { "PlantaCode", "ArticuloCode", "FechaMovimiento", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosArticulo_Periodo",
                schema: "logistica",
                table: "MovimientosArticulo",
                columns: new[] { "PlantaCode", "PeriodCode", "ArticuloCode", "FechaMovimiento", "Id" });

            migrationBuilder.CreateIndex(
                name: "UX_MovimientosArticulo_Reversa",
                schema: "logistica",
                table: "MovimientosArticulo",
                column: "ReversaDeMovimientoId",
                unique: true,
                filter: "[ReversaDeMovimientoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_TokenHash",
                schema: "admin",
                table: "PasswordResetTokens",
                column: "TokenHash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_UserId",
                schema: "admin",
                table: "PasswordResetTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SaldosMensualesArticulo_Articulo",
                schema: "logistica",
                table: "SaldosMensualesArticulo",
                columns: new[] { "PlantaCode", "ArticuloCode", "PeriodCode" });

            migrationBuilder.CreateIndex(
                name: "IX_SaldosMensualesArticulo_ArticuloCode",
                schema: "logistica",
                table: "SaldosMensualesArticulo",
                column: "ArticuloCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CierreIncidencias",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "CierreRevaluaciones",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "MovimientosArticulo",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "PasswordResetTokens",
                schema: "admin");

            migrationBuilder.DropTable(
                name: "ResponsablesObra",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "SaldosMensualesArticulo",
                schema: "logistica");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCostUsd",
                schema: "logistica",
                table: "StockArticulos",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitCost",
                schema: "logistica",
                table: "StockArticulos",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "AverageCost",
                schema: "logistica",
                table: "StockArticulos",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldNullable: true);
        }
    }
}
