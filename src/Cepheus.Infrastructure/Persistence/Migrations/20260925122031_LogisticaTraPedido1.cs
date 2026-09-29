using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LogisticaTraPedido1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    CodPlanta = table.Column<string>(type: "char(2)", nullable: false),
                    TipoPedidoCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    TipoValeCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    TramiteCode = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    SubCentroCostoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    OrdenTrabajoCode = table.Column<string>(type: "char(6)", nullable: true),
                    UnidadNegocioCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false, defaultValue: "000000"),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NetoPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    IgvPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    AprobadoPor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompradoPor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_Pedidos_OrdenesTrabajo_PlantaCode_OrdenTrabajoCode",
                        columns: x => new { x.PlantaCode, x.OrdenTrabajoCode },
                        principalSchema: "mantenimiento",
                        principalTable: "OrdenesTrabajo",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_SubCentrosCosto_SubCentroCostoCode",
                        column: x => x.SubCentroCostoCode,
                        principalSchema: "logistica",
                        principalTable: "SubCentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_TiposPedido_TipoPedidoCode",
                        column: x => x.TipoPedidoCode,
                        principalSchema: "logistica",
                        principalTable: "TiposPedido",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_TiposVale_TipoValeCode",
                        column: x => x.TipoValeCode,
                        principalSchema: "logistica",
                        principalTable: "TiposVale",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Tramites_TramiteCode",
                        column: x => x.TramiteCode,
                        principalSchema: "logistica",
                        principalTable: "Tramites",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_UnidadesNegocio_UnidadNegocioCode",
                        column: x => x.UnidadNegocioCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesNegocio",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    PedidoCode = table.Column<string>(type: "char(6)", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    ArticuloCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    DescripcionArticulo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UnidadMedidaCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false, defaultValue: "UN"),
                    PrecioArticulo = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    CantidadArticulo = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    TotalArticulo = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    OrdenCompraCode = table.Column<string>(type: "char(6)", nullable: true),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalles", x => new { x.PlantaCode, x.PedidoCode, x.ItemNumber });
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Pedidos_PlantaCode_PedidoCode",
                        columns: x => new { x.PlantaCode, x.PedidoCode },
                        principalSchema: "logistica",
                        principalTable: "Pedidos",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoDetalles_UnidadesMedida_UnidadMedidaCode",
                        column: x => x.UnidadMedidaCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesMedida",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_ProveedorCode",
                schema: "logistica",
                table: "PedidoDetalles",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalles_UnidadMedidaCode",
                schema: "logistica",
                table: "PedidoDetalles",
                column: "UnidadMedidaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_PlantaCode_OrdenTrabajoCode",
                schema: "logistica",
                table: "Pedidos",
                columns: new[] { "PlantaCode", "OrdenTrabajoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_SubCentroCostoCode",
                schema: "logistica",
                table: "Pedidos",
                column: "SubCentroCostoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TipoPedidoCode",
                schema: "logistica",
                table: "Pedidos",
                column: "TipoPedidoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TipoValeCode",
                schema: "logistica",
                table: "Pedidos",
                column: "TipoValeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TrabajadorCode",
                schema: "logistica",
                table: "Pedidos",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_TramiteCode",
                schema: "logistica",
                table: "Pedidos",
                column: "TramiteCode");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UnidadNegocioCode",
                schema: "logistica",
                table: "Pedidos",
                column: "UnidadNegocioCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Pedidos",
                schema: "logistica");
        }
    }
}
