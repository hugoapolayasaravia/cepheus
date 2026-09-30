using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EliminarMiEntidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaIngresoDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "NotaIngresos",
                schema: "logistica");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotaIngresos",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    OrdenCompraCode = table.Column<string>(type: "char(6)", nullable: true),
                    AsientoContable = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CodigoVale = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Condicion = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaDocumento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fonavi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FormaPagoCode = table.Column<string>(type: "char(2)", nullable: false),
                    Igv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IgvExterior = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MotivoDevolucionCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NoGravable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumeroGuia = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumeroReferencia = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Origen = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Renta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Servicio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoCambio = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    TipoDocumentoCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    TipoDocumentoReferenciaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaIngresos", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_NotaIngresos_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaIngresos_OrdenesCompra_PlantaCode_OrdenCompraCode",
                        columns: x => new { x.PlantaCode, x.OrdenCompraCode },
                        principalSchema: "logistica",
                        principalTable: "OrdenesCompra",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaIngresos_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaIngresos_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotaIngresoDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    NotaIngresoCode = table.Column<string>(type: "char(6)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    PedidoCode = table.Column<string>(type: "char(6)", nullable: false, defaultValue: ""),
                    GuiaCode = table.Column<string>(type: "char(6)", nullable: false, defaultValue: "000000"),
                    Cantidad = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(12,6)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaIngresoDetalles", x => new { x.PlantaCode, x.NotaIngresoCode, x.ArticuloCode, x.PedidoCode, x.GuiaCode });
                    table.ForeignKey(
                        name: "FK_NotaIngresoDetalles_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaIngresoDetalles_NotaIngresos_PlantaCode_NotaIngresoCode",
                        columns: x => new { x.PlantaCode, x.NotaIngresoCode },
                        principalSchema: "logistica",
                        principalTable: "NotaIngresos",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresoDetalles_ArticuloCode",
                schema: "logistica",
                table: "NotaIngresoDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresos_MonedaCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresos_PlantaCode_OrdenCompraCode",
                schema: "logistica",
                table: "NotaIngresos",
                columns: new[] { "PlantaCode", "OrdenCompraCode" });

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresos_ProveedorCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "ProveedorCode");
        }
    }
}
