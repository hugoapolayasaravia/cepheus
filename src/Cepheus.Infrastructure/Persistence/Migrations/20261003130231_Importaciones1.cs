using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Importaciones1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImportacionCode",
                schema: "logistica",
                table: "NotaIngresos",
                type: "char(6)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Importaciones",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    PesoNeto = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    PesoBruto = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    FechaPoliza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoCambio = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    TotalFob = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    TotalFlete = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    TotalSeguro = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    TotalAduana = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    Advalorem = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    Sobretasa = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    Igv = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    OtrosGastos = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Importaciones", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_Importaciones_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImportacionDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    ImportacionCode = table.Column<string>(type: "char(6)", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    ComprobantePagoCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoCambio = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    Cantidad = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    ValorFob = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    Flete = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    Seguro = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    ValorAduana = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    PorcentajeDet = table.Column<decimal>(type: "decimal(18,10)", nullable: false, defaultValue: 0m),
                    ValorDet = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    AdvaloremDet = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    SobretasaDet = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    IgvDet = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    OtrosGastosDet = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportacionDetalles", x => new { x.PlantaCode, x.ImportacionCode, x.ProveedorCode, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_ImportacionDetalles_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportacionDetalles_ComprobantesPago_ComprobantePagoCode",
                        column: x => x.ComprobantePagoCode,
                        principalSchema: "comun",
                        principalTable: "ComprobantesPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportacionDetalles_Importaciones_PlantaCode_ImportacionCode",
                        columns: x => new { x.PlantaCode, x.ImportacionCode },
                        principalSchema: "logistica",
                        principalTable: "Importaciones",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportacionDetalles_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImportacionGastos",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    ImportacionCode = table.Column<string>(type: "char(6)", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ComprobantePagoCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    Afecto = table.Column<bool>(type: "bit", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoCambio = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    NetoGasto = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    NetoGastoInafecto = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    Igv = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    IgvExterior = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    Total = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportacionGastos", x => new { x.PlantaCode, x.ImportacionCode, x.ProveedorCode, x.NumeroDocumento });
                    table.ForeignKey(
                        name: "FK_ImportacionGastos_ComprobantesPago_ComprobantePagoCode",
                        column: x => x.ComprobantePagoCode,
                        principalSchema: "comun",
                        principalTable: "ComprobantesPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportacionGastos_Importaciones_PlantaCode_ImportacionCode",
                        columns: x => new { x.PlantaCode, x.ImportacionCode },
                        principalSchema: "logistica",
                        principalTable: "Importaciones",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImportacionGastos_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportacionGastos_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImportacionGastoArticulos",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    ImportacionCode = table.Column<string>(type: "char(6)", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    ValorGasto = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    IgvGasto = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m),
                    IgvExtGasto = table.Column<decimal>(type: "decimal(12,4)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportacionGastoArticulos", x => new { x.PlantaCode, x.ImportacionCode, x.ProveedorCode, x.NumeroDocumento, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_ImportacionGastoArticulos_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportacionGastoArticulos_ImportacionGastos_PlantaCode_ImportacionCode_ProveedorCode_NumeroDocumento",
                        columns: x => new { x.PlantaCode, x.ImportacionCode, x.ProveedorCode, x.NumeroDocumento },
                        principalSchema: "logistica",
                        principalTable: "ImportacionGastos",
                        principalColumns: new[] { "PlantaCode", "ImportacionCode", "ProveedorCode", "NumeroDocumento" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresos_PlantaCode_ImportacionCode",
                schema: "logistica",
                table: "NotaIngresos",
                columns: new[] { "PlantaCode", "ImportacionCode" });

            migrationBuilder.CreateIndex(
                name: "IX_ImportacionDetalles_ArticuloCode",
                schema: "logistica",
                table: "ImportacionDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_ImportacionDetalles_ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionDetalles",
                column: "ComprobantePagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_ImportacionDetalles_PlantaCode_ImportacionCode_Estado",
                schema: "logistica",
                table: "ImportacionDetalles",
                columns: new[] { "PlantaCode", "ImportacionCode", "Estado" });

            migrationBuilder.CreateIndex(
                name: "IX_ImportacionDetalles_ProveedorCode",
                schema: "logistica",
                table: "ImportacionDetalles",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Importaciones_PlantaCode_CreatedAt",
                schema: "logistica",
                table: "Importaciones",
                columns: new[] { "PlantaCode", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_Importaciones_PlantaCode_Estado",
                schema: "logistica",
                table: "Importaciones",
                columns: new[] { "PlantaCode", "Estado" });

            migrationBuilder.CreateIndex(
                name: "IX_ImportacionGastoArticulos_ArticuloCode",
                schema: "logistica",
                table: "ImportacionGastoArticulos",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_ImportacionGastos_ComprobantePagoCode",
                schema: "logistica",
                table: "ImportacionGastos",
                column: "ComprobantePagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_ImportacionGastos_MonedaCode",
                schema: "logistica",
                table: "ImportacionGastos",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_ImportacionGastos_ProveedorCode",
                schema: "logistica",
                table: "ImportacionGastos",
                column: "ProveedorCode");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaIngresos_Importaciones_PlantaCode_ImportacionCode",
                schema: "logistica",
                table: "NotaIngresos",
                columns: new[] { "PlantaCode", "ImportacionCode" },
                principalSchema: "logistica",
                principalTable: "Importaciones",
                principalColumns: new[] { "PlantaCode", "Code" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaIngresos_Importaciones_PlantaCode_ImportacionCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.DropTable(
                name: "ImportacionDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ImportacionGastoArticulos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ImportacionGastos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Importaciones",
                schema: "logistica");

            migrationBuilder.DropIndex(
                name: "IX_NotaIngresos_PlantaCode_ImportacionCode",
                schema: "logistica",
                table: "NotaIngresos");

            migrationBuilder.DropColumn(
                name: "ImportacionCode",
                schema: "logistica",
                table: "NotaIngresos");
        }
    }
}
