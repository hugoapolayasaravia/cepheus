using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialLogisticaMaestrosPart1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Plantas",
                schema: "comun",
                table: "Plantas");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "comun",
                table: "Plantas");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TiposDocumento_Code",
                schema: "comun",
                table: "TiposDocumento",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plantas",
                schema: "comun",
                table: "Plantas",
                column: "Code");

            migrationBuilder.CreateTable(
                name: "Articulos",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    UnidadMedidaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    SubFamiliaCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    MinStock = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    MaxStock = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    IncomingStock = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    LeadTimeDays = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    AbcClass = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    TipoArticuloCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    PlanCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ManufacturerCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Observations = table.Column<string>(type: "varchar(max)", nullable: false, defaultValue: ""),
                    SalesTypeCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    SalesProductCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    IsAgreement = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AccountingAccountCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    AccountingAttachmentTypeCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PlantOriginCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Articulos_PlanesArticulo_PlanCode",
                        column: x => x.PlanCode,
                        principalSchema: "logistica",
                        principalTable: "PlanesArticulo",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_Plantas_PlantOriginCode",
                        column: x => x.PlantOriginCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_SubFamilias_SubFamiliaCode",
                        column: x => x.SubFamiliaCode,
                        principalSchema: "logistica",
                        principalTable: "SubFamilias",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_TiposArticulo_TipoArticuloCode",
                        column: x => x.TipoArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "TiposArticulo",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articulos_UnidadesMedida_UnidadMedidaCode",
                        column: x => x.UnidadMedidaCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesMedida",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bancos",
                schema: "comun",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CentrosCosto",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlantaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosCosto", x => x.Code);
                    table.ForeignKey(
                        name: "FK_CentrosCosto_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conductores",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DocumentTypeCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LicenseCategory = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Conductores_TiposDocumento_DocumentTypeCode",
                        column: x => x.DocumentTypeCode,
                        principalSchema: "comun",
                        principalTable: "TiposDocumento",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ControlCierres",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PeriodCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    ClosureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DifferenceAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlCierres", x => new { x.PlantaCode, x.PeriodCode });
                    table.ForeignKey(
                        name: "FK_ControlCierres_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DocumentTypeCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TradeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ProviderType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SunatCondition = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SunatStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DeactivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Proveedores_TiposDocumento_DocumentTypeCode",
                        column: x => x.DocumentTypeCode,
                        principalSchema: "comun",
                        principalTable: "TiposDocumento",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transportistas",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DocumentTypeCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TradeName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UbigeoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MtcRegistrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsOwnFleet = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportistas", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Transportistas_TiposDocumento_DocumentTypeCode",
                        column: x => x.DocumentTypeCode,
                        principalSchema: "comun",
                        principalTable: "TiposDocumento",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transportistas_Ubigeos_UbigeoCode",
                        column: x => x.UbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockArticulos",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ArticuloCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    UnitCost = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    UnitCostUsd = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    AverageCost = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MinStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    MaxStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockArticulos", x => new { x.PlantaCode, x.ArticuloCode });
                    table.CheckConstraint("CK_StockArticulos_Quantity_NonNegative", "[Quantity] >= 0");
                    table.ForeignKey(
                        name: "FK_StockArticulos_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockArticulos_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCentrosCosto",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CentroCostoCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountingAccountCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    AccountingAttachmentTypeCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    PlantaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ParentCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCentrosCosto", x => x.Code);
                    table.ForeignKey(
                        name: "FK_SubCentrosCosto_CentrosCosto_CentroCostoCode",
                        column: x => x.CentroCostoCode,
                        principalSchema: "logistica",
                        principalTable: "CentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubCentrosCosto_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubCentrosCosto_SubCentrosCosto_ParentCode",
                        column: x => x.ParentCode,
                        principalSchema: "logistica",
                        principalTable: "SubCentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticuloProveedor",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ArticuloCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    ProveedorCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    IsAgreement = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AgreementPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloProveedor", x => new { x.PlantaCode, x.ArticuloCode, x.ProveedorCode });
                    table.ForeignKey(
                        name: "FK_ArticuloProveedor_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticuloProveedor_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticuloProveedor_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorCondiciones",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FormaPagoCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PaymentTermDays = table.Column<int>(type: "int", nullable: false),
                    MonedaCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorCondiciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProveedorCondiciones_FormasPago_FormaPagoCode",
                        column: x => x.FormaPagoCode,
                        principalSchema: "logistica",
                        principalTable: "FormasPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProveedorCondiciones_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProveedorCondiciones_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorContactos",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorContactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProveedorContactos_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorCuentas",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    BancoCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InterbankCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MonedaCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorCuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProveedorCuentas_Bancos_BancoCode",
                        column: x => x.BancoCode,
                        principalSchema: "comun",
                        principalTable: "Bancos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProveedorCuentas_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProveedorCuentas_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorDirecciones",
                schema: "logistica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    AddressType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UbigeoCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorDirecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProveedorDirecciones_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProveedorDirecciones_Ubigeos_UbigeoCode",
                        column: x => x.UbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                schema: "logistica",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TransportistaCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VehicleCategory = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    VehicleType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManufactureYear = table.Column<short>(type: "smallint", nullable: true),
                    EngineNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChassisNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CargoCapacityKg = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    LengthM = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    WidthM = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    HeightM = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    VehicularCertificateNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CirculationCardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VehicularConfiguration = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Transportistas_TransportistaCode",
                        column: x => x.TransportistaCode,
                        principalSchema: "logistica",
                        principalTable: "Transportistas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloProveedor_ArticuloCode",
                schema: "logistica",
                table: "ArticuloProveedor",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloProveedor_ProveedorCode",
                schema: "logistica",
                table: "ArticuloProveedor",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_PlanCode",
                schema: "logistica",
                table: "Articulos",
                column: "PlanCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_PlantOriginCode",
                schema: "logistica",
                table: "Articulos",
                column: "PlantOriginCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_SubFamiliaCode",
                schema: "logistica",
                table: "Articulos",
                column: "SubFamiliaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_TipoArticuloCode",
                schema: "logistica",
                table: "Articulos",
                column: "TipoArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_UnidadMedidaCode",
                schema: "logistica",
                table: "Articulos",
                column: "UnidadMedidaCode");

            migrationBuilder.CreateIndex(
                name: "IX_CentrosCosto_PlantaCode",
                schema: "logistica",
                table: "CentrosCosto",
                column: "PlantaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Conductores_DocumentTypeCode_DocumentNumber",
                schema: "logistica",
                table: "Conductores",
                columns: new[] { "DocumentTypeCode", "DocumentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conductores_DriverLicenseNumber",
                schema: "logistica",
                table: "Conductores",
                column: "DriverLicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCondiciones_FormaPagoCode",
                schema: "logistica",
                table: "ProveedorCondiciones",
                column: "FormaPagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCondiciones_MonedaCode",
                schema: "logistica",
                table: "ProveedorCondiciones",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCondiciones_ProveedorCode",
                schema: "logistica",
                table: "ProveedorCondiciones",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorContactos_ProveedorCode",
                schema: "logistica",
                table: "ProveedorContactos",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCuentas_BancoCode",
                schema: "logistica",
                table: "ProveedorCuentas",
                column: "BancoCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCuentas_MonedaCode",
                schema: "logistica",
                table: "ProveedorCuentas",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorCuentas_ProveedorCode",
                schema: "logistica",
                table: "ProveedorCuentas",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorDirecciones_ProveedorCode",
                schema: "logistica",
                table: "ProveedorDirecciones",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorDirecciones_UbigeoCode",
                schema: "logistica",
                table: "ProveedorDirecciones",
                column: "UbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_DocumentNumber",
                schema: "logistica",
                table: "Proveedores",
                column: "DocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_DocumentTypeCode",
                schema: "logistica",
                table: "Proveedores",
                column: "DocumentTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_LegalName",
                schema: "logistica",
                table: "Proveedores",
                column: "LegalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockArticulos_ArticuloCode",
                schema: "logistica",
                table: "StockArticulos",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCentrosCosto_CentroCostoCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                column: "CentroCostoCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCentrosCosto_ParentCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                column: "ParentCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCentrosCosto_PlantaCode",
                schema: "logistica",
                table: "SubCentrosCosto",
                column: "PlantaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Transportistas_DocumentTypeCode_DocumentNumber",
                schema: "logistica",
                table: "Transportistas",
                columns: new[] { "DocumentTypeCode", "DocumentNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportistas_LegalName",
                schema: "logistica",
                table: "Transportistas",
                column: "LegalName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportistas_UbigeoCode",
                schema: "logistica",
                table: "Transportistas",
                column: "UbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_LicensePlate",
                schema: "logistica",
                table: "Vehiculos",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TransportistaCode",
                schema: "logistica",
                table: "Vehiculos",
                column: "TransportistaCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticuloProveedor",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Conductores",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ControlCierres",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ProveedorCondiciones",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ProveedorContactos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ProveedorCuentas",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "ProveedorDirecciones",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "StockArticulos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "SubCentrosCosto",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Vehiculos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Bancos",
                schema: "comun");

            migrationBuilder.DropTable(
                name: "Proveedores",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Articulos",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "CentrosCosto",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Transportistas",
                schema: "logistica");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TiposDocumento_Code",
                schema: "comun",
                table: "TiposDocumento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Plantas",
                schema: "comun",
                table: "Plantas");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "comun",
                table: "Plantas",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "comun",
                table: "Plantas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Plantas",
                schema: "comun",
                table: "Plantas",
                column: "Id");
        }
    }
}
