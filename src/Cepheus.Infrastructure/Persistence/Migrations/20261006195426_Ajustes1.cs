using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Ajustes1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AjustesInventario",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Neto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Igv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    AsientoContable = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjustesInventario", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_AjustesInventario_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AjusteInventarioDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    AjusteCode = table.Column<string>(type: "char(6)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    AsientoContable = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjusteInventarioDetalles", x => new { x.PlantaCode, x.AjusteCode, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_AjusteInventarioDetalles_AjustesInventario_PlantaCode_AjusteCode",
                        columns: x => new { x.PlantaCode, x.AjusteCode },
                        principalSchema: "logistica",
                        principalTable: "AjustesInventario",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AjusteInventarioDetalles_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AjusteInventarioDetalles_ArticuloCode",
                schema: "logistica",
                table: "AjusteInventarioDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_AjusteInventarioDetalles_PlantaCode_AjusteCode_ItemNumber",
                schema: "logistica",
                table: "AjusteInventarioDetalles",
                columns: new[] { "PlantaCode", "AjusteCode", "ItemNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_AjusteInventarioDetalles_PlantaCode_ArticuloCode_Estado_Tipo",
                schema: "logistica",
                table: "AjusteInventarioDetalles",
                columns: new[] { "PlantaCode", "ArticuloCode", "Estado", "Tipo" });

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventario_PlantaCode_CreatedAt",
                schema: "logistica",
                table: "AjustesInventario",
                columns: new[] { "PlantaCode", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventario_PlantaCode_Estado",
                schema: "logistica",
                table: "AjustesInventario",
                columns: new[] { "PlantaCode", "Estado" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AjusteInventarioDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "AjustesInventario",
                schema: "logistica");
        }
    }
}
