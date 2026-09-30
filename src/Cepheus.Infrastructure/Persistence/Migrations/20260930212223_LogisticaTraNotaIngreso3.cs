using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LogisticaTraNotaIngreso3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_MotivosDevolucion_Code",
                schema: "comun",
                table: "MotivosDevolucion",
                column: "Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ComprobantesPago_Code",
                schema: "comun",
                table: "ComprobantesPago",
                column: "Code");

            migrationBuilder.CreateTable(
                name: "NotaIngresos",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    Condicion = table.Column<int>(type: "int", nullable: false),
                    OrdenCompraCode = table.Column<string>(type: "char(6)", nullable: true),
                    TipoDocumentoCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MotivoDevolucionCode = table.Column<string>(type: "char(2)", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumeroGuia = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NumeroReferencia = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Origen = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoReferenciaCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormaPagoCode = table.Column<string>(type: "char(2)", nullable: false),
                    TipoCambio = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Igv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoGravable = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Renta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fonavi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Servicio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IgvExterior = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AsientoContable = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CodigoVale = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    FechaDocumento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaIngresos", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_NotaIngresos_ComprobantesPago_TipoDocumentoCode",
                        column: x => x.TipoDocumentoCode,
                        principalSchema: "comun",
                        principalTable: "ComprobantesPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaIngresos_ComprobantesPago_TipoDocumentoReferenciaCode",
                        column: x => x.TipoDocumentoReferenciaCode,
                        principalSchema: "comun",
                        principalTable: "ComprobantesPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaIngresos_FormasPago_FormaPagoCode",
                        column: x => x.FormaPagoCode,
                        principalSchema: "logistica",
                        principalTable: "FormasPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaIngresos_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotaIngresos_MotivosDevolucion_MotivoDevolucionCode",
                        column: x => x.MotivoDevolucionCode,
                        principalSchema: "comun",
                        principalTable: "MotivosDevolucion",
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    NotaIngresoCode = table.Column<string>(type: "char(6)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    PedidoCode = table.Column<string>(type: "char(6)", nullable: true),
                    GuiaCode = table.Column<string>(type: "char(6)", nullable: true),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(12,6)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaIngresoDetalles", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_NotaIngresoDetalles_Pedidos_PlantaCode_PedidoCode",
                        columns: x => new { x.PlantaCode, x.PedidoCode },
                        principalSchema: "logistica",
                        principalTable: "Pedidos",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresoDetalles_ArticuloCode",
                schema: "logistica",
                table: "NotaIngresoDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresoDetalles_PlantaCode_NotaIngresoCode_ArticuloCode_PedidoCode_GuiaCode",
                schema: "logistica",
                table: "NotaIngresoDetalles",
                columns: new[] { "PlantaCode", "NotaIngresoCode", "ArticuloCode", "PedidoCode", "GuiaCode" });

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresoDetalles_PlantaCode_NotaIngresoCode_ItemNumber",
                schema: "logistica",
                table: "NotaIngresoDetalles",
                columns: new[] { "PlantaCode", "NotaIngresoCode", "ItemNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresoDetalles_PlantaCode_PedidoCode",
                schema: "logistica",
                table: "NotaIngresoDetalles",
                columns: new[] { "PlantaCode", "PedidoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresos_FormaPagoCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "FormaPagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresos_MonedaCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresos_MotivoDevolucionCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "MotivoDevolucionCode");

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

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresos_TipoDocumentoCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "TipoDocumentoCode");

            migrationBuilder.CreateIndex(
                name: "IX_NotaIngresos_TipoDocumentoReferenciaCode",
                schema: "logistica",
                table: "NotaIngresos",
                column: "TipoDocumentoReferenciaCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaIngresoDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "NotaIngresos",
                schema: "logistica");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_MotivosDevolucion_Code",
                schema: "comun",
                table: "MotivosDevolucion");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ComprobantesPago_Code",
                schema: "comun",
                table: "ComprobantesPago");
        }
    }
}
