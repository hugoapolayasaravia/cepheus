using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrdenServicio1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdenesServicio",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    ComprobantePagoCode = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    FormaPagoCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoCambio = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Igv = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    NoGravable = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Renta = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Fonavi = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Servicio = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    IgvExterior = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    AsientoContable = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    AprobadoPor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesadoPor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaProcesado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompradorCode = table.Column<string>(type: "char(3)", nullable: false),
                    LugarEnvioCode = table.Column<string>(type: "char(3)", nullable: false),
                    TramiteCode = table.Column<string>(type: "char(1)", nullable: false),
                    NotaCompraCode = table.Column<string>(type: "char(3)", nullable: true),
                    UnidadNegocioCode = table.Column<string>(type: "char(6)", nullable: false),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    Observaciones1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Observaciones2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesServicio", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_Compradores_CompradorCode",
                        column: x => x.CompradorCode,
                        principalSchema: "logistica",
                        principalTable: "Compradores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_ComprobantesPago_ComprobantePagoCode",
                        column: x => x.ComprobantePagoCode,
                        principalSchema: "comun",
                        principalTable: "ComprobantesPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_FormasPago_FormaPagoCode",
                        column: x => x.FormaPagoCode,
                        principalSchema: "logistica",
                        principalTable: "FormasPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_LugaresEnvio_LugarEnvioCode",
                        column: x => x.LugarEnvioCode,
                        principalSchema: "logistica",
                        principalTable: "LugaresEnvio",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_NotasCompra_NotaCompraCode",
                        column: x => x.NotaCompraCode,
                        principalSchema: "logistica",
                        principalTable: "NotasCompra",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_Tramites_TramiteCode",
                        column: x => x.TramiteCode,
                        principalSchema: "logistica",
                        principalTable: "Tramites",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicio_UnidadesNegocio_UnidadNegocioCode",
                        column: x => x.UnidadNegocioCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesNegocio",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenServicioDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    OrdenServicioCode = table.Column<string>(type: "char(6)", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    Glosa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    TipoValeCode = table.Column<string>(type: "char(3)", nullable: false),
                    SubCentroCostoCode = table.Column<string>(type: "char(6)", nullable: false),
                    SubCentroEjecutorCode = table.Column<string>(type: "char(4)", nullable: true),
                    OrdenTrabajoCode = table.Column<string>(type: "char(6)", nullable: true),
                    PlantaAfectadaCode = table.Column<string>(type: "char(2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenServicioDetalles", x => new { x.PlantaCode, x.OrdenServicioCode, x.ItemNumber });
                    table.ForeignKey(
                        name: "FK_OrdenServicioDetalles_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicioDetalles_OrdenesServicio_PlantaCode_OrdenServicioCode",
                        columns: x => new { x.PlantaCode, x.OrdenServicioCode },
                        principalSchema: "logistica",
                        principalTable: "OrdenesServicio",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenServicioDetalles_OrdenesTrabajo_PlantaCode_OrdenTrabajoCode",
                        columns: x => new { x.PlantaCode, x.OrdenTrabajoCode },
                        principalSchema: "mantenimiento",
                        principalTable: "OrdenesTrabajo",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicioDetalles_Plantas_PlantaAfectadaCode",
                        column: x => x.PlantaAfectadaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicioDetalles_SubCentrosCosto_SubCentroCostoCode",
                        column: x => x.SubCentroCostoCode,
                        principalSchema: "logistica",
                        principalTable: "SubCentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicioDetalles_SubCentrosEjecutores_SubCentroEjecutorCode",
                        column: x => x.SubCentroEjecutorCode,
                        principalSchema: "mantenimiento",
                        principalTable: "SubCentrosEjecutores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicioDetalles_TiposVale_TipoValeCode",
                        column: x => x.TipoValeCode,
                        principalSchema: "logistica",
                        principalTable: "TiposVale",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_CompradorCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "CompradorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_ComprobantePagoCode_ProveedorCode_NumeroDocumento",
                schema: "logistica",
                table: "OrdenesServicio",
                columns: new[] { "ComprobantePagoCode", "ProveedorCode", "NumeroDocumento" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_FormaPagoCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "FormaPagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_LugarEnvioCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "LugarEnvioCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_MonedaCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_NotaCompraCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "NotaCompraCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_PlantaCode_FechaProceso",
                schema: "logistica",
                table: "OrdenesServicio",
                columns: new[] { "PlantaCode", "FechaProceso" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_ProveedorCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_TrabajadorCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_TramiteCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "TramiteCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_UnidadNegocioCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "UnidadNegocioCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioDetalles_ArticuloCode",
                schema: "logistica",
                table: "OrdenServicioDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioDetalles_PlantaAfectadaCode",
                schema: "logistica",
                table: "OrdenServicioDetalles",
                column: "PlantaAfectadaCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioDetalles_PlantaCode_OrdenTrabajoCode",
                schema: "logistica",
                table: "OrdenServicioDetalles",
                columns: new[] { "PlantaCode", "OrdenTrabajoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioDetalles_SubCentroCostoCode",
                schema: "logistica",
                table: "OrdenServicioDetalles",
                column: "SubCentroCostoCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioDetalles_SubCentroEjecutorCode",
                schema: "logistica",
                table: "OrdenServicioDetalles",
                column: "SubCentroEjecutorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioDetalles_TipoValeCode",
                schema: "logistica",
                table: "OrdenServicioDetalles",
                column: "TipoValeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenServicioDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "OrdenesServicio",
                schema: "logistica");
        }
    }
}
