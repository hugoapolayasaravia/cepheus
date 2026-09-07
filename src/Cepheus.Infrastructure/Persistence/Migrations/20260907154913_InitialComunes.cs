using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialComunes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "comun");

            migrationBuilder.CreateTable(
                name: "ComprobantesPago",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SunatCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RequiresRuc = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RequiresAddress = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobantesPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlesVentas",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IgvPercentage = table.Column<decimal>(type: "numeric(24,2)", nullable: false),
                    WithholdingPercentage = table.Column<decimal>(type: "numeric(24,2)", nullable: false),
                    ClosingPeriod = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    SalesProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasesProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesCancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchasesCancelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithholdingCap = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    DetractionPercentage = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    IncomeTaxPercentage = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    FonaviPercentage = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    ForeignIgvPercentage = table.Column<decimal>(type: "numeric(5,2)", nullable: false),
                    QuotaPercentage = table.Column<decimal>(type: "numeric(6,2)", nullable: false),
                    BlocksGrouping = table.Column<bool>(type: "bit", nullable: false),
                    WithholdingCapInvoice = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    WorkOrderDaysLimit = table.Column<int>(type: "int", nullable: false),
                    WorkOrderMaxDays = table.Column<int>(type: "int", nullable: false),
                    SaleMaxDays = table.Column<int>(type: "int", nullable: false),
                    BalanceLimit = table.Column<int>(type: "int", nullable: true),
                    AdditionalActivationDays = table.Column<int>(type: "int", nullable: true),
                    IsServiceIndicator = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlesVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monedas",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NumericCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DecimalPlaces = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivosDevolucion",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AffectsStock = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosDevolucion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plantas",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AddressComplement = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UbigeoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    ManagerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HasWarehouse = table.Column<bool>(type: "bit", nullable: false),
                    IsProductionPlant = table.Column<bool>(type: "bit", nullable: false),
                    IsProject = table.Column<bool>(type: "bit", nullable: false),
                    RequiresApprovals = table.Column<bool>(type: "bit", nullable: false),
                    AppliesDetraction = table.Column<bool>(type: "bit", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposCambio",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    SellRate = table.Column<decimal>(type: "numeric(9,4)", nullable: false),
                    BuyRate = table.Column<decimal>(type: "numeric(9,4)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCambio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumento",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    SunatCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AffectsIgv = table.Column<bool>(type: "bit", nullable: false),
                    IsNonTaxable = table.Column<bool>(type: "bit", nullable: false),
                    AffectsIncomeTax = table.Column<bool>(type: "bit", nullable: false),
                    AffectsFonavi = table.Column<bool>(type: "bit", nullable: false),
                    IsService = table.Column<bool>(type: "bit", nullable: false),
                    AffectsForeignIgv = table.Column<bool>(type: "bit", nullable: false),
                    AvailableForPurchaseOrder = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ubigeos",
                schema: "comun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubigeos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesPago_Code",
                schema: "comun",
                table: "ComprobantesPago",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesPago_SunatCode",
                schema: "comun",
                table: "ComprobantesPago",
                column: "SunatCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monedas_Code",
                schema: "comun",
                table: "Monedas",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monedas_NumericCode",
                schema: "comun",
                table: "Monedas",
                column: "NumericCode",
                unique: true,
                filter: "[NumericCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MotivosDevolucion_Code",
                schema: "comun",
                table: "MotivosDevolucion",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_Code",
                schema: "comun",
                table: "Plantas",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposCambio_Date",
                schema: "comun",
                table: "TiposCambio",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposDocumento_Code",
                schema: "comun",
                table: "TiposDocumento",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ubigeos_Code",
                schema: "comun",
                table: "Ubigeos",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ubigeos_Department_Province_District",
                schema: "comun",
                table: "Ubigeos",
                columns: new[] { "Department", "Province", "District" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprobantesPago",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "ControlesVentas",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "Monedas",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "MotivosDevolucion",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "Plantas",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "TiposCambio",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "TiposDocumento",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "Ubigeos",
                schema: "comun");
        }
    }
}
