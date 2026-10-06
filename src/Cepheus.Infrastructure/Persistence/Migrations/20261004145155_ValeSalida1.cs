using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ValeSalida1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequiresHorometro",
                schema: "logistica",
                table: "Articulos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TiposValeArticulo",
                schema: "logistica",
                columns: table => new
                {
                    TipoValeCode = table.Column<string>(type: "char(3)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposValeArticulo", x => new { x.TipoValeCode, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_TiposValeArticulo_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposValeArticulo_TiposVale_TipoValeCode",
                        column: x => x.TipoValeCode,
                        principalSchema: "logistica",
                        principalTable: "TiposVale",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vales",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(7)", nullable: false),
                    TipoValeCode = table.Column<string>(type: "char(3)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubCentroCostoCode = table.Column<string>(type: "char(6)", nullable: false),
                    SubCentroEjecutorCode = table.Column<string>(type: "char(4)", nullable: true),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    OrdenTrabajoCode = table.Column<string>(type: "char(6)", nullable: true),
                    UnidadNegocioCode = table.Column<string>(type: "char(6)", nullable: false),
                    PlantaAfectadaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Neto = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Igv = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    AsientoContable = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    AprobadoPor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesadoPor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaProcesado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnuladoPor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Preparado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vales", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_Vales_OrdenesTrabajo_PlantaCode_OrdenTrabajoCode",
                        columns: x => new { x.PlantaCode, x.OrdenTrabajoCode },
                        principalSchema: "mantenimiento",
                        principalTable: "OrdenesTrabajo",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vales_Plantas_PlantaAfectadaCode",
                        column: x => x.PlantaAfectadaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vales_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vales_SubCentrosCosto_SubCentroCostoCode",
                        column: x => x.SubCentroCostoCode,
                        principalSchema: "logistica",
                        principalTable: "SubCentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vales_SubCentrosEjecutores_SubCentroEjecutorCode",
                        column: x => x.SubCentroEjecutorCode,
                        principalSchema: "mantenimiento",
                        principalTable: "SubCentrosEjecutores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vales_TiposVale_TipoValeCode",
                        column: x => x.TipoValeCode,
                        principalSchema: "logistica",
                        principalTable: "TiposVale",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vales_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vales_UnidadesNegocio_UnidadNegocioCode",
                        column: x => x.UnidadNegocioCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesNegocio",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValeDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    ValeCode = table.Column<string>(type: "char(7)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    AsientoContable = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Propiedad01 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    MaterialOtFechaProceso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValeDetalles", x => new { x.PlantaCode, x.ValeCode, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_ValeDetalles_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValeDetalles_Vales_PlantaCode_ValeCode",
                        columns: x => new { x.PlantaCode, x.ValeCode },
                        principalSchema: "logistica",
                        principalTable: "Vales",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TiposValeArticulo_ArticuloCode",
                schema: "logistica",
                table: "TiposValeArticulo",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_ValeDetalles_ArticuloCode",
                schema: "logistica",
                table: "ValeDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_ValeDetalles_PlantaCode_ArticuloCode_Estado",
                schema: "logistica",
                table: "ValeDetalles",
                columns: new[] { "PlantaCode", "ArticuloCode", "Estado" });

            migrationBuilder.CreateIndex(
                name: "IX_ValeDetalles_PlantaCode_ValeCode_ItemNumber",
                schema: "logistica",
                table: "ValeDetalles",
                columns: new[] { "PlantaCode", "ValeCode", "ItemNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Vales_PlantaAfectadaCode",
                schema: "logistica",
                table: "Vales",
                column: "PlantaAfectadaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vales_PlantaCode_CreatedAt",
                schema: "logistica",
                table: "Vales",
                columns: new[] { "PlantaCode", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_Vales_PlantaCode_Estado",
                schema: "logistica",
                table: "Vales",
                columns: new[] { "PlantaCode", "Estado" });

            migrationBuilder.CreateIndex(
                name: "IX_Vales_PlantaCode_OrdenTrabajoCode",
                schema: "logistica",
                table: "Vales",
                columns: new[] { "PlantaCode", "OrdenTrabajoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Vales_SubCentroCostoCode",
                schema: "logistica",
                table: "Vales",
                column: "SubCentroCostoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vales_SubCentroEjecutorCode",
                schema: "logistica",
                table: "Vales",
                column: "SubCentroEjecutorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vales_TipoValeCode",
                schema: "logistica",
                table: "Vales",
                column: "TipoValeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vales_TrabajadorCode",
                schema: "logistica",
                table: "Vales",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vales_UnidadNegocioCode",
                schema: "logistica",
                table: "Vales",
                column: "UnidadNegocioCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposValeArticulo",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ValeDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Vales",
                schema: "logistica");

            migrationBuilder.DropColumn(
                name: "RequiresHorometro",
                schema: "logistica",
                table: "Articulos");
        }
    }
}
