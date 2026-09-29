using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LogisticaTraCotiza1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CantidadCotizada",
                schema: "logistica",
                table: "PedidoDetalles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    OriginalCode = table.Column<string>(type: "char(6)", nullable: true),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Cotizaciones_PlantaCode_OriginalCode",
                        columns: x => new { x.PlantaCode, x.OriginalCode },
                        principalSchema: "logistica",
                        principalTable: "Cotizaciones",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    CotizacionCode = table.Column<string>(type: "char(6)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    CantidadArticulo = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionDetalles", x => new { x.PlantaCode, x.CotizacionCode, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_CotizacionDetalles_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CotizacionDetalles_Cotizaciones_PlantaCode_CotizacionCode",
                        columns: x => new { x.PlantaCode, x.CotizacionCode },
                        principalSchema: "logistica",
                        principalTable: "Cotizaciones",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionProveedores",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    CotizacionCode = table.Column<string>(type: "char(6)", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    NetoCotizacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    IgvCotizacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalCotizacion = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Observaciones = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionProveedores", x => new { x.PlantaCode, x.CotizacionCode, x.ProveedorCode });
                    table.ForeignKey(
                        name: "FK_CotizacionProveedores_Cotizaciones_PlantaCode_CotizacionCode",
                        columns: x => new { x.PlantaCode, x.CotizacionCode },
                        principalSchema: "logistica",
                        principalTable: "Cotizaciones",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CotizacionProveedores_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CotizacionProveedores_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionPedidoOrigenes",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    CotizacionCode = table.Column<string>(type: "char(6)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    PedidoCode = table.Column<string>(type: "char(6)", nullable: false),
                    PedidoItemNumber = table.Column<int>(type: "int", nullable: false),
                    CantidadTomada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionPedidoOrigenes", x => new { x.PlantaCode, x.CotizacionCode, x.ArticuloCode, x.PedidoCode, x.PedidoItemNumber });
                    table.ForeignKey(
                        name: "FK_CotizacionPedidoOrigenes_CotizacionDetalles_PlantaCode_CotizacionCode_ArticuloCode",
                        columns: x => new { x.PlantaCode, x.CotizacionCode, x.ArticuloCode },
                        principalSchema: "logistica",
                        principalTable: "CotizacionDetalles",
                        principalColumns: new[] { "PlantaCode", "CotizacionCode", "ArticuloCode" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CotizacionPedidoOrigenes_PedidoDetalles_PlantaCode_PedidoCode_PedidoItemNumber",
                        columns: x => new { x.PlantaCode, x.PedidoCode, x.PedidoItemNumber },
                        principalSchema: "logistica",
                        principalTable: "PedidoDetalles",
                        principalColumns: new[] { "PlantaCode", "PedidoCode", "ItemNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionProveedorDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    CotizacionCode = table.Column<string>(type: "char(6)", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    CantidadArticulo = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PrecioArticulo = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    DescuentoArticulo = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalLinea = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionProveedorDetalles", x => new { x.PlantaCode, x.CotizacionCode, x.ProveedorCode, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_CotizacionProveedorDetalles_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CotizacionProveedorDetalles_CotizacionProveedores_PlantaCode_CotizacionCode_ProveedorCode",
                        columns: x => new { x.PlantaCode, x.CotizacionCode, x.ProveedorCode },
                        principalSchema: "logistica",
                        principalTable: "CotizacionProveedores",
                        principalColumns: new[] { "PlantaCode", "CotizacionCode", "ProveedorCode" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionDetalles_ArticuloCode",
                schema: "logistica",
                table: "CotizacionDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_PlantaCode_OriginalCode",
                schema: "logistica",
                table: "Cotizaciones",
                columns: new[] { "PlantaCode", "OriginalCode" });

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionPedidoOrigenes_PlantaCode_PedidoCode_PedidoItemNumber",
                schema: "logistica",
                table: "CotizacionPedidoOrigenes",
                columns: new[] { "PlantaCode", "PedidoCode", "PedidoItemNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionProveedorDetalles_ArticuloCode",
                schema: "logistica",
                table: "CotizacionProveedorDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionProveedores_MonedaCode",
                schema: "logistica",
                table: "CotizacionProveedores",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionProveedores_ProveedorCode",
                schema: "logistica",
                table: "CotizacionProveedores",
                column: "ProveedorCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotizacionPedidoOrigenes",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "CotizacionProveedorDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "CotizacionDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "CotizacionProveedores",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Cotizaciones",
                schema: "logistica");

            migrationBuilder.DropColumn(
                name: "CantidadCotizada",
                schema: "logistica",
                table: "PedidoDetalles");
        }
    }
}
