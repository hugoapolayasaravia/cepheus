using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class hojadecorte1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposHojaCorte",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHojaCorte", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "HojasCorte",
                schema: "facturacion",
                columns: table => new
                {
                    Year = table.Column<string>(type: "char(4)", nullable: false),
                    Code = table.Column<string>(type: "char(8)", nullable: false),
                    TipoHojaCorteCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    ClienteCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ObraCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    WorkName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    WorkAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    WorkAddressUbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    TecnicoCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    VendedorCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    ViguetaDispatchDate = table.Column<DateTime>(type: "date", nullable: true),
                    BovedillaDispatchDate = table.Column<DateTime>(type: "date", nullable: true),
                    ClientViguetaDispatchDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientBovedillaDispatchDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StorageDate = table.Column<DateTime>(type: "date", nullable: true),
                    OrdenTrabajoCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ParentYear = table.Column<string>(type: "char(4)", nullable: true),
                    ParentCode = table.Column<string>(type: "char(8)", nullable: true),
                    Turn = table.Column<int>(type: "int", nullable: false),
                    IsModifiable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Motivo = table.Column<int>(type: "int", nullable: true),
                    ProductType = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojasCorte", x => new { x.Year, x.Code });
                    table.ForeignKey(
                        name: "FK_HojasCorte_Clientes_ClienteCode",
                        column: x => x.ClienteCode,
                        principalSchema: "facturacion",
                        principalTable: "Clientes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojasCorte_HojasCorte_ParentYear_ParentCode",
                        columns: x => new { x.ParentYear, x.ParentCode },
                        principalSchema: "facturacion",
                        principalTable: "HojasCorte",
                        principalColumns: new[] { "Year", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojasCorte_Obras_ClienteCode_ObraCode",
                        columns: x => new { x.ClienteCode, x.ObraCode },
                        principalSchema: "facturacion",
                        principalTable: "Obras",
                        principalColumns: new[] { "ClienteCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojasCorte_Tecnicos_TecnicoCode",
                        column: x => x.TecnicoCode,
                        principalSchema: "facturacion",
                        principalTable: "Tecnicos",
                        principalColumn: "TrabajadorCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojasCorte_TiposHojaCorte_TipoHojaCorteCode",
                        column: x => x.TipoHojaCorteCode,
                        principalSchema: "facturacion",
                        principalTable: "TiposHojaCorte",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojasCorte_Ubigeos_WorkAddressUbigeoCode",
                        column: x => x.WorkAddressUbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojasCorte_Vendedores_VendedorCode",
                        column: x => x.VendedorCode,
                        principalSchema: "facturacion",
                        principalTable: "Vendedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HojaCorteDetalles",
                schema: "facturacion",
                columns: table => new
                {
                    Year = table.Column<string>(type: "char(4)", nullable: false),
                    HojaCorteCode = table.Column<string>(type: "char(8)", nullable: false),
                    ProductoTipoCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    ProductoCode = table.Column<string>(type: "char(4)", maxLength: 8, nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    UnitCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Panel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CablesSide1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CablesSide2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Lot1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lot2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lot3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojaCorteDetalles", x => new { x.Year, x.HojaCorteCode, x.ProductoTipoCode, x.ProductoCode, x.ItemNumber });
                    table.ForeignKey(
                        name: "FK_HojaCorteDetalles_HojasCorte_Year_HojaCorteCode",
                        columns: x => new { x.Year, x.HojaCorteCode },
                        principalSchema: "facturacion",
                        principalTable: "HojasCorte",
                        principalColumns: new[] { "Year", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HojaCorteDetalles_Productos_ProductoTipoCode_ProductoCode",
                        columns: x => new { x.ProductoTipoCode, x.ProductoCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojaCorteDetalles_UnidadesMedidaVenta_UnitCode",
                        column: x => x.UnitCode,
                        principalSchema: "facturacion",
                        principalTable: "UnidadesMedidaVenta",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HojaCorteDetalles_ProductoTipoCode_ProductoCode",
                schema: "facturacion",
                table: "HojaCorteDetalles",
                columns: new[] { "ProductoTipoCode", "ProductoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_HojaCorteDetalles_UnitCode",
                schema: "facturacion",
                table: "HojaCorteDetalles",
                column: "UnitCode");

            migrationBuilder.CreateIndex(
                name: "IX_HojasCorte_ClienteCode",
                schema: "facturacion",
                table: "HojasCorte",
                column: "ClienteCode");

            migrationBuilder.CreateIndex(
                name: "IX_HojasCorte_ClienteCode_ObraCode",
                schema: "facturacion",
                table: "HojasCorte",
                columns: new[] { "ClienteCode", "ObraCode" });

            migrationBuilder.CreateIndex(
                name: "IX_HojasCorte_Date",
                schema: "facturacion",
                table: "HojasCorte",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_HojasCorte_OrdenTrabajoCode",
                schema: "facturacion",
                table: "HojasCorte",
                column: "OrdenTrabajoCode");

            migrationBuilder.CreateIndex(
                name: "IX_HojasCorte_ParentYear_ParentCode",
                schema: "facturacion",
                table: "HojasCorte",
                columns: new[] { "ParentYear", "ParentCode" });

            migrationBuilder.CreateIndex(
                name: "IX_HojasCorte_Status",
                schema: "facturacion",
                table: "HojasCorte",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_HojasCorte_TecnicoCode",
                schema: "facturacion",
                table: "HojasCorte",
                column: "TecnicoCode");

            migrationBuilder.CreateIndex(
                name: "IX_HojasCorte_TipoHojaCorteCode",
                schema: "facturacion",
                table: "HojasCorte",
                column: "TipoHojaCorteCode");

            migrationBuilder.CreateIndex(
                name: "IX_HojasCorte_VendedorCode",
                schema: "facturacion",
                table: "HojasCorte",
                column: "VendedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_HojasCorte_WorkAddressUbigeoCode",
                schema: "facturacion",
                table: "HojasCorte",
                column: "WorkAddressUbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_TiposHojaCorte_Name",
                schema: "facturacion",
                table: "TiposHojaCorte",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HojaCorteDetalles",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "HojasCorte",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "TiposHojaCorte",
                schema: "facturacion");
        }
    }
}
