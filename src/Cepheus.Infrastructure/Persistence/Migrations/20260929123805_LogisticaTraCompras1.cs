using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cepheus.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LogisticaTraCompras1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AffectsFonavi",
                schema: "comun",
                table: "TiposDocumento");

            migrationBuilder.DropColumn(
                name: "AffectsForeignIgv",
                schema: "comun",
                table: "TiposDocumento");

            migrationBuilder.DropColumn(
                name: "AffectsIgv",
                schema: "comun",
                table: "TiposDocumento");

            migrationBuilder.DropColumn(
                name: "AffectsIncomeTax",
                schema: "comun",
                table: "TiposDocumento");

            migrationBuilder.DropColumn(
                name: "AvailableForPurchaseOrder",
                schema: "comun",
                table: "TiposDocumento");

            migrationBuilder.DropColumn(
                name: "IsNonTaxable",
                schema: "comun",
                table: "TiposDocumento");

            migrationBuilder.DropColumn(
                name: "IsService",
                schema: "comun",
                table: "TiposDocumento");

            migrationBuilder.AddColumn<string>(
                name: "TrabajadorCode",
                schema: "admin",
                table: "Users",
                type: "char(5)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CantidadEnCompra",
                schema: "logistica",
                table: "PedidoDetalles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "AffectsFonavi",
                schema: "comun",
                table: "ComprobantesPago",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AffectsForeignIgv",
                schema: "comun",
                table: "ComprobantesPago",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AffectsIgv",
                schema: "comun",
                table: "ComprobantesPago",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AffectsIncomeTax",
                schema: "comun",
                table: "ComprobantesPago",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvailableForPurchaseOrder",
                schema: "comun",
                table: "ComprobantesPago",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNonTaxable",
                schema: "comun",
                table: "ComprobantesPago",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsService",
                schema: "comun",
                table: "ComprobantesPago",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AlturasLosa",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    ConcreteProductoTipoCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    ConcreteProductoCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    PolystyreneProductoTipoCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    PolystyreneProductoCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    PolystyreneValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PolystyreneWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlturasLosa", x => x.Code);
                    table.ForeignKey(
                        name: "FK_AlturasLosa_Productos_ConcreteProductoTipoCode_ConcreteProductoCode",
                        columns: x => new { x.ConcreteProductoTipoCode, x.ConcreteProductoCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlturasLosa_Productos_PolystyreneProductoTipoCode_PolystyreneProductoCode",
                        columns: x => new { x.PolystyreneProductoTipoCode, x.PolystyreneProductoCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fletes",
                schema: "facturacion",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fletes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "NotasCotizacionPlantilla",
                schema: "facturacion",
                columns: table => new
                {
                    NegocioCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasCotizacionPlantilla", x => new { x.NegocioCode, x.Code });
                    table.ForeignKey(
                        name: "FK_NotasCotizacionPlantilla_Negocios_NegocioCode",
                        column: x => x.NegocioCode,
                        principalSchema: "comun",
                        principalTable: "Negocios",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesCompra",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(6)", nullable: false),
                    TipoCompraCode = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    ComprobantePagoId = table.Column<int>(type: "int", nullable: true),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProveedorCode = table.Column<string>(type: "char(5)", nullable: false),
                    CompradorCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    MonedaCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    LugarEnvioCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    FormaPagoCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    TramiteCode = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Observaciones1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Observaciones2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NotaCompraCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    UnidadNegocioCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false, defaultValue: "000000"),
                    EnviarCorreoProveedor = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    AprobadoPor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MotivoRetraso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NetoCompra = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    IgvCompra = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    TotalCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    NoGravableCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    RentaCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    FonaviCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    ServicioCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    IgvExteriorCompra = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesCompra", x => new { x.PlantaCode, x.Code });
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_Compradores_CompradorCode",
                        column: x => x.CompradorCode,
                        principalSchema: "logistica",
                        principalTable: "Compradores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_ComprobantesPago_ComprobantePagoId",
                        column: x => x.ComprobantePagoId,
                        principalSchema: "comun",
                        principalTable: "ComprobantesPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_FormasPago_FormaPagoCode",
                        column: x => x.FormaPagoCode,
                        principalSchema: "logistica",
                        principalTable: "FormasPago",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_LugaresEnvio_LugarEnvioCode",
                        column: x => x.LugarEnvioCode,
                        principalSchema: "logistica",
                        principalTable: "LugaresEnvio",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_Monedas_MonedaCode",
                        column: x => x.MonedaCode,
                        principalSchema: "comun",
                        principalTable: "Monedas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_NotasCompra_NotaCompraCode",
                        column: x => x.NotaCompraCode,
                        principalSchema: "logistica",
                        principalTable: "NotasCompra",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_Plantas_PlantaCode",
                        column: x => x.PlantaCode,
                        principalSchema: "comun",
                        principalTable: "Plantas",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_Proveedores_ProveedorCode",
                        column: x => x.ProveedorCode,
                        principalSchema: "logistica",
                        principalTable: "Proveedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_TiposCompra_TipoCompraCode",
                        column: x => x.TipoCompraCode,
                        principalSchema: "logistica",
                        principalTable: "TiposCompra",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_Tramites_TramiteCode",
                        column: x => x.TramiteCode,
                        principalSchema: "logistica",
                        principalTable: "Tramites",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_UnidadesNegocio_UnidadNegocioCode",
                        column: x => x.UnidadNegocioCode,
                        principalSchema: "logistica",
                        principalTable: "UnidadesNegocio",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                schema: "facturacion",
                columns: table => new
                {
                    TrabajadorCode = table.Column<string>(type: "char(5)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.TrabajadorCode);
                    table.ForeignKey(
                        name: "FK_Tecnicos_Trabajadores_TrabajadorCode",
                        column: x => x.TrabajadorCode,
                        principalSchema: "rrhh",
                        principalTable: "Trabajadores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreciosProducto",
                schema: "facturacion",
                columns: table => new
                {
                    FleteCode = table.Column<string>(type: "char(2)", nullable: false),
                    ProductoTipoCode = table.Column<string>(type: "char(2)", nullable: false),
                    ProductoCode = table.Column<string>(type: "char(4)", nullable: false),
                    CurrencyTypeCode = table.Column<string>(type: "char(1)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "S"),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    TransportAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    FreightAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreciosProducto", x => new { x.FleteCode, x.ProductoTipoCode, x.ProductoCode, x.CurrencyTypeCode, x.CurrencyCode });
                    table.ForeignKey(
                        name: "FK_PreciosProducto_Fletes_FleteCode",
                        column: x => x.FleteCode,
                        principalSchema: "facturacion",
                        principalTable: "Fletes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PreciosProducto_Productos_ProductoTipoCode_ProductoCode",
                        columns: x => new { x.ProductoTipoCode, x.ProductoCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompraDetalles",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    OrdenCompraCode = table.Column<string>(type: "char(6)", nullable: false),
                    ArticuloCode = table.Column<string>(type: "char(7)", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    CantidadArticulo = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    PrecioArticulo = table.Column<decimal>(type: "decimal(12,6)", nullable: false, defaultValue: 0m),
                    DescuentoArticulo = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    TotalArticulo = table.Column<decimal>(type: "decimal(12,2)", nullable: false, defaultValue: 0m),
                    CantidadEntregada = table.Column<decimal>(type: "decimal(12,5)", nullable: false, defaultValue: 0m),
                    SubCentroCostoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompraDetalles", x => new { x.PlantaCode, x.OrdenCompraCode, x.ArticuloCode });
                    table.ForeignKey(
                        name: "FK_OrdenCompraDetalles_Articulos_ArticuloCode",
                        column: x => x.ArticuloCode,
                        principalSchema: "logistica",
                        principalTable: "Articulos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenCompraDetalles_OrdenesCompra_PlantaCode_OrdenCompraCode",
                        columns: x => new { x.PlantaCode, x.OrdenCompraCode },
                        principalSchema: "logistica",
                        principalTable: "OrdenesCompra",
                        principalColumns: new[] { "PlantaCode", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenCompraDetalles_SubCentrosCosto_SubCentroCostoCode",
                        column: x => x.SubCentroCostoCode,
                        principalSchema: "logistica",
                        principalTable: "SubCentrosCosto",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                schema: "facturacion",
                columns: table => new
                {
                    NegocioCode = table.Column<string>(type: "char(2)", nullable: false),
                    Year = table.Column<string>(type: "char(4)", nullable: false),
                    Month = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(8)", nullable: false),
                    VendedorCode = table.Column<string>(type: "char(4)", maxLength: 4, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrencyCode = table.Column<string>(type: "char(1)", nullable: false),
                    FormaPagoVentaCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    TecnicoCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: true),
                    AppliesIgv = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    GlobalVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    WorkDurationMonths = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ClienteCode = table.Column<string>(type: "char(5)", maxLength: 5, nullable: true),
                    Ruc = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClientAddress = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
                    ClientAddressUbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false, defaultValue: "150101"),
                    ObraCode = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    WorkName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    WorkAddressUbigeoCode = table.Column<string>(type: "char(6)", maxLength: 6, nullable: false, defaultValue: "150101"),
                    WorkAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DispatchDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FleteCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false, defaultValue: "01"),
                    IgvRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    ProcessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GrossAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IgvAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    OriginNegocioCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    OriginYear = table.Column<string>(type: "char(4)", maxLength: 4, nullable: true),
                    OriginMonth = table.Column<string>(type: "char(2)", maxLength: 2, nullable: true),
                    OriginCode = table.Column<string>(type: "char(8)", maxLength: 8, nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CanceledBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CanceledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPrinted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => new { x.NegocioCode, x.Year, x.Month, x.Code });
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Clientes_ClienteCode",
                        column: x => x.ClienteCode,
                        principalSchema: "facturacion",
                        principalTable: "Clientes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Cotizaciones_OriginNegocioCode_OriginYear_OriginMonth_OriginCode",
                        columns: x => new { x.OriginNegocioCode, x.OriginYear, x.OriginMonth, x.OriginCode },
                        principalSchema: "facturacion",
                        principalTable: "Cotizaciones",
                        principalColumns: new[] { "NegocioCode", "Year", "Month", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Fletes_FleteCode",
                        column: x => x.FleteCode,
                        principalSchema: "facturacion",
                        principalTable: "Fletes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_FormasPagoVenta_FormaPagoVentaCode",
                        column: x => x.FormaPagoVentaCode,
                        principalSchema: "facturacion",
                        principalTable: "FormasPagoVenta",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Negocios_NegocioCode",
                        column: x => x.NegocioCode,
                        principalSchema: "comun",
                        principalTable: "Negocios",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Obras_ClienteCode_ObraCode",
                        columns: x => new { x.ClienteCode, x.ObraCode },
                        principalSchema: "facturacion",
                        principalTable: "Obras",
                        principalColumns: new[] { "ClienteCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Tecnicos_TecnicoCode",
                        column: x => x.TecnicoCode,
                        principalSchema: "facturacion",
                        principalTable: "Tecnicos",
                        principalColumn: "TrabajadorCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Ubigeos_ClientAddressUbigeoCode",
                        column: x => x.ClientAddressUbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Ubigeos_WorkAddressUbigeoCode",
                        column: x => x.WorkAddressUbigeoCode,
                        principalSchema: "comun",
                        principalTable: "Ubigeos",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Vendedores_VendedorCode",
                        column: x => x.VendedorCode,
                        principalSchema: "facturacion",
                        principalTable: "Vendedores",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompraPedidoOrigenes",
                schema: "logistica",
                columns: table => new
                {
                    PlantaCode = table.Column<string>(type: "char(2)", nullable: false),
                    OrdenCompraCode = table.Column<string>(type: "char(6)", nullable: false),
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
                    table.PrimaryKey("PK_OrdenCompraPedidoOrigenes", x => new { x.PlantaCode, x.OrdenCompraCode, x.ArticuloCode, x.PedidoCode, x.PedidoItemNumber });
                    table.ForeignKey(
                        name: "FK_OrdenCompraPedidoOrigenes_OrdenCompraDetalles_PlantaCode_OrdenCompraCode_ArticuloCode",
                        columns: x => new { x.PlantaCode, x.OrdenCompraCode, x.ArticuloCode },
                        principalSchema: "logistica",
                        principalTable: "OrdenCompraDetalles",
                        principalColumns: new[] { "PlantaCode", "OrdenCompraCode", "ArticuloCode" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenCompraPedidoOrigenes_PedidoDetalles_PlantaCode_PedidoCode_PedidoItemNumber",
                        columns: x => new { x.PlantaCode, x.PedidoCode, x.PedidoItemNumber },
                        principalSchema: "logistica",
                        principalTable: "PedidoDetalles",
                        principalColumns: new[] { "PlantaCode", "PedidoCode", "ItemNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionesDetalle",
                schema: "facturacion",
                columns: table => new
                {
                    NegocioCode = table.Column<string>(type: "char(2)", nullable: false),
                    Year = table.Column<string>(type: "char(4)", nullable: false),
                    Month = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(8)", nullable: false),
                    Item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoTipoCode = table.Column<string>(type: "char(2)", nullable: false),
                    ProductoCode = table.Column<string>(type: "char(4)", nullable: false),
                    UnitCode = table.Column<string>(type: "char(2)", maxLength: 5, nullable: false, defaultValue: ""),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    Observations = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    DeliveredQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionesDetalle", x => new { x.NegocioCode, x.Year, x.Month, x.Code, x.Item });
                    table.ForeignKey(
                        name: "FK_CotizacionesDetalle_Cotizaciones_NegocioCode_Year_Month_Code",
                        columns: x => new { x.NegocioCode, x.Year, x.Month, x.Code },
                        principalSchema: "facturacion",
                        principalTable: "Cotizaciones",
                        principalColumns: new[] { "NegocioCode", "Year", "Month", "Code" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CotizacionesDetalle_Productos_ProductoTipoCode_ProductoCode",
                        columns: x => new { x.ProductoTipoCode, x.ProductoCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CotizacionesDetalle_UnidadesMedidaVenta_UnitCode",
                        column: x => x.UnitCode,
                        principalSchema: "facturacion",
                        principalTable: "UnidadesMedidaVenta",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionesMetradoResumen",
                schema: "facturacion",
                columns: table => new
                {
                    NegocioCode = table.Column<string>(type: "char(2)", nullable: false),
                    Year = table.Column<string>(type: "char(4)", nullable: false),
                    Month = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(8)", nullable: false),
                    LevelNumber = table.Column<int>(type: "int", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AlturaLosaCode = table.Column<string>(type: "char(2)", nullable: false),
                    OverloadOrShortage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LinealMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalVaults = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalMeters = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PricePerM2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    Quantity = table.Column<decimal>(type: "decimal(18,0)", nullable: false, defaultValue: 0m),
                    BuildingLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HasTransport = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    TotalVaultsAlt = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalMetersAlt = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TotalPriceAlt = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    PricePerM2Alt = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    HasMinPrice = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MinTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    MinTotalAlt = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    MinTotalB = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    MinTotalAltB = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    HasTransportB = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    HasMinPriceB = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionesMetradoResumen", x => new { x.NegocioCode, x.Year, x.Month, x.Code, x.LevelNumber });
                    table.ForeignKey(
                        name: "FK_CotizacionesMetradoResumen_AlturasLosa_AlturaLosaCode",
                        column: x => x.AlturaLosaCode,
                        principalSchema: "facturacion",
                        principalTable: "AlturasLosa",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CotizacionesMetradoResumen_Cotizaciones_NegocioCode_Year_Month_Code",
                        columns: x => new { x.NegocioCode, x.Year, x.Month, x.Code },
                        principalSchema: "facturacion",
                        principalTable: "Cotizaciones",
                        principalColumns: new[] { "NegocioCode", "Year", "Month", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionesNotas",
                schema: "facturacion",
                columns: table => new
                {
                    NegocioCode = table.Column<string>(type: "char(2)", nullable: false),
                    Year = table.Column<string>(type: "char(4)", nullable: false),
                    Month = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(8)", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Option = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionesNotas", x => new { x.NegocioCode, x.Year, x.Month, x.Code, x.Sequence });
                    table.ForeignKey(
                        name: "FK_CotizacionesNotas_Cotizaciones_NegocioCode_Year_Month_Code",
                        columns: x => new { x.NegocioCode, x.Year, x.Month, x.Code },
                        principalSchema: "facturacion",
                        principalTable: "Cotizaciones",
                        principalColumns: new[] { "NegocioCode", "Year", "Month", "Code" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionesMetradoDetalle",
                schema: "facturacion",
                columns: table => new
                {
                    NegocioCode = table.Column<string>(type: "char(2)", nullable: false),
                    Year = table.Column<string>(type: "char(4)", nullable: false),
                    Month = table.Column<string>(type: "char(2)", nullable: false),
                    Code = table.Column<string>(type: "char(8)", nullable: false),
                    LevelNumber = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<string>(type: "char(3)", nullable: false),
                    ProductoTipoCode = table.Column<string>(type: "char(2)", nullable: false),
                    ProductoCode = table.Column<string>(type: "char(4)", nullable: false),
                    PanelCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, defaultValue: ""),
                    Times = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    InnerLength = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    OuterLength = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    Support = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    TotalMaterial = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    VaultCount = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    WastePercentage = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    Row = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    QuantityB = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    Support2 = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    Width = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    Area = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    MaterialPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    MaterialIgv = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    TransportPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    VaultPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    VaultTotalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    MaterialPriceAlt = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    TransportPriceAlt = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    VaultPriceAlt = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    VaultTotalPriceAlt = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    SortOrder = table.Column<string>(type: "char(3)", nullable: false, defaultValue: "00"),
                    DeliveredTotalMaterial = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    DeliveredQuantityB = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    PolystyrenePrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    PolystyreneTotalPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    PolystyrenePriceAlt = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    PolystyreneTotalPriceAlt = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    Widening = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    SupportP = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    WastePercentageP = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    QuantityP = table.Column<decimal>(type: "decimal(18,6)", nullable: false, defaultValue: 0m),
                    HasAnchorage = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Spacing = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionesMetradoDetalle", x => new { x.NegocioCode, x.Year, x.Month, x.Code, x.LevelNumber, x.Order, x.ProductoTipoCode, x.ProductoCode });
                    table.ForeignKey(
                        name: "FK_CotizacionesMetradoDetalle_CotizacionesMetradoResumen_NegocioCode_Year_Month_Code_LevelNumber",
                        columns: x => new { x.NegocioCode, x.Year, x.Month, x.Code, x.LevelNumber },
                        principalSchema: "facturacion",
                        principalTable: "CotizacionesMetradoResumen",
                        principalColumns: new[] { "NegocioCode", "Year", "Month", "Code", "LevelNumber" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CotizacionesMetradoDetalle_Productos_ProductoTipoCode_ProductoCode",
                        columns: x => new { x.ProductoTipoCode, x.ProductoCode },
                        principalSchema: "facturacion",
                        principalTable: "Productos",
                        principalColumns: new[] { "TipoProductoCode", "Code" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_TrabajadorCode",
                schema: "admin",
                table: "Users",
                column: "TrabajadorCode");

            migrationBuilder.CreateIndex(
                name: "IX_AlturasLosa_ConcreteProductoTipoCode_ConcreteProductoCode",
                schema: "facturacion",
                table: "AlturasLosa",
                columns: new[] { "ConcreteProductoTipoCode", "ConcreteProductoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_AlturasLosa_Name",
                schema: "facturacion",
                table: "AlturasLosa",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlturasLosa_PolystyreneProductoTipoCode_PolystyreneProductoCode",
                schema: "facturacion",
                table: "AlturasLosa",
                columns: new[] { "PolystyreneProductoTipoCode", "PolystyreneProductoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_ClientAddressUbigeoCode",
                schema: "facturacion",
                table: "Cotizaciones",
                column: "ClientAddressUbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_ClienteCode",
                schema: "facturacion",
                table: "Cotizaciones",
                column: "ClienteCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_ClienteCode_ObraCode",
                schema: "facturacion",
                table: "Cotizaciones",
                columns: new[] { "ClienteCode", "ObraCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_Date",
                schema: "facturacion",
                table: "Cotizaciones",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_FleteCode",
                schema: "facturacion",
                table: "Cotizaciones",
                column: "FleteCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_FormaPagoVentaCode",
                schema: "facturacion",
                table: "Cotizaciones",
                column: "FormaPagoVentaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_OriginNegocioCode_OriginYear_OriginMonth_OriginCode",
                schema: "facturacion",
                table: "Cotizaciones",
                columns: new[] { "OriginNegocioCode", "OriginYear", "OriginMonth", "OriginCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_Status",
                schema: "facturacion",
                table: "Cotizaciones",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_TecnicoCode",
                schema: "facturacion",
                table: "Cotizaciones",
                column: "TecnicoCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_VendedorCode",
                schema: "facturacion",
                table: "Cotizaciones",
                column: "VendedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_WorkAddressUbigeoCode",
                schema: "facturacion",
                table: "Cotizaciones",
                column: "WorkAddressUbigeoCode");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionesDetalle_ProductoTipoCode_ProductoCode",
                schema: "facturacion",
                table: "CotizacionesDetalle",
                columns: new[] { "ProductoTipoCode", "ProductoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionesDetalle_UnitCode",
                schema: "facturacion",
                table: "CotizacionesDetalle",
                column: "UnitCode");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionesMetradoDetalle_ProductoTipoCode_ProductoCode",
                schema: "facturacion",
                table: "CotizacionesMetradoDetalle",
                columns: new[] { "ProductoTipoCode", "ProductoCode" });

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionesMetradoResumen_AlturaLosaCode",
                schema: "facturacion",
                table: "CotizacionesMetradoResumen",
                column: "AlturaLosaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Fletes_Name",
                schema: "facturacion",
                table: "Fletes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotasCotizacionPlantilla_Option",
                schema: "facturacion",
                table: "NotasCotizacionPlantilla",
                column: "Option");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalles_ArticuloCode",
                schema: "logistica",
                table: "OrdenCompraDetalles",
                column: "ArticuloCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalles_SubCentroCostoCode",
                schema: "logistica",
                table: "OrdenCompraDetalles",
                column: "SubCentroCostoCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraPedidoOrigenes_PlantaCode_PedidoCode_PedidoItemNumber",
                schema: "logistica",
                table: "OrdenCompraPedidoOrigenes",
                columns: new[] { "PlantaCode", "PedidoCode", "PedidoItemNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_CompradorCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "CompradorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_ComprobantePagoId",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "ComprobantePagoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_FormaPagoCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "FormaPagoCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_LugarEnvioCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "LugarEnvioCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_MonedaCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "MonedaCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_NotaCompraCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "NotaCompraCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_ProveedorCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "ProveedorCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_TipoCompraCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "TipoCompraCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_TramiteCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "TramiteCode");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_UnidadNegocioCode",
                schema: "logistica",
                table: "OrdenesCompra",
                column: "UnidadNegocioCode");

            migrationBuilder.CreateIndex(
                name: "IX_PreciosProducto_ProductoTipoCode_ProductoCode",
                schema: "facturacion",
                table: "PreciosProducto",
                columns: new[] { "ProductoTipoCode", "ProductoCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Trabajadores_TrabajadorCode",
                schema: "admin",
                table: "Users",
                column: "TrabajadorCode",
                principalSchema: "rrhh",
                principalTable: "Trabajadores",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Trabajadores_TrabajadorCode",
                schema: "admin",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CotizacionesDetalle",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "CotizacionesMetradoDetalle",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "CotizacionesNotas",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "NotasCotizacionPlantilla",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "OrdenCompraPedidoOrigenes",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "PreciosProducto",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "CotizacionesMetradoResumen",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "OrdenCompraDetalles",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "AlturasLosa",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "Cotizaciones",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "OrdenesCompra",
                schema: "logistica");

            migrationBuilder.DropTable(
                name: "Fletes",
                schema: "facturacion");

            migrationBuilder.DropTable(
                name: "Tecnicos",
                schema: "facturacion");

            migrationBuilder.DropIndex(
                name: "IX_Users_TrabajadorCode",
                schema: "admin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrabajadorCode",
                schema: "admin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CantidadEnCompra",
                schema: "logistica",
                table: "PedidoDetalles");

            migrationBuilder.DropColumn(
                name: "AffectsFonavi",
                schema: "comun",
                table: "ComprobantesPago");

            migrationBuilder.DropColumn(
                name: "AffectsForeignIgv",
                schema: "comun",
                table: "ComprobantesPago");

            migrationBuilder.DropColumn(
                name: "AffectsIgv",
                schema: "comun",
                table: "ComprobantesPago");

            migrationBuilder.DropColumn(
                name: "AffectsIncomeTax",
                schema: "comun",
                table: "ComprobantesPago");

            migrationBuilder.DropColumn(
                name: "AvailableForPurchaseOrder",
                schema: "comun",
                table: "ComprobantesPago");

            migrationBuilder.DropColumn(
                name: "IsNonTaxable",
                schema: "comun",
                table: "ComprobantesPago");

            migrationBuilder.DropColumn(
                name: "IsService",
                schema: "comun",
                table: "ComprobantesPago");

            migrationBuilder.AddColumn<bool>(
                name: "AffectsFonavi",
                schema: "comun",
                table: "TiposDocumento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AffectsForeignIgv",
                schema: "comun",
                table: "TiposDocumento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AffectsIgv",
                schema: "comun",
                table: "TiposDocumento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AffectsIncomeTax",
                schema: "comun",
                table: "TiposDocumento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvailableForPurchaseOrder",
                schema: "comun",
                table: "TiposDocumento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNonTaxable",
                schema: "comun",
                table: "TiposDocumento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsService",
                schema: "comun",
                table: "TiposDocumento",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
