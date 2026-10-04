using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrdenServicio3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesServicio_Trabajadores_TrabajadorCode",
                schema: "logistica",
                table: "OrdenesServicio");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesServicio_TrabajadorCode",
                schema: "logistica",
                table: "OrdenesServicio");

            migrationBuilder.DropColumn(
                name: "FechaProcesado",
                schema: "logistica",
                table: "OrdenesServicio");

            migrationBuilder.DropColumn(
                name: "TrabajadorCode",
                schema: "logistica",
                table: "OrdenesServicio");

            migrationBuilder.AddColumn<string>(
                name: "ValeSalidaCode",
                schema: "logistica",
                table: "OrdenesServicio",
                type: "char(6)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OrdenesServicioSalida",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    Neto = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Igv = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    AsientoContable = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    AprobadoPor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProcesadoPor = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FechaProcesado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesServicioSalida", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_OrdenesServicioSalida_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesServicioSalida_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenServicioSalidaDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    SalidaCode = table.Column<string>(type: "char(6)", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    Glosa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    AsientoContable = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Propiedad01 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
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
                    table.PrimaryKey("PK_OrdenServicioSalidaDetalles", x => new { x.PlantaCode, x.SalidaCode, x.ItemNumber });
                    table.ForeignKey(
                        name: "FK_OrdenServicioSalidaDetalles_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicioSalidaDetalles_OrdenesServicioSalida_PlantaCode_SalidaCode",
                        columns: x => new { x.PlantaCode, x.SalidaCode },
                        principalSchema: "logistica",
                        principalTable: "OrdenesServicioSalida",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenServicioSalidaDetalles_OrdenesTrabajo_PlantaCode_OrdenTrabajoCode",
                        columns: x => new { x.PlantaCode, x.OrdenTrabajoCode },
                        principalSchema: "mantenimiento",
                        principalTable: "OrdenesTrabajo",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicioSalidaDetalles_Plantas_PlantaAfectadaCode",
                        column: x => x.PlantaAfectadaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicioSalidaDetalles_SubCentrosCosto_SubCentroCostoCode",
                        column: x => x.SubCentroCostoCode,
                        principalSchema: "logistica",
                        principalTable: "SubCentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicioSalidaDetalles_SubCentrosEjecutores_SubCentroEjecutorCode",
                        column: x => x.SubCentroEjecutorCode,
                        principalSchema: "mantenimiento",
                        principalTable: "SubCentrosEjecutores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenServicioSalidaDetalles_TiposVale_TipoValeCode",
                        column: x => x.TipoValeCode,
                        principalSchema: "logistica",
                        principalTable: "TiposVale",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_PlantaCode_ValeSalidaCode",
                schema: "logistica",
                table: "OrdenesServicio",
                columns: new[] { "PlantaCode", "ValeSalidaCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicioSalida_PlantaCode_CreatedAt",
                schema: "logistica",
                table: "OrdenesServicioSalida",
                columns: new[] { "PlantaCode", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicioSalida_TrabajadorCode",
                schema: "logistica",
                table: "OrdenesServicioSalida",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioSalidaDetalles_ArticuloCode",
                schema: "logistica",
                table: "OrdenServicioSalidaDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioSalidaDetalles_PlantaAfectadaCode",
                schema: "logistica",
                table: "OrdenServicioSalidaDetalles",
                column: "PlantaAfectadaCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioSalidaDetalles_PlantaCode_OrdenTrabajoCode",
                schema: "logistica",
                table: "OrdenServicioSalidaDetalles",
                columns: new[] { "PlantaCode", "OrdenTrabajoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioSalidaDetalles_SubCentroCostoCode",
                schema: "logistica",
                table: "OrdenServicioSalidaDetalles",
                column: "SubCentroCostoCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioSalidaDetalles_SubCentroEjecutorCode",
                schema: "logistica",
                table: "OrdenServicioSalidaDetalles",
                column: "SubCentroEjecutorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenServicioSalidaDetalles_TipoValeCode",
                schema: "logistica",
                table: "OrdenServicioSalidaDetalles",
                column: "TipoValeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesServicio_OrdenesServicioSalida_PlantaCode_ValeSalidaCode",
                schema: "logistica",
                table: "OrdenesServicio",
                columns: new[] { "PlantaCode", "ValeSalidaCode" },
                principalSchema: "logistica",
                principalTable: "OrdenesServicioSalida",
                principalColumns: new[] { "PlantaCode", "Code" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesServicio_OrdenesServicioSalida_PlantaCode_ValeSalidaCode",
                schema: "logistica",
                table: "OrdenesServicio");

            migrationBuilder.DropTable(
                name: "OrdenServicioSalidaDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "OrdenesServicioSalida",
                schema: "logistica");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesServicio_PlantaCode_ValeSalidaCode",
                schema: "logistica",
                table: "OrdenesServicio");

            migrationBuilder.DropColumn(
                name: "ValeSalidaCode",
                schema: "logistica",
                table: "OrdenesServicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaProcesado",
                schema: "logistica",
                table: "OrdenesServicio",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrabajadorCode",
                schema: "logistica",
                table: "OrdenesServicio",
                type: "char(5)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesServicio_TrabajadorCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "TrabajadorCode");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesServicio_Trabajadores_TrabajadorCode",
                schema: "logistica",
                table: "OrdenesServicio",
                column: "TrabajadorCode",
                principalSchema: "rrhh",
                principalTable: "Trabajadores",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
